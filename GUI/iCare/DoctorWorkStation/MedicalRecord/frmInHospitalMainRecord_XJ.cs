using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.Controls;
using System.Windows.Forms;
using System.Data;
using iCareData;
using com.digitalwave.DataShareService;
using com.digitalwave.common.ICD10.Tool;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    /// 住院病案首页---新疆
    /// </summary>
    public partial class frmInHospitalMainRecord_XJ : frmHRPBaseForm, PublicFunction
    {

        #region Define

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIDCardTitle;
        private System.Windows.Forms.Label lblOccupationTitle;
        private System.Windows.Forms.Label lblNationTitle;
        private System.Windows.Forms.Label lblNationalityTitle;
        private System.Windows.Forms.Label lblMarriedTitle;
        private System.Windows.Forms.Label lblOfficePCTitle;
        private System.Windows.Forms.Label lblOfficeAddressTitle;
        private System.Windows.Forms.Label lblOfficePhoneTitle;
        private System.Windows.Forms.Label lblHmePCTitle;
        private System.Windows.Forms.Label lblHomeAddressTitle;
        private System.Windows.Forms.Label lblInHospitalSetionTitle;
        private System.Windows.Forms.Label lblMasterDiagnose;
        private System.Windows.Forms.DataGrid dtgOperation;
        private System.Windows.Forms.Label lblDeliveryChild;
        private System.Windows.Forms.Label lblOperationAmt;
        private System.Windows.Forms.Label lblBloodTran;
        private System.Windows.Forms.Label lblO2;
        private System.Windows.Forms.Label lblAssayAmt;
        private System.Windows.Forms.Label lblRadiationAmt;
        private System.Windows.Forms.Label lblWMAmt;
        private System.Windows.Forms.Label lblBedAmt;
        private System.Windows.Forms.Label lblTotalAmt;
    
        private System.Windows.Forms.Label lblHomePlaceTitle;
        private System.Windows.Forms.Label lblOutHospitalDateTitle;
        private System.Windows.Forms.Label lblInSickRoomTitle;
        private System.Windows.Forms.Label lblInHospitalDaysTitle;
        private System.Windows.Forms.Label lblOutSickRoomTitle;
        private System.Windows.Forms.Label lblOutHospitalSetionTitle;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblDiagnosisTitle;
        private com.digitalwave.controls.ctlRichTextBox txtMainDiagnosis;
        private System.Windows.Forms.Label lblConditionTitle;
        private com.digitalwave.controls.ctlRichTextBox txtICD_10OfMain;
        private System.Windows.Forms.Label lblRTTitle;
        private System.Windows.Forms.GroupBox gpbRTMode;
        private System.Windows.Forms.RadioButton rdbRTAssistant;
        private System.Windows.Forms.RadioButton rdbRTCure;
        private System.Windows.Forms.RadioButton rdbRTAppeasement;
        private System.Windows.Forms.GroupBox gpbRTEquipment;
        private System.Windows.Forms.CheckBox chkRTLacuna;
        private System.Windows.Forms.CheckBox chkRTX_Ray;
        private System.Windows.Forms.CheckBox chkRTAccelerator;
        private System.Windows.Forms.GroupBox gpbRTRule;
        private System.Windows.Forms.RadioButton rdbRTSection;
        private System.Windows.Forms.RadioButton rdbContinue;
        private System.Windows.Forms.RadioButton rdbRTGap;
        private System.Windows.Forms.GroupBox gpbOriginalDisease;
        private System.Windows.Forms.RadioButton rdbOriginalDiseaseRepeat;
        private System.Windows.Forms.RadioButton rdbOriginalDiseaseFirst;
        private System.Windows.Forms.Label lblOriginalDiseaseTitle;
        private System.Windows.Forms.Label lblOriginalDiseaseDose;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit3;
        private com.digitalwave.controls.ctlRichTextBox txtOriginalDiseaseGy;
        private com.digitalwave.controls.ctlRichTextBox txtOriginalDiseaseTimes;
        private com.digitalwave.controls.ctlRichTextBox txtOriginalDiseaseDays;
        private System.Windows.Forms.Label lblOriginalDiseaseBeginDateTitle;
        private System.Windows.Forms.Label lblOriginalDiseaseTo;
        private System.Windows.Forms.Label lblLymphToTitle;
        private System.Windows.Forms.Label lblLymphBeginDateTitle;
        private com.digitalwave.controls.ctlRichTextBox txtLymphDays;
        private com.digitalwave.controls.ctlRichTextBox txtLymphTimes;
        private com.digitalwave.controls.ctlRichTextBox txtLymphGy;
        private System.Windows.Forms.Label lblLymphUnit1;
        private System.Windows.Forms.Label lblLymphUnit2;
        private System.Windows.Forms.Label lblLympUnit3;
        private System.Windows.Forms.Label lblLymphDose;
        private System.Windows.Forms.Label lblLymphTitle;
        private System.Windows.Forms.GroupBox gpbLymph;
        private System.Windows.Forms.RadioButton rdbLymphRepeat;
        private System.Windows.Forms.RadioButton rdbLymphFirst;
        private System.Windows.Forms.Label lblMetastasisTo;
        private System.Windows.Forms.Label lblMetastasisBeginDateTitle;
        private com.digitalwave.controls.ctlRichTextBox txtMetastasisDays;
        private com.digitalwave.controls.ctlRichTextBox txtMetastasisTimes;
        private com.digitalwave.controls.ctlRichTextBox txtMetastasisGy;
        private System.Windows.Forms.Label lblMetastasisUnit1;
        private System.Windows.Forms.Label lblMetastasisUnit2;
        private System.Windows.Forms.Label lblMetastasisUnit3;
        private System.Windows.Forms.Label lblMetastasisDose;
        private System.Windows.Forms.Label lblMetastasisTitle;
        private System.Windows.Forms.Label lblChemotherapyTitle;
        private System.Windows.Forms.GroupBox gpbChemotherapyMode;
        private System.Windows.Forms.RadioButton rdbChemotherapyNewMedicine;
        private System.Windows.Forms.RadioButton rdbChemotherapyAssistant;
        private System.Windows.Forms.RadioButton rdbChemotherapyAssisantNew;
        private System.Windows.Forms.RadioButton rdbChemotherapyAppeasement;
        private System.Windows.Forms.RadioButton rdbChemotherapyCure;
        private System.Windows.Forms.GroupBox gpbChemotherapyRule;
        private System.Windows.Forms.CheckBox chkChemotherapyOther;
        private System.Windows.Forms.CheckBox chkChemotherapyOtherTry;
        private System.Windows.Forms.CheckBox chkChemotherapySpinal;
        private System.Windows.Forms.CheckBox chkChemotherapyAbdomen;
        private System.Windows.Forms.CheckBox chkChemotherapyThorax;
        private System.Windows.Forms.CheckBox chkChemotherapyIntubate;
        private System.Windows.Forms.CheckBox chkChemotherapyLocal;
        private System.Windows.Forms.CheckBox chkChemotherapyWholeBody;
        private System.Windows.Forms.DataGrid dtgChemotherapy;
        private System.Windows.Forms.Label lblCMFinishedAmt;
        private com.digitalwave.controls.ctlRichTextBox txtTotalAmt;
        private com.digitalwave.controls.ctlRichTextBox txtRadiationAmt;
        private com.digitalwave.controls.ctlRichTextBox txtBedAmt;
        private com.digitalwave.controls.ctlRichTextBox txtDeliveryChildAmt;
        private com.digitalwave.controls.ctlRichTextBox txtBloodAmt;
        private com.digitalwave.controls.ctlRichTextBox txtAssayAmt;
        private com.digitalwave.controls.ctlRichTextBox txtCMFinishedAmt;
        private com.digitalwave.controls.ctlRichTextBox txtOperationAmt;
        private com.digitalwave.controls.ctlRichTextBox txtWMAmt;
        private com.digitalwave.controls.ctlRichTextBox txtO2Amt;
        private com.digitalwave.controls.ctlRichTextBox txtCMSemiFinishedAmt;
        private System.Windows.Forms.Label lblCMSemiFinishedTitle;
        private com.digitalwave.controls.ctlRichTextBox txtNurseAmt;
        private System.Windows.Forms.Label lblNurseAmt;
        private com.digitalwave.controls.ctlRichTextBox txtTreatmentAmt;
        private System.Windows.Forms.Label lblTreatmentAmt;
        private com.digitalwave.controls.ctlRichTextBox txtOtherAmt1;
        private System.Windows.Forms.Label lblOtherAmt1;
        private com.digitalwave.controls.ctlRichTextBox txtBabyAmt;
        private com.digitalwave.controls.ctlRichTextBox txtAnaethesiaAmt;
        private com.digitalwave.controls.ctlRichTextBox txtAccompanyAmt;
        private com.digitalwave.controls.ctlRichTextBox txtCheckAmt;
        private System.Windows.Forms.Label lblAccompanyAmt;
        private System.Windows.Forms.Label lblBabyAmt;
        private System.Windows.Forms.Label lblAnaethisiaAmt;
        private System.Windows.Forms.Label lblCheckAmt;
        private com.digitalwave.controls.ctlRichTextBox txtOtherAmt2;
        private com.digitalwave.controls.ctlRichTextBox txtOtherAmt3;
        private System.Windows.Forms.Label lblComma;
        private System.Windows.Forms.Label lblComma2;
        private System.Windows.Forms.Label lblCorpseCheck;
        private System.Windows.Forms.Label lblFirstCaseTitle;
        private System.Windows.Forms.Label lblFollowTitle;
        private com.digitalwave.controls.ctlRichTextBox txtFollow_Week;
        private System.Windows.Forms.Label lblFollowDate;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label lblFollowMonth;
        private com.digitalwave.controls.ctlRichTextBox txtFollow_Month;
        private System.Windows.Forms.Label lblFollowYear;
        private com.digitalwave.controls.ctlRichTextBox txtFollow_Year;
        private System.Windows.Forms.Label lblModelCaseTitle;
        private System.Windows.Forms.Label lblBloodTransAction;
        private System.Windows.Forms.Label lblBloodTypeDesp;
        private com.digitalwave.controls.ctlRichTextBox txtBloodType;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblBloodRh;
        private com.digitalwave.controls.ctlRichTextBox txtRBC;
        private System.Windows.Forms.Label lblRBCUnit;
        private System.Windows.Forms.Label lblBloodComponent;
        private com.digitalwave.controls.ctlRichTextBox txtPLT;
        private System.Windows.Forms.Label lblUnit10;
        private System.Windows.Forms.Label lblPLT;
        private com.digitalwave.controls.ctlRichTextBox txtPlasm;
        private System.Windows.Forms.Label lblUnit11;
        private System.Windows.Forms.Label lblPlasm;
        private com.digitalwave.controls.ctlRichTextBox txtWholeBlood;
        private System.Windows.Forms.Label lblUnit13;
        private System.Windows.Forms.Label lblWholeBlood;
        private com.digitalwave.controls.ctlRichTextBox txtOtherBlood;
        private System.Windows.Forms.Label lblUnit14;
        private System.Windows.Forms.Label lblOtherBlood;
        private com.digitalwave.controls.ctlRichTextBox txtNurseLevelI;
        private System.Windows.Forms.Label lblNurseLevelI;
        private com.digitalwave.controls.ctlRichTextBox txtTOPLevel;
        private System.Windows.Forms.Label lblUnit21;
        private System.Windows.Forms.Label lblNurseLevel;
        private com.digitalwave.controls.ctlRichTextBox txtLongDistanctConsultation;
        private System.Windows.Forms.Label lblLongDistanceConsultation;
        private com.digitalwave.controls.ctlRichTextBox txtConsultation;
        private System.Windows.Forms.Label lblUnit15;
        private System.Windows.Forms.Label lblConsultation;
        private System.Windows.Forms.Label lblUnit20;
        private System.Windows.Forms.Label lblUnit22;
        private System.Windows.Forms.Label lblUnit23;
        private com.digitalwave.controls.ctlRichTextBox txtNurseLevelII;
        private System.Windows.Forms.Label lblNurseLevelII;
        private System.Windows.Forms.Label lblUnit24;
        private com.digitalwave.controls.ctlRichTextBox txtNurseLevelIII;
        private System.Windows.Forms.Label lblNurseLevelIII;
        private com.digitalwave.controls.ctlRichTextBox txtICU;
        private System.Windows.Forms.Label lblUnit25;
        private System.Windows.Forms.Label lblICU;
        private System.Windows.Forms.Label lblUnit26;
        private com.digitalwave.controls.ctlRichTextBox txtSpecialNurse;
        private System.Windows.Forms.Label lblSpecialNurse;
        private System.Windows.Forms.GroupBox gpbLine3;
        private System.Windows.Forms.Label lblInsuranceDesp1;
        private System.Windows.Forms.Label lblTimesTitle;
        private System.Windows.Forms.Label lblTimesInHospital;
        private System.Windows.Forms.Label lblModeOfPaymentTitle;
        private com.digitalwave.controls.ctlRichTextBox txtInsuranceNum;
        private System.Windows.Forms.Label lblInuranceTitle;
        private System.Windows.Forms.Label lblProvince;
        private System.Windows.Forms.Label lblProvinceTitle;
        private System.Windows.Forms.Label lblPatientHistoryNO;

        #endregion

        #region
        private com.digitalwave.controls.ctlRichTextBox txtPatientHistoryNO;
        private System.Windows.Forms.DataGridTextBoxColumn dtcDept;
        private System.Windows.Forms.DataGrid dtgChangeDept2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dtcChangeDept;
        private System.Windows.Forms.DataGridTableStyle dtcChemotherapy;
        private System.Windows.Forms.DataGridTextBoxColumn dtcDate;
        private System.Windows.Forms.DataGridTextBoxColumn dtcMedicineName;
        private System.Windows.Forms.DataGridTextBoxColumn dtcPeriod;
        private System.Windows.Forms.DataGridBoolColumn dtcCR;
        private System.Windows.Forms.DataGridBoolColumn dtcPR;
        private System.Windows.Forms.DataGridBoolColumn dtcMR;
        private System.Windows.Forms.DataGridBoolColumn dtcS;
        private System.Windows.Forms.DataGridBoolColumn dtcP;
        private System.Windows.Forms.DataGridBoolColumn dtcNA;
        private com.digitalwave.controls.ctlRichTextBox txtDiagnosis;
        private System.Windows.Forms.CheckBox chkRTCo;
        private System.Windows.Forms.GroupBox gpbCorpseCheck;
        private System.Windows.Forms.RadioButton rdbCorpseCheckNO;
        private System.Windows.Forms.RadioButton rdbCorpseCheckYes;
        private System.Windows.Forms.GroupBox gpbFirstCase;
        private System.Windows.Forms.RadioButton rdbFirstCaseNO;
        private System.Windows.Forms.RadioButton rdbFirstCaseYes;
        private System.Windows.Forms.GroupBox gpbModelCase;
        private System.Windows.Forms.RadioButton rdbModelCaseNO;
        private System.Windows.Forms.RadioButton rdbModelCaseYes;
        private System.Windows.Forms.RadioButton rdbBloodTransActionNO;
        private System.Windows.Forms.RadioButton rdbBloodTransActionYes;
        private System.Windows.Forms.GroupBox gpbFollow;
        private System.Windows.Forms.RadioButton rdbFollowNO;
        private System.Windows.Forms.RadioButton rdbFollowYes;
        private System.Windows.Forms.GroupBox gpbBloodRh;
        private System.Windows.Forms.RadioButton rdbBloodRh_An;
        private System.Windows.Forms.RadioButton rdbBloodRh_Ka;
        private System.Windows.Forms.GroupBox gpbBloodTransAction;
        private System.Windows.Forms.ListView lsvOperationEmployee;
        private System.Windows.Forms.ColumnHeader clmEmployeeID;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
        private System.Windows.Forms.ListView lsvAanaesthesiaMode;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
        private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
        private System.Windows.Forms.Label lblInHospitalDays;
        private System.Windows.Forms.Label lblInSickRoom;
        private System.Windows.Forms.Label lblOutSickRoom;
        private System.Windows.Forms.Label lblOutHospitalSetion;
        private System.Windows.Forms.Label lblInHosptialSetion;
        private System.Windows.Forms.Label lblTimes;
        private PinkieControls.ButtonXP m_cmdFillPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridTextBoxColumn dtcDiagnosis;
        private System.Windows.Forms.DataGridBoolColumn dtcHealOfMain;
        private System.Windows.Forms.DataGridBoolColumn dtcOnTheMendOfMain;
        private System.Windows.Forms.DataGridBoolColumn dtcNotCureOfMain;
        private System.Windows.Forms.DataGridBoolColumn dtcDieOfMain;
        private System.Windows.Forms.DataGridBoolColumn dtcNotDefineOfMain;
        private System.Windows.Forms.DataGridTextBoxColumn ICD10;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.ImageList imageList1;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCounty;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboCity;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboProvince;
        private TabControl tabControl2;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind;
        private Label m_lblOutHospitalDate;
        private ListView m_lsvTransDept;
        private ColumnHeader m_clmFromDept;
        private ColumnHeader m_clmTransDate;
        private ColumnHeader m_clmToDept;
        private TextBox m_txtSign;
        private PinkieControls.ButtonXP m_cmdSign;



        #endregion

        #region
        private ctlTimePicker m_dtpBirthDate;
        private TextBox m_txtNationality;
        private TextBox m_txtCountry;
        private TextBox m_txtOccupation;
        private TextBox m_txtOfficePC;
        private TextBox m_txtOfficeAddress;
        private TextBox m_txtIDCard;
        private TextBox m_txtHomePhone;
        private TextBox m_txtNation;
        private TextBox m_txtMarried;
        private TextBox m_txtHomeAddress;
        private TextBox m_txtHomePC;
        private TextBox m_txtCompanyName;
        private Label label1;
        private Panel panel3;
        private TextBox m_txtContactManAddress;
        private TextBox m_txtContactManPhone;
        private TextBox m_txtRelation;
        private TextBox m_txtContactMan;
        private TextBox m_txtLinkManzipcode;
        private Label label2;
        private Label lblContactManAddressTitle;
        private Label lblContactManTitle;
        private Label lblRelationTitle;
        private Label lblContactManPhoneTitle;
        private Label label4;
        private TextBox txtDiagnosisICD10;
        private DataGrid dgDiagnosis1;
        private ComboBox m_cboMainSeq;
        private Label label5;
        private DataGrid dgDiagnosis3;
        private DataGrid dgDiagnosis2;
        private DataGridTableStyle dataGridTableStyle2;
        private DataGridTextBoxColumn m_dgtbInDia;
        private DataGridTextBoxColumn m_dgtbInDiaICD;
        private DataGridTableStyle dataGridTableStyle3;
        private DataGridTableStyle dataGridTableStyle3z;
        private DataGridTextBoxColumn m_dgtbOtherDia;
        private DataGridTextBoxColumn m_dgtbOtherDiaICD;
        private DataGridTextBoxColumn m_dgtbOtherDiaz;
        private DataGridTextBoxColumn m_dgtbOtherDiaICDz;
        private DataGridTableStyle dataGridTableStyle4;
        private DataGridTableStyle dataGridTableStyle4z;
        private DataGridTextBoxColumn m_dgtbInfectionDia;
        private DataGridTextBoxColumn m_dgtbInfectionDiaICD;
        private DataGridTextBoxColumn m_dgtbInfectionDiaz;
        private DataGridTextBoxColumn m_dgtbInfectionDiaICDz;
        private DataGridTextBoxColumn m_dtcInfectionResult;
        private DataGridTextBoxColumn m_dtcInfectionResultz;
        private DataGridTextBoxColumn m_dtcOtherDiaResult;
        private DataGridTextBoxColumn m_dtcOtherDiaResultz;
        private System.Windows.Forms.TreeView trvTime;
        clsEmrSignToolCollection m_objSign;
        DataTable m_dtbInHospitalDiagnosis = null;
        DataTable m_dtbInHospitalDiagnosisZhong = null;
        private DataGridTableStyle dataGridTableStyle5;
        private DataGridTextBoxColumn m_dtcOperationID;
        private DataGridTextBoxColumn m_dtcOperationDate;
        private DataGridTextBoxColumn m_dtcOperationName;
        private DataGridTextBoxColumn m_dtcOperator;
        private DataGridTextBoxColumn m_dtcAssistant1;
        private DataGridTextBoxColumn m_dtcAssistant2;
        private DataGridTextBoxColumn m_dtcAnaesthesiaMode;
        private DataGridTextBoxColumn m_dtcCutLevel;
        private DataGridTextBoxColumn m_dtcAnaesthetist;
        DataTable m_dtbInfectionDiagnosis = null;
        DataTable m_dtbInfectionDiagnosisZhong = null;
        private DataView m_dtvICD = null;
        private DataView m_dtvOp = null;
        private DataView m_dtvEmp = null;
        private DataTable m_dtbICD = null;
        private DataTable m_dtbOp = null;
        private PinkieControls.ButtonXP m_cmdCommit;
        private DataTable m_dtbEmp = null;
        private DataTable m_dtbAna = null;
        private string m_strRegisterID = "";
        private Panel panel4;
        private RadioButton rdbBloodRh_No;
        private RadioButton rdbBloodTransNoAction;
        private Panel panel5;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpOriginalDiseaseBeginDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpMetastasisEndDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpLymphEndDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpOriginalDiseaseEndDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpMetastasisBeginDate;
        private com.digitalwave.Controls.ctlMaskedDateTimePicker dtpLymphBeginDate;
        #endregion 

        private DataView m_dtvAna = null;
        private int isFirstCellChange = 0;
        private ComboBox m_cboModeOfPayment;
        private Button button1;
        private Timer m_timShowTips;
        private bool m_blnIsDateRight = true;



        public frmInHospitalMainRecord_XJ()
        {
            InitializeComponent();

            //指明医生工作站表单
            intFormType = 1;

            m_mthSetRichTextBoxAttribInControl(this);

            m_objDomain = new clsInHospitalMainRecordDomain_XJ();

            #region DataTable Define
            m_mthInitDataTable();
            #endregion

            m_strOpenDate = null;
            m_bolIfHasSave = false;
            m_objPublicDomain = new clsPublicDomain();
            m_objCollection = new clsInHospitalMainRecord_Collection();

            m_mthSetControlReadOnly(this, true);

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(new Control[]{m_cmdAttendInForAdvancesStudyDt,m_cmdQCNurse,m_cmdCoder,m_cmdDoctor,m_cmdSign,
															 m_cmdDirectorDt,m_cmdSubDirectorDt,m_cmdQCDt,m_cmdDt,m_cmdGraduateStudentIntern,m_cmdInHospitalDt,m_cmdIntern},
                new Control[]{txtAttendInForAdvancesStudyDt,txtQCNurse,txtCoder,txtDoctor,m_txtSign,
								 txtDirectorDt,txtSubDirectorDt,txtQCDt,txtDt,txtGraduateStudentIntern,txtInHospitalDt,txtIntern},
                new int[] { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new bool[] { false, false, false, false, true, false, false, false, false, false, false, false });

            m_objShareDomain = new clsOperationRecordDoctorShareDomain();

        }
        
        private clsOperationRecordDoctorShareDomain m_objShareDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;
        private clsPatient m_objSelectedPatient;
        private clsInHospitalMainRecordDomain_XJ m_objDomain;
        private clsInHospitalMainRecord_Collection m_objCollection;

        /// <summary>
        /// 是否打印题目，打印预览时为true，套打时为false，进行套打前设置为true，套打后设置为false
        /// </summary>
        private static bool s_blnPrintTitle = true;

        /// <summary>
        /// 标志该次住院的住院病案首页是否已经生成过
        /// false -- 否   true -- 是
        /// </summary>
        private bool m_bolIfHasSave;
        /// <summary>
        /// 该次住院的住院病案首页生成时间
        /// </summary>
        private string m_strOpenDate;

        #region DataTable Define
        private DataTable m_dtbOtherDiagnosis;
        private DataTable m_dtbOtherDiagnosisz;
        //private DataTable m_dtbChangeDept;

        private DataTable m_dtbOperationDetail;

        private DataTable m_dtbBaby;

        private DataTable m_dtbChemotherapy;
        #endregion
        /// <summary>
        /// 存放当前获得焦点的RichTextBox(模糊查询人名用)
        /// </summary>
        private com.digitalwave.controls.ctlRichTextBox m_RtbCurrentTextBox;

        private clsPublicDomain m_objPublicDomain;

        public override int m_IntFormID
        {
            get
            {
                return 28;
            }
        }

        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                return "";
            }
        }
        #endregion 属性

        #region 模糊查询定义
        //		private clsRichTextListView m_objRichTextListView0;
        //		private clsRichTextListView m_objRichTextListView1;
        //		private clsRichTextListView m_objRichTextListView2;
        //		private clsRichTextListView m_objRichTextListView3;
        //		private clsRichTextListView m_objRichTextListView4;
        //		private clsRichTextListView m_objRichTextListView5;
        //		private clsRichTextListView m_objRichTextListView6;
        //		private clsRichTextListView m_objRichTextListView7;
        //		private clsRichTextListView m_objRichTextListView8;
        //		private clsRichTextListView m_objRichTextListView9;
        //		private clsRichTextListView m_objRichTextListView10;

        private clsGridListView m_objGridListView0;
        private clsGridListView m_objGridListView1;
        private clsGridListView m_objGridListView2;
        private clsGridListView m_objGridListView3;

        private clsGridListView m_objGridListView4;

        private Hashtable m_hasAanaesthesiaMode;

        /// <summary>
        /// 标志模糊查询时是否清空内容
        /// true -- 清空 false -- 不清空
        /// </summary>
        private bool m_bolIfChange = true;
        #endregion


        #region 初始化DataTable
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        private void m_mthInitDataTable()
        {
            DataColumn dtcTemp;

            #region 诊断

            #region   西医入院诊断

      

            m_dtbInHospitalDiagnosis = new DataTable("InDiagnosis");
            DataColumn dcInHos = this.m_dtbInHospitalDiagnosis.Columns.Add("诊断内容");
            dcInHos.DefaultValue = "";
            DataColumn dcInHosICD = this.m_dtbInHospitalDiagnosis.Columns.Add("ICD码");
            dcInHosICD.DefaultValue = "";

            this.m_dgtbInDia.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInDiaICD.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInDia.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbInDiaICD.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            dgDiagnosis1.DataSource = m_dtbInHospitalDiagnosis;
            #endregion
            #region  中医入院诊断
            m_dtbInHospitalDiagnosisZhong = new DataTable("InDiagnosisZhong");
            DataColumn dcInHosz = this.m_dtbInHospitalDiagnosisZhong.Columns.Add("诊断内容");
            dcInHosz.DefaultValue = "";
            DataColumn dcInHosICDz = this.m_dtbInHospitalDiagnosisZhong.Columns.Add("ICD码");
            dcInHosICDz.DefaultValue = "";

            this.m_dgtbInDiaz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInDiaICDz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInDiaz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbInDiaICDz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            dgDiagnosiszhongyi.DataSource = m_dtbInHospitalDiagnosisZhong;
            #endregion

            #region 西医出院诊断

            m_dtbOtherDiagnosis = new DataTable("OtherDiagnosis");
            DataColumn dc = this.m_dtbOtherDiagnosis.Columns.Add("诊断内容");
            dc.DefaultValue = "";

            DataColumn dcICD = this.m_dtbOtherDiagnosis.Columns.Add("ICD码");
            dcICD.DefaultValue = "";

            dtcTemp = new DataColumn("疗效");
            dtcTemp.DefaultValue = "";
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);

            this.m_dgtbOtherDia.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbOtherDiaICD.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbOtherDia.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbOtherDiaICD.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dgDiagnosis3.DataSource = m_dtbOtherDiagnosis;

            ComboBox cmbFunctionArea = new ComboBox();
            cmbFunctionArea.Items.AddRange(new object[] { "治愈", "好转", "未愈", "死亡", "其他", "" });
            cmbFunctionArea.Cursor = Cursors.Arrow;
            cmbFunctionArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionArea.Dock = DockStyle.Fill;
            //在选定项发生更改并且提交了该更改后发生 
            cmbFunctionArea.SelectionChangeCommitted += new System.EventHandler(cmbFunctionArea_SelectionChangeCommitted);
            cmbFunctionArea.Enter += new EventHandler(cmbFunctionArea_Enter);
            ///把ComboBox添加到DataGridTableStyle的第一列
            m_dtcOtherDiaResult.TextBox.Controls.Add(cmbFunctionArea);
            
            #endregion

            #region 中医出院诊断

            m_dtbOtherDiagnosisz = new DataTable("OtherDiagnosisz");
            DataColumn dcz = this.m_dtbOtherDiagnosisz.Columns.Add("诊断内容");
            dcz.DefaultValue = "";

            DataColumn dcICDz = this.m_dtbOtherDiagnosisz.Columns.Add("ICD码");
            dcICDz.DefaultValue = "";

            dtcTemp = new DataColumn("疗效");
            dtcTemp.DefaultValue = "";
            this.m_dtbOtherDiagnosisz.Columns.Add(dtcTemp);

            this.m_dgtbOtherDiaz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbOtherDiaICDz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbOtherDiaz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbOtherDiaICDz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dgDiagnosis3zhongyi.DataSource = m_dtbOtherDiagnosisz;

            ComboBox cmbFunctionAreaz = new ComboBox();
            cmbFunctionAreaz.Items.AddRange(new object[] { "治愈", "好转", "未愈", "死亡", "其他", "" });
            cmbFunctionAreaz.Cursor = Cursors.Arrow;
            cmbFunctionAreaz.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionAreaz.Dock = DockStyle.Fill;
            //在选定项发生更改并且提交了该更改后发生 
            cmbFunctionAreaz.SelectionChangeCommitted += new System.EventHandler(cmbFunctionArea_SelectionChangeCommitted);
            cmbFunctionAreaz.Enter += new EventHandler(cmbFunctionAreaz_Enter);
            ///把ComboBox添加到DataGridTableStyle的第一列
            m_dtcOtherDiaResultz.TextBox.Controls.Add(cmbFunctionAreaz);
            #endregion

            #region   感染名称
            m_dtbInfectionDiagnosis = new DataTable("InfectionDiagnosis");
            DataColumn dcInfection = this.m_dtbInfectionDiagnosis.Columns.Add("诊断内容");
            dcInfection.DefaultValue = "";

            DataColumn dcInfectionICD = this.m_dtbInfectionDiagnosis.Columns.Add("ICD码");
            dcInfectionICD.DefaultValue = "";

            dtcTemp = new DataColumn("疗效");
            dtcTemp.DefaultValue = "";
            m_dtbInfectionDiagnosis.Columns.Add(dtcTemp);

            this.m_dgtbInfectionDia.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInfectionDiaICD.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInfectionDia.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbInfectionDiaICD.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dgDiagnosis2.DataSource = m_dtbInfectionDiagnosis;

            ComboBox cmbFunctionAreaI = new ComboBox();
            cmbFunctionAreaI.Items.AddRange(new object[] { "治愈", "好转", "未愈", "死亡", "其他", "" });
            cmbFunctionAreaI.Cursor = Cursors.Arrow;
            cmbFunctionAreaI.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionAreaI.Dock = DockStyle.Fill;
            //在选定项发生更改并且提交了该更改后发生 
            cmbFunctionAreaI.SelectionChangeCommitted += new System.EventHandler(cmbFunctionArea_SelectionChangeCommitted);
            cmbFunctionAreaI.Enter += new EventHandler(cmbFunctionAreaI_Enter);
            ///把ComboBox添加到DataGridTableStyle的第一列
            m_dtcInfectionResult.TextBox.Controls.Add(cmbFunctionAreaI);
            #endregion

            #region   并发症名称
            m_dtbInfectionDiagnosisZhong = new DataTable("InfectionDiagnosisZhong");
            DataColumn dcInfectionz = this.m_dtbInfectionDiagnosisZhong.Columns.Add("诊断内容");
            dcInfectionz.DefaultValue = "";

            DataColumn dcInfectionICDz = this.m_dtbInfectionDiagnosisZhong.Columns.Add("ICD码");
            dcInfectionICDz.DefaultValue = "";

            dtcTemp = new DataColumn("疗效");
            dtcTemp.DefaultValue = "";
            m_dtbInfectionDiagnosisZhong.Columns.Add(dtcTemp);

            this.m_dgtbInfectionDiaz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInfectionDiaICDz.TextBox.KeyDown += new KeyEventHandler(this.m_mthEvent_KeyDown);
            this.m_dgtbInfectionDiaz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dgtbInfectionDiaICDz.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dgDiagnosis2zhong.DataSource = m_dtbInfectionDiagnosisZhong;

            ComboBox cmbFunctionAreaIz = new ComboBox();
            cmbFunctionAreaIz.Items.AddRange(new object[] { "治愈", "好转", "未愈", "死亡", "其他", "" });
            cmbFunctionAreaIz.Cursor = Cursors.Arrow;
            cmbFunctionAreaIz.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionAreaIz.Dock = DockStyle.Fill;
            //在选定项发生更改并且提交了该更改后发生 
            cmbFunctionAreaIz.SelectionChangeCommitted += new System.EventHandler(cmbFunctionArea_SelectionChangeCommitted);
            cmbFunctionAreaIz.Enter += new EventHandler(cmbFunctionAreaIz_Enter);
            ///把ComboBox添加到DataGridTableStyle的第一列
            m_dtcInfectionResultz.TextBox.Controls.Add(cmbFunctionAreaIz);
            #endregion
            #endregion

            #region 手术麻醉
            m_dtbOperationDetail = new DataTable("OperationDetail");
            dtcTemp = new DataColumn("手术、操作编码");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//0
            dtcTemp = new DataColumn("手术、操作日期");
            dtcTemp.DataType = typeof(System.DateTime);
            dtcTemp.DefaultValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//1
            dtcTemp = new DataColumn("手术、操作名称");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//2
            dtcTemp = new DataColumn("术者");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//3
            dtcTemp = new DataColumn("Ⅰ助");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//4
            dtcTemp = new DataColumn("Ⅱ助");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//5
            dtcTemp = new DataColumn("麻醉方式");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//6
            dtcTemp = new DataColumn("切口愈合等级");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//7
            dtcTemp = new DataColumn("麻醉医师");
            dtcTemp.DefaultValue = "";
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);//8
            this.m_dtbOperationDetail.Columns.Add("AnesthesiaModeID");//9
            this.m_dtbOperationDetail.Columns.Add("OperatorID");//10
            this.m_dtbOperationDetail.Columns.Add("Assistant1ID");//11
            this.m_dtbOperationDetail.Columns.Add("Assistant2ID");//12
            this.m_dtbOperationDetail.Columns.Add("AnesthetistID");//13
            this.dtgOperation.DataSource = m_dtbOperationDetail;
            DateTimePicker dtpOperationDate = new DateTimePicker();
            dtpOperationDate.Dock = DockStyle.Fill;
            dtpOperationDate.Name = "dtpOperationDate";
            dtpOperationDate.ValueChanged += new EventHandler(dtp_OperationDateValueChanged);
            m_dtcOperationDate.TextBox.Controls.Add(dtpOperationDate);
            #region 麻醉及手术名称相关事件定义
            //this.m_dtcOperationDate.TextBox.TextChanged += new EventHandler(OperationDate_TextChanged);
            //this.m_dtcAanaesthesiaMode.TextBox.GotFocus += new EventHandler(dtcAanaesthesiaMode_GotFocus);
            this.m_dtcOperationID.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);
            this.m_dtcOperationName.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);
            this.m_dtcAnaesthesiaMode.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);
            #endregion

            #region 手术、麻醉医师查询相关事件定义
            this.m_dtcOperator.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);

            this.m_dtcAssistant1.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);

            this.m_dtcAssistant2.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);

            this.m_dtcAnaesthetist.TextBox.KeyDown += new KeyEventHandler(m_mthEvent_KeyDown);
            #endregion

            this.m_dtcOperationID.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcOperationDate.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcOperationName.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcOperator.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcAssistant2.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcAssistant1.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcAnaesthesiaMode.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcCutLevel.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.m_dtcAnaesthetist.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.m_dtcOperationDate.TextBox.Leave+=new EventHandler(m_mthDate_Change);
            this.dtgOperation.DataSource = m_dtbOperationDetail;

            #region DataGrid模糊查询初始化

            //m_objGridListView0 = new clsGridListView(dtgOperation, m_dtcOperator, lsvOperationEmployee, new EventHandler(m_objAddGridListViewItemArr));
            //m_objGridListView1 = new clsGridListView(dtgOperation, m_dtcAssistant1, lsvOperationEmployee, new EventHandler(m_objAddGridListViewItemArr));
            //m_objGridListView2 = new clsGridListView(dtgOperation, m_dtcAssistant2, lsvOperationEmployee, new EventHandler(m_objAddGridListViewItemArr));
            //m_objGridListView3 = new clsGridListView(dtgOperation, m_dtcAnaesthetist, lsvOperationEmployee, new EventHandler(m_objAddGridListViewItemArr));
            //m_objGridListView4 = new clsGridListView(dtgOperation, m_dtcAnaesthesiaMode, lsvAanaesthesiaMode, new EventHandler(m_objAddGridAanaesthesiaModeListViewItemArr));

            m_hasAanaesthesiaMode = new Hashtable();
            #endregion
            #endregion

            #region 产科
            m_dtbBaby = new DataTable("Baby");

            dtcTemp = new DataColumn("婴儿序号");
            dtcTemp.DataType = typeof(int);
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("男性");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("女性");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("活产");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("死产");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("死胎");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            this.m_dtbBaby.Columns.Add("婴儿体重(g)");
            dtcTemp = new DataColumn("死亡");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("转科");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("出院");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("自然");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("I度窒息");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("II度窒息");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbBaby.Columns.Add(dtcTemp);
            this.m_dtbBaby.Columns.Add("医院感染次数");
            this.m_dtbBaby.Columns.Add("主要医院感染名称");
            this.m_dtbBaby.Columns.Add("ICD10");
            this.m_dtbBaby.Columns.Add("抢救次数");
            this.m_dtbBaby.Columns.Add("抢救成功次数");
        //    dtgBaby.DataSource = m_dtbBaby;
            m_dtbBaby.RowChanged += new DataRowChangeEventHandler(m_mthRowChanged);
            m_dtbBaby.RowDeleted += new DataRowChangeEventHandler(m_mthRowChanged);

            //this.dtcSeqNo.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcWeight.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcInfectionTimes.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcInfectionName.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcICD10.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcSalveTimes.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            //this.dtcSalveSuccessTimes.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);

            #endregion

            #region 肿瘤专科
            m_dtbChemotherapy = new DataTable("Chemotherapy");
            dtcTemp = new DataColumn("日期");
            dtcTemp.DataType = typeof(System.DateTime);
            dtcTemp.DefaultValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            this.m_dtbChemotherapy.Columns.Add("药品名称（剂量）");
            this.m_dtbChemotherapy.Columns.Add("疗程");
            dtcTemp = new DataColumn("疗效消失(CR)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("显效(PR)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("好转(MR)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("不变(S)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("恶化(P)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("未定(NA)");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbChemotherapy.Columns.Add(dtcTemp);
            dtgChemotherapy.DataSource = m_dtbChemotherapy;
            this.dtcDate.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dtcMedicineName.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            this.dtcPeriod.TextBox.DoubleClick += new EventHandler(m_dtgRecord_DoubleClick);
            DateTimePicker dtpChemotherapyDate = new DateTimePicker();
            dtpChemotherapyDate.Name = "dtpChemotherapyDate";
            dtpChemotherapyDate.Dock = DockStyle.Fill;
            dtpChemotherapyDate.ValueChanged += new EventHandler(dtp_ChemotherapyDateValueChanged);
            dtcDate.TextBox.Controls.Add(dtpChemotherapyDate);
            //this.dtcDate.TextBox.Leave += new EventHandler(m_mthDate_Change);
            #endregion
        }
        private void dtp_OperationDateValueChanged(object sender, EventArgs e)
        {
            this.dtgOperation[this.dtgOperation.CurrentCell] = ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd");
        }
        private void dtp_ChemotherapyDateValueChanged(object sender, EventArgs e)
        {
            this.dtgChemotherapy[this.dtgChemotherapy.CurrentCell] = ((DateTimePicker)sender).Value.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 当前DataGird
        /// </summary>
        string strControl = string.Empty;

        private void cmbFunctionArea_Enter(object sender, EventArgs e)
        {
            strControl = "dgDiagnosis3";
        }
        private void cmbFunctionAreaz_Enter(object sender, EventArgs e)
        {
            strControl = "dgDiagnosis3zhongyi";
        }

        private void cmbFunctionAreaI_Enter(object sender, EventArgs e)
        {
            strControl = "dgDiagnosis2";
        }
        private void cmbFunctionAreaIz_Enter(object sender, EventArgs e)
        {
            strControl = "dgDiagnosis2zhong";
        }
        private void cmbFunctionArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (strControl == "dgDiagnosis2")
            {
                dgDiagnosis2.BindingContext[dgDiagnosis2.DataSource, dgDiagnosis2.DataMember].EndCurrentEdit();
                if (dgDiagnosis2.CurrentRowIndex >= m_dtbInfectionDiagnosis.Rows.Count)
                {
                    DataRow drTemp = m_dtbInfectionDiagnosis.NewRow();
                    drTemp[0] = dgDiagnosis2[dgDiagnosis2.CurrentRowIndex, 0].ToString();
                    drTemp[1] = dgDiagnosis2[dgDiagnosis2.CurrentRowIndex, 1].ToString();
                    drTemp[2] = ((ComboBox)sender).SelectedItem.ToString();
                    m_dtbInfectionDiagnosis.Rows.Add(drTemp);
                }
                else
                {
                    m_dtbInfectionDiagnosis.Rows[dgDiagnosis2.CurrentRowIndex][2] = ((ComboBox)sender).SelectedItem.ToString();
                }
                return;

            }
            else if (strControl == "dgDiagnosis2zhong")
            {
                dgDiagnosis2zhong.BindingContext[dgDiagnosis2zhong.DataSource, dgDiagnosis2zhong.DataMember].EndCurrentEdit();
                if (dgDiagnosis2zhong.CurrentRowIndex >= m_dtbInfectionDiagnosisZhong.Rows.Count)
                {
                    DataRow drTemp = m_dtbInfectionDiagnosisZhong.NewRow();
                    drTemp[0] = dgDiagnosis2zhong[dgDiagnosis2zhong.CurrentRowIndex, 0].ToString();
                    drTemp[1] = dgDiagnosis2zhong[dgDiagnosis2zhong.CurrentRowIndex, 1].ToString();
                    drTemp[2] = ((ComboBox)sender).SelectedItem.ToString();
                    m_dtbInfectionDiagnosisZhong.Rows.Add(drTemp);
                }
                else
                {
                    m_dtbInfectionDiagnosisZhong.Rows[dgDiagnosis2zhong.CurrentRowIndex][2] = ((ComboBox)sender).SelectedItem.ToString();
                }
                return;

            }
            else if (strControl == "dgDiagnosis3")
            {
                dgDiagnosis3.BindingContext[dgDiagnosis3.DataSource, dgDiagnosis3.DataMember].EndCurrentEdit();
                if (dgDiagnosis3.CurrentRowIndex >= m_dtbOtherDiagnosis.Rows.Count)
                {
                    DataRow drTemp = m_dtbOtherDiagnosis.NewRow();
                    drTemp[0] = dgDiagnosis3[dgDiagnosis3.CurrentRowIndex, 0].ToString();
                    drTemp[1] = dgDiagnosis3[dgDiagnosis3.CurrentRowIndex, 1].ToString();
                    drTemp[2] = ((ComboBox)sender).SelectedItem.ToString();
                    m_dtbOtherDiagnosis.Rows.Add(drTemp);
                }
                else
                {
                    m_dtbOtherDiagnosis.Rows[dgDiagnosis3.CurrentRowIndex][2] = ((ComboBox)sender).SelectedItem.ToString();
                }
                return;

            }
            else if (strControl == "dgDiagnosis3zhongyi")
            {
                dgDiagnosis3zhongyi.BindingContext[dgDiagnosis3zhongyi.DataSource, dgDiagnosis3zhongyi.DataMember].EndCurrentEdit();
                if (dgDiagnosis3zhongyi.CurrentRowIndex >= m_dtbOtherDiagnosisz.Rows.Count)
                {
                    DataRow drTemp = m_dtbOtherDiagnosisz.NewRow();
                    drTemp[0] = dgDiagnosis3zhongyi[dgDiagnosis3zhongyi.CurrentRowIndex, 0].ToString();
                    drTemp[1] = dgDiagnosis3zhongyi[dgDiagnosis3zhongyi.CurrentRowIndex, 1].ToString();
                    drTemp[2] = ((ComboBox)sender).SelectedItem.ToString();
                    m_dtbOtherDiagnosisz.Rows.Add(drTemp);
                }
                else
                {
                    m_dtbOtherDiagnosisz.Rows[dgDiagnosis3zhongyi.CurrentRowIndex][2] = ((ComboBox)sender).SelectedItem.ToString();
                }
                return;

            }
        }
        #endregion

        private void frmInHospitalMainRecord_XJ_Load(object sender, EventArgs e)
        {
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);

            clsAnaesthesiaModeInOperation[] m_objAnaesthesiaModeArr = new clsOperationRecordDomain().m_objGetAnaesthesiaMode();

            for (int i1 = 0; i1 < m_objAnaesthesiaModeArr.Length; i1++)
            {
                m_hasAanaesthesiaMode.Add(m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeID, m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeName);
            }
            m_mthSetQuickKeys();
            //			lblAreaTitle.Visible=false;
            //			m_cboArea.Visible =false;
            //			lblBedNoTitle.Visible =false;
            //			m_txtBedNO.Visible=false;
            //			m_lsvInPatientID.Visible = false;
            m_mthInitGroupBoxTagValue();
            //			txtInPatientID.Focus();


            m_mthfrmLoad();

            txtDiagnosis.Focus();
            m_mthGetDistrict("0", ref m_cboProvince);
            if (m_cboProvince.GetItemsCount() != 0)
                m_cboProvince.SelectedIndex = 0;

            m_cboMainSeq.SelectedIndex = 0;
            m_cboMainSeqzhongyi.SelectedIndex = 0;

            m_cboMainSeqzhzhu.SelectedIndex = 0;

            base.m_mthAssociateComboBoxItemEvent(m_cboModeOfPayment);

            this.rdbNormal.Checked = true;
            gpbCondictionWhenIn.Tag = "2";
        }


        private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            m_mthRecordChangedToSave();

            m_cmdCommit.Enabled = false;
            m_bolIfHasSave = false;
            m_strOpenDate = null;
            m_txtFocusedRichTextBox = null;
            m_RtbCurrentTextBox = null;
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_mthCleanUpPatientDetailInfo();
            if (trvTime.SelectedNode.Tag == null)
            {
                m_mthSetControlReadOnly(this, true);
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
                m_mthAddFormStatusForClosingSave();
                return;

            }
            m_cmdCommit.Enabled = true;
            //设置病人当次住院的基本信息 更新信息
            m_mthOnlySetPatientInfo(m_objSelectedPatient);
            m_objSelectedPatient.m_ObjPeopleInfo = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo;

            m_mthSetPatientCurrentInHospitalDeptInfo();

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthDiaplayDetail();
            m_mthSetControlReadOnly(this, false);
        }

        /// <summary>
        /// 读取手术记录单的共享数据
        /// </summary>
        private void m_mthLoadOperationInfo()
        {
            if (m_objSelectedPatient != null)
            {
                clsOperationRecordDoctorShareDomain.stuBaseOperationValue[] stuValueArr;
                long lngRes = m_objShareDomain.m_lngGetBaseOperationValueArr(m_objSelectedPatient.m_StrInPatientID, m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out stuValueArr);

                if (lngRes > 0 && stuValueArr != null)
                {
                    for (int i = 0; i < stuValueArr.Length; i++)
                    {
                        object[] objValue = new object[14];
                        objValue[0] = "";//操作编码
                        objValue[1] = stuValueArr[i].m_strOperationBeginDate;
                        objValue[2] = stuValueArr[i].m_strOperationName;
                        objValue[3] = stuValueArr[i].m_strOperationDoctorName;
                        objValue[4] = stuValueArr[i].m_strFirstAssistantName;
                        objValue[5] = stuValueArr[i].m_strSecondAssistantName;
                        objValue[6] = stuValueArr[i].m_strAnaesthesiaCategoryDosage;
                        objValue[7] = "/";
                        objValue[8] = stuValueArr[i].m_strAnaesther;
                        objValue[9] = "";//麻醉方式的ID
                        objValue[10] = stuValueArr[i].m_strOperationDoctorID;
                        objValue[11] = stuValueArr[i].m_strFirstAssistantID;
                        objValue[12] = stuValueArr[i].m_strSecondAssistantID;
                        objValue[13] = "";//麻醉医师的ID

                        m_dtbOperationDetail.Rows.Add(objValue);
                    }
                }
            }
        }

        #region 判断该次住院的住院病案首页是否已经生成过
        /// <summary>
        /// 判断该次住院的住院病案首页是否已经生成过
        /// </summary>
        private void m_mthCheckIfHasSave(string m_strInPatientDate)
        {
            if (m_strInPatientDate == null || m_strInPatientDate == "")
            {
                m_bolIfHasSave = false;
                return;
            }
            m_strOpenDate = null;
            long lngRes = m_objDomain.m_lngGetOpenDateInfo(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, out m_strOpenDate);
            if (lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            if (m_strOpenDate == null || m_strOpenDate == "")
            {
                m_bolIfHasSave = false;
            }
            else
            {
                m_bolIfHasSave = true;
            }
        }

        #endregion

        #region 显示该次住院的住院病案首页的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的信息
        /// </summary>
        private void m_mthDiaplayDetail()
        {
            string m_strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            m_mthCheckIfHasSave(m_strInPatientDate);
            long m_lngRes = 0;
            if (m_bolIfHasSave)
            {
                m_lngRes = m_objDomain.m_lngGetMainInfo(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objMain);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_lngRes = m_objDomain.m_lngGetContentInfo(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objContent);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_lngRes = m_objDomain.m_lngGetDiagnosisArr(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objDiagnosisArr);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_lngRes = m_objDomain.m_lngGetOperationArr(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objOperationArr);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_lngRes = m_objDomain.m_lngGetBabyArr(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objBabyArr);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_lngRes = m_objDomain.m_lngGetChemotherapyArr(m_objSelectedPatient.m_StrInPatientID, m_strInPatientDate, m_strOpenDate, out m_objCollection.m_objChemotherapyArr);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return;
                }
                m_bolIfChange = false;

                m_mthSetMainInfo(m_objCollection.m_objMain, m_objCollection.m_objContent);
                m_mthSetDiagnosisInfo(m_objCollection.m_objDiagnosisArr);
                m_mthSetOperationInfo(m_objCollection.m_objOperationArr);
                m_mthSetBabyInfo(m_objCollection.m_objBabyArr);
                //m_mthSetChemotherapyInfo(m_objCollection.m_objChemotherapyArr);
                m_bolIfChange = true;

                if (m_objCollection.m_objMain.m_intISHANDIN != 1)
                {
                    m_mthLoadChargeInfo();
                }

                //当前处于修改记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);

                m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;
            }
            else
            {
                m_mthLoadOperationInfo();

                m_mthLoadChargeInfo();

                m_mthSetDefaultValue(m_objSelectedPatient);

                //当前处于新增记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                m_EnmFormEditStatus = MDIParent.enmFormEditStatus.AddNew;
            }

            m_mthAddFormStatusForClosingSave();
        }

        /// <summary>
        /// 设置各种类型的默认值
        /// </summary>
        /// <param name="p_objPatient"></param>
        private void m_mthSetDefaultValue(clsPatient p_objPatient)
        {
            //new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

            //自动模板
            m_mthSetSpecialPatientTemplateSet(p_objPatient);

            #region 从住院病历读取数据
            string strInPatientDate = p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            clsInPatientCaseHisoryDefaultDomain objInPaitentCaseDefault = new clsInPatientCaseHisoryDefaultDomain();
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = null;
            if (p_objPatient != null)
            {
                objInPatientCaseDefaultValue = objInPaitentCaseDefault.lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID, strInPatientDate);
                if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
                {
                    txtDiagnosis.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
                    //txtInHospitalDiagnosis.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
                    txtMainDiagnosis.Text = objInPatientCaseDefaultValue[0].m_strFinallyDiagnose != "" ? objInPatientCaseDefaultValue[0].m_strFinallyDiagnose : objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
                    dtpConfirmDiagnosisDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate);
                }
            }
            #endregion

            //设完默认值后回到光标床号
            m_txtBedNO.Focus();
        }

        private void m_mthGetDeletedDetail(string p_strInpatientId, string p_strInpatientDate, string p_strOpenDate, ref clsInHospitalMainRecord_Collection p_objCollection)
        {
            long m_lngRes = 0;

            m_lngRes = m_objDomain.m_lngGetDeletedMainInfo(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objMain);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            m_lngRes = m_objDomain.m_lngGetDeletedContentInfo(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objContent);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            m_lngRes = m_objDomain.m_lngGetDeleteDiagnosisArr(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objDiagnosisArr);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            m_lngRes = m_objDomain.m_lngGetDeletedOperationArr(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objOperationArr);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            m_lngRes = m_objDomain.m_lngGetBabyArr(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objBabyArr);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            m_lngRes = m_objDomain.m_lngGetDeletedChemotherapyArr(p_strInpatientId, p_strInpatientDate, p_strOpenDate, out p_objCollection.m_objChemotherapyArr);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
        }

        private void m_mthDiaplayDeletedDetail(string p_strInpatientId, string p_strInpatientDate, string p_strOpenDate)
        {
            m_mthGetDeletedDetail(p_strInpatientId, p_strInpatientDate, p_strOpenDate, ref  m_objCollection);
            m_bolIfChange = false;
            m_mthSetMainInfo(m_objCollection.m_objMain, m_objCollection.m_objContent);
            m_mthSetDiagnosisInfo(m_objCollection.m_objDiagnosisArr);
            m_mthSetOperationInfo(m_objCollection.m_objOperationArr);
            m_mthSetBabyInfo(m_objCollection.m_objBabyArr);
            //m_mthSetChemotherapyInfo(m_objCollection.m_objChemotherapyArr);
            m_bolIfChange = true;


        }


        #endregion

        #region 显示该病人该次住院的科室，出院住院信息
        /// <summary>
        /// 当次住院转科信息
        /// </summary>
        clsInHospitalMainTransDeptInstance objTransDeptInstance = null;
        /// <summary>
        /// 显示该病人该次住院的科室，出院住院信息
        /// </summary>
        private void m_mthSetPatientCurrentInHospitalDeptInfo()
        {
            if (m_ObjCurrentEmrPatientSession == null)
                return;
            lblTimes.Text = m_ObjCurrentEmrPatientSession.m_strInTimes;//第几次住院

            #region 获取入院、出院科室，转科情况
            DateTime dtmOutDate = new DateTime(1900, 1, 1);
            long lngRes = 0;
            lngRes = m_objDomain.m_lngGetInHospitalMainTransDeptInstance(m_ObjCurrentEmrPatientSession.m_strRegisterId, out objTransDeptInstance);
            m_strRegisterID = m_ObjCurrentEmrPatientSession.m_strRegisterId;

            if (lngRes > 0 && objTransDeptInstance != null)
            {
                if (objTransDeptInstance.m_demOutPatientDate != new DateTime(1900, 1, 1) && objTransDeptInstance.m_demOutPatientDate != DateTime.MinValue)
                    m_lblOutHospitalDate.Text = objTransDeptInstance.m_demOutPatientDate.ToString("yyyy年MM月dd日 HH时");
                else
                    m_lblOutHospitalDate.Text = "";
                lblInHosptialSetion.Text = objTransDeptInstance.m_strInPatientAreaName;
                //lblInSickRoom.Text = objTransDeptInstance.m_strInPatientAreaName + objTransDeptInstance.m_strInPatientBedName;
                lblInSickRoom.Text = objTransDeptInstance.m_strInPatientBedName;
                lblOutHospitalSetion.Text = objTransDeptInstance.m_strOutPatientAreaName;
                //lblOutSickRoom.Text = objTransDeptInstance.m_strOutPatientAreaName + objTransDeptInstance.m_strOutPatientBedName;
                lblOutSickRoom.Text = objTransDeptInstance.m_strOutPatientBedName;
                if (objTransDeptInstance.m_strTransSourceAreaIDArr != null
                    && objTransDeptInstance.m_strTransTargetAreaIDArr != null
                    && objTransDeptInstance.m_strTransSourceAreaIDArr.Length == objTransDeptInstance.m_strTransTargetAreaIDArr.Length)
                {                  
                    if (objTransDeptInstance.m_strTransDeptDateArr != null)
                    {
                        m_lsvTransDept.Items.Clear();
                        for (int i = 0; i < objTransDeptInstance.m_strTransSourceAreaIDArr.Length; i++)
                        {

                            DateTime dtTransDate = Convert.ToDateTime(objTransDeptInstance.m_strTransDeptDateArr[i]);
                            ListViewItem item = new ListViewItem(new string[]{objTransDeptInstance.m_strTransSourceAreaNameArr[i],
																			 dtTransDate.ToString("yyyy-MM-dd"),
																			 objTransDeptInstance.m_strTransTargetAreaNameArr[i]});
                            m_lsvTransDept.Items.Add(item);

                        }
                    }
                }
            }
            else
            {
                m_lblOutHospitalDate.Text = "";
                lblInHosptialSetion.Text = "";
                lblOutHospitalSetion.Text = "";
                m_lsvTransDept.Items.Clear();
                lblInSickRoom.Text = "";
                lblOutSickRoom.Text = "";
            }
            #endregion

            //m_lblInHospitalDate.Text = Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy年MM月dd日 HH时");

            System.TimeSpan diff = new TimeSpan(0);
            DateTime dtmTemp = DateTime.Now;
            if (m_lblOutHospitalDate.Text == "")
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
                diff = Convert.ToDateTime(m_lblOutHospitalDate.Text).Subtract(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate);
            }

            if (diff.Days < 1)
                lblInHospitalDays.Text = "1";
            else if (m_lblOutHospitalDate.Text == "")
            {
                diff = Convert.ToDateTime(dtmTemp.ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd")));
                lblInHospitalDays.Text = diff.Days.ToString();
            }
            else
            {
                diff = Convert.ToDateTime(Convert.ToDateTime(m_lblOutHospitalDate.Text).ToString("yyyy-MM-dd")).Subtract(Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd")));
                lblInHospitalDays.Text = diff.Days.ToString();
            }
            #region Old
            //if(m_objSession.m_DtmOutDate == DateTime.Parse("1900-01-01 00:00:00") || m_objSession.m_DtmOutDate == m_objSession.m_DtmInDate)//（没有出院日期，表示未曾出院）
            //    dtpOutHospitalDate.Value = DateTime.Now;
            //else
            //    dtpOutHospitalDate.Value = m_objSession.m_DtmOutDate;

            //System.TimeSpan diff=dtpOutHospitalDate.Value.Subtract(m_objSession.m_DtmInDate);
            //lblInHospitalDays.Text = ((int)diff.TotalDays).ToString();
            //int m_intDeptCount = m_objSession.m_intGetDeptCount();
            //if(m_intDeptCount <=0)
            //    return;
            //clsInBedDeptInfo m_objFirstDeptInfo = m_objSession.m_objGetDeptByIndex(0);
            //clsInBedDeptInfo m_objLastDeptInfo = m_objSession.m_objGetDeptByIndex(m_intDeptCount - 1);
            //if(m_objFirstDeptInfo != null)
            //{
            //    lblInHosptialSetion.Text = m_objFirstDeptInfo.m_ObjDept.m_StrDeptName;
            //    //				lblInSickRoom.Text = m_objFirstDeptInfo.m_objGetAreaByIndex(0).m_objGetRoomByIndex(0).m_ObjRoom.m_StrRoomName;
            //    lblInSickRoom.Text = m_objFirstDeptInfo.m_ObjSession.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
            //}
            //if(m_objLastDeptInfo != null)
            //{
            //    lblOutHospitalSetion.Text = m_objSession.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName;
            //    //				lblOutSickRoom.Text = m_objSession.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomName;
            //    lblOutSickRoom.Text = m_objSession.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
            //}

            //dtgChangeDept.CurrentRowIndex = 0;
            //m_dtbChangeDept.Rows.Clear();
            //for(int i1=1;i1<m_intDeptCount;i1++)
            //{
            //    m_dtbChangeDept.Rows.Add(new object[]{m_objSession.m_objGetDeptByIndex(i1).m_ObjDept.m_StrDeptName});
            //}
            #endregion Old
        }
        #endregion

        #region 显示该次住院的住院病案首页的主表信息
        /// <summary>
        /// 显示该次住院的住院病案首页的主表信息
        /// </summary>
        /// <param name="p_objContent"></param>
        private void m_mthSetMainInfo(clsInHospitalMainRecord_Main p_objMain, clsInHospitalMainRecord_Content p_objContent)
        {
            if (p_objMain == null || p_objContent == null)
            {

                #region 在住院病历没有记录时候，从其他表读入信息,刘颖源,2003-5-14 17:50:50
                string strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                clsInPatientCaseHisoryDefaultDomain objInPaitentCaseDefault = new clsInPatientCaseHisoryDefaultDomain();
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = null;

                if (m_objSelectedPatient != null)
                {
                    objInPatientCaseDefaultValue = objInPaitentCaseDefault.lngGetAllInPatientCaseHisoryDefault(m_objSelectedPatient.m_StrInPatientID, strInPatientDate);
                    if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
                    {
                        //this.txtInHospitalDiagnosis.Text =objInPatientCaseDefaultValue[0].m_strFinallyDiagnose ; 
                    }
                }
                #endregion

                return;
            }
     
            txtDiagnosis.m_mthSetNewText(p_objContent.m_strDiagnosis, p_objMain.m_strDiagnosisXML);
            txtDiagnosisZhongYi.m_mthSetNewText(p_objContent.m_strDiagnosiszhong, p_objMain.m_strDiagnosiszhongXML);
            //			txtInHospitalDiagnosis.m_mthSetNewText(p_objContent.m_strInHospitalDiagnosis,p_objMain.m_strInHospitalDiagnosisXML);
            m_strCurrentOpenDate = p_objContent.m_strOpenDate;
            if (p_objMain.m_intISHANDIN == 1)
            {
                m_cmdCommit.Enabled = false;
            }
            else
            {
                m_cmdCommit.Enabled = true;
            }

            int i = 0;
            int j = 0;
            if (p_objContent.m_strBirthPlace.Trim() != "")
            {
                i = p_objContent.m_strBirthPlace.IndexOf(">");
                j = p_objContent.m_strBirthPlace.LastIndexOf(">");

                //m_cboProvince.Text = (p_objContent.m_strBirthPlace).Substring(0, i);
                //m_cboCity.Text = (p_objContent.m_strBirthPlace).Substring(i + 2, j - i - 3);
                //m_cboCounty.Text = (p_objContent.m_strBirthPlace).Substring(j + 1, p_objContent.m_strBirthPlace.Length - j - 1);
                txtchusheng.Text = p_objContent.m_strBirthPlace;
            }
            else
            {
                txtchusheng.Text = "";
                //m_cboProvince.Text = "";
                //m_cboCity.Text = "";
                //m_cboCounty.Text = "";
            }


            //txtDiagnosis.Text = p_objContent.m_strDiagnosis;
            txtDiagnosisICD10.Text = p_objMain.m_strMZICD10;
            txtICD_10OfMain.Text = p_objMain.m_strMAINICD10;
            txtICD_10OfMainzhongyi.Text = p_objMain.m_strMAINICD10Zhong;

            txtzhuzhengICD.Text = p_objContent.m_strZhuZhengICD;
            //txtInHospitalDiagnosis.Text = p_objContent.m_strInHospitalDiagnosis;

            #region 签名
            //新的签名
            TextBoxBase[] txtArr = new TextBoxBase[] { txtDoctor,  txtQCNurse, txtCoder,
            txtDirectorDt,txtSubDirectorDt,txtQCDt,txtDt,txtInHospitalDt,txtAttendInForAdvancesStudyDt,txtGraduateStudentIntern,txtIntern};
            string[][] strArr = new string[txtArr.Length][];

            strArr[0] = new string[] { p_objContent.m_strDoctor, p_objContent.m_strDoctorName, "" };
            strArr[1] = new string[] { p_objContent.m_strQCNurse, p_objContent.m_strQCNurseName, "" };
            strArr[2] = new string[] { p_objContent.m_strCoder, p_objContent.m_strCoderName, "" };
            strArr[3] = new string[] { p_objContent.m_strDirectorDt, p_objContent.m_strDirectorDtName, "" };
            strArr[4] = new string[] { p_objContent.m_strSubDirectorDt, p_objContent.m_strSubDirectorDtName, "" };
            strArr[5] = new string[] { p_objContent.m_strQCDt, p_objContent.m_strQCDtName, "" };
            strArr[6] = new string[] { p_objContent.m_strDt, p_objContent.m_strDtName, "" };
            strArr[7] = new string[] { p_objContent.m_strInHospitalDt, p_objContent.m_strInHospitalDtName, "" };
            strArr[8] = new string[] { p_objContent.m_strAttendInForAdvancesStudyDt, p_objContent.m_strAttendInForAdvancesStudyDtName, "" };
            strArr[9] = new string[] { p_objContent.m_strGraduateStudentIntern, p_objContent.m_strGraduateStudentInternName, "" };
            strArr[10] = new string[] { p_objContent.m_strIntern, p_objContent.m_strInternName, "" };
            m_mthAddSignToTextBoxByValue(txtArr, strArr,
                new bool[] { true, true, true, true, true, true, true, true, true, true, true }, true);
            m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { m_txtSign }, new string[] { p_objMain.m_strCreateUserID }, new bool[] { true });
            #endregion

            //if(p_objContent.m_strDoctor != null && p_objContent.m_strDoctor != "")
            //{
            //    txtDoctor.Tag = p_objContent.m_strDoctor;
            //    txtDoctor.Text = new clsEmployee(p_objContent.m_strDoctor).m_StrFirstName;
            //}
            txtMainDiagnosis.m_mthSetNewText(p_objContent.m_strMainDiagnosis, p_objMain.m_strMainDiagnosisXML);
            txtMainDiagnosiszhongyi.m_mthSetNewText(p_objContent.m_strMainDiagnosisZhong, p_objMain.m_strMainDiagnosisZhongXML);
            txtzhuzheng.m_mthSetNewText(p_objContent.m_strZhuZheng, p_objMain.m_strZhuZhengXML);
            //txtMainDiagnosis.Text = p_objContent.m_strMainDiagnosis; txtzhuzheng
            //gpbMainDiagnosis.Tag = p_objContent.m_strMainConditionSeq;
            dtpConfirmDiagnosisDate.Value = DateTime.Parse(p_objContent.m_strConfirmDiagnosisDate);
            gpbCondictionWhenIn.Tag = p_objContent.m_strCondictionWhenIn;
            #region
            switch (p_objContent.m_strCondictionWhenIn)
            {
                case "0":
                    rdbDanger.Checked = true;
                    break;
                case "1":
                    rdbEmergency.Checked = true;
                    break;
                case "2":
                    rdbNormal.Checked = true;
                    break;
                default:
                    rdbDanger.Checked = true;
                    break;
            }
          
            int intSIndex = -1;
            if (int.TryParse(p_objContent.m_strMainConditionSeq, out intSIndex))
            {
                m_cboMainSeq.SelectedIndex = intSIndex;
            }
            else
            {
                m_cboMainSeq.SelectedIndex = -1;
            }
            int intSIndex2 = -1;
            if (int.TryParse(p_objContent.m_strMainConditionSeqZhong, out intSIndex2))
            {
                m_cboMainSeqzhongyi.SelectedIndex = intSIndex2;
            }
            else
            {
                m_cboMainSeqzhongyi.SelectedIndex = -1;
            }

            int intSIndex3 = -1;
            if (int.TryParse(p_objContent.m_strZhuZhengSeq, out intSIndex3))
            {
                m_cboMainSeqzhzhu.SelectedIndex = intSIndex3;
            }
            else
            {
                m_cboMainSeqzhzhu.SelectedIndex = -1;
            }
            #endregion 
            #region
            //switch(p_objContent.m_strMainConditionSeq)
            //{
            //    case "0":
            //        rdbHealOfMain.Checked = true;
            //        break;
            //    case "1":
            //        rdbOnTheMendOfMain.Checked = true;
            //        break;
            //    case "2":
            //        rdbNotCureOfMain.Checked = true;
            //        break;
            //    case "3":
            //        rdbDieOfMain.Checked = true;
            //        break;
            //    case "4":
            //        rdbNotDefineOfMain.Checked = true;
            //        break;
            //    default:
            //        break;
            //}
            //			txtICD_10OfMain.m_mthSetNewText(p_objContent.m_strICD_10OfMain,p_objMain.m_strICD_10OfMainXML);
            //			txtICD_10OfMain.Text = p_objContent.m_strICD_10OfMain;

            //			txtInfectionDiagnosis.m_mthSetNewText(p_objContent.m_strInfectionDiagnosis,p_objMain.m_strInfectionDiagnosisXML);
            //txtInfectionDiagnosis.Text = p_objContent.m_strInfectionDiagnosis;
            //gpbInfection.Tag = p_objContent.m_strInfectionCondictionSeq;
            //switch(p_objContent.m_strInfectionCondictionSeq)
            //{
            //    case "0":
            //        rdbHealOfInfection.Checked = true;
            //        break;
            //    case "1":
            //        rdbOnTheMendOfInfection.Checked = true;
            //        break;
            //    case "2":
            //        rdbNotCureOfInfection.Checked = true;
            //        break;
            //    case "3":
            //        rdbDieOfInfection.Checked = true;
            //        break;
            //    case "4":
            //        rdbNotDefineOfInfection.Checked = true;
            //        break;
            //    default:
            //        break;
            //}
            //			txtICD_10OfInfection.m_mthSetNewText(p_objContent.m_strICD_10OfInfection,p_objMain.m_strICD_10OfInfectionXML);
            #endregion
            txtPathologyDiagnosis.m_mthSetNewText(p_objContent.m_strPathologyDiagnosis, p_objMain.m_strPathologyDiagnosisXML);
            txtScacheSource.m_mthSetNewText(p_objContent.m_strScacheSource, p_objMain.m_strScacheSourceXML);
            txtSensitive.m_mthSetNewText(p_objContent.m_strSensitive, p_objMain.m_strSensitiveXML);
            txtHbsAg.m_mthSetNewText(p_objContent.m_strHbsAg, p_objMain.m_strHbsAgXML);
            txtHCV_Ab.m_mthSetNewText(p_objContent.m_strHCV_Ab, p_objMain.m_strHCV_AbXML);
            txtHIV_Ab.m_mthSetNewText(p_objContent.m_strHIV_Ab, p_objMain.m_strHIV_AbXML);
            txtAccordWithOutHospital.m_mthSetNewText(p_objContent.m_strAccordWithOutHospital, p_objMain.m_strAccordWithOutHospitalXML);
            txtAccordWithOutHospitalzhong.m_mthSetNewText(p_objContent.m_strAccordWithOutHospitalZhong, p_objMain.m_strAccordWithOutHospitalZhongXML);
            //txtAccordInWithOut.m_mthSetNewText(p_objContent.m_strAccordInWithOut, p_objMain.m_strAccordInWithOutXML);
            //txtAccordBeforeOperationWithAfter.m_mthSetNewText(p_objContent.m_strAccordBeforeOperationWithAfter, p_objMain.m_strAccordBfOprWithAfXML);
            txtAccordClinicWithPathology.m_mthSetNewText(p_objContent.m_strAccordClinicWithPathology, p_objMain.m_strAccordClinicWithPathologyXML);
            txtAccordRadiateWithPathology.m_mthSetNewText(p_objContent.m_strAccordRadiateWithPathology, p_objMain.m_strAccordRadiateWithPathologyXML);
            txtSalveTimes.m_mthSetNewText(p_objContent.m_strSalveTimes, p_objMain.m_strSalveTimesXML);
            txtSalveSuccess.m_mthSetNewText(p_objContent.m_strSalveSuccess, p_objMain.m_strSalveSuccessXML);
            txtchuyuanfangshi.m_mthSetNewText(p_objContent.m_strChuYuanFangShi, p_objMain.m_strChuYuanFangShiXML);
            txtleibie.m_mthSetNewText(p_objContent.m_strZhiLiaoLeiBie, p_objMain.m_strZhiLiaoLeiBieXML);
            txtzhiji.m_mthSetNewText(p_objContent.m_strZhongYaoZhiJi, p_objMain.m_strZhongYaoZhiJiXML);
            txtruyuantujing.m_mthSetNewText(p_objContent.m_strRuYuanTuJing, p_objMain.m_strRuYuanTuJingXML);
            txtruyuanqian.m_mthSetNewText(p_objContent.m_strWaiYaunZhiLiao, p_objMain.m_strWaiYaunZhiLiaoXML);
            txtbinglihao.Text = p_objContent.m_strBingLiHao;
            txtweizhong.m_mthSetNewText(p_objContent.m_strWeiZhong, p_objMain.m_strWeiZhongXML);
            txtjizheng.m_mthSetNewText(p_objContent.m_strJiZheng, p_objMain.m_strJiZhengXML);
            txtyinanqingkuang.m_mthSetNewText(p_objContent.m_strYiNan, p_objMain.m_strYiNanXML);
            txtSalveMethod.m_mthSetNewText(p_objContent.m_strFangFa, p_objMain.m_strFangFaXML);

            txtshoushu.m_mthSetNewText(p_objContent.m_strShouShu, p_objMain.m_strShouShuXML);
            txt_zhiliao.m_mthSetNewText(p_objContent.m_strZiLiao, p_objMain.m_strZiLiaoXML);
            txtjiancha.m_mthSetNewText(p_objContent.m_strJianCha, p_objMain.m_strJianChaXML);
            txtzhengduan.m_mthSetNewText(p_objContent.m_strZDuan, p_objMain.m_strZDuanXML);
            txtdeathreason.m_mthSetNewText(p_objContent.m_strSiWang, p_objMain.m_strSiWangXML);
            if (p_objContent.m_strSiWangTime != "")
            {
                dtpdeathtime.Text = p_objContent.m_strSiWangTime;
            }
            else
            {
                dtpdeathtime.Text = "";
            }
            //txtICD_10OfInfection.Text = p_objContent.m_strICD_10OfInfection;
            //txtPathologyDiagnosis.Text = p_objContent.m_strPathologyDiagnosis;
            //txtScacheSource.Text = p_objContent.m_strScacheSource;
            //txtSensitive.Text = p_objContent.m_strSensitive;
            //txtHbsAg.Text = p_objContent.m_strHbsAg;
            //txtHCV_Ab.Text = p_objContent.m_strHCV_Ab;
            //txtHIV_Ab.Text = p_objContent.m_strHIV_Ab;
            //txtAccordWithOutHospital.Text = p_objContent.m_strAccordWithOutHospital;
            txt_shuye.Text = p_objContent.m_strShuYe;
            txtAccordInWithOut.Text = p_objContent.m_strAccordInWithOut;
            txtAccordInWithOutzhong.Text = p_objContent.m_strAccordInWithOutZhong;
            txtAccordBeforeOperationWithAfter.Text = p_objContent.m_strAccordBeforeOperationWithAfter;
            #region
            //txtAccordClinicWithPathology.Text = p_objContent.m_strAccordClinicWithPathology;
            //txtAccordRadiateWithPathology.Text = p_objContent.m_strAccordRadiateWithPathology;
            //txtSalveTimes.Text = p_objContent.m_strSalveTimes;
            //txtSalveSuccess.Text = p_objContent.m_strSalveSuccess;
            //if(p_objContent.m_strDirectorDt != null && p_objContent.m_strDirectorDt != "")
            //{
            //    txtDirectorDt.Tag = p_objContent.m_strDirectorDt;
            //    txtDirectorDt.Text = new clsEmployee(p_objContent.m_strDirectorDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strSubDirectorDt != null && p_objContent.m_strSubDirectorDt != "")
            //{
            //    txtSubDirectorDt.Tag = p_objContent.m_strSubDirectorDt;
            //    txtSubDirectorDt.Text = new clsEmployee(p_objContent.m_strSubDirectorDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strDt != null && p_objContent.m_strDt != "")
            //{
            //    txtDt.Tag = p_objContent.m_strDt;
            //    txtDt.Text = new clsEmployee(p_objContent.m_strDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strInHospitalDt != null && p_objContent.m_strInHospitalDt != "")
            //{
            //    txtInHospitalDt.Tag = p_objContent.m_strInHospitalDt;
            //    txtInHospitalDt.Text = new clsEmployee(p_objContent.m_strInHospitalDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strAttendInForAdvancesStudyDt != null && p_objContent.m_strAttendInForAdvancesStudyDt != "")
            //{
            //    txtAttendInForAdvancesStudyDt.Tag = p_objContent.m_strAttendInForAdvancesStudyDt;
            //    txtAttendInForAdvancesStudyDt.Text = new clsEmployee(p_objContent.m_strAttendInForAdvancesStudyDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strGraduateStudentIntern != null && p_objContent.m_strGraduateStudentIntern != "")
            //{
            //    txtGraduateStudentIntern.Tag = p_objContent.m_strGraduateStudentIntern;
            //    txtGraduateStudentIntern.Text = new clsEmployee(p_objContent.m_strGraduateStudentIntern).m_StrFirstName;
            //}
            //			if(p_objContent.m_strIntern != null && p_objContent.m_strIntern != "")
            //			{
            //				txtIntern.Tag = p_objContent.m_strIntern;
            //				txtIntern.Text = new clsEmployee(p_objContent.m_strIntern).m_StrFirstName;
            //			}
            //实习医生自己签名
            #endregion
            #region
            //  txtIntern.Text = p_objContent.m_strIntern;

            //if(p_objContent.m_strCoder != null && p_objContent.m_strCoder != "")
            //{
            //    txtCoder.Tag = p_objContent.m_strCoder;
            //    txtCoder.Text = new clsEmployee(p_objContent.m_strCoder).m_StrFirstName;
            //}
            txt_zhiliang.Text = p_objContent.m_strQuality;
          //  gpbQuality.Tag = p_objContent.m_strQuality;
            //switch (p_objContent.m_strQuality)
            //{
            //    case "0":
            //        rdbQuality1.Checked = true;
            //        break;
            //    case "1":
            //        rdbQuality2.Checked = true;
            //        break;
            //    case "2":
            //        rdbQuality3.Checked = true;
            //        break;
            //    default:
            //        break;
            //}
            //if(p_objContent.m_strQCDt != null && p_objContent.m_strQCDt != "")
            //{
            //    txtQCDt.Tag = p_objContent.m_strQCDt;
            //    txtQCDt.Text = new clsEmployee(p_objContent.m_strQCDt).m_StrFirstName;
            //}
            //if(p_objContent.m_strQCNurse != null && p_objContent.m_strQCNurse != "")
            //{
            //    txtQCNurse.Tag = p_objContent.m_strQCNurse;
            //    txtQCNurse.Text = new clsEmployee(p_objContent.m_strQCNurse).m_StrFirstName;
            //}
            dtpQCTime.Value = DateTime.Parse(p_objContent.m_strQCTime);
            switch (p_objContent.m_strOperation)
            {
                case "0":
                    radioButton1.Checked = true;
                    break;
                case "1":
                    radioButton2.Checked = true;
                    break;
                default:
                    break;
            }
            //switch (p_objContent.m_strBaby)
            //{
            //    case "0":
            //        radioButton3.Checked = true;
            //        break;
            //    case "1":
            //        radioButton4.Checked = true;
            //        break;
            //    default:
            //        break;
            //}
            gpbRTMode.Tag = p_objContent.m_strRTModeSeq;
            switch (p_objContent.m_strRTModeSeq)
            {
                case "0":
                    rdbRTCure.Checked = true;
                    break;
                case "1":
                    rdbRTAppeasement.Checked = true;
                    break;
                case "2":
                    rdbRTAssistant.Checked = true;
                    break;
                default:
                    break;
            }
            gpbRTRule.Tag = p_objContent.m_strRTRuleSeq;
            switch (p_objContent.m_strRTRuleSeq)
            {
                case "0":
                    rdbContinue.Checked = true;
                    break;
                case "1":
                    rdbRTGap.Checked = true;
                    break;
                case "2":
                    rdbRTSection.Checked = true;
                    break;
                default:
                    break;
            }
            if (p_objContent.m_strRTCo == "1")
                chkRTCo.Checked = true;
            else
                chkRTCo.Checked = false;
            if (p_objContent.m_strRTAccelerator == "1")
                chkRTAccelerator.Checked = true;
            else
                chkRTAccelerator.Checked = false;
            if (p_objContent.m_strRTX_Ray == "1")
                chkRTX_Ray.Checked = true;
            else
                chkRTX_Ray.Checked = false;
            if (p_objContent.m_strRTLacuna == "1")
                chkRTLacuna.Checked = true;
            else
                chkRTLacuna.Checked = false;
            gpbOriginalDisease.Tag = p_objContent.m_strOriginalDiseaseSeq;
            switch (p_objContent.m_strOriginalDiseaseSeq)
            {
                case "0":
                    rdbOriginalDiseaseFirst.Checked = true;
                    break;
                case "1":
                    rdbOriginalDiseaseRepeat.Checked = true;
                    break;
                default:
                    break;
            }
            //			txtOriginalDiseaseGy.m_mthSetNewText(p_objContent.m_strOriginalDiseaseGy,p_objMain.m_strOriginalDiseaseGyXML);
            //			txtOriginalDiseaseTimes.m_mthSetNewText(p_objContent.m_strOriginalDiseaseTimes,p_objMain.m_strOriginalDiseaseTimesXML);
            //			txtOriginalDiseaseDays.m_mthSetNewText(p_objContent.m_strOriginalDiseaseDays,p_objMain.m_strOriginalDiseaseDaysXML);
            txtOriginalDiseaseGy.Text = p_objContent.m_strOriginalDiseaseGy;
            txtOriginalDiseaseTimes.Text = p_objContent.m_strOriginalDiseaseTimes;
            txtOriginalDiseaseDays.Text = p_objContent.m_strOriginalDiseaseDays;
            dtpOriginalDiseaseBeginDate.Text = p_objContent.m_strOriginalDiseaseBeginDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strOriginalDiseaseBeginDate;
            dtpOriginalDiseaseEndDate.Text = p_objContent.m_strOriginalDiseaseEndDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strOriginalDiseaseEndDate;
            gpbLymph.Tag = p_objContent.m_strLymphSeq;
            switch (p_objContent.m_strLymphSeq)
            {
                case "0":
                    rdbLymphFirst.Checked = true;
                    break;
                case "1":
                    rdbLymphRepeat.Checked = true;
                    break;
                default:
                    break;
            }
            //			txtLymphGy.m_mthSetNewText(p_objContent.m_strLymphGy,p_objMain.m_strLymphGyXML);
            //			txtLymphTimes.m_mthSetNewText(p_objContent.m_strLymphTimes,p_objMain.m_strLymphTimesXML);
            #endregion 
            txtLymphDays.m_mthSetNewText(p_objContent.m_strLymphDays,p_objMain.m_strLymphDaysXML);
            txtLymphGy.Text = p_objContent.m_strLymphGy;
            txtLymphTimes.Text = p_objContent.m_strLymphTimes;
            txtLymphDays.Text = p_objContent.m_strLymphDays;
            dtpLymphBeginDate.Text = p_objContent.m_strLymphBeginDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strLymphBeginDate;
            dtpLymphEndDate.Text = p_objContent.m_strLymphEndDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strLymphEndDate;
            //			txtMetastasisGy.m_mthSetNewText(p_objContent.m_strMetastasisGy,p_objMain.m_strMetastasisGyXML);
            //			txtMetastasisTimes.m_mthSetNewText(p_objContent.m_strMetastasisTimes,p_objMain.m_strMetastasisTimesXML);
            //			txtMetastasisDays.m_mthSetNewText(p_objContent.m_strMetastasisDays,p_objMain.m_strMetastasisDaysXML);
            txtMetastasisGy.Text = p_objContent.m_strMetastasisGy;
            txtMetastasisTimes.Text = p_objContent.m_strMetastasisTimes;
            txtMetastasisDays.Text = p_objContent.m_strMetastasisDays;
            dtpMetastasisBeginDate.Text = p_objContent.m_strMetastasisBeginDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strMetastasisBeginDate;
            dtpMetastasisEndDate.Text = p_objContent.m_strMetastasisEndDate == "1900-01-01 00:00:00" ? "" : p_objContent.m_strMetastasisEndDate;
            gpbChemotherapyMode.Tag = p_objContent.m_strChemotherapyModeSeq;
            #region
            switch (p_objContent.m_strChemotherapyModeSeq)
            {
                case "0":
                    rdbChemotherapyCure.Checked = true;
                    break;
                case "1":
                    rdbChemotherapyAppeasement.Checked = true;
                    break;
                case "2":
                    rdbChemotherapyAssisantNew.Checked = true;
                    break;
                case "3":
                    rdbChemotherapyAssistant.Checked = true;
                    break;
                case "4":
                    rdbChemotherapyNewMedicine.Checked = true;
                    break;
                default:
                    break;
            }
            if (p_objContent.m_strChemotherapyWholeBody == "1")
                chkChemotherapyWholeBody.Checked = true;
            else
                chkChemotherapyWholeBody.Checked = false;
            if (p_objContent.m_strChemotherapyLocal == "1")
                chkChemotherapyLocal.Checked = true;
            else
                chkChemotherapyLocal.Checked = false;
            if (p_objContent.m_strChemotherapyIntubate == "1")
                chkChemotherapyIntubate.Checked = true;
            else
                chkChemotherapyIntubate.Checked = false;
            if (p_objContent.m_strChemotherapyThorax == "1")
                chkChemotherapyThorax.Checked = true;
            else
                chkChemotherapyThorax.Checked = false;
            if (p_objContent.m_strChemotherapyAbdomen == "1")
                chkChemotherapyAbdomen.Checked = true;
            else
                chkChemotherapyAbdomen.Checked = false;
            if (p_objContent.m_strChemotherapySpinal == "1")
                chkChemotherapySpinal.Checked = true;
            else
                chkChemotherapySpinal.Checked = false;
            if (p_objContent.m_strChemotherapyOtherTry == "1")
                chkChemotherapyOtherTry.Checked = true;
            else
                chkChemotherapyOtherTry.Checked = false;
            if (p_objContent.m_strChemotherapyOther == "1")
                chkChemotherapyOther.Checked = true;
            else
                chkChemotherapyOther.Checked = false;
            switch (p_objContent.m_strChemotherapy)
            {
                case "0":
                    radioButton5.Checked = true;
                    break;
                case "1":
                    radioButton6.Checked = true;
                    break;
                default:
                    break;
            }
            #endregion
            #region
            //			txtTotalAmt.m_mthSetNewText(p_objContent.m_strTotalAmt,p_objMain.m_strTotalAmtXML);
            //			txtBedAmt.m_mthSetNewText(p_objContent.m_strBedAmt,p_objMain.m_strBedAmtXML);
            //			txtNurseAmt.m_mthSetNewText(p_objContent.m_strNurseAmt,p_objMain.m_strNurseAmtXML);
            //			txtWMAmt.m_mthSetNewText(p_objContent.m_strWMAmt,p_objMain.m_strWMAmtXML);
            //			txtCMFinishedAmt.m_mthSetNewText(p_objContent.m_strCMFinishedAmt,p_objMain.m_strCMFinishedAmtXML);
            //			txtCMSemiFinishedAmt.m_mthSetNewText(p_objContent.m_strCMSemiFinishedAmt,p_objMain.m_strCMSemiFinishedAmtXML);
            //			txtRadiationAmt.m_mthSetNewText(p_objContent.m_strRadiationAmt,p_objMain.m_strRadiationAmtXML);
            //			txtAssayAmt.m_mthSetNewText(p_objContent.m_strAssayAmt,p_objMain.m_strAssayAmtXML);
            //			txtO2Amt.m_mthSetNewText(p_objContent.m_strO2Amt,p_objMain.m_strO2AmtXML);
            //			txtBloodAmt.m_mthSetNewText(p_objContent.m_strBloodAmt,p_objMain.m_strBloodAmtXML);
            //			txtTreatmentAmt.m_mthSetNewText(p_objContent.m_strTreatmentAmt,p_objMain.m_strTreatmentAmtXML);
            //			txtOperationAmt.m_mthSetNewText(p_objContent.m_strOperationAmt,p_objMain.m_strOperationAmtXML);
            //			txtDeliveryChildAmt.m_mthSetNewText(p_objContent.m_strDeliveryChildAmt,p_objMain.m_strDeliveryChildAmtXML);
            //			txtCheckAmt.m_mthSetNewText(p_objContent.m_strCheckAmt,p_objMain.m_strCheckAmtXML);
            //			txtAnaethesiaAmt.m_mthSetNewText(p_objContent.m_strAnaethesiaAmt,p_objMain.m_strAnaethesiaAmtXML);
            //			txtBabyAmt.m_mthSetNewText(p_objContent.m_strBabyAmt,p_objMain.m_strBabyAmtXML);
            //			txtAccompanyAmt.m_mthSetNewText(p_objContent.m_strAccompanyAmt,p_objMain.m_strAccompanyAmtXML);
            //			txtOtherAmt1.m_mthSetNewText(p_objContent.m_strOtherAmt1,p_objMain.m_strOtherAmt1XML);
            //			txtOtherAmt2.m_mthSetNewText(p_objContent.m_strOtherAmt2,p_objMain.m_strOtherAmt2XML);
            //			txtOtherAmt3.m_mthSetNewText(p_objContent.m_strOtherAmt3,p_objMain.m_strOtherAmt3XML);
            #endregion
            txtTotalAmt.Text = p_objContent.m_strTotalAmt;
            txtBedAmt.Text = p_objContent.m_strBedAmt;
            txtNurseAmt.Text = p_objContent.m_strNurseAmt;
            txtWMAmt.Text = p_objContent.m_strWMAmt;
            txtCMFinishedAmt.Text = p_objContent.m_strCMFinishedAmt;
            txtCMSemiFinishedAmt.Text = p_objContent.m_strCMSemiFinishedAmt;
            txtRadiationAmt.Text = p_objContent.m_strRadiationAmt;
            txtAssayAmt.Text = p_objContent.m_strAssayAmt;
            txtO2Amt.Text = p_objContent.m_strO2Amt;
            txtBloodAmt.Text = p_objContent.m_strBloodAmt;
            txtTreatmentAmt.Text = p_objContent.m_strTreatmentAmt;
            txtOperationAmt.Text = p_objContent.m_strOperationAmt;
            txtDeliveryChildAmt.Text = p_objContent.m_strDeliveryChildAmt;
            txtCheckAmt.Text = p_objContent.m_strCheckAmt;
            txtAnaethesiaAmt.Text = p_objContent.m_strAnaethesiaAmt;
            txtBabyAmt.Text = p_objContent.m_strBabyAmt;
            txtAccompanyAmt.Text = p_objContent.m_strAccompanyAmt;
            txtOtherAmt1.Text = p_objContent.m_strOtherAmt1;
            txtOtherAmt2.Text = p_objContent.m_strOtherAmt2;
            txtOtherAmt3.Text = p_objContent.m_strOtherAmt3;
            #region
            switch (p_objContent.m_strCorpseCheck)
            {
                case "1":
                    gpbCorpseCheck.Tag = "1";
                    rdbCorpseCheckYes.Checked = true;
                    break;
                case "0":
                    gpbCorpseCheck.Tag = "0";
                    rdbCorpseCheckNO.Checked = true;
                    break;
                default:
                    break;
            }

            switch (p_objContent.m_strFirstCase)
            {
                case "1":
                    gpbFirstCase.Tag = "1";
                    rdbFirstCaseYes.Checked = true;
                    break;
                case "0":
                    gpbFirstCase.Tag = "0";
                    rdbFirstCaseNO.Checked = true;
                    break;
                default:
                    break;
            }

            switch (p_objContent.m_strFollow)
            {
                case "1":
                    gpbFollow.Tag = "1";
                    rdbFollowYes.Checked = true;
                    break;
                case "0":
                    gpbFollow.Tag = "0";
                    rdbFollowNO.Checked = true;
                    break;
                default:
                    break;
            }
            //			txtFollow_Week.m_mthSetNewText(p_objContent.m_strFollow_Week,p_objMain.m_strFollow_WeekXML);
            //			txtFollow_Month.m_mthSetNewText(p_objContent.m_strFollow_Month,p_objMain.m_strFollow_MonthXML);
            //			txtFollow_Year.m_mthSetNewText(p_objContent.m_strFollow_Year,p_objMain.m_strFollow_YearXML);
            txtFollow_Week.Text = p_objContent.m_strFollow_Week;
            txtFollow_Month.Text = p_objContent.m_strFollow_Month;
            txtFollow_Year.Text = p_objContent.m_strFollow_Year;
             
            switch (p_objContent.m_strModelCase)
            {
                case "1":
                    gpbModelCase.Tag = "1";
                    rdbModelCaseYes.Checked = true;
                    break;
                case "0":
                    gpbModelCase.Tag = "0";
                    rdbModelCaseNO.Checked = true;
                    break;
                default:
                    break;
            }
            //			txtBloodType.m_mthSetNewText(p_objContent.m_strBloodType,p_objMain.m_strBloodTypeXML);
            txtBloodType.Text = p_objContent.m_strBloodType;
            switch (p_objContent.m_strBloodRh)
            {
                case "1":
                    gpbBloodRh.Tag = "1";
                    rdbBloodRh_Ka.Checked = true;
                    break;
                case "2":
                    gpbBloodRh.Tag = "2";
                    rdbBloodRh_An.Checked = true;
                    break;
                case "3":
                    gpbBloodRh.Tag = "3";
                    rdbBloodRh_No.Checked = true;
                    break;
                default:
                    break;
            }

            txt_shuxue.Text = p_objContent.m_strBloodTransActoin;

            //switch (p_objContent.m_strBloodTransActoin)
            //{
            //    case "1":
            //        gpbBloodTransAction.Tag = "1";
            //        rdbBloodTransActionYes.Checked = true;
            //        break;
            //    case "2":
            //        gpbBloodTransAction.Tag = "2";
            //        rdbBloodTransActionNO.Checked = true;
            //        break;
            //    case "3":
            //        gpbBloodTransAction.Tag = "3";
            //        rdbBloodTransNoAction.Checked = true;
            //        break;
            //    default:
            //        break;
            //}

            //			txtRBC.m_mthSetNewText(p_objContent.m_strRBC,p_objMain.m_strRBCXML);
            //			txtPLT.m_mthSetNewText(p_objContent.m_strPLT,p_objMain.m_strPLTXML);
            //			txtPlasm.m_mthSetNewText(p_objContent.m_strPlasm,p_objMain.m_strPlasmXML);
            //			txtWholeBlood.m_mthSetNewText(p_objContent.m_strWholeBlood,p_objMain.m_strWholeBloodXML);
            //			txtOtherBlood.m_mthSetNewText(p_objContent.m_strOtherBlood,p_objMain.m_strOtherBloodXML);
            //			txtConsultation.m_mthSetNewText(p_objContent.m_strConsultation,p_objMain.m_strConsultationXML);
            //			txtLongDistanctConsultation.m_mthSetNewText(p_objContent.m_strLongDistanctConsultation,p_objMain.m_strLongDistanctConsultationXML);
            //			txtTOPLevel.m_mthSetNewText(p_objContent.m_strTOPLevel,p_objMain.m_strTOPLevelXML);
            //			txtNurseLevelI.m_mthSetNewText(p_objContent.m_strNurseLevelI,p_objMain.m_strNurseLevelIXML);
            //			txtNurseLevelII.m_mthSetNewText(p_objContent.m_strNurseLevelII,p_objMain.m_strNurseLevelIIXML);
            //			txtNurseLevelIII.m_mthSetNewText(p_objContent.m_strNurseLevelIII,p_objMain.m_strNurseLevelIIIXML);
            //			txtICU.m_mthSetNewText(p_objContent.m_strICU,p_objMain.m_strICUXML);
            //			txtSpecialNurse.m_mthSetNewText(p_objContent.m_strSpecialNurse,p_objMain.m_strSpecialNurseXML);
            //
            //
            //			txtInsuranceNum.m_mthSetNewText(p_objContent.m_strInsuranceNum,p_objMain.m_strInsuranceNumXML);
            //			m_cboModeOfPayment.m_mthSetNewText(p_objContent.m_strModeOfPayment,p_objMain.m_strModeOfPaymentXML);
            //			txtPatientHistoryNO.m_mthSetNewText(p_objContent.m_strPatientHistoryNO,p_objMain.m_strPatientHistoryNOXML);
            #endregion 
            txtRBC.Text = p_objContent.m_strRBC;
            txtPLT.Text = p_objContent.m_strPLT;
            txtPlasm.Text = p_objContent.m_strPlasm;
            txtWholeBlood.Text = p_objContent.m_strWholeBlood;
            txtOtherBlood.Text = p_objContent.m_strOtherBlood;
            txtConsultation.Text = p_objContent.m_strConsultation;
            txtLongDistanctConsultation.Text = p_objContent.m_strLongDistanctConsultation;
            txtTOPLevel.Text = p_objContent.m_strTOPLevel;
            txtNurseLevelI.Text = p_objContent.m_strNurseLevelI;
            txtNurseLevelII.Text = p_objContent.m_strNurseLevelII;
            txtNurseLevelIII.Text = p_objContent.m_strNurseLevelIII;
            txtICU.Text = p_objContent.m_strICU;
            txtSpecialNurse.Text = p_objContent.m_strSpecialNurse;


            txtInsuranceNum.Text = p_objContent.m_strInsuranceNum;
            m_cboModeOfPayment.Text = p_objContent.m_strModeOfPayment;
            txtPatientHistoryNO.Text = p_objContent.m_strPatientHistoryNO;
            if (p_objContent.m_strChuShengData != DateTime.MinValue)
            {
                m_dtpBirthDate.Value = p_objContent.m_strChuShengData;
            }
            else
            {
                m_dtpBirthDate.Value = DateTime.Now;
            }
            m_txtNationality.Text = p_objContent.m_strGuoJi;
            m_txtCountry.Text = p_objContent.m_strShengShi;
            m_txtOccupation.Text = p_objContent.m_strZhiYe;
            m_txtNation.Text = p_objContent.m_strMingZhu;
            m_txtMarried.Text = p_objContent.m_strHunYin;
            m_txtHomePhone.Text = p_objContent.m_strDianHua;
            m_txtIDCard.Text = p_objContent.m_strShengFenID;
            txtchusheng.Text = p_objContent.m_strChuShenDi;
            m_txtCompanyName.Text = p_objContent.m_strGongZuoDanWei;
            m_txtOfficeAddress.Text = p_objContent.m_strDanWeiDiZhi;
            m_txtOfficePC.Text = p_objContent.m_strDanWeiYouBian;
            m_txtHomeAddress.Text = p_objContent.m_strHuKouZhuZhi;
            m_txtHomePC.Text = p_objContent.m_strHuKouYouBian;
            m_txtContactMan.Text = p_objContent.m_strLianXiRenName;
            m_txtRelation.Text = p_objContent.m_strLianXiRenGuanXi;
            m_txtContactManPhone.Text = p_objContent.m_strLianXiRenDianHua;
            m_txtContactManAddress.Text = p_objContent.m_strLianXiRenDiZhi;

            //int m_intSessionIndex = trvTime.Nodes[0].Nodes.Count - (trvTime.SelectedNode.Index);
            //clsInBedSessionInfo m_objSession = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_intSessionIndex-1);

            //if(m_objSession.m_DtmOutDate == DateTime.Parse("1900-01-01 00:00:00") || m_objSession.m_DtmOutDate == m_objSession.m_DtmInDate)//（没有出院日期，表示未曾出院）
            //    dtpOutHospitalDate.Value = DateTime.Now;
            //else
            //    dtpOutHospitalDate.Value = m_objSession.m_DtmOutDate;
        }
        #endregion

        #region 显示该次住院的住院病案首页的其它诊断表的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的其它诊断表的信息
        /// </summary>
        /// <param name="p_objOtherDiagnosisArr"></param>
        private void m_mthSetOtherDiagnosisInfo(clsInHospitalMainRecord_OtherDiagnosis[] p_objOtherDiagnosisArr)
        {
            if (p_objOtherDiagnosisArr == null || p_objOtherDiagnosisArr.Length <= 0)
                return;

            object[] m_objResArr = new object[7];
            #region
            for (int i1 = 0; i1 < p_objOtherDiagnosisArr.Length; i1++)
            {
                m_objResArr[0] = p_objOtherDiagnosisArr[i1].m_strDiagnosisDesc;
                switch (p_objOtherDiagnosisArr[i1].m_strConditionSeq)
                {
                    case "0":
                        m_objResArr[1] = true;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        break;
                    case "1":
                        m_objResArr[1] = false;
                        m_objResArr[2] = true;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        break;
                    case "2":
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = true;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        break;
                    case "3":
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = true;
                        m_objResArr[5] = false;
                        break;
                    case "4":
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = true;
                        break;
                    default:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        break;
                }
                m_objResArr[6] = p_objOtherDiagnosisArr[i1].m_strICD10;
                m_dtbOtherDiagnosis.Rows.Add(m_objResArr);

                m_dtbOtherDiagnosisz.Rows.Add(m_objResArr);
            }

            #endregion
        }
        #endregion

        #region 显示该次住院的住院病案首页的诊断记录
        /// <summary>
        /// 转换出院情况，按病案标准
        /// 1－治愈 2－好转 3－未愈 4－死亡 5－其他
        /// </summary>
        /// <param name="pstring">需要转换的字符</param>
        /// <param name="pflag">0 汉字to数字 1 数字to汉字</param>
        /// <returns></returns>
        private string ConvertState(string pstring, int pflag)
        {
            //默认出院情况为治愈
            string strState;
            if (pflag == 0)
            {
                try
                {
                    switch (pstring.Trim())
                    {
                        case "治愈":
                            strState = "1";
                            break;
                        case "好转":
                            strState = "2";
                            break;
                        case "未愈":
                            strState = "3";
                            break;
                        case "死亡":
                            strState = "4";
                            break;
                        case "其他":
                            strState = "5";
                            break;
                        default:
                            strState = "6";
                            break;
                    }
                }
                catch
                {
                    strState = "1";
                }
            }
            else
            {
                try
                {
                    switch (pstring.Trim())
                    {
                        case "1":
                            strState = "治愈";
                            break;
                        case "2":
                            strState = "好转";
                            break;
                        case "3":
                            strState = "未愈";
                            break;
                        case "4":
                            strState = "死亡";
                            break;
                        case "5":
                            strState = "其他";
                            break;
                        default:
                            strState = "";
                            break;
                    }
                }
                catch
                {
                    strState = "治愈";
                }
            }
            return strState;
        }

        private void m_mthSetDiagnosisInfo(clsInHospitalMainRecord_Diagnosis[] p_objDiagnosisArr)
        {
            m_dtbInHospitalDiagnosis.Rows.Clear();
            m_dtbInHospitalDiagnosisZhong.Rows.Clear();
            m_dtbOtherDiagnosis.Rows.Clear();
            m_dtbOtherDiagnosisz.Rows.Clear();
            m_dtbInfectionDiagnosis.Rows.Clear();
            m_dtbInfectionDiagnosisZhong.Rows.Clear();

            if (p_objDiagnosisArr == null || p_objDiagnosisArr.Length <= 0)
            {
                return;
            }

            m_dtbInHospitalDiagnosis.BeginLoadData();
            m_dtbInHospitalDiagnosisZhong.BeginLoadData();
            m_dtbOtherDiagnosis.BeginLoadData();
            m_dtbOtherDiagnosisz.BeginLoadData();
            m_dtbInfectionDiagnosis.BeginLoadData();
            m_dtbInfectionDiagnosisZhong.BeginLoadData();
            try
            {
                object[] objDia = null;
               // object[] objDia2 = null;
                for (int i = 0; i < p_objDiagnosisArr.Length; i++)
                {
                    string strType = p_objDiagnosisArr[i].m_strDIAGNOSISTYPE;
                    if (strType == "1")
                    {
                        objDia = new object[2];
                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        m_dtbInHospitalDiagnosis.LoadDataRow(objDia, true);

                        //objDia2 = new object[2];
                        //objDia2[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        //objDia2[1] = p_objDiagnosisArr[i].m_strICD10;
                        //m_dtbInHospitalDiagnosisZhong.LoadDataRow(objDia2, true);
                    }
                    else if (strType == "4")   //中医入院中断  SGH 2007/12/5
                    {
                        objDia = new object[2];
                        //objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        //objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        //m_dtbInHospitalDiagnosis.LoadDataRow(objDia, true);

                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        m_dtbInHospitalDiagnosisZhong.LoadDataRow(objDia, true);
                    }
                    else if (strType == "2")
                    {
                        objDia = new object[3];
                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        objDia[2] = ConvertState(p_objDiagnosisArr[i].m_strRESULT, 1);
                        m_dtbInfectionDiagnosis.LoadDataRow(objDia, true);
                    }
                    else if (strType == "6")
                    {
                        objDia = new object[3];
                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        objDia[2] = ConvertState(p_objDiagnosisArr[i].m_strRESULT, 1);
                        m_dtbInfectionDiagnosisZhong.LoadDataRow(objDia, true);
                    }
                    else if (strType == "3")
                    {
                        objDia = new object[3];
                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        objDia[2] = ConvertState(p_objDiagnosisArr[i].m_strRESULT, 1);
                        m_dtbOtherDiagnosis.LoadDataRow(objDia, true);
                    }
                    else if (strType == "5")
                    {
                        objDia = new object[3];
                        objDia[0] = p_objDiagnosisArr[i].m_strDIAGNOSIS;
                        objDia[1] = p_objDiagnosisArr[i].m_strICD10;
                        objDia[2] = ConvertState(p_objDiagnosisArr[i].m_strRESULT, 1);
                        m_dtbOtherDiagnosisz.LoadDataRow(objDia, true);
                    }
                }
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                m_dtbInHospitalDiagnosis.EndLoadData();
                m_dtbInHospitalDiagnosisZhong.EndLoadData();
                m_dtbOtherDiagnosis.EndLoadData();
                m_dtbOtherDiagnosisz.EndLoadData();
                m_dtbInfectionDiagnosis.EndLoadData();
                m_dtbInfectionDiagnosisZhong.EndLoadData();
            }
        }
        #endregion


        #region 显示该次住院的住院病案首页的手术情况表的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的手术情况表的信息
        /// </summary>
        /// <param name="p_objOperationArr"></param>
        private void m_mthSetOperationInfo(clsInHospitalMainRecord_Operation[] p_objOperationArr)
        {
            if (p_objOperationArr == null || p_objOperationArr.Length <= 0)
                return;

            object[] m_objResArr = new object[14];
            for (int i1 = 0; i1 < p_objOperationArr.Length; i1++)
            {
                m_objResArr[0] = p_objOperationArr[i1].m_strOperationID;
                m_objResArr[1] = p_objOperationArr[i1].m_strOperationDate;
                m_objResArr[2] = p_objOperationArr[i1].m_strOperationName;
                m_objResArr[3] = p_objOperationArr[i1].m_strOperatorName;
                m_objResArr[4] = p_objOperationArr[i1].m_strAssistant1Name;
                m_objResArr[5] = p_objOperationArr[i1].m_strAssistant2Name;
                //				if(p_objOperationArr[i1].m_strAanaesthesiaModeID == null || p_objOperationArr[i1].m_strAanaesthesiaModeID == "")
                //					m_objResArr[6] = p_objOperationArr[i1].m_strAanaesthesiaModeID;
                //				else
                //					m_objResArr[6] = m_hasAanaesthesiaMode[p_objOperationArr[i1].m_strAanaesthesiaModeID];
                m_objResArr[6] = p_objOperationArr[i1].m_strAanaesthesiaModeName;
                m_objResArr[7] = p_objOperationArr[i1].m_strCutLevel;
                //				m_objResArr[8] = new clsEmployee(p_objOperationArr[i1].m_strAnaesthetist).m_StrFirstName;
                m_objResArr[8] = p_objOperationArr[i1].m_strAnaesthetistName;
                m_objResArr[9] = p_objOperationArr[i1].m_strAanaesthesiaModeID;
                m_objResArr[10] = p_objOperationArr[i1].m_strOperator;

                m_objResArr[11] = p_objOperationArr[i1].m_strAssistant1;
                m_objResArr[12] = p_objOperationArr[i1].m_strAssistant2;
                m_objResArr[13] = p_objOperationArr[i1].m_strAnaesthetist;
                m_dtbOperationDetail.Rows.Add(m_objResArr);
            }
        }
        #endregion

        #region 显示该次住院的住院病案首页的婴儿表的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的婴儿表的信息
        /// </summary>
        /// <param name="p_objBabyArr"></param>
        private void m_mthSetBabyInfo(clsInHospitalMainRecord_Baby[] p_objBabyArr)
        {
            if (p_objBabyArr == null || p_objBabyArr.Length <= 0)
                return;
            object[] m_objResArr = new object[18];
            for (int i1 = 0; i1 < p_objBabyArr.Length; i1++)
            {
                m_objResArr[0] = ((int)(int.Parse(p_objBabyArr[i1].m_strSeqID) + 1)).ToString();
                if (p_objBabyArr[i1].m_strMale == "1")
                    m_objResArr[1] = true;
                else
                    m_objResArr[1] = false;
                if (p_objBabyArr[i1].m_strFemale == "1")
                    m_objResArr[2] = true;
                else
                    m_objResArr[2] = false;
                if (p_objBabyArr[i1].m_strLiveBorn == "1")
                    m_objResArr[3] = true;
                else
                    m_objResArr[3] = false;
                if (p_objBabyArr[i1].m_strDieBorn == "1")
                    m_objResArr[4] = true;
                else
                    m_objResArr[4] = false;
                if (p_objBabyArr[i1].m_strDieNotBorn == "1")
                    m_objResArr[5] = true;
                else
                    m_objResArr[5] = false;

                m_objResArr[6] = p_objBabyArr[i1].m_strWeight;

                if (p_objBabyArr[i1].m_strDie == "1")
                    m_objResArr[7] = true;
                else
                    m_objResArr[7] = false;
                if (p_objBabyArr[i1].m_strChangeDepartment == "1")
                    m_objResArr[8] = true;
                else
                    m_objResArr[8] = false;
                if (p_objBabyArr[i1].m_strOutHospital == "1")
                    m_objResArr[9] = true;
                else
                    m_objResArr[9] = false;
                if (p_objBabyArr[i1].m_strNaturalCondiction == "1")
                    m_objResArr[10] = true;
                else
                    m_objResArr[10] = false;
                if (p_objBabyArr[i1].m_strSuffocate1 == "1")
                    m_objResArr[11] = true;
                else
                    m_objResArr[11] = false;
                if (p_objBabyArr[i1].m_strSuffocate2 == "1")
                    m_objResArr[12] = true;
                else
                    m_objResArr[12] = false;

                m_objResArr[13] = p_objBabyArr[i1].m_strInfectionTimes;
                m_objResArr[14] = p_objBabyArr[i1].m_strInfectionName;
                m_objResArr[15] = p_objBabyArr[i1].m_strICD10;
                m_objResArr[16] = p_objBabyArr[i1].m_strSalveTimes;
                m_objResArr[17] = p_objBabyArr[i1].m_strSalveSuccessTimes;

                m_dtbBaby.Rows.Add(m_objResArr);
            }

        }
        #endregion

        #region 显示该次住院的住院病案首页的化疗表的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的化疗表的信息
        /// </summary>
        /// <param name="p_objChemotherapyArr"></param>
        //private void m_mthSetChemotherapyInfo(clsInHospitalMainRecord_Chemotherapy[] p_objChemotherapyArr)
        //{
        //    if (p_objChemotherapyArr == null || p_objChemotherapyArr.Length <= 0)
        //        return;

        //    object[] m_objResArr = new object[9];
        //    for (int i1 = 0; i1 < p_objChemotherapyArr.Length; i1++)
        //    {
        //        m_objResArr[0] = p_objChemotherapyArr[i1].m_strChemotherapyDate;
        //        m_objResArr[1] = p_objChemotherapyArr[i1].m_strMedicineName;
        //        m_objResArr[2] = p_objChemotherapyArr[i1].m_strPeriod;
        //        if (p_objChemotherapyArr[i1].m_strField_CR == "1")
        //            m_objResArr[3] = true;
        //        else
        //            m_objResArr[3] = false;
        //        if (p_objChemotherapyArr[i1].m_strField_PR == "1")
        //            m_objResArr[4] = true;
        //        else
        //            m_objResArr[4] = false;
        //        if (p_objChemotherapyArr[i1].m_strField_MR == "1")
        //            m_objResArr[5] = true;
        //        else
        //            m_objResArr[5] = false;
        //        if (p_objChemotherapyArr[i1].m_strField_S == "1")
        //            m_objResArr[6] = true;
        //        else
        //            m_objResArr[6] = false;
        //        if (p_objChemotherapyArr[i1].m_strField_P == "1")
        //            m_objResArr[7] = true;
        //        else
        //            m_objResArr[7] = false;
        //        if (p_objChemotherapyArr[i1].m_strField_NA == "1")
        //            m_objResArr[8] = true;
        //        else
        //            m_objResArr[8] = false;
        //        m_dtbChemotherapy.Rows.Add(m_objResArr);
        //    }
        //}
        #endregion

        protected override bool m_BlnCanTextChanged
        {
            get
            {
                return true;
            }
        }

        clsInBedSessionInfo objSessionInfo = null;

        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            //objSessionInfo = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1);
            //显式将m_ObjPeopleInfo置空，保证重新从数据库中读取最新的病人资料
            //因用户可能在本窗体(病案首页)修改病人基本资料
            //objSessionInfo.m_ObjPeopleInfo = null;
            p_objSelectedPatient.m_ObjPeopleInfo = null;
            clsPeopleInfo objPeopleInfo = p_objSelectedPatient.m_ObjPeopleInfo;

            lblSex.Text = objPeopleInfo.m_StrSex;
            lblAge.Text = objPeopleInfo.m_StrAge;
            if (objPeopleInfo.m_DtmBirth != null && objPeopleInfo.m_DtmBirth != DateTime.MinValue)
            {
                m_dtpBirthDate.Value = objPeopleInfo.m_DtmBirth;
            }
            else
            {
                objPeopleInfo.m_DtmBirth = DateTime.Now;
            }
            m_txtMarried.Text = objPeopleInfo.m_StrMarried;
            //m_txtOccupation.Text = objPeopleInfo.m_StrOccupation;
            m_txtNationality.Text = objPeopleInfo.m_StrNationality;
            m_txtNation.Text = objPeopleInfo.m_StrNation;
            m_txtIDCard.Text = objPeopleInfo.m_StrIDCard;
            lblProvince.Text = objPeopleInfo.m_StrHomeplace;
            m_txtCountry.Text = objPeopleInfo.m_StrNativePlace;

            m_txtOfficeAddress.Text = objPeopleInfo.m_StrOfficeAddress;
            m_txtCompanyName.Text = objPeopleInfo.m_StrOffice_name;

            m_txtHomePhone.Text = objPeopleInfo.m_StrHomePhone;//改为家庭电话
            m_txtOfficePC.Text = objPeopleInfo.m_StrOfficePC;

            m_txtHomeAddress.Text = objPeopleInfo.m_StrHomeAddress;

            m_txtHomePC.Text = objPeopleInfo.m_StrHomePC;
            m_txtContactMan.Text = objPeopleInfo.m_StrLinkManFirstName;
            m_txtRelation.Text = objPeopleInfo.m_StrPatientRelation;

            m_txtContactManAddress.Text = objPeopleInfo.m_StrLinkManAddress;
            m_txtLinkManzipcode.Text = objPeopleInfo.m_StrLinkManPC;

            m_txtContactManPhone.Text = objPeopleInfo.m_StrLinkManPhone;

            txtInsuranceNum.Text = objPeopleInfo.m_Strinsurance;
            m_cboModeOfPayment.Text = objPeopleInfo.m_StrPayTypeName;
        }
        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            m_objSelectedPatient = p_objSelectedPatient;
            //			m_mthCleanUP();
            //m_mthGetPatientDetailInfo();
        }

        #region 获得病人基本信息
        /// <summary>
        /// 获得病人基本信息
        /// </summary>
        private void m_mthGetPatientDetailInfo()
        {
            if (m_objSelectedPatient == null)
                return;

            //lblAge_Year.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy");
            //lblAge_Month.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("MM");
            //lblAge_Day.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("dd");
            //lblMarried.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
            //lblOccupation.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;			
            //lblNationality.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNationality;
            //lblNation.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            //lblIDCard.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrIDCard;
            //lblProvince.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;
            //lblCountry.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNativePlace;

            //lblOfficeAddress.Text =m_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_name+ "  "+m_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_district+
            //    m_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_street ;

            //lblOfficePhone.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePhone;
            //lblOfficePC.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficePC;

            //lblHomeAddress.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;

            //lblHomePC.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePC;
            //lblContactMan.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;
            //lblRelation.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrPatientRelation;

            //lblContactManAddress.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManAddress ;
            //lblLinkManzipcode.Text=m_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManPC;

            //lblContactManPhone.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManPhone;

            trvTime.Nodes[0].Nodes.Clear();
            TreeNode m_trnNewNode;
            for (int i1 = (m_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount() - 1); i1 >= 0; i1--)
            {
                m_trnNewNode = new TreeNode(m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i1).m_DtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                m_trnNewNode.Tag = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i1).m_DtmInDate;
                trvTime.Nodes[0].Nodes.Add(m_trnNewNode);
            }

            //选中默认节点
            for (int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
            {
                if ((DateTime)trvTime.Nodes[0].Nodes[i].Tag == m_objSelectedPatient.m_DtmSelectedInDate)
                    trvTime.SelectedNode = trvTime.Nodes[0].Nodes[i];
            }

            trvTime.ExpandAll();
        }
        #endregion

        protected override bool m_BlnIsAddNew
        {
            get
            {
                if (m_bolIfHasSave)
                    return false;
                else
                    return true;
            }
        }

        private bool m_bolSaveCheck()
        {
            if (m_objSelectedPatient == null)
            {
                m_mthShowNoPatient();
                return false;
            }
            //if(m_objSelectedPatient != null)
            //{
            //    //2003.4.24 wingo modify m_StrPatientID --> m_StrInPatientID
            //    if(m_objSelectedPatient.m_StrHISInPatientID != txtInPatientID.Text.Trim())
            //    {
            //        m_mthShowNoPatient();
            //        return false;
            //    }
            //}
            if (m_ObjCurrentEmrPatientSession == null || m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                return false;
            }
            this.button1.Focus();
            if (!m_blnIsDateRight)
            {
                return false;
            }
            string strTmp = m_chkForCmdCommit_Click();
            if (strTmp != "true")
            {
                return false;
            }
            //if(strTmp!="true")
            //{

            //    if(clsPublicFunction.ShowQuestionMessageBox(strTmp+"继续请确定！") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(string.IsNullOrEmpty(txtInsuranceNum.Text.Trim()))
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("社保号为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(string.IsNullOrEmpty(m_cboModeOfPayment.Text.Trim()))
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("医疗付款方式为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //			if(txtPatientHistoryNO.Text.Trim() == "")
            //			{
            //				if(clsPublicFunction.ShowQuestionMessageBox("病案号为空，是否继续？") == DialogResult.No)
            //				{
            //					return false;
            //				}
            //			}
            //if(string.IsNullOrEmpty(txtDiagnosis.Text.Trim()))
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("门诊（急）诊断为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(txtInHospitalDiagnosis.Text.Trim() == "")
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("入院诊断为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(txtDoctor.Tag == null || txtDoctor.Text.Trim() == string.Empty)
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("门诊（急）医生为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(dtpConfirmDiagnosisDate.Value == DateTime.Parse("1900-1-1"))
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("入院后确诊日期为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            //if(string.IsNullOrEmpty(txtMainDiagnosis.Text.Trim()))
            //{
            //    if(clsPublicFunction.ShowQuestionMessageBox("主要诊断为空，是否继续？") == DialogResult.No)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        #region 添加新纪录 m_lngSubAddNew
        /// <summary>
        /// 添加新纪录 m_lngSubAddNew
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubAddNew()
        {
            if (!m_bolSaveCheck())
                return -1;
            string m_strCurrentDateTime = m_objPublicDomain.m_strGetServerTime();
            string m_strInPatientID = m_objSelectedPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            bool m_bolIfSucceed = true;
            m_objCollection.m_objMain = m_objGetMain(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objContent = m_objGetContent(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objDiagnosisArr = m_objGetDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            m_objCollection.m_objOperationArr = m_objGetOperationArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            //m_objCollection.m_objBabyArr = m_objGetBabyArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            //m_objCollection.m_objChemotherapyArr = m_objGetChemotherapyArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            //电子签名 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID.Trim() + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(m_objCollection, objSign_VO) == -1)
                return -1;

            long m_lngRes = m_objDomain.m_lngDoSave(m_objCollection, m_BlnIsAddNew);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                m_objCollection.m_objMain = null;
                m_objCollection.m_objContent = null;
                m_objCollection.m_objBabyArr = null;
                m_objCollection.m_objChemotherapyArr = null;
                m_objCollection.m_objOperationArr = null;
                m_objCollection.m_objDiagnosisArr = null;
            }
            else
            {
                m_bolIfHasSave = true;
            }
            return m_lngRes;
        }

        #endregion


        #region 修改检查(删除，打印时也可用)
        /// <summary>
        /// 修改检查(删除，打印时也可用)
        /// </summary>
        /// <param name="p_bolMdfOrDel"></param>
        /// <returns></returns>
        private bool m_bolModifyCheck(bool p_bolMdfOrDel)
        {
            string m_strLastModifyDate = null;
            string m_strLastModifyUserID = null;
            if (m_objCollection == null || m_objCollection.m_objContent == null)
                return false;
            long m_lngRes = m_objDomain.m_lngGetLastModifyDateAndUser(m_objCollection.m_objContent.m_strInPatientID, m_objCollection.m_objContent.m_strInPatientDate, m_objCollection.m_objContent.m_strOpenDate, out m_strLastModifyDate, out m_strLastModifyUserID);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return false;
            }
            if (m_strLastModifyDate == null || m_strLastModifyDate == "")
            {
                string m_strDeactivedDate = null;
                string m_strDeactivedUserID = null;
                m_lngRes = m_objDomain.m_lngGetDeactivedDateAndUser(m_objCollection.m_objContent.m_strInPatientID, m_objCollection.m_objContent.m_strInPatientDate, out m_strDeactivedDate, out m_strDeactivedUserID);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return false;
                }
                else
                {
                    m_mthShowRecordDeleted(m_strDeactivedUserID, m_strDeactivedDate);
                    return false;
                }
            }

            if (DateTime.Parse(m_objCollection.m_objContent.m_strLastModifyDate) != DateTime.Parse(m_strLastModifyDate))
            {
                if (m_bolShowRecordModified(m_strLastModifyUserID, m_strLastModifyDate))
                {
                    m_mthCleanUpPatientInHospitalMainRecrodInfo();
                    m_mthCleanUpPatientDetailInfo();
                    m_mthSetPatientCurrentInHospitalDeptInfo();
                    m_mthDiaplayDetail();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (p_bolMdfOrDel)//修改时
                {
                    //					if(m_bolShowIfModify())
                    //					{
                    return true;
                    //					}
                    //					else
                    //					{
                    //						return false;
                    //					}
                }
                else//删除时
                {
                    return true;
                }
            }
        }

        #endregion
        #region 修改纪录 m_lngSubModify
        /// <summary>
        /// 修改纪录 m_lngSubModify
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubModify()
        {
            if (!m_bolSaveCheck())
                return -1;
            if (!m_bolModifyCheck(true))
                return -1;
            string m_strCurrentDateTime = m_objPublicDomain.m_strGetServerTime();
            string m_strInPatientID = m_objSelectedPatient.m_StrInPatientID;
            string m_strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            bool m_bolIfSucceed = true;

            clsInHospitalMainRecord_Main m_objMain = m_objGetMain(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_Content m_objContent = m_objGetContent(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_Diagnosis[] m_objDiagnosisArr = m_objGetDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_Operation[] m_objOperationArr = m_objGetOperationArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            //clsInHospitalMainRecord_Baby[] m_objBabyArr = m_objGetBabyArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            //clsInHospitalMainRecord_Chemotherapy[] m_objChemotherapyArr = m_objGetChemotherapyArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);


            //电子签名
            clsInHospitalMainRecord_Collection m_objCollection1 = new clsInHospitalMainRecord_Collection();
            m_objCollection1.m_objMain = m_objMain;
            m_objCollection1.m_objContent = m_objContent;
            m_objCollection1.m_objDiagnosisArr = m_objDiagnosisArr;
            m_objCollection1.m_objOperationArr = m_objOperationArr;
            //m_objCollection1.m_objBabyArr = m_objBabyArr;
            //m_objCollection1.m_objChemotherapyArr = m_objChemotherapyArr;
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID.Trim() + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(m_objCollection1, objSign_VO) == -1)
                return -1;
            //			long m_lngRes = m_objDomain.m_lngDoSave(m_objCollection.m_objMain,m_objCollection.m_objContent,m_objCollection.m_objOtherDiagnosisArr,m_objCollection.m_objOperationArr,m_objCollection.m_objBabyArr,m_objCollection.m_objChemotherapyArr,m_BlnIsAddNew);
            long m_lngRes = m_objDomain.m_lngDoSave(m_objCollection1, m_BlnIsAddNew);

            if (m_lngRes < 1)
            {
                m_mthShowDBError();
            }
            else
            {
                m_objCollection.m_objMain = m_objMain;
                m_objCollection.m_objContent = m_objContent;
                m_objCollection.m_objDiagnosisArr = m_objDiagnosisArr;
                m_objCollection.m_objOperationArr = m_objOperationArr;
                //m_objCollection.m_objBabyArr = m_objBabyArr;
                //m_objCollection.m_objChemotherapyArr = m_objChemotherapyArr;
            }
            //			if(m_lngRes > 0)
            //			{
            //				TreeNode m_trnTempNode = trvTime.SelectedNode;
            //				trvTime.SelectedNode = trvTime.Nodes[0];
            //				trvTime.SelectedNode = m_trnTempNode;
            //			}
            return m_lngRes;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        protected override long m_lngSubDelete()
        {
            if (m_objSelectedPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                m_mthShowNoPatient();
                return -1;
            }

            if (m_objCurrentContext.m_ObjControl.m_enmDeleteCheck(m_ObjCurrentEmrPatientSession.m_strAreaId, this, enmFormState.NowUser)
                == enmDBControlCheckResult.Disable)
            {
                clsPublicFunction.s_mthShowNotPermitMessage();
                return -1;
            }

            //if(m_objSelectedPatient != null)
            //{
            //    //2003.4.24 wingo modify m_StrPatientID --> m_StrInPatientID
            //    if(m_objSelectedPatient.m_StrHISInPatientID != txtInPatientID.Text.Trim())
            //    {
            //        m_mthShowNoPatient();
            //        return -1;
            //    }
            //}
            if (m_objCollection == null)
            {
                return -1;
            }
            //if(trvTime.Nodes[0].Nodes.Count <=0 || trvTime.SelectedNode == null)
            //    return -1;			

            if (!m_bolModifyCheck(false))
                return -1;

            long m_lngRes = m_objDomain.m_lngDeleteRecord(m_objCollection.m_objContent.m_strInPatientID, m_objCollection.m_objContent.m_strInPatientDate, m_objCollection.m_objContent.m_strOpenDate, MDIParent.OperatorID);
            if (m_lngRes < 1)
            {
                base.m_mthShowDBError();
                return -1;
            }
            else
            {
                //trvTime_AfterSelect(null,null);
                m_objCollection.m_objMain = null;
                m_objCollection.m_objContent = null;
                m_objCollection.m_objBabyArr = null;
                m_objCollection.m_objChemotherapyArr = null;
                m_objCollection.m_objOperationArr = null;
                m_objCollection.m_objDiagnosisArr = null;
                return 1;
            }
        }
        #endregion
        #region 获得主表的内容
        /// <summary>
        /// 获得主表的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_Main m_objGetMain(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            clsInHospitalMainRecord_Main m_objMain = new clsInHospitalMainRecord_Main();
            try
            {
                string aaa = this.m_dgtbInDia.TextBox.Text;
  
                m_objMain.m_strInPatientID = p_strInPatientID;
                m_objMain.m_strInPatientDate = p_strInPatientDate;
                if (m_bolIfHasSave)
                    m_objMain.m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
                else
                    m_objMain.m_strOpenDate = p_strCurrentDateTime;
                m_objMain.m_strCreateUserID = MDIParent.OperatorID;
                m_objMain.m_strDeActivedDate = "";
                m_objMain.m_strDeActivedOperatorID = "";
                m_objMain.m_strStatus = "1";
                m_objMain.m_strDiagnosisXML = txtDiagnosis.m_strGetXmlText();
                m_objMain.m_strDiagnosiszhongXML = txtDiagnosisZhongYi.m_strGetXmlText();
                //m_objMain.m_strInHospitalDiagnosisXML = txtInHospitalDiagnosis.m_strGetXmlText();
                m_objMain.m_strMainDiagnosisXML = txtMainDiagnosis.m_strGetXmlText();
                m_objMain.m_strMainDiagnosisZhongXML = txtMainDiagnosiszhongyi.m_strGetXmlText();
                m_objMain.m_strZhuZhengXML = txtzhuzheng.m_strGetXmlText();
                m_objMain.m_strICD_10OfMainXML = txtICD_10OfMain.m_strGetXmlText();

                m_objMain.m_strWeiZhongXML = txtweizhong.m_strGetXmlText();
                m_objMain.m_strJiZhengXML = txtjizheng.m_strGetXmlText();
                m_objMain.m_strYiNanXML = txtyinanqingkuang.m_strGetXmlText();
                m_objMain.m_strFangFaXML = txtSalveMethod.m_strGetXmlText();

                m_objMain.m_strShouShuXML = txtshoushu.m_strGetXmlText();
                m_objMain.m_strZiLiaoXML = txt_zhiliao.m_strGetXmlText();
                m_objMain.m_strZDuanXML = txtzhengduan.m_strGetXmlText();
                m_objMain.m_strJianChaXML = txtjiancha.m_strGetXmlText();
                m_objMain.m_strSiWangXML = txtdeathreason.m_strGetXmlText();
                if (dtpdeathtime.Text != "")
                {
                    m_objMain.m_strDeathTime = dtpdeathtime.Text;
                }
                else
                {
                    m_objMain.m_strDeathTime = "";
                }

                //m_objMain.m_strInfectionDiagnosisXML = txtInfectionDiagnosis.m_strGetXmlText();
                //m_objMain.m_strICD_10OfInfectionXML = txtICD_10OfInfection.m_strGetXmlText();
                m_objMain.m_strPathologyDiagnosisXML = txtPathologyDiagnosis.m_strGetXmlText();
                m_objMain.m_strScacheSourceXML = txtScacheSource.m_strGetXmlText();
                m_objMain.m_strSensitiveXML = txtSensitive.m_strGetXmlText();
                m_objMain.m_strHbsAgXML = txtHbsAg.m_strGetXmlText();
                m_objMain.m_strHCV_AbXML = txtHCV_Ab.m_strGetXmlText();
                m_objMain.m_strHIV_AbXML = txtHIV_Ab.m_strGetXmlText();
                m_objMain.m_strAccordWithOutHospitalXML = txtAccordWithOutHospital.m_strGetXmlText();

                m_objMain.m_strAccordWithOutHospitalZhongXML = txtAccordWithOutHospitalzhong.m_strGetXmlText();
                m_objMain.m_strAccordInWithOutXML = txtAccordInWithOut.m_strGetXmlText();
                m_objMain.m_strAccordInWithOutZhongXML = txtAccordInWithOutzhong.m_strGetXmlText();
                m_objMain.m_strAccordBeforeOperationWithAfterXML = txtAccordBeforeOperationWithAfter.m_strGetXmlText();
                m_objMain.m_strAccordClinicWithPathologyXML = txtAccordClinicWithPathology.m_strGetXmlText();
                m_objMain.m_strAccordRadiateWithPathologyXML = txtAccordRadiateWithPathology.m_strGetXmlText();
                m_objMain.m_strSalveTimesXML = txtSalveTimes.m_strGetXmlText();
                m_objMain.m_strSalveSuccessXML = txtSalveSuccess.m_strGetXmlText();
                m_objMain.m_strChuYuanFangShiXML = txtchuyuanfangshi.m_strGetXmlText();
                m_objMain.m_strZhiLiaoLeiBieXML = txtleibie.m_strGetXmlText();
                m_objMain.m_strZhongYaoZhiJiXML = txtzhiji.m_strGetXmlText();
                m_objMain.m_strRuYuanTuJingXML = txtruyuantujing.m_strGetXmlText();
                m_objMain.m_strWaiYaunZhiLiaoXML = txtruyuanqian.m_strGetXmlText();
                m_objMain.m_strBingLiHaoXML = txtbinglihao.Text;

                m_objMain.m_strOriginalDiseaseGyXML = txtOriginalDiseaseGy.m_strGetXmlText();
                m_objMain.m_strOriginalDiseaseTimesXML = txtOriginalDiseaseTimes.m_strGetXmlText();
                m_objMain.m_strOriginalDiseaseDaysXML = txtOriginalDiseaseDays.m_strGetXmlText();
                m_objMain.m_strLymphGyXML = txtLymphGy.m_strGetXmlText();
                m_objMain.m_strLymphTimesXML = txtLymphTimes.m_strGetXmlText();
                m_objMain.m_strLymphDaysXML = txtLymphDays.m_strGetXmlText();
                m_objMain.m_strMetastasisGyXML = txtMetastasisGy.m_strGetXmlText();
                m_objMain.m_strMetastasisTimesXML = txtMetastasisTimes.m_strGetXmlText();
                m_objMain.m_strMetastasisDaysXML = txtMetastasisDays.m_strGetXmlText();
                m_objMain.m_strTotalAmtXML = txtTotalAmt.m_strGetXmlText();
                m_objMain.m_strBedAmtXML = txtBedAmt.m_strGetXmlText();
                m_objMain.m_strNurseAmtXML = txtNurseAmt.m_strGetXmlText();
                m_objMain.m_strWMAmtXML = txtWMAmt.m_strGetXmlText();
                m_objMain.m_strCMFinishedAmtXML = txtCMFinishedAmt.m_strGetXmlText();
                m_objMain.m_strCMSemiFinishedAmtXML = txtCMSemiFinishedAmt.m_strGetXmlText();
                m_objMain.m_strRadiationAmtXML = txtRadiationAmt.m_strGetXmlText();
                m_objMain.m_strAssayAmtXML = txtAssayAmt.m_strGetXmlText();
                m_objMain.m_strO2AmtXML = txtO2Amt.m_strGetXmlText();
                m_objMain.m_strBloodAmtXML = txtBloodAmt.m_strGetXmlText();
                m_objMain.m_strTreatmentAmtXML = txtTreatmentAmt.m_strGetXmlText();
                m_objMain.m_strOperationAmtXML = txtOperationAmt.m_strGetXmlText();
                m_objMain.m_strDeliveryChildAmtXML = txtDeliveryChildAmt.m_strGetXmlText();
                m_objMain.m_strCheckAmtXML = txtCheckAmt.m_strGetXmlText();
                m_objMain.m_strAnaethesiaAmtXML = txtAnaethesiaAmt.m_strGetXmlText();
                m_objMain.m_strBabyAmtXML = txtBabyAmt.m_strGetXmlText();
                m_objMain.m_strAccompanyAmtXML = txtAccompanyAmt.m_strGetXmlText();
                m_objMain.m_strOtherAmt1XML = txtOtherAmt1.m_strGetXmlText();
                m_objMain.m_strOtherAmt2XML = txtOtherAmt2.m_strGetXmlText();
                m_objMain.m_strOtherAmt3XML = txtOtherAmt3.m_strGetXmlText();
                m_objMain.m_strFollow_WeekXML = txtFollow_Week.m_strGetXmlText();
                m_objMain.m_strFollow_MonthXML = txtFollow_Month.m_strGetXmlText();
                m_objMain.m_strFollow_YearXML = txtFollow_Year.m_strGetXmlText();
                m_objMain.m_strBloodTypeXML = txtBloodType.m_strGetXmlText();
                m_objMain.m_strShuYeXML = txt_shuye.m_strGetXmlText();
                m_objMain.m_strRBCXML = txtRBC.m_strGetXmlText();
                m_objMain.m_strPLTXML = txtPLT.m_strGetXmlText();
                m_objMain.m_strPlasmXML = txtPlasm.m_strGetXmlText();
                m_objMain.m_strWholeBloodXML = txtWholeBlood.m_strGetXmlText();
                m_objMain.m_strOtherBloodXML = txtOtherBlood.m_strGetXmlText();
                m_objMain.m_strConsultationXML = txtConsultation.m_strGetXmlText();
                m_objMain.m_strLongDistanctConsultationXML = txtLongDistanctConsultation.m_strGetXmlText();
                m_objMain.m_strTOPLevelXML = txtTOPLevel.m_strGetXmlText();
                m_objMain.m_strNurseLevelIXML = txtNurseLevelI.m_strGetXmlText();
                m_objMain.m_strNurseLevelIIXML = txtNurseLevelII.m_strGetXmlText();
                m_objMain.m_strNurseLevelIIIXML = txtNurseLevelIII.m_strGetXmlText();
                m_objMain.m_strICUXML = txtICU.m_strGetXmlText();
                m_objMain.m_strSpecialNurseXML = txtSpecialNurse.m_strGetXmlText();

                m_objMain.m_strInsuranceNumXML = txtInsuranceNum.m_strGetXmlText();
                m_objMain.m_strModeOfPaymentXML = string.Empty;
                m_objMain.m_strPatientHistoryNOXML = txtPatientHistoryNO.m_strGetXmlText();

                m_objMain.m_strMZICD10 = txtDiagnosisICD10.Text;
                m_objMain.m_strMAINICD10 = txtICD_10OfMain.Text;
                m_objMain.m_strMAINICD10Zhong = txtICD_10OfMainzhongyi.Text;

                m_objMain.m_strZhuZhengICDS = txtzhuzhengICD.Text;
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objMain;
        }
        #endregion

        #region 获得子表的内容
        /// <summary>
        /// 获得子表的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_Content m_objGetContent(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            clsInHospitalMainRecord_Content m_objContent = new clsInHospitalMainRecord_Content();
            try
            {
              

                m_objContent.m_strInPatientID = p_strInPatientID;
                m_objContent.m_strInPatientDate = p_strInPatientDate;
                if (m_bolIfHasSave)
                    m_objContent.m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
                else
                    m_objContent.m_strOpenDate = p_strCurrentDateTime;
                //				m_objContent.m_strOpenDate = p_strCurrentDateTime;
                m_objContent.m_strLastModifyDate = p_strCurrentDateTime;
                m_objContent.m_strLastModifyUserID = MDIParent.OperatorID;
                m_objContent.m_strDeActivedDate = "";
                m_objContent.m_strDeActivedOperatorID = "";
                m_objContent.m_strStatus = "1";
                m_objContent.m_strDiagnosis = txtDiagnosis.Text;
                m_objContent.m_strDiagnosiszhong = txtDiagnosisZhongYi.Text;
                //m_objContent.m_strInHospitalDiagnosis = txtInHospitalDiagnosis.Text;
                if (txtDoctor.Tag == null)
                    m_objContent.m_strDoctor = "";
                else
                    m_objContent.m_strDoctor = ((clsEmrEmployeeBase_VO)txtDoctor.Tag).m_strEMPID_CHR;
                if (dtpConfirmDiagnosisDate.Value.Date >= Convert.ToDateTime(m_objContent.m_strInPatientDate).Date && dtpConfirmDiagnosisDate.Value < DateTime.Now)
                {
                    m_objContent.m_strConfirmDiagnosisDate = dtpConfirmDiagnosisDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    MessageBox.Show("确诊日期应该在入院日期与出院日期之间!", "输入有误", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dtpConfirmDiagnosisDate.Focus();

                    return null;
                }

                m_objContent.m_strCondictionWhenIn = gpbCondictionWhenIn.Tag.ToString();
                m_objContent.m_strMainDiagnosis = txtMainDiagnosis.Text;
                m_objContent.m_strMainDiagnosisZhong = txtMainDiagnosiszhongyi.Text;
                m_objContent.m_strZhuZheng = txtzhuzheng.Text;
                //m_objContent.m_strMainConditionSeq = gpbMainDiagnosis.Tag.ToString();
                if (m_cboMainSeq.SelectedIndex >= 0)
                {
                    m_objContent.m_strMainConditionSeq = m_cboMainSeq.SelectedIndex.ToString();
                }
                else
                {
                    m_objContent.m_strMainConditionSeq = "-1";
                }

                if (m_cboMainSeqzhongyi.SelectedIndex >= 0)
                {
                    m_objContent.m_strMainConditionSeqZhong = m_cboMainSeqzhongyi.SelectedIndex.ToString();
                }
                else
                {
                    m_objContent.m_strMainConditionSeqZhong = "-1";
                }

                if (m_cboMainSeqzhzhu.SelectedIndex >= 0)
                {
                    m_objContent.m_strZhuZhengSeq = m_cboMainSeqzhzhu.SelectedIndex.ToString();
                }
                else
                {
                    m_objContent.m_strZhuZhengSeq = "-1";
                }

                m_objContent.m_strICD_10OfMain = txtICD_10OfMain.Text;
                m_objContent.m_strICD_10OfMainZhong = txtICD_10OfMainzhongyi.Text;
                m_objContent.m_strZhuZhengICD = txtzhuzhengICD.Text;
                //m_objContent.m_strInfectionDiagnosis = txtInfectionDiagnosis.Text;
                //m_objContent.m_strInfectionCondictionSeq = gpbInfection.Tag.ToString();
                //m_objContent.m_strICD_10OfInfection = txtICD_10OfInfection.Text;

                m_objContent.m_strWeiZhong = txtweizhong.Text;
                m_objContent.m_strJiZheng = txtjizheng.Text;
                m_objContent.m_strYiNan = txtyinanqingkuang.Text;
                m_objContent.m_strFangFa = txtSalveMethod.Text;


                m_objContent.m_strShouShu = txtshoushu.Text;
                m_objContent.m_strZiLiao = txt_zhiliao.Text;
                m_objContent.m_strJianCha = txtjiancha.Text;
                m_objContent.m_strZDuan = txtzhengduan.Text;
                m_objContent.m_strSiWang = txtdeathreason.Text;
                if (dtpdeathtime.Text != "")
                {
                    m_objContent.m_strSiWangTime = dtpdeathtime.Text;
                }
                else
                {
                    m_objContent.m_strSiWangTime = "";
                }
                m_objContent.m_strPathologyDiagnosis = txtPathologyDiagnosis.Text;
                m_objContent.m_strScacheSource = txtScacheSource.Text;
                m_objContent.m_strSensitive = txtSensitive.Text;
                m_objContent.m_strHbsAg = txtHbsAg.Text;
                m_objContent.m_strHCV_Ab = txtHCV_Ab.Text;
                m_objContent.m_strHIV_Ab = txtHIV_Ab.Text;
                m_objContent.m_strAccordWithOutHospital = txtAccordWithOutHospital.Text;
                m_objContent.m_strAccordWithOutHospitalZhong = txtAccordWithOutHospitalzhong.Text;
                m_objContent.m_strAccordInWithOut = txtAccordInWithOut.Text;
                m_objContent.m_strAccordInWithOutZhong = txtAccordInWithOutzhong.Text;
                m_objContent.m_strAccordBeforeOperationWithAfter = txtAccordBeforeOperationWithAfter.Text;
                m_objContent.m_strAccordClinicWithPathology = txtAccordClinicWithPathology.Text;

                m_objContent.m_strAccordRadiateWithPathology = txtAccordRadiateWithPathology.Text;
                m_objContent.m_strSalveTimes = txtSalveTimes.Text;
                m_objContent.m_strSalveSuccess = txtSalveSuccess.Text;
                m_objContent.m_strChuYuanFangShi = txtchuyuanfangshi.Text;
                m_objContent.m_strZhiLiaoLeiBie = txtleibie.Text;
                m_objContent.m_strZhongYaoZhiJi = txtzhiji.Text;
                m_objContent.m_strRuYuanTuJing = txtruyuantujing.Text;
                m_objContent.m_strWaiYaunZhiLiao = txtruyuanqian.Text;
                m_objContent.m_strBingLiHao = txtbinglihao.Text;

              //  m_objContent.m_strBirthPlace = m_cboProvince.Text + ">>" + m_cboCity.Text + ">>" + m_cboCounty.Text;
                m_objContent.m_strBirthPlace = txtchusheng.Text;
                if (txtDirectorDt.Tag == null)
                    m_objContent.m_strDirectorDt = "";
                else
                    m_objContent.m_strDirectorDt = ((clsEmrEmployeeBase_VO)txtDirectorDt.Tag).m_strEMPID_CHR;
                if (txtSubDirectorDt.Tag == null)
                    m_objContent.m_strSubDirectorDt = "";
                else
                    m_objContent.m_strSubDirectorDt = ((clsEmrEmployeeBase_VO)txtSubDirectorDt.Tag).m_strEMPID_CHR;
                if (txtDt.Tag == null)
                {
                    m_objContent.m_strDt = "";
                    //MessageBox.Show("主治医师必须签名", "签名警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return null;
                }
                else
                {
                    m_objContent.m_strDt = ((clsEmrEmployeeBase_VO)txtDt.Tag).m_strEMPID_CHR;
                }
                if (txtInHospitalDt.Tag == null)
                    m_objContent.m_strInHospitalDt = "";
                else
                    m_objContent.m_strInHospitalDt = ((clsEmrEmployeeBase_VO)txtInHospitalDt.Tag).m_strEMPID_CHR;
                if (txtAttendInForAdvancesStudyDt.Tag == null)
                    m_objContent.m_strAttendInForAdvancesStudyDt = "";
                else
                    m_objContent.m_strAttendInForAdvancesStudyDt = ((clsEmrEmployeeBase_VO)txtAttendInForAdvancesStudyDt.Tag).m_strEMPID_CHR;
                if (txtGraduateStudentIntern.Tag == null)
                    m_objContent.m_strGraduateStudentIntern = "";
                else
                    m_objContent.m_strGraduateStudentIntern = ((clsEmrEmployeeBase_VO)txtGraduateStudentIntern.Tag).m_strEMPID_CHR;
                //				if(txtIntern.Tag == null)
                //					m_objContent.m_strIntern = "";
                //				else
                //					m_objContent.m_strIntern = txtIntern.Tag.ToString();
                //实习医生自己签名
                //m_objContent.m_strIntern = txtIntern.Text;

                if (txtIntern.Tag == null)
                    m_objContent.m_strIntern = "";
                else
                    m_objContent.m_strIntern = ((clsEmrEmployeeBase_VO)txtIntern.Tag).m_strEMPID_CHR;

                if (txtCoder.Tag == null)
                    m_objContent.m_strCoder = "";
                else
                    m_objContent.m_strCoder = ((clsEmrEmployeeBase_VO)txtCoder.Tag).m_strEMPID_CHR;
                //if (gpbQuality.Tag == null)
                //{
                //    m_objContent.m_strQuality = "";
                //}
                //else
                //{
                //    m_objContent.m_strQuality = gpbQuality.Tag.ToString();
                //}

                m_objContent.m_strQuality = txt_zhiliang.Text;

                if (txtQCDt.Tag == null)
                    m_objContent.m_strQCDt = "";
                else
                    m_objContent.m_strQCDt = ((clsEmrEmployeeBase_VO)txtQCDt.Tag).m_strEMPID_CHR;
                if (txtQCNurse.Tag == null)
                {
                    m_objContent.m_strQCNurse = "";
                    //MessageBox.Show("质控护士必须签名", "签名警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return null ;
                }
                else
                {
                    m_objContent.m_strQCNurse = ((clsEmrEmployeeBase_VO)txtQCNurse.Tag).m_strEMPID_CHR;
                }
                m_objContent.m_strQCTime = dtpQCTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                m_objContent.m_strRTModeSeq = gpbRTMode.Tag.ToString();
                m_objContent.m_strRTRuleSeq = gpbRTRule.Tag.ToString();
                if (radioButton1.Checked)
                    m_objContent.m_strOperation = "0";
                else
                    m_objContent.m_strOperation = "1";
                //if (radioButton3.Checked)
                //    m_objContent.m_strBaby = "0";
                //else
                //    m_objContent.m_strBaby = "1";
                if (chkRTCo.Checked)
                    m_objContent.m_strRTCo = "1";
                else
                    m_objContent.m_strRTCo = "0";
                if (chkRTAccelerator.Checked)
                    m_objContent.m_strRTAccelerator = "1";
                else
                    m_objContent.m_strRTAccelerator = "0";
                if (chkRTX_Ray.Checked)
                    m_objContent.m_strRTX_Ray = "1";
                else
                    m_objContent.m_strRTX_Ray = "0";
                if (chkRTLacuna.Checked)
                    m_objContent.m_strRTLacuna = "1";
                else
                    m_objContent.m_strRTLacuna = "0";

                m_objContent.m_strOriginalDiseaseSeq = gpbOriginalDisease.Tag.ToString();
                m_objContent.m_strOriginalDiseaseGy = txtOriginalDiseaseGy.Text;
                m_objContent.m_strOriginalDiseaseTimes = txtOriginalDiseaseTimes.Text;
                m_objContent.m_strOriginalDiseaseDays = txtOriginalDiseaseDays.Text;
                m_objContent.m_strOriginalDiseaseBeginDate = dtpOriginalDiseaseBeginDate.Text;
                m_objContent.m_strOriginalDiseaseEndDate = dtpOriginalDiseaseEndDate.Text;
                m_objContent.m_strLymphSeq = gpbLymph.Tag.ToString();
                m_objContent.m_strLymphGy = txtLymphGy.Text;
                m_objContent.m_strLymphTimes = txtLymphTimes.Text;
                m_objContent.m_strLymphDays = txtLymphDays.Text;
                m_objContent.m_strLymphBeginDate = dtpLymphBeginDate.Text;
                m_objContent.m_strLymphEndDate = dtpLymphEndDate.Text;
                m_objContent.m_strMetastasisGy = txtMetastasisGy.Text;
                m_objContent.m_strMetastasisTimes = txtMetastasisTimes.Text;
                m_objContent.m_strMetastasisDays = txtMetastasisDays.Text;
                m_objContent.m_strMetastasisBeginDate = dtpMetastasisBeginDate.Text;
                m_objContent.m_strMetastasisEndDate = dtpMetastasisEndDate.Text;
                m_objContent.m_strChemotherapyModeSeq = gpbChemotherapyMode.Tag.ToString();
                if (chkChemotherapyWholeBody.Checked)
                    m_objContent.m_strChemotherapyWholeBody = "1";
                else
                    m_objContent.m_strChemotherapyWholeBody = "0";
                if (chkChemotherapyLocal.Checked)
                    m_objContent.m_strChemotherapyLocal = "1";
                else
                    m_objContent.m_strChemotherapyLocal = "0";
                if (chkChemotherapyIntubate.Checked)
                    m_objContent.m_strChemotherapyIntubate = "1";
                else
                    m_objContent.m_strChemotherapyIntubate = "0";
                if (chkChemotherapyThorax.Checked)
                    m_objContent.m_strChemotherapyThorax = "1";
                else
                    m_objContent.m_strChemotherapyThorax = "0";
                if (chkChemotherapyAbdomen.Checked)
                    m_objContent.m_strChemotherapyAbdomen = "1";
                else
                    m_objContent.m_strChemotherapyAbdomen = "0";
                if (chkChemotherapySpinal.Checked)
                    m_objContent.m_strChemotherapySpinal = "1";
                else
                    m_objContent.m_strChemotherapySpinal = "0";
                if (chkChemotherapyOtherTry.Checked)
                    m_objContent.m_strChemotherapyOtherTry = "1";
                else
                    m_objContent.m_strChemotherapyOtherTry = "0";
                if (chkChemotherapyOther.Checked)
                    m_objContent.m_strChemotherapyOther = "1";
                else
                    m_objContent.m_strChemotherapyOther = "0";
                if (radioButton5.Checked)
                    m_objContent.m_strChemotherapy = "0";
                else
                    m_objContent.m_strChemotherapy = "1";

                m_objContent.m_strTotalAmt = txtTotalAmt.Text;
                m_objContent.m_strBedAmt = txtBedAmt.Text;
                m_objContent.m_strNurseAmt = txtNurseAmt.Text;
                m_objContent.m_strWMAmt = txtWMAmt.Text;
                m_objContent.m_strCMFinishedAmt = txtCMFinishedAmt.Text;
                m_objContent.m_strCMSemiFinishedAmt = txtCMSemiFinishedAmt.Text;
                m_objContent.m_strRadiationAmt = txtRadiationAmt.Text;
                m_objContent.m_strAssayAmt = txtAssayAmt.Text;
                m_objContent.m_strO2Amt = txtO2Amt.Text;
                m_objContent.m_strBloodAmt = txtBloodAmt.Text;
                m_objContent.m_strTreatmentAmt = txtTreatmentAmt.Text;
                m_objContent.m_strOperationAmt = txtOperationAmt.Text;
                m_objContent.m_strDeliveryChildAmt = txtDeliveryChildAmt.Text;
                m_objContent.m_strCheckAmt = txtCheckAmt.Text;
                m_objContent.m_strAnaethesiaAmt = txtAnaethesiaAmt.Text;
                m_objContent.m_strBabyAmt = txtBabyAmt.Text;
                m_objContent.m_strAccompanyAmt = txtAccompanyAmt.Text;
                m_objContent.m_strOtherAmt1 = txtOtherAmt1.Text;
                m_objContent.m_strOtherAmt2 = txtOtherAmt2.Text;
                m_objContent.m_strOtherAmt3 = txtOtherAmt3.Text;
                m_objContent.m_strCorpseCheck = gpbCorpseCheck.Tag.ToString();
                m_objContent.m_strFirstCase = gpbFirstCase.Tag.ToString();
                m_objContent.m_strFollow = gpbFollow.Tag.ToString();
                m_objContent.m_strFollow_Week = txtFollow_Week.Text;
                m_objContent.m_strFollow_Month = txtFollow_Month.Text;
                m_objContent.m_strFollow_Year = txtFollow_Year.Text;
                m_objContent.m_strModelCase = gpbModelCase.Tag.ToString();
                m_objContent.m_strBloodType = txtBloodType.Text;
                m_objContent.m_strShuYe = txt_shuye.Text;
                m_objContent.m_strBloodRh = gpbBloodRh.Tag.ToString();
                //m_objContent.m_strBloodTransActoin = gpbBloodTransAction.Tag.ToString();
                m_objContent.m_strBloodTransActoin = txt_shuxue.Text;
                m_objContent.m_strRBC = txtRBC.Text;
                m_objContent.m_strPLT = txtPLT.Text;
                m_objContent.m_strPlasm = txtPlasm.Text;
                m_objContent.m_strWholeBlood = txtWholeBlood.Text;
                m_objContent.m_strOtherBlood = txtOtherBlood.Text;
                m_objContent.m_strConsultation = txtConsultation.Text;
                m_objContent.m_strLongDistanctConsultation = txtLongDistanctConsultation.Text;
                m_objContent.m_strTOPLevel = txtTOPLevel.Text;
                m_objContent.m_strNurseLevelI = txtNurseLevelI.Text;
                m_objContent.m_strNurseLevelII = txtNurseLevelII.Text;
                m_objContent.m_strNurseLevelIII = txtNurseLevelIII.Text;
                m_objContent.m_strICU = txtICU.Text;
                m_objContent.m_strSpecialNurse = txtSpecialNurse.Text;

                m_objContent.m_strChuShengData = m_dtpBirthDate.Value;
                m_objContent.m_strGuoJi = m_txtNationality.Text;
                m_objContent.m_strShengShi = m_txtCountry.Text;
                m_objContent.m_strZhiYe = m_txtOccupation.Text;
                m_objContent.m_strMingZhu = m_txtNation.Text;
                m_objContent.m_strHunYin = m_txtMarried.Text;
                m_objContent.m_strDianHua = m_txtHomePhone.Text;
                m_objContent.m_strShengFenID = m_txtIDCard.Text;
                m_objContent.m_strChuShenDi = txtchusheng.Text;
                m_objContent.m_strGongZuoDanWei = m_txtCompanyName.Text;
                m_objContent.m_strDanWeiDiZhi = m_txtOfficeAddress.Text;
                m_objContent.m_strDanWeiYouBian = m_txtOfficePC.Text;
                m_objContent.m_strHuKouZhuZhi = m_txtHomeAddress.Text;
                m_objContent.m_strHuKouYouBian = m_txtHomePC.Text;
                m_objContent.m_strLianXiRenName = m_txtContactMan.Text;
                m_objContent.m_strLianXiRenGuanXi = m_txtRelation.Text;
                m_objContent.m_strLianXiRenDianHua = m_txtContactManPhone.Text;
                m_objContent.m_strLianXiRenDiZhi = m_txtContactManAddress.Text;

                
                m_objContent.m_strInsuranceNum = txtInsuranceNum.Text;
                m_objContent.m_strModeOfPayment = m_cboModeOfPayment.Text;
                m_objContent.m_strPatientHistoryNO = m_objBaseCurrentPatient.m_StrEMRInPatientID;//txtPatientHistoryNO.Text;
                m_objContent.m_strOutPatientDate = m_lblOutHospitalDate.Text;
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objContent;
        }
        #endregion

        #region 获得界面其它诊断的内容
        /// <summary>
        /// 获得界面其它诊断的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_OtherDiagnosis[] m_objGetOtherDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime, out bool p_bolIfSucceed)
        {
            p_bolIfSucceed = true;
            //dtgOtherDiagnosis.UnSelect(dtgOtherDiagnosis.CurrentCell.RowNumber);
            //if (this.ActiveControl.Parent == dtgOtherDiagnosis)
            //{
            //    dtgOtherDiagnosis.CurrentCell = new DataGridCell(dtgOtherDiagnosis.CurrentCell.RowNumber + 1, 0);
            //}
          
            #region
            //if (m_dtbOtherDiagnosis != null)
            //{
                int m_intRows = m_dtbOtherDiagnosis.Rows.Count;
                if (m_intRows <= 0)
                    return null;
                clsInHospitalMainRecord_OtherDiagnosis[] m_objOtherDiagnosisArr = new clsInHospitalMainRecord_OtherDiagnosis[m_intRows];
                try
                {
                    for (int i1 = 0; i1 < m_intRows; i1++)
                    {
                        m_objOtherDiagnosisArr[i1] = new clsInHospitalMainRecord_OtherDiagnosis();
                        m_objOtherDiagnosisArr[i1].m_strInPatientID = p_strInPatientID;
                        m_objOtherDiagnosisArr[i1].m_strInPatientDate = p_strInPatientDate;
                        if (m_bolIfHasSave)
                            m_objOtherDiagnosisArr[i1].m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
                        else
                            m_objOtherDiagnosisArr[i1].m_strOpenDate = p_strCurrentDateTime;
                        m_objOtherDiagnosisArr[i1].m_strLastModifyDate = p_strCurrentDateTime;
                        m_objOtherDiagnosisArr[i1].m_strLastModifyUserID = MDIParent.OperatorID;
                        m_objOtherDiagnosisArr[i1].m_strDeActivedDate = "";
                        m_objOtherDiagnosisArr[i1].m_strDeActivedOperatorID = "";
                        m_objOtherDiagnosisArr[i1].m_strStatus = "1";
                        m_objOtherDiagnosisArr[i1].m_strSeqID = i1.ToString();
                        m_objOtherDiagnosisArr[i1].m_strDiagnosisDesc = m_dtbOtherDiagnosis.Rows[i1][0].ToString();

                        if (m_dtbOtherDiagnosis.Rows[i1][1].ToString() == "True")
                            m_objOtherDiagnosisArr[i1].m_strConditionSeq = "0";
                        else if (m_dtbOtherDiagnosis.Rows[i1][2].ToString() == "True")
                            m_objOtherDiagnosisArr[i1].m_strConditionSeq = "1";
                        else if (m_dtbOtherDiagnosis.Rows[i1][3].ToString() == "True")
                            m_objOtherDiagnosisArr[i1].m_strConditionSeq = "2";
                        else if (m_dtbOtherDiagnosis.Rows[i1][4].ToString() == "True")
                            m_objOtherDiagnosisArr[i1].m_strConditionSeq = "3";
                        else if (m_dtbOtherDiagnosis.Rows[i1][5].ToString() == "True")
                            m_objOtherDiagnosisArr[i1].m_strConditionSeq = "4";
                        if (m_objOtherDiagnosisArr[i1].m_strConditionSeq == null || m_objOtherDiagnosisArr[i1].m_strConditionSeq == "")
                        {
                            clsPublicFunction.ShowInformationMessageBox("其他诊断中选择项第 " + ++i1 + " 行有误，请检查！");
                            p_bolIfSucceed = false;
                            return null;
                        }
                        m_objOtherDiagnosisArr[i1].m_strICD10 = m_dtbOtherDiagnosis.Rows[i1][6].ToString();
                    }
                }
                catch (Exception err)
                {
                    clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
                }

                return m_objOtherDiagnosisArr;
            //}
            #endregion

            //#region
            //if (m_dtbOtherDiagnosisz != null)
            //{
            //    int m_intRows = m_dtbOtherDiagnosisz.Rows.Count;
            //    if (m_intRows <= 0)
            //        return null;
            //    clsInHospitalMainRecord_OtherDiagnosis[] m_objOtherDiagnosisArr = new clsInHospitalMainRecord_OtherDiagnosis[m_intRows];
            //    try
            //    {
            //        for (int i1 = 0; i1 < m_intRows; i1++)
            //        {
            //            m_objOtherDiagnosisArr[i1] = new clsInHospitalMainRecord_OtherDiagnosis();
            //            m_objOtherDiagnosisArr[i1].m_strInPatientID = p_strInPatientID;
            //            m_objOtherDiagnosisArr[i1].m_strInPatientDate = p_strInPatientDate;
            //            if (m_bolIfHasSave)
            //                m_objOtherDiagnosisArr[i1].m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
            //            else
            //                m_objOtherDiagnosisArr[i1].m_strOpenDate = p_strCurrentDateTime;
            //            m_objOtherDiagnosisArr[i1].m_strLastModifyDate = p_strCurrentDateTime;
            //            m_objOtherDiagnosisArr[i1].m_strLastModifyUserID = MDIParent.OperatorID;
            //            m_objOtherDiagnosisArr[i1].m_strDeActivedDate = "";
            //            m_objOtherDiagnosisArr[i1].m_strDeActivedOperatorID = "";
            //            m_objOtherDiagnosisArr[i1].m_strStatus = "1";
            //            m_objOtherDiagnosisArr[i1].m_strSeqID = i1.ToString();
            //            m_objOtherDiagnosisArr[i1].m_strDiagnosisDesc = m_dtbOtherDiagnosisz.Rows[i1][0].ToString();

            //            if (m_dtbOtherDiagnosisz.Rows[i1][1].ToString() == "True")
            //                m_objOtherDiagnosisArr[i1].m_strConditionSeq = "0";
            //            else if (m_dtbOtherDiagnosisz.Rows[i1][2].ToString() == "True")
            //                m_objOtherDiagnosisArr[i1].m_strConditionSeq = "1";
            //            else if (m_dtbOtherDiagnosisz.Rows[i1][3].ToString() == "True")
            //                m_objOtherDiagnosisArr[i1].m_strConditionSeq = "2";
            //            else if (m_dtbOtherDiagnosisz.Rows[i1][4].ToString() == "True")
            //                m_objOtherDiagnosisArr[i1].m_strConditionSeq = "3";
            //            else if (m_dtbOtherDiagnosisz.Rows[i1][5].ToString() == "True")
            //                m_objOtherDiagnosisArr[i1].m_strConditionSeq = "4";
            //            if (m_objOtherDiagnosisArr[i1].m_strConditionSeq == null || m_objOtherDiagnosisArr[i1].m_strConditionSeq == "")
            //            {
            //                clsPublicFunction.ShowInformationMessageBox("其他诊断中选择项第 " + ++i1 + " 行有误，请检查！");
            //                p_bolIfSucceed = false;
            //                return null;
            //            }
            //            m_objOtherDiagnosisArr[i1].m_strICD10 = m_dtbOtherDiagnosisz.Rows[i1][6].ToString();
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            //    }

            //    return m_objOtherDiagnosisArr;
            //}
            //#endregion
           

        }
        #endregion

        #region 获得界面手术情况的内容
        /// <summary>
        /// 获得界面手术情况的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_Operation[] m_objGetOperationArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            if (this.ActiveControl.Parent == dtgOperation)
            {
                dtgOperation.CurrentCell = new DataGridCell(dtgOperation.CurrentCell.RowNumber + 1, 0);
            }
            //dtgOperation.UnSelect(dtgOtherDiagnosis.CurrentCell.RowNumber);
            int m_intRows = m_dtbOperationDetail.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsInHospitalMainRecord_Operation[] m_objOperationArr = new clsInHospitalMainRecord_Operation[m_intRows];
            try
            {
                for (int i1 = 0; i1 < m_intRows; i1++)
                {
                    m_objOperationArr[i1] = new clsInHospitalMainRecord_Operation();
                    m_objOperationArr[i1].m_strInPatientID = p_strInPatientID;
                    m_objOperationArr[i1].m_strInPatientDate = p_strInPatientDate;
                    if (m_bolIfHasSave)
                        m_objOperationArr[i1].m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
                    else
                        m_objOperationArr[i1].m_strOpenDate = p_strCurrentDateTime;
                    //					m_objOperationArr[i1].m_strOpenDate = p_strCurrentDateTime;
                    m_objOperationArr[i1].m_strLastModifyDate = p_strCurrentDateTime;
                    m_objOperationArr[i1].m_strLastModifyUserID = MDIParent.OperatorID;
                    m_objOperationArr[i1].m_strDeActivedDate = "";
                    m_objOperationArr[i1].m_strDeActivedOperatorID = "";
                    m_objOperationArr[i1].m_strStatus = "1";
                    m_objOperationArr[i1].m_strSeqID = i1.ToString();
                    m_objOperationArr[i1].m_strOperationID = m_dtbOperationDetail.Rows[i1][0].ToString();
                    if (m_dtbOperationDetail.Rows[i1][1].ToString() == "")
                        m_objOperationArr[i1].m_strOperationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    else
                        m_objOperationArr[i1].m_strOperationDate = m_dtbOperationDetail.Rows[i1][1].ToString();
                    m_objOperationArr[i1].m_strOperationName = m_dtbOperationDetail.Rows[i1][2].ToString();
                    m_objOperationArr[i1].m_strOperator = m_dtbOperationDetail.Rows[i1][10].ToString();
                    m_objOperationArr[i1].m_strAssistant1 = m_dtbOperationDetail.Rows[i1][11].ToString();
                    m_objOperationArr[i1].m_strAssistant2 = m_dtbOperationDetail.Rows[i1][12].ToString();
                    m_objOperationArr[i1].m_strAanaesthesiaModeName = m_dtbOperationDetail.Rows[i1][6].ToString();
                    m_objOperationArr[i1].m_strAanaesthesiaModeID = m_dtbOperationDetail.Rows[i1][9].ToString();
                    m_objOperationArr[i1].m_strCutLevel = m_dtbOperationDetail.Rows[i1][7].ToString();
                    m_objOperationArr[i1].m_strAnaesthetistName = m_dtbOperationDetail.Rows[i1][8].ToString();
                    m_objOperationArr[i1].m_strAnaesthetist = m_dtbOperationDetail.Rows[i1][13].ToString();
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objOperationArr;
        }
        #endregion

        #region 获得界面婴儿记录的内容
        /// <summary>
        /// 获得界面婴儿记录的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        //private clsInHospitalMainRecord_Baby[] m_objGetBabyArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        //{
        //    //dtgBaby.UnSelect(dtgOtherDiagnosis.CurrentCell.RowNumber);
        //    if (this.ActiveControl.Parent == dtgBaby)
        //    {
        //        dtgBaby.CurrentCell = new DataGridCell(dtgBaby.CurrentCell.RowNumber + 1, 0);
        //    }
        //    int m_intRows = m_dtbBaby.Rows.Count;
        //    if (m_intRows <= 0)
        //        return null;
        //    clsInHospitalMainRecord_Baby[] m_objBabyArr = new clsInHospitalMainRecord_Baby[m_intRows];
        //    try
        //    {
        //        for (int i1 = 0; i1 < m_intRows; i1++)
        //        {
        //            m_objBabyArr[i1] = new clsInHospitalMainRecord_Baby();
        //            m_objBabyArr[i1].m_strInPatientID = p_strInPatientID;
        //            m_objBabyArr[i1].m_strInPatientDate = p_strInPatientDate;
        //            if (m_bolIfHasSave)
        //                m_objBabyArr[i1].m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
        //            else
        //                m_objBabyArr[i1].m_strOpenDate = p_strCurrentDateTime;
        //            //					m_objBabyArr[i1].m_strOpenDate = p_strCurrentDateTime;
        //            m_objBabyArr[i1].m_strLastModifyDate = p_strCurrentDateTime;
        //            m_objBabyArr[i1].m_strLastModifyUserID = MDIParent.OperatorID;
        //            m_objBabyArr[i1].m_strDeActivedDate = "";
        //            m_objBabyArr[i1].m_strDeActivedOperatorID = "";
        //            m_objBabyArr[i1].m_strStatus = "1";
        //            m_objBabyArr[i1].m_strSeqID = i1.ToString();

        //            if (m_dtbBaby.Rows[i1][1].ToString() == "True")
        //                m_objBabyArr[i1].m_strMale = "1";
        //            else
        //                m_objBabyArr[i1].m_strMale = "0";
        //            if (m_dtbBaby.Rows[i1][2].ToString() == "True")
        //                m_objBabyArr[i1].m_strFemale = "1";
        //            else
        //                m_objBabyArr[i1].m_strFemale = "0";
        //            if (m_dtbBaby.Rows[i1][3].ToString() == "True")
        //                m_objBabyArr[i1].m_strLiveBorn = "1";
        //            else
        //                m_objBabyArr[i1].m_strLiveBorn = "0";
        //            if (m_dtbBaby.Rows[i1][4].ToString() == "True")
        //                m_objBabyArr[i1].m_strDieBorn = "1";
        //            else
        //                m_objBabyArr[i1].m_strDieBorn = "0";
        //            if (m_dtbBaby.Rows[i1][5].ToString() == "True")
        //                m_objBabyArr[i1].m_strDieNotBorn = "1";
        //            else
        //                m_objBabyArr[i1].m_strDieNotBorn = "0";

        //            m_objBabyArr[i1].m_strWeight = m_dtbBaby.Rows[i1][6].ToString();

        //            if (m_dtbBaby.Rows[i1][7].ToString() == "True")
        //                m_objBabyArr[i1].m_strDie = "1";
        //            else
        //                m_objBabyArr[i1].m_strDie = "0";
        //            if (m_dtbBaby.Rows[i1][8].ToString() == "True")
        //                m_objBabyArr[i1].m_strChangeDepartment = "1";
        //            else
        //                m_objBabyArr[i1].m_strChangeDepartment = "0";
        //            if (m_dtbBaby.Rows[i1][9].ToString() == "True")
        //                m_objBabyArr[i1].m_strOutHospital = "1";
        //            else
        //                m_objBabyArr[i1].m_strOutHospital = "0";
        //            if (m_dtbBaby.Rows[i1][10].ToString() == "True")
        //                m_objBabyArr[i1].m_strNaturalCondiction = "1";
        //            else
        //                m_objBabyArr[i1].m_strNaturalCondiction = "0";
        //            if (m_dtbBaby.Rows[i1][11].ToString() == "True")
        //                m_objBabyArr[i1].m_strSuffocate1 = "1";
        //            else
        //                m_objBabyArr[i1].m_strSuffocate1 = "0";
        //            if (m_dtbBaby.Rows[i1][12].ToString() == "True")
        //                m_objBabyArr[i1].m_strSuffocate2 = "1";
        //            else
        //                m_objBabyArr[i1].m_strSuffocate2 = "0";

        //            m_objBabyArr[i1].m_strInfectionTimes = m_dtbBaby.Rows[i1][13].ToString();
        //            m_objBabyArr[i1].m_strInfectionName = m_dtbBaby.Rows[i1][14].ToString();
        //            m_objBabyArr[i1].m_strICD10 = m_dtbBaby.Rows[i1][15].ToString();
        //            m_objBabyArr[i1].m_strSalveTimes = m_dtbBaby.Rows[i1][16].ToString();
        //            m_objBabyArr[i1].m_strSalveSuccessTimes = m_dtbBaby.Rows[i1][17].ToString();
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
        //    }
        //    return m_objBabyArr;
        //}
        #endregion

        #region 获得界面化疗用药及疗效的内容
        /// <summary>
        /// 获得界面化疗用药及疗效的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        //private clsInHospitalMainRecord_Chemotherapy[] m_objGetChemotherapyArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        //{
        //    //dtgChemotherapy.UnSelect(dtgOtherDiagnosis.CurrentCell.RowNumber);
        //    if (this.ActiveControl.Parent == dtgChemotherapy)
        //    {
        //        dtgChemotherapy.CurrentCell = new DataGridCell(dtgChemotherapy.CurrentCell.RowNumber + 1, 0);
        //    }
        //    int m_intRows = m_dtbChemotherapy.Rows.Count;
        //    if (m_intRows <= 0)
        //        return null;
        //    clsInHospitalMainRecord_Chemotherapy[] m_objChemotherapyArr = new clsInHospitalMainRecord_Chemotherapy[m_intRows];
        //    try
        //    {
        //        for (int i1 = 0; i1 < m_intRows; i1++)
        //        {
        //            m_objChemotherapyArr[i1] = new clsInHospitalMainRecord_Chemotherapy();
        //            m_objChemotherapyArr[i1].m_strInPatientID = p_strInPatientID;
        //            m_objChemotherapyArr[i1].m_strInPatientDate = p_strInPatientDate;
        //            if (m_bolIfHasSave)
        //                m_objChemotherapyArr[i1].m_strOpenDate = m_objCollection.m_objMain.m_strOpenDate;
        //            else
        //                m_objChemotherapyArr[i1].m_strOpenDate = p_strCurrentDateTime;
        //            //					m_objChemotherapyArr[i1].m_strOpenDate = p_strCurrentDateTime;
        //            m_objChemotherapyArr[i1].m_strLastModifyDate = p_strCurrentDateTime;
        //            m_objChemotherapyArr[i1].m_strLastModifyUserID = MDIParent.OperatorID;
        //            m_objChemotherapyArr[i1].m_strDeActivedDate = "";
        //            m_objChemotherapyArr[i1].m_strDeActivedOperatorID = "";
        //            m_objChemotherapyArr[i1].m_strStatus = "1";
        //            m_objChemotherapyArr[i1].m_strSeqID = i1.ToString();

        //            if (m_dtbChemotherapy.Rows[i1][0].ToString() == "")//处理用户没有做任何改动，而DataGrid里面放的是空值时的情况
        //                m_objChemotherapyArr[i1].m_strChemotherapyDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        //            else
        //                m_objChemotherapyArr[i1].m_strChemotherapyDate = m_dtbChemotherapy.Rows[i1][0].ToString();
        //            m_objChemotherapyArr[i1].m_strMedicineName = m_dtbChemotherapy.Rows[i1][1].ToString();
        //            m_objChemotherapyArr[i1].m_strPeriod = m_dtbChemotherapy.Rows[i1][2].ToString();

        //            if (m_dtbChemotherapy.Rows[i1][3].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_CR = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_CR = "0";

        //            if (m_dtbChemotherapy.Rows[i1][4].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_PR = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_PR = "0";

        //            if (m_dtbChemotherapy.Rows[i1][5].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_MR = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_MR = "0";

        //            if (m_dtbChemotherapy.Rows[i1][6].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_S = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_S = "0";

        //            if (m_dtbChemotherapy.Rows[i1][7].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_P = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_P = "0";

        //            if (m_dtbChemotherapy.Rows[i1][8].ToString() == "True")
        //                m_objChemotherapyArr[i1].m_strField_NA = "1";
        //            else
        //                m_objChemotherapyArr[i1].m_strField_NA = "0";

        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
        //    }
        //    return m_objChemotherapyArr;
        //}
        #endregion

        #region 获得界面诊断内容
        /// <summary>
        /// 获得界面诊断内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_Diagnosis[] m_objGetDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            System.Collections.Generic.List<clsInHospitalMainRecord_Diagnosis> objDiagnosisArr = new System.Collections.Generic.List<clsInHospitalMainRecord_Diagnosis>();
            if (this.ActiveControl != null)
            {
                if (this.ActiveControl.Parent == dgDiagnosis1)
                {
                    dgDiagnosis1.CurrentCell = new DataGridCell(dgDiagnosis1.CurrentCell.RowNumber + 1, 0);
                }
                else if (this.ActiveControl.Parent == dgDiagnosiszhongyi)
                {
                    dgDiagnosiszhongyi.CurrentCell = new DataGridCell(dgDiagnosiszhongyi.CurrentCell.RowNumber + 1, 0);
                }
                else if (this.ActiveControl.Parent == dgDiagnosis2)
                {
                    dgDiagnosis2.CurrentCell = new DataGridCell(dgDiagnosis2.CurrentCell.RowNumber + 1, 0);
                }
                else if (this.ActiveControl.Parent == dgDiagnosis2zhong)
                {
                    dgDiagnosis2zhong.CurrentCell = new DataGridCell(dgDiagnosis2zhong.CurrentCell.RowNumber + 1, 0);
                }
                else if (this.ActiveControl.Parent == dgDiagnosis3)
                {
                    dgDiagnosis3.CurrentCell = new DataGridCell(dgDiagnosis3.CurrentCell.RowNumber + 1, 0);
                }
                else if (this.ActiveControl.Parent == dgDiagnosis3zhongyi)
                {
                    dgDiagnosis3zhongyi.CurrentCell = new DataGridCell(dgDiagnosis3zhongyi.CurrentCell.RowNumber + 1, 0);
                }
            }

            try
            {
                clsInHospitalMainRecord_Diagnosis objDia = null;
                DataRow drCurrent = null;
                if (m_dtbInHospitalDiagnosis != null)
                {
                    int rowsCount = m_dtbInHospitalDiagnosis.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbInHospitalDiagnosis.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "1";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = string.Empty;
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }
                //中医入院中断  SGH 2007/12/5
                if (m_dtbInHospitalDiagnosisZhong != null)
                {
                    int rowsCount = m_dtbInHospitalDiagnosisZhong.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbInHospitalDiagnosisZhong.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "4";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = string.Empty;
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }


                if (m_dtbInfectionDiagnosis != null)
                {
                    int rowsCount = m_dtbInfectionDiagnosis.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbInfectionDiagnosis.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "2";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = ConvertState(drCurrent[2].ToString(), 0);
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }

                if (m_dtbInfectionDiagnosisZhong != null)
                {
                    int rowsCount = m_dtbInfectionDiagnosisZhong.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbInfectionDiagnosisZhong.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "6";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = ConvertState(drCurrent[2].ToString(), 0);
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }



                if (m_dtbOtherDiagnosis != null)
                {
                    int rowsCount = m_dtbOtherDiagnosis.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbOtherDiagnosis.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "3";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = ConvertState(drCurrent[2].ToString(), 0);
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }

                if (m_dtbOtherDiagnosisz != null)
                {
                    int rowsCount = m_dtbOtherDiagnosisz.Rows.Count;
                    if (rowsCount > 0)
                    {
                        for (int i = 0; i < rowsCount; i++)
                        {
                            drCurrent = m_dtbOtherDiagnosisz.Rows[i];
                            objDia = new clsInHospitalMainRecord_Diagnosis();
                            objDia.m_strDIAGNOSISTYPE = "5";
                            objDia.m_strDIAGNOSIS = drCurrent[0].ToString();
                            objDia.m_strICD10 = drCurrent[1].ToString();
                            objDia.m_strSEQID = i.ToString();
                            objDia.m_strRESULT = ConvertState(drCurrent[2].ToString(), 0);
                            objDia.m_strINPATIENTID = p_strInPatientID;
                            objDia.m_strINPATIENTDATE = p_strInPatientDate;
                            objDia.m_strLASTMODIFYDATE = p_strCurrentDateTime;
                            objDia.m_strLASTMODIFYUSERID = MDIParent.OperatorID;
                            if (m_bolIfHasSave)
                                objDia.m_strOPENDATE = m_objCollection.m_objMain.m_strOpenDate;
                            else
                                objDia.m_strOPENDATE = p_strCurrentDateTime;
                            objDiagnosisArr.Add(objDia);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return objDiagnosisArr.ToArray();
        }
        #endregion

        private void lsvEmployee_DoubleClick(object sender, System.EventArgs e)
        {
            //if(sender==null)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("参数错误!");						
            //    return;
            //}

            ///*
            // * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
            // */
            //if(lsvEmployee.SelectedItems.Count <= 0)
            //    return;

            //clsEmployee objEmp = (clsEmployee)lsvEmployee.SelectedItems[0].Tag;

            //if(objEmp == null)
            //    return;	

            ////			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
            ////				return;

            //lsvEmployee.Visible = false;

            //if( ( ((Control)sender).Top==txtDoctor.Bottom && ((Control)sender).Left==txtDoctor.Left) || ((Control)sender).Name=="txtDoctor")
            //{
            //    txtDoctor.Text=objEmp.m_StrLastName;
            //    txtDoctor.Tag= objEmp.m_StrEmployeeID;
            //    txtDoctor.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtDirectorDt.Bottom && ((Control)sender).Left==txtDirectorDt.Left) || ((Control)sender).Name=="txtDirectorDt")
            //{
            //    txtDirectorDt.Text=objEmp.m_StrLastName;
            //    txtDirectorDt.Tag= objEmp.m_StrEmployeeID;
            //    txtDirectorDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtSubDirectorDt.Bottom && ((Control)sender).Left==txtSubDirectorDt.Left) || ((Control)sender).Name=="txtSubDirectorDt")
            //{
            //    txtSubDirectorDt.Text=objEmp.m_StrLastName;
            //    txtSubDirectorDt.Tag= objEmp.m_StrEmployeeID;
            //    txtSubDirectorDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtDt.Bottom && ((Control)sender).Left==txtDt.Left) || ((Control)sender).Name=="txtDt")
            //{
            //    txtDt.Text=objEmp.m_StrLastName;
            //    txtDt.Tag= objEmp.m_StrEmployeeID;
            //    txtDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtInHospitalDt.Bottom && ((Control)sender).Left==txtInHospitalDt.Left) || ((Control)sender).Name=="txtInHospitalDt")
            //{
            //    txtInHospitalDt.Text=objEmp.m_StrLastName;
            //    txtInHospitalDt.Tag= objEmp.m_StrEmployeeID;
            //    txtInHospitalDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtAttendInForAdvancesStudyDt.Bottom && ((Control)sender).Left==txtAttendInForAdvancesStudyDt.Left) || ((Control)sender).Name=="txtAttendInForAdvancesStudyDt")
            //{
            //    txtAttendInForAdvancesStudyDt.Text=objEmp.m_StrLastName;
            //    txtAttendInForAdvancesStudyDt.Tag= objEmp.m_StrEmployeeID;
            //    txtAttendInForAdvancesStudyDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtGraduateStudentIntern.Bottom && ((Control)sender).Left==txtGraduateStudentIntern.Left) || ((Control)sender).Name=="txtGraduateStudentIntern")
            //{
            //    txtGraduateStudentIntern.Text=objEmp.m_StrLastName;
            //    txtGraduateStudentIntern.Tag= objEmp.m_StrEmployeeID;
            //    txtGraduateStudentIntern.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtIntern.Bottom && ((Control)sender).Left==txtIntern.Left) || ((Control)sender).Name=="txtIntern")
            //{
            //    txtIntern.Text=objEmp.m_StrLastName;
            //    txtIntern.Tag= objEmp.m_StrEmployeeID;
            //    txtIntern.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtCoder.Bottom && ((Control)sender).Left==txtCoder.Left) || ((Control)sender).Name=="txtCoder")
            //{
            //    txtCoder.Text=objEmp.m_StrLastName;
            //    txtCoder.Tag= objEmp.m_StrEmployeeID;
            //    txtCoder.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtQCDt.Bottom && ((Control)sender).Left==txtQCDt.Left) || ((Control)sender).Name=="txtQCDt")
            //{
            //    txtQCDt.Text=objEmp.m_StrLastName;
            //    txtQCDt.Tag= objEmp.m_StrEmployeeID;
            //    txtQCDt.Focus();
            //}
            //else if( ( ((Control)sender).Top==txtQCNurse.Bottom && ((Control)sender).Left==txtQCNurse.Left) || ((Control)sender).Name=="txtQCNurse")
            //{
            //    txtQCNurse.Text=objEmp.m_StrLastName;
            //    txtQCNurse.Tag= objEmp.m_StrEmployeeID;
            //    txtQCNurse.Focus();
            //}	

        }

        #region old
        //		private void lsvEmployee_DoubleClick(object sender, System.EventArgs e)
        //		{
        //			if(lsvEmployee.SelectedItems.Count <= 0)
        //				return;
        //
        //			string m_strEmplayeeID = lsvEmployee.SelectedItems[0].SubItems[0].Text;
        //			string m_strEmplayeeName = lsvEmployee.SelectedItems[0].SubItems[1].Text;
        //
        //			if(!m_blnCheckEmployeeSign(m_strEmplayeeID,m_strEmplayeeName))
        //				return;
        //
        //			m_RtbCurrentTextBox.Tag = m_strEmplayeeID;
        //			m_bolIfChange = false;
        //			m_RtbCurrentTextBox.Text = m_strEmplayeeName;
        //			m_bolIfChange = true;
        //			
        //			lsvEmployee.Visible = false;
        //			
        //			/*
        //			 * 用于防止模糊查询的ListView位置随意变动
        //			 * */
        //			if(m_RtbCurrentTextBox.Name == "txtDoctor")
        //				lblMasterDiagnose.Focus();
        //			else
        //				lblTumourPatientRecordTitle.Focus();
        //			m_RtbCurrentTextBox.Focus();
        //		}
        #endregion old



        #region 给所有CheckBox的GroupBox容器的Tag付初值为"1"
        /// <summary>
        /// 给所有CheckBox的GroupBox容器的Tag付初值为"1",表示默认选择第一个。
        /// 写入数据库时直接从GroupBox的Tag中获得CheckBox的值
        /// </summary>
        private void m_mthInitGroupBoxTagValue()
        {
            gpbCondictionWhenIn.Tag = "2";
            //gpbMainDiagnosis.Tag = "0";
            //gpbInfection.Tag = "0";
            gpbQuality.Tag = "-1";
            gpbRTMode.Tag = "-1";
            gpbRTRule.Tag = "-1";
            gpbOriginalDisease.Tag = "-1";
            gpbLymph.Tag = "-1";
            gpbChemotherapyMode.Tag = "-1";
            gpbCorpseCheck.Tag = "1";
            gpbFirstCase.Tag = "1";
            gpbModelCase.Tag = "1";
            gpbFollow.Tag = "1";
            gpbBloodRh.Tag = "3";
            gpbBloodTransAction.Tag = "3";
        }
        #endregion

        #region CheckedChange
        //private void MainDiagnosis_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    if(rdbHealOfMain.Checked)
        //        gpbMainDiagnosis.Tag = "0";
        //    else if(rdbOnTheMendOfMain.Checked)
        //        gpbMainDiagnosis.Tag = "1";
        //    else if(rdbNotCureOfMain.Checked)
        //        gpbMainDiagnosis.Tag = "2";
        //    else if(rdbDieOfMain.Checked)
        //        gpbMainDiagnosis.Tag = "3";
        //    else if(rdbNotDefineOfMain.Checked)
        //        gpbMainDiagnosis.Tag = "4";
        //}

        private void CondictionWhenIn_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbDanger.Checked)
                gpbCondictionWhenIn.Tag = "0";
            else if (rdbEmergency.Checked)
                gpbCondictionWhenIn.Tag = "1";
            else if (rdbNormal.Checked)
                gpbCondictionWhenIn.Tag = "2";
        }

        //private void Infection_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    if(rdbHealOfInfection.Checked)
        //        gpbInfection.Tag = "0";
        //    else if(rdbOnTheMendOfInfection.Checked)
        //        gpbInfection.Tag = "1";
        //    else if(rdbNotCureOfInfection.Checked)
        //        gpbInfection.Tag = "2";
        //    else if(rdbDieOfInfection.Checked)
        //        gpbInfection.Tag = "3";
        //    else if(rdbNotDefineOfInfection.Checked)
        //        gpbInfection.Tag = "4";
        //}

        private void Quality_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdbQuality1.Checked)
            //    gpbQuality.Tag = "0";
            //else if (rdbQuality2.Checked)
            //    gpbQuality.Tag = "1";
            //else if (rdbQuality3.Checked)
            //    gpbQuality.Tag = "2";
        }

        private void RTMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbRTCure.Checked)
                gpbRTMode.Tag = "0";
            else if (rdbRTAppeasement.Checked)
                gpbRTMode.Tag = "1";
            else if (rdbRTAssistant.Checked)
                gpbRTMode.Tag = "2";
        }

        private void RTRule_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbContinue.Checked)
                gpbRTRule.Tag = "0";
            else if (rdbRTGap.Checked)
                gpbRTRule.Tag = "1";
            else if (rdbRTSection.Checked)
                gpbRTRule.Tag = "2";
        }

        private void OriginalDisease_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbOriginalDiseaseFirst.Checked)
                gpbOriginalDisease.Tag = "0";
            else if (rdbOriginalDiseaseRepeat.Checked)
                gpbOriginalDisease.Tag = "1";
        }

        private void Lymph_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbLymphFirst.Checked)
                gpbLymph.Tag = "0";
            else if (rdbLymphRepeat.Checked)
                gpbLymph.Tag = "1";

        }

        private void ChemotherapyMode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbChemotherapyCure.Checked)
                gpbChemotherapyMode.Tag = "0";
            else if (rdbChemotherapyAppeasement.Checked)
                gpbChemotherapyMode.Tag = "1";
            else if (rdbChemotherapyAssisantNew.Checked)
                gpbChemotherapyMode.Tag = "2";
            else if (rdbChemotherapyAssistant.Checked)
                gpbChemotherapyMode.Tag = "3";
            else if (rdbChemotherapyNewMedicine.Checked)
                gpbChemotherapyMode.Tag = "4";
        }

        private void CorpseCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbCorpseCheckYes.Checked)
                gpbCorpseCheck.Tag = "1";
            else if (rdbCorpseCheckNO.Checked)
                gpbCorpseCheck.Tag = "0";
        }

        private void FirstCase_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbFirstCaseYes.Checked)
                gpbFirstCase.Tag = "1";
            else if (rdbFirstCaseNO.Checked)
                gpbFirstCase.Tag = "0";
        }

        private void ModelCase_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbModelCaseYes.Checked)
                gpbModelCase.Tag = "1";
            else if (rdbModelCaseNO.Checked)
                gpbModelCase.Tag = "0";
        }

        private void Follow_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbFollowYes.Checked)
            {
                gpbFollow.Tag = "1";
                txtFollow_Week.Enabled = true;
                txtFollow_Month.Enabled = true;
                txtFollow_Year.Enabled = true;
                txtFollow_Week.Text = "";
                txtFollow_Month.Text = "";
                txtFollow_Year.Text = "";
            }
            else if (rdbFollowNO.Checked)
            {
                gpbFollow.Tag = "0";
                txtFollow_Week.Text = "-";
                txtFollow_Month.Text = "-";
                txtFollow_Year.Text = "-";
                txtFollow_Week.Enabled = false;
                txtFollow_Month.Enabled = false;
                txtFollow_Year.Enabled = false;
            }
        }

        private void BloodRh_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbBloodRh_Ka.Checked)
                gpbBloodRh.Tag = "1";
            else if (rdbBloodRh_An.Checked)
                gpbBloodRh.Tag = "2";
            else if (rdbBloodRh_No.Checked)
                gpbBloodRh.Tag = "3";
        }

        private void BloodTransAction_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (rdbBloodTransActionYes.Checked)
            //    gpbBloodTransAction.Tag = "1";
            //else if (rdbBloodTransActionNO.Checked)
            //    gpbBloodTransAction.Tag = "2";
            //else if (rdbBloodTransNoAction.Checked)
            //    gpbBloodTransAction.Tag = "3";
        }
        #endregion



        /// <summary>
        /// 在手术DataGrid中，当前所使用的DataGridTextBox
        /// </summary>
        private DataGridTextBox m_dgtCurrentBox;

        #region 把模糊查询的结果放在lsvOperationEmplayee中
        /// <summary>
        /// 把模糊查询的结果放在lsvOperationEmplayee中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_objAddGridListViewItemArr(object sender, EventArgs e)
        {
            clsOperationEqipmentQtyDomain m_objOEQDomain = new clsOperationEqipmentQtyDomain();
            DataGridTextBox m_dgtTemp = ((DataGridTextBox)sender);
            if (m_dgtTemp.Text.Trim() == "")
                return;
            m_dgtCurrentBox = m_dgtTemp;

            try
            {
                lsvOperationEmployee.Items.Clear();
                bool blnSuccess = false;

                ListViewItem[] lsvItemArr = null;

                if (m_dgtTemp == null || m_dgtTemp.Text == null || m_dgtTemp.Text == "")
                    return;
                lsvItemArr = m_objOEQDomain.m_lviGetEmployee(m_dgtTemp.Text, ref blnSuccess);

                if (blnSuccess == false)
                    return;
                for (int i1 = 0; i1 < lsvItemArr.Length; i1++)
                {
                    lsvOperationEmployee.Items.AddRange(new ListViewItem[] { lsvItemArr[i1] });
                }

                m_mthChangeListViewLastColumnWidth(lsvOperationEmployee);
            }
            catch { }
        }
        #endregion


        private void lsvOperationEmployee_DoubleClick(object sender, System.EventArgs e)
        {
            if (lsvOperationEmployee.SelectedItems.Count <= 0)
                return;

            string m_strEmplayeeName = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
            string m_strEmplayeeID = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;

            //			if(!m_blnCheckEmployeeSign(m_strEmplayeeID,m_strEmplayeeName))
            //				return;

            int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
            int m_intCurrentRowNumber = this.dtgOperation.CurrentRowIndex;
            DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
            object[] m_objRes = m_dtrOperation.ItemArray;
            if (m_intCurrentColumnNumber == 3)
            {
                m_objRes[3] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[10] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 4)
            {
                m_objRes[4] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[11] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 5)
            {
                m_objRes[5] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[12] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 8)
            {
                m_objRes[8] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[13] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            lsvOperationEmployee.Visible = false;
            //lblTumourPatientRecordTitle.Focus();
        }


        #region 把模糊查询的结果放在lsvAanaesthesiaMode中
        /// <summary>
        /// 把模糊查询的结果放在lsvAanaesthesiaMode中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_objAddGridAanaesthesiaModeListViewItemArr(object sender, EventArgs e)
        {
            string m_strInput = m_objGridListView4.strGetCurrentText().Trim();
            if (m_strInput == null || m_strInput == "")
                return;

            clsAnaesthesiaModeInOperation[] m_objAnaesthesiaModeArr = null;
            long m_lngRes = m_objDomain.m_lngGetAnaesthesiaModeLikeID(m_strInput, out m_objAnaesthesiaModeArr);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            try
            {
                lsvAanaesthesiaMode.Items.Clear();

                if (m_objAnaesthesiaModeArr == null || m_objAnaesthesiaModeArr.Length <= 0)
                    return;

                ListViewItem m_lviNewItem;
                for (int i1 = 0; i1 < m_objAnaesthesiaModeArr.Length; i1++)
                {
                    m_lviNewItem = new ListViewItem(m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeID);
                    m_lviNewItem.SubItems.Add(m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeName);
                    lsvAanaesthesiaMode.Items.Add(m_lviNewItem);
                }

                m_mthChangeListViewLastColumnWidth(lsvAanaesthesiaMode);
            }
            catch { }
        }
        #endregion

        private void lsvAanaesthesiaMode_DoubleClick(object sender, System.EventArgs e)
        {
            if (lsvAanaesthesiaMode.Items.Count <= 0)
                return;
            if (lsvAanaesthesiaMode.SelectedItems.Count <= 0)
                return;
            int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
            int m_intCurrentRowNumber = this.dtgOperation.CurrentRowIndex;
            DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
            object[] m_objRes = m_dtrOperation.ItemArray;
            m_objRes[6] = lsvAanaesthesiaMode.SelectedItems[0].SubItems[1].Text;
            m_objRes[9] = lsvAanaesthesiaMode.SelectedItems[0].SubItems[0].Text;
            m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            lsvAanaesthesiaMode.Visible = false;
            //lblTumourPatientRecordTitle.Focus();
        }

        private void dtgOperation_CurrentCellChanged(object sender, System.EventArgs e)
        {
            dtgOperationCurrentCellChanged();
            //int m_intCurrentGridColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
            //int m_intCurrentGridRowNumber = this.dtgOperation.CurrentRowIndex;

            //int m_intCurrentTableRowNumber = this.m_dtbOperationDetail.Rows.Count;

            //DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentGridRowNumber];
            //object[] m_objRes = new object[13];
            //if (m_intCurrentGridRowNumber == m_intCurrentTableRowNumber)
            //{

            //}
            //if (m_intCurrentRowNumber == 0)
            //{
            //    if (m_dtbOperationDetail.Rows.Count < 0)
            //        m_objRes[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    m_dtbOperationDetail.Rows.Add(m_objRes);
            //}
            //if (m_intCurrentRowNumber > 0 && m_dtbOperationDetail.Rows.Count < m_intCurrentRowNumber)
            //{
            //    m_objRes[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    m_dtbOperationDetail.Rows.Add(m_objRes);
            //}
            //if (m_dtbOperationDetail.Rows.Count < m_intCurrentRowNumber)
            //{
            //    m_objRes[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    m_dtbOperationDetail.Rows.Add(m_objRes);
            //}
            //if (m_intCurrentColumnNumber == 1 && m_objRes[1].ToString() != "")
            //{
            //    m_objRes[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //}
            //this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            //lsvAanaesthesiaMode.Visible = false;
            //lblTumourPatientRecordTitle.Focus();
        }

        #region PublicFunction
        public void Copy()
        {
            m_lngCopy();
        }

        public void Cut()
        {
            m_lngCut();
        }

        public void Delete()
        {
            if (m_ObjCurrentEmrPatientSession == null || m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                return;
            }

            long m_lngRe = m_lngDelete();
            if (m_lngRe > 0)
            {
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                clsPublicFunction.ShowInformationMessageBox("删除成功！");
            }
        }

        public void Display()
        {

        }

        public void Display(string cardno, string sendcheckdate)
        {

        }

        public void Paste()
        {
            m_lngPaste();
        }

        public void Print()
        {
            m_lngPrint();
        }

        public void Redo()
        {

        }

        /// <summary>
        ///是否按提交按钮保存
        /// </summary>
        private bool m_blnIsCommit = false;
        public void Save()
        {

            long m_lngRe = m_lngSave();
            if (m_lngRe > 0)
            {
                if (!m_blnIsCommit)
                {
                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                    clsPublicFunction.ShowInformationMessageBox("保存成功！");
                }
            }
            else if (m_lngRe == -40)
                clsPublicFunction.ShowInformationMessageBox("对不起，您没有权限修改！");
            else
                clsPublicFunction.ShowInformationMessageBox("保存失败！");

        }

        public void Undo()
        {

        }
        public void Verify()
        {

            try
            {
                //检查当前病人变量是否为null 
                if (m_objCollection == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("未选定病人,无法验证!");
                }
                string strInPatientID = m_objCollection.m_objContent.m_strInPatientID;
                string strInPatientDate = DateTime.Parse(m_objCollection.m_objContent.m_strInPatientDate).ToString("yyyy-MM-dd HH:mm:ss");
                string strRecordID = strInPatientID.Trim() + "-" + strInPatientDate;
                long lngRes = m_lngSignVerify(this.Name.Trim(), strRecordID);
            }
            catch (Exception exp)
            {
                MessageBox.Show("签名验证出现异常：" + exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override iCare.enmFormState m_EnmCurrentFormState
        {
            get
            {
                return enmFormState.NowUser;
            }
        }
        #endregion

        private void m_mthCleanUP()
        {
            m_mthCleanUpPatientBaseInfo();
            m_mthCleanUpPatientDetailInfo();
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_objCollection.m_objMain = null;
            m_objCollection.m_objContent = null;
            m_objCollection.m_objDiagnosisArr = null;
            m_objCollection.m_objOperationArr = null;
            m_objCollection.m_objBabyArr = null;
            m_objCollection.m_objChemotherapyArr = null;
            m_mthSetControlReadOnly(this, true);
        }

        #region 清空病人基本信息内容
        /// <summary>
        /// 清空病人基本信息内容
        /// </summary>
        private void m_mthCleanUpPatientBaseInfo()
        {
            base.m_mthClearPatientBaseInfo();
            //			m_txtPatientName.Text = "";
            //			lblSex.Text = "";
            m_dtpBirthDate.Value = DateTime.Now;
            //			lblAge.Text = "";
            m_txtMarried.Text = "";
            m_txtOccupation.Text = "";
            m_txtNationality.Text = "";
            m_txtNation.Text = "";
            m_txtIDCard.Text = "";
            //m_txtProvince.Text = "";
            m_txtCountry.Text = "";
            m_txtOfficeAddress.Text = "";
            m_txtHomePhone.Text = "";
            m_txtOfficePC.Text = "";
            m_txtHomeAddress.Text = "";
            m_txtHomePC.Text = "";
            m_txtContactMan.Text = "";
            m_txtRelation.Text = "";
            m_txtContactManAddress.Text = "";
            m_txtContactManPhone.Text = "";
        }
        #endregion

        #region 清空病人基本住院信息内容
        /// <summary>
        /// 清空病人基本住院信息内容
        /// </summary>
        private void m_mthCleanUpPatientDetailInfo()
        {
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(m_txtSign);

            //dtgChangeDept.CurrentRowIndex = 0;
            //m_dtbChangeDept.Rows.Clear();
            lblInHosptialSetion.Text = "";
            lblInSickRoom.Text = "";
            lblOutHospitalSetion.Text = "";
            lblOutSickRoom.Text = "";
            lblInHospitalDays.Text = "";
            //dtpOutHospitalDate.Value = DateTime.Now;
            m_lblOutHospitalDate.Text = "";
            m_lsvTransDept.Items.Clear();
        }
        #endregion

        #region 清空病人住院病案首页内容
        /// <summary>
        /// 清空病人住院病案首页内容
        /// </summary>
        private void m_mthCleanUpPatientInHospitalMainRecrodInfo()
        {
            m_strCurrentOpenDate = "";

            txtInsuranceNum.m_mthClearText();
            //m_cboModeOfPayment.m_mthClearText();
            txtPatientHistoryNO.m_mthClearText();
            //dtpOutHospitalDate.Value = DateTime.Now;
            m_lblOutHospitalDate.Text = "";
            m_lsvTransDept.Items.Clear();

            txtDiagnosis.m_mthClearText();
            txtDiagnosisZhongYi.m_mthClearText();
            //txtInHospitalDiagnosis.m_mthClearText();
            txtDoctor.Tag = null;
            txtDoctor.Text = string.Empty;
            dtpConfirmDiagnosisDate.Value = DateTime.Now;
            gpbCondictionWhenIn.Tag = "2";
            rdbDanger.Checked = false;
            rdbEmergency.Checked = false;
            rdbNormal.Checked = true;

            txtMainDiagnosis.m_mthClearText();
            txtMainDiagnosiszhongyi.m_mthClearText();

            txtzhuzheng.m_mthClearText();

            //gpbMainDiagnosis.Tag = "0";
            //rdbHealOfMain.Checked = true;
            //rdbOnTheMendOfMain.Checked = false;
            //rdbNotCureOfMain.Checked = false;
            //rdbDieOfMain.Checked = false;
            //rdbNotDefineOfMain.Checked = false;

            txtICD_10OfMain.m_mthClearText();
            txtICD_10OfMainzhongyi.m_mthClearText();
            txtzhuzhengICD.m_mthClearText();
            //txtInfectionDiagnosis.m_mthClearText();

            //gpbInfection.Tag = "0";
            //rdbHealOfInfection.Checked = true;
            //rdbOnTheMendOfInfection.Checked = false;
            //rdbNotCureOfInfection.Checked = false;
            //rdbDieOfInfection.Checked = false;
            //rdbNotDefineOfInfection.Checked = false;

            //txtICD_10OfInfection.m_mthClearText();
            txtPathologyDiagnosis.m_mthClearText();
            //			txtScacheSource.Text = clsDefaultValue.c_strScacheSource;
            txtSensitive.m_mthClearText();
            txtHbsAg.m_mthClearText();
            txtHCV_Ab.m_mthClearText();
            txtHIV_Ab.m_mthClearText();
            txtweizhong.m_mthClearText();
            txtjizheng.m_mthClearText();
            txtyinanqingkuang.m_mthClearText();
            txtSalveMethod.m_mthClearText();
            txtAccordWithOutHospital.m_mthClearText();
            txtdeathreason.m_mthClearText();
            txtshoushu.m_mthClearText();
            txt_zhiliao.m_mthClearText();
            txtjiancha.m_mthClearText();
            txtzhengduan.m_mthClearText(); 
            dtpdeathtime.Text = "";
            txtAccordWithOutHospitalzhong.m_mthClearText();
            txtAccordInWithOut.m_mthClearText();
            txtAccordInWithOutzhong.m_mthClearText();
            txtAccordBeforeOperationWithAfter.m_mthClearText();
            txtAccordClinicWithPathology.m_mthClearText();
            txtAccordRadiateWithPathology.m_mthClearText();
            txtSalveTimes.m_mthClearText();
            txtSalveSuccess.m_mthClearText();
            txtbinglihao.Text = "";
            txtchuyuanfangshi.Text = "";
            txtleibie.Text = "";
            txtzhiji.Text = "";
            txtruyuanqian.Text = "";
            txtruyuantujing.Text = "";
            txtDirectorDt.Tag = null;
            txtDirectorDt.Text = string.Empty;
            txtSubDirectorDt.Tag = null;
            txtSubDirectorDt.Text = string.Empty;
            txtDt.Tag = null;
            txtDt.Text = string.Empty;
            txtInHospitalDt.Tag = null;
            txtInHospitalDt.Text = string.Empty;
            txtAttendInForAdvancesStudyDt.Tag = null;
            txtAttendInForAdvancesStudyDt.Text = string.Empty;

            txtGraduateStudentIntern.Tag = null;
            txtGraduateStudentIntern.Text = string.Empty;
            txtIntern.Tag = null;
            txtIntern.Text = string.Empty;
            txtCoder.Tag = null;
            txtCoder.Text = string.Empty;

            //gpbQuality.Tag = "-1";
            //rdbQuality1.Checked = false;
            //rdbQuality2.Checked = false;
            //rdbQuality3.Checked = false;

            txt_zhiliang.Text = "";

            txtQCDt.Tag = null;
            txtQCDt.Text = string.Empty;
            txtQCNurse.Tag = null;
            txtQCNurse.Text = string.Empty;
            //			dtpQCTime.Value = DateTime.Parse("1900年01月01日");
            dtpQCTime.Value = DateTime.Now;

            gpbRTMode.Tag = "-1";
            rdbRTCure.Checked = false;
            rdbRTAppeasement.Checked = false;
            rdbRTAssistant.Checked = false;

            gpbRTRule.Tag = "-1";
            rdbContinue.Checked = false;
            rdbRTGap.Checked = false;
            rdbRTSection.Checked = false;

            chkRTCo.Checked = false;
            chkRTAccelerator.Checked = false;
            chkRTX_Ray.Checked = false;
            chkRTLacuna.Checked = false;

            gpbOriginalDisease.Tag = "-1";
            rdbOriginalDiseaseFirst.Checked = false;
            rdbOriginalDiseaseRepeat.Checked = false;
            txtOriginalDiseaseGy.m_mthClearText();
            txtOriginalDiseaseTimes.m_mthClearText();
            txtOriginalDiseaseDays.m_mthClearText();
            //dtpOriginalDiseaseBeginDate.Text = DateTime.Now.ToString("yyyyMMdd"); 
            //dtpOriginalDiseaseEndDate.Text = DateTime.Now.ToString("yyyyMMdd");

            gpbLymph.Tag = "-1";
            rdbLymphFirst.Checked = false;
            rdbLymphRepeat.Checked = false;

            txtLymphGy.m_mthClearText();
            txtLymphTimes.m_mthClearText();
            txtLymphDays.m_mthClearText();
            //dtpLymphBeginDate.Text = DateTime.Now.ToString("yyyyMMdd");
            //dtpLymphEndDate.Text = DateTime.Now.ToString("yyyyMMdd");
            txtMetastasisGy.m_mthClearText();
            txtMetastasisTimes.m_mthClearText();
            txtMetastasisDays.m_mthClearText();
            //dtpMetastasisBeginDate.Text = DateTime.Now.ToString("yyyyMMdd");
            //dtpMetastasisEndDate.Text = DateTime.Now.ToString("yyyyMMdd");

            dtpOriginalDiseaseBeginDate.m_mthClearValue();
            dtpOriginalDiseaseEndDate.m_mthClearValue();
            dtpLymphBeginDate.m_mthClearValue();
            dtpLymphEndDate.m_mthClearValue();
            dtpMetastasisBeginDate.m_mthClearValue();
            dtpMetastasisEndDate.m_mthClearValue();

            gpbChemotherapyMode.Tag = "-1";
            rdbChemotherapyCure.Checked = false;
            rdbChemotherapyAppeasement.Checked = false;
            rdbChemotherapyAssisantNew.Checked = false;
            rdbChemotherapyAssistant.Checked = false;
            rdbChemotherapyNewMedicine.Checked = false;

            chkChemotherapyWholeBody.Checked = false;
            chkChemotherapyLocal.Checked = false;
            chkChemotherapyIntubate.Checked = false;
            chkChemotherapyThorax.Checked = false;
            chkChemotherapyAbdomen.Checked = false;
            chkChemotherapySpinal.Checked = false;
            chkChemotherapyOtherTry.Checked = false;
            chkChemotherapyOther.Checked = false;

            txtTotalAmt.m_mthClearText();
            txtBedAmt.m_mthClearText();
            txtNurseAmt.m_mthClearText();
            txtWMAmt.m_mthClearText();
            txtCMFinishedAmt.m_mthClearText();
            txtCMSemiFinishedAmt.m_mthClearText();
            txtRadiationAmt.m_mthClearText();
            txtAssayAmt.m_mthClearText();
            txtO2Amt.m_mthClearText();
            txtBloodAmt.m_mthClearText();
            txtTreatmentAmt.m_mthClearText();
            txtOperationAmt.m_mthClearText();
            txtDeliveryChildAmt.m_mthClearText();
            txtCheckAmt.m_mthClearText();
            txtAnaethesiaAmt.m_mthClearText();
            txtBabyAmt.m_mthClearText();
            txtAccompanyAmt.m_mthClearText();
            txtOtherAmt1.m_mthClearText();
            txtOtherAmt2.m_mthClearText();
            txtOtherAmt3.m_mthClearText();

            gpbCorpseCheck.Tag = "1";
            rdbCorpseCheckYes.Checked = true;
            rdbCorpseCheckNO.Checked = false;

            gpbFirstCase.Tag = "1";
            rdbFirstCaseYes.Checked = true;
            rdbFirstCaseNO.Checked = false;

            gpbFollow.Tag = "1";
            rdbFollowYes.Checked = true;
            rdbFollowNO.Checked = false;

            txtFollow_Week.m_mthClearText();
            txtFollow_Month.m_mthClearText();
            txtFollow_Year.m_mthClearText();

            gpbModelCase.Tag = "1";
            rdbModelCaseYes.Checked = true;
            rdbModelCaseNO.Checked = false;
            txtBloodType.m_mthClearText();
            txt_shuye.m_mthClearText();
            gpbBloodRh.Tag = "3";
            rdbBloodRh_Ka.Checked = false;
            rdbBloodRh_An.Checked = false;
            rdbBloodRh_No.Checked = true;

            gpbBloodTransAction.Tag = "3";
            //rdbBloodTransActionYes.Checked = false;
            //rdbBloodTransActionNO.Checked = false;
            //rdbBloodTransNoAction.Checked = true;
            txt_shuxue.Text = "";

            txtRBC.m_mthClearText();
            txtPLT.m_mthClearText();
            txtPlasm.m_mthClearText();
            txtWholeBlood.m_mthClearText();
            txtOtherBlood.m_mthClearText();
            txtConsultation.m_mthClearText();
            txtLongDistanctConsultation.m_mthClearText();
            txtTOPLevel.m_mthClearText();
            txtNurseLevelI.m_mthClearText();
            txtNurseLevelII.m_mthClearText();
            txtNurseLevelIII.m_mthClearText();
            txtICU.m_mthClearText();
            txtSpecialNurse.m_mthClearText();

            //dtgOtherDiagnosis.CurrentRowIndex = 0;
            m_dtbOtherDiagnosis.Rows.Clear();
            m_dtbOtherDiagnosisz.Rows.Clear();

            dtgOperation.CurrentRowIndex = 0;
            m_dtbOperationDetail.Rows.Clear();

            //dtgBaby.CurrentRowIndex = 0;
            m_dtbBaby.Rows.Clear();

            //dtgChemotherapy.CurrentRowIndex = 0;
            //m_dtbChemotherapy.Rows.Clear();

            txtInsuranceNum.Text = "";
            lblTimes.Text = "";
            m_cboModeOfPayment.Text = "";
            txtPatientHistoryNO.Text = "";

            m_dtbInfectionDiagnosis.Rows.Clear();
            m_dtbInfectionDiagnosisZhong.Rows.Clear();
            m_dtbInHospitalDiagnosis.Rows.Clear();
            m_dtbInHospitalDiagnosisZhong.Rows.Clear();

            txtDiagnosisICD10.Clear();
        }
        #endregion

        #region 婴儿DataGrid控制

        //bool blnIsChange = false;
        /// <summary>
        /// 婴儿DataGrid控制
        /// </summary>
        /// <param name="p_objSender"></param>
        /// <param name="p_objArg"></param>
        private void m_mthRowChanged(object p_objSender, DataRowChangeEventArgs e)
        {
            if (e.Action == DataRowAction.Add)
            {
                //blnIsChange = true;
                object[] objNewValue = e.Row.ItemArray;
                objNewValue[0] = m_dtbBaby.Rows.Count;// + 1;
                e.Row.ItemArray = objNewValue;
                //blnIsChange = false;
            }
            else if (e.Action == DataRowAction.Delete)
            {
                //blnIsChange = true;
                for (int i = 0; i < m_dtbBaby.Rows.Count; i++)
                {
                    object[] objValue = m_dtbBaby.Rows[i].ItemArray;
                    objValue[0] = i + 1;
                    m_dtbBaby.Rows[i].ItemArray = objValue;
                }
                //blnIsChange = false;
            }
            //else if (e.Action == DataRowAction.Change && !blnIsChange)
            //{
            //    blnIsChange = true;
            //    object[] objNewValue = new object[e.Row.ItemArray.Length];
            //    e.Row.ItemArray.CopyTo(objNewValue,0);
            //    e.Row.CancelEdit();
            //    object[] objOldValues = e.Row.ItemArray;
            //    if (!objNewValue[1].Equals(objOldValues[1]) && objNewValue[1].ToString() == "True")
            //        objNewValue[2] = false;
            //    else if (!objNewValue[2].Equals(objOldValues[2]) && objNewValue[2].ToString() == "True")
            //        objNewValue[1] = false;
            //    e.Row.ItemArray = objNewValue;
            //    e.Row.AcceptChanges();
            //    blnIsChange = false;
            //}
        }
        #endregion


        #region 添加键盘快捷键
        private void m_mthSetQuickKeys()
        {
            m_mthSetControlEvent(this);
        }

        private void m_mthSetControlEvent(Control p_ctlControl)
        {
            #region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName != "Lable" && strTypeName != "Button")
            {
                p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox" && strTypeName != "ctlTimePicker")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        string strSubTypeName = subcontrol.GetType().Name;
                        if (strSubTypeName != "Lable" && strSubTypeName != "Button" && strSubTypeName != "ctlTimePicker")
                            m_mthSetControlEvent(subcontrol);
                    }
                }
            }
            #endregion
        }

        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search

                #region No uesed
                //case Keys.Enter:// enter				

                //    if(((Control)sender).Name=="txtDoctor" || ((Control)sender).Name=="txtDirectorDt"  || ((Control)sender).Name=="txtSubDirectorDt" || ((Control)sender).Name=="txtDt" || ((Control)sender).Name=="txtInHospitalDt"|| ((Control)sender).Name=="txtAttendInForAdvancesStudyDt"|| ((Control)sender).Name=="txtGraduateStudentIntern"|| ((Control)sender).Name=="txtIntern"|| ((Control)sender).Name=="txtCoder"|| ((Control)sender).Name=="txtQCDt"|| ((Control)sender).Name=="txtQCNurse")
                //    {	
                //        lsvEmployee.Left=((Control)sender).Left;
                //        lsvEmployee.Top=((Control)sender).Bottom;	
                //        m_mthGetDoctorList(((Control)sender).Text);

                //        if(lsvEmployee.Items.Count==1 && (((Control)sender).Text==lsvEmployee.Items[0].SubItems[0].Text|| ((Control)sender).Text==lsvEmployee.Items[0].SubItems[1].Text))
                //        {
                //            lsvEmployee.Items[0].Selected=true;
                //            lsvEmployee_DoubleClick(sender,null);
                //            break;
                //        }
                //    }		
                //    else if(((Control)sender).Name=="lsvEmployee")
                //    {
                //        lsvEmployee_DoubleClick(sender,null);						
                //    }
                //    break;


                //case Keys.Down:
                //    if(sender.GetType().Name=="ctlRichTextBox")
                //    {
                //        if(lsvEmployee.Visible && lsvEmployee.Items.Count >0)
                //        {
                //            lsvEmployee.Items[0].Selected = true;
                //            lsvEmployee.Focus();
                //        }
                //        if(lsvAanaesthesiaMode.Visible && lsvAanaesthesiaMode.Items.Count >0)
                //        {
                //            lsvAanaesthesiaMode.Items[0].Selected = true;
                //            lsvAanaesthesiaMode.Focus();
                //        }
                //        if(lsvOperationEmployee.Visible && lsvAanaesthesiaMode.Items.Count > 0)
                //        {
                //            lsvOperationEmployee.Items[0].Selected = true;
                //            lsvOperationEmployee.Focus();
                //        }
                //        if(((Control)sender).Name=="txtDoctor" || ((Control)sender).Name=="txtDirectorDt"  || ((Control)sender).Name=="txtSubDirectorDt" || ((Control)sender).Name=="txtDt" || ((Control)sender).Name=="txtInHospitalDt"|| ((Control)sender).Name=="txtAttendInForAdvancesStudyDt"|| ((Control)sender).Name=="txtGraduateStudentIntern"|| ((Control)sender).Name=="txtIntern"|| ((Control)sender).Name=="txtCoder"|| ((Control)sender).Name=="txtQCDt"|| ((Control)sender).Name=="txtQCNurse")
                //        {	
                //            if(((Control)sender).Text.Length>0)
                //            {	
                //                if(lsvEmployee.Visible==false || lsvEmployee.Items.Count==0)
                //                {		
                //                    lsvEmployee.Left=((Control)sender).Left;
                //                    lsvEmployee.Top=((Control)sender).Bottom;	
                //                    m_mthGetDoctorList(((Control)sender).Text);
                //                }
                //                lsvEmployee.BringToFront();
                //                lsvEmployee.Visible=true;
                //                lsvEmployee.Focus();
                //                if( lsvEmployee.Items.Count>0)
                //                {
                //                    lsvEmployee.Items[0].Selected=true;
                //                    lsvEmployee.Items[0].Focused=true;
                //                }	
                //            }
                //        }	
                //    }
                //    break;


                //				case Keys.Up:
                //					if(lsvEmployee.Items.Count > 0 && lsvEmployee.Items[0].Selected)
                //						m_RtbCurrentTextBox.Focus();
                //					break;		
                #endregion no uesed

                case Keys.F2://save
                    this.Save();
                    break;
                case Keys.F3://del
                    this.Delete();
                    break;
                case Keys.F4://print
                    this.Print();
                    break;
                case Keys.F5://refresh
                    this.txtInPatientID.Text = "";
                    m_mthCleanUP();
                    this.trvTime.Nodes[0].Nodes.Clear();
                    txtInPatientID.Focus();
                    break;
                case Keys.F6://Search					
                    break;
                case Keys.F9:
                    m_mthQueryDictDate(sender);//查询字典
                    break;
            }
        }

        #endregion
        #region datagrid双击行删除记录
        private void m_dtgRecord_DoubleClick(object sender, EventArgs e)
        {
            if (MDIParent.m_objCurrentPatient == null)
                return;
            DataGrid dg = (DataGrid)((DataGridTextBox)sender).Parent;
            switch (dg.Name)
            {
                case "dgDiagnosis3"://西医其他诊断
                    if (dg.CurrentRowIndex < m_dtbOtherDiagnosis.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbOtherDiagnosis.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbOtherDiagnosis.AcceptChanges();
                        }
                    }
                    break;
                case "dgDiagnosis1"://入院诊断
                    if (dg.CurrentRowIndex < m_dtbInHospitalDiagnosis.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbInHospitalDiagnosis.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbInHospitalDiagnosis.AcceptChanges();
                        }
                    }
                    break;
                case "dgDiagnosiszhongyi"://中医入院诊断
                    if (dg.CurrentRowIndex < m_dtbInHospitalDiagnosisZhong.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbInHospitalDiagnosisZhong.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbInHospitalDiagnosisZhong.AcceptChanges();
                        }
                    }
                    break;
                case "dgDiagnosis2"://医院感染名称
                    if (dg.CurrentRowIndex < m_dtbInfectionDiagnosis.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbInfectionDiagnosis.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbInfectionDiagnosis.AcceptChanges();
                        }
                    }
                    break;
                case "dgDiagnosis2zhong"://医院感染名称
                    if (dg.CurrentRowIndex < m_dtbInfectionDiagnosisZhong.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbInfectionDiagnosisZhong.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbInfectionDiagnosisZhong.AcceptChanges();
                        }
                    }
                    break;
                case "dtgOperation"://手术情况
                    if (dg.CurrentRowIndex < m_dtbOperationDetail.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbOperationDetail.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbOperationDetail.AcceptChanges();
                        }
                    }
                    break;
                case "dtgBaby"://产科分娩婴儿记录表
                    if (dg.CurrentRowIndex < m_dtbBaby.Rows.Count)
                    {
                        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            m_dtbBaby.Rows[dg.CurrentRowIndex].Delete();
                            m_dtbBaby.AcceptChanges();
                        }
                    }
                    break;
                //case "dtgChemotherapy"://化疗用药及疗效
                //    if (dg.CurrentRowIndex < m_dtbChemotherapy.Rows.Count)
                //    {
                //        if (clsPublicFunction.ShowInformationMessageBox("确认删除此行记录？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //        {
                //            m_dtbChemotherapy.Rows[dg.CurrentRowIndex].Delete();
                //            m_dtbChemotherapy.AcceptChanges();
                //        }
                //    }
                //    break;
                default:
                    break;
            }
        }
        #endregion

        #region 手术情况、化疗用药日期判断
        private void m_mthDate_Change(object sender, System.EventArgs e)
        {
            DataGridTextBox dg = (DataGridTextBox)sender;
            DateTime dtmTemp;
            DateTime.TryParse(dg.Text, out dtmTemp);
            if (dtmTemp == DateTime.MinValue)
            {
                dg.Text = "";
            }
            else
            {
                int intOperationDate = Convert.ToInt32(Convert.ToDateTime(dg.Text).ToString("yyyyMMdd"));
                int intInpatientDate = Convert.ToInt32(m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyyMMdd"));
                int intOutPatientDate = m_lblOutHospitalDate.Text == "" ? Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) : Convert.ToInt32(Convert.ToDateTime(m_lblOutHospitalDate.Text).ToString("yyyyMMdd"));
                if (intOperationDate < intInpatientDate || intOperationDate > intOutPatientDate)
                {
                    clsPublicFunction.ShowInformationMessageBox("时间应介于入院日期和出院日期之间！");
                    dg.Focus();
                }
            }
        }
        #endregion

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

            //if(p_strDoctorNameLike.Length == 0)
            //{
            //    lsvEmployee.Visible = false;
            //    return;
            //}							

            //clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

            //if(objDoctorArr == null)
            //{
            //    lsvEmployee.Visible = false;
            //    return;
            //}

            //lsvEmployee.Items.Clear();

            //for(int i=0;i<objDoctorArr.Length;i++)
            //{
            //    ListViewItem lviDoctor = new ListViewItem(
            //        new string[]{
            //                        objDoctorArr[i].m_StrEmployeeID,
            //                        objDoctorArr[i].m_StrFirstName
            //                    });
            //    lviDoctor.Tag = objDoctorArr[i];

            //    lsvEmployee.Items.Add(lviDoctor);
            //}

            //m_mthChangeListViewLastColumnWidth(lsvEmployee);
            //lsvEmployee.BringToFront();
            //lsvEmployee.Visible = true;

            //if(lsvEmployee.Items.Count > 0)
            //{
            //    lsvEmployee.Focus();
            //    lsvEmployee.Items[0].Selected = true;
            //}
        }

        //private void dtpOutHospitalDate_evtValueChanged(object sender, System.EventArgs e)
        //{
        //    if(trvTime.SelectedNode == null)
        //        return;
        //    if(trvTime.SelectedNode.Tag == null)
        //        return;

        //    /*计算实际住院天数
        //     * */
        //    System.TimeSpan diff=dtpOutHospitalDate.Value.Subtract(((DateTime)trvTime.SelectedNode.Tag));
        //    lblInHospitalDays.Text = ((int)diff.TotalDays).ToString();
        //}


        #region	打印

        #region 有关打印的声明
        private DateTime m_dtmCurrentPrintTime;
        private clsPublicControlPaint m_objCPaint;
        private clsPrintContext m_objPrintContext;
        private clsPrintDateInfo m_objPrintDateInfo;
        private System.Drawing.Printing.PrintDocument pdcOperation;
        /// <summary>
        /// 标题的字体
        /// </summary>
        private Font m_fotTitleFont;

        /// <summary>
        /// 画正方形的字体
        /// </summary>
        private Font m_fotRetangleFont;
        /// <summary>
        /// 表头的字体
        /// </summary>
        private Font m_fotHeaderFont;
        /// <summary>
        /// 表内容的字体
        /// </summary>
        private Font m_fotSmallFont;
        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;
        /// <summary>
        /// 刷子
        /// </summary>
        private SolidBrush m_slbBrush;
        /// <summary>
        /// 获取坐标的类
        /// </summary>
        private clsPrintPageSettingForRecord m_objPageSetting;
        /// <summary>
        /// 打印的病人基本信息类
        /// </summary>
        //		private int m_intYPos = (int)enmRectangleInfo.TopY + 12;
        private int m_intYPos = (int)enmRectangleInfo.TopY1;
        //		private int m_intPreY = (int)enmRectangleInfo.TopY;
        //		private int m_intEndIndex = 0;
        //		private int m_intPages=1;

        private class clsEveryRecordPageInfo
        {
            public string m_strModeOfPayment;
            public string m_strInsuranceNum;
            public string m_strTimes;
            public string m_strPatientHistoryNO;
        }

        /// <summary>
        /// 格子的信息
        /// </summary>
        public enum enmRectangleInfo
        {
            /// <summary>
            /// 格子的顶端
            /// </summary>
            TopY = 140,
            TopY1 = 36,

            ///<summary>
            /// 格子的左端
            /// </summary>
            //			LeftX = 78,
            LeftX = 18,
            LeftX1 = 2,
            /// <summary>
            /// 格子的右端
            /// </summary>
            //			RightX = 827-30,
            RightX = 180 + 17,
            RightX1 = 185,
            /// <summary>
            /// 格子每行的步长
            /// </summary>
            //			RowStep = 25,
            RowStep = 7,
            RowStep1 = 6,
            SmallRowStep = 20,
            /// <summary>
            /// 格子的行数
            /// </summary>
            RowLinesNum = 32,

            ColumnsMark1 = 35,

            /// <summary>
            /// CheckBox偏移右边文本的距离
            /// </summary>
            CheckShift = 15,

            /// <summary>
            /// 底划线偏移文本顶点的距离
            /// </summary>
            BottomLineShift = 15,

            BottomY = 1024

        }
        #region 打印行定义
        private clsPrintLine1 m_objLine1;
        private clsPrintLine2 m_objLine2;
        private clsPrintLine3 m_objLine3;
        private clsPrintLine4 m_objLine4;
        private clsPrintLine5 m_objLine5;
        private clsPrintLine6 m_objLine6;
        private clsPrintLine7 m_objLine7;
        private clsPrintLine8 m_objLine8;
        private clsPrintLine9 m_objLine9;
        private clsPrintLine10 m_objLine10;
        private clsPrintLine11 m_objLine11;
        private clsPrintLine12 m_objLine12;
        private clsPrintLine13 m_objLine13;
        private clsPrintLine14 m_objLine14;
        private clsPrintLine15 m_objLine15;
        private clsPrintLine16 m_objLine16;
        private clsPrintLine17 m_objLine17;
        private clsPrintLine18 m_objLine18;
        private clsPrintLine19 m_objLine19;
        private clsPrintLine20 m_objLine20;
        private clsPrintLine21 m_objLine21;
        //		private clsPrintLine22 m_objLine22;
        //		private clsPrintLine23 m_objLine23;
        //		private clsPrintLine24 m_objLine24;
        //		private clsPrintLine25 m_objLine25;
        //		private clsPrintLine26 m_objLine26;
        //		private clsPrintLine27 m_objLine27;
        private clsPrintLine100 m_objLine100;
        private clsPrintLine101 m_objLine101;
        private clsPrintLine102 m_objLine102;
        private clsPrintLine103 m_objLine103;
        private clsPrintLine104 m_objLine104;
        private clsPrintLine105 m_objLine105;
        private clsPrintLine106 m_objLine106;
        private clsPrintLine107 m_objLine107;
        private clsPrintLine108 m_objLine108;
        private clsPrintLine109 m_objLine109;
        private clsPrintLine110 m_objLine110;
        private clsPrintLine111 m_objLine111;
        private clsPrintLine112 m_objLine112;
        private clsPrintLine113 m_objLine113;
        private clsPrintLine114 m_objLine114;
       // private clsPrintLine115 m_objLine115;
        private clsPrintLine116 m_objLine116;
        private clsPrintLine117 m_objLine117;
        private clsPrintLine118 m_objLine118;
        private clsPrintLine119 m_objLine119;
        private clsPrintLine120 m_objLine120;
        private clsPrintLine121 m_objLine121;
        private clsPrintLine122 m_objLine122;
        private clsPrintLine123 m_objLine123;
        private clsPrintLine124 m_objLine124;
        private clsPrintLine125 m_objLine125;
        private clsPrintLine126 m_objLine126;
        private clsPrintLine127 m_objLine127;
        private clsPrintLine128 m_objLine128;
        private clsPrintLine129 m_objLine129;
        #endregion

        /// <summary>
        /// 打印元素
        /// </summary>
        private enum enmItemDefination
        {
            //基本元素
            InPatientID_Title,
            InPatientID,
            Name_Title,
            Name,
            Sex_Title,
            Sex,
            Age_Title,
            Age,
            Dept_Name_Title,
            Dept_Name,
            BedNo_Title,
            BedNo,

            Page_HospitalName,
            Page_Name_Title,
            Page_Title,
            Page_Num,
            Page_Of,
            Page_Count,

            Print_Date_Title,
            Print_Date,

        }


        #region 定义打印各元素的坐标点
        protected class clsPrintPageSettingForRecord
        {
            public clsPrintPageSettingForRecord() { }

            /// <summary>
            /// 获得坐标点
            /// </summary>
            /// <param name="p_intItemName">项目名称</param>
            /// <returns></returns>
            public PointF m_getCoordinatePoint(int p_intItemName)
            {
                PointF m_fReturnPoint;
                switch (p_intItemName)
                {

                    case (int)enmItemDefination.Page_HospitalName:
                        m_fReturnPoint = new PointF(71f, 13f);
                        break;
                    case (int)enmItemDefination.Page_Name_Title:
                        m_fReturnPoint = new PointF(83f, 22f);
                        break;
                    case (int)enmItemDefination.Name_Title:
                        m_fReturnPoint = new PointF(18f, 29f);
                        break;
                    case (int)enmItemDefination.Name:
                        m_fReturnPoint = new PointF(42f, 20f);
                        break;

                    case (int)enmItemDefination.Sex_Title:
                        m_fReturnPoint = new PointF(150f, 120f);
                        break;
                    case (int)enmItemDefination.Sex:
                        m_fReturnPoint = new PointF(200f, 120f);
                        break;

                    case (int)enmItemDefination.Age_Title:
                        m_fReturnPoint = new PointF(250f, 120f);
                        break;
                    case (int)enmItemDefination.Age:
                        m_fReturnPoint = new PointF(300f, 120f);
                        break;

                    case (int)enmItemDefination.Dept_Name_Title:
                        m_fReturnPoint = new PointF(330f, 120f);
                        break;
                    case (int)enmItemDefination.Dept_Name:
                        m_fReturnPoint = new PointF(370f, 120f);
                        break;

                    case (int)enmItemDefination.BedNo_Title:
                        m_fReturnPoint = new PointF(450f, 120f);
                        break;
                    case (int)enmItemDefination.BedNo:
                        m_fReturnPoint = new PointF(500f, 120f);
                        break;

                    case (int)enmItemDefination.InPatientID_Title:
                        m_fReturnPoint = new PointF(49f, 30f);
                        break;
                    case (int)enmItemDefination.InPatientID:
                        m_fReturnPoint = new PointF(68f, 30f);
                        break;
                    //					case (int)enmItemDefination.BasePointOne:
                    //						m_fReturnPoint = new PointF(20f,150f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointTwo:
                    //						m_fReturnPoint = new PointF(50f,150f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointThree:
                    //						m_fReturnPoint = new PointF(20f,250f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointFour:
                    //						m_fReturnPoint = new PointF(20f,280f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointFive:
                    //						m_fReturnPoint = new PointF(50f,280f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointSix:
                    //						m_fReturnPoint = new PointF(20f,600f);
                    //						break;
                    //					case (int)enmItemDefination.BasePointSeven:
                    //						m_fReturnPoint = new PointF(50f,600f);
                    //						break;
                    default:
                        m_fReturnPoint = new PointF(400f, 400f);
                        break;

                }
                return m_fReturnPoint;
            }
        }

        #endregion
        #endregion

        #region 外部打印.

        System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
            {
                objPrintToolCS.m_mthPrintPage(e);

                if (ppdPrintPreview != null)
                    while (!ppdPrintPreview.m_blnHandlePrint(e))
                        objPrintToolCS.m_mthPrintPage(e);
            }
            else
            {
                objPrintTool.m_mthPrintPage(e);

                if (ppdPrintPreview != null)
                    while (!ppdPrintPreview.m_blnHandlePrint(e))
                        objPrintTool.m_mthPrintPage(e);
            }
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
                objPrintToolCS.m_mthBeginPrint(e);
            else objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
                objPrintToolCS.m_mthEndPrint(e);
            else objPrintTool.m_mthEndPrint(e);
        }
        private clsInHospitalMainRecordCSPrintTool objPrintToolCS;
        private clsInHospitalMainRecord_XJPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
            {
                objPrintToolCS = new clsInHospitalMainRecordCSPrintTool(!m_blnDirectPrint);
                objPrintToolCS.m_mthInitPrintTool(null);
                if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                    objPrintToolCS.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                else
                    objPrintToolCS.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);

                objPrintToolCS.m_mthInitPrintContent();
            }
            else
            {
                objPrintTool = new clsInHospitalMainRecord_XJPrintTool(true);
                objPrintTool.m_mthInitPrintTool(null);
                if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);

                objPrintTool.m_mthInitPrintContent();
            }
            m_mthStartPrint();
        }

        private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();

        private void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
            {
                if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
                {
                    objPrintToolCS.m_BlnPreview = false;
                    objPrintToolCS.m_BlnIsDummy = false;
                    m_pdcPrintDocument.Print();
                    if (clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        objPrintToolCS.m_BlnIsDummy = true;
                        m_pdcPrintDocument.Print();
                    }
                }
                else
                {
                    objPrintTool.m_BlnPreview = false;
                    objPrintTool.m_BlnIsDummy = false;
                    m_pdcPrintDocument.Print();
                    if (clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        objPrintTool.m_BlnIsDummy = true;
                        m_pdcPrintDocument.Print();
                    }
                }
                // m_pdcPrintDocument.Print();
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
        #endregion 外部打印

        protected long m_lngSubPrint1()//作废
        {
            if (m_objSelectedPatient != null && m_objCollection.m_objContent != null)//当有资料的时候，要检查，否则，打印空表
            {
                if (!m_bolModifyCheck(false))
                {
                    return -1;
                }
            }
            //			if(m_objSelectedPatient == null || txtInPatientID.Text == "")
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("请正确输入住院号！");
            //				return -1;
            //			}
            //			if(trvTime.SelectedNode == null)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("请正确输入住院号！");
            //				return -1;
            //			}
            //			if(trvTime.SelectedNode.Tag == null)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("请选择住院日期！");
            //				return -1;
            //			}
            #region 有关打印初始化
            pdcOperation = new System.Drawing.Printing.PrintDocument();

            this.pdcOperation.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdcOperation_PrintPage);
            m_fotTitleFont = new Font("SimSun", 20, FontStyle.Bold);
            m_fotHeaderFont = new Font("SimSun", 12, FontStyle.Bold);
            m_fotRetangleFont = new Font("SimSun", 16);
            m_fotSmallFont = new Font("SimSun", 10.5f);
            m_GridPen = new Pen(Color.Black, 0.2f);
            m_slbBrush = new SolidBrush(Color.Black);
            m_objPageSetting = new clsPrintPageSettingForRecord();
            m_objCPaint = new clsPublicControlPaint();
            m_objPrintDateInfo = new clsPrintDateInfo();
            m_bolIfFirst = true;
            #region 打印行初始化
            m_objLine1 = new clsPrintLine1();
            m_objLine2 = new clsPrintLine2();
            m_objLine3 = new clsPrintLine3();
            m_objLine4 = new clsPrintLine4();
            m_objLine5 = new clsPrintLine5();
            m_objLine6 = new clsPrintLine6();
            m_objLine7 = new clsPrintLine7();
            m_objLine8 = new clsPrintLine8();
            m_objLine9 = new clsPrintLine9();
            m_objLine10 = new clsPrintLine10();
            m_objLine11 = new clsPrintLine11();
            m_objLine12 = new clsPrintLine12();
            m_objLine13 = new clsPrintLine13();
            m_objLine14 = new clsPrintLine14();
            m_objLine15 = new clsPrintLine15();
            m_objLine16 = new clsPrintLine16();
            m_objLine17 = new clsPrintLine17();
            m_objLine18 = new clsPrintLine18();
            m_objLine19 = new clsPrintLine19();
            m_objLine20 = new clsPrintLine20();
            m_objLine21 = new clsPrintLine21();
            m_objLine100 = new clsPrintLine100();
            m_objLine101 = new clsPrintLine101();
            m_objLine102 = new clsPrintLine102();
            m_objLine103 = new clsPrintLine103();
            m_objLine104 = new clsPrintLine104();
            m_objLine105 = new clsPrintLine105();
            m_objLine106 = new clsPrintLine106();
            m_objLine107 = new clsPrintLine107();
            m_objLine108 = new clsPrintLine108();
            m_objLine109 = new clsPrintLine109();
            m_objLine110 = new clsPrintLine110();
            m_objLine111 = new clsPrintLine111();
            m_objLine112 = new clsPrintLine112();
            m_objLine113 = new clsPrintLine113();
            m_objLine114 = new clsPrintLine114();
            //m_objLine115 = new clsPrintLine115();
            m_objLine116 = new clsPrintLine116();
            m_objLine117 = new clsPrintLine117();
            m_objLine118 = new clsPrintLine118();
            m_objLine119 = new clsPrintLine119();
            m_objLine120 = new clsPrintLine120();
            m_objLine121 = new clsPrintLine121();
            m_objLine122 = new clsPrintLine122();
            m_objLine123 = new clsPrintLine123();
            m_objLine124 = new clsPrintLine124();
            m_objLine125 = new clsPrintLine125();
            m_objLine126 = new clsPrintLine126();
            m_objLine127 = new clsPrintLine127();
            m_objLine128 = new clsPrintLine128();
            m_objLine129 = new clsPrintLine129();
            m_objPrintContext = new clsPrintContext(
                new clsPrintLineBase[]{
										  m_objLine1,
										  m_objLine2,
										  m_objLine3,
										  m_objLine4,
										  m_objLine5,
										  m_objLine6,
										  m_objLine7,
										  m_objLine8,
										  m_objLine9,
										  m_objLine10,
										  m_objLine11,
										  m_objLine12,
										  m_objLine13,
										  m_objLine14,
										  m_objLine15,
										  m_objLine16,
										  m_objLine17,
										  m_objLine18,
										  m_objLine19,
										  m_objLine20,
										  m_objLine21,
										  m_objLine100,
										  m_objLine101,
										  m_objLine102,
										  m_objLine103,
										  m_objLine104,
										  m_objLine105,
										  m_objLine106,
										  m_objLine107,
										  m_objLine108,
										  m_objLine109,
										  m_objLine110,
										  m_objLine111,
										  m_objLine112,
										  m_objLine113,
										  m_objLine114,
                                          //m_objLine115,
										  m_objLine116,
										  m_objLine117,
										  m_objLine118,
										  m_objLine119,
										  m_objLine120,
										  m_objLine121,
										  m_objLine122,
										  m_objLine123,
										  m_objLine124,
										  m_objLine125,
										  m_objLine126,
										  m_objLine127,
										  m_objLine128,
										  m_objLine129
									  });
            #endregion

            m_dtmCurrentPrintTime = DateTime.Parse(m_objPublicDomain.m_strGetServerTime());
            m_objPrintContext.m_DtmFirstPrintTime = this.m_dtmCurrentPrintTime;
            #endregion
            m_mthSetPrintValue();
            try
            {
                //				PageSetupDialog pageSetupDialog = new PageSetupDialog();
                //
                //				pageSetupDialog.Document = pdcOperation;
                //				pageSetupDialog.ShowDialog();				

                printpreviewdialog.Document = pdcOperation;
                printpreviewdialog.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return 1;
        }
        private PrintTool.frmPrintPreviewDialog printpreviewdialog = new PrintTool.frmPrintPreviewDialog();

        private bool m_bolIfFirst = true;
        private void pdcOperation_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //			e.PageSettings.

            e.HasMorePages = false;

            GraphicsUnit enmOld = e.Graphics.PageUnit;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            if (m_bolIfFirst && frmInHospitalMainRecord_XJ.s_blnPrintTitle)
            {
                m_mthPrintTitleInfo(e);
                e.Graphics.DrawLine(m_GridPen, (int)enmRectangleInfo.LeftX - 2, (int)enmRectangleInfo.TopY1 - 2, (int)enmRectangleInfo.RightX, (int)enmRectangleInfo.TopY1 - 2);

            }

            Font fntNormal = new Font("SimSun", 10.5f);
            //			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX-2,(int)enmRectangleInfo.TopY1-2,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY1-2);
            #region old code
            //			if(m_intPages!=1)
            //				m_intYPos=m_intYPos+5;
            //			while(m_objPrintContext.m_BlnHaveMoreLine)
            //			{
            //				m_objPrintContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);
            //				#region 处理换页
            ////				if(m_intYPos >(int)enmRectangleInfo.BottomY 
            ////					&& m_objPrintContext.m_BlnHaveMoreLine)
            ////				{
            ////					e.HasMorePages = true;
            ////					switch(m_intEndIndex)
            ////					{
            ////											
            ////						case 0:
            ////							m_mthHandleOneEnd(m_intYPos,e.Graphics,fntNormal);
            ////							m_intPreY=(int)enmRectangleInfo.TopY;
            ////							m_intEndIndex--;
            ////							break;
            ////						case 1:
            ////							m_mthHandleTwoEnd(m_intYPos,e.Graphics,fntNormal);
            ////							m_intPreY=(int)enmRectangleInfo.TopY;
            ////							m_intEndIndex--;
            ////							break;
            ////						case 2:
            ////							m_mthHandleThreeEnd(m_intYPos,e.Graphics,fntNormal);
            ////							m_intPreY=(int)enmRectangleInfo.TopY;
            ////							m_intEndIndex--;
            ////							break;
            ////						
            ////					}
            ////					
            ////				
            ////					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos-5);
            ////					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos-5);
            ////					
            ////					m_intPages++;
            ////					m_intYPos=(int)enmRectangleInfo.TopY+5;
            ////					
            ////					return;
            ////				}
            //				#endregion
            //				
            //				m_mthPrintHeader(e);
            //
            //				Font fntNormal = new Font("",12);
            //				while(m_objPrintLineContext.m_BlnHaveMoreLine)
            //				{
            //					m_objPrintLineContext.m_mthPrintNextLine(ref m_intYPos,e.Graphics,fntNormal);
            //
            //					if(m_intYPos > 969+130
            //						&& m_objPrintLineContext.m_BlnHaveMoreLine)
            //					{
            //						m_mthPrintFoot(e);
            //
            //						e.HasMorePages = true;
            //
            //						m_intYPos = 90;
            //
            //						m_intCurrentPage++;
            //
            //						return;
            //					}				
            //				}
            //
            //				//全部打完
            //				m_mthPrintFoot(e);
            //
            //				m_objPrintLineContext.m_mthReset();
            //
            //				m_intYPos = 90;
            //			}
            ////			m_intYPos=m_intYPos-5;
            ////			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos ,(int)enmRectangleInfo.RightX,m_intYPos);
            ////			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.LeftX,m_intYPos);
            ////			e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.RightX,(int)enmRectangleInfo.TopY,(int)enmRectangleInfo.RightX,m_intYPos);
            ////			
            ////			//全部打完
            //			m_objPrintContext.m_mthReset();
            ////			m_intPages=1;
            ////			m_intEndIndex=0;
            //			m_intYPos = (int)enmRectangleInfo.TopY;
            ////			m_intPreY=(int)enmRectangleInfo.TopY;
            #endregion
            while (m_objPrintContext.m_BlnHaveMoreLine)
            {
                m_objPrintContext.m_mthPrintNextLine(ref m_intYPos, e.Graphics, fntNormal);
                if (m_intYPos > 235 && m_objPrintContext.m_BlnHaveMoreLine)
                {
                    e.HasMorePages = true;
                    m_bolIfFirst = false;
                    //					e.Graphics.DrawLine(m_GridPen,(int)enmRectangleInfo.LeftX,m_intYPos,(int)enmRectangleInfo.RightX,m_intYPos);
                    //					m_objPrintContext.m_mthReset();
                    //					m_intYPos = (int)enmRectangleInfo.TopY+5;
                    m_intYPos = 12;
                    return;
                }
            }
            //全部打完
            m_objPrintContext.m_mthReset();

            //			m_intYPos = (int)enmRectangleInfo.TopY+5;
            m_intYPos = 36;

            e.Graphics.PageUnit = enmOld;

            m_bolIfFirst = true;

            //			frmInHospitalMainRecord_XJ.s_blnPrintTitle = false;
        }

        #region 标题文字部分
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsEveryRecordPageInfo objEveryRecordPageInfo = new clsEveryRecordPageInfo();
            //************************************************
            objEveryRecordPageInfo.m_strInsuranceNum = txtInsuranceNum.Text;
            objEveryRecordPageInfo.m_strTimes = lblTimes.Text;
            objEveryRecordPageInfo.m_strModeOfPayment = m_cboModeOfPayment.Text;
            objEveryRecordPageInfo.m_strPatientHistoryNO = txtPatientHistoryNO.Text;
            //			
            GraphicsUnit enmOld = e.Graphics.PageUnit;
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;


            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotTitleFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName));

            e.Graphics.DrawString("住 院 病 案 首 页 ※", m_fotHeaderFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title));


            e.Graphics.DrawString("医疗付款方式:", m_fotSmallFont, m_slbBrush, m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title));
            //			System.Windows.Forms.ControlPaint.DrawCheckBox(e.Graphics,120,115,25,25,PinkieControls.ButtonXPState.Flat);
            e.Graphics.DrawRectangle(new Pen(m_slbBrush, 0.1f), 44, 29, 3, 3);

            e.Graphics.DrawString(objEveryRecordPageInfo.m_strModeOfPayment, m_fotSmallFont, m_slbBrush, 44f, 29f);
            e.Graphics.DrawString("医保号:", m_fotSmallFont, m_slbBrush, 55f, 29f);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strInsuranceNum, m_fotSmallFont, m_slbBrush, 69f, 29f);
            e.Graphics.DrawString("第     次住院", m_fotSmallFont, m_slbBrush, 96f, 29f);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strTimes, m_fotSmallFont, m_slbBrush, 103f, 29f);
            e.Graphics.DrawString("病案号:___________ ", m_fotSmallFont, m_slbBrush, 153f, 29f);
            e.Graphics.DrawString(objEveryRecordPageInfo.m_strPatientHistoryNO, m_fotSmallFont, m_slbBrush, 169f, 29f);
            e.Graphics.PageUnit = enmOld;
        }

        #endregion

        private void m_mthSetPrintValue()
        {
            bool m_bolIfCheck = false;
            if (m_objSelectedPatient != null && m_objCollection.m_objContent != null)//当有资料的时候，要检查，否则，打印空表
            {
                m_bolIfCheck = true;
            }

            object[] m_objDataArr = null;//row
            object[] m_objSubDataArr = null;//column
            string m_strTemp = "";
            if (m_bolIfCheck)
            {
                clsPeopleInfo m_objPeople = m_objSelectedPatient.m_ObjPeopleInfo;
                m_objLine1.m_ObjPrintLineInfo = m_objPeople;
                m_objLine2.m_ObjPrintLineInfo = m_objPeople;
                m_objLine3.m_ObjPrintLineInfo = m_objPeople;
                m_objLine4.m_ObjPrintLineInfo = m_objPeople;
                m_objLine5.m_ObjPrintLineInfo = m_objPeople;
            }
            else
            {
                m_objLine1.m_ObjPrintLineInfo = null;
                m_objLine2.m_ObjPrintLineInfo = null;
                m_objLine3.m_ObjPrintLineInfo = null;
                m_objLine4.m_ObjPrintLineInfo = null;
                m_objLine5.m_ObjPrintLineInfo = null;
            }

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                //			m_objDataArr[0] = ((DateTime)trvTime.SelectedNode.Tag);
                m_objDataArr[0] = DateTime.Parse(m_objCollection.m_objContent.m_strInPatientDate).ToString("yyyy    MM    dd   HH");
                m_objDataArr[1] = lblInHosptialSetion.Text;
                m_objDataArr[2] = lblInSickRoom.Text;
                //for(int i1=0;i1<m_dtbChangeDept.Rows.Count;i1++)
                //{
                //    m_strTemp += m_dtbChangeDept.Rows[i1][0].ToString() + ";";
                //}
                m_objDataArr[3] = m_strTemp;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine6.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                //			m_objDataArr[0] = dtpOutHospitalDate.Value;
                m_objDataArr[0] = DateTime.Parse(m_objCollection.m_objContent.m_strOutPatientDate).ToString("yyyy    MM    dd   HH");
                m_objDataArr[1] = lblOutHospitalSetion.Text;
                m_objDataArr[2] = lblOutSickRoom.Text;
                m_objDataArr[3] = lblInHospitalDays.Text;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine7.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            //			m_objDataArr[0] = txtDiagnosis.Text;
            //			m_objDataArr[1] = txtDoctor.Text;
            //			m_objDataArr[2] = ((int)(int.Parse(gpbCondictionWhenIn.Tag.ToString()) + 1)).ToString();
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strDiagnosis;
                if (m_objCollection.m_objContent.m_strDoctor == null || m_objCollection.m_objContent.m_strDoctor == "")
                    m_objDataArr[1] = "";
                else
                {
                    m_objDataArr[1] = new clsEmployee(m_objCollection.m_objContent.m_strDoctor).m_StrFirstName;
                }


                m_objDataArr[2] = int.Parse(m_objCollection.m_objContent.m_strCondictionWhenIn) + 1;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine8.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[2];
            //			m_objDataArr[0] = txtInHospitalDiagnosis.Text;
            //			m_objDataArr[1] = dtpConfirmDiagnosisDate.Value;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strInHospitalDiagnosis;
                m_objDataArr[1] = DateTime.Parse(m_objCollection.m_objContent.m_strConfirmDiagnosisDate).ToString("yyyy    MM    dd  ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine9.m_ObjPrintLineInfo = m_objDataArr;


            m_objLine10.m_ObjPrintLineInfo = null;

            m_objDataArr = new Object[3];
            //			m_objDataArr[0] = txtMainDiagnosis.Text;
            //			m_objDataArr[1] = gpbCondictionWhenIn.Tag.ToString();
            //			m_objDataArr[2] = txtICD_10OfMain.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strMainDiagnosis;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strMainConditionSeq;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strICD_10OfMain;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine11.m_ObjPrintLineInfo = m_objDataArr;

            //if(m_objCollection.m_objOtherDiagnosisArr == null || m_objCollection.m_objOtherDiagnosisArr.Length <= 0)
            //{
            //    m_objLine12.m_ObjPrintLineInfo = null;
            //}
            //else
            //{
            //    if(m_objCollection.m_objOtherDiagnosisArr.Length > 0)
            //    {
            //        m_objDataArr = new Object[m_objCollection.m_objOtherDiagnosisArr.Length];

            //        for(int i1=0;i1<m_objCollection.m_objOtherDiagnosisArr.Length;i1++)
            //        {
            //            m_objSubDataArr = new object[3];
            //            m_objSubDataArr[0] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strDiagnosisDesc;
            //            m_objSubDataArr[1] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strConditionSeq;
            //            m_objSubDataArr[2] = m_objCollection.m_objOtherDiagnosisArr[i1].m_strICD10;
            //            m_objDataArr[i1] = m_objSubDataArr;
            //        }
            //        m_objLine12.m_ObjPrintLineInfo = m_objDataArr;
            //    }
            //}

            m_objDataArr = new Object[3];
            //			m_objDataArr[0] = txtInfectionDiagnosis.Text;
            //			m_objDataArr[1] = gpbInfection.Tag.ToString();
            //			m_objDataArr[2] = txtICD_10OfInfection.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strInfectionDiagnosis;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strInfectionCondictionSeq;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strICD_10OfInfection;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }

            m_objLine13.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                //			m_objDataArr[0] = txtPathologyDiagnosis.Text;
                m_objDataArr[0] = m_objCollection.m_objContent.m_strPathologyDiagnosis;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine14.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[1];
            if (m_bolIfCheck)
            {
                //				m_objDataArr[0] = txtScacheSource.Text;
                m_objDataArr[0] = m_objCollection.m_objContent.m_strScacheSource;
            }
            else
            {
                m_objDataArr[0] = "";
            }
            m_objLine15.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            //			m_objDataArr[0] = txtSensitive.Text;
            //			m_objDataArr[1] = txtHbsAg.Text;
            //			m_objDataArr[2] = txtHCV_Ab.Text;
            //			m_objDataArr[3] = txtHIV_Ab.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strSensitive;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strHbsAg;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strHCV_Ab;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strHIV_Ab;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine16.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            //			m_objDataArr[0] = txtAccordWithOutHospital.Text;
            //			m_objDataArr[1] = txtAccordInWithOut.Text;
            //			m_objDataArr[2] = txtAccordBeforeOperationWithAfter.Text;
            //			m_objDataArr[3] = txtAccordClinicWithPathology.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strAccordWithOutHospital;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strAccordInWithOut;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strAccordBeforeOperationWithAfter;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strAccordClinicWithPathology;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine17.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[3];
            //			m_objDataArr[0] = txtAccordRadiateWithPathology.Text;
            //			m_objDataArr[1] = txtSalveTimes.Text;
            //			m_objDataArr[2] = txtSalveSuccess.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strAccordRadiateWithPathology;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strSalveTimes;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strSalveSuccess;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine18.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            //			m_objDataArr[0] = txtDirectorDt.Text;
            //			m_objDataArr[1] = txtSubDirectorDt.Text;
            //			m_objDataArr[2] = txtDt.Text;
            //			m_objDataArr[3] = txtInHospitalDt.Text;
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strDirectorDt == null || m_objCollection.m_objContent.m_strDirectorDt == "")
                    m_objDataArr[0] = "";
                else
                    m_objDataArr[0] = new clsEmployee(m_objCollection.m_objContent.m_strDirectorDt).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strSubDirectorDt == null || m_objCollection.m_objContent.m_strSubDirectorDt == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = new clsEmployee(m_objCollection.m_objContent.m_strSubDirectorDt).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strDt == null || m_objCollection.m_objContent.m_strDt == "")
                    m_objDataArr[2] = "";
                else
                    m_objDataArr[2] = new clsEmployee(m_objCollection.m_objContent.m_strDt).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strInHospitalDt == null || m_objCollection.m_objContent.m_strInHospitalDt == "")
                    m_objDataArr[3] = "";
                else
                    m_objDataArr[3] = new clsEmployee(m_objCollection.m_objContent.m_strInHospitalDt).m_StrFirstName;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine19.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            //			m_objDataArr[0] = txtAttendInForAdvancesStudyDt.Text;
            //			m_objDataArr[1] = txtGraduateStudentIntern.Text;
            //			m_objDataArr[2] = txtIntern.Text;
            //			m_objDataArr[3] = txtCoder.Text;
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDt == null || m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDt == "")
                    m_objDataArr[0] = "";
                else
                    m_objDataArr[0] = new clsEmployee(m_objCollection.m_objContent.m_strAttendInForAdvancesStudyDt).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strGraduateStudentIntern == null || m_objCollection.m_objContent.m_strGraduateStudentIntern == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = new clsEmployee(m_objCollection.m_objContent.m_strGraduateStudentIntern).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strIntern == null || m_objCollection.m_objContent.m_strIntern == "")
                    m_objDataArr[2] = "";
                else
                    m_objDataArr[2] = new clsEmployee(m_objCollection.m_objContent.m_strIntern).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strCoder == null || m_objCollection.m_objContent.m_strCoder == "")
                    m_objDataArr[3] = "";
                else
                    m_objDataArr[3] = new clsEmployee(m_objCollection.m_objContent.m_strCoder).m_StrFirstName;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine20.m_ObjPrintLineInfo = m_objDataArr;

            m_objDataArr = new Object[4];
            //			m_objDataArr[0] = ((int)(int.Parse(gpbQuality.Tag.ToString()) + 1)).ToString();
            //			m_objDataArr[1] = txtQCDt.Text;
            //			m_objDataArr[2] = txtQCNurse.Text;
            //			m_objDataArr[3] = dtpQCTime.Value;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strQuality;
                if (m_objCollection.m_objContent.m_strQCDt == null || m_objCollection.m_objContent.m_strQCDt == "")
                    m_objDataArr[1] = "";
                else
                    m_objDataArr[1] = new clsEmployee(m_objCollection.m_objContent.m_strQCDt).m_StrFirstName;
                if (m_objCollection.m_objContent.m_strQCNurse == null || m_objCollection.m_objContent.m_strQCNurse == "")
                    m_objDataArr[2] = "";
                else
                    m_objDataArr[2] = new clsEmployee(m_objCollection.m_objContent.m_strQCNurse).m_StrFirstName;
                m_objDataArr[3] = DateTime.Parse(m_objCollection.m_objContent.m_strQCTime).ToString("yyyy    MM    dd  ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine21.m_ObjPrintLineInfo = m_objDataArr;

            //*******************************

            //第二页
            if (m_objCollection.m_objOperationArr == null || m_objCollection.m_objOperationArr.Length <= 0)
            {
                m_objLine102.m_ObjPrintLineInfo = null;
            }
            else
            {
                m_objDataArr = new Object[m_objCollection.m_objOperationArr.Length];

                for (int i1 = 0; i1 < m_objCollection.m_objOperationArr.Length; i1++)
                {
                    m_objSubDataArr = new object[9];
                    m_objSubDataArr[0] = m_objCollection.m_objOperationArr[i1].m_strOperationID;
                    m_objSubDataArr[1] = DateTime.Parse(m_objCollection.m_objOperationArr[i1].m_strOperationDate).ToString("yyyy-MM-dd HH:mm");
                    m_objSubDataArr[2] = m_objCollection.m_objOperationArr[i1].m_strOperationName;
                    m_objSubDataArr[3] = new clsEmployee(m_objCollection.m_objOperationArr[i1].m_strOperator).m_StrFirstName;
                    m_objSubDataArr[4] = new clsEmployee(m_objCollection.m_objOperationArr[i1].m_strAssistant1).m_StrFirstName;
                    m_objSubDataArr[5] = new clsEmployee(m_objCollection.m_objOperationArr[i1].m_strAssistant2).m_StrFirstName;
                    if (m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeID == null || m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeID == "")
                        m_objSubDataArr[6] = "";
                    else
                        m_objSubDataArr[6] = m_hasAanaesthesiaMode[m_objCollection.m_objOperationArr[i1].m_strAanaesthesiaModeID];
                    m_objSubDataArr[7] = m_objCollection.m_objOperationArr[i1].m_strCutLevel;
                    m_objSubDataArr[8] = new clsEmployee(m_objCollection.m_objOperationArr[i1].m_strAnaesthetist).m_StrFirstName;
                    for (int j2 = 0; j2 < 9; j2++)
                    {
                        if (m_objSubDataArr[j2] == null)
                            m_objSubDataArr[j2] = "";
                    }

                    m_objDataArr[i1] = m_objSubDataArr;
                }
                m_objLine102.m_ObjPrintLineInfo = m_objDataArr;
            }


            if (m_objCollection.m_objBabyArr == null || m_objCollection.m_objBabyArr.Length <= 0)
            {
                m_objLine109.m_ObjPrintLineInfo = null;
            }
            else
            {
                m_objDataArr = new Object[m_objCollection.m_objBabyArr.Length];

                for (int i1 = 0; i1 < m_objCollection.m_objBabyArr.Length; i1++)
                {
                    m_objSubDataArr = new object[18];
                    m_objSubDataArr[0] = m_objCollection.m_objBabyArr[i1].m_strSeqID;
                    if (m_objCollection.m_objBabyArr[i1].m_strMale == "True" || m_objCollection.m_objBabyArr[i1].m_strMale == "1")
                        m_objSubDataArr[1] = "√";
                    else
                        m_objSubDataArr[1] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strFemale == "True" || m_objCollection.m_objBabyArr[i1].m_strFemale == "1")
                        m_objSubDataArr[2] = "√";
                    else
                        m_objSubDataArr[2] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strLiveBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strLiveBorn == "1")
                        m_objSubDataArr[3] = "√";
                    else
                        m_objSubDataArr[3] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strDieBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strDieBorn == "1")
                        m_objSubDataArr[4] = "√";
                    else
                        m_objSubDataArr[4] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strDieNotBorn == "True" || m_objCollection.m_objBabyArr[i1].m_strDieNotBorn == "1")
                        m_objSubDataArr[5] = "√";
                    else
                        m_objSubDataArr[5] = "";
                    m_objSubDataArr[6] = m_objCollection.m_objBabyArr[i1].m_strWeight;
                    if (m_objCollection.m_objBabyArr[i1].m_strDie == "True" || m_objCollection.m_objBabyArr[i1].m_strDie == "1")
                        m_objSubDataArr[7] = "√";
                    else
                        m_objSubDataArr[7] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strChangeDepartment == "True" || m_objCollection.m_objBabyArr[i1].m_strChangeDepartment == "1")
                        m_objSubDataArr[8] = "√";
                    else
                        m_objSubDataArr[8] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strOutHospital == "True" || m_objCollection.m_objBabyArr[i1].m_strOutHospital == "1")
                        m_objSubDataArr[9] = "√";
                    else
                        m_objSubDataArr[9] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strNaturalCondiction == "True" || m_objCollection.m_objBabyArr[i1].m_strNaturalCondiction == "1")
                        m_objSubDataArr[10] = "√";
                    else
                        m_objSubDataArr[10] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strSuffocate1 == "True" || m_objCollection.m_objBabyArr[i1].m_strSuffocate1 == "1")
                        m_objSubDataArr[11] = "√";
                    else
                        m_objSubDataArr[11] = "";
                    if (m_objCollection.m_objBabyArr[i1].m_strSuffocate2 == "True" || m_objCollection.m_objBabyArr[i1].m_strSuffocate1 == "2")
                        m_objSubDataArr[12] = "√";
                    else
                        m_objSubDataArr[12] = "";
                    m_objSubDataArr[13] = m_objCollection.m_objBabyArr[i1].m_strInfectionTimes;
                    m_objSubDataArr[14] = m_objCollection.m_objBabyArr[i1].m_strInfectionName;
                    m_objSubDataArr[15] = m_objCollection.m_objBabyArr[i1].m_strICD10;
                    m_objSubDataArr[16] = m_objCollection.m_objBabyArr[i1].m_strSalveTimes;
                    m_objSubDataArr[17] = m_objCollection.m_objBabyArr[i1].m_strSalveSuccessTimes;
                    m_objDataArr[i1] = m_objSubDataArr;
                }
                m_objLine109.m_ObjPrintLineInfo = m_objDataArr;
            }


            m_objDataArr = new Object[6];
            //			m_objDataArr[0]=gpbRTMode.Tag.ToString();
            //			m_objDataArr[1]=gpbRTRule.Tag.ToString();
            //			m_objDataArr[2]=this.chkRTCo.Checked==true? "√":"";
            //			m_objDataArr[3]=this.chkRTAccelerator.Checked==true?"√":"";
            //			m_objDataArr[4]=this.chkRTX_Ray.Checked==true? "√":"";
            //			m_objDataArr[5]=this.chkRTLacuna.Checked==true? "√":"";
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strRTModeSeq;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strRTRuleSeq;
                if (m_objCollection.m_objContent.m_strRTCo == "True" || m_objCollection.m_objContent.m_strRTCo == "1")
                    m_objDataArr[2] = "√";
                else
                    m_objDataArr[2] = "";
                if (m_objCollection.m_objContent.m_strRTAccelerator == "True" || m_objCollection.m_objContent.m_strRTAccelerator == "1")
                    m_objDataArr[3] = "√";
                else
                    m_objDataArr[3] = "";
                if (m_objCollection.m_objContent.m_strRTX_Ray == "True" || m_objCollection.m_objContent.m_strRTX_Ray == "1")
                    m_objDataArr[4] = "√";
                else
                    m_objDataArr[4] = "";
                if (m_objCollection.m_objContent.m_strRTLacuna == "True" || m_objCollection.m_objContent.m_strRTLacuna == "1")
                    m_objDataArr[5] = "√";
                else
                    m_objDataArr[5] = "";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
            }
            m_objLine111.m_ObjPrintLineInfo = m_objDataArr;
            //112
            m_objDataArr = new Object[5];
            //			m_objDataArr[0]=gpbOriginalDisease.Tag.ToString();
            //			m_objDataArr[1]=txtOriginalDiseaseGy.Text;
            //			m_objDataArr[2]=txtOriginalDiseaseTimes.Text ;
            //			m_objDataArr[3]=txtOriginalDiseaseDays.Text ;
            //			m_objDataArr[4]=dtpOriginalDiseaseBeginDate.Value.ToString("yyyy年MM月dd日")+"至" +dtpOriginalDiseaseEndDate.Value.ToString("yyyy年MM月dd日");
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strOriginalDiseaseSeq;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strOriginalDiseaseGy;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strOriginalDiseaseTimes;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strOriginalDiseaseDays;
                m_objDataArr[4] = DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseBeginDate).ToString("yy   MM   dd  ") + "   " + DateTime.Parse(m_objCollection.m_objContent.m_strOriginalDiseaseEndDate).ToString("yy   MM   dd   ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine112.m_ObjPrintLineInfo = m_objDataArr;

            //113

            m_objDataArr = new Object[5];
            //			m_objDataArr[0]=gpbLymph.Tag.ToString();
            //			m_objDataArr[1]=txtLymphGy.Text;
            //			m_objDataArr[2]=txtLymphTimes.Text ;
            //			m_objDataArr[3]=txtLymphDays.Text ;
            //			m_objDataArr[4]=dtpLymphBeginDate.Value.ToString("yyyy年MM月dd日")+"至" +dtpLymphEndDate.Value.ToString("yyyy年MM月dd日");
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strLymphSeq;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strLymphGy;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strLymphTimes;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strLymphDays;
                m_objDataArr[4] = DateTime.Parse(m_objCollection.m_objContent.m_strLymphBeginDate).ToString("yy   MM   dd  ") + "   " + DateTime.Parse(m_objCollection.m_objContent.m_strLymphEndDate).ToString("yy   MM   dd   ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine113.m_ObjPrintLineInfo = m_objDataArr;

            //114           
            m_objDataArr = new Object[4];
            //			m_objDataArr[0]=txtMetastasisGy.Text ;
            //			m_objDataArr[1]=txtMetastasisTimes.Text;
            //			m_objDataArr[2]=txtMetastasisDays.Text ;
            //			m_objDataArr[3]=dtpMetastasisBeginDate.Value.ToString("yyyy年MM月dd日") + "至" +dtpMetastasisEndDate.Value.ToString("yyyy年MM月dd日");
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strMetastasisGy;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strMetastasisTimes;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strMetastasisDays;
                m_objDataArr[3] = DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisBeginDate).ToString("yy   MM   dd  ") + "   " + DateTime.Parse(m_objCollection.m_objContent.m_strMetastasisEndDate).ToString("yy   MM   dd   ");
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine114.m_ObjPrintLineInfo = m_objDataArr;

            //115
            //m_objDataArr = new Object[5];
            ////			m_objDataArr[0]=gpbChemotherapyMode.Tag.ToString();
            ////			m_objDataArr[1]=chkChemotherapyWholeBody.Checked==true? "√":"";
            ////			m_objDataArr[2]=this.chkChemotherapyLocal.Checked==true?"√":"";
            ////			m_objDataArr[3]=this.chkChemotherapyIntubate.Checked==true? "√":"";
            ////			m_objDataArr[4]=this.chkChemotherapyThorax.Checked==true? "√":"";
            //if (m_bolIfCheck)
            //{
            //    m_objDataArr[0] = m_objCollection.m_objContent.m_strChemotherapyModeSeq;
            //    if (m_objCollection.m_objContent.m_strChemotherapyWholeBody == "True" || m_objCollection.m_objContent.m_strChemotherapyWholeBody == "1")
            //        m_objDataArr[1] = "√";
            //    else
            //        m_objDataArr[1] = "";
            //    if (m_objCollection.m_objContent.m_strChemotherapyLocal == "True" || m_objCollection.m_objContent.m_strChemotherapyLocal == "1")
            //        m_objDataArr[2] = "√";
            //    else
            //        m_objDataArr[2] = "";
            //    if (m_objCollection.m_objContent.m_strChemotherapyIntubate == "True" || m_objCollection.m_objContent.m_strChemotherapyIntubate == "1")
            //        m_objDataArr[3] = "√";
            //    else
            //        m_objDataArr[3] = "";
            //    if (m_objCollection.m_objContent.m_strChemotherapyThorax == "True" || m_objCollection.m_objContent.m_strChemotherapyThorax == "1")
            //        m_objDataArr[4] = "√";
            //    else
            //        m_objDataArr[4] = "";
            //}
            //else
            //{
            //    m_objDataArr[0] = "";
            //    m_objDataArr[1] = "";
            //    m_objDataArr[2] = "";
            //    m_objDataArr[3] = "";
            //    m_objDataArr[4] = "";
            //}
            //m_objLine115.m_ObjPrintLineInfo = m_objDataArr;
            //116
            m_objDataArr = new Object[4];
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strChemotherapyAbdomen == "True" || m_objCollection.m_objContent.m_strChemotherapyAbdomen == "1")
                    m_objDataArr[0] = "√";
                else
                    m_objDataArr[0] = "";
                if (m_objCollection.m_objContent.m_strChemotherapySpinal == "True" || m_objCollection.m_objContent.m_strChemotherapySpinal == "1")
                    m_objDataArr[1] = "√";
                else
                    m_objDataArr[1] = "";
                if (m_objCollection.m_objContent.m_strChemotherapyOtherTry == "True" || m_objCollection.m_objContent.m_strChemotherapyOtherTry == "1")
                    m_objDataArr[2] = "√";
                else
                    m_objDataArr[2] = "";
                if (m_objCollection.m_objContent.m_strChemotherapyOther == "True" || m_objCollection.m_objContent.m_strChemotherapyOther == "1")
                    m_objDataArr[3] = "√";
                else
                    m_objDataArr[3] = "";
                //			m_objDataArr[0]=chkChemotherapyAbdomen.Checked==true? "√":"";
                //			m_objDataArr[1]=chkChemotherapySpinal.Checked==true?"√":"";
                //			m_objDataArr[2]=chkChemotherapyOtherTry.Checked==true? "√":"";
                //			m_objDataArr[3]=chkChemotherapyOther.Checked==true? "√":"";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
            }
            m_objLine116.m_ObjPrintLineInfo = m_objDataArr;
            //118
            if (m_objCollection.m_objChemotherapyArr == null || m_objCollection.m_objChemotherapyArr.Length <= 0)
            {
                m_objLine118.m_ObjPrintLineInfo = null;
            }
            else
            {
                if (m_objCollection.m_objChemotherapyArr.Length > 0)
                {
                    m_objDataArr = new Object[m_objCollection.m_objChemotherapyArr.Length];

                    for (int i1 = 0; i1 < m_objCollection.m_objChemotherapyArr.Length; i1++)
                    {
                        m_objSubDataArr = new object[4];
                        m_objSubDataArr[0] = DateTime.Parse(m_objCollection.m_objChemotherapyArr[i1].m_strChemotherapyDate).ToString("yyyy-MM-dd HH:mm");
                        m_objSubDataArr[1] = m_objCollection.m_objChemotherapyArr[i1].m_strMedicineName;
                        m_objSubDataArr[2] = m_objCollection.m_objChemotherapyArr[i1].m_strPeriod;
                        if (m_objCollection.m_objChemotherapyArr[i1].m_strField_CR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_CR == "1")
                            m_objSubDataArr[3] = "3";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_PR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_PR == "1")
                            m_objSubDataArr[3] = "4";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_MR == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_MR == "1")
                            m_objSubDataArr[3] = "5";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_S == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_S == "1")
                            m_objSubDataArr[3] = "6";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_P == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_P == "1")
                            m_objSubDataArr[3] = "7";
                        else if (m_objCollection.m_objChemotherapyArr[i1].m_strField_NA == "True" || m_objCollection.m_objChemotherapyArr[i1].m_strField_NA == "1")
                            m_objSubDataArr[3] = "8";

                        m_objDataArr[i1] = m_objSubDataArr;
                    }
                    m_objLine118.m_ObjPrintLineInfo = m_objDataArr;
                }
            }

            //119
            m_objDataArr = new Object[6];
            //			m_objDataArr[0]=txtTotalAmt.Text ;
            //			m_objDataArr[1]=txtBedAmt.Text;
            //			m_objDataArr[2]=txtNurseAmt.Text ;
            //			m_objDataArr[3]=txtWMAmt.Text ;
            //			m_objDataArr[4]=txtCMFinishedAmt.Text ;
            //			m_objDataArr[5]=txtCMSemiFinishedAmt.Text ;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strTotalAmt;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strBedAmt;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strNurseAmt;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strWMAmt;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strCMFinishedAmt;
                m_objDataArr[5] = m_objCollection.m_objContent.m_strCMSemiFinishedAmt;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
            }
            m_objLine119.m_ObjPrintLineInfo = m_objDataArr;
            //120 

            m_objDataArr = new Object[7];
            //			m_objDataArr[0]=txtRadiationAmt.Text ;
            //			m_objDataArr[1]=txtAssayAmt.Text;
            //			m_objDataArr[2]=txtO2Amt.Text ;
            //			m_objDataArr[3]=txtBloodAmt.Text ;
            //			m_objDataArr[4]=txtTreatmentAmt.Text ;
            //			m_objDataArr[5]=txtOperationAmt.Text ;
            //			m_objDataArr[6]=txtDeliveryChildAmt.Text ;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strRadiationAmt;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strAssayAmt;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strO2Amt;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strBloodAmt;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strTreatmentAmt;
                m_objDataArr[5] = m_objCollection.m_objContent.m_strOperationAmt;
                m_objDataArr[6] = m_objCollection.m_objContent.m_strDeliveryChildAmt;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
                m_objDataArr[6] = "";
            }
            m_objLine120.m_ObjPrintLineInfo = m_objDataArr;
            //121

            m_objDataArr = new Object[7];
            //			m_objDataArr[0]=txtCheckAmt.Text ;
            //			m_objDataArr[1]=txtAnaethesiaAmt.Text;
            //			m_objDataArr[2]=txtBabyAmt.Text ;
            //			m_objDataArr[3]=txtAccompanyAmt.Text ;
            //			m_objDataArr[4]=txtOtherAmt1.Text ;
            //			m_objDataArr[5]=txtOtherAmt2.Text ;
            //			m_objDataArr[6]=txtOtherAmt3.Text ;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strCheckAmt;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strAnaethesiaAmt;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strBabyAmt;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strAccompanyAmt;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strOtherAmt1;
                m_objDataArr[5] = m_objCollection.m_objContent.m_strOtherAmt2;
                m_objDataArr[6] = m_objCollection.m_objContent.m_strOtherAmt3;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
                m_objDataArr[6] = "";
            }
            m_objLine121.m_ObjPrintLineInfo = m_objDataArr;

            //122

            m_objDataArr = new Object[2];
            //			if(gpbCorpseCheck.Tag == null)
            //				m_objDataArr[0]="";
            //			m_objDataArr[0]=((int)(int.Parse(gpbCorpseCheck.Tag.ToString()) + 1)).ToString();
            //			if(gpbFirstCase.Tag == null)
            //				m_objDataArr[1] = "";
            //			m_objDataArr[1]=((int)(int.Parse(gpbFirstCase.Tag.ToString()) + 1)).ToString();
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strCorpseCheck == "True" || m_objCollection.m_objContent.m_strCorpseCheck == "1")
                    m_objDataArr[0] = "1";
                else
                    m_objDataArr[0] = "2";
                if (m_objCollection.m_objContent.m_strFirstCase == "True" || m_objCollection.m_objContent.m_strFirstCase == "1")
                    m_objDataArr[1] = "1";
                else
                    m_objDataArr[1] = "2";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine122.m_ObjPrintLineInfo = m_objDataArr;

            //123
            m_objDataArr = new Object[3];
            //			m_objDataArr[0]=((int)(int.Parse(gpbFollow.Tag.ToString()) + 1)).ToString();
            //			m_objDataArr[1]=txtFollow_Week.Text.Trim().ToString()+"周"+txtFollow_Month.Text.Trim().ToString()+"月"+txtFollow_Year.Text.Trim().ToString()+"年";
            //			m_objDataArr[2]=((int)(int.Parse(gpbModelCase.Tag.ToString()) + 1)).ToString();
            if (m_bolIfCheck)
            {
                if (m_objCollection.m_objContent.m_strFollow == "True" || m_objCollection.m_objContent.m_strFollow == "1")
                    m_objDataArr[0] = "1";
                else
                    m_objDataArr[0] = "2";
                m_objDataArr[1] = m_objCollection.m_objContent.m_strFollow_Week + "     " + m_objCollection.m_objContent.m_strFollow_Month + "     " + m_objCollection.m_objContent.m_strFollow_Year;
                if (m_objCollection.m_objContent.m_strModelCase == "True" || m_objCollection.m_objContent.m_strFollow == "1")
                    m_objDataArr[2] = "1";
                else
                    m_objDataArr[2] = "2";
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine123.m_ObjPrintLineInfo = m_objDataArr;

            //124
            m_objDataArr = new Object[3];
            //			m_objDataArr[0]=txtBloodType.Text;
            //			m_objDataArr[1]=((int)(int.Parse(gpbBloodRh.Tag.ToString()) + 1)).ToString();
            //			m_objDataArr[2]=((int)(int.Parse(gpbBloodTransAction.Tag.ToString()) + 1)).ToString();
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strBloodType;
                if (m_objCollection.m_objContent.m_strBloodRh == "True" || m_objCollection.m_objContent.m_strBloodRh == "1")
                    m_objDataArr[1] = "1";
                else
                    m_objDataArr[1] = "2";

                //if (m_objCollection.m_objContent.m_strBloodTransActoin == "True" || m_objCollection.m_objContent.m_strBloodTransActoin == "1")
                //    m_objDataArr[2] = "1";
                //else
                //    m_objDataArr[2] = "2";

                m_objDataArr[2] = m_objCollection.m_objContent.m_strBloodTransActoin;

            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
            }
            m_objLine124.m_ObjPrintLineInfo = m_objDataArr;

            //125
            m_objDataArr = new Object[5];
            //			m_objDataArr[0]=txtRBC.Text;
            //			m_objDataArr[1]=txtPLT.Text;
            //			m_objDataArr[2]=txtPlasm.Text;
            //			m_objDataArr[3]=txtWholeBlood.Text;
            //			m_objDataArr[4]=txtOtherBlood.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strRBC;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strPLT;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strPlasm;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strWholeBlood;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strOtherBlood;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
            }
            m_objLine125.m_ObjPrintLineInfo = m_objDataArr;

            //126
            m_objDataArr = new Object[6];
            //			m_objDataArr[0]=txtConsultation.Text;
            //			m_objDataArr[1]=txtLongDistanctConsultation.Text;
            //			m_objDataArr[2]=txtTOPLevel.Text;
            //			m_objDataArr[3]=txtNurseLevelI.Text;
            //			m_objDataArr[4]=txtNurseLevelII.Text;
            //			m_objDataArr[5]=txtNurseLevelIII.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strConsultation;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strLongDistanctConsultation;
                m_objDataArr[2] = m_objCollection.m_objContent.m_strTOPLevel;
                m_objDataArr[3] = m_objCollection.m_objContent.m_strNurseLevelI;
                m_objDataArr[4] = m_objCollection.m_objContent.m_strNurseLevelII;
                m_objDataArr[5] = m_objCollection.m_objContent.m_strNurseLevelIII;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
                m_objDataArr[2] = "";
                m_objDataArr[3] = "";
                m_objDataArr[4] = "";
                m_objDataArr[5] = "";
            }
            m_objLine126.m_ObjPrintLineInfo = m_objDataArr;


            //127
            m_objDataArr = new Object[2];
            //			m_objDataArr[0]=txtICU.Text;
            //			m_objDataArr[1]=txtSpecialNurse.Text;
            if (m_bolIfCheck)
            {
                m_objDataArr[0] = m_objCollection.m_objContent.m_strICU;
                m_objDataArr[1] = m_objCollection.m_objContent.m_strSpecialNurse;
            }
            else
            {
                m_objDataArr[0] = "";
                m_objDataArr[1] = "";
            }
            m_objLine127.m_ObjPrintLineInfo = m_objDataArr;
        }

        private class clsPrintLine1 : clsPrintLineBase
        {

            Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine1()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				GraphicsUnit enmOld = p_objGrp.PageUnit;
                //				p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (m_objPeople == null)
                {
                    //#if PrintTitle

                    //					float fltOld = p_objGrp.PageScale;
                    //					p_objGrp.PageScale = 0.93f;

                    //					Pen pen = new Pen(Color.Black,0.1f);
                    if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("姓名___________性别    1.男 2.女   出生_____年___月____日  年龄___婚姻    1.未  2.已  3.离  4.丧", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 37, p_intPosY, 3, 3);

                        //					p_objGrp.PageScale = fltOld;					
                        //					p_objGrp.PageUnit = GraphicsUnit.Pixel;
                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 132, p_intPosY, 3, 3);
                    }

                    //#endif
                }
                else
                {
                    if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                    {
                        p_objGrp.DrawString("姓名___________性别    1.男 2.女   出生_____年___月____日  年龄___婚姻    1.未  2.已  3.离  4.丧", new Font("SimSun", 10.5f), Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 37, p_intPosY, 3, 3);
                        p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 132, p_intPosY, 3, 3);
                    }

                    p_objGrp.DrawString(m_objPeople.m_StrFirstName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 10, p_intPosY);
                    if (m_objPeople.m_StrSex == "男")
                        p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY);
                    else
                        p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 37, p_intPosY);

                    p_objGrp.DrawString(m_objPeople.m_DtmBirth.Year.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 73, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_DtmBirth.Month.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 87, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_DtmBirth.Day.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 97, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_IntAge.ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 118, p_intPosY);


                    if (m_objPeople.m_StrMarried == "未婚")
                        p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                    else
                        p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 132, p_intPosY);
                }

                p_intPosY += (int)enmRectangleInfo.RowStep;
                //				Top += Step;
                m_blnHaveMoreLine = false;
                //				p_objGrp.PageUnit = enmOld;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }


        private class clsPrintLine2 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            public clsPrintLine2()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("职业___________出生地_______省(市)_____县 民族__________国籍______身份证号______________________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrOccupation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 11, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrNativePlace, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 41, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrNativePlace, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 63, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrNation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 91, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrNationality, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 112, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrIDCard, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY);
                }

                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }


        private class clsPrintLine3 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            public clsPrintLine3()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("工作单位及地址________________________________________电话_____________邮政编码________________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrOfficePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrOfficeAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 29, p_intPosY);


                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objPeople.m_StrOfficeAddress,"",m_dtmFirstPrintTime);
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                //					m_blnFirstPrint = false;
                //				}
                //				m_objText1.m_mthPrintLine(360,(int)enmRectangleInfo.LeftX+130,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("_________________________________________________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+130,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                //				m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }


        private class clsPrintLine4 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            public clsPrintLine4()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("户口地址_____________________________________________________________邮政编码________________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrHomePC, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrHomeAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objPeople.m_StrHomeAddress,"",m_dtmFirstPrintTime);
                }
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;
                //					m_blnFirstPrint = false;
                //				}

                //				m_objText1.m_mthPrintLine(550,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("________________________________________________________________________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+90,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                //				m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }


        private class clsPrintLine5 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private clsPeopleInfo m_objPeople;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            public clsPrintLine5()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{

                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("联系人姓名_______________ 关系________ 地址________________________________电话______________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objPeople != null)
                {
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManFirstName, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrPatientRelation, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 60, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManPhone, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                    p_objGrp.DrawString(m_objPeople.m_StrLinkManAddress, m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 85, p_intPosY);
                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objPeople.m_StrLinkManAddress,"",m_dtmFirstPrintTime);
                }
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                //					m_blnFirstPrint = false;
                //				}

                //				m_objText1.m_mthPrintLine(300,(int)enmRectangleInfo.LeftX+340,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("_________________________________________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+330,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
                p_objGrp.PageUnit = enmOld;

                //
            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                //				m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objPeople = (clsPeopleInfo)value;
                    }
                }
            }
        }


        private class clsPrintLine6 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            public clsPrintLine6()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 11));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入院日期______年____月____日____时 入院科别________________病床_________转科科别______________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 85, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 122, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 153, p_intPosY);
                //					m_blnFirstPrint = false;
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[3].ToString(),"",m_dtmFirstPrintTime);
                //				}

                //				m_objText1.m_mthPrintLine(100,(int)enmRectangleInfo.LeftX+650,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("______________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+650,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                //				}
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine7 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr;
            public clsPrintLine7()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("出院日期______年____月____日____时 出院科别________________病室_________实际住院_____________天", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 85, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 122, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 153, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine8 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine8()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("门(急)诊诊断______________________________门(急)诊医生___________入院时情况:  1.危 2.急 3.一般", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    //					m_blnFirstPrint = false;
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 104, p_intPosY);
                p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 143, p_intPosY, 3, 3);
                if (m_objDataArr[2] != null)
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 143, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 27, p_intPosY);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //				}

                //				m_objText1.m_mthPrintLine(260,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("__________________________________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+100,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                //				}
                p_objGrp.PageUnit = enmOld;


            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine9 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            public clsPrintLine9()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("入院诊断_______________________________________________________入院后确诊日期_____年____月____日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 146, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                //					m_blnFirstPrint = false;
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //				}

                //				m_objText1.m_mthPrintLine(400,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				p_objGrp.DrawString("____________________________________________________",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+100,p_intPosY);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                //					m_intTimes++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
                p_objGrp.PageUnit = enmOld;


            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine10 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine10()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, 37 - 25, (int)enmRectangleInfo.LeftX - 2, 37 + 210);//p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 74, p_intPosY, (int)enmRectangleInfo.LeftX + 74, p_intPosY + 86);//(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 74, p_intPosY + 8, (int)enmRectangleInfo.LeftX + 157, p_intPosY + 8);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 89, p_intPosY + 8, (int)enmRectangleInfo.LeftX + 89, p_intPosY + 86);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 108, p_intPosY + 8, (int)enmRectangleInfo.LeftX + 108, p_intPosY + 86);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 124, p_intPosY + 8, (int)enmRectangleInfo.LeftX + 124, p_intPosY + 86);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 141, p_intPosY + 8, (int)enmRectangleInfo.LeftX + 141, p_intPosY + 86);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX + 157, p_intPosY, (int)enmRectangleInfo.LeftX + 157, p_intPosY + 86);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+72,p_intPosY,(int)enmRectangleInfo.LeftX+72,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("出院情况", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 107, p_intPosY + 2);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+153,p_intPosY,(int)enmRectangleInfo.LeftX+153,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                    p_objGrp.DrawString("出院诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 29, p_intPosY + 6);
                    p_objGrp.DrawString("ICD-10", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 161, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+153,p_intPosY,(int)enmRectangleInfo.LeftX+153,p_intPosY);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+72,p_intPosY,(int)enmRectangleInfo.LeftX+72,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("1治愈", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 76, p_intPosY + 10);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+90,p_intPosY,(int)enmRectangleInfo.LeftX+90,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("2好转", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 93, p_intPosY + 10);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+106,p_intPosY,(int)enmRectangleInfo.LeftX+106,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("3未愈", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+121,p_intPosY,(int)enmRectangleInfo.LeftX+121,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("4死亡", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 125, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+143,p_intPosY,(int)enmRectangleInfo.LeftX+143,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("5其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 142, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+153,p_intPosY,(int)enmRectangleInfo.LeftX+153,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);

                    p_intPosY += 15;
                    for (int i = 1; i <= 6; i++)
                    {
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                        p_intPosY += 13;
                    }
                    p_intPosY -= (78 - 6);

                    for (int i = 1; i <= 5; i++)
                    {
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                        p_intPosY += 13;
                    }

                    for (int i = 1; i <= 9; i++)
                    {
                        p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX - 2, p_intPosY, (int)enmRectangleInfo.RightX, p_intPosY);
                        p_intPosY += 7;
                    }

                    p_intPosY -= 133;
                }
                else
                    p_intPosY += 23;

                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;
            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine11 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine11()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("主要诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                switch (m_objDataArr[1].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 96, p_intPosY);
                        break;
                    case "2":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 113, p_intPosY);
                        break;
                    case "3":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                        break;
                    case "4":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY);
                        break;
                }
                //					p_objGrp.DrawString("A00.01",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+160,p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);

                //					m_objText1.m_mthSetContextWithCorrectBefore("身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知","",m_dtmFirstPrintTime);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //					m_blnFirstPrint = false;
                //
                //				}

                //				m_objText1.m_mthPrintLine(300,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //				}
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                p_objGrp.PageUnit = enmOld;
                //
            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine12 : clsPrintLineBase
        {

            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private int m_intCurrentRecord = 0;
            public clsPrintLine12()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("其他诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);					
                //					m_blnFirstPrint = false;
                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    object[] m_objSubDataArr = (object[])m_objDataArr[0];
                    p_objGrp.DrawString(m_objSubDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                    switch (m_objSubDataArr[1].ToString())
                    {
                        case "0":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                            break;
                        case "1":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 96, p_intPosY);
                            break;
                        case "2":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 113, p_intPosY);
                            break;
                        case "3":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                            break;
                        case "4":
                            p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY);
                            break;
                    }
                    p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY);
                }
                m_intCurrentRecord++;
                //				}

                //				m_objText1.m_mthPrintLine(300,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else if(m_objDataArr != null && m_intCurrentRecord < m_objDataArr.Length)
                //				{
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					object [] m_objSubDataArr = (object [])m_objDataArr[m_intCurrentRecord];
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //
                //					switch(m_objSubDataArr[1].ToString())
                //					{
                //						case "0":
                //							p_objGrp.DrawString("√",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+410,p_intPosY+5);
                //							break;
                //						case "1":
                //							p_objGrp.DrawString("√",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+470,p_intPosY+5);
                //							break;
                //						case "2":
                //							p_objGrp.DrawString("√",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+530,p_intPosY+5);
                //							break;
                //						case "3":
                //							p_objGrp.DrawString("√",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+590,p_intPosY+5);
                //							break;
                //						case "4":
                //							p_objGrp.DrawString("√",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+650,p_intPosY+5);
                //							break;
                //						default:
                //							break;
                //					}
                //					p_objGrp.DrawString(m_objSubDataArr[2].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+710,p_intPosY);
                //	
                //					m_intCurrentRecord++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += 8 * (int)enmRectangleInfo.RowStep + 3;
                p_objGrp.PageUnit = enmOld;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //				}

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #region 13 ~ 21

        private class clsPrintLine13 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine13()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("医院感染名称", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                switch (m_objDataArr[1].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 96, p_intPosY);
                        break;
                    case "2":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 113, p_intPosY);
                        break;
                    case "3":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 130, p_intPosY);
                        break;
                    case "4":
                        p_objGrp.DrawString("√", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 148, p_intPosY);
                        break;
                }
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 160, p_intPosY);

                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //					m_blnFirstPrint = false;
                //
                //				}

                //				m_objText1.m_mthPrintLine(300,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+400,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+460,p_intPosY,(int)enmRectangleInfo.LeftX+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+520,p_intPosY,(int)enmRectangleInfo.LeftX+520,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+700,p_intPosY,(int)enmRectangleInfo.LeftX+700,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                p_objGrp.PageUnit = enmOld;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY)
                //;
                //					p_intPosY -= (int)enmRectangleInfo.SmallRowStep;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine14 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine14()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病理诊断", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                //					m_blnFirstPrint = false;
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 23, p_intPosY);
                //					m_objText1.m_mthSetContextWithCorrectBefore("身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不知身体不","",m_dtmFirstPrintTime);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //				}

                //				m_objText1.m_mthPrintLine(680,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+100,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                p_objGrp.PageUnit = enmOld;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+100,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					p_intPosY -= (int)enmRectangleInfo.SmallRowStep;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine15 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine15()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("损伤、中毒的外部因素:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 38, p_intPosY);
                //					m_blnFirstPrint = false;
                //					m_objText1.m_mthSetContextWithCorrectBefore("身体不知身体不知身体不知身体不知身体不知身体不知身体不知","",m_dtmFirstPrintTime);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //					
                //				}
                //
                //				m_objText1.m_mthPrintLine(610,(int)enmRectangleInfo.LeftX+170,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+170,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                p_objGrp.PageUnit = enmOld;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+170,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					p_intPosY -= (int)enmRectangleInfo.SmallRowStep;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine16 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;

            public clsPrintLine16()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("药物过敏                             HbsAg     HCV-Ab      HIV-Ab       0.未做 1.阴性 2.阳性", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 82, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 106, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 131, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 82, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 106, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 131, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                //					m_objText1.m_mthSetContextWithCorrectBefore("身体不知身体不知身体不知身体不知身体不知身身体不知身身体不知身身体不知身身体不知身身体不知身身体不知身","",m_dtmFirstPrintTime);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objDataArr[0].ToString(),"",m_dtmFirstPrintTime);
                //					m_blnFirstPrint = false;
                //				}

                //				m_objText1.m_mthPrintLine(300,(int)enmRectangleInfo.LeftX+100,p_intPosY,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+100,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY);
                //					m_intTimes++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += (int)enmRectangleInfo.RowStep;
                p_objGrp.PageUnit = enmOld;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+100,p_intPosY,(int)enmRectangleInfo.LeftX+400,p_intPosY);
                //					p_intPosY -= (int)enmRectangleInfo.SmallRowStep;
                //					p_intPosY += (int)enmRectangleInfo.RowStep;
                //				}
            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine17 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine17()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("诊断符合情况   门诊与出院         入院与出院         术前与术后        临床与病理", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);


                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 49, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 84, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 119, p_intPosY, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 154, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 49, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 84, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 119, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 154, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep1;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine18 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine18()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;

                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("               放射与病理     0.未做 1.符合 2.不符合 3.不肯定     抢救______次   成功_______次", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);

                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 49, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 49, (float)p_intPosY);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 135, (float)p_intPosY);
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (float)enmRectangleInfo.LeftX + 165, (float)p_intPosY);

                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine19 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine19()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("科主任               主(副主)任医师               主治医师            住院医师", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objDataArr[0] != null)
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 15, p_intPosY);
                if (m_objDataArr[1] != null)
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                if (m_objDataArr[2] != null)
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                if (m_objDataArr[3] != null)
                    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine20 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine20()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("进修医师             研究生实习医师               实习医师            编码员", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                }

                if (m_objDataArr[0] != null)
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 18, p_intPosY);
                if (m_objDataArr[1] != null)
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 70, p_intPosY);
                if (m_objDataArr[2] != null)
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                if (m_objDataArr[3] != null)
                    p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 150, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;

            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine21 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private object[] m_objDataArr = null;
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);

            public clsPrintLine21()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                GraphicsUnit enmOld = p_objGrp.PageUnit;
                p_objGrp.PageUnit = GraphicsUnit.Millimeter;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("病案质量     1.甲  2.乙  3.丙   质控医师          质控护士          日期:_____年____月____日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX, p_intPosY);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX + 20, p_intPosY, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 20, p_intPosY);
                if (m_objDataArr[1] != null)
                    p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 80, p_intPosY);
                if (m_objDataArr[2] != null)
                    p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 110, p_intPosY);
                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX + 140, p_intPosY);
                p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
                p_objGrp.PageUnit = enmOld;



            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }



        #endregion

        #region 100 ^102
        private class clsPrintLine100 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine100()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.RightX1, p_intPosY);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 104, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 104, p_intPosY + 41);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY + 41);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+11);

                    p_objGrp.DrawString("手术、操作", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1, p_intPosY + 2);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 22, p_intPosY, (int)enmRectangleInfo.LeftX1 + 22, p_intPosY + 41);
                    p_objGrp.DrawString("手术、操作", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 27, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 47, p_intPosY, (int)enmRectangleInfo.LeftX1 + 47, p_intPosY + 41);
                    p_objGrp.DrawString("手术、操作名称", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 58, p_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 91, p_intPosY, (int)enmRectangleInfo.LeftX1 + 91, p_intPosY + 41);
                    p_objGrp.DrawString("手术、操作医师", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 99, p_intPosY + 1);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY + 41);
                    p_objGrp.DrawString("麻醉", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 134, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 145, p_intPosY, (int)enmRectangleInfo.LeftX1 + 145, p_intPosY + 41);
                    p_objGrp.DrawString("切口愈", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 148, p_intPosY + 2);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 162, p_intPosY, (int)enmRectangleInfo.LeftX1 + 162, p_intPosY + 41);
                    p_objGrp.DrawString("麻醉医师", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 4);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.RightX1, p_intPosY - 8, (int)enmRectangleInfo.RightX1, p_intPosY + 234);
                }
                //				p_intPosY += 5;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }


        private class clsPrintLine101 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine101()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 11, (int)enmRectangleInfo.RightX1, p_intPosY + 11);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("编码", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 7, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+80,p_intPosY,(int)enmRectangleInfo.LeftX1+80,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("日期", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 30, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+205,p_intPosY,(int)enmRectangleInfo.LeftX1+205,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_objGrp.DrawString("名称",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+260,p_intPosY+5);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 91, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY + 5);

                    p_objGrp.DrawString("术者", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 94, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+445,p_intPosY,(int)enmRectangleInfo.LeftX1+445,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("I 助", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 107, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+510,p_intPosY,(int)enmRectangleInfo.LeftX1+510,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("II 助", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+580,p_intPosY,(int)enmRectangleInfo.LeftX1+580,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("方式", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 134, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+640,p_intPosY,(int)enmRectangleInfo.LeftX1+640,p_intPosY+(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawString("合等级", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 148, p_intPosY + 7);
                    ////				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+710,p_intPosY,(int)enmRectangleInfo.LeftX1+710,p_intPosY+(int)enmRectangleInfo.RowStep);
                    //				p_objGrp.DrawString("医师",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+728,p_intPosY+5);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                }
                p_intPosY += 11;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }



        private class clsPrintLine102 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private clsPrintRichTextContext m_objText2;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private int m_intCurrentrecord = 0;
            private object[] m_objDataArr = null;

            public clsPrintLine102()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
                m_objText2 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				if(m_blnFirstPrint)
                //				{
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.RightX1, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 6, (int)enmRectangleInfo.RightX1, p_intPosY + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 12, (int)enmRectangleInfo.RightX1, p_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 18, (int)enmRectangleInfo.RightX1, p_intPosY + 18);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 24, (int)enmRectangleInfo.RightX1, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 30, (int)enmRectangleInfo.RightX1, p_intPosY + 30);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY - 5, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY - 5);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 205, p_intPosY - 5, (int)enmRectangleInfo.LeftX1 + 205, p_intPosY - 5);

                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+80,p_intPosY,(int)enmRectangleInfo.LeftX1+80,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+205,p_intPosY,(int)enmRectangleInfo.LeftX1+205,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+445,p_intPosY,(int)enmRectangleInfo.LeftX1+445,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    // 					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+510,p_intPosY,(int)enmRectangleInfo.LeftX1+510,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+580,p_intPosY,(int)enmRectangleInfo.LeftX1+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+640,p_intPosY,(int)enmRectangleInfo.LeftX1+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+710,p_intPosY,(int)enmRectangleInfo.LeftX1+710,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    //					m_blnFirstPrint = false;
                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    object[] m_objSubDataArr = (object[])m_objDataArr[0];
                    p_objGrp.DrawString(m_objSubDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 10, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 22, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 92, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 106, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 154, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 165, p_intPosY + 1);

                    p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 50, p_intPosY + 1);
                    p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY + 1);
                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[2].ToString(),"",m_dtmFirstPrintTime);
                    //						m_objText2.m_mthSetContextWithCorrectBefore(m_objSubDataArr[6].ToString(),"",m_dtmFirstPrintTime);
                    m_intCurrentrecord++;

                }
                //				}

                //				m_objText1.m_mthPrintLine(175,(int)enmRectangleInfo.LeftX+203,p_intPosY+5,p_objGrp);
                //				m_objText2.m_mthPrintLine(55,(int)enmRectangleInfo.LeftX+583,p_intPosY+5,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine()||m_objText2.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+80,p_intPosY,(int)enmRectangleInfo.LeftX+80,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+205,p_intPosY,(int)enmRectangleInfo.LeftX+205,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+380,p_intPosY,(int)enmRectangleInfo.LeftX+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+445,p_intPosY,(int)enmRectangleInfo.LeftX+445,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //           
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+510,p_intPosY,(int)enmRectangleInfo.LeftX+510,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+710,p_intPosY,(int)enmRectangleInfo.LeftX+710,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else if(m_objDataArr != null && m_intCurrentrecord < m_objDataArr.Length)
                //				{
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.LeftX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+80,p_intPosY,(int)enmRectangleInfo.LeftX+80,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+205,p_intPosY,(int)enmRectangleInfo.LeftX+205,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+380,p_intPosY,(int)enmRectangleInfo.LeftX+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+445,p_intPosY,(int)enmRectangleInfo.LeftX+445,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //           
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+510,p_intPosY,(int)enmRectangleInfo.LeftX+510,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+580,p_intPosY,(int)enmRectangleInfo.LeftX+580,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+640,p_intPosY,(int)enmRectangleInfo.LeftX+640,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX+710,p_intPosY,(int)enmRectangleInfo.LeftX+710,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					object [] m_objSubDataArr = (object [])m_objDataArr[m_intCurrentrecord];
                //					p_objGrp.DrawString(m_objSubDataArr[0].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+3,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[1].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+80,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[3].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+383,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[4].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+448,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[5].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+513,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[7].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+650,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[8].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX+720,p_intPosY+5);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[2].ToString(),"",m_dtmFirstPrintTime);
                //					m_objText2.m_mthSetContextWithCorrectBefore(m_objSubDataArr[6].ToString(),"",m_dtmFirstPrintTime);
                //					m_intCurrentrecord++;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //				}
            }

            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
                m_objText2.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #endregion



        private class clsPrintLine103 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine103()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("产科分娩婴儿记录表:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 32);
                }

                p_intPosY += 36;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }


        #region 104 ~ 109
        private class clsPrintLine104 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine104()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.RightX1, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 8, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 47, p_intPosY + 5);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 58, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 105, p_intPosY + 5);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 22, (int)enmRectangleInfo.RightX1, p_intPosY + 22);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 28, (int)enmRectangleInfo.RightX1, p_intPosY + 28);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 34, (int)enmRectangleInfo.RightX1, p_intPosY + 34);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 40, (int)enmRectangleInfo.RightX1, p_intPosY + 40);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 46, (int)enmRectangleInfo.RightX1, p_intPosY + 46);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.LeftX1, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 8, p_intPosY, (int)enmRectangleInfo.LeftX1 + 8, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 23, p_intPosY, (int)enmRectangleInfo.LeftX1 + 23, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 47, p_intPosY, (int)enmRectangleInfo.LeftX1 + 47, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 58, p_intPosY, (int)enmRectangleInfo.LeftX1 + 58, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 82, p_intPosY, (int)enmRectangleInfo.LeftX1 + 82, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 106, p_intPosY, (int)enmRectangleInfo.LeftX1 + 106, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY, (int)enmRectangleInfo.LeftX1 + 117, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 151, p_intPosY, (int)enmRectangleInfo.LeftX1 + 151, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 165, p_intPosY, (int)enmRectangleInfo.LeftX1 + 165, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 173, p_intPosY, (int)enmRectangleInfo.LeftX1 + 173, p_intPosY + 46);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 15, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 15, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 23, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 23, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 31, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 31, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 39, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 39, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 66, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 66, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 74, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 74, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 90, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 90, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 98, p_intPosY + 5, (int)enmRectangleInfo.LeftX1 + 98, p_intPosY + 46);
                    p_objGrp.DrawString("婴", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 3);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("性别", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 12, p_intPosY + 1);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("分娩结果", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 27, p_intPosY + 1);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("婴儿", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 49, p_intPosY + 2);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("婴儿转归", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 63, p_intPosY + 1);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("呼吸", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 90, p_intPosY + 1);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("抢", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 2);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;		
                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }

        private class clsPrintLine105 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine105()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("儿", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("男", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 9, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("女", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 17, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY);

                    p_objGrp.DrawString("活", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 25, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 33, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 40, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY);

                    p_objGrp.DrawString("体重", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 49, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("死", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("转", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 68, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("出", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 76, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY);

                    p_objGrp.DrawString("自", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 84, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("I", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 93, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("II", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 100, p_intPosY + 6);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY);

                    p_objGrp.DrawString("医院", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 107, p_intPosY + 3);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);


                    p_objGrp.DrawString("主要医院感染名称", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 8);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("ICD-10", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 152, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("救", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 7);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("抢救", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 174, p_intPosY + 3);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }

        private class clsPrintLine106 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine106()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("序", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 12);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.RowStep);


                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.RowStep);


                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.RowStep);


                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("度", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 92, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("度", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 100, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.RowStep);


                    p_objGrp.DrawString("感染", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 107, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);


                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("次", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 12);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("成功", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 174, p_intPosY + 10);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }

        private class clsPrintLine107 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine107()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("号", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 18);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("性", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 9, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("性", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 17, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("产", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 25, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("产", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 33, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("胎", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 40, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("（g）", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 48, p_intPosY + 16);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("亡", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("科", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 68, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("院", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 76, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("然", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 84, p_intPosY + 15);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("窒", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 92, p_intPosY + 14);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("窒", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 100, p_intPosY + 14);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("次数", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 107, p_intPosY + 16);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);


                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("数", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 17);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("次数", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 174, p_intPosY + 17);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }

        private class clsPrintLine108 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine108()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.RowStep);

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("息", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 92, p_intPosY + 18);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("息", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 100, p_intPosY + 18);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                }

                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }

        private class clsPrintLine109 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private int m_intCurrentRecord = 0;
            private object[] m_objDataArr = null;
            public clsPrintLine109()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				if(m_blnFirstPrint)
                //				{
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                p_objGrp.DrawString("1", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 23);
                p_objGrp.DrawString("2", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 29);
                p_objGrp.DrawString("3", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 35);
                p_objGrp.DrawString("4", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 41);
                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    object[] m_objSubDataArr = (object[])m_objDataArr[0];
                    //						p_objGrp.DrawString(m_objSubDataArr[0].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+3,p_intPosY+24);

                    p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 9, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 17, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 25, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 33, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 40, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 49, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[7].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[8].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 68, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[9].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 76, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[10].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 84, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[11].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 93, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[12].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 100, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[13].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 108, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[14].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[15].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 152, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[16].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 24);
                    p_objGrp.DrawString(m_objSubDataArr[17].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 174, p_intPosY + 24);

                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[14].ToString(),"",m_dtmFirstPrintTime);
                    m_intCurrentRecord++;
                }
                m_blnHaveMoreLine = false;
                //					m_blnFirstPrint = false;
                //				}

                //				m_objText1.m_mthPrintLine(167,(int)enmRectangleInfo.LeftX1+463,p_intPosY+5,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else if(m_objDataArr != null && m_intCurrentRecord < m_objDataArr.Length)
                //				{
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+30,p_intPosY,(int)enmRectangleInfo.LeftX1+30,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+60,p_intPosY,(int)enmRectangleInfo.LeftX1+60,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+90,p_intPosY,(int)enmRectangleInfo.LeftX1+90,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+120,p_intPosY,(int)enmRectangleInfo.LeftX1+120,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+180,p_intPosY,(int)enmRectangleInfo.LeftX1+180,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+230,p_intPosY,(int)enmRectangleInfo.LeftX1+230,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+260,p_intPosY,(int)enmRectangleInfo.LeftX1+260,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+290,p_intPosY,(int)enmRectangleInfo.LeftX1+290,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+320,p_intPosY,(int)enmRectangleInfo.LeftX1+320,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+350,p_intPosY,(int)enmRectangleInfo.LeftX1+350,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+380,p_intPosY,(int)enmRectangleInfo.LeftX1+380,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+410,p_intPosY,(int)enmRectangleInfo.LeftX1+410,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+627,p_intPosY,(int)enmRectangleInfo.LeftX1+627,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+697,p_intPosY,(int)enmRectangleInfo.LeftX1+697,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+727,p_intPosY,(int)enmRectangleInfo.LeftX1+727,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					object [] m_objSubDataArr = (object [])m_objDataArr[m_intCurrentRecord];
                //					p_objGrp.DrawString(m_objSubDataArr[0].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+3,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[1].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+33,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[2].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+63,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[3].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+93,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[4].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+123,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[5].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+153,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[6].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+183,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[7].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+233,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[8].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+263,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[9].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+293,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[10].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+323,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[11].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+353,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[12].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+383,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[13].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+413,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[15].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+630,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[16].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+700,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[17].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+735,p_intPosY+5);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[14].ToString(),"",m_dtmFirstPrintTime);
                //					m_blnHaveMoreLine = true;
                //					m_intCurrentRecord++;
                //				}
                //				else
                //				{
                //					m_blnHaveMoreLine = false;
                //					p_intPosY += (int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX,p_intPosY,(int)enmRectangleInfo.RightX,p_intPosY);
                //				}
            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();

            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }



        #endregion

        private class clsPrintLine110 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine110()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("肿瘤专科病人治疗记录表:", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 50);
                }

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                p_intPosY += 55;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                    }
                }
            }
        }


        private class clsPrintLine111 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine111()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.RightX1, p_intPosY);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 6, (int)enmRectangleInfo.RightX1, p_intPosY + 6);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 12, (int)enmRectangleInfo.RightX1, p_intPosY + 12);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 18, (int)enmRectangleInfo.RightX1, p_intPosY + 18);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 24, (int)enmRectangleInfo.RightX1, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 36, (int)enmRectangleInfo.RightX1, p_intPosY + 36);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 46, (int)enmRectangleInfo.RightX1, p_intPosY + 46);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 52, (int)enmRectangleInfo.RightX1, p_intPosY + 52);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 58, (int)enmRectangleInfo.RightX1, p_intPosY + 58);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 64, (int)enmRectangleInfo.RightX1, p_intPosY + 64);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 66, (int)enmRectangleInfo.RightX1, p_intPosY + 66);

                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY, (int)enmRectangleInfo.LeftX1, p_intPosY + 66);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 22, p_intPosY + 36, (int)enmRectangleInfo.LeftX1 + 22, p_intPosY + 64);//(int)enmRectangleInfo.RowStep);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY + 36, (int)enmRectangleInfo.LeftX1 + 130, p_intPosY + 64);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1 + 140, p_intPosY + 36, (int)enmRectangleInfo.LeftX1 + 140, p_intPosY + 64);

                    p_objGrp.DrawString("I. 放疗:方式: 根治性、姑息性、辅助性   程式: 连续、间断、分段  装置: 钴、直加、X线、后装", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 2);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                }

                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 35, p_intPosY);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 50, p_intPosY);
                        break;
                    case "2":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 65, p_intPosY);
                        break;
                    default:
                        break;
                }
                switch (m_objDataArr[1].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 93, p_intPosY);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 104, p_intPosY);
                        break;
                    case "2":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 115, p_intPosY);
                        break;
                    default:
                        break;
                }
                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 139, p_intPosY + 1);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 148, p_intPosY + 1);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 159, p_intPosY + 1);

                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 170, p_intPosY + 1);


                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }


        private class clsPrintLine112 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine112()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("1. 原发灶（首次、复次） 剂量:   Gy/    次/     天:起止日期:20   年   月   至20   年   月   日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 7);
                }
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 24, p_intPosY + 6);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 31, p_intPosY + 6);
                        break;
                    default:
                        break;
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 74, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 88, p_intPosY + 7);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 125, p_intPosY + 7);
                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine113 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine113()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {



                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("2.区域淋巴结（首次、复次）剂量: Gy/    次/     天:起止日期:20   年   月   至20   年   月   日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 13);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                }

                switch (m_objDataArr[0].ToString())
                {
                    case "0":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 32, p_intPosY + 12);
                        break;
                    case "1":
                        p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 43, p_intPosY + 12);
                        break;
                    default:
                        break;
                }
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 74, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 88, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 125, p_intPosY + 13);

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine114 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine114()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {


                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("3.         转移灶剂量:          Gy/    次/     天:起止日期:20   年   月   至20   年   月   日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 19);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 74, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 88, p_intPosY + 19);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 125, p_intPosY + 19);

                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                //
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        //private class clsPrintLine115 : clsPrintLineBase
        //{
        //    private Font m_fotPrintFont = new Font("SimSun", 9);
        //    private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
        //    private Pen m_pen = new Pen(Brushes.Black, 0.1f);
        //    private object[] m_objDataArr = null;
        //    public clsPrintLine115()
        //    {
        //    }

        //    public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
        //    {

        //        //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
        //        //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
        //        if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
        //        {
        //            p_objGrp.DrawString("II.化疗:方式:根治性、姑息性、新辅助性、辅助性、新药  化疗方法:全化、半化、A插管、胸腔注、腹腔注、髓注、其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 26);
        //            //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);
        //        }

        //        switch (m_objDataArr[0].ToString())
        //        {
        //            case "0":
        //                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 28, p_intPosY + 25);
        //                break;
        //            case "1":
        //                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 41, p_intPosY + 25);
        //                break;
        //            case "2":
        //                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 56, p_intPosY + 25);
        //                break;
        //            case "3":
        //                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 70, p_intPosY + 25);
        //                break;
        //            case "4":
        //                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 81, p_intPosY + 25);
        //                break;
        //            default:
        //                break;
        //        }
        //        p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 108, p_intPosY + 26);

        //        p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 118, p_intPosY + 26);

        //        p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 129, p_intPosY + 26);

        //        p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 140, p_intPosY + 26);


        //        //				p_intPosY +=(int)enmRectangleInfo.RowStep;
        //        m_blnHaveMoreLine = false;

        //    }


        //    public override void m_mthReset()
        //    {
        //        m_blnHaveMoreLine = true;
        //    }
        //    public override object m_ObjPrintLineInfo
        //    {
        //        get
        //        {
        //            return m_objPrintLineInfo;
        //        }
        //        set
        //        {
        //            if (value != null)
        //            {
        //                m_objDataArr = (object[])value;
        //            }
        //        }
        //    }
        //}

        private class clsPrintLine116 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 9);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine116()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("         试用、其他", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 31);
                }

                //		p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 157, p_intPosY + 26);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 167, p_intPosY + 26);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 178, p_intPosY + 26);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 28, p_intPosY + 31);
                //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }
            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #region 117 ~ 118
        private class clsPrintLine117 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            public clsPrintLine117()
            {
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.RowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("日期", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 7, p_intPosY + 40);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("药物名称（剂量）", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 62, p_intPosY + 40);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("疗程", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 131, p_intPosY + 40);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+500,p_intPosY,(int)enmRectangleInfo.LeftX1+500,p_intPosY+(int)enmRectangleInfo.RowStep);

                    p_objGrp.DrawString("疗效（消失、显效、好转、", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 142, p_intPosY + 37);
                    p_objGrp.DrawString("不变、恶化、未定）", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 142, p_intPosY + 41);
                    //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.RowStep);

                    //				p_intPosY +=(int)enmRectangleInfo.RowStep;
                }
                m_blnHaveMoreLine = false;

            }


            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {

                    }
                }
            }
        }

        private class clsPrintLine118 : clsPrintLineBase
        {
            private clsPrintRichTextContext m_objText1;
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Font m_fotCheckFont = new Font("SimSun", 16, FontStyle.Bold);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            //			private bool m_blnFirstPrint = true;
            //			private int m_intTimes = 0;
            private object[] m_objDataArr = null;
            private int m_intCurrentRecord = 0;
            public clsPrintLine118()
            {
                m_objText1 = new clsPrintRichTextContext(Color.Black, new Font("SimSun", 10.5f));
            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                //				if(m_blnFirstPrint)
                //				{

                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);

                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+500,p_intPosY,(int)enmRectangleInfo.LeftX1+500,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("1.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1, p_intPosY + 47);
                    p_objGrp.DrawString("2.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1, p_intPosY + 53);
                    p_objGrp.DrawString("3.", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1, p_intPosY + 59);

                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 143, p_intPosY + 47);
                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 143, p_intPosY + 53);
                    p_objGrp.DrawString("CR、PR、MR、S、P、NA", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 143, p_intPosY + 59);
                }

                if (m_objDataArr != null && m_objDataArr.Length > 0)
                {
                    object[] m_objSubDataArr = (object[])m_objDataArr[0];
                    p_objGrp.DrawString(m_objSubDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 3, p_intPosY + 47);
                    p_objGrp.DrawString(m_objSubDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 60, p_intPosY + 47);
                    p_objGrp.DrawString(m_objSubDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 133, p_intPosY + 47);
                    //						p_objGrp.DrawString("CR、PR、MR、S、P、NA",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+143,p_intPosY+47);

                    if (m_objSubDataArr[3] != null)
                        switch (m_objSubDataArr[3].ToString())
                        {
                            case "3":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 141, p_intPosY + 47);
                                break;
                            case "4":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 150, p_intPosY + 47);
                                break;
                            case "5":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 158, p_intPosY + 47);
                                break;
                            case "6":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 166, p_intPosY + 47);
                                break;
                            case "7":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 172, p_intPosY + 47);
                                break;
                            case "8":
                                p_objGrp.DrawString("√", m_fotCheckFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 178, p_intPosY + 47);
                                break;
                            default:
                                break;
                        }
                    //						p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                    m_intCurrentRecord++;
                    //						m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[1].ToString(),"",m_dtmFirstPrintTime);
                }
                //					m_blnFirstPrint = false;


                //				}
                //
                //				m_objText1.m_mthPrintLine(310,(int)enmRectangleInfo.LeftX1+153,p_intPosY+5,p_objGrp);
                //				if(m_objText1.m_BlnHaveNextLine())
                //				{
                //					m_blnHaveMoreLine = true;
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+500,p_intPosY,(int)enmRectangleInfo.LeftX1+500,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //				
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_intTimes++;
                //				}
                //				else if(m_objDataArr != null && m_intCurrentRecord < m_objDataArr.Length)
                //				{
                //					p_intPosY +=(int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.LeftX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+150,p_intPosY,(int)enmRectangleInfo.LeftX1+150,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+460,p_intPosY,(int)enmRectangleInfo.LeftX1+460,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1+500,p_intPosY,(int)enmRectangleInfo.LeftX1+500,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //
                //					object [] m_objSubDataArr = (object [])m_objDataArr[m_intCurrentRecord];
                //					p_objGrp.DrawString(m_objSubDataArr[0].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+3,p_intPosY+5);
                //					p_objGrp.DrawString(m_objSubDataArr[2].ToString(),m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+463,p_intPosY+5);
                //					p_objGrp.DrawString(" CR、 PR、 MR、 S、 P、 NA",m_fotPrintFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+503,p_intPosY+5);
                //					
                //					if(m_objSubDataArr[3]!=null)
                //					switch(m_objSubDataArr[3].ToString())
                //					{
                //						case "3":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+520,p_intPosY+5);
                //							break;
                //						case "4":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+550,p_intPosY+5);
                //							break;
                //						case "5":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+590,p_intPosY+5);
                //							break;
                //						case "6":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+620,p_intPosY+5);
                //							break;
                //						case "7":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+650,p_intPosY+5);
                //							break;
                //						case "8":
                //							p_objGrp.DrawString("√",m_fotCheckFont,Brushes.Black,(int)enmRectangleInfo.LeftX1+680,p_intPosY+5);
                //							break;
                //						default:
                //							break;
                //					}
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.RightX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY+(int)enmRectangleInfo.SmallRowStep);
                //					m_objText1.m_mthSetContextWithCorrectBefore(m_objSubDataArr[1].ToString(),"",m_dtmFirstPrintTime);
                //					m_intCurrentRecord++;
                //					m_blnHaveMoreLine =true;
                //				}
                //				else
                //				{
                m_blnHaveMoreLine = false;
                p_intPosY += 65;
                //					p_intPosY += (int)enmRectangleInfo.SmallRowStep;
                //					p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);
                //				
                //				}

            }


            public override void m_mthReset()
            {
                //				m_intTimes = 0;
                m_blnHaveMoreLine = true;
                //				m_blnFirstPrint = true;
                m_objText1.m_mthRestartPrint();
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        #endregion

        private class clsPrintLine119 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine119()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("住院费用总计（元）:          床费       护理费        西药        中成药         中草药", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 40, p_intPosY + 3);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 68, p_intPosY + 3);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 93, p_intPosY + 3);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 118, p_intPosY + 3);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 145, p_intPosY + 3);

                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 174, p_intPosY + 3);

                //				p_intPosY += (int)enmRectangleInfo.RowStep;


                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine120 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine120()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("放射__________化验__________输氧__________输血__________诊疗__________手术__________接生_________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 8);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 13, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 39, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 65, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 92, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 145, p_intPosY + 8);

                p_objGrp.DrawString(m_objDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 170, p_intPosY + 8);

                //				p_intPosY += (int)enmRectangleInfo.RowStep;


                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine121 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine121()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("检查__________麻醉__________婴儿费________陪床费________其他__________、 __________、 __________", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 2, p_intPosY + 13);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 13, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 39, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 70, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 95, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 119, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 145, p_intPosY + 13);

                p_objGrp.DrawString(m_objDataArr[6].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 168, p_intPosY + 13);

                //				p_intPosY += (int)enmRectangleInfo.RowStep;


                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine122 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine122()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("尸检      1.是 2.否              手术、治疗、检查、诊断为本院第一例        1.是 2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 5, p_intPosY + 19);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 19, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 134, p_intPosY + 19, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 19);
                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 134, p_intPosY + 19);


                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 24, (int)enmRectangleInfo.RightX1, p_intPosY + 24);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 30, (int)enmRectangleInfo.RightX1, p_intPosY + 30);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 36, (int)enmRectangleInfo.RightX1, p_intPosY + 36);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 42, (int)enmRectangleInfo.RightX1, p_intPosY + 42);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 48, (int)enmRectangleInfo.RightX1, p_intPosY + 48);
                    p_objGrp.DrawLine(m_pen, (int)enmRectangleInfo.LeftX1, p_intPosY + 54, (int)enmRectangleInfo.RightX1, p_intPosY + 54);
                }

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine123 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine123()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("随诊      1.是 2.否          随诊期限        周    月    年        示教病例          1.是 2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 5, p_intPosY + 25);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 25, 3, 3);
                    p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 25);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 153, p_intPosY + 25, 3, 3);
                }

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 85, p_intPosY + 25);
                //				string m_strYear = DateTime.Parse(m_objDataArr[1]).Year;

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 153, p_intPosY + 25);


                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine124 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine124()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("血型   1.A  2.B 3.AB 4.O 5.其他               Rh     1.阴  2.阳    输血反应         1.是 2.否", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 5, p_intPosY + 31);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 31, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 153, p_intPosY + 31, 3, 3);
                    p_objGrp.DrawRectangle(m_pen, (int)enmRectangleInfo.LeftX1 + 99, p_intPosY + 31, 3, 3);
                }
                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 16, p_intPosY + 31);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 99, p_intPosY + 31);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 153, p_intPosY + 31);


                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine125 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;

            public clsPrintLine125()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("输血品种 1.红细胞      单位  2.血小板     袋   3.血浆        ml 4.全血       ml 5.其他    ml", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 5, p_intPosY + 37);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 41, p_intPosY + 37);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 79, p_intPosY + 37);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 112, p_intPosY + 37);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 144, p_intPosY + 37);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 172, p_intPosY + 37);



                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine126 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine126()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString(" 院际会诊    次    远程会诊     次  护理等级 1.特级    小时  2.I级    日 3.II级   日 4.III级  日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1, p_intPosY + 43);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 20, p_intPosY + 43);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 54, p_intPosY + 43);

                p_objGrp.DrawString(m_objDataArr[2].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 99, p_intPosY + 43);

                p_objGrp.DrawString(m_objDataArr[3].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 127, p_intPosY + 43);

                p_objGrp.DrawString(m_objDataArr[4].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 152, p_intPosY + 43);

                p_objGrp.DrawString(m_objDataArr[5].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 176, p_intPosY + 43);



                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine127 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            private Pen m_pen = new Pen(Brushes.Black, 0.1f);
            private object[] m_objDataArr = null;
            public clsPrintLine127()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("5. 重症监护      小时   6. 特殊护理     日", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 1, p_intPosY + 49);
                }

                p_objGrp.DrawString(m_objDataArr[0].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 26, p_intPosY + 49);

                p_objGrp.DrawString(m_objDataArr[1].ToString(), m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 71, p_intPosY + 49);


                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                //				p_objGrp.DrawLine(m_pen,(int)enmRectangleInfo.LeftX1,p_intPosY,(int)enmRectangleInfo.RightX1,p_intPosY);

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {
                        m_objDataArr = (object[])value;
                    }
                }
            }
        }

        private class clsPrintLine128 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            public clsPrintLine128()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("说明: 医疗付款方式 1、社会基本保险（补充保险、特大病保险）2、商业保险 3、自费保险 4、公费医疗 5、 ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 1, p_intPosY + 55);
                }

                //				p_intPosY += (int)enmRectangleInfo.RowStep;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {

                    }
                }
            }
        }

        private class clsPrintLine129 : clsPrintLineBase
        {
            private Font m_fotPrintFont = new Font("SimSun", 10.5f);
            public clsPrintLine129()
            {

            }

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (frmInHospitalMainRecord_XJ.s_blnPrintTitle)
                {
                    p_objGrp.DrawString("大病统筹 6、其他   住院费用总计   凡可有计算机提供住院费用清单的，住院首页中可不填 ", m_fotPrintFont, Brushes.Black, (int)enmRectangleInfo.LeftX1 + 13, p_intPosY + 61);
                }

                //				p_intPosY += (int)enmRectangleInfo.RowStep;

                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
            public override object m_ObjPrintLineInfo
            {
                get
                {
                    return m_objPrintLineInfo;
                }
                set
                {
                    if (value != null)
                    {

                    }
                }
            }
        }

        #endregion

        #region ctlRichTextBox的双划线、其他属性设置
        /// <summary>
        /// 设置双划线
        /// </summary>
        protected void m_mthSetRichTextBoxDoubleStrike()
        {
            //获取RichTextBox        
            //ctlRichTextBox objRichTextBox = (ctlRichTextBox)m_m_cmuRichTextBoxMenu.SourceControl;

            //objRichTextBox.m_mthSelectionDoubleStrikeThough(true);
            if (m_txtFocusedRichTextBox != null)
                m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);
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
            p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
            p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
            p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
            p_objRichTextBox.m_ClrDST = Color.Red;
            //p_objRichTextBox.m_BlnCanModifyLast = true;
        }

        protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
        {
            if (p_ctlControl.GetType().Name == "ctlRichTextBox")
            {
                m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
            }

            if (p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextBoxAttribInControl(subcontrol);
                }
            }
        }
        private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
        {
            m_mthSetRichTextBoxDoubleStrike();
        }
        private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox = null;//存放当前获得焦点的RichTextBox
        private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            m_txtFocusedRichTextBox = ((com.digitalwave.controls.ctlRichTextBox)(sender));
        }

        /// <summary>
        /// 设置窗体中控件输入文本的颜色
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_clrColor"></param>
        private void m_mthSetRichTextModifyColor(Control p_ctlControl, System.Drawing.Color p_clrColor)
        {
            #region 设置控件输入文本的颜色,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextModifyColor(subcontrol, p_clrColor);
                }
            }
            #endregion
        }


        private void m_mthSetRichTextCanModifyLast(Control p_ctlControl, bool p_blnCanModifyLast)
        {
            #region 设置控件输入文本的是否最后修改,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
            }

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextCanModifyLast(subcontrol, p_blnCanModifyLast);
                }
            }
            #endregion
        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(string p_strCreateUserID,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_blnReset || m_blnGetCanModifyLast(p_strCreateUserID))
            {
                m_mthSetRichTextModifyColor(this, clsHRPColor.s_ClrInputFore);
                m_mthSetRichTextCanModifyLast(this, true);
            }
            else if (p_strCreateUserID != null)
            {
                m_mthSetRichTextModifyColor(this, Color.Red);
                m_mthSetRichTextCanModifyLast(this, m_blnGetCanModifyLast(p_strCreateUserID));
            }
        }

        private bool m_blnGetCanModifyLast(string p_strCreateUserID)
        {
            if (p_strCreateUserID != null && p_strCreateUserID.Trim() == MDIParent.OperatorID.Trim())
                return true;
            else
                return false;
        }
        #endregion ctlRichTextBox的双划线、其他属性设置


        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            m_strOpenDate = p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss");
            m_mthSetPatientCurrentInHospitalDeptInfo();

            //如果选中的是根节点，不显示删除记录。只有选中哪个入院日期才会显示。
            if (m_ObjCurrentEmrPatientSession == null || m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择入院日期！");
                return;
            }
            m_mthDiaplayDeletedDetail(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_strOpenDate);
        }

        #region 审核
        private string m_strCurrentOpenDate = "";

        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (m_ObjCurrentEmrPatientSession == null || m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate == DateTime.MinValue)
                {
                    clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                    return "";
                }
                if (m_objCollection == null || m_objCollection.m_objMain == null)
                {
                    return "";
                }
                return m_objCollection.m_objMain.m_strOpenDate;
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

        //private DataGridCell m_PreOtherDiagnosisCell = new DataGridCell(-1,-1);
        //private void dtgOtherDiagnosis_CurrentCellChanged(object sender, System.EventArgs e)
        //{
        //    if(m_PreOtherDiagnosisCell.ColumnNumber >= 1 && m_PreOtherDiagnosisCell.ColumnNumber <= 5 && m_PreOtherDiagnosisCell.RowNumber < m_dtbOtherDiagnosis.Rows.Count)
        //    {
        //        object [] objValue = m_dtbOtherDiagnosis.Rows[m_PreOtherDiagnosisCell.RowNumber].ItemArray;

        //        bool blnValue = (bool)objValue[m_PreOtherDiagnosisCell.ColumnNumber];

        //        if(blnValue == true)
        //        {
        //            for(int i=1;i<=5;i++)
        //            {
        //                if(i != m_PreOtherDiagnosisCell.ColumnNumber)
        //                    objValue[i] = false;
        //            }

        //            m_dtbOtherDiagnosis.Rows[m_PreOtherDiagnosisCell.RowNumber].ItemArray = objValue;
        //        }
        //    }

        //    m_PreOtherDiagnosisCell = dtgOtherDiagnosis.CurrentCell;
        //}

        /// <summary>
        /// 直接套打
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdFillPrint_Click(object sender, System.EventArgs e)
        {
            objPrintTool = new clsInHospitalMainRecord_XJPrintTool(false);
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);

            objPrintTool.m_mthInitPrintContent();

            m_pdcPrintDocument.Print();
        }

        #region Jump Control
        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this, Keys.Enter);
        }
        #endregion

        #region 出生地
        private void m_cboProvince_evtAddItem(object sender, System.EventArgs e)
        {
            if (m_cboProvince.Text.Trim() == "")
                return;
            string strDistrict = m_cboProvince.Text;
            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngAddDistrict(strDistrict, "0", "1");
            }
            m_mthGetDistrict("0", ref m_cboProvince);
        }

        private void m_cboProvince_evtDelItem(object sender, System.EventArgs e)
        {
            return;
        }

        private void m_cboProvince_evtModifyItem(object sender, System.EventArgs e)
        {
            if (m_cboProvince.Text.Trim() == "")
                return;
            string strDistrict = m_cboProvince.Text;
            string strDisID = ((clsDistrict)m_cboProvince.SelectedItem).m_strDisID;
            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngModifyDistrict(strDistrict, strDisID);
            }
        }

        private void m_cboCity_evtAddItem(object sender, System.EventArgs e)
        {
            if (m_cboProvince.Text.Trim() == "" || m_cboProvince.SelectedItem == null)
            {
                MDIParent.ShowInformationMessageBox("请先选择一个省份！");
                return;
            }
            string strDistrict = m_cboCity.Text;
            string strParentID = ((clsDistrict)m_cboProvince.SelectedItem).m_strDisID;

            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngAddDistrict(strDistrict, strParentID, "2");
            }
            m_mthGetDistrict(((clsDistrict)m_cboProvince.SelectedItem).m_strDisID, ref m_cboCity);
        }

        private void m_cboCity_evtDelItem(object sender, System.EventArgs e)
        {
            return;
        }

        private void m_cboCity_evtModifyItem(object sender, System.EventArgs e)
        {
            if (m_cboProvince.Text.Trim() == "" || m_cboProvince.SelectedItem == null)
            {
                MDIParent.ShowInformationMessageBox("请先选择一个省份！");
                return;
            }
            string strDistrict = m_cboCity.Text;
            string strDisID = ((clsDistrict)m_cboCity.SelectedItem).m_strDisID;

            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngModifyDistrict(strDistrict, strDisID);
            }
        }

        private void m_cboCounty_evtAddItem(object sender, System.EventArgs e)
        {
            if (m_cboCity.Text.Trim() == "" || m_cboCity.SelectedItem == null)
            {
                MDIParent.ShowInformationMessageBox("请先选择一个市！");
                return;
            }
            string strDistrict = m_cboCounty.Text;
            string strParentID = ((clsDistrict)m_cboCity.SelectedItem).m_strDisID;

            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngAddDistrict(strDistrict, strParentID, "3");
            }
            m_mthGetDistrict(((clsDistrict)m_cboCity.SelectedItem).m_strDisID, ref m_cboCounty);
        }

        private void m_cboCounty_evtDelItem(object sender, System.EventArgs e)
        {
            return;
        }

        private void m_cboCounty_evtModifyItem(object sender, System.EventArgs e)
        {
            if (m_cboCity.Text.Trim() == "" || m_cboCity.SelectedItem == null)
            {
                MDIParent.ShowInformationMessageBox("请先选择一个市！");
                return;
            }
            string strDistrict = m_cboCounty.Text;
            string strDisID = ((clsDistrict)m_cboCounty.SelectedItem).m_strDisID;

            if (strDistrict.Trim() != "")
            {
                m_objDomain.m_lngModifyDistrict(strDistrict, strDisID);
            }
        }

        /// <summary>
        /// 获取出生地名
        /// </summary>
        /// <param name="strParentID">父类ID</param>
        private void m_mthGetDistrict(string strParentID, ref ctlComboBox m_ctlComBox)
        {
            DataTable dtResult = new DataTable();
            long lngRes = m_objDomain.m_lngGetDistrict(strParentID, ref dtResult);
            m_ctlComBox.ClearItem();
            m_ctlComBox.Text = "";
            m_ctlComBox.SelectedIndex = -1;

            if (lngRes > 0 && dtResult.Rows.Count > 0)
            {
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    clsDistrict objDis = new clsDistrict();
                    objDis.m_strDisID = dtResult.Rows[i]["ID_INT"].ToString();
                    objDis.m_strDistrict = dtResult.Rows[i]["NAME_CHR"].ToString();

                    m_ctlComBox.AddItem(objDis);
                }
            }
        }

        private void m_cboProvince_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_mthGetDistrict(((clsDistrict)m_cboProvince.SelectedItem).m_strDisID, ref m_cboCity);
            if (m_cboCity.GetItemsCount() > 0)
                m_cboCity.SelectedIndex = 0;
        }

        private void m_cboCity_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_mthGetDistrict(((clsDistrict)m_cboCity.SelectedItem).m_strDisID, ref m_cboCounty);
            if (m_cboCounty.GetItemsCount() > 0)
                m_cboCounty.SelectedIndex = 0;
        }

        private void m_cboProvince_DropDown(object sender, System.EventArgs e)
        {
            m_mthGetDistrict("0", ref m_cboProvince);
        }

        private void m_cboCity_evtTextChanged(object sender, System.EventArgs e)
        {
            if (m_cboCity.Text.Trim() == "")
            {
                m_cboCounty.ClearItem();
                m_cboCounty.Text = "";
            }
        }


        private void m_cboCity_DropDown(object sender, System.EventArgs e)
        {
            string strParentID = "";
            if (m_cboProvince.SelectedItem == null)
            {
                return;
            }
            long res = m_objDomain.m_lngGetIDByName(m_cboProvince.Text, "1", "0", out strParentID);
            if (res > 0)
                m_mthGetDistrict(strParentID, ref m_cboCity);
        }

        private void m_cboCounty_DropDown(object sender, System.EventArgs e)
        {
            string strParentID = "";
            if (m_cboCity.SelectedItem == null || m_cboProvince.SelectedItem == null)
            {
                return;
            }

            long res = m_objDomain.m_lngGetIDByName(m_cboCity.Text, "2", ((clsDistrict)m_cboProvince.SelectedItem).m_strDisID, out strParentID);
            if (res > 0)
                m_mthGetDistrict(strParentID, ref m_cboCounty);
        }


        private void m_cboProvince_evtTextChanged(object sender, System.EventArgs e)
        {
            if (m_cboProvince.Text.Trim() == "")
            {
                m_cboCity.ClearItem();
                m_cboCity.Text = "";
            }
        }
        #endregion

        protected override void m_mthAssociateComboBoxItemEvent(Control p_ctlParent)
        {
        }

        protected override void m_mthAfterSuccessfulSave()
        {
            m_mthSavePatientInfo();
        }

        #region 保存病人基本信息
        /// <summary>
        /// 保存病人基本信息
        /// </summary>
        private void m_mthSavePatientInfo()
        {
            if (m_objBaseCurrentPatient == null)
            {
                return;
            }

            clsPeopleInfo objPeopleInfo = new clsPeopleInfo();
            //objPeopleInfo.m_StrMarried = m_txtMarried.Text.Trim();
            //objPeopleInfo.m_DtmBirth = m_dtpBirthDate.Value.Date;
            //objPeopleInfo.m_StrNationality = m_txtNationality.Text.Trim();
            //objPeopleInfo.m_StrNativePlace = m_txtCountry.Text.Trim();
            //objPeopleInfo.m_StrOccupation = m_txtOccupation.Text.Trim();
            //objPeopleInfo.m_StrNation = m_txtNation.Text.Trim();
            //objPeopleInfo.m_StrHomePhone = m_txtHomePhone.Text.Trim();
            //objPeopleInfo.m_StrIDCard = m_txtIDCard.Text.Trim();
            //objPeopleInfo.m_StrOffice_name = m_txtCompanyName.Text.Trim();
            //objPeopleInfo.m_StrOfficeAddress = m_txtOfficeAddress.Text.Trim();
            //objPeopleInfo.m_StrOfficePC = m_txtOfficePC.Text.Trim();
            //objPeopleInfo.m_StrHomeAddress = m_txtHomeAddress.Text.Trim();
            //objPeopleInfo.m_StrHomePC = m_txtHomePC.Text.Trim();
            //objPeopleInfo.m_StrLinkManLastName = m_txtContactMan.Text.Trim();
            //objPeopleInfo.m_StrPatientRelation = m_txtRelation.Text.Trim();
            //objPeopleInfo.m_StrLinkManAddress = m_txtContactManAddress.Text.Trim();
            //objPeopleInfo.m_StrLinkManPC = m_txtLinkManzipcode.Text.Trim();
            //objPeopleInfo.m_StrLinkManPhone = m_txtContactManPhone.Text.Trim();
            //objPeopleInfo.m_StrBirthPlace = m_cboProvince.Text + m_cboCity.Text + m_cboCounty.Text;

            try
            {
                long lngRes = m_objDomain.m_lngSavePatientInfo(MDIParent.m_objCurrentPatient.m_strPATIENTID_CHR, MDIParent.m_objCurrentPatient.m_strREGISTERID_CHR, objPeopleInfo);
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }
        #endregion

        #region 查询ICD10
        private void m_lsvICD_10_DoubleClick(object sender, System.EventArgs e)
        {
            m_mthSetContentToMainForm(sender);
        }

        private void m_lsvICD_10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthSetContentToMainForm(sender);
            }
        }

        private void m_mthSetContentToMainForm(object sender)
        {
            try
            {
                ListView lsvCon = (ListView)sender;
                if (lsvCon.SelectedItems != null)
                {
                    if (arrlText.Count > 0)
                    {
                        ((Control)(arrlText[0])).Text = lsvCon.SelectedItems[0].SubItems[1].Text;
                        ((Control)(arrlText[1])).Text = lsvCon.SelectedItems[0].SubItems[0].Text;
                    }
                    else if (arrlDg.Count > 0)
                    {
                        int intRow = int.Parse(arrlDg[1].ToString());
                        if (arrlDg[0].ToString() == "dgDiagnosis1")
                        {
                            if (intRow < m_dtbInHospitalDiagnosis.Rows.Count)
                            {
                                m_dtbInHospitalDiagnosis.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbInHospitalDiagnosis.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbInHospitalDiagnosis.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbInHospitalDiagnosis.Rows.Add(drTemp);
                            }
                        }
                        else if (arrlDg[0].ToString() == "dgDiagnosiszhongyi")
                        {
                            if (intRow < m_dtbInHospitalDiagnosisZhong.Rows.Count)
                            {
                                m_dtbInHospitalDiagnosisZhong.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbInHospitalDiagnosisZhong.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbInHospitalDiagnosisZhong.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbInHospitalDiagnosisZhong.Rows.Add(drTemp);
                            }
                        }
                        else if (arrlDg[0].ToString() == "dgDiagnosis2")
                        {
                            if (intRow < m_dtbInfectionDiagnosis.Rows.Count)
                            {
                                m_dtbInfectionDiagnosis.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbInfectionDiagnosis.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbInfectionDiagnosis.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbInfectionDiagnosis.Rows.Add(drTemp);
                            }
                        }
                        else if (arrlDg[0].ToString() == "dgDiagnosis2zhong")
                        {
                            if (intRow < m_dtbInfectionDiagnosis.Rows.Count)
                            {
                                m_dtbInfectionDiagnosisZhong.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbInfectionDiagnosisZhong.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbInfectionDiagnosisZhong.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbInfectionDiagnosisZhong.Rows.Add(drTemp);
                            }
                        }
                        else if (arrlDg[0].ToString() == "dgDiagnosis3")
                        {
                            if (intRow < m_dtbOtherDiagnosis.Rows.Count)
                            {
                                m_dtbOtherDiagnosis.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbOtherDiagnosis.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbOtherDiagnosis.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbOtherDiagnosis.Rows.Add(drTemp);
                            }
                        }
                        else if (arrlDg[0].ToString() == "dgDiagnosis3zhongyi")
                        {
                            if (intRow < m_dtbOtherDiagnosisz.Rows.Count)
                            {
                                m_dtbOtherDiagnosisz.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                m_dtbOtherDiagnosisz.Rows[intRow][1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                DataRow drTemp = m_dtbOtherDiagnosisz.NewRow();
                                drTemp[0] = lsvCon.SelectedItems[0].SubItems[1].Text;
                                drTemp[1] = lsvCon.SelectedItems[0].SubItems[0].Text;
                                m_dtbOtherDiagnosisz.Rows.Add(drTemp);
                            }
                        }
                    }
                }
                frmQuery.Close();
            }
            catch
            {
                frmQuery.Close();
            }
        }

        private frmQueryListview frmQuery = null;

        ArrayList arrlText = null;
        ArrayList arrlDg = null;
        /// <summary>
        /// 查询字典
        /// </summary>
        /// <param name="sender">当前控件</param>
        private void m_mthQueryDictDate(object sender)
        {
            arrlText = new ArrayList();
            arrlDg = new ArrayList();

            if (sender == null)
                return;

            if (sender == m_dgtbInDia.TextBox || sender == m_dgtbInDiaICD.TextBox)
            {
                arrlDg.Add("dgDiagnosis1");
                arrlDg.Add(dgDiagnosis1.CurrentRowIndex);
              //  m_mthShowICDQueryForm();
            }
            else if (sender == m_dgtbInDiaz.TextBox || sender == m_dgtbInDiaICDz.TextBox)
            {
                arrlDg.Add("dgDiagnosiszhongyi");
                arrlDg.Add(dgDiagnosiszhongyi.CurrentRowIndex);
              //  m_mthShowICDQueryForm();
            }
            else if (sender == txtMainDiagnosis || sender == txtICD_10OfMain)
            {
                arrlText.Add(txtMainDiagnosis);
                arrlText.Add(txtICD_10OfMain);
                m_mthShowICDQueryForm();
            }
            else if (sender == txtMainDiagnosiszhongyi || sender == txtICD_10OfMainzhongyi)
            {
                arrlText.Add(txtMainDiagnosiszhongyi);
                arrlText.Add(txtICD_10OfMainzhongyi);
                m_mthShowICDQueryForm();
            }
            else if (sender == m_dgtbInfectionDia.TextBox || sender == m_dgtbInfectionDiaICD.TextBox)
            {
                arrlDg.Add("dgDiagnosis2");
                arrlDg.Add(dgDiagnosis2.CurrentRowIndex);
                m_mthShowICDQueryForm();
            }
            else if (sender == m_dgtbInfectionDiaz.TextBox || sender == m_dgtbInfectionDiaICDz.TextBox)
            {
                arrlDg.Add("dgDiagnosis2zhong");
                arrlDg.Add(dgDiagnosis2zhong.CurrentRowIndex);
                m_mthShowICDQueryForm();
            }
            else if (sender == m_dgtbOtherDia.TextBox || sender == m_dgtbOtherDiaICD.TextBox)
            {
                arrlDg.Add("dgDiagnosis3");
                arrlDg.Add(dgDiagnosis3.CurrentRowIndex);
                m_mthShowICDQueryForm();
            }
            else if (sender == m_dgtbOtherDiaz.TextBox || sender == m_dgtbOtherDiaICDz.TextBox)
            {
                arrlDg.Add("dgDiagnosis3zhongyi");
                arrlDg.Add(dgDiagnosis3zhongyi.CurrentRowIndex);
                m_mthShowICDQueryForm();
            }
            else if (sender == txtDiagnosis || sender == txtDiagnosisICD10)
            {
                arrlText.Add(txtDiagnosis);
                arrlText.Add(txtDiagnosisICD10);
                m_mthShowICDQueryForm();
            }
            else if (sender == m_dtcOperationID.TextBox || sender == m_dtcOperationName.TextBox)
            {
                arrlDg.Add("dtgOperation");
                arrlDg.Add(dtgOperation.CurrentRowIndex);
                m_mthShowOpQueryForm();
            }
            else if (sender == m_dtcOperator.TextBox || sender == m_dtcAssistant1.TextBox
                || sender == m_dtcAssistant2.TextBox || sender == m_dtcAnaesthetist.TextBox)
            {
                arrlDg.Add("dtgOperation");
                arrlDg.Add(dtgOperation.CurrentRowIndex);
                m_mthShowEmp((TextBox)sender);
            }
            else if (sender == m_dtcAnaesthesiaMode.TextBox)
            {
                arrlDg.Add("dtgOperation");
                arrlDg.Add(dtgOperation.CurrentRowIndex);
                m_mthShowAnaesthesiaMode();
            }
        }

        frmQueryListview frmQueryAna = null;
        private void m_mthShowAnaesthesiaMode()
        {
            if (frmQueryAna == null || frmQueryAna.IsDisposed)
            {
                frmQueryAna = new frmQueryListview();

                m_mthSetAnaListviewColumns();
                frmQueryAna.m_txtInput.TextChanged += new EventHandler(txtAnaInput_TextChanged);
                frmQueryAna.m_lsvDetail.DoubleClick += new EventHandler(m_lsvAna_DoubleClick);
                frmQueryAna.m_lsvDetail.KeyDown += new KeyEventHandler(m_lsvAna_KeyDown);
                frmQueryAna.m_txtInput.KeyDown += new KeyEventHandler(m_txtInput_KeyDown);
                frmQueryAna.m_cmdLast.Click += new EventHandler(m_cmdAnaLast_Click);
                frmQueryAna.m_cmdNext.Click += new EventHandler(m_cmdAnaNext_Click);
                frmQueryAna.m_lklCustom.Visible = true;
                frmQueryAna.m_lklCustom.Text = "刷新";
                frmQueryAna.m_lklCustom.Click += new EventHandler(m_lklAnaCustom_Click);
            }

            frmQueryAna.StartPosition = FormStartPosition.CenterScreen;
            frmQueryAna.Show();

            m_mthGetAnaData();

            if (m_dtbAna != null)
                m_dtvAna = new DataView(m_dtbAna);

            frmQueryAna.m_cmdLast.Enabled = false;
            frmQueryAna.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmQueryAna, m_dtvAna, 0);
        }

        private void m_mthShowICDQueryForm()
        {
            if (frmQuery == null || frmQuery.IsDisposed)
            {
                frmQuery = new frmQueryListview();

                m_mthSetListviewColumns();
                frmQuery.m_txtInput.TextChanged += new EventHandler(txtInput_TextChanged);
                frmQuery.m_lsvDetail.DoubleClick += new EventHandler(m_lsvICD_10_DoubleClick);
                frmQuery.m_lsvDetail.KeyDown += new KeyEventHandler(m_lsvICD_10_KeyDown);
                frmQuery.m_txtInput.KeyDown += new KeyEventHandler(m_txtInput_KeyDown);
                frmQuery.m_cmdLast.Click += new EventHandler(m_cmdICDLast_Click);
                frmQuery.m_cmdNext.Click += new EventHandler(m_cmdICDNext_Click);
                frmQuery.m_lklCustom.Visible = true;
                frmQuery.m_lklCustom.Text = "刷新";
                frmQuery.m_lklCustom.Click += new EventHandler(m_lklCustom_Click);
            }

            frmQuery.StartPosition = FormStartPosition.CenterScreen;
            frmQuery.Show();

            m_mthGetICDData();

            if (m_dtbICD != null)
                m_dtvICD = new DataView(m_dtbICD);

            frmQuery.m_cmdLast.Enabled = false;
            frmQuery.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmQuery, m_dtvICD, 0);
        }

        private void m_lklCustom_Click(object sender, EventArgs e)
        {
            m_mthGetDataFromDataBase("ICD_GD.xml", "ICD_GD");

            m_dtvICD = new DataView(m_dtbICD);
            frmQuery.m_cmdLast.Enabled = false;
            frmQuery.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmQuery, m_dtvICD, 0);
        }

        private void m_cmdICDNext_Click(object sender, EventArgs e)
        {
            if (m_dtvICD == null || m_dtvICD.Count == 0)
                return;
            int intIndex = 0;
            if (frmQuery.m_intCurrentIndex + 9 > m_dtvICD.Count - 1)
            {
                frmQuery.m_cmdLast.Enabled = false;
                intIndex = 0;
            }
            else
            {
                frmQuery.m_cmdLast.Enabled = true;
                intIndex = frmQuery.m_intCurrentIndex + 9;
            }

            m_mthUpdateQueryListView(frmQuery, m_dtvICD, intIndex);
        }

        private void m_cmdICDLast_Click(object sender, EventArgs e)
        {
            if (m_dtvICD == null || m_dtvICD.Count == 0)
                return;
            int intIndex = 0;
            if (frmQuery.m_intCurrentIndex - 9 < 0)
            {
                intIndex = 0;
                frmQuery.m_cmdNext.Enabled = true;
            }
            else
            {
                intIndex = frmQuery.m_intCurrentIndex - 9;
                frmQuery.m_cmdNext.Enabled = true;
            }

            m_mthUpdateQueryListView(frmQuery, m_dtvICD, intIndex);
        }

        private void m_mthUpdateQueryListView(frmQueryListview p_frmQuery, DataView p_dtvData, int intIndex)
        {
            try
            {
                p_frmQuery.m_lsvDetail.Items.Clear();
                if (p_dtvData == null || p_dtvData.Count == 0)
                    return;
                int intEnd = intIndex + 9;
                if (intIndex == 0)
                {
                    p_frmQuery.m_cmdLast.Enabled = false;
                    p_frmQuery.m_cmdNext.Enabled = true;
                }
                if (intIndex + 9 > p_dtvData.Count)
                {
                    intEnd = p_dtvData.Count;
                    p_frmQuery.m_cmdNext.Enabled = false;
                }
                p_frmQuery.m_lsvDetail.BeginUpdate();
                ListViewItem[] livItems = new ListViewItem[intEnd - intIndex];
                for (int i = 0; i < intEnd - intIndex; i++)
                {
                    livItems[i] = new ListViewItem(new string[] { p_dtvData[intIndex + i][0].ToString(),
                    p_dtvData[intIndex + i][1].ToString()});
                }
                p_frmQuery.m_lsvDetail.Items.AddRange(livItems);
                p_frmQuery.m_intCurrentIndex = intIndex;
            }
            finally
            {
                p_frmQuery.m_lsvDetail.EndUpdate();
            }
        }

        /// <summary>
        /// 输入框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInput_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string strFilter = ((TextBox)sender).Text.Trim();
                strFilter = strFilter.ToUpper();
                m_dtvICD.RowFilter = " code like '" + strFilter + "%' or name like '%" + strFilter + "%'";

                m_mthUpdateQueryListView(frmQuery, m_dtvICD, 0);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
        }

        /// <summary>
        /// 输入框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAnaInput_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string strFilter = ((TextBox)sender).Text.Trim();
                strFilter = strFilter.ToUpper();
                m_dtvAna.RowFilter = " code like '" + strFilter + "%' or name like '%" + strFilter + "%'";

                m_mthUpdateQueryListView(frmQueryAna, m_dtvAna, 0);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
        }

        /// <summary>
        /// 设置frmQueryListview中Listview的列
        /// </summary>
        /// <param name="p_lsvICD"></param>
        private void m_mthSetAnaListviewColumns()
        {
            System.Windows.Forms.ColumnHeader columnHeader1 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader2 = new ColumnHeader();
            frmQueryAna.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							columnHeader1,
																							columnHeader2});
            columnHeader1.Text = "编码";
            columnHeader1.Width = 100;

            columnHeader2.Text = "麻醉方式";
            columnHeader2.Width = 380;
        }

        /// <summary>
        /// 设置frmQueryListview中Listview的列
        /// </summary>
        /// <param name="p_lsvICD"></param>
        private void m_mthSetListviewColumns()
        {
            System.Windows.Forms.ColumnHeader columnHeader1 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader2 = new ColumnHeader();
            frmQuery.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							columnHeader1,
																							columnHeader2});
            columnHeader1.Text = "ICD码";
            columnHeader1.Width = 100;

            columnHeader2.Text = "诊断名称";
            columnHeader2.Width = 380;
        }

        private void QueryControls_Enter(object sender, System.EventArgs e)
        {
            //m_lblQueryTips.Visible = true;
            m_timShowTips.Enabled = true;
        }

        private void QueryControls_Leave(object sender, System.EventArgs e)
        {
            //m_lblQueryTips.Visible = false;
            m_timShowTips.Enabled = false;
        }

        private void m_txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                frmQueryListview frmCurrentQuery = ((Control)sender).FindForm() as frmQueryListview;
                if (frmCurrentQuery.m_lsvDetail.Items.Count > 0)
                {
                    frmCurrentQuery.m_lsvDetail.Focus();
                    frmCurrentQuery.m_lsvDetail.Items[0].Selected = true;
                }
            }
        }
        #endregion

        #region 手术
        /// <summary>
        /// 设置frmQueryListview中Listview的列
        /// </summary>
        private void m_mthSetOpListviewColumns()
        {
            System.Windows.Forms.ColumnHeader columnHeader1 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader2 = new ColumnHeader();
            frmOpQuery.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							columnHeader1,
																							columnHeader2});
            columnHeader1.Text = "手术码";
            columnHeader1.Width = 100;

            columnHeader2.Text = "手术名称";
            columnHeader2.Width = 380;
        }

        private frmQueryListview frmOpQuery = null;
        private void m_mthShowOpQueryForm()
        {
            if (frmOpQuery == null || frmOpQuery.IsDisposed)
            {
                frmOpQuery = new frmQueryListview();
                m_mthSetOpListviewColumns();
                frmOpQuery.m_txtInput.TextChanged += new EventHandler(txtInputOp_TextChanged);
                frmOpQuery.m_lsvDetail.DoubleClick += new EventHandler(m_lsvOp_DoubleClick);
                frmOpQuery.m_lsvDetail.KeyDown += new KeyEventHandler(m_lsvOp_KeyDown);
                frmOpQuery.m_txtInput.KeyDown += new KeyEventHandler(m_txtInput_KeyDown);
                frmOpQuery.m_cmdLast.Click += new EventHandler(m_cmdOpLast_Click);
                frmOpQuery.m_cmdNext.Click += new EventHandler(m_cmdOpNext_Click);
                frmOpQuery.m_lklCustom.Visible = true;
                frmOpQuery.m_lklCustom.Text = "刷新";
                frmOpQuery.m_lklCustom.Click += new EventHandler(m_lklCustomOp_Click);
            }

            frmOpQuery.StartPosition = FormStartPosition.CenterScreen;
            frmOpQuery.Show();

            m_mthGetOpData();

            if (m_dtbOp != null)
                m_dtvOp = new DataView(m_dtbOp);

            frmOpQuery.m_cmdLast.Enabled = false;
            frmOpQuery.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmOpQuery, m_dtvOp, 0);
        }

        private void m_lklCustomOp_Click(object sender, EventArgs e)
        {
            m_mthGetDataFromDataBase("Operation_GD.xml", "Operation_GD");

            m_dtvOp = new DataView(m_dtbOp);
            frmOpQuery.m_cmdLast.Enabled = false;
            frmOpQuery.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmOpQuery, m_dtvOp, 0);
        }

        private void m_lsvOp_DoubleClick(object sender, System.EventArgs e)
        {
            m_mthSetOpContentToMainForm(sender);
        }

        private void m_lsvOp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthSetOpContentToMainForm(sender);
            }
        }

        private void m_mthSetOpContentToMainForm(object sender)
        {
            try
            {
                ListView lsvCon = (ListView)sender;
                if (lsvCon.SelectedItems != null)
                {
                    int intRow = dtgOperation.CurrentRowIndex;
                    if (intRow <= m_dtbOperationDetail.Rows.Count)
                    {
                        dtgOperation.BindingContext[dtgOperation.DataSource, dtgOperation.DataMember].EndCurrentEdit();
                        m_dtbOperationDetail.Rows[intRow][0] = lsvCon.SelectedItems[0].SubItems[0].Text;
                        m_dtbOperationDetail.Rows[intRow][2] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    }
                    else
                    {

                        DataRow drTemp = m_dtbOperationDetail.NewRow();
                        drTemp[0] = lsvCon.SelectedItems[0].SubItems[0].Text;
                        drTemp[2] = lsvCon.SelectedItems[0].SubItems[1].Text;
                        m_dtbOperationDetail.Rows.Add(drTemp);
                    }
                }
                frmOpQuery.Close();
            }
            catch
            {
                frmOpQuery.Close();
            }
        }

        private void m_cmdOpNext_Click(object sender, EventArgs e)
        {
            if (m_dtvOp == null || m_dtvOp.Count == 0)
                return;
            int intIndex = 0;
            if (frmOpQuery.m_intCurrentIndex + 9 > m_dtvOp.Count - 1)
            {
                frmOpQuery.m_cmdLast.Enabled = false;
                intIndex = 0;
            }
            else
            {
                frmOpQuery.m_cmdLast.Enabled = true;
                intIndex = frmOpQuery.m_intCurrentIndex + 9;
            }

            m_mthUpdateQueryListView(frmOpQuery, m_dtvOp, intIndex);
        }

        private void m_cmdOpLast_Click(object sender, EventArgs e)
        {
            if (m_dtvOp == null || m_dtvOp.Count == 0)
                return;
            int intIndex = 0;
            if (frmOpQuery.m_intCurrentIndex - 9 < 0)
            {
                intIndex = 0;
                frmOpQuery.m_cmdNext.Enabled = true;
            }
            else
            {
                intIndex = frmOpQuery.m_intCurrentIndex - 9;
                frmOpQuery.m_cmdNext.Enabled = true;
            }

            m_mthUpdateQueryListView(frmOpQuery, m_dtvOp, intIndex);
        }

        /// <summary>
        /// 输入框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputOp_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string strFilter = ((TextBox)sender).Text.Trim();
                strFilter = strFilter.ToUpper();
                m_dtvOp.RowFilter = " code like '" + strFilter + "%' or name like '%" + strFilter + "%'";

                m_mthUpdateQueryListView(frmOpQuery, m_dtvOp, 0);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
        }

        #region 手术记录日期事件
        private void OperationDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strText = ((DataGridTextBox)sender).Text;
                DateTime dt = DateTime.Parse(strText);
                int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
                int m_intCurrentRowNumber = this.dtgOperation.CurrentCell.RowNumber;
                if (m_intCurrentRowNumber >= m_dtbOperationDetail.Rows.Count)
                {
                    object[] m_objResArr = new object[14];
                    m_objResArr[1] = strText;
                    m_dtbOperationDetail.Rows.Add(m_objResArr);
                }
            }
            catch
            {
                return;
            }
        }
        #endregion
        #endregion

        private void m_lsvAna_DoubleClick(object sender, System.EventArgs e)
        {
            m_mthSetAnaContentToMainForm(sender);
        }

        private void m_lsvAna_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthSetAnaContentToMainForm(sender);
            }
        }

        private void m_mthSetAnaContentToMainForm(object sender)
        {
            try
            {
                ListView lsvCon = (ListView)sender;
                if (lsvCon.SelectedItems != null)
                {
                    int intRow = dtgOperation.CurrentRowIndex;
                    if (intRow < m_dtbOperationDetail.Rows.Count)
                    {
                        m_dtbOperationDetail.Rows[intRow][9] = lsvCon.SelectedItems[0].SubItems[0].Text;
                        m_dtbOperationDetail.Rows[intRow][6] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    }
                    else
                    {
                        DataRow drTemp = m_dtbOperationDetail.NewRow();
                        drTemp[9] = lsvCon.SelectedItems[0].SubItems[0].Text;
                        drTemp[6] = lsvCon.SelectedItems[0].SubItems[1].Text;
                        m_dtbOperationDetail.Rows.Add(drTemp);
                    }
                }
                frmQueryAna.Close();
            }
            catch
            {
                frmQueryAna.Close();
            }
        }

        private void m_cmdAnaNext_Click(object sender, EventArgs e)
        {
            if (m_dtvAna == null || m_dtvAna.Count == 0)
                return;
            int intIndex = 0;
            if (frmQueryAna.m_intCurrentIndex + 9 > m_dtvAna.Count - 1)
            {
                frmQueryAna.m_cmdLast.Enabled = false;
                intIndex = 0;
            }
            else
            {
                frmQueryAna.m_cmdLast.Enabled = true;
                intIndex = frmQueryAna.m_intCurrentIndex + 9;
            }

            m_mthUpdateQueryListView(frmQueryAna, m_dtvAna, intIndex);
        }

        private void m_cmdAnaLast_Click(object sender, EventArgs e)
        {
            if (m_dtvAna == null || m_dtvAna.Count == 0)
                return;
            int intIndex = 0;
            if (frmQueryAna.m_intCurrentIndex - 9 < 0)
            {
                intIndex = 0;
                frmQueryAna.m_cmdNext.Enabled = true;
            }
            else
            {
                intIndex = frmQueryAna.m_intCurrentIndex - 9;
                frmQueryAna.m_cmdNext.Enabled = true;
            }

            m_mthUpdateQueryListView(frmQueryAna, m_dtvAna, intIndex);
        }

        private void m_lklAnaCustom_Click(object sender, EventArgs e)
        {
            m_mthGetDataFromDataBase("AnaesthesiaMode_GD.xml", "AnaesthesiaMode_GD");

            m_dtvAna = new DataView(m_dtbAna);
            frmQueryAna.m_cmdLast.Enabled = false;
            frmQueryAna.m_cmdNext.Enabled = true;
            m_mthUpdateQueryListView(frmQueryAna, m_dtvAna, 0);
        }

        #region 创建及读取本地XML文件操作
        /// <summary>
        /// 获取ICD数据
        /// </summary>
        private void m_mthGetICDData()
        {
            if (m_dtbICD != null && m_dtbICD.Rows.Count > 0)
            {
                return;
            }
            string strFile = "ICD_GD.xml";
            string strTableName = "ICD_GD";

            m_mthGetDataFromDataBaseOrXML(strFile, strTableName, ref m_dtbICD);
        }

        /// <summary>
        /// 获取手术数据
        /// </summary>
        private void m_mthGetOpData()
        {
            if (m_dtbOp != null && m_dtbOp.Rows.Count > 0)
            {
                return;
            }
            string strFile = "Operation_GD.xml";
            string strTableName = "Operation_GD";

            m_mthGetDataFromDataBaseOrXML(strFile, strTableName, ref m_dtbOp);
        }

        /// <summary>
        /// 获取麻醉方式数据
        /// </summary>
        private void m_mthGetAnaData()
        {
            if (m_dtbAna != null && m_dtbAna.Rows.Count > 0)
            {
                return;
            }
            string strFile = "AnaesthesiaMode_GD.xml";
            string strTableName = "AnaesthesiaMode_GD";

            m_mthGetDataFromDataBaseOrXML(strFile, strTableName, ref m_dtbAna);
        }

        /// <summary>
        /// 从数据库或XML中获取数据
        /// </summary>
        /// <param name="strFile">文件名</param>
        /// <param name="strTableName">DataTalbe名称</param>
        /// <param name="p_dtbTable">要获取的DataTable</param>
        private void m_mthGetDataFromDataBaseOrXML(string strFile, string strTableName, ref DataTable p_dtbTable)
        {
            if (!System.IO.File.Exists(strFile))
            {
                m_mthGetDataFromDataBase(strFile, strTableName);
            }
            else
            {
                try
                {
                    p_dtbTable = new DataTable(strTableName);
                    p_dtbTable.ReadXml(strFile);

                    if (p_dtbTable == null || p_dtbTable.Rows.Count <= 0)
                    {
                        m_mthGetDataFromDataBase(strFile, strTableName);
                    }
                }
                catch (Exception Ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(Ex);
                }
            }
        }

        /// <summary>
        /// 从数据库获取数据
        /// </summary>
        /// <param name="p_strFileName">XML文件名</param>
        /// <param name="p_strTableName">表名</param>
        private void m_mthGetDataFromDataBase(string p_strFileName, string p_strTableName)
        {
            System.Collections.ArrayList arrParameter = new System.Collections.ArrayList();
            arrParameter.Add(p_strFileName);

            long lngRes = 0;

            if (p_strFileName == "ICD_GD.xml")
            {
                lngRes = m_objDomain.m_lngGetICDDiagnosisCode(out m_dtbICD);

                if (m_dtbICD != null)
                {
                    m_dtbICD.TableName = p_strTableName;
                }
                arrParameter.Add(m_dtbICD);
            }
            else if (p_strFileName == "Operation_GD.xml")
            {
                lngRes = m_objDomain.m_lngGetOprationCode(out m_dtbOp);

                if (m_dtbOp != null)
                {
                    m_dtbOp.TableName = p_strTableName;
                }
                arrParameter.Add(m_dtbOp);
            }
            else if (p_strFileName == "AnaesthesiaMode_GD.xml")
            {
                lngRes = m_objDomain.m_lngGetAnaesthesiaMode(out m_dtbAna);

                if (m_dtbAna != null)
                {
                    m_dtbAna.TableName = p_strTableName;
                }
                arrParameter.Add(m_dtbAna);
            }

            System.Threading.Thread thrWrite = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(m_mthWriteXML));
            thrWrite.IsBackground = true;
            thrWrite.Start(arrParameter);
        }

        /// <summary>
        /// 将数据转换成XML文件
        /// </summary>
        /// <param name="Parameters">多线程参数</param>
        private void m_mthWriteXML(object Parameters)
        {
            if (Parameters == null)
            {
                return;
            }

            if (Parameters is System.Collections.ArrayList)
            {
                System.Collections.ArrayList PaArr = Parameters as System.Collections.ArrayList;
                if (PaArr.Count == 2)
                {
                    string strFileName = PaArr[0].ToString();
                    DataTable dtbDict = PaArr[1] as DataTable;

                    m_mthWriteXML(strFileName, dtbDict);
                }
            }
        }

        /// <summary>
        /// 将ICD数据转换成XML文件
        /// </summary>
        /// <param name="p_strFileName">XML文件名</param>
        /// <param name="p_dtbDict">数据</param>
        private void m_mthWriteXML(string p_strFileName, DataTable p_dtbDict)
        {
            if (string.IsNullOrEmpty(p_strFileName) || p_dtbDict == null || p_dtbDict.Rows.Count <= 0)
            {
                return;
            }

            Object thisLock = new Object();
            lock (thisLock)
            {
                try
                {
                    p_dtbDict.WriteXml(p_strFileName, XmlWriteMode.WriteSchema);
                }
                catch (Exception Ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(Ex);
                }
            }
        }
        #endregion

        #region 员工查询
        private void m_mthShowEmp(TextBox p_txtTarget)
        {
            com.digitalwave.Emr.Signature_gui.frmCommonUsePanel frmcommonusepanel = new com.digitalwave.Emr.Signature_gui.frmCommonUsePanel();
            frmcommonusepanel.m_mthSetParentForm(p_txtTarget, false);
            frmcommonusepanel.m_mthSetCommonUserType(-5);
            frmcommonusepanel.m_StrDeptID = string.Empty;
            frmcommonusepanel.m_StrEmployeeID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
            frmcommonusepanel.m_BlnIsMultiSignAndNoTag = false;
            frmcommonusepanel.FormClosed += new FormClosedEventHandler(frmcommonusepanel_FormClosed);

            frmcommonusepanel.TopMost = true;
            frmcommonusepanel.ShowDialog(this);
        }

        private void frmcommonusepanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            com.digitalwave.Emr.Signature_gui.frmCommonUsePanel frmcommonusepanel = sender as com.digitalwave.Emr.Signature_gui.frmCommonUsePanel;
            if (frmcommonusepanel.DialogResult == DialogResult.OK)
            {
                Control ctl = frmcommonusepanel.m_objSelectedControl;
                clsEmrEmployeeBase_VO objVO = ctl.Tag as clsEmrEmployeeBase_VO;
                if (dtgOperation.CurrentRowIndex > m_dtbOperationDetail.Rows.Count)
                {
                    DataRow dr = m_dtbOperationDetail.NewRow();
                    if (dtgOperation.CurrentCell.ColumnNumber == 3)
                    {
                        dr[3] = ctl.Text;
                        if (objVO != null)
                        {
                            dr[10] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 4)
                    {
                        dr[4] = ctl.Text;
                        if (objVO != null)
                        {
                            dr[11] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 5)
                    {
                        dr[5] = ctl.Text;
                        if (objVO != null)
                        {
                            dr[12] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 8)
                    {
                        dr[8] = ctl.Text;
                        if (objVO != null)
                        {
                            dr[13] = objVO.m_strEMPID_CHR;
                        }
                    }
                    m_dtbOperationDetail.Rows.Add(dr);
                }
                else
                {
                    dtgOperation.BindingContext[dtgOperation.DataSource, dtgOperation.DataMember].EndCurrentEdit();
                    if (dtgOperation.CurrentCell.ColumnNumber == 3)
                    {
                        m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][3] = ((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName;
                        if (string.IsNullOrEmpty(((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName))
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][10] = string.Empty;
                        }
                        else if (objVO != null)
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][10] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 4)
                    {
                        m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][4] = ((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName;
                        if (string.IsNullOrEmpty(((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName))
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][11] = string.Empty;
                        }
                        else if (objVO != null)
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][11] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 5)
                    {
                        m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][5] = ((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName;
                        if (string.IsNullOrEmpty(((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName))
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][12] = string.Empty;
                        }
                        else if (objVO != null)
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][12] = objVO.m_strEMPID_CHR;
                        }
                    }
                    else if (dtgOperation.CurrentCell.ColumnNumber == 8)
                    {
                        m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][8] = ((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName;
                        if (string.IsNullOrEmpty(((clsEmrEmployeeBase_VO)ctl.Tag).m_strGetTechnicalRankAndName))
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][13] = string.Empty;
                        }
                        else if (objVO != null)
                        {
                            m_dtbOperationDetail.Rows[dtgOperation.CurrentRowIndex][13] = objVO.m_strEMPID_CHR;
                        }
                    }
                }
            }
        }
        #endregion

        private void m_cmdCommit_Click(object sender, EventArgs e)
        {
            if (m_objBaseCurrentPatient == null)
            {
                return;
            }

            DialogResult dr = MessageBox.Show("病案只能提交一次，是否继续？", "病案首页", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            m_blnIsCommit = true;

            Save();


            this.Cursor = Cursors.WaitCursor;

            try
            {
                long lngRes = m_objDomain.m_lngCommitToGD(m_objCollection, objSessionInfo.m_ObjPeopleInfo, objTransDeptInstance, m_objSelectedPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (lngRes > 0)
                {
                    clsPublicFunction.ShowInformationMessageBox("病案已成功提交！");
                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                    m_cmdCommit.Enabled = false;
                }
                else
                    clsPublicFunction.ShowInformationMessageBox("病案提交失败！");
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            m_blnIsCommit = false;
        }

        /// <summary>
        /// 设置默认费用信息
        /// </summary>
        private void m_mthLoadChargeInfo()
        {
            clsInHospitalMainCharge[] objChargeArr = null;
            long lngRes = m_objDomain.m_lngGetCHRCATE(m_objBaseCurrentPatient.m_StrRegisterId, out objChargeArr);

            if (objChargeArr != null && objChargeArr.Length > 0)
            {
                double dblSum = 0D;
                for (int i = 0; i < objChargeArr.Length; i++)
                {
                    m_mthSetMoneyValueToUI(objChargeArr[i].m_dblMoney, objChargeArr[i].m_strTypeName, ref dblSum);
                }
                txtTotalAmt.Text = dblSum.ToString();
            }
        }

        #region 设置费用至界面
        /// <summary>
        /// 设置费用至界面
        /// </summary>
        /// <param name="p_dblMoney">费用金额</param>
        /// <param name="p_strChargeName">费用名称</param>
        /// <param name="p_dblSum">总和</param>
        private void m_mthSetMoneyValueToUI(double p_dblMoney, string p_strChargeName, ref double p_dblSum)
        {
            if (string.IsNullOrEmpty(p_strChargeName))
            {
                return;
            }

            switch (p_strChargeName)
            {
                case "手术费":
                    txtOperationAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "接生费":
                    txtDeliveryChildAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "检查费":
                    txtCheckAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "麻醉费":
                    txtAnaethesiaAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "婴儿费":
                    txtBabyAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "陪床费":
                    txtAccompanyAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "其他费":
                    txtOtherAmt1.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "诊疗费":
                    txtTreatmentAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "床位费":
                    txtBedAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "护理费":
                    txtNurseAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "放射费":
                    txtRadiationAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "化验费":
                    txtAssayAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "输氧费":
                    txtO2Amt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "输血费":
                    txtBloodAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "西药费":
                    txtWMAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "中草药费":
                    txtCMSemiFinishedAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
                case "中成药费":
                    txtCMFinishedAmt.Text = p_dblMoney.ToString();
                    p_dblSum += p_dblMoney;
                    break;
            }
        }
        #endregion       

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthRecordChangedToSave();

            m_cmdCommit.Enabled = false;
            m_bolIfHasSave = false;
            m_strOpenDate = null;
            m_txtFocusedRichTextBox = null;
            m_RtbCurrentTextBox = null;
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_mthCleanUpPatientDetailInfo();

            m_mthSetModifyControl(string.Empty, true);

            if (p_objSelectedSession == null)
            {
                m_mthSetControlReadOnly(this, true);
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
                m_mthAddFormStatusForClosingSave();
                return;

            }
            m_cmdCommit.Enabled = true;

            m_objBaseCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objBaseCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

            m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_objSelectedPatient = m_objBaseCurrentPatient;
            //设置病人当次住院的基本信息 更新信息
            m_mthOnlySetPatientInfo(m_objSelectedPatient);

            m_mthSetPatientCurrentInHospitalDeptInfo();
            m_mthSetControlReadOnly(this, true);
            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthDiaplayDetail();
            m_mthSetControlReadOnly(this, false);

            if (m_objCollection != null && m_objCollection.m_objMain != null)
                m_mthSetModifyControl(m_objCollection.m_objMain.m_strCreateUserID, false);
        }

        //private void radioButton3_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton3.Checked == true)
        //    {
        //        dtgBaby.Enabled = true;
        //    }
        //    else
        //    {
        //        dtgBaby.Enabled = false;
        //    }
        //}

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dtgOperation.Enabled = true;
            }
            else
            {
                m_dtbOperationDetail.Clear();
                dtgOperation.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                dtgChemotherapy.Enabled = true;
            }
            else
            {
                m_dtbChemotherapy.Clear();
                dtgChemotherapy.Enabled = false;
            }

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }
        int intErrorRow = 0;
        private bool dtgOperationCurrentCellChanged()
        {
            if (isFirstCellChange != 0 || tabControl2.SelectedIndex != 2)
            {
                tabControl2.SelectedIndex = 2;
                this.dtgOperation.Focus();
                dtgOperation.CurrentCell = new DataGridCell(intErrorRow, 1);
                isFirstCellChange = 0;
                return false;
            }
            int m_intCurrentGridRowNumber = this.dtgOperation.CurrentRowIndex;
            int m_intCurrentTableRowNumber = this.m_dtbOperationDetail.Rows.Count;
            DateTime dtmTemp;
            DataRow m_dtrOperation;
            object[] m_objRes;
            int intOperationDate;
            int intInpatientDate;
            int intOutPatientDate;
            for (int i = 0; i < m_intCurrentTableRowNumber; i++)
            {
                m_dtrOperation = this.m_dtbOperationDetail.Rows[i];
                m_objRes = m_dtrOperation.ItemArray;
                if (m_objRes[1].ToString() != "")
                {
                    DateTime.TryParse(m_objRes[1].ToString(), out dtmTemp);
                    if (dtmTemp == DateTime.MinValue)
                    {
                        m_objRes[1] = "";
                        break;
                    }
                    else
                    {
                        intOperationDate = Convert.ToInt32(Convert.ToDateTime(m_objRes[1].ToString()).ToString("yyyyMMdd"));
                        intInpatientDate = Convert.ToInt32(m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyyMMdd"));
                        intOutPatientDate = m_lblOutHospitalDate.Text == "" ? Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) : Convert.ToInt32(Convert.ToDateTime(m_lblOutHospitalDate.Text).ToString("yyyyMMdd"));
                        if (intOperationDate < intInpatientDate || intOperationDate > intOutPatientDate)
                        {
                            isFirstCellChange++;
                            clsPublicFunction.ShowInformationMessageBox("手术操作时间应介于入院日期和出院日期之间！");
                            tabControl2.SelectedIndex = 2;
                            this.dtgOperation.Focus();
                            dtgOperation.CurrentCell = new DataGridCell(i, 1);
                            intErrorRow = i;
                            isFirstCellChange = 0;
                            m_blnIsDateRight = false;
                            return false;
                        }
                    }
                }
            }
            m_blnIsDateRight = true;
            return true;
        }

        private bool dtgChemotherapyCurrentCellChanged()
        {
            if (isFirstCellChange != 0 || tabControl2.SelectedIndex != 3)
            {
                tabControl2.SelectedIndex = 3;
                dtgChemotherapy.Focus();
                dtgChemotherapy.CurrentCell = new DataGridCell(intErrorRow, 0);
                isFirstCellChange = 0;
                return false;
            }
            int m_intCurrentGridRowNumber = this.dtgChemotherapy.CurrentRowIndex;
            int m_intCurrentTableRowNumber = this.m_dtbChemotherapy.Rows.Count;
            DateTime dtmTemp;
            DataRow m_dtrChemotherapy;
            object[] m_objRes;
            int intChemotherapyDate;
            int intInpatientDate;
            int intOutPatientDate;
            for (int i = 0; i < m_intCurrentTableRowNumber; i++)
            {
                m_dtrChemotherapy = this.m_dtbChemotherapy.Rows[i];
                m_objRes = m_dtrChemotherapy.ItemArray;
                if (m_objRes[0].ToString() != "")
                {
                    DateTime.TryParse(m_objRes[0].ToString(), out dtmTemp);
                    if (dtmTemp == DateTime.MinValue)
                    {
                        m_objRes[0] = "";
                        break;
                    }
                    else
                    {
                        intChemotherapyDate = Convert.ToInt32(Convert.ToDateTime(m_objRes[0].ToString()).ToString("yyyyMMdd"));
                        intInpatientDate = Convert.ToInt32(m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyyMMdd"));
                        intOutPatientDate = m_lblOutHospitalDate.Text == "" ? Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) : Convert.ToInt32(Convert.ToDateTime(m_lblOutHospitalDate.Text).ToString("yyyyMMdd"));
                        if (intChemotherapyDate < intInpatientDate || intChemotherapyDate > intOutPatientDate)
                        {
                            isFirstCellChange++;
                            clsPublicFunction.ShowInformationMessageBox("化疗用药时间时间应介于入院日期和出院日期之间！");
                            tabControl2.SelectedIndex = 3;
                            dtgChemotherapy.Focus();
                            dtgChemotherapy.CurrentCell = new DataGridCell(i, 0);
                            intErrorRow = i;
                            isFirstCellChange = 0;
                            m_blnIsDateRight = false;
                            return false;
                        }
                    }
                }
            }
            m_blnIsDateRight = true;
            return true;
        }

        private void dtgChemotherapy_CurrentCellChanged(object sender, EventArgs e)
        {
            dtgChemotherapyCurrentCellChanged();
        }

        private void dtgChemotherapy_Leave(object sender, EventArgs e)
        {
            dtgChemotherapyCurrentCellChanged();
        }
        private void dtgOperation_Leave(object sender, EventArgs e)
        {
            dtgOperationCurrentCellChanged();
            //m_lblQueryTips.Visible = false;
            m_timShowTips.Enabled = false;
        }


        #region 检查必须输入的信息
        /// <summary>
        /// 按顺序检查必要信息，遇到为空的返回相关提示信息，以便通知用户
        /// </summary>
        /// <returns></returns>
        private string m_chkForCmdCommit_Click()
        {
            //入院后确诊日期在入院3天后
            if (dtpConfirmDiagnosisDate.Value > m_objSelectedPatient.m_DtmSelectedInDate.AddDays(3))
            {
                if (MessageBox.Show("入院后确诊日期在入院3天之后，是否继续保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    if (this.tabControl2.SelectedTab != this.tabPage6)
                        this.tabControl2.SelectedTab = this.tabPage6;
                    dtpConfirmDiagnosisDate.Focus();
                    return "";
                }
            }
            //填写了化疗用药，疗效必填
            //if (m_dtbChemotherapy.Rows.Count > 0)
            //{
            //    for (int i = 0; i < m_dtbChemotherapy.Rows.Count; i++)
            //    {
            //        if (m_dtbChemotherapy.Rows[i][3].ToString() == "True"
            //            || m_dtbChemotherapy.Rows[i][4].ToString() == "True"
            //            || m_dtbChemotherapy.Rows[i][5].ToString() == "True"
            //            || m_dtbChemotherapy.Rows[i][6].ToString() == "True"
            //            || m_dtbChemotherapy.Rows[i][7].ToString() == "True"
            //            || m_dtbChemotherapy.Rows[i][8].ToString() == "True"
            //             )
            //            continue;
            //        else
            //        {
            //            MessageBox.Show("化疗用药疗效必填！");
            //            return "化疗用药疗效必填！";
            //        }

            //    }

            //}
            //填写了手术、操作名称，术者必填；填写了麻醉方式，麻醉医师必填
            if (m_dtbOperationDetail.Rows.Count > 0)
            {
                for (int i = 0; i < m_dtbOperationDetail.Rows.Count; i++)
                {
                    if (m_dtbOperationDetail.Rows[i][2].ToString() != "")
                    {
                        if (m_dtbOperationDetail.Rows[i][10].ToString() == "")
                        {
                            MessageBox.Show("手术、操作名称已填，请填写术者！");
                            if (this.tabControl2.SelectedTab != this.tabPage8)
                                this.tabControl2.SelectedTab = this.tabPage8;
                            dtgOperation.Focus();
                            dtgOperation.CurrentCell = new DataGridCell(i, 3);
                            return "术者必填！";
                        }
                    }
                    if (m_dtbOperationDetail.Rows[i][6].ToString() != "")
                    {
                        if (m_dtbOperationDetail.Rows[i][13].ToString() != "")
                            continue;
                        else
                        {
                            MessageBox.Show("麻醉方式已填，请填写麻醉医师！");
                            if (this.tabControl2.SelectedTab != this.tabPage8)
                                this.tabControl2.SelectedTab = this.tabPage8;
                            dtgOperation.Focus();
                            dtgOperation.CurrentCell = new DataGridCell(i, 8);
                            return "麻醉医师必填！";
                        }
                    }
                }

            }
            // 病案首页保存时是否需要判断必填项； 0，不判断；1，判断；如果没有设置表示要判断。
            //if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3018") == 0)
            //    return "true";
            //if (!(string.IsNullOrEmpty(txtInsuranceNum.Text.Trim())))
            //{
            //    if (string.IsNullOrEmpty(this.m_txtIDCard.Text))
            //    {
            //        MessageBox.Show("身份证号码为空！");
            //        this.tabControl2.SelectedTab = this.tabPage6;
            //        m_txtIDCard.Focus();
            //        return "身份证号码为空！ ";
            //    }
            //}
            if (string.IsNullOrEmpty(m_cboModeOfPayment.Text.Trim()))
            {
                MessageBox.Show("付款方式为空！");

                m_cboModeOfPayment.Focus();
                return "付款方式为空！";

            }
            //if (string.IsNullOrEmpty(this.m_txtHomePhone.Text))
            //{
            //    MessageBox.Show("请输入电话号为空！");
            //    this.tabControl2.SelectedTab = this.tabPage6;
            //    m_txtHomePhone.Focus();
            //    return "电话号为空！";
            //}

            if (string.IsNullOrEmpty(this.txtDiagnosis.Text))
            {
                MessageBox.Show("西医门(急)诊诊断为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                txtDiagnosis.Focus();
                return "西医门(急)诊诊断为空！";
            }
            if (string.IsNullOrEmpty(this.txtDiagnosisZhongYi.Text))
            {
                MessageBox.Show("中医门(急)诊诊断为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                txtDiagnosisZhongYi.Focus();
                return "中医门(急)诊诊断为空！";
            }
            if (string.IsNullOrEmpty(this.txtDoctor.Text))
            {
                MessageBox.Show("门诊（急）医生为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                txtDoctor.Focus();
                return "门诊（急）医生为空！";
            }
            string m_strHospitalDiagnosis = null;
            for (int i1 = 0; i1 < this.m_dtbInHospitalDiagnosis.Rows.Count; i1++)
            {
                m_strHospitalDiagnosis = m_strHospitalDiagnosis + (m_dtbInHospitalDiagnosis.Rows[i1][0]).ToString();
            }
            if (string.IsNullOrEmpty(m_strHospitalDiagnosis))
            {
                MessageBox.Show("西医入院诊断为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                dgDiagnosis1.Focus();
                return "西医入院诊断为空！";
            }
            string m_strHospitalDiagnosisz = null;
            for (int i1 = 0; i1 < this.m_dtbInHospitalDiagnosisZhong.Rows.Count; i1++)
            {
                m_strHospitalDiagnosisz = m_strHospitalDiagnosisz + (m_dtbInHospitalDiagnosisZhong.Rows[i1][0]).ToString();
            }
            if (string.IsNullOrEmpty(m_strHospitalDiagnosisz))
            {
                MessageBox.Show("中医入院诊断为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                dgDiagnosiszhongyi.Focus();
                return "中医入院诊断为空！";
            }    

            if (string.IsNullOrEmpty(this.dtpConfirmDiagnosisDate.Text))
            {
                MessageBox.Show("入院后确诊日期为空！");
                this.tabControl2.SelectedTab = this.tabPage6;
                dtpConfirmDiagnosisDate.Focus();
                return "入院后确诊日期为空！";
            }
            if (string.IsNullOrEmpty(this.txt_zhiliang.Text))
            {
                MessageBox.Show("病案质量为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                this.txt_zhiliang.Focus();
                return "病案质量为空！";
            }
            if (string.IsNullOrEmpty(this.txtMainDiagnosiszhongyi.Text))
            {
                MessageBox.Show("中医主要诊断为空");
                this.tabControl2.SelectedTab = this.tabPage7;
                txtMainDiagnosiszhongyi.Focus();
                return "中医主要诊断为空！";
            }
            if (string.IsNullOrEmpty(this.txtzhuzheng.Text))
            {
                MessageBox.Show("中医主症诊断为空");
                this.tabControl2.SelectedTab = this.tabPage7;
                txtzhuzheng.Focus();
                return "中医主症诊断为空！";
            }
            if (string.IsNullOrEmpty(this.txtMainDiagnosis.Text))
            {
                MessageBox.Show("西医主要诊断为空");
                this.tabControl2.SelectedTab = this.tabPage7;
                txtMainDiagnosis.Focus();
                return "西医主要诊断为空！";
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            if (string.IsNullOrEmpty(this.txtSensitive.Text))
            {
                MessageBox.Show("药物过敏为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtSensitive.Focus();
                return "药物过敏为空！";
            }
            if (string.IsNullOrEmpty(this.txtDirectorDt.Text))
            {
                MessageBox.Show("科主任为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtDirectorDt.Focus();
                return "科主任为空！";
            }
            if (string.IsNullOrEmpty(this.txtSubDirectorDt.Text))
            {
                MessageBox.Show("主（副主）任医师为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtSubDirectorDt.Focus();
                return "主（副主）任医师为空！";
            }
            if (string.IsNullOrEmpty(this.txtDt.Text))
            {
                MessageBox.Show("主治医师为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtDt.Focus();
                return "主治医师为空！";
            }
            if (string.IsNullOrEmpty(this.txtInHospitalDt.Text))
            {
                MessageBox.Show("住院医师为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtInHospitalDt.Focus();
                return "住院医师为空！";
            }
            if (string.IsNullOrEmpty(this.txtQCDt.Text))
            {
                MessageBox.Show("质控医师为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtQCDt.Focus();
                return "质控医师医师为空！";
            }
            if (string.IsNullOrEmpty(this.txtQCNurse.Text))
            {
                MessageBox.Show("质控护士为空！");
                this.tabControl2.SelectedTab = this.tabPage8;
                txtQCNurse.Focus();
                return "质控护士为空！";
            }
            string txtAllBloodType = this.txtRBC.Text + this.txtPLT.Text + this.txtPlasm.Text + this.txtWholeBlood.Text + this.txtOtherBlood.Text;
            if (!rdbBloodTransNoAction.Checked && string.IsNullOrEmpty(txtAllBloodType))
            {
                MessageBox.Show("输血品种为空！");
                this.tabControl2.SelectedTab = this.tabPage10;
                txtRBC.Focus();
                return "输血品种为空！";
            }
            //string txtAllNurseLevel = this.txtTOPLevel.Text + this.txtNurseLevelI.Text + this.txtNurseLevelII.Text + this.txtNurseLevelIII.Text + this.txtICU.Text + this.txtSpecialNurse.Text;
            //if (string.IsNullOrEmpty(txtAllNurseLevel))
            //{
            //    MessageBox.Show("护理等级信息为空！");
            //    this.tabControl2.SelectedTab = this.tabPage10;
            //    txtTOPLevel.Focus();
            //    return "护理等级信息为空！";
            //}
            //if (rdbBloodTransActionYes.Checked == false && rdbBloodTransActionNO.Checked == false && rdbBloodTransNoAction.Checked == false)
            //{
            //    MessageBox.Show("输血反应为空！");
            //    this.tabControl2.SelectedTab = this.tabPage10;
            //    this.lblBloodTransAction.Focus();
            //    rdbBloodTransActionYes.Checked = false;
            //    rdbBloodTransActionNO.Checked = false;
            //    rdbBloodTransNoAction.Checked = false;
            //    return "输血反应为空！";
            //}
            if (string.IsNullOrEmpty(this.txt_shuxue.Text))
            {
                MessageBox.Show("输血反应为空！");
                this.tabControl2.SelectedTab = this.tabPage10;
                this.txt_shuxue.Focus();
                //rdbBloodTransActionYes.Checked = false;
                //rdbBloodTransActionNO.Checked = false;
                //rdbBloodTransNoAction.Checked = false;
                return "输血反应为空！";
            }

            return "true";

        }
        #endregion

        #region 作废重做
        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                m_mthDiaplayDeletedDetail(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null || m_objBaseCurrentPatient == null) return;
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO == "441900001")
            {
                objPrintToolCS = new clsInHospitalMainRecordCSPrintTool(true);
                objPrintToolCS.m_mthInitPrintTool(null);
                clsPrintInfo_InHospitalMainRecord objPrintInfo = new clsPrintInfo_InHospitalMainRecord();

                m_objDomain.m_mthSetPrintInfo(m_objBaseCurrentPatient, p_objSelectedValue.m_DtmInpatientDate, p_objSelectedValue.m_DtmOpenDate, ref objPrintInfo);

                m_mthGetDeletedDetail(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), ref  objPrintInfo.m_objCollection);

                objPrintToolCS.m_mthInitPrintContent();
            }
            else
            {
                objPrintTool = new clsInHospitalMainRecord_XJPrintTool(true);
                objPrintTool.m_mthInitPrintTool(null);
                clsPrintInfo_InHospitalMainRecord objPrintInfo = new clsPrintInfo_InHospitalMainRecord();

                m_objDomain.m_mthSetPrintInfo(m_objBaseCurrentPatient, p_objSelectedValue.m_DtmInpatientDate, p_objSelectedValue.m_DtmOpenDate, ref objPrintInfo);

                m_mthGetDeletedDetail(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), ref  objPrintInfo.m_objCollection);

                objPrintTool.m_mthInitPrintContent();
            }
            //未完成

            m_mthStartPrint();
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;
            new clsInPatientCaseHistoryDomain().m_lngGetAllInactiveInfo(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做

        private void button1_Click(object sender, EventArgs e)
        {
            txtMainDiagnosis.Text = m_dtbOtherDiagnosis.Rows.Count.ToString();
        }

        private void txtSensitive_TextChanged(object sender, EventArgs e)
        {
            //if (txtSensitive.Text != "无" || txtSensitive.Text != "没有")
            //{
            //    txtSensitive.ForeColor = Color.Red;
            //    txtSensitive.SelectionColor = Color.Red;
            //}
            //else
            //{
            //    txtSensitive.ForeColor = Color.Black;
            //}
        }

        private void txtSensitive_Leave(object sender, EventArgs e)
        {
            //if (txtSensitive.Text != "无" || txtSensitive.Text != "没有")
            //{
            //    txtSensitive.ForeColor = Color.Red;
            //}
        }

        private void m_ctlPatientInfo_Load(object sender, EventArgs e)
        {

        }

        private void m_timShowTips_Tick(object sender, EventArgs e)
        {
            //if (m_lblQueryTips.ForeColor == SystemColors.ActiveCaption)
            //{
            //    m_lblQueryTips.ForeColor = Color.Red;
            //}
            //else if (m_lblQueryTips.ForeColor == Color.Red)
            //{
            //    m_lblQueryTips.ForeColor = SystemColors.ActiveCaption;
            //}
        }

        private void txtAssayAmt_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}