using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO ;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using iCareData;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;


namespace iCare
{
    /// <summary>
    /// 手 术 记 录 单
    /// </summary>
	public class frmOperationRecordDoctor : iCare.frmHRPBaseForm,PublicFunction 
	{
		#region Windows Generate
        private System.Windows.Forms.TreeView trvTime;
        protected System.Windows.Forms.Label lblTotalAneaMinute;
		protected System.Windows.Forms.Label label6;
		protected System.Windows.Forms.Label lblTotalAneaHour;
		protected System.Windows.Forms.Label label8;
		protected System.Windows.Forms.Label label10;
		private com.digitalwave.controls.ctlRichTextBox txtDiagnoseBeforeOperation;
		protected System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label4;
		private com.digitalwave.controls.ctlRichTextBox txtDiagnoseAfterOperation;
		protected System.Windows.Forms.Label lblTendRecord;
		private com.digitalwave.controls.ctlRichTextBox txtOperationProcess;
		protected System.Windows.Forms.Label label7;
		private com.digitalwave.controls.ctlRichTextBox txtPathology;
		protected System.Windows.Forms.Label label11;
		private com.digitalwave.controls.ctlRichTextBox txtSampleOrExtra;
		protected System.Windows.Forms.Label label12;
		private com.digitalwave.controls.ctlRichTextBox txtSummary;
		private System.Windows.Forms.Label lblUpPuffDateTime;
		public com.digitalwave.controls.ctlRichTextBox txtInLiquid;
        public com.digitalwave.controls.ctlRichTextBox txtOutFlow;
		private System.Windows.Forms.ContextMenu ctmRichTextBoxMenu;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpAneasiaBeginDate;
        private com.digitalwave.Utility.Controls.ctlTimePicker dtpAneasiaEndDate;
		protected System.Windows.Forms.Label m_lblBlank;
        protected System.Windows.Forms.Label label16;
		public com.digitalwave.controls.ctlRichTextBox txtXRayNumber;
		private System.Windows.Forms.CheckedListBox lstOperationID;
		protected System.Windows.Forms.Label label15;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpCreateDate;
		public com.digitalwave.controls.ctlRichTextBox m_txtOperationName;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader clmEmployyID;
        protected System.Windows.Forms.ListView m_lsvOperationDoctor;
		protected System.Windows.Forms.ListView m_lsvAssistant;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
		protected System.Windows.Forms.ListView m_lsvNurse;
		private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox chkAnaesthesia;
		protected System.Windows.Forms.Label label23;
		public com.digitalwave.controls.ctlRichTextBox txtUseDragOnDay;
		public com.digitalwave.controls.ctlRichTextBox txtUseDrugLastNight;
		protected System.Windows.Forms.Label label21;
        public com.digitalwave.controls.ctlRichTextBox txtCategoryDosage;
		private System.ComponentModel.IContainer components = null;
		
		#endregion

		#region Member
		private PinkieControls.ButtonXP m_cmdOperationDoctor;
		private PinkieControls.ButtonXP m_cmdNurse;
		private PinkieControls.ButtonXP m_cmdAssistant;

		private clsEmployeeSignTool m_objSignTool;
		private PinkieControls.ButtonXP m_cmdUseDragOnDay;
		private PinkieControls.ButtonXP m_cmdCategoryDosage;
		private PinkieControls.ButtonXP m_cmdUseDrugLastNight;
		private PinkieControls.ButtonXP m_cmdOutFlow;
        protected System.Windows.Forms.Label label9;
        private PinkieControls.ButtonXP m_cmdDoctor2;
		private PinkieControls.ButtonXP m_cmdAnaesther;
		protected System.Windows.Forms.Label label13;
		protected System.Windows.Forms.Label label14;
		protected System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private PinkieControls.ButtonXP m_cmdPrint;
		protected System.Windows.Forms.Label label19;
		private com.digitalwave.Utility.Controls.ctlPaintContainer m_ctlPaintContainer;
        private clsCommonUseToolCollection m_objCUTC;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpOperationBeginTime;
		protected System.Windows.Forms.Label lblOperationOverTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpOperationOverTime;
		protected System.Windows.Forms.Label lblLeaveRoomTime;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label label2;
		protected System.Windows.Forms.Label lblTotalHour;
		protected System.Windows.Forms.Label lblTotalMinute;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ImageList imageList1;
		private Crownwood.Magic.Controls.TabControl tabControl2;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
        private Crownwood.Magic.Controls.TabPage tabPage6;
        private PinkieControls.ButtonXP m_cmdCompereTitle;
        protected ListView m_lsvDoctor1;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        protected ListView lsvSign;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        protected ListView m_lsvAnaesther;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
		 
		#endregion
        //定义签名类
        private clsEmrSignToolCollection m_objSign;

		#region Constructor
		public frmOperationRecordDoctor()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            #region 新通用绑定签名
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮, 签名框, 医生1or护士2, 身份验证trueorfalse, 员工ID);
            //手术者
            m_objSign.m_mthBindEmployeeSign(m_cmdOperationDoctor, m_lsvOperationDoctor, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //助手
            m_objSign.m_mthBindEmployeeSign(m_cmdAssistant, m_lsvAssistant, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //护士
            m_objSign.m_mthBindEmployeeSign(m_cmdNurse, m_lsvNurse, 2, false, clsEMRLogin.LoginInfo.m_strEmpID);
            //医师签名
            m_objSign.m_mthBindEmployeeSign(m_cmdCompereTitle, m_lsvDoctor1, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);

            //麻醉医师
            m_objSign.m_mthBindEmployeeSign(m_cmdAnaesther, m_lsvAnaesther, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);

            //医师有效签名
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctor2, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            #endregion

			#region White Border
			m_objDomain = new clsOperationRecordDoctorDomain();
            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvAssistant,m_lsvNurse,m_lsvOperationDoctor,m_ctlPaintContainer});													
			
