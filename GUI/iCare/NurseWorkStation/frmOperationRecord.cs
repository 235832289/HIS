using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using com.digitalwave.Utility.Controls;
using System.IO ;
using iCareData;
using System.Windows.Forms;
using System.Xml;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility;

namespace iCare
{
    /// <summary>
    /// 手术护理记录
    /// </summary>
	public class frmOperationRecord : frmHRPBaseForm,PublicFunction 
	{
		#region 

		private System.Windows.Forms.DataGrid dtgAllergic;
		private System.Windows.Forms.DataGrid dtgOperationLocation;
		private System.Windows.Forms.DataGrid dtgElectKnife;
		private System.Windows.Forms.DataGrid dtgDoublePole;
		private System.Windows.Forms.DataGrid dtgCathodeLocationSkin;
		private System.Windows.Forms.DataGrid dtgStypticRubber;
		private System.Windows.Forms.DataGrid dtgFoley;
		private System.Windows.Forms.DataGrid dtgStomach;
		private System.Windows.Forms.DataGrid dtgSkinAntisepsis;
		private System.Windows.Forms.DataGrid dtgBlood;
		private System.Windows.Forms.DataGrid dtgOutFlow;
		private System.Windows.Forms.DataGrid dtgFromHeadToFootSkin;
		private System.Windows.Forms.DataGrid dtgSample;
	
		private System.Windows.Forms.DataGrid dtgAfterOperationSendAfterOperationSend;
		private com.digitalwave.controls.ctlRichTextBox txtRecordContent;
		private System.Windows.Forms.DataGridTableStyle dtbElectKnifeStyle;
		private ctlDataGridDSTCheckBox dcmHaveNotElectKnife;
		private ctlDataGridDSTCheckBox dcmHaveUsedElectKnife;
		private cltDataGridDSTRichTextBox dcmElectKnifeModel;
		private cltDataGridDSTRichTextBox dcmElectKnifeSign;
		private cltDataGridDSTRichTextBox dcmElectKnifeSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbDoublePoleStyle;
		private ctlDataGridDSTCheckBox dcmHaveNotDoublePole;
		private ctlDataGridDSTCheckBox dcmHaveDoublePole;
		private cltDataGridDSTRichTextBox dcmDoublePoleContent;
		private cltDataGridDSTRichTextBox dcmCathodeLocation;
		private cltDataGridDSTRichTextBox dcmDoublePoleSign;
		private cltDataGridDSTRichTextBox dcmDoublePoleSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbStypticRubberStyle;
		private ctlDataGridDSTCheckBox dcmStypticRubber;
		private ctlDataGridDSTCheckBox dcmStypticPressure;
		private cltDataGridDSTRichTextBox dcmStypticSign;
		private cltDataGridDSTRichTextBox dcmStypticSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbStomachStyle;
		private ctlDataGridDSTCheckBox dcmStomachSickroom;
		private ctlDataGridDSTCheckBox dcmStomachOprationRoom;
		private cltDataGridDSTRichTextBox dcmStomachSign;
		private cltDataGridDSTRichTextBox dcmStomachSingTime;
		private System.Windows.Forms.DataGridTableStyle dtbSkinAntisepsisStyle;
		private ctlDataGridDSTCheckBox dcmSkinAntisepsis2;
		private ctlDataGridDSTCheckBox dcmSkinAntisepsis75;
		private ctlDataGridDSTCheckBox dcmSkinAntisepsisIodin;
		private ctlDataGridDSTCheckBox dcmSkinAntisepsisIodinRare;
		private cltDataGridDSTRichTextBox dcmSkinAntisepsisSign;
		private cltDataGridDSTRichTextBox dcmSkinAntisepsisSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbBloodStyle;
		private ctlDataGridDSTCheckBox dcmAllBlood;
		private cltDataGridDSTRichTextBox dcmAllBloodQty;
		private ctlDataGridDSTCheckBox dcmRedCell;
		private cltDataGridDSTRichTextBox dcmRedCellQty;
		private ctlDataGridDSTCheckBox dcmBloodPlasm;
		private cltDataGridDSTRichTextBox dcmBloodPlasmQty;
		private ctlDataGridDSTCheckBox dcmOwnBlood;
		private cltDataGridDSTRichTextBox dcmOwnBloodQty;
		private cltDataGridDSTRichTextBox dcmBloodSign;
		private cltDataGridDSTRichTextBox dcmBloodSignTime;
	
		private ctlDataGridDSTCheckBox dcmFromHeadToFootSkinBeforeOperationFull;
		private ctlDataGridDSTCheckBox dcmFromHeadToFootSkinBeforeOperationMar;
		private cltDataGridDSTRichTextBox dcmFromHeadToFootSkinBeforeOperationContent;
		private cltDataGridDSTRichTextBox dcmFromHeadToFootSkinSign;
		private cltDataGridDSTRichTextBox dcmFromHeadToFootSkinSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbSampleStyle;
		private System.Windows.Forms.DataGridTableStyle dtbFromHeadToFootSkinStyle;

		private ctlDataGridDSTCheckBox dcmSampleGeneral;
		private ctlDataGridDSTCheckBox dcmSampleSlice;
		private ctlDataGridDSTCheckBox dcmSampleBacilli;
		private ctlDataGridDSTCheckBox dcmSampleOther;
		private cltDataGridDSTRichTextBox dcmSampleSign;
		private cltDataGridDSTRichTextBox dcmSampleSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbAfterOperationSendStyle;
		private ctlDataGridDSTCheckBox dcmAfterOperationSendRenew;
		private ctlDataGridDSTCheckBox dcmAfterOperationSendICU;
		private ctlDataGridDSTCheckBox dcmAfterOperationSendSickRoom;
		private cltDataGridDSTRichTextBox dcmAfterOperationSendSign;
		private cltDataGridDSTRichTextBox dcmAfterOperationSendSignTime;
		private System.Windows.Forms.DataGridTableStyle dtgOperationLocationStyle;
		private ctlDataGridDSTCheckBox dcmOperationLocationOnHisBack;
		private ctlDataGridDSTCheckBox dcmOperationLocationSide;
		private ctlDataGridDSTCheckBox dcmOperationLocationParaplegic;
		private ctlDataGridDSTCheckBox dcmOperationLocationHypothyroid;
		private ctlDataGridDSTCheckBox dcmOperationLocationPA;
		private cltDataGridDSTRichTextBox dcmOperationLocationSign;
		private cltDataGridDSTRichTextBox dcmOperationLocationSignTime;
		private cltDataGridDSTRichTextBox dcmOtherOperationLocationContent;
		private System.Windows.Forms.DataGridTableStyle dtbAllergicStyle;
		private ctlDataGridDSTCheckBox dcmNotHaveAllergic;
		private ctlDataGridDSTCheckBox dcmHaveAllergic;
		private cltDataGridDSTRichTextBox dcmAllergicContent;
		private cltDataGridDSTRichTextBox dcmAllergicSign;
		private cltDataGridDSTRichTextBox dcmAllergicSignTime;
		protected System.Windows.Forms.Label lblAnaesthesiaModeTitle;
		protected System.Windows.Forms.Label lblOperationNameTitle;
		protected System.Windows.Forms.Label lblTendRecord;
		private cltDataGridDSTRichTextBox dcmSampleThing;
		private ctlDataGridDSTCheckBox dcmBloodOther;
		private cltDataGridDSTRichTextBox dcmBloodOtherQty;
		private System.Windows.Forms.DataGrid dtgUpStyptic;
		private cltDataGridDSTRichTextBox dcmStypticSignMode;
		private System.Windows.Forms.DataGridTableStyle dtbDownStypticStyle;
		private System.Windows.Forms.DataGrid dtgDownStyptic;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmDownForearm;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmDownThigh;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmDownRight;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmDownLeft;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox DownPuffDateTime;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmDownDeflateDateTime;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmDownTotalDateTime;
		private cltDataGridDSTRichTextBox dcmDownPress;
		private cltDataGridDSTRichTextBox dcmDownStypticSign;
		private cltDataGridDSTRichTextBox dcmDownStypticSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbUpStypticStyle;
		private ctlDataGridDSTCheckBox dcmUpForearm;
		private ctlDataGridDSTCheckBox dcmUpThigh;
		private ctlDataGridDSTCheckBox dcmUpRight;
		private ctlDataGridDSTCheckBox dcmUpLeft;
		private cltDataGridDSTRichTextBox dcmUpPuffDateTime;
		private cltDataGridDSTRichTextBox dcmUpDeflateDateTime;
		private cltDataGridDSTRichTextBox dcmUpTotalDateTime;
		private cltDataGridDSTRichTextBox dcmUpPress;
		private cltDataGridDSTRichTextBox dcmUpStypticSign;
		private cltDataGridDSTRichTextBox dcmUpStypticSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbFoleyStyle;
		private ctlDataGridDSTCheckBox dcmFoleySickroom;
		private ctlDataGridDSTCheckBox dcmFoleyOperationRoom;
		private ctlDataGridDSTCheckBox dcmFoleyDoubleAntrum;
		private ctlDataGridDSTCheckBox dcmFoleyThreeAntrum;
		private cltDataGridDSTRichTextBox dcmFoleySign;
		private cltDataGridDSTRichTextBox dcmFoleySignTime;
		private System.Windows.Forms.DataGrid dtgOutFlowThing;
		private System.Windows.Forms.DataGridTableStyle dtbOutflowStyle;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmNotHaveOutFlow;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmHaveOutFlow;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmOutFlowSign;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmOutFlowSignTime;
		private System.Windows.Forms.DataGridTableStyle dtbOutFlowThingStyle;
		private DataGridTextBoxColumn dcmOutFlowThing;
		private DataGridTextBoxColumn dcmOutFlowThingQty;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmFoleyOtherContent;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmSkinAntisepsisOtherContent;
		private ctlDataGridDSTCheckBox dcmSkinAntisepsisOther;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmOperationLocationOther;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmFoleyOther;
		protected System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblMlSputum;
		protected System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox gpbSences;
		private System.Windows.Forms.RadioButton rdbSencesComa;
		private System.Windows.Forms.RadioButton rdbSencesClear;
		private System.Windows.Forms.RadioButton rdbSencesSleep;
		private System.Windows.Forms.GroupBox gpbAllergic;
		private System.Windows.Forms.RadioButton rdbHaveNotAllergic;
		private System.Windows.Forms.RadioButton rdbHaveAllergic;
		public com.digitalwave.controls.ctlRichTextBox txtAllergicContent;
		private System.Windows.Forms.GroupBox gpbOperationLocation;
		private System.Windows.Forms.RadioButton rdbOperationLocationOther;
		private System.Windows.Forms.RadioButton rdbOperationLocationSide;
		private System.Windows.Forms.RadioButton rdbOperationLocationHypothyroid;
		private System.Windows.Forms.RadioButton rdbOperationLocationOnHisBack;
		private System.Windows.Forms.RadioButton rdbOperationLocationParaplegic;
		private System.Windows.Forms.GroupBox gpbElectKnife;
		private System.Windows.Forms.RadioButton rdbHaveNotElectKnife;
		private System.Windows.Forms.RadioButton rdbHaveUsedElectKnife;
		public com.digitalwave.controls.ctlRichTextBox txtElectKnifeModel;
		private System.Windows.Forms.GroupBox gpbDoublePole;
		protected System.Windows.Forms.Label lblDoublePolemode;
		private System.Windows.Forms.RadioButton rdbHaveNotDoublePole;
		private System.Windows.Forms.RadioButton rdbHaveDoublePole;
		public com.digitalwave.controls.ctlRichTextBox txtDoublePoleMode;
		private System.Windows.Forms.GroupBox gpbSkinBeforOperation1;
		private System.Windows.Forms.RadioButton rdbCathodeLocationSkinBeforOperationMar;
		private System.Windows.Forms.GroupBox gpbSkinBeforOperation;
		private System.Windows.Forms.RadioButton rdbCathodeLocationSkinAfterOperationFull;
		private System.Windows.Forms.RadioButton rdbCathodeLocationSkinAfterOperationMar;
		private System.Windows.Forms.GroupBox gpbStypticRubber;
		protected System.Windows.Forms.Label lblStypticPressureMode;
		public com.digitalwave.controls.ctlRichTextBox txtStypticPressureMode;
		private System.Windows.Forms.GroupBox gpbUp;
		private System.Windows.Forms.Label lblFen;
		private System.Windows.Forms.Label lblUpPuffDateTime;
		private System.Windows.Forms.Label lblUpTotalDateTime;
		private System.Windows.Forms.Label lblUpPress;
		private System.Windows.Forms.Label lblUpDeflateDateTime;
		private System.Windows.Forms.CheckBox chkUpThigh;
		private System.Windows.Forms.CheckBox chkUpLeft;
		private System.Windows.Forms.CheckBox chkUpRight;
		private System.Windows.Forms.CheckBox chkUpForearm;
		public com.digitalwave.controls.ctlRichTextBox txtUpPuffDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtUpDeflateDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtUpTotalDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtUpPress;
		private System.Windows.Forms.GroupBox gpbDown;
		private System.Windows.Forms.Label lblFen2;
		private System.Windows.Forms.Label lblmmhg;
		private System.Windows.Forms.Label lblDownPuffDateTime;
		private System.Windows.Forms.Label lblDownTotalDateTime;
		private System.Windows.Forms.Label lblDownPress;
		private System.Windows.Forms.Label lblDownDeflateDateTime;
		private System.Windows.Forms.CheckBox chkDownThigh;
		private System.Windows.Forms.CheckBox chkDownLeft;
		private System.Windows.Forms.CheckBox chkDownRight;
		private System.Windows.Forms.CheckBox chkDownForearm;
		public com.digitalwave.controls.ctlRichTextBox txtDownPuffDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtDownDeflateDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtDownTotalDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtDownPress;
		private System.Windows.Forms.GroupBox gpbFoley;
		public com.digitalwave.controls.ctlRichTextBox txtFoleyOtherContent;
		private System.Windows.Forms.CheckBox chkFoleyOperationRoom;
		private System.Windows.Forms.CheckBox chkFoleyDoubleAntrum;
		private System.Windows.Forms.CheckBox chkFoleyThreeAntrum;
		private System.Windows.Forms.CheckBox chkFoleySickroom;
		private System.Windows.Forms.GroupBox gpbStomach;
		private System.Windows.Forms.RadioButton rdbStomachSickroom;
		private System.Windows.Forms.RadioButton rdbStomachOprationRoom;
		private System.Windows.Forms.GroupBox gpbSkinAntisepsis;
		private System.Windows.Forms.CheckBox chkSkinAntisepsisOther;
		public com.digitalwave.controls.ctlRichTextBox txtSkinAntisepsisOtherContent;
		private System.Windows.Forms.CheckBox chkSkinAntisepsis75;
		private System.Windows.Forms.CheckBox chkSkinAntisepsisIodin;
		private System.Windows.Forms.CheckBox chkSkinAntisepsisIodinRare;
		private System.Windows.Forms.CheckBox chkSkinAntisepsis2;
		private System.Windows.Forms.GroupBox gpbBlood;
		protected System.Windows.Forms.Label lblml11;
		public com.digitalwave.controls.ctlRichTextBox txtAllBloodQty;
		protected System.Windows.Forms.Label lblml12;
		public com.digitalwave.controls.ctlRichTextBox txtRedCellQty;
		protected System.Windows.Forms.Label lblml13;
		public com.digitalwave.controls.ctlRichTextBox txtBloodPlasmQty;
		public com.digitalwave.controls.ctlRichTextBox txtOwnBloodQty;
		private System.Windows.Forms.CheckBox chkBloodOther;
		public com.digitalwave.controls.ctlRichTextBox txtBloodOther;
		private System.Windows.Forms.CheckBox chkRedCell;
		private System.Windows.Forms.CheckBox chkBloodPlasm;
		private System.Windows.Forms.CheckBox chkOwnBlood;
		private System.Windows.Forms.CheckBox chkAllBlood;
		private System.Windows.Forms.GroupBox gpbOutFlow;
		private System.Windows.Forms.RadioButton rdbHaveNotOutflow;
		private System.Windows.Forms.RadioButton rdbHaveOutFlow;
		private System.Windows.Forms.GroupBox gpbFromHeadToFootSkinBeforeOperatio;
		protected System.Windows.Forms.Label lblFromHeadToFootSkinBeforeOperationContent;
		private System.Windows.Forms.RadioButton rdbFromHeadToFootSkinBeforeOperationFull;
		private System.Windows.Forms.RadioButton rdbFromHeadToFootSkinBeforeOperationMar;
		public com.digitalwave.controls.ctlRichTextBox txtFromHeadToFootSkinBeforeOperationContent;
		private System.Windows.Forms.GroupBox gpbFromto2;
		protected System.Windows.Forms.Label lblFromHeadToFootSkinAfterOperationContent;
		private System.Windows.Forms.RadioButton rdbFromHeadToFootSkinAfterOperationFull;
		private System.Windows.Forms.RadioButton rdbFromHeadToFootSkinAfterOperationMar;
		public com.digitalwave.controls.ctlRichTextBox txtFromHeadToFootSkinAfterOperationContent;
		private com.digitalwave.controls.ctlRichTextBox txtSampleOtherContent;
		private System.Windows.Forms.GroupBox gpbSample;
		private System.Windows.Forms.CheckBox chkSampleSlice;
		private System.Windows.Forms.CheckBox chkSampleBacilli;
		private System.Windows.Forms.CheckBox chkSampleOther;
		private System.Windows.Forms.CheckBox chkSampleGeneral;
		private System.Windows.Forms.GroupBox gpbAfterOperationSend;
		private System.Windows.Forms.RadioButton rdbAfterOperationSendSickRoom;
		private System.Windows.Forms.RadioButton rdbAfterOperationSendRenew;
		private System.Windows.Forms.RadioButton rdbAfterOperationSendICU;
		private System.Windows.Forms.RadioButton rdbOperationLocationPA;
		public com.digitalwave.controls.ctlRichTextBox txtOtherOperationLocation;
		public com.digitalwave.controls.ctlRichTextBox txtCathodeLocation;
		private System.Windows.Forms.RadioButton rdbCathodeLocationSkinBeforOperationFull;
		private System.Windows.Forms.CheckBox chkFoleyOther;
		private System.Windows.Forms.DataGridTableStyle dtbCathodeLocationSkinStyle;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmCathodeLocationSkinBeforOperationFull;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmCathodeLocationSkinBeforOperationMar;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmCathodeLocationSkinBeforSign;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmCathodeLocationSkinBeforSignTime;
		private System.Windows.Forms.DataGrid dtgCathodeLocationAfterOperationSkin;
		private System.Windows.Forms.DataGridTableStyle dtbCathodeLocationAfterOperationSkinStyle;

		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmCathodeLocationSkinAfterOperationFull;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmCathodeLocationSkinAfterOperationMar;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmCathodeLocationSkinAfterOperationSignTime;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmCathodeLocationSkinAfterOperationSign;
	
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmFromHeadToFootSkinAfterOperationFull;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmFromHeadToFootSkinAfterOperationMar;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmFromHeadToFootSkinAfterOperationContent;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmFromHeadToFootSkinAfterOperationSign;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmFromHeadToFootSkinAfterOperationSignTime;
		
		private System.Windows.Forms.DataGrid dtgFromHeadToFootSkinAfterOperation;
		private System.Windows.Forms.DataGridTableStyle dtbFromHeadToFootSkinAfterOperationStyle;
		protected System.Windows.Forms.Label lblOpenDateTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpRecordTime;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.ContextMenu ctmRichTextBoxMenu;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmAnaesthesia;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmOperationID;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmSign;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmSignTime;
		private System.Windows.Forms.DataGrid dtgOperationIDAndAnaesthesia;
		private System.Windows.Forms.DataGridTableStyle dtbOperationIDAndAnaesthesiaStyle;
		private System.Windows.Forms.DataGrid dtgSences;
		private System.Windows.Forms.DataGridTableStyle dcmSencesStyle;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmSencesClear;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmSencesSleep;
		private com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox dcmSencesComa;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmSencesSign;
		private com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox dcmSencesSignTime;
		private com.digitalwave.Utility.Controls.ctlComboBox cboAnaesthesiaModeID;
        private com.digitalwave.Utility.Controls.ctlComboBox cboOperationID;
		private System.Windows.Forms.CheckBox chkStypticRubber;
		private System.Windows.Forms.CheckBox chkStypticPressure;
		protected System.Windows.Forms.Label lblDoubleElectKnifemode;
		private System.Windows.Forms.DataGridTextBoxColumn dcmOutFlowThingID;
		private System.Windows.Forms.Button m_cmdShowHistoryRecord;
		private System.Windows.Forms.Panel m_pnlOperationBefore;
		protected System.Windows.Forms.Label lblBeforeOperation;
		protected System.Windows.Forms.Label lblPatientInDateTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpPatientInDate;
		protected System.Windows.Forms.Label lblTendInOperation;
		protected System.Windows.Forms.Label lblOperationRoomTitle;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		protected System.Windows.Forms.Label lblOperationOverTime;
		protected System.Windows.Forms.Label lblLeaveRoomTime;
		protected System.Windows.Forms.Label lblCheck;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpLeaveRoomTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpOperationOverTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpOperationBeginTime;
		private com.digitalwave.controls.ctlRichTextBox txtOperationRoom;
		private System.Windows.Forms.Panel pnlPanel2;
		private System.Windows.Forms.Panel pnlPanel3;
		protected System.Windows.Forms.Label lblMl2;
		protected System.Windows.Forms.Label lblMl1;
		protected System.Windows.Forms.Label lblInLiquidQtyTitle;
		protected System.Windows.Forms.Label lblPeeOperatingQty;
		private com.digitalwave.controls.ctlRichTextBox txtPeeOperatingQty;
		private com.digitalwave.controls.ctlRichTextBox txtInLiquidQty;
        private System.Windows.Forms.Label m_lblBlank;
	
		private System.ComponentModel.IContainer components = null;

		#endregion
		private System.Windows.Forms.DataGrid m_dtgWound;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;

		private DataTable m_dtbWound;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.ListView lsvWoundThing;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        protected ListView m_lsvWashNurseSign;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private PinkieControls.ButtonXP m_cmdWashNurseSign;
        protected ListView m_lsvRecordNurseSign;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private PinkieControls.ButtonXP m_cmdRecordNurseSign;
        protected ListView m_lsvCircuitNurseSign;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private PinkieControls.ButtonXP m_cmdCircuitNurseSign;
        protected ListView m_lsvAnaDocSign;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        protected ListView m_lsvOperationer;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private PinkieControls.ButtonXP m_cmdAnaDocSign;
        private PinkieControls.ButtonXP m_cmdOperationer;
        private TextBox m_txtSign;
        protected ListView m_lsvBacilliCheckSign;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private PinkieControls.ButtonXP m_cmdSign;
        private PinkieControls.ButtonXP m_cmdBacilliCheckSign;
        private clsEmrSignToolCollection m_objSign;
		#region 构造函数和Dispose
		public frmOperationRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool = new clsBorderTool(Color.White);

			objDomain=new clsOperationRecordDomain();
			m_mthSetQuickKeys();
			m_mthSetRichTextAttrib();
		
			#region New DataTable
			dtbSences=new DataTable("Sences");
			dtbAllergic=new DataTable("Allergic");
			dtbOperationLocation=new DataTable("OperationLocation");
			dtbElectKnife =new DataTable("ElectKnife");
			dtbDoublePole=new DataTable ("DoublePole");
			dtbCathodeLocationSkin=new DataTable("CathodeLocationSkin");
			dtbStypticRubber=new DataTable("StypticRubber");
			dtbFoley=new DataTable("Foley");
			dtbStomach=new DataTable("Stomach");
			dtbSkinAntisepsis=new DataTable("SkinAntisepsis");
			dtbBlood=new DataTable("Blood");
			dtbOutFlow=new DataTable("OutFlow");
			dtbFromHeadToFootSkin=new DataTable("FromHeadToFootSkin");
			dtbSample=new DataTable("Sample");
			dtbAfterOperationSend=new DataTable("AfterOperationSend");
			dtbUpStyptic=new DataTable("UpStyptic");
			dtbDownStyptic=new DataTable("DownStyptic");
			dtbOutFlowThing=new DataTable("OutFlowThing");
			dtbFromHeadToFootSkinAfterOperation=new DataTable("FromHeadToFootSkinAfterOperation");
			dtbCathodeLocationAfterOperationSkin=new DataTable("CathodeLocationAfterOperationSkin");
			dtbOperationIDAndAnaesthesia=new DataTable("OperationIDAndAnaesthesia");
			dtbOperator=new DataTable("Operator");

			m_dtbWound = new DataTable("TableWound");
			m_dtbWound.Columns.Add("Name",typeof(string));
			m_dtbWound.Columns.Add("Quantity",typeof(string));
			m_dtgWound.DataSource = m_dtbWound;
			#endregion

			#region DataGrid 初始化
			this.dtbSences.Columns.Add("清醒",typeof(bool));
			this.dtbSences.Columns.Add("嗜睡",typeof(bool));
			this.dtbSences.Columns.Add("昏迷",typeof(bool));
			this.dtbSences.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbSences.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgSences.DataSource=dtbSences ;
			this.dtbAllergic.Columns.Add("无",typeof(bool));
			this.dtbAllergic.Columns.Add("有",typeof(bool));
			this.dtbAllergic.Columns.Add("过敏药物",typeof(clsDSTRichTextBoxValue));
			this.dtbAllergic.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbAllergic.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgAllergic.DataSource=dtbAllergic ;

			this.dtbOperationLocation.Columns.Add("仰卧位",typeof(bool));
			this.dtbOperationLocation.Columns.Add("侧卧位",typeof(bool));
			this.dtbOperationLocation.Columns.Add("俯卧位",typeof(bool));
			this.dtbOperationLocation.Columns.Add("截石位",typeof(bool));
			this.dtbOperationLocation.Columns.Add("甲状腺位",typeof(bool));
			this.dtbOperationLocation.Columns.Add("其他",typeof(bool));
			this.dtbOperationLocation.Columns.Add("体位",typeof(clsDSTRichTextBoxValue));
			this.dtbOperationLocation.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbOperationLocation.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgOperationLocation.DataSource=dtbOperationLocation ;

			this.dtbElectKnife.Columns.Add("否",typeof(bool));
			this.dtbElectKnife.Columns.Add("是",typeof(bool));
			this.dtbElectKnife.Columns.Add("型号",typeof(clsDSTRichTextBoxValue));
			this.dtbElectKnife.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbElectKnife.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgElectKnife.DataSource=dtbElectKnife ;

			this.dtbDoublePole.Columns.Add("否",typeof(bool));
			this.dtbDoublePole.Columns.Add("是",typeof(bool));
			this.dtbDoublePole.Columns.Add("型号",typeof(clsDSTRichTextBoxValue));
			this.dtbDoublePole.Columns.Add("负极板放置位置",typeof(clsDSTRichTextBoxValue));
			this.dtbDoublePole.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbDoublePole.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgDoublePole.DataSource=dtbDoublePole ;

			this.dtbCathodeLocationSkin.Columns.Add("完好",typeof(bool));
			this.dtbCathodeLocationSkin.Columns.Add("损伤",typeof(bool));
			this.dtbCathodeLocationSkin.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbCathodeLocationSkin.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgCathodeLocationSkin.DataSource=dtbCathodeLocationSkin ;

			this.dtbCathodeLocationAfterOperationSkin.Columns.Add("完好",typeof(bool));
			this.dtbCathodeLocationAfterOperationSkin.Columns.Add("损伤",typeof(bool));
			this.dtbCathodeLocationAfterOperationSkin.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbCathodeLocationAfterOperationSkin.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgCathodeLocationAfterOperationSkin.DataSource=dtbCathodeLocationAfterOperationSkin ;
			
	

			this.dtbStypticRubber.Columns.Add("驱血橡胶带",typeof(bool));
			this.dtbStypticRubber.Columns.Add("气压止血仪",typeof(bool));
			this.dtbStypticRubber.Columns.Add("型号",typeof(clsDSTRichTextBoxValue));
			this.dtbStypticRubber.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbStypticRubber.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgStypticRubber.DataSource=dtbStypticRubber ;

			this.dtbFoley.Columns.Add("病房带来",typeof(bool));
			this.dtbFoley.Columns.Add("手术室",typeof(bool));
			this.dtbFoley.Columns.Add("双腔",typeof(bool));
			this.dtbFoley.Columns.Add("三腔",typeof(bool));
			this.dtbFoley.Columns.Add("其他",typeof(bool));
			this.dtbFoley.Columns.Add("内容",typeof(clsDSTRichTextBoxValue));
			this.dtbFoley.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbFoley.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgFoley.DataSource=dtbFoley ;

			this.dtbStomach.Columns.Add("病房带来",typeof(bool));
			this.dtbStomach.Columns.Add("手术室",typeof(bool));
			this.dtbStomach.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbStomach.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgStomach.DataSource=dtbStomach ;

			this.dtbSkinAntisepsis.Columns.Add("2%碘酊",typeof(bool));
			this.dtbSkinAntisepsis.Columns.Add("75%酒精",typeof(bool));
			this.dtbSkinAntisepsis.Columns.Add("碘伏原液",typeof(bool));
			this.dtbSkinAntisepsis.Columns.Add("碘伏稀释液",typeof(bool));
			this.dtbSkinAntisepsis.Columns.Add("其他",typeof(bool));
			this.dtbSkinAntisepsis.Columns.Add("内容",typeof(clsDSTRichTextBoxValue));
			this.dtbSkinAntisepsis.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbSkinAntisepsis.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgSkinAntisepsis.DataSource=dtbSkinAntisepsis ;


			this.dtbBlood.Columns.Add("全血",typeof(bool));
			this.dtbBlood.Columns.Add("全血数量(ml)",typeof(clsDSTRichTextBoxValue));
			this.dtbBlood.Columns.Add("红细胞",typeof(bool));
			this.dtbBlood.Columns.Add("红细胞数量(单位)",typeof(clsDSTRichTextBoxValue));
			this.dtbBlood.Columns.Add("血浆",typeof(bool));
			this.dtbBlood.Columns.Add("血浆数量(ml)",typeof(clsDSTRichTextBoxValue));
			this.dtbBlood.Columns.Add("输自体血",typeof(bool));
			this.dtbBlood.Columns.Add("自体血数量(ml)",typeof(clsDSTRichTextBoxValue));
            //this.dtbBlood.Columns.Add("其他",typeof(clsDSTRichTextBoxValue));
            this.dtbBlood.Columns.Add("其他", typeof(bool));
			this.dtbBlood.Columns.Add("数量",typeof(clsDSTRichTextBoxValue));
			this.dtbBlood.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbBlood.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgBlood.DataSource=dtbBlood ;

			this.dtbOutFlow.Columns.Add("无",typeof(bool));
			this.dtbOutFlow.Columns.Add("有",typeof(bool));
			this.dtbOutFlow.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbOutFlow.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgOutFlow.DataSource=dtbOutFlow ;

			this.dtbFromHeadToFootSkin.Columns.Add("完整",typeof(bool));
			this.dtbFromHeadToFootSkin.Columns.Add("有损",typeof(bool));
			this.dtbFromHeadToFootSkin.Columns.Add("描述",typeof(clsDSTRichTextBoxValue));
			this.dtbFromHeadToFootSkin.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbFromHeadToFootSkin.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgFromHeadToFootSkin.DataSource=dtbFromHeadToFootSkin ;

			this.dtbFromHeadToFootSkinAfterOperation.Columns.Add("完好",typeof(bool));
			this.dtbFromHeadToFootSkinAfterOperation.Columns.Add("损伤",typeof(bool));
			this.dtbFromHeadToFootSkinAfterOperation.Columns.Add("描述",typeof(clsDSTRichTextBoxValue));
			this.dtbFromHeadToFootSkinAfterOperation.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbFromHeadToFootSkinAfterOperation.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgFromHeadToFootSkinAfterOperation.DataSource=dtbFromHeadToFootSkinAfterOperation ;
	

			this.dtbSample.Columns.Add("常规病理检查",typeof(bool));
			this.dtbSample.Columns.Add("冰冻切片",typeof(bool));
			this.dtbSample.Columns.Add("细菌培养",typeof(bool));
			this.dtbSample.Columns.Add("其他",typeof(bool));
			this.dtbSample.Columns.Add("标本物",typeof(clsDSTRichTextBoxValue));
			this.dtbSample.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbSample.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgSample.DataSource=dtbSample;

			this.dtbAfterOperationSend.Columns.Add("麻醉复苏室",typeof(bool));
			this.dtbAfterOperationSend.Columns.Add("ICU",typeof(bool));
			this.dtbAfterOperationSend.Columns.Add("病房",typeof(bool));
			this.dtbAfterOperationSend.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbAfterOperationSend.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgAfterOperationSendAfterOperationSend.DataSource=dtbAfterOperationSend ;

			this.dtbUpStyptic.Columns.Add("前臂",typeof(bool));
			this.dtbUpStyptic.Columns.Add("大腿",typeof(bool));
			this.dtbUpStyptic.Columns.Add("右",typeof(bool));
			this.dtbUpStyptic.Columns.Add("左",typeof(bool));
			this.dtbUpStyptic.Columns.Add("充气时间",typeof(clsDSTRichTextBoxValue));
			this.dtbUpStyptic.Columns.Add("放气时间",typeof(clsDSTRichTextBoxValue));
			this.dtbUpStyptic.Columns.Add("总时间（分）",typeof(clsDSTRichTextBoxValue));
			this.dtbUpStyptic.Columns.Add("压力",typeof(clsDSTRichTextBoxValue));
			this.dtbUpStyptic.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbUpStyptic.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgUpStyptic.DataSource=dtbUpStyptic ;

			this.dtbDownStyptic.Columns.Add("前臂",typeof(bool));
			this.dtbDownStyptic.Columns.Add("大腿",typeof(bool));
			this.dtbDownStyptic.Columns.Add("右",typeof(bool));
			this.dtbDownStyptic.Columns.Add("左",typeof(bool));
			this.dtbDownStyptic.Columns.Add("充气时间",typeof(clsDSTRichTextBoxValue));
			this.dtbDownStyptic.Columns.Add("放气时间",typeof(clsDSTRichTextBoxValue));
			this.dtbDownStyptic.Columns.Add("总时间（分）",typeof(clsDSTRichTextBoxValue));
			this.dtbDownStyptic.Columns.Add("压力",typeof(clsDSTRichTextBoxValue));
			this.dtbDownStyptic.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbDownStyptic.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgDownStyptic.DataSource=dtbDownStyptic ;

			//			m_dtcWoundThing = new DataColumn();
			//			m_dtcWoundThing.ColumnName= "编号";
			//			dtbOutFlowThing.Columns.Add(m_dtcWoundThing);
			//			dtbOutFlowThing.PrimaryKey = new DataColumn[]{m_dtcWoundThing};
			this.dtbOutFlowThing.Columns.Add("编号");
			this.dtbOutFlowThing.Columns.Add("引流物");
			this.dtbOutFlowThing.Columns.Add("数量");
			this.dtgOutFlowThing.DataSource=dtbOutFlowThing;

			this.dtbOperationIDAndAnaesthesia.Columns.Add("手术名称",typeof(clsDSTRichTextBoxValue));
			this.dtbOperationIDAndAnaesthesia.Columns.Add("麻醉方式",typeof(clsDSTRichTextBoxValue));
			this.dtbOperationIDAndAnaesthesia.Columns.Add("签名",typeof(clsDSTRichTextBoxValue));
			this.dtbOperationIDAndAnaesthesia.Columns.Add("日期",typeof(clsDSTRichTextBoxValue));
			this.dtgOperationIDAndAnaesthesia.DataSource=dtbOperationIDAndAnaesthesia ;

			//			this.dtbOperator.Columns.Add("记录护士");
			//			this.dtbOperator.Columns.Add("洗手护士");
			//			this.dtbOperator.Columns.Add("巡回护士");
			//			this.dtbOperator.Columns.Add("手术医生");
			//			this.dtbOperator.Columns.Add("麻醉医生");
			//			this.dtbOperator.Columns.Add("无菌监测");
			//			this.dtgOperator.DataSource=dtbOperator;

			#endregion

			m_objXmlMemStream = new MemoryStream(300);
			m_objXmlWriter = new XmlTextWriter(m_objXmlMemStream,System.Text.Encoding.Unicode);
			m_objXmlWriter.Flush();
			m_objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Unicode);
			m_objXML_DataGrid =new clsXML_DataGrid();

			m_objGridListViewWoundThing = new clsGridListView(dtgOutFlowThing,dcmOutFlowThing,lsvWoundThing,new EventHandler(m_objAddListViewItemWoundThingArr));			

			arlNurse = new ArrayList();

//			m_objCPaint = new clsPublicControlPaint();

			m_objPublicDomain = new clsPublicDomain();

            #region 电子签名
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdOperationer, m_lsvOperationer, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdAnaDocSign, m_lsvAnaDocSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);            
            m_objSign.m_mthBindEmployeeSign(m_cmdBacilliCheckSign, m_lsvBacilliCheckSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdWashNurseSign, m_lsvWashNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdCircuitNurseSign, m_lsvCircuitNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID); 
            m_objSign.m_mthBindEmployeeSign(m_cmdRecordNurseSign, m_lsvRecordNurseSign, 2, false, clsEMRLogin.LoginInfo.m_strEmpID); 
            #endregion
		}

		private clsPublicDomain m_objPublicDomain;

		/// <summary>
		/// 资源释放
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
		#endregion
		
		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.Nurses;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPNO_CHR;
				return "";
			}
		}
		#endregion 属性

		#region DateTable 定义
		private DataTable dtbSences;
		private DataTable dtbAllergic;
		private DataTable dtbOperationLocation;
		private DataTable dtbElectKnife;
		private DataTable dtbDoublePole;
		private DataTable dtbCathodeLocationSkin;
		private DataTable dtbStypticRubber;
		private DataTable dtbFoley;
		private DataTable dtbStomach;
		private DataTable dtbSkinAntisepsis;
		private DataTable dtbBlood;
		private DataTable dtbOutFlow;
		private DataTable dtbFromHeadToFootSkin;
		private DataTable dtbSample;
		private DataTable dtbAfterOperationSend;
		private DataTable dtbUpStyptic;
		private DataTable dtbDownStyptic;
		private DataTable dtbOutFlowThing;
		private DataTable dtbCathodeLocationAfterOperationSkin;
		private DataTable dtbFromHeadToFootSkinAfterOperation;
		private DataTable dtbOperationIDAndAnaesthesia;
		private DataTable dtbOperator;
		#endregion
        
		#region  <内存中保留记录信息变量>

		private string m_strInPatientID="";
		private string m_strInPatientDate="";

		private clsPatient m_objSelectedPatient;
		private clsOperationRecord m_objSelectedOperationRecord=null;
		private clsOperationRecordContent m_objSelectedOperationRecordContent=null;
		private string m_strSelectedOperationID;
		private string m_strSelectedAnaesthesiaModeID;
		private clsOperationDoctorNurse[]  m_objSelectedOperatorArr=null;
		private clsOperationWoundThingInfo[] m_objSelectedWoundThingArr=null;
		
		#endregion
		
		#region 变量
		private bool blnCanSearch=true;
		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox

		private MemoryStream m_objXmlMemStream;
		private XmlTextWriter m_objXmlWriter;
		private XmlParserContext m_objXmlParser;

		private clsXML_DataGrid m_objXML_DataGrid;

		private int m_intRowNumber; //保存当前dataGrid选定的行号
		private int m_intColumnNumber;//保存当前dataGrid选定的列号
		private clsGridListView m_objGridListViewWoundThing;
		private ArrayList arlNurse=null;
		private clsOperationRecordDomain objDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;

		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.White, new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.White, new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperationRecord));
            this.lblAnaesthesiaModeTitle = new System.Windows.Forms.Label();
            this.lblOperationNameTitle = new System.Windows.Forms.Label();
            this.lblTendRecord = new System.Windows.Forms.Label();
            this.dtgOutFlow = new System.Windows.Forms.DataGrid();
            this.dtbOutflowStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmNotHaveOutFlow = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmHaveOutFlow = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOutFlowSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmOutFlowSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgOutFlowThing = new System.Windows.Forms.DataGrid();
            this.dtbOutFlowThingStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmOutFlowThingID = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmOutFlowThing = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dcmOutFlowThingQty = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgFromHeadToFootSkin = new System.Windows.Forms.DataGrid();
            this.dtbFromHeadToFootSkinStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmFromHeadToFootSkinBeforeOperationFull = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFromHeadToFootSkinBeforeOperationMar = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFromHeadToFootSkinBeforeOperationContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFromHeadToFootSkinSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFromHeadToFootSkinSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgSample = new System.Windows.Forms.DataGrid();
            this.dtbSampleStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmSampleGeneral = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSampleSlice = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSampleBacilli = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSampleOther = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSampleThing = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSampleSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSampleSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgAfterOperationSendAfterOperationSend = new System.Windows.Forms.DataGrid();
            this.dtbAfterOperationSendStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmAfterOperationSendRenew = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmAfterOperationSendICU = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmAfterOperationSendSickRoom = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmAfterOperationSendSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmAfterOperationSendSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgSkinAntisepsis = new System.Windows.Forms.DataGrid();
            this.dtbSkinAntisepsisStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmSkinAntisepsis2 = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSkinAntisepsis75 = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSkinAntisepsisIodin = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSkinAntisepsisIodinRare = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSkinAntisepsisOther = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSkinAntisepsisOtherContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSkinAntisepsisSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSkinAntisepsisSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgBlood = new System.Windows.Forms.DataGrid();
            this.dtbBloodStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmAllBlood = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmAllBloodQty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmRedCell = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmRedCellQty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmBloodPlasm = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmBloodPlasmQty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmOwnBlood = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOwnBloodQty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmBloodOther = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmBloodOtherQty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmBloodSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmBloodSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgStypticRubber = new System.Windows.Forms.DataGrid();
            this.dtbStypticRubberStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmStypticRubber = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmStypticPressure = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmStypticSignMode = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmStypticSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmStypticSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgDoublePole = new System.Windows.Forms.DataGrid();
            this.dtbDoublePoleStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmHaveNotDoublePole = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmHaveDoublePole = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmDoublePoleContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmCathodeLocation = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDoublePoleSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDoublePoleSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgOperationLocation = new System.Windows.Forms.DataGrid();
            this.dtgOperationLocationStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmOperationLocationOnHisBack = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOperationLocationSide = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOperationLocationPA = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOperationLocationParaplegic = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOperationLocationHypothyroid = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOperationLocationOther = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmOtherOperationLocationContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmOperationLocationSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmOperationLocationSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgAllergic = new System.Windows.Forms.DataGrid();
            this.dtbAllergicStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmNotHaveAllergic = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmHaveAllergic = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmAllergicContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmAllergicSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmAllergicSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgElectKnife = new System.Windows.Forms.DataGrid();
            this.dtbElectKnifeStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmHaveNotElectKnife = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmHaveUsedElectKnife = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmElectKnifeModel = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmElectKnifeSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmElectKnifeSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgCathodeLocationSkin = new System.Windows.Forms.DataGrid();
            this.dtbCathodeLocationSkinStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmCathodeLocationSkinBeforOperationFull = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmCathodeLocationSkinBeforOperationMar = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmCathodeLocationSkinBeforSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmCathodeLocationSkinBeforSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgCathodeLocationAfterOperationSkin = new System.Windows.Forms.DataGrid();
            this.dtbCathodeLocationAfterOperationSkinStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmCathodeLocationSkinAfterOperationFull = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmCathodeLocationSkinAfterOperationMar = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmCathodeLocationSkinAfterOperationSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmCathodeLocationSkinAfterOperationSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgFoley = new System.Windows.Forms.DataGrid();
            this.dtbFoleyStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmFoleySickroom = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFoleyOperationRoom = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFoleyDoubleAntrum = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFoleyThreeAntrum = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFoleyOther = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFoleyOtherContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFoleySign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFoleySignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgStomach = new System.Windows.Forms.DataGrid();
            this.dtbStomachStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmStomachSickroom = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmStomachOprationRoom = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmStomachSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmStomachSingTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.txtRecordContent = new com.digitalwave.controls.ctlRichTextBox();
            this.dtgUpStyptic = new System.Windows.Forms.DataGrid();
            this.dtbUpStypticStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmUpForearm = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmUpThigh = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmUpRight = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmUpLeft = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmUpPuffDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmUpDeflateDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmUpTotalDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmUpPress = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmUpStypticSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmUpStypticSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtbDownStypticStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dtgDownStyptic = new System.Windows.Forms.DataGrid();
            this.dcmDownForearm = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmDownThigh = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmDownRight = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmDownLeft = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.DownPuffDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDownDeflateDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDownTotalDateTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDownPress = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDownStypticSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmDownStypticSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.gpbSences = new System.Windows.Forms.GroupBox();
            this.rdbSencesSleep = new System.Windows.Forms.RadioButton();
            this.rdbSencesComa = new System.Windows.Forms.RadioButton();
            this.rdbSencesClear = new System.Windows.Forms.RadioButton();
            this.gpbAllergic = new System.Windows.Forms.GroupBox();
            this.rdbHaveNotAllergic = new System.Windows.Forms.RadioButton();
            this.rdbHaveAllergic = new System.Windows.Forms.RadioButton();
            this.txtAllergicContent = new com.digitalwave.controls.ctlRichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.gpbOperationLocation = new System.Windows.Forms.GroupBox();
            this.txtOtherOperationLocation = new com.digitalwave.controls.ctlRichTextBox();
            this.rdbOperationLocationPA = new System.Windows.Forms.RadioButton();
            this.rdbOperationLocationOther = new System.Windows.Forms.RadioButton();
            this.rdbOperationLocationSide = new System.Windows.Forms.RadioButton();
            this.rdbOperationLocationHypothyroid = new System.Windows.Forms.RadioButton();
            this.rdbOperationLocationOnHisBack = new System.Windows.Forms.RadioButton();
            this.rdbOperationLocationParaplegic = new System.Windows.Forms.RadioButton();
            this.gpbElectKnife = new System.Windows.Forms.GroupBox();
            this.txtElectKnifeModel = new com.digitalwave.controls.ctlRichTextBox();
            this.rdbHaveNotElectKnife = new System.Windows.Forms.RadioButton();
            this.rdbHaveUsedElectKnife = new System.Windows.Forms.RadioButton();
            this.lblDoubleElectKnifemode = new System.Windows.Forms.Label();
            this.gpbDoublePole = new System.Windows.Forms.GroupBox();
            this.txtCathodeLocation = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDoublePoleMode = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDoublePolemode = new System.Windows.Forms.Label();
            this.rdbHaveNotDoublePole = new System.Windows.Forms.RadioButton();
            this.rdbHaveDoublePole = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.gpbSkinBeforOperation1 = new System.Windows.Forms.GroupBox();
            this.rdbCathodeLocationSkinBeforOperationFull = new System.Windows.Forms.RadioButton();
            this.rdbCathodeLocationSkinBeforOperationMar = new System.Windows.Forms.RadioButton();
            this.gpbSkinBeforOperation = new System.Windows.Forms.GroupBox();
            this.rdbCathodeLocationSkinAfterOperationFull = new System.Windows.Forms.RadioButton();
            this.rdbCathodeLocationSkinAfterOperationMar = new System.Windows.Forms.RadioButton();
            this.gpbStypticRubber = new System.Windows.Forms.GroupBox();
            this.txtStypticPressureMode = new com.digitalwave.controls.ctlRichTextBox();
            this.lblStypticPressureMode = new System.Windows.Forms.Label();
            this.chkStypticRubber = new System.Windows.Forms.CheckBox();
            this.chkStypticPressure = new System.Windows.Forms.CheckBox();
            this.gpbUp = new System.Windows.Forms.GroupBox();
            this.lblFen = new System.Windows.Forms.Label();
            this.lblMlSputum = new System.Windows.Forms.Label();
            this.lblUpPuffDateTime = new System.Windows.Forms.Label();
            this.lblUpTotalDateTime = new System.Windows.Forms.Label();
            this.lblUpPress = new System.Windows.Forms.Label();
            this.lblUpDeflateDateTime = new System.Windows.Forms.Label();
            this.chkUpThigh = new System.Windows.Forms.CheckBox();
            this.chkUpLeft = new System.Windows.Forms.CheckBox();
            this.chkUpRight = new System.Windows.Forms.CheckBox();
            this.chkUpForearm = new System.Windows.Forms.CheckBox();
            this.txtUpPuffDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtUpDeflateDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtUpTotalDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtUpPress = new com.digitalwave.controls.ctlRichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.gpbDown = new System.Windows.Forms.GroupBox();
            this.lblFen2 = new System.Windows.Forms.Label();
            this.lblmmhg = new System.Windows.Forms.Label();
            this.lblDownPuffDateTime = new System.Windows.Forms.Label();
            this.lblDownTotalDateTime = new System.Windows.Forms.Label();
            this.lblDownPress = new System.Windows.Forms.Label();
            this.lblDownDeflateDateTime = new System.Windows.Forms.Label();
            this.chkDownThigh = new System.Windows.Forms.CheckBox();
            this.chkDownLeft = new System.Windows.Forms.CheckBox();
            this.chkDownRight = new System.Windows.Forms.CheckBox();
            this.chkDownForearm = new System.Windows.Forms.CheckBox();
            this.txtDownPuffDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDownDeflateDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDownTotalDateTime = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDownPress = new com.digitalwave.controls.ctlRichTextBox();
            this.gpbFoley = new System.Windows.Forms.GroupBox();
            this.txtFoleyOtherContent = new com.digitalwave.controls.ctlRichTextBox();
            this.chkFoleyOther = new System.Windows.Forms.CheckBox();
            this.chkFoleyOperationRoom = new System.Windows.Forms.CheckBox();
            this.chkFoleyDoubleAntrum = new System.Windows.Forms.CheckBox();
            this.chkFoleyThreeAntrum = new System.Windows.Forms.CheckBox();
            this.chkFoleySickroom = new System.Windows.Forms.CheckBox();
            this.gpbStomach = new System.Windows.Forms.GroupBox();
            this.rdbStomachSickroom = new System.Windows.Forms.RadioButton();
            this.rdbStomachOprationRoom = new System.Windows.Forms.RadioButton();
            this.gpbSkinAntisepsis = new System.Windows.Forms.GroupBox();
            this.txtSkinAntisepsisOtherContent = new com.digitalwave.controls.ctlRichTextBox();
            this.chkSkinAntisepsisOther = new System.Windows.Forms.CheckBox();
            this.chkSkinAntisepsis75 = new System.Windows.Forms.CheckBox();
            this.chkSkinAntisepsisIodin = new System.Windows.Forms.CheckBox();
            this.chkSkinAntisepsisIodinRare = new System.Windows.Forms.CheckBox();
            this.chkSkinAntisepsis2 = new System.Windows.Forms.CheckBox();
            this.gpbBlood = new System.Windows.Forms.GroupBox();
            this.txtBloodOther = new com.digitalwave.controls.ctlRichTextBox();
            this.chkBloodOther = new System.Windows.Forms.CheckBox();
            this.chkOwnBlood = new System.Windows.Forms.CheckBox();
            this.chkBloodPlasm = new System.Windows.Forms.CheckBox();
            this.chkRedCell = new System.Windows.Forms.CheckBox();
            this.lblml11 = new System.Windows.Forms.Label();
            this.txtAllBloodQty = new com.digitalwave.controls.ctlRichTextBox();
            this.lblml12 = new System.Windows.Forms.Label();
            this.txtRedCellQty = new com.digitalwave.controls.ctlRichTextBox();
            this.lblml13 = new System.Windows.Forms.Label();
            this.txtBloodPlasmQty = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOwnBloodQty = new com.digitalwave.controls.ctlRichTextBox();
            this.chkAllBlood = new System.Windows.Forms.CheckBox();
            this.gpbOutFlow = new System.Windows.Forms.GroupBox();
            this.rdbHaveNotOutflow = new System.Windows.Forms.RadioButton();
            this.rdbHaveOutFlow = new System.Windows.Forms.RadioButton();
            this.gpbFromHeadToFootSkinBeforeOperatio = new System.Windows.Forms.GroupBox();
            this.txtFromHeadToFootSkinBeforeOperationContent = new com.digitalwave.controls.ctlRichTextBox();
            this.lblFromHeadToFootSkinBeforeOperationContent = new System.Windows.Forms.Label();
            this.rdbFromHeadToFootSkinBeforeOperationFull = new System.Windows.Forms.RadioButton();
            this.rdbFromHeadToFootSkinBeforeOperationMar = new System.Windows.Forms.RadioButton();
            this.gpbFromto2 = new System.Windows.Forms.GroupBox();
            this.txtFromHeadToFootSkinAfterOperationContent = new com.digitalwave.controls.ctlRichTextBox();
            this.lblFromHeadToFootSkinAfterOperationContent = new System.Windows.Forms.Label();
            this.rdbFromHeadToFootSkinAfterOperationFull = new System.Windows.Forms.RadioButton();
            this.rdbFromHeadToFootSkinAfterOperationMar = new System.Windows.Forms.RadioButton();
            this.txtSampleOtherContent = new com.digitalwave.controls.ctlRichTextBox();
            this.gpbSample = new System.Windows.Forms.GroupBox();
            this.chkSampleSlice = new System.Windows.Forms.CheckBox();
            this.chkSampleBacilli = new System.Windows.Forms.CheckBox();
            this.chkSampleOther = new System.Windows.Forms.CheckBox();
            this.chkSampleGeneral = new System.Windows.Forms.CheckBox();
            this.gpbAfterOperationSend = new System.Windows.Forms.GroupBox();
            this.rdbAfterOperationSendSickRoom = new System.Windows.Forms.RadioButton();
            this.rdbAfterOperationSendRenew = new System.Windows.Forms.RadioButton();
            this.rdbAfterOperationSendICU = new System.Windows.Forms.RadioButton();
            this.dtgFromHeadToFootSkinAfterOperation = new System.Windows.Forms.DataGrid();
            this.dtbFromHeadToFootSkinAfterOperationStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmFromHeadToFootSkinAfterOperationFull = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFromHeadToFootSkinAfterOperationMar = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmFromHeadToFootSkinAfterOperationContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFromHeadToFootSkinAfterOperationSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmFromHeadToFootSkinAfterOperationSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.lblOpenDateTime = new System.Windows.Forms.Label();
            this.dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.ctmRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.dtgOperationIDAndAnaesthesia = new System.Windows.Forms.DataGrid();
            this.dtbOperationIDAndAnaesthesiaStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmAnaesthesia = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmOperationID = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dtgSences = new System.Windows.Forms.DataGrid();
            this.dcmSencesStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dcmSencesClear = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSencesSleep = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSencesComa = new com.digitalwave.Utility.Controls.ctlDataGridDSTCheckBox();
            this.dcmSencesSign = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dcmSencesSignTime = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.cboAnaesthesiaModeID = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.cboOperationID = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cmdShowHistoryRecord = new System.Windows.Forms.Button();
            this.m_pnlOperationBefore = new System.Windows.Forms.Panel();
            this.lblPatientInDateTitle = new System.Windows.Forms.Label();
            this.dtpPatientInDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblBeforeOperation = new System.Windows.Forms.Label();
            this.pnlPanel2 = new System.Windows.Forms.Panel();
            this.lblTendInOperation = new System.Windows.Forms.Label();
            this.lblOperationRoomTitle = new System.Windows.Forms.Label();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.lblOperationOverTime = new System.Windows.Forms.Label();
            this.lblLeaveRoomTime = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.dtpLeaveRoomTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpOperationOverTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpOperationBeginTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.txtOperationRoom = new com.digitalwave.controls.ctlRichTextBox();
            this.pnlPanel3 = new System.Windows.Forms.Panel();
            this.txtPeeOperatingQty = new com.digitalwave.controls.ctlRichTextBox();
            this.txtInLiquidQty = new com.digitalwave.controls.ctlRichTextBox();
            this.lblMl2 = new System.Windows.Forms.Label();
            this.lblMl1 = new System.Windows.Forms.Label();
            this.lblInLiquidQtyTitle = new System.Windows.Forms.Label();
            this.lblPeeOperatingQty = new System.Windows.Forms.Label();
            this.m_lblBlank = new System.Windows.Forms.Label();
            this.m_dtgWound = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.m_lsvAnaDocSign = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.m_lsvOperationer = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdAnaDocSign = new PinkieControls.ButtonXP();
            this.m_cmdOperationer = new PinkieControls.ButtonXP();
            this.m_lsvBacilliCheckSign = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_cmdBacilliCheckSign = new PinkieControls.ButtonXP();
            this.m_lsvCircuitNurseSign = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdCircuitNurseSign = new PinkieControls.ButtonXP();
            this.m_lsvRecordNurseSign = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdRecordNurseSign = new PinkieControls.ButtonXP();
            this.m_lsvWashNurseSign = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdWashNurseSign = new PinkieControls.ButtonXP();
            this.lsvWoundThing = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOutFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOutFlowThing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFromHeadToFootSkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSample)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAfterOperationSendAfterOperationSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkinAntisepsis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBlood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStypticRubber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDoublePole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperationLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllergic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgElectKnife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCathodeLocationSkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCathodeLocationAfterOperationSkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFoley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStomach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUpStyptic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDownStyptic)).BeginInit();
            this.gpbSences.SuspendLayout();
            this.gpbAllergic.SuspendLayout();
            this.gpbOperationLocation.SuspendLayout();
            this.gpbElectKnife.SuspendLayout();
            this.gpbDoublePole.SuspendLayout();
            this.gpbSkinBeforOperation1.SuspendLayout();
            this.gpbSkinBeforOperation.SuspendLayout();
            this.gpbStypticRubber.SuspendLayout();
            this.gpbUp.SuspendLayout();
            this.gpbDown.SuspendLayout();
            this.gpbFoley.SuspendLayout();
            this.gpbStomach.SuspendLayout();
            this.gpbSkinAntisepsis.SuspendLayout();
            this.gpbBlood.SuspendLayout();
            this.gpbOutFlow.SuspendLayout();
            this.gpbFromHeadToFootSkinBeforeOperatio.SuspendLayout();
            this.gpbFromto2.SuspendLayout();
            this.gpbSample.SuspendLayout();
            this.gpbAfterOperationSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFromHeadToFootSkinAfterOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperationIDAndAnaesthesia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSences)).BeginInit();
            this.m_pnlOperationBefore.SuspendLayout();
            this.pnlPanel2.SuspendLayout();
            this.pnlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgWound)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(688, 600);
            this.lblSex.Visible = false;
            this.lblSex.Click += new System.EventHandler(this.lblSex_Click);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(722, 294);
            this.lblAge.Size = new System.Drawing.Size(48, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(644, 323);
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBedNoTitle.Visible = false;
            this.lblBedNoTitle.Click += new System.EventHandler(this.lblBedNoTitle_Click);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(582, 609);
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(9, 603);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            this.lblNameTitle.Click += new System.EventHandler(this.lblNameTitle_Click);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(640, 609);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            this.lblSexTitle.Click += new System.EventHandler(this.lblSexTitle_Click);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(681, 294);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(359, 263);
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(414, 142);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(70, 104);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(511, 599);
            this.txtInPatientID.Size = new System.Drawing.Size(70, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(59, 600);
            this.m_txtPatientName.Size = new System.Drawing.Size(90, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(684, 321);
            this.m_txtBedNO.Size = new System.Drawing.Size(52, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(403, 259);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(493, 142);
            this.m_lsvPatientName.Size = new System.Drawing.Size(90, 104);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(468, 32);
            this.m_lsvBedNO.Size = new System.Drawing.Size(52, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(202, 603);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(154, 608);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDept.Visible = false;
            this.lblDept.Click += new System.EventHandler(this.lblDept_Click);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(330, 599);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(736, 321);
            this.m_cmdNext.Size = new System.Drawing.Size(18, 21);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(663, 137);
            this.m_cmdPre.Size = new System.Drawing.Size(8, 4);
            this.m_cmdPre.Visible = true;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(625, 58);
            this.m_lblForTitle.Size = new System.Drawing.Size(3, 3);
            this.m_lblForTitle.Text = "手 术 护 理 记 录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(421, 605);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(667, 32);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(15, 2);
            this.m_pnlNewBase.Size = new System.Drawing.Size(750, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(748, 29);
            // 
            // lblAnaesthesiaModeTitle
            // 
            this.lblAnaesthesiaModeTitle.Location = new System.Drawing.Point(449, 107);
            this.lblAnaesthesiaModeTitle.Name = "lblAnaesthesiaModeTitle";
            this.lblAnaesthesiaModeTitle.Size = new System.Drawing.Size(72, 19);
            this.lblAnaesthesiaModeTitle.TabIndex = 625;
            this.lblAnaesthesiaModeTitle.Text = "麻醉方式:";
            // 
            // lblOperationNameTitle
            // 
            this.lblOperationNameTitle.AutoSize = true;
            this.lblOperationNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationNameTitle.Location = new System.Drawing.Point(220, 107);
            this.lblOperationNameTitle.Name = "lblOperationNameTitle";
            this.lblOperationNameTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationNameTitle.TabIndex = 512;
            this.lblOperationNameTitle.Text = "手术名称:";
            // 
            // lblTendRecord
            // 
            this.lblTendRecord.AutoSize = true;
            this.lblTendRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTendRecord.Location = new System.Drawing.Point(10, 212);
            this.lblTendRecord.Name = "lblTendRecord";
            this.lblTendRecord.Size = new System.Drawing.Size(82, 14);
            this.lblTendRecord.TabIndex = 515;
            this.lblTendRecord.Text = "护理记录：";
            // 
            // dtgOutFlow
            // 
            this.dtgOutFlow.BackColor = System.Drawing.Color.White;
            this.dtgOutFlow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOutFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgOutFlow.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOutFlow.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgOutFlow.CaptionText = "伤口引流物情况";
            this.dtgOutFlow.DataMember = "";
            this.dtgOutFlow.FlatMode = true;
            this.dtgOutFlow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOutFlow.ForeColor = System.Drawing.Color.Black;
            this.dtgOutFlow.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgOutFlow.Location = new System.Drawing.Point(196, -176);
            this.dtgOutFlow.Name = "dtgOutFlow";
            this.dtgOutFlow.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOutFlow.RowHeaderWidth = 10;
            this.dtgOutFlow.Size = new System.Drawing.Size(4, 37);
            this.dtgOutFlow.TabIndex = 5000;
            this.dtgOutFlow.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbOutflowStyle});
            // 
            // dtbOutflowStyle
            // 
            this.dtbOutflowStyle.AllowSorting = false;
            this.dtbOutflowStyle.DataGrid = this.dtgOutFlow;
            this.dtbOutflowStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmNotHaveOutFlow,
            this.dcmHaveOutFlow,
            this.dcmOutFlowSign,
            this.dcmOutFlowSignTime});
            this.dtbOutflowStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbOutflowStyle.MappingName = "OutFlow";
            // 
            // dcmNotHaveOutFlow
            // 
            this.dcmNotHaveOutFlow.HeaderText = "无";
            this.dcmNotHaveOutFlow.m_ClrDST = System.Drawing.Color.Red;
            this.dcmNotHaveOutFlow.MappingName = "无";
            this.dcmNotHaveOutFlow.NullText = "";
            this.dcmNotHaveOutFlow.NullValue = null;
            this.dcmNotHaveOutFlow.Width = 50;
            // 
            // dcmHaveOutFlow
            // 
            this.dcmHaveOutFlow.HeaderText = "有";
            this.dcmHaveOutFlow.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveOutFlow.MappingName = "有";
            this.dcmHaveOutFlow.NullText = "";
            this.dcmHaveOutFlow.NullValue = null;
            this.dcmHaveOutFlow.Width = 50;
            // 
            // dcmOutFlowSign
            // 
            this.dcmOutFlowSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOutFlowSign.HeaderText = "签名";
            this.dcmOutFlowSign.m_BlnGobleSet = true;
            this.dcmOutFlowSign.m_BlnUnderLineDST = false;
            this.dcmOutFlowSign.MappingName = "签名";
            this.dcmOutFlowSign.NullText = "";
            this.dcmOutFlowSign.Width = 72;
            // 
            // dcmOutFlowSignTime
            // 
            this.dcmOutFlowSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOutFlowSignTime.HeaderText = "日期";
            this.dcmOutFlowSignTime.m_BlnGobleSet = true;
            this.dcmOutFlowSignTime.m_BlnUnderLineDST = false;
            this.dcmOutFlowSignTime.MappingName = "日期";
            this.dcmOutFlowSignTime.NullText = "";
            this.dcmOutFlowSignTime.Width = 150;
            // 
            // dtgOutFlowThing
            // 
            this.dtgOutFlowThing.BackColor = System.Drawing.Color.White;
            this.dtgOutFlowThing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgOutFlowThing.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOutFlowThing.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOutFlowThing.CaptionText = "伤口引流物情况";
            this.dtgOutFlowThing.CaptionVisible = false;
            this.dtgOutFlowThing.DataMember = "";
            this.dtgOutFlowThing.FlatMode = true;
            this.dtgOutFlowThing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOutFlowThing.ForeColor = System.Drawing.Color.Black;
            this.dtgOutFlowThing.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgOutFlowThing.Location = new System.Drawing.Point(416, 10);
            this.dtgOutFlowThing.Name = "dtgOutFlowThing";
            this.dtgOutFlowThing.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOutFlowThing.RowHeaderWidth = 10;
            this.dtgOutFlowThing.Size = new System.Drawing.Size(316, 84);
            this.dtgOutFlowThing.TabIndex = 1000;
            this.dtgOutFlowThing.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbOutFlowThingStyle});
            this.dtgOutFlowThing.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dtgOutFlowThing_Navigate);
            // 
            // dtbOutFlowThingStyle
            // 
            this.dtbOutFlowThingStyle.AllowSorting = false;
            this.dtbOutFlowThingStyle.DataGrid = this.dtgOutFlowThing;
            this.dtbOutFlowThingStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmOutFlowThingID,
            this.dcmOutFlowThing,
            this.dcmOutFlowThingQty});
            this.dtbOutFlowThingStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbOutFlowThingStyle.MappingName = "OutFlowThing";
            // 
            // dcmOutFlowThingID
            // 
            this.dcmOutFlowThingID.Format = "";
            this.dcmOutFlowThingID.FormatInfo = null;
            this.dcmOutFlowThingID.HeaderText = "编号";
            this.dcmOutFlowThingID.MappingName = "编号";
            this.dcmOutFlowThingID.NullText = "";
            this.dcmOutFlowThingID.ReadOnly = true;
            this.dcmOutFlowThingID.Width = 75;
            // 
            // dcmOutFlowThing
            // 
            this.dcmOutFlowThing.Format = "";
            this.dcmOutFlowThing.FormatInfo = null;
            this.dcmOutFlowThing.HeaderText = "引流物";
            this.dcmOutFlowThing.MappingName = "引流物";
            this.dcmOutFlowThing.NullText = "";
            this.dcmOutFlowThing.Width = 150;
            // 
            // dcmOutFlowThingQty
            // 
            this.dcmOutFlowThingQty.Format = "";
            this.dcmOutFlowThingQty.FormatInfo = null;
            this.dcmOutFlowThingQty.HeaderText = "数量";
            this.dcmOutFlowThingQty.MappingName = "数量";
            this.dcmOutFlowThingQty.NullText = "";
            this.dcmOutFlowThingQty.Width = 75;
            // 
            // dtgFromHeadToFootSkin
            // 
            this.dtgFromHeadToFootSkin.BackColor = System.Drawing.Color.White;
            this.dtgFromHeadToFootSkin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFromHeadToFootSkin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgFromHeadToFootSkin.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFromHeadToFootSkin.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgFromHeadToFootSkin.CaptionText = "术前全身皮肤情况";
            this.dtgFromHeadToFootSkin.DataMember = "";
            this.dtgFromHeadToFootSkin.FlatMode = true;
            this.dtgFromHeadToFootSkin.ForeColor = System.Drawing.Color.Black;
            this.dtgFromHeadToFootSkin.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgFromHeadToFootSkin.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgFromHeadToFootSkin.Location = new System.Drawing.Point(421, 227);
            this.dtgFromHeadToFootSkin.Name = "dtgFromHeadToFootSkin";
            this.dtgFromHeadToFootSkin.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgFromHeadToFootSkin.RowHeaderWidth = 10;
            this.dtgFromHeadToFootSkin.Size = new System.Drawing.Size(42, 26);
            this.dtgFromHeadToFootSkin.TabIndex = 5000;
            this.dtgFromHeadToFootSkin.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbFromHeadToFootSkinStyle});
            // 
            // dtbFromHeadToFootSkinStyle
            // 
            this.dtbFromHeadToFootSkinStyle.AllowSorting = false;
            this.dtbFromHeadToFootSkinStyle.DataGrid = this.dtgFromHeadToFootSkin;
            this.dtbFromHeadToFootSkinStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmFromHeadToFootSkinBeforeOperationFull,
            this.dcmFromHeadToFootSkinBeforeOperationMar,
            this.dcmFromHeadToFootSkinBeforeOperationContent,
            this.dcmFromHeadToFootSkinSign,
            this.dcmFromHeadToFootSkinSignTime});
            this.dtbFromHeadToFootSkinStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbFromHeadToFootSkinStyle.MappingName = "FromHeadToFootSkin";
            // 
            // dcmFromHeadToFootSkinBeforeOperationFull
            // 
            this.dcmFromHeadToFootSkinBeforeOperationFull.HeaderText = "完整";
            this.dcmFromHeadToFootSkinBeforeOperationFull.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFromHeadToFootSkinBeforeOperationFull.MappingName = "完整";
            this.dcmFromHeadToFootSkinBeforeOperationFull.NullText = "";
            this.dcmFromHeadToFootSkinBeforeOperationFull.NullValue = null;
            this.dcmFromHeadToFootSkinBeforeOperationFull.Width = 38;
            // 
            // dcmFromHeadToFootSkinBeforeOperationMar
            // 
            this.dcmFromHeadToFootSkinBeforeOperationMar.HeaderText = "有损";
            this.dcmFromHeadToFootSkinBeforeOperationMar.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFromHeadToFootSkinBeforeOperationMar.MappingName = "有损";
            this.dcmFromHeadToFootSkinBeforeOperationMar.NullText = "";
            this.dcmFromHeadToFootSkinBeforeOperationMar.NullValue = null;
            this.dcmFromHeadToFootSkinBeforeOperationMar.Width = 38;
            // 
            // dcmFromHeadToFootSkinBeforeOperationContent
            // 
            this.dcmFromHeadToFootSkinBeforeOperationContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinBeforeOperationContent.HeaderText = "描述";
            this.dcmFromHeadToFootSkinBeforeOperationContent.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinBeforeOperationContent.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinBeforeOperationContent.MappingName = "描述";
            this.dcmFromHeadToFootSkinBeforeOperationContent.NullText = "";
            this.dcmFromHeadToFootSkinBeforeOperationContent.Width = 75;
            // 
            // dcmFromHeadToFootSkinSign
            // 
            this.dcmFromHeadToFootSkinSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinSign.HeaderText = "签名";
            this.dcmFromHeadToFootSkinSign.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinSign.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinSign.MappingName = "签名";
            this.dcmFromHeadToFootSkinSign.NullText = "";
            this.dcmFromHeadToFootSkinSign.Width = 60;
            // 
            // dcmFromHeadToFootSkinSignTime
            // 
            this.dcmFromHeadToFootSkinSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinSignTime.HeaderText = "日期";
            this.dcmFromHeadToFootSkinSignTime.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinSignTime.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinSignTime.MappingName = "日期";
            this.dcmFromHeadToFootSkinSignTime.NullText = "";
            this.dcmFromHeadToFootSkinSignTime.Width = 145;
            // 
            // dtgSample
            // 
            this.dtgSample.BackColor = System.Drawing.Color.White;
            this.dtgSample.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSample.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSample.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgSample.CaptionText = "标本";
            this.dtgSample.DataMember = "";
            this.dtgSample.FlatMode = true;
            this.dtgSample.ForeColor = System.Drawing.Color.Black;
            this.dtgSample.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgSample.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgSample.Location = new System.Drawing.Point(12, -140);
            this.dtgSample.Name = "dtgSample";
            this.dtgSample.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgSample.RowHeaderWidth = 10;
            this.dtgSample.Size = new System.Drawing.Size(4, 37);
            this.dtgSample.TabIndex = 5000;
            this.dtgSample.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbSampleStyle});
            // 
            // dtbSampleStyle
            // 
            this.dtbSampleStyle.AllowSorting = false;
            this.dtbSampleStyle.DataGrid = this.dtgSample;
            this.dtbSampleStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmSampleGeneral,
            this.dcmSampleSlice,
            this.dcmSampleBacilli,
            this.dcmSampleOther,
            this.dcmSampleThing,
            this.dcmSampleSign,
            this.dcmSampleSignTime});
            this.dtbSampleStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbSampleStyle.MappingName = "Sample";
            // 
            // dcmSampleGeneral
            // 
            this.dcmSampleGeneral.HeaderText = "常规病理检查";
            this.dcmSampleGeneral.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSampleGeneral.MappingName = "常规病理检查";
            this.dcmSampleGeneral.NullText = "";
            this.dcmSampleGeneral.NullValue = null;
            this.dcmSampleGeneral.Width = 105;
            // 
            // dcmSampleSlice
            // 
            this.dcmSampleSlice.HeaderText = "冰冻切片";
            this.dcmSampleSlice.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSampleSlice.MappingName = "冰冻切片";
            this.dcmSampleSlice.NullText = "";
            this.dcmSampleSlice.NullValue = null;
            this.dcmSampleSlice.Width = 70;
            // 
            // dcmSampleBacilli
            // 
            this.dcmSampleBacilli.HeaderText = "细菌培养";
            this.dcmSampleBacilli.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSampleBacilli.MappingName = "细菌培养";
            this.dcmSampleBacilli.NullText = "";
            this.dcmSampleBacilli.NullValue = null;
            this.dcmSampleBacilli.Width = 70;
            // 
            // dcmSampleOther
            // 
            this.dcmSampleOther.HeaderText = "其他";
            this.dcmSampleOther.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSampleOther.MappingName = "其他";
            this.dcmSampleOther.NullText = "";
            this.dcmSampleOther.NullValue = null;
            this.dcmSampleOther.Width = 50;
            // 
            // dcmSampleThing
            // 
            this.dcmSampleThing.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSampleThing.HeaderText = "标本物";
            this.dcmSampleThing.m_BlnGobleSet = true;
            this.dcmSampleThing.m_BlnUnderLineDST = false;
            this.dcmSampleThing.MappingName = "标本物";
            this.dcmSampleThing.NullText = "";
            this.dcmSampleThing.Width = 50;
            // 
            // dcmSampleSign
            // 
            this.dcmSampleSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSampleSign.HeaderText = "签名";
            this.dcmSampleSign.m_BlnGobleSet = true;
            this.dcmSampleSign.m_BlnUnderLineDST = false;
            this.dcmSampleSign.MappingName = "签名";
            this.dcmSampleSign.NullText = "";
            this.dcmSampleSign.Width = 50;
            // 
            // dcmSampleSignTime
            // 
            this.dcmSampleSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSampleSignTime.HeaderText = "日期";
            this.dcmSampleSignTime.m_BlnGobleSet = true;
            this.dcmSampleSignTime.m_BlnUnderLineDST = false;
            this.dcmSampleSignTime.MappingName = "日期";
            this.dcmSampleSignTime.NullText = "";
            this.dcmSampleSignTime.Width = 140;
            // 
            // dtgAfterOperationSendAfterOperationSend
            // 
            this.dtgAfterOperationSendAfterOperationSend.BackColor = System.Drawing.Color.White;
            this.dtgAfterOperationSendAfterOperationSend.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgAfterOperationSendAfterOperationSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgAfterOperationSendAfterOperationSend.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgAfterOperationSendAfterOperationSend.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAfterOperationSendAfterOperationSend.CaptionText = "术后送回";
            this.dtgAfterOperationSendAfterOperationSend.DataMember = "";
            this.dtgAfterOperationSendAfterOperationSend.FlatMode = true;
            this.dtgAfterOperationSendAfterOperationSend.ForeColor = System.Drawing.Color.Black;
            this.dtgAfterOperationSendAfterOperationSend.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgAfterOperationSendAfterOperationSend.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgAfterOperationSendAfterOperationSend.Location = new System.Drawing.Point(128, -168);
            this.dtgAfterOperationSendAfterOperationSend.Name = "dtgAfterOperationSendAfterOperationSend";
            this.dtgAfterOperationSendAfterOperationSend.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgAfterOperationSendAfterOperationSend.RowHeaderWidth = 10;
            this.dtgAfterOperationSendAfterOperationSend.Size = new System.Drawing.Size(4, 37);
            this.dtgAfterOperationSendAfterOperationSend.TabIndex = 5000;
            this.dtgAfterOperationSendAfterOperationSend.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbAfterOperationSendStyle});
            // 
            // dtbAfterOperationSendStyle
            // 
            this.dtbAfterOperationSendStyle.AllowSorting = false;
            this.dtbAfterOperationSendStyle.DataGrid = this.dtgAfterOperationSendAfterOperationSend;
            this.dtbAfterOperationSendStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmAfterOperationSendRenew,
            this.dcmAfterOperationSendICU,
            this.dcmAfterOperationSendSickRoom,
            this.dcmAfterOperationSendSign,
            this.dcmAfterOperationSendSignTime});
            this.dtbAfterOperationSendStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbAfterOperationSendStyle.MappingName = "AfterOperationSend";
            // 
            // dcmAfterOperationSendRenew
            // 
            this.dcmAfterOperationSendRenew.HeaderText = "麻醉复苏室";
            this.dcmAfterOperationSendRenew.m_ClrDST = System.Drawing.Color.Red;
            this.dcmAfterOperationSendRenew.MappingName = "麻醉复苏室";
            this.dcmAfterOperationSendRenew.NullText = "";
            this.dcmAfterOperationSendRenew.NullValue = null;
            this.dcmAfterOperationSendRenew.Width = 95;
            // 
            // dcmAfterOperationSendICU
            // 
            this.dcmAfterOperationSendICU.HeaderText = "ICU";
            this.dcmAfterOperationSendICU.m_ClrDST = System.Drawing.Color.Red;
            this.dcmAfterOperationSendICU.MappingName = "ICU";
            this.dcmAfterOperationSendICU.NullText = "";
            this.dcmAfterOperationSendICU.NullValue = null;
            this.dcmAfterOperationSendICU.Width = 50;
            // 
            // dcmAfterOperationSendSickRoom
            // 
            this.dcmAfterOperationSendSickRoom.HeaderText = "病房";
            this.dcmAfterOperationSendSickRoom.m_ClrDST = System.Drawing.Color.Red;
            this.dcmAfterOperationSendSickRoom.MappingName = "病房";
            this.dcmAfterOperationSendSickRoom.NullText = "";
            this.dcmAfterOperationSendSickRoom.NullValue = null;
            this.dcmAfterOperationSendSickRoom.Width = 50;
            // 
            // dcmAfterOperationSendSign
            // 
            this.dcmAfterOperationSendSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAfterOperationSendSign.HeaderText = "签名";
            this.dcmAfterOperationSendSign.m_BlnGobleSet = true;
            this.dcmAfterOperationSendSign.m_BlnUnderLineDST = false;
            this.dcmAfterOperationSendSign.MappingName = "签名";
            this.dcmAfterOperationSendSign.NullText = "";
            this.dcmAfterOperationSendSign.Width = 60;
            // 
            // dcmAfterOperationSendSignTime
            // 
            this.dcmAfterOperationSendSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAfterOperationSendSignTime.HeaderText = "日期";
            this.dcmAfterOperationSendSignTime.m_BlnGobleSet = true;
            this.dcmAfterOperationSendSignTime.m_BlnUnderLineDST = false;
            this.dcmAfterOperationSendSignTime.MappingName = "日期";
            this.dcmAfterOperationSendSignTime.NullText = "";
            this.dcmAfterOperationSendSignTime.Width = 145;
            // 
            // dtgSkinAntisepsis
            // 
            this.dtgSkinAntisepsis.BackColor = System.Drawing.Color.White;
            this.dtgSkinAntisepsis.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSkinAntisepsis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSkinAntisepsis.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSkinAntisepsis.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgSkinAntisepsis.CaptionText = "皮肤消毒";
            this.dtgSkinAntisepsis.DataMember = "";
            this.dtgSkinAntisepsis.FlatMode = true;
            this.dtgSkinAntisepsis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgSkinAntisepsis.ForeColor = System.Drawing.Color.Black;
            this.dtgSkinAntisepsis.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgSkinAntisepsis.Location = new System.Drawing.Point(469, 227);
            this.dtgSkinAntisepsis.Name = "dtgSkinAntisepsis";
            this.dtgSkinAntisepsis.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgSkinAntisepsis.RowHeaderWidth = 10;
            this.dtgSkinAntisepsis.Size = new System.Drawing.Size(106, 26);
            this.dtgSkinAntisepsis.TabIndex = 5000;
            this.dtgSkinAntisepsis.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbSkinAntisepsisStyle});
            // 
            // dtbSkinAntisepsisStyle
            // 
            this.dtbSkinAntisepsisStyle.AllowSorting = false;
            this.dtbSkinAntisepsisStyle.DataGrid = this.dtgSkinAntisepsis;
            this.dtbSkinAntisepsisStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmSkinAntisepsis2,
            this.dcmSkinAntisepsis75,
            this.dcmSkinAntisepsisIodin,
            this.dcmSkinAntisepsisIodinRare,
            this.dcmSkinAntisepsisOther,
            this.dcmSkinAntisepsisOtherContent,
            this.dcmSkinAntisepsisSign,
            this.dcmSkinAntisepsisSignTime});
            this.dtbSkinAntisepsisStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbSkinAntisepsisStyle.MappingName = "SkinAntisepsis";
            // 
            // dcmSkinAntisepsis2
            // 
            this.dcmSkinAntisepsis2.HeaderText = "2%碘酊";
            this.dcmSkinAntisepsis2.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSkinAntisepsis2.MappingName = "2%碘酊";
            this.dcmSkinAntisepsis2.NullText = "";
            this.dcmSkinAntisepsis2.NullValue = null;
            this.dcmSkinAntisepsis2.Width = 50;
            // 
            // dcmSkinAntisepsis75
            // 
            this.dcmSkinAntisepsis75.HeaderText = "75%酒精";
            this.dcmSkinAntisepsis75.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSkinAntisepsis75.MappingName = "75%酒精";
            this.dcmSkinAntisepsis75.NullText = "";
            this.dcmSkinAntisepsis75.NullValue = null;
            this.dcmSkinAntisepsis75.Width = 65;
            // 
            // dcmSkinAntisepsisIodin
            // 
            this.dcmSkinAntisepsisIodin.HeaderText = "碘伏原液";
            this.dcmSkinAntisepsisIodin.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSkinAntisepsisIodin.MappingName = "碘伏原液";
            this.dcmSkinAntisepsisIodin.NullText = "";
            this.dcmSkinAntisepsisIodin.NullValue = null;
            this.dcmSkinAntisepsisIodin.Width = 65;
            // 
            // dcmSkinAntisepsisIodinRare
            // 
            this.dcmSkinAntisepsisIodinRare.HeaderText = "碘伏稀释液";
            this.dcmSkinAntisepsisIodinRare.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSkinAntisepsisIodinRare.MappingName = "碘伏稀释液";
            this.dcmSkinAntisepsisIodinRare.NullText = "";
            this.dcmSkinAntisepsisIodinRare.NullValue = null;
            this.dcmSkinAntisepsisIodinRare.Width = 75;
            // 
            // dcmSkinAntisepsisOther
            // 
            this.dcmSkinAntisepsisOther.HeaderText = "其他";
            this.dcmSkinAntisepsisOther.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSkinAntisepsisOther.MappingName = "其他";
            this.dcmSkinAntisepsisOther.NullText = "";
            this.dcmSkinAntisepsisOther.NullValue = null;
            this.dcmSkinAntisepsisOther.Width = 35;
            // 
            // dcmSkinAntisepsisOtherContent
            // 
            this.dcmSkinAntisepsisOtherContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSkinAntisepsisOtherContent.HeaderText = "内容";
            this.dcmSkinAntisepsisOtherContent.m_BlnGobleSet = true;
            this.dcmSkinAntisepsisOtherContent.m_BlnUnderLineDST = false;
            this.dcmSkinAntisepsisOtherContent.MappingName = "内容";
            this.dcmSkinAntisepsisOtherContent.NullText = "";
            this.dcmSkinAntisepsisOtherContent.Width = 50;
            // 
            // dcmSkinAntisepsisSign
            // 
            this.dcmSkinAntisepsisSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSkinAntisepsisSign.HeaderText = "签名";
            this.dcmSkinAntisepsisSign.m_BlnGobleSet = true;
            this.dcmSkinAntisepsisSign.m_BlnUnderLineDST = false;
            this.dcmSkinAntisepsisSign.MappingName = "签名";
            this.dcmSkinAntisepsisSign.NullText = "";
            this.dcmSkinAntisepsisSign.Width = 50;
            // 
            // dcmSkinAntisepsisSignTime
            // 
            this.dcmSkinAntisepsisSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSkinAntisepsisSignTime.HeaderText = "日期";
            this.dcmSkinAntisepsisSignTime.m_BlnGobleSet = true;
            this.dcmSkinAntisepsisSignTime.m_BlnUnderLineDST = false;
            this.dcmSkinAntisepsisSignTime.MappingName = "日期";
            this.dcmSkinAntisepsisSignTime.NullText = "";
            this.dcmSkinAntisepsisSignTime.Width = 140;
            // 
            // dtgBlood
            // 
            this.dtgBlood.BackColor = System.Drawing.Color.White;
            this.dtgBlood.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgBlood.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgBlood.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgBlood.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgBlood.CaptionText = "血制品";
            this.dtgBlood.DataMember = "";
            this.dtgBlood.FlatMode = true;
            this.dtgBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgBlood.ForeColor = System.Drawing.Color.Black;
            this.dtgBlood.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgBlood.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgBlood.Location = new System.Drawing.Point(248, -128);
            this.dtgBlood.Name = "dtgBlood";
            this.dtgBlood.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgBlood.RowHeaderWidth = 10;
            this.dtgBlood.Size = new System.Drawing.Size(4, 37);
            this.dtgBlood.TabIndex = 5000;
            this.dtgBlood.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbBloodStyle});
            // 
            // dtbBloodStyle
            // 
            this.dtbBloodStyle.AllowSorting = false;
            this.dtbBloodStyle.DataGrid = this.dtgBlood;
            this.dtbBloodStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmAllBlood,
            this.dcmAllBloodQty,
            this.dcmRedCell,
            this.dcmRedCellQty,
            this.dcmBloodPlasm,
            this.dcmBloodPlasmQty,
            this.dcmOwnBlood,
            this.dcmOwnBloodQty,
            this.dcmBloodOther,
            this.dcmBloodOtherQty,
            this.dcmBloodSign,
            this.dcmBloodSignTime});
            this.dtbBloodStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbBloodStyle.MappingName = "Blood";
            // 
            // dcmAllBlood
            // 
            this.dcmAllBlood.HeaderText = "全血";
            this.dcmAllBlood.m_ClrDST = System.Drawing.Color.Red;
            this.dcmAllBlood.MappingName = "全血";
            this.dcmAllBlood.NullText = "";
            this.dcmAllBlood.NullValue = null;
            this.dcmAllBlood.Width = 35;
            // 
            // dcmAllBloodQty
            // 
            this.dcmAllBloodQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAllBloodQty.HeaderText = "全血数量(ml)";
            this.dcmAllBloodQty.m_BlnGobleSet = true;
            this.dcmAllBloodQty.m_BlnUnderLineDST = false;
            this.dcmAllBloodQty.MappingName = "全血数量(ml)";
            this.dcmAllBloodQty.NullText = "";
            this.dcmAllBloodQty.Width = 95;
            // 
            // dcmRedCell
            // 
            this.dcmRedCell.HeaderText = "红细胞";
            this.dcmRedCell.m_ClrDST = System.Drawing.Color.Red;
            this.dcmRedCell.MappingName = "红细胞";
            this.dcmRedCell.NullText = "";
            this.dcmRedCell.NullValue = null;
            this.dcmRedCell.Width = 50;
            // 
            // dcmRedCellQty
            // 
            this.dcmRedCellQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmRedCellQty.HeaderText = "红细胞数量(单位)";
            this.dcmRedCellQty.m_BlnGobleSet = true;
            this.dcmRedCellQty.m_BlnUnderLineDST = false;
            this.dcmRedCellQty.MappingName = "红细胞数量(单位)";
            this.dcmRedCellQty.NullText = "";
            this.dcmRedCellQty.Width = 125;
            // 
            // dcmBloodPlasm
            // 
            this.dcmBloodPlasm.HeaderText = "血浆";
            this.dcmBloodPlasm.m_ClrDST = System.Drawing.Color.Red;
            this.dcmBloodPlasm.MappingName = "血浆";
            this.dcmBloodPlasm.NullText = "";
            this.dcmBloodPlasm.NullValue = null;
            this.dcmBloodPlasm.Width = 35;
            // 
            // dcmBloodPlasmQty
            // 
            this.dcmBloodPlasmQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmBloodPlasmQty.HeaderText = "血浆数量(ml)";
            this.dcmBloodPlasmQty.m_BlnGobleSet = true;
            this.dcmBloodPlasmQty.m_BlnUnderLineDST = false;
            this.dcmBloodPlasmQty.MappingName = "血浆数量(ml)";
            this.dcmBloodPlasmQty.NullText = "";
            this.dcmBloodPlasmQty.Width = 95;
            // 
            // dcmOwnBlood
            // 
            this.dcmOwnBlood.HeaderText = "输自体血";
            this.dcmOwnBlood.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOwnBlood.MappingName = "输自体血";
            this.dcmOwnBlood.NullText = "";
            this.dcmOwnBlood.NullValue = null;
            this.dcmOwnBlood.Width = 70;
            // 
            // dcmOwnBloodQty
            // 
            this.dcmOwnBloodQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOwnBloodQty.HeaderText = "自体血数量(ml)";
            this.dcmOwnBloodQty.m_BlnGobleSet = true;
            this.dcmOwnBloodQty.m_BlnUnderLineDST = false;
            this.dcmOwnBloodQty.MappingName = "自体血数量(ml)";
            this.dcmOwnBloodQty.NullText = "";
            this.dcmOwnBloodQty.Width = 115;
            // 
            // dcmBloodOther
            // 
            this.dcmBloodOther.HeaderText = "其他";
            this.dcmBloodOther.m_ClrDST = System.Drawing.Color.Red;
            this.dcmBloodOther.MappingName = "其他";
            this.dcmBloodOther.NullText = "";
            this.dcmBloodOther.NullValue = null;
            this.dcmBloodOther.Width = 35;
            // 
            // dcmBloodOtherQty
            // 
            this.dcmBloodOtherQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmBloodOtherQty.HeaderText = "数量";
            this.dcmBloodOtherQty.m_BlnGobleSet = true;
            this.dcmBloodOtherQty.m_BlnUnderLineDST = false;
            this.dcmBloodOtherQty.MappingName = "数量";
            this.dcmBloodOtherQty.NullText = "";
            this.dcmBloodOtherQty.Width = 35;
            // 
            // dcmBloodSign
            // 
            this.dcmBloodSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmBloodSign.HeaderText = "签名";
            this.dcmBloodSign.m_BlnGobleSet = true;
            this.dcmBloodSign.m_BlnUnderLineDST = false;
            this.dcmBloodSign.MappingName = "签名";
            this.dcmBloodSign.NullText = "";
            this.dcmBloodSign.Width = 50;
            // 
            // dcmBloodSignTime
            // 
            this.dcmBloodSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmBloodSignTime.HeaderText = "日期";
            this.dcmBloodSignTime.m_BlnGobleSet = true;
            this.dcmBloodSignTime.m_BlnUnderLineDST = false;
            this.dcmBloodSignTime.MappingName = "日期";
            this.dcmBloodSignTime.NullText = "";
            this.dcmBloodSignTime.Width = 145;
            // 
            // dtgStypticRubber
            // 
            this.dtgStypticRubber.BackColor = System.Drawing.Color.White;
            this.dtgStypticRubber.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgStypticRubber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgStypticRubber.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgStypticRubber.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgStypticRubber.CaptionText = "止血带";
            this.dtgStypticRubber.DataMember = "";
            this.dtgStypticRubber.FlatMode = true;
            this.dtgStypticRubber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgStypticRubber.ForeColor = System.Drawing.Color.Black;
            this.dtgStypticRubber.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgStypticRubber.Location = new System.Drawing.Point(24, -132);
            this.dtgStypticRubber.Name = "dtgStypticRubber";
            this.dtgStypticRubber.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgStypticRubber.RowHeaderWidth = 10;
            this.dtgStypticRubber.Size = new System.Drawing.Size(4, 37);
            this.dtgStypticRubber.TabIndex = 5000;
            this.dtgStypticRubber.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbStypticRubberStyle});
            // 
            // dtbStypticRubberStyle
            // 
            this.dtbStypticRubberStyle.AllowSorting = false;
            this.dtbStypticRubberStyle.DataGrid = this.dtgStypticRubber;
            this.dtbStypticRubberStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmStypticRubber,
            this.dcmStypticPressure,
            this.dcmStypticSignMode,
            this.dcmStypticSign,
            this.dcmStypticSignTime});
            this.dtbStypticRubberStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbStypticRubberStyle.MappingName = "StypticRubber";
            // 
            // dcmStypticRubber
            // 
            this.dcmStypticRubber.HeaderText = "驱血橡胶带";
            this.dcmStypticRubber.m_ClrDST = System.Drawing.Color.Red;
            this.dcmStypticRubber.MappingName = "驱血橡胶带";
            this.dcmStypticRubber.NullText = "";
            this.dcmStypticRubber.NullValue = null;
            this.dcmStypticRubber.Width = 80;
            // 
            // dcmStypticPressure
            // 
            this.dcmStypticPressure.HeaderText = "气压止血仪";
            this.dcmStypticPressure.m_ClrDST = System.Drawing.Color.Red;
            this.dcmStypticPressure.MappingName = "气压止血仪";
            this.dcmStypticPressure.NullText = "";
            this.dcmStypticPressure.NullValue = null;
            this.dcmStypticPressure.Width = 80;
            // 
            // dcmStypticSignMode
            // 
            this.dcmStypticSignMode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmStypticSignMode.HeaderText = "型号";
            this.dcmStypticSignMode.m_BlnGobleSet = true;
            this.dcmStypticSignMode.m_BlnUnderLineDST = false;
            this.dcmStypticSignMode.MappingName = "型号";
            this.dcmStypticSignMode.NullText = "";
            this.dcmStypticSignMode.Width = 58;
            // 
            // dcmStypticSign
            // 
            this.dcmStypticSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmStypticSign.HeaderText = "签名";
            this.dcmStypticSign.m_BlnGobleSet = true;
            this.dcmStypticSign.m_BlnUnderLineDST = false;
            this.dcmStypticSign.MappingName = "签名";
            this.dcmStypticSign.NullText = "";
            this.dcmStypticSign.Width = 72;
            // 
            // dcmStypticSignTime
            // 
            this.dcmStypticSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmStypticSignTime.HeaderText = "日期";
            this.dcmStypticSignTime.m_BlnGobleSet = true;
            this.dcmStypticSignTime.m_BlnUnderLineDST = false;
            this.dcmStypticSignTime.MappingName = "日期";
            this.dcmStypticSignTime.NullText = "";
            this.dcmStypticSignTime.Width = 145;
            // 
            // dtgDoublePole
            // 
            this.dtgDoublePole.BackColor = System.Drawing.Color.White;
            this.dtgDoublePole.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgDoublePole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDoublePole.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgDoublePole.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDoublePole.CaptionText = "双极电凝";
            this.dtgDoublePole.DataMember = "";
            this.dtgDoublePole.FlatMode = true;
            this.dtgDoublePole.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgDoublePole.ForeColor = System.Drawing.Color.Black;
            this.dtgDoublePole.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgDoublePole.Location = new System.Drawing.Point(328, -172);
            this.dtgDoublePole.Name = "dtgDoublePole";
            this.dtgDoublePole.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgDoublePole.RowHeaderWidth = 10;
            this.dtgDoublePole.Size = new System.Drawing.Size(4, 37);
            this.dtgDoublePole.TabIndex = 5000;
            this.dtgDoublePole.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbDoublePoleStyle});
            // 
            // dtbDoublePoleStyle
            // 
            this.dtbDoublePoleStyle.AllowSorting = false;
            this.dtbDoublePoleStyle.DataGrid = this.dtgDoublePole;
            this.dtbDoublePoleStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmHaveNotDoublePole,
            this.dcmHaveDoublePole,
            this.dcmDoublePoleContent,
            this.dcmCathodeLocation,
            this.dcmDoublePoleSign,
            this.dcmDoublePoleSignTime});
            this.dtbDoublePoleStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbDoublePoleStyle.MappingName = "DoublePole";
            // 
            // dcmHaveNotDoublePole
            // 
            this.dcmHaveNotDoublePole.HeaderText = "否";
            this.dcmHaveNotDoublePole.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveNotDoublePole.MappingName = "否";
            this.dcmHaveNotDoublePole.NullText = "";
            this.dcmHaveNotDoublePole.NullValue = null;
            this.dcmHaveNotDoublePole.Width = 25;
            // 
            // dcmHaveDoublePole
            // 
            this.dcmHaveDoublePole.HeaderText = "是";
            this.dcmHaveDoublePole.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveDoublePole.MappingName = "是";
            this.dcmHaveDoublePole.NullText = "";
            this.dcmHaveDoublePole.NullValue = null;
            this.dcmHaveDoublePole.Width = 25;
            // 
            // dcmDoublePoleContent
            // 
            this.dcmDoublePoleContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDoublePoleContent.HeaderText = "型号";
            this.dcmDoublePoleContent.m_BlnGobleSet = true;
            this.dcmDoublePoleContent.m_BlnUnderLineDST = false;
            this.dcmDoublePoleContent.MappingName = "型号";
            this.dcmDoublePoleContent.NullText = "";
            this.dcmDoublePoleContent.Width = 50;
            // 
            // dcmCathodeLocation
            // 
            this.dcmCathodeLocation.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmCathodeLocation.HeaderText = "负极板放置位置";
            this.dcmCathodeLocation.m_BlnGobleSet = true;
            this.dcmCathodeLocation.m_BlnUnderLineDST = false;
            this.dcmCathodeLocation.MappingName = "负极板放置位置";
            this.dcmCathodeLocation.NullText = "";
            this.dcmCathodeLocation.Width = 103;
            // 
            // dcmDoublePoleSign
            // 
            this.dcmDoublePoleSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDoublePoleSign.HeaderText = "签名";
            this.dcmDoublePoleSign.m_BlnGobleSet = true;
            this.dcmDoublePoleSign.m_BlnUnderLineDST = false;
            this.dcmDoublePoleSign.MappingName = "签名";
            this.dcmDoublePoleSign.NullText = "";
            this.dcmDoublePoleSign.Width = 72;
            // 
            // dcmDoublePoleSignTime
            // 
            this.dcmDoublePoleSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDoublePoleSignTime.HeaderText = "日期";
            this.dcmDoublePoleSignTime.m_BlnGobleSet = true;
            this.dcmDoublePoleSignTime.m_BlnUnderLineDST = false;
            this.dcmDoublePoleSignTime.MappingName = "日期";
            this.dcmDoublePoleSignTime.NullText = "";
            this.dcmDoublePoleSignTime.Width = 145;
            // 
            // dtgOperationLocation
            // 
            this.dtgOperationLocation.BackColor = System.Drawing.Color.White;
            this.dtgOperationLocation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOperationLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgOperationLocation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOperationLocation.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgOperationLocation.CaptionText = "手术体位";
            this.dtgOperationLocation.DataMember = "";
            this.dtgOperationLocation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOperationLocation.ForeColor = System.Drawing.Color.Black;
            this.dtgOperationLocation.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOperationLocation.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgOperationLocation.Location = new System.Drawing.Point(-248, 752);
            this.dtgOperationLocation.Name = "dtgOperationLocation";
            this.dtgOperationLocation.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOperationLocation.RowHeaderWidth = 10;
            this.dtgOperationLocation.Size = new System.Drawing.Size(248, 8);
            this.dtgOperationLocation.TabIndex = 5000;
            this.dtgOperationLocation.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtgOperationLocationStyle});
            // 
            // dtgOperationLocationStyle
            // 
            this.dtgOperationLocationStyle.AllowSorting = false;
            this.dtgOperationLocationStyle.DataGrid = this.dtgOperationLocation;
            this.dtgOperationLocationStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmOperationLocationOnHisBack,
            this.dcmOperationLocationSide,
            this.dcmOperationLocationPA,
            this.dcmOperationLocationParaplegic,
            this.dcmOperationLocationHypothyroid,
            this.dcmOperationLocationOther,
            this.dcmOtherOperationLocationContent,
            this.dcmOperationLocationSign,
            this.dcmOperationLocationSignTime});
            this.dtgOperationLocationStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgOperationLocationStyle.MappingName = "OperationLocation";
            // 
            // dcmOperationLocationOnHisBack
            // 
            this.dcmOperationLocationOnHisBack.HeaderText = "仰卧位";
            this.dcmOperationLocationOnHisBack.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationOnHisBack.MappingName = "仰卧位";
            this.dcmOperationLocationOnHisBack.NullText = "";
            this.dcmOperationLocationOnHisBack.NullValue = null;
            this.dcmOperationLocationOnHisBack.Width = 50;
            // 
            // dcmOperationLocationSide
            // 
            this.dcmOperationLocationSide.HeaderText = "侧卧位";
            this.dcmOperationLocationSide.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationSide.MappingName = "侧卧位";
            this.dcmOperationLocationSide.NullText = "";
            this.dcmOperationLocationSide.NullValue = null;
            this.dcmOperationLocationSide.Width = 50;
            // 
            // dcmOperationLocationPA
            // 
            this.dcmOperationLocationPA.HeaderText = "俯卧位";
            this.dcmOperationLocationPA.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationPA.MappingName = "俯卧位";
            this.dcmOperationLocationPA.NullText = "";
            this.dcmOperationLocationPA.NullValue = null;
            this.dcmOperationLocationPA.Width = 50;
            // 
            // dcmOperationLocationParaplegic
            // 
            this.dcmOperationLocationParaplegic.HeaderText = "截石位";
            this.dcmOperationLocationParaplegic.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationParaplegic.MappingName = "截石位";
            this.dcmOperationLocationParaplegic.NullText = "";
            this.dcmOperationLocationParaplegic.NullValue = null;
            this.dcmOperationLocationParaplegic.Width = 50;
            // 
            // dcmOperationLocationHypothyroid
            // 
            this.dcmOperationLocationHypothyroid.HeaderText = "甲状腺位";
            this.dcmOperationLocationHypothyroid.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationHypothyroid.MappingName = "甲状腺位";
            this.dcmOperationLocationHypothyroid.NullText = "";
            this.dcmOperationLocationHypothyroid.NullValue = null;
            this.dcmOperationLocationHypothyroid.Width = 65;
            // 
            // dcmOperationLocationOther
            // 
            this.dcmOperationLocationOther.HeaderText = "其他";
            this.dcmOperationLocationOther.m_ClrDST = System.Drawing.Color.Red;
            this.dcmOperationLocationOther.MappingName = "其他";
            this.dcmOperationLocationOther.NullText = "";
            this.dcmOperationLocationOther.NullValue = null;
            this.dcmOperationLocationOther.Width = 36;
            // 
            // dcmOtherOperationLocationContent
            // 
            this.dcmOtherOperationLocationContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOtherOperationLocationContent.HeaderText = "体位";
            this.dcmOtherOperationLocationContent.m_BlnGobleSet = true;
            this.dcmOtherOperationLocationContent.m_BlnUnderLineDST = false;
            this.dcmOtherOperationLocationContent.MappingName = "体位";
            this.dcmOtherOperationLocationContent.NullText = "";
            this.dcmOtherOperationLocationContent.Width = 300;
            // 
            // dcmOperationLocationSign
            // 
            this.dcmOperationLocationSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOperationLocationSign.HeaderText = "签名";
            this.dcmOperationLocationSign.m_BlnGobleSet = true;
            this.dcmOperationLocationSign.m_BlnUnderLineDST = false;
            this.dcmOperationLocationSign.MappingName = "签名";
            this.dcmOperationLocationSign.NullText = "";
            this.dcmOperationLocationSign.Width = 72;
            // 
            // dcmOperationLocationSignTime
            // 
            this.dcmOperationLocationSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOperationLocationSignTime.HeaderText = "日期";
            this.dcmOperationLocationSignTime.m_BlnGobleSet = true;
            this.dcmOperationLocationSignTime.m_BlnUnderLineDST = false;
            this.dcmOperationLocationSignTime.MappingName = "日期";
            this.dcmOperationLocationSignTime.NullText = "";
            this.dcmOperationLocationSignTime.Width = 145;
            // 
            // dtgAllergic
            // 
            this.dtgAllergic.BackColor = System.Drawing.Color.White;
            this.dtgAllergic.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgAllergic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgAllergic.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgAllergic.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAllergic.CaptionText = "药物过敏史";
            this.dtgAllergic.DataMember = "";
            this.dtgAllergic.FlatMode = true;
            this.dtgAllergic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgAllergic.ForeColor = System.Drawing.Color.Black;
            this.dtgAllergic.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgAllergic.Location = new System.Drawing.Point(320, -156);
            this.dtgAllergic.Name = "dtgAllergic";
            this.dtgAllergic.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgAllergic.RowHeaderWidth = 10;
            this.dtgAllergic.Size = new System.Drawing.Size(4, 37);
            this.dtgAllergic.TabIndex = 5000;
            this.dtgAllergic.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbAllergicStyle});
            // 
            // dtbAllergicStyle
            // 
            this.dtbAllergicStyle.AllowSorting = false;
            this.dtbAllergicStyle.DataGrid = this.dtgAllergic;
            this.dtbAllergicStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmNotHaveAllergic,
            this.dcmHaveAllergic,
            this.dcmAllergicContent,
            this.dcmAllergicSign,
            this.dcmAllergicSignTime});
            this.dtbAllergicStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbAllergicStyle.MappingName = "Allergic";
            // 
            // dcmNotHaveAllergic
            // 
            this.dcmNotHaveAllergic.HeaderText = "无";
            this.dcmNotHaveAllergic.m_ClrDST = System.Drawing.Color.Red;
            this.dcmNotHaveAllergic.MappingName = "无";
            this.dcmNotHaveAllergic.NullText = "";
            this.dcmNotHaveAllergic.NullValue = null;
            this.dcmNotHaveAllergic.Width = 30;
            // 
            // dcmHaveAllergic
            // 
            this.dcmHaveAllergic.HeaderText = "有";
            this.dcmHaveAllergic.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveAllergic.MappingName = "有";
            this.dcmHaveAllergic.NullText = "";
            this.dcmHaveAllergic.NullValue = null;
            this.dcmHaveAllergic.Width = 30;
            // 
            // dcmAllergicContent
            // 
            this.dcmAllergicContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAllergicContent.HeaderText = "过敏药物";
            this.dcmAllergicContent.m_BlnGobleSet = true;
            this.dcmAllergicContent.m_BlnUnderLineDST = false;
            this.dcmAllergicContent.MappingName = "过敏药物";
            this.dcmAllergicContent.NullText = "";
            this.dcmAllergicContent.Width = 200;
            // 
            // dcmAllergicSign
            // 
            this.dcmAllergicSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAllergicSign.HeaderText = "签名";
            this.dcmAllergicSign.m_BlnGobleSet = true;
            this.dcmAllergicSign.m_BlnUnderLineDST = false;
            this.dcmAllergicSign.MappingName = "签名";
            this.dcmAllergicSign.NullText = "";
            this.dcmAllergicSign.Width = 72;
            // 
            // dcmAllergicSignTime
            // 
            this.dcmAllergicSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAllergicSignTime.HeaderText = "日期";
            this.dcmAllergicSignTime.m_BlnGobleSet = true;
            this.dcmAllergicSignTime.m_BlnUnderLineDST = false;
            this.dcmAllergicSignTime.MappingName = "日期";
            this.dcmAllergicSignTime.NullText = "";
            this.dcmAllergicSignTime.Width = 145;
            // 
            // dtgElectKnife
            // 
            this.dtgElectKnife.BackColor = System.Drawing.Color.White;
            this.dtgElectKnife.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgElectKnife.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgElectKnife.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgElectKnife.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgElectKnife.CaptionText = "使用电刀";
            this.dtgElectKnife.DataMember = "";
            this.dtgElectKnife.FlatMode = true;
            this.dtgElectKnife.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgElectKnife.ForeColor = System.Drawing.Color.Black;
            this.dtgElectKnife.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgElectKnife.Location = new System.Drawing.Point(358, 227);
            this.dtgElectKnife.Name = "dtgElectKnife";
            this.dtgElectKnife.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgElectKnife.RowHeaderWidth = 10;
            this.dtgElectKnife.Size = new System.Drawing.Size(56, 26);
            this.dtgElectKnife.TabIndex = 5000;
            this.dtgElectKnife.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbElectKnifeStyle});
            // 
            // dtbElectKnifeStyle
            // 
            this.dtbElectKnifeStyle.AllowSorting = false;
            this.dtbElectKnifeStyle.DataGrid = this.dtgElectKnife;
            this.dtbElectKnifeStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmHaveNotElectKnife,
            this.dcmHaveUsedElectKnife,
            this.dcmElectKnifeModel,
            this.dcmElectKnifeSign,
            this.dcmElectKnifeSignTime});
            this.dtbElectKnifeStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbElectKnifeStyle.MappingName = "ElectKnife";
            // 
            // dcmHaveNotElectKnife
            // 
            this.dcmHaveNotElectKnife.HeaderText = "否";
            this.dcmHaveNotElectKnife.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveNotElectKnife.MappingName = "否";
            this.dcmHaveNotElectKnife.NullText = "";
            this.dcmHaveNotElectKnife.NullValue = null;
            this.dcmHaveNotElectKnife.Width = 25;
            // 
            // dcmHaveUsedElectKnife
            // 
            this.dcmHaveUsedElectKnife.HeaderText = "是";
            this.dcmHaveUsedElectKnife.m_ClrDST = System.Drawing.Color.Red;
            this.dcmHaveUsedElectKnife.MappingName = "是";
            this.dcmHaveUsedElectKnife.NullText = "";
            this.dcmHaveUsedElectKnife.NullValue = null;
            this.dcmHaveUsedElectKnife.Width = 25;
            // 
            // dcmElectKnifeModel
            // 
            this.dcmElectKnifeModel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmElectKnifeModel.HeaderText = "型号";
            this.dcmElectKnifeModel.m_BlnGobleSet = true;
            this.dcmElectKnifeModel.m_BlnUnderLineDST = false;
            this.dcmElectKnifeModel.MappingName = "型号";
            this.dcmElectKnifeModel.NullText = "";
            this.dcmElectKnifeModel.Width = 75;
            // 
            // dcmElectKnifeSign
            // 
            this.dcmElectKnifeSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmElectKnifeSign.HeaderText = "签名";
            this.dcmElectKnifeSign.m_BlnGobleSet = true;
            this.dcmElectKnifeSign.m_BlnUnderLineDST = false;
            this.dcmElectKnifeSign.MappingName = "签名";
            this.dcmElectKnifeSign.NullText = "";
            this.dcmElectKnifeSign.Width = 72;
            // 
            // dcmElectKnifeSignTime
            // 
            this.dcmElectKnifeSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmElectKnifeSignTime.HeaderText = "日期";
            this.dcmElectKnifeSignTime.m_BlnGobleSet = true;
            this.dcmElectKnifeSignTime.m_BlnUnderLineDST = false;
            this.dcmElectKnifeSignTime.MappingName = "日期";
            this.dcmElectKnifeSignTime.NullText = "";
            this.dcmElectKnifeSignTime.Width = 145;
            // 
            // dtgCathodeLocationSkin
            // 
            this.dtgCathodeLocationSkin.BackColor = System.Drawing.Color.White;
            this.dtgCathodeLocationSkin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgCathodeLocationSkin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCathodeLocationSkin.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgCathodeLocationSkin.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgCathodeLocationSkin.CaptionText = "术前负极板部位皮肤";
            this.dtgCathodeLocationSkin.DataMember = "";
            this.dtgCathodeLocationSkin.FlatMode = true;
            this.dtgCathodeLocationSkin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgCathodeLocationSkin.ForeColor = System.Drawing.Color.Black;
            this.dtgCathodeLocationSkin.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgCathodeLocationSkin.Location = new System.Drawing.Point(8, -172);
            this.dtgCathodeLocationSkin.Name = "dtgCathodeLocationSkin";
            this.dtgCathodeLocationSkin.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgCathodeLocationSkin.RowHeaderWidth = 10;
            this.dtgCathodeLocationSkin.Size = new System.Drawing.Size(4, 37);
            this.dtgCathodeLocationSkin.TabIndex = 5000;
            this.dtgCathodeLocationSkin.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbCathodeLocationSkinStyle});
            // 
            // dtbCathodeLocationSkinStyle
            // 
            this.dtbCathodeLocationSkinStyle.AllowSorting = false;
            this.dtbCathodeLocationSkinStyle.DataGrid = this.dtgCathodeLocationSkin;
            this.dtbCathodeLocationSkinStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmCathodeLocationSkinBeforOperationFull,
            this.dcmCathodeLocationSkinBeforOperationMar,
            this.dcmCathodeLocationSkinBeforSign,
            this.dcmCathodeLocationSkinBeforSignTime});
            this.dtbCathodeLocationSkinStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbCathodeLocationSkinStyle.MappingName = "CathodeLocationSkin";
            // 
            // dcmCathodeLocationSkinBeforOperationFull
            // 
            this.dcmCathodeLocationSkinBeforOperationFull.HeaderText = "完好";
            this.dcmCathodeLocationSkinBeforOperationFull.m_ClrDST = System.Drawing.Color.Red;
            this.dcmCathodeLocationSkinBeforOperationFull.MappingName = "完好";
            this.dcmCathodeLocationSkinBeforOperationFull.NullText = "";
            this.dcmCathodeLocationSkinBeforOperationFull.NullValue = null;
            this.dcmCathodeLocationSkinBeforOperationFull.Width = 40;
            // 
            // dcmCathodeLocationSkinBeforOperationMar
            // 
            this.dcmCathodeLocationSkinBeforOperationMar.HeaderText = "损伤";
            this.dcmCathodeLocationSkinBeforOperationMar.m_ClrDST = System.Drawing.Color.Red;
            this.dcmCathodeLocationSkinBeforOperationMar.MappingName = "损伤";
            this.dcmCathodeLocationSkinBeforOperationMar.NullText = "";
            this.dcmCathodeLocationSkinBeforOperationMar.NullValue = null;
            this.dcmCathodeLocationSkinBeforOperationMar.Width = 40;
            // 
            // dcmCathodeLocationSkinBeforSign
            // 
            this.dcmCathodeLocationSkinBeforSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmCathodeLocationSkinBeforSign.HeaderText = "签名";
            this.dcmCathodeLocationSkinBeforSign.m_BlnGobleSet = true;
            this.dcmCathodeLocationSkinBeforSign.m_BlnUnderLineDST = false;
            this.dcmCathodeLocationSkinBeforSign.MappingName = "签名";
            this.dcmCathodeLocationSkinBeforSign.NullText = "";
            this.dcmCathodeLocationSkinBeforSign.Width = 60;
            // 
            // dcmCathodeLocationSkinBeforSignTime
            // 
            this.dcmCathodeLocationSkinBeforSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmCathodeLocationSkinBeforSignTime.HeaderText = "日期";
            this.dcmCathodeLocationSkinBeforSignTime.m_BlnGobleSet = true;
            this.dcmCathodeLocationSkinBeforSignTime.m_BlnUnderLineDST = false;
            this.dcmCathodeLocationSkinBeforSignTime.MappingName = "日期";
            this.dcmCathodeLocationSkinBeforSignTime.NullText = "";
            this.dcmCathodeLocationSkinBeforSignTime.Width = 145;
            // 
            // dtgCathodeLocationAfterOperationSkin
            // 
            this.dtgCathodeLocationAfterOperationSkin.BackColor = System.Drawing.Color.White;
            this.dtgCathodeLocationAfterOperationSkin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgCathodeLocationAfterOperationSkin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCathodeLocationAfterOperationSkin.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgCathodeLocationAfterOperationSkin.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgCathodeLocationAfterOperationSkin.CaptionText = "术后负极板部位皮肤";
            this.dtgCathodeLocationAfterOperationSkin.DataMember = "";
            this.dtgCathodeLocationAfterOperationSkin.FlatMode = true;
            this.dtgCathodeLocationAfterOperationSkin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgCathodeLocationAfterOperationSkin.ForeColor = System.Drawing.Color.Black;
            this.dtgCathodeLocationAfterOperationSkin.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgCathodeLocationAfterOperationSkin.Location = new System.Drawing.Point(168, -172);
            this.dtgCathodeLocationAfterOperationSkin.Name = "dtgCathodeLocationAfterOperationSkin";
            this.dtgCathodeLocationAfterOperationSkin.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgCathodeLocationAfterOperationSkin.RowHeaderWidth = 10;
            this.dtgCathodeLocationAfterOperationSkin.Size = new System.Drawing.Size(4, 37);
            this.dtgCathodeLocationAfterOperationSkin.TabIndex = 5000;
            this.dtgCathodeLocationAfterOperationSkin.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbCathodeLocationAfterOperationSkinStyle});
            // 
            // dtbCathodeLocationAfterOperationSkinStyle
            // 
            this.dtbCathodeLocationAfterOperationSkinStyle.AllowSorting = false;
            this.dtbCathodeLocationAfterOperationSkinStyle.DataGrid = this.dtgCathodeLocationAfterOperationSkin;
            this.dtbCathodeLocationAfterOperationSkinStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmCathodeLocationSkinAfterOperationFull,
            this.dcmCathodeLocationSkinAfterOperationMar,
            this.dcmCathodeLocationSkinAfterOperationSign,
            this.dcmCathodeLocationSkinAfterOperationSignTime});
            this.dtbCathodeLocationAfterOperationSkinStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbCathodeLocationAfterOperationSkinStyle.MappingName = "CathodeLocationAfterOperationSkin";
            // 
            // dcmCathodeLocationSkinAfterOperationFull
            // 
            this.dcmCathodeLocationSkinAfterOperationFull.HeaderText = "完好";
            this.dcmCathodeLocationSkinAfterOperationFull.m_ClrDST = System.Drawing.Color.Red;
            this.dcmCathodeLocationSkinAfterOperationFull.MappingName = "完好";
            this.dcmCathodeLocationSkinAfterOperationFull.NullText = "";
            this.dcmCathodeLocationSkinAfterOperationFull.NullValue = null;
            this.dcmCathodeLocationSkinAfterOperationFull.Width = 35;
            // 
            // dcmCathodeLocationSkinAfterOperationMar
            // 
            this.dcmCathodeLocationSkinAfterOperationMar.HeaderText = "损伤";
            this.dcmCathodeLocationSkinAfterOperationMar.m_ClrDST = System.Drawing.Color.Red;
            this.dcmCathodeLocationSkinAfterOperationMar.MappingName = "损伤";
            this.dcmCathodeLocationSkinAfterOperationMar.NullText = "";
            this.dcmCathodeLocationSkinAfterOperationMar.NullValue = null;
            this.dcmCathodeLocationSkinAfterOperationMar.Width = 35;
            // 
            // dcmCathodeLocationSkinAfterOperationSign
            // 
            this.dcmCathodeLocationSkinAfterOperationSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmCathodeLocationSkinAfterOperationSign.HeaderText = "签名";
            this.dcmCathodeLocationSkinAfterOperationSign.m_BlnGobleSet = true;
            this.dcmCathodeLocationSkinAfterOperationSign.m_BlnUnderLineDST = false;
            this.dcmCathodeLocationSkinAfterOperationSign.MappingName = "签名";
            this.dcmCathodeLocationSkinAfterOperationSign.NullText = "";
            this.dcmCathodeLocationSkinAfterOperationSign.Width = 60;
            // 
            // dcmCathodeLocationSkinAfterOperationSignTime
            // 
            this.dcmCathodeLocationSkinAfterOperationSignTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmCathodeLocationSkinAfterOperationSignTime.HeaderText = "日期";
            this.dcmCathodeLocationSkinAfterOperationSignTime.m_BlnGobleSet = true;
            this.dcmCathodeLocationSkinAfterOperationSignTime.m_BlnUnderLineDST = false;
            this.dcmCathodeLocationSkinAfterOperationSignTime.MappingName = "日期";
            this.dcmCathodeLocationSkinAfterOperationSignTime.NullText = "";
            this.dcmCathodeLocationSkinAfterOperationSignTime.Width = 145;
            // 
            // dtgFoley
            // 
            this.dtgFoley.BackColor = System.Drawing.Color.White;
            this.dtgFoley.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFoley.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgFoley.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFoley.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgFoley.CaptionText = "停留Foley氏尿管";
            this.dtgFoley.DataMember = "";
            this.dtgFoley.FlatMode = true;
            this.dtgFoley.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgFoley.ForeColor = System.Drawing.Color.Black;
            this.dtgFoley.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgFoley.Location = new System.Drawing.Point(360, -176);
            this.dtgFoley.Name = "dtgFoley";
            this.dtgFoley.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgFoley.RowHeaderWidth = 10;
            this.dtgFoley.Size = new System.Drawing.Size(4, 37);
            this.dtgFoley.TabIndex = 5000;
            this.dtgFoley.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbFoleyStyle});
            // 
            // dtbFoleyStyle
            // 
            this.dtbFoleyStyle.AllowSorting = false;
            this.dtbFoleyStyle.DataGrid = this.dtgFoley;
            this.dtbFoleyStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmFoleySickroom,
            this.dcmFoleyOperationRoom,
            this.dcmFoleyDoubleAntrum,
            this.dcmFoleyThreeAntrum,
            this.dcmFoleyOther,
            this.dcmFoleyOtherContent,
            this.dcmFoleySign,
            this.dcmFoleySignTime});
            this.dtbFoleyStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbFoleyStyle.MappingName = "Foley";
            // 
            // dcmFoleySickroom
            // 
            this.dcmFoleySickroom.HeaderText = "病房带来";
            this.dcmFoleySickroom.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFoleySickroom.MappingName = "病房带来";
            this.dcmFoleySickroom.NullText = "";
            this.dcmFoleySickroom.NullValue = null;
            this.dcmFoleySickroom.Width = 90;
            // 
            // dcmFoleyOperationRoom
            // 
            this.dcmFoleyOperationRoom.HeaderText = "手术室";
            this.dcmFoleyOperationRoom.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFoleyOperationRoom.MappingName = "手术室";
            this.dcmFoleyOperationRoom.NullText = "";
            this.dcmFoleyOperationRoom.NullValue = null;
            this.dcmFoleyOperationRoom.Width = 80;
            // 
            // dcmFoleyDoubleAntrum
            // 
            this.dcmFoleyDoubleAntrum.HeaderText = "双腔";
            this.dcmFoleyDoubleAntrum.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFoleyDoubleAntrum.MappingName = "双腔";
            this.dcmFoleyDoubleAntrum.NullText = "";
            this.dcmFoleyDoubleAntrum.NullValue = null;
            this.dcmFoleyDoubleAntrum.Width = 60;
            // 
            // dcmFoleyThreeAntrum
            // 
            this.dcmFoleyThreeAntrum.HeaderText = "三腔";
            this.dcmFoleyThreeAntrum.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFoleyThreeAntrum.MappingName = "三腔";
            this.dcmFoleyThreeAntrum.NullText = "";
            this.dcmFoleyThreeAntrum.NullValue = null;
            this.dcmFoleyThreeAntrum.Width = 60;
            // 
            // dcmFoleyOther
            // 
            this.dcmFoleyOther.HeaderText = "其他";
            this.dcmFoleyOther.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFoleyOther.MappingName = "其他";
            this.dcmFoleyOther.NullText = "";
            this.dcmFoleyOther.NullValue = null;
            this.dcmFoleyOther.Width = 35;
            // 
            // dcmFoleyOtherContent
            // 
            this.dcmFoleyOtherContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFoleyOtherContent.HeaderText = "内容";
            this.dcmFoleyOtherContent.m_BlnGobleSet = true;
            this.dcmFoleyOtherContent.m_BlnUnderLineDST = false;
            this.dcmFoleyOtherContent.MappingName = "内容";
            this.dcmFoleyOtherContent.NullText = "";
            this.dcmFoleyOtherContent.Width = 220;
            // 
            // dcmFoleySign
            // 
            this.dcmFoleySign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFoleySign.HeaderText = "签名";
            this.dcmFoleySign.m_BlnGobleSet = true;
            this.dcmFoleySign.m_BlnUnderLineDST = false;
            this.dcmFoleySign.MappingName = "签名";
            this.dcmFoleySign.NullText = "";
            this.dcmFoleySign.Width = 80;
            // 
            // dcmFoleySignTime
            // 
            this.dcmFoleySignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFoleySignTime.HeaderText = "日期";
            this.dcmFoleySignTime.m_BlnGobleSet = true;
            this.dcmFoleySignTime.m_BlnUnderLineDST = false;
            this.dcmFoleySignTime.MappingName = "日期";
            this.dcmFoleySignTime.NullText = "";
            this.dcmFoleySignTime.Width = 145;
            // 
            // dtgStomach
            // 
            this.dtgStomach.BackColor = System.Drawing.Color.White;
            this.dtgStomach.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgStomach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgStomach.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgStomach.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgStomach.CaptionText = "停留胃管";
            this.dtgStomach.DataMember = "";
            this.dtgStomach.FlatMode = true;
            this.dtgStomach.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgStomach.ForeColor = System.Drawing.Color.Black;
            this.dtgStomach.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgStomach.Location = new System.Drawing.Point(48, -160);
            this.dtgStomach.Name = "dtgStomach";
            this.dtgStomach.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgStomach.RowHeaderWidth = 10;
            this.dtgStomach.Size = new System.Drawing.Size(4, 37);
            this.dtgStomach.TabIndex = 5000;
            this.dtgStomach.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbStomachStyle});
            // 
            // dtbStomachStyle
            // 
            this.dtbStomachStyle.AllowSorting = false;
            this.dtbStomachStyle.DataGrid = this.dtgStomach;
            this.dtbStomachStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmStomachSickroom,
            this.dcmStomachOprationRoom,
            this.dcmStomachSign,
            this.dcmStomachSingTime});
            this.dtbStomachStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbStomachStyle.MappingName = "Stomach";
            // 
            // dcmStomachSickroom
            // 
            this.dcmStomachSickroom.HeaderText = "病房带来";
            this.dcmStomachSickroom.m_ClrDST = System.Drawing.Color.Red;
            this.dcmStomachSickroom.MappingName = "病房带来";
            this.dcmStomachSickroom.NullText = "";
            this.dcmStomachSickroom.NullValue = null;
            this.dcmStomachSickroom.Width = 68;
            // 
            // dcmStomachOprationRoom
            // 
            this.dcmStomachOprationRoom.HeaderText = "手术室";
            this.dcmStomachOprationRoom.m_ClrDST = System.Drawing.Color.Red;
            this.dcmStomachOprationRoom.MappingName = "手术室";
            this.dcmStomachOprationRoom.NullText = "";
            this.dcmStomachOprationRoom.NullValue = null;
            this.dcmStomachOprationRoom.Width = 68;
            // 
            // dcmStomachSign
            // 
            this.dcmStomachSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmStomachSign.HeaderText = "签名";
            this.dcmStomachSign.m_BlnGobleSet = true;
            this.dcmStomachSign.m_BlnUnderLineDST = false;
            this.dcmStomachSign.MappingName = "签名";
            this.dcmStomachSign.NullText = "";
            this.dcmStomachSign.Width = 50;
            // 
            // dcmStomachSingTime
            // 
            this.dcmStomachSingTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmStomachSingTime.HeaderText = "日期";
            this.dcmStomachSingTime.m_BlnGobleSet = true;
            this.dcmStomachSingTime.m_BlnUnderLineDST = false;
            this.dcmStomachSingTime.MappingName = "日期";
            this.dcmStomachSingTime.NullText = "";
            this.dcmStomachSingTime.Width = 145;
            // 
            // txtRecordContent
            // 
            this.txtRecordContent.AccessibleDescription = "护理记录";
            this.txtRecordContent.BackColor = System.Drawing.Color.White;
            this.txtRecordContent.ForeColor = System.Drawing.Color.Black;
            this.txtRecordContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRecordContent.Location = new System.Drawing.Point(10, 236);
            this.txtRecordContent.m_BlnIgnoreUserInfo = false;
            this.txtRecordContent.m_BlnPartControl = false;
            this.txtRecordContent.m_BlnReadOnly = false;
            this.txtRecordContent.m_BlnUnderLineDST = false;
            this.txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtRecordContent.m_IntCanModifyTime = 6;
            this.txtRecordContent.m_IntPartControlLength = 0;
            this.txtRecordContent.m_IntPartControlStartIndex = 0;
            this.txtRecordContent.m_StrUserID = "";
            this.txtRecordContent.m_StrUserName = "";
            this.txtRecordContent.Name = "txtRecordContent";
            this.txtRecordContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtRecordContent.Size = new System.Drawing.Size(722, 120);
            this.txtRecordContent.TabIndex = 1290;
            this.txtRecordContent.Text = "";
            // 
            // dtgUpStyptic
            // 
            this.dtgUpStyptic.BackColor = System.Drawing.Color.White;
            this.dtgUpStyptic.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgUpStyptic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgUpStyptic.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgUpStyptic.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgUpStyptic.CaptionText = "气压止血肢体位置一";
            this.dtgUpStyptic.DataMember = "";
            this.dtgUpStyptic.FlatMode = true;
            this.dtgUpStyptic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgUpStyptic.ForeColor = System.Drawing.Color.Black;
            this.dtgUpStyptic.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgUpStyptic.Location = new System.Drawing.Point(360, -156);
            this.dtgUpStyptic.Name = "dtgUpStyptic";
            this.dtgUpStyptic.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgUpStyptic.RowHeaderWidth = 10;
            this.dtgUpStyptic.Size = new System.Drawing.Size(4, 37);
            this.dtgUpStyptic.TabIndex = 5000;
            this.dtgUpStyptic.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbUpStypticStyle});
            // 
            // dtbUpStypticStyle
            // 
            this.dtbUpStypticStyle.AllowSorting = false;
            this.dtbUpStypticStyle.DataGrid = this.dtgUpStyptic;
            this.dtbUpStypticStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmUpForearm,
            this.dcmUpThigh,
            this.dcmUpRight,
            this.dcmUpLeft,
            this.dcmUpPuffDateTime,
            this.dcmUpDeflateDateTime,
            this.dcmUpTotalDateTime,
            this.dcmUpPress,
            this.dcmUpStypticSign,
            this.dcmUpStypticSignTime});
            this.dtbUpStypticStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbUpStypticStyle.MappingName = "UpStyptic";
            // 
            // dcmUpForearm
            // 
            this.dcmUpForearm.HeaderText = "前臂";
            this.dcmUpForearm.m_ClrDST = System.Drawing.Color.Red;
            this.dcmUpForearm.MappingName = "前臂";
            this.dcmUpForearm.NullText = "";
            this.dcmUpForearm.NullValue = null;
            this.dcmUpForearm.Width = 40;
            // 
            // dcmUpThigh
            // 
            this.dcmUpThigh.HeaderText = "大腿";
            this.dcmUpThigh.m_ClrDST = System.Drawing.Color.Red;
            this.dcmUpThigh.MappingName = "大腿";
            this.dcmUpThigh.NullText = "";
            this.dcmUpThigh.NullValue = null;
            this.dcmUpThigh.Width = 40;
            // 
            // dcmUpRight
            // 
            this.dcmUpRight.HeaderText = "右";
            this.dcmUpRight.m_ClrDST = System.Drawing.Color.Red;
            this.dcmUpRight.MappingName = "右";
            this.dcmUpRight.NullText = "";
            this.dcmUpRight.NullValue = null;
            this.dcmUpRight.Width = 30;
            // 
            // dcmUpLeft
            // 
            this.dcmUpLeft.HeaderText = "左";
            this.dcmUpLeft.m_ClrDST = System.Drawing.Color.Red;
            this.dcmUpLeft.MappingName = "左";
            this.dcmUpLeft.NullText = "";
            this.dcmUpLeft.NullValue = null;
            this.dcmUpLeft.Width = 30;
            // 
            // dcmUpPuffDateTime
            // 
            this.dcmUpPuffDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpPuffDateTime.HeaderText = "充气时间";
            this.dcmUpPuffDateTime.m_BlnGobleSet = true;
            this.dcmUpPuffDateTime.m_BlnUnderLineDST = false;
            this.dcmUpPuffDateTime.MappingName = "充气时间";
            this.dcmUpPuffDateTime.NullText = "";
            this.dcmUpPuffDateTime.Width = 80;
            // 
            // dcmUpDeflateDateTime
            // 
            this.dcmUpDeflateDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpDeflateDateTime.HeaderText = "放气时间";
            this.dcmUpDeflateDateTime.m_BlnGobleSet = true;
            this.dcmUpDeflateDateTime.m_BlnUnderLineDST = false;
            this.dcmUpDeflateDateTime.MappingName = "放气时间";
            this.dcmUpDeflateDateTime.NullText = "";
            this.dcmUpDeflateDateTime.Width = 80;
            // 
            // dcmUpTotalDateTime
            // 
            this.dcmUpTotalDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpTotalDateTime.HeaderText = "总时间（分）";
            this.dcmUpTotalDateTime.m_BlnGobleSet = true;
            this.dcmUpTotalDateTime.m_BlnUnderLineDST = false;
            this.dcmUpTotalDateTime.MappingName = "总时间（分）";
            this.dcmUpTotalDateTime.NullText = "";
            this.dcmUpTotalDateTime.Width = 120;
            // 
            // dcmUpPress
            // 
            this.dcmUpPress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpPress.HeaderText = "压力";
            this.dcmUpPress.m_BlnGobleSet = true;
            this.dcmUpPress.m_BlnUnderLineDST = false;
            this.dcmUpPress.MappingName = "压力";
            this.dcmUpPress.NullText = "";
            this.dcmUpPress.Width = 80;
            // 
            // dcmUpStypticSign
            // 
            this.dcmUpStypticSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpStypticSign.HeaderText = "签名";
            this.dcmUpStypticSign.m_BlnGobleSet = true;
            this.dcmUpStypticSign.m_BlnUnderLineDST = false;
            this.dcmUpStypticSign.MappingName = "签名";
            this.dcmUpStypticSign.NullText = "";
            this.dcmUpStypticSign.Width = 60;
            // 
            // dcmUpStypticSignTime
            // 
            this.dcmUpStypticSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmUpStypticSignTime.HeaderText = "日期";
            this.dcmUpStypticSignTime.m_BlnGobleSet = true;
            this.dcmUpStypticSignTime.m_BlnUnderLineDST = false;
            this.dcmUpStypticSignTime.MappingName = "日期";
            this.dcmUpStypticSignTime.NullText = "";
            this.dcmUpStypticSignTime.Width = 145;
            // 
            // dtbDownStypticStyle
            // 
            this.dtbDownStypticStyle.AllowSorting = false;
            this.dtbDownStypticStyle.DataGrid = this.dtgDownStyptic;
            this.dtbDownStypticStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmDownForearm,
            this.dcmDownThigh,
            this.dcmDownRight,
            this.dcmDownLeft,
            this.DownPuffDateTime,
            this.dcmDownDeflateDateTime,
            this.dcmDownTotalDateTime,
            this.dcmDownPress,
            this.dcmDownStypticSign,
            this.dcmDownStypticSignTime});
            this.dtbDownStypticStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbDownStypticStyle.MappingName = "DownStyptic";
            // 
            // dtgDownStyptic
            // 
            this.dtgDownStyptic.BackColor = System.Drawing.Color.White;
            this.dtgDownStyptic.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgDownStyptic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDownStyptic.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgDownStyptic.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgDownStyptic.CaptionText = "气压止血肢体位置二";
            this.dtgDownStyptic.DataMember = "";
            this.dtgDownStyptic.FlatMode = true;
            this.dtgDownStyptic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgDownStyptic.ForeColor = System.Drawing.Color.Black;
            this.dtgDownStyptic.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgDownStyptic.Location = new System.Drawing.Point(12, 0);
            this.dtgDownStyptic.Name = "dtgDownStyptic";
            this.dtgDownStyptic.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgDownStyptic.RowHeaderWidth = 10;
            this.dtgDownStyptic.Size = new System.Drawing.Size(4, 4);
            this.dtgDownStyptic.TabIndex = 5000;
            this.dtgDownStyptic.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbDownStypticStyle});
            // 
            // dcmDownForearm
            // 
            this.dcmDownForearm.HeaderText = "前臂";
            this.dcmDownForearm.m_ClrDST = System.Drawing.Color.Red;
            this.dcmDownForearm.MappingName = "前臂";
            this.dcmDownForearm.NullText = "";
            this.dcmDownForearm.NullValue = null;
            this.dcmDownForearm.Width = 40;
            // 
            // dcmDownThigh
            // 
            this.dcmDownThigh.HeaderText = "大腿";
            this.dcmDownThigh.m_ClrDST = System.Drawing.Color.Red;
            this.dcmDownThigh.MappingName = "大腿";
            this.dcmDownThigh.NullText = "";
            this.dcmDownThigh.NullValue = null;
            this.dcmDownThigh.Width = 40;
            // 
            // dcmDownRight
            // 
            this.dcmDownRight.HeaderText = "右";
            this.dcmDownRight.m_ClrDST = System.Drawing.Color.Red;
            this.dcmDownRight.MappingName = "右";
            this.dcmDownRight.NullText = "";
            this.dcmDownRight.NullValue = null;
            this.dcmDownRight.Width = 30;
            // 
            // dcmDownLeft
            // 
            this.dcmDownLeft.HeaderText = "左";
            this.dcmDownLeft.m_ClrDST = System.Drawing.Color.Red;
            this.dcmDownLeft.MappingName = "左";
            this.dcmDownLeft.NullText = "";
            this.dcmDownLeft.NullValue = null;
            this.dcmDownLeft.Width = 30;
            // 
            // DownPuffDateTime
            // 
            this.DownPuffDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DownPuffDateTime.HeaderText = "充气时间";
            this.DownPuffDateTime.m_BlnGobleSet = true;
            this.DownPuffDateTime.m_BlnUnderLineDST = false;
            this.DownPuffDateTime.MappingName = "充气时间";
            this.DownPuffDateTime.NullText = "";
            this.DownPuffDateTime.Width = 75;
            // 
            // dcmDownDeflateDateTime
            // 
            this.dcmDownDeflateDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDownDeflateDateTime.HeaderText = "放气时间";
            this.dcmDownDeflateDateTime.m_BlnGobleSet = true;
            this.dcmDownDeflateDateTime.m_BlnUnderLineDST = false;
            this.dcmDownDeflateDateTime.MappingName = "放气时间";
            this.dcmDownDeflateDateTime.NullText = "";
            this.dcmDownDeflateDateTime.Width = 75;
            // 
            // dcmDownTotalDateTime
            // 
            this.dcmDownTotalDateTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDownTotalDateTime.HeaderText = "总时间（分）";
            this.dcmDownTotalDateTime.m_BlnGobleSet = true;
            this.dcmDownTotalDateTime.m_BlnUnderLineDST = false;
            this.dcmDownTotalDateTime.MappingName = "总时间（分）";
            this.dcmDownTotalDateTime.NullText = "";
            this.dcmDownTotalDateTime.Width = 120;
            // 
            // dcmDownPress
            // 
            this.dcmDownPress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDownPress.HeaderText = "压力";
            this.dcmDownPress.m_BlnGobleSet = true;
            this.dcmDownPress.m_BlnUnderLineDST = false;
            this.dcmDownPress.MappingName = "压力";
            this.dcmDownPress.NullText = "";
            this.dcmDownPress.Width = 75;
            // 
            // dcmDownStypticSign
            // 
            this.dcmDownStypticSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDownStypticSign.HeaderText = "签名";
            this.dcmDownStypticSign.m_BlnGobleSet = true;
            this.dcmDownStypticSign.m_BlnUnderLineDST = false;
            this.dcmDownStypticSign.MappingName = "签名";
            this.dcmDownStypticSign.NullText = "";
            this.dcmDownStypticSign.Width = 80;
            // 
            // dcmDownStypticSignTime
            // 
            this.dcmDownStypticSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmDownStypticSignTime.HeaderText = "日期";
            this.dcmDownStypticSignTime.m_BlnGobleSet = true;
            this.dcmDownStypticSignTime.m_BlnUnderLineDST = false;
            this.dcmDownStypticSignTime.MappingName = "日期";
            this.dcmDownStypticSignTime.NullText = "";
            this.dcmDownStypticSignTime.Width = 145;
            // 
            // gpbSences
            // 
            this.gpbSences.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSences.Controls.Add(this.rdbSencesSleep);
            this.gpbSences.Controls.Add(this.rdbSencesComa);
            this.gpbSences.Controls.Add(this.rdbSencesClear);
            this.gpbSences.Location = new System.Drawing.Point(10, 49);
            this.gpbSences.Name = "gpbSences";
            this.gpbSences.Size = new System.Drawing.Size(213, 52);
            this.gpbSences.TabIndex = 80;
            this.gpbSences.TabStop = false;
            this.gpbSences.Text = "神志";
            // 
            // rdbSencesSleep
            // 
            this.rdbSencesSleep.Location = new System.Drawing.Point(61, 20);
            this.rdbSencesSleep.Name = "rdbSencesSleep";
            this.rdbSencesSleep.Size = new System.Drawing.Size(59, 24);
            this.rdbSencesSleep.TabIndex = 100;
            this.rdbSencesSleep.Text = "嗜睡";
            // 
            // rdbSencesComa
            // 
            this.rdbSencesComa.Location = new System.Drawing.Point(120, 20);
            this.rdbSencesComa.Name = "rdbSencesComa";
            this.rdbSencesComa.Size = new System.Drawing.Size(57, 24);
            this.rdbSencesComa.TabIndex = 110;
            this.rdbSencesComa.Text = "昏迷";
            // 
            // rdbSencesClear
            // 
            this.rdbSencesClear.Checked = true;
            this.rdbSencesClear.Location = new System.Drawing.Point(6, 20);
            this.rdbSencesClear.Name = "rdbSencesClear";
            this.rdbSencesClear.Size = new System.Drawing.Size(63, 24);
            this.rdbSencesClear.TabIndex = 90;
            this.rdbSencesClear.TabStop = true;
            this.rdbSencesClear.Text = "清醒";
            // 
            // gpbAllergic
            // 
            this.gpbAllergic.BackColor = System.Drawing.SystemColors.Control;
            this.gpbAllergic.Controls.Add(this.rdbHaveNotAllergic);
            this.gpbAllergic.Controls.Add(this.rdbHaveAllergic);
            this.gpbAllergic.Controls.Add(this.txtAllergicContent);
            this.gpbAllergic.Controls.Add(this.radioButton1);
            this.gpbAllergic.Location = new System.Drawing.Point(229, 48);
            this.gpbAllergic.Name = "gpbAllergic";
            this.gpbAllergic.Size = new System.Drawing.Size(345, 52);
            this.gpbAllergic.TabIndex = 115;
            this.gpbAllergic.TabStop = false;
            this.gpbAllergic.Text = "药物过敏史";
            // 
            // rdbHaveNotAllergic
            // 
            this.rdbHaveNotAllergic.Checked = true;
            this.rdbHaveNotAllergic.Location = new System.Drawing.Point(24, 21);
            this.rdbHaveNotAllergic.Name = "rdbHaveNotAllergic";
            this.rdbHaveNotAllergic.Size = new System.Drawing.Size(48, 24);
            this.rdbHaveNotAllergic.TabIndex = 120;
            this.rdbHaveNotAllergic.TabStop = true;
            this.rdbHaveNotAllergic.Text = "无";
            this.rdbHaveNotAllergic.CheckedChanged += new System.EventHandler(this.rdbAllergic_CheckedChanged);
            // 
            // rdbHaveAllergic
            // 
            this.rdbHaveAllergic.Location = new System.Drawing.Point(78, 21);
            this.rdbHaveAllergic.Name = "rdbHaveAllergic";
            this.rdbHaveAllergic.Size = new System.Drawing.Size(32, 23);
            this.rdbHaveAllergic.TabIndex = 130;
            this.rdbHaveAllergic.Text = "有";
            this.rdbHaveAllergic.CheckedChanged += new System.EventHandler(this.rdbAllergic_CheckedChanged);
            // 
            // txtAllergicContent
            // 
            this.txtAllergicContent.AccessibleDescription = "药物过敏史";
            this.txtAllergicContent.BackColor = System.Drawing.Color.White;
            this.txtAllergicContent.ForeColor = System.Drawing.Color.Black;
            this.txtAllergicContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAllergicContent.Location = new System.Drawing.Point(121, 23);
            this.txtAllergicContent.m_BlnIgnoreUserInfo = false;
            this.txtAllergicContent.m_BlnPartControl = false;
            this.txtAllergicContent.m_BlnReadOnly = false;
            this.txtAllergicContent.m_BlnUnderLineDST = false;
            this.txtAllergicContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtAllergicContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAllergicContent.m_IntCanModifyTime = 6;
            this.txtAllergicContent.m_IntPartControlLength = 0;
            this.txtAllergicContent.m_IntPartControlStartIndex = 0;
            this.txtAllergicContent.m_StrUserID = "";
            this.txtAllergicContent.m_StrUserName = "";
            this.txtAllergicContent.Multiline = false;
            this.txtAllergicContent.Name = "txtAllergicContent";
            this.txtAllergicContent.Size = new System.Drawing.Size(213, 20);
            this.txtAllergicContent.TabIndex = 140;
            this.txtAllergicContent.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 24);
            this.radioButton1.TabIndex = 120;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "无";
            // 
            // gpbOperationLocation
            // 
            this.gpbOperationLocation.BackColor = System.Drawing.SystemColors.Control;
            this.gpbOperationLocation.Controls.Add(this.txtOtherOperationLocation);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationPA);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationOther);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationSide);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationHypothyroid);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationOnHisBack);
            this.gpbOperationLocation.Controls.Add(this.rdbOperationLocationParaplegic);
            this.gpbOperationLocation.Location = new System.Drawing.Point(10, 112);
            this.gpbOperationLocation.Name = "gpbOperationLocation";
            this.gpbOperationLocation.Size = new System.Drawing.Size(622, 52);
            this.gpbOperationLocation.TabIndex = 150;
            this.gpbOperationLocation.TabStop = false;
            this.gpbOperationLocation.Text = "手术体位";
            // 
            // txtOtherOperationLocation
            // 
            this.txtOtherOperationLocation.AccessibleDescription = "手术体位";
            this.txtOtherOperationLocation.BackColor = System.Drawing.Color.White;
            this.txtOtherOperationLocation.ForeColor = System.Drawing.Color.Black;
            this.txtOtherOperationLocation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOtherOperationLocation.Location = new System.Drawing.Point(442, 26);
            this.txtOtherOperationLocation.m_BlnIgnoreUserInfo = false;
            this.txtOtherOperationLocation.m_BlnPartControl = false;
            this.txtOtherOperationLocation.m_BlnReadOnly = false;
            this.txtOtherOperationLocation.m_BlnUnderLineDST = false;
            this.txtOtherOperationLocation.m_ClrDST = System.Drawing.Color.Red;
            this.txtOtherOperationLocation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOtherOperationLocation.m_IntCanModifyTime = 6;
            this.txtOtherOperationLocation.m_IntPartControlLength = 0;
            this.txtOtherOperationLocation.m_IntPartControlStartIndex = 0;
            this.txtOtherOperationLocation.m_StrUserID = "";
            this.txtOtherOperationLocation.m_StrUserName = "";
            this.txtOtherOperationLocation.Multiline = false;
            this.txtOtherOperationLocation.Name = "txtOtherOperationLocation";
            this.txtOtherOperationLocation.Size = new System.Drawing.Size(168, 20);
            this.txtOtherOperationLocation.TabIndex = 220;
            this.txtOtherOperationLocation.Text = "";
            // 
            // rdbOperationLocationPA
            // 
            this.rdbOperationLocationPA.Location = new System.Drawing.Point(152, 24);
            this.rdbOperationLocationPA.Name = "rdbOperationLocationPA";
            this.rdbOperationLocationPA.Size = new System.Drawing.Size(68, 24);
            this.rdbOperationLocationPA.TabIndex = 180;
            this.rdbOperationLocationPA.Text = "俯卧位";
            this.rdbOperationLocationPA.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // rdbOperationLocationOther
            // 
            this.rdbOperationLocationOther.Location = new System.Drawing.Point(388, 24);
            this.rdbOperationLocationOther.Name = "rdbOperationLocationOther";
            this.rdbOperationLocationOther.Size = new System.Drawing.Size(64, 24);
            this.rdbOperationLocationOther.TabIndex = 210;
            this.rdbOperationLocationOther.Text = "其他";
            this.rdbOperationLocationOther.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // rdbOperationLocationSide
            // 
            this.rdbOperationLocationSide.Location = new System.Drawing.Point(80, 24);
            this.rdbOperationLocationSide.Name = "rdbOperationLocationSide";
            this.rdbOperationLocationSide.Size = new System.Drawing.Size(68, 24);
            this.rdbOperationLocationSide.TabIndex = 170;
            this.rdbOperationLocationSide.Text = "侧卧位";
            this.rdbOperationLocationSide.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // rdbOperationLocationHypothyroid
            // 
            this.rdbOperationLocationHypothyroid.Location = new System.Drawing.Point(300, 24);
            this.rdbOperationLocationHypothyroid.Name = "rdbOperationLocationHypothyroid";
            this.rdbOperationLocationHypothyroid.Size = new System.Drawing.Size(84, 24);
            this.rdbOperationLocationHypothyroid.TabIndex = 200;
            this.rdbOperationLocationHypothyroid.Text = "甲状腺位";
            this.rdbOperationLocationHypothyroid.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // rdbOperationLocationOnHisBack
            // 
            this.rdbOperationLocationOnHisBack.Checked = true;
            this.rdbOperationLocationOnHisBack.Location = new System.Drawing.Point(8, 24);
            this.rdbOperationLocationOnHisBack.Name = "rdbOperationLocationOnHisBack";
            this.rdbOperationLocationOnHisBack.Size = new System.Drawing.Size(68, 24);
            this.rdbOperationLocationOnHisBack.TabIndex = 160;
            this.rdbOperationLocationOnHisBack.TabStop = true;
            this.rdbOperationLocationOnHisBack.Text = "仰卧位";
            this.rdbOperationLocationOnHisBack.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // rdbOperationLocationParaplegic
            // 
            this.rdbOperationLocationParaplegic.Location = new System.Drawing.Point(228, 24);
            this.rdbOperationLocationParaplegic.Name = "rdbOperationLocationParaplegic";
            this.rdbOperationLocationParaplegic.Size = new System.Drawing.Size(68, 24);
            this.rdbOperationLocationParaplegic.TabIndex = 190;
            this.rdbOperationLocationParaplegic.Text = "截石位";
            this.rdbOperationLocationParaplegic.CheckedChanged += new System.EventHandler(this.rdbOperationLocationOnHisBack_CheckedChanged);
            // 
            // gpbElectKnife
            // 
            this.gpbElectKnife.BackColor = System.Drawing.SystemColors.Control;
            this.gpbElectKnife.Controls.Add(this.txtElectKnifeModel);
            this.gpbElectKnife.Controls.Add(this.rdbHaveNotElectKnife);
            this.gpbElectKnife.Controls.Add(this.rdbHaveUsedElectKnife);
            this.gpbElectKnife.Controls.Add(this.lblDoubleElectKnifemode);
            this.gpbElectKnife.Location = new System.Drawing.Point(10, 10);
            this.gpbElectKnife.Name = "gpbElectKnife";
            this.gpbElectKnife.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpbElectKnife.Size = new System.Drawing.Size(226, 48);
            this.gpbElectKnife.TabIndex = 290;
            this.gpbElectKnife.TabStop = false;
            this.gpbElectKnife.Text = "使用电刀";
            // 
            // txtElectKnifeModel
            // 
            this.txtElectKnifeModel.AccessibleDescription = "使用电刀-型号";
            this.txtElectKnifeModel.BackColor = System.Drawing.Color.White;
            this.txtElectKnifeModel.ForeColor = System.Drawing.Color.Black;
            this.txtElectKnifeModel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtElectKnifeModel.Location = new System.Drawing.Point(129, 19);
            this.txtElectKnifeModel.m_BlnIgnoreUserInfo = false;
            this.txtElectKnifeModel.m_BlnPartControl = false;
            this.txtElectKnifeModel.m_BlnReadOnly = false;
            this.txtElectKnifeModel.m_BlnUnderLineDST = false;
            this.txtElectKnifeModel.m_ClrDST = System.Drawing.Color.Red;
            this.txtElectKnifeModel.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtElectKnifeModel.m_IntCanModifyTime = 6;
            this.txtElectKnifeModel.m_IntPartControlLength = 0;
            this.txtElectKnifeModel.m_IntPartControlStartIndex = 0;
            this.txtElectKnifeModel.m_StrUserID = "";
            this.txtElectKnifeModel.m_StrUserName = "";
            this.txtElectKnifeModel.Multiline = false;
            this.txtElectKnifeModel.Name = "txtElectKnifeModel";
            this.txtElectKnifeModel.Size = new System.Drawing.Size(76, 20);
            this.txtElectKnifeModel.TabIndex = 320;
            this.txtElectKnifeModel.Text = "";
            // 
            // rdbHaveNotElectKnife
            // 
            this.rdbHaveNotElectKnife.Checked = true;
            this.rdbHaveNotElectKnife.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbHaveNotElectKnife.Location = new System.Drawing.Point(8, 16);
            this.rdbHaveNotElectKnife.Name = "rdbHaveNotElectKnife";
            this.rdbHaveNotElectKnife.Size = new System.Drawing.Size(32, 24);
            this.rdbHaveNotElectKnife.TabIndex = 300;
            this.rdbHaveNotElectKnife.TabStop = true;
            this.rdbHaveNotElectKnife.Text = "否";
            this.rdbHaveNotElectKnife.CheckedChanged += new System.EventHandler(this.rdbHaveNotElectKnife_CheckedChanged);
            // 
            // rdbHaveUsedElectKnife
            // 
            this.rdbHaveUsedElectKnife.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbHaveUsedElectKnife.Location = new System.Drawing.Point(48, 16);
            this.rdbHaveUsedElectKnife.Name = "rdbHaveUsedElectKnife";
            this.rdbHaveUsedElectKnife.Size = new System.Drawing.Size(32, 24);
            this.rdbHaveUsedElectKnife.TabIndex = 310;
            this.rdbHaveUsedElectKnife.Text = "是";
            this.rdbHaveUsedElectKnife.CheckedChanged += new System.EventHandler(this.rdbHaveNotElectKnife_CheckedChanged);
            // 
            // lblDoubleElectKnifemode
            // 
            this.lblDoubleElectKnifemode.AutoSize = true;
            this.lblDoubleElectKnifemode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoubleElectKnifemode.Location = new System.Drawing.Point(88, 21);
            this.lblDoubleElectKnifemode.Name = "lblDoubleElectKnifemode";
            this.lblDoubleElectKnifemode.Size = new System.Drawing.Size(49, 14);
            this.lblDoubleElectKnifemode.TabIndex = 30003;
            this.lblDoubleElectKnifemode.Text = "型号：";
            // 
            // gpbDoublePole
            // 
            this.gpbDoublePole.BackColor = System.Drawing.SystemColors.Control;
            this.gpbDoublePole.Controls.Add(this.txtCathodeLocation);
            this.gpbDoublePole.Controls.Add(this.txtDoublePoleMode);
            this.gpbDoublePole.Controls.Add(this.label2);
            this.gpbDoublePole.Controls.Add(this.lblDoublePolemode);
            this.gpbDoublePole.Controls.Add(this.rdbHaveNotDoublePole);
            this.gpbDoublePole.Controls.Add(this.rdbHaveDoublePole);
            this.gpbDoublePole.Controls.Add(this.radioButton2);
            this.gpbDoublePole.Location = new System.Drawing.Point(236, 10);
            this.gpbDoublePole.Name = "gpbDoublePole";
            this.gpbDoublePole.Size = new System.Drawing.Size(480, 48);
            this.gpbDoublePole.TabIndex = 330;
            this.gpbDoublePole.TabStop = false;
            this.gpbDoublePole.Text = "双极电凝";
            // 
            // txtCathodeLocation
            // 
            this.txtCathodeLocation.AccessibleDescription = "双极电凝-负极板放置部位";
            this.txtCathodeLocation.BackColor = System.Drawing.Color.White;
            this.txtCathodeLocation.ForeColor = System.Drawing.Color.Black;
            this.txtCathodeLocation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCathodeLocation.Location = new System.Drawing.Point(343, 19);
            this.txtCathodeLocation.m_BlnIgnoreUserInfo = false;
            this.txtCathodeLocation.m_BlnPartControl = false;
            this.txtCathodeLocation.m_BlnReadOnly = false;
            this.txtCathodeLocation.m_BlnUnderLineDST = false;
            this.txtCathodeLocation.m_ClrDST = System.Drawing.Color.Red;
            this.txtCathodeLocation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCathodeLocation.m_IntCanModifyTime = 6;
            this.txtCathodeLocation.m_IntPartControlLength = 0;
            this.txtCathodeLocation.m_IntPartControlStartIndex = 0;
            this.txtCathodeLocation.m_StrUserID = "";
            this.txtCathodeLocation.m_StrUserName = "";
            this.txtCathodeLocation.Multiline = false;
            this.txtCathodeLocation.Name = "txtCathodeLocation";
            this.txtCathodeLocation.Size = new System.Drawing.Size(106, 20);
            this.txtCathodeLocation.TabIndex = 360;
            this.txtCathodeLocation.Text = "";
            // 
            // txtDoublePoleMode
            // 
            this.txtDoublePoleMode.AccessibleDescription = "双极电凝-型号";
            this.txtDoublePoleMode.BackColor = System.Drawing.Color.White;
            this.txtDoublePoleMode.ForeColor = System.Drawing.Color.Black;
            this.txtDoublePoleMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDoublePoleMode.Location = new System.Drawing.Point(138, 19);
            this.txtDoublePoleMode.m_BlnIgnoreUserInfo = false;
            this.txtDoublePoleMode.m_BlnPartControl = false;
            this.txtDoublePoleMode.m_BlnReadOnly = false;
            this.txtDoublePoleMode.m_BlnUnderLineDST = false;
            this.txtDoublePoleMode.m_ClrDST = System.Drawing.Color.Red;
            this.txtDoublePoleMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDoublePoleMode.m_IntCanModifyTime = 6;
            this.txtDoublePoleMode.m_IntPartControlLength = 0;
            this.txtDoublePoleMode.m_IntPartControlStartIndex = 0;
            this.txtDoublePoleMode.m_StrUserID = "";
            this.txtDoublePoleMode.m_StrUserName = "";
            this.txtDoublePoleMode.Multiline = false;
            this.txtDoublePoleMode.Name = "txtDoublePoleMode";
            this.txtDoublePoleMode.Size = new System.Drawing.Size(72, 20);
            this.txtDoublePoleMode.TabIndex = 350;
            this.txtDoublePoleMode.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(232, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 5945;
            this.label2.Text = "负极板放置部位：";
            // 
            // lblDoublePolemode
            // 
            this.lblDoublePolemode.AutoSize = true;
            this.lblDoublePolemode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoublePolemode.Location = new System.Drawing.Point(96, 21);
            this.lblDoublePolemode.Name = "lblDoublePolemode";
            this.lblDoublePolemode.Size = new System.Drawing.Size(49, 14);
            this.lblDoublePolemode.TabIndex = 5;
            this.lblDoublePolemode.Text = "型号：";
            // 
            // rdbHaveNotDoublePole
            // 
            this.rdbHaveNotDoublePole.Checked = true;
            this.rdbHaveNotDoublePole.Location = new System.Drawing.Point(8, 16);
            this.rdbHaveNotDoublePole.Name = "rdbHaveNotDoublePole";
            this.rdbHaveNotDoublePole.Size = new System.Drawing.Size(48, 24);
            this.rdbHaveNotDoublePole.TabIndex = 340;
            this.rdbHaveNotDoublePole.TabStop = true;
            this.rdbHaveNotDoublePole.Text = "否";
            this.rdbHaveNotDoublePole.CheckedChanged += new System.EventHandler(this.DoublePole_CheckedChanged);
            // 
            // rdbHaveDoublePole
            // 
            this.rdbHaveDoublePole.Location = new System.Drawing.Point(56, 16);
            this.rdbHaveDoublePole.Name = "rdbHaveDoublePole";
            this.rdbHaveDoublePole.Size = new System.Drawing.Size(44, 24);
            this.rdbHaveDoublePole.TabIndex = 345;
            this.rdbHaveDoublePole.Text = "是";
            this.rdbHaveDoublePole.CheckedChanged += new System.EventHandler(this.DoublePole_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(56, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 24);
            this.radioButton2.TabIndex = 345;
            this.radioButton2.Text = "是";
            // 
            // gpbSkinBeforOperation1
            // 
            this.gpbSkinBeforOperation1.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSkinBeforOperation1.Controls.Add(this.rdbCathodeLocationSkinBeforOperationFull);
            this.gpbSkinBeforOperation1.Controls.Add(this.rdbCathodeLocationSkinBeforOperationMar);
            this.gpbSkinBeforOperation1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbSkinBeforOperation1.Location = new System.Drawing.Point(10, 246);
            this.gpbSkinBeforOperation1.Name = "gpbSkinBeforOperation1";
            this.gpbSkinBeforOperation1.Size = new System.Drawing.Size(152, 48);
            this.gpbSkinBeforOperation1.TabIndex = 370;
            this.gpbSkinBeforOperation1.TabStop = false;
            this.gpbSkinBeforOperation1.Text = "术前负极板部位皮肤";
            // 
            // rdbCathodeLocationSkinBeforOperationFull
            // 
            this.rdbCathodeLocationSkinBeforOperationFull.Checked = true;
            this.rdbCathodeLocationSkinBeforOperationFull.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbCathodeLocationSkinBeforOperationFull.Location = new System.Drawing.Point(12, 20);
            this.rdbCathodeLocationSkinBeforOperationFull.Name = "rdbCathodeLocationSkinBeforOperationFull";
            this.rdbCathodeLocationSkinBeforOperationFull.Size = new System.Drawing.Size(56, 24);
            this.rdbCathodeLocationSkinBeforOperationFull.TabIndex = 380;
            this.rdbCathodeLocationSkinBeforOperationFull.TabStop = true;
            this.rdbCathodeLocationSkinBeforOperationFull.Text = "完好";
            // 
            // rdbCathodeLocationSkinBeforOperationMar
            // 
            this.rdbCathodeLocationSkinBeforOperationMar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbCathodeLocationSkinBeforOperationMar.Location = new System.Drawing.Point(84, 20);
            this.rdbCathodeLocationSkinBeforOperationMar.Name = "rdbCathodeLocationSkinBeforOperationMar";
            this.rdbCathodeLocationSkinBeforOperationMar.Size = new System.Drawing.Size(56, 24);
            this.rdbCathodeLocationSkinBeforOperationMar.TabIndex = 390;
            this.rdbCathodeLocationSkinBeforOperationMar.Text = "损伤";
            // 
            // gpbSkinBeforOperation
            // 
            this.gpbSkinBeforOperation.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSkinBeforOperation.Controls.Add(this.rdbCathodeLocationSkinAfterOperationFull);
            this.gpbSkinBeforOperation.Controls.Add(this.rdbCathodeLocationSkinAfterOperationMar);
            this.gpbSkinBeforOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbSkinBeforOperation.Location = new System.Drawing.Point(170, 246);
            this.gpbSkinBeforOperation.Name = "gpbSkinBeforOperation";
            this.gpbSkinBeforOperation.Size = new System.Drawing.Size(158, 48);
            this.gpbSkinBeforOperation.TabIndex = 400;
            this.gpbSkinBeforOperation.TabStop = false;
            this.gpbSkinBeforOperation.Text = "术后负极板部位皮肤";
            // 
            // rdbCathodeLocationSkinAfterOperationFull
            // 
            this.rdbCathodeLocationSkinAfterOperationFull.Checked = true;
            this.rdbCathodeLocationSkinAfterOperationFull.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbCathodeLocationSkinAfterOperationFull.Location = new System.Drawing.Point(12, 20);
            this.rdbCathodeLocationSkinAfterOperationFull.Name = "rdbCathodeLocationSkinAfterOperationFull";
            this.rdbCathodeLocationSkinAfterOperationFull.Size = new System.Drawing.Size(56, 24);
            this.rdbCathodeLocationSkinAfterOperationFull.TabIndex = 410;
            this.rdbCathodeLocationSkinAfterOperationFull.TabStop = true;
            this.rdbCathodeLocationSkinAfterOperationFull.Text = "完好";
            // 
            // rdbCathodeLocationSkinAfterOperationMar
            // 
            this.rdbCathodeLocationSkinAfterOperationMar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbCathodeLocationSkinAfterOperationMar.Location = new System.Drawing.Point(92, 20);
            this.rdbCathodeLocationSkinAfterOperationMar.Name = "rdbCathodeLocationSkinAfterOperationMar";
            this.rdbCathodeLocationSkinAfterOperationMar.Size = new System.Drawing.Size(56, 24);
            this.rdbCathodeLocationSkinAfterOperationMar.TabIndex = 420;
            this.rdbCathodeLocationSkinAfterOperationMar.Text = "损伤";
            // 
            // gpbStypticRubber
            // 
            this.gpbStypticRubber.BackColor = System.Drawing.SystemColors.Control;
            this.gpbStypticRubber.Controls.Add(this.txtStypticPressureMode);
            this.gpbStypticRubber.Controls.Add(this.lblStypticPressureMode);
            this.gpbStypticRubber.Controls.Add(this.chkStypticRubber);
            this.gpbStypticRubber.Controls.Add(this.chkStypticPressure);
            this.gpbStypticRubber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbStypticRubber.Location = new System.Drawing.Point(332, 246);
            this.gpbStypticRubber.Name = "gpbStypticRubber";
            this.gpbStypticRubber.Size = new System.Drawing.Size(384, 48);
            this.gpbStypticRubber.TabIndex = 430;
            this.gpbStypticRubber.TabStop = false;
            this.gpbStypticRubber.Text = "止血带";
            // 
            // txtStypticPressureMode
            // 
            this.txtStypticPressureMode.AccessibleDescription = "止血带-型号";
            this.txtStypticPressureMode.BackColor = System.Drawing.Color.White;
            this.txtStypticPressureMode.ForeColor = System.Drawing.Color.Black;
            this.txtStypticPressureMode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtStypticPressureMode.Location = new System.Drawing.Point(275, 19);
            this.txtStypticPressureMode.m_BlnIgnoreUserInfo = false;
            this.txtStypticPressureMode.m_BlnPartControl = false;
            this.txtStypticPressureMode.m_BlnReadOnly = false;
            this.txtStypticPressureMode.m_BlnUnderLineDST = false;
            this.txtStypticPressureMode.m_ClrDST = System.Drawing.Color.Red;
            this.txtStypticPressureMode.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtStypticPressureMode.m_IntCanModifyTime = 6;
            this.txtStypticPressureMode.m_IntPartControlLength = 0;
            this.txtStypticPressureMode.m_IntPartControlStartIndex = 0;
            this.txtStypticPressureMode.m_StrUserID = "";
            this.txtStypticPressureMode.m_StrUserName = "";
            this.txtStypticPressureMode.Multiline = false;
            this.txtStypticPressureMode.Name = "txtStypticPressureMode";
            this.txtStypticPressureMode.Size = new System.Drawing.Size(74, 20);
            this.txtStypticPressureMode.TabIndex = 460;
            this.txtStypticPressureMode.Text = "";
            // 
            // lblStypticPressureMode
            // 
            this.lblStypticPressureMode.AutoSize = true;
            this.lblStypticPressureMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStypticPressureMode.Location = new System.Drawing.Point(232, 23);
            this.lblStypticPressureMode.Name = "lblStypticPressureMode";
            this.lblStypticPressureMode.Size = new System.Drawing.Size(49, 14);
            this.lblStypticPressureMode.TabIndex = 5944;
            this.lblStypticPressureMode.Text = "型号：";
            this.lblStypticPressureMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkStypticRubber
            // 
            this.chkStypticRubber.BackColor = System.Drawing.SystemColors.Control;
            this.chkStypticRubber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkStypticRubber.Location = new System.Drawing.Point(8, 20);
            this.chkStypticRubber.Name = "chkStypticRubber";
            this.chkStypticRubber.Size = new System.Drawing.Size(96, 22);
            this.chkStypticRubber.TabIndex = 440;
            this.chkStypticRubber.Text = "驱血橡皮带";
            this.chkStypticRubber.UseVisualStyleBackColor = false;
            // 
            // chkStypticPressure
            // 
            this.chkStypticPressure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkStypticPressure.Location = new System.Drawing.Point(116, 20);
            this.chkStypticPressure.Name = "chkStypticPressure";
            this.chkStypticPressure.Size = new System.Drawing.Size(112, 22);
            this.chkStypticPressure.TabIndex = 450;
            this.chkStypticPressure.Text = "气压止血仪";
            this.chkStypticPressure.CheckedChanged += new System.EventHandler(this.chkStypticPressure_CheckedChanged);
            // 
            // gpbUp
            // 
            this.gpbUp.BackColor = System.Drawing.SystemColors.Control;
            this.gpbUp.Controls.Add(this.lblFen);
            this.gpbUp.Controls.Add(this.lblMlSputum);
            this.gpbUp.Controls.Add(this.lblUpPuffDateTime);
            this.gpbUp.Controls.Add(this.lblUpTotalDateTime);
            this.gpbUp.Controls.Add(this.lblUpPress);
            this.gpbUp.Controls.Add(this.lblUpDeflateDateTime);
            this.gpbUp.Controls.Add(this.chkUpThigh);
            this.gpbUp.Controls.Add(this.chkUpLeft);
            this.gpbUp.Controls.Add(this.chkUpRight);
            this.gpbUp.Controls.Add(this.chkUpForearm);
            this.gpbUp.Controls.Add(this.txtUpPuffDateTime);
            this.gpbUp.Controls.Add(this.txtUpDeflateDateTime);
            this.gpbUp.Controls.Add(this.txtUpTotalDateTime);
            this.gpbUp.Controls.Add(this.txtUpPress);
            this.gpbUp.Controls.Add(this.checkBox1);
            this.gpbUp.Controls.Add(this.checkBox2);
            this.gpbUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbUp.Location = new System.Drawing.Point(8, 128);
            this.gpbUp.Name = "gpbUp";
            this.gpbUp.Size = new System.Drawing.Size(708, 48);
            this.gpbUp.TabIndex = 470;
            this.gpbUp.TabStop = false;
            this.gpbUp.Text = "气压止血肢体位置一";
            // 
            // lblFen
            // 
            this.lblFen.AutoSize = true;
            this.lblFen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFen.Location = new System.Drawing.Point(556, 21);
            this.lblFen.Name = "lblFen";
            this.lblFen.Size = new System.Drawing.Size(21, 14);
            this.lblFen.TabIndex = 5949;
            this.lblFen.Text = "分";
            this.lblFen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMlSputum
            // 
            this.lblMlSputum.AutoSize = true;
            this.lblMlSputum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMlSputum.Location = new System.Drawing.Point(654, 18);
            this.lblMlSputum.Name = "lblMlSputum";
            this.lblMlSputum.Size = new System.Drawing.Size(40, 16);
            this.lblMlSputum.TabIndex = 575;
            this.lblMlSputum.Text = "mmHg";
            this.lblMlSputum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpPuffDateTime
            // 
            this.lblUpPuffDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpPuffDateTime.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblUpPuffDateTime.Location = new System.Drawing.Point(196, 21);
            this.lblUpPuffDateTime.Name = "lblUpPuffDateTime";
            this.lblUpPuffDateTime.Size = new System.Drawing.Size(72, 19);
            this.lblUpPuffDateTime.TabIndex = 520;
            this.lblUpPuffDateTime.Text = "充气时间:";
            this.lblUpPuffDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpTotalDateTime
            // 
            this.lblUpTotalDateTime.AutoSize = true;
            this.lblUpTotalDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpTotalDateTime.Location = new System.Drawing.Point(458, 21);
            this.lblUpTotalDateTime.Name = "lblUpTotalDateTime";
            this.lblUpTotalDateTime.Size = new System.Drawing.Size(56, 14);
            this.lblUpTotalDateTime.TabIndex = 573;
            this.lblUpTotalDateTime.Text = "总时间:";
            this.lblUpTotalDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpPress
            // 
            this.lblUpPress.AutoSize = true;
            this.lblUpPress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpPress.Location = new System.Drawing.Point(577, 21);
            this.lblUpPress.Name = "lblUpPress";
            this.lblUpPress.Size = new System.Drawing.Size(35, 14);
            this.lblUpPress.TabIndex = 572;
            this.lblUpPress.Text = "压力";
            this.lblUpPress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpDeflateDateTime
            // 
            this.lblUpDeflateDateTime.AutoSize = true;
            this.lblUpDeflateDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpDeflateDateTime.Location = new System.Drawing.Point(330, 21);
            this.lblUpDeflateDateTime.Name = "lblUpDeflateDateTime";
            this.lblUpDeflateDateTime.Size = new System.Drawing.Size(70, 14);
            this.lblUpDeflateDateTime.TabIndex = 571;
            this.lblUpDeflateDateTime.Text = "放气时间:";
            this.lblUpDeflateDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkUpThigh
            // 
            this.chkUpThigh.BackColor = System.Drawing.SystemColors.Control;
            this.chkUpThigh.Location = new System.Drawing.Point(65, 16);
            this.chkUpThigh.Name = "chkUpThigh";
            this.chkUpThigh.Size = new System.Drawing.Size(56, 24);
            this.chkUpThigh.TabIndex = 490;
            this.chkUpThigh.Text = "大腿";
            this.chkUpThigh.UseVisualStyleBackColor = false;
            // 
            // chkUpLeft
            // 
            this.chkUpLeft.Location = new System.Drawing.Point(122, 18);
            this.chkUpLeft.Name = "chkUpLeft";
            this.chkUpLeft.Size = new System.Drawing.Size(36, 24);
            this.chkUpLeft.TabIndex = 500;
            this.chkUpLeft.Text = "左";
            // 
            // chkUpRight
            // 
            this.chkUpRight.Location = new System.Drawing.Point(159, 18);
            this.chkUpRight.Name = "chkUpRight";
            this.chkUpRight.Size = new System.Drawing.Size(36, 24);
            this.chkUpRight.TabIndex = 510;
            this.chkUpRight.Text = "右";
            // 
            // chkUpForearm
            // 
            this.chkUpForearm.Location = new System.Drawing.Point(8, 16);
            this.chkUpForearm.Name = "chkUpForearm";
            this.chkUpForearm.Size = new System.Drawing.Size(56, 24);
            this.chkUpForearm.TabIndex = 480;
            this.chkUpForearm.Text = "前臂";
            // 
            // txtUpPuffDateTime
            // 
            this.txtUpPuffDateTime.AccessibleDescription = "充气时间";
            this.txtUpPuffDateTime.BackColor = System.Drawing.Color.White;
            this.txtUpPuffDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtUpPuffDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpPuffDateTime.Location = new System.Drawing.Point(269, 20);
            this.txtUpPuffDateTime.m_BlnIgnoreUserInfo = false;
            this.txtUpPuffDateTime.m_BlnPartControl = false;
            this.txtUpPuffDateTime.m_BlnReadOnly = false;
            this.txtUpPuffDateTime.m_BlnUnderLineDST = false;
            this.txtUpPuffDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtUpPuffDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUpPuffDateTime.m_IntCanModifyTime = 6;
            this.txtUpPuffDateTime.m_IntPartControlLength = 0;
            this.txtUpPuffDateTime.m_IntPartControlStartIndex = 0;
            this.txtUpPuffDateTime.m_StrUserID = "";
            this.txtUpPuffDateTime.m_StrUserName = "";
            this.txtUpPuffDateTime.Multiline = false;
            this.txtUpPuffDateTime.Name = "txtUpPuffDateTime";
            this.txtUpPuffDateTime.Size = new System.Drawing.Size(60, 20);
            this.txtUpPuffDateTime.TabIndex = 530;
            this.txtUpPuffDateTime.Text = "";
            // 
            // txtUpDeflateDateTime
            // 
            this.txtUpDeflateDateTime.AccessibleDescription = "放气时间";
            this.txtUpDeflateDateTime.BackColor = System.Drawing.Color.White;
            this.txtUpDeflateDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtUpDeflateDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpDeflateDateTime.Location = new System.Drawing.Point(401, 20);
            this.txtUpDeflateDateTime.m_BlnIgnoreUserInfo = false;
            this.txtUpDeflateDateTime.m_BlnPartControl = false;
            this.txtUpDeflateDateTime.m_BlnReadOnly = false;
            this.txtUpDeflateDateTime.m_BlnUnderLineDST = false;
            this.txtUpDeflateDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtUpDeflateDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUpDeflateDateTime.m_IntCanModifyTime = 6;
            this.txtUpDeflateDateTime.m_IntPartControlLength = 0;
            this.txtUpDeflateDateTime.m_IntPartControlStartIndex = 0;
            this.txtUpDeflateDateTime.m_StrUserID = "";
            this.txtUpDeflateDateTime.m_StrUserName = "";
            this.txtUpDeflateDateTime.Multiline = false;
            this.txtUpDeflateDateTime.Name = "txtUpDeflateDateTime";
            this.txtUpDeflateDateTime.Size = new System.Drawing.Size(56, 20);
            this.txtUpDeflateDateTime.TabIndex = 540;
            this.txtUpDeflateDateTime.Text = "";
            // 
            // txtUpTotalDateTime
            // 
            this.txtUpTotalDateTime.AccessibleDescription = "总时间";
            this.txtUpTotalDateTime.BackColor = System.Drawing.Color.White;
            this.txtUpTotalDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtUpTotalDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpTotalDateTime.Location = new System.Drawing.Point(515, 20);
            this.txtUpTotalDateTime.m_BlnIgnoreUserInfo = false;
            this.txtUpTotalDateTime.m_BlnPartControl = false;
            this.txtUpTotalDateTime.m_BlnReadOnly = false;
            this.txtUpTotalDateTime.m_BlnUnderLineDST = false;
            this.txtUpTotalDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtUpTotalDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUpTotalDateTime.m_IntCanModifyTime = 6;
            this.txtUpTotalDateTime.m_IntPartControlLength = 0;
            this.txtUpTotalDateTime.m_IntPartControlStartIndex = 0;
            this.txtUpTotalDateTime.m_StrUserID = "";
            this.txtUpTotalDateTime.m_StrUserName = "";
            this.txtUpTotalDateTime.Multiline = false;
            this.txtUpTotalDateTime.Name = "txtUpTotalDateTime";
            this.txtUpTotalDateTime.Size = new System.Drawing.Size(40, 20);
            this.txtUpTotalDateTime.TabIndex = 550;
            this.txtUpTotalDateTime.Text = "";
            // 
            // txtUpPress
            // 
            this.txtUpPress.AccessibleDescription = "压力";
            this.txtUpPress.BackColor = System.Drawing.Color.White;
            this.txtUpPress.ForeColor = System.Drawing.Color.Black;
            this.txtUpPress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpPress.Location = new System.Drawing.Point(612, 20);
            this.txtUpPress.m_BlnIgnoreUserInfo = false;
            this.txtUpPress.m_BlnPartControl = false;
            this.txtUpPress.m_BlnReadOnly = false;
            this.txtUpPress.m_BlnUnderLineDST = false;
            this.txtUpPress.m_ClrDST = System.Drawing.Color.Red;
            this.txtUpPress.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUpPress.m_IntCanModifyTime = 6;
            this.txtUpPress.m_IntPartControlLength = 0;
            this.txtUpPress.m_IntPartControlStartIndex = 0;
            this.txtUpPress.m_StrUserID = "";
            this.txtUpPress.m_StrUserName = "";
            this.txtUpPress.Multiline = false;
            this.txtUpPress.Name = "txtUpPress";
            this.txtUpPress.Size = new System.Drawing.Size(44, 20);
            this.txtUpPress.TabIndex = 560;
            this.txtUpPress.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(68, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 24);
            this.checkBox1.TabIndex = 490;
            this.checkBox1.Text = "大腿";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(12, 20);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 24);
            this.checkBox2.TabIndex = 480;
            this.checkBox2.Text = "前臂";
            // 
            // gpbDown
            // 
            this.gpbDown.BackColor = System.Drawing.SystemColors.Control;
            this.gpbDown.Controls.Add(this.lblFen2);
            this.gpbDown.Controls.Add(this.lblmmhg);
            this.gpbDown.Controls.Add(this.lblDownPuffDateTime);
            this.gpbDown.Controls.Add(this.lblDownTotalDateTime);
            this.gpbDown.Controls.Add(this.lblDownPress);
            this.gpbDown.Controls.Add(this.lblDownDeflateDateTime);
            this.gpbDown.Controls.Add(this.chkDownThigh);
            this.gpbDown.Controls.Add(this.chkDownLeft);
            this.gpbDown.Controls.Add(this.chkDownRight);
            this.gpbDown.Controls.Add(this.chkDownForearm);
            this.gpbDown.Controls.Add(this.txtDownPuffDateTime);
            this.gpbDown.Controls.Add(this.txtDownDeflateDateTime);
            this.gpbDown.Controls.Add(this.txtDownTotalDateTime);
            this.gpbDown.Controls.Add(this.txtDownPress);
            this.gpbDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbDown.Location = new System.Drawing.Point(10, 187);
            this.gpbDown.Name = "gpbDown";
            this.gpbDown.Size = new System.Drawing.Size(708, 48);
            this.gpbDown.TabIndex = 570;
            this.gpbDown.TabStop = false;
            this.gpbDown.Text = "气压止血肢体位置二";
            this.gpbDown.Enter += new System.EventHandler(this.gpbDown_Enter);
            // 
            // lblFen2
            // 
            this.lblFen2.AutoSize = true;
            this.lblFen2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFen2.Location = new System.Drawing.Point(556, 22);
            this.lblFen2.Name = "lblFen2";
            this.lblFen2.Size = new System.Drawing.Size(21, 14);
            this.lblFen2.TabIndex = 5949;
            this.lblFen2.Text = "分";
            // 
            // lblmmhg
            // 
            this.lblmmhg.AutoSize = true;
            this.lblmmhg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmmhg.Location = new System.Drawing.Point(656, 20);
            this.lblmmhg.Name = "lblmmhg";
            this.lblmmhg.Size = new System.Drawing.Size(40, 16);
            this.lblmmhg.TabIndex = 575;
            this.lblmmhg.Text = "mmHg";
            // 
            // lblDownPuffDateTime
            // 
            this.lblDownPuffDateTime.AutoSize = true;
            this.lblDownPuffDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownPuffDateTime.Location = new System.Drawing.Point(196, 24);
            this.lblDownPuffDateTime.Name = "lblDownPuffDateTime";
            this.lblDownPuffDateTime.Size = new System.Drawing.Size(70, 14);
            this.lblDownPuffDateTime.TabIndex = 620;
            this.lblDownPuffDateTime.Text = "充气时间:";
            this.lblDownPuffDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDownTotalDateTime
            // 
            this.lblDownTotalDateTime.AutoSize = true;
            this.lblDownTotalDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownTotalDateTime.Location = new System.Drawing.Point(458, 22);
            this.lblDownTotalDateTime.Name = "lblDownTotalDateTime";
            this.lblDownTotalDateTime.Size = new System.Drawing.Size(56, 14);
            this.lblDownTotalDateTime.TabIndex = 573;
            this.lblDownTotalDateTime.Text = "总时间:";
            // 
            // lblDownPress
            // 
            this.lblDownPress.AutoSize = true;
            this.lblDownPress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownPress.Location = new System.Drawing.Point(577, 22);
            this.lblDownPress.Name = "lblDownPress";
            this.lblDownPress.Size = new System.Drawing.Size(35, 14);
            this.lblDownPress.TabIndex = 572;
            this.lblDownPress.Text = "压力";
            // 
            // lblDownDeflateDateTime
            // 
            this.lblDownDeflateDateTime.AutoSize = true;
            this.lblDownDeflateDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownDeflateDateTime.Location = new System.Drawing.Point(330, 22);
            this.lblDownDeflateDateTime.Name = "lblDownDeflateDateTime";
            this.lblDownDeflateDateTime.Size = new System.Drawing.Size(70, 14);
            this.lblDownDeflateDateTime.TabIndex = 571;
            this.lblDownDeflateDateTime.Text = "放气时间:";
            // 
            // chkDownThigh
            // 
            this.chkDownThigh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownThigh.Location = new System.Drawing.Point(65, 20);
            this.chkDownThigh.Name = "chkDownThigh";
            this.chkDownThigh.Size = new System.Drawing.Size(56, 24);
            this.chkDownThigh.TabIndex = 590;
            this.chkDownThigh.Text = "大腿";
            // 
            // chkDownLeft
            // 
            this.chkDownLeft.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownLeft.Location = new System.Drawing.Point(122, 20);
            this.chkDownLeft.Name = "chkDownLeft";
            this.chkDownLeft.Size = new System.Drawing.Size(36, 24);
            this.chkDownLeft.TabIndex = 600;
            this.chkDownLeft.Text = "左";
            // 
            // chkDownRight
            // 
            this.chkDownRight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownRight.Location = new System.Drawing.Point(159, 20);
            this.chkDownRight.Name = "chkDownRight";
            this.chkDownRight.Size = new System.Drawing.Size(36, 24);
            this.chkDownRight.TabIndex = 610;
            this.chkDownRight.Text = "右";
            // 
            // chkDownForearm
            // 
            this.chkDownForearm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownForearm.Location = new System.Drawing.Point(8, 20);
            this.chkDownForearm.Name = "chkDownForearm";
            this.chkDownForearm.Size = new System.Drawing.Size(56, 24);
            this.chkDownForearm.TabIndex = 580;
            this.chkDownForearm.Text = "前臂";
            // 
            // txtDownPuffDateTime
            // 
            this.txtDownPuffDateTime.BackColor = System.Drawing.Color.White;
            this.txtDownPuffDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtDownPuffDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDownPuffDateTime.Location = new System.Drawing.Point(269, 21);
            this.txtDownPuffDateTime.m_BlnIgnoreUserInfo = false;
            this.txtDownPuffDateTime.m_BlnPartControl = false;
            this.txtDownPuffDateTime.m_BlnReadOnly = false;
            this.txtDownPuffDateTime.m_BlnUnderLineDST = false;
            this.txtDownPuffDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtDownPuffDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDownPuffDateTime.m_IntCanModifyTime = 6;
            this.txtDownPuffDateTime.m_IntPartControlLength = 0;
            this.txtDownPuffDateTime.m_IntPartControlStartIndex = 0;
            this.txtDownPuffDateTime.m_StrUserID = "";
            this.txtDownPuffDateTime.m_StrUserName = "";
            this.txtDownPuffDateTime.Multiline = false;
            this.txtDownPuffDateTime.Name = "txtDownPuffDateTime";
            this.txtDownPuffDateTime.Size = new System.Drawing.Size(60, 20);
            this.txtDownPuffDateTime.TabIndex = 630;
            this.txtDownPuffDateTime.Text = "";
            // 
            // txtDownDeflateDateTime
            // 
            this.txtDownDeflateDateTime.BackColor = System.Drawing.Color.White;
            this.txtDownDeflateDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtDownDeflateDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDownDeflateDateTime.Location = new System.Drawing.Point(401, 19);
            this.txtDownDeflateDateTime.m_BlnIgnoreUserInfo = false;
            this.txtDownDeflateDateTime.m_BlnPartControl = false;
            this.txtDownDeflateDateTime.m_BlnReadOnly = false;
            this.txtDownDeflateDateTime.m_BlnUnderLineDST = false;
            this.txtDownDeflateDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtDownDeflateDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDownDeflateDateTime.m_IntCanModifyTime = 6;
            this.txtDownDeflateDateTime.m_IntPartControlLength = 0;
            this.txtDownDeflateDateTime.m_IntPartControlStartIndex = 0;
            this.txtDownDeflateDateTime.m_StrUserID = "";
            this.txtDownDeflateDateTime.m_StrUserName = "";
            this.txtDownDeflateDateTime.Multiline = false;
            this.txtDownDeflateDateTime.Name = "txtDownDeflateDateTime";
            this.txtDownDeflateDateTime.Size = new System.Drawing.Size(56, 20);
            this.txtDownDeflateDateTime.TabIndex = 640;
            this.txtDownDeflateDateTime.Text = "";
            // 
            // txtDownTotalDateTime
            // 
            this.txtDownTotalDateTime.BackColor = System.Drawing.Color.White;
            this.txtDownTotalDateTime.ForeColor = System.Drawing.Color.Black;
            this.txtDownTotalDateTime.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDownTotalDateTime.Location = new System.Drawing.Point(515, 19);
            this.txtDownTotalDateTime.m_BlnIgnoreUserInfo = false;
            this.txtDownTotalDateTime.m_BlnPartControl = false;
            this.txtDownTotalDateTime.m_BlnReadOnly = false;
            this.txtDownTotalDateTime.m_BlnUnderLineDST = false;
            this.txtDownTotalDateTime.m_ClrDST = System.Drawing.Color.Red;
            this.txtDownTotalDateTime.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDownTotalDateTime.m_IntCanModifyTime = 6;
            this.txtDownTotalDateTime.m_IntPartControlLength = 0;
            this.txtDownTotalDateTime.m_IntPartControlStartIndex = 0;
            this.txtDownTotalDateTime.m_StrUserID = "";
            this.txtDownTotalDateTime.m_StrUserName = "";
            this.txtDownTotalDateTime.Multiline = false;
            this.txtDownTotalDateTime.Name = "txtDownTotalDateTime";
            this.txtDownTotalDateTime.Size = new System.Drawing.Size(40, 20);
            this.txtDownTotalDateTime.TabIndex = 650;
            this.txtDownTotalDateTime.Text = "";
            // 
            // txtDownPress
            // 
            this.txtDownPress.BackColor = System.Drawing.Color.White;
            this.txtDownPress.ForeColor = System.Drawing.Color.Black;
            this.txtDownPress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDownPress.Location = new System.Drawing.Point(612, 19);
            this.txtDownPress.m_BlnIgnoreUserInfo = false;
            this.txtDownPress.m_BlnPartControl = false;
            this.txtDownPress.m_BlnReadOnly = false;
            this.txtDownPress.m_BlnUnderLineDST = false;
            this.txtDownPress.m_ClrDST = System.Drawing.Color.Red;
            this.txtDownPress.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDownPress.m_IntCanModifyTime = 6;
            this.txtDownPress.m_IntPartControlLength = 0;
            this.txtDownPress.m_IntPartControlStartIndex = 0;
            this.txtDownPress.m_StrUserID = "";
            this.txtDownPress.m_StrUserName = "";
            this.txtDownPress.Multiline = false;
            this.txtDownPress.Name = "txtDownPress";
            this.txtDownPress.Size = new System.Drawing.Size(44, 20);
            this.txtDownPress.TabIndex = 660;
            this.txtDownPress.Text = "";
            // 
            // gpbFoley
            // 
            this.gpbFoley.BackColor = System.Drawing.SystemColors.Control;
            this.gpbFoley.Controls.Add(this.txtFoleyOtherContent);
            this.gpbFoley.Controls.Add(this.chkFoleyOther);
            this.gpbFoley.Controls.Add(this.chkFoleyOperationRoom);
            this.gpbFoley.Controls.Add(this.chkFoleyDoubleAntrum);
            this.gpbFoley.Controls.Add(this.chkFoleyThreeAntrum);
            this.gpbFoley.Controls.Add(this.chkFoleySickroom);
            this.gpbFoley.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbFoley.Location = new System.Drawing.Point(10, 69);
            this.gpbFoley.Name = "gpbFoley";
            this.gpbFoley.Size = new System.Drawing.Size(488, 48);
            this.gpbFoley.TabIndex = 670;
            this.gpbFoley.TabStop = false;
            this.gpbFoley.Text = "停留Foley氏尿管";
            // 
            // txtFoleyOtherContent
            // 
            this.txtFoleyOtherContent.AccessibleDescription = "停留Foley氏尿管-其他";
            this.txtFoleyOtherContent.BackColor = System.Drawing.Color.White;
            this.txtFoleyOtherContent.ForeColor = System.Drawing.Color.Black;
            this.txtFoleyOtherContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFoleyOtherContent.Location = new System.Drawing.Point(344, 17);
            this.txtFoleyOtherContent.m_BlnIgnoreUserInfo = false;
            this.txtFoleyOtherContent.m_BlnPartControl = false;
            this.txtFoleyOtherContent.m_BlnReadOnly = false;
            this.txtFoleyOtherContent.m_BlnUnderLineDST = false;
            this.txtFoleyOtherContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtFoleyOtherContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtFoleyOtherContent.m_IntCanModifyTime = 6;
            this.txtFoleyOtherContent.m_IntPartControlLength = 0;
            this.txtFoleyOtherContent.m_IntPartControlStartIndex = 0;
            this.txtFoleyOtherContent.m_StrUserID = "";
            this.txtFoleyOtherContent.m_StrUserName = "";
            this.txtFoleyOtherContent.Multiline = false;
            this.txtFoleyOtherContent.Name = "txtFoleyOtherContent";
            this.txtFoleyOtherContent.Size = new System.Drawing.Size(124, 20);
            this.txtFoleyOtherContent.TabIndex = 730;
            this.txtFoleyOtherContent.Text = "";
            // 
            // chkFoleyOther
            // 
            this.chkFoleyOther.Location = new System.Drawing.Point(288, 16);
            this.chkFoleyOther.Name = "chkFoleyOther";
            this.chkFoleyOther.Size = new System.Drawing.Size(60, 24);
            this.chkFoleyOther.TabIndex = 720;
            this.chkFoleyOther.Text = "其它";
            this.chkFoleyOther.CheckedChanged += new System.EventHandler(this.chkFoleyOther_CheckedChanged);
            // 
            // chkFoleyOperationRoom
            // 
            this.chkFoleyOperationRoom.Location = new System.Drawing.Point(100, 16);
            this.chkFoleyOperationRoom.Name = "chkFoleyOperationRoom";
            this.chkFoleyOperationRoom.Size = new System.Drawing.Size(68, 24);
            this.chkFoleyOperationRoom.TabIndex = 690;
            this.chkFoleyOperationRoom.Text = "手术室";
            // 
            // chkFoleyDoubleAntrum
            // 
            this.chkFoleyDoubleAntrum.Location = new System.Drawing.Point(172, 16);
            this.chkFoleyDoubleAntrum.Name = "chkFoleyDoubleAntrum";
            this.chkFoleyDoubleAntrum.Size = new System.Drawing.Size(56, 24);
            this.chkFoleyDoubleAntrum.TabIndex = 700;
            this.chkFoleyDoubleAntrum.Text = "双腔";
            // 
            // chkFoleyThreeAntrum
            // 
            this.chkFoleyThreeAntrum.Location = new System.Drawing.Point(228, 16);
            this.chkFoleyThreeAntrum.Name = "chkFoleyThreeAntrum";
            this.chkFoleyThreeAntrum.Size = new System.Drawing.Size(60, 24);
            this.chkFoleyThreeAntrum.TabIndex = 710;
            this.chkFoleyThreeAntrum.Text = "三腔";
            // 
            // chkFoleySickroom
            // 
            this.chkFoleySickroom.Location = new System.Drawing.Point(12, 16);
            this.chkFoleySickroom.Name = "chkFoleySickroom";
            this.chkFoleySickroom.Size = new System.Drawing.Size(88, 24);
            this.chkFoleySickroom.TabIndex = 680;
            this.chkFoleySickroom.Text = "病房带来";
            // 
            // gpbStomach
            // 
            this.gpbStomach.BackColor = System.Drawing.SystemColors.Control;
            this.gpbStomach.Controls.Add(this.rdbStomachSickroom);
            this.gpbStomach.Controls.Add(this.rdbStomachOprationRoom);
            this.gpbStomach.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbStomach.Location = new System.Drawing.Point(500, 69);
            this.gpbStomach.Name = "gpbStomach";
            this.gpbStomach.Size = new System.Drawing.Size(216, 48);
            this.gpbStomach.TabIndex = 740;
            this.gpbStomach.TabStop = false;
            this.gpbStomach.Text = "停留胃管";
            // 
            // rdbStomachSickroom
            // 
            this.rdbStomachSickroom.Checked = true;
            this.rdbStomachSickroom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbStomachSickroom.Location = new System.Drawing.Point(20, 16);
            this.rdbStomachSickroom.Name = "rdbStomachSickroom";
            this.rdbStomachSickroom.Size = new System.Drawing.Size(92, 24);
            this.rdbStomachSickroom.TabIndex = 750;
            this.rdbStomachSickroom.TabStop = true;
            this.rdbStomachSickroom.Text = "病房带来";
            // 
            // rdbStomachOprationRoom
            // 
            this.rdbStomachOprationRoom.Location = new System.Drawing.Point(128, 16);
            this.rdbStomachOprationRoom.Name = "rdbStomachOprationRoom";
            this.rdbStomachOprationRoom.Size = new System.Drawing.Size(72, 24);
            this.rdbStomachOprationRoom.TabIndex = 760;
            this.rdbStomachOprationRoom.Text = "手术室";
            // 
            // gpbSkinAntisepsis
            // 
            this.gpbSkinAntisepsis.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSkinAntisepsis.Controls.Add(this.txtSkinAntisepsisOtherContent);
            this.gpbSkinAntisepsis.Controls.Add(this.chkSkinAntisepsisOther);
            this.gpbSkinAntisepsis.Controls.Add(this.chkSkinAntisepsis75);
            this.gpbSkinAntisepsis.Controls.Add(this.chkSkinAntisepsisIodin);
            this.gpbSkinAntisepsis.Controls.Add(this.chkSkinAntisepsisIodinRare);
            this.gpbSkinAntisepsis.Controls.Add(this.chkSkinAntisepsis2);
            this.gpbSkinAntisepsis.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbSkinAntisepsis.Location = new System.Drawing.Point(10, 305);
            this.gpbSkinAntisepsis.Name = "gpbSkinAntisepsis";
            this.gpbSkinAntisepsis.Size = new System.Drawing.Size(708, 48);
            this.gpbSkinAntisepsis.TabIndex = 770;
            this.gpbSkinAntisepsis.TabStop = false;
            this.gpbSkinAntisepsis.Text = "皮肤消毒";
            // 
            // txtSkinAntisepsisOtherContent
            // 
            this.txtSkinAntisepsisOtherContent.AccessibleDescription = "其他";
            this.txtSkinAntisepsisOtherContent.BackColor = System.Drawing.Color.White;
            this.txtSkinAntisepsisOtherContent.ForeColor = System.Drawing.Color.Black;
            this.txtSkinAntisepsisOtherContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSkinAntisepsisOtherContent.Location = new System.Drawing.Point(508, 20);
            this.txtSkinAntisepsisOtherContent.m_BlnIgnoreUserInfo = false;
            this.txtSkinAntisepsisOtherContent.m_BlnPartControl = false;
            this.txtSkinAntisepsisOtherContent.m_BlnReadOnly = false;
            this.txtSkinAntisepsisOtherContent.m_BlnUnderLineDST = false;
            this.txtSkinAntisepsisOtherContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtSkinAntisepsisOtherContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSkinAntisepsisOtherContent.m_IntCanModifyTime = 6;
            this.txtSkinAntisepsisOtherContent.m_IntPartControlLength = 0;
            this.txtSkinAntisepsisOtherContent.m_IntPartControlStartIndex = 0;
            this.txtSkinAntisepsisOtherContent.m_StrUserID = "";
            this.txtSkinAntisepsisOtherContent.m_StrUserName = "";
            this.txtSkinAntisepsisOtherContent.Multiline = false;
            this.txtSkinAntisepsisOtherContent.Name = "txtSkinAntisepsisOtherContent";
            this.txtSkinAntisepsisOtherContent.Size = new System.Drawing.Size(185, 20);
            this.txtSkinAntisepsisOtherContent.TabIndex = 830;
            this.txtSkinAntisepsisOtherContent.Text = "";
            // 
            // chkSkinAntisepsisOther
            // 
            this.chkSkinAntisepsisOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSkinAntisepsisOther.Location = new System.Drawing.Point(452, 20);
            this.chkSkinAntisepsisOther.Name = "chkSkinAntisepsisOther";
            this.chkSkinAntisepsisOther.Size = new System.Drawing.Size(56, 24);
            this.chkSkinAntisepsisOther.TabIndex = 820;
            this.chkSkinAntisepsisOther.Text = "其它";
            this.chkSkinAntisepsisOther.CheckedChanged += new System.EventHandler(this.chkSkinAntisepsisOther_CheckedChanged);
            // 
            // chkSkinAntisepsis75
            // 
            this.chkSkinAntisepsis75.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSkinAntisepsis75.Location = new System.Drawing.Point(104, 20);
            this.chkSkinAntisepsis75.Name = "chkSkinAntisepsis75";
            this.chkSkinAntisepsis75.Size = new System.Drawing.Size(76, 24);
            this.chkSkinAntisepsis75.TabIndex = 790;
            this.chkSkinAntisepsis75.Text = "75%酒精";
            // 
            // chkSkinAntisepsisIodin
            // 
            this.chkSkinAntisepsisIodin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSkinAntisepsisIodin.Location = new System.Drawing.Point(208, 20);
            this.chkSkinAntisepsisIodin.Name = "chkSkinAntisepsisIodin";
            this.chkSkinAntisepsisIodin.Size = new System.Drawing.Size(84, 24);
            this.chkSkinAntisepsisIodin.TabIndex = 800;
            this.chkSkinAntisepsisIodin.Text = "碘伏原液";
            // 
            // chkSkinAntisepsisIodinRare
            // 
            this.chkSkinAntisepsisIodinRare.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSkinAntisepsisIodinRare.Location = new System.Drawing.Point(324, 20);
            this.chkSkinAntisepsisIodinRare.Name = "chkSkinAntisepsisIodinRare";
            this.chkSkinAntisepsisIodinRare.Size = new System.Drawing.Size(96, 24);
            this.chkSkinAntisepsisIodinRare.TabIndex = 810;
            this.chkSkinAntisepsisIodinRare.Text = "碘伏稀释液";
            // 
            // chkSkinAntisepsis2
            // 
            this.chkSkinAntisepsis2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSkinAntisepsis2.Location = new System.Drawing.Point(8, 20);
            this.chkSkinAntisepsis2.Name = "chkSkinAntisepsis2";
            this.chkSkinAntisepsis2.Size = new System.Drawing.Size(72, 24);
            this.chkSkinAntisepsis2.TabIndex = 780;
            this.chkSkinAntisepsis2.Text = "2%碘酊";
            // 
            // gpbBlood
            // 
            this.gpbBlood.BackColor = System.Drawing.SystemColors.Control;
            this.gpbBlood.Controls.Add(this.txtBloodOther);
            this.gpbBlood.Controls.Add(this.chkBloodOther);
            this.gpbBlood.Controls.Add(this.chkOwnBlood);
            this.gpbBlood.Controls.Add(this.chkBloodPlasm);
            this.gpbBlood.Controls.Add(this.chkRedCell);
            this.gpbBlood.Controls.Add(this.lblml11);
            this.gpbBlood.Controls.Add(this.txtAllBloodQty);
            this.gpbBlood.Controls.Add(this.lblml12);
            this.gpbBlood.Controls.Add(this.txtRedCellQty);
            this.gpbBlood.Controls.Add(this.lblml13);
            this.gpbBlood.Controls.Add(this.txtBloodPlasmQty);
            this.gpbBlood.Controls.Add(this.label11);
            this.gpbBlood.Controls.Add(this.txtOwnBloodQty);
            this.gpbBlood.Controls.Add(this.chkAllBlood);
            this.gpbBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbBlood.Location = new System.Drawing.Point(10, 364);
            this.gpbBlood.Name = "gpbBlood";
            this.gpbBlood.Size = new System.Drawing.Size(708, 48);
            this.gpbBlood.TabIndex = 840;
            this.gpbBlood.TabStop = false;
            this.gpbBlood.Text = "血制品";
            // 
            // txtBloodOther
            // 
            this.txtBloodOther.AccessibleDescription = "其他";
            this.txtBloodOther.BackColor = System.Drawing.Color.White;
            this.txtBloodOther.ForeColor = System.Drawing.Color.Black;
            this.txtBloodOther.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBloodOther.Location = new System.Drawing.Point(598, 21);
            this.txtBloodOther.m_BlnIgnoreUserInfo = false;
            this.txtBloodOther.m_BlnPartControl = false;
            this.txtBloodOther.m_BlnReadOnly = false;
            this.txtBloodOther.m_BlnUnderLineDST = false;
            this.txtBloodOther.m_ClrDST = System.Drawing.Color.Red;
            this.txtBloodOther.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBloodOther.m_IntCanModifyTime = 6;
            this.txtBloodOther.m_IntPartControlLength = 0;
            this.txtBloodOther.m_IntPartControlStartIndex = 0;
            this.txtBloodOther.m_StrUserID = "";
            this.txtBloodOther.m_StrUserName = "";
            this.txtBloodOther.Multiline = false;
            this.txtBloodOther.Name = "txtBloodOther";
            this.txtBloodOther.Size = new System.Drawing.Size(82, 20);
            this.txtBloodOther.TabIndex = 940;
            this.txtBloodOther.Text = "";
            // 
            // chkBloodOther
            // 
            this.chkBloodOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBloodOther.Location = new System.Drawing.Point(544, 19);
            this.chkBloodOther.Name = "chkBloodOther";
            this.chkBloodOther.Size = new System.Drawing.Size(60, 24);
            this.chkBloodOther.TabIndex = 930;
            this.chkBloodOther.Text = "其它";
            this.chkBloodOther.CheckedChanged += new System.EventHandler(this.chkBloodOther_CheckedChanged);
            // 
            // chkOwnBlood
            // 
            this.chkOwnBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkOwnBlood.Location = new System.Drawing.Point(382, 18);
            this.chkOwnBlood.Name = "chkOwnBlood";
            this.chkOwnBlood.Size = new System.Drawing.Size(84, 24);
            this.chkOwnBlood.TabIndex = 910;
            this.chkOwnBlood.Text = "输自体血";
            this.chkOwnBlood.CheckedChanged += new System.EventHandler(this.chkOwnBlood_CheckedChanged);
            // 
            // chkBloodPlasm
            // 
            this.chkBloodPlasm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBloodPlasm.Location = new System.Drawing.Point(254, 18);
            this.chkBloodPlasm.Name = "chkBloodPlasm";
            this.chkBloodPlasm.Size = new System.Drawing.Size(60, 24);
            this.chkBloodPlasm.TabIndex = 890;
            this.chkBloodPlasm.Text = "血浆";
            this.chkBloodPlasm.CheckedChanged += new System.EventHandler(this.chkBloodPlasm_CheckedChanged);
            // 
            // chkRedCell
            // 
            this.chkRedCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRedCell.Location = new System.Drawing.Point(124, 18);
            this.chkRedCell.Name = "chkRedCell";
            this.chkRedCell.Size = new System.Drawing.Size(72, 24);
            this.chkRedCell.TabIndex = 870;
            this.chkRedCell.Text = "红细胞";
            this.chkRedCell.CheckedChanged += new System.EventHandler(this.chkRedCell_CheckedChanged);
            // 
            // lblml11
            // 
            this.lblml11.AutoSize = true;
            this.lblml11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblml11.Location = new System.Drawing.Point(104, 22);
            this.lblml11.Name = "lblml11";
            this.lblml11.Size = new System.Drawing.Size(21, 14);
            this.lblml11.TabIndex = 5958;
            this.lblml11.Text = "ml";
            // 
            // txtAllBloodQty
            // 
            this.txtAllBloodQty.AccessibleDescription = "全血";
            this.txtAllBloodQty.BackColor = System.Drawing.Color.White;
            this.txtAllBloodQty.ForeColor = System.Drawing.Color.Black;
            this.txtAllBloodQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAllBloodQty.Location = new System.Drawing.Point(64, 22);
            this.txtAllBloodQty.m_BlnIgnoreUserInfo = false;
            this.txtAllBloodQty.m_BlnPartControl = false;
            this.txtAllBloodQty.m_BlnReadOnly = false;
            this.txtAllBloodQty.m_BlnUnderLineDST = false;
            this.txtAllBloodQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtAllBloodQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAllBloodQty.m_IntCanModifyTime = 6;
            this.txtAllBloodQty.m_IntPartControlLength = 0;
            this.txtAllBloodQty.m_IntPartControlStartIndex = 0;
            this.txtAllBloodQty.m_StrUserID = "";
            this.txtAllBloodQty.m_StrUserName = "";
            this.txtAllBloodQty.Multiline = false;
            this.txtAllBloodQty.Name = "txtAllBloodQty";
            this.txtAllBloodQty.Size = new System.Drawing.Size(40, 20);
            this.txtAllBloodQty.TabIndex = 860;
            this.txtAllBloodQty.Text = "";
            // 
            // lblml12
            // 
            this.lblml12.AutoSize = true;
            this.lblml12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblml12.Location = new System.Drawing.Point(232, 20);
            this.lblml12.Name = "lblml12";
            this.lblml12.Size = new System.Drawing.Size(24, 16);
            this.lblml12.TabIndex = 5956;
            this.lblml12.Text = "ml";
            // 
            // txtRedCellQty
            // 
            this.txtRedCellQty.AccessibleDescription = "红细胞";
            this.txtRedCellQty.BackColor = System.Drawing.Color.White;
            this.txtRedCellQty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRedCellQty.ForeColor = System.Drawing.Color.Black;
            this.txtRedCellQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtRedCellQty.Location = new System.Drawing.Point(196, 22);
            this.txtRedCellQty.m_BlnIgnoreUserInfo = false;
            this.txtRedCellQty.m_BlnPartControl = false;
            this.txtRedCellQty.m_BlnReadOnly = false;
            this.txtRedCellQty.m_BlnUnderLineDST = false;
            this.txtRedCellQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtRedCellQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtRedCellQty.m_IntCanModifyTime = 6;
            this.txtRedCellQty.m_IntPartControlLength = 0;
            this.txtRedCellQty.m_IntPartControlStartIndex = 0;
            this.txtRedCellQty.m_StrUserID = "";
            this.txtRedCellQty.m_StrUserName = "";
            this.txtRedCellQty.Multiline = false;
            this.txtRedCellQty.Name = "txtRedCellQty";
            this.txtRedCellQty.Size = new System.Drawing.Size(36, 20);
            this.txtRedCellQty.TabIndex = 880;
            this.txtRedCellQty.Text = "";
            // 
            // lblml13
            // 
            this.lblml13.AutoSize = true;
            this.lblml13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblml13.Location = new System.Drawing.Point(362, 22);
            this.lblml13.Name = "lblml13";
            this.lblml13.Size = new System.Drawing.Size(21, 14);
            this.lblml13.TabIndex = 5954;
            this.lblml13.Text = "ml";
            // 
            // txtBloodPlasmQty
            // 
            this.txtBloodPlasmQty.AccessibleDescription = "血浆";
            this.txtBloodPlasmQty.BackColor = System.Drawing.Color.White;
            this.txtBloodPlasmQty.ForeColor = System.Drawing.Color.Black;
            this.txtBloodPlasmQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtBloodPlasmQty.Location = new System.Drawing.Point(314, 22);
            this.txtBloodPlasmQty.m_BlnIgnoreUserInfo = false;
            this.txtBloodPlasmQty.m_BlnPartControl = false;
            this.txtBloodPlasmQty.m_BlnReadOnly = false;
            this.txtBloodPlasmQty.m_BlnUnderLineDST = false;
            this.txtBloodPlasmQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtBloodPlasmQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBloodPlasmQty.m_IntCanModifyTime = 6;
            this.txtBloodPlasmQty.m_IntPartControlLength = 0;
            this.txtBloodPlasmQty.m_IntPartControlStartIndex = 0;
            this.txtBloodPlasmQty.m_StrUserID = "";
            this.txtBloodPlasmQty.m_StrUserName = "";
            this.txtBloodPlasmQty.Multiline = false;
            this.txtBloodPlasmQty.Name = "txtBloodPlasmQty";
            this.txtBloodPlasmQty.Size = new System.Drawing.Size(48, 20);
            this.txtBloodPlasmQty.TabIndex = 900;
            this.txtBloodPlasmQty.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(522, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 5952;
            this.label11.Text = "ml";
            // 
            // txtOwnBloodQty
            // 
            this.txtOwnBloodQty.AccessibleDescription = "输自体血";
            this.txtOwnBloodQty.BackColor = System.Drawing.Color.White;
            this.txtOwnBloodQty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOwnBloodQty.ForeColor = System.Drawing.Color.Black;
            this.txtOwnBloodQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOwnBloodQty.Location = new System.Drawing.Point(466, 22);
            this.txtOwnBloodQty.m_BlnIgnoreUserInfo = false;
            this.txtOwnBloodQty.m_BlnPartControl = false;
            this.txtOwnBloodQty.m_BlnReadOnly = false;
            this.txtOwnBloodQty.m_BlnUnderLineDST = false;
            this.txtOwnBloodQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtOwnBloodQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOwnBloodQty.m_IntCanModifyTime = 6;
            this.txtOwnBloodQty.m_IntPartControlLength = 0;
            this.txtOwnBloodQty.m_IntPartControlStartIndex = 0;
            this.txtOwnBloodQty.m_StrUserID = "";
            this.txtOwnBloodQty.m_StrUserName = "";
            this.txtOwnBloodQty.Multiline = false;
            this.txtOwnBloodQty.Name = "txtOwnBloodQty";
            this.txtOwnBloodQty.Size = new System.Drawing.Size(56, 20);
            this.txtOwnBloodQty.TabIndex = 920;
            this.txtOwnBloodQty.Text = "";
            // 
            // chkAllBlood
            // 
            this.chkAllBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAllBlood.Location = new System.Drawing.Point(8, 18);
            this.chkAllBlood.Name = "chkAllBlood";
            this.chkAllBlood.Size = new System.Drawing.Size(56, 24);
            this.chkAllBlood.TabIndex = 850;
            this.chkAllBlood.Text = "全血";
            this.chkAllBlood.CheckedChanged += new System.EventHandler(this.chkAllBlood_CheckedChanged);
            // 
            // gpbOutFlow
            // 
            this.gpbOutFlow.BackColor = System.Drawing.SystemColors.Control;
            this.gpbOutFlow.Controls.Add(this.rdbHaveNotOutflow);
            this.gpbOutFlow.Controls.Add(this.rdbHaveOutFlow);
            this.gpbOutFlow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbOutFlow.Location = new System.Drawing.Point(12, 48);
            this.gpbOutFlow.Name = "gpbOutFlow";
            this.gpbOutFlow.Size = new System.Drawing.Size(394, 48);
            this.gpbOutFlow.TabIndex = 970;
            this.gpbOutFlow.TabStop = false;
            this.gpbOutFlow.Text = "伤口引流物情况";
            // 
            // rdbHaveNotOutflow
            // 
            this.rdbHaveNotOutflow.Checked = true;
            this.rdbHaveNotOutflow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbHaveNotOutflow.Location = new System.Drawing.Point(20, 20);
            this.rdbHaveNotOutflow.Name = "rdbHaveNotOutflow";
            this.rdbHaveNotOutflow.Size = new System.Drawing.Size(36, 24);
            this.rdbHaveNotOutflow.TabIndex = 980;
            this.rdbHaveNotOutflow.TabStop = true;
            this.rdbHaveNotOutflow.Text = "无";
            // 
            // rdbHaveOutFlow
            // 
            this.rdbHaveOutFlow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbHaveOutFlow.Location = new System.Drawing.Point(128, 20);
            this.rdbHaveOutFlow.Name = "rdbHaveOutFlow";
            this.rdbHaveOutFlow.Size = new System.Drawing.Size(40, 24);
            this.rdbHaveOutFlow.TabIndex = 990;
            this.rdbHaveOutFlow.Text = "有";
            // 
            // gpbFromHeadToFootSkinBeforeOperatio
            // 
            this.gpbFromHeadToFootSkinBeforeOperatio.BackColor = System.Drawing.SystemColors.Control;
            this.gpbFromHeadToFootSkinBeforeOperatio.Controls.Add(this.txtFromHeadToFootSkinBeforeOperationContent);
            this.gpbFromHeadToFootSkinBeforeOperatio.Controls.Add(this.lblFromHeadToFootSkinBeforeOperationContent);
            this.gpbFromHeadToFootSkinBeforeOperatio.Controls.Add(this.rdbFromHeadToFootSkinBeforeOperationFull);
            this.gpbFromHeadToFootSkinBeforeOperatio.Controls.Add(this.rdbFromHeadToFootSkinBeforeOperationMar);
            this.gpbFromHeadToFootSkinBeforeOperatio.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbFromHeadToFootSkinBeforeOperatio.Location = new System.Drawing.Point(10, 104);
            this.gpbFromHeadToFootSkinBeforeOperatio.Name = "gpbFromHeadToFootSkinBeforeOperatio";
            this.gpbFromHeadToFootSkinBeforeOperatio.Size = new System.Drawing.Size(368, 48);
            this.gpbFromHeadToFootSkinBeforeOperatio.TabIndex = 1010;
            this.gpbFromHeadToFootSkinBeforeOperatio.TabStop = false;
            this.gpbFromHeadToFootSkinBeforeOperatio.Text = "术前全身皮肤情况";
            // 
            // txtFromHeadToFootSkinBeforeOperationContent
            // 
            this.txtFromHeadToFootSkinBeforeOperationContent.AccessibleDescription = "损伤描述";
            this.txtFromHeadToFootSkinBeforeOperationContent.BackColor = System.Drawing.Color.White;
            this.txtFromHeadToFootSkinBeforeOperationContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFromHeadToFootSkinBeforeOperationContent.ForeColor = System.Drawing.Color.Black;
            this.txtFromHeadToFootSkinBeforeOperationContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFromHeadToFootSkinBeforeOperationContent.Location = new System.Drawing.Point(222, 19);
            this.txtFromHeadToFootSkinBeforeOperationContent.m_BlnIgnoreUserInfo = false;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_BlnPartControl = false;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_BlnReadOnly = false;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_BlnUnderLineDST = false;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_IntCanModifyTime = 6;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_IntPartControlLength = 0;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_IntPartControlStartIndex = 0;
            this.txtFromHeadToFootSkinBeforeOperationContent.m_StrUserID = "";
            this.txtFromHeadToFootSkinBeforeOperationContent.m_StrUserName = "";
            this.txtFromHeadToFootSkinBeforeOperationContent.Multiline = false;
            this.txtFromHeadToFootSkinBeforeOperationContent.Name = "txtFromHeadToFootSkinBeforeOperationContent";
            this.txtFromHeadToFootSkinBeforeOperationContent.Size = new System.Drawing.Size(112, 20);
            this.txtFromHeadToFootSkinBeforeOperationContent.TabIndex = 1040;
            this.txtFromHeadToFootSkinBeforeOperationContent.Text = "";
            // 
            // lblFromHeadToFootSkinBeforeOperationContent
            // 
            this.lblFromHeadToFootSkinBeforeOperationContent.AutoSize = true;
            this.lblFromHeadToFootSkinBeforeOperationContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFromHeadToFootSkinBeforeOperationContent.Location = new System.Drawing.Point(152, 22);
            this.lblFromHeadToFootSkinBeforeOperationContent.Name = "lblFromHeadToFootSkinBeforeOperationContent";
            this.lblFromHeadToFootSkinBeforeOperationContent.Size = new System.Drawing.Size(77, 14);
            this.lblFromHeadToFootSkinBeforeOperationContent.TabIndex = 5944;
            this.lblFromHeadToFootSkinBeforeOperationContent.Text = "损伤描述：";
            // 
            // rdbFromHeadToFootSkinBeforeOperationFull
            // 
            this.rdbFromHeadToFootSkinBeforeOperationFull.Checked = true;
            this.rdbFromHeadToFootSkinBeforeOperationFull.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbFromHeadToFootSkinBeforeOperationFull.Location = new System.Drawing.Point(10, 16);
            this.rdbFromHeadToFootSkinBeforeOperationFull.Name = "rdbFromHeadToFootSkinBeforeOperationFull";
            this.rdbFromHeadToFootSkinBeforeOperationFull.Size = new System.Drawing.Size(60, 24);
            this.rdbFromHeadToFootSkinBeforeOperationFull.TabIndex = 1020;
            this.rdbFromHeadToFootSkinBeforeOperationFull.TabStop = true;
            this.rdbFromHeadToFootSkinBeforeOperationFull.Text = "完整";
            this.rdbFromHeadToFootSkinBeforeOperationFull.CheckedChanged += new System.EventHandler(this.rdbFromHeadToFootSkinBeforeOperationFull_CheckedChanged);
            // 
            // rdbFromHeadToFootSkinBeforeOperationMar
            // 
            this.rdbFromHeadToFootSkinBeforeOperationMar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbFromHeadToFootSkinBeforeOperationMar.Location = new System.Drawing.Point(83, 16);
            this.rdbFromHeadToFootSkinBeforeOperationMar.Name = "rdbFromHeadToFootSkinBeforeOperationMar";
            this.rdbFromHeadToFootSkinBeforeOperationMar.Size = new System.Drawing.Size(56, 24);
            this.rdbFromHeadToFootSkinBeforeOperationMar.TabIndex = 1030;
            this.rdbFromHeadToFootSkinBeforeOperationMar.Text = "有损";
            // 
            // gpbFromto2
            // 
            this.gpbFromto2.BackColor = System.Drawing.SystemColors.Control;
            this.gpbFromto2.Controls.Add(this.txtFromHeadToFootSkinAfterOperationContent);
            this.gpbFromto2.Controls.Add(this.lblFromHeadToFootSkinAfterOperationContent);
            this.gpbFromto2.Controls.Add(this.rdbFromHeadToFootSkinAfterOperationFull);
            this.gpbFromto2.Controls.Add(this.rdbFromHeadToFootSkinAfterOperationMar);
            this.gpbFromto2.Location = new System.Drawing.Point(386, 104);
            this.gpbFromto2.Name = "gpbFromto2";
            this.gpbFromto2.Size = new System.Drawing.Size(346, 48);
            this.gpbFromto2.TabIndex = 1050;
            this.gpbFromto2.TabStop = false;
            this.gpbFromto2.Text = "术后全身皮肤情况";
            // 
            // txtFromHeadToFootSkinAfterOperationContent
            // 
            this.txtFromHeadToFootSkinAfterOperationContent.AccessibleDescription = "损伤描述";
            this.txtFromHeadToFootSkinAfterOperationContent.BackColor = System.Drawing.Color.White;
            this.txtFromHeadToFootSkinAfterOperationContent.ForeColor = System.Drawing.Color.Black;
            this.txtFromHeadToFootSkinAfterOperationContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFromHeadToFootSkinAfterOperationContent.Location = new System.Drawing.Point(198, 19);
            this.txtFromHeadToFootSkinAfterOperationContent.m_BlnIgnoreUserInfo = false;
            this.txtFromHeadToFootSkinAfterOperationContent.m_BlnPartControl = false;
            this.txtFromHeadToFootSkinAfterOperationContent.m_BlnReadOnly = false;
            this.txtFromHeadToFootSkinAfterOperationContent.m_BlnUnderLineDST = false;
            this.txtFromHeadToFootSkinAfterOperationContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtFromHeadToFootSkinAfterOperationContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtFromHeadToFootSkinAfterOperationContent.m_IntCanModifyTime = 6;
            this.txtFromHeadToFootSkinAfterOperationContent.m_IntPartControlLength = 0;
            this.txtFromHeadToFootSkinAfterOperationContent.m_IntPartControlStartIndex = 0;
            this.txtFromHeadToFootSkinAfterOperationContent.m_StrUserID = "";
            this.txtFromHeadToFootSkinAfterOperationContent.m_StrUserName = "";
            this.txtFromHeadToFootSkinAfterOperationContent.Multiline = false;
            this.txtFromHeadToFootSkinAfterOperationContent.Name = "txtFromHeadToFootSkinAfterOperationContent";
            this.txtFromHeadToFootSkinAfterOperationContent.Size = new System.Drawing.Size(127, 20);
            this.txtFromHeadToFootSkinAfterOperationContent.TabIndex = 1080;
            this.txtFromHeadToFootSkinAfterOperationContent.Text = "";
            // 
            // lblFromHeadToFootSkinAfterOperationContent
            // 
            this.lblFromHeadToFootSkinAfterOperationContent.AutoSize = true;
            this.lblFromHeadToFootSkinAfterOperationContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFromHeadToFootSkinAfterOperationContent.Location = new System.Drawing.Point(128, 21);
            this.lblFromHeadToFootSkinAfterOperationContent.Name = "lblFromHeadToFootSkinAfterOperationContent";
            this.lblFromHeadToFootSkinAfterOperationContent.Size = new System.Drawing.Size(77, 14);
            this.lblFromHeadToFootSkinAfterOperationContent.TabIndex = 5944;
            this.lblFromHeadToFootSkinAfterOperationContent.Text = "损伤描述：";
            // 
            // rdbFromHeadToFootSkinAfterOperationFull
            // 
            this.rdbFromHeadToFootSkinAfterOperationFull.Checked = true;
            this.rdbFromHeadToFootSkinAfterOperationFull.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbFromHeadToFootSkinAfterOperationFull.Location = new System.Drawing.Point(8, 16);
            this.rdbFromHeadToFootSkinAfterOperationFull.Name = "rdbFromHeadToFootSkinAfterOperationFull";
            this.rdbFromHeadToFootSkinAfterOperationFull.Size = new System.Drawing.Size(60, 24);
            this.rdbFromHeadToFootSkinAfterOperationFull.TabIndex = 1060;
            this.rdbFromHeadToFootSkinAfterOperationFull.TabStop = true;
            this.rdbFromHeadToFootSkinAfterOperationFull.Text = "完整";
            this.rdbFromHeadToFootSkinAfterOperationFull.CheckedChanged += new System.EventHandler(this.FromHeadToFootSkinAfterOperationFull_CheckedChanged);
            // 
            // rdbFromHeadToFootSkinAfterOperationMar
            // 
            this.rdbFromHeadToFootSkinAfterOperationMar.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbFromHeadToFootSkinAfterOperationMar.Location = new System.Drawing.Point(70, 16);
            this.rdbFromHeadToFootSkinAfterOperationMar.Name = "rdbFromHeadToFootSkinAfterOperationMar";
            this.rdbFromHeadToFootSkinAfterOperationMar.Size = new System.Drawing.Size(56, 24);
            this.rdbFromHeadToFootSkinAfterOperationMar.TabIndex = 1070;
            this.rdbFromHeadToFootSkinAfterOperationMar.Text = "有损";
            this.rdbFromHeadToFootSkinAfterOperationMar.CheckedChanged += new System.EventHandler(this.FromHeadToFootSkinAfterOperationFull_CheckedChanged);
            // 
            // txtSampleOtherContent
            // 
            this.txtSampleOtherContent.AccessibleDescription = "标本";
            this.txtSampleOtherContent.BackColor = System.Drawing.Color.White;
            this.txtSampleOtherContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSampleOtherContent.ForeColor = System.Drawing.Color.Black;
            this.txtSampleOtherContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSampleOtherContent.Location = new System.Drawing.Point(379, 18);
            this.txtSampleOtherContent.m_BlnIgnoreUserInfo = false;
            this.txtSampleOtherContent.m_BlnPartControl = false;
            this.txtSampleOtherContent.m_BlnReadOnly = false;
            this.txtSampleOtherContent.m_BlnUnderLineDST = false;
            this.txtSampleOtherContent.m_ClrDST = System.Drawing.Color.Red;
            this.txtSampleOtherContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSampleOtherContent.m_IntCanModifyTime = 6;
            this.txtSampleOtherContent.m_IntPartControlLength = 0;
            this.txtSampleOtherContent.m_IntPartControlStartIndex = 0;
            this.txtSampleOtherContent.m_StrUserID = "";
            this.txtSampleOtherContent.m_StrUserName = "";
            this.txtSampleOtherContent.Multiline = false;
            this.txtSampleOtherContent.Name = "txtSampleOtherContent";
            this.txtSampleOtherContent.Size = new System.Drawing.Size(69, 20);
            this.txtSampleOtherContent.TabIndex = 1260;
            this.txtSampleOtherContent.Text = "";
            // 
            // gpbSample
            // 
            this.gpbSample.BackColor = System.Drawing.SystemColors.Control;
            this.gpbSample.Controls.Add(this.txtSampleOtherContent);
            this.gpbSample.Controls.Add(this.chkSampleSlice);
            this.gpbSample.Controls.Add(this.chkSampleBacilli);
            this.gpbSample.Controls.Add(this.chkSampleOther);
            this.gpbSample.Controls.Add(this.chkSampleGeneral);
            this.gpbSample.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbSample.ForeColor = System.Drawing.Color.Black;
            this.gpbSample.Location = new System.Drawing.Point(270, 159);
            this.gpbSample.Name = "gpbSample";
            this.gpbSample.Size = new System.Drawing.Size(462, 48);
            this.gpbSample.TabIndex = 1090;
            this.gpbSample.TabStop = false;
            this.gpbSample.Text = "标本";
            // 
            // chkSampleSlice
            // 
            this.chkSampleSlice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSampleSlice.ForeColor = System.Drawing.Color.Black;
            this.chkSampleSlice.Location = new System.Drawing.Point(132, 18);
            this.chkSampleSlice.Name = "chkSampleSlice";
            this.chkSampleSlice.Size = new System.Drawing.Size(96, 24);
            this.chkSampleSlice.TabIndex = 1210;
            this.chkSampleSlice.Text = "冰冻切片";
            // 
            // chkSampleBacilli
            // 
            this.chkSampleBacilli.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSampleBacilli.ForeColor = System.Drawing.Color.Black;
            this.chkSampleBacilli.Location = new System.Drawing.Point(232, 18);
            this.chkSampleBacilli.Name = "chkSampleBacilli";
            this.chkSampleBacilli.Size = new System.Drawing.Size(88, 24);
            this.chkSampleBacilli.TabIndex = 1230;
            this.chkSampleBacilli.Text = "细菌培养";
            // 
            // chkSampleOther
            // 
            this.chkSampleOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSampleOther.ForeColor = System.Drawing.Color.Black;
            this.chkSampleOther.Location = new System.Drawing.Point(324, 18);
            this.chkSampleOther.Name = "chkSampleOther";
            this.chkSampleOther.Size = new System.Drawing.Size(64, 24);
            this.chkSampleOther.TabIndex = 1240;
            this.chkSampleOther.Text = "其它";
            this.chkSampleOther.CheckedChanged += new System.EventHandler(this.chkSampleOther_CheckedChanged);
            // 
            // chkSampleGeneral
            // 
            this.chkSampleGeneral.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkSampleGeneral.ForeColor = System.Drawing.Color.Black;
            this.chkSampleGeneral.Location = new System.Drawing.Point(12, 18);
            this.chkSampleGeneral.Name = "chkSampleGeneral";
            this.chkSampleGeneral.Size = new System.Drawing.Size(124, 24);
            this.chkSampleGeneral.TabIndex = 1200;
            this.chkSampleGeneral.Text = "常规病理检查";
            // 
            // gpbAfterOperationSend
            // 
            this.gpbAfterOperationSend.BackColor = System.Drawing.SystemColors.Control;
            this.gpbAfterOperationSend.Controls.Add(this.rdbAfterOperationSendSickRoom);
            this.gpbAfterOperationSend.Controls.Add(this.rdbAfterOperationSendRenew);
            this.gpbAfterOperationSend.Controls.Add(this.rdbAfterOperationSendICU);
            this.gpbAfterOperationSend.Location = new System.Drawing.Point(10, 159);
            this.gpbAfterOperationSend.Name = "gpbAfterOperationSend";
            this.gpbAfterOperationSend.Size = new System.Drawing.Size(252, 48);
            this.gpbAfterOperationSend.TabIndex = 1250;
            this.gpbAfterOperationSend.TabStop = false;
            this.gpbAfterOperationSend.Text = "术后送回";
            this.gpbAfterOperationSend.Enter += new System.EventHandler(this.gpbAfterOperationSend_Enter);
            // 
            // rdbAfterOperationSendSickRoom
            // 
            this.rdbAfterOperationSendSickRoom.Location = new System.Drawing.Point(184, 18);
            this.rdbAfterOperationSendSickRoom.Name = "rdbAfterOperationSendSickRoom";
            this.rdbAfterOperationSendSickRoom.Size = new System.Drawing.Size(56, 24);
            this.rdbAfterOperationSendSickRoom.TabIndex = 1280;
            this.rdbAfterOperationSendSickRoom.Text = "病房";
            // 
            // rdbAfterOperationSendRenew
            // 
            this.rdbAfterOperationSendRenew.Checked = true;
            this.rdbAfterOperationSendRenew.Location = new System.Drawing.Point(12, 18);
            this.rdbAfterOperationSendRenew.Name = "rdbAfterOperationSendRenew";
            this.rdbAfterOperationSendRenew.Size = new System.Drawing.Size(108, 24);
            this.rdbAfterOperationSendRenew.TabIndex = 1260;
            this.rdbAfterOperationSendRenew.TabStop = true;
            this.rdbAfterOperationSendRenew.Text = "麻醉复苏室";
            // 
            // rdbAfterOperationSendICU
            // 
            this.rdbAfterOperationSendICU.Location = new System.Drawing.Point(124, 18);
            this.rdbAfterOperationSendICU.Name = "rdbAfterOperationSendICU";
            this.rdbAfterOperationSendICU.Size = new System.Drawing.Size(56, 24);
            this.rdbAfterOperationSendICU.TabIndex = 1270;
            this.rdbAfterOperationSendICU.Text = "ICU";
            // 
            // dtgFromHeadToFootSkinAfterOperation
            // 
            this.dtgFromHeadToFootSkinAfterOperation.BackColor = System.Drawing.Color.White;
            this.dtgFromHeadToFootSkinAfterOperation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFromHeadToFootSkinAfterOperation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgFromHeadToFootSkinAfterOperation.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgFromHeadToFootSkinAfterOperation.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgFromHeadToFootSkinAfterOperation.CaptionText = "术后全身皮肤情况";
            this.dtgFromHeadToFootSkinAfterOperation.DataMember = "";
            this.dtgFromHeadToFootSkinAfterOperation.FlatMode = true;
            this.dtgFromHeadToFootSkinAfterOperation.ForeColor = System.Drawing.Color.Black;
            this.dtgFromHeadToFootSkinAfterOperation.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgFromHeadToFootSkinAfterOperation.HeaderForeColor = System.Drawing.Color.Black;
            this.dtgFromHeadToFootSkinAfterOperation.Location = new System.Drawing.Point(264, -12);
            this.dtgFromHeadToFootSkinAfterOperation.Name = "dtgFromHeadToFootSkinAfterOperation";
            this.dtgFromHeadToFootSkinAfterOperation.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgFromHeadToFootSkinAfterOperation.RowHeaderWidth = 10;
            this.dtgFromHeadToFootSkinAfterOperation.Size = new System.Drawing.Size(4, 12);
            this.dtgFromHeadToFootSkinAfterOperation.TabIndex = 5000;
            this.dtgFromHeadToFootSkinAfterOperation.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbFromHeadToFootSkinAfterOperationStyle});
            // 
            // dtbFromHeadToFootSkinAfterOperationStyle
            // 
            this.dtbFromHeadToFootSkinAfterOperationStyle.AllowSorting = false;
            this.dtbFromHeadToFootSkinAfterOperationStyle.DataGrid = this.dtgFromHeadToFootSkinAfterOperation;
            this.dtbFromHeadToFootSkinAfterOperationStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmFromHeadToFootSkinAfterOperationFull,
            this.dcmFromHeadToFootSkinAfterOperationMar,
            this.dcmFromHeadToFootSkinAfterOperationContent,
            this.dcmFromHeadToFootSkinAfterOperationSign,
            this.dcmFromHeadToFootSkinAfterOperationSignTime});
            this.dtbFromHeadToFootSkinAfterOperationStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbFromHeadToFootSkinAfterOperationStyle.MappingName = "FromHeadToFootSkinAfterOperation";
            // 
            // dcmFromHeadToFootSkinAfterOperationFull
            // 
            this.dcmFromHeadToFootSkinAfterOperationFull.HeaderText = "完好";
            this.dcmFromHeadToFootSkinAfterOperationFull.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFromHeadToFootSkinAfterOperationFull.MappingName = "完好";
            this.dcmFromHeadToFootSkinAfterOperationFull.NullText = "";
            this.dcmFromHeadToFootSkinAfterOperationFull.NullValue = null;
            this.dcmFromHeadToFootSkinAfterOperationFull.Width = 38;
            // 
            // dcmFromHeadToFootSkinAfterOperationMar
            // 
            this.dcmFromHeadToFootSkinAfterOperationMar.HeaderText = "损伤";
            this.dcmFromHeadToFootSkinAfterOperationMar.m_ClrDST = System.Drawing.Color.Red;
            this.dcmFromHeadToFootSkinAfterOperationMar.MappingName = "损伤";
            this.dcmFromHeadToFootSkinAfterOperationMar.NullText = "";
            this.dcmFromHeadToFootSkinAfterOperationMar.NullValue = null;
            this.dcmFromHeadToFootSkinAfterOperationMar.Width = 38;
            // 
            // dcmFromHeadToFootSkinAfterOperationContent
            // 
            this.dcmFromHeadToFootSkinAfterOperationContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinAfterOperationContent.HeaderText = "描述";
            this.dcmFromHeadToFootSkinAfterOperationContent.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinAfterOperationContent.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinAfterOperationContent.MappingName = "描述";
            this.dcmFromHeadToFootSkinAfterOperationContent.NullText = "";
            this.dcmFromHeadToFootSkinAfterOperationContent.Width = 75;
            // 
            // dcmFromHeadToFootSkinAfterOperationSign
            // 
            this.dcmFromHeadToFootSkinAfterOperationSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinAfterOperationSign.HeaderText = "签名";
            this.dcmFromHeadToFootSkinAfterOperationSign.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinAfterOperationSign.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinAfterOperationSign.MappingName = "签名";
            this.dcmFromHeadToFootSkinAfterOperationSign.NullText = "";
            this.dcmFromHeadToFootSkinAfterOperationSign.Width = 50;
            // 
            // dcmFromHeadToFootSkinAfterOperationSignTime
            // 
            this.dcmFromHeadToFootSkinAfterOperationSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmFromHeadToFootSkinAfterOperationSignTime.HeaderText = "日期";
            this.dcmFromHeadToFootSkinAfterOperationSignTime.m_BlnGobleSet = true;
            this.dcmFromHeadToFootSkinAfterOperationSignTime.m_BlnUnderLineDST = false;
            this.dcmFromHeadToFootSkinAfterOperationSignTime.MappingName = "日期";
            this.dcmFromHeadToFootSkinAfterOperationSignTime.NullText = "";
            this.dcmFromHeadToFootSkinAfterOperationSignTime.Width = 145;
            // 
            // lblOpenDateTime
            // 
            this.lblOpenDateTime.AutoSize = true;
            this.lblOpenDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOpenDateTime.Location = new System.Drawing.Point(220, 71);
            this.lblOpenDateTime.Name = "lblOpenDateTime";
            this.lblOpenDateTime.Size = new System.Drawing.Size(70, 14);
            this.lblOpenDateTime.TabIndex = 624;
            this.lblOpenDateTime.Text = "记录时间:";
            // 
            // dtpRecordTime
            // 
            this.dtpRecordTime.BorderColor = System.Drawing.Color.Black;
            this.dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRecordTime.Location = new System.Drawing.Point(294, 67);
            this.dtpRecordTime.m_BlnOnlyTime = false;
            this.dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpRecordTime.Name = "dtpRecordTime";
            this.dtpRecordTime.ReadOnly = false;
            this.dtpRecordTime.Size = new System.Drawing.Size(214, 22);
            this.dtpRecordTime.TabIndex = 40;
            this.dtpRecordTime.TextBackColor = System.Drawing.Color.White;
            this.dtpRecordTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.FullRowSelect = true;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(15, 64);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(193, 64);
            this.trvTime.TabIndex = 30;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // ctmRichTextBoxMenu
            // 
            this.ctmRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDoubleStrikeOutDelete});
            // 
            // mniDoubleStrikeOutDelete
            // 
            this.mniDoubleStrikeOutDelete.Index = 0;
            this.mniDoubleStrikeOutDelete.Text = "双划线删除";
            this.mniDoubleStrikeOutDelete.Click += new System.EventHandler(this.mniDoubleStrikeOutDelete_Click);
            // 
            // dtgOperationIDAndAnaesthesia
            // 
            this.dtgOperationIDAndAnaesthesia.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgOperationIDAndAnaesthesia.BackColor = System.Drawing.Color.White;
            this.dtgOperationIDAndAnaesthesia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOperationIDAndAnaesthesia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgOperationIDAndAnaesthesia.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgOperationIDAndAnaesthesia.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgOperationIDAndAnaesthesia.CaptionText = "手术名称与麻醉方式";
            this.dtgOperationIDAndAnaesthesia.DataMember = "";
            this.dtgOperationIDAndAnaesthesia.FlatMode = true;
            this.dtgOperationIDAndAnaesthesia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgOperationIDAndAnaesthesia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtgOperationIDAndAnaesthesia.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtgOperationIDAndAnaesthesia.Location = new System.Drawing.Point(156, -144);
            this.dtgOperationIDAndAnaesthesia.Name = "dtgOperationIDAndAnaesthesia";
            this.dtgOperationIDAndAnaesthesia.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgOperationIDAndAnaesthesia.RowHeaderWidth = 10;
            this.dtgOperationIDAndAnaesthesia.Size = new System.Drawing.Size(4, 37);
            this.dtgOperationIDAndAnaesthesia.TabIndex = 5000;
            this.dtgOperationIDAndAnaesthesia.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dtbOperationIDAndAnaesthesiaStyle});
            // 
            // dtbOperationIDAndAnaesthesiaStyle
            // 
            this.dtbOperationIDAndAnaesthesiaStyle.AllowSorting = false;
            this.dtbOperationIDAndAnaesthesiaStyle.DataGrid = this.dtgOperationIDAndAnaesthesia;
            this.dtbOperationIDAndAnaesthesiaStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmAnaesthesia,
            this.dcmOperationID,
            this.dcmSign,
            this.dcmSignTime});
            this.dtbOperationIDAndAnaesthesiaStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtbOperationIDAndAnaesthesiaStyle.MappingName = "OperationIDAndAnaesthesia";
            // 
            // dcmAnaesthesia
            // 
            this.dcmAnaesthesia.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmAnaesthesia.HeaderText = "手术名称";
            this.dcmAnaesthesia.m_BlnGobleSet = true;
            this.dcmAnaesthesia.m_BlnUnderLineDST = false;
            this.dcmAnaesthesia.MappingName = "手术名称";
            this.dcmAnaesthesia.NullText = "";
            this.dcmAnaesthesia.Width = 200;
            // 
            // dcmOperationID
            // 
            this.dcmOperationID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmOperationID.HeaderText = "麻醉方式";
            this.dcmOperationID.m_BlnGobleSet = true;
            this.dcmOperationID.m_BlnUnderLineDST = false;
            this.dcmOperationID.MappingName = "麻醉方式";
            this.dcmOperationID.NullText = "";
            this.dcmOperationID.Width = 200;
            // 
            // dcmSign
            // 
            this.dcmSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSign.HeaderText = "签名";
            this.dcmSign.m_BlnGobleSet = true;
            this.dcmSign.m_BlnUnderLineDST = false;
            this.dcmSign.MappingName = "签名";
            this.dcmSign.NullText = "";
            this.dcmSign.Width = 59;
            // 
            // dcmSignTime
            // 
            this.dcmSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSignTime.HeaderText = "日期";
            this.dcmSignTime.m_BlnGobleSet = true;
            this.dcmSignTime.m_BlnUnderLineDST = false;
            this.dcmSignTime.MappingName = "日期";
            this.dcmSignTime.NullText = "";
            this.dcmSignTime.Width = 145;
            // 
            // dtgSences
            // 
            this.dtgSences.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgSences.BackColor = System.Drawing.Color.White;
            this.dtgSences.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSences.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.dtgSences.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgSences.CaptionText = "神志";
            this.dtgSences.DataMember = "";
            this.dtgSences.FlatMode = true;
            this.dtgSences.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgSences.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtgSences.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtgSences.Location = new System.Drawing.Point(56, -144);
            this.dtgSences.Name = "dtgSences";
            this.dtgSences.ParentRowsForeColor = System.Drawing.Color.White;
            this.dtgSences.RowHeaderWidth = 10;
            this.dtgSences.Size = new System.Drawing.Size(4, 37);
            this.dtgSences.TabIndex = 5000;
            this.dtgSences.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dcmSencesStyle});
            this.dtgSences.CurrentCellChanged += new System.EventHandler(this.dtgSences_CurrentCellChanged);
            // 
            // dcmSencesStyle
            // 
            this.dcmSencesStyle.AllowSorting = false;
            this.dcmSencesStyle.DataGrid = this.dtgSences;
            this.dcmSencesStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dcmSencesClear,
            this.dcmSencesSleep,
            this.dcmSencesComa,
            this.dcmSencesSign,
            this.dcmSencesSignTime});
            this.dcmSencesStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dcmSencesStyle.MappingName = "Sences";
            // 
            // dcmSencesClear
            // 
            this.dcmSencesClear.HeaderText = "清醒";
            this.dcmSencesClear.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSencesClear.MappingName = "清醒";
            this.dcmSencesClear.NullText = "";
            this.dcmSencesClear.NullValue = null;
            this.dcmSencesClear.Width = 37;
            // 
            // dcmSencesSleep
            // 
            this.dcmSencesSleep.HeaderText = "嗜睡";
            this.dcmSencesSleep.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSencesSleep.MappingName = "嗜睡";
            this.dcmSencesSleep.NullText = "";
            this.dcmSencesSleep.NullValue = null;
            this.dcmSencesSleep.Width = 37;
            // 
            // dcmSencesComa
            // 
            this.dcmSencesComa.HeaderText = "昏迷";
            this.dcmSencesComa.m_ClrDST = System.Drawing.Color.Red;
            this.dcmSencesComa.MappingName = "昏迷";
            this.dcmSencesComa.NullText = "";
            this.dcmSencesComa.NullValue = null;
            this.dcmSencesComa.Width = 37;
            // 
            // dcmSencesSign
            // 
            this.dcmSencesSign.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSencesSign.HeaderText = "签名";
            this.dcmSencesSign.m_BlnGobleSet = true;
            this.dcmSencesSign.m_BlnUnderLineDST = false;
            this.dcmSencesSign.MappingName = "签名";
            this.dcmSencesSign.NullText = "";
            this.dcmSencesSign.Width = 72;
            // 
            // dcmSencesSignTime
            // 
            this.dcmSencesSignTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dcmSencesSignTime.HeaderText = "日期";
            this.dcmSencesSignTime.m_BlnGobleSet = true;
            this.dcmSencesSignTime.m_BlnUnderLineDST = false;
            this.dcmSencesSignTime.MappingName = "日期";
            this.dcmSencesSignTime.NullText = "";
            this.dcmSencesSignTime.Width = 145;
            // 
            // cboAnaesthesiaModeID
            // 
            this.cboAnaesthesiaModeID.BackColor = System.Drawing.Color.White;
            this.cboAnaesthesiaModeID.BorderColor = System.Drawing.Color.Black;
            this.cboAnaesthesiaModeID.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.cboAnaesthesiaModeID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.cboAnaesthesiaModeID.DropButtonForeColor = System.Drawing.Color.Black;
            this.cboAnaesthesiaModeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboAnaesthesiaModeID.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboAnaesthesiaModeID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboAnaesthesiaModeID.ForeColor = System.Drawing.Color.Black;
            this.cboAnaesthesiaModeID.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.cboAnaesthesiaModeID.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.cboAnaesthesiaModeID.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.cboAnaesthesiaModeID.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboAnaesthesiaModeID.Location = new System.Drawing.Point(524, 102);
            this.cboAnaesthesiaModeID.m_BlnEnableItemEventMenu = false;
            this.cboAnaesthesiaModeID.Name = "cboAnaesthesiaModeID";
            this.cboAnaesthesiaModeID.SelectedIndex = -1;
            this.cboAnaesthesiaModeID.SelectedItem = null;
            this.cboAnaesthesiaModeID.SelectionStart = 0;
            this.cboAnaesthesiaModeID.Size = new System.Drawing.Size(147, 26);
            this.cboAnaesthesiaModeID.TabIndex = 60;
            this.cboAnaesthesiaModeID.TextBackColor = System.Drawing.Color.White;
            this.cboAnaesthesiaModeID.TextForeColor = System.Drawing.Color.Black;
            // 
            // cboOperationID
            // 
            this.cboOperationID.BackColor = System.Drawing.Color.White;
            this.cboOperationID.BorderColor = System.Drawing.Color.Black;
            this.cboOperationID.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.cboOperationID.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.cboOperationID.DropButtonForeColor = System.Drawing.Color.Black;
            this.cboOperationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboOperationID.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboOperationID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboOperationID.ForeColor = System.Drawing.Color.Black;
            this.cboOperationID.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.cboOperationID.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.cboOperationID.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.cboOperationID.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboOperationID.Location = new System.Drawing.Point(294, 102);
            this.cboOperationID.m_BlnEnableItemEventMenu = false;
            this.cboOperationID.Name = "cboOperationID";
            this.cboOperationID.SelectedIndex = -1;
            this.cboOperationID.SelectedItem = null;
            this.cboOperationID.SelectionStart = 0;
            this.cboOperationID.Size = new System.Drawing.Size(149, 26);
            this.cboOperationID.TabIndex = 50;
            this.cboOperationID.TextBackColor = System.Drawing.Color.White;
            this.cboOperationID.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdShowHistoryRecord
            // 
            this.m_cmdShowHistoryRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdShowHistoryRecord.Location = new System.Drawing.Point(589, 183);
            this.m_cmdShowHistoryRecord.Name = "m_cmdShowHistoryRecord";
            this.m_cmdShowHistoryRecord.Size = new System.Drawing.Size(176, 70);
            this.m_cmdShowHistoryRecord.TabIndex = 30004;
            this.m_cmdShowHistoryRecord.Text = "显示历史记录";
            this.m_cmdShowHistoryRecord.Visible = false;
            this.m_cmdShowHistoryRecord.Click += new System.EventHandler(this.m_cmdShowHistoryRecord_Click);
            // 
            // m_pnlOperationBefore
            // 
            this.m_pnlOperationBefore.BackColor = System.Drawing.SystemColors.Control;
            this.m_pnlOperationBefore.Controls.Add(this.lblPatientInDateTitle);
            this.m_pnlOperationBefore.Controls.Add(this.dtpPatientInDate);
            this.m_pnlOperationBefore.Location = new System.Drawing.Point(10, 10);
            this.m_pnlOperationBefore.Name = "m_pnlOperationBefore";
            this.m_pnlOperationBefore.Size = new System.Drawing.Size(352, 28);
            this.m_pnlOperationBefore.TabIndex = 70;
            // 
            // lblPatientInDateTitle
            // 
            this.lblPatientInDateTitle.AutoSize = true;
            this.lblPatientInDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientInDateTitle.Location = new System.Drawing.Point(4, 6);
            this.lblPatientInDateTitle.Name = "lblPatientInDateTitle";
            this.lblPatientInDateTitle.Size = new System.Drawing.Size(105, 14);
            this.lblPatientInDateTitle.TabIndex = 515;
            this.lblPatientInDateTitle.Text = "病人入室时间：";
            this.lblPatientInDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPatientInDate
            // 
            this.dtpPatientInDate.BackColor = System.Drawing.Color.Black;
            this.dtpPatientInDate.BorderColor = System.Drawing.Color.Black;
            this.dtpPatientInDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpPatientInDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpPatientInDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpPatientInDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpPatientInDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpPatientInDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpPatientInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPatientInDate.Location = new System.Drawing.Point(126, 2);
            this.dtpPatientInDate.m_BlnOnlyTime = false;
            this.dtpPatientInDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpPatientInDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPatientInDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPatientInDate.Name = "dtpPatientInDate";
            this.dtpPatientInDate.ReadOnly = false;
            this.dtpPatientInDate.Size = new System.Drawing.Size(212, 22);
            this.dtpPatientInDate.TabIndex = 71;
            this.dtpPatientInDate.TextBackColor = System.Drawing.Color.White;
            this.dtpPatientInDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblBeforeOperation
            // 
            this.lblBeforeOperation.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBeforeOperation.Location = new System.Drawing.Point(706, 103);
            this.lblBeforeOperation.Name = "lblBeforeOperation";
            this.lblBeforeOperation.Size = new System.Drawing.Size(8, 12);
            this.lblBeforeOperation.TabIndex = 516;
            this.lblBeforeOperation.Text = "术前情况";
            this.lblBeforeOperation.Visible = false;
            // 
            // pnlPanel2
            // 
            this.pnlPanel2.Controls.Add(this.lblTendInOperation);
            this.pnlPanel2.Controls.Add(this.dtgDownStyptic);
            this.pnlPanel2.Controls.Add(this.dtgFromHeadToFootSkinAfterOperation);
            this.pnlPanel2.Controls.Add(this.dtgAllergic);
            this.pnlPanel2.Controls.Add(this.dtgAfterOperationSendAfterOperationSend);
            this.pnlPanel2.Controls.Add(this.dtgOperationIDAndAnaesthesia);
            this.pnlPanel2.Controls.Add(this.dtgUpStyptic);
            this.pnlPanel2.Controls.Add(this.dtgStomach);
            this.pnlPanel2.Controls.Add(this.dtgBlood);
            this.pnlPanel2.Controls.Add(this.dtgCathodeLocationSkin);
            this.pnlPanel2.Controls.Add(this.dtgStypticRubber);
            this.pnlPanel2.Controls.Add(this.dtgSample);
            this.pnlPanel2.Controls.Add(this.dtgDoublePole);
            this.pnlPanel2.Controls.Add(this.dtgSences);
            this.pnlPanel2.Controls.Add(this.dtgFoley);
            this.pnlPanel2.Controls.Add(this.dtgOutFlow);
            this.pnlPanel2.Controls.Add(this.dtgCathodeLocationAfterOperationSkin);
            this.pnlPanel2.Location = new System.Drawing.Point(128, -136);
            this.pnlPanel2.Name = "pnlPanel2";
            this.pnlPanel2.Size = new System.Drawing.Size(67, 132);
            this.pnlPanel2.TabIndex = 250;
            // 
            // lblTendInOperation
            // 
            this.lblTendInOperation.AutoSize = true;
            this.lblTendInOperation.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTendInOperation.Location = new System.Drawing.Point(8, 96);
            this.lblTendInOperation.Name = "lblTendInOperation";
            this.lblTendInOperation.Size = new System.Drawing.Size(89, 19);
            this.lblTendInOperation.TabIndex = 529;
            this.lblTendInOperation.Text = "术中护理";
            // 
            // lblOperationRoomTitle
            // 
            this.lblOperationRoomTitle.AutoSize = true;
            this.lblOperationRoomTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOperationRoomTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationRoomTitle.Location = new System.Drawing.Point(10, 175);
            this.lblOperationRoomTitle.Name = "lblOperationRoomTitle";
            this.lblOperationRoomTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOperationRoomTitle.TabIndex = 528;
            this.lblOperationRoomTitle.Text = "手术间：";
            this.lblOperationRoomTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(315, 175);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(98, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 527;
            this.lblOperationBeginTimeTitle.Text = "手术开始时间:";
            this.lblOperationBeginTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOperationOverTime
            // 
            this.lblOperationOverTime.AutoSize = true;
            this.lblOperationOverTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblOperationOverTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationOverTime.Location = new System.Drawing.Point(10, 205);
            this.lblOperationOverTime.Name = "lblOperationOverTime";
            this.lblOperationOverTime.Size = new System.Drawing.Size(77, 14);
            this.lblOperationOverTime.TabIndex = 526;
            this.lblOperationOverTime.Text = "术毕时间：";
            this.lblOperationOverTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeaveRoomTime
            // 
            this.lblLeaveRoomTime.AutoSize = true;
            this.lblLeaveRoomTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblLeaveRoomTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeaveRoomTime.Location = new System.Drawing.Point(315, 205);
            this.lblLeaveRoomTime.Name = "lblLeaveRoomTime";
            this.lblLeaveRoomTime.Size = new System.Drawing.Size(77, 14);
            this.lblLeaveRoomTime.TabIndex = 525;
            this.lblLeaveRoomTime.Text = "离室时间：";
            this.lblLeaveRoomTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.BackColor = System.Drawing.SystemColors.Control;
            this.lblCheck.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheck.Location = new System.Drawing.Point(10, 235);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(246, 19);
            this.lblCheck.TabIndex = 524;
            this.lblCheck.Text = "无菌包监测：       合格";
            this.lblCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpLeaveRoomTime
            // 
            this.dtpLeaveRoomTime.BorderColor = System.Drawing.Color.Black;
            this.dtpLeaveRoomTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpLeaveRoomTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpLeaveRoomTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpLeaveRoomTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpLeaveRoomTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpLeaveRoomTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpLeaveRoomTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveRoomTime.Location = new System.Drawing.Point(387, 202);
            this.dtpLeaveRoomTime.m_BlnOnlyTime = false;
            this.dtpLeaveRoomTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpLeaveRoomTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLeaveRoomTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveRoomTime.Name = "dtpLeaveRoomTime";
            this.dtpLeaveRoomTime.ReadOnly = false;
            this.dtpLeaveRoomTime.Size = new System.Drawing.Size(212, 22);
            this.dtpLeaveRoomTime.TabIndex = 523;
            this.dtpLeaveRoomTime.TextBackColor = System.Drawing.Color.White;
            this.dtpLeaveRoomTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // dtpOperationOverTime
            // 
            this.dtpOperationOverTime.BackColor = System.Drawing.SystemColors.Control;
            this.dtpOperationOverTime.BorderColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpOperationOverTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpOperationOverTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpOperationOverTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationOverTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOperationOverTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperationOverTime.Location = new System.Drawing.Point(82, 202);
            this.dtpOperationOverTime.m_BlnOnlyTime = false;
            this.dtpOperationOverTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpOperationOverTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOperationOverTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOperationOverTime.Name = "dtpOperationOverTime";
            this.dtpOperationOverTime.ReadOnly = false;
            this.dtpOperationOverTime.Size = new System.Drawing.Size(212, 22);
            this.dtpOperationOverTime.TabIndex = 522;
            this.dtpOperationOverTime.TextBackColor = System.Drawing.Color.White;
            this.dtpOperationOverTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // dtpOperationBeginTime
            // 
            this.dtpOperationBeginTime.BorderColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpOperationBeginTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpOperationBeginTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpOperationBeginTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationBeginTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOperationBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperationBeginTime.Location = new System.Drawing.Point(414, 172);
            this.dtpOperationBeginTime.m_BlnOnlyTime = false;
            this.dtpOperationBeginTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpOperationBeginTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOperationBeginTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOperationBeginTime.Name = "dtpOperationBeginTime";
            this.dtpOperationBeginTime.ReadOnly = false;
            this.dtpOperationBeginTime.Size = new System.Drawing.Size(212, 22);
            this.dtpOperationBeginTime.TabIndex = 521;
            this.dtpOperationBeginTime.TextBackColor = System.Drawing.Color.White;
            this.dtpOperationBeginTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // txtOperationRoom
            // 
            this.txtOperationRoom.AccessibleDescription = "手术时间";
            this.txtOperationRoom.BackColor = System.Drawing.Color.White;
            this.txtOperationRoom.ForeColor = System.Drawing.Color.Black;
            this.txtOperationRoom.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOperationRoom.Location = new System.Drawing.Point(69, 173);
            this.txtOperationRoom.m_BlnIgnoreUserInfo = false;
            this.txtOperationRoom.m_BlnPartControl = false;
            this.txtOperationRoom.m_BlnReadOnly = false;
            this.txtOperationRoom.m_BlnUnderLineDST = false;
            this.txtOperationRoom.m_ClrDST = System.Drawing.Color.Red;
            this.txtOperationRoom.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOperationRoom.m_IntCanModifyTime = 6;
            this.txtOperationRoom.m_IntPartControlLength = 0;
            this.txtOperationRoom.m_IntPartControlStartIndex = 0;
            this.txtOperationRoom.m_StrUserID = "";
            this.txtOperationRoom.m_StrUserName = "";
            this.txtOperationRoom.Multiline = false;
            this.txtOperationRoom.Name = "txtOperationRoom";
            this.txtOperationRoom.Size = new System.Drawing.Size(225, 20);
            this.txtOperationRoom.TabIndex = 520;
            this.txtOperationRoom.Text = "";
            // 
            // pnlPanel3
            // 
            this.pnlPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPanel3.Controls.Add(this.txtPeeOperatingQty);
            this.pnlPanel3.Controls.Add(this.txtInLiquidQty);
            this.pnlPanel3.Controls.Add(this.lblMl2);
            this.pnlPanel3.Controls.Add(this.lblMl1);
            this.pnlPanel3.Controls.Add(this.lblInLiquidQtyTitle);
            this.pnlPanel3.Controls.Add(this.lblPeeOperatingQty);
            this.pnlPanel3.Location = new System.Drawing.Point(10, 10);
            this.pnlPanel3.Name = "pnlPanel3";
            this.pnlPanel3.Size = new System.Drawing.Size(396, 32);
            this.pnlPanel3.TabIndex = 950;
            // 
            // txtPeeOperatingQty
            // 
            this.txtPeeOperatingQty.AccessibleDescription = "术中尿量";
            this.txtPeeOperatingQty.BackColor = System.Drawing.Color.White;
            this.txtPeeOperatingQty.ForeColor = System.Drawing.Color.Black;
            this.txtPeeOperatingQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPeeOperatingQty.Location = new System.Drawing.Point(285, 5);
            this.txtPeeOperatingQty.m_BlnIgnoreUserInfo = false;
            this.txtPeeOperatingQty.m_BlnPartControl = false;
            this.txtPeeOperatingQty.m_BlnReadOnly = false;
            this.txtPeeOperatingQty.m_BlnUnderLineDST = false;
            this.txtPeeOperatingQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtPeeOperatingQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtPeeOperatingQty.m_IntCanModifyTime = 6;
            this.txtPeeOperatingQty.m_IntPartControlLength = 0;
            this.txtPeeOperatingQty.m_IntPartControlStartIndex = 0;
            this.txtPeeOperatingQty.m_StrUserID = "";
            this.txtPeeOperatingQty.m_StrUserName = "";
            this.txtPeeOperatingQty.Multiline = false;
            this.txtPeeOperatingQty.Name = "txtPeeOperatingQty";
            this.txtPeeOperatingQty.Size = new System.Drawing.Size(48, 20);
            this.txtPeeOperatingQty.TabIndex = 966;
            this.txtPeeOperatingQty.Text = "";
            // 
            // txtInLiquidQty
            // 
            this.txtInLiquidQty.AccessibleDescription = "输入液体量";
            this.txtInLiquidQty.BackColor = System.Drawing.Color.White;
            this.txtInLiquidQty.ForeColor = System.Drawing.Color.Black;
            this.txtInLiquidQty.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtInLiquidQty.Location = new System.Drawing.Point(87, 5);
            this.txtInLiquidQty.m_BlnIgnoreUserInfo = false;
            this.txtInLiquidQty.m_BlnPartControl = false;
            this.txtInLiquidQty.m_BlnReadOnly = false;
            this.txtInLiquidQty.m_BlnUnderLineDST = false;
            this.txtInLiquidQty.m_ClrDST = System.Drawing.Color.Red;
            this.txtInLiquidQty.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtInLiquidQty.m_IntCanModifyTime = 6;
            this.txtInLiquidQty.m_IntPartControlLength = 0;
            this.txtInLiquidQty.m_IntPartControlStartIndex = 0;
            this.txtInLiquidQty.m_StrUserID = "";
            this.txtInLiquidQty.m_StrUserName = "";
            this.txtInLiquidQty.Multiline = false;
            this.txtInLiquidQty.Name = "txtInLiquidQty";
            this.txtInLiquidQty.Size = new System.Drawing.Size(60, 20);
            this.txtInLiquidQty.TabIndex = 965;
            this.txtInLiquidQty.Text = "";
            // 
            // lblMl2
            // 
            this.lblMl2.AutoSize = true;
            this.lblMl2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMl2.Location = new System.Drawing.Point(339, 8);
            this.lblMl2.Name = "lblMl2";
            this.lblMl2.Size = new System.Drawing.Size(21, 14);
            this.lblMl2.TabIndex = 964;
            this.lblMl2.Text = "ml";
            // 
            // lblMl1
            // 
            this.lblMl1.AutoSize = true;
            this.lblMl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMl1.Location = new System.Drawing.Point(153, 8);
            this.lblMl1.Name = "lblMl1";
            this.lblMl1.Size = new System.Drawing.Size(21, 14);
            this.lblMl1.TabIndex = 963;
            this.lblMl1.Text = "ml";
            // 
            // lblInLiquidQtyTitle
            // 
            this.lblInLiquidQtyTitle.AutoSize = true;
            this.lblInLiquidQtyTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInLiquidQtyTitle.Location = new System.Drawing.Point(4, 8);
            this.lblInLiquidQtyTitle.Name = "lblInLiquidQtyTitle";
            this.lblInLiquidQtyTitle.Size = new System.Drawing.Size(91, 14);
            this.lblInLiquidQtyTitle.TabIndex = 962;
            this.lblInLiquidQtyTitle.Text = "输入液体量：";
            // 
            // lblPeeOperatingQty
            // 
            this.lblPeeOperatingQty.AutoSize = true;
            this.lblPeeOperatingQty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPeeOperatingQty.Location = new System.Drawing.Point(215, 8);
            this.lblPeeOperatingQty.Name = "lblPeeOperatingQty";
            this.lblPeeOperatingQty.Size = new System.Drawing.Size(77, 14);
            this.lblPeeOperatingQty.TabIndex = 961;
            this.lblPeeOperatingQty.Text = "术中尿量：";
            // 
            // m_lblBlank
            // 
            this.m_lblBlank.Location = new System.Drawing.Point(304, -2230);
            this.m_lblBlank.Name = "m_lblBlank";
            this.m_lblBlank.Size = new System.Drawing.Size(136, 87);
            this.m_lblBlank.TabIndex = 2000;
            // 
            // m_dtgWound
            // 
            this.m_dtgWound.DataMember = "";
            this.m_dtgWound.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtgWound.Location = new System.Drawing.Point(16, -2230);
            this.m_dtgWound.Name = "m_dtgWound";
            this.m_dtgWound.Size = new System.Drawing.Size(264, 79);
            this.m_dtgWound.TabIndex = 10000001;
            this.m_dtgWound.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.m_dtgWound.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.m_dtgWound;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "TableWound";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "名称";
            this.dataGridTextBoxColumn1.MappingName = "Name";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "数量";
            this.dataGridTextBoxColumn2.MappingName = "Quantity";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(399, 320);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(48, 36);
            this.tabControl1.TabIndex = 10000028;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(40, 9);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "术前情况";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.m_lblBlank);
            this.tabPage2.Controls.Add(this.m_dtgWound);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(40, 9);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "术中记录一";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(40, 9);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "术中记录二";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dtpOperationBeginTime);
            this.panel2.Controls.Add(this.dtpLeaveRoomTime);
            this.panel2.Controls.Add(this.dtpOperationOverTime);
            this.panel2.Controls.Add(this.txtOperationRoom);
            this.panel2.Controls.Add(this.lblOperationRoomTitle);
            this.panel2.Controls.Add(this.gpbSences);
            this.panel2.Controls.Add(this.lblOperationBeginTimeTitle);
            this.panel2.Controls.Add(this.lblOperationOverTime);
            this.panel2.Controls.Add(this.gpbAllergic);
            this.panel2.Controls.Add(this.lblLeaveRoomTime);
            this.panel2.Controls.Add(this.lblCheck);
            this.panel2.Controls.Add(this.m_pnlOperationBefore);
            this.panel2.Controls.Add(this.gpbOperationLocation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 438);
            this.panel2.TabIndex = 529;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.gpbElectKnife);
            this.panel1.Controls.Add(this.gpbDoublePole);
            this.panel1.Controls.Add(this.gpbSkinBeforOperation1);
            this.panel1.Controls.Add(this.gpbSkinBeforOperation);
            this.panel1.Controls.Add(this.gpbStypticRubber);
            this.panel1.Controls.Add(this.gpbUp);
            this.panel1.Controls.Add(this.gpbDown);
            this.panel1.Controls.Add(this.gpbStomach);
            this.panel1.Controls.Add(this.gpbSkinAntisepsis);
            this.panel1.Controls.Add(this.gpbBlood);
            this.panel1.Controls.Add(this.gpbFoley);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 438);
            this.panel1.TabIndex = 10000028;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_txtSign);
            this.panel3.Controls.Add(this.m_lsvAnaDocSign);
            this.panel3.Controls.Add(this.m_lsvOperationer);
            this.panel3.Controls.Add(this.m_cmdAnaDocSign);
            this.panel3.Controls.Add(this.m_cmdOperationer);
            this.panel3.Controls.Add(this.m_lsvBacilliCheckSign);
            this.panel3.Controls.Add(this.m_cmdSign);
            this.panel3.Controls.Add(this.m_cmdBacilliCheckSign);
            this.panel3.Controls.Add(this.m_lsvCircuitNurseSign);
            this.panel3.Controls.Add(this.m_cmdCircuitNurseSign);
            this.panel3.Controls.Add(this.m_lsvRecordNurseSign);
            this.panel3.Controls.Add(this.m_cmdRecordNurseSign);
            this.panel3.Controls.Add(this.m_lsvWashNurseSign);
            this.panel3.Controls.Add(this.m_cmdWashNurseSign);
            this.panel3.Controls.Add(this.lsvWoundThing);
            this.panel3.Controls.Add(this.pnlPanel3);
            this.panel3.Controls.Add(this.gpbFromHeadToFootSkinBeforeOperatio);
            this.panel3.Controls.Add(this.gpbFromto2);
            this.panel3.Controls.Add(this.gpbAfterOperationSend);
            this.panel3.Controls.Add(this.gpbSample);
            this.panel3.Controls.Add(this.lblTendRecord);
            this.panel3.Controls.Add(this.txtRecordContent);
            this.panel3.Controls.Add(this.gpbOutFlow);
            this.panel3.Controls.Add(this.dtgOutFlowThing);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(749, 438);
            this.panel3.TabIndex = 10000029;
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(635, 398);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(100, 24);
            this.m_txtSign.TabIndex = 10000082;
            this.m_txtSign.Visible = false;
            // 
            // m_lsvAnaDocSign
            // 
            this.m_lsvAnaDocSign.AccessibleDescription = "麻醉医生签名";
            this.m_lsvAnaDocSign.BackColor = System.Drawing.Color.White;
            this.m_lsvAnaDocSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.m_lsvAnaDocSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAnaDocSign.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAnaDocSign.FullRowSelect = true;
            this.m_lsvAnaDocSign.GridLines = true;
            this.m_lsvAnaDocSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAnaDocSign.Location = new System.Drawing.Point(330, 396);
            this.m_lsvAnaDocSign.Name = "m_lsvAnaDocSign";
            this.m_lsvAnaDocSign.Size = new System.Drawing.Size(160, 21);
            this.m_lsvAnaDocSign.TabIndex = 10000080;
            this.m_lsvAnaDocSign.UseCompatibleStateImageBehavior = false;
            this.m_lsvAnaDocSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // m_lsvOperationer
            // 
            this.m_lsvOperationer.AccessibleDescription = "手术医生签名";
            this.m_lsvOperationer.BackColor = System.Drawing.Color.White;
            this.m_lsvOperationer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.m_lsvOperationer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvOperationer.ForeColor = System.Drawing.Color.Black;
            this.m_lsvOperationer.FullRowSelect = true;
            this.m_lsvOperationer.GridLines = true;
            this.m_lsvOperationer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvOperationer.Location = new System.Drawing.Point(83, 396);
            this.m_lsvOperationer.Name = "m_lsvOperationer";
            this.m_lsvOperationer.Size = new System.Drawing.Size(160, 21);
            this.m_lsvOperationer.TabIndex = 10000081;
            this.m_lsvOperationer.UseCompatibleStateImageBehavior = false;
            this.m_lsvOperationer.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 70;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Width = 0;
            // 
            // m_cmdAnaDocSign
            // 
            this.m_cmdAnaDocSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAnaDocSign.DefaultScheme = true;
            this.m_cmdAnaDocSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAnaDocSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAnaDocSign.Hint = "";
            this.m_cmdAnaDocSign.Location = new System.Drawing.Point(257, 394);
            this.m_cmdAnaDocSign.Name = "m_cmdAnaDocSign";
            this.m_cmdAnaDocSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAnaDocSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdAnaDocSign.TabIndex = 10000079;
            this.m_cmdAnaDocSign.Tag = "1";
            this.m_cmdAnaDocSign.Text = "麻醉医生:";
            // 
            // m_cmdOperationer
            // 
            this.m_cmdOperationer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOperationer.DefaultScheme = true;
            this.m_cmdOperationer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOperationer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOperationer.Hint = "";
            this.m_cmdOperationer.Location = new System.Drawing.Point(10, 394);
            this.m_cmdOperationer.Name = "m_cmdOperationer";
            this.m_cmdOperationer.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOperationer.Size = new System.Drawing.Size(70, 24);
            this.m_cmdOperationer.TabIndex = 10000078;
            this.m_cmdOperationer.Tag = "1";
            this.m_cmdOperationer.Text = "手术医生:";
            // 
            // m_lsvBacilliCheckSign
            // 
            this.m_lsvBacilliCheckSign.AccessibleDescription = "无菌监测";
            this.m_lsvBacilliCheckSign.BackColor = System.Drawing.Color.White;
            this.m_lsvBacilliCheckSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14});
            this.m_lsvBacilliCheckSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBacilliCheckSign.ForeColor = System.Drawing.Color.Black;
            this.m_lsvBacilliCheckSign.FullRowSelect = true;
            this.m_lsvBacilliCheckSign.GridLines = true;
            this.m_lsvBacilliCheckSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvBacilliCheckSign.Location = new System.Drawing.Point(575, 394);
            this.m_lsvBacilliCheckSign.Name = "m_lsvBacilliCheckSign";
            this.m_lsvBacilliCheckSign.Size = new System.Drawing.Size(160, 21);
            this.m_lsvBacilliCheckSign.TabIndex = 10000077;
            this.m_lsvBacilliCheckSign.UseCompatibleStateImageBehavior = false;
            this.m_lsvBacilliCheckSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Width = 0;
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(558, 398);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdSign.TabIndex = 10000076;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "签  名:";
            this.m_cmdSign.Visible = false;
            // 
            // m_cmdBacilliCheckSign
            // 
            this.m_cmdBacilliCheckSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdBacilliCheckSign.DefaultScheme = true;
            this.m_cmdBacilliCheckSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdBacilliCheckSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdBacilliCheckSign.Hint = "";
            this.m_cmdBacilliCheckSign.Location = new System.Drawing.Point(502, 392);
            this.m_cmdBacilliCheckSign.Name = "m_cmdBacilliCheckSign";
            this.m_cmdBacilliCheckSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdBacilliCheckSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdBacilliCheckSign.TabIndex = 10000076;
            this.m_cmdBacilliCheckSign.Tag = "1";
            this.m_cmdBacilliCheckSign.Text = "无菌监测:";
            // 
            // m_lsvCircuitNurseSign
            // 
            this.m_lsvCircuitNurseSign.AccessibleDescription = "巡回护士签名";
            this.m_lsvCircuitNurseSign.BackColor = System.Drawing.Color.White;
            this.m_lsvCircuitNurseSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.m_lsvCircuitNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvCircuitNurseSign.ForeColor = System.Drawing.Color.Black;
            this.m_lsvCircuitNurseSign.FullRowSelect = true;
            this.m_lsvCircuitNurseSign.GridLines = true;
            this.m_lsvCircuitNurseSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvCircuitNurseSign.Location = new System.Drawing.Point(575, 364);
            this.m_lsvCircuitNurseSign.Name = "m_lsvCircuitNurseSign";
            this.m_lsvCircuitNurseSign.Size = new System.Drawing.Size(160, 21);
            this.m_lsvCircuitNurseSign.TabIndex = 10000077;
            this.m_lsvCircuitNurseSign.UseCompatibleStateImageBehavior = false;
            this.m_lsvCircuitNurseSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 0;
            // 
            // m_cmdCircuitNurseSign
            // 
            this.m_cmdCircuitNurseSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCircuitNurseSign.DefaultScheme = true;
            this.m_cmdCircuitNurseSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCircuitNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCircuitNurseSign.Hint = "";
            this.m_cmdCircuitNurseSign.Location = new System.Drawing.Point(502, 362);
            this.m_cmdCircuitNurseSign.Name = "m_cmdCircuitNurseSign";
            this.m_cmdCircuitNurseSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCircuitNurseSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdCircuitNurseSign.TabIndex = 10000076;
            this.m_cmdCircuitNurseSign.Tag = "1";
            this.m_cmdCircuitNurseSign.Text = "巡回护士:";
            // 
            // m_lsvRecordNurseSign
            // 
            this.m_lsvRecordNurseSign.AccessibleDescription = "记录护士签名";
            this.m_lsvRecordNurseSign.BackColor = System.Drawing.Color.White;
            this.m_lsvRecordNurseSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.m_lsvRecordNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvRecordNurseSign.ForeColor = System.Drawing.Color.Black;
            this.m_lsvRecordNurseSign.FullRowSelect = true;
            this.m_lsvRecordNurseSign.GridLines = true;
            this.m_lsvRecordNurseSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvRecordNurseSign.Location = new System.Drawing.Point(83, 363);
            this.m_lsvRecordNurseSign.Name = "m_lsvRecordNurseSign";
            this.m_lsvRecordNurseSign.Size = new System.Drawing.Size(160, 21);
            this.m_lsvRecordNurseSign.TabIndex = 10000075;
            this.m_lsvRecordNurseSign.UseCompatibleStateImageBehavior = false;
            this.m_lsvRecordNurseSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 0;
            // 
            // m_cmdRecordNurseSign
            // 
            this.m_cmdRecordNurseSign.AccessibleDescription = "记录护士签名";
            this.m_cmdRecordNurseSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRecordNurseSign.DefaultScheme = true;
            this.m_cmdRecordNurseSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRecordNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRecordNurseSign.Hint = "";
            this.m_cmdRecordNurseSign.Location = new System.Drawing.Point(10, 361);
            this.m_cmdRecordNurseSign.Name = "m_cmdRecordNurseSign";
            this.m_cmdRecordNurseSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRecordNurseSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdRecordNurseSign.TabIndex = 10000074;
            this.m_cmdRecordNurseSign.Tag = "1";
            this.m_cmdRecordNurseSign.Text = "记录护士:";
            // 
            // m_lsvWashNurseSign
            // 
            this.m_lsvWashNurseSign.AccessibleDescription = "洗手护士签名";
            this.m_lsvWashNurseSign.BackColor = System.Drawing.Color.White;
            this.m_lsvWashNurseSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.m_lsvWashNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvWashNurseSign.ForeColor = System.Drawing.Color.Black;
            this.m_lsvWashNurseSign.FullRowSelect = true;
            this.m_lsvWashNurseSign.GridLines = true;
            this.m_lsvWashNurseSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvWashNurseSign.Location = new System.Drawing.Point(330, 364);
            this.m_lsvWashNurseSign.Name = "m_lsvWashNurseSign";
            this.m_lsvWashNurseSign.Size = new System.Drawing.Size(160, 21);
            this.m_lsvWashNurseSign.TabIndex = 10000075;
            this.m_lsvWashNurseSign.UseCompatibleStateImageBehavior = false;
            this.m_lsvWashNurseSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 0;
            // 
            // m_cmdWashNurseSign
            // 
            this.m_cmdWashNurseSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdWashNurseSign.DefaultScheme = true;
            this.m_cmdWashNurseSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdWashNurseSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdWashNurseSign.Hint = "";
            this.m_cmdWashNurseSign.Location = new System.Drawing.Point(257, 362);
            this.m_cmdWashNurseSign.Name = "m_cmdWashNurseSign";
            this.m_cmdWashNurseSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdWashNurseSign.Size = new System.Drawing.Size(70, 24);
            this.m_cmdWashNurseSign.TabIndex = 10000074;
            this.m_cmdWashNurseSign.Tag = "1";
            this.m_cmdWashNurseSign.Text = "洗手护士:";
            // 
            // lsvWoundThing
            // 
            this.lsvWoundThing.BackColor = System.Drawing.Color.White;
            this.lsvWoundThing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvWoundThing.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvWoundThing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvWoundThing.FullRowSelect = true;
            this.lsvWoundThing.GridLines = true;
            this.lsvWoundThing.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvWoundThing.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lsvWoundThing.Location = new System.Drawing.Point(292, 58);
            this.lsvWoundThing.Name = "lsvWoundThing";
            this.lsvWoundThing.Size = new System.Drawing.Size(108, 184);
            this.lsvWoundThing.TabIndex = 10000029;
            this.lsvWoundThing.UseCompatibleStateImageBehavior = false;
            this.lsvWoundThing.View = System.Windows.Forms.View.Details;
            this.lsvWoundThing.Visible = false;
            this.lsvWoundThing.DoubleClick += new System.EventHandler(this.lsvWoundThing_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 80;
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(15, 132);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 2;
            this.tabControl2.SelectedTab = this.tabPage6;
            this.tabControl2.Size = new System.Drawing.Size(749, 464);
            this.tabControl2.TabIndex = 10000029;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4,
            this.tabPage5,
            this.tabPage6});
            this.tabControl2.SelectionChanged += new System.EventHandler(this.tabControl2_SelectionChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(749, 438);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "术前情况";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel1);
            this.tabPage5.ImageIndex = 1;
            this.tabPage5.ImageList = this.imageList1;
            this.tabPage5.Location = new System.Drawing.Point(0, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(749, 438);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Title = "术中记录一";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.ImageIndex = 1;
            this.tabPage6.ImageList = this.imageList1;
            this.tabPage6.Location = new System.Drawing.Point(0, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(749, 438);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Title = "术中记录二";
            // 
            // frmOperationRecord
            // 
            this.AccessibleDescription = "手术护理记录";
            this.AutoScroll = false;
            this.AutoScrollMargin = new System.Drawing.Size(10, 50);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(780, 631);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dtgOperationLocation);
            this.Controls.Add(this.pnlPanel2);
            this.Controls.Add(this.lblBeforeOperation);
            this.Controls.Add(this.cboOperationID);
            this.Controls.Add(this.cboAnaesthesiaModeID);
            this.Controls.Add(this.lblOperationNameTitle);
            this.Controls.Add(this.lblAnaesthesiaModeTitle);
            this.Controls.Add(this.lblOpenDateTime);
            this.Controls.Add(this.dtpRecordTime);
            this.Controls.Add(this.dtgElectKnife);
            this.Controls.Add(this.dtgFromHeadToFootSkin);
            this.Controls.Add(this.dtgSkinAntisepsis);
            this.Controls.Add(this.m_cmdShowHistoryRecord);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmOperationRecord";
            this.Text = "手术护理记录";
            this.Load += new System.EventHandler(this.frmOperationRecord_Load);
            this.Controls.SetChildIndex(this.m_cmdShowHistoryRecord, 0);
            this.Controls.SetChildIndex(this.dtgSkinAntisepsis, 0);
            this.Controls.SetChildIndex(this.dtgFromHeadToFootSkin, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.dtgElectKnife, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.dtpRecordTime, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblOpenDateTime, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblAnaesthesiaModeTitle, 0);
            this.Controls.SetChildIndex(this.lblOperationNameTitle, 0);
            this.Controls.SetChildIndex(this.cboAnaesthesiaModeID, 0);
            this.Controls.SetChildIndex(this.cboOperationID, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblBeforeOperation, 0);
            this.Controls.SetChildIndex(this.pnlPanel2, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.dtgOperationLocation, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgOutFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOutFlowThing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFromHeadToFootSkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSample)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAfterOperationSendAfterOperationSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkinAntisepsis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBlood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStypticRubber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDoublePole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperationLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAllergic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgElectKnife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCathodeLocationSkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCathodeLocationAfterOperationSkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFoley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStomach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUpStyptic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDownStyptic)).EndInit();
            this.gpbSences.ResumeLayout(false);
            this.gpbAllergic.ResumeLayout(false);
            this.gpbOperationLocation.ResumeLayout(false);
            this.gpbElectKnife.ResumeLayout(false);
            this.gpbElectKnife.PerformLayout();
            this.gpbDoublePole.ResumeLayout(false);
            this.gpbDoublePole.PerformLayout();
            this.gpbSkinBeforOperation1.ResumeLayout(false);
            this.gpbSkinBeforOperation.ResumeLayout(false);
            this.gpbStypticRubber.ResumeLayout(false);
            this.gpbStypticRubber.PerformLayout();
            this.gpbUp.ResumeLayout(false);
            this.gpbUp.PerformLayout();
            this.gpbDown.ResumeLayout(false);
            this.gpbDown.PerformLayout();
            this.gpbFoley.ResumeLayout(false);
            this.gpbStomach.ResumeLayout(false);
            this.gpbSkinAntisepsis.ResumeLayout(false);
            this.gpbBlood.ResumeLayout(false);
            this.gpbBlood.PerformLayout();
            this.gpbOutFlow.ResumeLayout(false);
            this.gpbFromHeadToFootSkinBeforeOperatio.ResumeLayout(false);
            this.gpbFromHeadToFootSkinBeforeOperatio.PerformLayout();
            this.gpbFromto2.ResumeLayout(false);
            this.gpbFromto2.PerformLayout();
            this.gpbSample.ResumeLayout(false);
            this.gpbAfterOperationSend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFromHeadToFootSkinAfterOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgOperationIDAndAnaesthesia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSences)).EndInit();
            this.m_pnlOperationBefore.ResumeLayout(false);
            this.m_pnlOperationBefore.PerformLayout();
            this.pnlPanel2.ResumeLayout(false);
            this.pnlPanel2.PerformLayout();
            this.pnlPanel3.ResumeLayout(false);
            this.pnlPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgWound)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		private void frmOperationRecord_Load(object sender, System.EventArgs e)
		{
			m_mthfrmLoad();

			this.m_lsvInPatientID.Visible =false;
			TreeNode trnNode=new TreeNode("记录日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			clsAnaesthesiaModeInOperation[] objAnaesthesiaModeInOperationArr=null;
			long lngRes=objDomain.m_lngGetAnaesthesiaMode(out objAnaesthesiaModeInOperationArr);
			if(lngRes>0)
			{
				if(objAnaesthesiaModeInOperationArr!=null)
					this.cboAnaesthesiaModeID.AddRangeItems(objAnaesthesiaModeInOperationArr);
			}

			clsOperationIDInOperation [] objOperationIDInOperationArr=null;
        	lngRes=objDomain.m_lngGetOperationID(out objOperationIDInOperationArr);
			if(lngRes>0)
			{
				if(objOperationIDInOperationArr!=null)
					this.cboOperationID.AddRangeItems(objOperationIDInOperationArr);
			}

			m_mthHideAllDataGrid(); 
			//lsvWoundThing.Visible=false;


			this.dtpRecordTime.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpRecordTime.m_mthResetSize();
		}

		
		#region 窗体常用附加函数		

//		private void m_mthPrintEnd(Object sender,System.Drawing.Printing.PrintEventArgs e)
//		{
//			if(m_objSelectedOperationRecord!=null)
//			{
//				objDomain.m_lngUpdateFirstPrintDate(m_strInPatientID,m_strInPatientDate,m_objSelectedOperationRecord.strOpenDate,m_dtmFirstPrintTime.ToString("yyyy-MM-dd HH:mm:ss"));//别的机可能格式不一样
//			}
//		}


		
		#region 添加RichText附加属性(含DataGrid的边框设置)
		
				
		private void m_mthSetRichTextAttrib()
		{			
			m_mthSetRichTextEvent(this);			
		}
		

		private void m_mthSetRichTextEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面ctlRichTextBox控件的附加属性,Jacky-2003-2-25				
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_ctlControl });
//				p_ctlControl.ContextMenu=ctmRichTextBoxMenu;
				p_ctlControl.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_StrUserID = MDIParent.strOperatorID;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_StrUserName = MDIParent.strOperatorName;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = Color.Black;
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrDST = Color.Red;
			}
			if(p_ctlControl.GetType().Name =="TreeView")
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                    {
                //                                        p_ctlControl ,
                //});
				
			}
			else if(p_ctlControl.GetType().Name=="DataGrid")//若窗体中不包含DataGrid项，可以注释此else块			
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_ctlControl });
				if(p_ctlControl.Name!="dtgNurse" && p_ctlControl.Name!="dtgOutFlowThing")
				   ((DataGrid)p_ctlControl).ReadOnly=true;//设置DataGrid为只读属性//可以根据需要调整此行				
			}
			else if(p_ctlControl.GetType().Name=="GroupBox" )//若窗体中GroupBox不需要利用到Tag，可以注释此else块					
				((GroupBox)p_ctlControl).Tag="0";				
			
			
			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextEvent(subcontrol);						
				} 	
			}				
					
			#endregion
		}


		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}


		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

	
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

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}
		
		private void m_mthClearUpRichText(Control p_ctlControl)
		{
			#region 清除所有ctlRichTextBox控件的内容，Jacky-2003-2-28				
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
			}			
			
			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthClearUpRichText(subcontrol);						
				} 	
			}				
					
			#endregion
			
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
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
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
			switch(e.KeyCode)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search, F7 118 Template
				case Keys.Enter:// enter	
//					if( ((Control)sender).Name=="txtInPatientID")
//					{
//						if(m_lsvInPatientID.Items.Count==1 && txtInPatientID.Text.Length==7)
//						{
//							m_lsvInPatientID.Items[0].Selected=true;
//							m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
//							break;
//						}
//					}					
//					else if( ((Control)sender).Name=="m_lsvInPatientID")
//					{
//						if(m_lsvInPatientID.SelectedItems.Count==1)
//						{
//							m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
//							break;
//						}
//					}
//					if(sender.GetType().Name=="ctlBorderTextBox" && ((ctlBorderTextBox)sender).Name=="txtInPatientID")
//					{
//						if(m_lsvInPatientID.Items.Count==1 && txtInPatientID.Text.Length==7)
//						{
//							m_mthClearPatientBaseInfo();
//								this.m_lsvInPatientID.Visible=false;
//							
//						}
//					}
//					
//					else if(sender.GetType().Name=="ListView" && ((ListView)sender).Name=="m_lsvInPatientID")
//					{
//						if(m_lsvInPatientID.SelectedItems.Count <= 0)
//							return;
//						m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
//					}
				
					if(((Control)sender).Name!="txtRecordContent" && ((Control)sender).Name!="m_txtSign")
						SendKeys.Send(  "{tab}"); //注意:如果是button控件,则不能send "Tab" 而应该是"Enter",如果是Text控件且允许多行编辑，也不能send "Tab"
					break;
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
					blnCanSearch =false;
					this.txtInPatientID.Text ="";
					blnCanSearch =true;
					base.m_mthClearPatientBaseInfo();
					m_mthClearUpRecord();
					m_objSelectedOperationRecord=null;
					m_objSelectedOperationRecordContent=null;
					m_strSelectedOperationID="";
					m_strSelectedAnaesthesiaModeID="";
					m_objSelectedOperatorArr=null;
					m_objSelectedWoundThingArr=null;
					this.trvTime.Nodes[0].Nodes.Clear();
					txtInPatientID.Focus();
					break;
				case Keys.F6://Search					
					break;
				

			}	
		}

		#endregion

		#region  PublicFunction
		public  void Save()
		{
			long lngRes = this.m_lngSave();

            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功");
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("保存失败");
            }
		}
		public void Delete()
		{
			long lngRes = m_lngDelete();

            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("删除成功");
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("删除失败");
            }
		}
		public void Display()
		{}
		public void Display(string cardno,string sendcheckdate)
		{}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Print()
		{
			this.m_lngPrint();
			
		}
		public void Copy()
		{m_lngCopy();}
		public void Cut()
		{m_lngCut();}

		public void Paste()
		{m_lngPaste();}
		public void Redo()
		{}
		public void Undo()
		{}
		#endregion 

		#endregion 窗体常用附加函数		

		#region OverRide Function

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			m_objSelectedPatient = p_objSelectedPatient;
			
            //txtInPatientID.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_StrHISInPatientID;

            //m_mthIsReadOnly();

            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();

            m_mthClearUpRecord();
            this.trvTime.Nodes[0].Nodes.Clear();
            //m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID ,m_strInPatientDate);
		}

		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return this.blnCanSearch;
			}
		}

		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}


		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox();
		}
	
		protected override bool m_BlnIsAddNew
		{
			get
			{
				if(dtpRecordTime.Enabled==true)
					return true;
				else 
					return false;
			}
		}
		
		protected override long m_lngSubModify()
		{
			return m_lngSaveWithMessageBox();
		}
		protected override long m_lngSubDelete()
		{
			if(m_objSelectedPatient!=null && m_objSelectedOperationRecord!=null )
			{
				long lngRes = objDomain. m_lngDeleteRecord(  m_objSelectedPatient.m_StrInPatientID,  m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objSelectedOperationRecord.strOpenDate );

				if(lngRes==1)
				{
					this.trvTime.SelectedNode.Remove();
				}

				return lngRes;
			}
			return 0;
		}

		#endregion 

		#region NewRecord -> AddNode || Modify
		
		private bool m_bolSaveCheck()
		{
			int m_intErrMessage = 1;
			if(m_strInPatientID == null || m_strInPatientID == "")
				m_intErrMessage = -1;
			if(cboAnaesthesiaModeID.Text == "")
				m_intErrMessage = -5;
			if(cboOperationID.Text == "")
				m_intErrMessage = -10;

			switch(m_intErrMessage)
			{
				case 1:
					return true;
				case  -1:
					clsPublicFunction.ShowInformationMessageBox("对不起，请输入病人住院编号！");
					return false;
				case  -5:
					clsPublicFunction.ShowInformationMessageBox("对不起，请输入麻醉方式！");
					return false;
				case -10:
					clsPublicFunction.ShowInformationMessageBox("对不起，请输入手术名称！");
					return false;
				default:
					return true;
			}			
			
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objSelectedSession"></param>
        /// <param name="p_intIndex"></param>
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
            {
                return;
            }

            base.m_objBaseCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            base.m_objBaseCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

            base.m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            base.m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_strInPatientID = p_objSelectedSession.m_strEMRInpatientId;
            m_strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            base.m_mthIsReadOnly();
            if (!base.m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            this.m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID, m_strInPatientDate);
        }
		
		private long m_lngSaveWithMessageBox()
		{
            //if (cboOperationID.SelectedIndex>=0)
            //    cboOperationID.SelectedIndex = 0;
            //if (cboAnaesthesiaModeID.SelectedIndex>=0)
            //    cboAnaesthesiaModeID.SelectedIndex = 0;

			if(!m_bolSaveCheck())
				return -1;
			
			if(m_blnCheckUserHasFillAllData()==false)
				return -1;
            if (this.ActiveControl.Parent == dtgOutFlow)
            {
                dtgOutFlow.CurrentCell = new DataGridCell(dtgOutFlow.CurrentCell.RowNumber + 1, 0);
            }

			clsOperationRecord objOperationRecord =new clsOperationRecord();
			clsOperationRecordContent objOperationRecordContent=new clsOperationRecordContent();
			
			objOperationRecord.strInPatientID=m_strInPatientID;
			objOperationRecord.strInPatientDate=m_strInPatientDate;
			objOperationRecordContent.strInPatientID=m_strInPatientID;
			objOperationRecordContent.strInPatientDate=m_strInPatientDate;
            objOperationRecordContent.strLastModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
			
            //没有key盘或者key盘持有人不在签名集合则不能保存
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objCompareTokey = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            if (objCompareTokey.m_lngCompareTOkey(objOperationRecordContent.strLastModifyUserID) == false)
            {
                MessageBox.Show("检测不到key盘或者key盘持有者不是当前签名者，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return -1;
            }
              
			string strNowTime=new clsPublicDomain().m_strGetServerTime();

			if(dtpRecordTime.Enabled==false && m_objSelectedOperationRecordContent!=null)
			{
				#region 修改处理
				string strLastModifyDate="";
				string strModidyUserID="";
				long lngRes=objDomain.m_lngCheckLastModifyRecord(m_objSelectedOperationRecordContent.strInPatientID,m_objSelectedOperationRecordContent.strInPatientDate,m_objSelectedOperationRecordContent.strOpenDate,out strLastModifyDate,out strModidyUserID);
				if(lngRes <= 0)
				{
					return lngRes;
				}
				objOperationRecord.strCreateUserID=m_objSelectedOperationRecord.strCreateUserID;	
				objOperationRecord.strCreateDate=m_objSelectedOperationRecord.strCreateDate ;
				objOperationRecord.strOpenDate=m_objSelectedOperationRecord.strOpenDate;
				objOperationRecord.strFirstPrintDate=m_objSelectedOperationRecord.strFirstPrintDate;
				
				#endregion 
			}
			else 
			{
				#region 新添处理
				bool blnIsDouble;
                long lngRes = objDomain.m_lngCheckNewCreateDate(m_objSelectedPatient.m_StrInPatientID, m_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), out blnIsDouble);
				if(lngRes <= 0)
				{
					return lngRes;
				}
				if(!blnIsDouble)
				{
					m_mthShowRecordTimeDouble();
					return -8;
				}
				
				objOperationRecord.strCreateUserID=((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPNO_CHR;	
				objOperationRecord.strCreateDate=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
				objOperationRecord.strOpenDate=strNowTime;
				#endregion
			}			
			objOperationRecordContent.strOpenDate=objOperationRecord.strOpenDate;
			objOperationRecordContent.strLastModifyDate=strNowTime;


            //objOperationRecord.strOperationNameXML=txtOperationID.m_strGetXmlText();
			objOperationRecordContent.strOperationName=cboOperationID.Text;
            //objOperationRecord.strAnaesthesiaModeXML=txtAnaesthesiaModeID.m_strGetXmlText();
			objOperationRecordContent.strAnaesthesiaMode=cboAnaesthesiaModeID.Text;
			objOperationRecord.strTendRecordXML=txtRecordContent.m_strGetXmlText();
			objOperationRecordContent.strTendRecord=txtRecordContent.Text;
			objOperationRecordContent.strStatus = "0";

			objOperationRecord.strStatus = "0";
			objOperationRecord.strIfConfirm = "0";
			
			#region 手术名称和麻醉方式
			
			clsOperationIDInOperation m_objOperationIDInOperation = new clsOperationIDInOperation();
			clsAnaesthesiaModeInOperation m_objAnaesthesiaModeInOperation = new clsAnaesthesiaModeInOperation();

            //m_objOperationIDInOperation.strOperationID =((clsOperationIDInOperation)(cboOperationID.SelectedItem)).strOperationID;
			m_objOperationIDInOperation.strOperationName  =cboOperationID.Text;

            //m_objAnaesthesiaModeInOperation.strAnaesthesiaModeID =((clsAnaesthesiaModeInOperation)(cboAnaesthesiaModeID.SelectedItem)).strAnaesthesiaModeID;
			m_objAnaesthesiaModeInOperation.strAnaesthesiaModeName =cboAnaesthesiaModeID.Text;

			clsOperationRecord_OperationID m_objOperationRecordOperation = new clsOperationRecord_OperationID();
			clsOperationRecord_Anaesthesia m_objOperationRecordAnaesthesia = new clsOperationRecord_Anaesthesia();

			m_objOperationRecordOperation.strOperationID = m_objOperationIDInOperation.strOperationID;
			m_objOperationRecordAnaesthesia.strAnaesthesiaModeID = m_objAnaesthesiaModeInOperation.strAnaesthesiaModeID;
			
			clsElementAttribute [] objclsElementAttributeArr=new clsElementAttribute[dtbOperationIDAndAnaesthesia.Columns.Count];
			for(int i=0;i<dtbOperationIDAndAnaesthesia.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="OperationName"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=m_objOperationIDInOperation.strOperationName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="AnaesthesiaName"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=m_objAnaesthesiaModeInOperation.strAnaesthesiaModeName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}	
			objOperationRecord.strOperation_AnaesthesiaXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbOperationIDAndAnaesthesia,ref m_objXmlMemStream,ref m_objXmlWriter);
			
			m_objOperationRecordOperation.strInPatientID = m_strInPatientID;
			m_objOperationRecordOperation.strInPatientDate = m_strInPatientDate;			
			m_objOperationRecordOperation.strOpenDate=objOperationRecord.strOpenDate;
			
			m_objOperationRecordOperation.strStatus="0";
			m_objOperationRecordOperation.strModifyDate = strNowTime;

			m_objOperationRecordAnaesthesia.strInPatientID = m_strInPatientID;
			m_objOperationRecordAnaesthesia.strInPatientDate = m_strInPatientDate;
			m_objOperationRecordAnaesthesia.strOpenDate=objOperationRecord.strOpenDate;
			
			m_objOperationRecordAnaesthesia.strStatus="0";
			m_objOperationRecordAnaesthesia.strModifyDate = strNowTime;						
			#endregion

			#region 神志
			objclsElementAttributeArr=new clsElementAttribute[dtbSences.Columns.Count];
			for(int i=0;i<dtbSences.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="rdbSencesClear"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbSencesClear.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="rdbSencesSleep"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbSencesSleep.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="rdbSencesComa"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbSencesComa.Checked.ToString();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			
			objOperationRecord.strSensesXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbSences,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strSensesClearHeaded=rdbSencesClear.Checked?"1":"0";
			objOperationRecordContent.strSensesSleep=rdbSencesSleep.Checked?"1":"0";
            objOperationRecordContent.strSensesComa =rdbSencesComa.Checked ? "1" : "0";

			#endregion
			
			#region 过敏史
			objclsElementAttributeArr=new clsElementAttribute[dtbAllergic.Columns.Count];
			for(int i=0;i<dtbAllergic.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="HaveNotAllergic"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveNotAllergic.Checked.ToString();
						break;
					case 1:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="HaveAllergic"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveAllergic.Checked.ToString();	
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="AllergicContent"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtAllergicContent.Text.Trim();
						try
						{
							txtAllergicContent.m_StrUserID = m_objCurrentContext.m_ObjEmployee.m_StrEmployeeID;
							txtAllergicContent.m_StrUserName = m_objCurrentContext.m_ObjEmployee.m_StrLastName;
							objclsElementAttributeArr[i].m_strValueXML=txtAllergicContent.m_strGetXmlText();
						}
						catch(Exception err)
						{
							MessageBox.Show(err.Message);
						}
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}	
			objOperationRecord.strAllergicContentXML=this.txtAllergicContent.m_strGetXmlText();
			objOperationRecord.strAllergicXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbAllergic,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strHaveNotAllergic=rdbHaveNotAllergic.Checked?"1":"0";
			objOperationRecordContent.strHaveAllergic=rdbHaveAllergic.Checked?"1":"0";
			objOperationRecordContent.strAllergicContent=txtAllergicContent.Text.Trim();
			#endregion

			#region 手术体位
			objclsElementAttributeArr=new clsElementAttribute[dtbOperationLocation.Columns.Count];
			for(int i=0;i<dtbOperationLocation.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationOnHisBack"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationOnHisBack.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationSide"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationSide.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationPA"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationPA.Checked.ToString();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationParaplegic"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationParaplegic.Checked.ToString();
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationHypothyroid"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationHypothyroid.Checked.ToString();
						break;
					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OperationLocationOther"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbOperationLocationOther.Checked.ToString();
						break;
					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="OtherOperationLocation"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtOtherOperationLocation.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtOtherOperationLocation.m_strGetXmlText();
						break;
					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 8:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strOtherOperationLocationXML=this.txtOtherOperationLocation.m_strGetXmlText();
			objOperationRecord.strOperationLocationXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbOperationLocation,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strOperationLocationOnHisBack=rdbOperationLocationOnHisBack.Checked?"1":"0";
			objOperationRecordContent.strOperationLocationSide=rdbOperationLocationSide.Checked?"1":"0";
			objOperationRecordContent.strOperationLocationPA=rdbOperationLocationPA.Checked?"1":"0";
			objOperationRecordContent.strOperationLocationParaplegic=rdbOperationLocationParaplegic.Checked?"1":"0";
			objOperationRecordContent.strOperationLocationHypothyroid=rdbOperationLocationHypothyroid.Checked?"1":"0";
			objOperationRecordContent.strOperationLocationOther=rdbOperationLocationOther.Checked?"1":"0";
			objOperationRecordContent.strOtherOperationLocation=txtOtherOperationLocation.Text.Trim();
			#endregion

			#region 手术间及各个时间
			objOperationRecord.strOperationRoomXML = txtOperationRoom.m_strGetXmlText();
			objOperationRecordContent.strOperationRoom = txtOperationRoom.Text.Trim();

			objOperationRecord.strPatientInDate = dtpPatientInDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.strPatientInDate = dtpPatientInDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

			objOperationRecord.strOperationBeginDate = dtpOperationBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.strOperationBeginDate = dtpOperationBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

			objOperationRecord.strOperationEndDate = dtpOperationOverTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.strOperationEndDate = dtpOperationOverTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

			objOperationRecord.strOperationLeaveDate= dtpLeaveRoomTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.strOperationLeaveDate = dtpLeaveRoomTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

			#endregion

			#region 使用电刀
			objclsElementAttributeArr=new clsElementAttribute[dtbElectKnife.Columns.Count];
			for(int i=0;i<dtbElectKnife.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="HaveNotElectKnife"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveNotElectKnife.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="HaveUsedElectKnife"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveUsedElectKnife.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="ElectKnifeModel"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtElectKnifeModel.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtElectKnifeModel.m_strGetXmlText();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strElectKnifeModelXML=this.txtElectKnifeModel.m_strGetXmlText();
			objOperationRecord.strElectKnifeXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbElectKnife,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strHaveNotElectKnife=rdbHaveNotElectKnife.Checked?"1":"0";
			objOperationRecordContent.strHaveUsedElectKnife=rdbHaveUsedElectKnife.Checked?"1":"0";
			objOperationRecordContent.strElectKnifeModel=txtElectKnifeModel.Text.Trim();
			#endregion

			#region 双极电凝
			objclsElementAttributeArr=new clsElementAttribute[dtbDoublePole.Columns.Count];
			for(int i=0;i<dtbDoublePole.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="rdbHaveNotDoublePole"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveNotDoublePole.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="rdbHaveDoublePole"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveDoublePole.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="txtDoublePoleMode"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtDoublePoleMode.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtDoublePoleMode.m_strGetXmlText();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="txtCathodeLocation"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtCathodeLocation.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtCathodeLocation.m_strGetXmlText();
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strDoublePoleContentXML=this.txtDoublePoleMode.m_strGetXmlText();
			objOperationRecord.strDoublePoleXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbDoublePole,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strHaveNotDoublePole=rdbHaveNotDoublePole.Checked?"1":"0";
			objOperationRecordContent.strHaveDoublePole=rdbHaveDoublePole.Checked?"1":"0";
			objOperationRecordContent.strDoublePoleContent=txtDoublePoleMode.Text.Trim();
			objOperationRecordContent.strCathodeLocation=txtCathodeLocation.Text.Trim();
			#endregion

			#region 术前负极板部位皮肤
			objclsElementAttributeArr=new clsElementAttribute[dtbCathodeLocationSkin.Columns.Count];
			for(int i=0;i<dtbCathodeLocationSkin.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="CATHODELOCSKINBFOPRMAR"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbCathodeLocationSkinBeforOperationFull.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="CATHODELOCSKINBFOPRFULL"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbCathodeLocationSkinBeforOperationMar.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strCathodeLocationXML=this.txtCathodeLocation.m_strGetXmlText();
			objOperationRecord.strCathodeLocationSkinXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbCathodeLocationSkin,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strCathodeLocationSkinBeforOperationMar=rdbCathodeLocationSkinBeforOperationMar.Checked?"1":"0";
			objOperationRecordContent.strCathodeLocationSkinBeforOperationFull=rdbCathodeLocationSkinBeforOperationFull.Checked?"1":"0";
			#endregion

			#region 术后负极板部位皮肤
			objclsElementAttributeArr=new clsElementAttribute[dtbCathodeLocationAfterOperationSkin.Columns.Count];
			for(int i=0;i<dtbCathodeLocationAfterOperationSkin.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="CATHODELOCSKINAFOPRNMAR"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbCathodeLocationSkinAfterOperationFull.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="CATHODELOCSKINAFOPRFULL"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbCathodeLocationSkinAfterOperationMar.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}	
			objOperationRecord.strCathodeLocationSkinAfterOperationXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbCathodeLocationAfterOperationSkin,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strCathodeLocationSkinAfterOperationMar=rdbCathodeLocationSkinAfterOperationMar.Checked?"1":"0";
			objOperationRecordContent.strCathodeLocationSkinAfterOperationFull=rdbCathodeLocationSkinAfterOperationFull.Checked?"1":"0";
			#endregion

			#region 止血带
			objclsElementAttributeArr=new clsElementAttribute[dtbStypticRubber.Columns.Count];
			for(int i=0;i<dtbStypticRubber.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="StypticRubber"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkStypticRubber.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="StypticPressure"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkStypticPressure.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="StypticPressureMode"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtStypticPressureMode.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtStypticPressureMode.m_strGetXmlText();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}	
			objOperationRecord.strStypticPressureModeXML=this.txtStypticPressureMode.m_strGetXmlText();
			objOperationRecord.strStypticRubberXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbStypticRubber,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strStypticRubber=chkStypticRubber.Checked?"1":"0";
			objOperationRecordContent.strStypticPressure=chkStypticPressure.Checked?"1":"0";
			objOperationRecordContent.strStypticPressureMode=txtStypticPressureMode.Text.Trim();
			#endregion

			#region 单/双肢 上
			objclsElementAttributeArr=new clsElementAttribute[dtbUpStyptic.Columns.Count];
			for(int i=0;i<dtbUpStyptic.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="UpForearm"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkUpForearm.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="UpThigh"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkUpThigh.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="UpRight"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkUpRight.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="UpLeft"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkUpLeft.Checked.ToString();
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="UpPuffDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtUpPuffDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtUpPuffDateTime.m_strGetXmlText();
						break;
					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="UpDeflateDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtUpDeflateDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtUpDeflateDateTime.m_strGetXmlText();
						break;
					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="UpTotalDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtUpTotalDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtUpTotalDateTime.m_strGetXmlText();
						break;
					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="UpPress"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtUpPress.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtUpPress.m_strGetXmlText();
						break;
					case 8:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 9:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strUpPuffDateTimeXML=this.txtUpPuffDateTime.m_strGetXmlText();
			objOperationRecord.strUpDeflateDateTimeXML=this.txtUpDeflateDateTime.m_strGetXmlText();
			objOperationRecord.strUpTotalDateTimeXML=this.txtUpTotalDateTime.m_strGetXmlText();
			objOperationRecord.strUpPressXML=this.txtUpPress.m_strGetXmlText();
			objOperationRecord.strUpXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbUpStyptic,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strUpForearm=chkUpForearm.Checked?"1":"0";
			objOperationRecordContent.strUpThigh=chkUpThigh.Checked?"1":"0";
			objOperationRecordContent.strUpRight=chkUpRight.Checked?"1":"0";
			objOperationRecordContent.strUpLeft=chkUpLeft.Checked?"1":"0";
			objOperationRecordContent.strUpPuffDateTime=txtUpPuffDateTime.Text.Trim();
			objOperationRecordContent.strUpDeflateDateTime=txtUpDeflateDateTime.Text.Trim();
			objOperationRecordContent.strUpTotalDateTime=txtUpTotalDateTime.Text.Trim();
			objOperationRecordContent.strUpPress=txtUpPress.Text.Trim();
			#endregion

			#region 单/双肢 下
			objclsElementAttributeArr=new clsElementAttribute[dtbDownStyptic.Columns.Count];
			for(int i=0;i<dtbDownStyptic.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="DownForearm"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkDownForearm.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="DownThigh"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkDownThigh.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="DownRight"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkDownRight.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="DownLeft"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkDownLeft.Checked.ToString();
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="DownPuffDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtDownPuffDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtDownPuffDateTime.m_strGetXmlText();
						break;
					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="DownDeflateDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtDownDeflateDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtDownDeflateDateTime.m_strGetXmlText();
						break;
					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="DownTotalDateTime"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtDownTotalDateTime.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtDownTotalDateTime.m_strGetXmlText();
						break;
					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="DownPress"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtDownPress.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtDownPress.m_strGetXmlText();
						break;
					case 8:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 9:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strDownPuffDateTimeXML=this.txtDownPuffDateTime.m_strGetXmlText();
			objOperationRecord.strDownDeflateDateTimeXML=this.txtDownDeflateDateTime.m_strGetXmlText();
			objOperationRecord.strDownTotalDateTimeXML=this.txtDownTotalDateTime.m_strGetXmlText();
			objOperationRecord.strDownPressXML=this.txtDownPress.m_strGetXmlText();
			objOperationRecord.strDownXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbDownStyptic,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strDownForearm=chkDownForearm.Checked?"1":"0";
			objOperationRecordContent.strDownThigh=chkDownThigh.Checked?"1":"0";
			objOperationRecordContent.strDownRight=chkDownRight.Checked?"1":"0";
			objOperationRecordContent.strDownLeft=chkDownLeft.Checked?"1":"0";
			objOperationRecordContent.strDownPuffDateTime=txtDownPuffDateTime.Text.Trim();
			objOperationRecordContent.strDownDeflateDateTime=txtDownDeflateDateTime.Text.Trim();
			objOperationRecordContent.strDownTotalDateTime=txtDownTotalDateTime.Text.Trim();
			objOperationRecordContent.strDownPress=txtDownPress.Text.Trim();
			#endregion

			#region 停留Foley氏尿管
			objclsElementAttributeArr=new clsElementAttribute[dtbFoley.Columns.Count];
			for(int i=0;i<dtbFoley.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:	
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FoleySickroom"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkFoleySickroom.Checked.ToString();	
						break;
					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FoleyOperationRoom"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkFoleyOperationRoom.Checked.ToString();
						break;
					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FoleyDoubleAntrum"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkFoleyDoubleAntrum.Checked.ToString();
						break;
					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FoleyThreeAntrum"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkFoleyThreeAntrum.Checked.ToString();
						break;
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FoleyOther"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkFoleyOther.Checked.ToString();
						break;
					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="FoleyOtherContent"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=txtFoleyOtherContent.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML=txtFoleyOtherContent.m_strGetXmlText();
						break;
					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="InPatientModeSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}	
			objOperationRecord.strFoleyOtherContentXML=this.txtFoleyOtherContent.m_strGetXmlText();
			objOperationRecord.strFoleyXML=m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbFoley,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strFoleySickroom=chkFoleySickroom.Checked?"1":"0";
			objOperationRecordContent.strFoleyOperationRoom=chkFoleyOperationRoom.Checked?"1":"0";
			objOperationRecordContent.strFoleyDoubleAntrum=chkFoleyDoubleAntrum.Checked?"1":"0";
			objOperationRecordContent.strFoleyThreeAntrum=chkFoleyThreeAntrum.Checked?"1":"0";
			objOperationRecordContent.strFoleyOther=chkFoleyOther.Checked?"1":"0";
			objOperationRecordContent.strFoleyOtherContent=txtFoleyOtherContent.Text.Trim();
			#endregion

			#region 停留胃管
			objclsElementAttributeArr=new clsElementAttribute[dtbStomach.Columns.Count];
			for(int i=0;i<dtbStomach.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST = false;
						objclsElementAttributeArr[i].m_strElementName="StomachSickroom"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbStomachSickroom.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST = false;
						objclsElementAttributeArr[i].m_strElementName="StomachOprationRoom"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbStomachOprationRoom.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="StomachSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="StomachcSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			
			objOperationRecord.strStomachXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbStomach,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strStomachSickroom = rdbStomachSickroom.Checked?"1":"0";
			objOperationRecordContent.strStomachOprationRoom = rdbStomachOprationRoom.Checked?"1":"0";
			#endregion

			#region 皮肤消毒
			objclsElementAttributeArr=new clsElementAttribute[dtbSkinAntisepsis.Columns.Count];
			for(int i=0;i<dtbSkinAntisepsis.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsis2"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSkinAntisepsis2.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsis75"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSkinAntisepsis75.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsisIodin"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSkinAntisepsisIodin.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsisIodinRare"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSkinAntisepsisIodinRare.Checked.ToString();
						break;
						
					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsisOther"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSkinAntisepsisOther.Checked.ToString();
						break;

					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName = "SkinAntisepsisOtherContent"+i.ToString();
						objclsElementAttributeArr[i].m_strValue = txtSkinAntisepsisOtherContent.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtSkinAntisepsisOtherContent.m_strGetXmlText();
						break;

					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsisSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="SkinAntisepsisSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strSkinAntisepsisOtherContentXML=this.txtSkinAntisepsisOtherContent.m_strGetXmlText();
			objOperationRecord.strSkinAntisepsisXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbSkinAntisepsis,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strSkinAntisepsis2 = chkSkinAntisepsis2.Checked?"1":"0";
			objOperationRecordContent.strSkinAntisepsis75 = chkSkinAntisepsis75.Checked?"1":"0";
			objOperationRecordContent.strSkinAntisepsisIodin = chkSkinAntisepsisIodin.Checked?"1":"0";
			objOperationRecordContent.strSkinAntisepsisIodinRare = chkSkinAntisepsisIodinRare.Checked?"1":"0";
			objOperationRecordContent.strSkinAntisepsisOther = chkSkinAntisepsisOther.Checked?"1":"0";
			objOperationRecordContent.strSkinAntisepsisOtherContent = txtSkinAntisepsisOtherContent.Text.Trim();
			#endregion

			#region 血制品
			objclsElementAttributeArr=new clsElementAttribute[dtbBlood.Columns.Count];
			for(int i=0;i<dtbBlood.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="AllBlood"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkAllBlood.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="AllBloodQty";
						objclsElementAttributeArr[i].m_strValue = txtAllBloodQty.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtAllBloodQty.m_strGetXmlText();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="RedCell"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkRedCell.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="RedCellQty";
						objclsElementAttributeArr[i].m_strValue = txtRedCellQty.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtRedCellQty.m_strGetXmlText();
						break;

					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="BloodPlasm"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkBloodPlasm.Checked.ToString();
						break;

					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="BloodPlasmQty";
						objclsElementAttributeArr[i].m_strValue = txtBloodPlasmQty.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtBloodPlasmQty.m_strGetXmlText();
						break;

					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="OwnBlood"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkOwnBlood.Checked.ToString();
						break;

					case 7:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="OwnBloodQty";
						objclsElementAttributeArr[i].m_strValue = txtOwnBloodQty.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtOwnBloodQty.m_strGetXmlText();
						break;

					case 8:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="BloodOther"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkBloodOther.Checked.ToString();
						break;

					case 9:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="BloodOtherQty";
						objclsElementAttributeArr[i].m_strValue = txtBloodOther.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtBloodOther.m_strGetXmlText();
						break;

					case 10:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="BloodSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 11:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="BloodSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}

			objOperationRecord.strAllBloodQtyXML=this.txtAllBloodQty.m_strGetXmlText();
			objOperationRecord.strRedCellQtyXML=this.txtRedCellQty.m_strGetXmlText();
			objOperationRecord.strBloodPlasmQtyXML=this.txtBloodPlasmQty.m_strGetXmlText();
			objOperationRecord.strOwnBloodQtyXML=this.txtOwnBloodQty.m_strGetXmlText();
			objOperationRecord.strBloodOtherQtyXML=this.txtBloodOther.m_strGetXmlText();
			objOperationRecord.strBloodXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbBlood,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strAllBlood = chkAllBlood.Checked?"1":"0";
			objOperationRecordContent.strOwnBlood = chkOwnBlood.Checked?"1":"0";
			objOperationRecordContent.strRedCell = chkRedCell.Checked?"1":"0";
			objOperationRecordContent.strBloodPlasm = chkBloodPlasm.Checked?"1":"0";
			objOperationRecordContent.strBloodOther = chkBloodOther.Checked?"1":"0";
			objOperationRecordContent.strAllBloodQty = txtAllBloodQty.Text.Trim();
			objOperationRecordContent.strOwnBloodQty = txtOwnBloodQty.Text.Trim();
			objOperationRecordContent.strRedCellQty = txtRedCellQty.Text.Trim();
			objOperationRecordContent.strBloodPlasmQty = txtBloodPlasmQty.Text.Trim();
			objOperationRecordContent.strBloodOtherQty = txtBloodOther.Text.Trim();
			#endregion

			#region 输入液体量和术中尿量
			objOperationRecord.strInLiquidQtyXML = txtInLiquidQty.m_strGetXmlText();
			objOperationRecordContent.strInLiquidQty = txtInLiquidQty.Text.Trim();

			objOperationRecord.strPeeOperatingQtyXML = txtPeeOperatingQty.m_strGetXmlText();
			objOperationRecordContent.strPeeOperatingQty = txtPeeOperatingQty.Text.Trim();
			#endregion

			#region 术前全身皮肤情况
			objclsElementAttributeArr=new clsElementAttribute[dtbFromHeadToFootSkin.Columns.Count];
			for(int i=0;i<dtbFromHeadToFootSkin.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FROMHEADTOFOOTSKINBFOPRFULL"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbFromHeadToFootSkinBeforeOperationFull.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FROMHEADTOFOOTSKINBFOPRMAR"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbFromHeadToFootSkinBeforeOperationMar.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName = "FROMHEADTOFOOTSKINBFOPRCONT"+i.ToString();
						objclsElementAttributeArr[i].m_strValue = txtFromHeadToFootSkinBeforeOperationContent.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtFromHeadToFootSkinBeforeOperationContent.m_strGetXmlText();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="FromHeadToFootSkinSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="FromHeadToFootSkinSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord .strFromHeadToFootSkinBeforeOperationContentXML=this.txtFromHeadToFootSkinBeforeOperationContent.m_strGetXmlText();
			objOperationRecord.strFromHeadToFootSkinXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbFromHeadToFootSkin,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strFromHeadToFootSkinBeforeOperationFull = rdbFromHeadToFootSkinBeforeOperationFull.Checked?"1":"0";
			objOperationRecordContent.strFromHeadToFootSkinBeforeOperationMar = rdbFromHeadToFootSkinBeforeOperationMar.Checked?"1":"0";
			objOperationRecordContent.strFromHeadToFootSkinBeforeOperationContent = txtFromHeadToFootSkinBeforeOperationContent.Text.Trim();
			#endregion

			#region 术后全身皮肤情况
			objclsElementAttributeArr=new clsElementAttribute[dtbFromHeadToFootSkinAfterOperation.Columns.Count];
			for(int i=0;i<dtbFromHeadToFootSkinAfterOperation.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FROMHEADTOFOOTSKINAFOPRFULL"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbFromHeadToFootSkinAfterOperationFull.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="FROMHEADTOFOOTSKINAFOPRMAR"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbFromHeadToFootSkinAfterOperationMar.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName = "FROMHEADTOFOOTSKINAFOPRNCONT"+i.ToString();
						objclsElementAttributeArr[i].m_strValue = txtFromHeadToFootSkinAfterOperationContent.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtFromHeadToFootSkinAfterOperationContent.m_strGetXmlText();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="FromHeadToFootSkinAfterOperationSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="FromHeadToFootSkinAfterOperationSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strFromHeadToFootSkinAfterOperationContentXML=this.txtFromHeadToFootSkinAfterOperationContent.m_strGetXmlText();
			objOperationRecord.strFromHeadToFootSkinAfterOperationXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbFromHeadToFootSkinAfterOperation,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strFromHeadToFootSkinAfterOperationFull = rdbFromHeadToFootSkinAfterOperationFull.Checked?"1":"0";
			objOperationRecordContent.strFromHeadToFootSkinAfterOperationMar = rdbFromHeadToFootSkinAfterOperationMar.Checked?"1":"0";
			objOperationRecordContent.strFromHeadToFootSkinAfterOperationContent = txtFromHeadToFootSkinAfterOperationContent.Text.Trim();
			#endregion

			#region 标本
			objclsElementAttributeArr=new clsElementAttribute[dtbSample.Columns.Count];
			for(int i=0;i<dtbSample.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SampleGeneral"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSampleGeneral.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SampleSlice"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSampleSlice.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SampleBacilli"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSampleBacilli.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="SampleOther"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=chkSampleOther.Checked.ToString();
						break;

					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName = "SampleThing"+i.ToString();
						objclsElementAttributeArr[i].m_strValue = txtSampleOtherContent.Text.Trim();
						objclsElementAttributeArr[i].m_strValueXML = txtSampleOtherContent.m_strGetXmlText();
						break;

					case 5:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="SampleSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 6:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="SampleSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strSampleOtherContentXML=this.txtSampleOtherContent.m_strGetXmlText();
			objOperationRecord.strSampleXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbSample,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strSampleGeneral = chkSampleGeneral.Checked?"1":"0";
			objOperationRecordContent.strSampleSlice = chkSampleSlice.Checked?"1":"0";
			objOperationRecordContent.strSampleBacilli = chkSampleBacilli.Checked?"1":"0";
			objOperationRecordContent.strSampleOther = chkSampleOther.Checked?"1":"0";
			objOperationRecordContent.strSampleOtherContent = txtSampleOtherContent.Text.Trim();
			#endregion

			#region 术后送回
			objclsElementAttributeArr=new clsElementAttribute[dtbAfterOperationSend.Columns.Count];
			for(int i=0;i<dtbAfterOperationSend.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="AfterOperationSendRenew"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbAfterOperationSendRenew.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="AfterOperationSendICU"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbAfterOperationSendICU.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="AfterOperationSendSickRoom"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbAfterOperationSendSickRoom.Checked.ToString();
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="AfterOperationSendSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 4:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="AfterOperationSendSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strAfterOperationSendXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbAfterOperationSend,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strAfterOperationSendRenew = rdbAfterOperationSendRenew.Checked?"1":"0";
			objOperationRecordContent.strAfterOperationSendICU = rdbAfterOperationSendICU.Checked?"1":"0";
			objOperationRecordContent.strAfterOperationSendSickRoom = rdbAfterOperationSendSickRoom.Checked?"1":"0";
			#endregion

			#region 医生及护士
			int intSignCount = 0;

            intSignCount = m_lsvOperationer.Items.Count + m_lsvAnaDocSign.Items.Count
                + m_lsvWashNurseSign.Items.Count + m_lsvCircuitNurseSign.Items.Count 
                + m_lsvBacilliCheckSign.Items.Count + m_lsvRecordNurseSign.Items.Count + 1;

			objOperationRecord.objSignerArr = new clsEmrSigns_VO[intSignCount];
            strUserIDList = "";
            strUserNameList = "";
            m_mthGetSignArr(new Control[] { m_lsvOperationer, m_lsvAnaDocSign, m_lsvWashNurseSign, m_lsvCircuitNurseSign, m_lsvBacilliCheckSign, m_lsvRecordNurseSign, m_txtSign }, ref objOperationRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            //int currentSignCount = 0;
            //for (int i = 0; i < m_lsvOperationer.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvOperationer.Items[i].Tag);
            //    objOperationRecord.objSignerArr[i].controlName = "m_lsvOperationer";
            //    objOperationRecord.objSignerArr[i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount = m_lsvOperationer.Items.Count;

            //for (int i = 0; i < m_lsvAnaDocSign.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvAnaDocSign.Items[i].Tag);
            //    objOperationRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvAnaDocSign";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvAnaDocSign.Items.Count;

            //for (int i = 0; i < m_lsvWashNurseSign.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvWashNurseSign.Items[i].Tag);
            //    objOperationRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvWashNurseSign";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvWashNurseSign.Items.Count;

            //for (int i = 0; i < m_lsvCircuitNurseSign.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvCircuitNurseSign.Items[i].Tag);
            //    objOperationRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvCircuitNurseSign";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvCircuitNurseSign.Items.Count;

            //for (int i = 0; i < m_lsvBacilliCheckSign.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvBacilliCheckSign.Items[i].Tag);
            //    objOperationRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvBacilliCheckSign";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvBacilliCheckSign.Items.Count;

            //for (int i = 0; i < m_lsvRecordNurseSign.Items.Count; i++)
            //{
            //    objOperationRecord.objSignerArr[currentSignCount + i] = new clsEmrSigns_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = new clsEmrEmployeeBase_VO();
            //    objOperationRecord.objSignerArr[currentSignCount + i].objEmployee = (clsEmrEmployeeBase_VO)(m_lsvRecordNurseSign.Items[i].Tag);
            //    objOperationRecord.objSignerArr[currentSignCount + i].controlName = "m_lsvRecordNurseSign";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strFORMID_VCHR = "frmOperationRecord";
            //    objOperationRecord.objSignerArr[currentSignCount + i].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}
            //currentSignCount += m_lsvRecordNurseSign.Items.Count;

            //objOperationRecord.objSignerArr[intSignCount - 1] = new clsEmrSigns_VO();
            //objOperationRecord.objSignerArr[intSignCount - 1].objEmployee = new clsEmrEmployeeBase_VO();
            //objOperationRecord.objSignerArr[intSignCount - 1].objEmployee = (clsEmrEmployeeBase_VO)(m_txtSign.Tag);
            //objOperationRecord.objSignerArr[intSignCount - 1].controlName = "m_txtSign";
            //objOperationRecord.objSignerArr[intSignCount - 1].m_strFORMID_VCHR = "frmOperationRecord";
            //objOperationRecord.objSignerArr[intSignCount - 1].m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
			#endregion

			#region 伤口引流物
			clsOperationWoundThingInfo[] m_objWoundThingArr = m_objGetOperationThingInfo(dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

			//2003.3.6 刘荣国 修改
			objclsElementAttributeArr=new clsElementAttribute[dtbOutFlow.Columns.Count];
			for(int i=0;i<dtbOutFlow.Columns.Count;i++)
			{
				objclsElementAttributeArr[i]=new clsElementAttribute();
				switch(i)
				{
					case 0:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="NotHaveOutFlow"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveNotOutflow.Checked.ToString();
						break;

					case 1:
						objclsElementAttributeArr[i].m_blnIsDST=false;
						objclsElementAttributeArr[i].m_strElementName="HaveOutFlow"+i.ToString();
						objclsElementAttributeArr[i].m_strValue=rdbHaveOutFlow.Checked.ToString();
						break;

					case 2:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="OutFlowSign";
						objclsElementAttributeArr[i].m_strValue=MDIParent.strOperatorName;
						objclsElementAttributeArr[i].m_strValueXML="";
						break;

					case 3:
						objclsElementAttributeArr[i].m_blnIsDST=true;
						objclsElementAttributeArr[i].m_strElementName="OutFlowSignTime";
						objclsElementAttributeArr[i].m_strValue=dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
						objclsElementAttributeArr[i].m_strValueXML="";
						break;
				}
			}
			objOperationRecord.strOutFlowXML = m_objXML_DataGrid.m_strGetXMLFromDataTable(objclsElementAttributeArr,dtbOutFlow,ref m_objXmlMemStream,ref m_objXmlWriter);
			objOperationRecordContent.strHaveOutFlow = rdbHaveOutFlow.Checked?"1":"0";
			objOperationRecordContent.strNotHaveOutFlow = rdbHaveNotOutflow.Checked?"1":"0";

			#endregion

			#region 护理纪录
			objOperationRecord.strTendRecordXML = txtRecordContent.m_strGetXmlText();
			objOperationRecordContent.strTendRecord = txtRecordContent.Text.Trim();
			#endregion

			for(int i=0;i<m_objWoundThingArr.Length;i++)
			{
				m_objWoundThingArr[i].strOpenDate = objOperationRecordContent.strOpenDate;
				m_objWoundThingArr[i].strLastModifyDate = objOperationRecordContent.strLastModifyDate;
			}

			long lngSuccess=0;
			lngSuccess=objDomain.m_lngSave(objOperationRecord,objOperationRecordContent,null,m_objOperationRecordOperation,m_objOperationRecordAnaesthesia,m_objWoundThingArr,dtpRecordTime.Enabled);
			if(lngSuccess<=0)
			{
			    m_mthShowDBError();
			}
			else
			{
				if(dtpRecordTime.Enabled)//若为新纪录添加该时间到时间树上
				{
					m_objSelectedOperationRecord=objOperationRecord;
					m_objSelectedOperationRecordContent=objOperationRecordContent;
					m_strSelectedOperationID=m_objOperationRecordOperation.strOperationID;
					m_strSelectedAnaesthesiaModeID=m_objOperationRecordAnaesthesia.strAnaesthesiaModeID;
                    //m_objSelectedOperatorArr=objOperationNurseArr;
					m_objSelectedWoundThingArr=m_objWoundThingArr ;
					m_mthAddNode(dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
				}
				else
				{
					//更新内存变量
					m_objSelectedOperationRecord=objOperationRecord;
					m_objSelectedOperationRecordContent=objOperationRecordContent;
					m_strSelectedOperationID=m_objOperationRecordOperation.strOperationID;
					m_strSelectedAnaesthesiaModeID=m_objOperationRecordAnaesthesia.strAnaesthesiaModeID;
                    //m_objSelectedOperatorArr=objOperationNurseArr;
					m_objSelectedWoundThingArr=m_objWoundThingArr ;
			
				}

				m_mthDisplayDataTableAndGroupBoxInfo();//更新界面
			}
			m_mthSetRichTextCanModifyLast(this,true);
			return 1;
			
		}

		
		private void m_mthAddNode(string strTime)
		{ 
			if(strTime=="" ||strTime==null) return ;
			TreeNode trnNode=new TreeNode(strTime);
			trnNode.Tag="1";
			if(trvTime.Nodes[0].Nodes.Count==0)
			{
				trvTime.Nodes[0].Nodes.Add(trnNode);
				trvTime.SelectedNode=trnNode ;
				trvTime.ExpandAll(); 
			}
			else 
			{
				for(int i=0;i<trvTime.Nodes[0].Nodes.Count;i++)
				{
					if(trnNode.Text.CompareTo (trvTime.Nodes[0].Nodes[i].Text)>0)
					{
						trvTime.Nodes[0].Nodes.Insert(i,trnNode);
						trvTime.SelectedNode=trnNode ;
						break;
					}
				}
			}
		}
		
		#endregion

		#region ClearUp Content
		/// <summary>
		/// 清空
		/// </summary>
		private void m_mthClearUpRecord()
		{

			#region 设置所有CheckBox and RadioBox 为初始值 RichTextBox 清空
			try
			{
				foreach(Control ctlControl in this.Controls )
				{
					string typeName = ctlControl.GetType().Name;
                    if (typeName == "DateTimePicker")
                    {
                        ((DateTimePicker)ctlControl).Value = DateTime.Now;
                    }
					else if(typeName == "ctlRichTextBox" )
					{
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_mthClearText();
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_StrUserID = MDIParent.OperatorID ;
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_StrUserName = MDIParent.OperatorName ;
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_ClrOldPartInsertText = Color.Black;
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_ClrDST = Color.Red;
						((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_BlnCanModifyLast = false;
					}
                    else if (typeName == "GroupBox")
					{
						int intTabIndex=m_intGetMinTabIndexInGrout((GroupBox)ctlControl);
						foreach(Control ctlGrp in ctlControl.Controls )
						{
						
							typeName=ctlGrp.GetType().Name ;
							if(typeName=="RadioButton")
							{
//								if(ctlGrp.TabIndex==intTabIndex)
//									((RadioButton)ctlGrp).Checked=true;
//								else 
									((RadioButton)ctlGrp).Checked=false;
						                            
							}
                            else if (typeName == "CheckBox")
								((CheckBox)ctlGrp).Checked=false;

                            else if (typeName == "ctlRichTextBox")
							{
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_mthClearText();
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_StrUserID = MDIParent.OperatorID ;
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_StrUserName = MDIParent.OperatorName ;
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_ClrOldPartInsertText = Color.Black;
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_ClrDST = Color.Red;
								((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_BlnCanModifyLast = false;
							}
                            else if (typeName == "GroupBox")
							{
								int intTabIndexSub=m_intGetMinTabIndexInGrout((GroupBox)ctlGrp);
								foreach(Control ctlSubGrp in ctlGrp.Controls )
								{   
								
									typeName=ctlSubGrp.GetType().Name ;
									if(typeName=="RadioButton")
									{
//										if(ctlSubGrp.TabIndex==intTabIndex)
//											((RadioButton)ctlSubGrp).Checked=true;
//										else 
											((RadioButton)ctlSubGrp).Checked=false;
										intTabIndexSub=ctlSubGrp.TabIndex;
                            
									}
                                    else if (typeName == "CheckBox")
										((CheckBox)ctlSubGrp).Checked=false;
                                    else if (typeName == "ctlRichTextBox")
										((com.digitalwave.controls.ctlRichTextBox)ctlSubGrp).m_mthClearText();
								
								}
							}
						}
					}
				}
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);
			}

			#endregion 
			
			m_mthClear_Recursive(tabControl2,null);
			
			txtOperationRoom.m_mthClearText();

			m_strCurrentOpenDate = "";		
			
			dtgSences.CurrentRowIndex = 0;
			dtbSences.Rows.Clear ();

			dtgAllergic.CurrentRowIndex = 0;
			dtbAllergic.Rows.Clear();

			dtgOperationLocation.CurrentRowIndex = 0;
			dtbOperationLocation.Rows.Clear();

			dtgElectKnife.CurrentRowIndex = 0;
			dtbElectKnife.Rows.Clear ();

			dtgDoublePole.CurrentRowIndex = 0;
			dtbDoublePole.Rows.Clear ();

			dtgCathodeLocationSkin.CurrentRowIndex = 0;
			dtbCathodeLocationSkin.Rows.Clear ();

			dtgStypticRubber.CurrentRowIndex = 0;
			dtbStypticRubber.Rows.Clear ();

			dtgFoley.CurrentRowIndex = 0;
			dtbFoley.Rows.Clear ();

			dtgStomach.CurrentRowIndex = 0;
			dtbStomach.Rows.Clear ();

			dtgSkinAntisepsis.CurrentRowIndex = 0;
			dtbSkinAntisepsis.Rows.Clear ();

			dtgBlood.CurrentRowIndex = 0;
			dtbBlood.Rows.Clear ();

			dtgOutFlow.CurrentRowIndex = 0;
			dtbOutFlow.Rows.Clear ();

			dtgFromHeadToFootSkin.CurrentRowIndex = 0;
			dtbFromHeadToFootSkin.Rows.Clear ();

			dtgSample.CurrentRowIndex = 0;
			dtbSample.Rows.Clear ();

			dtgAfterOperationSendAfterOperationSend.CurrentRowIndex = 0;
			dtbAfterOperationSend.Rows.Clear ();

			dtgUpStyptic.CurrentRowIndex = 0;
			dtbUpStyptic.Rows.Clear ();

			dtgDownStyptic.CurrentRowIndex = 0;
			dtbDownStyptic.Rows.Clear ();

			dtgOutFlowThing.CurrentRowIndex = 0;
			dtbOutFlowThing.Rows.Clear ();

			dtgFromHeadToFootSkinAfterOperation.CurrentRowIndex = 0;
			dtbFromHeadToFootSkinAfterOperation.Rows.Clear ();

			dtgCathodeLocationAfterOperationSkin.CurrentRowIndex = 0;
			dtbCathodeLocationAfterOperationSkin.Rows.Clear ();

			dtgOperationIDAndAnaesthesia.CurrentRowIndex = 0;
			dtbOperationIDAndAnaesthesia.Rows.Clear();

            //dtgNurse.CurrentRowIndex = 0;
            //dtbNurse.Rows.Clear();

			dtgOutFlowThing.CurrentRowIndex = 0;
			dtbOutFlowThing.Rows.Clear();

			this.dtpLeaveRoomTime.Value=DateTime.Now;
			this.dtpOperationBeginTime.Value=DateTime.Now;
			this.dtpOperationOverTime.Value =DateTime.Now;
			this.dtpPatientInDate.Value=DateTime.Now;
			this.dtpRecordTime.Value=DateTime.Now;
			this.dtpRecordTime.Enabled =true;

			this.cboAnaesthesiaModeID.SelectedIndex=-1;
			this.cboOperationID.SelectedIndex =-1;
            m_lsvOperationer.Items.Clear();
            m_lsvAnaDocSign.Items.Clear();
            m_lsvWashNurseSign.Items.Clear();
            m_lsvCircuitNurseSign.Items.Clear();
            m_lsvBacilliCheckSign.Items.Clear();
            m_lsvRecordNurseSign.Items.Clear();
            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
		
			arlNurse.Clear();
			m_arlWoundThing.Clear();
				
		}


		private int m_intGetMinTabIndexInGrout(GroupBox gpbControl)
		{
			int intIndex=100000;
			foreach(Control ctlSub in gpbControl.Controls)
			{
				if(intIndex>ctlSub.TabIndex)
					intIndex=ctlSub.TabIndex ;
			}
			return intIndex ;
		}
		
		#endregion ClearUp Content

		#region LoadTree ->Select TreeNode ->Display
		private void m_mthLoadAllRecordTimeOfAPatient(string p_strPatientID,string p_strPatientDate)
		{
			m_mthClearUpRecord();
			if(p_strPatientID ==null || p_strPatientID =="") 
				return ;
			this.trvTime.Nodes[0].Nodes.Clear();
			DateTime [] m_dtmArr= objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strPatientID ,p_strPatientDate);
			if(m_dtmArr==null) 
			{
				return ;
			}

			for(int i=0;i<m_dtmArr.Length ;i++)
			{
				string strDate=m_dtmArr[i].ToString("yyyy-MM-dd HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag ="1";
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
			}
            this.trvTime.ExpandAll();

			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}

        protected bool m_blnCanShowDiseaseTrack = true;
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

			try
			{
				m_mthRecordChangedToSave();

				m_mthClearUpRecord();

				if(this.trvTime.SelectedNode.Tag.ToString() == "0")
				{
					
					this.dtpRecordTime.Enabled =true;
					m_objSelectedOperationRecord=null;
					m_objSelectedOperationRecordContent=null;
					m_strSelectedOperationID="";
					m_strSelectedAnaesthesiaModeID="";
					m_objSelectedOperatorArr=null;
					m_objSelectedWoundThingArr=null;

					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
	
					return;	

				}
				else
				{
                    if (!m_blnCanShowDiseaseTrack)
                    {
                        clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                        return;
                    }

					this.dtpRecordTime.Enabled = false;
                    this.m_cmdSign.Enabled = false;
					m_mthSetSummaryInfo(m_objSelectedPatient,this.trvTime.SelectedNode.Text);

					if(m_objSelectedOperationRecordContent==null)
					{
						m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
						m_mthSetRichTextCanModifyLast(this,true);
					}
					else
					{
						m_mthSetRichTextModifyColor(this,Color.Red);
						m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(m_objSelectedOperationRecordContent.strLastModifyUserID));
					}
//					if(m_objSelectedOperationRecord==null)
//					{
//						string strLastModifyDate="";
//						string strModidyUserID="";
//
//						long lngRes=objDomain.m_lngGetDeleteUser(m_strInPatientID,m_strInPatientDate,m_objSelectedOperationRecord,out strLastModifyDate ,out strModidyUserID);
//						if(lngRes<=0)
//                            return  ;
//						m_mthShowRecordDeleted(new clsEmployee(strModidyUserID).m_StrFirstName,strLastModifyDate);
//
//					}
					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );

				}

				m_mthAddFormStatusForClosingSave();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message + "\r\n" + err.StackTrace);
			}
		}

		private void m_mthSetSummaryInfo(clsPatient objPatient,string p_strCreateDate)
		{
			if(objPatient==null || p_strCreateDate==null ||p_strCreateDate=="")
				return ;
			clsOperationRecord  objOperationRecord=new clsOperationRecord();
			clsOperationRecordContent objOPerationRecordContent=new clsOperationRecordContent();
			
			long lngRes=objDomain.m_lngGetOperationRecord(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out objOperationRecord);
			if(lngRes>=0)
			{
				m_objSelectedOperationRecord=objOperationRecord ;
			}
			else
			{
				m_objSelectedOperationRecord=null;
			}
			lngRes=objDomain.m_lngGetOperationRecordContent(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out objOPerationRecordContent);

			if(lngRes>=0)
			{
				m_objSelectedOperationRecordContent=objOPerationRecordContent;
                //m_objSignTool.m_mtSetSpecialEmployee(objOPerationRecordContent.strLastModifyUserID);
			}
			else 
			{
				m_objSelectedOperationRecordContent=null;
			}
			lngRes=objDomain.m_lngGetLastestAnaesthesiaID(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out m_strSelectedAnaesthesiaModeID);

			if(lngRes<0)
			{
				m_strSelectedAnaesthesiaModeID="";
			}
			lngRes=objDomain.m_lngGetLastestOperationID(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out m_strSelectedOperationID);
			if(lngRes<0)
			{
				m_strSelectedOperationID="";
			}
			
			m_mthDisplayDataTableAndGroupBoxInfo();

			if(m_objSelectedOperationRecord!=null)
			{
                m_mthDisplayOperationOperator(m_objSelectedOperationRecord.objSignerArr);
				m_mthDisplayWoundThing(p_strCreateDate);
			}

		}

		private void m_mthSetDeleteSummaryInfo(clsPatient objPatient,string p_strCreateDate)
		{
			if(objPatient==null || p_strCreateDate==null ||p_strCreateDate=="")
				return ;
			clsOperationRecord  objOperationRecord=new clsOperationRecord();
			clsOperationRecordContent objOPerationRecordContent=new clsOperationRecordContent();

			long lngRes=objDomain.m_lngGetDeleteOperationRecord(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out objOperationRecord);
			if(lngRes>=0)
			{
				m_objSelectedOperationRecord=objOperationRecord ;
			}
			else
			{
				m_objSelectedOperationRecord=null;
			}
			lngRes=objDomain.m_lngGetDeleteOperationRecordContent(m_strInPatientID,m_strInPatientDate,p_strCreateDate,out objOPerationRecordContent);

			if(lngRes>=0)
			{
				m_objSelectedOperationRecordContent=objOPerationRecordContent;
			}
			else 
			{
				m_objSelectedOperationRecordContent=null;
			}
						
			m_mthDisplayDeleteDataTableAndGroupBoxInfo();
            m_mthDisplayOperationOperator(m_objSelectedOperationRecord.objSignerArr);
		}

		#region 根据所选时间的内容填充DataTable和GroupBox
		private void m_mthDisplayDataTableAndGroupBoxInfo()
		{
			try
			{
				if(m_objSelectedOperationRecord == null && m_objSelectedOperationRecordContent==null)
					return;

				m_strCurrentOpenDate = m_objSelectedOperationRecord.strOpenDate;

				dtpRecordTime.Value = DateTime.Parse(m_objSelectedOperationRecord.strCreateDate);
				
				txtRecordContent.m_mthSetNewText(m_objSelectedOperationRecordContent.strTendRecord,m_objSelectedOperationRecord.strTendRecordXML);
				cboOperationID.Text = m_objSelectedOperationRecordContent.strOperationName;
				cboAnaesthesiaModeID.Text = m_objSelectedOperationRecordContent.strAnaesthesiaMode;

                //#region 手术名称cbo
                //for(int i1=0; i1<cboOperationID.GetItemsCount();i1++)
                //{
                //    if(((clsOperationIDInOperation)(cboOperationID.GetItem(i1))).strOperationID == m_strSelectedOperationID)
                //    {
                //        cboOperationID.SelectedIndex = i1;
                //        break;
                //    }
                //}
                //#endregion

                //#region 麻醉方式
                //for(int i1=0; i1<cboAnaesthesiaModeID.GetItemsCount();i1++)
                //{
                //    if(((clsAnaesthesiaModeInOperation)(cboAnaesthesiaModeID.GetItem(i1))).strAnaesthesiaModeID == m_strSelectedAnaesthesiaModeID)
                //    {
                //        cboAnaesthesiaModeID.SelectedIndex = i1;
                //        break;
                //    }
                //}

                //#endregion

				#region 手术名称及麻醉方式

				bool [] blnIsDSTArr=new bool[dtbOperationIDAndAnaesthesia.Columns.Count];
				for(int i=0;i<dtbOperationIDAndAnaesthesia.Columns.Count;i++)
				{						
					blnIsDSTArr[i]=true;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOperation_AnaesthesiaXML,blnIsDSTArr,m_objXmlParser,ref dtgOperationIDAndAnaesthesia);

				#endregion

				#region 神志
				blnIsDSTArr=new bool[dtbSences.Columns.Count];
				for(int i=0;i<dtbSences.Columns.Count;i++)
				{						
					if(i>dtbSences.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSensesXML,blnIsDSTArr,m_objXmlParser,ref dtgSences);
				if(dtbSences.Rows.Count>0)
				{
					rdbSencesClear.Checked=(bool)(dtbSences.Rows[0][0]);
					rdbSencesSleep.Checked=(bool)(dtbSences.Rows[0][1]);
					rdbSencesComa.Checked=(bool)(dtbSences.Rows[0][2]);
				}
				#endregion

				#region 过敏史
				blnIsDSTArr=new bool[dtbAllergic.Columns.Count];
				for(int i=0;i<dtbAllergic.Columns.Count;i++)
				{						
					if(i>dtbAllergic.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strAllergicXML,blnIsDSTArr,m_objXmlParser,ref dtgAllergic);
				if(dtbAllergic.Rows.Count>0)
				{
					rdbHaveNotAllergic.Checked=(bool)(dtbAllergic.Rows[0][0]);
					rdbHaveAllergic.Checked=(bool)(dtbAllergic.Rows[0][1]);
					txtAllergicContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbAllergic.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbAllergic.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				//***********************************
				//2003.3.5 刘荣国修改				
				//手术体位, 手术间,时间, 使用电刀
				//双极电凝,术前负极板部位皮肤
				//术后负极板部位皮肤
				//止血带
				//气压止血肢体位置一
				//气压止血肢体位置二
				//停留Foley氏尿管
				//停留胃管
				//皮肤消毒,血制品,术前全身皮肤情况
				//术后全身皮肤情况,标本
				//术后送回
				#region 手术体位
				blnIsDSTArr = new bool[dtbOperationLocation.Columns.Count];
				for(int i=0;i<dtbOperationLocation.Columns.Count;i++)
				{						
					if(i>dtbOperationLocation.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOperationLocationXML,blnIsDSTArr,m_objXmlParser,ref dtgOperationLocation);
				if(dtbOperationLocation.Rows.Count>0)
				{
					rdbOperationLocationOnHisBack.Checked=(bool)(dtbOperationLocation.Rows[0][0]);
					rdbOperationLocationSide.Checked=(bool)(dtbOperationLocation.Rows[0][1]);
					rdbOperationLocationPA.Checked=(bool)(dtbOperationLocation.Rows[0][2]);
					rdbOperationLocationParaplegic.Checked=(bool)(dtbOperationLocation.Rows[0][3]);
					rdbOperationLocationHypothyroid.Checked=(bool)(dtbOperationLocation.Rows[0][4]);
					rdbOperationLocationOther.Checked = (bool)(dtbOperationLocation.Rows[0][5]);
					txtOtherOperationLocation.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbOperationLocation.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbOperationLocation.Rows[0][6])).m_strDSTXml);
				}
				#endregion

				#region 手术间,时间
				txtOperationRoom.m_mthSetNewText(m_objSelectedOperationRecordContent.strOperationRoom,m_objSelectedOperationRecord.strOperationRoomXML);
				dtpOperationBeginTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationBeginDate);
				dtpOperationOverTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationEndDate);
				dtpLeaveRoomTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationLeaveDate);
				#endregion

				#region 使用电刀
				blnIsDSTArr = new bool[dtbElectKnife.Columns.Count];
				for(int i=0;i<dtbElectKnife.Columns.Count;i++)
				{						
					if(i>dtbElectKnife.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strElectKnifeXML,blnIsDSTArr,m_objXmlParser,ref dtgElectKnife);
				if(dtbElectKnife.Rows.Count>0)
				{
					rdbHaveNotElectKnife.Checked=(bool)(dtbElectKnife.Rows[0][0]);
					rdbHaveUsedElectKnife.Checked=(bool)(dtbElectKnife.Rows[0][1]);
					txtElectKnifeModel.m_mthSetNewText(((clsDSTRichTextBoxValue)(dtbElectKnife.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbElectKnife.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 双极电凝
				blnIsDSTArr = new bool[dtbDoublePole.Columns.Count];
				for(int i=0;i<dtbDoublePole.Columns.Count;i++)
				{						
					if(i>dtbDoublePole.Columns.Count-5)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strDoublePoleXML,blnIsDSTArr,m_objXmlParser,ref dtgDoublePole);
				if(dtbDoublePole.Rows.Count>0)
				{
					rdbHaveNotDoublePole.Checked=(bool)(dtbDoublePole.Rows[0][0]);
					rdbHaveDoublePole.Checked=(bool)(dtbDoublePole.Rows[0][1]);
					txtDoublePoleMode.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][2])).m_strDSTXml);
					txtCathodeLocation.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][3])).m_strText,((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][3])).m_strDSTXml);
				}
				#endregion

				#region 术前负极板部位皮肤
				blnIsDSTArr = new bool[dtbCathodeLocationSkin.Columns.Count];
				for(int i=0;i<dtbCathodeLocationSkin.Columns.Count;i++)
				{						
					if(i>dtbCathodeLocationSkin.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strCathodeLocationSkinXML,blnIsDSTArr,m_objXmlParser,ref dtgCathodeLocationSkin);
				if(dtbCathodeLocationSkin.Rows.Count>0)
				{
					rdbCathodeLocationSkinBeforOperationFull.Checked=(bool)(dtbCathodeLocationSkin.Rows[0][0]);
					rdbCathodeLocationSkinBeforOperationMar.Checked=(bool)(dtbCathodeLocationSkin.Rows[0][1]);
				}
				#endregion

				#region 术后负极板部位皮肤
				blnIsDSTArr = new bool[dtbCathodeLocationAfterOperationSkin.Columns.Count];
				for(int i=0;i<dtbCathodeLocationAfterOperationSkin.Columns.Count;i++)
				{						
					if(i>dtbCathodeLocationAfterOperationSkin.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strCathodeLocationSkinAfterOperationXML,blnIsDSTArr,m_objXmlParser,ref dtgCathodeLocationAfterOperationSkin);
				if(dtbCathodeLocationAfterOperationSkin.Rows.Count>0)
				{
					rdbCathodeLocationSkinAfterOperationFull.Checked=(bool)(dtbCathodeLocationAfterOperationSkin.Rows[0][0]);
					rdbCathodeLocationSkinAfterOperationMar.Checked=(bool)(dtbCathodeLocationAfterOperationSkin.Rows[0][1]);
				}
				#endregion

				#region 止血带
				blnIsDSTArr = new bool[dtbStypticRubber.Columns.Count];
				for(int i=0;i<dtbStypticRubber.Columns.Count;i++)
				{						
					if(i>dtbStypticRubber.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strStypticRubberXML,blnIsDSTArr,m_objXmlParser,ref dtgStypticRubber);
				if(dtbStypticRubber.Rows.Count>0)
				{
					chkStypticRubber.Checked=(bool)(dtbStypticRubber.Rows[0][0]);
					chkStypticPressure.Checked=(bool)(dtbStypticRubber.Rows[0][1]);
					txtStypticPressureMode.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbStypticRubber.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbStypticRubber.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 气压止血肢体位置一
				blnIsDSTArr = new bool[dtbUpStyptic.Columns.Count];
				for(int i=0;i<dtbUpStyptic.Columns.Count;i++)
				{						
					if(i>dtbUpStyptic.Columns.Count-7)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strUpXML,blnIsDSTArr,m_objXmlParser,ref dtgUpStyptic);
				if(dtbUpStyptic.Rows.Count>0)
				{
					chkUpForearm.Checked=(bool)(dtbUpStyptic.Rows[0][0]);
					chkUpThigh.Checked=(bool)(dtbUpStyptic.Rows[0][1]);
					chkUpLeft.Checked = (bool)(dtbUpStyptic.Rows[0][2]);
					chkUpRight.Checked = (bool)(dtbUpStyptic.Rows[0][3]);
					txtUpPuffDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][4])).m_strDSTXml);
					txtUpDeflateDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][5])).m_strDSTXml);
					txtUpTotalDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][6])).m_strDSTXml);
					txtUpPress.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][7])).m_strDSTXml);
				}
				#endregion

				#region 气压止血肢体位置二
				blnIsDSTArr = new bool[dtbDownStyptic.Columns.Count];
				for(int i=0;i<dtbDownStyptic.Columns.Count;i++)
				{						
					if(i>dtbDownStyptic.Columns.Count-7)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strDownXML,blnIsDSTArr,m_objXmlParser,ref dtgDownStyptic);
				if(dtbUpStyptic.Rows.Count>0)
				{
					chkDownForearm.Checked=(bool)(dtbDownStyptic.Rows[0][0]);
					chkDownThigh.Checked=(bool)(dtbDownStyptic.Rows[0][1]);
					chkDownLeft.Checked = (bool)(dtbDownStyptic.Rows[0][2]);
					chkDownRight.Checked = (bool)(dtbDownStyptic.Rows[0][3]);
					txtDownPuffDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][4])).m_strDSTXml);
					txtDownDeflateDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][5])).m_strDSTXml);
					txtDownTotalDateTime.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][6])).m_strDSTXml);
					txtDownPress.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][7])).m_strDSTXml);
				}
				#endregion

				#region 停留Foley氏尿管
				blnIsDSTArr = new bool[dtbFoley.Columns.Count];
				for(int i=0;i<dtbFoley.Columns.Count;i++)
				{						
					if(i>dtbFoley.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFoleyXML,blnIsDSTArr,m_objXmlParser,ref dtgFoley);
				if(dtbFoley.Rows.Count>0)
				{
					chkFoleySickroom.Checked=(bool)(dtbFoley.Rows[0][0]);
					chkFoleyOperationRoom.Checked=(bool)(dtbFoley.Rows[0][1]);
					chkFoleyDoubleAntrum.Checked = (bool)(dtbFoley.Rows[0][2]);
					chkFoleyThreeAntrum.Checked = (bool)(dtbFoley.Rows[0][3]);
					chkFoleyOther.Checked = (bool)(dtbFoley.Rows[0][4]);
					txtFoleyOtherContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbFoley.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbFoley.Rows[0][5])).m_strDSTXml);
				}
				#endregion

				#region 停留胃管
				blnIsDSTArr = new bool[dtbStomach.Columns.Count];
				for(int i=0;i<dtbStomach.Columns.Count;i++)
				{						
					if(i>dtbStomach.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strStomachXML,blnIsDSTArr,m_objXmlParser,ref dtgStomach);
				if(dtbStomach.Rows.Count>0)
				{
					rdbStomachSickroom.Checked=(bool)(dtbStomach.Rows[0][0]);
					rdbStomachOprationRoom.Checked=(bool)(dtbStomach.Rows[0][1]);
				}
				#endregion

				#region 皮肤消毒
				blnIsDSTArr = new bool[dtbSkinAntisepsis.Columns.Count];
				for(int i=0;i<dtbSkinAntisepsis.Columns.Count;i++)
				{						
					if(i>dtbSkinAntisepsis.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSkinAntisepsisXML,blnIsDSTArr,m_objXmlParser,ref dtgSkinAntisepsis);
				if(dtbSkinAntisepsis.Rows.Count>0)
				{
					chkSkinAntisepsis2.Checked=(bool)(dtbSkinAntisepsis.Rows[0][0]);
					chkSkinAntisepsis75.Checked=(bool)(dtbSkinAntisepsis.Rows[0][1]);
					chkSkinAntisepsisIodin.Checked=(bool)(dtbSkinAntisepsis.Rows[0][2]);
					chkSkinAntisepsisIodinRare.Checked=(bool)(dtbSkinAntisepsis.Rows[0][3]);
					chkSkinAntisepsisOther.Checked=(bool)(dtbSkinAntisepsis.Rows[0][4]);
					txtSkinAntisepsisOtherContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbSkinAntisepsis.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbSkinAntisepsis.Rows[0][5])).m_strDSTXml);
				}
				#endregion

				#region 血制品
				blnIsDSTArr = new bool[dtbBlood.Columns.Count];
				for(int i=0;i<dtbBlood.Columns.Count;i++)
				{	
					if(i<(dtbBlood.Columns.Count - 2))
					{
						if((i % 2) != 0)
							blnIsDSTArr[i] = true;
						else
							blnIsDSTArr[i] = false;
					}
					else
						blnIsDSTArr[i] = true;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strBloodXML,blnIsDSTArr,m_objXmlParser,ref dtgBlood);
				if(dtbBlood.Rows.Count>0)
				{
					chkAllBlood.Checked=(bool)(dtbBlood.Rows[0][0]);
					txtAllBloodQty.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][1])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][1])).m_strDSTXml);
					chkRedCell.Checked=(bool)(dtbBlood.Rows[0][2]);
					txtRedCellQty.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][3])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][3])).m_strDSTXml);
					chkBloodPlasm.Checked=(bool)(dtbBlood.Rows[0][4]);
					txtBloodPlasmQty.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][5])).m_strDSTXml);
					chkOwnBlood.Checked=(bool)(dtbBlood.Rows[0][6]);
					txtOwnBloodQty.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][7])).m_strDSTXml);
					chkBloodOther.Checked=(bool)(dtbBlood.Rows[0][8]);
					txtBloodOther.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][9])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][9])).m_strDSTXml);					
				}
				#endregion

				#region 术前全身皮肤情况
				blnIsDSTArr = new bool[dtbFromHeadToFootSkin.Columns.Count];
				for(int i=0;i<dtbFromHeadToFootSkin.Columns.Count;i++)
				{						
					if(i>dtbFromHeadToFootSkin.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFromHeadToFootSkinXML,blnIsDSTArr,m_objXmlParser,ref dtgFromHeadToFootSkin);
				if(dtbFromHeadToFootSkin.Rows.Count>0)
				{
					rdbFromHeadToFootSkinBeforeOperationFull.Checked=(bool)(dtbFromHeadToFootSkin.Rows[0][0]);
					rdbFromHeadToFootSkinBeforeOperationMar.Checked=(bool)(dtbFromHeadToFootSkin.Rows[0][1]);
					txtFromHeadToFootSkinBeforeOperationContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkin.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkin.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 术后全身皮肤情况
				blnIsDSTArr = new bool[dtbFromHeadToFootSkinAfterOperation.Columns.Count];
				for(int i=0;i<dtbFromHeadToFootSkinAfterOperation.Columns.Count;i++)
				{						
					if(i>dtbFromHeadToFootSkinAfterOperation.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFromHeadToFootSkinAfterOperationXML,blnIsDSTArr,m_objXmlParser,ref dtgFromHeadToFootSkinAfterOperation);
				if(dtbFromHeadToFootSkinAfterOperation.Rows.Count>0)
				{
					rdbFromHeadToFootSkinAfterOperationFull.Checked=(bool)(dtbFromHeadToFootSkinAfterOperation.Rows[0][0]);
					rdbFromHeadToFootSkinAfterOperationMar.Checked=(bool)(dtbFromHeadToFootSkinAfterOperation.Rows[0][1]);
					txtFromHeadToFootSkinAfterOperationContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkinAfterOperation.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkinAfterOperation.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 标本
				blnIsDSTArr = new bool[dtbSample.Columns.Count];
				for(int i=0;i<dtbSample.Columns.Count;i++)
				{						
					if(i>dtbSample.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSampleXML,blnIsDSTArr,m_objXmlParser,ref dtgSample);
				if(dtbSample.Rows.Count>0)
				{
					chkSampleGeneral.Checked=(bool)(dtbSample.Rows[0][0]);
					chkSampleSlice.Checked=(bool)(dtbSample.Rows[0][1]);
					chkSampleBacilli.Checked=(bool)(dtbSample.Rows[0][2]);
					chkSampleOther.Checked=(bool)(dtbSample.Rows[0][3]);
					txtSampleOtherContent.m_mthSetNewText( ((clsDSTRichTextBoxValue)(dtbSample.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbSample.Rows[0][4])).m_strDSTXml);
				}
				#endregion

				#region 术后送回
				blnIsDSTArr = new bool[dtbAfterOperationSend.Columns.Count];
				for(int i=0;i<dtbAfterOperationSend.Columns.Count;i++)
				{						
					if(i>dtbAfterOperationSend.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strAfterOperationSendXML,blnIsDSTArr,m_objXmlParser,ref dtgAfterOperationSendAfterOperationSend);
				if(dtbAfterOperationSend.Rows.Count>0)
				{
					rdbAfterOperationSendRenew.Checked=(bool)(dtbAfterOperationSend.Rows[0][0]);
					rdbAfterOperationSendICU.Checked=(bool)(dtbAfterOperationSend.Rows[0][1]);
					rdbAfterOperationSendSickRoom.Checked=(bool)(dtbAfterOperationSend.Rows[0][2]);
				}
				#endregion

				#region 输入液体量和术中尿量
				txtInLiquidQty.m_mthSetNewText(m_objSelectedOperationRecordContent.strInLiquidQty,m_objSelectedOperationRecord.strInLiquidQtyXML);
				txtPeeOperatingQty.m_mthSetNewText(m_objSelectedOperationRecordContent.strPeeOperatingQty,m_objSelectedOperationRecord.strPeeOperatingQtyXML);

			#endregion

				//2003.3.6刘荣国修改
				#region 伤口引流物情况
				blnIsDSTArr = new bool[dtbOutFlow.Columns.Count];
				for(int i=0;i<dtbOutFlow.Columns.Count;i++)
				{						
					if(i>dtbOutFlow.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOutFlowXML,blnIsDSTArr,m_objXmlParser,ref dtgOutFlow);
				if(dtbOutFlow.Rows.Count>0)
				{
					rdbHaveNotOutflow.Checked=(bool)(dtbOutFlow.Rows[0][0]);
					rdbHaveOutFlow.Checked=(bool)(dtbOutFlow.Rows[0][1]);
				}
				#endregion

			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message + "\r\n" + err.StackTrace);
			}
		}

		#endregion

		#region 根据所选时间的已被删除的内容填充DataTable和GroupBox
		private void m_mthDisplayDeleteDataTableAndGroupBoxInfo()
		{
			try
			{
				if(m_objSelectedOperationRecord == null && m_objSelectedOperationRecordContent==null)
					return;
//				dtpRecordTime.Value = DateTime.Parse(m_objSelectedOperationRecord.strCreateDate);
				
				txtRecordContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectedOperationRecordContent.strTendRecord,m_objSelectedOperationRecord.strTendRecordXML);
				cboOperationID.Text=m_objSelectedOperationRecordContent.strOperationName;
				cboAnaesthesiaModeID.Text=m_objSelectedOperationRecordContent.strAnaesthesiaMode;

				#region 手术名称及麻醉方式

				bool [] blnIsDSTArr=new bool[dtbOperationIDAndAnaesthesia.Columns.Count];
				for(int i=0;i<dtbOperationIDAndAnaesthesia.Columns.Count;i++)
				{						
					blnIsDSTArr[i]=true;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOperation_AnaesthesiaXML,blnIsDSTArr,m_objXmlParser,ref dtgOperationIDAndAnaesthesia);

				#endregion

				#region 神志
				blnIsDSTArr=new bool[dtbSences.Columns.Count];
				for(int i=0;i<dtbSences.Columns.Count;i++)
				{						
					if(i>dtbSences.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSensesXML,blnIsDSTArr,m_objXmlParser,ref dtgSences);
				if(dtbSences.Rows.Count>0)
				{
					rdbSencesClear.Checked=(bool)(dtbSences.Rows[0][0]);
					rdbSencesSleep.Checked=(bool)(dtbSences.Rows[0][1]);
					rdbSencesComa.Checked=(bool)(dtbSences.Rows[0][2]);
				}
				#endregion

				#region 过敏史
				blnIsDSTArr=new bool[dtbAllergic.Columns.Count];
				for(int i=0;i<dtbAllergic.Columns.Count;i++)
				{						
					if(i>dtbAllergic.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strAllergicXML,blnIsDSTArr,m_objXmlParser,ref dtgAllergic);
				if(dtbAllergic.Rows.Count>0)
				{
					rdbHaveNotAllergic.Checked=(bool)(dtbAllergic.Rows[0][0]);
					rdbHaveAllergic.Checked=(bool)(dtbAllergic.Rows[0][1]);
					txtAllergicContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbAllergic.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbAllergic.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				//***********************************
				//2003.3.5 刘荣国修改				
				//手术体位, 手术间,时间, 使用电刀
				//双极电凝,术前负极板部位皮肤
				//术后负极板部位皮肤
				//止血带
				//气压止血肢体位置一
				//气压止血肢体位置二
				//停留Foley氏尿管
				//停留胃管
				//皮肤消毒,血制品,术前全身皮肤情况
				//术后全身皮肤情况,标本
				//术后送回
				#region 手术体位
				blnIsDSTArr = new bool[dtbOperationLocation.Columns.Count];
				for(int i=0;i<dtbOperationLocation.Columns.Count;i++)
				{						
					if(i>dtbOperationLocation.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOperationLocationXML,blnIsDSTArr,m_objXmlParser,ref dtgOperationLocation);
				if(dtbOperationLocation.Rows.Count>0)
				{
					rdbOperationLocationOnHisBack.Checked=(bool)(dtbOperationLocation.Rows[0][0]);
					rdbOperationLocationSide.Checked=(bool)(dtbOperationLocation.Rows[0][1]);
					rdbOperationLocationPA.Checked=(bool)(dtbOperationLocation.Rows[0][2]);
					rdbOperationLocationParaplegic.Checked=(bool)(dtbOperationLocation.Rows[0][3]);
					rdbOperationLocationHypothyroid.Checked=(bool)(dtbOperationLocation.Rows[0][4]);
					rdbOperationLocationOther.Checked = (bool)(dtbOperationLocation.Rows[0][5]);
					txtOtherOperationLocation.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbOperationLocation.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbOperationLocation.Rows[0][6])).m_strDSTXml);
				}
				#endregion

				#region 手术间,时间
				txtOperationRoom.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectedOperationRecordContent.strOperationRoom,m_objSelectedOperationRecord.strOperationRoomXML);
				dtpOperationBeginTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationBeginDate);
				dtpOperationOverTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationEndDate);
				dtpLeaveRoomTime.Value = DateTime.Parse(m_objSelectedOperationRecordContent.strOperationLeaveDate);
				#endregion

				#region 使用电刀
				blnIsDSTArr = new bool[dtbElectKnife.Columns.Count];
				for(int i=0;i<dtbElectKnife.Columns.Count;i++)
				{						
					if(i>dtbElectKnife.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strElectKnifeXML,blnIsDSTArr,m_objXmlParser,ref dtgElectKnife);
				if(dtbElectKnife.Rows.Count>0)
				{
					rdbHaveNotElectKnife.Checked=(bool)(dtbElectKnife.Rows[0][0]);
					rdbHaveUsedElectKnife.Checked=(bool)(dtbElectKnife.Rows[0][1]);
					txtElectKnifeModel.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(((clsDSTRichTextBoxValue)(dtbElectKnife.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbElectKnife.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 双极电凝
				blnIsDSTArr = new bool[dtbDoublePole.Columns.Count];
				for(int i=0;i<dtbDoublePole.Columns.Count;i++)
				{						
					if(i>dtbDoublePole.Columns.Count-5)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strDoublePoleXML,blnIsDSTArr,m_objXmlParser,ref dtgDoublePole);
				if(dtbDoublePole.Rows.Count>0)
				{
					rdbHaveNotDoublePole.Checked=(bool)(dtbDoublePole.Rows[0][0]);
					rdbHaveDoublePole.Checked=(bool)(dtbDoublePole.Rows[0][1]);
					txtDoublePoleMode.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][2])).m_strDSTXml);
					txtCathodeLocation.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][3])).m_strText,((clsDSTRichTextBoxValue)(dtbDoublePole.Rows[0][3])).m_strDSTXml);
				}
				#endregion

				#region 术前负极板部位皮肤
				blnIsDSTArr = new bool[dtbCathodeLocationSkin.Columns.Count];
				for(int i=0;i<dtbCathodeLocationSkin.Columns.Count;i++)
				{						
					if(i>dtbCathodeLocationSkin.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strCathodeLocationSkinXML,blnIsDSTArr,m_objXmlParser,ref dtgCathodeLocationSkin);
				if(dtbCathodeLocationSkin.Rows.Count>0)
				{
					rdbCathodeLocationSkinBeforOperationFull.Checked=(bool)(dtbCathodeLocationSkin.Rows[0][0]);
					rdbCathodeLocationSkinBeforOperationMar.Checked=(bool)(dtbCathodeLocationSkin.Rows[0][1]);
				}
				#endregion

				#region 术后负极板部位皮肤
				blnIsDSTArr = new bool[dtbCathodeLocationAfterOperationSkin.Columns.Count];
				for(int i=0;i<dtbCathodeLocationAfterOperationSkin.Columns.Count;i++)
				{						
					if(i>dtbCathodeLocationAfterOperationSkin.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strCathodeLocationSkinAfterOperationXML,blnIsDSTArr,m_objXmlParser,ref dtgCathodeLocationAfterOperationSkin);
				if(dtbCathodeLocationAfterOperationSkin.Rows.Count>0)
				{
					rdbCathodeLocationSkinAfterOperationFull.Checked=(bool)(dtbCathodeLocationAfterOperationSkin.Rows[0][0]);
					rdbCathodeLocationSkinAfterOperationMar.Checked=(bool)(dtbCathodeLocationAfterOperationSkin.Rows[0][1]);
				}
				#endregion

				#region 止血带
				blnIsDSTArr = new bool[dtbStypticRubber.Columns.Count];
				for(int i=0;i<dtbStypticRubber.Columns.Count;i++)
				{						
					if(i>dtbStypticRubber.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strStypticRubberXML,blnIsDSTArr,m_objXmlParser,ref dtgStypticRubber);
				if(dtbStypticRubber.Rows.Count>0)
				{
					chkStypticRubber.Checked=(bool)(dtbStypticRubber.Rows[0][0]);
					chkStypticPressure.Checked=(bool)(dtbStypticRubber.Rows[0][1]);
					txtStypticPressureMode.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbStypticRubber.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbStypticRubber.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 气压止血肢体位置一
				blnIsDSTArr = new bool[dtbUpStyptic.Columns.Count];
				for(int i=0;i<dtbUpStyptic.Columns.Count;i++)
				{						
					if(i>dtbUpStyptic.Columns.Count-7)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strUpXML,blnIsDSTArr,m_objXmlParser,ref dtgUpStyptic);
				if(dtbUpStyptic.Rows.Count>0)
				{
					chkUpForearm.Checked=(bool)(dtbUpStyptic.Rows[0][0]);
					chkUpThigh.Checked=(bool)(dtbUpStyptic.Rows[0][1]);
					chkUpLeft.Checked = (bool)(dtbUpStyptic.Rows[0][2]);
					chkUpRight.Checked = (bool)(dtbUpStyptic.Rows[0][3]);
					txtUpPuffDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][4])).m_strDSTXml);
					txtUpDeflateDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][5])).m_strDSTXml);
					txtUpTotalDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][6])).m_strDSTXml);
					txtUpPress.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbUpStyptic.Rows[0][7])).m_strDSTXml);
				}
				#endregion

				#region 气压止血肢体位置二
				blnIsDSTArr = new bool[dtbDownStyptic.Columns.Count];
				for(int i=0;i<dtbDownStyptic.Columns.Count;i++)
				{						
					if(i>dtbDownStyptic.Columns.Count-7)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strDownXML,blnIsDSTArr,m_objXmlParser,ref dtgDownStyptic);
				if(dtbUpStyptic.Rows.Count>0)
				{
					chkDownForearm.Checked=(bool)(dtbDownStyptic.Rows[0][0]);
					chkDownThigh.Checked=(bool)(dtbDownStyptic.Rows[0][1]);
					chkDownLeft.Checked = (bool)(dtbDownStyptic.Rows[0][2]);
					chkDownRight.Checked = (bool)(dtbDownStyptic.Rows[0][3]);
					txtDownPuffDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][4])).m_strDSTXml);
					txtDownDeflateDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][5])).m_strDSTXml);
					txtDownTotalDateTime.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][6])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][6])).m_strDSTXml);
					txtDownPress.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbDownStyptic.Rows[0][7])).m_strDSTXml);
				}
				#endregion

				#region 停留Foley氏尿管
				blnIsDSTArr = new bool[dtbFoley.Columns.Count];
				for(int i=0;i<dtbFoley.Columns.Count;i++)
				{						
					if(i>dtbFoley.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFoleyXML,blnIsDSTArr,m_objXmlParser,ref dtgFoley);
				if(dtbFoley.Rows.Count>0)
				{
					chkFoleySickroom.Checked=(bool)(dtbFoley.Rows[0][0]);
					chkFoleyOperationRoom.Checked=(bool)(dtbFoley.Rows[0][1]);
					chkFoleyDoubleAntrum.Checked = (bool)(dtbFoley.Rows[0][2]);
					chkFoleyThreeAntrum.Checked = (bool)(dtbFoley.Rows[0][3]);
					chkFoleyOther.Checked = (bool)(dtbFoley.Rows[0][4]);
					txtFoleyOtherContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbFoley.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbFoley.Rows[0][5])).m_strDSTXml);
				}
				#endregion

				#region 停留胃管
				blnIsDSTArr = new bool[dtbStomach.Columns.Count];
				for(int i=0;i<dtbStomach.Columns.Count;i++)
				{						
					if(i>dtbStomach.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strStomachXML,blnIsDSTArr,m_objXmlParser,ref dtgStomach);
				if(dtbStomach.Rows.Count>0)
				{
					rdbStomachSickroom.Checked=(bool)(dtbStomach.Rows[0][0]);
					rdbStomachOprationRoom.Checked=(bool)(dtbStomach.Rows[0][1]);
				}
				#endregion

				#region 皮肤消毒
				blnIsDSTArr = new bool[dtbSkinAntisepsis.Columns.Count];
				for(int i=0;i<dtbSkinAntisepsis.Columns.Count;i++)
				{						
					if(i>dtbSkinAntisepsis.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSkinAntisepsisXML,blnIsDSTArr,m_objXmlParser,ref dtgSkinAntisepsis);
				if(dtbSkinAntisepsis.Rows.Count>0)
				{
					chkSkinAntisepsis2.Checked=(bool)(dtbSkinAntisepsis.Rows[0][0]);
					chkSkinAntisepsis75.Checked=(bool)(dtbSkinAntisepsis.Rows[0][1]);
					chkSkinAntisepsisIodin.Checked=(bool)(dtbSkinAntisepsis.Rows[0][2]);
					chkSkinAntisepsisIodinRare.Checked=(bool)(dtbSkinAntisepsis.Rows[0][3]);
					chkSkinAntisepsisOther.Checked=(bool)(dtbSkinAntisepsis.Rows[0][4]);
					txtSkinAntisepsisOtherContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbSkinAntisepsis.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbSkinAntisepsis.Rows[0][5])).m_strDSTXml);
				}
				#endregion

				#region 血制品
				blnIsDSTArr = new bool[dtbBlood.Columns.Count];
				for(int i=0;i<dtbBlood.Columns.Count;i++)
				{	
					if(i<(dtbBlood.Columns.Count - 2))
					{
						if((i % 2) != 0)
							blnIsDSTArr[i] = true;
						else
							blnIsDSTArr[i] = false;
					}
					else
						blnIsDSTArr[i] = true;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strBloodXML,blnIsDSTArr,m_objXmlParser,ref dtgBlood);
				if(dtbBlood.Rows.Count>0)
				{
					chkAllBlood.Checked=(bool)(dtbBlood.Rows[0][0]);
					txtAllBloodQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][1])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][1])).m_strDSTXml);
					chkRedCell.Checked=(bool)(dtbBlood.Rows[0][2]);
					txtRedCellQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][3])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][3])).m_strDSTXml);
					chkBloodPlasm.Checked=(bool)(dtbBlood.Rows[0][4]);
					txtBloodPlasmQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][5])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][5])).m_strDSTXml);
					chkOwnBlood.Checked=(bool)(dtbBlood.Rows[0][6]);
					txtOwnBloodQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][7])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][7])).m_strDSTXml);
					chkBloodOther.Checked=(bool)(dtbBlood.Rows[0][8]);
					txtBloodOther.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][9])).m_strText,((clsDSTRichTextBoxValue)(dtbBlood.Rows[0][9])).m_strDSTXml);					
				}
				#endregion

				#region 术前全身皮肤情况
				blnIsDSTArr = new bool[dtbFromHeadToFootSkin.Columns.Count];
				for(int i=0;i<dtbFromHeadToFootSkin.Columns.Count;i++)
				{						
					if(i>dtbFromHeadToFootSkin.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFromHeadToFootSkinXML,blnIsDSTArr,m_objXmlParser,ref dtgFromHeadToFootSkin);
				if(dtbFromHeadToFootSkin.Rows.Count>0)
				{
					rdbFromHeadToFootSkinBeforeOperationFull.Checked=(bool)(dtbFromHeadToFootSkin.Rows[0][0]);
					rdbFromHeadToFootSkinBeforeOperationMar.Checked=(bool)(dtbFromHeadToFootSkin.Rows[0][1]);
					txtFromHeadToFootSkinBeforeOperationContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkin.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkin.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 术后全身皮肤情况
				blnIsDSTArr = new bool[dtbFromHeadToFootSkinAfterOperation.Columns.Count];
				for(int i=0;i<dtbFromHeadToFootSkinAfterOperation.Columns.Count;i++)
				{						
					if(i>dtbFromHeadToFootSkinAfterOperation.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strFromHeadToFootSkinAfterOperationXML,blnIsDSTArr,m_objXmlParser,ref dtgFromHeadToFootSkinAfterOperation);
				if(dtbFromHeadToFootSkinAfterOperation.Rows.Count>0)
				{
					rdbFromHeadToFootSkinAfterOperationFull.Checked=(bool)(dtbFromHeadToFootSkinAfterOperation.Rows[0][0]);
					rdbFromHeadToFootSkinAfterOperationMar.Checked=(bool)(dtbFromHeadToFootSkinAfterOperation.Rows[0][1]);
					txtFromHeadToFootSkinAfterOperationContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkinAfterOperation.Rows[0][2])).m_strText,((clsDSTRichTextBoxValue)(dtbFromHeadToFootSkinAfterOperation.Rows[0][2])).m_strDSTXml);
				}
				#endregion

				#region 标本
				blnIsDSTArr = new bool[dtbSample.Columns.Count];
				for(int i=0;i<dtbSample.Columns.Count;i++)
				{						
					if(i>dtbSample.Columns.Count-4)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strSampleXML,blnIsDSTArr,m_objXmlParser,ref dtgSample);
				if(dtbSample.Rows.Count>0)
				{
					chkSampleGeneral.Checked=(bool)(dtbSample.Rows[0][0]);
					chkSampleSlice.Checked=(bool)(dtbSample.Rows[0][1]);
					chkSampleBacilli.Checked=(bool)(dtbSample.Rows[0][2]);
					chkSampleOther.Checked=(bool)(dtbSample.Rows[0][3]);
					txtSampleOtherContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText( ((clsDSTRichTextBoxValue)(dtbSample.Rows[0][4])).m_strText,((clsDSTRichTextBoxValue)(dtbSample.Rows[0][4])).m_strDSTXml);
				}
				#endregion

				#region 术后送回
				blnIsDSTArr = new bool[dtbAfterOperationSend.Columns.Count];
				for(int i=0;i<dtbAfterOperationSend.Columns.Count;i++)
				{						
					if(i>dtbAfterOperationSend.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strAfterOperationSendXML,blnIsDSTArr,m_objXmlParser,ref dtgAfterOperationSendAfterOperationSend);
				if(dtbAfterOperationSend.Rows.Count>0)
				{
					rdbAfterOperationSendRenew.Checked=(bool)(dtbAfterOperationSend.Rows[0][0]);
					rdbAfterOperationSendICU.Checked=(bool)(dtbAfterOperationSend.Rows[0][1]);
					rdbAfterOperationSendSickRoom.Checked=(bool)(dtbAfterOperationSend.Rows[0][2]);
				}
				#endregion

				#region 输入液体量和术中尿量
				txtInLiquidQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectedOperationRecordContent.strInLiquidQty,m_objSelectedOperationRecord.strInLiquidQtyXML);
				txtPeeOperatingQty.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectedOperationRecordContent.strPeeOperatingQty,m_objSelectedOperationRecord.strPeeOperatingQtyXML);

			#endregion

				//2003.3.6刘荣国修改
				#region 伤口引流物情况
				blnIsDSTArr = new bool[dtbOutFlow.Columns.Count];
				for(int i=0;i<dtbOutFlow.Columns.Count;i++)
				{						
					if(i>dtbOutFlow.Columns.Count-3)
						blnIsDSTArr[i]=true;
					else blnIsDSTArr[i]=false;
				}	
				m_objXML_DataGrid.m_blnSetDataFromXML(m_objSelectedOperationRecord.strOutFlowXML,blnIsDSTArr,m_objXmlParser,ref dtgOutFlow);
				if(dtbOutFlow.Rows.Count>0)
				{
					rdbHaveNotOutflow.Checked=(bool)(dtbOutFlow.Rows[0][0]);
					rdbHaveOutFlow.Checked=(bool)(dtbOutFlow.Rows[0][1]);
				}
				#endregion

			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message + "\r\n" + err.StackTrace);
			}
		}

		#endregion

		#region 显示医生，护士
		
		private void m_mthDisplayOperationOperator(clsEmrSigns_VO[] objSignArr)
		{
            #region 签名集合
            if (objSignArr != null)
            {

                m_mthAddSignToTextBoxBase(new TextBoxBase[] { m_txtSign }, objSignArr, new bool[] { true }, false);
                m_mthAddSignToListView(m_lsvOperationer, objSignArr);
                m_mthAddSignToListView(m_lsvAnaDocSign, objSignArr);
                m_mthAddSignToListView(m_lsvWashNurseSign, objSignArr);
                m_mthAddSignToListView(m_lsvCircuitNurseSign, objSignArr);
                m_mthAddSignToListView(m_lsvRecordNurseSign, objSignArr);
                m_mthAddSignToListView(m_lsvBacilliCheckSign, objSignArr);

                //m_lsvOperationer.Items.Clear();
                //m_lsvAnaDocSign.Items.Clear();
                //m_lsvWashNurseSign.Clear();
                //m_lsvCircuitNurseSign.Clear();
                //m_lsvRecordNurseSign.Clear();
                //m_lsvBacilliCheckSign.Clear();
                //m_txtSign.Tag = null;
                //m_txtSign.Clear();

                //for (int i = 0; i < objSignArr.Length; i++)
                //{
                //    if (objSignArr[i].controlName == "m_lsvOperationer")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvOperationer.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_lsvAnaDocSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvAnaDocSign.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_lsvWashNurseSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvWashNurseSign.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_lsvCircuitNurseSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvCircuitNurseSign.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_lsvBacilliCheckSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvBacilliCheckSign.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_lsvRecordNurseSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objSignArr[i].objEmployee.m_strLASTNAME_VCHR);
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objSignArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag = objSignArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        m_lsvRecordNurseSign.Items.Add(lviNewItem);
                //    }
                //    else if (objSignArr[i].controlName == "m_txtSign")
                //    {
                //        m_txtSign.Text = objSignArr[i].objEmployee.m_strLASTNAME_VCHR;
                //        m_txtSign.Tag = objSignArr[i].objEmployee;
                //    }
                //}
            }
            #endregion		
		}			
		#endregion

		#region 刘荣国增加显示伤口外流物情况

		private void m_mthDisplayWoundThing(string p_strSelectedCreateDate)
		{
			int intRows;
			clsOperationWoundThingInfo[] objWoundThingArr=null;
			long lngRes= objDomain.m_lngGetWoundThing(m_strInPatientID,m_strInPatientDate,p_strSelectedCreateDate,out intRows,out objWoundThingArr );
			if(lngRes<=0)
			{
				return ;
			}
			if(intRows == 0)
				return;
			m_objSelectedWoundThingArr=objWoundThingArr ;

			for(int i = 0; i < intRows; i++)
			{
				Object [] objRows=new object[3];
				for(int j = 0;j < 3;j++)
				{
					objRows[j]="";

				}
				dtbOutFlowThing.Rows.Add(objRows);
			}

			for(int i = 0; i < objWoundThingArr.Length; i++)
			{
				dtbOutFlowThing.Rows[i][0] = objWoundThingArr[i].strWoundThingID;
				dtbOutFlowThing.Rows[i][1] = objWoundThingArr[i].strWoundThingName;
				dtbOutFlowThing.Rows[i][2] = objWoundThingArr[i].strQuantity;
			}
		}

		
		#endregion
		#endregion 

		/// <summary>
		/// 判断用户已经填写完整所有的栏目
		/// </summary>
		/// <returns></returns>
		private bool m_blnCheckUserHasFillAllData()
		{

			#region 检查各个GroupBox是否赋值			

			#region 神志
			if(rdbSencesClear.Checked==false &&rdbSencesSleep.Checked==false && rdbSencesComa.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,神志选项没有选填");
				rdbSencesClear.Focus();
				rdbSencesClear.Checked=true;
				return false;
			}
			#endregion

			#region 药物过敏史
			if(rdbHaveNotAllergic.Checked==false &&rdbHaveAllergic.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,药物过敏史选项没有选填");
				rdbHaveNotAllergic.Focus();
				rdbHaveNotAllergic.Checked=true;
				return false;
			}
			#endregion

			#region 手术体位
			if(rdbOperationLocationOnHisBack.Checked==false &&rdbOperationLocationSide.Checked==false &&rdbOperationLocationPA.Checked==false
				&& rdbOperationLocationParaplegic.Checked==false &&rdbOperationLocationHypothyroid.Checked==false &&rdbOperationLocationOther.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,手术体位选项没有选填");
				rdbOperationLocationOnHisBack.Focus();
				rdbOperationLocationOnHisBack.Checked=true;
				return false;
			}
			#endregion

			#region 使用电刀
			if(rdbHaveNotElectKnife.Checked==false &&rdbHaveUsedElectKnife.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,使用电刀选项没有选填");
				rdbHaveNotElectKnife.Focus();
				rdbHaveNotElectKnife.Checked=true;
				return false;
			}			
			#endregion

			#region 双极电凝
			if(rdbHaveNotDoublePole.Checked==false &&rdbHaveDoublePole.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,双极电凝选项没有选填");
				rdbHaveNotDoublePole.Focus();
				rdbHaveNotDoublePole.Checked=true;
				return false;
			}			
			#endregion			

			#region 术前负极板部位皮肤
			if(rdbCathodeLocationSkinBeforOperationFull.Checked==false &&rdbCathodeLocationSkinBeforOperationMar.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,术前负极板部位皮肤选项没有选填");
				rdbCathodeLocationSkinBeforOperationFull.Focus();
				rdbCathodeLocationSkinBeforOperationFull.Checked=true;
				return false;
			}			
			#endregion	

			#region 术后负极板部位皮肤
			if(rdbCathodeLocationSkinAfterOperationFull.Checked==false &&rdbCathodeLocationSkinAfterOperationMar.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,术后负极板部位皮肤选项没有选填");
				rdbCathodeLocationSkinAfterOperationFull.Focus();
				rdbCathodeLocationSkinAfterOperationFull.Checked=true;
				return false;
			}			
			#endregion			

			#region 止血带
			if(chkStypticRubber.Checked==false &&chkStypticPressure.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,止血带选项没有选填");
				chkStypticRubber.Focus();
				chkStypticRubber.Checked=true;
				return false;
			}			
			#endregion

			#region 气压止血肢体位置一
			if(chkUpForearm.Checked==false &&chkUpThigh.Checked==false  &&chkUpLeft.Checked==false && chkUpRight.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,气压止血肢体位置一选项没有选填");
				chkUpForearm.Focus();
				chkUpForearm.Checked=true;
				return false;
			}			
			#endregion

			#region 停留Foley氏尿管
			if(chkFoleySickroom.Checked==false &&chkFoleyOperationRoom.Checked==false &&chkFoleyDoubleAntrum.Checked==false &&chkFoleyThreeAntrum.Checked==false &&chkFoleyOther.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,停留Foley氏尿管选项没有选填");
				chkFoleySickroom.Focus();
				chkFoleySickroom.Checked=true;
				return false;
			}			
			#endregion			

			#region 停留胃管
			if(rdbStomachSickroom.Checked==false &&rdbStomachOprationRoom.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,停留胃管选项没有选填");
				rdbStomachSickroom.Focus();
				rdbStomachSickroom.Checked=true;
				return false;
			}					
			#endregion

			#region 皮肤消毒
			if(chkSkinAntisepsis2.Checked==false &&chkSkinAntisepsis75.Checked==false &&chkSkinAntisepsisIodin.Checked==false &&chkSkinAntisepsisIodinRare.Checked==false &&chkSkinAntisepsisOther.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,皮肤消毒选项没有选填");
				chkSkinAntisepsis2.Focus();
				chkSkinAntisepsis2.Checked=true;
				return false;
			}
			#endregion			

			#region 血制品
			if(chkAllBlood.Checked==false &&chkRedCell.Checked==false &&chkBloodPlasm.Checked==false  &&chkBloodOther.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,血制品选项没有选填");
				chkAllBlood.Focus();
				chkAllBlood.Checked=true;
				return false;
			}
			#endregion

			#region 伤口引流物情况
			if(rdbHaveNotOutflow.Checked==false &&rdbHaveOutFlow.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,伤口引流物情况选项没有选填");
				rdbHaveNotOutflow.Focus();
				rdbHaveNotOutflow.Checked=true;
				return false;
			}
			#endregion

			#region 术前全身皮肤情况
			if(rdbFromHeadToFootSkinBeforeOperationFull.Checked==false &&rdbFromHeadToFootSkinBeforeOperationMar.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,术前全身皮肤情况选项没有选填");
				rdbFromHeadToFootSkinBeforeOperationFull.Focus();
				rdbFromHeadToFootSkinBeforeOperationFull.Checked=true;
				return false;
			}
			#endregion

			#region 术后全身皮肤情况
			if(rdbFromHeadToFootSkinAfterOperationFull.Checked==false &&rdbFromHeadToFootSkinAfterOperationMar.Checked==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,术后全身皮肤情况选项没有选填");
				rdbFromHeadToFootSkinAfterOperationFull.Focus();
				rdbFromHeadToFootSkinAfterOperationFull.Checked=true;
				return false;
			}
			#endregion

			#region 标本
			if(chkSampleGeneral.Checked==false &&chkSampleSlice.Checked==false &&chkSampleBacilli.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,标本选项没有选填");
				chkSampleGeneral.Focus();
				chkSampleGeneral.Checked=true;
				return false;
			}
			#endregion	

			#region 术后送回
			if(rdbAfterOperationSendRenew.Checked==false &&rdbAfterOperationSendICU.Checked==false  &&rdbAfterOperationSendSickRoom.Checked==false)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,术后送回选项没有选填");
				rdbAfterOperationSendRenew.Focus();
				rdbAfterOperationSendRenew.Checked=true;
				return false;
			}
			#endregion		
		
			#endregion 各个DataGrid和GroupBox的赋值

			return true;
		}

		#region 显示/隐藏历史记录,jacky-2003-4-16
		private void m_cmdShowHistoryRecord_Click(object sender, System.EventArgs e)
		{
			if(m_cmdShowHistoryRecord.Tag==null || m_cmdShowHistoryRecord.Tag.ToString()=="显示历史记录")
				m_mthShowAllDataGrid();
			else// (m_cmdShowHistoryRecord.Tag.ToString()=="隐藏历史记录")
				m_mthHideAllDataGrid();		
		}

		/// <summary>
		/// 隐藏历史记录
		/// </summary>
		private void m_mthHideAllDataGrid()
		{			
			foreach(Control control in this.Controls)
			{										
				if(control.GetType().Name=="DataGrid" && control.Name !="dtgNurse" && control.Name!="dtgOutFlowThing")
				{					
					//control.Location.Y=0;
                    //m_objBorderTool.m_mthUnChangedControlBorder(control );
					control.Visible=false;
				}						
			} 
			
			foreach(Control control in this.Controls)
			{										
				if(control.GetType().Name=="GroupBox" ||control.GetType().Name=="Panel" || control.Name=="lblTendRecord" || control.Name=="txtRecordContent"||control.Name=="m_lblBlank" || control.Name=="dtgNurse" || control.Name!="dtgOutFlowThing")
				{
					control.Location = new System.Drawing.Point(control.Location.X, control.Location.Y -m_intGetGroupBoxVOffset(control));
				}						
			} 
			
			m_cmdShowHistoryRecord.Tag="显示历史记录";
			m_cmdShowHistoryRecord.Text="显示历史记录";

			dtgOutFlowThing.Left = gpbOutFlow.Right + 10;
			dtgOutFlowThing.Top = gpbOutFlow.Top - 40;

			this.Refresh();
		}

		/// <summary>
		/// 显示历史记录
		/// </summary>
		private void m_mthShowAllDataGrid()
		{			
			foreach(Control control in this.Controls)
			{										
				if(control.GetType().Name=="DataGrid" && control.Name !="dtgNurse")
				{
					control.Visible=true;
					//control.Location.Y=0;
                    //m_objBorderTool.m_mthChangedControlBorder(control );
				}						
			} 
		
			foreach(Control control in this.Controls)
			{										
				if(control.GetType().Name=="GroupBox" ||control.GetType().Name=="Panel" || control.Name=="lblTendRecord" || control.Name=="txtRecordContent"||control.Name=="m_lblBlank" || control.Name=="dtgNurse")
				{
					control.Location = new System.Drawing.Point(control.Location.X, control.Location.Y +m_intGetGroupBoxVOffset(control));
				}						
			} 
			
			m_cmdShowHistoryRecord.Tag="隐藏历史记录";
			m_cmdShowHistoryRecord.Text="隐藏历史记录";
			this.Refresh();
		}

		/// <summary>
		/// 得到界面GroupBox的垂直偏移
		/// </summary>
		/// <param name="p_gpbSelectedGroupBox"></param>
		/// <returns></returns>
		private int m_intGetGroupBoxVOffset(Control p_ctlControl)
		{
			int intRows=0;

			#region 各个GroupBox以及异常信息所在位置偏移行数的赋值	
			
			string strControlName=p_ctlControl.Name;
			switch(strControlName)
			{				
				case "m_pnlOperationBefore" : case "gpbSences":	case "gpbAllergic":			
					intRows= 1;
					break;
				
				case "gpbOperationLocation" :				
					intRows= 2;
					break;				
						
				case "pnlPanel2" : case "gpbElectKnife" : case "gpbDoublePole" :
					intRows= 3;
					break;
				
				case "gpbSkinBeforOperation1" :	case "gpbSkinBeforOperation" :	case "gpbStypticRubber" :				
					intRows= 4;
					break;
				
				case "gpbUp" :						
					intRows= 5;			
					break;
				
				case "gpbDown" :
					intRows= 6;
					break;
				
				case "gpbFoley" :
					intRows= 7;
					break;
				
				case "gpbStomach" :
				case "gpbSkinAntisepsis" :
					intRows= 8;
					break;
				
				case "gpbBlood" :
					intRows= 9;
					break;
				
				case "gpbOutFlow" :case "pnlPanel3" :///////
					intRows= 10;
					break;
			
				case "gpbFromHeadToFootSkinBeforeOperatio" :case "gpbFromto2" :
					intRows= 11;
					break;
					
				case "gpbSample" :case "gpbAfterOperationSend" :
					intRows= 12;
					break;
				
				case "lblTendRecord" :case "txtRecordContent" :case "m_lblBlank" : case "dtgNurse":
					intRows= 13;
					break;				
			
				default : intRows= 0;break;		
			}			
			
			#endregion 赋值

			int intVOffset=0;			
			intVOffset=intRows * 100;//界面所有可隐藏的DataGrid高度为100			
			return intVOffset;
		}

		#endregion 显示/隐藏历史记录
				
		

		#region 把模糊查询的结果放在lsvWoundThing中
		
		private void m_objAddListViewItemWoundThingArr(object sender,EventArgs e)
		{
			try
			{
				lsvWoundThing.Items.Clear();
				clsPublicIDAndName[] objWoundThingArr=null;
                
				long lngRes =objDomain.m_lngGetWoundThing(m_objGridListViewWoundThing.strGetCurrentText(),out objWoundThingArr);					

				if(objWoundThingArr == null || objWoundThingArr.Length  <=0)
					return;
				ListViewItem m_lviNewItem;
				for (int i1=0; i1<objWoundThingArr.Length; i1++)
				{
					m_lviNewItem = new ListViewItem(objWoundThingArr[i1].m_strID);
					m_lviNewItem.SubItems.Add(objWoundThingArr[i1].m_strName);
					m_lviNewItem.Tag = objWoundThingArr[i1];
					lsvWoundThing.Items.Add(m_lviNewItem);
				}
			}
			catch{}
		}
		
		
		#endregion
		
		

		#region Readonly 控制
		private void rdbAllergic_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbHaveAllergic.Checked)
//				txtAllergicContent.m_BlnReadOnly = false;
//			if(rdbHaveNotAllergic.Checked)
//				txtAllergicContent.m_BlnReadOnly = true;
		}

		private void rdbOperationLocationOnHisBack_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbOperationLocationOther.Checked)
//				txtOtherOperationLocation.ReadOnly = false;
//			else
//				txtOtherOperationLocation.ReadOnly = true;
		}

		private void rdbHaveNotElectKnife_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbHaveNotElectKnife.Checked)
//				txtElectKnifeModel.ReadOnly = false;
//			if(rdbHaveUsedElectKnife.Checked)
//				txtElectKnifeModel.ReadOnly = true;
		}

		private void DoublePole_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbHaveNotDoublePole.Checked)
//			{
//				txtDoublePoleMode.ReadOnly = false;
//				txtCathodeLocation.ReadOnly = false;
//			}
//			if(rdbHaveDoublePole.Checked)
//			{
//				txtDoublePoleMode.ReadOnly = true;
//				txtCathodeLocation.ReadOnly = true;
//			}
		}

		private void chkStypticPressure_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkStypticPressure.Checked)
//				txtStypticPressureMode.ReadOnly = true;
//			else
//				txtStypticPressureMode.ReadOnly = false;
		}

		private void chkFoleyOther_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkFoleyOther.Checked)
//				txtFoleyOtherContent.ReadOnly = true;
//			else
//				txtFoleyOtherContent.ReadOnly = false;
		}

		private void chkSkinAntisepsisOther_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkSkinAntisepsisOther.Checked)
//				txtSkinAntisepsisOtherContent.ReadOnly = true;
//			else
//				txtSkinAntisepsisOtherContent.ReadOnly = false;
		}

		private void rdbFromHeadToFootSkinBeforeOperationFull_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbFromHeadToFootSkinBeforeOperationFull.Checked)
//				txtFromHeadToFootSkinBeforeOperationContent.ReadOnly = true;
//			if(rdbCathodeLocationSkinBeforOperationMar.Checked)
//				txtFromHeadToFootSkinBeforeOperationContent.ReadOnly = false;
		}

		private void FromHeadToFootSkinAfterOperationFull_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(rdbFromHeadToFootSkinAfterOperationFull.Checked)
//				txtFromHeadToFootSkinAfterOperationContent.ReadOnly = true;
//			if(rdbFromHeadToFootSkinAfterOperationMar.Checked)
//				txtFromHeadToFootSkinAfterOperationContent.ReadOnly = false;
		}

		private void chkAllBlood_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkAllBlood.Checked)
//				txtAllBloodQty.ReadOnly = false;
//			else
//				txtAllBloodQty.ReadOnly = true;
		}

		private void chkRedCell_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkRedCell.Checked)
//				txtRedCellQty.ReadOnly = false;
//			else
//				txtRedCellQty.ReadOnly = true;
		}

		private void chkBloodPlasm_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkBloodPlasm.Checked)
//				txtBloodPlasmQty.ReadOnly = false;
//			else
//				txtBloodPlasmQty.ReadOnly = true;
		}

		private void chkOwnBlood_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkOwnBlood.Checked)
//				txtOwnBloodQty.ReadOnly = false;
//			else
//				txtOwnBloodQty.ReadOnly = true;
		}

		private void chkBloodOther_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkBloodOther.Checked)
//				txtBloodOther.ReadOnly = false;
//			else
//				txtBloodOther.ReadOnly = true;

		}

		private void chkSampleOther_CheckedChanged(object sender, System.EventArgs e)
		{
//			if(chkSampleOther.Checked)
//				txtSampleOtherContent.ReadOnly = false;
//			else
//				txtSampleOtherContent.ReadOnly = true;
		}

		private void dtgSences_CurrentCellChanged(object sender, System.EventArgs e)
		{
//			MessageBox.Show("Test Current change" + dtgSences.CurrentRowIndex.ToString());
			
		}
		#endregion

		#region 伤口外流物
		private ArrayList m_arlWoundThing = new ArrayList();
		private void lsvWoundThing_DoubleClick(object sender, System.EventArgs e)
		{
			if(lsvWoundThing.Items.Count <=0)
				return;
			if(lsvWoundThing.SelectedItems.Count <=0)
				return;

			m_arlWoundThing.Clear();

			for(int i=0;i<dtbOutFlowThing.Rows.Count;i++)
			{
				m_arlWoundThing.Add(dtbOutFlowThing.Rows[i][0]);
			}

			if(m_arlWoundThing.Contains(lsvWoundThing.SelectedItems[0].SubItems[0].Text))
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，该引流物已经选择过了，请重新选择！");
				return;
			}
			m_arlWoundThing.Add(lsvWoundThing.SelectedItems[0].SubItems[0].Text);
			int m_intColumnNumber=dtgOutFlowThing.CurrentCell.ColumnNumber;
			int m_intRowNumber=dtgOutFlowThing.CurrentCell.RowNumber;

			object[] objRow = new object[2];
			objRow[0]=lsvWoundThing.SelectedItems[0].SubItems[0].Text;	
			objRow[1]=lsvWoundThing.SelectedItems[0].SubItems[1].Text;
//			objRow[2]="";
			dtbOutFlowThing.Rows[m_intRowNumber][m_intColumnNumber-1] = objRow[0];   //Name
			dtbOutFlowThing.Rows[m_intRowNumber][m_intColumnNumber] = objRow[1]; //ID
//			dtbOutFlowThing.Rows[m_intRowNumber][m_intColumnNumber+1] = objRow[2]; //Quantity
			this.lblFromHeadToFootSkinAfterOperationContent.Focus();
		}

		private clsOperationWoundThingInfo[] m_objGetOperationThingInfo(string p_strCurrentTime)
		{
			if(p_strCurrentTime == null || p_strCurrentTime =="")
				return null;
			clsOperationWoundThingInfo[] m_objDataInfoArr = new clsOperationWoundThingInfo[dtbOutFlowThing.Rows.Count];
			for(int i1=0;i1<dtbOutFlowThing.Rows.Count;i1++)
			{
				m_objDataInfoArr[i1] = new clsOperationWoundThingInfo();
				m_objDataInfoArr[i1].strWoundThingID = dtbOutFlowThing.Rows[i1][0].ToString();
				m_objDataInfoArr[i1].strQuantity = dtbOutFlowThing.Rows[i1][2].ToString();
				m_objDataInfoArr[i1].strInPatientID = m_strInPatientID;
				m_objDataInfoArr[i1].strInPatientDate = m_strInPatientDate;
				if(dtpRecordTime.Enabled==false && m_objSelectedOperationRecordContent!=null)
					m_objDataInfoArr[i1].strOpenDate = dtpRecordTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
				else
					m_objDataInfoArr[i1].strOpenDate = p_strCurrentTime;

				m_objDataInfoArr[i1].strLastModifyDate = p_strCurrentTime;

				m_objDataInfoArr[i1].strStatus = "0";
			}
			return m_objDataInfoArr;
		}

		#endregion
	
		#region	打印
		#region 在外部测试本打印的演示实例.	
				
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
				}
		
				private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
				{
					objPrintTool.m_mthBeginPrint(e);				
				}
		
				private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
				{
					objPrintTool.m_mthEndPrint(e);
				}
		
				clsOperationRecordPrintTool objPrintTool;
				private void m_mthDemoPrint_FromDataSource()
				{	
					objPrintTool=new clsOperationRecordPrintTool();
					objPrintTool.m_mthInitPrintTool(null);
                    if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                        objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                    else
                    {
                        m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                        if ( m_objSelectedOperationRecord == null || m_objSelectedOperationRecord.strCreateDate == "" || m_objSelectedOperationRecord.strCreateDate == null)
                            objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                        else
                            objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.Parse(m_objSelectedOperationRecord.strCreateDate));
                    }					
					objPrintTool.m_mthInitPrintContent();					
					
					m_mthStartPrint();
				}
				
				private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				private void m_mthStartPrint()
				{				
					if(m_blnDirectPrint)
					{
						m_pdcPrintDocument.Print();
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
		#endregion 在外部测试本打印的演示实例.
		

		
		#endregion

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			m_mthSetDeleteSummaryInfo(m_objSelectedPatient,p_dtmRecordDate.ToString());
		}

		public override int m_IntFormID
		{
			get
			{
				return 31;
			}
		}

		#region 审核
		private string m_strCurrentOpenDate = "";

		private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void gpbDown_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void dtgOutFlowThing_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

		private void gpbAfterOperationSend_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void lblSex_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblDept_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblNameTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblSexTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblBedNoTitle_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tabControl2_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}		
	
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

//				if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
//				{
//					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
//					return "";
//				}
//				return (string)this.trvTime.SelectedNode.Tag;
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
	}

	public enum enmOperationName
	{
		strWashNurse = 0,
		strCircuitNurse = 1,
		strRecordNurse = 2,
		strOperationDt = 3,
		strAnaesthesiaDt = 4,
		strNoBacillusNurse = 5
	}
	public class clsPublicControlPaint
	{
		public clsPublicControlPaint()
		{}

		private int m_intControlWidth=15;
		private int m_intControlHeight=15;
		private Rectangle m_rtgReturnRectangle;

		/// <summary>
		/// 获得所画控件的矩形
		/// </summary>
		/// <param name="p_intX">控件的Ｘ坐标</param>
		/// <param name="p_intY">控件的Ｙ坐标</param>
		/// <returns></returns>
		public Rectangle m_rtgGetControlPaint(int p_intX,int p_intY)
		{
			m_rtgReturnRectangle = new Rectangle(p_intX,p_intY,m_intControlWidth,m_intControlHeight);
			return m_rtgReturnRectangle;
		}		
	}
}

