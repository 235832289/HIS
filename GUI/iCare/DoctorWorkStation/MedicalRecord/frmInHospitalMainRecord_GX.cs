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
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
    /// <summary>
    /// 住院病案首页(广西)
    /// </summary>
    public class frmInHospitalMainRecord_GX : frmHRPBaseForm, PublicFunction
    {
        #region 控件定义
        private System.Windows.Forms.TreeView trvTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblBirthPlace;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOccupationTitle;
        private System.Windows.Forms.Label lblMarried;
        private System.Windows.Forms.Label lblMarriedTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInHospitalTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNation;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPayType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOfficeAddressTitle;
        private System.Windows.Forms.Label lblOfficeAddress;
        private System.Windows.Forms.Label lblOfficePCTitle;
        private System.Windows.Forms.Label lblOfficePC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblContactManTitle;
        public System.Windows.Forms.Label lblContactMan;
        private System.Windows.Forms.Label lblRelationTitle;
        public System.Windows.Forms.Label lblRelation;
        private System.Windows.Forms.Label lblContactManPhoneTitle;
        private System.Windows.Forms.Label lblContactManPhone;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblContactManAddress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInHospitalSetionTitle;
        private System.Windows.Forms.Label lblInHosptialSetion;
        private System.Windows.Forms.Label lblOutHospitalSetionTitle;
        private System.Windows.Forms.Label lblOutHospitalSetion;
        private System.Windows.Forms.Label lblHomePC;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblInHospitalDays;
        private System.Windows.Forms.Label lblHomeAddress;
        private System.Windows.Forms.Label lblOfficePhone;
        private System.Windows.Forms.ColumnHeader m_clmFromDept;
        private System.Windows.Forms.ColumnHeader m_clmTransDate;
        private System.Windows.Forms.ColumnHeader m_clmToDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView m_lsvTransDept;
        private System.Windows.Forms.Label label10;
        private com.digitalwave.Utility.Controls.ctlTimePicker dtpDiagnoseDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private com.digitalwave.controls.ctlRichTextBox txtDiagnosis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private com.digitalwave.controls.ctlRichTextBox m_txtSTATCODEOFDIAGNOSIS;
        private com.digitalwave.controls.ctlRichTextBox m_txtICD_10OFDIAGNOSIS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private com.digitalwave.controls.ctlRichTextBox m_txtMainDiagnosis;
        private com.digitalwave.controls.ctlRichTextBox m_txtICD_10OFMAIN;
        private com.digitalwave.controls.ctlRichTextBox m_txtSTATCODEOFMAIN;
        private System.Windows.Forms.DataGrid dtgOtherDiagnosis;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ0;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ1;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ2;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ3;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ4;
        private System.Windows.Forms.CheckBox m_chkMAINCONDITIONSEQ5;
        private com.digitalwave.controls.ctlRichTextBox m_txtMainDiagnosisOther;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private com.digitalwave.controls.ctlRichTextBox m_txtCOMPLICATIONOther;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ0;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ1;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ2;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ3;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ4;
        private System.Windows.Forms.CheckBox m_chkCOMPLICATIONSEQ5;
        private com.digitalwave.controls.ctlRichTextBox m_txtICD_10OFCOMPLICATION;
        private com.digitalwave.controls.ctlRichTextBox m_txtSTATCODEOFCOMPLICATION;
        private com.digitalwave.controls.ctlRichTextBox m_txtCOMPLICATION;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private com.digitalwave.controls.ctlRichTextBox m_txtINFECTIONDIAGNOSISOther;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ0;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ1;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ2;
        private com.digitalwave.controls.ctlRichTextBox m_txtICD_10OFINFECTION;
        private com.digitalwave.controls.ctlRichTextBox m_txtSTATCODEOFINFECTION;
        private com.digitalwave.controls.ctlRichTextBox m_txtINFECTIONDIAGNOSIS;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ3;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ4;
        private System.Windows.Forms.CheckBox m_chkINFECTIONCONDICTIONSEQ5;
        private com.digitalwave.controls.ctlRichTextBox m_txtPATHOLOGYDIAGNOSISOther;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ0;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ1;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ2;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ3;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ4;
        private System.Windows.Forms.CheckBox m_chkPATHOLOGYDIAGNOSISSEQ5;
        private com.digitalwave.controls.ctlRichTextBox m_txtICD_10OFPATHOLOGYDIA;
        private com.digitalwave.controls.ctlRichTextBox m_txtSTATCODEOFPATHOLOGYDIA;
        private com.digitalwave.controls.ctlRichTextBox m_txtPATHOLOGYDIAGNOSIS;
        private System.Windows.Forms.Label label32;
        private com.digitalwave.controls.ctlRichTextBox m_txtScacheSource;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ListView lsvOperationEmployee;
        private System.Windows.Forms.ColumnHeader clmEmployeeID;
        private System.Windows.Forms.ColumnHeader clmEmployeeName;
        private System.Windows.Forms.ListView lsvAanaesthesiaMode;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DataGrid dtgOperation;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dtcOperationName;
        private System.Windows.Forms.DataGridTextBoxColumn dtcOperator;
        private System.Windows.Forms.DataGridTextBoxColumn dtcAssistant1;
        private System.Windows.Forms.DataGridTextBoxColumn dtcAssistant2;
        private System.Windows.Forms.DataGridTextBoxColumn dtcAanaesthesiaMode;
        private System.Windows.Forms.DataGridTextBoxColumn dtcCutLevel;
        private System.Windows.Forms.DataGridTextBoxColumn dtcAnaesthetist;
        private System.Windows.Forms.DataGridTextBoxColumn dtcOperationID;
        private System.Windows.Forms.CheckBox m_chkNEW5DISEASE1;
        private System.Windows.Forms.CheckBox m_chkNEW5DISEASE2;
        private System.Windows.Forms.CheckBox m_chkSECONDLEVELTRANSFER1;
        private System.Windows.Forms.CheckBox m_chkSECONDLEVELTRANSFER2;
        private com.digitalwave.controls.ctlRichTextBox m_txtSENSITIVE;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHBsAg;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHCV_Ab;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboHIV_Ab;
        private System.Windows.Forms.GroupBox groupBox7;
        private com.digitalwave.controls.ctlRichTextBox m_txtNEONATEDISEASE1;
        private com.digitalwave.controls.ctlRichTextBox m_txtNEONATEDISEASE2;
        private com.digitalwave.controls.ctlRichTextBox m_txtNEONATEDISEASE3;
        private com.digitalwave.controls.ctlRichTextBox m_txtNEONATEDISEASE4;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox m_chkHASREMIND1;
        private System.Windows.Forms.CheckBox m_chkHASREMIND2;
        private System.Windows.Forms.Label label46;
        private com.digitalwave.controls.ctlRichTextBox m_txtREMINDTERM;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.CheckBox m_chkFIRSTCASE1;
        private System.Windows.Forms.CheckBox m_chkFIRSTCASE2;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.CheckBox m_chkQUALITY1;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.CheckBox m_chkANTIBACTERIAL2;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.CheckBox m_chkANTIBACTERIAL1;
        private System.Windows.Forms.CheckBox m_chkPATHOGENY2;
        private System.Windows.Forms.CheckBox m_chkPATHOGENYRESULT1;
        private System.Windows.Forms.CheckBox m_chkPATHOGENYRESULT2;
        private System.Windows.Forms.CheckBox m_chkPATHOGENY1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.CheckBox m_chkBLOODTRANSACTOIN2;
        private System.Windows.Forms.CheckBox m_chkBLOODTRANSACTOIN1;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.CheckBox m_chkTRANSFUSIONSACTION2;
        private System.Windows.Forms.CheckBox m_chkTRANSFUSIONSACTION1;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.CheckBox m_chkCTCHECK2;
        private System.Windows.Forms.CheckBox m_chkCTCHECK1;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.CheckBox m_chkMRICHECK2;
        private System.Windows.Forms.CheckBox m_chkMRICHECK1;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckBox m_chkBLOODTYPE1;
        private System.Windows.Forms.CheckBox m_chkBLOODTYPE0;
        private System.Windows.Forms.CheckBox m_chkBLOODTYPE2;
        private System.Windows.Forms.CheckBox m_chkBLOODTYPE3;
        private System.Windows.Forms.CheckBox m_chkBLOODTYPE4;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.CheckBox m_chkBLOODRH0;
        private System.Windows.Forms.CheckBox m_chkBLOODRH1;
        private System.Windows.Forms.CheckBox m_chkBLOODRH2;
        private System.Windows.Forms.GroupBox groupBox9;
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
        private PinkieControls.ButtonXP m_cmdSubDirectorDt;
        private PinkieControls.ButtonXP m_cmdDt;
        private PinkieControls.ButtonXP m_cmdInHospitalDt;
        private PinkieControls.ButtonXP m_cmdGraduateStudentIntern;
        private PinkieControls.ButtonXP m_cmdIntern;
        private System.Windows.Forms.Label lblBedAmt;
        private System.Windows.Forms.Label lblTotalAmt;
        private System.Windows.Forms.Label lblWMAmt;
        private System.Windows.Forms.Label lblCMFinishedAmt;
        private System.Windows.Forms.Label lblCMSemiFinishedTitle;
        private System.Windows.Forms.Label lblNurseAmt;
        private System.Windows.Forms.Label lblRadiationAmt;
        private System.Windows.Forms.Label lblAssayAmt;
        private System.Windows.Forms.Label lblO2;
        private System.Windows.Forms.Label lblBloodTran;
        private System.Windows.Forms.Label lblTreatmentAmt;
        private System.Windows.Forms.Label lblDeliveryChild;
        private System.Windows.Forms.Label lblOperationAmt;
        private System.Windows.Forms.Label lblCheckAmt;
        private System.Windows.Forms.Label lblAnaethisiaAmt;
        private System.Windows.Forms.Label lblBabyAmt;
        private System.Windows.Forms.Label lblAccompanyAmt;
        private System.Windows.Forms.Label lblOtherAmt1;
        private System.Windows.Forms.Label label75;
        private com.digitalwave.controls.ctlRichTextBox m_txtRBC;
        private com.digitalwave.controls.ctlRichTextBox m_txtPLT;
        private com.digitalwave.controls.ctlRichTextBox m_txtPLASM;
        private com.digitalwave.controls.ctlRichTextBox m_txtWHOLEBLOOD;
        private com.digitalwave.controls.ctlRichTextBox m_txtOTHERBLOOD;
        private PinkieControls.ButtonXP m_cmdINPUTMACHINE;
        private PinkieControls.ButtonXP m_cmdSTATISTIC;
        private PinkieControls.ButtonXP m_cmdDeptDirectorDt;
        private PinkieControls.ButtonXP m_cmdDirectorDt;
        private PinkieControls.ButtonXP m_cmdOutHospitalDoc;
        private PinkieControls.ButtonXP m_cmdNEATEN;
        private PinkieControls.ButtonXP m_cmdCODER;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel m_pnlInstanceWhenIn;
        private System.Windows.Forms.Panel m_pnlCOMPLICATIONSEQ;
        private System.Windows.Forms.Panel m_pnlMAINCONDITIONSEQ;
        private System.Windows.Forms.Panel m_pnlINFECTIONCONDICTIONSEQ;
        private System.Windows.Forms.Panel m_pnlPATHOLOGYDIAGNOSISSEQ;
        private System.Windows.Forms.Panel m_pnlHASREMIND;
        private System.Windows.Forms.Panel m_pnlNEW5DISEASE;
        private System.Windows.Forms.Panel m_pnlSECONDLEVELTRANSFER;
        private System.Windows.Forms.Panel m_pnlPATHOGENYRESULT;
        private System.Windows.Forms.Panel m_pnlANTIBACTERIAL;
        private System.Windows.Forms.Panel m_pnlQUALITY;
        private System.Windows.Forms.CheckBox m_chkQUALITY2;
        private System.Windows.Forms.CheckBox m_chkQUALITY3;
        private System.Windows.Forms.Panel m_pnlFIRSTCASE;
        private System.Windows.Forms.Panel m_pnlPATHOGENY;
        private System.Windows.Forms.Panel m_pnlMODELCASE;
        private System.Windows.Forms.CheckBox m_chkMODELCASE2;
        private System.Windows.Forms.CheckBox m_chkMODELCASE1;
        private System.Windows.Forms.Panel m_pnlBLOODTRANSACTOIN;
        private System.Windows.Forms.Panel m_pnlTRANSFUSIONSACTION;
        private System.Windows.Forms.Panel m_pnlCTCHECK;
        private System.Windows.Forms.Panel m_pnlMRICHECK;
        private System.Windows.Forms.Panel m_pnlBLOODTYPE;
        private System.Windows.Forms.Panel m_pnlBLOODRH;
        private System.Windows.Forms.Label m_lblInHospitalDate;
        private System.Windows.Forms.Label m_lblOutHospitalDate;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboClinicPh;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboClinicOUt;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboInOut;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBeforeOpAfterOp;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDeathCheck;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboClinicRad;
        private PinkieControls.ButtonXP m_cmdAttendInStudyDt;
        private System.Windows.Forms.CheckBox m_chkInstanceWhenIn1;
        private System.Windows.Forms.CheckBox m_chkInstanceWhenIn2;
        private System.Windows.Forms.CheckBox m_chkInstanceWhenIn3;
        private System.Windows.Forms.Label lblLinkManzipcode;
        private clsInHospitalMainTransDeptInstance m_objTransDeptInstance;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcDiaCon;
        private System.Windows.Forms.DataGridBoolColumn m_dtcCure;
        private System.Windows.Forms.DataGridBoolColumn m_dtcMend;
        private System.Windows.Forms.DataGridBoolColumn m_dtcNoCure;
        private System.Windows.Forms.DataGridBoolColumn m_dtcDeath;
        private System.Windows.Forms.DataGridBoolColumn m_dtcOther;
        private System.Windows.Forms.DataGridBoolColumn m_dtcNormal;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcStatc;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcICD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox m_chkXRayCheck2;
        private System.Windows.Forms.CheckBox m_chkXRayCheck1;
        private System.Windows.Forms.CheckBox m_chkXRayCheck3;
        private System.Windows.Forms.Panel m_pnlXRayCheck;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcInHospitalDiagnosis;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcSTATCODEOFINHOSPITALDIA;
        private System.Windows.Forms.DataGridTextBoxColumn m_dtcICD_10OFINHOSPITALDIA;
        private System.Windows.Forms.DataGrid dtgInHospitalDiagnosis;
        private PinkieControls.ButtonXP m_cmdSubmit;
        #endregion

        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;
        //定义签名类
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
        private clsInHospitalMainRecordDomain_GX m_objDomain;
        private DataTable m_dtbOtherDiagnosis;
        private DataTable m_dtbOperationDetail;
        private DataTable m_dtbInHospitalDiagnosis;
        private clsPublicDomain m_objPublicDomain;
        private clsInHospitalMainRecord_GX_Collection m_objCollection;
        private clsPatient m_objSelectedPatient;
        private string m_strRegisterID = "";
        /// <summary>
        /// 标志模糊查询时是否清空内容
        /// true -- 清空 false -- 不清空
        /// </summary>
        private bool m_bolIfChange = true;
        /// <summary>
        /// 标志该次住院的住院病案首页是否已经生成过
        /// false -- 否   true -- 是
        /// </summary>
        private bool m_bolIfHasSave;
        /// <summary>
        /// 该次住院的住院病案首页生成时间
        /// </summary>
        private string m_strOpenDate;
        /// <summary>
        /// 存放当前获得焦点的RichTextBox(模糊查询人名用)
        /// </summary>
        private com.digitalwave.controls.ctlRichTextBox m_RtbCurrentTextBox;
        private long m_longEMR_SEQ = 0;
        /// <summary>
        /// 当前提交状态
        /// </summary>
        #region
        private int m_intSubmit = 0;
        private System.Windows.Forms.Label m_lblTips;
        private DataView m_dtvOp = null;
        private DataView m_dtvEmp = null;
        private DataTable m_dtbOp = null;
        private TextBox txtDeptDirectorDt;
        private TextBox m_txtOutHospitalDoc;
        private TextBox txtInHospitalDt;
        private TextBox txtDt;
        private TextBox txtSubDirectorDt;
        private TextBox txtDirectorDt;
        private TextBox txtAttendInStudyDt;
        private TextBox m_txtSALVESUCCESS;
        private TextBox m_txtSALVETIMES;
        private TextBox txtTotalAmt;
        private TextBox txtIntern;
        private TextBox txtGraduateStudentIntern;
        private TextBox txtCMFinishedAmt;
        private TextBox txtWMAmt;
        private TextBox txtNurseAmt;
        private TextBox txtBedAmt;
        private TextBox txtCMSemiFinishedAmt;
        private TextBox txtBloodAmt;
        private TextBox txtO2Amt;
        private TextBox txtAssayAmt;
        private TextBox txtRadiationAmt;
        private TextBox txtCheckAmt;
        private TextBox txtOperationAmt;
        private TextBox txtTreatmentAmt;
        private TextBox txtDeliveryChildAmt;
        private TextBox txtAnaethesiaAmt;
        private TextBox txtBabyAmt;
        private TextBox m_txtNEATEN;
        private TextBox txtOtherAmt;
        private TextBox txtAccompanyAmt;
        private TextBox m_txtSTATISTIC;
        private TextBox m_txtINPUTMACHINE;
        private TextBox m_txtCODER;
        private DataGridTextBoxColumn dtcOperationDate;
        private DataTable m_dtbEmp = null;
        #endregion
        public frmInHospitalMainRecord_GX()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            #region 初始化
            //m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                this.trvTime,
            //                                                dtgInHospitalDiagnosis,
            //                                                dtgOtherDiagnosis,
            //                                                dtgOperation,
            //                                            });

            m_mthSetRichTextBoxAttribInControl(this);
            m_mthInitDataTable();
            m_objDomain = new clsInHospitalMainRecordDomain_GX();
            m_objDomain.m_lngGetOperationDesc(out m_dtbOp);
            if (m_dtbOp != null && m_dtbOp.Rows.Count > 0)
                m_dtvOp = m_dtbOp.DefaultView;
            m_objDomain.m_lngGetAllEmp(out m_dtbEmp);
            if (m_dtbEmp != null && m_dtbEmp.Rows.Count > 0)
                m_dtvEmp = m_dtbEmp.DefaultView;

            m_strOpenDate = null;
            m_bolIfHasSave = false;
            m_objPublicDomain = new clsPublicDomain();
            m_objCollection = new clsInHospitalMainRecord_GX_Collection();

            m_mthSetControlReadOnly(this, true);

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDeptDirectorDt, txtDeptDirectorDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDt, txtDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdInHospitalDt, txtInHospitalDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOutHospitalDoc, m_txtOutHospitalDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDirectorDt, txtDirectorDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdSubDirectorDt, txtSubDirectorDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAttendInStudyDt, txtAttendInStudyDt, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);

            m_mthSetComboBoxItem();
            #endregion
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("入院日期");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInHospitalMainRecord_GX));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgInHospitalDiagnosis = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.m_dtcInHospitalDiagnosis = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcSTATCODEOFINHOSPITALDIA = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcICD_10OFINHOSPITALDIA = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_lblOutHospitalDate = new System.Windows.Forms.Label();
            this.m_lblInHospitalDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtICD_10OFDIAGNOSIS = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTATCODEOFDIAGNOSIS = new com.digitalwave.controls.ctlRichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiagnosis = new com.digitalwave.controls.ctlRichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDiagnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_pnlInstanceWhenIn = new System.Windows.Forms.Panel();
            this.m_chkInstanceWhenIn1 = new System.Windows.Forms.CheckBox();
            this.m_chkInstanceWhenIn2 = new System.Windows.Forms.CheckBox();
            this.m_chkInstanceWhenIn3 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lsvTransDept = new System.Windows.Forms.ListView();
            this.m_clmFromDept = new System.Windows.Forms.ColumnHeader();
            this.m_clmTransDate = new System.Windows.Forms.ColumnHeader();
            this.m_clmToDept = new System.Windows.Forms.ColumnHeader();
            this.lblInHospitalDays = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOutHospitalSetion = new System.Windows.Forms.Label();
            this.lblInHospitalSetionTitle = new System.Windows.Forms.Label();
            this.lblInHosptialSetion = new System.Windows.Forms.Label();
            this.lblOutHospitalSetionTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContactManAddress = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRelation = new System.Windows.Forms.Label();
            this.lblContactManPhone = new System.Windows.Forms.Label();
            this.lblContactManTitle = new System.Windows.Forms.Label();
            this.lblContactMan = new System.Windows.Forms.Label();
            this.lblRelationTitle = new System.Windows.Forms.Label();
            this.lblContactManPhoneTitle = new System.Windows.Forms.Label();
            this.lblHomePC = new System.Windows.Forms.Label();
            this.lblOfficePC = new System.Windows.Forms.Label();
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOfficeAddress = new System.Windows.Forms.Label();
            this.lblOfficePhone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOfficePCTitle = new System.Windows.Forms.Label();
            this.lblOfficeAddressTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblNation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBirthPlace = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLinkManzipcode = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_pnlCOMPLICATIONSEQ = new System.Windows.Forms.Panel();
            this.m_txtCOMPLICATIONOther = new com.digitalwave.controls.ctlRichTextBox();
            this.m_chkCOMPLICATIONSEQ0 = new System.Windows.Forms.CheckBox();
            this.m_chkCOMPLICATIONSEQ1 = new System.Windows.Forms.CheckBox();
            this.m_chkCOMPLICATIONSEQ2 = new System.Windows.Forms.CheckBox();
            this.m_chkCOMPLICATIONSEQ3 = new System.Windows.Forms.CheckBox();
            this.m_chkCOMPLICATIONSEQ4 = new System.Windows.Forms.CheckBox();
            this.m_chkCOMPLICATIONSEQ5 = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtICD_10OFCOMPLICATION = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTATCODEOFCOMPLICATION = new com.digitalwave.controls.ctlRichTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtCOMPLICATION = new com.digitalwave.controls.ctlRichTextBox();
            this.dtgOtherDiagnosis = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.m_dtcDiaCon = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcCure = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcMend = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcNoCure = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcDeath = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcOther = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcNormal = new System.Windows.Forms.DataGridBoolColumn();
            this.m_dtcStatc = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcICD = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_pnlMAINCONDITIONSEQ = new System.Windows.Forms.Panel();
            this.m_txtMainDiagnosisOther = new com.digitalwave.controls.ctlRichTextBox();
            this.m_chkMAINCONDITIONSEQ0 = new System.Windows.Forms.CheckBox();
            this.m_chkMAINCONDITIONSEQ1 = new System.Windows.Forms.CheckBox();
            this.m_chkMAINCONDITIONSEQ2 = new System.Windows.Forms.CheckBox();
            this.m_chkMAINCONDITIONSEQ3 = new System.Windows.Forms.CheckBox();
            this.m_chkMAINCONDITIONSEQ4 = new System.Windows.Forms.CheckBox();
            this.m_chkMAINCONDITIONSEQ5 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtICD_10OFMAIN = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTATCODEOFMAIN = new com.digitalwave.controls.ctlRichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtMainDiagnosis = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_pnlINFECTIONCONDICTIONSEQ = new System.Windows.Forms.Panel();
            this.m_txtINFECTIONDIAGNOSISOther = new com.digitalwave.controls.ctlRichTextBox();
            this.m_chkINFECTIONCONDICTIONSEQ0 = new System.Windows.Forms.CheckBox();
            this.m_chkINFECTIONCONDICTIONSEQ1 = new System.Windows.Forms.CheckBox();
            this.m_chkINFECTIONCONDICTIONSEQ2 = new System.Windows.Forms.CheckBox();
            this.m_chkINFECTIONCONDICTIONSEQ3 = new System.Windows.Forms.CheckBox();
            this.m_chkINFECTIONCONDICTIONSEQ4 = new System.Windows.Forms.CheckBox();
            this.m_chkINFECTIONCONDICTIONSEQ5 = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_txtICD_10OFINFECTION = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTATCODEOFINFECTION = new com.digitalwave.controls.ctlRichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.m_txtINFECTIONDIAGNOSIS = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_pnlPATHOLOGYDIAGNOSISSEQ = new System.Windows.Forms.Panel();
            this.m_txtPATHOLOGYDIAGNOSISOther = new com.digitalwave.controls.ctlRichTextBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ0 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ1 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ2 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ3 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ4 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOLOGYDIAGNOSISSEQ5 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.m_txtICD_10OFPATHOLOGYDIA = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtSTATCODEOFPATHOLOGYDIA = new com.digitalwave.controls.ctlRichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.m_txtPATHOLOGYDIAGNOSIS = new com.digitalwave.controls.ctlRichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_txtSALVESUCCESS = new System.Windows.Forms.TextBox();
            this.m_txtSALVETIMES = new System.Windows.Forms.TextBox();
            this.m_txtREMINDTERM = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlHASREMIND = new System.Windows.Forms.Panel();
            this.m_chkHASREMIND2 = new System.Windows.Forms.CheckBox();
            this.m_chkHASREMIND1 = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label39 = new System.Windows.Forms.Label();
            this.m_txtNEONATEDISEASE1 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtNEONATEDISEASE2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtNEONATEDISEASE3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtNEONATEDISEASE4 = new com.digitalwave.controls.ctlRichTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lsvOperationEmployee = new System.Windows.Forms.ListView();
            this.clmEmployeeID = new System.Windows.Forms.ColumnHeader();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.lsvAanaesthesiaMode = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.dtgOperation = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dtcOperationDate = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcOperationName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcOperator = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcAssistant1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcAssistant2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcAanaesthesiaMode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcCutLevel = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcAnaesthetist = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtcOperationID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_cboHBsAg = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.m_pnlNEW5DISEASE = new System.Windows.Forms.Panel();
            this.m_chkNEW5DISEASE1 = new System.Windows.Forms.CheckBox();
            this.m_chkNEW5DISEASE2 = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.m_txtScacheSource = new com.digitalwave.controls.ctlRichTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.m_pnlSECONDLEVELTRANSFER = new System.Windows.Forms.Panel();
            this.m_chkSECONDLEVELTRANSFER1 = new System.Windows.Forms.CheckBox();
            this.m_chkSECONDLEVELTRANSFER2 = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.m_txtSENSITIVE = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboHCV_Ab = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.m_cboHIV_Ab = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.m_txtSTATISTIC = new System.Windows.Forms.TextBox();
            this.m_txtINPUTMACHINE = new System.Windows.Forms.TextBox();
            this.m_txtCODER = new System.Windows.Forms.TextBox();
            this.m_txtNEATEN = new System.Windows.Forms.TextBox();
            this.txtOtherAmt = new System.Windows.Forms.TextBox();
            this.txtAccompanyAmt = new System.Windows.Forms.TextBox();
            this.txtBabyAmt = new System.Windows.Forms.TextBox();
            this.txtDeliveryChildAmt = new System.Windows.Forms.TextBox();
            this.txtAnaethesiaAmt = new System.Windows.Forms.TextBox();
            this.txtCheckAmt = new System.Windows.Forms.TextBox();
            this.txtOperationAmt = new System.Windows.Forms.TextBox();
            this.txtTreatmentAmt = new System.Windows.Forms.TextBox();
            this.txtBloodAmt = new System.Windows.Forms.TextBox();
            this.txtO2Amt = new System.Windows.Forms.TextBox();
            this.txtAssayAmt = new System.Windows.Forms.TextBox();
            this.txtRadiationAmt = new System.Windows.Forms.TextBox();
            this.txtCMSemiFinishedAmt = new System.Windows.Forms.TextBox();
            this.txtCMFinishedAmt = new System.Windows.Forms.TextBox();
            this.txtWMAmt = new System.Windows.Forms.TextBox();
            this.txtNurseAmt = new System.Windows.Forms.TextBox();
            this.txtBedAmt = new System.Windows.Forms.TextBox();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.txtIntern = new System.Windows.Forms.TextBox();
            this.txtGraduateStudentIntern = new System.Windows.Forms.TextBox();
            this.txtAttendInStudyDt = new System.Windows.Forms.TextBox();
            this.txtSubDirectorDt = new System.Windows.Forms.TextBox();
            this.txtDirectorDt = new System.Windows.Forms.TextBox();
            this.m_txtOutHospitalDoc = new System.Windows.Forms.TextBox();
            this.txtInHospitalDt = new System.Windows.Forms.TextBox();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.txtDeptDirectorDt = new System.Windows.Forms.TextBox();
            this.m_pnlXRayCheck = new System.Windows.Forms.Panel();
            this.m_chkXRayCheck3 = new System.Windows.Forms.CheckBox();
            this.m_chkXRayCheck2 = new System.Windows.Forms.CheckBox();
            this.m_chkXRayCheck1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.lblBedAmt = new System.Windows.Forms.Label();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.lblWMAmt = new System.Windows.Forms.Label();
            this.lblCMFinishedAmt = new System.Windows.Forms.Label();
            this.lblCMSemiFinishedTitle = new System.Windows.Forms.Label();
            this.lblNurseAmt = new System.Windows.Forms.Label();
            this.lblRadiationAmt = new System.Windows.Forms.Label();
            this.lblAssayAmt = new System.Windows.Forms.Label();
            this.lblO2 = new System.Windows.Forms.Label();
            this.lblBloodTran = new System.Windows.Forms.Label();
            this.lblTreatmentAmt = new System.Windows.Forms.Label();
            this.lblDeliveryChild = new System.Windows.Forms.Label();
            this.lblOperationAmt = new System.Windows.Forms.Label();
            this.lblCheckAmt = new System.Windows.Forms.Label();
            this.lblAnaethisiaAmt = new System.Windows.Forms.Label();
            this.lblBabyAmt = new System.Windows.Forms.Label();
            this.lblAccompanyAmt = new System.Windows.Forms.Label();
            this.lblOtherAmt1 = new System.Windows.Forms.Label();
            this.m_cmdDeptDirectorDt = new PinkieControls.ButtonXP();
            this.m_cmdSubDirectorDt = new PinkieControls.ButtonXP();
            this.m_cmdDt = new PinkieControls.ButtonXP();
            this.m_cmdInHospitalDt = new PinkieControls.ButtonXP();
            this.m_cmdAttendInStudyDt = new PinkieControls.ButtonXP();
            this.m_cmdGraduateStudentIntern = new PinkieControls.ButtonXP();
            this.m_cmdIntern = new PinkieControls.ButtonXP();
            this.m_cmdDirectorDt = new PinkieControls.ButtonXP();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.m_txtWHOLEBLOOD = new com.digitalwave.controls.ctlRichTextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.m_txtRBC = new com.digitalwave.controls.ctlRichTextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.m_txtPLT = new com.digitalwave.controls.ctlRichTextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.m_txtPLASM = new com.digitalwave.controls.ctlRichTextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.m_txtOTHERBLOOD = new com.digitalwave.controls.ctlRichTextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.m_pnlPATHOGENYRESULT = new System.Windows.Forms.Panel();
            this.m_chkPATHOGENYRESULT1 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOGENYRESULT2 = new System.Windows.Forms.CheckBox();
            this.label56 = new System.Windows.Forms.Label();
            this.m_pnlANTIBACTERIAL = new System.Windows.Forms.Panel();
            this.m_chkANTIBACTERIAL2 = new System.Windows.Forms.CheckBox();
            this.m_chkANTIBACTERIAL1 = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.m_pnlQUALITY = new System.Windows.Forms.Panel();
            this.m_chkQUALITY1 = new System.Windows.Forms.CheckBox();
            this.m_chkQUALITY2 = new System.Windows.Forms.CheckBox();
            this.m_chkQUALITY3 = new System.Windows.Forms.CheckBox();
            this.label54 = new System.Windows.Forms.Label();
            this.m_pnlFIRSTCASE = new System.Windows.Forms.Panel();
            this.m_chkFIRSTCASE2 = new System.Windows.Forms.CheckBox();
            this.m_chkFIRSTCASE1 = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.m_cboClinicPh = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboClinicOUt = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.m_cboInOut = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.m_cboBeforeOpAfterOp = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.m_cboDeathCheck = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboClinicRad = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.m_pnlPATHOGENY = new System.Windows.Forms.Panel();
            this.m_chkPATHOGENY2 = new System.Windows.Forms.CheckBox();
            this.m_chkPATHOGENY1 = new System.Windows.Forms.CheckBox();
            this.label57 = new System.Windows.Forms.Label();
            this.m_pnlMODELCASE = new System.Windows.Forms.Panel();
            this.m_chkMODELCASE2 = new System.Windows.Forms.CheckBox();
            this.m_chkMODELCASE1 = new System.Windows.Forms.CheckBox();
            this.m_pnlBLOODTRANSACTOIN = new System.Windows.Forms.Panel();
            this.m_chkBLOODTRANSACTOIN2 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODTRANSACTOIN1 = new System.Windows.Forms.CheckBox();
            this.label60 = new System.Windows.Forms.Label();
            this.m_pnlTRANSFUSIONSACTION = new System.Windows.Forms.Panel();
            this.m_chkTRANSFUSIONSACTION2 = new System.Windows.Forms.CheckBox();
            this.m_chkTRANSFUSIONSACTION1 = new System.Windows.Forms.CheckBox();
            this.label61 = new System.Windows.Forms.Label();
            this.m_pnlCTCHECK = new System.Windows.Forms.Panel();
            this.m_chkCTCHECK2 = new System.Windows.Forms.CheckBox();
            this.m_chkCTCHECK1 = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.m_pnlMRICHECK = new System.Windows.Forms.Panel();
            this.m_chkMRICHECK2 = new System.Windows.Forms.CheckBox();
            this.m_chkMRICHECK1 = new System.Windows.Forms.CheckBox();
            this.m_pnlBLOODTYPE = new System.Windows.Forms.Panel();
            this.m_chkBLOODTYPE4 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODTYPE3 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODTYPE2 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODTYPE1 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODTYPE0 = new System.Windows.Forms.CheckBox();
            this.m_pnlBLOODRH = new System.Windows.Forms.Panel();
            this.m_chkBLOODRH1 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODRH0 = new System.Windows.Forms.CheckBox();
            this.m_chkBLOODRH2 = new System.Windows.Forms.CheckBox();
            this.m_cmdOutHospitalDoc = new PinkieControls.ButtonXP();
            this.m_cmdNEATEN = new PinkieControls.ButtonXP();
            this.m_cmdCODER = new PinkieControls.ButtonXP();
            this.m_cmdINPUTMACHINE = new PinkieControls.ButtonXP();
            this.m_cmdSTATISTIC = new PinkieControls.ButtonXP();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblOccupation = new System.Windows.Forms.Label();
            this.m_cboPayType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblOccupationTitle = new System.Windows.Forms.Label();
            this.lblMarried = new System.Windows.Forms.Label();
            this.lblMarriedTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInHospitalTimes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdSubmit = new PinkieControls.ButtonXP();
            this.m_lblTips = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInHospitalDiagnosis)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_pnlInstanceWhenIn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.m_pnlCOMPLICATIONSEQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtherDiagnosis)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.m_pnlMAINCONDITIONSEQ.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.m_pnlINFECTIONCONDICTIONSEQ.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_pnlHASREMIND.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperation)).BeginInit();
            this.m_pnlNEW5DISEASE.SuspendLayout();
            this.m_pnlSECONDLEVELTRANSFER.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.m_pnlXRayCheck.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.m_pnlPATHOGENYRESULT.SuspendLayout();
            this.m_pnlANTIBACTERIAL.SuspendLayout();
            this.m_pnlQUALITY.SuspendLayout();
            this.m_pnlFIRSTCASE.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.m_pnlPATHOGENY.SuspendLayout();
            this.m_pnlMODELCASE.SuspendLayout();
            this.m_pnlBLOODTRANSACTOIN.SuspendLayout();
            this.m_pnlTRANSFUSIONSACTION.SuspendLayout();
            this.m_pnlCTCHECK.SuspendLayout();
            this.m_pnlMRICHECK.SuspendLayout();
            this.m_pnlBLOODTYPE.SuspendLayout();
            this.m_pnlBLOODRH.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(616, 147);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(712, 147);
            this.lblAge.Size = new System.Drawing.Size(68, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(400, 117);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(385, 147);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(568, 117);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(568, 147);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(670, 147);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(192, 147);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(440, 108);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(442, 146);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(616, 115);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(444, 115);
            this.m_txtBedNO.Size = new System.Drawing.Size(80, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(240, 145);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(616, 169);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(440, 170);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(240, 115);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(192, 117);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 98);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(528, 115);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(320, 101);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(742, 117);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(564, 39);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(668, 38);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(8, 115);
            this.trvTime.Name = "trvTime";
            treeNode2.Name = "";
            treeNode2.Text = "入院日期";
            this.trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(176, 60);
            this.trvTime.TabIndex = 10000004;
            this.trvTime.Visible = false;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(8, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 518);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(766, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "登记资料";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtgInHospitalDiagnosis);
            this.panel2.Controls.Add(this.m_lblOutHospitalDate);
            this.panel2.Controls.Add(this.m_lblInHospitalDate);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.dtpDiagnoseDate);
            this.panel2.Controls.Add(this.m_pnlInstanceWhenIn);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.m_lsvTransDept);
            this.panel2.Controls.Add(this.lblInHospitalDays);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.lblOutHospitalSetion);
            this.panel2.Controls.Add(this.lblInHospitalSetionTitle);
            this.panel2.Controls.Add(this.lblInHosptialSetion);
            this.panel2.Controls.Add(this.lblOutHospitalSetionTitle);
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 338);
            this.panel2.TabIndex = 10000026;
            // 
            // dtgInHospitalDiagnosis
            // 
            this.dtgInHospitalDiagnosis.BackgroundColor = System.Drawing.Color.White;
            this.dtgInHospitalDiagnosis.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgInHospitalDiagnosis.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgInHospitalDiagnosis.CaptionText = "入院诊断";
            this.dtgInHospitalDiagnosis.DataMember = "";
            this.dtgInHospitalDiagnosis.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgInHospitalDiagnosis.Location = new System.Drawing.Point(4, 222);
            this.dtgInHospitalDiagnosis.Name = "dtgInHospitalDiagnosis";
            this.dtgInHospitalDiagnosis.ParentRowsForeColor = System.Drawing.SystemColors.Window;
            this.dtgInHospitalDiagnosis.Size = new System.Drawing.Size(756, 110);
            this.dtgInHospitalDiagnosis.TabIndex = 30026;
            this.dtgInHospitalDiagnosis.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dtgInHospitalDiagnosis;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.m_dtcInHospitalDiagnosis,
            this.m_dtcSTATCODEOFINHOSPITALDIA,
            this.m_dtcICD_10OFINHOSPITALDIA});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "InHospitalDiagnose";
            // 
            // m_dtcInHospitalDiagnosis
            // 
            this.m_dtcInHospitalDiagnosis.Format = "";
            this.m_dtcInHospitalDiagnosis.FormatInfo = null;
            this.m_dtcInHospitalDiagnosis.HeaderText = "诊断内容";
            this.m_dtcInHospitalDiagnosis.MappingName = "诊断内容";
            this.m_dtcInHospitalDiagnosis.Width = 550;
            // 
            // m_dtcSTATCODEOFINHOSPITALDIA
            // 
            this.m_dtcSTATCODEOFINHOSPITALDIA.Format = "";
            this.m_dtcSTATCODEOFINHOSPITALDIA.FormatInfo = null;
            this.m_dtcSTATCODEOFINHOSPITALDIA.HeaderText = "统计码";
            this.m_dtcSTATCODEOFINHOSPITALDIA.MappingName = "统计码";
            this.m_dtcSTATCODEOFINHOSPITALDIA.Width = 70;
            // 
            // m_dtcICD_10OFINHOSPITALDIA
            // 
            this.m_dtcICD_10OFINHOSPITALDIA.Format = "";
            this.m_dtcICD_10OFINHOSPITALDIA.FormatInfo = null;
            this.m_dtcICD_10OFINHOSPITALDIA.HeaderText = "ICD码";
            this.m_dtcICD_10OFINHOSPITALDIA.MappingName = "ICD码";
            this.m_dtcICD_10OFINHOSPITALDIA.Width = 70;
            // 
            // m_lblOutHospitalDate
            // 
            this.m_lblOutHospitalDate.AccessibleDescription = "出院日期";
            this.m_lblOutHospitalDate.Location = new System.Drawing.Point(220, 30);
            this.m_lblOutHospitalDate.Name = "m_lblOutHospitalDate";
            this.m_lblOutHospitalDate.Size = new System.Drawing.Size(208, 20);
            this.m_lblOutHospitalDate.TabIndex = 30025;
            // 
            // m_lblInHospitalDate
            // 
            this.m_lblInHospitalDate.AccessibleDescription = "入院日期";
            this.m_lblInHospitalDate.Location = new System.Drawing.Point(220, 6);
            this.m_lblInHospitalDate.Name = "m_lblInHospitalDate";
            this.m_lblInHospitalDate.Size = new System.Drawing.Size(208, 20);
            this.m_lblInHospitalDate.TabIndex = 30024;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtICD_10OFDIAGNOSIS);
            this.groupBox1.Controls.Add(this.m_txtSTATCODEOFDIAGNOSIS);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtDiagnosis);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(4, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 102);
            this.groupBox1.TabIndex = 30022;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "门(急)诊诊断";
            // 
            // m_txtICD_10OFDIAGNOSIS
            // 
            this.m_txtICD_10OFDIAGNOSIS.AccessibleDescription = "门(急)诊诊断ICD码";
            this.m_txtICD_10OFDIAGNOSIS.BackColor = System.Drawing.Color.White;
            this.m_txtICD_10OFDIAGNOSIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICD_10OFDIAGNOSIS.ForeColor = System.Drawing.Color.Black;
            this.m_txtICD_10OFDIAGNOSIS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICD_10OFDIAGNOSIS.Location = new System.Drawing.Point(624, 64);
            this.m_txtICD_10OFDIAGNOSIS.m_BlnIgnoreUserInfo = false;
            this.m_txtICD_10OFDIAGNOSIS.m_BlnPartControl = false;
            this.m_txtICD_10OFDIAGNOSIS.m_BlnReadOnly = false;
            this.m_txtICD_10OFDIAGNOSIS.m_BlnUnderLineDST = false;
            this.m_txtICD_10OFDIAGNOSIS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICD_10OFDIAGNOSIS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICD_10OFDIAGNOSIS.m_IntCanModifyTime = 6;
            this.m_txtICD_10OFDIAGNOSIS.m_IntPartControlLength = 0;
            this.m_txtICD_10OFDIAGNOSIS.m_IntPartControlStartIndex = 0;
            this.m_txtICD_10OFDIAGNOSIS.m_StrUserID = "";
            this.m_txtICD_10OFDIAGNOSIS.m_StrUserName = "";
            this.m_txtICD_10OFDIAGNOSIS.MaxLength = 15;
            this.m_txtICD_10OFDIAGNOSIS.Multiline = false;
            this.m_txtICD_10OFDIAGNOSIS.Name = "m_txtICD_10OFDIAGNOSIS";
            this.m_txtICD_10OFDIAGNOSIS.Size = new System.Drawing.Size(126, 24);
            this.m_txtICD_10OFDIAGNOSIS.TabIndex = 45;
            this.m_txtICD_10OFDIAGNOSIS.Text = "";
            // 
            // m_txtSTATCODEOFDIAGNOSIS
            // 
            this.m_txtSTATCODEOFDIAGNOSIS.AccessibleDescription = "门(急)诊诊断统计码";
            this.m_txtSTATCODEOFDIAGNOSIS.BackColor = System.Drawing.Color.White;
            this.m_txtSTATCODEOFDIAGNOSIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTATCODEOFDIAGNOSIS.ForeColor = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFDIAGNOSIS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTATCODEOFDIAGNOSIS.Location = new System.Drawing.Point(624, 26);
            this.m_txtSTATCODEOFDIAGNOSIS.m_BlnIgnoreUserInfo = false;
            this.m_txtSTATCODEOFDIAGNOSIS.m_BlnPartControl = false;
            this.m_txtSTATCODEOFDIAGNOSIS.m_BlnReadOnly = false;
            this.m_txtSTATCODEOFDIAGNOSIS.m_BlnUnderLineDST = false;
            this.m_txtSTATCODEOFDIAGNOSIS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTATCODEOFDIAGNOSIS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFDIAGNOSIS.m_IntCanModifyTime = 6;
            this.m_txtSTATCODEOFDIAGNOSIS.m_IntPartControlLength = 0;
            this.m_txtSTATCODEOFDIAGNOSIS.m_IntPartControlStartIndex = 0;
            this.m_txtSTATCODEOFDIAGNOSIS.m_StrUserID = "";
            this.m_txtSTATCODEOFDIAGNOSIS.m_StrUserName = "";
            this.m_txtSTATCODEOFDIAGNOSIS.MaxLength = 15;
            this.m_txtSTATCODEOFDIAGNOSIS.Multiline = false;
            this.m_txtSTATCODEOFDIAGNOSIS.Name = "m_txtSTATCODEOFDIAGNOSIS";
            this.m_txtSTATCODEOFDIAGNOSIS.Size = new System.Drawing.Size(126, 24);
            this.m_txtSTATCODEOFDIAGNOSIS.TabIndex = 40;
            this.m_txtSTATCODEOFDIAGNOSIS.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(566, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 30020;
            this.label12.Text = "统计码:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.AccessibleDescription = "门诊（急）诊断";
            this.txtDiagnosis.BackColor = System.Drawing.Color.White;
            this.txtDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.txtDiagnosis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagnosis.Location = new System.Drawing.Point(6, 22);
            this.txtDiagnosis.m_BlnIgnoreUserInfo = false;
            this.txtDiagnosis.m_BlnPartControl = false;
            this.txtDiagnosis.m_BlnReadOnly = false;
            this.txtDiagnosis.m_BlnUnderLineDST = false;
            this.txtDiagnosis.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagnosis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagnosis.m_IntCanModifyTime = 6;
            this.txtDiagnosis.m_IntPartControlLength = 0;
            this.txtDiagnosis.m_IntPartControlStartIndex = 0;
            this.txtDiagnosis.m_StrUserID = "";
            this.txtDiagnosis.m_StrUserName = "";
            this.txtDiagnosis.MaxLength = 8000;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(558, 74);
            this.txtDiagnosis.TabIndex = 35;
            this.txtDiagnosis.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(574, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 14);
            this.label17.TabIndex = 30020;
            this.label17.Text = "ICD码:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(308, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 14);
            this.label10.TabIndex = 30017;
            this.label10.Text = "入院后确诊日期:";
            // 
            // dtpDiagnoseDate
            // 
            this.dtpDiagnoseDate.AccessibleDescription = "入院后确诊日期";
            this.dtpDiagnoseDate.BorderColor = System.Drawing.Color.Black;
            this.dtpDiagnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpDiagnoseDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpDiagnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDiagnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpDiagnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpDiagnoseDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDiagnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDiagnoseDate.Location = new System.Drawing.Point(422, 82);
            this.dtpDiagnoseDate.m_BlnOnlyTime = false;
            this.dtpDiagnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpDiagnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDiagnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDiagnoseDate.Name = "dtpDiagnoseDate";
            this.dtpDiagnoseDate.ReadOnly = false;
            this.dtpDiagnoseDate.Size = new System.Drawing.Size(138, 22);
            this.dtpDiagnoseDate.TabIndex = 30;
            this.dtpDiagnoseDate.TextBackColor = System.Drawing.Color.White;
            this.dtpDiagnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_pnlInstanceWhenIn
            // 
            this.m_pnlInstanceWhenIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlInstanceWhenIn.Controls.Add(this.m_chkInstanceWhenIn1);
            this.m_pnlInstanceWhenIn.Controls.Add(this.m_chkInstanceWhenIn2);
            this.m_pnlInstanceWhenIn.Controls.Add(this.m_chkInstanceWhenIn3);
            this.m_pnlInstanceWhenIn.Location = new System.Drawing.Point(86, 78);
            this.m_pnlInstanceWhenIn.Name = "m_pnlInstanceWhenIn";
            this.m_pnlInstanceWhenIn.Size = new System.Drawing.Size(212, 30);
            this.m_pnlInstanceWhenIn.TabIndex = 30015;
            // 
            // m_chkInstanceWhenIn1
            // 
            this.m_chkInstanceWhenIn1.AccessibleDescription = "入院时情况>>危";
            this.m_chkInstanceWhenIn1.Location = new System.Drawing.Point(4, 2);
            this.m_chkInstanceWhenIn1.Name = "m_chkInstanceWhenIn1";
            this.m_chkInstanceWhenIn1.Size = new System.Drawing.Size(58, 24);
            this.m_chkInstanceWhenIn1.TabIndex = 15;
            this.m_chkInstanceWhenIn1.Text = "1.危";
            this.m_chkInstanceWhenIn1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkInstanceWhenIn2
            // 
            this.m_chkInstanceWhenIn2.AccessibleDescription = "入院时情况>>急";
            this.m_chkInstanceWhenIn2.Location = new System.Drawing.Point(68, 2);
            this.m_chkInstanceWhenIn2.Name = "m_chkInstanceWhenIn2";
            this.m_chkInstanceWhenIn2.Size = new System.Drawing.Size(58, 24);
            this.m_chkInstanceWhenIn2.TabIndex = 20;
            this.m_chkInstanceWhenIn2.Text = "2.急";
            this.m_chkInstanceWhenIn2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkInstanceWhenIn3
            // 
            this.m_chkInstanceWhenIn3.AccessibleDescription = "入院时情况>>一般";
            this.m_chkInstanceWhenIn3.Location = new System.Drawing.Point(134, 2);
            this.m_chkInstanceWhenIn3.Name = "m_chkInstanceWhenIn3";
            this.m_chkInstanceWhenIn3.Size = new System.Drawing.Size(72, 24);
            this.m_chkInstanceWhenIn3.TabIndex = 25;
            this.m_chkInstanceWhenIn3.Text = "3.一般";
            this.m_chkInstanceWhenIn3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 30014;
            this.label7.Text = "入院时情况:";
            // 
            // m_lsvTransDept
            // 
            this.m_lsvTransDept.AccessibleDescription = "转科情况";
            this.m_lsvTransDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvTransDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_clmFromDept,
            this.m_clmTransDate,
            this.m_clmToDept});
            this.m_lsvTransDept.GridLines = true;
            this.m_lsvTransDept.Location = new System.Drawing.Point(432, 4);
            this.m_lsvTransDept.Name = "m_lsvTransDept";
            this.m_lsvTransDept.Size = new System.Drawing.Size(328, 72);
            this.m_lsvTransDept.TabIndex = 30013;
            this.m_lsvTransDept.UseCompatibleStateImageBehavior = false;
            this.m_lsvTransDept.View = System.Windows.Forms.View.Details;
            // 
            // m_clmFromDept
            // 
            this.m_clmFromDept.Text = "转出科室";
            this.m_clmFromDept.Width = 115;
            // 
            // m_clmTransDate
            // 
            this.m_clmTransDate.Text = "转科日期";
            this.m_clmTransDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_clmTransDate.Width = 90;
            // 
            // m_clmToDept
            // 
            this.m_clmToDept.Text = "转入科室";
            this.m_clmToDept.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_clmToDept.Width = 115;
            // 
            // lblInHospitalDays
            // 
            this.lblInHospitalDays.AccessibleDescription = "住院天数";
            this.lblInHospitalDays.Location = new System.Drawing.Point(32, 54);
            this.lblInHospitalDays.Name = "lblInHospitalDays";
            this.lblInHospitalDays.Size = new System.Drawing.Size(52, 20);
            this.lblInHospitalDays.TabIndex = 30012;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(2, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 14);
            this.label16.TabIndex = 30011;
            this.label16.Text = "共住        天";
            // 
            // lblOutHospitalSetion
            // 
            this.lblOutHospitalSetion.AccessibleDescription = "出院科别";
            this.lblOutHospitalSetion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutHospitalSetion.Location = new System.Drawing.Point(70, 30);
            this.lblOutHospitalSetion.Name = "lblOutHospitalSetion";
            this.lblOutHospitalSetion.Size = new System.Drawing.Size(148, 20);
            this.lblOutHospitalSetion.TabIndex = 30006;
            // 
            // lblInHospitalSetionTitle
            // 
            this.lblInHospitalSetionTitle.AutoSize = true;
            this.lblInHospitalSetionTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalSetionTitle.Location = new System.Drawing.Point(2, 6);
            this.lblInHospitalSetionTitle.Name = "lblInHospitalSetionTitle";
            this.lblInHospitalSetionTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalSetionTitle.TabIndex = 30007;
            this.lblInHospitalSetionTitle.Text = "入院科别:";
            // 
            // lblInHosptialSetion
            // 
            this.lblInHosptialSetion.AccessibleDescription = "入院科别";
            this.lblInHosptialSetion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHosptialSetion.Location = new System.Drawing.Point(70, 6);
            this.lblInHosptialSetion.Name = "lblInHosptialSetion";
            this.lblInHosptialSetion.Size = new System.Drawing.Size(148, 20);
            this.lblInHosptialSetion.TabIndex = 30009;
            // 
            // lblOutHospitalSetionTitle
            // 
            this.lblOutHospitalSetionTitle.AutoSize = true;
            this.lblOutHospitalSetionTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOutHospitalSetionTitle.Location = new System.Drawing.Point(2, 30);
            this.lblOutHospitalSetionTitle.Name = "lblOutHospitalSetionTitle";
            this.lblOutHospitalSetionTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOutHospitalSetionTitle.TabIndex = 30008;
            this.lblOutHospitalSetionTitle.Text = "出院科别:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblContactManAddress);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lblRelation);
            this.panel1.Controls.Add(this.lblContactManPhone);
            this.panel1.Controls.Add(this.lblContactManTitle);
            this.panel1.Controls.Add(this.lblContactMan);
            this.panel1.Controls.Add(this.lblRelationTitle);
            this.panel1.Controls.Add(this.lblContactManPhoneTitle);
            this.panel1.Controls.Add(this.lblHomePC);
            this.panel1.Controls.Add(this.lblOfficePC);
            this.panel1.Controls.Add(this.lblHomeAddress);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblOfficeAddress);
            this.panel1.Controls.Add(this.lblOfficePhone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblOfficePCTitle);
            this.panel1.Controls.Add(this.lblOfficeAddressTitle);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.lblNationality);
            this.panel1.Controls.Add(this.lblNation);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblBirthPlace);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblLinkManzipcode);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(0, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 118);
            this.panel1.TabIndex = 10000025;
            // 
            // lblContactManAddress
            // 
            this.lblContactManAddress.AccessibleDescription = "联系人地址";
            this.lblContactManAddress.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactManAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContactManAddress.Location = new System.Drawing.Point(82, 92);
            this.lblContactManAddress.Name = "lblContactManAddress";
            this.lblContactManAddress.Size = new System.Drawing.Size(546, 20);
            this.lblContactManAddress.TabIndex = 10000041;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 14);
            this.label13.TabIndex = 10000040;
            this.label13.Text = "联系人地址:";
            // 
            // lblRelation
            // 
            this.lblRelation.AccessibleDescription = "联系人关系";
            this.lblRelation.BackColor = System.Drawing.SystemColors.Control;
            this.lblRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRelation.Location = new System.Drawing.Point(286, 70);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(96, 20);
            this.lblRelation.TabIndex = 10000035;
            // 
            // lblContactManPhone
            // 
            this.lblContactManPhone.AccessibleDescription = "联系人电话";
            this.lblContactManPhone.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactManPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContactManPhone.Location = new System.Drawing.Point(538, 70);
            this.lblContactManPhone.Name = "lblContactManPhone";
            this.lblContactManPhone.Size = new System.Drawing.Size(128, 20);
            this.lblContactManPhone.TabIndex = 10000036;
            // 
            // lblContactManTitle
            // 
            this.lblContactManTitle.AutoSize = true;
            this.lblContactManTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactManTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContactManTitle.Location = new System.Drawing.Point(2, 70);
            this.lblContactManTitle.Name = "lblContactManTitle";
            this.lblContactManTitle.Size = new System.Drawing.Size(84, 14);
            this.lblContactManTitle.TabIndex = 10000037;
            this.lblContactManTitle.Text = "联系人姓名:";
            // 
            // lblContactMan
            // 
            this.lblContactMan.AccessibleDescription = "联系人姓名";
            this.lblContactMan.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContactMan.Location = new System.Drawing.Point(86, 70);
            this.lblContactMan.Name = "lblContactMan";
            this.lblContactMan.Size = new System.Drawing.Size(158, 20);
            this.lblContactMan.TabIndex = 10000034;
            // 
            // lblRelationTitle
            // 
            this.lblRelationTitle.AutoSize = true;
            this.lblRelationTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblRelationTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRelationTitle.Location = new System.Drawing.Point(246, 70);
            this.lblRelationTitle.Name = "lblRelationTitle";
            this.lblRelationTitle.Size = new System.Drawing.Size(42, 14);
            this.lblRelationTitle.TabIndex = 10000039;
            this.lblRelationTitle.Text = "关系:";
            // 
            // lblContactManPhoneTitle
            // 
            this.lblContactManPhoneTitle.AutoSize = true;
            this.lblContactManPhoneTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblContactManPhoneTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContactManPhoneTitle.Location = new System.Drawing.Point(498, 70);
            this.lblContactManPhoneTitle.Name = "lblContactManPhoneTitle";
            this.lblContactManPhoneTitle.Size = new System.Drawing.Size(42, 14);
            this.lblContactManPhoneTitle.TabIndex = 10000038;
            this.lblContactManPhoneTitle.Text = "电话:";
            // 
            // lblHomePC
            // 
            this.lblHomePC.AccessibleDescription = "联系人邮政编码";
            this.lblHomePC.BackColor = System.Drawing.SystemColors.Control;
            this.lblHomePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHomePC.Location = new System.Drawing.Point(702, 48);
            this.lblHomePC.Name = "lblHomePC";
            this.lblHomePC.Size = new System.Drawing.Size(60, 20);
            this.lblHomePC.TabIndex = 10000029;
            // 
            // lblOfficePC
            // 
            this.lblOfficePC.AccessibleDescription = "工作单位邮政编码";
            this.lblOfficePC.BackColor = System.Drawing.SystemColors.Control;
            this.lblOfficePC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOfficePC.Location = new System.Drawing.Point(702, 26);
            this.lblOfficePC.Name = "lblOfficePC";
            this.lblOfficePC.Size = new System.Drawing.Size(60, 20);
            this.lblOfficePC.TabIndex = 10000029;
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.AccessibleDescription = "户口地址";
            this.lblHomeAddress.BackColor = System.Drawing.SystemColors.Control;
            this.lblHomeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHomeAddress.Location = new System.Drawing.Point(68, 48);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(562, 20);
            this.lblHomeAddress.TabIndex = 10000028;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10000033;
            this.label9.Text = "户口地址:";
            // 
            // lblOfficeAddress
            // 
            this.lblOfficeAddress.AccessibleDescription = "工作单位及地址";
            this.lblOfficeAddress.BackColor = System.Drawing.SystemColors.Control;
            this.lblOfficeAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOfficeAddress.Location = new System.Drawing.Point(112, 26);
            this.lblOfficeAddress.Name = "lblOfficeAddress";
            this.lblOfficeAddress.Size = new System.Drawing.Size(388, 20);
            this.lblOfficeAddress.TabIndex = 10000028;
            // 
            // lblOfficePhone
            // 
            this.lblOfficePhone.AccessibleDescription = "工作单位电话";
            this.lblOfficePhone.Location = new System.Drawing.Point(538, 26);
            this.lblOfficePhone.Name = "lblOfficePhone";
            this.lblOfficePhone.Size = new System.Drawing.Size(92, 20);
            this.lblOfficePhone.TabIndex = 10000032;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000031;
            this.label5.Text = "电话:";
            // 
            // lblOfficePCTitle
            // 
            this.lblOfficePCTitle.AutoSize = true;
            this.lblOfficePCTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOfficePCTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOfficePCTitle.Location = new System.Drawing.Point(632, 26);
            this.lblOfficePCTitle.Name = "lblOfficePCTitle";
            this.lblOfficePCTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOfficePCTitle.TabIndex = 10000030;
            this.lblOfficePCTitle.Text = "邮政编码:";
            // 
            // lblOfficeAddressTitle
            // 
            this.lblOfficeAddressTitle.AutoSize = true;
            this.lblOfficeAddressTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOfficeAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOfficeAddressTitle.Location = new System.Drawing.Point(2, 26);
            this.lblOfficeAddressTitle.Name = "lblOfficeAddressTitle";
            this.lblOfficeAddressTitle.Size = new System.Drawing.Size(112, 14);
            this.lblOfficeAddressTitle.TabIndex = 10000027;
            this.lblOfficeAddressTitle.Text = "工作单位及地址:";
            // 
            // lblID
            // 
            this.lblID.AccessibleDescription = "身份证号";
            this.lblID.Location = new System.Drawing.Point(610, 4);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(152, 20);
            this.lblID.TabIndex = 10000026;
            // 
            // lblNationality
            // 
            this.lblNationality.AccessibleDescription = "国籍";
            this.lblNationality.Location = new System.Drawing.Point(426, 4);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(110, 20);
            this.lblNationality.TabIndex = 10000026;
            // 
            // lblNation
            // 
            this.lblNation.AccessibleDescription = "民族";
            this.lblNation.Location = new System.Drawing.Point(286, 4);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(96, 20);
            this.lblNation.TabIndex = 10000026;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 10000025;
            this.label4.Text = "民族:";
            // 
            // lblBirthPlace
            // 
            this.lblBirthPlace.AccessibleDescription = "出生地";
            this.lblBirthPlace.Location = new System.Drawing.Point(56, 4);
            this.lblBirthPlace.Name = "lblBirthPlace";
            this.lblBirthPlace.Size = new System.Drawing.Size(188, 20);
            this.lblBirthPlace.TabIndex = 10000024;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 10000023;
            this.label3.Text = "出生地:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10000025;
            this.label6.Text = "国籍:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 10000025;
            this.label8.Text = "身份证号:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(632, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 10000030;
            this.label11.Text = "邮政编码:";
            // 
            // lblLinkManzipcode
            // 
            this.lblLinkManzipcode.AccessibleDescription = "联系人邮政编码";
            this.lblLinkManzipcode.BackColor = System.Drawing.SystemColors.Control;
            this.lblLinkManzipcode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLinkManzipcode.Location = new System.Drawing.Point(702, 92);
            this.lblLinkManzipcode.Name = "lblLinkManzipcode";
            this.lblLinkManzipcode.Size = new System.Drawing.Size(60, 20);
            this.lblLinkManzipcode.TabIndex = 10000029;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(632, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 10000030;
            this.label15.Text = "邮政编码:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.dtgOtherDiagnosis);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(766, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出院诊断";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_pnlCOMPLICATIONSEQ);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.m_txtICD_10OFCOMPLICATION);
            this.groupBox4.Controls.Add(this.m_txtSTATCODEOFCOMPLICATION);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.m_txtCOMPLICATION);
            this.groupBox4.Location = new System.Drawing.Point(2, 198);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(762, 94);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "并发症(含手术麻醉)";
            // 
            // m_pnlCOMPLICATIONSEQ
            // 
            this.m_pnlCOMPLICATIONSEQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_txtCOMPLICATIONOther);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ0);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ1);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ2);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ3);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ4);
            this.m_pnlCOMPLICATIONSEQ.Controls.Add(this.m_chkCOMPLICATIONSEQ5);
            this.m_pnlCOMPLICATIONSEQ.Location = new System.Drawing.Point(50, 64);
            this.m_pnlCOMPLICATIONSEQ.Name = "m_pnlCOMPLICATIONSEQ";
            this.m_pnlCOMPLICATIONSEQ.Size = new System.Drawing.Size(704, 26);
            this.m_pnlCOMPLICATIONSEQ.TabIndex = 30027;
            // 
            // m_txtCOMPLICATIONOther
            // 
            this.m_txtCOMPLICATIONOther.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>其他Text";
            this.m_txtCOMPLICATIONOther.BackColor = System.Drawing.Color.White;
            this.m_txtCOMPLICATIONOther.Enabled = false;
            this.m_txtCOMPLICATIONOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCOMPLICATIONOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtCOMPLICATIONOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCOMPLICATIONOther.Location = new System.Drawing.Point(354, 0);
            this.m_txtCOMPLICATIONOther.m_BlnIgnoreUserInfo = false;
            this.m_txtCOMPLICATIONOther.m_BlnPartControl = false;
            this.m_txtCOMPLICATIONOther.m_BlnReadOnly = false;
            this.m_txtCOMPLICATIONOther.m_BlnUnderLineDST = false;
            this.m_txtCOMPLICATIONOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCOMPLICATIONOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCOMPLICATIONOther.m_IntCanModifyTime = 6;
            this.m_txtCOMPLICATIONOther.m_IntPartControlLength = 0;
            this.m_txtCOMPLICATIONOther.m_IntPartControlStartIndex = 0;
            this.m_txtCOMPLICATIONOther.m_StrUserID = "";
            this.m_txtCOMPLICATIONOther.m_StrUserName = "";
            this.m_txtCOMPLICATIONOther.MaxLength = 8000;
            this.m_txtCOMPLICATIONOther.Multiline = false;
            this.m_txtCOMPLICATIONOther.Name = "m_txtCOMPLICATIONOther";
            this.m_txtCOMPLICATIONOther.Size = new System.Drawing.Size(242, 24);
            this.m_txtCOMPLICATIONOther.TabIndex = 155;
            this.m_txtCOMPLICATIONOther.Text = "";
            // 
            // m_chkCOMPLICATIONSEQ0
            // 
            this.m_chkCOMPLICATIONSEQ0.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>治愈";
            this.m_chkCOMPLICATIONSEQ0.Location = new System.Drawing.Point(4, 0);
            this.m_chkCOMPLICATIONSEQ0.Name = "m_chkCOMPLICATIONSEQ0";
            this.m_chkCOMPLICATIONSEQ0.Size = new System.Drawing.Size(70, 24);
            this.m_chkCOMPLICATIONSEQ0.TabIndex = 130;
            this.m_chkCOMPLICATIONSEQ0.Text = "治愈、";
            this.m_chkCOMPLICATIONSEQ0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCOMPLICATIONSEQ1
            // 
            this.m_chkCOMPLICATIONSEQ1.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>好转";
            this.m_chkCOMPLICATIONSEQ1.Location = new System.Drawing.Point(78, 0);
            this.m_chkCOMPLICATIONSEQ1.Name = "m_chkCOMPLICATIONSEQ1";
            this.m_chkCOMPLICATIONSEQ1.Size = new System.Drawing.Size(70, 24);
            this.m_chkCOMPLICATIONSEQ1.TabIndex = 135;
            this.m_chkCOMPLICATIONSEQ1.Text = "好转、";
            this.m_chkCOMPLICATIONSEQ1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCOMPLICATIONSEQ2
            // 
            this.m_chkCOMPLICATIONSEQ2.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>未愈";
            this.m_chkCOMPLICATIONSEQ2.Location = new System.Drawing.Point(154, 0);
            this.m_chkCOMPLICATIONSEQ2.Name = "m_chkCOMPLICATIONSEQ2";
            this.m_chkCOMPLICATIONSEQ2.Size = new System.Drawing.Size(70, 24);
            this.m_chkCOMPLICATIONSEQ2.TabIndex = 140;
            this.m_chkCOMPLICATIONSEQ2.Text = "未愈、";
            this.m_chkCOMPLICATIONSEQ2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCOMPLICATIONSEQ3
            // 
            this.m_chkCOMPLICATIONSEQ3.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>死亡";
            this.m_chkCOMPLICATIONSEQ3.Location = new System.Drawing.Point(228, 0);
            this.m_chkCOMPLICATIONSEQ3.Name = "m_chkCOMPLICATIONSEQ3";
            this.m_chkCOMPLICATIONSEQ3.Size = new System.Drawing.Size(70, 24);
            this.m_chkCOMPLICATIONSEQ3.TabIndex = 145;
            this.m_chkCOMPLICATIONSEQ3.Text = "死亡、";
            this.m_chkCOMPLICATIONSEQ3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCOMPLICATIONSEQ4
            // 
            this.m_chkCOMPLICATIONSEQ4.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>其他";
            this.m_chkCOMPLICATIONSEQ4.Location = new System.Drawing.Point(302, 0);
            this.m_chkCOMPLICATIONSEQ4.Name = "m_chkCOMPLICATIONSEQ4";
            this.m_chkCOMPLICATIONSEQ4.Size = new System.Drawing.Size(70, 24);
            this.m_chkCOMPLICATIONSEQ4.TabIndex = 150;
            this.m_chkCOMPLICATIONSEQ4.Text = "其他";
            this.m_chkCOMPLICATIONSEQ4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCOMPLICATIONSEQ5
            // 
            this.m_chkCOMPLICATIONSEQ5.AccessibleDescription = "并发症(含手术麻醉)>>疗效>>正常分娩";
            this.m_chkCOMPLICATIONSEQ5.Location = new System.Drawing.Point(608, 0);
            this.m_chkCOMPLICATIONSEQ5.Name = "m_chkCOMPLICATIONSEQ5";
            this.m_chkCOMPLICATIONSEQ5.Size = new System.Drawing.Size(90, 24);
            this.m_chkCOMPLICATIONSEQ5.TabIndex = 160;
            this.m_chkCOMPLICATIONSEQ5.Text = "正常分娩";
            this.m_chkCOMPLICATIONSEQ5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 68);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 14);
            this.label23.TabIndex = 30026;
            this.label23.Text = "疗效:";
            // 
            // m_txtICD_10OFCOMPLICATION
            // 
            this.m_txtICD_10OFCOMPLICATION.AccessibleDescription = "并发症(含手术麻醉)>>ICD码";
            this.m_txtICD_10OFCOMPLICATION.BackColor = System.Drawing.Color.White;
            this.m_txtICD_10OFCOMPLICATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICD_10OFCOMPLICATION.ForeColor = System.Drawing.Color.Black;
            this.m_txtICD_10OFCOMPLICATION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICD_10OFCOMPLICATION.Location = new System.Drawing.Point(630, 40);
            this.m_txtICD_10OFCOMPLICATION.m_BlnIgnoreUserInfo = false;
            this.m_txtICD_10OFCOMPLICATION.m_BlnPartControl = false;
            this.m_txtICD_10OFCOMPLICATION.m_BlnReadOnly = false;
            this.m_txtICD_10OFCOMPLICATION.m_BlnUnderLineDST = false;
            this.m_txtICD_10OFCOMPLICATION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICD_10OFCOMPLICATION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICD_10OFCOMPLICATION.m_IntCanModifyTime = 6;
            this.m_txtICD_10OFCOMPLICATION.m_IntPartControlLength = 0;
            this.m_txtICD_10OFCOMPLICATION.m_IntPartControlStartIndex = 0;
            this.m_txtICD_10OFCOMPLICATION.m_StrUserID = "";
            this.m_txtICD_10OFCOMPLICATION.m_StrUserName = "";
            this.m_txtICD_10OFCOMPLICATION.MaxLength = 15;
            this.m_txtICD_10OFCOMPLICATION.Multiline = false;
            this.m_txtICD_10OFCOMPLICATION.Name = "m_txtICD_10OFCOMPLICATION";
            this.m_txtICD_10OFCOMPLICATION.Size = new System.Drawing.Size(126, 24);
            this.m_txtICD_10OFCOMPLICATION.TabIndex = 120;
            this.m_txtICD_10OFCOMPLICATION.Text = "";
            // 
            // m_txtSTATCODEOFCOMPLICATION
            // 
            this.m_txtSTATCODEOFCOMPLICATION.AccessibleDescription = "并发症(含手术麻醉)>>统计码";
            this.m_txtSTATCODEOFCOMPLICATION.BackColor = System.Drawing.Color.White;
            this.m_txtSTATCODEOFCOMPLICATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTATCODEOFCOMPLICATION.ForeColor = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFCOMPLICATION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTATCODEOFCOMPLICATION.Location = new System.Drawing.Point(630, 14);
            this.m_txtSTATCODEOFCOMPLICATION.m_BlnIgnoreUserInfo = false;
            this.m_txtSTATCODEOFCOMPLICATION.m_BlnPartControl = false;
            this.m_txtSTATCODEOFCOMPLICATION.m_BlnReadOnly = false;
            this.m_txtSTATCODEOFCOMPLICATION.m_BlnUnderLineDST = false;
            this.m_txtSTATCODEOFCOMPLICATION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTATCODEOFCOMPLICATION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFCOMPLICATION.m_IntCanModifyTime = 6;
            this.m_txtSTATCODEOFCOMPLICATION.m_IntPartControlLength = 0;
            this.m_txtSTATCODEOFCOMPLICATION.m_IntPartControlStartIndex = 0;
            this.m_txtSTATCODEOFCOMPLICATION.m_StrUserID = "";
            this.m_txtSTATCODEOFCOMPLICATION.m_StrUserName = "";
            this.m_txtSTATCODEOFCOMPLICATION.MaxLength = 15;
            this.m_txtSTATCODEOFCOMPLICATION.Multiline = false;
            this.m_txtSTATCODEOFCOMPLICATION.Name = "m_txtSTATCODEOFCOMPLICATION";
            this.m_txtSTATCODEOFCOMPLICATION.Size = new System.Drawing.Size(126, 24);
            this.m_txtSTATCODEOFCOMPLICATION.TabIndex = 120;
            this.m_txtSTATCODEOFCOMPLICATION.Text = "";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(572, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 14);
            this.label24.TabIndex = 30022;
            this.label24.Text = "统计码:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(580, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 30023;
            this.label25.Text = "ICD码:";
            // 
            // m_txtCOMPLICATION
            // 
            this.m_txtCOMPLICATION.AccessibleDescription = "并发症(含手术麻醉)";
            this.m_txtCOMPLICATION.BackColor = System.Drawing.Color.White;
            this.m_txtCOMPLICATION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCOMPLICATION.ForeColor = System.Drawing.Color.Black;
            this.m_txtCOMPLICATION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCOMPLICATION.Location = new System.Drawing.Point(6, 16);
            this.m_txtCOMPLICATION.m_BlnIgnoreUserInfo = false;
            this.m_txtCOMPLICATION.m_BlnPartControl = false;
            this.m_txtCOMPLICATION.m_BlnReadOnly = false;
            this.m_txtCOMPLICATION.m_BlnUnderLineDST = false;
            this.m_txtCOMPLICATION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtCOMPLICATION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCOMPLICATION.m_IntCanModifyTime = 6;
            this.m_txtCOMPLICATION.m_IntPartControlLength = 0;
            this.m_txtCOMPLICATION.m_IntPartControlStartIndex = 0;
            this.m_txtCOMPLICATION.m_StrUserID = "";
            this.m_txtCOMPLICATION.m_StrUserName = "";
            this.m_txtCOMPLICATION.MaxLength = 8000;
            this.m_txtCOMPLICATION.Name = "m_txtCOMPLICATION";
            this.m_txtCOMPLICATION.Size = new System.Drawing.Size(558, 46);
            this.m_txtCOMPLICATION.TabIndex = 115;
            this.m_txtCOMPLICATION.Text = "";
            // 
            // dtgOtherDiagnosis
            // 
            this.dtgOtherDiagnosis.AllowSorting = false;
            this.dtgOtherDiagnosis.BackgroundColor = System.Drawing.Color.White;
            this.dtgOtherDiagnosis.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgOtherDiagnosis.CaptionForeColor = System.Drawing.Color.Black;
            this.dtgOtherDiagnosis.CaptionText = "出院其它诊断";
            this.dtgOtherDiagnosis.DataMember = "";
            this.dtgOtherDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOtherDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.dtgOtherDiagnosis.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgOtherDiagnosis.Location = new System.Drawing.Point(4, 102);
            this.dtgOtherDiagnosis.Name = "dtgOtherDiagnosis";
            this.dtgOtherDiagnosis.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOtherDiagnosis.RowHeaderWidth = 40;
            this.dtgOtherDiagnosis.Size = new System.Drawing.Size(756, 92);
            this.dtgOtherDiagnosis.TabIndex = 112;
            this.dtgOtherDiagnosis.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dtgOtherDiagnosis;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.m_dtcDiaCon,
            this.m_dtcCure,
            this.m_dtcMend,
            this.m_dtcNoCure,
            this.m_dtcDeath,
            this.m_dtcOther,
            this.m_dtcNormal,
            this.m_dtcStatc,
            this.m_dtcICD});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "OtherDiagnosis";
            // 
            // m_dtcDiaCon
            // 
            this.m_dtcDiaCon.Format = "";
            this.m_dtcDiaCon.FormatInfo = null;
            this.m_dtcDiaCon.HeaderText = "诊断内容";
            this.m_dtcDiaCon.MappingName = "诊断内容";
            this.m_dtcDiaCon.Width = 225;
            // 
            // m_dtcCure
            // 
            this.m_dtcCure.HeaderText = "治愈";
            this.m_dtcCure.MappingName = "治愈";
            this.m_dtcCure.Width = 50;
            // 
            // m_dtcMend
            // 
            this.m_dtcMend.HeaderText = "好转";
            this.m_dtcMend.MappingName = "好转";
            this.m_dtcMend.Width = 50;
            // 
            // m_dtcNoCure
            // 
            this.m_dtcNoCure.HeaderText = "未愈";
            this.m_dtcNoCure.MappingName = "未愈";
            this.m_dtcNoCure.Width = 50;
            // 
            // m_dtcDeath
            // 
            this.m_dtcDeath.HeaderText = "死亡";
            this.m_dtcDeath.MappingName = "死亡";
            this.m_dtcDeath.Width = 50;
            // 
            // m_dtcOther
            // 
            this.m_dtcOther.HeaderText = "其他";
            this.m_dtcOther.MappingName = "其他";
            this.m_dtcOther.Width = 50;
            // 
            // m_dtcNormal
            // 
            this.m_dtcNormal.HeaderText = "正常分娩";
            this.m_dtcNormal.MappingName = "正常分娩";
            this.m_dtcNormal.Width = 70;
            // 
            // m_dtcStatc
            // 
            this.m_dtcStatc.Format = "";
            this.m_dtcStatc.FormatInfo = null;
            this.m_dtcStatc.HeaderText = "统计码";
            this.m_dtcStatc.MappingName = "统计码";
            this.m_dtcStatc.Width = 70;
            // 
            // m_dtcICD
            // 
            this.m_dtcICD.Format = "";
            this.m_dtcICD.FormatInfo = null;
            this.m_dtcICD.HeaderText = "ICD码";
            this.m_dtcICD.MappingName = "ICD码";
            this.m_dtcICD.Width = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_pnlMAINCONDITIONSEQ);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.m_txtICD_10OFMAIN);
            this.groupBox3.Controls.Add(this.m_txtSTATCODEOFMAIN);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.m_txtMainDiagnosis);
            this.groupBox3.Location = new System.Drawing.Point(2, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 94);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出院主要诊断";
            // 
            // m_pnlMAINCONDITIONSEQ
            // 
            this.m_pnlMAINCONDITIONSEQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_txtMainDiagnosisOther);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ0);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ1);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ2);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ3);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ4);
            this.m_pnlMAINCONDITIONSEQ.Controls.Add(this.m_chkMAINCONDITIONSEQ5);
            this.m_pnlMAINCONDITIONSEQ.Location = new System.Drawing.Point(50, 64);
            this.m_pnlMAINCONDITIONSEQ.Name = "m_pnlMAINCONDITIONSEQ";
            this.m_pnlMAINCONDITIONSEQ.Size = new System.Drawing.Size(704, 26);
            this.m_pnlMAINCONDITIONSEQ.TabIndex = 30027;
            // 
            // m_txtMainDiagnosisOther
            // 
            this.m_txtMainDiagnosisOther.AccessibleDescription = "出院主要诊断>>疗效>>其他Text";
            this.m_txtMainDiagnosisOther.BackColor = System.Drawing.Color.White;
            this.m_txtMainDiagnosisOther.Enabled = false;
            this.m_txtMainDiagnosisOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDiagnosisOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtMainDiagnosisOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDiagnosisOther.Location = new System.Drawing.Point(354, 0);
            this.m_txtMainDiagnosisOther.m_BlnIgnoreUserInfo = false;
            this.m_txtMainDiagnosisOther.m_BlnPartControl = false;
            this.m_txtMainDiagnosisOther.m_BlnReadOnly = false;
            this.m_txtMainDiagnosisOther.m_BlnUnderLineDST = false;
            this.m_txtMainDiagnosisOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMainDiagnosisOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMainDiagnosisOther.m_IntCanModifyTime = 6;
            this.m_txtMainDiagnosisOther.m_IntPartControlLength = 0;
            this.m_txtMainDiagnosisOther.m_IntPartControlStartIndex = 0;
            this.m_txtMainDiagnosisOther.m_StrUserID = "";
            this.m_txtMainDiagnosisOther.m_StrUserName = "";
            this.m_txtMainDiagnosisOther.MaxLength = 8000;
            this.m_txtMainDiagnosisOther.Multiline = false;
            this.m_txtMainDiagnosisOther.Name = "m_txtMainDiagnosisOther";
            this.m_txtMainDiagnosisOther.Size = new System.Drawing.Size(242, 24);
            this.m_txtMainDiagnosisOther.TabIndex = 105;
            this.m_txtMainDiagnosisOther.Text = "";
            // 
            // m_chkMAINCONDITIONSEQ0
            // 
            this.m_chkMAINCONDITIONSEQ0.AccessibleDescription = "出院主要诊断>>疗效>>治愈";
            this.m_chkMAINCONDITIONSEQ0.Location = new System.Drawing.Point(4, 0);
            this.m_chkMAINCONDITIONSEQ0.Name = "m_chkMAINCONDITIONSEQ0";
            this.m_chkMAINCONDITIONSEQ0.Size = new System.Drawing.Size(70, 24);
            this.m_chkMAINCONDITIONSEQ0.TabIndex = 80;
            this.m_chkMAINCONDITIONSEQ0.Text = "治愈、";
            this.m_chkMAINCONDITIONSEQ0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMAINCONDITIONSEQ1
            // 
            this.m_chkMAINCONDITIONSEQ1.AccessibleDescription = "出院主要诊断>>疗效>>好转";
            this.m_chkMAINCONDITIONSEQ1.Location = new System.Drawing.Point(78, 0);
            this.m_chkMAINCONDITIONSEQ1.Name = "m_chkMAINCONDITIONSEQ1";
            this.m_chkMAINCONDITIONSEQ1.Size = new System.Drawing.Size(70, 24);
            this.m_chkMAINCONDITIONSEQ1.TabIndex = 85;
            this.m_chkMAINCONDITIONSEQ1.Text = "好转、";
            this.m_chkMAINCONDITIONSEQ1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMAINCONDITIONSEQ2
            // 
            this.m_chkMAINCONDITIONSEQ2.AccessibleDescription = "出院主要诊断>>疗效>>未愈";
            this.m_chkMAINCONDITIONSEQ2.Location = new System.Drawing.Point(154, 0);
            this.m_chkMAINCONDITIONSEQ2.Name = "m_chkMAINCONDITIONSEQ2";
            this.m_chkMAINCONDITIONSEQ2.Size = new System.Drawing.Size(70, 24);
            this.m_chkMAINCONDITIONSEQ2.TabIndex = 90;
            this.m_chkMAINCONDITIONSEQ2.Text = "未愈、";
            this.m_chkMAINCONDITIONSEQ2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMAINCONDITIONSEQ3
            // 
            this.m_chkMAINCONDITIONSEQ3.AccessibleDescription = "出院主要诊断>>疗效>>死亡";
            this.m_chkMAINCONDITIONSEQ3.Location = new System.Drawing.Point(228, 0);
            this.m_chkMAINCONDITIONSEQ3.Name = "m_chkMAINCONDITIONSEQ3";
            this.m_chkMAINCONDITIONSEQ3.Size = new System.Drawing.Size(70, 24);
            this.m_chkMAINCONDITIONSEQ3.TabIndex = 95;
            this.m_chkMAINCONDITIONSEQ3.Text = "死亡、";
            this.m_chkMAINCONDITIONSEQ3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMAINCONDITIONSEQ4
            // 
            this.m_chkMAINCONDITIONSEQ4.AccessibleDescription = "出院主要诊断>>疗效>>其他";
            this.m_chkMAINCONDITIONSEQ4.Location = new System.Drawing.Point(302, 0);
            this.m_chkMAINCONDITIONSEQ4.Name = "m_chkMAINCONDITIONSEQ4";
            this.m_chkMAINCONDITIONSEQ4.Size = new System.Drawing.Size(70, 24);
            this.m_chkMAINCONDITIONSEQ4.TabIndex = 100;
            this.m_chkMAINCONDITIONSEQ4.Text = "其他";
            this.m_chkMAINCONDITIONSEQ4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMAINCONDITIONSEQ5
            // 
            this.m_chkMAINCONDITIONSEQ5.AccessibleDescription = "出院主要诊断>>疗效>>正常分娩";
            this.m_chkMAINCONDITIONSEQ5.Location = new System.Drawing.Point(608, 0);
            this.m_chkMAINCONDITIONSEQ5.Name = "m_chkMAINCONDITIONSEQ5";
            this.m_chkMAINCONDITIONSEQ5.Size = new System.Drawing.Size(90, 24);
            this.m_chkMAINCONDITIONSEQ5.TabIndex = 110;
            this.m_chkMAINCONDITIONSEQ5.Text = "正常分娩";
            this.m_chkMAINCONDITIONSEQ5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 14);
            this.label22.TabIndex = 30026;
            this.label22.Text = "疗效:";
            // 
            // m_txtICD_10OFMAIN
            // 
            this.m_txtICD_10OFMAIN.AccessibleDescription = "出院主要诊断ICD码";
            this.m_txtICD_10OFMAIN.BackColor = System.Drawing.Color.White;
            this.m_txtICD_10OFMAIN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICD_10OFMAIN.ForeColor = System.Drawing.Color.Black;
            this.m_txtICD_10OFMAIN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICD_10OFMAIN.Location = new System.Drawing.Point(630, 40);
            this.m_txtICD_10OFMAIN.m_BlnIgnoreUserInfo = false;
            this.m_txtICD_10OFMAIN.m_BlnPartControl = false;
            this.m_txtICD_10OFMAIN.m_BlnReadOnly = false;
            this.m_txtICD_10OFMAIN.m_BlnUnderLineDST = false;
            this.m_txtICD_10OFMAIN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICD_10OFMAIN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICD_10OFMAIN.m_IntCanModifyTime = 6;
            this.m_txtICD_10OFMAIN.m_IntPartControlLength = 0;
            this.m_txtICD_10OFMAIN.m_IntPartControlStartIndex = 0;
            this.m_txtICD_10OFMAIN.m_StrUserID = "";
            this.m_txtICD_10OFMAIN.m_StrUserName = "";
            this.m_txtICD_10OFMAIN.MaxLength = 15;
            this.m_txtICD_10OFMAIN.Multiline = false;
            this.m_txtICD_10OFMAIN.Name = "m_txtICD_10OFMAIN";
            this.m_txtICD_10OFMAIN.Size = new System.Drawing.Size(126, 24);
            this.m_txtICD_10OFMAIN.TabIndex = 75;
            this.m_txtICD_10OFMAIN.Text = "";
            // 
            // m_txtSTATCODEOFMAIN
            // 
            this.m_txtSTATCODEOFMAIN.AccessibleDescription = "出院主要诊断统计码";
            this.m_txtSTATCODEOFMAIN.BackColor = System.Drawing.Color.White;
            this.m_txtSTATCODEOFMAIN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTATCODEOFMAIN.ForeColor = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFMAIN.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTATCODEOFMAIN.Location = new System.Drawing.Point(630, 14);
            this.m_txtSTATCODEOFMAIN.m_BlnIgnoreUserInfo = false;
            this.m_txtSTATCODEOFMAIN.m_BlnPartControl = false;
            this.m_txtSTATCODEOFMAIN.m_BlnReadOnly = false;
            this.m_txtSTATCODEOFMAIN.m_BlnUnderLineDST = false;
            this.m_txtSTATCODEOFMAIN.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTATCODEOFMAIN.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFMAIN.m_IntCanModifyTime = 6;
            this.m_txtSTATCODEOFMAIN.m_IntPartControlLength = 0;
            this.m_txtSTATCODEOFMAIN.m_IntPartControlStartIndex = 0;
            this.m_txtSTATCODEOFMAIN.m_StrUserID = "";
            this.m_txtSTATCODEOFMAIN.m_StrUserName = "";
            this.m_txtSTATCODEOFMAIN.MaxLength = 15;
            this.m_txtSTATCODEOFMAIN.Multiline = false;
            this.m_txtSTATCODEOFMAIN.Name = "m_txtSTATCODEOFMAIN";
            this.m_txtSTATCODEOFMAIN.Size = new System.Drawing.Size(126, 24);
            this.m_txtSTATCODEOFMAIN.TabIndex = 70;
            this.m_txtSTATCODEOFMAIN.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(572, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 14);
            this.label20.TabIndex = 30022;
            this.label20.Text = "统计码:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(580, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 14);
            this.label21.TabIndex = 30023;
            this.label21.Text = "ICD码:";
            // 
            // m_txtMainDiagnosis
            // 
            this.m_txtMainDiagnosis.AccessibleDescription = "出院主要诊断";
            this.m_txtMainDiagnosis.BackColor = System.Drawing.Color.White;
            this.m_txtMainDiagnosis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMainDiagnosis.ForeColor = System.Drawing.Color.Black;
            this.m_txtMainDiagnosis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtMainDiagnosis.Location = new System.Drawing.Point(6, 16);
            this.m_txtMainDiagnosis.m_BlnIgnoreUserInfo = false;
            this.m_txtMainDiagnosis.m_BlnPartControl = false;
            this.m_txtMainDiagnosis.m_BlnReadOnly = false;
            this.m_txtMainDiagnosis.m_BlnUnderLineDST = false;
            this.m_txtMainDiagnosis.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtMainDiagnosis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtMainDiagnosis.m_IntCanModifyTime = 6;
            this.m_txtMainDiagnosis.m_IntPartControlLength = 0;
            this.m_txtMainDiagnosis.m_IntPartControlStartIndex = 0;
            this.m_txtMainDiagnosis.m_StrUserID = "";
            this.m_txtMainDiagnosis.m_StrUserName = "";
            this.m_txtMainDiagnosis.MaxLength = 8000;
            this.m_txtMainDiagnosis.Name = "m_txtMainDiagnosis";
            this.m_txtMainDiagnosis.Size = new System.Drawing.Size(558, 46);
            this.m_txtMainDiagnosis.TabIndex = 65;
            this.m_txtMainDiagnosis.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_pnlINFECTIONCONDICTIONSEQ);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.m_txtICD_10OFINFECTION);
            this.groupBox5.Controls.Add(this.m_txtSTATCODEOFINFECTION);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.m_txtINFECTIONDIAGNOSIS);
            this.groupBox5.Location = new System.Drawing.Point(2, 296);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(762, 94);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "院内感染名称";
            // 
            // m_pnlINFECTIONCONDICTIONSEQ
            // 
            this.m_pnlINFECTIONCONDICTIONSEQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_txtINFECTIONDIAGNOSISOther);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ0);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ1);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ2);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ3);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ4);
            this.m_pnlINFECTIONCONDICTIONSEQ.Controls.Add(this.m_chkINFECTIONCONDICTIONSEQ5);
            this.m_pnlINFECTIONCONDICTIONSEQ.Location = new System.Drawing.Point(50, 64);
            this.m_pnlINFECTIONCONDICTIONSEQ.Name = "m_pnlINFECTIONCONDICTIONSEQ";
            this.m_pnlINFECTIONCONDICTIONSEQ.Size = new System.Drawing.Size(704, 26);
            this.m_pnlINFECTIONCONDICTIONSEQ.TabIndex = 30027;
            // 
            // m_txtINFECTIONDIAGNOSISOther
            // 
            this.m_txtINFECTIONDIAGNOSISOther.AccessibleDescription = "院内感染名称>>疗效>>其他Text";
            this.m_txtINFECTIONDIAGNOSISOther.BackColor = System.Drawing.Color.White;
            this.m_txtINFECTIONDIAGNOSISOther.Enabled = false;
            this.m_txtINFECTIONDIAGNOSISOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFECTIONDIAGNOSISOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtINFECTIONDIAGNOSISOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFECTIONDIAGNOSISOther.Location = new System.Drawing.Point(354, 0);
            this.m_txtINFECTIONDIAGNOSISOther.m_BlnIgnoreUserInfo = false;
            this.m_txtINFECTIONDIAGNOSISOther.m_BlnPartControl = false;
            this.m_txtINFECTIONDIAGNOSISOther.m_BlnReadOnly = false;
            this.m_txtINFECTIONDIAGNOSISOther.m_BlnUnderLineDST = false;
            this.m_txtINFECTIONDIAGNOSISOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFECTIONDIAGNOSISOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFECTIONDIAGNOSISOther.m_IntCanModifyTime = 6;
            this.m_txtINFECTIONDIAGNOSISOther.m_IntPartControlLength = 0;
            this.m_txtINFECTIONDIAGNOSISOther.m_IntPartControlStartIndex = 0;
            this.m_txtINFECTIONDIAGNOSISOther.m_StrUserID = "";
            this.m_txtINFECTIONDIAGNOSISOther.m_StrUserName = "";
            this.m_txtINFECTIONDIAGNOSISOther.MaxLength = 8000;
            this.m_txtINFECTIONDIAGNOSISOther.Multiline = false;
            this.m_txtINFECTIONDIAGNOSISOther.Name = "m_txtINFECTIONDIAGNOSISOther";
            this.m_txtINFECTIONDIAGNOSISOther.Size = new System.Drawing.Size(242, 24);
            this.m_txtINFECTIONDIAGNOSISOther.TabIndex = 205;
            this.m_txtINFECTIONDIAGNOSISOther.Text = "";
            // 
            // m_chkINFECTIONCONDICTIONSEQ0
            // 
            this.m_chkINFECTIONCONDICTIONSEQ0.AccessibleDescription = "院内感染名称>>疗效>>治愈";
            this.m_chkINFECTIONCONDICTIONSEQ0.Location = new System.Drawing.Point(4, 0);
            this.m_chkINFECTIONCONDICTIONSEQ0.Name = "m_chkINFECTIONCONDICTIONSEQ0";
            this.m_chkINFECTIONCONDICTIONSEQ0.Size = new System.Drawing.Size(70, 24);
            this.m_chkINFECTIONCONDICTIONSEQ0.TabIndex = 180;
            this.m_chkINFECTIONCONDICTIONSEQ0.Text = "治愈、";
            this.m_chkINFECTIONCONDICTIONSEQ0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkINFECTIONCONDICTIONSEQ1
            // 
            this.m_chkINFECTIONCONDICTIONSEQ1.AccessibleDescription = "院内感染名称>>疗效>>好转";
            this.m_chkINFECTIONCONDICTIONSEQ1.Location = new System.Drawing.Point(78, 0);
            this.m_chkINFECTIONCONDICTIONSEQ1.Name = "m_chkINFECTIONCONDICTIONSEQ1";
            this.m_chkINFECTIONCONDICTIONSEQ1.Size = new System.Drawing.Size(70, 24);
            this.m_chkINFECTIONCONDICTIONSEQ1.TabIndex = 185;
            this.m_chkINFECTIONCONDICTIONSEQ1.Text = "好转、";
            this.m_chkINFECTIONCONDICTIONSEQ1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkINFECTIONCONDICTIONSEQ2
            // 
            this.m_chkINFECTIONCONDICTIONSEQ2.AccessibleDescription = "院内感染名称>>疗效>>未愈";
            this.m_chkINFECTIONCONDICTIONSEQ2.Location = new System.Drawing.Point(154, 0);
            this.m_chkINFECTIONCONDICTIONSEQ2.Name = "m_chkINFECTIONCONDICTIONSEQ2";
            this.m_chkINFECTIONCONDICTIONSEQ2.Size = new System.Drawing.Size(70, 24);
            this.m_chkINFECTIONCONDICTIONSEQ2.TabIndex = 190;
            this.m_chkINFECTIONCONDICTIONSEQ2.Text = "未愈、";
            this.m_chkINFECTIONCONDICTIONSEQ2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkINFECTIONCONDICTIONSEQ3
            // 
            this.m_chkINFECTIONCONDICTIONSEQ3.AccessibleDescription = "院内感染名称>>疗效>>死亡";
            this.m_chkINFECTIONCONDICTIONSEQ3.Location = new System.Drawing.Point(228, 0);
            this.m_chkINFECTIONCONDICTIONSEQ3.Name = "m_chkINFECTIONCONDICTIONSEQ3";
            this.m_chkINFECTIONCONDICTIONSEQ3.Size = new System.Drawing.Size(70, 24);
            this.m_chkINFECTIONCONDICTIONSEQ3.TabIndex = 195;
            this.m_chkINFECTIONCONDICTIONSEQ3.Text = "死亡、";
            this.m_chkINFECTIONCONDICTIONSEQ3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkINFECTIONCONDICTIONSEQ4
            // 
            this.m_chkINFECTIONCONDICTIONSEQ4.AccessibleDescription = "院内感染名称>>疗效>>其他";
            this.m_chkINFECTIONCONDICTIONSEQ4.Location = new System.Drawing.Point(302, 0);
            this.m_chkINFECTIONCONDICTIONSEQ4.Name = "m_chkINFECTIONCONDICTIONSEQ4";
            this.m_chkINFECTIONCONDICTIONSEQ4.Size = new System.Drawing.Size(70, 24);
            this.m_chkINFECTIONCONDICTIONSEQ4.TabIndex = 200;
            this.m_chkINFECTIONCONDICTIONSEQ4.Text = "其他";
            this.m_chkINFECTIONCONDICTIONSEQ4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkINFECTIONCONDICTIONSEQ5
            // 
            this.m_chkINFECTIONCONDICTIONSEQ5.AccessibleDescription = "院内感染名称>>疗效>>正常分娩";
            this.m_chkINFECTIONCONDICTIONSEQ5.Location = new System.Drawing.Point(608, 0);
            this.m_chkINFECTIONCONDICTIONSEQ5.Name = "m_chkINFECTIONCONDICTIONSEQ5";
            this.m_chkINFECTIONCONDICTIONSEQ5.Size = new System.Drawing.Size(90, 24);
            this.m_chkINFECTIONCONDICTIONSEQ5.TabIndex = 210;
            this.m_chkINFECTIONCONDICTIONSEQ5.Text = "正常分娩";
            this.m_chkINFECTIONCONDICTIONSEQ5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 14);
            this.label26.TabIndex = 30026;
            this.label26.Text = "疗效:";
            // 
            // m_txtICD_10OFINFECTION
            // 
            this.m_txtICD_10OFINFECTION.AccessibleDescription = "院内感染名称>>";
            this.m_txtICD_10OFINFECTION.BackColor = System.Drawing.Color.White;
            this.m_txtICD_10OFINFECTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICD_10OFINFECTION.ForeColor = System.Drawing.Color.Black;
            this.m_txtICD_10OFINFECTION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICD_10OFINFECTION.Location = new System.Drawing.Point(630, 40);
            this.m_txtICD_10OFINFECTION.m_BlnIgnoreUserInfo = false;
            this.m_txtICD_10OFINFECTION.m_BlnPartControl = false;
            this.m_txtICD_10OFINFECTION.m_BlnReadOnly = false;
            this.m_txtICD_10OFINFECTION.m_BlnUnderLineDST = false;
            this.m_txtICD_10OFINFECTION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICD_10OFINFECTION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICD_10OFINFECTION.m_IntCanModifyTime = 6;
            this.m_txtICD_10OFINFECTION.m_IntPartControlLength = 0;
            this.m_txtICD_10OFINFECTION.m_IntPartControlStartIndex = 0;
            this.m_txtICD_10OFINFECTION.m_StrUserID = "";
            this.m_txtICD_10OFINFECTION.m_StrUserName = "";
            this.m_txtICD_10OFINFECTION.MaxLength = 15;
            this.m_txtICD_10OFINFECTION.Multiline = false;
            this.m_txtICD_10OFINFECTION.Name = "m_txtICD_10OFINFECTION";
            this.m_txtICD_10OFINFECTION.Size = new System.Drawing.Size(126, 24);
            this.m_txtICD_10OFINFECTION.TabIndex = 175;
            this.m_txtICD_10OFINFECTION.Text = "";
            // 
            // m_txtSTATCODEOFINFECTION
            // 
            this.m_txtSTATCODEOFINFECTION.AccessibleDescription = "院内感染名称>>统计码";
            this.m_txtSTATCODEOFINFECTION.BackColor = System.Drawing.Color.White;
            this.m_txtSTATCODEOFINFECTION.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTATCODEOFINFECTION.ForeColor = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFINFECTION.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTATCODEOFINFECTION.Location = new System.Drawing.Point(630, 14);
            this.m_txtSTATCODEOFINFECTION.m_BlnIgnoreUserInfo = false;
            this.m_txtSTATCODEOFINFECTION.m_BlnPartControl = false;
            this.m_txtSTATCODEOFINFECTION.m_BlnReadOnly = false;
            this.m_txtSTATCODEOFINFECTION.m_BlnUnderLineDST = false;
            this.m_txtSTATCODEOFINFECTION.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTATCODEOFINFECTION.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFINFECTION.m_IntCanModifyTime = 6;
            this.m_txtSTATCODEOFINFECTION.m_IntPartControlLength = 0;
            this.m_txtSTATCODEOFINFECTION.m_IntPartControlStartIndex = 0;
            this.m_txtSTATCODEOFINFECTION.m_StrUserID = "";
            this.m_txtSTATCODEOFINFECTION.m_StrUserName = "";
            this.m_txtSTATCODEOFINFECTION.MaxLength = 15;
            this.m_txtSTATCODEOFINFECTION.Multiline = false;
            this.m_txtSTATCODEOFINFECTION.Name = "m_txtSTATCODEOFINFECTION";
            this.m_txtSTATCODEOFINFECTION.Size = new System.Drawing.Size(126, 24);
            this.m_txtSTATCODEOFINFECTION.TabIndex = 170;
            this.m_txtSTATCODEOFINFECTION.Text = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(572, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 14);
            this.label27.TabIndex = 30022;
            this.label27.Text = "统计码:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(580, 43);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 14);
            this.label28.TabIndex = 30023;
            this.label28.Text = "ICD码:";
            // 
            // m_txtINFECTIONDIAGNOSIS
            // 
            this.m_txtINFECTIONDIAGNOSIS.AccessibleDescription = "院内感染名称";
            this.m_txtINFECTIONDIAGNOSIS.BackColor = System.Drawing.Color.White;
            this.m_txtINFECTIONDIAGNOSIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtINFECTIONDIAGNOSIS.ForeColor = System.Drawing.Color.Black;
            this.m_txtINFECTIONDIAGNOSIS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtINFECTIONDIAGNOSIS.Location = new System.Drawing.Point(6, 16);
            this.m_txtINFECTIONDIAGNOSIS.m_BlnIgnoreUserInfo = false;
            this.m_txtINFECTIONDIAGNOSIS.m_BlnPartControl = false;
            this.m_txtINFECTIONDIAGNOSIS.m_BlnReadOnly = false;
            this.m_txtINFECTIONDIAGNOSIS.m_BlnUnderLineDST = false;
            this.m_txtINFECTIONDIAGNOSIS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtINFECTIONDIAGNOSIS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtINFECTIONDIAGNOSIS.m_IntCanModifyTime = 6;
            this.m_txtINFECTIONDIAGNOSIS.m_IntPartControlLength = 0;
            this.m_txtINFECTIONDIAGNOSIS.m_IntPartControlStartIndex = 0;
            this.m_txtINFECTIONDIAGNOSIS.m_StrUserID = "";
            this.m_txtINFECTIONDIAGNOSIS.m_StrUserName = "";
            this.m_txtINFECTIONDIAGNOSIS.MaxLength = 8000;
            this.m_txtINFECTIONDIAGNOSIS.Name = "m_txtINFECTIONDIAGNOSIS";
            this.m_txtINFECTIONDIAGNOSIS.Size = new System.Drawing.Size(558, 46);
            this.m_txtINFECTIONDIAGNOSIS.TabIndex = 165;
            this.m_txtINFECTIONDIAGNOSIS.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_pnlPATHOLOGYDIAGNOSISSEQ);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.m_txtICD_10OFPATHOLOGYDIA);
            this.groupBox6.Controls.Add(this.m_txtSTATCODEOFPATHOLOGYDIA);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.m_txtPATHOLOGYDIAGNOSIS);
            this.groupBox6.Location = new System.Drawing.Point(2, 394);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(762, 94);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "病理诊断";
            // 
            // m_pnlPATHOLOGYDIAGNOSISSEQ
            // 
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_txtPATHOLOGYDIAGNOSISOther);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ0);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ1);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ2);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ3);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ4);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Controls.Add(this.m_chkPATHOLOGYDIAGNOSISSEQ5);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Location = new System.Drawing.Point(50, 64);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Name = "m_pnlPATHOLOGYDIAGNOSISSEQ";
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.Size = new System.Drawing.Size(704, 26);
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.TabIndex = 30027;
            // 
            // m_txtPATHOLOGYDIAGNOSISOther
            // 
            this.m_txtPATHOLOGYDIAGNOSISOther.AccessibleDescription = "病理诊断>>疗效>>其他Text";
            this.m_txtPATHOLOGYDIAGNOSISOther.BackColor = System.Drawing.Color.White;
            this.m_txtPATHOLOGYDIAGNOSISOther.Enabled = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPATHOLOGYDIAGNOSISOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtPATHOLOGYDIAGNOSISOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPATHOLOGYDIAGNOSISOther.Location = new System.Drawing.Point(354, 0);
            this.m_txtPATHOLOGYDIAGNOSISOther.m_BlnIgnoreUserInfo = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_BlnPartControl = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_BlnReadOnly = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_BlnUnderLineDST = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_IntCanModifyTime = 6;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_IntPartControlLength = 0;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_IntPartControlStartIndex = 0;
            this.m_txtPATHOLOGYDIAGNOSISOther.m_StrUserID = "";
            this.m_txtPATHOLOGYDIAGNOSISOther.m_StrUserName = "";
            this.m_txtPATHOLOGYDIAGNOSISOther.MaxLength = 8000;
            this.m_txtPATHOLOGYDIAGNOSISOther.Multiline = false;
            this.m_txtPATHOLOGYDIAGNOSISOther.Name = "m_txtPATHOLOGYDIAGNOSISOther";
            this.m_txtPATHOLOGYDIAGNOSISOther.Size = new System.Drawing.Size(242, 24);
            this.m_txtPATHOLOGYDIAGNOSISOther.TabIndex = 255;
            this.m_txtPATHOLOGYDIAGNOSISOther.Text = "";
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ0
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.AccessibleDescription = "病理诊断>>疗效>>治愈";
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.Location = new System.Drawing.Point(4, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.Name = "m_chkPATHOLOGYDIAGNOSISSEQ0";
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.Size = new System.Drawing.Size(70, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.TabIndex = 230;
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.Text = "治愈、";
            this.m_chkPATHOLOGYDIAGNOSISSEQ0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ1
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.AccessibleDescription = "病理诊断>>疗效>>好转";
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.Location = new System.Drawing.Point(78, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.Name = "m_chkPATHOLOGYDIAGNOSISSEQ1";
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.Size = new System.Drawing.Size(70, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.TabIndex = 235;
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.Text = "好转、";
            this.m_chkPATHOLOGYDIAGNOSISSEQ1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ2
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.AccessibleDescription = "病理诊断>>疗效>>未愈";
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.Location = new System.Drawing.Point(154, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.Name = "m_chkPATHOLOGYDIAGNOSISSEQ2";
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.Size = new System.Drawing.Size(70, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.TabIndex = 240;
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.Text = "未愈、";
            this.m_chkPATHOLOGYDIAGNOSISSEQ2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ3
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.AccessibleDescription = "病理诊断>>疗效>>死亡";
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.Location = new System.Drawing.Point(228, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.Name = "m_chkPATHOLOGYDIAGNOSISSEQ3";
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.Size = new System.Drawing.Size(70, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.TabIndex = 245;
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.Text = "死亡、";
            this.m_chkPATHOLOGYDIAGNOSISSEQ3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ4
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.Location = new System.Drawing.Point(302, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.Name = "m_chkPATHOLOGYDIAGNOSISSEQ4";
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.Size = new System.Drawing.Size(70, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.TabIndex = 250;
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.Text = "其他";
            this.m_chkPATHOLOGYDIAGNOSISSEQ4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOLOGYDIAGNOSISSEQ5
            // 
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.AccessibleDescription = "病理诊断>>疗效>>正常分娩";
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.Location = new System.Drawing.Point(608, 0);
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.Name = "m_chkPATHOLOGYDIAGNOSISSEQ5";
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.Size = new System.Drawing.Size(90, 24);
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.TabIndex = 260;
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.Text = "正常分娩";
            this.m_chkPATHOLOGYDIAGNOSISSEQ5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 14);
            this.label29.TabIndex = 30026;
            this.label29.Text = "疗效:";
            // 
            // m_txtICD_10OFPATHOLOGYDIA
            // 
            this.m_txtICD_10OFPATHOLOGYDIA.AccessibleDescription = "病理诊断>>ICD码";
            this.m_txtICD_10OFPATHOLOGYDIA.BackColor = System.Drawing.Color.White;
            this.m_txtICD_10OFPATHOLOGYDIA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtICD_10OFPATHOLOGYDIA.ForeColor = System.Drawing.Color.Black;
            this.m_txtICD_10OFPATHOLOGYDIA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtICD_10OFPATHOLOGYDIA.Location = new System.Drawing.Point(630, 40);
            this.m_txtICD_10OFPATHOLOGYDIA.m_BlnIgnoreUserInfo = false;
            this.m_txtICD_10OFPATHOLOGYDIA.m_BlnPartControl = false;
            this.m_txtICD_10OFPATHOLOGYDIA.m_BlnReadOnly = false;
            this.m_txtICD_10OFPATHOLOGYDIA.m_BlnUnderLineDST = false;
            this.m_txtICD_10OFPATHOLOGYDIA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtICD_10OFPATHOLOGYDIA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtICD_10OFPATHOLOGYDIA.m_IntCanModifyTime = 6;
            this.m_txtICD_10OFPATHOLOGYDIA.m_IntPartControlLength = 0;
            this.m_txtICD_10OFPATHOLOGYDIA.m_IntPartControlStartIndex = 0;
            this.m_txtICD_10OFPATHOLOGYDIA.m_StrUserID = "";
            this.m_txtICD_10OFPATHOLOGYDIA.m_StrUserName = "";
            this.m_txtICD_10OFPATHOLOGYDIA.MaxLength = 15;
            this.m_txtICD_10OFPATHOLOGYDIA.Multiline = false;
            this.m_txtICD_10OFPATHOLOGYDIA.Name = "m_txtICD_10OFPATHOLOGYDIA";
            this.m_txtICD_10OFPATHOLOGYDIA.Size = new System.Drawing.Size(126, 24);
            this.m_txtICD_10OFPATHOLOGYDIA.TabIndex = 225;
            this.m_txtICD_10OFPATHOLOGYDIA.Text = "";
            // 
            // m_txtSTATCODEOFPATHOLOGYDIA
            // 
            this.m_txtSTATCODEOFPATHOLOGYDIA.AccessibleDescription = "病理诊断>>统计码";
            this.m_txtSTATCODEOFPATHOLOGYDIA.BackColor = System.Drawing.Color.White;
            this.m_txtSTATCODEOFPATHOLOGYDIA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSTATCODEOFPATHOLOGYDIA.ForeColor = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFPATHOLOGYDIA.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSTATCODEOFPATHOLOGYDIA.Location = new System.Drawing.Point(630, 14);
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_BlnIgnoreUserInfo = false;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_BlnPartControl = false;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_BlnReadOnly = false;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_BlnUnderLineDST = false;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_IntCanModifyTime = 6;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_IntPartControlLength = 0;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_IntPartControlStartIndex = 0;
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_StrUserID = "";
            this.m_txtSTATCODEOFPATHOLOGYDIA.m_StrUserName = "";
            this.m_txtSTATCODEOFPATHOLOGYDIA.MaxLength = 15;
            this.m_txtSTATCODEOFPATHOLOGYDIA.Multiline = false;
            this.m_txtSTATCODEOFPATHOLOGYDIA.Name = "m_txtSTATCODEOFPATHOLOGYDIA";
            this.m_txtSTATCODEOFPATHOLOGYDIA.Size = new System.Drawing.Size(126, 24);
            this.m_txtSTATCODEOFPATHOLOGYDIA.TabIndex = 220;
            this.m_txtSTATCODEOFPATHOLOGYDIA.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(572, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 14);
            this.label30.TabIndex = 30022;
            this.label30.Text = "统计码:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(580, 43);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 14);
            this.label31.TabIndex = 30023;
            this.label31.Text = "ICD码:";
            // 
            // m_txtPATHOLOGYDIAGNOSIS
            // 
            this.m_txtPATHOLOGYDIAGNOSIS.AccessibleDescription = "病理诊断";
            this.m_txtPATHOLOGYDIAGNOSIS.BackColor = System.Drawing.Color.White;
            this.m_txtPATHOLOGYDIAGNOSIS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPATHOLOGYDIAGNOSIS.ForeColor = System.Drawing.Color.Black;
            this.m_txtPATHOLOGYDIAGNOSIS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPATHOLOGYDIAGNOSIS.Location = new System.Drawing.Point(6, 16);
            this.m_txtPATHOLOGYDIAGNOSIS.m_BlnIgnoreUserInfo = false;
            this.m_txtPATHOLOGYDIAGNOSIS.m_BlnPartControl = false;
            this.m_txtPATHOLOGYDIAGNOSIS.m_BlnReadOnly = false;
            this.m_txtPATHOLOGYDIAGNOSIS.m_BlnUnderLineDST = false;
            this.m_txtPATHOLOGYDIAGNOSIS.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPATHOLOGYDIAGNOSIS.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPATHOLOGYDIAGNOSIS.m_IntCanModifyTime = 6;
            this.m_txtPATHOLOGYDIAGNOSIS.m_IntPartControlLength = 0;
            this.m_txtPATHOLOGYDIAGNOSIS.m_IntPartControlStartIndex = 0;
            this.m_txtPATHOLOGYDIAGNOSIS.m_StrUserID = "";
            this.m_txtPATHOLOGYDIAGNOSIS.m_StrUserName = "";
            this.m_txtPATHOLOGYDIAGNOSIS.MaxLength = 8000;
            this.m_txtPATHOLOGYDIAGNOSIS.Name = "m_txtPATHOLOGYDIAGNOSIS";
            this.m_txtPATHOLOGYDIAGNOSIS.Size = new System.Drawing.Size(558, 46);
            this.m_txtPATHOLOGYDIAGNOSIS.TabIndex = 215;
            this.m_txtPATHOLOGYDIAGNOSIS.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_txtSALVESUCCESS);
            this.tabPage3.Controls.Add(this.m_txtSALVETIMES);
            this.tabPage3.Controls.Add(this.m_txtREMINDTERM);
            this.tabPage3.Controls.Add(this.m_pnlHASREMIND);
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.lsvOperationEmployee);
            this.tabPage3.Controls.Add(this.lsvAanaesthesiaMode);
            this.tabPage3.Controls.Add(this.dtgOperation);
            this.tabPage3.Controls.Add(this.m_cboHBsAg);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.m_pnlNEW5DISEASE);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.m_txtScacheSource);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Controls.Add(this.m_pnlSECONDLEVELTRANSFER);
            this.tabPage3.Controls.Add(this.label34);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.m_txtSENSITIVE);
            this.tabPage3.Controls.Add(this.m_cboHCV_Ab);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.m_cboHIV_Ab);
            this.tabPage3.Controls.Add(this.label38);
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.ImageIndex = 4;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(766, 491);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "手术资料";
            // 
            // m_txtSALVESUCCESS
            // 
            this.m_txtSALVESUCCESS.AccessibleDescription = "抢救成功次数";
            this.m_txtSALVESUCCESS.Location = new System.Drawing.Point(283, 456);
            this.m_txtSALVESUCCESS.Name = "m_txtSALVESUCCESS";
            this.m_txtSALVESUCCESS.Size = new System.Drawing.Size(100, 23);
            this.m_txtSALVESUCCESS.TabIndex = 340;
            this.m_txtSALVESUCCESS.MouseLeave += new System.EventHandler(this.m_txtCheckIntType_MouseLeave);
            this.m_txtSALVESUCCESS.Leave += new System.EventHandler(this.m_txtCheckIntType_Leave);
            // 
            // m_txtSALVETIMES
            // 
            this.m_txtSALVETIMES.AccessibleDescription = "抢救次数";
            this.m_txtSALVETIMES.Location = new System.Drawing.Point(77, 456);
            this.m_txtSALVETIMES.Name = "m_txtSALVETIMES";
            this.m_txtSALVETIMES.Size = new System.Drawing.Size(98, 23);
            this.m_txtSALVETIMES.TabIndex = 335;
            this.m_txtSALVETIMES.MouseLeave += new System.EventHandler(this.m_txtCheckIntType_MouseLeave);
            this.m_txtSALVETIMES.Leave += new System.EventHandler(this.m_txtCheckIntType_Leave);
            // 
            // m_txtREMINDTERM
            // 
            this.m_txtREMINDTERM.AccessibleDescription = "随诊期限";
            this.m_txtREMINDTERM.BackColor = System.Drawing.Color.White;
            this.m_txtREMINDTERM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtREMINDTERM.ForeColor = System.Drawing.Color.Black;
            this.m_txtREMINDTERM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtREMINDTERM.Location = new System.Drawing.Point(642, 456);
            this.m_txtREMINDTERM.m_BlnIgnoreUserInfo = false;
            this.m_txtREMINDTERM.m_BlnPartControl = false;
            this.m_txtREMINDTERM.m_BlnReadOnly = false;
            this.m_txtREMINDTERM.m_BlnUnderLineDST = false;
            this.m_txtREMINDTERM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtREMINDTERM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtREMINDTERM.m_IntCanModifyTime = 6;
            this.m_txtREMINDTERM.m_IntPartControlLength = 0;
            this.m_txtREMINDTERM.m_IntPartControlStartIndex = 0;
            this.m_txtREMINDTERM.m_StrUserID = "";
            this.m_txtREMINDTERM.m_StrUserName = "";
            this.m_txtREMINDTERM.MaxLength = 8000;
            this.m_txtREMINDTERM.Multiline = false;
            this.m_txtREMINDTERM.Name = "m_txtREMINDTERM";
            this.m_txtREMINDTERM.Size = new System.Drawing.Size(112, 22);
            this.m_txtREMINDTERM.TabIndex = 355;
            this.m_txtREMINDTERM.Text = "";
            // 
            // m_pnlHASREMIND
            // 
            this.m_pnlHASREMIND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlHASREMIND.Controls.Add(this.m_chkHASREMIND2);
            this.m_pnlHASREMIND.Controls.Add(this.m_chkHASREMIND1);
            this.m_pnlHASREMIND.Location = new System.Drawing.Point(442, 452);
            this.m_pnlHASREMIND.Name = "m_pnlHASREMIND";
            this.m_pnlHASREMIND.Size = new System.Drawing.Size(116, 30);
            this.m_pnlHASREMIND.TabIndex = 10000026;
            // 
            // m_chkHASREMIND2
            // 
            this.m_chkHASREMIND2.AccessibleDescription = "随诊>>否";
            this.m_chkHASREMIND2.Location = new System.Drawing.Point(66, 2);
            this.m_chkHASREMIND2.Name = "m_chkHASREMIND2";
            this.m_chkHASREMIND2.Size = new System.Drawing.Size(60, 24);
            this.m_chkHASREMIND2.TabIndex = 350;
            this.m_chkHASREMIND2.Text = "否";
            this.m_chkHASREMIND2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkHASREMIND1
            // 
            this.m_chkHASREMIND1.AccessibleDescription = "随诊>>是";
            this.m_chkHASREMIND1.Location = new System.Drawing.Point(8, 2);
            this.m_chkHASREMIND1.Name = "m_chkHASREMIND1";
            this.m_chkHASREMIND1.Size = new System.Drawing.Size(60, 24);
            this.m_chkHASREMIND1.TabIndex = 345;
            this.m_chkHASREMIND1.Text = "是、";
            this.m_chkHASREMIND1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 458);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(70, 14);
            this.label43.TabIndex = 10000024;
            this.label43.Text = "抢救次数:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label39);
            this.groupBox7.Controls.Add(this.m_txtNEONATEDISEASE1);
            this.groupBox7.Controls.Add(this.m_txtNEONATEDISEASE2);
            this.groupBox7.Controls.Add(this.m_txtNEONATEDISEASE3);
            this.groupBox7.Controls.Add(this.m_txtNEONATEDISEASE4);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Location = new System.Drawing.Point(4, 318);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(758, 126);
            this.groupBox7.TabIndex = 10000023;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "新生儿疾病诊断";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(8, 22);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(21, 14);
            this.label39.TabIndex = 11;
            this.label39.Text = "1.";
            // 
            // m_txtNEONATEDISEASE1
            // 
            this.m_txtNEONATEDISEASE1.AccessibleDescription = "新生儿疾病诊断1";
            this.m_txtNEONATEDISEASE1.BackColor = System.Drawing.Color.White;
            this.m_txtNEONATEDISEASE1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNEONATEDISEASE1.ForeColor = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNEONATEDISEASE1.Location = new System.Drawing.Point(32, 20);
            this.m_txtNEONATEDISEASE1.m_BlnIgnoreUserInfo = false;
            this.m_txtNEONATEDISEASE1.m_BlnPartControl = false;
            this.m_txtNEONATEDISEASE1.m_BlnReadOnly = false;
            this.m_txtNEONATEDISEASE1.m_BlnUnderLineDST = false;
            this.m_txtNEONATEDISEASE1.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNEONATEDISEASE1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE1.m_IntCanModifyTime = 6;
            this.m_txtNEONATEDISEASE1.m_IntPartControlLength = 0;
            this.m_txtNEONATEDISEASE1.m_IntPartControlStartIndex = 0;
            this.m_txtNEONATEDISEASE1.m_StrUserID = "";
            this.m_txtNEONATEDISEASE1.m_StrUserName = "";
            this.m_txtNEONATEDISEASE1.MaxLength = 8000;
            this.m_txtNEONATEDISEASE1.Multiline = false;
            this.m_txtNEONATEDISEASE1.Name = "m_txtNEONATEDISEASE1";
            this.m_txtNEONATEDISEASE1.Size = new System.Drawing.Size(718, 22);
            this.m_txtNEONATEDISEASE1.TabIndex = 315;
            this.m_txtNEONATEDISEASE1.Text = "";
            // 
            // m_txtNEONATEDISEASE2
            // 
            this.m_txtNEONATEDISEASE2.AccessibleDescription = "新生儿疾病诊断2";
            this.m_txtNEONATEDISEASE2.BackColor = System.Drawing.Color.White;
            this.m_txtNEONATEDISEASE2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNEONATEDISEASE2.ForeColor = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNEONATEDISEASE2.Location = new System.Drawing.Point(32, 46);
            this.m_txtNEONATEDISEASE2.m_BlnIgnoreUserInfo = false;
            this.m_txtNEONATEDISEASE2.m_BlnPartControl = false;
            this.m_txtNEONATEDISEASE2.m_BlnReadOnly = false;
            this.m_txtNEONATEDISEASE2.m_BlnUnderLineDST = false;
            this.m_txtNEONATEDISEASE2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNEONATEDISEASE2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE2.m_IntCanModifyTime = 6;
            this.m_txtNEONATEDISEASE2.m_IntPartControlLength = 0;
            this.m_txtNEONATEDISEASE2.m_IntPartControlStartIndex = 0;
            this.m_txtNEONATEDISEASE2.m_StrUserID = "";
            this.m_txtNEONATEDISEASE2.m_StrUserName = "";
            this.m_txtNEONATEDISEASE2.MaxLength = 8000;
            this.m_txtNEONATEDISEASE2.Multiline = false;
            this.m_txtNEONATEDISEASE2.Name = "m_txtNEONATEDISEASE2";
            this.m_txtNEONATEDISEASE2.Size = new System.Drawing.Size(718, 22);
            this.m_txtNEONATEDISEASE2.TabIndex = 320;
            this.m_txtNEONATEDISEASE2.Text = "";
            // 
            // m_txtNEONATEDISEASE3
            // 
            this.m_txtNEONATEDISEASE3.AccessibleDescription = "新生儿疾病诊断3";
            this.m_txtNEONATEDISEASE3.BackColor = System.Drawing.Color.White;
            this.m_txtNEONATEDISEASE3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNEONATEDISEASE3.ForeColor = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNEONATEDISEASE3.Location = new System.Drawing.Point(32, 72);
            this.m_txtNEONATEDISEASE3.m_BlnIgnoreUserInfo = false;
            this.m_txtNEONATEDISEASE3.m_BlnPartControl = false;
            this.m_txtNEONATEDISEASE3.m_BlnReadOnly = false;
            this.m_txtNEONATEDISEASE3.m_BlnUnderLineDST = false;
            this.m_txtNEONATEDISEASE3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNEONATEDISEASE3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE3.m_IntCanModifyTime = 6;
            this.m_txtNEONATEDISEASE3.m_IntPartControlLength = 0;
            this.m_txtNEONATEDISEASE3.m_IntPartControlStartIndex = 0;
            this.m_txtNEONATEDISEASE3.m_StrUserID = "";
            this.m_txtNEONATEDISEASE3.m_StrUserName = "";
            this.m_txtNEONATEDISEASE3.MaxLength = 8000;
            this.m_txtNEONATEDISEASE3.Multiline = false;
            this.m_txtNEONATEDISEASE3.Name = "m_txtNEONATEDISEASE3";
            this.m_txtNEONATEDISEASE3.Size = new System.Drawing.Size(718, 22);
            this.m_txtNEONATEDISEASE3.TabIndex = 325;
            this.m_txtNEONATEDISEASE3.Text = "";
            // 
            // m_txtNEONATEDISEASE4
            // 
            this.m_txtNEONATEDISEASE4.AccessibleDescription = "新生儿疾病诊断4";
            this.m_txtNEONATEDISEASE4.BackColor = System.Drawing.Color.White;
            this.m_txtNEONATEDISEASE4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtNEONATEDISEASE4.ForeColor = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtNEONATEDISEASE4.Location = new System.Drawing.Point(32, 98);
            this.m_txtNEONATEDISEASE4.m_BlnIgnoreUserInfo = false;
            this.m_txtNEONATEDISEASE4.m_BlnPartControl = false;
            this.m_txtNEONATEDISEASE4.m_BlnReadOnly = false;
            this.m_txtNEONATEDISEASE4.m_BlnUnderLineDST = false;
            this.m_txtNEONATEDISEASE4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtNEONATEDISEASE4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtNEONATEDISEASE4.m_IntCanModifyTime = 6;
            this.m_txtNEONATEDISEASE4.m_IntPartControlLength = 0;
            this.m_txtNEONATEDISEASE4.m_IntPartControlStartIndex = 0;
            this.m_txtNEONATEDISEASE4.m_StrUserID = "";
            this.m_txtNEONATEDISEASE4.m_StrUserName = "";
            this.m_txtNEONATEDISEASE4.MaxLength = 8000;
            this.m_txtNEONATEDISEASE4.Multiline = false;
            this.m_txtNEONATEDISEASE4.Name = "m_txtNEONATEDISEASE4";
            this.m_txtNEONATEDISEASE4.Size = new System.Drawing.Size(718, 22);
            this.m_txtNEONATEDISEASE4.TabIndex = 330;
            this.m_txtNEONATEDISEASE4.Text = "";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 48);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(21, 14);
            this.label40.TabIndex = 11;
            this.label40.Text = "2.";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 74);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(21, 14);
            this.label41.TabIndex = 11;
            this.label41.Text = "3.";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 100);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(21, 14);
            this.label42.TabIndex = 11;
            this.label42.Text = "4.";
            // 
            // lsvOperationEmployee
            // 
            this.lsvOperationEmployee.BackColor = System.Drawing.Color.White;
            this.lsvOperationEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvOperationEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeID,
            this.clmEmployeeName});
            this.lsvOperationEmployee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvOperationEmployee.FullRowSelect = true;
            this.lsvOperationEmployee.GridLines = true;
            this.lsvOperationEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvOperationEmployee.Location = new System.Drawing.Point(154, 124);
            this.lsvOperationEmployee.Name = "lsvOperationEmployee";
            this.lsvOperationEmployee.Size = new System.Drawing.Size(190, 106);
            this.lsvOperationEmployee.TabIndex = 10000021;
            this.lsvOperationEmployee.UseCompatibleStateImageBehavior = false;
            this.lsvOperationEmployee.View = System.Windows.Forms.View.Details;
            this.lsvOperationEmployee.Visible = false;
            this.lsvOperationEmployee.DoubleClick += new System.EventHandler(this.lsvOperationEmployee_DoubleClick);
            // 
            // clmEmployeeID
            // 
            this.clmEmployeeID.Width = 0;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 160;
            // 
            // lsvAanaesthesiaMode
            // 
            this.lsvAanaesthesiaMode.BackColor = System.Drawing.Color.White;
            this.lsvAanaesthesiaMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvAanaesthesiaMode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvAanaesthesiaMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvAanaesthesiaMode.FullRowSelect = true;
            this.lsvAanaesthesiaMode.GridLines = true;
            this.lsvAanaesthesiaMode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvAanaesthesiaMode.Location = new System.Drawing.Point(322, 124);
            this.lsvAanaesthesiaMode.Name = "lsvAanaesthesiaMode";
            this.lsvAanaesthesiaMode.Size = new System.Drawing.Size(206, 106);
            this.lsvAanaesthesiaMode.TabIndex = 10000022;
            this.lsvAanaesthesiaMode.UseCompatibleStateImageBehavior = false;
            this.lsvAanaesthesiaMode.View = System.Windows.Forms.View.Details;
            this.lsvAanaesthesiaMode.Visible = false;
            this.lsvAanaesthesiaMode.DoubleClick += new System.EventHandler(this.lsvAanaesthesiaMode_DoubleClick);
            this.lsvAanaesthesiaMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAanaesthesiaMode_KeyDown);
            this.lsvAanaesthesiaMode.LostFocus += new System.EventHandler(this.lsvAanaesthesiaMode_LostFocus);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 116;
            // 
            // dtgOperation
            // 
            this.dtgOperation.AllowSorting = false;
            this.dtgOperation.BackgroundColor = System.Drawing.Color.White;
            this.dtgOperation.CaptionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dtgOperation.CaptionForeColor = System.Drawing.Color.Black;
            this.dtgOperation.CaptionText = "手术情况";
            this.dtgOperation.DataMember = "";
            this.dtgOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOperation.ForeColor = System.Drawing.Color.Black;
            this.dtgOperation.HeaderForeColor = System.Drawing.Color.White;
            this.dtgOperation.Location = new System.Drawing.Point(4, 98);
            this.dtgOperation.Name = "dtgOperation";
            this.dtgOperation.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOperation.RowHeaderWidth = 40;
            this.dtgOperation.Size = new System.Drawing.Size(758, 212);
            this.dtgOperation.TabIndex = 10000020;
            this.dtgOperation.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dtgOperation;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dtcOperationDate,
            this.dtcOperationName,
            this.dtcOperator,
            this.dtcAssistant1,
            this.dtcAssistant2,
            this.dtcAanaesthesiaMode,
            this.dtcCutLevel,
            this.dtcAnaesthetist,
            this.dtcOperationID});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "OperationDetail";
            // 
            // dtcOperationDate
            // 
            this.dtcOperationDate.Format = "yyyy-MM-dd HH:mm";
            this.dtcOperationDate.FormatInfo = null;
            this.dtcOperationDate.HeaderText = "手术、操作日期";
            this.dtcOperationDate.MappingName = "手术、操作日期";
            this.dtcOperationDate.NullText = "";
            this.dtcOperationDate.Width = 130;
            // 
            // dtcOperationName
            // 
            this.dtcOperationName.Format = "";
            this.dtcOperationName.FormatInfo = null;
            this.dtcOperationName.HeaderText = "手术、操作名称";
            this.dtcOperationName.MappingName = "手术、操作名称";
            this.dtcOperationName.NullText = "";
            this.dtcOperationName.Width = 200;
            // 
            // dtcOperator
            // 
            this.dtcOperator.Format = "";
            this.dtcOperator.FormatInfo = null;
            this.dtcOperator.HeaderText = "术者";
            this.dtcOperator.MappingName = "术者";
            this.dtcOperator.NullText = "";
            this.dtcOperator.Width = 80;
            // 
            // dtcAssistant1
            // 
            this.dtcAssistant1.Format = "";
            this.dtcAssistant1.FormatInfo = null;
            this.dtcAssistant1.HeaderText = "Ⅰ助";
            this.dtcAssistant1.MappingName = "Ⅰ助";
            this.dtcAssistant1.NullText = "";
            this.dtcAssistant1.Width = 80;
            // 
            // dtcAssistant2
            // 
            this.dtcAssistant2.Format = "";
            this.dtcAssistant2.FormatInfo = null;
            this.dtcAssistant2.HeaderText = "Ⅱ助";
            this.dtcAssistant2.MappingName = "Ⅱ助";
            this.dtcAssistant2.NullText = "";
            this.dtcAssistant2.Width = 80;
            // 
            // dtcAanaesthesiaMode
            // 
            this.dtcAanaesthesiaMode.Format = "";
            this.dtcAanaesthesiaMode.FormatInfo = null;
            this.dtcAanaesthesiaMode.HeaderText = "麻醉方式";
            this.dtcAanaesthesiaMode.MappingName = "麻醉方式";
            this.dtcAanaesthesiaMode.NullText = "";
            this.dtcAanaesthesiaMode.Width = 180;
            // 
            // dtcCutLevel
            // 
            this.dtcCutLevel.Format = "";
            this.dtcCutLevel.FormatInfo = null;
            this.dtcCutLevel.HeaderText = "切口";
            this.dtcCutLevel.MappingName = "切口";
            this.dtcCutLevel.NullText = "/";
            this.dtcCutLevel.Width = 80;
            // 
            // dtcAnaesthetist
            // 
            this.dtcAnaesthetist.Format = "";
            this.dtcAnaesthetist.FormatInfo = null;
            this.dtcAnaesthetist.HeaderText = "麻醉医生";
            this.dtcAnaesthetist.MappingName = "麻醉医生";
            this.dtcAnaesthetist.NullText = "";
            this.dtcAnaesthetist.Width = 80;
            // 
            // dtcOperationID
            // 
            this.dtcOperationID.Format = "";
            this.dtcOperationID.FormatInfo = null;
            this.dtcOperationID.HeaderText = "手术、操作编码";
            this.dtcOperationID.MappingName = "手术、操作编码";
            this.dtcOperationID.NullText = "";
            this.dtcOperationID.Width = 120;
            // 
            // m_cboHBsAg
            // 
            this.m_cboHBsAg.AccessibleDescription = "HBsAg";
            this.m_cboHBsAg.BackColor = System.Drawing.Color.White;
            this.m_cboHBsAg.BorderColor = System.Drawing.Color.Black;
            this.m_cboHBsAg.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHBsAg.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHBsAg.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHBsAg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboHBsAg.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHBsAg.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHBsAg.ForeColor = System.Drawing.Color.Black;
            this.m_cboHBsAg.ListBackColor = System.Drawing.Color.White;
            this.m_cboHBsAg.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHBsAg.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHBsAg.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHBsAg.Location = new System.Drawing.Point(62, 66);
            this.m_cboHBsAg.m_BlnEnableItemEventMenu = false;
            this.m_cboHBsAg.Name = "m_cboHBsAg";
            this.m_cboHBsAg.SelectedIndex = -1;
            this.m_cboHBsAg.SelectedItem = null;
            this.m_cboHBsAg.SelectionStart = 0;
            this.m_cboHBsAg.Size = new System.Drawing.Size(102, 23);
            this.m_cboHBsAg.TabIndex = 300;
            this.m_cboHBsAg.TextBackColor = System.Drawing.Color.White;
            this.m_cboHBsAg.TextForeColor = System.Drawing.Color.Black;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(12, 68);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 14);
            this.label36.TabIndex = 12;
            this.label36.Text = "HBsAg:";
            // 
            // m_pnlNEW5DISEASE
            // 
            this.m_pnlNEW5DISEASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlNEW5DISEASE.Controls.Add(this.m_chkNEW5DISEASE1);
            this.m_pnlNEW5DISEASE.Controls.Add(this.m_chkNEW5DISEASE2);
            this.m_pnlNEW5DISEASE.Location = new System.Drawing.Point(62, 28);
            this.m_pnlNEW5DISEASE.Name = "m_pnlNEW5DISEASE";
            this.m_pnlNEW5DISEASE.Size = new System.Drawing.Size(102, 34);
            this.m_pnlNEW5DISEASE.TabIndex = 11;
            // 
            // m_chkNEW5DISEASE1
            // 
            this.m_chkNEW5DISEASE1.AccessibleDescription = "新五病>>是";
            this.m_chkNEW5DISEASE1.Location = new System.Drawing.Point(2, 4);
            this.m_chkNEW5DISEASE1.Name = "m_chkNEW5DISEASE1";
            this.m_chkNEW5DISEASE1.Size = new System.Drawing.Size(54, 24);
            this.m_chkNEW5DISEASE1.TabIndex = 270;
            this.m_chkNEW5DISEASE1.Text = "是、";
            this.m_chkNEW5DISEASE1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkNEW5DISEASE2
            // 
            this.m_chkNEW5DISEASE2.AccessibleDescription = "新五病>>否";
            this.m_chkNEW5DISEASE2.Location = new System.Drawing.Point(56, 4);
            this.m_chkNEW5DISEASE2.Name = "m_chkNEW5DISEASE2";
            this.m_chkNEW5DISEASE2.Size = new System.Drawing.Size(42, 24);
            this.m_chkNEW5DISEASE2.TabIndex = 275;
            this.m_chkNEW5DISEASE2.Text = "否";
            this.m_chkNEW5DISEASE2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 36);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 14);
            this.label33.TabIndex = 10;
            this.label33.Text = "新五病:";
            // 
            // m_txtScacheSource
            // 
            this.m_txtScacheSource.AccessibleDescription = "损伤、中毒的外部因素";
            this.m_txtScacheSource.BackColor = System.Drawing.Color.White;
            this.m_txtScacheSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtScacheSource.ForeColor = System.Drawing.Color.Black;
            this.m_txtScacheSource.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtScacheSource.Location = new System.Drawing.Point(164, 4);
            this.m_txtScacheSource.m_BlnIgnoreUserInfo = false;
            this.m_txtScacheSource.m_BlnPartControl = false;
            this.m_txtScacheSource.m_BlnReadOnly = false;
            this.m_txtScacheSource.m_BlnUnderLineDST = false;
            this.m_txtScacheSource.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtScacheSource.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtScacheSource.m_IntCanModifyTime = 6;
            this.m_txtScacheSource.m_IntPartControlLength = 0;
            this.m_txtScacheSource.m_IntPartControlStartIndex = 0;
            this.m_txtScacheSource.m_StrUserID = "";
            this.m_txtScacheSource.m_StrUserName = "";
            this.m_txtScacheSource.MaxLength = 8000;
            this.m_txtScacheSource.Multiline = false;
            this.m_txtScacheSource.Name = "m_txtScacheSource";
            this.m_txtScacheSource.Size = new System.Drawing.Size(592, 22);
            this.m_txtScacheSource.TabIndex = 265;
            this.m_txtScacheSource.Text = "";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(154, 14);
            this.label32.TabIndex = 0;
            this.label32.Text = "损伤和中毒的外部原因:";
            // 
            // m_pnlSECONDLEVELTRANSFER
            // 
            this.m_pnlSECONDLEVELTRANSFER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlSECONDLEVELTRANSFER.Controls.Add(this.m_chkSECONDLEVELTRANSFER1);
            this.m_pnlSECONDLEVELTRANSFER.Controls.Add(this.m_chkSECONDLEVELTRANSFER2);
            this.m_pnlSECONDLEVELTRANSFER.Location = new System.Drawing.Point(238, 28);
            this.m_pnlSECONDLEVELTRANSFER.Name = "m_pnlSECONDLEVELTRANSFER";
            this.m_pnlSECONDLEVELTRANSFER.Size = new System.Drawing.Size(102, 34);
            this.m_pnlSECONDLEVELTRANSFER.TabIndex = 11;
            // 
            // m_chkSECONDLEVELTRANSFER1
            // 
            this.m_chkSECONDLEVELTRANSFER1.AccessibleDescription = "二级转诊>>有";
            this.m_chkSECONDLEVELTRANSFER1.Location = new System.Drawing.Point(2, 4);
            this.m_chkSECONDLEVELTRANSFER1.Name = "m_chkSECONDLEVELTRANSFER1";
            this.m_chkSECONDLEVELTRANSFER1.Size = new System.Drawing.Size(54, 24);
            this.m_chkSECONDLEVELTRANSFER1.TabIndex = 280;
            this.m_chkSECONDLEVELTRANSFER1.Text = "有、";
            this.m_chkSECONDLEVELTRANSFER1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkSECONDLEVELTRANSFER2
            // 
            this.m_chkSECONDLEVELTRANSFER2.AccessibleDescription = "二级转诊>>无";
            this.m_chkSECONDLEVELTRANSFER2.Location = new System.Drawing.Point(56, 4);
            this.m_chkSECONDLEVELTRANSFER2.Name = "m_chkSECONDLEVELTRANSFER2";
            this.m_chkSECONDLEVELTRANSFER2.Size = new System.Drawing.Size(42, 24);
            this.m_chkSECONDLEVELTRANSFER2.TabIndex = 285;
            this.m_chkSECONDLEVELTRANSFER2.Text = "无";
            this.m_chkSECONDLEVELTRANSFER2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(170, 36);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 14);
            this.label34.TabIndex = 10;
            this.label34.Text = "二级转诊:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(384, 34);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 14);
            this.label35.TabIndex = 0;
            this.label35.Text = "过敏药物:";
            // 
            // m_txtSENSITIVE
            // 
            this.m_txtSENSITIVE.AccessibleDescription = "过敏药物";
            this.m_txtSENSITIVE.BackColor = System.Drawing.Color.White;
            this.m_txtSENSITIVE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSENSITIVE.ForeColor = System.Drawing.Color.Black;
            this.m_txtSENSITIVE.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSENSITIVE.Location = new System.Drawing.Point(454, 32);
            this.m_txtSENSITIVE.m_BlnIgnoreUserInfo = false;
            this.m_txtSENSITIVE.m_BlnPartControl = false;
            this.m_txtSENSITIVE.m_BlnReadOnly = false;
            this.m_txtSENSITIVE.m_BlnUnderLineDST = false;
            this.m_txtSENSITIVE.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSENSITIVE.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSENSITIVE.m_IntCanModifyTime = 6;
            this.m_txtSENSITIVE.m_IntPartControlLength = 0;
            this.m_txtSENSITIVE.m_IntPartControlStartIndex = 0;
            this.m_txtSENSITIVE.m_StrUserID = "";
            this.m_txtSENSITIVE.m_StrUserName = "";
            this.m_txtSENSITIVE.MaxLength = 8000;
            this.m_txtSENSITIVE.Multiline = false;
            this.m_txtSENSITIVE.Name = "m_txtSENSITIVE";
            this.m_txtSENSITIVE.Size = new System.Drawing.Size(302, 22);
            this.m_txtSENSITIVE.TabIndex = 290;
            this.m_txtSENSITIVE.Text = "";
            // 
            // m_cboHCV_Ab
            // 
            this.m_cboHCV_Ab.AccessibleDescription = "HCV-Ab";
            this.m_cboHCV_Ab.BackColor = System.Drawing.Color.White;
            this.m_cboHCV_Ab.BorderColor = System.Drawing.Color.Black;
            this.m_cboHCV_Ab.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHCV_Ab.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHCV_Ab.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHCV_Ab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboHCV_Ab.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHCV_Ab.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHCV_Ab.ForeColor = System.Drawing.Color.Black;
            this.m_cboHCV_Ab.ListBackColor = System.Drawing.Color.White;
            this.m_cboHCV_Ab.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHCV_Ab.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHCV_Ab.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHCV_Ab.Location = new System.Drawing.Point(238, 66);
            this.m_cboHCV_Ab.m_BlnEnableItemEventMenu = false;
            this.m_cboHCV_Ab.Name = "m_cboHCV_Ab";
            this.m_cboHCV_Ab.SelectedIndex = -1;
            this.m_cboHCV_Ab.SelectedItem = null;
            this.m_cboHCV_Ab.SelectionStart = 0;
            this.m_cboHCV_Ab.Size = new System.Drawing.Size(102, 23);
            this.m_cboHCV_Ab.TabIndex = 305;
            this.m_cboHCV_Ab.TextBackColor = System.Drawing.Color.White;
            this.m_cboHCV_Ab.TextForeColor = System.Drawing.Color.Black;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(170, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(70, 14);
            this.label37.TabIndex = 12;
            this.label37.Text = "HCV - Ab:";
            // 
            // m_cboHIV_Ab
            // 
            this.m_cboHIV_Ab.AccessibleDescription = "HIV-Ab";
            this.m_cboHIV_Ab.BackColor = System.Drawing.Color.White;
            this.m_cboHIV_Ab.BorderColor = System.Drawing.Color.Black;
            this.m_cboHIV_Ab.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboHIV_Ab.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboHIV_Ab.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboHIV_Ab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboHIV_Ab.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHIV_Ab.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboHIV_Ab.ForeColor = System.Drawing.Color.Black;
            this.m_cboHIV_Ab.ListBackColor = System.Drawing.Color.White;
            this.m_cboHIV_Ab.ListForeColor = System.Drawing.Color.Black;
            this.m_cboHIV_Ab.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboHIV_Ab.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboHIV_Ab.Location = new System.Drawing.Point(414, 66);
            this.m_cboHIV_Ab.m_BlnEnableItemEventMenu = false;
            this.m_cboHIV_Ab.Name = "m_cboHIV_Ab";
            this.m_cboHIV_Ab.SelectedIndex = -1;
            this.m_cboHIV_Ab.SelectedItem = null;
            this.m_cboHIV_Ab.SelectionStart = 0;
            this.m_cboHIV_Ab.Size = new System.Drawing.Size(102, 23);
            this.m_cboHIV_Ab.TabIndex = 310;
            this.m_cboHIV_Ab.TextBackColor = System.Drawing.Color.White;
            this.m_cboHIV_Ab.TextForeColor = System.Drawing.Color.Black;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(346, 68);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(70, 14);
            this.label38.TabIndex = 12;
            this.label38.Text = "HIV - Ab:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(188, 458);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(98, 14);
            this.label44.TabIndex = 10000024;
            this.label44.Text = "抢救成功次数:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(400, 458);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(42, 14);
            this.label45.TabIndex = 10000024;
            this.label45.Text = "随诊:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(572, 458);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(70, 14);
            this.label46.TabIndex = 10000024;
            this.label46.Text = "随诊期限:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_txtSTATISTIC);
            this.tabPage4.Controls.Add(this.m_txtINPUTMACHINE);
            this.tabPage4.Controls.Add(this.m_txtCODER);
            this.tabPage4.Controls.Add(this.m_txtNEATEN);
            this.tabPage4.Controls.Add(this.txtOtherAmt);
            this.tabPage4.Controls.Add(this.txtAccompanyAmt);
            this.tabPage4.Controls.Add(this.txtBabyAmt);
            this.tabPage4.Controls.Add(this.txtDeliveryChildAmt);
            this.tabPage4.Controls.Add(this.txtAnaethesiaAmt);
            this.tabPage4.Controls.Add(this.txtCheckAmt);
            this.tabPage4.Controls.Add(this.txtOperationAmt);
            this.tabPage4.Controls.Add(this.txtTreatmentAmt);
            this.tabPage4.Controls.Add(this.txtBloodAmt);
            this.tabPage4.Controls.Add(this.txtO2Amt);
            this.tabPage4.Controls.Add(this.txtAssayAmt);
            this.tabPage4.Controls.Add(this.txtRadiationAmt);
            this.tabPage4.Controls.Add(this.txtCMSemiFinishedAmt);
            this.tabPage4.Controls.Add(this.txtCMFinishedAmt);
            this.tabPage4.Controls.Add(this.txtWMAmt);
            this.tabPage4.Controls.Add(this.txtNurseAmt);
            this.tabPage4.Controls.Add(this.txtBedAmt);
            this.tabPage4.Controls.Add(this.txtTotalAmt);
            this.tabPage4.Controls.Add(this.txtIntern);
            this.tabPage4.Controls.Add(this.txtGraduateStudentIntern);
            this.tabPage4.Controls.Add(this.txtAttendInStudyDt);
            this.tabPage4.Controls.Add(this.txtSubDirectorDt);
            this.tabPage4.Controls.Add(this.txtDirectorDt);
            this.tabPage4.Controls.Add(this.m_txtOutHospitalDoc);
            this.tabPage4.Controls.Add(this.txtInHospitalDt);
            this.tabPage4.Controls.Add(this.txtDt);
            this.tabPage4.Controls.Add(this.txtDeptDirectorDt);
            this.tabPage4.Controls.Add(this.m_pnlXRayCheck);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label75);
            this.tabPage4.Controls.Add(this.lblBedAmt);
            this.tabPage4.Controls.Add(this.lblTotalAmt);
            this.tabPage4.Controls.Add(this.lblWMAmt);
            this.tabPage4.Controls.Add(this.lblCMFinishedAmt);
            this.tabPage4.Controls.Add(this.lblCMSemiFinishedTitle);
            this.tabPage4.Controls.Add(this.lblNurseAmt);
            this.tabPage4.Controls.Add(this.lblRadiationAmt);
            this.tabPage4.Controls.Add(this.lblAssayAmt);
            this.tabPage4.Controls.Add(this.lblO2);
            this.tabPage4.Controls.Add(this.lblBloodTran);
            this.tabPage4.Controls.Add(this.lblTreatmentAmt);
            this.tabPage4.Controls.Add(this.lblDeliveryChild);
            this.tabPage4.Controls.Add(this.lblOperationAmt);
            this.tabPage4.Controls.Add(this.lblCheckAmt);
            this.tabPage4.Controls.Add(this.lblAnaethisiaAmt);
            this.tabPage4.Controls.Add(this.lblBabyAmt);
            this.tabPage4.Controls.Add(this.lblAccompanyAmt);
            this.tabPage4.Controls.Add(this.lblOtherAmt1);
            this.tabPage4.Controls.Add(this.m_cmdDeptDirectorDt);
            this.tabPage4.Controls.Add(this.m_cmdSubDirectorDt);
            this.tabPage4.Controls.Add(this.m_cmdDt);
            this.tabPage4.Controls.Add(this.m_cmdInHospitalDt);
            this.tabPage4.Controls.Add(this.m_cmdAttendInStudyDt);
            this.tabPage4.Controls.Add(this.m_cmdGraduateStudentIntern);
            this.tabPage4.Controls.Add(this.m_cmdIntern);
            this.tabPage4.Controls.Add(this.m_cmdDirectorDt);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.label64);
            this.tabPage4.Controls.Add(this.label63);
            this.tabPage4.Controls.Add(this.label59);
            this.tabPage4.Controls.Add(this.label58);
            this.tabPage4.Controls.Add(this.m_pnlPATHOGENYRESULT);
            this.tabPage4.Controls.Add(this.label56);
            this.tabPage4.Controls.Add(this.m_pnlANTIBACTERIAL);
            this.tabPage4.Controls.Add(this.label55);
            this.tabPage4.Controls.Add(this.m_pnlQUALITY);
            this.tabPage4.Controls.Add(this.label54);
            this.tabPage4.Controls.Add(this.m_pnlFIRSTCASE);
            this.tabPage4.Controls.Add(this.label53);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.m_pnlPATHOGENY);
            this.tabPage4.Controls.Add(this.label57);
            this.tabPage4.Controls.Add(this.m_pnlMODELCASE);
            this.tabPage4.Controls.Add(this.m_pnlBLOODTRANSACTOIN);
            this.tabPage4.Controls.Add(this.label60);
            this.tabPage4.Controls.Add(this.m_pnlTRANSFUSIONSACTION);
            this.tabPage4.Controls.Add(this.label61);
            this.tabPage4.Controls.Add(this.m_pnlCTCHECK);
            this.tabPage4.Controls.Add(this.label62);
            this.tabPage4.Controls.Add(this.m_pnlMRICHECK);
            this.tabPage4.Controls.Add(this.m_pnlBLOODTYPE);
            this.tabPage4.Controls.Add(this.m_pnlBLOODRH);
            this.tabPage4.Controls.Add(this.m_cmdOutHospitalDoc);
            this.tabPage4.Controls.Add(this.m_cmdNEATEN);
            this.tabPage4.Controls.Add(this.m_cmdCODER);
            this.tabPage4.Controls.Add(this.m_cmdINPUTMACHINE);
            this.tabPage4.Controls.Add(this.m_cmdSTATISTIC);
            this.tabPage4.ImageIndex = 6;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(766, 491);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "统计费用";
            // 
            // m_txtSTATISTIC
            // 
            this.m_txtSTATISTIC.AccessibleDescription = "统计人";
            this.m_txtSTATISTIC.Location = new System.Drawing.Point(646, 444);
            this.m_txtSTATISTIC.Name = "m_txtSTATISTIC";
            this.m_txtSTATISTIC.Size = new System.Drawing.Size(85, 23);
            this.m_txtSTATISTIC.TabIndex = 605;
            // 
            // m_txtINPUTMACHINE
            // 
            this.m_txtINPUTMACHINE.AccessibleDescription = "入机人";
            this.m_txtINPUTMACHINE.Location = new System.Drawing.Point(463, 444);
            this.m_txtINPUTMACHINE.Name = "m_txtINPUTMACHINE";
            this.m_txtINPUTMACHINE.Size = new System.Drawing.Size(85, 23);
            this.m_txtINPUTMACHINE.TabIndex = 605;
            // 
            // m_txtCODER
            // 
            this.m_txtCODER.AccessibleDescription = "编码人";
            this.m_txtCODER.Location = new System.Drawing.Point(278, 444);
            this.m_txtCODER.Name = "m_txtCODER";
            this.m_txtCODER.Size = new System.Drawing.Size(85, 23);
            this.m_txtCODER.TabIndex = 605;
            // 
            // m_txtNEATEN
            // 
            this.m_txtNEATEN.AccessibleDescription = "整理人";
            this.m_txtNEATEN.Location = new System.Drawing.Point(96, 444);
            this.m_txtNEATEN.Name = "m_txtNEATEN";
            this.m_txtNEATEN.Size = new System.Drawing.Size(85, 23);
            this.m_txtNEATEN.TabIndex = 605;
            // 
            // txtOtherAmt
            // 
            this.txtOtherAmt.AccessibleDescription = "其他费用";
            this.txtOtherAmt.Location = new System.Drawing.Point(456, 413);
            this.txtOtherAmt.Name = "txtOtherAmt";
            this.txtOtherAmt.Size = new System.Drawing.Size(64, 23);
            this.txtOtherAmt.TabIndex = 690;
            this.txtOtherAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtOtherAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtAccompanyAmt
            // 
            this.txtAccompanyAmt.AccessibleDescription = "陪床费";
            this.txtAccompanyAmt.Location = new System.Drawing.Point(350, 413);
            this.txtAccompanyAmt.Name = "txtAccompanyAmt";
            this.txtAccompanyAmt.Size = new System.Drawing.Size(64, 23);
            this.txtAccompanyAmt.TabIndex = 685;
            this.txtAccompanyAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtAccompanyAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtBabyAmt
            // 
            this.txtBabyAmt.AccessibleDescription = "婴儿费";
            this.txtBabyAmt.Location = new System.Drawing.Point(252, 413);
            this.txtBabyAmt.Name = "txtBabyAmt";
            this.txtBabyAmt.Size = new System.Drawing.Size(52, 23);
            this.txtBabyAmt.TabIndex = 680;
            this.txtBabyAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtBabyAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtDeliveryChildAmt
            // 
            this.txtDeliveryChildAmt.AccessibleDescription = "接生费";
            this.txtDeliveryChildAmt.Location = new System.Drawing.Point(140, 413);
            this.txtDeliveryChildAmt.Name = "txtDeliveryChildAmt";
            this.txtDeliveryChildAmt.Size = new System.Drawing.Size(64, 23);
            this.txtDeliveryChildAmt.TabIndex = 675;
            this.txtDeliveryChildAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtDeliveryChildAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtAnaethesiaAmt
            // 
            this.txtAnaethesiaAmt.AccessibleDescription = "麻醉费";
            this.txtAnaethesiaAmt.Location = new System.Drawing.Point(38, 413);
            this.txtAnaethesiaAmt.Name = "txtAnaethesiaAmt";
            this.txtAnaethesiaAmt.Size = new System.Drawing.Size(64, 23);
            this.txtAnaethesiaAmt.TabIndex = 670;
            this.txtAnaethesiaAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtAnaethesiaAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtCheckAmt
            // 
            this.txtCheckAmt.AccessibleDescription = "检查费";
            this.txtCheckAmt.Location = new System.Drawing.Point(684, 386);
            this.txtCheckAmt.Name = "txtCheckAmt";
            this.txtCheckAmt.Size = new System.Drawing.Size(64, 23);
            this.txtCheckAmt.TabIndex = 665;
            this.txtCheckAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtCheckAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtOperationAmt
            // 
            this.txtOperationAmt.AccessibleDescription = "手术费";
            this.txtOperationAmt.Location = new System.Drawing.Point(568, 386);
            this.txtOperationAmt.Name = "txtOperationAmt";
            this.txtOperationAmt.Size = new System.Drawing.Size(64, 23);
            this.txtOperationAmt.TabIndex = 660;
            this.txtOperationAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtOperationAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtTreatmentAmt
            // 
            this.txtTreatmentAmt.AccessibleDescription = "诊疗费";
            this.txtTreatmentAmt.Location = new System.Drawing.Point(456, 386);
            this.txtTreatmentAmt.Name = "txtTreatmentAmt";
            this.txtTreatmentAmt.Size = new System.Drawing.Size(64, 23);
            this.txtTreatmentAmt.TabIndex = 655;
            this.txtTreatmentAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtTreatmentAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtBloodAmt
            // 
            this.txtBloodAmt.AccessibleDescription = "输血费";
            this.txtBloodAmt.Location = new System.Drawing.Point(350, 385);
            this.txtBloodAmt.Name = "txtBloodAmt";
            this.txtBloodAmt.Size = new System.Drawing.Size(64, 23);
            this.txtBloodAmt.TabIndex = 650;
            this.txtBloodAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtBloodAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtO2Amt
            // 
            this.txtO2Amt.AccessibleDescription = "输氧费";
            this.txtO2Amt.Location = new System.Drawing.Point(242, 385);
            this.txtO2Amt.Name = "txtO2Amt";
            this.txtO2Amt.Size = new System.Drawing.Size(62, 23);
            this.txtO2Amt.TabIndex = 645;
            this.txtO2Amt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtO2Amt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtAssayAmt
            // 
            this.txtAssayAmt.AccessibleDescription = "化验费";
            this.txtAssayAmt.Location = new System.Drawing.Point(140, 385);
            this.txtAssayAmt.Name = "txtAssayAmt";
            this.txtAssayAmt.Size = new System.Drawing.Size(64, 23);
            this.txtAssayAmt.TabIndex = 640;
            this.txtAssayAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtAssayAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtRadiationAmt
            // 
            this.txtRadiationAmt.AccessibleDescription = "放射费";
            this.txtRadiationAmt.Location = new System.Drawing.Point(38, 385);
            this.txtRadiationAmt.Name = "txtRadiationAmt";
            this.txtRadiationAmt.Size = new System.Drawing.Size(64, 23);
            this.txtRadiationAmt.TabIndex = 635;
            this.txtRadiationAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtRadiationAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtCMSemiFinishedAmt
            // 
            this.txtCMSemiFinishedAmt.AccessibleDescription = "中草药费";
            this.txtCMSemiFinishedAmt.Location = new System.Drawing.Point(684, 359);
            this.txtCMSemiFinishedAmt.Name = "txtCMSemiFinishedAmt";
            this.txtCMSemiFinishedAmt.Size = new System.Drawing.Size(64, 23);
            this.txtCMSemiFinishedAmt.TabIndex = 630;
            this.txtCMSemiFinishedAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtCMSemiFinishedAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtCMFinishedAmt
            // 
            this.txtCMFinishedAmt.AccessibleDescription = "中成药费";
            this.txtCMFinishedAmt.Location = new System.Drawing.Point(568, 359);
            this.txtCMFinishedAmt.Name = "txtCMFinishedAmt";
            this.txtCMFinishedAmt.Size = new System.Drawing.Size(64, 23);
            this.txtCMFinishedAmt.TabIndex = 625;
            this.txtCMFinishedAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtCMFinishedAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtWMAmt
            // 
            this.txtWMAmt.AccessibleDescription = "西药费";
            this.txtWMAmt.Location = new System.Drawing.Point(456, 359);
            this.txtWMAmt.Name = "txtWMAmt";
            this.txtWMAmt.Size = new System.Drawing.Size(64, 23);
            this.txtWMAmt.TabIndex = 620;
            this.txtWMAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtWMAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtNurseAmt
            // 
            this.txtNurseAmt.AccessibleDescription = "护理费";
            this.txtNurseAmt.Location = new System.Drawing.Point(350, 359);
            this.txtNurseAmt.Name = "txtNurseAmt";
            this.txtNurseAmt.Size = new System.Drawing.Size(64, 23);
            this.txtNurseAmt.TabIndex = 615;
            this.txtNurseAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtNurseAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtBedAmt
            // 
            this.txtBedAmt.AccessibleDescription = "床位费";
            this.txtBedAmt.Location = new System.Drawing.Point(242, 359);
            this.txtBedAmt.Name = "txtBedAmt";
            this.txtBedAmt.Size = new System.Drawing.Size(62, 23);
            this.txtBedAmt.TabIndex = 610;
            this.txtBedAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtBedAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.AccessibleDescription = "住院费用总计";
            this.txtTotalAmt.Location = new System.Drawing.Point(140, 359);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.Size = new System.Drawing.Size(64, 23);
            this.txtTotalAmt.TabIndex = 605;
            this.txtTotalAmt.MouseLeave += new System.EventHandler(this.m_txtCheckDouble_MouseLeave);
            this.txtTotalAmt.Leave += new System.EventHandler(this.m_txtCheckDouble_Leave);
            // 
            // txtIntern
            // 
            this.txtIntern.AccessibleDescription = "实习医师";
            this.txtIntern.Location = new System.Drawing.Point(646, 327);
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Size = new System.Drawing.Size(80, 23);
            this.txtIntern.TabIndex = 605;
            // 
            // txtGraduateStudentIntern
            // 
            this.txtGraduateStudentIntern.AccessibleDescription = "研究生实习医师";
            this.txtGraduateStudentIntern.Location = new System.Drawing.Point(469, 326);
            this.txtGraduateStudentIntern.Name = "txtGraduateStudentIntern";
            this.txtGraduateStudentIntern.Size = new System.Drawing.Size(80, 23);
            this.txtGraduateStudentIntern.TabIndex = 604;
            // 
            // txtAttendInStudyDt
            // 
            this.txtAttendInStudyDt.AccessibleDescription = "进修医师";
            this.txtAttendInStudyDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttendInStudyDt.Location = new System.Drawing.Point(264, 326);
            this.txtAttendInStudyDt.Name = "txtAttendInStudyDt";
            this.txtAttendInStudyDt.Size = new System.Drawing.Size(80, 23);
            this.txtAttendInStudyDt.TabIndex = 603;
            // 
            // txtSubDirectorDt
            // 
            this.txtSubDirectorDt.AccessibleDescription = "副主任医师";
            this.txtSubDirectorDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtSubDirectorDt.Location = new System.Drawing.Point(94, 326);
            this.txtSubDirectorDt.Name = "txtSubDirectorDt";
            this.txtSubDirectorDt.ReadOnly = true;
            this.txtSubDirectorDt.Size = new System.Drawing.Size(80, 23);
            this.txtSubDirectorDt.TabIndex = 600;
            // 
            // txtDirectorDt
            // 
            this.txtDirectorDt.AccessibleDescription = "主任医师";
            this.txtDirectorDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtDirectorDt.Location = new System.Drawing.Point(94, 299);
            this.txtDirectorDt.Name = "txtDirectorDt";
            this.txtDirectorDt.ReadOnly = true;
            this.txtDirectorDt.Size = new System.Drawing.Size(80, 23);
            this.txtDirectorDt.TabIndex = 606;
            // 
            // m_txtOutHospitalDoc
            // 
            this.m_txtOutHospitalDoc.AccessibleDescription = "出院医师";
            this.m_txtOutHospitalDoc.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtOutHospitalDoc.Location = new System.Drawing.Point(646, 271);
            this.m_txtOutHospitalDoc.Name = "m_txtOutHospitalDoc";
            this.m_txtOutHospitalDoc.ReadOnly = true;
            this.m_txtOutHospitalDoc.Size = new System.Drawing.Size(80, 23);
            this.m_txtOutHospitalDoc.TabIndex = 602;
            // 
            // txtInHospitalDt
            // 
            this.txtInHospitalDt.AccessibleDescription = "住院医师";
            this.txtInHospitalDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtInHospitalDt.Location = new System.Drawing.Point(469, 270);
            this.txtInHospitalDt.Name = "txtInHospitalDt";
            this.txtInHospitalDt.ReadOnly = true;
            this.txtInHospitalDt.Size = new System.Drawing.Size(80, 23);
            this.txtInHospitalDt.TabIndex = 602;
            // 
            // txtDt
            // 
            this.txtDt.AccessibleDescription = "主治医师";
            this.txtDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtDt.Location = new System.Drawing.Point(264, 270);
            this.txtDt.Name = "txtDt";
            this.txtDt.ReadOnly = true;
            this.txtDt.Size = new System.Drawing.Size(80, 23);
            this.txtDt.TabIndex = 601;
            // 
            // txtDeptDirectorDt
            // 
            this.txtDeptDirectorDt.AccessibleDescription = "科主任";
            this.txtDeptDirectorDt.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeptDirectorDt.Location = new System.Drawing.Point(94, 270);
            this.txtDeptDirectorDt.Name = "txtDeptDirectorDt";
            this.txtDeptDirectorDt.ReadOnly = true;
            this.txtDeptDirectorDt.Size = new System.Drawing.Size(80, 23);
            this.txtDeptDirectorDt.TabIndex = 599;
            // 
            // m_pnlXRayCheck
            // 
            this.m_pnlXRayCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlXRayCheck.Controls.Add(this.m_chkXRayCheck3);
            this.m_pnlXRayCheck.Controls.Add(this.m_chkXRayCheck2);
            this.m_pnlXRayCheck.Controls.Add(this.m_chkXRayCheck1);
            this.m_pnlXRayCheck.Location = new System.Drawing.Point(624, 182);
            this.m_pnlXRayCheck.Name = "m_pnlXRayCheck";
            this.m_pnlXRayCheck.Size = new System.Drawing.Size(136, 30);
            this.m_pnlXRayCheck.TabIndex = 7;
            // 
            // m_chkXRayCheck3
            // 
            this.m_chkXRayCheck3.AccessibleDescription = "大型X光机检查>>无";
            this.m_chkXRayCheck3.Location = new System.Drawing.Point(98, 2);
            this.m_chkXRayCheck3.Name = "m_chkXRayCheck3";
            this.m_chkXRayCheck3.Size = new System.Drawing.Size(54, 24);
            this.m_chkXRayCheck3.TabIndex = 530;
            this.m_chkXRayCheck3.Text = "无";
            this.m_chkXRayCheck3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkXRayCheck2
            // 
            this.m_chkXRayCheck2.AccessibleDescription = "大型X光机检查>>阴性";
            this.m_chkXRayCheck2.Location = new System.Drawing.Point(50, 2);
            this.m_chkXRayCheck2.Name = "m_chkXRayCheck2";
            this.m_chkXRayCheck2.Size = new System.Drawing.Size(56, 24);
            this.m_chkXRayCheck2.TabIndex = 525;
            this.m_chkXRayCheck2.Text = "阴性";
            this.m_chkXRayCheck2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkXRayCheck1
            // 
            this.m_chkXRayCheck1.AccessibleDescription = "大型X光机检查>>阳性";
            this.m_chkXRayCheck1.Location = new System.Drawing.Point(2, 2);
            this.m_chkXRayCheck1.Name = "m_chkXRayCheck1";
            this.m_chkXRayCheck1.Size = new System.Drawing.Size(56, 24);
            this.m_chkXRayCheck1.TabIndex = 520;
            this.m_chkXRayCheck1.Text = "阳性";
            this.m_chkXRayCheck1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(525, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 14);
            this.label14.TabIndex = 29158;
            this.label14.Text = "大型X光机检查";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(6, 470);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(665, 14);
            this.label75.TabIndex = 29157;
            this.label75.Text = "诊断依据:有病理证实在诊断名前加 “#”，细胞学证实加“△”，细菌证实加“+”，临床诊断不加符号。";
            // 
            // lblBedAmt
            // 
            this.lblBedAmt.AutoSize = true;
            this.lblBedAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedAmt.Location = new System.Drawing.Point(208, 362);
            this.lblBedAmt.Name = "lblBedAmt";
            this.lblBedAmt.Size = new System.Drawing.Size(35, 14);
            this.lblBedAmt.TabIndex = 29140;
            this.lblBedAmt.Text = "床位";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAmt.Location = new System.Drawing.Point(4, 362);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(133, 14);
            this.lblTotalAmt.TabIndex = 29139;
            this.lblTotalAmt.Text = "住院费用总计（元）";
            // 
            // lblWMAmt
            // 
            this.lblWMAmt.AutoSize = true;
            this.lblWMAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWMAmt.Location = new System.Drawing.Point(422, 362);
            this.lblWMAmt.Name = "lblWMAmt";
            this.lblWMAmt.Size = new System.Drawing.Size(35, 14);
            this.lblWMAmt.TabIndex = 29141;
            this.lblWMAmt.Text = "西药";
            // 
            // lblCMFinishedAmt
            // 
            this.lblCMFinishedAmt.AutoSize = true;
            this.lblCMFinishedAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCMFinishedAmt.Location = new System.Drawing.Point(520, 362);
            this.lblCMFinishedAmt.Name = "lblCMFinishedAmt";
            this.lblCMFinishedAmt.Size = new System.Drawing.Size(49, 14);
            this.lblCMFinishedAmt.TabIndex = 29142;
            this.lblCMFinishedAmt.Text = "中成药";
            // 
            // lblCMSemiFinishedTitle
            // 
            this.lblCMSemiFinishedTitle.AutoSize = true;
            this.lblCMSemiFinishedTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCMSemiFinishedTitle.Location = new System.Drawing.Point(636, 362);
            this.lblCMSemiFinishedTitle.Name = "lblCMSemiFinishedTitle";
            this.lblCMSemiFinishedTitle.Size = new System.Drawing.Size(49, 14);
            this.lblCMSemiFinishedTitle.TabIndex = 29149;
            this.lblCMSemiFinishedTitle.Text = "中草药";
            // 
            // lblNurseAmt
            // 
            this.lblNurseAmt.AutoSize = true;
            this.lblNurseAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNurseAmt.Location = new System.Drawing.Point(304, 362);
            this.lblNurseAmt.Name = "lblNurseAmt";
            this.lblNurseAmt.Size = new System.Drawing.Size(49, 14);
            this.lblNurseAmt.TabIndex = 29150;
            this.lblNurseAmt.Text = "护理费";
            // 
            // lblRadiationAmt
            // 
            this.lblRadiationAmt.AutoSize = true;
            this.lblRadiationAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRadiationAmt.Location = new System.Drawing.Point(4, 390);
            this.lblRadiationAmt.Name = "lblRadiationAmt";
            this.lblRadiationAmt.Size = new System.Drawing.Size(35, 14);
            this.lblRadiationAmt.TabIndex = 29143;
            this.lblRadiationAmt.Text = "放射";
            // 
            // lblAssayAmt
            // 
            this.lblAssayAmt.AutoSize = true;
            this.lblAssayAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAssayAmt.Location = new System.Drawing.Point(106, 390);
            this.lblAssayAmt.Name = "lblAssayAmt";
            this.lblAssayAmt.Size = new System.Drawing.Size(35, 14);
            this.lblAssayAmt.TabIndex = 29144;
            this.lblAssayAmt.Text = "化验";
            // 
            // lblO2
            // 
            this.lblO2.AutoSize = true;
            this.lblO2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblO2.Location = new System.Drawing.Point(208, 390);
            this.lblO2.Name = "lblO2";
            this.lblO2.Size = new System.Drawing.Size(35, 14);
            this.lblO2.TabIndex = 29145;
            this.lblO2.Text = "输氧";
            // 
            // lblBloodTran
            // 
            this.lblBloodTran.AutoSize = true;
            this.lblBloodTran.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodTran.Location = new System.Drawing.Point(314, 390);
            this.lblBloodTran.Name = "lblBloodTran";
            this.lblBloodTran.Size = new System.Drawing.Size(35, 14);
            this.lblBloodTran.TabIndex = 29146;
            this.lblBloodTran.Text = "输血";
            // 
            // lblTreatmentAmt
            // 
            this.lblTreatmentAmt.AutoSize = true;
            this.lblTreatmentAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTreatmentAmt.Location = new System.Drawing.Point(424, 390);
            this.lblTreatmentAmt.Name = "lblTreatmentAmt";
            this.lblTreatmentAmt.Size = new System.Drawing.Size(35, 14);
            this.lblTreatmentAmt.TabIndex = 29151;
            this.lblTreatmentAmt.Text = "诊疗";
            // 
            // lblDeliveryChild
            // 
            this.lblDeliveryChild.AutoSize = true;
            this.lblDeliveryChild.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeliveryChild.Location = new System.Drawing.Point(106, 418);
            this.lblDeliveryChild.Name = "lblDeliveryChild";
            this.lblDeliveryChild.Size = new System.Drawing.Size(35, 14);
            this.lblDeliveryChild.TabIndex = 29148;
            this.lblDeliveryChild.Text = "接生";
            // 
            // lblOperationAmt
            // 
            this.lblOperationAmt.AutoSize = true;
            this.lblOperationAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationAmt.Location = new System.Drawing.Point(534, 390);
            this.lblOperationAmt.Name = "lblOperationAmt";
            this.lblOperationAmt.Size = new System.Drawing.Size(35, 14);
            this.lblOperationAmt.TabIndex = 29147;
            this.lblOperationAmt.Text = "手术";
            // 
            // lblCheckAmt
            // 
            this.lblCheckAmt.AutoSize = true;
            this.lblCheckAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckAmt.Location = new System.Drawing.Point(650, 388);
            this.lblCheckAmt.Name = "lblCheckAmt";
            this.lblCheckAmt.Size = new System.Drawing.Size(35, 14);
            this.lblCheckAmt.TabIndex = 29152;
            this.lblCheckAmt.Text = "检查";
            // 
            // lblAnaethisiaAmt
            // 
            this.lblAnaethisiaAmt.AutoSize = true;
            this.lblAnaethisiaAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnaethisiaAmt.Location = new System.Drawing.Point(4, 418);
            this.lblAnaethisiaAmt.Name = "lblAnaethisiaAmt";
            this.lblAnaethisiaAmt.Size = new System.Drawing.Size(35, 14);
            this.lblAnaethisiaAmt.TabIndex = 29153;
            this.lblAnaethisiaAmt.Text = "麻醉";
            // 
            // lblBabyAmt
            // 
            this.lblBabyAmt.AutoSize = true;
            this.lblBabyAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBabyAmt.Location = new System.Drawing.Point(204, 418);
            this.lblBabyAmt.Name = "lblBabyAmt";
            this.lblBabyAmt.Size = new System.Drawing.Size(49, 14);
            this.lblBabyAmt.TabIndex = 29154;
            this.lblBabyAmt.Text = "婴儿费";
            // 
            // lblAccompanyAmt
            // 
            this.lblAccompanyAmt.AutoSize = true;
            this.lblAccompanyAmt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAccompanyAmt.Location = new System.Drawing.Point(304, 418);
            this.lblAccompanyAmt.Name = "lblAccompanyAmt";
            this.lblAccompanyAmt.Size = new System.Drawing.Size(49, 14);
            this.lblAccompanyAmt.TabIndex = 29155;
            this.lblAccompanyAmt.Text = "陪床费";
            // 
            // lblOtherAmt1
            // 
            this.lblOtherAmt1.AutoSize = true;
            this.lblOtherAmt1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherAmt1.Location = new System.Drawing.Point(424, 418);
            this.lblOtherAmt1.Name = "lblOtherAmt1";
            this.lblOtherAmt1.Size = new System.Drawing.Size(35, 14);
            this.lblOtherAmt1.TabIndex = 29156;
            this.lblOtherAmt1.Text = "其他";
            // 
            // m_cmdDeptDirectorDt
            // 
            this.m_cmdDeptDirectorDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDeptDirectorDt.DefaultScheme = true;
            this.m_cmdDeptDirectorDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDeptDirectorDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDeptDirectorDt.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDeptDirectorDt.Hint = "";
            this.m_cmdDeptDirectorDt.Location = new System.Drawing.Point(2, 268);
            this.m_cmdDeptDirectorDt.Name = "m_cmdDeptDirectorDt";
            this.m_cmdDeptDirectorDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDeptDirectorDt.Size = new System.Drawing.Size(92, 24);
            this.m_cmdDeptDirectorDt.TabIndex = 560;
            this.m_cmdDeptDirectorDt.Text = "科主任:";
            // 
            // m_cmdSubDirectorDt
            // 
            this.m_cmdSubDirectorDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSubDirectorDt.DefaultScheme = true;
            this.m_cmdSubDirectorDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSubDirectorDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSubDirectorDt.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSubDirectorDt.Hint = "";
            this.m_cmdSubDirectorDt.Location = new System.Drawing.Point(2, 326);
            this.m_cmdSubDirectorDt.Name = "m_cmdSubDirectorDt";
            this.m_cmdSubDirectorDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSubDirectorDt.Size = new System.Drawing.Size(92, 24);
            this.m_cmdSubDirectorDt.TabIndex = 585;
            this.m_cmdSubDirectorDt.Text = "副主任医师:";
            // 
            // m_cmdDt
            // 
            this.m_cmdDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDt.DefaultScheme = true;
            this.m_cmdDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDt.Hint = "";
            this.m_cmdDt.Location = new System.Drawing.Point(178, 270);
            this.m_cmdDt.Name = "m_cmdDt";
            this.m_cmdDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDt.Size = new System.Drawing.Size(84, 24);
            this.m_cmdDt.TabIndex = 565;
            this.m_cmdDt.Text = "主治医师:";
            // 
            // m_cmdInHospitalDt
            // 
            this.m_cmdInHospitalDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdInHospitalDt.DefaultScheme = true;
            this.m_cmdInHospitalDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdInHospitalDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdInHospitalDt.Hint = "";
            this.m_cmdInHospitalDt.Location = new System.Drawing.Point(350, 270);
            this.m_cmdInHospitalDt.Name = "m_cmdInHospitalDt";
            this.m_cmdInHospitalDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdInHospitalDt.Size = new System.Drawing.Size(118, 24);
            this.m_cmdInHospitalDt.TabIndex = 570;
            this.m_cmdInHospitalDt.Text = "入院医师:";
            // 
            // m_cmdAttendInStudyDt
            // 
            this.m_cmdAttendInStudyDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdAttendInStudyDt.DefaultScheme = true;
            this.m_cmdAttendInStudyDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAttendInStudyDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAttendInStudyDt.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAttendInStudyDt.Hint = "";
            this.m_cmdAttendInStudyDt.Location = new System.Drawing.Point(178, 326);
            this.m_cmdAttendInStudyDt.Name = "m_cmdAttendInStudyDt";
            this.m_cmdAttendInStudyDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAttendInStudyDt.Size = new System.Drawing.Size(84, 24);
            this.m_cmdAttendInStudyDt.TabIndex = 590;
            this.m_cmdAttendInStudyDt.Text = "进修医师:";
            // 
            // m_cmdGraduateStudentIntern
            // 
            this.m_cmdGraduateStudentIntern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdGraduateStudentIntern.DefaultScheme = true;
            this.m_cmdGraduateStudentIntern.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdGraduateStudentIntern.Enabled = false;
            this.m_cmdGraduateStudentIntern.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdGraduateStudentIntern.ForeColor = System.Drawing.Color.Black;
            this.m_cmdGraduateStudentIntern.Hint = "";
            this.m_cmdGraduateStudentIntern.Location = new System.Drawing.Point(350, 326);
            this.m_cmdGraduateStudentIntern.Name = "m_cmdGraduateStudentIntern";
            this.m_cmdGraduateStudentIntern.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdGraduateStudentIntern.Size = new System.Drawing.Size(118, 24);
            this.m_cmdGraduateStudentIntern.TabIndex = 595;
            this.m_cmdGraduateStudentIntern.Text = "研究生实习医师:";
            // 
            // m_cmdIntern
            // 
            this.m_cmdIntern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdIntern.DefaultScheme = true;
            this.m_cmdIntern.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdIntern.Enabled = false;
            this.m_cmdIntern.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdIntern.Hint = "";
            this.m_cmdIntern.Location = new System.Drawing.Point(554, 326);
            this.m_cmdIntern.Name = "m_cmdIntern";
            this.m_cmdIntern.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdIntern.Size = new System.Drawing.Size(92, 24);
            this.m_cmdIntern.TabIndex = 600;
            this.m_cmdIntern.Text = "实习医师:";
            // 
            // m_cmdDirectorDt
            // 
            this.m_cmdDirectorDt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdDirectorDt.DefaultScheme = true;
            this.m_cmdDirectorDt.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDirectorDt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirectorDt.Hint = "";
            this.m_cmdDirectorDt.Location = new System.Drawing.Point(2, 298);
            this.m_cmdDirectorDt.Name = "m_cmdDirectorDt";
            this.m_cmdDirectorDt.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDirectorDt.Size = new System.Drawing.Size(92, 24);
            this.m_cmdDirectorDt.TabIndex = 580;
            this.m_cmdDirectorDt.Text = "主任医师:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.m_txtWHOLEBLOOD);
            this.groupBox9.Controls.Add(this.label66);
            this.groupBox9.Controls.Add(this.label65);
            this.groupBox9.Controls.Add(this.m_txtRBC);
            this.groupBox9.Controls.Add(this.label67);
            this.groupBox9.Controls.Add(this.label68);
            this.groupBox9.Controls.Add(this.m_txtPLT);
            this.groupBox9.Controls.Add(this.label69);
            this.groupBox9.Controls.Add(this.m_txtPLASM);
            this.groupBox9.Controls.Add(this.label70);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Controls.Add(this.label72);
            this.groupBox9.Controls.Add(this.label73);
            this.groupBox9.Controls.Add(this.m_txtOTHERBLOOD);
            this.groupBox9.Controls.Add(this.label74);
            this.groupBox9.Location = new System.Drawing.Point(2, 216);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(760, 46);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "输血品种";
            // 
            // m_txtWHOLEBLOOD
            // 
            this.m_txtWHOLEBLOOD.AccessibleDescription = "全血";
            this.m_txtWHOLEBLOOD.BackColor = System.Drawing.Color.White;
            this.m_txtWHOLEBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWHOLEBLOOD.ForeColor = System.Drawing.Color.Black;
            this.m_txtWHOLEBLOOD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtWHOLEBLOOD.Location = new System.Drawing.Point(536, 20);
            this.m_txtWHOLEBLOOD.m_BlnIgnoreUserInfo = false;
            this.m_txtWHOLEBLOOD.m_BlnPartControl = false;
            this.m_txtWHOLEBLOOD.m_BlnReadOnly = false;
            this.m_txtWHOLEBLOOD.m_BlnUnderLineDST = false;
            this.m_txtWHOLEBLOOD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtWHOLEBLOOD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtWHOLEBLOOD.m_IntCanModifyTime = 6;
            this.m_txtWHOLEBLOOD.m_IntPartControlLength = 0;
            this.m_txtWHOLEBLOOD.m_IntPartControlStartIndex = 0;
            this.m_txtWHOLEBLOOD.m_StrUserID = "";
            this.m_txtWHOLEBLOOD.m_StrUserName = "";
            this.m_txtWHOLEBLOOD.MaxLength = 8000;
            this.m_txtWHOLEBLOOD.Multiline = false;
            this.m_txtWHOLEBLOOD.Name = "m_txtWHOLEBLOOD";
            this.m_txtWHOLEBLOOD.Size = new System.Drawing.Size(62, 22);
            this.m_txtWHOLEBLOOD.TabIndex = 550;
            this.m_txtWHOLEBLOOD.Text = "";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(134, 22);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(35, 14);
            this.label66.TabIndex = 12;
            this.label66.Text = "单位";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(8, 22);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(63, 14);
            this.label65.TabIndex = 11;
            this.label65.Text = "1.红细胞";
            // 
            // m_txtRBC
            // 
            this.m_txtRBC.AccessibleDescription = "红细胞";
            this.m_txtRBC.BackColor = System.Drawing.Color.White;
            this.m_txtRBC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRBC.ForeColor = System.Drawing.Color.Black;
            this.m_txtRBC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRBC.Location = new System.Drawing.Point(72, 20);
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
            this.m_txtRBC.Size = new System.Drawing.Size(62, 22);
            this.m_txtRBC.TabIndex = 535;
            this.m_txtRBC.Text = "";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(308, 22);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(21, 14);
            this.label67.TabIndex = 12;
            this.label67.Text = "袋";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(182, 22);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(63, 14);
            this.label68.TabIndex = 11;
            this.label68.Text = "2.血小板";
            // 
            // m_txtPLT
            // 
            this.m_txtPLT.AccessibleDescription = "血小板";
            this.m_txtPLT.BackColor = System.Drawing.Color.White;
            this.m_txtPLT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPLT.ForeColor = System.Drawing.Color.Black;
            this.m_txtPLT.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPLT.Location = new System.Drawing.Point(246, 20);
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
            this.m_txtPLT.Size = new System.Drawing.Size(62, 22);
            this.m_txtPLT.TabIndex = 540;
            this.m_txtPLT.Text = "";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(342, 22);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(49, 14);
            this.label69.TabIndex = 11;
            this.label69.Text = "3.血浆";
            // 
            // m_txtPLASM
            // 
            this.m_txtPLASM.AccessibleDescription = "血浆";
            this.m_txtPLASM.BackColor = System.Drawing.Color.White;
            this.m_txtPLASM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPLASM.ForeColor = System.Drawing.Color.Black;
            this.m_txtPLASM.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtPLASM.Location = new System.Drawing.Point(390, 20);
            this.m_txtPLASM.m_BlnIgnoreUserInfo = false;
            this.m_txtPLASM.m_BlnPartControl = false;
            this.m_txtPLASM.m_BlnReadOnly = false;
            this.m_txtPLASM.m_BlnUnderLineDST = false;
            this.m_txtPLASM.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtPLASM.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtPLASM.m_IntCanModifyTime = 6;
            this.m_txtPLASM.m_IntPartControlLength = 0;
            this.m_txtPLASM.m_IntPartControlStartIndex = 0;
            this.m_txtPLASM.m_StrUserID = "";
            this.m_txtPLASM.m_StrUserName = "";
            this.m_txtPLASM.MaxLength = 8000;
            this.m_txtPLASM.Multiline = false;
            this.m_txtPLASM.Name = "m_txtPLASM";
            this.m_txtPLASM.Size = new System.Drawing.Size(62, 22);
            this.m_txtPLASM.TabIndex = 545;
            this.m_txtPLASM.Text = "";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(452, 22);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(21, 14);
            this.label70.TabIndex = 12;
            this.label70.Text = "ml";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(488, 22);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(49, 14);
            this.label71.TabIndex = 11;
            this.label71.Text = "4.全血";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(598, 22);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(21, 14);
            this.label72.TabIndex = 12;
            this.label72.Text = "ml";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(628, 22);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(49, 14);
            this.label73.TabIndex = 11;
            this.label73.Text = "5.其它";
            // 
            // m_txtOTHERBLOOD
            // 
            this.m_txtOTHERBLOOD.AccessibleDescription = "输血品种>>其它";
            this.m_txtOTHERBLOOD.BackColor = System.Drawing.Color.White;
            this.m_txtOTHERBLOOD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOTHERBLOOD.ForeColor = System.Drawing.Color.Black;
            this.m_txtOTHERBLOOD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOTHERBLOOD.Location = new System.Drawing.Point(676, 20);
            this.m_txtOTHERBLOOD.m_BlnIgnoreUserInfo = false;
            this.m_txtOTHERBLOOD.m_BlnPartControl = false;
            this.m_txtOTHERBLOOD.m_BlnReadOnly = false;
            this.m_txtOTHERBLOOD.m_BlnUnderLineDST = false;
            this.m_txtOTHERBLOOD.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOTHERBLOOD.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOTHERBLOOD.m_IntCanModifyTime = 6;
            this.m_txtOTHERBLOOD.m_IntPartControlLength = 0;
            this.m_txtOTHERBLOOD.m_IntPartControlStartIndex = 0;
            this.m_txtOTHERBLOOD.m_StrUserID = "";
            this.m_txtOTHERBLOOD.m_StrUserName = "";
            this.m_txtOTHERBLOOD.MaxLength = 8000;
            this.m_txtOTHERBLOOD.Multiline = false;
            this.m_txtOTHERBLOOD.Name = "m_txtOTHERBLOOD";
            this.m_txtOTHERBLOOD.Size = new System.Drawing.Size(62, 22);
            this.m_txtOTHERBLOOD.TabIndex = 555;
            this.m_txtOTHERBLOOD.Text = "";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(738, 22);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(21, 14);
            this.label74.TabIndex = 12;
            this.label74.Text = "ml";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(350, 186);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(21, 14);
            this.label64.TabIndex = 12;
            this.label64.Text = "Rh";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(37, 186);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(35, 14);
            this.label63.TabIndex = 11;
            this.label63.Text = "血型";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(8, 154);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(63, 14);
            this.label59.TabIndex = 10;
            this.label59.Text = "输血反应";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 88);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(63, 14);
            this.label58.TabIndex = 9;
            this.label58.Text = "示教病例";
            // 
            // m_pnlPATHOGENYRESULT
            // 
            this.m_pnlPATHOGENYRESULT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlPATHOGENYRESULT.Controls.Add(this.m_chkPATHOGENYRESULT1);
            this.m_pnlPATHOGENYRESULT.Controls.Add(this.m_chkPATHOGENYRESULT2);
            this.m_pnlPATHOGENYRESULT.Location = new System.Drawing.Point(594, 116);
            this.m_pnlPATHOGENYRESULT.Name = "m_pnlPATHOGENYRESULT";
            this.m_pnlPATHOGENYRESULT.Size = new System.Drawing.Size(132, 30);
            this.m_pnlPATHOGENYRESULT.TabIndex = 7;
            // 
            // m_chkPATHOGENYRESULT1
            // 
            this.m_chkPATHOGENYRESULT1.AccessibleDescription = "病原学送检结果>>阳性";
            this.m_chkPATHOGENYRESULT1.Location = new System.Drawing.Point(4, 2);
            this.m_chkPATHOGENYRESULT1.Name = "m_chkPATHOGENYRESULT1";
            this.m_chkPATHOGENYRESULT1.Size = new System.Drawing.Size(68, 24);
            this.m_chkPATHOGENYRESULT1.TabIndex = 445;
            this.m_chkPATHOGENYRESULT1.Text = "阳性、";
            this.m_chkPATHOGENYRESULT1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOGENYRESULT2
            // 
            this.m_chkPATHOGENYRESULT2.AccessibleDescription = "病原学送检结果>>阴性";
            this.m_chkPATHOGENYRESULT2.Location = new System.Drawing.Point(72, 2);
            this.m_chkPATHOGENYRESULT2.Name = "m_chkPATHOGENYRESULT2";
            this.m_chkPATHOGENYRESULT2.Size = new System.Drawing.Size(54, 24);
            this.m_chkPATHOGENYRESULT2.TabIndex = 450;
            this.m_chkPATHOGENYRESULT2.Text = "阴性";
            this.m_chkPATHOGENYRESULT2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(224, 122);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(84, 14);
            this.label56.TabIndex = 8;
            this.label56.Text = "病原学送检:";
            // 
            // m_pnlANTIBACTERIAL
            // 
            this.m_pnlANTIBACTERIAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlANTIBACTERIAL.Controls.Add(this.m_chkANTIBACTERIAL2);
            this.m_pnlANTIBACTERIAL.Controls.Add(this.m_chkANTIBACTERIAL1);
            this.m_pnlANTIBACTERIAL.Location = new System.Drawing.Point(96, 116);
            this.m_pnlANTIBACTERIAL.Name = "m_pnlANTIBACTERIAL";
            this.m_pnlANTIBACTERIAL.Size = new System.Drawing.Size(98, 30);
            this.m_pnlANTIBACTERIAL.TabIndex = 7;
            // 
            // m_chkANTIBACTERIAL2
            // 
            this.m_chkANTIBACTERIAL2.AccessibleDescription = "抗菌药物使用>>否";
            this.m_chkANTIBACTERIAL2.Location = new System.Drawing.Point(54, 2);
            this.m_chkANTIBACTERIAL2.Name = "m_chkANTIBACTERIAL2";
            this.m_chkANTIBACTERIAL2.Size = new System.Drawing.Size(54, 24);
            this.m_chkANTIBACTERIAL2.TabIndex = 430;
            this.m_chkANTIBACTERIAL2.Text = "否";
            this.m_chkANTIBACTERIAL2.Click += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkANTIBACTERIAL1
            // 
            this.m_chkANTIBACTERIAL1.AccessibleDescription = "抗菌药物使用>>是";
            this.m_chkANTIBACTERIAL1.Location = new System.Drawing.Point(4, 2);
            this.m_chkANTIBACTERIAL1.Name = "m_chkANTIBACTERIAL1";
            this.m_chkANTIBACTERIAL1.Size = new System.Drawing.Size(54, 24);
            this.m_chkANTIBACTERIAL1.TabIndex = 425;
            this.m_chkANTIBACTERIAL1.Text = "是、";
            this.m_chkANTIBACTERIAL1.Click += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 122);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(91, 14);
            this.label55.TabIndex = 6;
            this.label55.Text = "抗菌药物使用";
            // 
            // m_pnlQUALITY
            // 
            this.m_pnlQUALITY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlQUALITY.Controls.Add(this.m_chkQUALITY1);
            this.m_pnlQUALITY.Controls.Add(this.m_chkQUALITY2);
            this.m_pnlQUALITY.Controls.Add(this.m_chkQUALITY3);
            this.m_pnlQUALITY.Location = new System.Drawing.Point(594, 84);
            this.m_pnlQUALITY.Name = "m_pnlQUALITY";
            this.m_pnlQUALITY.Size = new System.Drawing.Size(166, 30);
            this.m_pnlQUALITY.TabIndex = 5;
            // 
            // m_chkQUALITY1
            // 
            this.m_chkQUALITY1.AccessibleDescription = "病案质量>>甲";
            this.m_chkQUALITY1.Location = new System.Drawing.Point(4, 2);
            this.m_chkQUALITY1.Name = "m_chkQUALITY1";
            this.m_chkQUALITY1.Size = new System.Drawing.Size(54, 24);
            this.m_chkQUALITY1.TabIndex = 410;
            this.m_chkQUALITY1.Text = "甲、";
            this.m_chkQUALITY1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkQUALITY2
            // 
            this.m_chkQUALITY2.AccessibleDescription = "病案质量>>乙";
            this.m_chkQUALITY2.Location = new System.Drawing.Point(62, 2);
            this.m_chkQUALITY2.Name = "m_chkQUALITY2";
            this.m_chkQUALITY2.Size = new System.Drawing.Size(54, 24);
            this.m_chkQUALITY2.TabIndex = 415;
            this.m_chkQUALITY2.Text = "乙、";
            this.m_chkQUALITY2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkQUALITY3
            // 
            this.m_chkQUALITY3.AccessibleDescription = "病案质量>>丙";
            this.m_chkQUALITY3.Location = new System.Drawing.Point(120, 2);
            this.m_chkQUALITY3.Name = "m_chkQUALITY3";
            this.m_chkQUALITY3.Size = new System.Drawing.Size(54, 24);
            this.m_chkQUALITY3.TabIndex = 420;
            this.m_chkQUALITY3.Text = "丙";
            this.m_chkQUALITY3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(532, 90);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(63, 14);
            this.label54.TabIndex = 4;
            this.label54.Text = "病案质量";
            // 
            // m_pnlFIRSTCASE
            // 
            this.m_pnlFIRSTCASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlFIRSTCASE.Controls.Add(this.m_chkFIRSTCASE2);
            this.m_pnlFIRSTCASE.Controls.Add(this.m_chkFIRSTCASE1);
            this.m_pnlFIRSTCASE.Location = new System.Drawing.Point(424, 84);
            this.m_pnlFIRSTCASE.Name = "m_pnlFIRSTCASE";
            this.m_pnlFIRSTCASE.Size = new System.Drawing.Size(96, 30);
            this.m_pnlFIRSTCASE.TabIndex = 3;
            // 
            // m_chkFIRSTCASE2
            // 
            this.m_chkFIRSTCASE2.AccessibleDescription = "为本院第一例>>否";
            this.m_chkFIRSTCASE2.Location = new System.Drawing.Point(54, 2);
            this.m_chkFIRSTCASE2.Name = "m_chkFIRSTCASE2";
            this.m_chkFIRSTCASE2.Size = new System.Drawing.Size(56, 24);
            this.m_chkFIRSTCASE2.TabIndex = 405;
            this.m_chkFIRSTCASE2.Text = "否";
            this.m_chkFIRSTCASE2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkFIRSTCASE1
            // 
            this.m_chkFIRSTCASE1.AccessibleDescription = "为本院第一例>>是";
            this.m_chkFIRSTCASE1.Location = new System.Drawing.Point(4, 2);
            this.m_chkFIRSTCASE1.Name = "m_chkFIRSTCASE1";
            this.m_chkFIRSTCASE1.Size = new System.Drawing.Size(56, 24);
            this.m_chkFIRSTCASE1.TabIndex = 400;
            this.m_chkFIRSTCASE1.Text = "是、";
            this.m_chkFIRSTCASE1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(174, 90);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(245, 14);
            this.label53.TabIndex = 2;
            this.label53.Text = "手术、治疗、检查、诊断为本院第一例";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.m_cboClinicPh);
            this.groupBox8.Controls.Add(this.m_cboClinicOUt);
            this.groupBox8.Controls.Add(this.label47);
            this.groupBox8.Controls.Add(this.label48);
            this.groupBox8.Controls.Add(this.m_cboInOut);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.m_cboBeforeOpAfterOp);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.m_cboDeathCheck);
            this.groupBox8.Controls.Add(this.m_cboClinicRad);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Location = new System.Drawing.Point(2, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(760, 74);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "诊断符合情况";
            // 
            // m_cboClinicPh
            // 
            this.m_cboClinicPh.AccessibleDescription = "诊断符合情况>>临床-病理";
            this.m_cboClinicPh.BackColor = System.Drawing.Color.White;
            this.m_cboClinicPh.BorderColor = System.Drawing.Color.Black;
            this.m_cboClinicPh.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboClinicPh.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboClinicPh.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboClinicPh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboClinicPh.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicPh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicPh.ForeColor = System.Drawing.Color.Black;
            this.m_cboClinicPh.ListBackColor = System.Drawing.Color.White;
            this.m_cboClinicPh.ListForeColor = System.Drawing.Color.Black;
            this.m_cboClinicPh.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboClinicPh.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboClinicPh.Location = new System.Drawing.Point(98, 46);
            this.m_cboClinicPh.m_BlnEnableItemEventMenu = false;
            this.m_cboClinicPh.Name = "m_cboClinicPh";
            this.m_cboClinicPh.SelectedIndex = -1;
            this.m_cboClinicPh.SelectedItem = null;
            this.m_cboClinicPh.SelectionStart = 0;
            this.m_cboClinicPh.Size = new System.Drawing.Size(102, 23);
            this.m_cboClinicPh.TabIndex = 375;
            this.m_cboClinicPh.TextBackColor = System.Drawing.Color.White;
            this.m_cboClinicPh.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboClinicOUt
            // 
            this.m_cboClinicOUt.AccessibleDescription = "诊断符合情况>>门诊-出院";
            this.m_cboClinicOUt.BackColor = System.Drawing.Color.White;
            this.m_cboClinicOUt.BorderColor = System.Drawing.Color.Black;
            this.m_cboClinicOUt.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboClinicOUt.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboClinicOUt.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboClinicOUt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboClinicOUt.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicOUt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicOUt.ForeColor = System.Drawing.Color.Black;
            this.m_cboClinicOUt.ListBackColor = System.Drawing.Color.White;
            this.m_cboClinicOUt.ListForeColor = System.Drawing.Color.Black;
            this.m_cboClinicOUt.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboClinicOUt.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboClinicOUt.Location = new System.Drawing.Point(98, 20);
            this.m_cboClinicOUt.m_BlnEnableItemEventMenu = false;
            this.m_cboClinicOUt.Name = "m_cboClinicOUt";
            this.m_cboClinicOUt.SelectedIndex = -1;
            this.m_cboClinicOUt.SelectedItem = null;
            this.m_cboClinicOUt.SelectionStart = 0;
            this.m_cboClinicOUt.Size = new System.Drawing.Size(102, 23);
            this.m_cboClinicOUt.TabIndex = 360;
            this.m_cboClinicOUt.TextBackColor = System.Drawing.Color.White;
            this.m_cboClinicOUt.TextForeColor = System.Drawing.Color.Black;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(8, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(91, 14);
            this.label47.TabIndex = 0;
            this.label47.Text = "门诊 ─ 出院";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(272, 22);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(91, 14);
            this.label48.TabIndex = 0;
            this.label48.Text = "入院 ─ 出院";
            // 
            // m_cboInOut
            // 
            this.m_cboInOut.AccessibleDescription = "诊断符合情况>>入院-出院";
            this.m_cboInOut.BackColor = System.Drawing.Color.White;
            this.m_cboInOut.BorderColor = System.Drawing.Color.Black;
            this.m_cboInOut.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboInOut.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboInOut.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboInOut.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboInOut.ForeColor = System.Drawing.Color.Black;
            this.m_cboInOut.ListBackColor = System.Drawing.Color.White;
            this.m_cboInOut.ListForeColor = System.Drawing.Color.Black;
            this.m_cboInOut.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboInOut.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboInOut.Location = new System.Drawing.Point(364, 20);
            this.m_cboInOut.m_BlnEnableItemEventMenu = false;
            this.m_cboInOut.Name = "m_cboInOut";
            this.m_cboInOut.SelectedIndex = -1;
            this.m_cboInOut.SelectedItem = null;
            this.m_cboInOut.SelectionStart = 0;
            this.m_cboInOut.Size = new System.Drawing.Size(102, 23);
            this.m_cboInOut.TabIndex = 365;
            this.m_cboInOut.TextBackColor = System.Drawing.Color.White;
            this.m_cboInOut.TextForeColor = System.Drawing.Color.Black;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(548, 22);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(91, 14);
            this.label49.TabIndex = 0;
            this.label49.Text = "术前 ─ 术后";
            // 
            // m_cboBeforeOpAfterOp
            // 
            this.m_cboBeforeOpAfterOp.AccessibleDescription = "诊断符合情况>>术前-术后";
            this.m_cboBeforeOpAfterOp.BackColor = System.Drawing.Color.White;
            this.m_cboBeforeOpAfterOp.BorderColor = System.Drawing.Color.Black;
            this.m_cboBeforeOpAfterOp.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBeforeOpAfterOp.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBeforeOpAfterOp.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBeforeOpAfterOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBeforeOpAfterOp.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBeforeOpAfterOp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBeforeOpAfterOp.ForeColor = System.Drawing.Color.Black;
            this.m_cboBeforeOpAfterOp.ListBackColor = System.Drawing.Color.White;
            this.m_cboBeforeOpAfterOp.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBeforeOpAfterOp.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBeforeOpAfterOp.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBeforeOpAfterOp.Location = new System.Drawing.Point(640, 20);
            this.m_cboBeforeOpAfterOp.m_BlnEnableItemEventMenu = false;
            this.m_cboBeforeOpAfterOp.Name = "m_cboBeforeOpAfterOp";
            this.m_cboBeforeOpAfterOp.SelectedIndex = -1;
            this.m_cboBeforeOpAfterOp.SelectedItem = null;
            this.m_cboBeforeOpAfterOp.SelectionStart = 0;
            this.m_cboBeforeOpAfterOp.Size = new System.Drawing.Size(102, 23);
            this.m_cboBeforeOpAfterOp.TabIndex = 370;
            this.m_cboBeforeOpAfterOp.TextBackColor = System.Drawing.Color.White;
            this.m_cboBeforeOpAfterOp.TextForeColor = System.Drawing.Color.Black;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(548, 48);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(91, 14);
            this.label50.TabIndex = 0;
            this.label50.Text = "临床 ─ 放射";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(272, 48);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(91, 14);
            this.label51.TabIndex = 0;
            this.label51.Text = "死亡 ─ 尸检";
            // 
            // m_cboDeathCheck
            // 
            this.m_cboDeathCheck.AccessibleDescription = "诊断符合情况>>死亡-尸检";
            this.m_cboDeathCheck.BackColor = System.Drawing.Color.White;
            this.m_cboDeathCheck.BorderColor = System.Drawing.Color.Black;
            this.m_cboDeathCheck.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDeathCheck.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDeathCheck.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDeathCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeathCheck.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDeathCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDeathCheck.ForeColor = System.Drawing.Color.Black;
            this.m_cboDeathCheck.ListBackColor = System.Drawing.Color.White;
            this.m_cboDeathCheck.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDeathCheck.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDeathCheck.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDeathCheck.Location = new System.Drawing.Point(364, 46);
            this.m_cboDeathCheck.m_BlnEnableItemEventMenu = false;
            this.m_cboDeathCheck.Name = "m_cboDeathCheck";
            this.m_cboDeathCheck.SelectedIndex = -1;
            this.m_cboDeathCheck.SelectedItem = null;
            this.m_cboDeathCheck.SelectionStart = 0;
            this.m_cboDeathCheck.Size = new System.Drawing.Size(102, 23);
            this.m_cboDeathCheck.TabIndex = 380;
            this.m_cboDeathCheck.TextBackColor = System.Drawing.Color.White;
            this.m_cboDeathCheck.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboClinicRad
            // 
            this.m_cboClinicRad.AccessibleDescription = "诊断符合情况>>临床-放射";
            this.m_cboClinicRad.BackColor = System.Drawing.Color.White;
            this.m_cboClinicRad.BorderColor = System.Drawing.Color.Black;
            this.m_cboClinicRad.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboClinicRad.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboClinicRad.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboClinicRad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboClinicRad.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicRad.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboClinicRad.ForeColor = System.Drawing.Color.Black;
            this.m_cboClinicRad.ListBackColor = System.Drawing.Color.White;
            this.m_cboClinicRad.ListForeColor = System.Drawing.Color.Black;
            this.m_cboClinicRad.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboClinicRad.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboClinicRad.Location = new System.Drawing.Point(640, 46);
            this.m_cboClinicRad.m_BlnEnableItemEventMenu = false;
            this.m_cboClinicRad.Name = "m_cboClinicRad";
            this.m_cboClinicRad.SelectedIndex = -1;
            this.m_cboClinicRad.SelectedItem = null;
            this.m_cboClinicRad.SelectionStart = 0;
            this.m_cboClinicRad.Size = new System.Drawing.Size(102, 23);
            this.m_cboClinicRad.TabIndex = 385;
            this.m_cboClinicRad.TextBackColor = System.Drawing.Color.White;
            this.m_cboClinicRad.TextForeColor = System.Drawing.Color.Black;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(8, 48);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(91, 14);
            this.label52.TabIndex = 0;
            this.label52.Text = "临床 ─ 病理";
            // 
            // m_pnlPATHOGENY
            // 
            this.m_pnlPATHOGENY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlPATHOGENY.Controls.Add(this.m_chkPATHOGENY2);
            this.m_pnlPATHOGENY.Controls.Add(this.m_chkPATHOGENY1);
            this.m_pnlPATHOGENY.Location = new System.Drawing.Point(308, 116);
            this.m_pnlPATHOGENY.Name = "m_pnlPATHOGENY";
            this.m_pnlPATHOGENY.Size = new System.Drawing.Size(94, 30);
            this.m_pnlPATHOGENY.TabIndex = 7;
            // 
            // m_chkPATHOGENY2
            // 
            this.m_chkPATHOGENY2.AccessibleDescription = "病原学送检>>否";
            this.m_chkPATHOGENY2.Location = new System.Drawing.Point(48, 2);
            this.m_chkPATHOGENY2.Name = "m_chkPATHOGENY2";
            this.m_chkPATHOGENY2.Size = new System.Drawing.Size(54, 24);
            this.m_chkPATHOGENY2.TabIndex = 440;
            this.m_chkPATHOGENY2.Text = "否";
            this.m_chkPATHOGENY2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkPATHOGENY1
            // 
            this.m_chkPATHOGENY1.AccessibleDescription = "病原学送检>>是";
            this.m_chkPATHOGENY1.Location = new System.Drawing.Point(4, 2);
            this.m_chkPATHOGENY1.Name = "m_chkPATHOGENY1";
            this.m_chkPATHOGENY1.Size = new System.Drawing.Size(54, 24);
            this.m_chkPATHOGENY1.TabIndex = 435;
            this.m_chkPATHOGENY1.Text = "是、";
            this.m_chkPATHOGENY1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(480, 122);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(112, 14);
            this.label57.TabIndex = 8;
            this.label57.Text = "病原学送检结果:";
            // 
            // m_pnlMODELCASE
            // 
            this.m_pnlMODELCASE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlMODELCASE.Controls.Add(this.m_chkMODELCASE2);
            this.m_pnlMODELCASE.Controls.Add(this.m_chkMODELCASE1);
            this.m_pnlMODELCASE.Location = new System.Drawing.Point(72, 84);
            this.m_pnlMODELCASE.Name = "m_pnlMODELCASE";
            this.m_pnlMODELCASE.Size = new System.Drawing.Size(90, 30);
            this.m_pnlMODELCASE.TabIndex = 3;
            // 
            // m_chkMODELCASE2
            // 
            this.m_chkMODELCASE2.AccessibleDescription = "示教病例>>否";
            this.m_chkMODELCASE2.Location = new System.Drawing.Point(48, 2);
            this.m_chkMODELCASE2.Name = "m_chkMODELCASE2";
            this.m_chkMODELCASE2.Size = new System.Drawing.Size(56, 24);
            this.m_chkMODELCASE2.TabIndex = 395;
            this.m_chkMODELCASE2.Text = "否";
            this.m_chkMODELCASE2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMODELCASE1
            // 
            this.m_chkMODELCASE1.AccessibleDescription = "示教病例>>是";
            this.m_chkMODELCASE1.Location = new System.Drawing.Point(4, 2);
            this.m_chkMODELCASE1.Name = "m_chkMODELCASE1";
            this.m_chkMODELCASE1.Size = new System.Drawing.Size(56, 24);
            this.m_chkMODELCASE1.TabIndex = 390;
            this.m_chkMODELCASE1.Text = "是、";
            this.m_chkMODELCASE1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_pnlBLOODTRANSACTOIN
            // 
            this.m_pnlBLOODTRANSACTOIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlBLOODTRANSACTOIN.Controls.Add(this.m_chkBLOODTRANSACTOIN2);
            this.m_pnlBLOODTRANSACTOIN.Controls.Add(this.m_chkBLOODTRANSACTOIN1);
            this.m_pnlBLOODTRANSACTOIN.Location = new System.Drawing.Point(72, 148);
            this.m_pnlBLOODTRANSACTOIN.Name = "m_pnlBLOODTRANSACTOIN";
            this.m_pnlBLOODTRANSACTOIN.Size = new System.Drawing.Size(98, 30);
            this.m_pnlBLOODTRANSACTOIN.TabIndex = 7;
            // 
            // m_chkBLOODTRANSACTOIN2
            // 
            this.m_chkBLOODTRANSACTOIN2.AccessibleDescription = "输血反应>>无";
            this.m_chkBLOODTRANSACTOIN2.Location = new System.Drawing.Point(54, 2);
            this.m_chkBLOODTRANSACTOIN2.Name = "m_chkBLOODTRANSACTOIN2";
            this.m_chkBLOODTRANSACTOIN2.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTRANSACTOIN2.TabIndex = 460;
            this.m_chkBLOODTRANSACTOIN2.Text = "无";
            this.m_chkBLOODTRANSACTOIN2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODTRANSACTOIN1
            // 
            this.m_chkBLOODTRANSACTOIN1.AccessibleDescription = "输血反应>>有";
            this.m_chkBLOODTRANSACTOIN1.Location = new System.Drawing.Point(4, 2);
            this.m_chkBLOODTRANSACTOIN1.Name = "m_chkBLOODTRANSACTOIN1";
            this.m_chkBLOODTRANSACTOIN1.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTRANSACTOIN1.TabIndex = 455;
            this.m_chkBLOODTRANSACTOIN1.Text = "有、";
            this.m_chkBLOODTRANSACTOIN1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(188, 154);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(63, 14);
            this.label60.TabIndex = 10;
            this.label60.Text = "输液反应";
            // 
            // m_pnlTRANSFUSIONSACTION
            // 
            this.m_pnlTRANSFUSIONSACTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlTRANSFUSIONSACTION.Controls.Add(this.m_chkTRANSFUSIONSACTION2);
            this.m_pnlTRANSFUSIONSACTION.Controls.Add(this.m_chkTRANSFUSIONSACTION1);
            this.m_pnlTRANSFUSIONSACTION.Location = new System.Drawing.Point(252, 148);
            this.m_pnlTRANSFUSIONSACTION.Name = "m_pnlTRANSFUSIONSACTION";
            this.m_pnlTRANSFUSIONSACTION.Size = new System.Drawing.Size(98, 30);
            this.m_pnlTRANSFUSIONSACTION.TabIndex = 7;
            // 
            // m_chkTRANSFUSIONSACTION2
            // 
            this.m_chkTRANSFUSIONSACTION2.AccessibleDescription = "输液反应>>无";
            this.m_chkTRANSFUSIONSACTION2.Location = new System.Drawing.Point(54, 2);
            this.m_chkTRANSFUSIONSACTION2.Name = "m_chkTRANSFUSIONSACTION2";
            this.m_chkTRANSFUSIONSACTION2.Size = new System.Drawing.Size(54, 24);
            this.m_chkTRANSFUSIONSACTION2.TabIndex = 470;
            this.m_chkTRANSFUSIONSACTION2.Text = "无";
            this.m_chkTRANSFUSIONSACTION2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkTRANSFUSIONSACTION1
            // 
            this.m_chkTRANSFUSIONSACTION1.AccessibleDescription = "输液反应>>有";
            this.m_chkTRANSFUSIONSACTION1.Location = new System.Drawing.Point(4, 2);
            this.m_chkTRANSFUSIONSACTION1.Name = "m_chkTRANSFUSIONSACTION1";
            this.m_chkTRANSFUSIONSACTION1.Size = new System.Drawing.Size(54, 24);
            this.m_chkTRANSFUSIONSACTION1.TabIndex = 465;
            this.m_chkTRANSFUSIONSACTION1.Text = "有、";
            this.m_chkTRANSFUSIONSACTION1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(375, 154);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(49, 14);
            this.label61.TabIndex = 10;
            this.label61.Text = "CT检查";
            // 
            // m_pnlCTCHECK
            // 
            this.m_pnlCTCHECK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlCTCHECK.Controls.Add(this.m_chkCTCHECK2);
            this.m_pnlCTCHECK.Controls.Add(this.m_chkCTCHECK1);
            this.m_pnlCTCHECK.Location = new System.Drawing.Point(424, 148);
            this.m_pnlCTCHECK.Name = "m_pnlCTCHECK";
            this.m_pnlCTCHECK.Size = new System.Drawing.Size(98, 30);
            this.m_pnlCTCHECK.TabIndex = 7;
            // 
            // m_chkCTCHECK2
            // 
            this.m_chkCTCHECK2.AccessibleDescription = "CT检查>>无";
            this.m_chkCTCHECK2.Location = new System.Drawing.Point(54, 2);
            this.m_chkCTCHECK2.Name = "m_chkCTCHECK2";
            this.m_chkCTCHECK2.Size = new System.Drawing.Size(54, 24);
            this.m_chkCTCHECK2.TabIndex = 480;
            this.m_chkCTCHECK2.Text = "无";
            this.m_chkCTCHECK2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkCTCHECK1
            // 
            this.m_chkCTCHECK1.AccessibleDescription = "CT检查>>有";
            this.m_chkCTCHECK1.Location = new System.Drawing.Point(4, 2);
            this.m_chkCTCHECK1.Name = "m_chkCTCHECK1";
            this.m_chkCTCHECK1.Size = new System.Drawing.Size(54, 24);
            this.m_chkCTCHECK1.TabIndex = 475;
            this.m_chkCTCHECK1.Text = "有、";
            this.m_chkCTCHECK1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(568, 154);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(56, 14);
            this.label62.TabIndex = 10;
            this.label62.Text = "MRI检查";
            // 
            // m_pnlMRICHECK
            // 
            this.m_pnlMRICHECK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlMRICHECK.Controls.Add(this.m_chkMRICHECK2);
            this.m_pnlMRICHECK.Controls.Add(this.m_chkMRICHECK1);
            this.m_pnlMRICHECK.Location = new System.Drawing.Point(626, 148);
            this.m_pnlMRICHECK.Name = "m_pnlMRICHECK";
            this.m_pnlMRICHECK.Size = new System.Drawing.Size(98, 30);
            this.m_pnlMRICHECK.TabIndex = 7;
            // 
            // m_chkMRICHECK2
            // 
            this.m_chkMRICHECK2.AccessibleDescription = "MRI检查>>无";
            this.m_chkMRICHECK2.Location = new System.Drawing.Point(54, 2);
            this.m_chkMRICHECK2.Name = "m_chkMRICHECK2";
            this.m_chkMRICHECK2.Size = new System.Drawing.Size(54, 24);
            this.m_chkMRICHECK2.TabIndex = 490;
            this.m_chkMRICHECK2.Text = "无";
            this.m_chkMRICHECK2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkMRICHECK1
            // 
            this.m_chkMRICHECK1.AccessibleDescription = "MRI检查>>有";
            this.m_chkMRICHECK1.Location = new System.Drawing.Point(4, 2);
            this.m_chkMRICHECK1.Name = "m_chkMRICHECK1";
            this.m_chkMRICHECK1.Size = new System.Drawing.Size(54, 24);
            this.m_chkMRICHECK1.TabIndex = 485;
            this.m_chkMRICHECK1.Text = "有、";
            this.m_chkMRICHECK1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_pnlBLOODTYPE
            // 
            this.m_pnlBLOODTYPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlBLOODTYPE.Controls.Add(this.m_chkBLOODTYPE4);
            this.m_pnlBLOODTYPE.Controls.Add(this.m_chkBLOODTYPE3);
            this.m_pnlBLOODTYPE.Controls.Add(this.m_chkBLOODTYPE2);
            this.m_pnlBLOODTYPE.Controls.Add(this.m_chkBLOODTYPE1);
            this.m_pnlBLOODTYPE.Controls.Add(this.m_chkBLOODTYPE0);
            this.m_pnlBLOODTYPE.Location = new System.Drawing.Point(72, 180);
            this.m_pnlBLOODTYPE.Name = "m_pnlBLOODTYPE";
            this.m_pnlBLOODTYPE.Size = new System.Drawing.Size(246, 30);
            this.m_pnlBLOODTYPE.TabIndex = 7;
            // 
            // m_chkBLOODTYPE4
            // 
            this.m_chkBLOODTYPE4.AccessibleDescription = "血型>>O";
            this.m_chkBLOODTYPE4.Checked = true;
            this.m_chkBLOODTYPE4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkBLOODTYPE4.Location = new System.Drawing.Point(208, 2);
            this.m_chkBLOODTYPE4.Name = "m_chkBLOODTYPE4";
            this.m_chkBLOODTYPE4.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTYPE4.TabIndex = 515;
            this.m_chkBLOODTYPE4.Text = "O";
            this.m_chkBLOODTYPE4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODTYPE3
            // 
            this.m_chkBLOODTYPE3.AccessibleDescription = "血型>>AB";
            this.m_chkBLOODTYPE3.Location = new System.Drawing.Point(160, 2);
            this.m_chkBLOODTYPE3.Name = "m_chkBLOODTYPE3";
            this.m_chkBLOODTYPE3.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTYPE3.TabIndex = 510;
            this.m_chkBLOODTYPE3.Text = "AB";
            this.m_chkBLOODTYPE3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODTYPE2
            // 
            this.m_chkBLOODTYPE2.AccessibleDescription = "血型>>B";
            this.m_chkBLOODTYPE2.Location = new System.Drawing.Point(112, 2);
            this.m_chkBLOODTYPE2.Name = "m_chkBLOODTYPE2";
            this.m_chkBLOODTYPE2.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTYPE2.TabIndex = 505;
            this.m_chkBLOODTYPE2.Text = "B";
            this.m_chkBLOODTYPE2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODTYPE1
            // 
            this.m_chkBLOODTYPE1.AccessibleDescription = "血型>>A";
            this.m_chkBLOODTYPE1.Location = new System.Drawing.Point(64, 2);
            this.m_chkBLOODTYPE1.Name = "m_chkBLOODTYPE1";
            this.m_chkBLOODTYPE1.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTYPE1.TabIndex = 500;
            this.m_chkBLOODTYPE1.Text = "A";
            this.m_chkBLOODTYPE1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODTYPE0
            // 
            this.m_chkBLOODTYPE0.AccessibleDescription = "血型>>不详";
            this.m_chkBLOODTYPE0.Location = new System.Drawing.Point(4, 2);
            this.m_chkBLOODTYPE0.Name = "m_chkBLOODTYPE0";
            this.m_chkBLOODTYPE0.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODTYPE0.TabIndex = 495;
            this.m_chkBLOODTYPE0.Text = "不详";
            this.m_chkBLOODTYPE0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_pnlBLOODRH
            // 
            this.m_pnlBLOODRH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlBLOODRH.Controls.Add(this.m_chkBLOODRH1);
            this.m_pnlBLOODRH.Controls.Add(this.m_chkBLOODRH0);
            this.m_pnlBLOODRH.Controls.Add(this.m_chkBLOODRH2);
            this.m_pnlBLOODRH.Location = new System.Drawing.Point(372, 180);
            this.m_pnlBLOODRH.Name = "m_pnlBLOODRH";
            this.m_pnlBLOODRH.Size = new System.Drawing.Size(150, 30);
            this.m_pnlBLOODRH.TabIndex = 7;
            // 
            // m_chkBLOODRH1
            // 
            this.m_chkBLOODRH1.AccessibleDescription = "Rh>>阴";
            this.m_chkBLOODRH1.Location = new System.Drawing.Point(64, 2);
            this.m_chkBLOODRH1.Name = "m_chkBLOODRH1";
            this.m_chkBLOODRH1.Size = new System.Drawing.Size(40, 24);
            this.m_chkBLOODRH1.TabIndex = 525;
            this.m_chkBLOODRH1.Text = "阴";
            this.m_chkBLOODRH1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODRH0
            // 
            this.m_chkBLOODRH0.AccessibleDescription = "Rh>>不详";
            this.m_chkBLOODRH0.Location = new System.Drawing.Point(4, 2);
            this.m_chkBLOODRH0.Name = "m_chkBLOODRH0";
            this.m_chkBLOODRH0.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODRH0.TabIndex = 520;
            this.m_chkBLOODRH0.Text = "不详";
            this.m_chkBLOODRH0.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_chkBLOODRH2
            // 
            this.m_chkBLOODRH2.AccessibleDescription = "Rh>>阳";
            this.m_chkBLOODRH2.Location = new System.Drawing.Point(104, 2);
            this.m_chkBLOODRH2.Name = "m_chkBLOODRH2";
            this.m_chkBLOODRH2.Size = new System.Drawing.Size(54, 24);
            this.m_chkBLOODRH2.TabIndex = 530;
            this.m_chkBLOODRH2.Text = "阳";
            this.m_chkBLOODRH2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_cmdOutHospitalDoc
            // 
            this.m_cmdOutHospitalDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdOutHospitalDoc.DefaultScheme = true;
            this.m_cmdOutHospitalDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOutHospitalDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOutHospitalDoc.Hint = "";
            this.m_cmdOutHospitalDoc.Location = new System.Drawing.Point(554, 270);
            this.m_cmdOutHospitalDoc.Name = "m_cmdOutHospitalDoc";
            this.m_cmdOutHospitalDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOutHospitalDoc.Size = new System.Drawing.Size(92, 24);
            this.m_cmdOutHospitalDoc.TabIndex = 575;
            this.m_cmdOutHospitalDoc.Text = "出院医师:";
            // 
            // m_cmdNEATEN
            // 
            this.m_cmdNEATEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdNEATEN.DefaultScheme = true;
            this.m_cmdNEATEN.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNEATEN.Enabled = false;
            this.m_cmdNEATEN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNEATEN.Hint = "";
            this.m_cmdNEATEN.Location = new System.Drawing.Point(2, 444);
            this.m_cmdNEATEN.Name = "m_cmdNEATEN";
            this.m_cmdNEATEN.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNEATEN.Size = new System.Drawing.Size(92, 24);
            this.m_cmdNEATEN.TabIndex = 700;
            this.m_cmdNEATEN.Text = "整  理:";
            // 
            // m_cmdCODER
            // 
            this.m_cmdCODER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdCODER.DefaultScheme = true;
            this.m_cmdCODER.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCODER.Enabled = false;
            this.m_cmdCODER.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCODER.Hint = "";
            this.m_cmdCODER.Location = new System.Drawing.Point(184, 444);
            this.m_cmdCODER.Name = "m_cmdCODER";
            this.m_cmdCODER.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCODER.Size = new System.Drawing.Size(92, 24);
            this.m_cmdCODER.TabIndex = 705;
            this.m_cmdCODER.Text = "编  码:";
            // 
            // m_cmdINPUTMACHINE
            // 
            this.m_cmdINPUTMACHINE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdINPUTMACHINE.DefaultScheme = true;
            this.m_cmdINPUTMACHINE.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdINPUTMACHINE.Enabled = false;
            this.m_cmdINPUTMACHINE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdINPUTMACHINE.Hint = "";
            this.m_cmdINPUTMACHINE.Location = new System.Drawing.Point(366, 444);
            this.m_cmdINPUTMACHINE.Name = "m_cmdINPUTMACHINE";
            this.m_cmdINPUTMACHINE.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdINPUTMACHINE.Size = new System.Drawing.Size(92, 24);
            this.m_cmdINPUTMACHINE.TabIndex = 710;
            this.m_cmdINPUTMACHINE.Text = "入  机:";
            // 
            // m_cmdSTATISTIC
            // 
            this.m_cmdSTATISTIC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSTATISTIC.DefaultScheme = true;
            this.m_cmdSTATISTIC.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSTATISTIC.Enabled = false;
            this.m_cmdSTATISTIC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSTATISTIC.Hint = "";
            this.m_cmdSTATISTIC.Location = new System.Drawing.Point(554, 444);
            this.m_cmdSTATISTIC.Name = "m_cmdSTATISTIC";
            this.m_cmdSTATISTIC.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSTATISTIC.Size = new System.Drawing.Size(92, 24);
            this.m_cmdSTATISTIC.TabIndex = 715;
            this.m_cmdSTATISTIC.Text = "统  计:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            // 
            // lblOccupation
            // 
            this.lblOccupation.AccessibleDescription = "职业";
            this.lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOccupation.Location = new System.Drawing.Point(616, 72);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(164, 20);
            this.lblOccupation.TabIndex = 10000021;
            this.lblOccupation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cboPayType
            // 
            this.m_cboPayType.AccessibleDescription = "付费方式";
            this.m_cboPayType.BackColor = System.Drawing.Color.White;
            this.m_cboPayType.BorderColor = System.Drawing.Color.Black;
            this.m_cboPayType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboPayType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboPayType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboPayType.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPayType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboPayType.ForeColor = System.Drawing.Color.Black;
            this.m_cboPayType.ListBackColor = System.Drawing.Color.White;
            this.m_cboPayType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboPayType.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboPayType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboPayType.Location = new System.Drawing.Point(240, 70);
            this.m_cboPayType.m_BlnEnableItemEventMenu = true;
            this.m_cboPayType.Name = "m_cboPayType";
            this.m_cboPayType.SelectedIndex = -1;
            this.m_cboPayType.SelectedItem = null;
            this.m_cboPayType.SelectionStart = 0;
            this.m_cboPayType.Size = new System.Drawing.Size(144, 23);
            this.m_cboPayType.TabIndex = 10;
            this.m_cboPayType.TextBackColor = System.Drawing.Color.White;
            this.m_cboPayType.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblOccupationTitle
            // 
            this.lblOccupationTitle.AutoSize = true;
            this.lblOccupationTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOccupationTitle.Location = new System.Drawing.Point(568, 72);
            this.lblOccupationTitle.Name = "lblOccupationTitle";
            this.lblOccupationTitle.Size = new System.Drawing.Size(42, 14);
            this.lblOccupationTitle.TabIndex = 10000022;
            this.lblOccupationTitle.Text = "职业:";
            this.lblOccupationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarried
            // 
            this.lblMarried.AccessibleDescription = "婚姻状况";
            this.lblMarried.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMarried.Location = new System.Drawing.Point(458, 72);
            this.lblMarried.Name = "lblMarried";
            this.lblMarried.Size = new System.Drawing.Size(98, 20);
            this.lblMarried.TabIndex = 10000020;
            this.lblMarried.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMarriedTitle
            // 
            this.lblMarriedTitle.AutoSize = true;
            this.lblMarriedTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMarriedTitle.Location = new System.Drawing.Point(385, 72);
            this.lblMarriedTitle.Name = "lblMarriedTitle";
            this.lblMarriedTitle.Size = new System.Drawing.Size(70, 14);
            this.lblMarriedTitle.TabIndex = 10000019;
            this.lblMarriedTitle.Text = "婚姻状况:";
            this.lblMarriedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000017;
            this.label2.Text = "付费方式:";
            // 
            // lblInHospitalTimes
            // 
            this.lblInHospitalTimes.AccessibleDescription = "入院次数";
            this.lblInHospitalTimes.Location = new System.Drawing.Point(86, 72);
            this.lblInHospitalTimes.Name = "lblInHospitalTimes";
            this.lblInHospitalTimes.Size = new System.Drawing.Size(26, 19);
            this.lblInHospitalTimes.TabIndex = 10000016;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 10000015;
            this.label1.Text = "第    次入院";
            // 
            // m_cmdSubmit
            // 
            this.m_cmdSubmit.AccessibleDescription = "提交";
            this.m_cmdSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))), ((int)(((byte)(237)))));
            this.m_cmdSubmit.DefaultScheme = true;
            this.m_cmdSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSubmit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSubmit.Hint = "";
            this.m_cmdSubmit.Location = new System.Drawing.Point(6, 70);
            this.m_cmdSubmit.Name = "m_cmdSubmit";
            this.m_cmdSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSubmit.Size = new System.Drawing.Size(60, 24);
            this.m_cmdSubmit.TabIndex = 10000023;
            this.m_cmdSubmit.Text = "提交";
            this.m_cmdSubmit.Visible = false;
            this.m_cmdSubmit.Click += new System.EventHandler(this.m_cmdSubmit_Click);
            // 
            // m_lblTips
            // 
            this.m_lblTips.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.m_lblTips.Location = new System.Drawing.Point(10, 613);
            this.m_lblTips.Name = "m_lblTips";
            this.m_lblTips.Size = new System.Drawing.Size(752, 14);
            this.m_lblTips.TabIndex = 10000027;
            // 
            // frmInHospitalMainRecord_GX
            // 
            this.ClientSize = new System.Drawing.Size(792, 659);
            this.Controls.Add(this.m_cmdSubmit);
            this.Controls.Add(this.lblInHospitalTimes);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.lblMarried);
            this.Controls.Add(this.m_cboPayType);
            this.Controls.Add(this.lblMarriedTitle);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOccupationTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lblTips);
            this.Name = "frmInHospitalMainRecord_GX";
            this.Text = "住院病案首页";
            this.Load += new System.EventHandler(this.frmInHospitalMainRecord_GX_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_lblTips, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblOccupationTitle, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblMarriedTitle, 0);
            this.Controls.SetChildIndex(this.m_cboPayType, 0);
            this.Controls.SetChildIndex(this.lblMarried, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.lblInHospitalTimes, 0);
            this.Controls.SetChildIndex(this.m_cmdSubmit, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInHospitalDiagnosis)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pnlInstanceWhenIn.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.m_pnlCOMPLICATIONSEQ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOtherDiagnosis)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.m_pnlMAINCONDITIONSEQ.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.m_pnlINFECTIONCONDICTIONSEQ.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.m_pnlPATHOLOGYDIAGNOSISSEQ.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.m_pnlHASREMIND.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperation)).EndInit();
            this.m_pnlNEW5DISEASE.ResumeLayout(false);
            this.m_pnlSECONDLEVELTRANSFER.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.m_pnlXRayCheck.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.m_pnlPATHOGENYRESULT.ResumeLayout(false);
            this.m_pnlANTIBACTERIAL.ResumeLayout(false);
            this.m_pnlQUALITY.ResumeLayout(false);
            this.m_pnlFIRSTCASE.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.m_pnlPATHOGENY.ResumeLayout(false);
            this.m_pnlMODELCASE.ResumeLayout(false);
            this.m_pnlBLOODTRANSACTOIN.ResumeLayout(false);
            this.m_pnlTRANSFUSIONSACTION.ResumeLayout(false);
            this.m_pnlCTCHECK.ResumeLayout(false);
            this.m_pnlMRICHECK.ResumeLayout(false);
            this.m_pnlBLOODTYPE.ResumeLayout(false);
            this.m_pnlBLOODRH.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

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
            if (m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                return;
            }
            if (m_objCollection != null && m_objCollection.m_objMain != null && m_objCollection.m_objMain.m_intSUBMIT_INT == 1)
            {
                clsPublicFunction.ShowInformationMessageBox("不能删除已提交至病案室的记录！");
                return;
            }

            long m_lngRe = m_lngDelete();
            if (m_lngRe > 0)
            {
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
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

        public void Save()
        {  
            long m_lngRe = m_lngSave();
            if (m_lngRe > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
            }
        }

        public void Undo()
        {

        }
        public void Verify()
        {

            try
            {
                //检查当前病人变量是否为null 
                //				if(m_objCollection == null)
                //				{
                //					clsPublicFunction.ShowInformationMessageBox("未选定病人,无法验证!");
                //				}
                //				string strInPatientID =m_objCollection.m_objContent.m_strInPatientID;
                //				string strInPatientDate =DateTime.Parse(m_objCollection.m_objContent.m_strInPatientDate).ToString("yyyy-MM-dd HH:mm:ss");
                //				string strRecordID=strInPatientID.Trim()+"-"+strInPatientDate;
                //				long lngRes=m_lngSignVerify(this.Name.Trim(),strRecordID);
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

        public override int m_IntFormID
        {
            get
            {
                return 110;
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

        #region 选择TreeView结点事件
        private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            m_mthRecordChangedToSave();

            m_bolIfHasSave = false;
            m_strOpenDate = null;
            m_txtFocusedRichTextBox = null;
            m_RtbCurrentTextBox = null;
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_mthCleanUpPatientDetailInfo();
            m_objCollection = null;
            if (trvTime.SelectedNode.Tag == null)
            {
                m_mthSetControlReadOnly(this, true);
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
                m_mthAddFormStatusForClosingSave();
                return;

            }

            //设置病人当次住院的基本信息
            m_mthOnlySetPatientInfo(m_objSelectedPatient);

            m_objSelectedPatient.m_ObjPeopleInfo = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo;

            txtInPatientID.Text = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;

            long lngRes = m_objDomain.m_lngGetRegisterIDByPatient(m_objSelectedPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out m_strRegisterID);
            if (!string.IsNullOrEmpty(m_strRegisterID))
            {
                frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = m_strRegisterID;
            }
            m_objBaseCurrentPatient.m_StrRegisterId = m_strRegisterID;

            m_mthSetPatientCurrentInHospitalDeptInfo();
            m_mthSetControlReadOnly(this, true);
            this.m_cmdSubmit.Enabled = true;
            this.m_cmdSubmit.Text = "提交";

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
            m_mthSetSignReadOnly();
        }
        #endregion

        #region CheckBox选择事件
        /// <summary>
        /// CheckBox选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Panel objPnl = (Panel)((CheckBox)sender).Parent;
            if (objPnl == null)
                return;
            if (((CheckBox)sender).Checked)
            {
                string str = ((CheckBox)sender).Name;
                foreach (Control chk in objPnl.Controls)
                {
                    if (chk.GetType().FullName != "System.Windows.Forms.CheckBox")
                        continue;
                    else if (((CheckBox)chk).Name.Trim() != str.Trim())
                        ((CheckBox)chk).Checked = !((CheckBox)sender).Checked;
                }
            }

            switch (((CheckBox)sender).Name)
            {
                case "m_chkMAINCONDITIONSEQ4":
                    if (((CheckBox)sender).Checked)
                        m_txtMainDiagnosisOther.Enabled = true;
                    else
                    {
                        m_txtMainDiagnosisOther.Enabled = false;
                        m_txtMainDiagnosisOther.Text = "";
                    }
                    break;
                case "m_chkCOMPLICATIONSEQ4":
                    if (((CheckBox)sender).Checked)
                        m_txtCOMPLICATIONOther.Enabled = true;
                    else
                    {
                        m_txtCOMPLICATIONOther.Enabled = false;
                        m_txtCOMPLICATIONOther.Text = "";
                    }
                    break;
                case "m_chkINFECTIONCONDICTIONSEQ4":
                    if (((CheckBox)sender).Checked)
                        m_txtINFECTIONDIAGNOSISOther.Enabled = true;
                    else
                    {
                        m_txtINFECTIONDIAGNOSISOther.Enabled = false;
                        m_txtINFECTIONDIAGNOSISOther.Text = "";
                    }
                    break;
                case "m_chkPATHOLOGYDIAGNOSISSEQ4":
                    if (((CheckBox)sender).Checked)
                        m_txtPATHOLOGYDIAGNOSISOther.Enabled = true;
                    else
                    {
                        m_txtPATHOLOGYDIAGNOSISOther.Enabled = false;
                        m_txtPATHOLOGYDIAGNOSISOther.Text = "";
                    }
                    break;
                case "m_chkHASREMIND2":
                    if (((CheckBox)sender).Checked)
                    {
                        m_txtREMINDTERM.Text = "无";
                    }
                    break;
                case "m_chkPATHOGENY2":
                    if (((CheckBox)sender).Checked)
                    {
                        m_pnlPATHOGENYRESULT.Enabled = false;
                        m_chkPATHOGENYRESULT1.Checked = false;
                        m_chkPATHOGENYRESULT2.Checked = false;
                    }
                    else
                    {
                        m_pnlPATHOGENYRESULT.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 设置RichTextBox属性
        private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox = null;//存放当前获得焦点的RichTextBox
        private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            m_txtFocusedRichTextBox = ((com.digitalwave.controls.ctlRichTextBox)(sender));
        }

        /// <summary>
        /// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
        /// </summary>
        /// <param name="p_objRichTextBox"></param>
        protected void m_mthSetRichTextBoxAttrib(com.digitalwave.controls.ctlRichTextBox p_objRichTextBox)
        {
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
            //设置右键菜单			
            p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);


            //设置其他属性			
            p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
            p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
            p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
            p_objRichTextBox.m_ClrDST = Color.Red;
            p_objRichTextBox.ForeColor = SystemColors.WindowText;
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

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(string p_strCreateUserID,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_blnReset)
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

        #endregion

        #region 初始化DataTable
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        private void m_mthInitDataTable()
        {
            DataColumn dtcTemp;

            m_dtbInHospitalDiagnosis = new DataTable("InHospitalDiagnose");
            DataColumn dcInHos = this.m_dtbInHospitalDiagnosis.Columns.Add("诊断内容");
            dcInHos.DefaultValue = "";
            DataColumn dcInHosStat = this.m_dtbInHospitalDiagnosis.Columns.Add("统计码");
            dcInHosStat.DefaultValue = "";
            DataColumn dcInHosICD = this.m_dtbInHospitalDiagnosis.Columns.Add("ICD码");
            dcInHosICD.DefaultValue = "";

            dtgInHospitalDiagnosis.DataSource = m_dtbInHospitalDiagnosis;


            m_dtbOtherDiagnosis = new DataTable("OtherDiagnosis");
            DataColumn dc = this.m_dtbOtherDiagnosis.Columns.Add("诊断内容");
            dc.DefaultValue = "";

            dtcTemp = new DataColumn("治愈");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("好转");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("未愈");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("死亡");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("其他");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);
            dtcTemp = new DataColumn("正常分娩");
            dtcTemp.DataType = typeof(bool);
            dtcTemp.DefaultValue = false;
            this.m_dtbOtherDiagnosis.Columns.Add(dtcTemp);

            DataColumn dcStat = this.m_dtbOtherDiagnosis.Columns.Add("统计码");
            dcStat.DefaultValue = "";

            DataColumn dcICD = this.m_dtbOtherDiagnosis.Columns.Add("ICD码");
            dcICD.DefaultValue = "";

            this.dtgOtherDiagnosis.DataSource = m_dtbOtherDiagnosis;

            m_dtbOperationDetail = new DataTable("OperationDetail");
            dtcTemp = new DataColumn("手术、操作日期");
            dtcTemp.DataType = typeof(System.DateTime);
            dtcTemp.DefaultValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.m_dtbOperationDetail.Columns.Add(dtcTemp);
            this.m_dtbOperationDetail.Columns.Add("手术、操作名称");
            this.m_dtbOperationDetail.Columns.Add("术者");
            this.m_dtbOperationDetail.Columns.Add("Ⅰ助");
            this.m_dtbOperationDetail.Columns.Add("Ⅱ助");
            this.m_dtbOperationDetail.Columns.Add("麻醉方式");//6
            this.m_dtbOperationDetail.Columns.Add("切口");
            this.m_dtbOperationDetail.Columns.Add("麻醉医生");//8
            this.m_dtbOperationDetail.Columns.Add("手术、操作编码");
            this.m_dtbOperationDetail.Columns.Add("AnesthesiaModeID");
            this.m_dtbOperationDetail.Columns.Add("OperatorID");
            this.m_dtbOperationDetail.Columns.Add("Assistant1ID");
            this.m_dtbOperationDetail.Columns.Add("Assistant2ID");
            this.m_dtbOperationDetail.Columns.Add("AnesthetistID");
            #region 麻醉及手术名称相关事件定义
            this.dtcOperationDate.TextBox.TextChanged += new EventHandler(OperationDate_TextChanged);
            this.dtcAanaesthesiaMode.TextBox.GotFocus += new EventHandler(dtcAanaesthesiaMode_GotFocus);
            this.dtcOperationID.TextBox.KeyDown += new KeyEventHandler(OperationDesc_KeyDown);
            this.dtcOperationName.TextBox.KeyDown += new KeyEventHandler(OperationDesc_KeyDown);
            this.dtcOperationID.TextBox.LostFocus += new EventHandler(OperationDesc_LostFocus);
            this.dtcOperationName.TextBox.LostFocus += new EventHandler(OperationDesc_LostFocus);
            this.dtcOperationID.TextBox.GotFocus += new EventHandler(OperationDesc_GotFocus);
            this.dtcOperationName.TextBox.GotFocus += new EventHandler(OperationDesc_GotFocus);
            #endregion
            #region 手术、麻醉医师查询相关事件定义
            this.dtcOperator.TextBox.KeyDown += new KeyEventHandler(Emp_KeyDown);
            this.dtcOperator.TextBox.LostFocus += new EventHandler(Emp_LostFocus);
            this.dtcOperator.TextBox.GotFocus += new EventHandler(Emp_GotFocus);
            this.dtcAssistant1.TextBox.KeyDown += new KeyEventHandler(Emp_KeyDown);
            this.dtcAssistant1.TextBox.LostFocus += new EventHandler(Emp_LostFocus);
            this.dtcAssistant1.TextBox.GotFocus += new EventHandler(Emp_GotFocus);
            this.dtcAssistant2.TextBox.KeyDown += new KeyEventHandler(Emp_KeyDown);
            this.dtcAssistant2.TextBox.LostFocus += new EventHandler(Emp_LostFocus);
            this.dtcAssistant2.TextBox.GotFocus += new EventHandler(Emp_GotFocus);
            this.dtcAnaesthetist.TextBox.KeyDown += new KeyEventHandler(Emp_KeyDown);
            this.dtcAnaesthetist.TextBox.LostFocus += new EventHandler(Emp_LostFocus);
            this.dtcAnaesthetist.TextBox.GotFocus += new EventHandler(Emp_GotFocus);
            #endregion
            this.dtgOperation.DataSource = m_dtbOperationDetail;
        }
        #endregion

        #region dtcAanaesthesiaMode的事件
        private clsAnaesthesiaModeInOperation[] m_objAnaesthesiaModeArr = null;
        private void dtcAanaesthesiaMode_GotFocus(object sender, System.EventArgs e)
        {
            long m_lngRes = 0;
            if (m_objAnaesthesiaModeArr == null)
            {
                m_lngRes = m_objDomain.m_lngGetAnaesthesiaModeLikeID(out m_objAnaesthesiaModeArr);
            }

            if (m_objAnaesthesiaModeArr != null && m_objAnaesthesiaModeArr.Length > 0)
            {
                int x = dtcAanaesthesiaMode.TextBox.Location.X + dtgOperation.Location.X;
                int y = dtcAanaesthesiaMode.TextBox.Location.Y + dtgOperation.Location.Y + dtcAanaesthesiaMode.TextBox.Height;

                if (x != dtgOperation.Location.X)
                {
                    Point p = new Point(x, y);
                    lsvAanaesthesiaMode.Location = p;
                    lsvAanaesthesiaMode.Width = dtcAanaesthesiaMode.TextBox.Width;
                    lsvAanaesthesiaMode.Visible = true;
                }
                lsvAanaesthesiaMode.Items.Clear();
                lsvAanaesthesiaMode.BeginUpdate();
                ListViewItem[] livItems = new ListViewItem[m_objAnaesthesiaModeArr.Length];
                for (int i = 0 ; i < m_objAnaesthesiaModeArr.Length ; i++)
                {
                    livItems[i] = new ListViewItem(new string[]{m_objAnaesthesiaModeArr[i].strAnaesthesiaModeID,
																m_objAnaesthesiaModeArr[i].strAnaesthesiaModeName});
                }
                lsvAanaesthesiaMode.Items.AddRange(livItems);
                lsvAanaesthesiaMode.Focus();
                lsvAanaesthesiaMode.Items[0].Selected = true;
                lsvAanaesthesiaMode.EndUpdate();
            }
        }

        private void dtcAanaesthesiaMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (lsvAanaesthesiaMode.Visible && lsvAanaesthesiaMode.Items.Count > 0 && e.KeyCode == Keys.Down)
            {
                lsvAanaesthesiaMode.Items[0].Selected = true;
            }
        }
        #endregion

        #region 把模糊查询的结果放在lsvOperationEmplayee中
        /// <summary>
        /// 在手术DataGrid中，当前所使用的DataGridTextBox
        /// </summary>
        private DataGridTextBox m_dgtCurrentBox;
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
                long m_lngRes = m_objDomain.m_lngGetEmpArrByIDOrNameLike(m_dgtTemp.Text, out lsvItemArr);

                if (m_lngRes <= 0 || lsvItemArr == null)
                    return;
                for (int i1 = 0 ; i1 < lsvItemArr.Length ; i1++)
                {
                    lsvOperationEmployee.Items.AddRange(new ListViewItem[] { lsvItemArr[i1] });
                }

                m_mthChangeListViewLastColumnWidth(lsvOperationEmployee);
            }
            catch { }
        }
        #endregion

        #region 把模糊查询的结果放在lsvAanaesthesiaMode中
        /// <summary>
        /// 把模糊查询的结果放在lsvAanaesthesiaMode中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //		private void m_objAddGridAanaesthesiaModeListViewItemArr(object sender,EventArgs e)
        //		{
        //			string m_strInput = m_objGridListView4.strGetCurrentText().Trim();
        //			if(m_strInput == null || m_strInput == "")
        //				return;
        //			 
        //			clsAnaesthesiaModeInOperation[] m_objAnaesthesiaModeArr = null;
        //			long m_lngRes = m_objDomain.m_lngGetAnaesthesiaModeLikeID(m_strInput,out m_objAnaesthesiaModeArr);
        //			if(m_lngRes < 1)
        //			{
        //				m_mthShowDBError();
        //				return;
        //			}
        //			try
        //			{
        //				lsvAanaesthesiaMode.Items.Clear();
        //				
        //				if(m_objAnaesthesiaModeArr == null || m_objAnaesthesiaModeArr.Length <=0)
        //					return;
        //				
        //				ListViewItem m_lviNewItem;
        //				for(int i1=0;i1<m_objAnaesthesiaModeArr.Length;i1++)
        //				{
        //					m_lviNewItem = new ListViewItem(m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeID);
        //					m_lviNewItem.SubItems.Add(m_objAnaesthesiaModeArr[i1].strAnaesthesiaModeName);
        //					lsvAanaesthesiaMode.Items.Add(m_lviNewItem);
        //				}
        //
        //				m_mthChangeListViewLastColumnWidth(lsvAanaesthesiaMode);
        //			}
        //			catch{}
        //		}
        #endregion

        #region 窗体Load事件
        private void frmInHospitalMainRecord_GX_Load(object sender, System.EventArgs e)
        {
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
            m_mthSetQuickKeys();
            m_mthfrmLoad();

            m_chkInstanceWhenIn1.Focus();
        }
        #endregion

        protected override bool m_BlnCanTextChanged
        {
            get
            {
                return true;
            }
        }


        #region 清空当前窗体的一些对象
        private void m_mthCleanUP()
        {
            m_mthCleanUpPatientBaseInfo();
            m_mthCleanUpPatientDetailInfo();
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_objCollection.m_objMain = null;
            m_objCollection.m_objContent = null;
            m_objCollection.m_objOtherDiagnosisArr = null;
            m_objCollection.m_objOperationArr = null;
            m_objCollection.m_objInDiagnosisArr = null;
            m_mthSetControlReadOnly(this, true);
        }
        #endregion

        #region 清空病人基本信息内容
        /// <summary>
        /// 清空病人基本信息内容
        /// </summary>
        private void m_mthCleanUpPatientBaseInfo()
        {
            base.m_mthClearPatientBaseInfo();
            lblMarried.Text = "";
            lblOccupation.Text = "";
            lblNationality.Text = "";
            lblNation.Text = "";
            lblID.Text = "";
            lblOfficeAddress.Text = "";
            lblOfficePhone.Text = "";
            lblOfficePC.Text = "";
            lblHomeAddress.Text = "";
            lblHomePC.Text = "";
            lblContactMan.Text = "";
            lblRelation.Text = "";
            lblContactManAddress.Text = "";
            lblContactManPhone.Text = "";
            lblLinkManzipcode.Text = "";
            lblInHospitalTimes.Text = "";
            lblBirthPlace.Text = "";
        }
        #endregion

        #region 清空病人基本住院信息内容
        /// <summary>
        /// 清空病人基本住院信息内容
        /// </summary>
        private void m_mthCleanUpPatientDetailInfo()
        {
            lblInHosptialSetion.Text = "";
            lblOutHospitalSetion.Text = "";
            lblInHospitalDays.Text = "";
            m_lblInHospitalDate.Text = "";
            m_lblOutHospitalDate.Text = "";
        }
        #endregion

        #region 清空病人住院病案首页内容
        /// <summary>
        /// 清空病人住院病案首页内容
        /// </summary>
        private void m_mthCleanUpPatientInHospitalMainRecrodInfo()
        {
            m_strCurrentOpenDate = "";
            m_intSubmit = 0;

            m_cboPayType.Text = "";
            m_cboPayType.SelectedIndex = -1;

            m_lsvTransDept.Items.Clear();

            m_mthSetFalseCheckInPanel(m_pnlInstanceWhenIn);

            txtDiagnosis.m_mthClearText();
            m_txtSTATCODEOFDIAGNOSIS.m_mthClearText();
            m_txtICD_10OFDIAGNOSIS.m_mthClearText();

            dtgInHospitalDiagnosis.CurrentRowIndex = 0;
            m_dtbInHospitalDiagnosis.Rows.Clear();

            //			txtInHospitalDiagnosis.m_mthClearText();
            //			m_txtSTATCODEOFINHOSPITALDIA.m_mthClearText();
            //			m_txtICD_10OFINHOSPITALDIA.m_mthClearText();

            dtpDiagnoseDate.Value = DateTime.Now;

            m_txtMainDiagnosis.m_mthClearText();
            m_txtSTATCODEOFMAIN.m_mthClearText();
            m_txtICD_10OFMAIN.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlMAINCONDITIONSEQ);
            m_txtMainDiagnosisOther.m_mthClearText();

            //dtgOtherDiagnosis.CurrentRowIndex = 0;
            m_dtbOtherDiagnosis.Rows.Clear();
            dtgOtherDiagnosis.CurrentRowIndex = 0;

            m_txtCOMPLICATION.m_mthClearText();
            m_txtSTATCODEOFCOMPLICATION.m_mthClearText();
            m_txtICD_10OFCOMPLICATION.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlCOMPLICATIONSEQ);
            m_txtCOMPLICATIONOther.m_mthClearText();

            m_txtINFECTIONDIAGNOSIS.m_mthClearText();
            m_txtSTATCODEOFINFECTION.m_mthClearText();
            m_txtICD_10OFINFECTION.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlINFECTIONCONDICTIONSEQ);
            m_txtINFECTIONDIAGNOSISOther.m_mthClearText();

            m_txtPATHOLOGYDIAGNOSIS.m_mthClearText();
            m_txtSTATCODEOFPATHOLOGYDIA.m_mthClearText();
            m_txtICD_10OFPATHOLOGYDIA.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlPATHOLOGYDIAGNOSISSEQ);
            m_txtPATHOLOGYDIAGNOSISOther.m_mthClearText();

            m_txtScacheSource.m_mthClearText();
            m_txtSENSITIVE.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlNEW5DISEASE);

            m_mthSetFalseCheckInPanel(m_pnlSECONDLEVELTRANSFER);

            m_cboHBsAg.SelectedIndex = 0;
            m_cboHCV_Ab.SelectedIndex = 0;
            m_cboHIV_Ab.SelectedIndex = 0;

            dtgOperation.CurrentRowIndex = 0;
            m_dtbOperationDetail.Rows.Clear();

            m_txtNEONATEDISEASE1.m_mthClearText();
            m_txtNEONATEDISEASE2.m_mthClearText();
            m_txtNEONATEDISEASE3.m_mthClearText();
            m_txtNEONATEDISEASE4.m_mthClearText();

            m_txtSALVETIMES.Clear();
            m_txtSALVESUCCESS.Clear();
            m_txtREMINDTERM.m_mthClearText();

            m_mthSetFalseCheckInPanel(m_pnlHASREMIND);

            m_cboClinicOUt.SelectedIndex = 0;
            m_cboInOut.SelectedIndex = 0;
            m_cboBeforeOpAfterOp.SelectedIndex = 0;
            m_cboClinicPh.SelectedIndex = 0;
            m_cboDeathCheck.SelectedIndex = 0;
            m_cboClinicRad.SelectedIndex = 0;

            m_mthSetFalseCheckInPanel(m_pnlMODELCASE);
            m_mthSetFalseCheckInPanel(m_pnlFIRSTCASE);
            m_mthSetFalseCheckInPanel(m_pnlQUALITY);
            m_mthSetFalseCheckInPanel(m_pnlANTIBACTERIAL);
            m_mthSetFalseCheckInPanel(m_pnlPATHOGENY);
            m_mthSetFalseCheckInPanel(m_pnlPATHOGENYRESULT);
            m_mthSetFalseCheckInPanel(m_pnlBLOODTRANSACTOIN);
            m_mthSetFalseCheckInPanel(m_pnlTRANSFUSIONSACTION);
            m_mthSetFalseCheckInPanel(m_pnlCTCHECK);
            m_mthSetFalseCheckInPanel(m_pnlMRICHECK);
            m_mthSetFalseCheckInPanel(m_pnlBLOODTYPE);
            m_mthSetFalseCheckInPanel(m_pnlBLOODRH);
            m_mthSetFalseCheckInPanel(m_pnlXRayCheck);

            m_txtRBC.m_mthClearText();
            m_txtPLT.m_mthClearText();
            m_txtPLASM.m_mthClearText();
            m_txtWHOLEBLOOD.m_mthClearText();
            m_txtOTHERBLOOD.m_mthClearText();
            txtTotalAmt.Clear();
            txtBedAmt.Clear();
            txtNurseAmt.Clear();
            txtWMAmt.Clear();
            txtCMFinishedAmt.Clear();
            txtCMSemiFinishedAmt.Clear();
            txtRadiationAmt.Clear();
            txtAssayAmt.Clear();
            txtO2Amt.Clear();
            txtBloodAmt.Clear();
            txtTreatmentAmt.Clear();
            txtOperationAmt.Clear();
            txtCheckAmt.Clear();
            txtAnaethesiaAmt.Clear();
            txtDeliveryChildAmt.Clear();
            txtBabyAmt.Clear();
            txtAccompanyAmt.Clear();
            txtOtherAmt.Clear();

            txtDeptDirectorDt.Clear();
            txtDeptDirectorDt.Tag = null;
            txtDt.Clear();
            txtDt.Tag = null;
            txtInHospitalDt.Clear();
            txtInHospitalDt.Tag = null;
            m_txtOutHospitalDoc.Clear();
            m_txtOutHospitalDoc.Tag = null;
            txtDirectorDt.Clear();
            txtDirectorDt.Tag = null;
            txtSubDirectorDt.Clear();
            txtSubDirectorDt.Tag = null;
            txtAttendInStudyDt.Clear();
            txtAttendInStudyDt.Tag = null;
            txtGraduateStudentIntern.Clear();
            txtIntern.Clear();
            m_txtNEATEN.Clear();
            m_txtCODER.Clear();
            m_txtINPUTMACHINE.Clear();
            m_txtSTATISTIC.Clear();
        }

        private void m_mthSetFalseCheckInPanel(Panel ctlPnl)
        {
            foreach (Control ctl in ctlPnl.Controls)
            {
                switch (ctl.GetType().FullName)
                {
                    case "System.Windows.Forms.CheckBox":
                        ((CheckBox)ctl).Checked = false;
                        break;
                    case "System.Windows.Forms.RadioButton":
                        ((RadioButton)ctl).Checked = false;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 获得病人基本信息
        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            m_objSelectedPatient = p_objSelectedPatient;
            //m_mthGetPatientDetailInfo();
        }
        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            clsPeopleInfo objPeopleInfo = p_objSelectedPatient.m_ObjPeopleInfo;

            lblSex.Text = objPeopleInfo.m_StrSex;
            lblAge.Text = objPeopleInfo.m_StrAge;

            lblMarried.Text = objPeopleInfo.m_StrMarried;
            lblOccupation.Text = objPeopleInfo.m_StrOccupation;
            lblNationality.Text = objPeopleInfo.m_StrNationality;
            lblNation.Text = objPeopleInfo.m_StrNation;
            lblID.Text = objPeopleInfo.m_StrIDCard;
            lblBirthPlace.Text = objPeopleInfo.m_StrHomeplace;

            lblOfficeAddress.Text = objPeopleInfo.m_StrOffice_name + "  " + m_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficeAddress;

            lblOfficePhone.Text = objPeopleInfo.m_StrOfficePhone;
            lblOfficePC.Text = objPeopleInfo.m_StrOfficePC;

            lblHomeAddress.Text = objPeopleInfo.m_StrHomeAddress;

            lblHomePC.Text = objPeopleInfo.m_StrHomePC;
            lblContactMan.Text = objPeopleInfo.m_StrLinkManFirstName;
            lblRelation.Text = objPeopleInfo.m_StrPatientRelation;

            lblContactManAddress.Text = objPeopleInfo.m_StrLinkManAddress;
            lblLinkManzipcode.Text = objPeopleInfo.m_StrLinkManPC;

            lblContactManPhone.Text = objPeopleInfo.m_StrLinkManPhone;


        }
        /// <summary>
        /// 获得病人基本信息
        /// </summary>
        private void m_mthGetPatientDetailInfo()
        {
            if (m_objSelectedPatient == null)
                return;

            //lblMarried.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrMarried;
            //lblOccupation.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrOccupation;			
            //lblNationality.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNationality;
            //lblNation.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrNation;
            //lblID.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrIDCard;
            //lblBirthPlace.Text = m_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeplace;

            //lblOfficeAddress.Text =m_objSelectedPatient.m_ObjPeopleInfo.m_StrOffice_name+ "  "+m_objSelectedPatient.m_ObjPeopleInfo.m_StrOfficeAddress ;

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
            for (int i1 = (m_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount() - 1) ; i1 >= 0 ; i1--)
            {
                m_trnNewNode = new TreeNode(m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i1).m_DtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                m_trnNewNode.Tag = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i1).m_DtmEMRInDate;
                trvTime.Nodes[0].Nodes.Add(m_trnNewNode);
            }

            //选中默认节点
            for (int i = 0 ; i < trvTime.Nodes[0].Nodes.Count ; i++)
            {
                if ((DateTime)trvTime.Nodes[0].Nodes[i].Tag == m_objSelectedPatient.m_DtmSelectedInDate)
                    trvTime.SelectedNode = trvTime.Nodes[0].Nodes[i];
            }

            trvTime.ExpandAll();
        }
        #endregion

        #region 判断该次住院的住院病案首页是否已经生成过
        /// <summary>
        /// 判断该次住院的住院病案首页是否已经生成过
        /// </summary>
        private void m_mthCheckIfHasSave(string m_strRegisterID)
        {
            if (string.IsNullOrEmpty(m_strRegisterID))
            {
                m_bolIfHasSave = false;
                return;
            }
            m_strOpenDate = null;
            DateTime[] dtmOpendateArr = null;
            DateTime dtmOpendate = DateTime.MinValue;
            long lngRes = m_objDomain.m_lngGetOpenDateInfo(m_strRegisterID, out dtmOpendateArr);
            if (lngRes < 1)
            {
                m_mthShowDBError();
                return;
            }
            if (dtmOpendateArr != null && dtmOpendateArr.Length > 0)
            {
                dtmOpendate = dtmOpendateArr[0];
            }
            if (dtmOpendate == new DateTime(1900, 1, 1) || dtmOpendate == DateTime.MinValue)
            {
                m_bolIfHasSave = false;
            }
            else
            {
                m_strOpenDate = dtmOpendate.ToString("yyyy-MM-dd HH:mm:ss");
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
            m_mthCheckIfHasSave(m_strRegisterID);
            long m_lngRes = 0;
            if (m_bolIfHasSave)
            {
                m_lngRes = m_objDomain.m_lngGetInfo(m_strRegisterID, m_strOpenDate, false, out m_objCollection);
                if (m_lngRes < 1)
                {
                    return;
                }
                m_bolIfChange = false;
                m_mthSetMainInfo(m_objCollection.m_objMain, m_objCollection.m_objContent);
                m_mthSetOtherDiagnosisInfo(m_objCollection.m_objOtherDiagnosisArr);
                m_mthSetInDiagnosisInfo(m_objCollection.m_objInDiagnosisArr);
                m_mthSetOperationInfo(m_objCollection.m_objOperationArr);
                m_bolIfChange = true;

                //当前处于修改记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);

                m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;
            }
            else
            {
                m_mthLoadOperationInfo();

                m_mthSetDefaultValue(m_objSelectedPatient);

                //读取军惠表中的收费信息
                int intInTimes = (lblInHospitalTimes.Text == "" ? 0 : (int.Parse(lblInHospitalTimes.Text)));

                com.digitalwave.InHospitalMainRecord.clsQuery8iServ objServ =
                    (com.digitalwave.InHospitalMainRecord.clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.InHospitalMainRecord.clsQuery8iServ));

                clsInHospitalMainRecord_GXContent objChargeContent = null;              

               long lngRes = objServ.m_lngGetCost(m_objSelectedPatient.m_StrInPatientID, intInTimes, out objChargeContent);            
               
               if (lngRes < 1)
                {
                    return;
                }
              
               objServ = null;
                         
               m_mthSetChargeInfo(objChargeContent);

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
            new clsDefaultValueTool(this, p_objPatient).m_mthSetDefaultValue();

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
                    //					txtInHospitalDiagnosis.Text=objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
                    if (!string.IsNullOrEmpty(objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose))
                    {
                        string[] DiagnosisArr = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose.Split('\n');
                        if (DiagnosisArr != null)
                        {
                            m_dtbInHospitalDiagnosis.BeginLoadData();
                            for (int i = 0 ; i < DiagnosisArr.Length ; i++)
                            {
                                m_dtbInHospitalDiagnosis.LoadDataRow(new string[] { DiagnosisArr[i], "", "" }, true);
                            }
                            m_dtbInHospitalDiagnosis.EndLoadData();
                        }
                    }
                    //					m_txtMainDiagnosis.Text = objInPatientCaseDefaultValue[0].m_strFinallyDiagnose != "" ? objInPatientCaseDefaultValue[0].m_strFinallyDiagnose : objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose; 
                    dtpDiagnoseDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate);
                }
                //m_txtMainDiagnosis.Text = "无";
            }
            #endregion

            //设完默认值后回到光标床号
            m_txtBedNO.Focus();
        }



        private void m_mthDiaplayDeletedDetail()
        {
            //如果选中的是根节点，不显示删除记录。只有选中那个入院日期才会显示。
            if (m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择入院日期！");
                return;
            }

            string m_strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");

            long m_lngRes = 0;

            m_lngRes = m_objDomain.m_lngGetDeletedInfo(m_strRegisterID, m_strOpenDate, out m_objCollection);

            m_bolIfChange = false;
            if (m_objCollection == null)
                return;
            m_mthSetDelMainInfo(m_objCollection.m_objMain, m_objCollection.m_objContent);
            m_mthSetOtherDiagnosisInfo(m_objCollection.m_objOtherDiagnosisArr);
            m_mthSetInDiagnosisInfo(m_objCollection.m_objInDiagnosisArr);
            m_mthSetOperationInfo(m_objCollection.m_objOperationArr);
            m_bolIfChange = true;
        }

        #region 显示该次住院的住院病案首页主表信息
        /// <summary>
        /// 显示该次住院的住院病案首页主表信息
        /// </summary>
        /// <param name="p_objContent"></param>
        private void m_mthSetMainInfo(clsInHospitalMainRecord_GX p_objMain, clsInHospitalMainRecord_GXContent p_objContent)
        {
            if (p_objMain == null || p_objContent == null)
            {
                #region 在住院病历没有记录时候，从其他表读入信息
                string strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                clsInPatientCaseHisoryDefaultDomain objInPaitentCaseDefault = new clsInPatientCaseHisoryDefaultDomain();
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = null;

                if (m_objSelectedPatient != null)
                {
                    objInPatientCaseDefaultValue = objInPaitentCaseDefault.lngGetAllInPatientCaseHisoryDefault(m_objSelectedPatient.m_StrInPatientID, strInPatientDate);
                    if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
                    {
                        //						this.txtInHospitalDiagnosis.Text =objInPatientCaseDefaultValue[0].m_strFinallyDiagnose ; 
                        m_dtbInHospitalDiagnosis.Rows.Add(new string[] { objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose, "", "" });
                    }
                }
                #endregion
                return;
            }

            #region 显示病案首页信息
            m_cboPayType.Text = p_objContent.m_strPAYTYPE;

            m_strCurrentOpenDate = p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_intSubmit = p_objMain.m_intSUBMIT_INT;
            #region
            if (p_objMain.m_intSUBMIT_INT == 1)
            {
                this.m_cmdSubmit.Enabled = false;
                this.m_cmdSubmit.Text = "已提交";
                //m_mthSetControlReadOnly(this, true);
            }
            else
            {

                //m_mthSetControlReadOnly(this, false);
                this.m_cmdSubmit.Enabled = true;
                this.m_cmdSubmit.Text = "提交";
            }

            switch (p_objContent.m_intCONDICTIONWHENIN)
            {
                case 1:
                    m_chkInstanceWhenIn1.Checked = true;
                    break;
                case 2:
                    m_chkInstanceWhenIn2.Checked = true;
                    break;
                case 3:
                    m_chkInstanceWhenIn3.Checked = true;
                    break;
            }
            #endregion
            dtpDiagnoseDate.Value = p_objContent.m_dtmCONFIRMDIAGNOSISDATE;

            txtDiagnosis.m_mthSetNewText(p_objContent.m_strDIAGNOSIS, p_objMain.m_strDIAGNOSISXML);
            m_txtSTATCODEOFDIAGNOSIS.m_mthSetNewText(p_objContent.m_strSTATCODEOFDIAGNOSIS, p_objMain.m_strSTATCODEOFDIAGNOSISXML);
            m_txtICD_10OFDIAGNOSIS.m_mthSetNewText(p_objContent.m_strICD_10OFDIAGNOSIS, p_objMain.m_strICD_10OFDIAGNOSISXML);

            //			txtInHospitalDiagnosis.m_mthSetNewText(p_objContent.m_strINHOSPITALDIAGNOSIS, p_objMain.m_strINHOSPITALDIAGNOSISXML);
            //			m_txtSTATCODEOFINHOSPITALDIA.m_mthSetNewText(p_objContent.m_strSTATCODEOFINHOSPITALDIA, p_objMain.m_strSTATCODEOFINHOSPITALDIAXML);
            //			m_txtICD_10OFINHOSPITALDIA.m_mthSetNewText(p_objContent.m_strICD_10OFINHOSPITALDIA, p_objMain.m_strICD_10OFINHOSPITALDIAXML);

            m_txtMainDiagnosis.m_mthSetNewText(p_objContent.m_strMAINDIAGNOSIS, p_objMain.m_strMAINDIAGNOSISXML);
            m_txtSTATCODEOFMAIN.m_mthSetNewText(p_objContent.m_strSTATCODEOFMAIN, p_objMain.m_strSTATCODEOFMAINXML);
            m_txtICD_10OFMAIN.m_mthSetNewText(p_objContent.m_strICD_10OFMAIN, p_objMain.m_strICD_10OFMAINXML);
            m_txtMainDiagnosisOther.m_mthSetNewText(p_objContent.m_strOTHERMAINCONDITION, p_objMain.m_strOTHERMAINCONDITIONXML);
            #region
            switch (p_objContent.m_intMAINCONDITIONSEQ)
            {
                case 0:
                    m_chkMAINCONDITIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkMAINCONDITIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkMAINCONDITIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkMAINCONDITIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkMAINCONDITIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkMAINCONDITIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtCOMPLICATION.m_mthSetNewText(p_objContent.m_strCOMPLICATION, p_objMain.m_strCOMPLICATIONXML);
            m_txtSTATCODEOFCOMPLICATION.m_mthSetNewText(p_objContent.m_strSTATCODEOFCOMPLICATION, p_objMain.m_strSTATCODEOFCOMPLICATIONXML);
            m_txtICD_10OFCOMPLICATION.m_mthSetNewText(p_objContent.m_strICD_10OFCOMPLICATION, p_objMain.m_strICD_10OFCOMPLICATIONXML);
            m_txtCOMPLICATIONOther.m_mthSetNewText(p_objContent.m_strOTHERCOMPLICATION, p_objMain.m_strOTHERCOMPLICATIONXML);
            #region
            switch (p_objContent.m_intCOMPLICATIONSEQ)
            {
                case 0:
                    m_chkCOMPLICATIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkCOMPLICATIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkCOMPLICATIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkCOMPLICATIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkCOMPLICATIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkCOMPLICATIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtINFECTIONDIAGNOSIS.m_mthSetNewText(p_objContent.m_strINFECTIONDIAGNOSIS, p_objMain.m_strINFECTIONDIAGNOSISXML);
            m_txtSTATCODEOFINFECTION.m_mthSetNewText(p_objContent.m_strSTATCODEOFINFECTION, p_objMain.m_strSTATCODEOFINFECTIONXML);
            m_txtICD_10OFINFECTION.m_mthSetNewText(p_objContent.m_strICD_10OFINFECTION, p_objMain.m_strICD_10OFINFECTIONXML);
            m_txtINFECTIONDIAGNOSISOther.m_mthSetNewText(p_objContent.m_strOTHERINFECTIONCONDICTION, p_objMain.m_strOTHERINFECTIONCONDICTIONXML);
            #region
            switch (p_objContent.m_intINFECTIONCONDICTIONSEQ)
            {
                case 0:
                    m_chkINFECTIONCONDICTIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkINFECTIONCONDICTIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkINFECTIONCONDICTIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkINFECTIONCONDICTIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkINFECTIONCONDICTIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkINFECTIONCONDICTIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtPATHOLOGYDIAGNOSIS.m_mthSetNewText(p_objContent.m_strPATHOLOGYDIAGNOSIS, p_objMain.m_strPATHOLOGYDIAGNOSISXML);
            m_txtSTATCODEOFPATHOLOGYDIA.m_mthSetNewText(p_objContent.m_strSTATCODEOFPATHOLOGYDIA, p_objMain.m_strSTATCODEOFPATHOLOGYDIAXML);
            m_txtICD_10OFPATHOLOGYDIA.m_mthSetNewText(p_objContent.m_strICD_10OFPATHOLOGYDIA, p_objMain.m_strICD_10OFPATHOLOGYDIAXML);
            m_txtPATHOLOGYDIAGNOSISOther.m_mthSetNewText(p_objContent.m_strOTHERPATHOLOGYDIAGNOSIS, p_objMain.m_strOTHERPATHOLOGYDIAGNOSISXML);
            #region
            switch (p_objContent.m_intPATHOLOGYDIAGNOSISSEQ)
            {
                case 0:
                    m_chkPATHOLOGYDIAGNOSISSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkPATHOLOGYDIAGNOSISSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOLOGYDIAGNOSISSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkPATHOLOGYDIAGNOSISSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkPATHOLOGYDIAGNOSISSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkPATHOLOGYDIAGNOSISSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtScacheSource.m_mthSetNewText(p_objContent.m_strSCACHESOURCE, p_objMain.m_strSCACHESOURCEXML);
            #region
            switch (p_objContent.m_intNEW5DISEASE)
            {
                case 1:
                    m_chkNEW5DISEASE1.Checked = true;
                    break;
                case 2:
                    m_chkNEW5DISEASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intSECONDLEVELTRANSFER)
            {
                case 1:
                    m_chkSECONDLEVELTRANSFER1.Checked = true;
                    break;
                case 2:
                    m_chkSECONDLEVELTRANSFER2.Checked = true;
                    break;
            }
            #endregion
            m_txtSENSITIVE.m_mthSetNewText(p_objContent.m_strSENSITIVE, p_objMain.m_strSENSITIVEXML);

            m_cboHBsAg.SelectedIndex = p_objContent.m_intHBSAG;
            m_cboHCV_Ab.SelectedIndex = p_objContent.m_intHCV_AB;
            m_cboHIV_Ab.SelectedIndex = p_objContent.m_intHIV_AB;

            m_txtNEONATEDISEASE1.m_mthSetNewText(p_objContent.m_strNEONATEDISEASE1, p_objMain.m_strNEONATEDISEASE1XML);
            m_txtNEONATEDISEASE2.m_mthSetNewText(p_objContent.m_strNEONATEDISEASE2, p_objMain.m_strNEONATEDISEASE2XML);
            m_txtNEONATEDISEASE3.m_mthSetNewText(p_objContent.m_strNEONATEDISEASE3, p_objMain.m_strNEONATEDISEASE3XML);
            m_txtNEONATEDISEASE4.m_mthSetNewText(p_objContent.m_strNEONATEDISEASE4, p_objMain.m_strNEONATEDISEASE4XML);

            m_txtSALVETIMES.Text = p_objContent.m_intSALVETIMES.ToString();
            m_txtSALVESUCCESS.Text = p_objContent.m_intSALVESUCCESS.ToString();

            switch (p_objContent.m_intHASREMIND)
            {
                case 1:
                    m_chkHASREMIND1.Checked = true;
                    break;
                case 2:
                    m_chkHASREMIND2.Checked = true;
                    break;
            }

            m_txtREMINDTERM.m_mthSetNewText(p_objContent.m_strREMINDTERM, p_objMain.m_strREMINDTERMXML);

            m_cboClinicOUt.SelectedIndex = p_objContent.m_intACCORDWITHOUTHOSPITAL - 1;
            m_cboInOut.SelectedIndex = p_objContent.m_intACCORDINWITHOUT - 1;
            m_cboBeforeOpAfterOp.SelectedIndex = p_objContent.m_intACCORDBFOPRWITHAF;
            m_cboClinicPh.SelectedIndex = p_objContent.m_intACCORDCLINICWITHPATHOLOGY;
            m_cboDeathCheck.SelectedIndex = p_objContent.m_intACCORDDEATHWITHBODYCHECK;
            m_cboClinicRad.SelectedIndex = p_objContent.m_intACCORDCLINICWITHRADIATE;
            #region
            switch (p_objContent.m_intMODELCASE)
            {
                case 1:
                    m_chkMODELCASE1.Checked = true;
                    break;
                case 2:
                    m_chkMODELCASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intFIRSTCASE)
            {
                case 1:
                    m_chkFIRSTCASE1.Checked = true;
                    break;
                case 2:
                    m_chkFIRSTCASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intQUALITY)
            {
                case 1:
                    m_chkQUALITY1.Checked = true;
                    break;
                case 2:
                    m_chkQUALITY2.Checked = true;
                    break;
                case 3:
                    m_chkQUALITY3.Checked = true;
                    break;
            }

            switch (p_objContent.m_intANTIBACTERIAL)
            {
                case 1:
                    m_chkANTIBACTERIAL1.Checked = true;
                    break;
                case 2:
                    m_chkANTIBACTERIAL2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intPATHOGENY)
            {
                case 1:
                    m_chkPATHOGENY1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOGENY2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intPATHOGENYRESULT)
            {
                case 1:
                    m_chkPATHOGENYRESULT1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOGENYRESULT2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODTRANSACTOIN)
            {
                case 1:
                    m_chkBLOODTRANSACTOIN1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODTRANSACTOIN2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intTRANSFUSIONSACTION)
            {
                case 1:
                    m_chkTRANSFUSIONSACTION1.Checked = true;
                    break;
                case 2:
                    m_chkTRANSFUSIONSACTION2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intMRICHECK)
            {
                case 1:
                    m_chkMRICHECK1.Checked = true;
                    break;
                case 2:
                    m_chkMRICHECK2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intCTCHECK)
            {
                case 1:
                    m_chkCTCHECK1.Checked = true;
                    break;
                case 2:
                    m_chkCTCHECK2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODTYPE)
            {
                case 0:
                    m_chkBLOODTYPE0.Checked = true;
                    break;
                case 1:
                    m_chkBLOODTYPE1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODTYPE2.Checked = true;
                    break;
                case 3:
                    m_chkBLOODTYPE3.Checked = true;
                    break;
                case 4:
                    m_chkBLOODTYPE4.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODRH)
            {
                case 0:
                    m_chkBLOODRH0.Checked = true;
                    break;
                case 1:
                    m_chkBLOODRH1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODRH2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intXRAYCHECK)
            {
                case 1:
                    m_chkXRayCheck1.Checked = true;
                    break;
                case 2:
                    m_chkXRayCheck2.Checked = true;
                    break;
                case 3:
                    m_chkXRayCheck3.Checked = true;
                    break;
            }
            #endregion

            m_txtRBC.m_mthSetNewText(p_objContent.m_strRBC, p_objMain.m_strRBCXML);
            m_txtPLT.m_mthSetNewText(p_objContent.m_strPLT, p_objMain.m_strPLTXML);
            m_txtPLASM.m_mthSetNewText(p_objContent.m_strPLASM, p_objMain.m_strPLASMXML);
            m_txtWHOLEBLOOD.m_mthSetNewText(p_objContent.m_strWHOLEBLOOD, p_objMain.m_strWHOLEBLOODXML);
            m_txtOTHERBLOOD.m_mthSetNewText(p_objContent.m_strOTHERBLOOD, p_objMain.m_strOTHERBLOODXML);
            #region
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDEPTDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDeptDirectorDt.Tag = objEmpVO;
                txtDeptDirectorDt.Text = p_objContent.m_strDEPTDIRECTORDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDt.Tag = objEmpVO;
                txtDt.Text = p_objContent.m_strDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strINHOSPITALDOC, out objEmpVO);
            if (objEmpVO != null)
            {
                txtInHospitalDt.Tag = objEmpVO;
                txtInHospitalDt.Text = p_objContent.m_strINHOSPITALDOCNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strOUTHOSPITALDOC, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtOutHospitalDoc.Tag = objEmpVO;
                m_txtOutHospitalDoc.Text = p_objContent.m_strOUTHOSPITALDOCNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDirectorDt.Tag = objEmpVO;
                txtDirectorDt.Text = p_objContent.m_strDIRECTORDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strSUBDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtSubDirectorDt.Tag = objEmpVO;
                txtSubDirectorDt.Text = p_objContent.m_strSUBDIRECTORDTNAME;
            }

            if (!string.IsNullOrEmpty(p_objContent.m_strATTENDINFORADVANCESSTUDYDT))
            {
                objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strATTENDINFORADVANCESSTUDYDT, out objEmpVO);
                if (objEmpVO != null)
                {
                    txtAttendInStudyDt.Tag = objEmpVO;
                }
            }
            #endregion
            txtAttendInStudyDt.Text = p_objContent.m_strATTENDINFORADVANCESSTUDYDTNAME;

            txtGraduateStudentIntern.Text = p_objContent.m_strGRADUATESTUDENTINTERNNAME;
            txtIntern.Text = p_objContent.m_strINTERNNAME;

            txtTotalAmt.Text = p_objContent.m_dblTOTALAMT.ToString();
            txtBedAmt.Text = p_objContent.m_dblBEDAMT.ToString();
            txtNurseAmt.Text = p_objContent.m_dblNURSEAMT.ToString();
            txtWMAmt.Text = p_objContent.m_dblWMAMT.ToString();
            txtCMFinishedAmt.Text = p_objContent.m_dblCMFINISHEDAMT.ToString();
            txtCMSemiFinishedAmt.Text = p_objContent.m_dblCMSEMIFINISHEDAMT.ToString();
            txtRadiationAmt.Text = p_objContent.m_dblRADIATIONAMT.ToString();
            txtAssayAmt.Text = p_objContent.m_dblASSAYAMT.ToString();
            txtO2Amt.Text = p_objContent.m_dblO2AMT.ToString();
            txtBloodAmt.Text = p_objContent.m_dblBLOODAMT.ToString();
            txtTreatmentAmt.Text = p_objContent.m_dblTREATMENTAMT.ToString();
            txtOperationAmt.Text = p_objContent.m_dblOPERATIONAMT.ToString();
            txtCheckAmt.Text = p_objContent.m_dblCHECKAMT.ToString();
            txtAnaethesiaAmt.Text = p_objContent.m_dblANAETHESIAAMT.ToString();
            txtDeliveryChildAmt.Text = p_objContent.m_dblDELIVERYCHILDAMT.ToString();
            txtBabyAmt.Text = p_objContent.m_dblBABYAMT.ToString();
            txtAccompanyAmt.Text = p_objContent.m_dblACCOMPANYAMT.ToString();
            txtOtherAmt.Text = p_objContent.m_dblOTHERAMT.ToString();

            m_txtNEATEN.Text = p_objContent.m_strNEATENNAME;

            m_txtCODER.Text = p_objContent.m_strCODINGNAME;

            m_txtINPUTMACHINE.Text = p_objContent.m_strINPUTMACHINENAME;

            m_txtSTATISTIC.Text = p_objContent.m_strSTATISTICNAME;
            #endregion
        }
        #endregion

        #region 显示入院诊断
        /// <summary>
        /// 显示入院诊断
        /// </summary>
        /// <param name="p_objOtherDiagnosisArr"></param>
        private void m_mthSetInDiagnosisInfo(clsInHospitalMainRecord_GXInDiagnosis[] p_objInDiagnosisArr)
        {
            if (p_objInDiagnosisArr == null || p_objInDiagnosisArr.Length <= 0)
                return;

            object[] m_objResArr = new object[3];
            for (int i1 = 0 ; i1 < p_objInDiagnosisArr.Length ; i1++)
            {
                m_objResArr[0] = p_objInDiagnosisArr[i1].m_strDIAGNOSISDESC;
                m_objResArr[1] = p_objInDiagnosisArr[i1].m_strSTATCODE;
                m_objResArr[2] = p_objInDiagnosisArr[i1].m_strICD10;
                m_dtbInHospitalDiagnosis.Rows.Add(m_objResArr);
            }
        }
        #endregion

        #region 显示出院其他诊断
        /// <summary>
        /// 显示出院其他诊断
        /// </summary>
        /// <param name="p_objOtherDiagnosisArr"></param>
        private void m_mthSetOtherDiagnosisInfo(clsInHospitalMainRecord_GXOtherDiagnose[] p_objOtherDiagnosisArr)
        {
            if (p_objOtherDiagnosisArr == null || p_objOtherDiagnosisArr.Length <= 0)
                return;

            object[] m_objResArr = new object[9];
            for (int i1 = 0 ; i1 < p_objOtherDiagnosisArr.Length ; i1++)
            {
                m_objResArr[0] = p_objOtherDiagnosisArr[i1].m_strDIAGNOSISDESC;
                switch (p_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ)
                {
                    case 0:
                        m_objResArr[1] = true;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        m_objResArr[6] = false;
                        break;
                    case 1:
                        m_objResArr[1] = false;
                        m_objResArr[2] = true;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        m_objResArr[6] = false;
                        break;
                    case 2:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = true;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        m_objResArr[6] = false;
                        break;
                    case 3:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = true;
                        m_objResArr[5] = false;
                        m_objResArr[6] = false;
                        break;
                    case 4:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = true;
                        m_objResArr[6] = false;
                        break;
                    case 5:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        m_objResArr[6] = true;
                        break;
                    default:
                        m_objResArr[1] = false;
                        m_objResArr[2] = false;
                        m_objResArr[3] = false;
                        m_objResArr[4] = false;
                        m_objResArr[5] = false;
                        m_objResArr[6] = false;
                        break;
                }
                m_objResArr[7] = p_objOtherDiagnosisArr[i1].m_strSTATCODE;
                m_objResArr[8] = p_objOtherDiagnosisArr[i1].m_strICD10;
                m_dtbOtherDiagnosis.Rows.Add(m_objResArr);
            }
        }
        #endregion

        #region 显示该次住院的住院病案首页的手术情况表的信息
        /// <summary>
        /// 显示该次住院的住院病案首页的手术情况表的信息
        /// </summary>
        /// <param name="p_objOperationArr"></param>
        private void m_mthSetOperationInfo(clsInHospitalMainRecord_GXOperation[] p_objOperationArr)
        {
            if (p_objOperationArr == null || p_objOperationArr.Length <= 0)
                return;

            object[] m_objResArr = new object[14];
            for (int i1 = 0 ; i1 < p_objOperationArr.Length ; i1++)
            {
                if (p_objOperationArr[i1].m_dtmOPERATIONDATE != new DateTime(1900, 1, 1))
                    m_objResArr[0] = p_objOperationArr[i1].m_dtmOPERATIONDATE.ToString("yyyy-MM-dd HH:mm:ss");
                else
                {
                    m_objResArr[0] = DBNull.Value;
                }
                m_objResArr[1] = p_objOperationArr[i1].m_strOPERATIONNAME;
                m_objResArr[2] = p_objOperationArr[i1].m_strOPERATORNAME;
                m_objResArr[3] = p_objOperationArr[i1].m_strASSISTANT1NAME;
                m_objResArr[4] = p_objOperationArr[i1].m_strASSISTANT2NAME;
                m_objResArr[5] = p_objOperationArr[i1].m_strOPERATIONAANAESTHESIAMODENAME;
                m_objResArr[6] = p_objOperationArr[i1].m_strCUTLEVEL;
                m_objResArr[7] = p_objOperationArr[i1].m_strANAESTHETISTNAME;
                m_objResArr[8] = p_objOperationArr[i1].m_strOPERATIONID;
                m_objResArr[9] = p_objOperationArr[i1].m_strAANAESTHESIAMODEID;
                m_objResArr[10] = p_objOperationArr[i1].m_strOPERATOR;
                m_objResArr[11] = p_objOperationArr[i1].m_strASSISTANT1;
                m_objResArr[12] = p_objOperationArr[i1].m_strASSISTANT2;
                m_objResArr[13] = p_objOperationArr[i1].m_strANAESTHETIST;
                m_dtbOperationDetail.Rows.Add(m_objResArr);
            }
        }
        #endregion

        #region 显示已删除的该次住院的住院病案首页主表信息
        /// <summary>
        /// 显示已删除的该次住院的住院病案首页主表信息
        /// </summary>
        /// <param name="p_objContent"></param>
        private void m_mthSetDelMainInfo(clsInHospitalMainRecord_GX p_objMain, clsInHospitalMainRecord_GXContent p_objContent)
        {
            if (p_objMain == null || p_objContent == null)
            {
                #region 在住院病历没有记录时候，从其他表读入信息
                string strInPatientDate = m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                clsInPatientCaseHisoryDefaultDomain objInPaitentCaseDefault = new clsInPatientCaseHisoryDefaultDomain();
                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = null;

                if (m_objSelectedPatient != null)
                {
                    objInPatientCaseDefaultValue = objInPaitentCaseDefault.lngGetAllInPatientCaseHisoryDefault(m_objSelectedPatient.m_StrInPatientID, strInPatientDate);
                    if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
                    {
                        //						this.txtInHospitalDiagnosis.Text =objInPatientCaseDefaultValue[0].m_strFinallyDiagnose ; 
                    }
                }
                #endregion
                return;
            }

            #region 显示病案首页信息
            m_cboPayType.Text = p_objContent.m_strPAYTYPE;

            m_strCurrentOpenDate = p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_intSubmit = p_objMain.m_intSUBMIT_INT;

            if (p_objMain.m_intSUBMIT_INT == 1)
            {
                this.m_cmdSubmit.Enabled = false;
                this.m_cmdSubmit.Text = "已提交";
                //m_mthSetControlReadOnly(this, true);
            }
            else
            {

                //m_mthSetControlReadOnly(this, false);
                this.m_cmdSubmit.Enabled = true;
                this.m_cmdSubmit.Text = "提交";
            }

            switch (p_objContent.m_intCONDICTIONWHENIN)
            {
                case 1:
                    m_chkInstanceWhenIn1.Checked = true;
                    break;
                case 2:
                    m_chkInstanceWhenIn2.Checked = true;
                    break;
                case 3:
                    m_chkInstanceWhenIn3.Checked = true;
                    break;
            }

            dtpDiagnoseDate.Value = p_objContent.m_dtmCONFIRMDIAGNOSISDATE;

            txtDiagnosis.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strDIAGNOSIS, p_objMain.m_strDIAGNOSISXML);
            m_txtSTATCODEOFDIAGNOSIS.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFDIAGNOSIS, p_objMain.m_strSTATCODEOFDIAGNOSISXML);
            m_txtICD_10OFDIAGNOSIS.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFDIAGNOSIS, p_objMain.m_strICD_10OFDIAGNOSISXML);

            //			txtInHospitalDiagnosis.Text=ctlRichTextBox.s_strGetRightText(p_objContent.m_strINHOSPITALDIAGNOSIS, p_objMain.m_strINHOSPITALDIAGNOSISXML);
            //			m_txtSTATCODEOFINHOSPITALDIA.Text=ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFINHOSPITALDIA, p_objMain.m_strSTATCODEOFINHOSPITALDIAXML);
            //			m_txtICD_10OFINHOSPITALDIA.Text=ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFINHOSPITALDIA, p_objMain.m_strICD_10OFINHOSPITALDIAXML);

            m_txtMainDiagnosis.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strMAINDIAGNOSIS, p_objMain.m_strMAINDIAGNOSISXML);
            m_txtSTATCODEOFMAIN.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFMAIN, p_objMain.m_strSTATCODEOFMAINXML);
            m_txtICD_10OFMAIN.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFMAIN, p_objMain.m_strICD_10OFMAINXML);
            m_txtMainDiagnosisOther.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strOTHERMAINCONDITION, p_objMain.m_strOTHERMAINCONDITIONXML);
            #region
            switch (p_objContent.m_intMAINCONDITIONSEQ)
            {
                case 0:
                    m_chkMAINCONDITIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkMAINCONDITIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkMAINCONDITIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkMAINCONDITIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkMAINCONDITIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkMAINCONDITIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtCOMPLICATION.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strCOMPLICATION, p_objMain.m_strCOMPLICATIONXML);
            m_txtSTATCODEOFCOMPLICATION.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFCOMPLICATION, p_objMain.m_strSTATCODEOFCOMPLICATIONXML);
            m_txtICD_10OFCOMPLICATION.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFCOMPLICATION, p_objMain.m_strICD_10OFCOMPLICATIONXML);
            m_txtCOMPLICATIONOther.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strOTHERCOMPLICATION, p_objMain.m_strOTHERCOMPLICATIONXML);
            #region
            switch (p_objContent.m_intCOMPLICATIONSEQ)
            {
                case 0:
                    m_chkCOMPLICATIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkCOMPLICATIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkCOMPLICATIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkCOMPLICATIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkCOMPLICATIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkCOMPLICATIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtINFECTIONDIAGNOSIS.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strINFECTIONDIAGNOSIS, p_objMain.m_strINFECTIONDIAGNOSISXML);
            m_txtSTATCODEOFINFECTION.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFINFECTION, p_objMain.m_strSTATCODEOFINFECTIONXML);
            m_txtICD_10OFINFECTION.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFINFECTION, p_objMain.m_strICD_10OFINFECTIONXML);
            #region
            switch (p_objContent.m_intINFECTIONCONDICTIONSEQ)
            {
                case 0:
                    m_chkINFECTIONCONDICTIONSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkINFECTIONCONDICTIONSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkINFECTIONCONDICTIONSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkINFECTIONCONDICTIONSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkINFECTIONCONDICTIONSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkINFECTIONCONDICTIONSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtPATHOLOGYDIAGNOSIS.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strPATHOLOGYDIAGNOSIS, p_objMain.m_strPATHOLOGYDIAGNOSISXML);
            m_txtSTATCODEOFPATHOLOGYDIA.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSTATCODEOFPATHOLOGYDIA, p_objMain.m_strSTATCODEOFPATHOLOGYDIAXML);
            m_txtICD_10OFPATHOLOGYDIA.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strICD_10OFPATHOLOGYDIA, p_objMain.m_strICD_10OFPATHOLOGYDIAXML);
            m_txtPATHOLOGYDIAGNOSISOther.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strOTHERPATHOLOGYDIAGNOSIS, p_objMain.m_strOTHERPATHOLOGYDIAGNOSISXML);
            #region
            switch (p_objContent.m_intPATHOLOGYDIAGNOSISSEQ)
            {
                case 0:
                    m_chkPATHOLOGYDIAGNOSISSEQ0.Checked = true;
                    break;
                case 1:
                    m_chkPATHOLOGYDIAGNOSISSEQ1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOLOGYDIAGNOSISSEQ2.Checked = true;
                    break;
                case 3:
                    m_chkPATHOLOGYDIAGNOSISSEQ3.Checked = true;
                    break;
                case 4:
                    m_chkPATHOLOGYDIAGNOSISSEQ4.Checked = true;
                    break;
                case 5:
                    m_chkPATHOLOGYDIAGNOSISSEQ5.Checked = true;
                    break;
            }
            #endregion
            m_txtScacheSource.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSCACHESOURCE, p_objMain.m_strSCACHESOURCEXML);
            #region
            switch (p_objContent.m_intNEW5DISEASE)
            {
                case 1:
                    m_chkNEW5DISEASE1.Checked = true;
                    break;
                case 2:
                    m_chkNEW5DISEASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intSECONDLEVELTRANSFER)
            {
                case 1:
                    m_chkSECONDLEVELTRANSFER1.Checked = true;
                    break;
                case 2:
                    m_chkSECONDLEVELTRANSFER2.Checked = true;
                    break;
            }
            #endregion
            m_txtSENSITIVE.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strSENSITIVE, p_objMain.m_strSENSITIVEXML);

            m_cboHBsAg.SelectedIndex = p_objContent.m_intHBSAG;
            m_cboHCV_Ab.SelectedIndex = p_objContent.m_intHCV_AB;
            m_cboHIV_Ab.SelectedIndex = p_objContent.m_intHIV_AB;

            m_txtNEONATEDISEASE1.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strNEONATEDISEASE1, p_objMain.m_strNEONATEDISEASE1XML);
            m_txtNEONATEDISEASE2.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strNEONATEDISEASE2, p_objMain.m_strNEONATEDISEASE2XML);
            m_txtNEONATEDISEASE3.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strNEONATEDISEASE3, p_objMain.m_strNEONATEDISEASE3XML);
            m_txtNEONATEDISEASE4.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strNEONATEDISEASE4, p_objMain.m_strNEONATEDISEASE4XML);

            m_txtSALVETIMES.Text = p_objContent.m_intSALVETIMES.ToString();
            m_txtSALVESUCCESS.Text = p_objContent.m_intSALVESUCCESS.ToString();

            switch (p_objContent.m_intHASREMIND)
            {
                case 1:
                    m_chkHASREMIND1.Checked = true;
                    break;
                case 2:
                    m_chkHASREMIND2.Checked = true;
                    break;
            }

            m_txtREMINDTERM.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strREMINDTERM, p_objMain.m_strREMINDTERMXML);

            m_cboClinicOUt.SelectedIndex = p_objContent.m_intACCORDWITHOUTHOSPITAL - 1;
            m_cboInOut.SelectedIndex = p_objContent.m_intACCORDINWITHOUT - 1;
            m_cboBeforeOpAfterOp.SelectedIndex = p_objContent.m_intACCORDBFOPRWITHAF;
            m_cboClinicPh.SelectedIndex = p_objContent.m_intACCORDCLINICWITHPATHOLOGY;
            m_cboDeathCheck.SelectedIndex = p_objContent.m_intACCORDDEATHWITHBODYCHECK;
            m_cboClinicRad.SelectedIndex = p_objContent.m_intACCORDCLINICWITHRADIATE;
            #region
            switch (p_objContent.m_intMODELCASE)
            {
                case 1:
                    m_chkMODELCASE1.Checked = true;
                    break;
                case 2:
                    m_chkMODELCASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intFIRSTCASE)
            {
                case 1:
                    m_chkFIRSTCASE1.Checked = true;
                    break;
                case 2:
                    m_chkFIRSTCASE2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intQUALITY)
            {
                case 1:
                    m_chkQUALITY1.Checked = true;
                    break;
                case 2:
                    m_chkQUALITY2.Checked = true;
                    break;
                case 3:
                    m_chkQUALITY3.Checked = true;
                    break;
            }

            switch (p_objContent.m_intANTIBACTERIAL)
            {
                case 1:
                    m_chkANTIBACTERIAL1.Checked = true;
                    break;
                case 2:
                    m_chkANTIBACTERIAL2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intPATHOGENY)
            {
                case 1:
                    m_chkPATHOGENY1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOGENY2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intPATHOGENYRESULT)
            {
                case 1:
                    m_chkPATHOGENYRESULT1.Checked = true;
                    break;
                case 2:
                    m_chkPATHOGENYRESULT2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODTRANSACTOIN)
            {
                case 1:
                    m_chkBLOODTRANSACTOIN1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODTRANSACTOIN2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intTRANSFUSIONSACTION)
            {
                case 1:
                    m_chkTRANSFUSIONSACTION1.Checked = true;
                    break;
                case 2:
                    m_chkTRANSFUSIONSACTION2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intMRICHECK)
            {
                case 1:
                    m_chkMRICHECK1.Checked = true;
                    break;
                case 2:
                    m_chkMRICHECK2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intCTCHECK)
            {
                case 1:
                    m_chkCTCHECK1.Checked = true;
                    break;
                case 2:
                    m_chkCTCHECK2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODTYPE)
            {
                case 0:
                    m_chkBLOODTYPE0.Checked = true;
                    break;
                case 1:
                    m_chkBLOODTYPE1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODTYPE2.Checked = true;
                    break;
                case 3:
                    m_chkBLOODTYPE3.Checked = true;
                    break;
                case 4:
                    m_chkBLOODTYPE4.Checked = true;
                    break;
            }

            switch (p_objContent.m_intBLOODRH)
            {
                case 0:
                    m_chkBLOODRH0.Checked = true;
                    break;
                case 1:
                    m_chkBLOODRH1.Checked = true;
                    break;
                case 2:
                    m_chkBLOODRH2.Checked = true;
                    break;
            }

            switch (p_objContent.m_intXRAYCHECK)
            {
                case 1:
                    m_chkXRayCheck1.Checked = true;
                    break;
                case 2:
                    m_chkXRayCheck2.Checked = true;
                    break;
                case 3:
                    m_chkXRayCheck3.Checked = true;
                    break;
            }

            #endregion

            m_txtRBC.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strRBC, p_objMain.m_strRBCXML);
            m_txtPLT.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strPLT, p_objMain.m_strPLTXML);
            m_txtPLASM.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strPLASM, p_objMain.m_strPLASMXML);
            m_txtWHOLEBLOOD.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strWHOLEBLOOD, p_objMain.m_strWHOLEBLOODXML);
            m_txtOTHERBLOOD.Text = ctlRichTextBox.s_strGetRightText(p_objContent.m_strOTHERBLOOD, p_objMain.m_strOTHERBLOODXML);
            #region
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDEPTDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDeptDirectorDt.Tag = objEmpVO;
                txtDeptDirectorDt.Text = p_objContent.m_strDEPTDIRECTORDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDt.Tag = objEmpVO;
                txtDt.Text = p_objContent.m_strDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strINHOSPITALDOC, out objEmpVO);
            if (objEmpVO != null)
            {
                txtInHospitalDt.Tag = objEmpVO;
                txtInHospitalDt.Text = p_objContent.m_strINHOSPITALDOCNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strOUTHOSPITALDOC, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtOutHospitalDoc.Tag = objEmpVO;
                m_txtOutHospitalDoc.Text = p_objContent.m_strOUTHOSPITALDOCNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtDirectorDt.Tag = objEmpVO;
                txtDirectorDt.Text = p_objContent.m_strDIRECTORDTNAME;
            }

            objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strSUBDIRECTORDT, out objEmpVO);
            if (objEmpVO != null)
            {
                txtSubDirectorDt.Tag = objEmpVO;
                txtSubDirectorDt.Text = p_objContent.m_strSUBDIRECTORDTNAME;
            }

            if (!string.IsNullOrEmpty(p_objContent.m_strATTENDINFORADVANCESSTUDYDT))
            {
                objEmployeeSign.m_lngGetEmpByNO_IncludeHistory(p_objContent.m_strATTENDINFORADVANCESSTUDYDT, out objEmpVO);
                if (objEmpVO != null)
                {
                    txtAttendInStudyDt.Tag = objEmpVO;
                }
            }
            #endregion
            txtAttendInStudyDt.Text = p_objContent.m_strATTENDINFORADVANCESSTUDYDTNAME;

            txtGraduateStudentIntern.Text = p_objContent.m_strGRADUATESTUDENTINTERNNAME;
            txtIntern.Text = p_objContent.m_strINTERNNAME;

            txtTotalAmt.Text = p_objContent.m_dblTOTALAMT.ToString();
            txtBedAmt.Text = p_objContent.m_dblBEDAMT.ToString();
            txtNurseAmt.Text = p_objContent.m_dblNURSEAMT.ToString();
            txtWMAmt.Text = p_objContent.m_dblWMAMT.ToString();
            txtCMFinishedAmt.Text = p_objContent.m_dblCMFINISHEDAMT.ToString();
            txtCMSemiFinishedAmt.Text = p_objContent.m_dblCMSEMIFINISHEDAMT.ToString();
            txtRadiationAmt.Text = p_objContent.m_dblRADIATIONAMT.ToString();
            txtAssayAmt.Text = p_objContent.m_dblASSAYAMT.ToString();
            txtO2Amt.Text = p_objContent.m_dblO2AMT.ToString();
            txtBloodAmt.Text = p_objContent.m_dblBLOODAMT.ToString();
            txtTreatmentAmt.Text = p_objContent.m_dblTREATMENTAMT.ToString();
            txtOperationAmt.Text = p_objContent.m_dblOPERATIONAMT.ToString();
            txtCheckAmt.Text = p_objContent.m_dblCHECKAMT.ToString();
            txtAnaethesiaAmt.Text = p_objContent.m_dblANAETHESIAAMT.ToString();
            txtDeliveryChildAmt.Text = p_objContent.m_dblDELIVERYCHILDAMT.ToString();
            txtBabyAmt.Text = p_objContent.m_dblBABYAMT.ToString();
            txtAccompanyAmt.Text = p_objContent.m_dblACCOMPANYAMT.ToString();
            txtOtherAmt.Text = p_objContent.m_dblOTHERAMT.ToString();

            m_txtNEATEN.Text = p_objContent.m_strNEATENNAME;

            m_txtCODER.Text = p_objContent.m_strCODINGNAME;

            m_txtINPUTMACHINE.Text = p_objContent.m_strINPUTMACHINENAME;

            m_txtSTATISTIC.Text = p_objContent.m_strSTATISTICNAME;
            #endregion
        }
        #endregion

        #endregion

        #region 添加新纪录
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
            if (m_objCollection == null)
                m_objCollection = new clsInHospitalMainRecord_GX_Collection();
            m_objCollection.m_objMain = m_objGetMain(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objContent = m_objGetContent(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objInDiagnosisArr = m_objGetInDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objOtherDiagnosisArr = m_objGetOtherDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);
            m_objCollection.m_objOperationArr = m_objGetOperationArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            //手术日期在范围外，不允许保存
            if (m_dtbOperationDetail.Rows.Count > 0 && m_objCollection.m_objOperationArr == null)
            {
                return -1;
            }

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
                m_objCollection.m_objOperationArr = null;
                m_objCollection.m_objOtherDiagnosisArr = null;
                m_objCollection.m_objInDiagnosisArr = null;
            }
            else
            {
                m_bolIfHasSave = true;
            }
            return m_lngRes;
        }

        #endregion

        #region 修改检查
        /// <summary>
        /// 修改检查
        /// </summary>
        /// <param name="p_bolMdfOrDel"></param>
        /// <returns></returns>
        private bool m_bolModifyCheck(bool p_bolMdfOrDel)
        {
            DateTime m_dtmLastModifyDate = DateTime.MinValue;
            string m_strLastModifyUserID = null;
            if (m_objCollection == null || m_objCollection.m_objContent == null)
                return false;
            long m_lngRes = m_objDomain.m_lngGetLastModifyDateAndUser(m_objCollection.m_objMain.m_lngEMR_SEQ, out m_strLastModifyUserID, out m_dtmLastModifyDate);
            if (m_lngRes < 1)
            {
                m_mthShowDBError();
                return false;
            }
            if (m_dtmLastModifyDate == DateTime.MinValue || m_dtmLastModifyDate == new DateTime(1900, 1, 1))
            {
                DateTime m_dtmDeactivedDate = DateTime.MinValue;
                string m_strDeactivedUserID = null;
                m_lngRes = m_objDomain.m_lngGetDeactivedDateAndUser(frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR, out m_dtmDeactivedDate, out m_strDeactivedUserID);
                if (m_lngRes < 1)
                {
                    m_mthShowDBError();
                    return false;
                }
                else
                {
                    m_mthShowRecordDeleted(m_strDeactivedUserID, m_dtmDeactivedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    return false;
                }
            }

            if (m_objCollection.m_objContent.m_dtmModifyDate != m_dtmLastModifyDate)
            {
                if (m_bolShowRecordModified(m_strLastModifyUserID, m_dtmLastModifyDate.ToString("yyyy-MM-dd HH:mm:ss")))
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
                    return true;
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

            clsInHospitalMainRecord_GX m_objMain = m_objGetMain(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_GXContent m_objContent = m_objGetContent(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_GXInDiagnosis[] m_objInDiagnosisArr = m_objGetInDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_GXOtherDiagnose[] m_objOtherDiagnosisArr = m_objGetOtherDiagnosisArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            clsInHospitalMainRecord_GXOperation[] m_objOperationArr = m_objGetOperationArr(m_strInPatientID, m_strInPatientDate, m_strCurrentDateTime);

            //手术日期在范围外，不允许保存
            if (m_dtbOperationDetail.Rows.Count > 0 && m_objOperationArr == null)
            {
                return -1;
            }
            //电子签名
            clsInHospitalMainRecord_GX_Collection m_objCollection1 = new clsInHospitalMainRecord_GX_Collection();
            m_objCollection1.m_objMain = m_objMain;
            m_objCollection1.m_objContent = m_objContent;
            m_objCollection1.m_objInDiagnosisArr = m_objInDiagnosisArr;
            m_objCollection1.m_objOtherDiagnosisArr = m_objOtherDiagnosisArr;
            m_objCollection1.m_objOperationArr = m_objOperationArr;
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID.Trim() + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(m_objCollection1, objSign_VO) == -1)
                return -1;

            long m_lngRes = m_objDomain.m_lngDoSave(m_objCollection1, m_BlnIsAddNew);

            if (m_lngRes < 1)
            {
                m_mthShowDBError();
            }
            else
            {
                m_objCollection.m_objMain = m_objMain;
                m_objCollection.m_objContent = m_objContent;
                m_objCollection.m_objOtherDiagnosisArr = m_objOtherDiagnosisArr;
                m_objCollection.m_objOperationArr = m_objOperationArr;
                m_objCollection.m_objInDiagnosisArr = m_objInDiagnosisArr;
            }
            return m_lngRes;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        protected override long m_lngSubDelete()
        {
            if (m_objCurrentContext.m_ObjControl.m_enmDeleteCheck(m_ObjCurrentEmrPatientSession.m_strAreaId, this, enmFormState.NowUser)
                == enmDBControlCheckResult.Disable)
            {
                clsPublicFunction.s_mthShowNotPermitMessage();
                return -1;
            }

            if (m_objSelectedPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                m_mthShowNoPatient();
                return -1;
            }
            if (m_objCollection == null)
            {
                return -1;
            }
            //if (trvTime.Nodes[0].Nodes.Count <= 0 || trvTime.SelectedNode == null)
            //    return -1;

            if (!m_bolModifyCheck(false))
                return -1;

            long m_lngRes = m_objDomain.m_lngDeleteRecord(m_objCollection.m_objMain.m_lngEMR_SEQ, MDIParent.OperatorID);
            if (m_lngRes < 1)
            {
                base.m_mthShowDBError();
                return -1;
            }
            else
            {
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                m_objCollection = null;
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
        private clsInHospitalMainRecord_GX m_objGetMain(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            clsInHospitalMainRecord_GX m_objMain = new clsInHospitalMainRecord_GX();
            try
            {
                m_objMain.m_intSUBMIT_INT = this.m_intSubmit;
                m_objMain.m_strInPatientID = p_strInPatientID;
                m_objMain.m_dtmInPatientDate = Convert.ToDateTime(p_strInPatientDate);
                if (m_bolIfHasSave)
                {
                    m_objMain.m_dtmOpenDate = m_objCollection.m_objMain.m_dtmOpenDate;
                    m_objMain.m_lngEMR_SEQ = m_objCollection.m_objMain.m_lngEMR_SEQ;
                }
                else
                    m_objMain.m_dtmOpenDate = Convert.ToDateTime(p_strCurrentDateTime);
                m_objMain.m_strCreateUserID = MDIParent.OperatorID;

                m_objMain.m_strDIAGNOSISXML = txtDiagnosis.m_strGetXmlText();
                //				m_objMain.m_strINHOSPITALDIAGNOSISXML = txtInHospitalDiagnosis.m_strGetXmlText();
                m_objMain.m_strMAINDIAGNOSISXML = m_txtMainDiagnosis.m_strGetXmlText();
                m_objMain.m_strCOMPLICATIONXML = m_txtCOMPLICATION.m_strGetXmlText();
                m_objMain.m_strINFECTIONDIAGNOSISXML = m_txtINFECTIONDIAGNOSIS.m_strGetXmlText();
                m_objMain.m_strPATHOLOGYDIAGNOSISXML = m_txtPATHOLOGYDIAGNOSIS.m_strGetXmlText();
                m_objMain.m_strICD_10OFMAINXML = m_txtICD_10OFMAIN.m_strGetXmlText();
                m_objMain.m_strICD_10OFINFECTIONXML = m_txtICD_10OFINFECTION.m_strGetXmlText();
                m_objMain.m_strICD_10OFCOMPLICATIONXML = m_txtICD_10OFCOMPLICATION.m_strGetXmlText();
                m_objMain.m_strICD_10OFDIAGNOSISXML = m_txtICD_10OFDIAGNOSIS.m_strGetXmlText();
                //				m_objMain.m_strICD_10OFINHOSPITALDIAXML = m_txtICD_10OFINHOSPITALDIA.m_strGetXmlText();
                m_objMain.m_strICD_10OFPATHOLOGYDIAXML = m_txtICD_10OFPATHOLOGYDIA.m_strGetXmlText();
                m_objMain.m_strSTATCODEOFMAINXML = m_txtSTATCODEOFMAIN.m_strGetXmlText();
                m_objMain.m_strSTATCODEOFINFECTIONXML = m_txtSTATCODEOFINFECTION.m_strGetXmlText();
                m_objMain.m_strSTATCODEOFPATHOLOGYDIAXML = m_txtSTATCODEOFPATHOLOGYDIA.m_strGetXmlText();
                m_objMain.m_strSTATCODEOFDIAGNOSISXML = m_txtSTATCODEOFDIAGNOSIS.m_strGetXmlText();
                //				m_objMain.m_strSTATCODEOFINHOSPITALDIAXML = m_txtSTATCODEOFINHOSPITALDIA.m_strGetXmlText();
                m_objMain.m_strSTATCODEOFCOMPLICATIONXML = m_txtSTATCODEOFCOMPLICATION.m_strGetXmlText();
                m_objMain.m_strSCACHESOURCEXML = m_txtScacheSource.m_strGetXmlText();
                m_objMain.m_strSENSITIVEXML = m_txtSENSITIVE.m_strGetXmlText();
                m_objMain.m_strNEONATEDISEASE1XML = m_txtNEONATEDISEASE1.m_strGetXmlText();
                m_objMain.m_strNEONATEDISEASE2XML = m_txtNEONATEDISEASE2.m_strGetXmlText();
                m_objMain.m_strNEONATEDISEASE3XML = m_txtNEONATEDISEASE3.m_strGetXmlText();
                m_objMain.m_strNEONATEDISEASE4XML = m_txtNEONATEDISEASE4.m_strGetXmlText();
                //m_objMain.m_strSALVETIMESXML = m_txtSALVETIMES.m_strGetXmlText();
                //m_objMain.m_strSALVESUCCESSXML = m_txtSALVESUCCESS.m_strGetXmlText();
                m_objMain.m_strREMINDTERMXML = m_txtREMINDTERM.m_strGetXmlText();
                m_objMain.m_strRBCXML = m_txtRBC.m_strGetXmlText();
                m_objMain.m_strPLTXML = m_txtPLT.m_strGetXmlText();
                m_objMain.m_strPLASMXML = m_txtPLASM.m_strGetXmlText();
                m_objMain.m_strWHOLEBLOODXML = m_txtWHOLEBLOOD.m_strGetXmlText();
                m_objMain.m_strOTHERBLOODXML = m_txtOTHERBLOOD.m_strGetXmlText();
                if (m_strRegisterID != null)
                    m_objMain.m_strREGISTERID_CHR = m_strRegisterID;
                m_objMain.m_strOTHERMAINCONDITIONXML = m_txtMainDiagnosisOther.m_strGetXmlText();
                m_objMain.m_strOTHERCOMPLICATIONXML = m_txtCOMPLICATIONOther.m_strGetXmlText();
                m_objMain.m_strOTHERINFECTIONCONDICTIONXML = m_txtINFECTIONDIAGNOSISOther.m_strGetXmlText();
                m_objMain.m_strOTHERPATHOLOGYDIAGNOSISXML = m_txtPATHOLOGYDIAGNOSISOther.m_strGetXmlText();
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
        private clsInHospitalMainRecord_GXContent m_objGetContent(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            clsInHospitalMainRecord_GXContent m_objContent = new clsInHospitalMainRecord_GXContent();
            try
            {
                m_objContent.m_strInPatientID = p_strInPatientID;
                m_objContent.m_dtmInPatientDate = Convert.ToDateTime(p_strInPatientDate);
                if (m_bolIfHasSave)
                {
                    m_objContent.m_dtmOpenDate = m_objCollection.m_objMain.m_dtmOpenDate;
                    m_objContent.m_lngEMR_SEQ = m_objCollection.m_objMain.m_lngEMR_SEQ;
                }
                else
                    m_objContent.m_dtmOpenDate = Convert.ToDateTime(p_strCurrentDateTime);
                m_objContent.m_dtmModifyDate = Convert.ToDateTime(p_strCurrentDateTime);
                m_objContent.m_strModifyUserID = MDIParent.OperatorID;

                if (m_chkInstanceWhenIn1.Checked)
                    m_objContent.m_intCONDICTIONWHENIN = 1;
                else if (m_chkInstanceWhenIn2.Checked)
                    m_objContent.m_intCONDICTIONWHENIN = 2;
                else if (m_chkInstanceWhenIn3.Checked)
                    m_objContent.m_intCONDICTIONWHENIN = 3;

                m_objContent.m_dtmCONFIRMDIAGNOSISDATE = dtpDiagnoseDate.Value;
                m_objContent.m_strDIAGNOSIS = txtDiagnosis.Text;
                //				m_objContent.m_strINHOSPITALDIAGNOSIS = txtInHospitalDiagnosis.Text;
                m_objContent.m_strMAINDIAGNOSIS = m_txtMainDiagnosis.Text;
                m_objContent.m_strCOMPLICATION = m_txtCOMPLICATION.Text;
                m_objContent.m_strINFECTIONDIAGNOSIS = m_txtINFECTIONDIAGNOSIS.Text;
                m_objContent.m_strPATHOLOGYDIAGNOSIS = m_txtPATHOLOGYDIAGNOSIS.Text;
                m_objContent.m_strICD_10OFMAIN = m_txtICD_10OFMAIN.Text;
                m_objContent.m_strICD_10OFINFECTION = m_txtICD_10OFINFECTION.Text;
                m_objContent.m_strICD_10OFCOMPLICATION = m_txtICD_10OFCOMPLICATION.Text;
                m_objContent.m_strICD_10OFDIAGNOSIS = m_txtICD_10OFDIAGNOSIS.Text;
                //				m_objContent.m_strICD_10OFINHOSPITALDIA = m_txtICD_10OFINHOSPITALDIA.Text;
                m_objContent.m_strICD_10OFPATHOLOGYDIA = m_txtICD_10OFPATHOLOGYDIA.Text;
                m_objContent.m_strSTATCODEOFMAIN = m_txtSTATCODEOFMAIN.Text;
                m_objContent.m_strSTATCODEOFINFECTION = m_txtSTATCODEOFINFECTION.Text;
                m_objContent.m_strSTATCODEOFPATHOLOGYDIA = m_txtSTATCODEOFPATHOLOGYDIA.Text;
                m_objContent.m_strSTATCODEOFDIAGNOSIS = m_txtSTATCODEOFDIAGNOSIS.Text;
                //				m_objContent.m_strSTATCODEOFINHOSPITALDIA = m_txtSTATCODEOFINHOSPITALDIA.Text;
                m_objContent.m_strSTATCODEOFCOMPLICATION = m_txtSTATCODEOFCOMPLICATION.Text;
                #region
                if (m_chkMAINCONDITIONSEQ0.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 0;
                else if (m_chkMAINCONDITIONSEQ1.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 1;
                else if (m_chkMAINCONDITIONSEQ2.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 2;
                else if (m_chkMAINCONDITIONSEQ3.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 3;
                else if (m_chkMAINCONDITIONSEQ4.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 4;
                else if (m_chkMAINCONDITIONSEQ5.Checked)
                    m_objContent.m_intMAINCONDITIONSEQ = 5;

                if (m_chkCOMPLICATIONSEQ0.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 0;
                else if (m_chkCOMPLICATIONSEQ1.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 1;
                else if (m_chkCOMPLICATIONSEQ2.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 2;
                else if (m_chkCOMPLICATIONSEQ3.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 3;
                else if (m_chkCOMPLICATIONSEQ4.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 4;
                else if (m_chkCOMPLICATIONSEQ5.Checked)
                    m_objContent.m_intCOMPLICATIONSEQ = 5;

                if (m_chkINFECTIONCONDICTIONSEQ0.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 0;
                else if (m_chkINFECTIONCONDICTIONSEQ1.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 1;
                else if (m_chkINFECTIONCONDICTIONSEQ2.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 2;
                else if (m_chkINFECTIONCONDICTIONSEQ3.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 3;
                else if (m_chkINFECTIONCONDICTIONSEQ4.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 4;
                else if (m_chkINFECTIONCONDICTIONSEQ5.Checked)
                    m_objContent.m_intINFECTIONCONDICTIONSEQ = 5;

                if (m_chkPATHOLOGYDIAGNOSISSEQ0.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 0;
                else if (m_chkPATHOLOGYDIAGNOSISSEQ1.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 1;
                else if (m_chkPATHOLOGYDIAGNOSISSEQ2.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 2;
                else if (m_chkPATHOLOGYDIAGNOSISSEQ3.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 3;
                else if (m_chkPATHOLOGYDIAGNOSISSEQ4.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 4;
                else if (m_chkPATHOLOGYDIAGNOSISSEQ5.Checked)
                    m_objContent.m_intPATHOLOGYDIAGNOSISSEQ = 5;

                m_objContent.m_strSCACHESOURCE = m_txtScacheSource.Text;

                if (m_chkNEW5DISEASE1.Checked)
                    m_objContent.m_intNEW5DISEASE = 1;
                else if (m_chkNEW5DISEASE2.Checked)
                    m_objContent.m_intNEW5DISEASE = 2;

                if (m_chkSECONDLEVELTRANSFER1.Checked)
                    m_objContent.m_intSECONDLEVELTRANSFER = 1;
                else if (m_chkSECONDLEVELTRANSFER2.Checked)
                    m_objContent.m_intSECONDLEVELTRANSFER = 2;
                #endregion
                m_objContent.m_strSENSITIVE = m_txtSENSITIVE.Text;
                m_objContent.m_intHBSAG = m_cboHBsAg.SelectedIndex;
                m_objContent.m_intHCV_AB = m_cboHCV_Ab.SelectedIndex;
                m_objContent.m_intHIV_AB = m_cboHIV_Ab.SelectedIndex;

                m_objContent.m_strNEONATEDISEASE1 = m_txtNEONATEDISEASE1.Text;
                m_objContent.m_strNEONATEDISEASE2 = m_txtNEONATEDISEASE2.Text;
                m_objContent.m_strNEONATEDISEASE3 = m_txtNEONATEDISEASE3.Text;
                m_objContent.m_strNEONATEDISEASE4 = m_txtNEONATEDISEASE4.Text;
                if (m_txtSALVETIMES.Text.Trim() != "")
                    m_objContent.m_intSALVETIMES = Convert.ToInt32(m_txtSALVETIMES.Text);
                if (m_txtSALVESUCCESS.Text.Trim() != "")
                    m_objContent.m_intSALVESUCCESS = Convert.ToInt32(m_txtSALVESUCCESS.Text);

                if (m_chkHASREMIND1.Checked)
                    m_objContent.m_intHASREMIND = 1;
                else if (m_chkHASREMIND2.Checked)
                    m_objContent.m_intHASREMIND = 2;

                m_objContent.m_strREMINDTERM = m_txtREMINDTERM.Text;
                m_objContent.m_intACCORDWITHOUTHOSPITAL = m_cboClinicOUt.SelectedIndex + 1;
                m_objContent.m_intACCORDINWITHOUT = m_cboInOut.SelectedIndex + 1;
                m_objContent.m_intACCORDBFOPRWITHAF = m_cboBeforeOpAfterOp.SelectedIndex;
                m_objContent.m_intACCORDCLINICWITHPATHOLOGY = m_cboClinicPh.SelectedIndex;
                m_objContent.m_intACCORDCLINICWITHRADIATE = m_cboClinicRad.SelectedIndex;
                m_objContent.m_intACCORDDEATHWITHBODYCHECK = m_cboDeathCheck.SelectedIndex;
                #region
                if (m_chkFIRSTCASE1.Checked)
                    m_objContent.m_intFIRSTCASE = 1;
                else if (m_chkFIRSTCASE2.Checked)
                    m_objContent.m_intFIRSTCASE = 2;

                if (m_chkMODELCASE1.Checked)
                    m_objContent.m_intMODELCASE = 1;
                else if (m_chkMODELCASE2.Checked)
                    m_objContent.m_intMODELCASE = 2;

                if (m_chkQUALITY1.Checked)
                    m_objContent.m_intQUALITY = 1;
                else if (m_chkQUALITY2.Checked)
                    m_objContent.m_intQUALITY = 2;
                else if (m_chkQUALITY3.Checked)
                    m_objContent.m_intQUALITY = 3;

                if (m_chkANTIBACTERIAL1.Checked)
                    m_objContent.m_intANTIBACTERIAL = 1;
                else if (m_chkANTIBACTERIAL2.Checked)
                    m_objContent.m_intANTIBACTERIAL = 2;

                if (m_chkPATHOGENY1.Checked)
                    m_objContent.m_intPATHOGENY = 1;
                else if (m_chkPATHOGENY2.Checked)
                    m_objContent.m_intPATHOGENY = 2;

                if (m_chkPATHOGENYRESULT1.Checked)
                    m_objContent.m_intPATHOGENYRESULT = 1;
                else if (m_chkPATHOGENYRESULT2.Checked)
                    m_objContent.m_intPATHOGENYRESULT = 2;

                if (m_chkBLOODTRANSACTOIN1.Checked)
                    m_objContent.m_intBLOODTRANSACTOIN = 1;
                else if (m_chkBLOODTRANSACTOIN2.Checked)
                    m_objContent.m_intBLOODTRANSACTOIN = 2;

                if (m_chkTRANSFUSIONSACTION1.Checked)
                    m_objContent.m_intTRANSFUSIONSACTION = 1;
                else if (m_chkTRANSFUSIONSACTION2.Checked)
                    m_objContent.m_intTRANSFUSIONSACTION = 2;

                if (m_chkMRICHECK1.Checked)
                    m_objContent.m_intMRICHECK = 1;
                else if (m_chkMRICHECK2.Checked)
                    m_objContent.m_intMRICHECK = 2;

                if (m_chkCTCHECK1.Checked)
                    m_objContent.m_intCTCHECK = 1;
                else if (m_chkCTCHECK2.Checked)
                    m_objContent.m_intCTCHECK = 2;

                if (m_chkBLOODTYPE0.Checked)
                    m_objContent.m_intBLOODTYPE = 0;
                else if (m_chkBLOODTYPE1.Checked)
                    m_objContent.m_intBLOODTYPE = 1;
                else if (m_chkBLOODTYPE2.Checked)
                    m_objContent.m_intBLOODTYPE = 2;
                else if (m_chkBLOODTYPE3.Checked)
                    m_objContent.m_intBLOODTYPE = 3;
                else if (m_chkBLOODTYPE4.Checked)
                    m_objContent.m_intBLOODTYPE = 4;

                if (m_chkBLOODRH0.Checked)
                    m_objContent.m_intBLOODRH = 0;
                else if (m_chkBLOODRH1.Checked)
                    m_objContent.m_intBLOODRH = 1;
                else if (m_chkBLOODRH2.Checked)
                    m_objContent.m_intBLOODRH = 2;

                if (m_chkXRayCheck1.Checked)
                    m_objContent.m_intXRAYCHECK = 1;
                else if (m_chkXRayCheck2.Checked)
                    m_objContent.m_intXRAYCHECK = 2;
                else if (m_chkXRayCheck3.Checked)
                    m_objContent.m_intXRAYCHECK = 3;
                #endregion
                m_objContent.m_strRBC = m_txtRBC.Text;
                m_objContent.m_strPLT = m_txtPLT.Text;
                m_objContent.m_strPLASM = m_txtPLASM.Text;
                m_objContent.m_strWHOLEBLOOD = m_txtWHOLEBLOOD.Text;
                m_objContent.m_strOTHERBLOOD = m_txtOTHERBLOOD.Text;
                #region
                if (txtDeptDirectorDt.Tag == null)
                {
                    m_objContent.m_strDEPTDIRECTORDTNAME = "";
                    m_objContent.m_strDEPTDIRECTORDT = "";
                }
                else
                {
                    m_objContent.m_strDEPTDIRECTORDTNAME = txtDeptDirectorDt.Text;
                    m_objContent.m_strDEPTDIRECTORDT = ((clsEmrEmployeeBase_VO)txtDeptDirectorDt.Tag).m_strEMPNO_CHR;
                }
                if (txtDt.Tag == null)
                {
                    m_objContent.m_strDTNAME = "";
                    m_objContent.m_strDT = "";
                }
                else
                {
                    m_objContent.m_strDTNAME = txtDt.Text;
                    m_objContent.m_strDT = ((clsEmrEmployeeBase_VO)txtDt.Tag).m_strEMPNO_CHR;
                }
                if (txtInHospitalDt.Tag == null)
                {
                    m_objContent.m_strINHOSPITALDOCNAME = "";
                    m_objContent.m_strINHOSPITALDOC = "";
                }
                else
                {
                    m_objContent.m_strINHOSPITALDOCNAME = txtInHospitalDt.Text;
                    m_objContent.m_strINHOSPITALDOC = ((clsEmrEmployeeBase_VO)txtInHospitalDt.Tag).m_strEMPNO_CHR;
                }
                if (m_txtOutHospitalDoc.Tag == null)
                {
                    m_objContent.m_strOUTHOSPITALDOCNAME = "";
                    m_objContent.m_strOUTHOSPITALDOC = "";
                }
                else
                {
                    m_objContent.m_strOUTHOSPITALDOCNAME = m_txtOutHospitalDoc.Text;
                    m_objContent.m_strOUTHOSPITALDOC = ((clsEmrEmployeeBase_VO)m_txtOutHospitalDoc.Tag).m_strEMPNO_CHR;
                }
                if (txtDirectorDt.Tag == null)
                {
                    m_objContent.m_strDIRECTORDTNAME = "";
                    m_objContent.m_strDIRECTORDT = "";
                }
                else
                {
                    m_objContent.m_strDIRECTORDTNAME = txtDirectorDt.Text;
                    m_objContent.m_strDIRECTORDT = ((clsEmrEmployeeBase_VO)txtDirectorDt.Tag).m_strEMPNO_CHR;
                }
                if (txtSubDirectorDt.Tag == null)
                {
                    m_objContent.m_strSUBDIRECTORDTNAME = "";
                    m_objContent.m_strSUBDIRECTORDT = "";
                }
                else
                {
                    m_objContent.m_strSUBDIRECTORDTNAME = txtSubDirectorDt.Text;
                    m_objContent.m_strSUBDIRECTORDT = ((clsEmrEmployeeBase_VO)txtSubDirectorDt.Tag).m_strEMPNO_CHR;
                }
                #endregion 
                //if(txtAttendInStudyDt.Tag == null)
                //    m_objContent.m_strATTENDINFORADVANCESSTUDYDT = "";
                //else
                //    m_objContent.m_strATTENDINFORADVANCESSTUDYDT = ((clsEmrEmployeeBase_VO)txtAttendInStudyDt.Tag).m_strEMPNO_CHR;

                m_objContent.m_strATTENDINFORADVANCESSTUDYDTNAME = txtAttendInStudyDt.Text;
                m_objContent.m_strGRADUATESTUDENTINTERNNAME = txtGraduateStudentIntern.Text;
                m_objContent.m_strINTERNNAME = txtIntern.Text;

                if (txtTotalAmt.Text.Trim() != "")
                    m_objContent.m_dblTOTALAMT = Convert.ToDouble(txtTotalAmt.Text);
                if (txtBedAmt.Text.Trim() != "")
                    m_objContent.m_dblBEDAMT = Convert.ToDouble(txtBedAmt.Text);
                if (txtNurseAmt.Text.Trim() != "")
                    m_objContent.m_dblNURSEAMT = Convert.ToDouble(txtNurseAmt.Text);
                if (txtWMAmt.Text.Trim() != "")
                    m_objContent.m_dblWMAMT = Convert.ToDouble(txtWMAmt.Text);
                if (txtCMFinishedAmt.Text.Trim() != "")
                    m_objContent.m_dblCMFINISHEDAMT = Convert.ToDouble(txtCMFinishedAmt.Text);
                if (txtCMSemiFinishedAmt.Text.Trim() != "")
                    m_objContent.m_dblCMSEMIFINISHEDAMT = Convert.ToDouble(txtCMSemiFinishedAmt.Text);
                if (txtRadiationAmt.Text.Trim() != "")
                    m_objContent.m_dblRADIATIONAMT = Convert.ToDouble(txtRadiationAmt.Text);
                if (txtAssayAmt.Text.Trim() != "")
                    m_objContent.m_dblASSAYAMT = Convert.ToDouble(txtAssayAmt.Text);
                if (txtO2Amt.Text.Trim() != "")
                    m_objContent.m_dblO2AMT = Convert.ToDouble(txtO2Amt.Text);
                if (txtBloodAmt.Text.Trim() != "")
                    m_objContent.m_dblBLOODAMT = Convert.ToDouble(txtBloodAmt.Text);
                if (txtTreatmentAmt.Text.Trim() != "")
                    m_objContent.m_dblTREATMENTAMT = Convert.ToDouble(txtTreatmentAmt.Text);
                if (txtOperationAmt.Text.Trim() != "")
                    m_objContent.m_dblOPERATIONAMT = Convert.ToDouble(txtOperationAmt.Text);
                if (txtCheckAmt.Text.Trim() != "")
                    m_objContent.m_dblCHECKAMT = Convert.ToDouble(txtCheckAmt.Text);
                if (txtAnaethesiaAmt.Text.Trim() != "")
                    m_objContent.m_dblANAETHESIAAMT = Convert.ToDouble(txtAnaethesiaAmt.Text);
                if (txtDeliveryChildAmt.Text.Trim() != "")
                    m_objContent.m_dblDELIVERYCHILDAMT = Convert.ToDouble(txtDeliveryChildAmt.Text);
                if (txtBabyAmt.Text.Trim() != "")
                    m_objContent.m_dblBABYAMT = Convert.ToDouble(txtBabyAmt.Text);
                if (txtAccompanyAmt.Text.Trim() != "")
                    m_objContent.m_dblACCOMPANYAMT = Convert.ToDouble(txtAccompanyAmt.Text);
                if (txtOtherAmt.Text.Trim() != "")
                    m_objContent.m_dblOTHERAMT = Convert.ToDouble(txtOtherAmt.Text);

                if (m_strRegisterID != null)
                    m_objContent.m_strREGISTERID_CHR = m_strRegisterID;


                m_objContent.m_strNEATENNAME = m_txtNEATEN.Text;
                m_objContent.m_strCODINGNAME = m_txtCODER.Text;
                m_objContent.m_strINPUTMACHINENAME = m_txtINPUTMACHINE.Text;
                m_objContent.m_strSTATISTICNAME = m_txtSTATISTIC.Text;

                m_objContent.m_strPAYTYPE = m_cboPayType.Text;
                m_objContent.m_strOTHERMAINCONDITION = m_txtMainDiagnosisOther.Text;
                m_objContent.m_strOTHERCOMPLICATION = m_txtCOMPLICATIONOther.Text;
                m_objContent.m_strOTHERINFECTIONCONDICTION = m_txtINFECTIONDIAGNOSISOther.Text;
                m_objContent.m_strOTHERPATHOLOGYDIAGNOSIS = m_txtPATHOLOGYDIAGNOSISOther.Text;
                m_objContent.m_dtmCATALOG_DATE = DateTime.MinValue;
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objContent;
        }
        #endregion

        #region 获得入院诊断的内容
        /// <summary>
        /// 获得界面手术情况的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_GXInDiagnosis[] m_objGetInDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {

            if (this.ActiveControl.Parent == dtgInHospitalDiagnosis)
            {
                dtgInHospitalDiagnosis.CurrentCell = new DataGridCell(dtgInHospitalDiagnosis.CurrentCell.RowNumber + 1, 0);
            }

            int m_intRows = m_dtbInHospitalDiagnosis.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsInHospitalMainRecord_GXInDiagnosis[] m_objInDiaArr = new clsInHospitalMainRecord_GXInDiagnosis[m_intRows];
            try
            {
                for (int i1 = 0 ; i1 < m_intRows ; i1++)
                {
                    m_objInDiaArr[i1] = new clsInHospitalMainRecord_GXInDiagnosis();
                    m_objInDiaArr[i1].m_strInPatientID = p_strInPatientID;
                    m_objInDiaArr[i1].m_dtmInPatientDate = Convert.ToDateTime(p_strInPatientDate);
                    if (m_bolIfHasSave)
                    {
                        m_objInDiaArr[i1].m_dtmOpenDate = m_objCollection.m_objMain.m_dtmOpenDate;
                        m_objInDiaArr[i1].m_lngEMR_SEQ = m_objCollection.m_objMain.m_lngEMR_SEQ;
                    }
                    else
                        m_objInDiaArr[i1].m_dtmOpenDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objInDiaArr[i1].m_dtmModifyDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objInDiaArr[i1].m_strModifyUserID = MDIParent.OperatorID;
                    m_objInDiaArr[i1].m_strSEQID = i1.ToString();
                    m_objInDiaArr[i1].m_strDIAGNOSISDESC = m_dtbInHospitalDiagnosis.Rows[i1][0].ToString();

                    m_objInDiaArr[i1].m_strSTATCODE = m_dtbInHospitalDiagnosis.Rows[i1][1].ToString();
                    m_objInDiaArr[i1].m_strICD10 = m_dtbInHospitalDiagnosis.Rows[i1][2].ToString();
                    if (m_strRegisterID != null)
                        m_objInDiaArr[i1].m_strREGISTERID_CHR = m_strRegisterID;
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objInDiaArr;
        }
        #endregion

        #region 获得出院其它诊断的内容
        /// <summary>
        /// 获得出院其它诊断的内容
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strCurrentDateTime"></param>
        /// <returns></returns>
        private clsInHospitalMainRecord_GXOtherDiagnose[] m_objGetOtherDiagnosisArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            //if (dtgOtherDiagnosis != null)
            //{
            //    //dataGridTableStyle1.EndEdit(dataGridTableStyle1.GridColumnStyles[dtgOtherDiagnosis.CurrentCell.ColumnNumber], dtgOtherDiagnosis.CurrentCell.RowNumber, true);
            //    dtgOtherDiagnosis.BindingContext[dtgOtherDiagnosis.DataSource, dtgOtherDiagnosis.DataMember].EndCurrentEdit();
            //}
            dtgOtherDiagnosis.BindingContext[dtgOtherDiagnosis.DataSource, dtgOtherDiagnosis.DataMember].EndCurrentEdit();
            if (this.ActiveControl == dtgOtherDiagnosis)
            {
                dtgOtherDiagnosis.CurrentCell = new DataGridCell(dtgOtherDiagnosis.CurrentCell.RowNumber + 1, 0);
               
            }

            int m_intRows = m_dtbOtherDiagnosis.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsInHospitalMainRecord_GXOtherDiagnose[] m_objOtherDiagnosisArr = new clsInHospitalMainRecord_GXOtherDiagnose[m_intRows];
            try
            {
                for (int i1 = 0 ; i1 < m_intRows ; i1++)
                {
                    m_objOtherDiagnosisArr[i1] = new clsInHospitalMainRecord_GXOtherDiagnose();
                    m_objOtherDiagnosisArr[i1].m_strInPatientID = p_strInPatientID;
                    m_objOtherDiagnosisArr[i1].m_dtmInPatientDate = Convert.ToDateTime(p_strInPatientDate);
                    if (m_bolIfHasSave)
                    {
                        m_objOtherDiagnosisArr[i1].m_dtmOpenDate = m_objCollection.m_objMain.m_dtmOpenDate;
                        m_objOtherDiagnosisArr[i1].m_lngEMR_SEQ = m_objCollection.m_objMain.m_lngEMR_SEQ;
                    }
                    else
                        m_objOtherDiagnosisArr[i1].m_dtmOpenDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objOtherDiagnosisArr[i1].m_dtmModifyDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objOtherDiagnosisArr[i1].m_strModifyUserID = MDIParent.OperatorID;
                    m_objOtherDiagnosisArr[i1].m_strSEQID = i1.ToString();
                    m_objOtherDiagnosisArr[i1].m_strDIAGNOSISDESC = m_dtbOtherDiagnosis.Rows[i1][0].ToString();

                    if (m_dtbOtherDiagnosis.Rows[i1][1].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 0;
                    else if (m_dtbOtherDiagnosis.Rows[i1][2].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 1;
                    else if (m_dtbOtherDiagnosis.Rows[i1][3].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 2;
                    else if (m_dtbOtherDiagnosis.Rows[i1][4].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 3;
                    else if (m_dtbOtherDiagnosis.Rows[i1][5].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 4;
                    else if (m_dtbOtherDiagnosis.Rows[i1][6].ToString() == "True")
                        m_objOtherDiagnosisArr[i1].m_intCONDITIONSEQ = 5;
                    m_objOtherDiagnosisArr[i1].m_strOTHERCONDITION = "";
                    m_objOtherDiagnosisArr[i1].m_strSTATCODE = m_dtbOtherDiagnosis.Rows[i1][7].ToString();
                    m_objOtherDiagnosisArr[i1].m_strICD10 = m_dtbOtherDiagnosis.Rows[i1][8].ToString();
                    if (m_strRegisterID != null)
                        m_objOtherDiagnosisArr[i1].m_strREGISTERID_CHR = m_strRegisterID;
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objOtherDiagnosisArr;
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
        private clsInHospitalMainRecord_GXOperation[] m_objGetOperationArr(string p_strInPatientID, string p_strInPatientDate, string p_strCurrentDateTime)
        {
            if (this.ActiveControl.Parent == dtgOperation)
            {
                dtgOperation.CurrentCell = new DataGridCell(dtgOperation.CurrentCell.RowNumber + 1, 1);
            }

            int m_intRows = m_dtbOperationDetail.Rows.Count;
            if (m_intRows <= 0)
                return null;
            clsInHospitalMainRecord_GXOperation[] m_objOperationArr = new clsInHospitalMainRecord_GXOperation[m_intRows];
            try
            {
                DateTime dtmTemp = DateTime.MinValue;
                DateTime dtmInDate = Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd HH:mm"));

                DateTime dtmOutDate = DateTime.MinValue;
                if (m_ObjCurrentEmrPatientSession.m_dtmOutDate != DateTime.MinValue && m_ObjCurrentEmrPatientSession.m_dtmOutDate != new DateTime(1900,1,1))
                {
                    dtmOutDate = Convert.ToDateTime(m_ObjCurrentEmrPatientSession.m_dtmOutDate.ToString("yyyy-MM-dd HH:mm"));
                }
                
                for (int i1 = 0 ; i1 < m_intRows ; i1++)
                {
                    m_objOperationArr[i1] = new clsInHospitalMainRecord_GXOperation();
                    m_objOperationArr[i1].m_strInPatientID = p_strInPatientID;
                    m_objOperationArr[i1].m_dtmInPatientDate = Convert.ToDateTime(p_strInPatientDate);
                    if (m_bolIfHasSave)
                    {
                        m_objOperationArr[i1].m_dtmOpenDate = m_objCollection.m_objMain.m_dtmOpenDate;
                        m_objOperationArr[i1].m_lngEMR_SEQ = m_objCollection.m_objMain.m_lngEMR_SEQ;
                    }
                    else
                        m_objOperationArr[i1].m_dtmOpenDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objOperationArr[i1].m_dtmModifyDate = Convert.ToDateTime(p_strCurrentDateTime);
                    m_objOperationArr[i1].m_strModifyUserID = MDIParent.OperatorID;
                    m_objOperationArr[i1].m_strSEQID = i1.ToString();
                    m_objOperationArr[i1].m_strOPERATIONID = m_dtbOperationDetail.Rows[i1][8].ToString();

                    if (DateTime.TryParse(m_dtbOperationDetail.Rows[i1][0].ToString(),out dtmTemp))
                    {
                        if (dtmInDate > dtmTemp)
                        {
                            clsPublicFunction.ShowInformationMessageBox("手术日期不能小于入院日期"); 
                            tabControl1.SelectedIndex = 2;
                            return null;
                        }

                        if (dtmOutDate != DateTime.MinValue && dtmOutDate < dtmTemp)
                        {
                            clsPublicFunction.ShowInformationMessageBox("手术日期不能大于出院日期");
                            tabControl1.SelectedIndex = 2;
                            return null;
                        }
                        m_objOperationArr[i1].m_dtmOPERATIONDATE = dtmTemp;
                    }
                    else
                    {
                        m_objOperationArr[i1].m_dtmOPERATIONDATE = new DateTime(1900, 1, 1);
                    }
                    m_objOperationArr[i1].m_strOPERATIONNAME = m_dtbOperationDetail.Rows[i1][1].ToString();
                    m_objOperationArr[i1].m_strOPERATOR = m_dtbOperationDetail.Rows[i1][10].ToString();
                    m_objOperationArr[i1].m_strASSISTANT1 = m_dtbOperationDetail.Rows[i1][11].ToString();
                    m_objOperationArr[i1].m_strASSISTANT2 = m_dtbOperationDetail.Rows[i1][12].ToString();
                    m_objOperationArr[i1].m_strOPERATIONAANAESTHESIAMODENAME = m_dtbOperationDetail.Rows[i1][5].ToString();
                    m_objOperationArr[i1].m_strAANAESTHESIAMODEID = m_dtbOperationDetail.Rows[i1][9].ToString();
                    m_objOperationArr[i1].m_strCUTLEVEL = m_dtbOperationDetail.Rows[i1][6].ToString();
                    m_objOperationArr[i1].m_strANAESTHETISTNAME = m_dtbOperationDetail.Rows[i1][7].ToString();
                    m_objOperationArr[i1].m_strANAESTHETIST = m_dtbOperationDetail.Rows[i1][13].ToString();
                    if (m_strRegisterID != null)
                        m_objOperationArr[i1].m_strREGISTERID_CHR = m_strRegisterID;
                }
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
            }
            return m_objOperationArr;
        }
        #endregion

        #region 显示该病人该次住院的科室，转科出院住院信息
        /// <summary>
        /// 显示该病人该次住院的科室，转科出院住院信息
        /// </summary>
        private void m_mthSetPatientCurrentInHospitalDeptInfo()
        {
            if (m_objSelectedPatient == null || m_ObjCurrentEmrPatientSession == null)
                return;
            //int m_intSessionIndex = trvTime.Nodes[0].Nodes.Count - (trvTime.SelectedNode.Index);
            lblInHospitalTimes.Text = m_ObjCurrentEmrPatientSession.m_strInTimes;//第几次住院

            //clsInBedSessionInfo m_objSession = m_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_intSessionIndex - 1);

            #region 获取入院、出院科室，转科情况
            DateTime dtmOutDate = new DateTime(1900, 1, 1);
            long lngRes = m_objDomain.m_lngGetInHospitalMainTransDeptInstance(m_ObjCurrentEmrPatientSession.m_strRegisterId, out m_objTransDeptInstance);
            m_strRegisterID = m_ObjCurrentEmrPatientSession.m_strRegisterId;
            //if (frmHRPExplorer.objpCurrentPatient != null && frmHRPExplorer.objpCurrentPatient.m_strPATIENTID_CHR.Trim() == m_objSelectedPatient.m_StrPatientID.Trim())
            //{
            //    lngRes = m_objDomain.m_lngGetInHospitalMainTransDeptInstance(frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR, out m_objTransDeptInstance);
            //    m_strRegisterID = frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //else
            //{
            //    lngRes = m_objDomain.m_lngGetInHospitalMainTransDeptInstance(m_objSelectedPatient.m_StrPatientID, m_objSelectedPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out m_strRegisterID, out m_objTransDeptInstance);
            //}
            if (lngRes > 0 && m_objTransDeptInstance != null)
            {
                if (m_objTransDeptInstance.m_demOutPatientDate != new DateTime(1900, 1, 1) && m_objTransDeptInstance.m_demOutPatientDate != DateTime.MinValue)
                    m_lblOutHospitalDate.Text = m_objTransDeptInstance.m_demOutPatientDate.ToString("yyyy年MM月dd日 HH时");
                else
                    m_lblOutHospitalDate.Text = "";
                lblInHosptialSetion.Text = m_objTransDeptInstance.m_strInPatientDeptName;
                lblOutHospitalSetion.Text = m_objTransDeptInstance.m_strOutPatientDeptName;
                if (m_objTransDeptInstance.m_strTransSourceDeptIDArr != null
                    && m_objTransDeptInstance.m_strTransTargetDeptIDArr != null
                    && m_objTransDeptInstance.m_strTransSourceDeptIDArr.Length == m_objTransDeptInstance.m_strTransTargetDeptIDArr.Length)
                {
                    m_lsvTransDept.Items.Clear();
                    for (int i = 0 ; i < m_objTransDeptInstance.m_strTransSourceDeptIDArr.Length ; i++)
                    {
                        DateTime dtTransDate = Convert.ToDateTime(m_objTransDeptInstance.m_strTransDeptDateArr[i]);
                        ListViewItem item = new ListViewItem(new string[]{m_objTransDeptInstance.m_strTransSourceDeptNameArr[i],
																			 dtTransDate.ToString("yyyy-MM-dd"),
																			 m_objTransDeptInstance.m_strTransTargetDeptNameArr[i]});
                        m_lsvTransDept.Items.Add(item);
                    }
                }
            }
            else
            {
                m_lblOutHospitalDate.Text = "";
                lblInHosptialSetion.Text = "";
                lblOutHospitalSetion.Text = "";
                m_lsvTransDept.Items.Clear();
            }
            #endregion

            m_lblInHospitalDate.Text = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy年MM月dd日 HH时");

            System.TimeSpan diff = new TimeSpan(0);
            if (m_lblOutHospitalDate.Text == "")
            {
                diff = DateTime.Now.Subtract(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate);
            }
            else
            {
                diff = Convert.ToDateTime(m_lblOutHospitalDate.Text).Subtract(m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate);
            }
            lblInHospitalDays.Text = ((int)diff.TotalDays + 1).ToString();
        }
        #endregion

        #region 读取手术同步表的数据
        /// <summary>
        /// 读取手术同步表的数据
        /// </summary>
        private void m_mthLoadOperationInfo()
        {
            if (m_objSelectedPatient != null)
            {
                DataTable dtResult = new DataTable();
                long lngRes = m_objDomain.m_lngGetOpInfo(m_objSelectedPatient.m_StrInPatientID, m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out dtResult);

                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    for (int i = 0 ; i < dtResult.Rows.Count ; i++)
                    {
                        object[] objValue = new object[14];
                        objValue[0] = dtResult.Rows[i]["OPERATIONDATE"];
                        objValue[1] = dtResult.Rows[i]["OPERATIONNAME"];
                        objValue[2] = dtResult.Rows[i]["OPERATORNAME"];
                        objValue[3] = dtResult.Rows[i]["ASSISTANT1NAME"];
                        objValue[4] = dtResult.Rows[i]["ASSISTANT2NAME"];
                        objValue[5] = dtResult.Rows[i]["AANAESTHESIAMODEID"];
                        objValue[6] = "/";
                        objValue[7] = dtResult.Rows[i]["ANAESTHETISTNAME"];
                        objValue[8] = "";//操作编码
                        objValue[9] = "";//麻醉方式的ID
                        objValue[10] = dtResult.Rows[i]["OPERATOR"];
                        objValue[11] = dtResult.Rows[i]["ASSISTANT1"];
                        objValue[12] = dtResult.Rows[i]["ASSISTANT2"];
                        objValue[13] = dtResult.Rows[i]["ANAESTHETIST"]; ;//麻醉医师的ID

                        m_dtbOperationDetail.Rows.Add(objValue);
                    }
                }
            }
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
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        string strSubTypeName = subcontrol.GetType().Name;
                        if (strSubTypeName != "Lable" && strSubTypeName != "Button")
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
            }
        }

        #endregion

        #region 获取当前病人的作废内容
        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            m_strOpenDate = p_dtmRecordDate.ToString();
            m_mthSetPatientCurrentInHospitalDeptInfo();
            m_mthDiaplayDeletedDetail();
        }
        #endregion

        #region 审核
        private string m_strCurrentOpenDate = "";

        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (m_ObjCurrentEmrPatientSession == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                    return "";
                }
                return m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString();
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

        #region Jump Control
        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this, Keys.Enter);
        }
        #endregion

        #region 添加固定项目至combobox
        private void m_mthSetComboBoxItem()
        {
            string[] strCheckArr = { "未做", "阴性", "阳性" };//HBsAg,HCV-Ab,HIV-Ab检查
            string[] strAccordArr = { "无", "符合", "不符", "待查" };//诊断符合情况

            for (int i = 0 ; i < strCheckArr.Length ; i++)
            {
                m_cboHBsAg.AddItem(strCheckArr[i]);
                m_cboHCV_Ab.AddItem(strCheckArr[i]);
                m_cboHIV_Ab.AddItem(strCheckArr[i]);
            }
            m_cboHIV_Ab.AddItem("初筛阳性");

            for (int j = 0 ; j < strAccordArr.Length ; j++)
            {
                if (j>0)
                {
                    m_cboClinicOUt.AddItem(strAccordArr[j]);
                    m_cboInOut.AddItem(strAccordArr[j]);
                }
                
                m_cboBeforeOpAfterOp.AddItem(strAccordArr[j]);
                m_cboClinicPh.AddItem(strAccordArr[j]);
                m_cboDeathCheck.AddItem(strAccordArr[j]);
                m_cboClinicRad.AddItem(strAccordArr[j]);
            }
        }
        #endregion

        #region 判断是否新添记录
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
        #endregion

        #region 保存前检查
        private bool m_bolSaveCheck()
        {
            if (m_objSelectedPatient == null)
            {
                m_mthShowNoPatient();
                return false;
            }
            if (m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请选择入院时间！");
                return false;
            }

            if (!m_chkInstanceWhenIn1.Checked && !m_chkInstanceWhenIn2.Checked && !m_chkInstanceWhenIn3.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未填写入院时情况，不能保存！");
                tabControl1.SelectedIndex = 0;
                return false;
            }

            if (m_txtOutHospitalDoc.Text.Trim() == "" || m_txtOutHospitalDoc.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("出院医师未签名，不能保存！");
                return false;
            }

            if (m_cboPayType.Text.Trim() == "")
            {
                clsPublicFunction.ShowInformationMessageBox("付款方式为空，不能保存！");
                return false;
            }
            if (txtDiagnosis.Text.Trim() == "")
            {
                clsPublicFunction.ShowInformationMessageBox("门诊（急）诊断为空，不能保存！");
                return false;
            }
            if (m_dtbInHospitalDiagnosis == null || m_dtbInHospitalDiagnosis.Rows.Count <= 0)
            {
                clsPublicFunction.ShowInformationMessageBox("入院诊断为空，不能保存！");
                return false;
            }
            if (m_txtMainDiagnosis.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("出院主要诊断为空，不能保存！");
                return false;
            }
            if (!m_chkNEW5DISEASE1.Checked && !m_chkNEW5DISEASE2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入是否新五病，不能保存！");
                return false;
            }
            if (!m_chkSECONDLEVELTRANSFER1.Checked && !m_chkSECONDLEVELTRANSFER2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入有无二级转诊，不能保存！");
                return false;
            }
            if (m_cboHBsAg.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入HBsAg情况，不能保存！");
                return false;
            }
            if (m_cboHCV_Ab.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入HCV-Ab情况，不能保存！");
                return false;
            }
            if (m_cboHIV_Ab.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入HIV-Ab情况，不能保存！");
                return false;
            }
            if (m_txtSALVETIMES.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入抢救次数，不能保存！");
                return false;
            }
            if (m_txtSALVESUCCESS.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入抢救成功次数，不能保存！");
                return false;
            }
            if (!m_chkHASREMIND1.Checked && !m_chkHASREMIND2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入随诊情况，不能保存！");
                return false;
            }
            if (m_cboClinicOUt.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入门诊-出院诊断符合情况，不能保存！");
                return false;
            }
            if (m_cboInOut.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入入院-出院诊断符合情况，不能保存！");
                return false;
            }
            if (m_cboBeforeOpAfterOp.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入术前-术后诊断符合情况，不能保存！");
                return false;
            }
            if (m_cboClinicPh.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入临床-病理诊断符合情况，不能保存！");
                return false;
            }
            if (m_cboDeathCheck.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入死亡-尸检诊断符合情况，不能保存！");
                return false;
            }
            if (m_cboClinicRad.SelectedIndex < 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入临床-放射诊断符合情况，不能保存！");
                return false;
            }
            if (!m_chkMODELCASE1.Checked && !m_chkMODELCASE2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入是否示教病例，不能保存！");
                return false;
            }
            if (!m_chkFIRSTCASE1.Checked && !m_chkFIRSTCASE2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入手术、治疗、检查、诊断是否为本院第一例，不能保存！");
                return false;
            }
            if (!m_chkQUALITY1.Checked && !m_chkQUALITY2.Checked && !m_chkQUALITY3.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入手术、治疗、检查、诊断是否为本院第一例，不能保存！");
                return false;
            }
            if (!m_chkANTIBACTERIAL1.Checked && !m_chkANTIBACTERIAL2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入抗菌药物使用情况，不能保存！");
                return false;
            }
            if (!m_chkPATHOGENY1.Checked && !m_chkPATHOGENY2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入是否病原学送检，不能保存！");
                return false;
            }
            if (m_chkPATHOGENY1.Checked && !m_chkPATHOGENYRESULT1.Checked && !m_chkPATHOGENYRESULT2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入病原学送检结果，不能保存！");
                return false;
            }
            if (!m_chkQUALITY1.Checked && !m_chkQUALITY2.Checked && !m_chkQUALITY3.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入病案质量，不能保存！");
                return false;
            }
            if (!m_chkBLOODTRANSACTOIN1.Checked && !m_chkBLOODTRANSACTOIN2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血反应情况，不能保存！");
                return false;
            }
            if (!m_chkTRANSFUSIONSACTION1.Checked && !m_chkTRANSFUSIONSACTION2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输液反应情况，不能保存！");
                return false;
            }
            if (!m_chkCTCHECK1.Checked && !m_chkCTCHECK2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入CT检查情况，不能保存！");
                return false;
            }
            if (!m_chkMRICHECK1.Checked && !m_chkMRICHECK2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入MRI检查情况，不能保存！");
                return false;
            }
            if (!m_chkBLOODTYPE0.Checked && !m_chkBLOODTYPE1.Checked && !m_chkBLOODTYPE2.Checked && !m_chkBLOODTYPE3.Checked && !m_chkBLOODTYPE4.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入血型，不能保存！");
                return false;
            }
            if (!m_chkBLOODRH0.Checked && !m_chkBLOODRH1.Checked && !m_chkBLOODRH2.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入Rh情况，不能保存！");
                return false;
            }
            if (!m_chkXRayCheck1.Checked && !m_chkXRayCheck2.Checked && !m_chkXRayCheck3.Checked)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入大型X光机检查情况，不能保存！");
                return false;
            }
            if (m_txtRBC.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血品种--红细胞，不能保存！");
                return false;
            }
            if (m_txtPLT.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血品种--血小板，不能保存！");
                return false;
            }
            if (m_txtPLASM.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血品种--血浆，不能保存！");
                return false;
            }
            if (m_txtWHOLEBLOOD.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血品种--全血，不能保存！");
                return false;
            }
            if (m_txtOTHERBLOOD.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("未输入输血品种--其它，不能保存！");
                return false;
            }
            return true;
        }
        #endregion

        #region 双击手术信息表中的员工和麻醉方式ListView事件
        private void lsvOperationEmployee_DoubleClick(object sender, System.EventArgs e)
        {
            if (lsvOperationEmployee.SelectedItems.Count <= 0)
                return;

            string m_strEmplayeeName = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
            string m_strEmplayeeID = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;

            int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
            int m_intCurrentRowNumber = this.dtgOperation.CurrentRowIndex;
            DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
            object[] m_objRes = m_dtrOperation.ItemArray;
            if (m_intCurrentColumnNumber == 2)
            {
                m_objRes[2] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[10] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 3)
            {
                m_objRes[3] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[11] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 4)
            {
                m_objRes[4] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[12] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            if (m_intCurrentColumnNumber == 7)
            {
                m_objRes[7] = lsvOperationEmployee.SelectedItems[0].SubItems[1].Text;
                m_objRes[13] = lsvOperationEmployee.SelectedItems[0].SubItems[0].Text;
            }
            this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            lsvOperationEmployee.Visible = false;
        }

        private void lsvAanaesthesiaMode_DoubleClick(object sender, System.EventArgs e)
        {
            if (lsvAanaesthesiaMode.Items.Count <= 0)
                return;
            if (lsvAanaesthesiaMode.SelectedItems.Count <= 0)
                return;
            int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
            int m_intCurrentRowNumber = this.dtgOperation.CurrentCell.RowNumber;
            if (m_intCurrentRowNumber >= m_dtbOperationDetail.Rows.Count)
            {
                object[] m_objResArr = new object[14];
                m_objResArr[5] = " ";
                m_dtbOperationDetail.Rows.Add(m_objResArr);
            }
            DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
            object[] m_objRes = m_dtrOperation.ItemArray;
            m_objRes[5] = lsvAanaesthesiaMode.SelectedItems[0].SubItems[1].Text;
            m_objRes[9] = lsvAanaesthesiaMode.SelectedItems[0].SubItems[0].Text;
            m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            lsvAanaesthesiaMode.Visible = false;
        }
        #endregion

        #region 确保输入数字
        private void m_txtCheckIntType_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.Trim() == "")
                    return;
                int intTimes = int.Parse(((TextBox)sender).Text);
            }
            catch
            {
                MDIParent.ShowInformationMessageBox(((TextBox)sender).AccessibleDescription + "须填写整数！");
                ((TextBox)sender).Text = "";
            }
        }

        private void m_txtCheckDouble_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.Trim() == "")
                    return;
                double dblAmt = double.Parse(((TextBox)sender).Text);
            }
            catch
            {
                MDIParent.ShowInformationMessageBox(((TextBox)sender).AccessibleDescription + "须填写数字！");
                ((TextBox)sender).Text = "";
            }
        }

        private void m_txtCheckIntType_MouseLeave(object sender, System.EventArgs e)
        {
            m_txtCheckIntType_Leave(sender, null);
        }

        private void m_txtCheckDouble_MouseLeave(object sender, System.EventArgs e)
        {
            m_txtCheckDouble_Leave(sender, null);
        }
        #endregion

        #region 将同步表中的收费信息显示到界面
        /// <summary>
        /// 将同步表中的收费信息显示到界面
        /// </summary>
        private void m_mthSetChargeInfo(clsInHospitalMainRecord_GXContent objContent)
        {
            if (objContent == null)
                return;

            txtTotalAmt.Text = objContent.m_dblTOTALAMT.ToString();
            txtBedAmt.Text = objContent.m_dblBEDAMT.ToString();
            txtNurseAmt.Text = objContent.m_dblNURSEAMT.ToString();
            txtWMAmt.Text = objContent.m_dblWMAMT.ToString();
            txtCMFinishedAmt.Text = objContent.m_dblCMFINISHEDAMT.ToString();
            txtCMSemiFinishedAmt.Text = objContent.m_dblCMSEMIFINISHEDAMT.ToString();
            txtRadiationAmt.Text = objContent.m_dblRADIATIONAMT.ToString();
            txtAssayAmt.Text = objContent.m_dblASSAYAMT.ToString();
            txtO2Amt.Text = objContent.m_dblO2AMT.ToString();
            txtBloodAmt.Text = objContent.m_dblBLOODAMT.ToString();
            txtTreatmentAmt.Text = objContent.m_dblTREATMENTAMT.ToString();
            txtOperationAmt.Text = objContent.m_dblOPERATIONAMT.ToString();
            txtCheckAmt.Text = objContent.m_dblCHECKAMT.ToString();
            txtAnaethesiaAmt.Text = objContent.m_dblANAETHESIAAMT.ToString();
            txtDeliveryChildAmt.Text = objContent.m_dblDELIVERYCHILDAMT.ToString();
            txtBabyAmt.Text = objContent.m_dblBABYAMT.ToString();
            txtAccompanyAmt.Text = objContent.m_dblACCOMPANYAMT.ToString();
            txtOtherAmt.Text = objContent.m_dblOTHERAMT.ToString();
        }
        #endregion

        #region 使combobox不可编辑
        private void m_cbo_evtGotFocus(object sender, System.EventArgs e)
        {
            ctlComboBox cbo = sender as ctlComboBox;
            foreach (Control ctl in cbo.Controls)
            {
                if (ctl.GetType().Name.Trim() == "ctlRichTextBox")
                {
                    ((iCare.CustomForm.ctlRichTextBox)ctl).ReadOnly = true;
                }
                else if (ctl.GetType().Name.Trim() == "ctlBorderTextBox")
                {
                    ((com.digitalwave.Utility.Controls.ctlBorderTextBox)ctl).ReadOnly = true;
                }
            }
        }
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

        clsInHospitalMainRecord_GXPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            objPrintTool = new clsInHospitalMainRecord_GXPrintTool(!m_blnDirectPrint, false);
            objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint();
        }

        private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();

        private void m_mthStartPrint()
        {
            if (m_blnDirectPrint)
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

        #region 提交表单
        private void m_cmdSubmit_Click(object sender, System.EventArgs e)
        {
            this.m_intSubmit = 1;
            if (clsPublicFunction.ShowQuestionMessageBox("提交后将不能再对此记录进行修改\n是否继续？", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            long lngRes = m_lngSave();
            if (lngRes > 0)
            {
                this.m_cmdSubmit.Enabled = false;
                this.m_cmdSubmit.Text = "已提交";
            }
        }
        #endregion

        #region 手术麻醉lsvAanaesthesiaMode相关事件
        private void lsvAanaesthesiaMode_LostFocus(object sender, System.EventArgs e)
        {
            lsvAanaesthesiaMode.Visible = false;
        }

        private void lsvAanaesthesiaMode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            lsvAanaesthesiaMode_DoubleClick(sender, null);
        }
        #endregion

        #region 手术名称查询
        private void OperationDesc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    m_mthQueryOpDesc(8);
                    break;
                case Keys.F9:
                    m_mthQueryOpDesc(9);
                    break;
                case Keys.F10:
                    m_mthQueryOpDesc(10);
                    break;
            }
        }

        private int m_intKeys = 9;
        private frmQueryListview frmOpQuery = null;
        private void m_mthQueryOpDesc(int p_intKey)
        {
            m_intKeys = p_intKey;
            frmOpQuery = new frmQueryListview();
            m_mthSetOpListviewColumns();
            frmOpQuery.m_txtInput.TextChanged += new EventHandler(txtOpInput_TextChanged);
            frmOpQuery.m_lsvDetail.DoubleClick += new EventHandler(m_lsvOpDesc_DoubleClick);
            frmOpQuery.m_lsvDetail.KeyDown += new KeyEventHandler(m_lsvOpDesc_KeyDown);
            frmOpQuery.m_txtInput.KeyDown += new KeyEventHandler(m_txtOpInput_KeyDown);
            frmOpQuery.m_cmdLast.Click += new EventHandler(m_cmdOpLast_Click);
            frmOpQuery.m_cmdNext.Click += new EventHandler(m_cmdOpNext_Click);

            int x = dtgOperation.Location.X;
            int y = dtgOperation.Location.Y + dtgOperation.Height + tabControl1.Location.Y;

            Point p = new Point(x, y);
            frmOpQuery.Location = p;
            frmOpQuery.StartPosition = FormStartPosition.Manual;
            frmOpQuery.Show();

            if (m_dtvOp != null)
                m_dtvOp.RowFilter = "";

            frmOpQuery.m_cmdLast.Enabled = false;
            frmOpQuery.m_cmdNext.Enabled = true;
            m_mthUpdateOpListView(0);
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

            m_mthUpdateOpListView(intIndex);
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

            m_mthUpdateOpListView(intIndex);
        }

        private void m_mthUpdateOpListView(int intIndex)
        {
            try
            {
                frmOpQuery.m_lsvDetail.Items.Clear();
                if (m_dtvOp == null || m_dtvOp.Count == 0)
                    return;
                int intEnd = intIndex + 9;
                if (intIndex == 0)
                {
                    frmOpQuery.m_cmdLast.Enabled = false;
                    frmOpQuery.m_cmdNext.Enabled = true;
                }
                if (intIndex + 9 > m_dtvOp.Count)
                {
                    intEnd = m_dtvOp.Count;
                    frmOpQuery.m_cmdNext.Enabled = false;
                }
                frmOpQuery.m_lsvDetail.BeginUpdate();
                ListViewItem[] livItems = new ListViewItem[intEnd - intIndex];
                for (int i = 0 ; i < intEnd - intIndex ; i++)
                {
                    livItems[i] = new ListViewItem(new string[] { m_dtvOp[intIndex + i][0].ToString(),
                    m_dtvOp[intIndex + i][1].ToString(),
                    m_dtvOp[intIndex + i][2].ToString()});
                }
                frmOpQuery.m_lsvDetail.Items.AddRange(livItems);
                frmOpQuery.m_intCurrentIndex = intIndex;
            }
            finally
            {
                frmOpQuery.m_lsvDetail.EndUpdate();
            }
        }

        /// <summary>
        /// 设置frmQueryListview中Listview的列
        /// </summary>
        /// <param name="p_lsvICD"></param>
        private void m_mthSetOpListviewColumns()
        {
            System.Windows.Forms.ColumnHeader columnHeader1 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader2 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader3 = new ColumnHeader();
            frmOpQuery.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  columnHeader1,
																							  columnHeader2,
																							  columnHeader3});
            columnHeader1.Text = "编码";
            columnHeader1.Width = 70;

            columnHeader2.Text = "手术名称";
            columnHeader2.Width = 330;

            columnHeader3.Text = "拼音码";
            columnHeader3.Width = 80;
        }

        private void OperationDesc_LostFocus(object sender, EventArgs e)
        {
            m_lblTips.Text = "";
        }

        private void OperationDesc_GotFocus(object sender, EventArgs e)
        {
            m_lblTips.Text = "按F9调出辅助代码录入，按F8调出拼音辅助代码录入，按F10调出诊断名称辅助录入";
        }

        /// <summary>
        /// 输入框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOpInput_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string strFilter = ((TextBox)sender).Text.Trim();
                strFilter = strFilter.ToUpper();
                switch (m_intKeys)
                {
                    case 8:
                        m_dtvOp.RowFilter = " INPUT_CODE like '" + strFilter + "%'";
                        break;
                    case 9:
                        m_dtvOp.RowFilter = " OPERATION_CODE like '" + strFilter + "%'";
                        break;
                    case 10:
                        m_dtvOp.RowFilter = " OPERATION_NAME like '" + strFilter + "%'";
                        break;
                }
                m_mthUpdateOpListView(0);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
        }

        private void m_txtOpInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (frmOpQuery.m_lsvDetail.Items.Count > 0)
                {
                    frmOpQuery.m_lsvDetail.Focus();
                    frmOpQuery.m_lsvDetail.Items[0].Selected = true;
                }
            }
        }

        private void m_lsvOpDesc_DoubleClick(object sender, System.EventArgs e)
        {
            m_mthSetOpContentToMainForm(sender);
        }

        private void m_lsvOpDesc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
                if (lsvCon.Items.Count <= 0)
                    return;
                if (lsvCon.SelectedItems.Count <= 0)
                    return;
                int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
                int m_intCurrentRowNumber = this.dtgOperation.CurrentCell.RowNumber;
                if (m_intCurrentRowNumber >= m_dtbOperationDetail.Rows.Count)
                {
                    object[] m_objResArr = new object[14];
                    m_objResArr[1] = " ";
                    m_dtbOperationDetail.Rows.Add(m_objResArr);
                }
                DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
                object[] m_objRes = m_dtrOperation.ItemArray;
                m_objRes[1] = lsvCon.SelectedItems[0].SubItems[1].Text;
                m_objRes[8] = lsvCon.SelectedItems[0].SubItems[0].Text;
                m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;

                frmOpQuery.Close();
            }
            catch
            {
                frmOpQuery.Close();
            }
        }
        #endregion

        #region 手术、麻醉医师查询
        private void Emp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    m_mthQueryEmpDesc(8);
                    break;
                case Keys.F9:
                    m_mthQueryEmpDesc(9);
                    break;
                case Keys.F10:
                    m_mthQueryEmpDesc(10);
                    break;
            }
        }

        private frmQueryListview frmQueryEmp = null;
        private DataTable m_dtbCurrentDeptEmp = null;
        private void m_mthQueryEmpDesc(int p_intKey)
        {
            m_intKeys = p_intKey;
            frmQueryEmp = new frmQueryListview();
            frmQueryEmp.m_lklCustom.Visible = true;
            frmQueryEmp.m_lklCustom.Text = "全院";

            m_mthSetEmpListviewColumns();
            frmQueryEmp.m_txtInput.TextChanged += new EventHandler(txtEmpInput_TextChanged);
            frmQueryEmp.m_lsvDetail.DoubleClick += new EventHandler(m_lsvEmpDesc_DoubleClick);
            frmQueryEmp.m_lsvDetail.KeyDown += new KeyEventHandler(m_lsvEmpDesc_KeyDown);
            frmQueryEmp.m_txtInput.KeyDown += new KeyEventHandler(m_txtEmpInput_KeyDown);
            frmQueryEmp.m_cmdLast.Click += new EventHandler(m_cmdEmpLast_Click);
            frmQueryEmp.m_cmdNext.Click += new EventHandler(m_cmdEmpNext_Click);
            frmQueryEmp.m_lklCustom.LinkClicked += new LinkLabelLinkClickedEventHandler(m_lklCustom_LinkClicked);

            int x = dtgOperation.Location.X;
            int y = dtgOperation.Location.Y + dtgOperation.Height + tabControl1.Location.Y;

            Point p = new Point(x, y);
            frmQueryEmp.Location = p;
            frmQueryEmp.StartPosition = FormStartPosition.Manual;
            frmQueryEmp.Show();

            if (m_dtvEmp != null)
                m_dtvEmp.RowFilter = "";

            frmQueryEmp.m_cmdLast.Enabled = false;
            frmQueryEmp.m_cmdNext.Enabled = true;

            if (m_dtbCurrentDeptEmp == null)
            {
                m_objDomain.m_lngGetCurrentDeptEmp(clsEMRLogin.LoginInfo.m_strInpatientAreaID, out m_dtbCurrentDeptEmp);
            }
            
            m_dtvEmp = new DataView(m_dtbCurrentDeptEmp);
            m_mthUpdateEmpListView(0);
        }

        private void m_lklCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_dtvEmp = new DataView(m_dtbEmp);
            m_mthUpdateEmpListView(0);
        }

        private void m_cmdEmpNext_Click(object sender, EventArgs e)
        {
            if (m_dtvEmp == null || m_dtvEmp.Count == 0)
                return;
            int intIndex = 0;
            if (frmQueryEmp.m_intCurrentIndex + 9 > m_dtvEmp.Count - 1)
            {
                frmQueryEmp.m_cmdLast.Enabled = false;
                intIndex = 0;
            }
            else
            {
                frmQueryEmp.m_cmdLast.Enabled = true;
                intIndex = frmQueryEmp.m_intCurrentIndex + 9;
            }

            m_mthUpdateEmpListView(intIndex);
        }

        private void m_cmdEmpLast_Click(object sender, EventArgs e)
        {
            if (m_dtvEmp == null || m_dtvEmp.Count == 0)
                return;
            int intIndex = 0;
            if (frmQueryEmp.m_intCurrentIndex - 9 < 0)
            {
                intIndex = 0;
                frmQueryEmp.m_cmdNext.Enabled = true;
            }
            else
            {
                intIndex = frmQueryEmp.m_intCurrentIndex - 9;
                frmQueryEmp.m_cmdNext.Enabled = true;
            }

            m_mthUpdateEmpListView(intIndex);
        }

        private void m_mthUpdateEmpListView(int intIndex)
        {
            try
            {
                frmQueryEmp.m_lsvDetail.Items.Clear();
                if (m_dtvEmp == null || m_dtvEmp.Count == 0)
                    return;
                int intEnd = intIndex + 9;
                if (intIndex == 0)
                {
                    frmQueryEmp.m_cmdLast.Enabled = false;
                    frmQueryEmp.m_cmdNext.Enabled = true;
                }
                if (intIndex + 9 > m_dtvEmp.Count)
                {
                    intEnd = m_dtvEmp.Count;
                    frmQueryEmp.m_cmdNext.Enabled = false;
                }
                frmQueryEmp.m_lsvDetail.BeginUpdate();
                ListViewItem[] livItems = new ListViewItem[intEnd - intIndex];
                for (int i = 0 ; i < intEnd - intIndex ; i++)
                {
                    livItems[i] = new ListViewItem(new string[] { m_dtvEmp[intIndex + i]["PYCODE_CHR"].ToString(),
                    m_dtvEmp[intIndex + i]["LASTNAME_VCHR"].ToString(),
                    m_dtvEmp[intIndex + i]["EMPNO_CHR"].ToString(),
                    m_dtvEmp[intIndex + i]["EMPID_CHR"].ToString()});
                }
                frmQueryEmp.m_lsvDetail.Items.AddRange(livItems);
                frmQueryEmp.m_intCurrentIndex = intIndex;
            }
            finally
            {
                frmQueryEmp.m_lsvDetail.EndUpdate();
            }
        }

        /// <summary>
        /// 设置frmQueryListview中Listview的列
        /// </summary>
        /// <param name="p_lsvICD"></param>
        private void m_mthSetEmpListviewColumns()
        {
            System.Windows.Forms.ColumnHeader columnHeader1 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader2 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader3 = new ColumnHeader();
            System.Windows.Forms.ColumnHeader columnHeader4 = new ColumnHeader();
            frmQueryEmp.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 columnHeader1,
																								 columnHeader2,
																								 columnHeader3,
																								 columnHeader4});
            columnHeader1.Text = "拼音码";
            columnHeader1.Width = 100;

            columnHeader2.Text = "姓名";
            columnHeader2.Width = 200;

            columnHeader3.Text = "工号";
            columnHeader3.Width = 120;

            columnHeader4.Text = "ID";
            columnHeader4.Width = 0;
        }

        private void Emp_LostFocus(object sender, EventArgs e)
        {
            m_lblTips.Text = "";
        }

        private void Emp_GotFocus(object sender, EventArgs e)
        {
            m_lblTips.Text = "按F9调出辅助代码录入，按F8调出拼音辅助代码录入，按F10调出姓名辅助录入";
        }

        /// <summary>
        /// 输入框内容改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmpInput_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                string strFilter = ((TextBox)sender).Text.Trim();
                strFilter = strFilter.ToUpper();
                switch (m_intKeys)
                {
                    case 8:
                        m_dtvEmp.RowFilter = " PYCODE_CHR like '" + strFilter + "%'";
                        break;
                    case 9:
                        m_dtvEmp.RowFilter = " EMPNO_CHR like '" + strFilter + "%'";
                        break;
                    case 10:
                        m_dtvEmp.RowFilter = " LASTNAME_VCHR like '" + strFilter + "%'";
                        break;
                }
                m_mthUpdateEmpListView(0);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
        }

        private void m_txtEmpInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (frmQueryEmp.m_lsvDetail.Items.Count > 0)
                {
                    frmQueryEmp.m_lsvDetail.Focus();
                    frmQueryEmp.m_lsvDetail.Items[0].Selected = true;
                }
            }
        }

        private void m_lsvEmpDesc_DoubleClick(object sender, System.EventArgs e)
        {
            m_mthSetEmpContentToMainForm(sender);
        }

        private void m_lsvEmpDesc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthSetEmpContentToMainForm(sender);
            }
        }

        private void m_mthSetEmpContentToMainForm(object sender)
        {
            try
            {
                ListView lsvCon = (ListView)sender;
                if (lsvCon.Items.Count <= 0)
                    return;
                if (lsvCon.SelectedItems.Count <= 0)
                    return;
                int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
                int m_intCurrentRowNumber = this.dtgOperation.CurrentCell.RowNumber;
                if (m_intCurrentRowNumber >= m_dtbOperationDetail.Rows.Count)
                {
                    object[] m_objResArr = new object[14];
                    m_objResArr[m_intCurrentColumnNumber] = " ";
                    m_dtbOperationDetail.Rows.Add(m_objResArr);
                }
                DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
                object[] m_objRes = m_dtrOperation.ItemArray;
                if (m_intCurrentColumnNumber == 2)
                {
                    m_objRes[2] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    m_objRes[10] = lsvCon.SelectedItems[0].SubItems[3].Text;
                }
                if (m_intCurrentColumnNumber == 3)
                {
                    m_objRes[3] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    m_objRes[11] = lsvCon.SelectedItems[0].SubItems[3].Text;
                }
                if (m_intCurrentColumnNumber == 4)
                {
                    m_objRes[4] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    m_objRes[12] = lsvCon.SelectedItems[0].SubItems[3].Text;
                }
                if (m_intCurrentColumnNumber == 7)
                {
                    m_objRes[7] = lsvCon.SelectedItems[0].SubItems[1].Text;
                    m_objRes[13] = lsvCon.SelectedItems[0].SubItems[3].Text;
                }
                m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;

                frmQueryEmp.Close();
            }
            catch
            {
                frmQueryEmp.Close();
            }
        }
        #endregion

        #region 手术记录日期事件
        private void OperationDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Parse(((DataGridTextBox)sender).Text);
                int m_intCurrentColumnNumber = dtgOperation.CurrentCell.ColumnNumber;
                int m_intCurrentRowNumber = this.dtgOperation.CurrentCell.RowNumber;
                if (m_intCurrentRowNumber >= m_dtbOperationDetail.Rows.Count)
                {
                    object[] m_objResArr = new object[14];
                    m_objResArr[0] = ((DataGridTextBox)sender).Text;
                    m_dtbOperationDetail.Rows.Add(m_objResArr);
                }
                //DataRow m_dtrOperation = this.m_dtbOperationDetail.Rows[m_intCurrentRowNumber];
                //object[] m_objRes = m_dtrOperation.ItemArray;
                //m_objRes[0] = ((DataGridTextBox)sender).Text;
                //m_dtbOperationDetail.Rows[m_intCurrentRowNumber].ItemArray = m_objRes;
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region 设置签名框为只读
        private void m_mthSetSignReadOnly()
        {
            txtDeptDirectorDt.ReadOnly = true;
            txtDt.ReadOnly = true;
            txtInHospitalDt.ReadOnly = true;
            m_txtOutHospitalDoc.ReadOnly = true;
            txtDirectorDt.ReadOnly = true;
            txtSubDirectorDt.ReadOnly = true;
            //txtAttendInStudyDt.ReadOnly = true;
        }
        #endregion

        #region 选择一次入院时间
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            m_mthRecordChangedToSave();

            m_bolIfHasSave = false;
            m_strOpenDate = null;
            m_txtFocusedRichTextBox = null;
            m_RtbCurrentTextBox = null;
            m_mthCleanUpPatientInHospitalMainRecrodInfo();
            m_mthCleanUpPatientDetailInfo();
            m_objCollection = null;
            m_mthSetModifyControl(string.Empty, true);

            if (p_objSelectedSession == null)
            {
                m_mthSetControlReadOnly(this, true);
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
                m_mthAddFormStatusForClosingSave();
                return;

            }

            m_objSelectedPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objSelectedPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

            m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objSelectedPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
            m_objSelectedPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthOnlySetPatientInfo(m_objSelectedPatient);

            m_mthSetPatientCurrentInHospitalDeptInfo();
            m_mthSetControlReadOnly(this, true);
            this.m_cmdSubmit.Enabled = true;
            this.m_cmdSubmit.Text = "提交";

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
            m_mthSetSignReadOnly();
        } 
        #endregion

    }
}