			foreach(Control ctlControl in this.Controls )
			{
				string typeName = ctlControl.GetType().Name;
				if(typeName == "ctlRichTextBox")
				{
                    //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                    //                                    {
                    //                                        ctlControl ,
                    //});

					ctlControl.ContextMenu = ctmRichTextBoxMenu ;
					ctlControl.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

					((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_StrUserID = MDIParent.strOperatorID;
					((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_StrUserName = MDIParent.strOperatorName;
					((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_ClrOldPartInsertText = Color.Black;
					((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_ClrDST = Color.Red;

					m_mthAddRichTextInfo((com.digitalwave.controls.ctlRichTextBox)ctlControl);
				}
                //if(typeName =="TreeView")
                //{
                //    m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlControl ,
                //    });
					
                //}				
                //if(typeName == "DataGrid")
                //{
                //    m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                //                                        {
                //                                            ctlControl ,
                //    });
                //}

				if(typeName =="GroupBox")
				{
					foreach(Control ctlGrp in ctlControl.Controls )
					{
						typeName=ctlGrp.GetType().Name ;
						if(typeName =="ctlRichTextBox")
						{
                            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
                            //                                            {
                            //                                                ctlGrp ,
                            //});

							ctlGrp.ContextMenu=ctmRichTextBoxMenu ;
							ctlGrp.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

							((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_StrUserID = MDIParent.strOperatorID;
							((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_StrUserName = MDIParent.strOperatorName;
							((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_ClrOldPartInsertText = Color.Black;
							((com.digitalwave.controls.ctlRichTextBox)ctlGrp).m_ClrDST = Color.Red;

							m_mthAddRichTextInfo((com.digitalwave.controls.ctlRichTextBox)ctlGrp);
						}
					}
				}
			}
			#endregion



			m_mthSetQuickKeys();

			m_mthSetRichTextBoxAttribInControl(this);

			m_objPublicDomain = new clsPublicDomain();

			//签名常用值
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{m_cmdOperationDoctor,m_cmdAssistant,this.m_cmdEmployeeSign,this.m_cmdCompereTitle,this.m_cmdDoctor2},
            //    new Control[]{m_lsvOperationDoctor,m_lsvAssistant,this.m_txtSign,this.m_lsvDoctor1,this.m_txtDoctor2},new int[]{1,1,1,1,1});
            //m_objCUTC.m_mthBindEmployeeSign(m_cmdNurse,m_lsvNurse,2);

            //m_objCUTC.m_mthBindControl(new Control[]{m_cmdUseDragOnDay,m_cmdUseDrugLastNight,m_cmdCategoryDosage,m_cmdOutFlow},
            //    new Control[]{txtUseDragOnDay,txtUseDrugLastNight,txtCategoryDosage,txtOutFlow},
            //    new enmCommonUseValue[]{enmCommonUseValue.frmOperationRecordDoctor_UseDragOnDay,enmCommonUseValue.frmOperationRecordDoctor_UseDrugLastNight,
            //    enmCommonUseValue.frmOperationRecordDoctor_CategoryDosage,enmCommonUseValue.frmOperationRecordDoctor_OutFlow});

            //m_objSignTool.m_mthAddListViewDeleteMenu(new ListView[]{m_lsvOperationDoctor,m_lsvAssistant,m_lsvNurse});

 
		 
		}
		private clsPublicDomain m_objPublicDomain;
		#endregion

		#region Member
        //private clsBorderTool  m_objBorderTool;

	

		private bool m_blnCanSearch=true;

		private clsOperationRecordDoctorDomain m_objDomain;

		private clsPatient m_objSelectedPatient; //保存当前选择的病人

		private string m_strInPatientID = "";    

		private string m_strInPatientDate = "";  

		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox = null;

		private string m_strOpenDate = "";    

		private clsOperationRecordDoctor m_objSelectOperationRecord;//保存选择的纪录的XML  

		private clsOperationRecordContentDoctor m_objSelectOperationRecordContent; //保存选择的纪录的内容

		#endregion

		#region Dispose
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperationRecordDoctor));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.chkAnaesthesia = new System.Windows.Forms.CheckBox();
            this.lblTotalAneaMinute = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalAneaHour = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpAneasiaBeginDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.dtpAneasiaEndDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.txtDiagnoseBeforeOperation = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiagnoseAfterOperation = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTendRecord = new System.Windows.Forms.Label();
            this.txtOperationProcess = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPathology = new com.digitalwave.controls.ctlRichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSampleOrExtra = new com.digitalwave.controls.ctlRichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSummary = new com.digitalwave.controls.ctlRichTextBox();
            this.lblUpPuffDateTime = new System.Windows.Forms.Label();
            this.txtInLiquid = new com.digitalwave.controls.ctlRichTextBox();
            this.txtOutFlow = new com.digitalwave.controls.ctlRichTextBox();
            this.ctmRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.m_lblBlank = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtXRayNumber = new com.digitalwave.controls.ctlRichTextBox();
            this.lstOperationID = new System.Windows.Forms.CheckedListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtOperationName = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lsvOperationDoctor = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.clmEmployyID = new System.Windows.Forms.ColumnHeader();
            this.m_lsvAssistant = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_lsvNurse = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label23 = new System.Windows.Forms.Label();
            this.txtUseDragOnDay = new com.digitalwave.controls.ctlRichTextBox();
            this.txtUseDrugLastNight = new com.digitalwave.controls.ctlRichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCategoryDosage = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOperationDoctor = new PinkieControls.ButtonXP();
            this.m_cmdNurse = new PinkieControls.ButtonXP();
            this.m_cmdAssistant = new PinkieControls.ButtonXP();
            this.m_cmdUseDragOnDay = new PinkieControls.ButtonXP();
            this.m_cmdCategoryDosage = new PinkieControls.ButtonXP();
            this.m_cmdUseDrugLastNight = new PinkieControls.ButtonXP();
            this.m_cmdOutFlow = new PinkieControls.ButtonXP();
            this.label9 = new System.Windows.Forms.Label();
            this.m_cmdDoctor2 = new PinkieControls.ButtonXP();
            this.m_cmdAnaesther = new PinkieControls.ButtonXP();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.label19 = new System.Windows.Forms.Label();
            this.m_ctlPaintContainer = new com.digitalwave.Utility.Controls.ctlPaintContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_lsvAnaesther = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lsvDoctor1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.dtpOperationBeginTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblOperationOverTime = new System.Windows.Forms.Label();
            this.dtpOperationOverTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblLeaveRoomTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalHour = new System.Windows.Forms.Label();
            this.lblTotalMinute = new System.Windows.Forms.Label();
            this.m_cmdCompereTitle = new PinkieControls.ButtonXP();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl2 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(264, 157);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(215, 171);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(243, 159);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(260, 157);
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(287, 147);
            this.lblNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblNameTitle.Text = "姓 名:";
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(243, 154);
            this.lblSexTitle.Size = new System.Drawing.Size(49, 14);
            this.lblSexTitle.Text = "性 别:";
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(227, 161);
            this.lblAgeTitle.Size = new System.Drawing.Size(49, 14);
            this.lblAgeTitle.Text = "年 龄:";
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(239, 164);
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(222, 146);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(242, 155);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(622, 101);
            this.m_txtPatientName.Size = new System.Drawing.Size(92, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(254, 161);
            this.m_txtBedNO.Size = new System.Drawing.Size(92, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(222, 167);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(230, 145);
            this.m_lsvPatientName.Size = new System.Drawing.Size(92, 105);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(230, 118);
            this.m_lsvBedNO.Size = new System.Drawing.Size(112, 105);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(230, 164);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(239, 150);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(254, 150);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 33);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(302, 164);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 22);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(246, 146);
            this.m_cmdPre.Size = new System.Drawing.Size(24, 22);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(254, 171);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 24);
            this.m_lblForTitle.Text = "手 术 记 录 单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(387, 197);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(721, 34);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.lsvSign);
            this.m_pnlNewBase.Controls.Add(this.m_cmdDoctor2);
            this.m_pnlNewBase.Location = new System.Drawing.Point(3, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(795, 90);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_cmdDoctor2, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lsvSign, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(191, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(607, 60);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(4, 34);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(189, 61);
            this.trvTime.TabIndex = 100;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // chkAnaesthesia
            // 
            this.chkAnaesthesia.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAnaesthesia.ForeColor = System.Drawing.Color.Black;
            this.chkAnaesthesia.Location = new System.Drawing.Point(320, 140);
            this.chkAnaesthesia.Name = "chkAnaesthesia";
            this.chkAnaesthesia.Size = new System.Drawing.Size(64, 27);
            this.chkAnaesthesia.TabIndex = 535;
            this.chkAnaesthesia.Text = "全麻";
            this.chkAnaesthesia.CheckedChanged += new System.EventHandler(this.chkAnaesthesia_CheckedChanged);
            // 
            // lblTotalAneaMinute
            // 
            this.lblTotalAneaMinute.Location = new System.Drawing.Point(115, 150);
            this.lblTotalAneaMinute.Name = "lblTotalAneaMinute";
            this.lblTotalAneaMinute.Size = new System.Drawing.Size(100, 23);
            this.lblTotalAneaMinute.TabIndex = 1000000005;
            this.lblTotalAneaMinute.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(644, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 523;
            this.label6.Text = "时";
            // 
            // lblTotalAneaHour
            // 
            this.lblTotalAneaHour.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalAneaHour.Location = new System.Drawing.Point(618, 112);
            this.lblTotalAneaHour.Name = "lblTotalAneaHour";
            this.lblTotalAneaHour.Size = new System.Drawing.Size(20, 16);
            this.lblTotalAneaHour.TabIndex = 522;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(592, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 521;
            this.label8.Text = "共";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(16, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 14);
            this.label10.TabIndex = 519;
            this.label10.Text = "麻醉开始时间:";
            // 
            // dtpAneasiaBeginDate
            // 
            this.dtpAneasiaBeginDate.BorderColor = System.Drawing.Color.Black;
            this.dtpAneasiaBeginDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpAneasiaBeginDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpAneasiaBeginDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpAneasiaBeginDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaBeginDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpAneasiaBeginDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpAneasiaBeginDate.ForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAneasiaBeginDate.Location = new System.Drawing.Point(116, 112);
            this.dtpAneasiaBeginDate.m_BlnOnlyTime = false;
            this.dtpAneasiaBeginDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpAneasiaBeginDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAneasiaBeginDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAneasiaBeginDate.Name = "dtpAneasiaBeginDate";
            this.dtpAneasiaBeginDate.ReadOnly = false;
            this.dtpAneasiaBeginDate.Size = new System.Drawing.Size(188, 22);
            this.dtpAneasiaBeginDate.TabIndex = 530;
            this.dtpAneasiaBeginDate.TextBackColor = System.Drawing.Color.White;
            this.dtpAneasiaBeginDate.TextForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaBeginDate.evtValueChanged += new System.EventHandler(this.dtpAneasiaBeginDate_evtValueChanged);
            // 
            // dtpAneasiaEndDate
            // 
            this.dtpAneasiaEndDate.BorderColor = System.Drawing.Color.Black;
            this.dtpAneasiaEndDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpAneasiaEndDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpAneasiaEndDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpAneasiaEndDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaEndDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpAneasiaEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpAneasiaEndDate.ForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAneasiaEndDate.Location = new System.Drawing.Point(396, 112);
            this.dtpAneasiaEndDate.m_BlnOnlyTime = false;
            this.dtpAneasiaEndDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpAneasiaEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAneasiaEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAneasiaEndDate.Name = "dtpAneasiaEndDate";
            this.dtpAneasiaEndDate.ReadOnly = false;
            this.dtpAneasiaEndDate.Size = new System.Drawing.Size(188, 22);
            this.dtpAneasiaEndDate.TabIndex = 531;
            this.dtpAneasiaEndDate.TextBackColor = System.Drawing.Color.White;
            this.dtpAneasiaEndDate.TextForeColor = System.Drawing.Color.Black;
            this.dtpAneasiaEndDate.evtValueChanged += new System.EventHandler(this.dtpAneasiaEndDate_evtValueChanged);
            // 
            // txtDiagnoseBeforeOperation
            // 
            this.txtDiagnoseBeforeOperation.AccessibleDescription = "术前诊断";
            this.txtDiagnoseBeforeOperation.BackColor = System.Drawing.Color.White;
            this.txtDiagnoseBeforeOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnoseBeforeOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDiagnoseBeforeOperation.ForeColor = System.Drawing.Color.Black;
            this.txtDiagnoseBeforeOperation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagnoseBeforeOperation.Location = new System.Drawing.Point(78, 36);
            this.txtDiagnoseBeforeOperation.m_BlnIgnoreUserInfo = false;
            this.txtDiagnoseBeforeOperation.m_BlnPartControl = false;
            this.txtDiagnoseBeforeOperation.m_BlnReadOnly = false;
            this.txtDiagnoseBeforeOperation.m_BlnUnderLineDST = false;
            this.txtDiagnoseBeforeOperation.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagnoseBeforeOperation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagnoseBeforeOperation.m_IntCanModifyTime = 6;
            this.txtDiagnoseBeforeOperation.m_IntPartControlLength = 0;
            this.txtDiagnoseBeforeOperation.m_IntPartControlStartIndex = 0;
            this.txtDiagnoseBeforeOperation.m_StrUserID = "";
            this.txtDiagnoseBeforeOperation.m_StrUserName = "";
            this.txtDiagnoseBeforeOperation.Name = "txtDiagnoseBeforeOperation";
            this.txtDiagnoseBeforeOperation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDiagnoseBeforeOperation.Size = new System.Drawing.Size(282, 72);
            this.txtDiagnoseBeforeOperation.TabIndex = 130;
            this.txtDiagnoseBeforeOperation.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 1292;
            this.label3.Text = "术前诊断:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(394, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1293;
            this.label4.Text = "术后诊断:";
            // 
            // txtDiagnoseAfterOperation
            // 
            this.txtDiagnoseAfterOperation.AccessibleDescription = "术后诊断";
            this.txtDiagnoseAfterOperation.BackColor = System.Drawing.Color.White;
            this.txtDiagnoseAfterOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnoseAfterOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDiagnoseAfterOperation.ForeColor = System.Drawing.Color.Black;
            this.txtDiagnoseAfterOperation.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagnoseAfterOperation.Location = new System.Drawing.Point(466, 38);
            this.txtDiagnoseAfterOperation.m_BlnIgnoreUserInfo = false;
            this.txtDiagnoseAfterOperation.m_BlnPartControl = false;
            this.txtDiagnoseAfterOperation.m_BlnReadOnly = false;
            this.txtDiagnoseAfterOperation.m_BlnUnderLineDST = false;
            this.txtDiagnoseAfterOperation.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagnoseAfterOperation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagnoseAfterOperation.m_IntCanModifyTime = 6;
            this.txtDiagnoseAfterOperation.m_IntPartControlLength = 0;
            this.txtDiagnoseAfterOperation.m_IntPartControlStartIndex = 0;
            this.txtDiagnoseAfterOperation.m_StrUserID = "";
            this.txtDiagnoseAfterOperation.m_StrUserName = "";
            this.txtDiagnoseAfterOperation.Name = "txtDiagnoseAfterOperation";
            this.txtDiagnoseAfterOperation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtDiagnoseAfterOperation.Size = new System.Drawing.Size(261, 72);
            this.txtDiagnoseAfterOperation.TabIndex = 140;
            this.txtDiagnoseAfterOperation.Text = "";
            // 
            // lblTendRecord
            // 
            this.lblTendRecord.AutoSize = true;
            this.lblTendRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTendRecord.ForeColor = System.Drawing.Color.Black;
            this.lblTendRecord.Location = new System.Drawing.Point(12, 8);
            this.lblTendRecord.Name = "lblTendRecord";
            this.lblTendRecord.Size = new System.Drawing.Size(70, 14);
            this.lblTendRecord.TabIndex = 1295;
            this.lblTendRecord.Text = "手术经过:";
            // 
            // txtOperationProcess
            // 
            this.txtOperationProcess.AccessibleDescription = "手术经过";
            this.txtOperationProcess.BackColor = System.Drawing.Color.White;
            this.txtOperationProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOperationProcess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperationProcess.ForeColor = System.Drawing.Color.Black;
            this.txtOperationProcess.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOperationProcess.Location = new System.Drawing.Point(12, 30);
            this.txtOperationProcess.m_BlnIgnoreUserInfo = false;
            this.txtOperationProcess.m_BlnPartControl = false;
            this.txtOperationProcess.m_BlnReadOnly = false;
            this.txtOperationProcess.m_BlnUnderLineDST = false;
            this.txtOperationProcess.m_ClrDST = System.Drawing.Color.Red;
            this.txtOperationProcess.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOperationProcess.m_IntCanModifyTime = 6;
            this.txtOperationProcess.m_IntPartControlLength = 0;
            this.txtOperationProcess.m_IntPartControlStartIndex = 0;
            this.txtOperationProcess.m_StrUserID = "";
            this.txtOperationProcess.m_StrUserName = "";
            this.txtOperationProcess.Name = "txtOperationProcess";
            this.txtOperationProcess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOperationProcess.Size = new System.Drawing.Size(762, 112);
            this.txtOperationProcess.TabIndex = 540;
            this.txtOperationProcess.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 1297;
            this.label7.Text = "病理所见:";
            // 
            // txtPathology
            // 
            this.txtPathology.AccessibleDescription = "病理所见";
            this.txtPathology.BackColor = System.Drawing.Color.White;
            this.txtPathology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathology.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPathology.ForeColor = System.Drawing.Color.Black;
            this.txtPathology.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPathology.Location = new System.Drawing.Point(12, 168);
            this.txtPathology.m_BlnIgnoreUserInfo = false;
            this.txtPathology.m_BlnPartControl = false;
            this.txtPathology.m_BlnReadOnly = false;
            this.txtPathology.m_BlnUnderLineDST = false;
            this.txtPathology.m_ClrDST = System.Drawing.Color.Red;
            this.txtPathology.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtPathology.m_IntCanModifyTime = 6;
            this.txtPathology.m_IntPartControlLength = 0;
            this.txtPathology.m_IntPartControlStartIndex = 0;
            this.txtPathology.m_StrUserID = "";
            this.txtPathology.m_StrUserName = "";
            this.txtPathology.MaxLength = 2000;
            this.txtPathology.Name = "txtPathology";
            this.txtPathology.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtPathology.Size = new System.Drawing.Size(762, 64);
            this.txtPathology.TabIndex = 550;
            this.txtPathology.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 14);
            this.label11.TabIndex = 1299;
            this.label11.Text = "标本肉眼所见或特殊记录:";
            // 
            // txtSampleOrExtra
            // 
            this.txtSampleOrExtra.AccessibleDescription = "标本肉眼所见或特殊记录";
            this.txtSampleOrExtra.BackColor = System.Drawing.Color.White;
            this.txtSampleOrExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSampleOrExtra.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSampleOrExtra.ForeColor = System.Drawing.Color.Black;
            this.txtSampleOrExtra.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSampleOrExtra.Location = new System.Drawing.Point(16, 84);
            this.txtSampleOrExtra.m_BlnIgnoreUserInfo = false;
            this.txtSampleOrExtra.m_BlnPartControl = false;
            this.txtSampleOrExtra.m_BlnReadOnly = false;
            this.txtSampleOrExtra.m_BlnUnderLineDST = false;
            this.txtSampleOrExtra.m_ClrDST = System.Drawing.Color.Red;
            this.txtSampleOrExtra.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSampleOrExtra.m_IntCanModifyTime = 6;
            this.txtSampleOrExtra.m_IntPartControlLength = 0;
            this.txtSampleOrExtra.m_IntPartControlStartIndex = 0;
            this.txtSampleOrExtra.m_StrUserID = "";
            this.txtSampleOrExtra.m_StrUserName = "";
            this.txtSampleOrExtra.MaxLength = 2000;
            this.txtSampleOrExtra.Name = "txtSampleOrExtra";
            this.txtSampleOrExtra.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtSampleOrExtra.Size = new System.Drawing.Size(720, 188);
            this.txtSampleOrExtra.TabIndex = 580;
            this.txtSampleOrExtra.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(16, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 14);
            this.label12.TabIndex = 1301;
            this.label12.Text = "术后总结与讲评意见:";
            // 
            // txtSummary
            // 
            this.txtSummary.AccessibleDescription = "术后总结与讲评意见";
            this.txtSummary.BackColor = System.Drawing.Color.White;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSummary.ForeColor = System.Drawing.Color.White;
            this.txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSummary.Location = new System.Drawing.Point(16, 296);
            this.txtSummary.m_BlnIgnoreUserInfo = false;
            this.txtSummary.m_BlnPartControl = false;
            this.txtSummary.m_BlnReadOnly = false;
            this.txtSummary.m_BlnUnderLineDST = false;
            this.txtSummary.m_ClrDST = System.Drawing.Color.Red;
            this.txtSummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtSummary.m_IntCanModifyTime = 6;
            this.txtSummary.m_IntPartControlLength = 0;
            this.txtSummary.m_IntPartControlStartIndex = 0;
            this.txtSummary.m_StrUserID = "";
            this.txtSummary.m_StrUserName = "";
            this.txtSummary.MaxLength = 2000;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtSummary.Size = new System.Drawing.Size(720, 180);
            this.txtSummary.TabIndex = 590;
            this.txtSummary.Text = "";
            // 
            // lblUpPuffDateTime
            // 
            this.lblUpPuffDateTime.AutoSize = true;
            this.lblUpPuffDateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpPuffDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblUpPuffDateTime.Location = new System.Drawing.Point(20, 16);
            this.lblUpPuffDateTime.Name = "lblUpPuffDateTime";
            this.lblUpPuffDateTime.Size = new System.Drawing.Size(154, 14);
            this.lblUpPuffDateTime.TabIndex = 1303;
            this.lblUpPuffDateTime.Text = "手术期间输液（输血）:";
            // 
            // txtInLiquid
            // 
            this.txtInLiquid.BackColor = System.Drawing.Color.White;
            this.txtInLiquid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInLiquid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInLiquid.ForeColor = System.Drawing.Color.Black;
            this.txtInLiquid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtInLiquid.Location = new System.Drawing.Point(176, 12);
            this.txtInLiquid.m_BlnIgnoreUserInfo = false;
            this.txtInLiquid.m_BlnPartControl = false;
            this.txtInLiquid.m_BlnReadOnly = false;
            this.txtInLiquid.m_BlnUnderLineDST = false;
            this.txtInLiquid.m_ClrDST = System.Drawing.Color.Red;
            this.txtInLiquid.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtInLiquid.m_IntCanModifyTime = 6;
            this.txtInLiquid.m_IntPartControlLength = 0;
            this.txtInLiquid.m_IntPartControlStartIndex = 0;
            this.txtInLiquid.m_StrUserID = "";
            this.txtInLiquid.m_StrUserName = "";
            this.txtInLiquid.Multiline = false;
            this.txtInLiquid.Name = "txtInLiquid";
            this.txtInLiquid.Size = new System.Drawing.Size(560, 21);
            this.txtInLiquid.TabIndex = 560;
            this.txtInLiquid.Text = "";
            // 
            // txtOutFlow
            // 
            this.txtOutFlow.AccessibleDescription = "引流物或填充物";
            this.txtOutFlow.BackColor = System.Drawing.Color.White;
            this.txtOutFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutFlow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutFlow.ForeColor = System.Drawing.Color.Black;
            this.txtOutFlow.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOutFlow.Location = new System.Drawing.Point(176, 36);
            this.txtOutFlow.m_BlnIgnoreUserInfo = false;
            this.txtOutFlow.m_BlnPartControl = false;
            this.txtOutFlow.m_BlnReadOnly = false;
            this.txtOutFlow.m_BlnUnderLineDST = false;
            this.txtOutFlow.m_ClrDST = System.Drawing.Color.Red;
            this.txtOutFlow.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOutFlow.m_IntCanModifyTime = 6;
            this.txtOutFlow.m_IntPartControlLength = 0;
            this.txtOutFlow.m_IntPartControlStartIndex = 0;
            this.txtOutFlow.m_StrUserID = "";
            this.txtOutFlow.m_StrUserName = "";
            this.txtOutFlow.Multiline = false;
            this.txtOutFlow.Name = "txtOutFlow";
            this.txtOutFlow.Size = new System.Drawing.Size(560, 21);
            this.txtOutFlow.TabIndex = 570;
            this.txtOutFlow.Text = "";
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
            // m_lblBlank
            // 
            this.m_lblBlank.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBlank.ForeColor = System.Drawing.Color.Black;
            this.m_lblBlank.Location = new System.Drawing.Point(260, 624);
            this.m_lblBlank.Name = "m_lblBlank";
            this.m_lblBlank.Size = new System.Drawing.Size(52, 16);
            this.m_lblBlank.TabIndex = 630;
            this.m_lblBlank.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(394, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 30009;
            this.label16.Text = "X 光 号 :";
            // 
            // txtXRayNumber
            // 
            this.txtXRayNumber.AccessibleDescription = "X光号";
            this.txtXRayNumber.BackColor = System.Drawing.Color.White;
            this.txtXRayNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXRayNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXRayNumber.ForeColor = System.Drawing.Color.Black;
            this.txtXRayNumber.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtXRayNumber.Location = new System.Drawing.Point(466, 10);
            this.txtXRayNumber.m_BlnIgnoreUserInfo = false;
            this.txtXRayNumber.m_BlnPartControl = false;
            this.txtXRayNumber.m_BlnReadOnly = false;
            this.txtXRayNumber.m_BlnUnderLineDST = false;
            this.txtXRayNumber.m_ClrDST = System.Drawing.Color.Red;
            this.txtXRayNumber.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtXRayNumber.m_IntCanModifyTime = 6;
            this.txtXRayNumber.m_IntPartControlLength = 0;
            this.txtXRayNumber.m_IntPartControlStartIndex = 0;
            this.txtXRayNumber.m_StrUserID = "";
            this.txtXRayNumber.m_StrUserName = "";
            this.txtXRayNumber.Multiline = false;
            this.txtXRayNumber.Name = "txtXRayNumber";
            this.txtXRayNumber.Size = new System.Drawing.Size(261, 24);
            this.txtXRayNumber.TabIndex = 120;
            this.txtXRayNumber.Text = "";
            // 
            // lstOperationID
            // 
            this.lstOperationID.BackColor = System.Drawing.Color.White;
            this.lstOperationID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstOperationID.CheckOnClick = true;
            this.lstOperationID.ForeColor = System.Drawing.Color.Black;
            this.lstOperationID.HorizontalScrollbar = true;
            this.lstOperationID.Location = new System.Drawing.Point(369, 64);
            this.lstOperationID.Name = "lstOperationID";
            this.lstOperationID.Size = new System.Drawing.Size(132, 16);
            this.lstOperationID.TabIndex = 504;
            this.lstOperationID.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(2, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 30010;
            this.label15.Text = "记录时间:";
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpCreateDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDate.Location = new System.Drawing.Point(78, 4);
            this.dtpCreateDate.m_BlnOnlyTime = false;
            this.dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.ReadOnly = false;
            this.dtpCreateDate.Size = new System.Drawing.Size(192, 22);
            this.dtpCreateDate.TabIndex = 110;
            this.dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            this.dtpCreateDate.evtValueChanged += new System.EventHandler(this.dtpCreateDate_evtValueChanged);
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "手术名称";
            this.m_txtOperationName.BackColor = System.Drawing.Color.White;
            this.m_txtOperationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOperationName.Location = new System.Drawing.Point(96, 8);
            this.m_txtOperationName.m_BlnIgnoreUserInfo = false;
            this.m_txtOperationName.m_BlnPartControl = false;
            this.m_txtOperationName.m_BlnReadOnly = false;
            this.m_txtOperationName.m_BlnUnderLineDST = false;
            this.m_txtOperationName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOperationName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOperationName.m_IntCanModifyTime = 6;
            this.m_txtOperationName.m_IntPartControlLength = 0;
            this.m_txtOperationName.m_IntPartControlStartIndex = 0;
            this.m_txtOperationName.m_StrUserID = "";
            this.m_txtOperationName.m_StrUserName = "";
            this.m_txtOperationName.Multiline = false;
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.Size = new System.Drawing.Size(636, 24);
            this.m_txtOperationName.TabIndex = 150;
            this.m_txtOperationName.Text = "";
            // 
            // m_lsvOperationDoctor
            // 
            this.m_lsvOperationDoctor.BackColor = System.Drawing.Color.White;
            this.m_lsvOperationDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.clmEmployyID});
            this.m_lsvOperationDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvOperationDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_lsvOperationDoctor.FullRowSelect = true;
            this.m_lsvOperationDoctor.GridLines = true;
            this.m_lsvOperationDoctor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvOperationDoctor.Location = new System.Drawing.Point(96, 44);
            this.m_lsvOperationDoctor.Name = "m_lsvOperationDoctor";
            this.m_lsvOperationDoctor.Size = new System.Drawing.Size(264, 24);
            this.m_lsvOperationDoctor.TabIndex = 180;
            this.m_lsvOperationDoctor.UseCompatibleStateImageBehavior = false;
            this.m_lsvOperationDoctor.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 70;
            // 
            // clmEmployyID
            // 
            this.clmEmployyID.Width = 0;
            // 
            // m_lsvAssistant
            // 
            this.m_lsvAssistant.BackColor = System.Drawing.Color.White;
            this.m_lsvAssistant.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvAssistant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAssistant.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAssistant.FullRowSelect = true;
            this.m_lsvAssistant.GridLines = true;
            this.m_lsvAssistant.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAssistant.Location = new System.Drawing.Point(468, 44);
            this.m_lsvAssistant.Name = "m_lsvAssistant";
            this.m_lsvAssistant.Size = new System.Drawing.Size(264, 24);
            this.m_lsvAssistant.TabIndex = 210;
            this.m_lsvAssistant.UseCompatibleStateImageBehavior = false;
            this.m_lsvAssistant.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // m_lsvNurse
            // 
            this.m_lsvNurse.BackColor = System.Drawing.Color.White;
            this.m_lsvNurse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.m_lsvNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvNurse.ForeColor = System.Drawing.Color.Black;
            this.m_lsvNurse.FullRowSelect = true;
            this.m_lsvNurse.GridLines = true;
            this.m_lsvNurse.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvNurse.Location = new System.Drawing.Point(96, 80);
            this.m_lsvNurse.Name = "m_lsvNurse";
            this.m_lsvNurse.Size = new System.Drawing.Size(264, 24);
            this.m_lsvNurse.TabIndex = 240;
            this.m_lsvNurse.UseCompatibleStateImageBehavior = false;
            this.m_lsvNurse.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(320, 116);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(70, 14);
            this.label23.TabIndex = 10000018;
            this.label23.Text = "完毕时间:";
            // 
            // txtUseDragOnDay
            // 
            this.txtUseDragOnDay.BackColor = System.Drawing.Color.White;
            this.txtUseDragOnDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUseDragOnDay.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtUseDragOnDay.ForeColor = System.Drawing.Color.Black;
            this.txtUseDragOnDay.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUseDragOnDay.Location = new System.Drawing.Point(208, 44);
            this.txtUseDragOnDay.m_BlnIgnoreUserInfo = false;
            this.txtUseDragOnDay.m_BlnPartControl = false;
            this.txtUseDragOnDay.m_BlnReadOnly = false;
            this.txtUseDragOnDay.m_BlnUnderLineDST = false;
            this.txtUseDragOnDay.m_ClrDST = System.Drawing.Color.Red;
            this.txtUseDragOnDay.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUseDragOnDay.m_IntCanModifyTime = 6;
            this.txtUseDragOnDay.m_IntPartControlLength = 0;
            this.txtUseDragOnDay.m_IntPartControlStartIndex = 0;
            this.txtUseDragOnDay.m_StrUserID = "";
            this.txtUseDragOnDay.m_StrUserName = "";
            this.txtUseDragOnDay.Multiline = false;
            this.txtUseDragOnDay.Name = "txtUseDragOnDay";
            this.txtUseDragOnDay.Size = new System.Drawing.Size(520, 21);
            this.txtUseDragOnDay.TabIndex = 300;
            this.txtUseDragOnDay.Text = "";
            // 
            // txtUseDrugLastNight
            // 
            this.txtUseDrugLastNight.BackColor = System.Drawing.Color.White;
            this.txtUseDrugLastNight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUseDrugLastNight.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtUseDrugLastNight.ForeColor = System.Drawing.Color.Black;
            this.txtUseDrugLastNight.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUseDrugLastNight.Location = new System.Drawing.Point(208, 8);
            this.txtUseDrugLastNight.m_BlnIgnoreUserInfo = false;
            this.txtUseDrugLastNight.m_BlnPartControl = false;
            this.txtUseDrugLastNight.m_BlnReadOnly = false;
            this.txtUseDrugLastNight.m_BlnUnderLineDST = false;
            this.txtUseDrugLastNight.m_ClrDST = System.Drawing.Color.Red;
            this.txtUseDrugLastNight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtUseDrugLastNight.m_IntCanModifyTime = 6;
            this.txtUseDrugLastNight.m_IntPartControlLength = 0;
            this.txtUseDrugLastNight.m_IntPartControlStartIndex = 0;
            this.txtUseDrugLastNight.m_StrUserID = "";
            this.txtUseDrugLastNight.m_StrUserName = "";
            this.txtUseDrugLastNight.Multiline = false;
            this.txtUseDrugLastNight.Name = "txtUseDrugLastNight";
            this.txtUseDrugLastNight.Size = new System.Drawing.Size(520, 21);
            this.txtUseDrugLastNight.TabIndex = 280;
            this.txtUseDrugLastNight.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(16, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 14);
            this.label21.TabIndex = 10000020;
            this.label21.Text = "麻醉前用药:";
            // 
            // txtCategoryDosage
            // 
            this.txtCategoryDosage.AccessibleDescription = "麻醉种类及用量";
            this.txtCategoryDosage.BackColor = System.Drawing.Color.White;
            this.txtCategoryDosage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryDosage.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtCategoryDosage.ForeColor = System.Drawing.Color.Black;
            this.txtCategoryDosage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCategoryDosage.Location = new System.Drawing.Point(208, 76);
            this.txtCategoryDosage.m_BlnIgnoreUserInfo = false;
            this.txtCategoryDosage.m_BlnPartControl = false;
            this.txtCategoryDosage.m_BlnReadOnly = false;
            this.txtCategoryDosage.m_BlnUnderLineDST = false;
            this.txtCategoryDosage.m_ClrDST = System.Drawing.Color.Red;
            this.txtCategoryDosage.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCategoryDosage.m_IntCanModifyTime = 6;
            this.txtCategoryDosage.m_IntPartControlLength = 0;
            this.txtCategoryDosage.m_IntPartControlStartIndex = 0;
            this.txtCategoryDosage.m_StrUserID = "";
            this.txtCategoryDosage.m_StrUserName = "";
            this.txtCategoryDosage.Multiline = false;
            this.txtCategoryDosage.Name = "txtCategoryDosage";
            this.txtCategoryDosage.Size = new System.Drawing.Size(520, 21);
            this.txtCategoryDosage.TabIndex = 320;
            this.txtCategoryDosage.Text = "";
            // 
            // m_cmdOperationDoctor
            // 
            this.m_cmdOperationDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOperationDoctor.DefaultScheme = true;
            this.m_cmdOperationDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOperationDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOperationDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdOperationDoctor.Hint = "";
            this.m_cmdOperationDoctor.Location = new System.Drawing.Point(8, 44);
            this.m_cmdOperationDoctor.Name = "m_cmdOperationDoctor";
            this.m_cmdOperationDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOperationDoctor.Size = new System.Drawing.Size(84, 24);
            this.m_cmdOperationDoctor.TabIndex = 160;
            this.m_cmdOperationDoctor.Tag = "1";
            this.m_cmdOperationDoctor.Text = "手术医师:";
            // 
            // m_cmdNurse
            // 
            this.m_cmdNurse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdNurse.DefaultScheme = true;
            this.m_cmdNurse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNurse.ForeColor = System.Drawing.Color.Black;
            this.m_cmdNurse.Hint = "";
            this.m_cmdNurse.Location = new System.Drawing.Point(8, 80);
            this.m_cmdNurse.Name = "m_cmdNurse";
            this.m_cmdNurse.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNurse.Size = new System.Drawing.Size(84, 24);
            this.m_cmdNurse.TabIndex = 220;
            this.m_cmdNurse.Text = "护   士:";
            // 
            // m_cmdAssistant
            // 
            this.m_cmdAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAssistant.DefaultScheme = true;
            this.m_cmdAssistant.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAssistant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAssistant.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAssistant.Hint = "";
            this.m_cmdAssistant.Location = new System.Drawing.Point(384, 44);
            this.m_cmdAssistant.Name = "m_cmdAssistant";
            this.m_cmdAssistant.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAssistant.Size = new System.Drawing.Size(80, 24);
            this.m_cmdAssistant.TabIndex = 190;
            this.m_cmdAssistant.Tag = "1";
            this.m_cmdAssistant.Text = "助    手:";
            // 
            // m_cmdUseDragOnDay
            // 
            this.m_cmdUseDragOnDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdUseDragOnDay.DefaultScheme = true;
            this.m_cmdUseDragOnDay.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdUseDragOnDay.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdUseDragOnDay.ForeColor = System.Drawing.Color.Black;
            this.m_cmdUseDragOnDay.Hint = "";
            this.m_cmdUseDragOnDay.Location = new System.Drawing.Point(164, 40);
            this.m_cmdUseDragOnDay.Name = "m_cmdUseDragOnDay";
            this.m_cmdUseDragOnDay.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdUseDragOnDay.Size = new System.Drawing.Size(40, 24);
            this.m_cmdUseDragOnDay.TabIndex = 290;
            this.m_cmdUseDragOnDay.Text = "术  日:";
            this.m_cmdUseDragOnDay.Visible = false;
            // 
            // m_cmdCategoryDosage
            // 
            this.m_cmdCategoryDosage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCategoryDosage.DefaultScheme = true;
            this.m_cmdCategoryDosage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCategoryDosage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCategoryDosage.Hint = "";
            this.m_cmdCategoryDosage.Location = new System.Drawing.Point(164, 72);
            this.m_cmdCategoryDosage.Name = "m_cmdCategoryDosage";
            this.m_cmdCategoryDosage.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCategoryDosage.Size = new System.Drawing.Size(36, 28);
            this.m_cmdCategoryDosage.TabIndex = 310;
            this.m_cmdCategoryDosage.Text = "麻醉种类及用量:";
            this.m_cmdCategoryDosage.Visible = false;
            // 
            // m_cmdUseDrugLastNight
            // 
            this.m_cmdUseDrugLastNight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdUseDrugLastNight.DefaultScheme = true;
            this.m_cmdUseDrugLastNight.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdUseDrugLastNight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdUseDrugLastNight.ForeColor = System.Drawing.Color.Black;
            this.m_cmdUseDrugLastNight.Hint = "";
            this.m_cmdUseDrugLastNight.Location = new System.Drawing.Point(164, 4);
            this.m_cmdUseDrugLastNight.Name = "m_cmdUseDrugLastNight";
            this.m_cmdUseDrugLastNight.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdUseDrugLastNight.Size = new System.Drawing.Size(40, 24);
            this.m_cmdUseDrugLastNight.TabIndex = 270;
            this.m_cmdUseDrugLastNight.Text = "前  晚:";
            this.m_cmdUseDrugLastNight.Visible = false;
            // 
            // m_cmdOutFlow
            // 
            this.m_cmdOutFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOutFlow.DefaultScheme = true;
            this.m_cmdOutFlow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOutFlow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOutFlow.ForeColor = System.Drawing.Color.Black;
            this.m_cmdOutFlow.Hint = "";
            this.m_cmdOutFlow.Location = new System.Drawing.Point(228, 60);
            this.m_cmdOutFlow.Name = "m_cmdOutFlow";
            this.m_cmdOutFlow.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOutFlow.Size = new System.Drawing.Size(28, 24);
            this.m_cmdOutFlow.TabIndex = 565;
            this.m_cmdOutFlow.Text = "引 流 物 或 填 充 物  :";
            this.m_cmdOutFlow.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 10000081;
            this.label9.Text = "手术名称:";
            // 
            // m_cmdDoctor2
            // 
            this.m_cmdDoctor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctor2.DefaultScheme = true;
            this.m_cmdDoctor2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctor2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctor2.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDoctor2.Hint = "";
            this.m_cmdDoctor2.Location = new System.Drawing.Point(194, 57);
            this.m_cmdDoctor2.Name = "m_cmdDoctor2";
            this.m_cmdDoctor2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctor2.Size = new System.Drawing.Size(77, 28);
            this.m_cmdDoctor2.TabIndex = 600;
            this.m_cmdDoctor2.Tag = "1";
            this.m_cmdDoctor2.Text = "医师签名:";
            // 
            // m_cmdAnaesther
            // 
            this.m_cmdAnaesther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAnaesther.DefaultScheme = true;
            this.m_cmdAnaesther.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAnaesther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAnaesther.ForeColor = System.Drawing.Color.Black;
            this.m_cmdAnaesther.Hint = "";
            this.m_cmdAnaesther.Location = new System.Drawing.Point(220, 140);
            this.m_cmdAnaesther.Name = "m_cmdAnaesther";
            this.m_cmdAnaesther.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAnaesther.Size = new System.Drawing.Size(80, 24);
            this.m_cmdAnaesther.TabIndex = 534;
            this.m_cmdAnaesther.Text = "麻醉医师";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(104, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 10000085;
            this.label13.Text = "前   晚";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(104, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 14);
            this.label14.TabIndex = 10000086;
            this.label14.Text = "术   日";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(104, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 14);
            this.label17.TabIndex = 10000087;
            this.label17.Text = "麻醉种类及用量";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(56, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 14);
            this.label18.TabIndex = 10000088;
            this.label18.Text = "引流物或填充物 :";
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ForeColor = System.Drawing.Color.Black;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(545, 56);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(64, 28);
            this.m_cmdPrint.TabIndex = 1000000001;
            this.m_cmdPrint.Text = "打 印";
            this.m_cmdPrint.Visible = false;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(12, 244);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(154, 14);
            this.label19.TabIndex = 1000000003;
            this.label19.Tag = "9";
            this.label19.Text = "病理所见附加图片信息:";
            // 
            // m_ctlPaintContainer
            // 
            this.m_ctlPaintContainer.AutoScroll = true;
            this.m_ctlPaintContainer.BackColor = System.Drawing.Color.White;
            this.m_ctlPaintContainer.ForeColor = System.Drawing.Color.Black;
            this.m_ctlPaintContainer.Location = new System.Drawing.Point(12, 264);
            this.m_ctlPaintContainer.m_BlnCanAddImage = true;
            this.m_ctlPaintContainer.m_BlnScaleSize = true;
            this.m_ctlPaintContainer.m_ClrcmdRubber = System.Drawing.Color.Silver;
            this.m_ctlPaintContainer.m_ClrcmdSelected = System.Drawing.Color.White;
            this.m_ctlPaintContainer.m_ClrgpbTools = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_ctlPaintContainer.m_ClrppgPicSize = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_ctlPaintContainer.m_ClrrdbDash = System.Drawing.Color.Silver;
            this.m_ctlPaintContainer.m_ClrrdbLine = System.Drawing.Color.Silver;
            this.m_ctlPaintContainer.m_ClrrdbPen = System.Drawing.Color.Silver;
            this.m_ctlPaintContainer.m_ClrrdbText = System.Drawing.Color.Silver;
            this.m_ctlPaintContainer.m_IntDefaultHeight = 253;
            this.m_ctlPaintContainer.m_IntDefaultWidth = 320;
            this.m_ctlPaintContainer.Name = "m_ctlPaintContainer";
            this.m_ctlPaintContainer.Size = new System.Drawing.Size(762, 196);
            this.m_ctlPaintContainer.TabIndex = 1000000002;
            this.m_ctlPaintContainer.TabStop = false;
            this.m_ctlPaintContainer.选择科室图片 = com.digitalwave.Utility.Controls.ctlPaintContainer.enmImageNames.无;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.m_lsvAnaesther);
            this.panel4.Controls.Add(this.txtCategoryDosage);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.m_cmdUseDrugLastNight);
            this.panel4.Controls.Add(this.txtUseDrugLastNight);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.m_cmdUseDragOnDay);
            this.panel4.Controls.Add(this.txtUseDragOnDay);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.m_cmdCategoryDosage);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.dtpAneasiaBeginDate);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.dtpAneasiaEndDate);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.m_cmdAnaesther);
            this.panel4.Controls.Add(this.chkAnaesthesia);
            this.panel4.Controls.Add(this.lblTotalAneaHour);
            this.panel4.Location = new System.Drawing.Point(8, 300);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 176);
            this.panel4.TabIndex = 10000090;
            // 
            // m_lsvAnaesther
            // 
            this.m_lsvAnaesther.BackColor = System.Drawing.Color.White;
            this.m_lsvAnaesther.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11});
            this.m_lsvAnaesther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvAnaesther.ForeColor = System.Drawing.Color.Black;
            this.m_lsvAnaesther.FullRowSelect = true;
            this.m_lsvAnaesther.GridLines = true;
            this.m_lsvAnaesther.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvAnaesther.Location = new System.Drawing.Point(396, 143);
            this.m_lsvAnaesther.Name = "m_lsvAnaesther";
            this.m_lsvAnaesther.Size = new System.Drawing.Size(240, 24);
            this.m_lsvAnaesther.TabIndex = 10000088;
            this.m_lsvAnaesther.UseCompatibleStateImageBehavior = false;
            this.m_lsvAnaesther.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Width = 70;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Width = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_lsvDoctor1);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.m_txtOperationName);
            this.panel3.Controls.Add(this.m_cmdOperationDoctor);
            this.panel3.Controls.Add(this.m_lsvOperationDoctor);
            this.panel3.Controls.Add(this.m_cmdAssistant);
            this.panel3.Controls.Add(this.m_lsvAssistant);
            this.panel3.Controls.Add(this.m_cmdNurse);
            this.panel3.Controls.Add(this.m_lsvNurse);
            this.panel3.Controls.Add(this.lblOperationBeginTimeTitle);
            this.panel3.Controls.Add(this.dtpOperationBeginTime);
            this.panel3.Controls.Add(this.lblOperationOverTime);
            this.panel3.Controls.Add(this.dtpOperationOverTime);
            this.panel3.Controls.Add(this.lblLeaveRoomTime);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lblTotalHour);
            this.panel3.Controls.Add(this.lblTotalMinute);
            this.panel3.Controls.Add(this.m_cmdCompereTitle);
            this.panel3.Location = new System.Drawing.Point(8, 128);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 168);
            this.panel3.TabIndex = 10000089;
            // 
            // m_lsvDoctor1
            // 
            this.m_lsvDoctor1.BackColor = System.Drawing.Color.White;
            this.m_lsvDoctor1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvDoctor1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvDoctor1.ForeColor = System.Drawing.Color.Black;
            this.m_lsvDoctor1.FullRowSelect = true;
            this.m_lsvDoctor1.GridLines = true;
            this.m_lsvDoctor1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvDoctor1.Location = new System.Drawing.Point(468, 80);
            this.m_lsvDoctor1.Name = "m_lsvDoctor1";
            this.m_lsvDoctor1.Size = new System.Drawing.Size(264, 24);
            this.m_lsvDoctor1.TabIndex = 1000000011;
            this.m_lsvDoctor1.UseCompatibleStateImageBehavior = false;
            this.m_lsvDoctor1.View = System.Windows.Forms.View.SmallIcon;
            this.m_lsvDoctor1.Visible = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 0;
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationBeginTimeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(8, 128);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(98, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 10000026;
            this.lblOperationBeginTimeTitle.Text = "手术开始时间:";
            // 
            // dtpOperationBeginTime
            // 
            this.dtpOperationBeginTime.BackColor = System.Drawing.Color.Gainsboro;
            this.dtpOperationBeginTime.BorderColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpOperationBeginTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpOperationBeginTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpOperationBeginTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationBeginTime.Font = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationBeginTime.ForeColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperationBeginTime.Location = new System.Drawing.Point(112, 124);
            this.dtpOperationBeginTime.m_BlnOnlyTime = false;
            this.dtpOperationBeginTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpOperationBeginTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOperationBeginTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOperationBeginTime.Name = "dtpOperationBeginTime";
            this.dtpOperationBeginTime.ReadOnly = false;
            this.dtpOperationBeginTime.Size = new System.Drawing.Size(188, 22);
            this.dtpOperationBeginTime.TabIndex = 250;
            this.dtpOperationBeginTime.TextBackColor = System.Drawing.Color.White;
            this.dtpOperationBeginTime.TextForeColor = System.Drawing.Color.Black;
            this.dtpOperationBeginTime.evtValueChanged += new System.EventHandler(this.dtpOperationBeginTime_evtValueChanged);
            // 
            // lblOperationOverTime
            // 
            this.lblOperationOverTime.AutoSize = true;
            this.lblOperationOverTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblOperationOverTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationOverTime.ForeColor = System.Drawing.Color.Black;
            this.lblOperationOverTime.Location = new System.Drawing.Point(316, 128);
            this.lblOperationOverTime.Name = "lblOperationOverTime";
            this.lblOperationOverTime.Size = new System.Drawing.Size(70, 14);
            this.lblOperationOverTime.TabIndex = 10000028;
            this.lblOperationOverTime.Text = "术毕时间:";
            // 
            // dtpOperationOverTime
            // 
            this.dtpOperationOverTime.BackColor = System.Drawing.Color.Gainsboro;
            this.dtpOperationOverTime.BorderColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpOperationOverTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpOperationOverTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpOperationOverTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationOverTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOperationOverTime.ForeColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperationOverTime.Location = new System.Drawing.Point(388, 124);
            this.dtpOperationOverTime.m_BlnOnlyTime = false;
            this.dtpOperationOverTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpOperationOverTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOperationOverTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOperationOverTime.Name = "dtpOperationOverTime";
            this.dtpOperationOverTime.ReadOnly = false;
            this.dtpOperationOverTime.Size = new System.Drawing.Size(188, 22);
            this.dtpOperationOverTime.TabIndex = 260;
            this.dtpOperationOverTime.TextBackColor = System.Drawing.Color.White;
            this.dtpOperationOverTime.TextForeColor = System.Drawing.Color.Black;
            this.dtpOperationOverTime.evtValueChanged += new System.EventHandler(this.dtpOperationOverTime_evtValueChanged);
            // 
            // lblLeaveRoomTime
            // 
            this.lblLeaveRoomTime.AutoSize = true;
            this.lblLeaveRoomTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblLeaveRoomTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeaveRoomTime.ForeColor = System.Drawing.Color.Black;
            this.lblLeaveRoomTime.Location = new System.Drawing.Point(584, 128);
            this.lblLeaveRoomTime.Name = "lblLeaveRoomTime";
            this.lblLeaveRoomTime.Size = new System.Drawing.Size(21, 14);
            this.lblLeaveRoomTime.TabIndex = 10000030;
            this.lblLeaveRoomTime.Text = "共";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(638, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 10000032;
            this.label1.Text = "时";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(692, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10000033;
            this.label2.Text = "分钟";
            // 
            // lblTotalHour
            // 
            this.lblTotalHour.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalHour.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalHour.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTotalHour.Location = new System.Drawing.Point(611, 128);
            this.lblTotalHour.Name = "lblTotalHour";
            this.lblTotalHour.Size = new System.Drawing.Size(20, 16);
            this.lblTotalHour.TabIndex = 10000031;
            // 
            // lblTotalMinute
            // 
            this.lblTotalMinute.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalMinute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalMinute.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTotalMinute.Location = new System.Drawing.Point(665, 128);
            this.lblTotalMinute.Name = "lblTotalMinute";
            this.lblTotalMinute.Size = new System.Drawing.Size(20, 16);
            this.lblTotalMinute.TabIndex = 10000034;
            // 
            // m_cmdCompereTitle
            // 
            this.m_cmdCompereTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCompereTitle.DefaultScheme = true;
            this.m_cmdCompereTitle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCompereTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCompereTitle.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCompereTitle.Hint = "";
            this.m_cmdCompereTitle.Location = new System.Drawing.Point(384, 80);
            this.m_cmdCompereTitle.Name = "m_cmdCompereTitle";
            this.m_cmdCompereTitle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCompereTitle.Size = new System.Drawing.Size(80, 24);
            this.m_cmdCompereTitle.TabIndex = 1000000010;
            this.m_cmdCompereTitle.Text = "医师签名:";
            this.m_cmdCompereTitle.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.dtpCreateDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDiagnoseBeforeOperation);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtXRayNumber);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDiagnoseAfterOperation);
            this.panel2.Location = new System.Drawing.Point(8, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 120);
            this.panel2.TabIndex = 10000088;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lblTendRecord);
            this.panel5.Controls.Add(this.txtOperationProcess);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.txtPathology);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.m_ctlPaintContainer);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(797, 484);
            this.panel5.TabIndex = 1298;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.txtSummary);
            this.panel6.Controls.Add(this.lblUpPuffDateTime);
            this.panel6.Controls.Add(this.txtInLiquid);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.txtOutFlow);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txtSampleOrExtra);
            this.panel6.Controls.Add(this.m_cmdOutFlow);
            this.panel6.Controls.Add(this.m_cmdPrint);
            this.panel6.Controls.Add(this.lstOperationID);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(797, 484);
            this.panel6.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 484);
            this.panel1.TabIndex = 10000091;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // tabControl2
            // 
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl2.IDEPixelArea = true;
            this.tabControl2.Location = new System.Drawing.Point(3, 101);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.PositionTop = true;
            this.tabControl2.SelectedIndex = 1;
            this.tabControl2.SelectedTab = this.tabPage5;
            this.tabControl2.Size = new System.Drawing.Size(797, 509);
            this.tabControl2.TabIndex = 1000000007;
            this.tabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4,
            this.tabPage5,
            this.tabPage6});
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel1);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(797, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "手术基本资料";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel5);
            this.tabPage5.ImageIndex = 1;
            this.tabPage5.ImageList = this.imageList1;
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(797, 484);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Title = "手术经过和病理情况";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel6);
            this.tabPage6.ImageIndex = 2;
            this.tabPage6.ImageList = this.imageList1;
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(797, 484);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Title = "引流、填充和术后总结";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(274, 57);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(512, 28);
            this.lsvSign.TabIndex = 1000000012;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Width = 0;
            // 
            // frmOperationRecordDoctor
            // 
            this.AccessibleDescription = "手   术   记   录";
            this.AutoScroll = false;
            this.AutoScrollMargin = new System.Drawing.Size(10, 70);
            this.ClientSize = new System.Drawing.Size(803, 653);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.m_lblBlank);
            this.Controls.Add(this.lblTotalAneaMinute);
            this.Name = "frmOperationRecordDoctor";
            this.Text = "手 术 记 录 单";
            this.Load += new System.EventHandler(this.frmOperationRecordDoctor_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblTotalAneaMinute, 0);
            this.Controls.SetChildIndex(this.m_lblBlank, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        /// <summary>
        ///  窗体启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void frmOperationRecordDoctor_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			this.m_lsvInPatientID.Visible =false;
			TreeNode trnNode=new TreeNode("记录日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			clsOperationIDInOperation [] objOperationIDInOperationArr = m_objDomain.m_objGetOperationID();
			if(objOperationIDInOperationArr!=null && objOperationIDInOperationArr.Length >0)
			{
				this.lstOperationID.Items.AddRange(objOperationIDInOperationArr);
				this.lstOperationID.SetItemChecked(0,true);//默认选中第一个
			}

			m_mthfrmLoad();

			this.dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpCreateDate.m_mthResetSize();

			//dtpOperationBeginTime dtpOperationOverTime dtpAneasiaBeginDate dtpAneasiaEndDate
			this.dtpOperationBeginTime.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Minute;
			this.dtpOperationBeginTime.m_mthResetSize();
			this.dtpOperationOverTime.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Minute;
			this.dtpOperationOverTime.m_mthResetSize();
			this.dtpAneasiaBeginDate.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Minute;
			this.dtpAneasiaBeginDate.m_mthResetSize();
			this.dtpAneasiaEndDate.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Minute;
			this.dtpAneasiaEndDate.m_mthResetSize();

			txtDiagnoseBeforeOperation.Focus();
		}

		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);	
		}

		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox = ((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

		

		private clsPictureBoxValue[] m_objPics;
        protected bool m_blnCanShowDiseaseTrack = true;
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpRecord();

			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			{
				dtpCreateDate.Enabled = true;
				dtpCreateDate.Value=DateTime.Now;
                if (m_strInPatientID != null && m_strInPatientID != "")
                {
                    clsPeopleInfo objPeo = new clsPeopleInfo();
                    objPeo.m_StrLastName = m_txtPatientName.Text;
                    m_mthSetDefaultValue(new clsPatient(m_strInPatientID, txtInPatientID.Text, objPeo));
                }

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);

//				return;
			}
			else
			{
                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				dtpCreateDate.Enabled = false;

				/*给几个全局变量赋值*/
				m_strCurrentOpenDate = ((DateTime)trvTime.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss");
				m_strOpenDate = ((DateTime)trvTime.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss");
				m_objSelectOperationRecord = m_objDomain.m_objGetOperationRecord(m_strInPatientID,m_strInPatientDate,m_strOpenDate);
				m_objSelectOperationRecordContent = m_objDomain.m_objGetOperationRecordContent(m_strInPatientID,m_strInPatientDate,m_strOpenDate);
                if (m_objSelectOperationRecordContent != null && m_objSelectOperationRecord != null)
                {
                    m_objSelectOperationRecordContent.m_strCreateDate = m_objSelectOperationRecord.m_strCreateDate;
                }
                
                m_objDomain.m_lngGetPics(m_strInPatientID,m_strInPatientDate,m_strOpenDate,out m_objPics);
				
				m_mthDisplay();
				m_mthDisplayTime();

				m_mthSetModifyControl(m_objSelectOperationRecordContent,false);

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify);


			}

			m_mthAddFormStatusForClosingSave();
		}

		private void dtpOperationOverTime_evtValueChanged(object sender, System.EventArgs e)
		{
			m_mthDisplayTime();
			dtpAneasiaEndDate.Value = dtpOperationOverTime.Value;
		}

		private void dtpOperationBeginTime_evtValueChanged(object sender, System.EventArgs e)
		{
			m_mthDisplayTime();
//			dtpOperationOverTime.Value = dtpOperationBeginTime.Value;
			dtpAneasiaBeginDate.Value = dtpOperationBeginTime.Value;
//			dtpAneasiaEndDate.Value = dtpOperationBeginTime.Value;
		}

		private void dtpAneasiaEndDate_evtValueChanged(object sender, System.EventArgs e)
		{
			m_mthDisplayTime();
		}

		private void dtpAneasiaBeginDate_evtValueChanged(object sender, System.EventArgs e)
		{
			m_mthDisplayTime();
		}

		
		#region Display
		/// <summary>
		/// 显示指定表单数据
		/// </summary>
		private void m_mthDisplay()
		{
			if(m_objSelectOperationRecord!= null && m_objSelectOperationRecordContent != null)
			{
				m_txtOperationName.m_mthSetNewText(m_objSelectOperationRecordContent.m_strOperationName,m_objSelectOperationRecord.m_strOperationNameXML);

				txtCategoryDosage.m_mthSetNewText(m_objSelectOperationRecordContent.m_strAnaesthesiaCategoryDosage,m_objSelectOperationRecord.m_strAnaesthesiaCategoryDosageXML);
				txtDiagnoseBeforeOperation.m_mthSetNewText(m_objSelectOperationRecordContent.m_strDiagnoseBeforeOperation, m_objSelectOperationRecord.m_strDiagnoseBeforeOperationXML);
				txtDiagnoseAfterOperation.m_mthSetNewText(m_objSelectOperationRecordContent.m_strDiagnoseAfterOperation, m_objSelectOperationRecord.m_strDiagnoseAfterOperationXML);
				dtpCreateDate.Value = DateTime.Parse(m_objSelectOperationRecord.m_strCreateDate);
				dtpOperationBeginTime.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strOperationBeginDate);
				dtpOperationOverTime.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strOperationEndDate);
				dtpAneasiaBeginDate.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strAnaesthesiaBeginDate);
				dtpAneasiaEndDate.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strAnaesthesiaEndDate);
				txtUseDrugLastNight.m_mthSetNewText(m_objSelectOperationRecordContent.m_strAnaesthesiaBeforeOperation,m_objSelectOperationRecord.m_strAnaesthesiaBeforeOperationXML);
				txtUseDragOnDay.m_mthSetNewText(m_objSelectOperationRecordContent.m_strAnaesthesiaInOperation, m_objSelectOperationRecord.m_strAnaesthesiaInOperationXML);
				txtOperationProcess.m_mthSetNewText(m_objSelectOperationRecordContent.m_strOperationProcess, m_objSelectOperationRecord.m_strOperationProcessXML);
				txtPathology.m_mthSetNewText(m_objSelectOperationRecordContent.m_strPathology, m_objSelectOperationRecord.m_strPathologyXML);
				txtInLiquid.m_mthSetNewText(m_objSelectOperationRecordContent.m_strInLiquid, m_objSelectOperationRecord.m_strInLiquidXML);
				txtOutFlow.m_mthSetNewText(m_objSelectOperationRecordContent.m_strOutFlow, m_objSelectOperationRecord.m_strOutFlowXML);
				txtSampleOrExtra.m_mthSetNewText(m_objSelectOperationRecordContent.m_strSampleOrExtraRecord, m_objSelectOperationRecord.m_strSampleOrExtraRecordXML);
				txtSummary.m_mthSetNewText(m_objSelectOperationRecordContent.m_strSummaryAfterOperation, m_objSelectOperationRecord.m_strSummaryAfterOperationXML);
				txtXRayNumber.m_mthSetNewText(m_objSelectOperationRecordContent.m_strXRayNumber,m_objSelectOperationRecord.m_strXRayNumberXML);
				m_lsvAnaesther.Text = m_objSelectOperationRecordContent.m_strAnaesther;
				if(m_lsvAnaesther.Text=="麻醉科")
				{
					chkAnaesthesia.Checked = true;
				}

                #region 签名集合
                //有效医师
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    //m_mthAddSignToListView(lsvSign, m_objSelectOperationRecord.objSignerArr);
                    //m_mthAddSignToListView(m_lsvOperationDoctor, m_objSelectOperationRecord.objSignerArr);
                    //m_mthAddSignToListView(m_lsvAssistant, m_objSelectOperationRecord.objSignerArr);
                    //m_mthAddSignToListView(m_lsvNurse, m_objSelectOperationRecord.objSignerArr);
                    //m_mthAddSignToListView(m_lsvDoctor1, m_objSelectOperationRecord.objSignerArr);
                    //m_mthAddSignToListView(m_lsvAnaesther, m_objSelectOperationRecord.objSignerArr);
                    lsvSign.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "lsvSign")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            lsvSign.Items.Add(lviNewItem);
                        }
                    }
                }
               // 手术者
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_lsvOperationDoctor.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvOperationDoctor")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            m_lsvOperationDoctor.Items.Add(lviNewItem);
                        }
                    }
                }
              //  助手
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_lsvAssistant.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvAssistant")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            m_lsvAssistant.Items.Add(lviNewItem);
                        }
                    }
                }
                //护士
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_lsvNurse.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvNurse")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            m_lsvNurse.Items.Add(lviNewItem);
                        }
                    }
                }
                //医师
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_lsvDoctor1.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvDoctor1")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            m_lsvDoctor1.Items.Add(lviNewItem);
                        }
                    }
                }
                //麻醉
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_lsvAnaesther.Items.Clear();
                    for (int i = 0; i < m_objSelectOperationRecord.objSignerArr.Length; i++)
                    {
                        if (m_objSelectOperationRecord.objSignerArr[i].controlName == "m_lsvAnaesther")
                        {
                            ListViewItem lviNewItem = new ListViewItem(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                            //ID 检查重复用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                            //级别 排序用
                            lviNewItem.SubItems.Add(m_objSelectOperationRecord.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                            //tag均为对象
                            lviNewItem.Tag = m_objSelectOperationRecord.objSignerArr[i].objEmployee;
                            //是按顺序保存故获取顺序也一样
                            m_lsvAnaesther.Items.Add(lviNewItem);
                        }
                    }
                }
                  #endregion 签名		
               
			}

			#region 显示图片信息
			if(m_objPics != null && m_objPics.Length > 0)
				m_ctlPaintContainer.m_mthSetPicValue(m_objPics);
			#endregion
			
		}

		private void m_mthDisplayTime()
		{
			TimeSpan tsTimeSpan = dtpOperationOverTime.Value - dtpOperationBeginTime.Value;
			int intHour = (int)tsTimeSpan.TotalHours;
			int intMinute = (int)(tsTimeSpan.TotalMinutes - intHour*60);

			lblTotalHour.Text = intHour.ToString();
			lblTotalMinute.Text = intMinute.ToString();

			tsTimeSpan = dtpAneasiaEndDate.Value - dtpAneasiaBeginDate.Value;
			intHour = (int)tsTimeSpan.TotalHours;
			intMinute = (int)(tsTimeSpan.TotalMinutes - intHour*60);

			lblTotalAneaHour.Text = intHour.ToString();
			lblTotalAneaMinute.Text = intMinute.ToString();

		}

	
		#endregion

		#region Tools
        /// <summary>
        /// 初始化清空
        /// </summary>
		private void m_mthClearUpRecord()
		{
            //默认签名
            MDIParent.m_mthSetDefaulEmployee(lsvSign);

			m_strCurrentOpenDate = "";
 			m_lsvOperationDoctor.Items.Clear();
			m_lsvAssistant.Items.Clear();
			m_lsvNurse.Items.Clear();
			m_lsvAnaesther.Items.Clear();
            m_lsvDoctor1.Items.Clear();
            lsvSign.Items.Clear();
 			chkAnaesthesia.Checked = false;

            dtpCreateDate.Enabled = true;
            dtpCreateDate.Value = DateTime.Now;

			//清除RichTextBox 的内容
//			foreach(Control ctlControl in this.Controls )
//			{
//				string typeName = ctlControl.GetType().Name;
//				if(typeName == "ctlRichTextBox" )
//				{
//					((ctlRichTextBox)ctlControl).m_mthClearText();
//				}
//
//				foreach(Control ctlGrp in ctlControl.Controls )
//				{
//						
//					typeName=ctlGrp.GetType().Name ;
//					if(typeName =="ctlRichTextBox")
//						((ctlRichTextBox)ctlGrp).m_mthClearText();
//				}
//			}
			m_mthClear_Recursive(tabControl2,null);

			

			
			if(lstOperationID.CheckedItems.Count>0)
				for(int i=0;i<lstOperationID.Items.Count;i++)
				{
					lstOperationID.SetItemChecked(i,false);
				}

		

			dtpAneasiaBeginDate.Value = DateTime.Now;
			dtpAneasiaEndDate.Value = DateTime.Now;
			dtpOperationBeginTime.Value = DateTime.Now;
			dtpOperationOverTime.Value = DateTime.Now;

			m_strOpenDate = "";

			m_objSelectOperationRecord = null;
			m_objSelectOperationRecordContent = null;		

			//在这之前对RichTextBox赋值，字体可能为红色
			m_mthSetModifyControl(null,true);

			m_ctlPaintContainer.m_mthClear();
		}

		/// <summary>
		/// tag 0 根 
		/// </summary>
		/// <param name="p_strPatientID"></param>
		/// <param name="p_strPatientDate"></param>
		private void m_mthLoadAllRecordTimeOfAPatient(string p_strPatientID,string p_strPatientDate)
		{
			m_mthClearUpRecord();

			if(p_strPatientID ==null || p_strPatientID =="") 
				return ;


			this.trvTime.Nodes[0].Nodes.Clear();

			DateTime [,] m_dtmArr= m_objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strPatientID ,p_strPatientDate);

			if(m_dtmArr==null || m_dtmArr.Length == 0) 
			{
                clsPeopleInfo objPeo = new clsPeopleInfo();
                objPeo.m_StrLastName = m_txtPatientName.Text;
                m_mthSetDefaultValue(new clsPatient(p_strPatientID, txtInPatientID.Text, objPeo));								
				return ;
			}

			for(int i=m_dtmArr.Length/2 - 1;i>=0 ;i--)
			{
				string strDate=m_dtmArr[i,0].ToString("yyyy-MM-dd HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i,1];
				this.trvTime.Nodes[0].Nodes.Insert(0,trnDate );
			}
            this.trvTime.ExpandAll();

			this.trvTime.SelectedNode = trvTime.Nodes[0].Nodes[0];
		}

		#endregion

		#region Save
        /// <summary>
        /// 保存单据
        /// </summary>
        /// <returns></returns>
		private long m_lngSaveWithMessageBox()
		{
//			//当前控件处于焦点状态下的控件
//			Control m_ctlLast=this.ActiveControl;

			long lngRes=m_lngSaveWithoutMessageBox();

//			//保存过程中可能更改了控件的焦点,需要重新把焦点定位到保存之前的焦点控件上。
//			if(m_ctlLast!=null)
//                m_ctlLast.Focus();

			 
			if(lngRes==-11)
			{
				clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");				
			}
			else if(lngRes==-12)
			{
				m_mthShowRecordTimeDouble();
			}
			else if(lngRes==-21)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
			}
			else if(lngRes==-31)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，本记录已被他人修改，请重新读取一次！");
			}
			return lngRes;
		}
        /// <summary>
        /// 保存单据
        /// </summary>
        /// <returns></returns>
		private long m_lngSaveWithoutMessageBox()
		{
			if(m_strInPatientID == null || m_strInPatientID == "")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，请输入病人住院编号！");
				return 0;
			}
            //作用？？
			if(lstOperationID.CheckedItems.Count == 0)
			{
				lstOperationID.SetItemChecked(0,true);
				//clsPublicFunction.ShowInformationMessageBox("对不起，请至少选择一个手术名称！");
				//return 0;
			}
            //需要签名
            if(lsvSign.Items.Count == 0)
			{
                clsPublicFunction.ShowInformationMessageBox("对不起，请医师签名");
                return 0;
            } 

            //赋值
			string strCurrentDate = new clsPublicDomain().m_strGetServerTime();//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); /*+((float)(DateTime.Now.Millisecond)/1000f).ToString(".000");*/

			clsOperationRecordDoctor objOperationRecord = new clsOperationRecordDoctor();
			clsOperationRecordContentDoctor objOperationRecordContent = new clsOperationRecordContentDoctor();

			objOperationRecord.m_strInPatientID = m_strInPatientID;
			objOperationRecord.m_strInPatientDate = m_strInPatientDate;
			objOperationRecord.m_strCreateDate = dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecord.m_strOpenDate = (m_strOpenDate == "") ? strCurrentDate : m_strOpenDate;

			objOperationRecordContent.m_strInPatientID = m_strInPatientID;
			objOperationRecordContent.m_strInPatientDate = m_strInPatientDate;
			objOperationRecordContent.m_strOpenDate = objOperationRecord.m_strOpenDate;
			objOperationRecordContent.m_strLastModifyDate = strCurrentDate;
			//objOperationRecordContent.m_strLastModifyUserID = ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;

			objOperationRecord.m_strCreateUserID = MDIParent.strOperatorID;	

			objOperationRecord.m_strOperationNameXML = m_txtOperationName.m_strGetXmlText();
			objOperationRecordContent.m_strOperationName = m_txtOperationName.Text;
			objOperationRecord.m_strDiagnoseBeforeOperationXML = txtDiagnoseBeforeOperation.m_strGetXmlText();
			objOperationRecord.m_strDiagnoseAfterOperationXML = txtDiagnoseAfterOperation.m_strGetXmlText();
			objOperationRecordContent.m_strDiagnoseBeforeOperation = txtDiagnoseBeforeOperation.Text;
			objOperationRecordContent.m_strDiagnoseAfterOperation = txtDiagnoseAfterOperation.Text;

			objOperationRecord.m_strAnaesthesiaCategoryDosageXML = txtCategoryDosage.m_strGetXmlText();
			objOperationRecord.m_strAnaesthesiaBeforeOperationXML = txtUseDrugLastNight.m_strGetXmlText();
			objOperationRecord.m_strAnaesthesiaInOperationXML = txtUseDragOnDay.m_strGetXmlText();
			
			objOperationRecordContent.m_strAnaesthesiaCategoryDosage = txtCategoryDosage.Text ;
			objOperationRecordContent.m_strAnaesthesiaBeforeOperation = txtUseDrugLastNight.Text ;
			objOperationRecordContent.m_strAnaesthesiaInOperation = txtUseDragOnDay.Text ;

			objOperationRecord.m_strOperationProcessXML = txtOperationProcess.m_strGetXmlText();
			objOperationRecord.m_strPathologyXML = txtPathology.m_strGetXmlText();
			objOperationRecord.m_strSampleOrExtraRecordXML = txtSampleOrExtra.m_strGetXmlText();
			objOperationRecord.m_strSummaryAfterOperationXML = txtSummary.m_strGetXmlText();
			objOperationRecord.m_strInLiquidXML = txtInLiquid.m_strGetXmlText();
			objOperationRecord.m_strOutFlowXML = txtOutFlow.m_strGetXmlText();
			objOperationRecord.m_strXRayNumberXML = txtXRayNumber.m_strGetXmlText();

			objOperationRecordContent.m_strOperationProcess = txtOperationProcess.Text ;
			objOperationRecordContent.m_strPathology = txtPathology.Text ;
			objOperationRecordContent.m_strSampleOrExtraRecord = txtSampleOrExtra.Text ;
			objOperationRecordContent.m_strSummaryAfterOperation = txtSummary.Text ;
			objOperationRecordContent.m_strInLiquid = txtInLiquid.Text ;
			objOperationRecordContent.m_strOutFlow = txtOutFlow.Text ;
			objOperationRecordContent.m_strXRayNumber = txtXRayNumber.Text ;
			objOperationRecordContent.m_strAnaesther = m_lsvAnaesther.Text;

            #region 签名集合
            //签名个数
            int intSignerCount = m_lsvOperationDoctor.Items.Count + 
                                 m_lsvAssistant.Items.Count + 
                                 m_lsvNurse.Items.Count +
                                 m_lsvDoctor1.Items.Count +
                                 lsvSign.Items.Count +
                                 m_lsvAnaesther.Items.Count;

            objOperationRecord.objSignerArr = new clsEmrSigns_VO[intSignerCount];
            string strUserIDList = "";
            string strUserNameList = "";
            m_mthGetSignArr(new Control[] { lsvSign, m_lsvOperationDoctor, m_lsvAssistant, m_lsvNurse, m_lsvDoctor1, m_lsvAnaesther }, ref objOperationRecord.objSignerArr, ref strUserIDList, ref strUserNameList);
            
            objOperationRecordContent.m_strLastModifyUserID = strUserIDList;

			//为病案首页的数据复用添加“1助”信息
			if(m_lsvAssistant.Items.Count >= 1)
			{
				objOperationRecordContent.m_strFirstAssistantID = m_lsvAssistant.Items[0].SubItems[1].Text;
				objOperationRecordContent.m_strFirstAssistantName = m_lsvAssistant.Items[0].SubItems[0].Text;
			}

			//为病案首页的数据复用添加“2助”信息
			if(m_lsvAssistant.Items.Count >= 2)
			{
				objOperationRecordContent.m_strSecondAssistantID = m_lsvAssistant.Items[1].SubItems[1].Text;
				objOperationRecordContent.m_strSecondAssistantName = m_lsvAssistant.Items[1].SubItems[0].Text;
			}
			#endregion
			

			objOperationRecordContent.m_strOperationBeginDate = dtpOperationBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.m_strOperationEndDate = dtpOperationOverTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.m_strAnaesthesiaBeginDate = dtpAneasiaBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objOperationRecordContent.m_strAnaesthesiaEndDate = dtpAneasiaEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

			objOperationRecordContent.m_strDeActivedDate = "";
			objOperationRecordContent.m_strDeActivedOperatorID = "";
			objOperationRecordContent.m_strStatus = "0";

			objOperationRecord.m_strDeActivedDate = "";
			objOperationRecord.m_strDeActivedOperatorID = "";
			objOperationRecord.m_strStatus = "0";
			objOperationRecord.m_strIfConfirm = "1";
			
            // 目的?? tfzhang
			clsOperationRecord_OperationID[] m_objOperationRecordOperationArr = new clsOperationRecord_OperationID[lstOperationID.CheckedItems.Count];
			for(int i=0;i<lstOperationID.CheckedItems.Count;i++)
			{
				m_objOperationRecordOperationArr[i]=new clsOperationRecord_OperationID();
				m_objOperationRecordOperationArr[i].strOperationID = ((clsOperationIDInOperation)(lstOperationID.CheckedItems[i])).strOperationID;
				m_objOperationRecordOperationArr[i].strInPatientID = m_strInPatientID;
				m_objOperationRecordOperationArr[i].strOpenDate = objOperationRecord.m_strOpenDate;
				m_objOperationRecordOperationArr[i].strInPatientDate = m_strInPatientDate;
				m_objOperationRecordOperationArr[i].strModifyDate = strCurrentDate;
				m_objOperationRecordOperationArr[i].strStatus = "0";
			}
			#region 保存图片信息
			clsPictureBoxValue[] objPics = m_ctlPaintContainer.m_objGetPicValue();
			#endregion

			bool blnNewRecord = false;
			if(m_strOpenDate == "")
			{
				blnNewRecord = true;
				#region 判断用户输入的时间是否已存在（仅在添加记录时要考虑）
				bool blnRecordExist=false;
				long lngResult=m_objDomain.m_lngRecordExist(objOperationRecord.m_strInPatientID,objOperationRecord.m_strInPatientDate,dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"),out blnRecordExist);
				if(lngResult >0 && blnRecordExist==true)
				{
//					m_mthShowRecordTimeDouble();
					return -12;
				}
				#endregion 判断用户输入的时间是否已存在（仅在添加记录时要考虑）
			}
			else
			{
				blnNewRecord = false;				
//				if(!m_bolShowIfModify())
//					return -3;

				string strLastModifyDate;
				long lngCheckRes = m_objDomain.m_lngGetOperationRecordLastModifyDate(m_strInPatientID,m_strInPatientDate,m_strOpenDate,out strLastModifyDate);

				if(lngCheckRes <= 0)
					return lngCheckRes;
				if(strLastModifyDate == "" || strLastModifyDate == null)
					return -31;

				if(DateTime.Parse(m_objSelectOperationRecordContent.m_strLastModifyDate) != DateTime.Parse(strLastModifyDate))
				{
					return -31;
				}
//				clsOperationRecordDoctor objCheckOperationRecord = m_objDomain.m_objGetOperationRecord(m_strInPatientID,m_strInPatientDate,m_strOpenDate);
//				if(!m_objSelectOperationRecord.m_strXML_TotalRecord.Equals(objCheckOperationRecord.m_strXML_TotalRecord))
//				{
//					//clsPublicFunction.ShowInformationMessageBox("Not Equal,Some one had changed this record!");
//					return -31;
//				}
			}

			clsOperationRecordDoc_All objAll = new clsOperationRecordDoc_All();
			objAll.m_objSelectOperationRecord = objOperationRecord;
			objAll.m_objSelectOperationRecordContent = objOperationRecordContent;
			//objAll.m_objOperationRecord_OperationIDArr = m_objOperationRecordOperationArr;
			//objAll.m_objOperatorArr = objOperationNurseArr;
			//objAll.m_objSelectDoctorSign = objDoctorSign;
			objAll.m_objPics = objPics;

			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			 clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientID + "-" + m_strInPatientDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objAll, objSign_VO) == -1)
                return -1;

			//long lngRes = m_objDomain.m_lngSave(objOperationRecord,objOperationRecordContent,blnNewRecord,m_objOperationRecordOperationArr,objOperationNurseArr,objDoctorSign,objPics);
            long lngRes = m_objDomain.m_lngSave(objOperationRecord, objOperationRecordContent, blnNewRecord, m_objOperationRecordOperationArr, null, null, objPics);

            if(lngRes<=0)
			{
				return -21;
			}
			else
			{
				if(m_strOpenDate == "")
				{
					m_mthAddNodeToTrv(DateTime.Parse(strCurrentDate));					
				}
				else
				{
					TreeNode m_trnTempNode = trvTime.SelectedNode;
					trvTime.SelectedNode = trvTime.Nodes[0];
					trvTime.SelectedNode = m_trnTempNode;
				}
			}
			return 1;
		}

		private void m_mthAddNodeToTrv(DateTime p_dtmOpenDate)
		{
			string strDate=dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmOpenDate;
			
			int intIndex = trvTime.Nodes[0].Nodes.Count;
			for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
			{
				if((DateTime.Parse(trvTime.Nodes[0].Nodes[i].Text)) < dtpCreateDate.Value)
				{
					intIndex = i;
					break;
				}
			}

			this.trvTime.Nodes[0].Nodes.Insert(intIndex,trnDate );
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[intIndex];
			
		}
		#endregion

		#region Override
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return m_blnCanSearch;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return (this.trvTime.SelectedNode==trvTime.Nodes[0] || this.trvTime.SelectedNode == null);//(m_strOpenDate == "" || m_strOpenDate == null);
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_objSelectedPatient = p_objSelectedPatient;
			m_strInPatientID = p_objSelectedPatient.m_StrEMRInPatientID;
			m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            //txtInPatientID.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_StrHISInPatientID;

            m_mthIsReadOnly();
            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();

            //m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID ,m_strInPatientDate);
		}

		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox();
		}

		protected override long m_lngSubModify()
		{
			return m_lngSaveWithMessageBox();
		}

		
		#region 使用外部的打印方法.	Alex 2003-7-2

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

			if(ppdPrintPreview != null)
				while(!ppdPrintPreview.m_blnHandlePrint(e))
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

		clsOperationRecordDoctorPrintTool objPrintTool;
		private void m_mthDemoPrint_FromDataSource()
		{	
			objPrintTool=new clsOperationRecordDoctorPrintTool();
			objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                if (this.trvTime.SelectedNode == null || this.trvTime.SelectedNode == trvTime.Nodes[0] || trvTime.SelectedNode.Tag == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.Parse(trvTime.SelectedNode.Tag.ToString()));
            }					
			objPrintTool.m_mthInitPrintContent();				
			
			m_mthStartPrint();
		}
		
		private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
		private void m_mthStartPrint()
		{			
			if(m_blnDirectPrint)
			{
				objPrintTool.m_BlnPreview = false;
				objPrintTool.m_BlnIsDummy = false;
				m_pdcPrintDocument.Print();
				if(clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint,MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					objPrintTool.m_BlnIsDummy = true;
					m_pdcPrintDocument.Print();
				}				
			}
			else
			{
				objPrintTool.m_BlnPreview = true;
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{
			m_mthDemoPrint_FromDataSource();
			return 1;
		}
		#endregion 使用外部的打印方法

		private PrintPreviewDialog printpreviewdialog = new PrintPreviewDialog();

		protected override long m_lngSubDelete()
		{
//			//获取当前的活动控件
//			Control m_ctlLast=this.ActiveControl;

			long lngRes = 0;
			if(m_objSelectedPatient!=null && m_objSelectOperationRecord!=null )
            {
                //权限判断
                string strDeptIDTemp = base.m_ObjCurrentEmrPatientSession.m_strAreaId;// ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
                bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objSelectOperationRecord.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
                if (!blnIsAllow)
                    return -1;
				lngRes = m_objDomain. m_lngDeleteRecord(  m_objSelectedPatient.m_StrInPatientID,  m_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objSelectOperationRecord.m_strOpenDate,MDIParent.OperatorID );

			}
			if(lngRes > 0)
			{
				m_mthClearUpRecord();

				
				trvTime.SelectedNode.Remove();
			}

//			//如果删除过程中更改了活动控件，需要重新将该控件设为活动
//			if(m_ctlLast!=null)
//				m_ctlLast.Focus();

			return lngRes;
		}

		#endregion

		#region Public Function
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
			this.m_lngDelete();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
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
//			m_lngSubPrint();
			m_lngPrint();//只有调用父类的才有提示保存
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			if(this.m_lngSave() > 0)
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
				//MessageBox.Show("保存成功！");
            //else
            //    MessageBox.Show("保存失败！");
		}

		public void Undo()
		{
		
		}
		#endregion

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
                case 13:
                    break;
                case 40:
                    break;
                case 46:
                    if (((Control)sender).GetType().Name == "ListView")
                    {
                        ListView lstControl = (ListView)sender;
                        while (lstControl.SelectedItems.Count > 0)
                            lstControl.SelectedItems[0].Remove();
                    }
                    break;

                case 113://save
                    this.Save();
                    break;
                case 114://del
                    this.Delete();
                    break;
                case 115://print
                    this.Print();
                    break;
                case 116://refresh
                    m_blnCanSearch = false;
                    this.txtInPatientID.Text = "";
                    m_blnCanSearch = true;
                    m_mthClearUpRecord();

                    this.m_txtPatientName.Text = "";
                    this.lblAge.Text = "";
                    this.m_cboArea.Text = "";
                    this.m_txtBedNO.Text = "";
                    this.lblSex.Text = "";

                    m_strInPatientDate = "";
                    m_strInPatientID = "";

                    this.trvTime.Nodes[0].Nodes.Clear();
                    dtpCreateDate.Enabled = true;
                    break;
                case 117://Search					
                    break;
            }
        }

		#endregion		

		#region 设置是否允许修改（修改留痕迹），以及修改颜色

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsOperationRecordContentDoctor p_objRecordContent,
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
                m_mthSetRichTextCanModifyLast(this, m_blnGetCanModifyLast(p_objRecordContent.m_strLastModifyUserID,DateTime.Parse( p_objRecordContent.m_strCreateDate), 0));
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
        private bool m_blnGetCanModifyLast(string p_strModifyUserID, DateTime p_dtmCreatDate, int p_intMark)
		{
            int intl = int.Parse(clsEMRLogin.StrCanModifyTime);
            if (p_dtmCreatDate.AddHours(intl) >= DateTime.Now)
            {
                if (p_strModifyUserID == null || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPNO_CHR.Trim()) >= 0 || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim()) >= 0)
                {
                    //chkModifyWithoutMatk.Visible = true;
                    chkModifyWithoutMatk.Checked = true;
                    return true;
                }
                else
                {
                    chkModifyWithoutMatk.Checked = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
		}
		#endregion

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
                if (lsvSign.Items.Count > 0)
                {
                    //默认返回第一签名人
                    return ((clsEmrEmployeeBase_VO)(lsvSign.Items[0].Tag)).m_strLASTNAME_VCHR;

                }
                else
                {
                     return "";
                }
				
			}
		}
		#endregion 属性

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(com.digitalwave.controls.ctlRichTextBox p_objRichTextBox)
		{
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
			//设置右键菜单			
//			p_objRichTextBox.ContextMenu=ctmRichTextBoxMenu;
			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
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
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期，此处表示OpenDate</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}

			this.trvTime.SelectedNode=trvTime.Nodes[0];
			/*给几个全局变量赋值*/
			m_strOpenDate = p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss");

			m_objSelectOperationRecord = m_objDomain.m_objGetDeletedOperationRecord(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"));

			m_objSelectOperationRecordContent = m_objDomain.m_objGetDeletedOperationRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"));
 				
			m_mthDisplayDeletedRecord();
//			m_mthDisplayOperationOperator(m_strOpenDate);
			m_mthDisplayTime();	
			
			m_strOpenDate="";
		}

		private void m_mthDisplayDeletedRecord()
		{
            //if(m_strOperationIDArr !=null)
            //{
            //    m_strOperationNameArr=new string[m_strOperationIDArr.Length];
            //    for(int i0=0;i0< m_strOperationIDArr.Length;i0++)
            //    {
            //        for(int j1=0; j1<lstOperationID.Items.Count;j1++)
            //        {
            //            if(((clsOperationIDInOperation)(lstOperationID.Items[j1])).strOperationID == m_strOperationIDArr[i0])
            //            {
            //                lstOperationID.SetItemChecked(j1,true);
            //                m_strOperationNameArr[i0]=((clsOperationIDInOperation)(lstOperationID.Items[j1])).strOperationName;
            //                break;
            //            }
            //        }
            //    }
            //}

			if(m_objSelectOperationRecord!= null && m_objSelectOperationRecordContent != null)
			{
				m_txtOperationName.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strOperationName,m_objSelectOperationRecord.m_strOperationNameXML);

				txtCategoryDosage.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strAnaesthesiaCategoryDosage,m_objSelectOperationRecord.m_strAnaesthesiaCategoryDosageXML);
				txtDiagnoseBeforeOperation.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strDiagnoseBeforeOperation, m_objSelectOperationRecord.m_strDiagnoseBeforeOperationXML);
				txtDiagnoseAfterOperation.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strDiagnoseAfterOperation, m_objSelectOperationRecord.m_strDiagnoseAfterOperationXML);
				dtpCreateDate.Value = DateTime.Parse(m_objSelectOperationRecord.m_strCreateDate);
				dtpOperationBeginTime.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strOperationBeginDate);
				dtpOperationOverTime.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strOperationEndDate);
				dtpAneasiaBeginDate.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strAnaesthesiaBeginDate);
				dtpAneasiaEndDate.Value = DateTime.Parse(m_objSelectOperationRecordContent.m_strAnaesthesiaEndDate);
				txtUseDrugLastNight.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strAnaesthesiaBeforeOperation,m_objSelectOperationRecord.m_strAnaesthesiaBeforeOperationXML);
				txtUseDragOnDay.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strAnaesthesiaInOperation, m_objSelectOperationRecord.m_strAnaesthesiaInOperationXML);
				txtOperationProcess.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strOperationProcess, m_objSelectOperationRecord.m_strOperationProcessXML);
				txtPathology.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strPathology, m_objSelectOperationRecord.m_strPathologyXML);
				txtInLiquid.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strInLiquid, m_objSelectOperationRecord.m_strInLiquidXML);
				txtOutFlow.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strOutFlow, m_objSelectOperationRecord.m_strOutFlowXML);
				txtSampleOrExtra.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strSampleOrExtraRecord, m_objSelectOperationRecord.m_strSampleOrExtraRecordXML);
				txtSummary.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strSummaryAfterOperation, m_objSelectOperationRecord.m_strSummaryAfterOperationXML);
				txtXRayNumber.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(m_objSelectOperationRecordContent.m_strXRayNumber,m_objSelectOperationRecord.m_strXRayNumberXML);
			}
		}

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>
		public override int m_IntFormID
		{
			get
			{
				return 24;
			}
		}
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

            this.m_strInPatientID = p_objSelectedSession.m_strEMRInpatientId;
            this.m_strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            base.m_mthIsReadOnly();
            if (!base.m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }
            this.m_mthLoadAllRecordTimeOfAPatient(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
            //this.m_mthSetPatientFormInfo(base.m_objBaseCurrentPatient);

            base.m_mthPerformSessionChanged(p_objSelectedSession, p_intIndex);
        }

		#region 审核
		private string m_strCurrentOpenDate = "";

		private void chkAnaesthesia_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chkAnaesthesia.Checked==true)
				m_lsvAnaesther.Text = "麻醉科";
			else
				m_lsvAnaesther.Text = "";
		}
	
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

				if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null || trvTime.SelectedNode.Tag.ToString() == "0")
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return this.trvTime.SelectedNode.Tag.ToString();
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

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{


			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);
			m_mthSetSpecialPatientTemplateSet(p_objPatient,enmAssociate.Operation);

			//数据复用
