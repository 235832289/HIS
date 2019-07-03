using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls ;
using iCareData ;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	public class frmEKGOrder : iCare.frmHRPBaseForm,PublicFunction
	{
		private System.Windows.Forms.TreeView trvTime;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		protected System.Windows.Forms.Label lblEKGNumber;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtEKGNumber;
		protected System.Windows.Forms.Label lblEKGMessage;
        protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label lblClinicalImpression;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalImpression;
		protected System.Windows.Forms.Label lblObeservationResult;
		private PinkieControls.ButtonXP cmdRequesterSign;
        private PinkieControls.ButtonXP cmdDoctorSign;
		private System.Windows.Forms.CheckBox chkHadOtherDrug;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtComeEK;
		private System.ComponentModel.IContainer components = null;


		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
		private clsEKGOrderDomain  m_objDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private bool blnCanDelete=true;              //是否可以执行删除操作
		private clsCommonUseToolCollection m_objCUTC;
		private clsEKGOrder m_objEKG=null;
        private com.digitalwave.controls.ctlRichTextBox txtResult;
		private clsPatient m_objCurrentPatient=null;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplicationDate;
        private TextBox txtRequesterSign;
        private TextBox txtDoctorSign;

        private clsEmployeeSignTool m_objSignTool;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		
		public frmEKGOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(this.txtRequesterSign);

			m_objDomain=new clsEKGOrderDomain(); 
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.trvTime
            //                                                                 ,this.txtClinicalImpression 
            //                                                                 ,this.txtResult 
            //                                                                 });	
			// TODO: Add any initialization after the InitializeComponent call

			m_dtsRept = m_dtsInitdsEKGOrderDataSet();

			trvTime.HideSelection=false;

			//签名常用值
            //m_objCUTC = new clsCommonUseToolCollection(this);
            //m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.cmdDoctorSign,this.cmdRequesterSign },
            //    new Control[]{this.txtDoctorSign,this.txtRequesterSign  },new int[]{1,1});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(cmdDoctorSign, txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(cmdRequesterSign, txtRequesterSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		private DataSet m_dtsRept;
		private bool blnCanSearch=true; 

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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEKGOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.lblEKGNumber = new System.Windows.Forms.Label();
            this.dtpApplicationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.txtEKGNumber = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblEKGMessage = new System.Windows.Forms.Label();
            this.lblClinicalImpression = new System.Windows.Forms.Label();
            this.txtClinicalImpression = new com.digitalwave.controls.ctlRichTextBox();
            this.chkHadOtherDrug = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComeEK = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.cmdRequesterSign = new PinkieControls.ButtonXP();
            this.lblObeservationResult = new System.Windows.Forms.Label();
            this.txtResult = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdDoctorSign = new PinkieControls.ButtonXP();
            this.txtRequesterSign = new System.Windows.Forms.TextBox();
            this.txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(327, 232);
            this.lblSex.Size = new System.Drawing.Size(32, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(313, 235);
            this.lblAge.Size = new System.Drawing.Size(30, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(327, 250);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(327, 229);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(321, 215);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(321, 220);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(321, 232);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(321, 220);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(324, 170);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(88, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(316, 251);
            this.txtInPatientID.Size = new System.Drawing.Size(90, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(324, 226);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(316, 251);
            this.m_txtBedNO.Size = new System.Drawing.Size(60, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(300, 251);
            this.m_cboArea.Size = new System.Drawing.Size(112, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(324, 170);
            this.m_lsvPatientName.Size = new System.Drawing.Size(84, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(330, 170);
            this.m_lsvBedNO.Size = new System.Drawing.Size(82, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(300, 250);
            this.m_cboDept.Size = new System.Drawing.Size(112, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(321, 212);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(316, 232);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(330, 232);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(330, 205);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(369, 224);
            this.m_lblForTitle.Text = "心电图申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(432, 240);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 59);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.trvTime);
            this.m_pnlNewBase.Controls.Add(this.dtpApplicationDate);
            this.m_pnlNewBase.Controls.Add(this.lblOperationBeginTimeTitle);
            this.m_pnlNewBase.Controls.Add(this.txtEKGNumber);
            this.m_pnlNewBase.Controls.Add(this.lblEKGNumber);
            this.m_pnlNewBase.Location = new System.Drawing.Point(5, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 86);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblEKGNumber, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtEKGNumber, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblOperationBeginTimeTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.dtpApplicationDate, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.trvTime, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(195, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(594, 56);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(0, 29);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(194, 55);
            this.trvTime.TabIndex = 10;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(198, 62);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 1000000002;
            this.lblOperationBeginTimeTitle.Text = "申请日期:";
            // 
            // lblEKGNumber
            // 
            this.lblEKGNumber.AutoSize = true;
            this.lblEKGNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEKGNumber.Location = new System.Drawing.Point(486, 62);
            this.lblEKGNumber.Name = "lblEKGNumber";
            this.lblEKGNumber.Size = new System.Drawing.Size(70, 14);
            this.lblEKGNumber.TabIndex = 1000000004;
            this.lblEKGNumber.Text = "心电图号:";
            // 
            // dtpApplicationDate
            // 
            this.dtpApplicationDate.BorderColor = System.Drawing.Color.Black;
            this.dtpApplicationDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplicationDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplicationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplicationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplicationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplicationDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplicationDate.Location = new System.Drawing.Point(266, 59);
            this.dtpApplicationDate.m_BlnOnlyTime = false;
            this.dtpApplicationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplicationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplicationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplicationDate.Name = "dtpApplicationDate";
            this.dtpApplicationDate.ReadOnly = false;
            this.dtpApplicationDate.Size = new System.Drawing.Size(214, 22);
            this.dtpApplicationDate.TabIndex = 20;
            this.dtpApplicationDate.TextBackColor = System.Drawing.Color.White;
            this.dtpApplicationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // txtEKGNumber
            // 
            this.txtEKGNumber.BackColor = System.Drawing.Color.White;
            this.txtEKGNumber.BorderColor = System.Drawing.Color.Transparent;
            this.txtEKGNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEKGNumber.ForeColor = System.Drawing.Color.Black;
            this.txtEKGNumber.Location = new System.Drawing.Point(555, 58);
            this.txtEKGNumber.Name = "txtEKGNumber";
            this.txtEKGNumber.Size = new System.Drawing.Size(90, 23);
            this.txtEKGNumber.TabIndex = 30;
            // 
            // lblEKGMessage
            // 
            this.lblEKGMessage.AutoSize = true;
            this.lblEKGMessage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEKGMessage.ForeColor = System.Drawing.Color.Black;
            this.lblEKGMessage.Location = new System.Drawing.Point(469, 96);
            this.lblEKGMessage.Name = "lblEKGMessage";
            this.lblEKGMessage.Size = new System.Drawing.Size(329, 14);
            this.lblEKGMessage.TabIndex = 1000000005;
            this.lblEKGMessage.Text = "(如患者以往曾在本院作上列检查：务请注明其号数)";
            // 
            // lblClinicalImpression
            // 
            this.lblClinicalImpression.AutoSize = true;
            this.lblClinicalImpression.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicalImpression.Location = new System.Drawing.Point(3, 97);
            this.lblClinicalImpression.Name = "lblClinicalImpression";
            this.lblClinicalImpression.Size = new System.Drawing.Size(287, 14);
            this.lblClinicalImpression.TabIndex = 1000000006;
            this.lblClinicalImpression.Text = "临床印象(请详细填写，包括检查及诊断意见)";
            // 
            // txtClinicalImpression
            // 
            this.txtClinicalImpression.AccessibleDescription = "病历";
            this.txtClinicalImpression.BackColor = System.Drawing.Color.White;
            this.txtClinicalImpression.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalImpression.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalImpression.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtClinicalImpression.Location = new System.Drawing.Point(6, 120);
            this.txtClinicalImpression.m_BlnIgnoreUserInfo = true;
            this.txtClinicalImpression.m_BlnPartControl = false;
            this.txtClinicalImpression.m_BlnReadOnly = false;
            this.txtClinicalImpression.m_BlnUnderLineDST = false;
            this.txtClinicalImpression.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalImpression.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalImpression.m_IntCanModifyTime = 6;
            this.txtClinicalImpression.m_IntPartControlLength = 0;
            this.txtClinicalImpression.m_IntPartControlStartIndex = 0;
            this.txtClinicalImpression.m_StrUserID = "";
            this.txtClinicalImpression.m_StrUserName = "";
            this.txtClinicalImpression.Name = "txtClinicalImpression";
            this.txtClinicalImpression.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalImpression.Size = new System.Drawing.Size(793, 168);
            this.txtClinicalImpression.TabIndex = 40;
            this.txtClinicalImpression.Text = "";
            // 
            // chkHadOtherDrug
            // 
            this.chkHadOtherDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHadOtherDrug.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHadOtherDrug.Location = new System.Drawing.Point(20, 290);
            this.chkHadOtherDrug.Name = "chkHadOtherDrug";
            this.chkHadOtherDrug.Size = new System.Drawing.Size(360, 22);
            this.chkHadOtherDrug.TabIndex = 50;
            this.chkHadOtherDrug.Tag = "44";
            this.chkHadOtherDrug.Text = "是否服用过洋地黄(或其他药物)剂量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 14);
            this.label1.TabIndex = 1000000009;
            this.label1.Text = "请注明患者是否能送来心电图室：";
            // 
            // txtComeEK
            // 
            this.txtComeEK.BackColor = System.Drawing.Color.White;
            this.txtComeEK.BorderColor = System.Drawing.Color.Transparent;
            this.txtComeEK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtComeEK.ForeColor = System.Drawing.Color.Black;
            this.txtComeEK.Location = new System.Drawing.Point(228, 310);
            this.txtComeEK.Name = "txtComeEK";
            this.txtComeEK.Size = new System.Drawing.Size(568, 23);
            this.txtComeEK.TabIndex = 60;
            // 
            // cmdRequesterSign
            // 
            this.cmdRequesterSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdRequesterSign.DefaultScheme = true;
            this.cmdRequesterSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRequesterSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRequesterSign.Hint = "";
            this.cmdRequesterSign.Location = new System.Drawing.Point(544, 338);
            this.cmdRequesterSign.Name = "cmdRequesterSign";
            this.cmdRequesterSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRequesterSign.Size = new System.Drawing.Size(84, 24);
            this.cmdRequesterSign.TabIndex = 70;
            this.cmdRequesterSign.Tag = "1";
            this.cmdRequesterSign.Text = "申请医生:";
            // 
            // lblObeservationResult
            // 
            this.lblObeservationResult.AutoSize = true;
            this.lblObeservationResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblObeservationResult.Location = new System.Drawing.Point(7, 346);
            this.lblObeservationResult.Name = "lblObeservationResult";
            this.lblObeservationResult.Size = new System.Drawing.Size(70, 14);
            this.lblObeservationResult.TabIndex = 1000000014;
            this.lblObeservationResult.Text = "观察结果:";
            // 
            // txtResult
            // 
            this.txtResult.AccessibleDescription = "病历";
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.ForeColor = System.Drawing.Color.Black;
            this.txtResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtResult.Location = new System.Drawing.Point(5, 366);
            this.txtResult.m_BlnIgnoreUserInfo = true;
            this.txtResult.m_BlnPartControl = false;
            this.txtResult.m_BlnReadOnly = false;
            this.txtResult.m_BlnUnderLineDST = false;
            this.txtResult.m_ClrDST = System.Drawing.Color.Red;
            this.txtResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtResult.m_IntCanModifyTime = 6;
            this.txtResult.m_IntPartControlLength = 0;
            this.txtResult.m_IntPartControlStartIndex = 0;
            this.txtResult.m_StrUserID = "";
            this.txtResult.m_StrUserName = "";
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtResult.Size = new System.Drawing.Size(794, 210);
            this.txtResult.TabIndex = 90;
            this.txtResult.Text = "";
            // 
            // cmdDoctorSign
            // 
            this.cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdDoctorSign.DefaultScheme = true;
            this.cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdDoctorSign.Hint = "";
            this.cmdDoctorSign.Location = new System.Drawing.Point(620, 581);
            this.cmdDoctorSign.Name = "cmdDoctorSign";
            this.cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdDoctorSign.Size = new System.Drawing.Size(58, 24);
            this.cmdDoctorSign.TabIndex = 100;
            this.cmdDoctorSign.Tag = "";
            this.cmdDoctorSign.Text = "医师:";
            // 
            // txtRequesterSign
            // 
            this.txtRequesterSign.Location = new System.Drawing.Point(634, 338);
            this.txtRequesterSign.Name = "txtRequesterSign";
            this.txtRequesterSign.ReadOnly = true;
            this.txtRequesterSign.Size = new System.Drawing.Size(100, 23);
            this.txtRequesterSign.TabIndex = 1000000015;
            // 
            // txtDoctorSign
            // 
            this.txtDoctorSign.Location = new System.Drawing.Point(684, 582);
            this.txtDoctorSign.Name = "txtDoctorSign";
            this.txtDoctorSign.ReadOnly = true;
            this.txtDoctorSign.Size = new System.Drawing.Size(100, 23);
            this.txtDoctorSign.TabIndex = 1000000015;
            // 
            // frmEKGOrder
            // 
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(805, 644);
            this.Controls.Add(this.lblObeservationResult);
            this.Controls.Add(this.txtRequesterSign);
            this.Controls.Add(this.txtDoctorSign);
            this.Controls.Add(this.lblClinicalImpression);
            this.Controls.Add(this.lblEKGMessage);
            this.Controls.Add(this.txtComeEK);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmdDoctorSign);
            this.Controls.Add(this.txtClinicalImpression);
            this.Controls.Add(this.cmdRequesterSign);
            this.Controls.Add(this.chkHadOtherDrug);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEKGOrder";
            this.Text = "心电图申请单";
            this.Load += new System.EventHandler(this.frmEKGOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.chkHadOtherDrug, 0);
            this.Controls.SetChildIndex(this.cmdRequesterSign, 0);
            this.Controls.SetChildIndex(this.txtClinicalImpression, 0);
            this.Controls.SetChildIndex(this.cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.txtResult, 0);
            this.Controls.SetChildIndex(this.txtComeEK, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblEKGMessage, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblClinicalImpression, 0);
            this.Controls.SetChildIndex(this.txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.txtRequesterSign, 0);
            this.Controls.SetChildIndex(this.lblObeservationResult, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmEKGOrder_Load(object sender, System.EventArgs e)
		{
            //m_lsvEmployee.Visible=false;
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			this.trvTime.SelectedNode=this.trvTime.Nodes[0];

			this.dtpApplicationDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpApplicationDate.m_mthResetSize();

		}

		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			//利用递归调用，读取并设置所有界面事件	
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
		
		}


		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
//					if(((Control)sender).Name=="m_lsvEmployee")
//					{
//						
//						m_lsvEmployee_DoubleClick(null,null);
//					}

			
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
					blnCanSearch =false;
					this.txtInPatientID.Text ="";
					blnCanSearch =true;
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_mthReadOnly(false);
					m_objEKG=null;
					m_objCurrentPatient=null;
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}


		#region PublicFunction 重载基类窗体
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return blnCanSearch;
			}
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;			
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objEKG=null;			

            //txtInPatientID.Tag = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString();
            //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;
			m_objCurrentPatient=p_objSelectedPatient ;
            //m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
			
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(dtpApplicationDate.Enabled==true)////Add New
					return true;
				else 
					return false;
		
			}
		}
		protected override long m_lngSubModify()
		{
			if(m_objEKG==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
			if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR != m_objEKG.strCreateUserID.Trim())
			{	//非申请医生无法更改记录
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}

			m_objEKG=objEKGOrderContent(false);

            if (m_objEKG == null)
            {
                return -1;
            }
			long lngSave=m_objDomain.lngSave(false,m_objEKG);

			if(lngSave>0)
			{
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
			try
			{
				m_objEKG=new clsEKGOrder();

				m_objEKG=objEKGOrderContent(true);

                if (m_objEKG == null)
                {
                    return -1;
                }

				long lngSave=m_objDomain.lngSave(true,m_objEKG);

				if(lngSave>0)
				{

                    clsPublicFunction.ShowInformationMessageBox("保存成功！");
					m_mthAddNodeToTrv(this.dtpApplicationDate.Value);

					//				
					//				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(1),strBookingInfo);	
					//			
					//				if(!blnSendRes)
					//					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

					return 1;
				}
				else 
				{
					clsPublicFunction.ShowInformationMessageBox("保存失败！");
					return -5;
				}
			}
			catch//(System.Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败!");
				return 0;
			}
			
		}
		
		protected override long m_lngSubPrint()
		{
			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptEKGRequest.rpt");
			}

			m_mthAddNewDataFordsEKGOrderDataSet(m_dtsRept);

			if(m_blnDirectPrint)
			{
				m_rpdOrderRept.PrintToPrinter(1,true,1,100);
			}
			else
			{
				frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//				objView.MdiParent = this.MdiParent;
				objView.ShowDialog();
			}
			return 1;
		


		}
		protected override long m_lngSubDelete()
		{
			if(blnCanDelete==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,无权删除他人的记录!");
				return 1;
			}
			if(m_objEKG==null || m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objEKG.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			
			//设置删除日期和删除者ID
			m_objEKG.m_dtmDeActivedDate=DateTime.Now;
			m_objEKG.m_strDeActivedOperatorID=MDIParent.OperatorID;

			long lngRes=m_objDomain.lngDelete(m_objEKG);

			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(DateTime.Parse(trnNode.Tag.ToString())==DateTime.Parse(m_objEKG.m_dteApplicationDate))
					{
						trnNode.Remove();
						break;
					}
				}
				m_mthClearUpSheet();
				m_mthReadOnly(false);
			}
			return lngRes ;
		}
	
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Save()
		{
			if(m_objCurrentPatient==null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
				return ;
			}
			m_lngSave();

		}

		public void Display()
		{
					

		}
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(string cardno,string sendcheckdate){}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			try
			{
				long m_lngRe=m_objDomain.lngGetEKGOrder(strInPatientID,strInPatientDate,strCreateDate,out m_objEKG);
				if(m_lngRe<0) 
					return ;

				//申请者只应该填写属于申请的那部分内容。对申请作出回复的人也只应该填写报告的那部分内容
				if(m_objEKG.strCreateUserID.Trim()!=clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim())
				{
					m_mthReadOnly(true);
				}
				else
				{
					m_mthReadOnly(false);
				}


                //m_objSignTool.m_mtSetSpecialEmployee(m_objEKG.m_strRequesterSign);

				//this.lblApplyDotorID.Tag=m_objEKG.strApplyDotorID;

				this.txtClinicalImpression.Text=m_objEKG.m_strClinicalImpression ;
				this.txtComeEK.Text=m_objEKG.m_strComeEK;
				this.txtResult.Text=m_objEKG.m_strResult;
				this.dtpApplicationDate.Value=DateTime.Parse(m_objEKG.m_dteApplicationDate);
				this.chkHadOtherDrug.Checked=m_objEKG.m_blnHadOtherDrug;
				this.txtEKGNumber.Text=m_objEKG.m_strEKGNumber;

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(m_objEKG.m_strDoctorSign, out objEmpVO);
                if (objEmpVO != null)
                {
                    this.txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                    this.txtDoctorSign.Tag = objEmpVO;
                }

                clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(m_objEKG.m_strRequesterSign, out objEmpVO1);
                if (objEmpVO != null)
                {
                    this.txtRequesterSign.Text = objEmpVO1.m_strLASTNAME_VCHR;
                    this.txtRequesterSign.Tag = objEmpVO1;
                }
			}
			catch//(Exception ex)
			{

			}
		}

		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{
			m_lngPrint();
		}
		
		#endregion PublicFunction
	
		
		private clsEKGOrder objEKGOrderContent(bool blnIsAddNew)
		{
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                return null;
            }

            if (txtRequesterSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请医师签名");
                return null;
            }

			if(blnIsAddNew==true)
			{	
				m_objEKG.strCreateUserID =clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                m_objEKG.strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objEKG.strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
				m_objEKG.strCreateDate =this.dtpApplicationDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); 

			}

            m_objEKG.m_strRequesterSign = ((clsEmrEmployeeBase_VO)txtRequesterSign.Tag).m_strEMPID_CHR;
			m_objEKG.m_blnHadOtherDrug=chkHadOtherDrug.Checked ;
			m_objEKG.m_dteApplicationDate=dtpApplicationDate.Value.ToString();
			m_objEKG.m_strClinicalImpression=txtClinicalImpression.Text.Trim();
			if(txtDoctorSign.Tag!=null)
			{
                m_objEKG.m_strDoctorSign = ((clsEmrEmployeeBase_VO)txtDoctorSign.Tag).m_strEMPID_CHR;
			}
			m_objEKG.m_strEKGNumber=txtEKGNumber.Text.Trim();
			m_objEKG.m_strResult=txtResult.Text.Trim();
			m_objEKG.m_strComeEK=txtComeEK.Text.Trim();

			return m_objEKG;
		}


		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			try
			{
				string strDate=p_dtmAdd.ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =p_dtmAdd;
				if(trvTime.Nodes[0].Nodes.Count==0)
					trvTime.Nodes[0].Nodes.Add(trnDate);
				else 
				{
					for(int i=0;i<trvTime.Nodes[0].Nodes.Count;i++)
					{
						if(trnDate.Text.CompareTo (trvTime.Nodes[0].Nodes[i].Text)>0)
						{
							trvTime.Nodes[0].Nodes.Insert(i,trnDate);
							break;
						}
					}
				}
				trvTime.SelectedNode=trnDate ;
				this.trvTime.ExpandAll();
			}
			catch(Exception ex)
			{
				clsPublicFunction.ShowInformationMessageBox(ex.Message);
			}
		
		}
			

		private void m_mthClearUpSheet()
		{
			foreach(Control ctlTemp in this.Controls)
			{
				
				if((ctlTemp.GetType().Name =="ctlBorderTextBox" || ctlTemp.GetType().Name=="RichTextBox" )&& ctlTemp.Name!="txtInPatientID" && ctlTemp.Name!="m_txtPatientName" && ctlTemp.Name!="m_txtBedNO")
					ctlTemp.Text="";
				else if(ctlTemp.GetType().Name=="ctlRichTextBox")
                    ((com.digitalwave.controls.ctlRichTextBox)ctlTemp).m_mthClearText();				
			}
			this.chkHadOtherDrug.Checked=false;
            this.dtpApplicationDate.Value = DateTime.Now;
            this.dtpApplicationDate.Enabled = true;
            MDIParent.m_mthSetDefaulEmployee(txtRequesterSign);
            txtDoctorSign.Text = string.Empty;
            txtDoctorSign.Tag = null;
		}


		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName" && ctlText.Name != "m_txtApplicationID")
						ctlText.Enabled=false;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicationDate") 
						((ctlTimePicker)ctlText).Enabled=false;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = true;
					
					
				}
				blnCanDelete=false;
			}
			else
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
					
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID")
						ctlText.Enabled=true;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicationDate") 
						((ctlTimePicker)ctlText).Enabled=true;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = false;
										
				}
				blnCanDelete=true;

			}
		}
				
		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			
			try
			{
				if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
				string[] m_strAll;
				m_strAll=m_objDomain.strGetEKGOrderArrByPatientID(p_strInPatientID ,p_strInPatientDate);

				//在MidTier会给m_strAll值初始化长度为0
				if(m_strAll.Length>0)
				{
					this.trvTime.Nodes[0].Nodes.Clear();
					foreach(string m_strTemp in m_strAll)
					{
			
						string strDate=DateTime.Parse(m_strTemp).ToString("yyyy年MM月dd日 HH:mm:ss");
						TreeNode trnDate=new TreeNode(strDate);
						trnDate.Tag =m_strTemp;
						this.trvTime.Nodes[0].Nodes.Add(trnDate );
					
					}
				}
				else
				{
					m_mthSetDefaultValue(m_objCurrentPatient);
					return;
				}
			
				this.trvTime.ExpandAll();
				this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];	
			}
			catch//(System.Exception ex)
			{
//				MessageBox.Show(ex.Message);
			}
		}


		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmSelectedInDate.ToString());
			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
			{
//				this.m_txtParticular.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.m_txtClinic.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			}		
		}


		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objEKG  =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpApplicationDate.Enabled =true;
			if(this.trvTime.SelectedNode.Tag.ToString()!="0" && m_ObjCurrentEmrPatientSession != null)
			{
                Display(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), trvTime.SelectedNode.Tag.ToString());
				this.dtpApplicationDate.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpApplicationDate.Enabled =false;
				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpApplicationDate.Value=DateTime.Now;