//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtDiagnoseBeforeOperation.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;						
//				this.txtDiagnoseAfterOperation.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;						
//			}

			//设完默认值后回到光标床号
			m_txtBedNO.Focus();
		}

		private void m_cmdPrint_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			objPrintTool=new clsOperationRecordDoctorPrintTool();
			objPrintTool.m_mthInitPrintTool(null);	
			if(m_objBaseCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
			else if(this.trvTime.SelectedNode ==null || this.trvTime.SelectedNode==trvTime.Nodes[0] || trvTime.SelectedNode.Tag==null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate,DateTime.MinValue);
			else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.Parse(trvTime.SelectedNode.Tag.ToString()));
										
			objPrintTool.m_mthInitPrintContent();
			
			this.Cursor = Cursors.Default;
			
//			objPrintTool.m_IntPageNeedToPrint = 1;
			objPrintTool.m_BlnIsDummy = false;
			m_pdcPrintDocument.Print();
            clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strPromptForPrint);
			objPrintTool.m_BlnIsDummy = true;
//			objPrintTool.m_IntPageNeedToPrint = 2;
			m_pdcPrintDocument.Print();
		}

		/// <summary>
		/// 手术、麻醉时间与记录日期同步
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dtpCreateDate_evtValueChanged(object sender, System.EventArgs e)
		{
			dtpOperationBeginTime.Value = dtpCreateDate.Value;
			dtpOperationOverTime.Value = dtpCreateDate.Value;
			dtpAneasiaBeginDate.Value = dtpCreateDate.Value;
			dtpAneasiaEndDate.Value = dtpCreateDate.Value;
		}



        #region 作废重做

        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (p_objSelectedValue != null)
            {
                clsOperationRecordContentDoctor p_objContent = new clsOperationRecordContentDoctor();
                p_objContent = m_objDomain.m_objGetDeletedOperationRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (p_objContent == null)
                {
                    //switch (lngRes)
                    //{
                    //    case (long)(iCareData.enmOperationResult.Not_permission):
                    //        m_mthShowNotPermitted(); break;
                    //    case (long)(iCareData.enmOperationResult.DB_Fail):
                    //        m_mthShowDBError(); break;
                    //}
                    return blnIsOK;
                }

                
                this.dtpCreateDate.Text = p_objContent.m_strCreateDate;
                this.txtXRayNumber.Text = p_objContent.m_strXRayNumber;
                this.txtDiagnoseBeforeOperation.Text = p_objContent.m_strDiagnoseBeforeOperation;
                this.txtDiagnoseAfterOperation.Text = p_objContent.m_strDiagnoseAfterOperation;
                this.m_txtOperationName.Text = p_objContent.m_strOperationName;
                if (m_objSelectOperationRecord.objSignerArr != null)
                {
                    m_mthAddSignToListView(lsvSign, m_objSelectOperationRecord.objSignerArr);
                    m_mthAddSignToListView(m_lsvOperationDoctor, m_objSelectOperationRecord.objSignerArr);
                    m_mthAddSignToListView(m_lsvAssistant, m_objSelectOperationRecord.objSignerArr);
                    m_mthAddSignToListView(m_lsvNurse, m_objSelectOperationRecord.objSignerArr);
                    m_mthAddSignToListView(m_lsvDoctor1, m_objSelectOperationRecord.objSignerArr);
                    m_mthAddSignToListView(m_lsvAnaesther, m_objSelectOperationRecord.objSignerArr);
                }
                this.dtpOperationBeginTime.Text = p_objContent.m_strOperationBeginDate;
                this.dtpOperationOverTime.Text = p_objContent.m_strOperationEndDate;
                //this.lblTotalHour.Text
                //this.lblTotalMinute.Text
                //this.txtUseDrugLastNight.Text
                //this.txtUseDragOnDay.Text
                //this.txtCategoryDosage.Text
                this.dtpAneasiaBeginDate.Text = p_objContent.m_strAnaesthesiaBeginDate;
                this.dtpAneasiaEndDate.Text = p_objContent.m_strAnaesthesiaEndDate;
                //this.lblTotalAneaHour.Text
                //this.chkAnaesthesia.Checked 

                this.txtOperationProcess.Text = p_objContent.m_strOperationProcess;
                this.txtPathology.Text = p_objContent.m_strPathology;


                this.txtInLiquid.Text = p_objContent.m_strInLiquid;
                this.txtOutFlow.Text = p_objContent.m_strOutFlow;
                this.txtSampleOrExtra.Text = p_objContent.m_strSampleOrExtraRecord;
                this.txtSummary.Text = p_objContent.m_strSummaryAfterOperation;


                blnIsOK = true;
            }
            return blnIsOK;
        }

        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue == null) return;
            objPrintTool = new clsOperationRecordDoctorPrintTool();

            if (m_objBaseCurrentPatient != null)
            {
                objPrintTool.m_mthInitPrintTool(null);
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    p_objSelectedValue.m_DtmInpatientDate,
                    p_objSelectedValue.m_DtmOpenDate);
                clsPrintInfo_OperationRecordDoctor objPrintInfo = new clsPrintInfo_OperationRecordDoctor();
                

                //objPrintInfo.m_dtmHISInDate = p_objSelectedValue.m_DtmInpatientDate;  //???
                objPrintInfo.m_dtmInPatientDate = p_objSelectedValue.m_DtmInpatientDate;
                objPrintInfo.m_dtmOpenDate =  p_objSelectedValue.m_DtmOpenDate;
                //objPrintInfo.m_strAge = p_objSelectedValue;           
                //objPrintInfo.m_strAreaName
                //objPrintInfo.m_strBedName
                //objPrintInfo.m_strDeptName=
                //objPrintInfo.m_strHISInPatientID=
                objPrintInfo.m_strInPatientID = p_objSelectedValue.m_StrInpatientId;
                //objPrintInfo.m_strPatientName =
                //objPrintInfo.m_strSex=p_objSelectedValue
                

                clsOperationRecordContentDoctor objContent = new clsOperationRecordContentDoctor();
                objContent = m_objDomain.m_objGetDeletedOperationRecordContent(p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), p_objSelectedValue.m_DtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //objPrintInfo.m_objContent = objContent;
                objPrintInfo.m_objSelectOperationRecordContent = objContent;
                //objPrintInfo.m_blnIsFirstPrint = false;

                objPrintTool.m_mthSetPrintContent(objPrintInfo);



                m_mthStartPrint();
                //ppdPrintPreview.Document = m_pdcPrintDocument;
                //ppdPrintPreview.ShowDialog(p_infOwner);
            }
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




	}
}