//				this.lblApplyDotorID.Text=MDIParent.OperatorName;
//				this.lblApplyDotorID.Tag=MDIParent.OperatorID;

                if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
                {
				    m_mthSetDefaultValue(m_objCurrentPatient);
                }
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				
			}

			m_mthAddFormStatusForClosingSave();
		}
		

		#region 打印

		/*
		* DataSet : dsEKGOrder
		* DataTable : dtEKGOrder
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : PatientDepartment(string)
		* 	DataColumn : PatientBed(string)
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : ApplicationDate(string)
		* 	DataColumn : EKGNumber(string)
		* 	DataColumn : ClinicalImpression(string)
		* 	DataColumn : HadOtherDrug(string)
		* 	DataColumn : ComeEK(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : Result(string)
		* 	DataColumn : DoctorSign(string)
		* DataTable : dtEKGOrderEx
		* 	DataColumn : Field1(string)
		* 	DataColumn : Field2(string)
		* 	DataColumn : Field3(string)
		* 	DataColumn : Field4(string)
		* 	DataColumn : Field5(string)
		* 	DataColumn : Field6(string)
		* 	DataColumn : Field7(string)
		* 	DataColumn : Field8(string)
		* 	DataColumn : Field9(string)
		* 	DataColumn : Field10(string)
		*/ 
		private DataSet m_dtsInitdsEKGOrderDataSet()
		{
			DataSet dsdsEKGOrder = new DataSet("dsEKGOrder");

			DataTable dtdtEKGOrder = new DataTable("dtEKGOrder");

			DataColumn dcdtEKGOrderPatientName = new DataColumn("PatientName",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderPatientName);

			DataColumn dcdtEKGOrderPatientSex = new DataColumn("PatientSex",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderPatientSex);

			DataColumn dcdtEKGOrderPatientAge = new DataColumn("PatientAge",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderPatientAge);

			DataColumn dcdtEKGOrderPatientDepartment = new DataColumn("PatientDepartment",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderPatientDepartment);

			DataColumn dcdtEKGOrderPatientBed = new DataColumn("PatientBed",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderPatientBed);

			DataColumn dcdtEKGOrderInPatientID = new DataColumn("InPatientID",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderInPatientID);

			DataColumn dcdtEKGOrderApplicationDate = new DataColumn("ApplicationDate",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderApplicationDate);

			DataColumn dcdtEKGOrderEKGNumber = new DataColumn("EKGNumber",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderEKGNumber);

			DataColumn dcdtEKGOrderClinicalImpression = new DataColumn("ClinicalImpression",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderClinicalImpression);

			DataColumn dcdtEKGOrderHadOtherDrug = new DataColumn("HadOtherDrug",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderHadOtherDrug);

			DataColumn dcdtEKGOrderComeEK = new DataColumn("ComeEK",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderComeEK);

			DataColumn dcdtEKGOrderRequesterSign = new DataColumn("RequesterSign",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderRequesterSign);

			DataColumn dcdtEKGOrderResult = new DataColumn("Result",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderResult);

			DataColumn dcdtEKGOrderDoctorSign = new DataColumn("DoctorSign",typeof(string));

			dtdtEKGOrder.Columns.Add(dcdtEKGOrderDoctorSign);

			dsdsEKGOrder.Tables.Add(dtdtEKGOrder);

			#region 扩展字段
//			DataTable dtdtEKGOrderEx = new DataTable("dtEKGOrderEx");
//
//			DataColumn dcdtEKGOrderExField1 = new DataColumn("Field1",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField1);
//
//			DataColumn dcdtEKGOrderExField2 = new DataColumn("Field2",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField2);
//
//			DataColumn dcdtEKGOrderExField3 = new DataColumn("Field3",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField3);
//
//			DataColumn dcdtEKGOrderExField4 = new DataColumn("Field4",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField4);
//
//			DataColumn dcdtEKGOrderExField5 = new DataColumn("Field5",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField5);
//
//			DataColumn dcdtEKGOrderExField6 = new DataColumn("Field6",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField6);
//
//			DataColumn dcdtEKGOrderExField7 = new DataColumn("Field7",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField7);
//
//			DataColumn dcdtEKGOrderExField8 = new DataColumn("Field8",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField8);
//
//			DataColumn dcdtEKGOrderExField9 = new DataColumn("Field9",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField9);
//
//			DataColumn dcdtEKGOrderExField10 = new DataColumn("Field10",typeof(string));
//
//			dtdtEKGOrderEx.Columns.Add(dcdtEKGOrderExField10);
//
//			dsdsEKGOrder.Tables.Add(dtdtEKGOrderEx);

			#endregion

			return dsdsEKGOrder;
		}

		/*
		* DataSet : dsEKGOrder
		* DataTable : dtEKGOrder
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : PatientDepartment(string)
		* 	DataColumn : PatientBed(string)
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : ApplicationDate(string)
		* 	DataColumn : EKGNumber(string)
		* 	DataColumn : ClinicalImpression(string)
		* 	DataColumn : HadOtherDrug(string)
		* 	DataColumn : ComeEK(string)
		* 	DataColumn : RequesterSign(string)
		* 	DataColumn : Result(string)
		* 	DataColumn : DoctorSign(string)
		* DataTable : dtEKGOrderEx
		* 	DataColumn : Field1(string)
		* 	DataColumn : Field2(string)
		* 	DataColumn : Field3(string)
		* 	DataColumn : Field4(string)
		* 	DataColumn : Field5(string)
		* 	DataColumn : Field6(string)
		* 	DataColumn : Field7(string)
		* 	DataColumn : Field8(string)
		* 	DataColumn : Field9(string)
		* 	DataColumn : Field10(string)
		*/ 
		private void m_mthAddNewDataFordsEKGOrderDataSet(DataSet dsdsEKGOrder)
		{
			DataTable dtdtEKGOrder = dsdsEKGOrder.Tables["DTEKGORDER"];
			dtdtEKGOrder.Rows.Clear();

			object [] objdtEKGOrderDatas = new object[14];

			if(m_objEKG !=null && m_objCurrentPatient!=null && m_ObjCurrentEmrPatientSession != null)
			{
				objdtEKGOrderDatas[0] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
				objdtEKGOrderDatas[1] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
				objdtEKGOrderDatas[2] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objdtEKGOrderDatas[3] = m_ObjCurrentEmrPatientSession.m_strAreaName;
				objdtEKGOrderDatas[4] = string.Empty;
                objdtEKGOrderDatas[5] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
				objdtEKGOrderDatas[6] =DateTime.Parse(m_objEKG.m_dteApplicationDate).ToString("");
				objdtEKGOrderDatas[7] = m_objEKG.m_strEKGNumber ;
				objdtEKGOrderDatas[8] = m_objEKG.m_strClinicalImpression ;
				objdtEKGOrderDatas[9] = (m_objEKG.m_blnHadOtherDrug ? "√" : "");
				objdtEKGOrderDatas[10] = m_objEKG.m_strComeEK;
				objdtEKGOrderDatas[11] = txtRequesterSign.Text;
				objdtEKGOrderDatas[12] = m_objEKG.m_strResult;
				objdtEKGOrderDatas[13] = txtDoctorSign.Text;
			}
			else 
			{
				for(int i=0;i<objdtEKGOrderDatas.Length-1;i++)
					objdtEKGOrderDatas[i]="";
			}

			dtdtEKGOrder.Rows.Add(objdtEKGOrderDatas);

			m_rpdOrderRept.Database.Tables["DTEKGORDER"].SetDataSource(dtdtEKGOrder);

			m_rpdOrderRept.Refresh();

			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();



//			DataTable dtdtEKGOrderEx = dsdsEKGOrder.Tables["DTEKGORDEREX"];
			//dtdtEKGOrderEx.Rows.Clear();

//			object [] objdtEKGOrderExDatas = new object[10];

			//objdtEKGOrderExDatas[0] = ;
			//objdtEKGOrderExDatas[1] = ;
			//objdtEKGOrderExDatas[2] = ;
			//objdtEKGOrderExDatas[3] = ;
			//objdtEKGOrderExDatas[4] = ;
			//objdtEKGOrderExDatas[5] = ;
			//objdtEKGOrderExDatas[6] = ;
			//objdtEKGOrderExDatas[7] = ;
			//objdtEKGOrderExDatas[8] = ;
			//objdtEKGOrderExDatas[9] = ;
//			dtdtEKGOrderEx.Rows.Add(objdtEKGOrderExDatas);
//			.Database.Tables["DTEKGORDEREX"].SetDataSource(dtdtEKGOrderEx);
//
//			.Refresh();

			//MemoryStream objStream = new MemoryStream(300);
			//.Save(objStream,ImageFormat.Bmp);
			//object objImage = objStream.GetBuffer();
		}

		#endregion

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_mthClearUpSheet();

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objCurrentPatient = m_objBaseCurrentPatient;

            m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllTimeOfAPatient(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }
	}
}

