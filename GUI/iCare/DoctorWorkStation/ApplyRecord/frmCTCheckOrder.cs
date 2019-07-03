using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Xml;
using System.IO;
using System.Text;
using System.Data ;
using CrystalDecisions.CrystalReports.Engine ;
using iCareData;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	public class frmCTCheckOrder : iCare.frmHRPBaseForm,PublicFunction 
	{
		#region define 
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblResume;
		private System.Windows.Forms.Label lblClinic;
		private System.Windows.Forms.Label lblCheck;
		private System.Windows.Forms.Label lblResumeAsthma;
		private System.Windows.Forms.Label lblParticular;
		protected System.Windows.Forms.RichTextBox m_txtClinic;
		private System.Windows.Forms.Label lblBefore;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblIdea;
		protected System.Windows.Forms.RichTextBox m_txtIdea;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblWho;
		protected System.Windows.Forms.RichTextBox m_txtParticular;
		private System.Windows.Forms.Label lblPhone;
		protected System.Windows.Forms.RichTextBox m_txtCheckPart;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtApplyDotorID;
		private System.Windows.Forms.Label lblAddressContent;
		private System.Windows.Forms.Label lblTelContent;
		private System.Windows.Forms.Label lblOtherCheck;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtAdvanceID;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpAdvanceTime;
		private System.Windows.Forms.Label lblRecordTimeTitle;
		private System.Windows.Forms.Label labelCTNO;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplyTime;
        //private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.Label lblDeptName;
		private System.Windows.Forms.Label lblCheckMoney;
		private System.Windows.Forms.Label lblPhotoMonty;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtCheckMoneyContent;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtPhotoMontyContent;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtCTNO;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.GroupBox m_gpbReligion;
		private System.Windows.Forms.RadioButton m_rdbResumeNone;
		private System.Windows.Forms.RadioButton m_rdbResumeHave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton m_rdbResumeAsthmaHave;
		private System.Windows.Forms.RadioButton m_rdbResumeAsthmaNone;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton m_rdbWalk;
		private System.Windows.Forms.RadioButton m_rdbTool;
		private System.Windows.Forms.Button m_cmdSetLabCheckResult;
		private System.ComponentModel.IContainer components = null;
		#endregion
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtApplicationID;
		private System.Windows.Forms.Label lblApplicationID;
		private PinkieControls.ButtonXP m_cmdApplyDoc;
		private clsCommonUseToolCollection m_objCUTC;
		protected System.Windows.Forms.RichTextBox m_txtApplicationComment;
		private System.Windows.Forms.CheckBox m_chkNeedRequire;

        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
		
		private string m_strPatientID="";
		private string m_strPatientName="";
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lblCancer;
		private System.Windows.Forms.Label lblAKP;
		private System.Windows.Forms.Label lblRed;
		private System.Windows.Forms.Label lblFetus;
		private System.Windows.Forms.Label lblAlbumen;
		private System.Windows.Forms.Label lblLiver;
		protected System.Windows.Forms.RichTextBox m_txtCancer;
		protected System.Windows.Forms.RichTextBox m_txtAKP;
		protected System.Windows.Forms.RichTextBox m_txtRed;
		protected System.Windows.Forms.RichTextBox m_txtFetus;
		protected System.Windows.Forms.RichTextBox m_txtAlbumen;
		protected System.Windows.Forms.RichTextBox m_txtLiver;
		private System.Windows.Forms.Label lblEmiction;
		private System.Windows.Forms.Label lblPhlegm;
		private System.Windows.Forms.Label lblBloodDoop;
		private System.Windows.Forms.Label lblBlood;
		private System.Windows.Forms.Label lbl17;
		private System.Windows.Forms.Label lblFecula;
		protected System.Windows.Forms.RichTextBox m_txtEmiction;
		protected System.Windows.Forms.RichTextBox m_txtPhlegm;
		protected System.Windows.Forms.RichTextBox m_txtBloodDoop;
		protected System.Windows.Forms.RichTextBox m_txtBlood;
		protected System.Windows.Forms.RichTextBox m_txtPee17;
		protected System.Windows.Forms.RichTextBox m_txtFecula;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.Label lblUltrasonic;
		private System.Windows.Forms.Label lblscan;
		private System.Windows.Forms.Label lblPancreas;
		private System.Windows.Forms.Label lblBreast;
		private System.Windows.Forms.Label lblBladder;
		protected System.Windows.Forms.RichTextBox m_txtPancreas;
		protected System.Windows.Forms.RichTextBox m_txtScan;
		protected System.Windows.Forms.RichTextBox m_txtOther;
		protected System.Windows.Forms.RichTextBox m_txtUltrasonic;
		protected System.Windows.Forms.RichTextBox m_txtBladder;
		protected System.Windows.Forms.RichTextBox m_txtBreast;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView m_lsvJY_ItemChoice;
		private System.Windows.Forms.ColumnHeader clmPat_c_name;
		private System.Windows.Forms.ColumnHeader clmSendDate;
        private System.Windows.Forms.Label lblApplyDotorID;
        private TextBox m_txtSign;
		private string m_strClinicDiagnoses="";
		
		public frmCTCheckOrder(string p_strPatientID,string p_strPatientName,string p_strClinicDiagnoses):this()
		{
			if(p_strPatientID!=null)
				m_strPatientID=p_strPatientID;
			if(p_strPatientName!=null)
				m_strPatientName=p_strPatientName;
			if(p_strClinicDiagnoses!=null)
				m_strClinicDiagnoses=p_strClinicDiagnoses;
		}
		public frmCTCheckOrder()
		{
			InitializeComponent();

            //m_objSignTool.m_mthAddControl(m_txtSign);

			m_objDomain=new clsCTCheckOrderDomain(); 

			this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);

			m_dtsRept = m_dtsInitdtsCTCheckOrderDataSet();
		
			trvTime.HideSelection=false;

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdApplyDoc, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

		}

		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
		private clsCTCheckOrderDomain m_objDomain;
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private bool blnCanDelete=true;              //是否可以执行删除操作

		private clsCTCheckOrder m_objCT=null;
		private clsPatient m_objCurrentPatient=null;

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
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblResume = new System.Windows.Forms.Label();
            this.lblClinic = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.lblResumeAsthma = new System.Windows.Forms.Label();
            this.lblParticular = new System.Windows.Forms.Label();
            this.m_txtClinic = new System.Windows.Forms.RichTextBox();
            this.m_txtCheckPart = new System.Windows.Forms.RichTextBox();
            this.m_txtApplyDotorID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblBefore = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIdea = new System.Windows.Forms.Label();
            this.m_txtIdea = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblWho = new System.Windows.Forms.Label();
            this.m_txtAdvanceID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtParticular = new System.Windows.Forms.RichTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddressContent = new System.Windows.Forms.Label();
            this.lblTelContent = new System.Windows.Forms.Label();
            this.lblOtherCheck = new System.Windows.Forms.Label();
            this.dtpAdvanceTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblRecordTimeTitle = new System.Windows.Forms.Label();
            this.labelCTNO = new System.Windows.Forms.Label();
            this.dtpApplyTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblDeptName = new System.Windows.Forms.Label();
            this.lblCheckMoney = new System.Windows.Forms.Label();
            this.lblPhotoMonty = new System.Windows.Forms.Label();
            this.txtCheckMoneyContent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtPhotoMontyContent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtCTNO = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.m_gpbReligion = new System.Windows.Forms.GroupBox();
            this.m_rdbResumeHave = new System.Windows.Forms.RadioButton();
            this.m_rdbResumeNone = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_rdbResumeAsthmaHave = new System.Windows.Forms.RadioButton();
            this.m_rdbResumeAsthmaNone = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rdbWalk = new System.Windows.Forms.RadioButton();
            this.m_rdbTool = new System.Windows.Forms.RadioButton();
            this.m_cmdSetLabCheckResult = new System.Windows.Forms.Button();
            this.m_txtApplicationID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.m_cmdApplyDoc = new PinkieControls.ButtonXP();
            this.m_txtApplicationComment = new System.Windows.Forms.RichTextBox();
            this.m_chkNeedRequire = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblEmiction = new System.Windows.Forms.Label();
            this.lblPhlegm = new System.Windows.Forms.Label();
            this.lblBloodDoop = new System.Windows.Forms.Label();
            this.lblBlood = new System.Windows.Forms.Label();
            this.lbl17 = new System.Windows.Forms.Label();
            this.lblFecula = new System.Windows.Forms.Label();
            this.m_txtEmiction = new System.Windows.Forms.RichTextBox();
            this.m_txtPhlegm = new System.Windows.Forms.RichTextBox();
            this.m_txtBloodDoop = new System.Windows.Forms.RichTextBox();
            this.m_txtBlood = new System.Windows.Forms.RichTextBox();
            this.m_txtPee17 = new System.Windows.Forms.RichTextBox();
            this.m_txtFecula = new System.Windows.Forms.RichTextBox();
            this.lblCancer = new System.Windows.Forms.Label();
            this.lblAKP = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblFetus = new System.Windows.Forms.Label();
            this.lblAlbumen = new System.Windows.Forms.Label();
            this.lblLiver = new System.Windows.Forms.Label();
            this.m_txtCancer = new System.Windows.Forms.RichTextBox();
            this.m_txtAKP = new System.Windows.Forms.RichTextBox();
            this.m_txtRed = new System.Windows.Forms.RichTextBox();
            this.m_txtFetus = new System.Windows.Forms.RichTextBox();
            this.m_txtAlbumen = new System.Windows.Forms.RichTextBox();
            this.m_txtLiver = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_txtPancreas = new System.Windows.Forms.RichTextBox();
            this.m_txtScan = new System.Windows.Forms.RichTextBox();
            this.m_txtOther = new System.Windows.Forms.RichTextBox();
            this.m_txtUltrasonic = new System.Windows.Forms.RichTextBox();
            this.m_txtBladder = new System.Windows.Forms.RichTextBox();
            this.m_txtBreast = new System.Windows.Forms.RichTextBox();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblUltrasonic = new System.Windows.Forms.Label();
            this.lblscan = new System.Windows.Forms.Label();
            this.lblPancreas = new System.Windows.Forms.Label();
            this.lblBreast = new System.Windows.Forms.Label();
            this.lblBladder = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_lsvJY_ItemChoice = new System.Windows.Forms.ListView();
            this.clmPat_c_name = new System.Windows.Forms.ColumnHeader();
            this.clmSendDate = new System.Windows.Forms.ColumnHeader();
            this.lblApplyDotorID = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.m_gpbReligion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(275, 205);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(276, 205);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(228, 235);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(226, 250);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(275, 205);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(276, 205);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(275, 205);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(228, 205);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(276, 205);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(144, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(276, 205);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(276, 202);
            this.m_txtPatientName.Size = new System.Drawing.Size(84, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(276, 205);
            this.m_txtBedNO.Size = new System.Drawing.Size(92, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(276, 205);
            this.m_cboArea.Size = new System.Drawing.Size(160, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(288, 205);
            this.m_lsvPatientName.Size = new System.Drawing.Size(104, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(276, 205);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(276, 205);
            this.m_cboDept.Size = new System.Drawing.Size(160, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(228, 221);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(252)))), ((int)(((byte)(224)))), ((int)(((byte)(166)))));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(276, 277);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(278, 205);
            this.m_cmdNext.Size = new System.Drawing.Size(24, 20);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(276, 205);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(301, 277);
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 20);
            this.m_lblForTitle.Text = "CT检查申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(452, 246);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(722, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.txtCTNO);
            this.m_pnlNewBase.Controls.Add(this.labelCTNO);
            this.m_pnlNewBase.Controls.Add(this.dtpApplyTime);
            this.m_pnlNewBase.Controls.Add(this.lblApplicationID);
            this.m_pnlNewBase.Controls.Add(this.m_txtApplicationID);
            this.m_pnlNewBase.Controls.Add(this.lblRecordTimeTitle);
            this.m_pnlNewBase.Controls.Add(this.lblAddress);
            this.m_pnlNewBase.Controls.Add(this.lblAddressContent);
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 6);
            this.m_pnlNewBase.Size = new System.Drawing.Size(796, 113);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblAddressContent, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblAddress, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblRecordTimeTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtApplicationID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblApplicationID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.dtpApplyTime, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.labelCTNO, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtCTNO, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRelationPhone = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(601, 83);
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("宋体", 9F);
            this.lblAddress.Location = new System.Drawing.Point(391, 56);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(92, 29);
            this.lblAddress.TabIndex = 501;
            this.lblAddress.Text = "本市联系人单位或者地址:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResume
            // 
            this.lblResume.AutoSize = true;
            this.lblResume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResume.Location = new System.Drawing.Point(8, 27);
            this.lblResume.Name = "lblResume";
            this.lblResume.Size = new System.Drawing.Size(70, 14);
            this.lblResume.TabIndex = 503;
            this.lblResume.Text = "过敏病史:";
            this.lblResume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClinic
            // 
            this.lblClinic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinic.Location = new System.Drawing.Point(232, 128);
            this.lblClinic.Name = "lblClinic";
            this.lblClinic.Size = new System.Drawing.Size(20, 68);
            this.lblClinic.TabIndex = 511;
            this.lblClinic.Text = "临床诊断";
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheck.Location = new System.Drawing.Point(36, 219);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(91, 14);
            this.lblCheck.TabIndex = 513;
            this.lblCheck.Text = "申请检查部分";
            // 
            // lblResumeAsthma
            // 
            this.lblResumeAsthma.AutoSize = true;
            this.lblResumeAsthma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblResumeAsthma.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResumeAsthma.Location = new System.Drawing.Point(8, 96);
            this.lblResumeAsthma.Name = "lblResumeAsthma";
            this.lblResumeAsthma.Size = new System.Drawing.Size(70, 14);
            this.lblResumeAsthma.TabIndex = 517;
            this.lblResumeAsthma.Text = "哮喘病史:";
            this.lblResumeAsthma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblParticular
            // 
            this.lblParticular.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParticular.Location = new System.Drawing.Point(232, 24);
            this.lblParticular.Name = "lblParticular";
            this.lblParticular.Size = new System.Drawing.Size(20, 96);
            this.lblParticular.TabIndex = 518;
            this.lblParticular.Text = "详细病历及体征";
            // 
            // m_txtClinic
            // 
            this.m_txtClinic.AccessibleDescription = "临床诊断";
            this.m_txtClinic.BackColor = System.Drawing.Color.White;
            this.m_txtClinic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClinic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtClinic.ForeColor = System.Drawing.Color.Black;
            this.m_txtClinic.Location = new System.Drawing.Point(256, 124);
            this.m_txtClinic.Name = "m_txtClinic";
            this.m_txtClinic.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtClinic.Size = new System.Drawing.Size(492, 72);
            this.m_txtClinic.TabIndex = 570;
            this.m_txtClinic.Text = "";
            // 
            // m_txtCheckPart
            // 
            this.m_txtCheckPart.AccessibleDescription = "申请检查部位";
            this.m_txtCheckPart.BackColor = System.Drawing.Color.White;
            this.m_txtCheckPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCheckPart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckPart.ForeColor = System.Drawing.Color.Black;
            this.m_txtCheckPart.Location = new System.Drawing.Point(132, 216);
            this.m_txtCheckPart.MaxLength = 8000;
            this.m_txtCheckPart.Multiline = false;
            this.m_txtCheckPart.Name = "m_txtCheckPart";
            this.m_txtCheckPart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCheckPart.Size = new System.Drawing.Size(356, 24);
            this.m_txtCheckPart.TabIndex = 580;
            this.m_txtCheckPart.Text = "";
            // 
            // m_txtApplyDotorID
            // 
            this.m_txtApplyDotorID.AccessibleDescription = "化验检查";
            this.m_txtApplyDotorID.AccessibleName = "NoDefault";
            this.m_txtApplyDotorID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtApplyDotorID.BorderColor = System.Drawing.Color.White;
            this.m_txtApplyDotorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtApplyDotorID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplyDotorID.ForeColor = System.Drawing.Color.White;
            this.m_txtApplyDotorID.Location = new System.Drawing.Point(256, 480);
            this.m_txtApplyDotorID.Name = "m_txtApplyDotorID";
            this.m_txtApplyDotorID.Size = new System.Drawing.Size(120, 26);
            this.m_txtApplyDotorID.TabIndex = 590;
            this.m_txtApplyDotorID.Visible = false;
            // 
            // lblBefore
            // 
            this.lblBefore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBefore.Location = new System.Drawing.Point(4, 284);
            this.lblBefore.Name = "lblBefore";
            this.lblBefore.Size = new System.Drawing.Size(24, 136);
            this.lblBefore.TabIndex = 676;
            this.lblBefore.Text = "既往检查结果";
            this.lblBefore.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(604, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 677;
            this.label9.Text = "化验检查";
            this.label9.Visible = false;
            // 
            // lblIdea
            // 
            this.lblIdea.AutoSize = true;
            this.lblIdea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIdea.Location = new System.Drawing.Point(12, 444);
            this.lblIdea.Name = "lblIdea";
            this.lblIdea.Size = new System.Drawing.Size(133, 14);
            this.lblIdea.TabIndex = 715;
            this.lblIdea.Text = "CT室接诊医生师意见";
            // 
            // m_txtIdea
            // 
            this.m_txtIdea.AccessibleDescription = "CT室接诊医生师意见:";
            this.m_txtIdea.BackColor = System.Drawing.Color.White;
            this.m_txtIdea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtIdea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtIdea.ForeColor = System.Drawing.Color.Black;
            this.m_txtIdea.Location = new System.Drawing.Point(8, 468);
            this.m_txtIdea.Name = "m_txtIdea";
            this.m_txtIdea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtIdea.Size = new System.Drawing.Size(793, 92);
            this.m_txtIdea.TabIndex = 780;
            this.m_txtIdea.Text = "";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDate.Location = new System.Drawing.Point(12, 573);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(91, 14);
            this.lblDate.TabIndex = 717;
            this.lblDate.Text = "预约扫描日期";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWho
            // 
            this.lblWho.AutoSize = true;
            this.lblWho.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWho.Location = new System.Drawing.Point(365, 567);
            this.lblWho.Name = "lblWho";
            this.lblWho.Size = new System.Drawing.Size(49, 14);
            this.lblWho.TabIndex = 723;
            this.lblWho.Text = "预约者";
            this.lblWho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtAdvanceID
            // 
            this.m_txtAdvanceID.AccessibleDescription = "预约者";
            this.m_txtAdvanceID.BackColor = System.Drawing.Color.White;
            this.m_txtAdvanceID.BorderColor = System.Drawing.Color.White;
            this.m_txtAdvanceID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAdvanceID.ForeColor = System.Drawing.Color.Black;
            this.m_txtAdvanceID.Location = new System.Drawing.Point(420, 564);
            this.m_txtAdvanceID.Name = "m_txtAdvanceID";
            this.m_txtAdvanceID.Size = new System.Drawing.Size(120, 23);
            this.m_txtAdvanceID.TabIndex = 800;
            // 
            // m_txtParticular
            // 
            this.m_txtParticular.AccessibleDescription = "详细病历及体征";
            this.m_txtParticular.BackColor = System.Drawing.Color.White;
            this.m_txtParticular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtParticular.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtParticular.ForeColor = System.Drawing.Color.Black;
            this.m_txtParticular.Location = new System.Drawing.Point(256, 20);
            this.m_txtParticular.Name = "m_txtParticular";
            this.m_txtParticular.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtParticular.Size = new System.Drawing.Size(492, 100);
            this.m_txtParticular.TabIndex = 560;
            this.m_txtParticular.Text = "";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhone.Location = new System.Drawing.Point(212, 278);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(70, 14);
            this.lblPhone.TabIndex = 752;
            this.lblPhone.Text = "联系电话:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhone.Visible = false;
            // 
            // lblAddressContent
            // 
            this.lblAddressContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddressContent.Location = new System.Drawing.Point(485, 56);
            this.lblAddressContent.Name = "lblAddressContent";
            this.lblAddressContent.Size = new System.Drawing.Size(216, 29);
            this.lblAddressContent.TabIndex = 501;
            this.lblAddressContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelContent
            // 
            this.lblTelContent.AutoSize = true;
            this.lblTelContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTelContent.Location = new System.Drawing.Point(282, 264);
            this.lblTelContent.Name = "lblTelContent";
            this.lblTelContent.Size = new System.Drawing.Size(0, 14);
            this.lblTelContent.TabIndex = 752;
            this.lblTelContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTelContent.Visible = false;
            // 
            // lblOtherCheck
            // 
            this.lblOtherCheck.AutoSize = true;
            this.lblOtherCheck.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherCheck.Location = new System.Drawing.Point(16, 244);
            this.lblOtherCheck.Name = "lblOtherCheck";
            this.lblOtherCheck.Size = new System.Drawing.Size(89, 20);
            this.lblOtherCheck.TabIndex = 677;
            this.lblOtherCheck.Text = "其他检查";
            this.lblOtherCheck.Visible = false;
            // 
            // dtpAdvanceTime
            // 
            this.dtpAdvanceTime.BorderColor = System.Drawing.Color.Black;
            this.dtpAdvanceTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpAdvanceTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpAdvanceTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpAdvanceTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpAdvanceTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpAdvanceTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpAdvanceTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAdvanceTime.Location = new System.Drawing.Point(104, 566);
            this.dtpAdvanceTime.m_BlnOnlyTime = false;
            this.dtpAdvanceTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpAdvanceTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAdvanceTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpAdvanceTime.Name = "dtpAdvanceTime";
            this.dtpAdvanceTime.ReadOnly = false;
            this.dtpAdvanceTime.Size = new System.Drawing.Size(168, 22);
            this.dtpAdvanceTime.TabIndex = 790;
            this.dtpAdvanceTime.TextBackColor = System.Drawing.Color.White;
            this.dtpAdvanceTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblRecordTimeTitle
            // 
            this.lblRecordTimeTitle.AutoSize = true;
            this.lblRecordTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordTimeTitle.Location = new System.Drawing.Point(193, 90);
            this.lblRecordTimeTitle.Name = "lblRecordTimeTitle";
            this.lblRecordTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblRecordTimeTitle.TabIndex = 6051;
            this.lblRecordTimeTitle.Text = "申请时间:";
            this.lblRecordTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCTNO
            // 
            this.labelCTNO.AllowDrop = true;
            this.labelCTNO.AutoSize = true;
            this.labelCTNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCTNO.ForeColor = System.Drawing.Color.Black;
            this.labelCTNO.Location = new System.Drawing.Point(653, 91);
            this.labelCTNO.Name = "labelCTNO";
            this.labelCTNO.Size = new System.Drawing.Size(42, 14);
            this.labelCTNO.TabIndex = 6048;
            this.labelCTNO.Text = "CT号:";
            this.labelCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpApplyTime
            // 
            this.dtpApplyTime.BackColor = System.Drawing.SystemColors.Control;
            this.dtpApplyTime.BorderColor = System.Drawing.Color.Black;
            this.dtpApplyTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplyTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.dtpApplyTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplyTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplyTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplyTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTime.Location = new System.Drawing.Point(261, 88);
            this.dtpApplyTime.m_BlnOnlyTime = false;
            this.dtpApplyTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplyTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplyTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplyTime.Name = "dtpApplyTime";
            this.dtpApplyTime.ReadOnly = false;
            this.dtpApplyTime.Size = new System.Drawing.Size(212, 22);
            this.dtpApplyTime.TabIndex = 520;
            this.dtpApplyTime.TextBackColor = System.Drawing.Color.White;
            this.dtpApplyTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblDeptName
            // 
            this.lblDeptName.AllowDrop = true;
            this.lblDeptName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptName.ForeColor = System.Drawing.Color.White;
            this.lblDeptName.Location = new System.Drawing.Point(275, 200);
            this.lblDeptName.Name = "lblDeptName";
            this.lblDeptName.Size = new System.Drawing.Size(12, 19);
            this.lblDeptName.TabIndex = 6048;
            this.lblDeptName.Visible = false;
            // 
            // lblCheckMoney
            // 
            this.lblCheckMoney.AllowDrop = true;
            this.lblCheckMoney.AutoSize = true;
            this.lblCheckMoney.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckMoney.ForeColor = System.Drawing.Color.Black;
            this.lblCheckMoney.Location = new System.Drawing.Point(417, 122);
            this.lblCheckMoney.Name = "lblCheckMoney";
            this.lblCheckMoney.Size = new System.Drawing.Size(70, 14);
            this.lblCheckMoney.TabIndex = 6048;
            this.lblCheckMoney.Text = "检 查 费:";
            this.lblCheckMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhotoMonty
            // 
            this.lblPhotoMonty.AllowDrop = true;
            this.lblPhotoMonty.AutoSize = true;
            this.lblPhotoMonty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhotoMonty.ForeColor = System.Drawing.Color.Black;
            this.lblPhotoMonty.Location = new System.Drawing.Point(629, 122);
            this.lblPhotoMonty.Name = "lblPhotoMonty";
            this.lblPhotoMonty.Size = new System.Drawing.Size(56, 14);
            this.lblPhotoMonty.TabIndex = 6048;
            this.lblPhotoMonty.Text = "造影费:";
            // 
            // txtCheckMoneyContent
            // 
            this.txtCheckMoneyContent.AccessibleDescription = "检查费";
            this.txtCheckMoneyContent.BackColor = System.Drawing.Color.White;
            this.txtCheckMoneyContent.BorderColor = System.Drawing.Color.White;
            this.txtCheckMoneyContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckMoneyContent.ForeColor = System.Drawing.Color.Black;
            this.txtCheckMoneyContent.Location = new System.Drawing.Point(501, 120);
            this.txtCheckMoneyContent.Name = "txtCheckMoneyContent";
            this.txtCheckMoneyContent.Size = new System.Drawing.Size(108, 23);
            this.txtCheckMoneyContent.TabIndex = 540;
            // 
            // txtPhotoMontyContent
            // 
            this.txtPhotoMontyContent.AccessibleDescription = "造影费";
            this.txtPhotoMontyContent.BackColor = System.Drawing.Color.White;
            this.txtPhotoMontyContent.BorderColor = System.Drawing.Color.White;
            this.txtPhotoMontyContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPhotoMontyContent.ForeColor = System.Drawing.Color.Black;
            this.txtPhotoMontyContent.Location = new System.Drawing.Point(693, 120);
            this.txtPhotoMontyContent.Name = "txtPhotoMontyContent";
            this.txtPhotoMontyContent.Size = new System.Drawing.Size(108, 23);
            this.txtPhotoMontyContent.TabIndex = 545;
            // 
            // txtCTNO
            // 
            this.txtCTNO.AccessibleDescription = "检查号";
            this.txtCTNO.BackColor = System.Drawing.Color.White;
            this.txtCTNO.BorderColor = System.Drawing.Color.White;
            this.txtCTNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCTNO.ForeColor = System.Drawing.Color.Black;
            this.txtCTNO.Location = new System.Drawing.Point(693, 87);
            this.txtCTNO.Name = "txtCTNO";
            this.txtCTNO.Size = new System.Drawing.Size(100, 23);
            this.txtCTNO.TabIndex = 535;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(5, 37);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(191, 80);
            this.trvTime.TabIndex = 510;
            // 
            // m_gpbReligion
            // 
            this.m_gpbReligion.Controls.Add(this.m_rdbResumeHave);
            this.m_gpbReligion.Controls.Add(this.m_rdbResumeNone);
            this.m_gpbReligion.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gpbReligion.Location = new System.Drawing.Point(80, 16);
            this.m_gpbReligion.Name = "m_gpbReligion";
            this.m_gpbReligion.Size = new System.Drawing.Size(132, 40);
            this.m_gpbReligion.TabIndex = 551;
            this.m_gpbReligion.TabStop = false;
            this.m_gpbReligion.Tag = "0";
            // 
            // m_rdbResumeHave
            // 
            this.m_rdbResumeHave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbResumeHave.Location = new System.Drawing.Point(76, 12);
            this.m_rdbResumeHave.Name = "m_rdbResumeHave";
            this.m_rdbResumeHave.Size = new System.Drawing.Size(52, 24);
            this.m_rdbResumeHave.TabIndex = 553;
            this.m_rdbResumeHave.TabStop = true;
            this.m_rdbResumeHave.Text = "有";
            // 
            // m_rdbResumeNone
            // 
            this.m_rdbResumeNone.Checked = true;
            this.m_rdbResumeNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbResumeNone.Location = new System.Drawing.Point(8, 12);
            this.m_rdbResumeNone.Name = "m_rdbResumeNone";
            this.m_rdbResumeNone.Size = new System.Drawing.Size(56, 24);
            this.m_rdbResumeNone.TabIndex = 552;
            this.m_rdbResumeNone.TabStop = true;
            this.m_rdbResumeNone.Text = "无";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_rdbResumeAsthmaHave);
            this.groupBox1.Controls.Add(this.m_rdbResumeAsthmaNone);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(80, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 40);
            this.groupBox1.TabIndex = 554;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "0";
            // 
            // m_rdbResumeAsthmaHave
            // 
            this.m_rdbResumeAsthmaHave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbResumeAsthmaHave.Location = new System.Drawing.Point(72, 12);
            this.m_rdbResumeAsthmaHave.Name = "m_rdbResumeAsthmaHave";
            this.m_rdbResumeAsthmaHave.Size = new System.Drawing.Size(40, 24);
            this.m_rdbResumeAsthmaHave.TabIndex = 556;
            this.m_rdbResumeAsthmaHave.TabStop = true;
            this.m_rdbResumeAsthmaHave.Text = "有";
            // 
            // m_rdbResumeAsthmaNone
            // 
            this.m_rdbResumeAsthmaNone.Checked = true;
            this.m_rdbResumeAsthmaNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbResumeAsthmaNone.Location = new System.Drawing.Point(12, 12);
            this.m_rdbResumeAsthmaNone.Name = "m_rdbResumeAsthmaNone";
            this.m_rdbResumeAsthmaNone.Size = new System.Drawing.Size(44, 24);
            this.m_rdbResumeAsthmaNone.TabIndex = 555;
            this.m_rdbResumeAsthmaNone.TabStop = true;
            this.m_rdbResumeAsthmaNone.Text = "无";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rdbWalk);
            this.groupBox2.Controls.Add(this.m_rdbTool);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(76, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 40);
            this.groupBox2.TabIndex = 557;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "0";
            // 
            // m_rdbWalk
            // 
            this.m_rdbWalk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbWalk.Location = new System.Drawing.Point(72, 12);
            this.m_rdbWalk.Name = "m_rdbWalk";
            this.m_rdbWalk.Size = new System.Drawing.Size(56, 24);
            this.m_rdbWalk.TabIndex = 558;
            this.m_rdbWalk.Text = "步行";
            // 
            // m_rdbTool
            // 
            this.m_rdbTool.Checked = true;
            this.m_rdbTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rdbTool.Location = new System.Drawing.Point(8, 12);
            this.m_rdbTool.Name = "m_rdbTool";
            this.m_rdbTool.Size = new System.Drawing.Size(56, 24);
            this.m_rdbTool.TabIndex = 559;
            this.m_rdbTool.TabStop = true;
            this.m_rdbTool.Text = "担架";
            // 
            // m_cmdSetLabCheckResult
            // 
            this.m_cmdSetLabCheckResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdSetLabCheckResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSetLabCheckResult.Location = new System.Drawing.Point(32, 304);
            this.m_cmdSetLabCheckResult.Name = "m_cmdSetLabCheckResult";
            this.m_cmdSetLabCheckResult.Size = new System.Drawing.Size(84, 32);
            this.m_cmdSetLabCheckResult.TabIndex = 595;
            this.m_cmdSetLabCheckResult.Text = "最新结果";
            this.m_cmdSetLabCheckResult.Visible = false;
            this.m_cmdSetLabCheckResult.Click += new System.EventHandler(this.m_cmdSetLabCheckResult_Click);
            this.m_cmdSetLabCheckResult.Leave += new System.EventHandler(this.m_lsvJY_ItemChoice_Leave);
            // 
            // m_txtApplicationID
            // 
            this.m_txtApplicationID.AccessibleDescription = "检查号";
            this.m_txtApplicationID.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationID.BorderColor = System.Drawing.Color.White;
            this.m_txtApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplicationID.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationID.Location = new System.Drawing.Point(545, 87);
            this.m_txtApplicationID.Name = "m_txtApplicationID";
            this.m_txtApplicationID.ReadOnly = true;
            this.m_txtApplicationID.Size = new System.Drawing.Size(108, 23);
            this.m_txtApplicationID.TabIndex = 530;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AllowDrop = true;
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationID.Location = new System.Drawing.Point(476, 91);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(70, 14);
            this.lblApplicationID.TabIndex = 6048;
            this.lblApplicationID.Text = "申请单号:";
            this.lblApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_cmdApplyDoc
            // 
            this.m_cmdApplyDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdApplyDoc.DefaultScheme = true;
            this.m_cmdApplyDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdApplyDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdApplyDoc.Hint = "";
            this.m_cmdApplyDoc.Location = new System.Drawing.Point(524, 232);
            this.m_cmdApplyDoc.Name = "m_cmdApplyDoc";
            this.m_cmdApplyDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdApplyDoc.Size = new System.Drawing.Size(116, 24);
            this.m_cmdApplyDoc.TabIndex = 10000088;
            this.m_cmdApplyDoc.Tag = "1";
            this.m_cmdApplyDoc.Text = "申请医师签名:";
            // 
            // m_txtApplicationComment
            // 
            this.m_txtApplicationComment.AccessibleDescription = "需要预约答复";
            this.m_txtApplicationComment.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtApplicationComment.Enabled = false;
            this.m_txtApplicationComment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplicationComment.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationComment.Location = new System.Drawing.Point(132, 248);
            this.m_txtApplicationComment.MaxLength = 150;
            this.m_txtApplicationComment.Multiline = false;
            this.m_txtApplicationComment.Name = "m_txtApplicationComment";
            this.m_txtApplicationComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtApplicationComment.Size = new System.Drawing.Size(356, 24);
            this.m_txtApplicationComment.TabIndex = 582;
            this.m_txtApplicationComment.Text = "";
            // 
            // m_chkNeedRequire
            // 
            this.m_chkNeedRequire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkNeedRequire.Location = new System.Drawing.Point(4, 248);
            this.m_chkNeedRequire.Name = "m_chkNeedRequire";
            this.m_chkNeedRequire.Size = new System.Drawing.Size(124, 24);
            this.m_chkNeedRequire.TabIndex = 581;
            this.m_chkNeedRequire.Text = "需要预约答复";
            this.m_chkNeedRequire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.CheckedChanged += new System.EventHandler(this.m_chkNeedRequire_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblEmiction);
            this.groupBox3.Controls.Add(this.lblPhlegm);
            this.groupBox3.Controls.Add(this.lblBloodDoop);
            this.groupBox3.Controls.Add(this.lblBlood);
            this.groupBox3.Controls.Add(this.lbl17);
            this.groupBox3.Controls.Add(this.lblFecula);
            this.groupBox3.Controls.Add(this.m_txtEmiction);
            this.groupBox3.Controls.Add(this.m_txtPhlegm);
            this.groupBox3.Controls.Add(this.m_txtBloodDoop);
            this.groupBox3.Controls.Add(this.m_txtBlood);
            this.groupBox3.Controls.Add(this.m_txtPee17);
            this.groupBox3.Controls.Add(this.m_txtFecula);
            this.groupBox3.Controls.Add(this.lblCancer);
            this.groupBox3.Controls.Add(this.lblAKP);
            this.groupBox3.Controls.Add(this.lblRed);
            this.groupBox3.Controls.Add(this.lblFetus);
            this.groupBox3.Controls.Add(this.lblAlbumen);
            this.groupBox3.Controls.Add(this.lblLiver);
            this.groupBox3.Controls.Add(this.m_txtCancer);
            this.groupBox3.Controls.Add(this.m_txtAKP);
            this.groupBox3.Controls.Add(this.m_txtRed);
            this.groupBox3.Controls.Add(this.m_txtFetus);
            this.groupBox3.Controls.Add(this.m_txtAlbumen);
            this.groupBox3.Controls.Add(this.m_txtLiver);
            this.groupBox3.Location = new System.Drawing.Point(4, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 264);
            this.groupBox3.TabIndex = 10000089;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "化验检查";
            // 
            // lblEmiction
            // 
            this.lblEmiction.AutoSize = true;
            this.lblEmiction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmiction.Location = new System.Drawing.Point(244, 235);
            this.lblEmiction.Name = "lblEmiction";
            this.lblEmiction.Size = new System.Drawing.Size(49, 14);
            this.lblEmiction.TabIndex = 724;
            this.lblEmiction.Text = "尿常规";
            this.lblEmiction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhlegm
            // 
            this.lblPhlegm.AutoSize = true;
            this.lblPhlegm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhlegm.Location = new System.Drawing.Point(228, 193);
            this.lblPhlegm.Name = "lblPhlegm";
            this.lblPhlegm.Size = new System.Drawing.Size(63, 14);
            this.lblPhlegm.TabIndex = 723;
            this.lblPhlegm.Text = "痰细胞学";
            this.lblPhlegm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBloodDoop
            // 
            this.lblBloodDoop.AutoSize = true;
            this.lblBloodDoop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBloodDoop.Location = new System.Drawing.Point(256, 151);
            this.lblBloodDoop.Name = "lblBloodDoop";
            this.lblBloodDoop.Size = new System.Drawing.Size(35, 14);
            this.lblBloodDoop.TabIndex = 722;
            this.lblBloodDoop.Text = "血沉";
            this.lblBloodDoop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlood
            // 
            this.lblBlood.AutoSize = true;
            this.lblBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlood.Location = new System.Drawing.Point(256, 109);
            this.lblBlood.Name = "lblBlood";
            this.lblBlood.Size = new System.Drawing.Size(35, 14);
            this.lblBlood.TabIndex = 721;
            this.lblBlood.Text = "血钾";
            this.lblBlood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl17
            // 
            this.lbl17.AutoSize = true;
            this.lbl17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl17.Location = new System.Drawing.Point(208, 67);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(84, 14);
            this.lbl17.TabIndex = 720;
            this.lbl17.Text = "尿17酮,17羟";
            this.lbl17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecula
            // 
            this.lblFecula.AutoSize = true;
            this.lblFecula.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFecula.Location = new System.Drawing.Point(244, 25);
            this.lblFecula.Name = "lblFecula";
            this.lblFecula.Size = new System.Drawing.Size(49, 14);
            this.lblFecula.TabIndex = 719;
            this.lblFecula.Text = "淀粉酶";
            this.lblFecula.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtEmiction
            // 
            this.m_txtEmiction.AccessibleDescription = "既往检查结果-尿常规";
            this.m_txtEmiction.BackColor = System.Drawing.Color.White;
            this.m_txtEmiction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEmiction.ForeColor = System.Drawing.Color.Black;
            this.m_txtEmiction.Location = new System.Drawing.Point(292, 234);
            this.m_txtEmiction.Multiline = false;
            this.m_txtEmiction.Name = "m_txtEmiction";
            this.m_txtEmiction.Size = new System.Drawing.Size(124, 20);
            this.m_txtEmiction.TabIndex = 727;
            this.m_txtEmiction.Text = "";
            // 
            // m_txtPhlegm
            // 
            this.m_txtPhlegm.AccessibleDescription = "既往检查结果-痰细胞学";
            this.m_txtPhlegm.BackColor = System.Drawing.Color.White;
            this.m_txtPhlegm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPhlegm.ForeColor = System.Drawing.Color.Black;
            this.m_txtPhlegm.Location = new System.Drawing.Point(292, 192);
            this.m_txtPhlegm.Multiline = false;
            this.m_txtPhlegm.Name = "m_txtPhlegm";
            this.m_txtPhlegm.Size = new System.Drawing.Size(124, 20);
            this.m_txtPhlegm.TabIndex = 726;
            this.m_txtPhlegm.Text = "";
            // 
            // m_txtBloodDoop
            // 
            this.m_txtBloodDoop.AccessibleDescription = "既往检查结果-血沉";
            this.m_txtBloodDoop.BackColor = System.Drawing.Color.White;
            this.m_txtBloodDoop.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBloodDoop.ForeColor = System.Drawing.Color.Black;
            this.m_txtBloodDoop.Location = new System.Drawing.Point(292, 150);
            this.m_txtBloodDoop.Multiline = false;
            this.m_txtBloodDoop.Name = "m_txtBloodDoop";
            this.m_txtBloodDoop.Size = new System.Drawing.Size(124, 20);
            this.m_txtBloodDoop.TabIndex = 725;
            this.m_txtBloodDoop.Text = "";
            // 
            // m_txtBlood
            // 
            this.m_txtBlood.AccessibleDescription = "既往检查结果-血钾";
            this.m_txtBlood.BackColor = System.Drawing.Color.White;
            this.m_txtBlood.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBlood.ForeColor = System.Drawing.Color.Black;
            this.m_txtBlood.Location = new System.Drawing.Point(292, 108);
            this.m_txtBlood.Multiline = false;
            this.m_txtBlood.Name = "m_txtBlood";
            this.m_txtBlood.Size = new System.Drawing.Size(124, 20);
            this.m_txtBlood.TabIndex = 718;
            this.m_txtBlood.Text = "";
            // 
            // m_txtPee17
            // 
            this.m_txtPee17.AccessibleDescription = "既往检查结果-尿17酮、17羟";
            this.m_txtPee17.BackColor = System.Drawing.Color.White;
            this.m_txtPee17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPee17.ForeColor = System.Drawing.Color.Black;
            this.m_txtPee17.Location = new System.Drawing.Point(292, 66);
            this.m_txtPee17.Multiline = false;
            this.m_txtPee17.Name = "m_txtPee17";
            this.m_txtPee17.Size = new System.Drawing.Size(124, 20);
            this.m_txtPee17.TabIndex = 717;
            this.m_txtPee17.Text = "";
            // 
            // m_txtFecula
            // 
            this.m_txtFecula.AccessibleDescription = "既往检查结果-淀粉酶";
            this.m_txtFecula.BackColor = System.Drawing.Color.White;
            this.m_txtFecula.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFecula.ForeColor = System.Drawing.Color.Black;
            this.m_txtFecula.Location = new System.Drawing.Point(292, 24);
            this.m_txtFecula.Multiline = false;
            this.m_txtFecula.Name = "m_txtFecula";
            this.m_txtFecula.Size = new System.Drawing.Size(124, 20);
            this.m_txtFecula.TabIndex = 716;
            this.m_txtFecula.Text = "";
            // 
            // lblCancer
            // 
            this.lblCancer.AutoSize = true;
            this.lblCancer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCancer.Location = new System.Drawing.Point(8, 235);
            this.lblCancer.Name = "lblCancer";
            this.lblCancer.Size = new System.Drawing.Size(63, 14);
            this.lblCancer.TabIndex = 715;
            this.lblCancer.Text = "癌胚抗原";
            this.lblCancer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAKP
            // 
            this.lblAKP.AutoSize = true;
            this.lblAKP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAKP.Location = new System.Drawing.Point(44, 193);
            this.lblAKP.Name = "lblAKP";
            this.lblAKP.Size = new System.Drawing.Size(28, 14);
            this.lblAKP.TabIndex = 714;
            this.lblAKP.Text = "AKP";
            this.lblAKP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRed.Location = new System.Drawing.Point(24, 151);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(49, 14);
            this.lblRed.TabIndex = 713;
            this.lblRed.Text = "胆红质";
            this.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFetus
            // 
            this.lblFetus.AutoSize = true;
            this.lblFetus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFetus.Location = new System.Drawing.Point(36, 109);
            this.lblFetus.Name = "lblFetus";
            this.lblFetus.Size = new System.Drawing.Size(35, 14);
            this.lblFetus.TabIndex = 712;
            this.lblFetus.Text = "胎甲";
            this.lblFetus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlbumen
            // 
            this.lblAlbumen.AutoSize = true;
            this.lblAlbumen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAlbumen.Location = new System.Drawing.Point(8, 67);
            this.lblAlbumen.Name = "lblAlbumen";
            this.lblAlbumen.Size = new System.Drawing.Size(63, 14);
            this.lblAlbumen.TabIndex = 711;
            this.lblAlbumen.Text = "蛋白电泳";
            this.lblAlbumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLiver
            // 
            this.lblLiver.AutoSize = true;
            this.lblLiver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLiver.Location = new System.Drawing.Point(36, 25);
            this.lblLiver.Name = "lblLiver";
            this.lblLiver.Size = new System.Drawing.Size(35, 14);
            this.lblLiver.TabIndex = 710;
            this.lblLiver.Text = "肝功";
            this.lblLiver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCancer
            // 
            this.m_txtCancer.AccessibleDescription = "既往检查结果-癌胚抗原";
            this.m_txtCancer.BackColor = System.Drawing.Color.White;
            this.m_txtCancer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCancer.ForeColor = System.Drawing.Color.Black;
            this.m_txtCancer.Location = new System.Drawing.Point(72, 234);
            this.m_txtCancer.Multiline = false;
            this.m_txtCancer.Name = "m_txtCancer";
            this.m_txtCancer.Size = new System.Drawing.Size(124, 20);
            this.m_txtCancer.TabIndex = 709;
            this.m_txtCancer.Text = "";
            // 
            // m_txtAKP
            // 
            this.m_txtAKP.AccessibleDescription = "既往检查结果-AKP";
            this.m_txtAKP.BackColor = System.Drawing.Color.White;
            this.m_txtAKP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAKP.ForeColor = System.Drawing.Color.Black;
            this.m_txtAKP.Location = new System.Drawing.Point(72, 192);
            this.m_txtAKP.Multiline = false;
            this.m_txtAKP.Name = "m_txtAKP";
            this.m_txtAKP.Size = new System.Drawing.Size(124, 20);
            this.m_txtAKP.TabIndex = 708;
            this.m_txtAKP.Text = "";
            // 
            // m_txtRed
            // 
            this.m_txtRed.AccessibleDescription = "既往检查结果-胆红质";
            this.m_txtRed.BackColor = System.Drawing.Color.White;
            this.m_txtRed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRed.ForeColor = System.Drawing.Color.Black;
            this.m_txtRed.Location = new System.Drawing.Point(72, 150);
            this.m_txtRed.Multiline = false;
            this.m_txtRed.Name = "m_txtRed";
            this.m_txtRed.Size = new System.Drawing.Size(124, 20);
            this.m_txtRed.TabIndex = 707;
            this.m_txtRed.Text = "";
            // 
            // m_txtFetus
            // 
            this.m_txtFetus.AccessibleDescription = "既往检查结果-胎甲";
            this.m_txtFetus.BackColor = System.Drawing.Color.White;
            this.m_txtFetus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFetus.ForeColor = System.Drawing.Color.Black;
            this.m_txtFetus.Location = new System.Drawing.Point(72, 108);
            this.m_txtFetus.Multiline = false;
            this.m_txtFetus.Name = "m_txtFetus";
            this.m_txtFetus.Size = new System.Drawing.Size(124, 20);
            this.m_txtFetus.TabIndex = 706;
            this.m_txtFetus.Text = "";
            // 
            // m_txtAlbumen
            // 
            this.m_txtAlbumen.AccessibleDescription = "蛋白电池";
            this.m_txtAlbumen.BackColor = System.Drawing.Color.White;
            this.m_txtAlbumen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtAlbumen.ForeColor = System.Drawing.Color.Black;
            this.m_txtAlbumen.Location = new System.Drawing.Point(72, 66);
            this.m_txtAlbumen.Multiline = false;
            this.m_txtAlbumen.Name = "m_txtAlbumen";
            this.m_txtAlbumen.Size = new System.Drawing.Size(124, 20);
            this.m_txtAlbumen.TabIndex = 705;
            this.m_txtAlbumen.Text = "";
            // 
            // m_txtLiver
            // 
            this.m_txtLiver.AccessibleDescription = "既往检查结果-肝功";
            this.m_txtLiver.BackColor = System.Drawing.Color.White;
            this.m_txtLiver.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLiver.ForeColor = System.Drawing.Color.Black;
            this.m_txtLiver.Location = new System.Drawing.Point(72, 24);
            this.m_txtLiver.Multiline = false;
            this.m_txtLiver.Name = "m_txtLiver";
            this.m_txtLiver.Size = new System.Drawing.Size(124, 20);
            this.m_txtLiver.TabIndex = 704;
            this.m_txtLiver.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_txtPancreas);
            this.groupBox4.Controls.Add(this.m_txtScan);
            this.groupBox4.Controls.Add(this.m_txtOther);
            this.groupBox4.Controls.Add(this.m_txtUltrasonic);
            this.groupBox4.Controls.Add(this.m_txtBladder);
            this.groupBox4.Controls.Add(this.m_txtBreast);
            this.groupBox4.Controls.Add(this.lblOther);
            this.groupBox4.Controls.Add(this.lblUltrasonic);
            this.groupBox4.Controls.Add(this.lblscan);
            this.groupBox4.Controls.Add(this.lblPancreas);
            this.groupBox4.Controls.Add(this.lblBreast);
            this.groupBox4.Controls.Add(this.lblBladder);
            this.groupBox4.Location = new System.Drawing.Point(432, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 264);
            this.groupBox4.TabIndex = 10000090;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其它检查";
            // 
            // m_txtPancreas
            // 
            this.m_txtPancreas.AccessibleDescription = "既往检查结果-胰胆管造影";
            this.m_txtPancreas.BackColor = System.Drawing.Color.White;
            this.m_txtPancreas.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPancreas.ForeColor = System.Drawing.Color.Black;
            this.m_txtPancreas.Location = new System.Drawing.Point(80, 54);
            this.m_txtPancreas.Name = "m_txtPancreas";
            this.m_txtPancreas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPancreas.Size = new System.Drawing.Size(248, 36);
            this.m_txtPancreas.TabIndex = 777;
            this.m_txtPancreas.Text = "";
            // 
            // m_txtScan
            // 
            this.m_txtScan.AccessibleDescription = "既往检查结果-同位素扫描";
            this.m_txtScan.BackColor = System.Drawing.Color.White;
            this.m_txtScan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtScan.ForeColor = System.Drawing.Color.Black;
            this.m_txtScan.Location = new System.Drawing.Point(80, 96);
            this.m_txtScan.Name = "m_txtScan";
            this.m_txtScan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtScan.Size = new System.Drawing.Size(248, 36);
            this.m_txtScan.TabIndex = 778;
            this.m_txtScan.Text = "";
            // 
            // m_txtOther
            // 
            this.m_txtOther.AccessibleDescription = "既往检查结果-其它";
            this.m_txtOther.BackColor = System.Drawing.Color.White;
            this.m_txtOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtOther.Location = new System.Drawing.Point(80, 222);
            this.m_txtOther.Name = "m_txtOther";
            this.m_txtOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOther.Size = new System.Drawing.Size(248, 36);
            this.m_txtOther.TabIndex = 782;
            this.m_txtOther.Text = "";
            // 
            // m_txtUltrasonic
            // 
            this.m_txtUltrasonic.AccessibleDescription = "既往检查结果-超声";
            this.m_txtUltrasonic.BackColor = System.Drawing.Color.White;
            this.m_txtUltrasonic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtUltrasonic.ForeColor = System.Drawing.Color.Black;
            this.m_txtUltrasonic.Location = new System.Drawing.Point(80, 180);
            this.m_txtUltrasonic.Name = "m_txtUltrasonic";
            this.m_txtUltrasonic.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtUltrasonic.Size = new System.Drawing.Size(248, 36);
            this.m_txtUltrasonic.TabIndex = 781;
            this.m_txtUltrasonic.Text = "";
            // 
            // m_txtBladder
            // 
            this.m_txtBladder.AccessibleDescription = "既往检查结果-膀胱镜";
            this.m_txtBladder.BackColor = System.Drawing.Color.White;
            this.m_txtBladder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBladder.ForeColor = System.Drawing.Color.Black;
            this.m_txtBladder.Location = new System.Drawing.Point(80, 138);
            this.m_txtBladder.Name = "m_txtBladder";
            this.m_txtBladder.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBladder.Size = new System.Drawing.Size(248, 36);
            this.m_txtBladder.TabIndex = 780;
            this.m_txtBladder.Text = "";
            // 
            // m_txtBreast
            // 
            this.m_txtBreast.AccessibleDescription = "既往检查结果-胸片";
            this.m_txtBreast.BackColor = System.Drawing.Color.White;
            this.m_txtBreast.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBreast.ForeColor = System.Drawing.Color.Black;
            this.m_txtBreast.Location = new System.Drawing.Point(80, 12);
            this.m_txtBreast.Name = "m_txtBreast";
            this.m_txtBreast.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBreast.Size = new System.Drawing.Size(248, 36);
            this.m_txtBreast.TabIndex = 776;
            this.m_txtBreast.Text = "";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOther.Location = new System.Drawing.Point(44, 231);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(35, 14);
            this.lblOther.TabIndex = 779;
            this.lblOther.Text = "其它";
            // 
            // lblUltrasonic
            // 
            this.lblUltrasonic.AutoSize = true;
            this.lblUltrasonic.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUltrasonic.Location = new System.Drawing.Point(44, 189);
            this.lblUltrasonic.Name = "lblUltrasonic";
            this.lblUltrasonic.Size = new System.Drawing.Size(35, 14);
            this.lblUltrasonic.TabIndex = 775;
            this.lblUltrasonic.Text = "超声";
            // 
            // lblscan
            // 
            this.lblscan.AutoSize = true;
            this.lblscan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblscan.Location = new System.Drawing.Point(4, 105);
            this.lblscan.Name = "lblscan";
            this.lblscan.Size = new System.Drawing.Size(77, 14);
            this.lblscan.TabIndex = 773;
            this.lblscan.Text = "同位素扫描";
            // 
            // lblPancreas
            // 
            this.lblPancreas.AutoSize = true;
            this.lblPancreas.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPancreas.Location = new System.Drawing.Point(4, 63);
            this.lblPancreas.Name = "lblPancreas";
            this.lblPancreas.Size = new System.Drawing.Size(77, 14);
            this.lblPancreas.TabIndex = 772;
            this.lblPancreas.Text = "胰胆管造影";
            // 
            // lblBreast
            // 
            this.lblBreast.AutoSize = true;
            this.lblBreast.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBreast.Location = new System.Drawing.Point(44, 21);
            this.lblBreast.Name = "lblBreast";
            this.lblBreast.Size = new System.Drawing.Size(35, 14);
            this.lblBreast.TabIndex = 771;
            this.lblBreast.Text = "胸片";
            // 
            // lblBladder
            // 
            this.lblBladder.AutoSize = true;
            this.lblBladder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBladder.Location = new System.Drawing.Point(32, 147);
            this.lblBladder.Name = "lblBladder";
            this.lblBladder.Size = new System.Drawing.Size(49, 14);
            this.lblBladder.TabIndex = 774;
            this.lblBladder.Text = "膀胱镜";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.lblResume);
            this.groupBox5.Controls.Add(this.lblResumeAsthma);
            this.groupBox5.Controls.Add(this.m_gpbReligion);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.m_txtParticular);
            this.groupBox5.Controls.Add(this.lblParticular);
            this.groupBox5.Controls.Add(this.lblClinic);
            this.groupBox5.Controls.Add(this.m_txtClinic);
            this.groupBox5.Location = new System.Drawing.Point(8, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(756, 204);
            this.groupBox5.TabIndex = 10000091;
            this.groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(220, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(2, 236);
            this.groupBox6.TabIndex = 571;
            this.groupBox6.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 309);
            this.tabControl1.TabIndex = 10000092;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtSign);
            this.tabPage1.Controls.Add(this.m_txtCheckPart);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.m_cmdApplyDoc);
            this.tabPage1.Controls.Add(this.lblCheck);
            this.tabPage1.Controls.Add(this.m_chkNeedRequire);
            this.tabPage1.Controls.Add(this.m_txtApplicationComment);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(789, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "普通信息";
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(644, 231);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(108, 23);
            this.m_txtSign.TabIndex = 10000098;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(789, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "检查信息";
            // 
            // m_lsvJY_ItemChoice
            // 
            this.m_lsvJY_ItemChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_lsvJY_ItemChoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvJY_ItemChoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPat_c_name,
            this.clmSendDate});
            this.m_lsvJY_ItemChoice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvJY_ItemChoice.ForeColor = System.Drawing.Color.White;
            this.m_lsvJY_ItemChoice.FullRowSelect = true;
            this.m_lsvJY_ItemChoice.GridLines = true;
            this.m_lsvJY_ItemChoice.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvJY_ItemChoice.Location = new System.Drawing.Point(256, 421);
            this.m_lsvJY_ItemChoice.Name = "m_lsvJY_ItemChoice";
            this.m_lsvJY_ItemChoice.Size = new System.Drawing.Size(282, 25);
            this.m_lsvJY_ItemChoice.TabIndex = 10000099;
            this.m_lsvJY_ItemChoice.UseCompatibleStateImageBehavior = false;
            this.m_lsvJY_ItemChoice.View = System.Windows.Forms.View.Details;
            this.m_lsvJY_ItemChoice.Visible = false;
            // 
            // clmPat_c_name
            // 
            this.clmPat_c_name.Text = "组合名称";
            this.clmPat_c_name.Width = 100;
            // 
            // clmSendDate
            // 
            this.clmSendDate.Text = "送检时间";
            this.clmSendDate.Width = 180;
            // 
            // lblApplyDotorID
            // 
            this.lblApplyDotorID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplyDotorID.Location = new System.Drawing.Point(660, 436);
            this.lblApplyDotorID.Name = "lblApplyDotorID";
            this.lblApplyDotorID.Size = new System.Drawing.Size(104, 24);
            this.lblApplyDotorID.TabIndex = 10000100;
            this.lblApplyDotorID.Visible = false;
            // 
            // frmCTCheckOrder
            // 
            this.AccessibleDescription = "CT检查申请单";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(816, 590);
            this.Controls.Add(this.lblCheckMoney);
            this.Controls.Add(this.lblPhotoMonty);
            this.Controls.Add(this.txtPhotoMontyContent);
            this.Controls.Add(this.txtCheckMoneyContent);
            this.Controls.Add(this.lblApplyDotorID);
            this.Controls.Add(this.m_txtIdea);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTelContent);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblWho);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblIdea);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblOtherCheck);
            this.Controls.Add(this.m_txtApplyDotorID);
            this.Controls.Add(this.m_txtAdvanceID);
            this.Controls.Add(this.m_cmdSetLabCheckResult);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.dtpAdvanceTime);
            this.Controls.Add(this.lblBefore);
            this.Controls.Add(this.lblDeptName);
            this.Controls.Add(this.m_lsvJY_ItemChoice);
            this.Name = "frmCTCheckOrder";
            this.Text = "CT检查申请单";
            this.Load += new System.EventHandler(this.frmCTCheckOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lsvJY_ItemChoice, 0);
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
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDeptName, 0);
            this.Controls.SetChildIndex(this.lblBefore, 0);
            this.Controls.SetChildIndex(this.dtpAdvanceTime, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_cmdSetLabCheckResult, 0);
            this.Controls.SetChildIndex(this.m_txtAdvanceID, 0);
            this.Controls.SetChildIndex(this.m_txtApplyDotorID, 0);
            this.Controls.SetChildIndex(this.lblOtherCheck, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.lblIdea, 0);
            this.Controls.SetChildIndex(this.lblDate, 0);
            this.Controls.SetChildIndex(this.lblWho, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblTelContent, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_txtIdea, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.lblApplyDotorID, 0);
            this.Controls.SetChildIndex(this.txtCheckMoneyContent, 0);
            this.Controls.SetChildIndex(this.txtPhotoMontyContent, 0);
            this.Controls.SetChildIndex(this.lblPhotoMonty, 0);
            this.Controls.SetChildIndex(this.lblCheckMoney, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.m_gpbReligion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	
		#region 重载基类窗体
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
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objCT=null;

			if(p_objSelectedPatient != null)
			{
                //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString();
                //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;

				lblTelContent.Text  = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
				lblAddressContent.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrLinkManAddress ;

				m_objCurrentPatient=p_objSelectedPatient ;
				m_strPatientID = m_objCurrentPatient.m_StrInPatientID;
				//m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
			}
//			m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
            //m_mthLoadAllTimeOfAPatient(m_strPatientID);			
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				
				if(dtpApplyTime.Enabled==true)////Add New
					return true;
				else 
					return false;
		
			}
		}
		protected override long m_lngSubModify()
		{
			if(m_objCT==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
            if (clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim() != m_objCT.strCreateUserID.Trim())
			{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}

			ImageRequest objImageRequest=new ImageRequest();
			string m_strApplicationID="";

			m_objCT=objCTCheckOrderContent(false);
			objImageRequest=m_objSetImageRequestValue(this.m_objCT);
			
//			m_strApplicationID=m_objCT.strApplicationID;
			m_strApplicationID=m_txtApplicationID.Text;
			
//			if(m_strApplicationID=="")
//				clsPublicFunction.ShowInformationMessageBox("申请单号为空");

			long lngSave=m_objDomain.lngSave(m_objCT,false,objImageRequest,ref m_strApplicationID); 
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

            if (m_txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请者签名！");
                return -1;
            }
			ImageRequest m_objImageRequest=new ImageRequest();
			
			m_objCT=new clsCTCheckOrder();

			string m_strApplicationID="";
			
			m_objCT=objCTCheckOrderContent(true);
           	m_objImageRequest=this.m_objSetImageRequestValue(m_objCT) ;

			long lngSave=m_objDomain.lngSave(m_objCT,true,m_objImageRequest,ref m_strApplicationID); 

			if(lngSave>0)
			{
				
				m_mthAddNodeToTrv(this.dtpApplyTime.Value);
				m_txtApplicationID.Text = m_strApplicationID;
				m_objCT.strApplicationID = m_strApplicationID;

				string strBookingInfo = "申请单号："+m_strApplicationID+"\r\n姓名："+m_objImageRequest.m_strPatientName+"\r\n住院号："+m_objImageRequest.m_strInPatientID+"\r\n检查部位："+m_objImageRequest.m_strCheckPart;

				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(1),strBookingInfo);	
			
				if(!blnSendRes)
					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
				return -5;
			}
			
		}
		
		protected override long m_lngSubPrint()
		{
			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptCTCheckOrder.rpt");
			}

			m_mthAddNewDataFordtsCTCheckOrderDataSet(m_dtsRept);
			
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
			if(m_objCT==null || m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;
            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objCT.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objCT.strInPatientID,m_objCT.strInPatientDate,m_objCT.strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objCT.strCreateDate)
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
		#endregion 
		
		# region PublicFuction

		public void Save()
		{
//			if(m_objCurrentPatient==null)
//			{
//				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
//				return ;
//			}
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
			m_objCT=m_objDomain.objDisplay( strInPatientID,strInPatientDate,strCreateDate);
			if(m_objCT==null) 
				return ;

			if(m_objCT.strCreateUserID.Trim()!=clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim())
			{
				m_mthReadOnly(true);
			}
			else
			{
				m_mthReadOnly(false);
			}

            this.lblApplyDotorID.Text = new clsEmployee(m_objCT.strApplyDotorID).m_StrFirstName;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objCT.strApplyDotorID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO;
            }

			this.lblApplyDotorID.Tag=m_objCT.strApplyDotorID;

			m_txtApplicationID.Text = m_objCT.strApplicationID;
			this.m_txtAdvanceID.Text=m_objCT.strAdvanceID ;
			this.dtpAdvanceTime.Text =m_objCT.strAdvanceTime ;
			this.m_txtAKP.Text =m_objCT.strAKP ;
			this.m_txtAlbumen.Text =m_objCT.strAlbumen ; 
			this.m_txtBladder.Text =m_objCT.strBladder ;
			this.m_txtBlood.Text =m_objCT.strBlood;
			this.m_txtBloodDoop.Text =m_objCT.strBloodDoop;
			this.m_txtBreast .Text =m_objCT.strBreast;
			this.m_txtCancer.Text =m_objCT.strCancer;
			this.txtCheckMoneyContent.Text =m_objCT.strCheckMoneyContent;
			this.m_txtCheckPart.Text =m_objCT.strCheckPart;
			this.m_txtClinic.Text =m_objCT.strClinic;
			this.dtpApplyTime.Text =m_objCT.strCreateDate;
			this.txtCTNO.Text=m_objCT.strCTNO;
			this.m_txtEmiction.Text =m_objCT.strEmiction;
			this.m_txtFecula.Text =m_objCT.strFecula;
			this.m_txtFetus.Text =m_objCT.strFetus;
			this.m_txtIdea.Text=m_objCT.strIdea;
			this.m_txtLiver.Text=m_objCT.strLiver;
			this.m_txtOther.Text=m_objCT.strOther;
			this.m_txtPancreas.Text=m_objCT.strPancreas;
			this.m_txtParticular.Text=m_objCT.strParticular;
			this.m_txtPee17.Text=m_objCT.strPee17;
			this.m_txtPhlegm.Text=m_objCT.strPhlegm;
			this.txtPhotoMontyContent.Text=m_objCT.strPhotoMontyContent;
			this.m_txtRed.Text=m_objCT.strRed;
			this.m_rdbResumeAsthmaHave.Checked=(m_objCT.strResumeAsthmaHave.Trim() == "1" ? true:false);
			this.m_rdbResumeAsthmaNone.Checked=(m_objCT.strResumeAsthmaNone.Trim() == "1" ? true:false);
			this.m_rdbResumeHave.Checked=(m_objCT.strResumeHave.Trim() == "1" ? true:false);
			this.m_rdbResumeNone.Checked=(m_objCT.strResumeNone.Trim() == "1" ? true:false);
			this.m_txtScan.Text=m_objCT.strScan;
			this.m_rdbTool.Checked =(m_objCT.strTool.Trim() == "1" ? true:false);
			this.m_txtUltrasonic.Text=m_objCT.strUltrasonic;
			this.m_rdbWalk.Checked=(m_objCT.strWalk.Trim() == "1" ? true:false);

			m_chkNeedRequire.Checked = false;
			m_txtApplicationComment.Text = "";
		}

		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Print()
		{
			m_lngPrint();
		}
		
	
		#endregion
	
		
		// 将CT数据记录入影像表
		private ImageRequest m_objSetImageRequestValue(clsCTCheckOrder p_objCTCheckOrder)
		{
			ImageRequest m_objImageRequest=new ImageRequest();

			if(p_objCTCheckOrder!=null && m_ObjCurrentEmrPatientSession != null)
			{
				//构建ApplicationInfo

				string strApplicationInfo="";
				if(this.m_rdbResumeHave.Checked==true)
					strApplicationInfo="过敏病史:有"+","+"\n\r";
				else
					strApplicationInfo="过敏病史:无"+","+"\n\r";

				if(this.m_rdbResumeAsthmaHave.Checked==true)
					strApplicationInfo+="哮喘病史:有"+","+"\n\r";
				else
					strApplicationInfo+="哮喘病史:无"+","+"\n\r";

				if(this.m_txtParticular.Text.Trim()!="")
					strApplicationInfo+="详细病史及体征:"+this.m_txtParticular.Text.Trim()+","+"\n\r";

				strApplicationInfo+="化验检查(";

				if(this.m_txtLiver.Text.Trim()!="")
					strApplicationInfo+="肝功:"+this.m_txtLiver.Text.Trim()+",";
				if(this.m_txtFecula.Text.Trim()!="")
					strApplicationInfo+="淀粉酶:"+this.m_txtFecula.Text.Trim()+",";
				if(this.m_txtAlbumen.Text.Trim()!="")
					strApplicationInfo+="蛋白电泳:"+this.m_txtAlbumen.Text.Trim()+",";
				if(this.m_txtPee17.Text.Trim()!="")
					strApplicationInfo+="尿17酮、17羟:"+this.m_txtPee17.Text.Trim()+",";
				if(this.m_txtFetus.Text.Trim()!="")
					strApplicationInfo+="胎甲:"+this.m_txtFetus.Text.Trim()+",";
				if(this.m_txtBlood.Text.Trim()!="")
					strApplicationInfo+="血钾:"+this.m_txtBlood.Text.Trim()+",";
				if(this.m_txtRed.Text.Trim()!="")
					strApplicationInfo+="胆红质:"+this.m_txtRed.Text.Trim()+",";
				if(this.m_txtBloodDoop.Text.Trim()!="")
					strApplicationInfo+="血沉:"+this.m_txtBloodDoop.Text.Trim()+",";
				if(this.m_txtAKP.Text.Trim()!="")
					strApplicationInfo+="AKP:"+this.m_txtAKP.Text.Trim()+",";
				if(this.m_txtPhlegm.Text.Trim()!="")
					strApplicationInfo+="痰细胞学:"+this.m_txtPhlegm.Text.Trim()+",";
				if(this.m_txtCancer.Text.Trim()!="")
					strApplicationInfo+="癌胚抗原:"+this.m_txtCancer.Text.Trim()+",";
				if(this.m_txtEmiction.Text.Trim()!="")
					strApplicationInfo+="尿常规:"+this.m_txtEmiction.Text.Trim();

				strApplicationInfo+=") 其他检查(";

				if(this.m_txtBreast.Text.Trim()!="")
					strApplicationInfo+="胸片:"+this.m_txtBreast.Text.Trim()+",";
				if(this.m_txtPancreas.Text.Trim()!="")
					strApplicationInfo+="胰胆管造影:"+this.m_txtPancreas.Text.Trim()+",";
				if(this.m_txtScan.Text.Trim()!="")
					strApplicationInfo+="同位素扫描:"+this.m_txtScan.Text.Trim()+",";
				if(this.m_txtBladder.Text.Trim()!="")
					strApplicationInfo+="膀胱镜:"+this.m_txtBladder.Text.Trim()+",";
				if(this.m_txtUltrasonic.Text.Trim()!="")
					strApplicationInfo+="超声:"+this.m_txtUltrasonic.Text.Trim()+",";
				if(this.m_txtOther.Text.Trim()!="")
					strApplicationInfo+="其他:"+this.m_txtOther.Text.Trim();


				strApplicationInfo+=")";



				m_objImageRequest.m_strApplicationInfo=strApplicationInfo ;
				m_objImageRequest.m_strApplicationType="1";		//CT
				m_objImageRequest.m_strBedName=this.m_txtBedNO.Text;
				m_objImageRequest.m_strCheckPart=p_objCTCheckOrder.strCheckPart ;;	//申请检查部位
				m_objImageRequest.m_strCheckPurpose="";//objBUltraCheckOrder.m_strche
				m_objImageRequest.m_strDeptID=m_ObjCurrentEmrPatientSession.m_strAreaId ;
                m_objImageRequest.m_strDeptName = m_ObjCurrentEmrPatientSession.m_strAreaName;
				m_objImageRequest.m_strDiagnose=p_objCTCheckOrder.strClinic ;
				m_objImageRequest.m_strDoctorID =p_objCTCheckOrder.strCreateUserID;
				m_objImageRequest.m_strDoctorName  =m_txtSign.Text ;
				m_objImageRequest.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
				m_objImageRequest.m_strPatientBirth =m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy-MM-dd HH:mm:ss");
				m_objImageRequest.m_strPatientName =m_objCurrentPatient.m_StrName;
				m_objImageRequest.m_strPatientSex  =m_objCurrentPatient.m_StrSex ;
				m_objImageRequest.m_strRequestDateTime  =p_objCTCheckOrder.strCreateDate;
				m_objImageRequest.m_blnIfNeedRequire = m_chkNeedRequire.Checked;
				if(m_objImageRequest.m_blnIfNeedRequire)
				{
					m_objImageRequest.m_strApplicationComment = m_txtApplicationComment.Text;
				}
				else
				{
					m_objImageRequest.m_strApplicationComment = "";
				}

			}
			return m_objImageRequest;
		}

		private clsCTCheckOrder objCTCheckOrderContent(bool blnIsAddNew)
		{
			if (m_objCT==null)
				m_objCT=new clsCTCheckOrder() ;

            m_objCT.strApplyDotorID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
//			m_objCT.strApplyDotorID = m_txtSign.Text;
			if(blnIsAddNew==true)
			{	
				m_objCT.strCreateUserID =clsEMRLogin.LoginEmployee.m_strEMPID_CHR;
                m_objCT.strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objCT.strInPatientID = m_objCurrentPatient.m_StrEMRInPatientID;
//				m_objCT.strInPatientDate ="1900-01-01";
//				m_objCT.strInPatientID=m_strPatientID;

				m_objCT.strCreateDate =this.dtpApplyTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); 
////				if(lblApplyDotorID.Tag!=null)
////					m_objCT.strApplyDotorID=this.lblApplyDotorID.Tag.ToString();
////				else 
////					m_objCT.strApplyDotorID="";
			}
		
			m_objCT.strStatus ="0";
			m_objCT.strIfConfirm  ="0";
			
			m_objCT.strAdvanceID=this.m_txtAdvanceID.Text.Trim() ;
			m_objCT.strAdvanceTime=this.dtpAdvanceTime.Value.ToString("yyyy-MM-dd hh:mm:ss"); 
			m_objCT.strAKP=this.m_txtAKP.Text.Trim() ;
			
			m_objCT.strAlbumen=this.m_txtAlbumen.Text.Trim() ;
			m_objCT.strBladder=this.m_txtBladder.Text.Trim() ;
			
			m_objCT.strBloodDoop=this.m_txtBloodDoop.Text.Trim() ;
			m_objCT.strBreast=this.m_txtBreast.Text.Trim() ;
			m_objCT.strBlood=this.m_txtBlood.Text.Trim() ;
			
			m_objCT.strCancer=this.m_txtCancer.Text.Trim() ;
			m_objCT.strCheckMoneyContent=this.txtCheckMoneyContent.Text.Trim() ;
			m_objCT.strCheckPart=this.m_txtCheckPart.Text.Trim() ;
			
			m_objCT.strClinic=this.m_txtClinic.Text.Trim() ;
			m_objCT.strCTNO=this.txtCTNO.Text.Trim() ;
			m_objCT.strEmiction=this.m_txtEmiction.Text.Trim() ;
			
			m_objCT.strFecula=this.m_txtFecula.Text.Trim() ;
			m_objCT.strFetus=this.m_txtFetus.Text.Trim() ;
			m_objCT.strIdea=this.m_txtIdea.Text.Trim() ;
			
			m_objCT.strLiver=this.m_txtLiver.Text.Trim() ;
			m_objCT.strOther=this.m_txtOther.Text.Trim() ;
			m_objCT.strPancreas=this.m_txtPancreas.Text.Trim() ;
			
			m_objCT.strParticular=this.m_txtParticular.Text.Trim() ;
			m_objCT.strPee17=this.m_txtPee17.Text.Trim() ;
			m_objCT.strPhlegm=this.m_txtPhlegm.Text.Trim() ;

			m_objCT.strPhotoMontyContent=this.txtPhotoMontyContent.Text.Trim() ;
			m_objCT.strRed=this.m_txtRed.Text.Trim() ;
			m_objCT.strResumeAsthmaHave=(this.m_rdbResumeAsthmaHave.Checked ==true? "1":"0");
			
			m_objCT.strResumeAsthmaNone=(this.m_rdbResumeAsthmaNone.Checked ==true? "1":"0");
			m_objCT.strResumeHave=(this.m_rdbResumeHave.Checked ==true? "1":"0");
			m_objCT.strResumeNone=(this.m_rdbResumeNone.Checked ==true? "1":"0");

			m_objCT.strScan=this.m_txtScan.Text.Trim() ;
			m_objCT.strTool=(this.m_rdbTool.Checked ==true? "1":"0");

			m_objCT.strUltrasonic=this.m_txtUltrasonic.Text.Trim() ;
			
			m_objCT.strWalk=(this.m_rdbWalk.Checked ==true? "1":"0");

			return m_objCT;
		}

		
		private void frmCTCheckOrder_Load(object sender, System.EventArgs e)
		{
			
			if(m_strPatientID.Trim().Length==0 && MDIParent.s_ObjCurrentPatient!=null)
				m_strPatientID=MDIParent.s_ObjCurrentPatient.m_StrInPatientID;
			if(m_strPatientID.Trim().Length==0 && MDIParent.s_ObjCurrentPatient!=null)
				m_strPatientName=MDIParent.s_ObjCurrentPatient.m_StrName;

			m_lsvJY_ItemChoice.Visible=false;
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);
			if(this.trvTime.SelectedNode!=null)
			{
				this.trvTime.SelectedNode=this.trvTime.Nodes[0];
			}
			this.dtpApplyTime.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpApplyTime.m_mthResetSize();

			this.dtpAdvanceTime.m_EnmVisibleFlag = ctlTimePicker.enmDateTimeFlag.Hour;
			this.dtpAdvanceTime.m_mthResetSize();
			if(m_objCurrentPatient!=null)
			{
				this.m_mthSetPatientFormInfo(m_objCurrentPatient);
			}
//			m_txtSign.Text = MDIParent.OperatorName;
			txtCheckMoneyContent.Focus();
		}

		
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
//			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objCT =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpApplyTime.Enabled =true;
			this.m_txtSign.Enabled = true;
			if(this.trvTime.SelectedNode.Tag.ToString()!="0")
			{
				//Display(m_strPatientID,txtInPatientID.Tag.ToString(),trvTime.SelectedNode.Tag.ToString());
				Display(m_strPatientID,"",trvTime.SelectedNode.Tag.ToString());
				this.dtpApplyTime.Text =this.trvTime.SelectedNode.Tag.ToString();
                //this.m_txtSign.Text = new clsEmployee(m_objCT.strApplyDotorID).m_StrFirstName;
				this.dtpApplyTime.Enabled =false;
				this.m_txtSign.Enabled = false;
				
				//当前处于修改记录状态
//				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpApplyTime.Value=DateTime.Now;
//				this.lblApplyDotorID.Text=MDIParent.OperatorName;
//				this.lblApplyDotorID.Tag=MDIParent.OperatorID;
				this.dtpApplyTime.Enabled =true;

				m_mthSetDefaultValue(m_objCurrentPatient);
				//当前处于新增记录状态
//				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				
			}

			m_mthAddFormStatusForClosingSave();
		
		}
		
		
		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			
			if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
			DateTime [] m_dtmArr=
				m_objDomain .m_dtmGetTimeInfoOfAPatientArr(p_strInPatientID ,p_strInPatientDate);
			if(m_dtmArr==null) 
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}
			this.trvTime.Nodes[0].Nodes .Clear();
			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}
			
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}
		
		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID)
		{
			
			DateTime [] m_dtmArr=
				m_objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strInPatientID);
			if(m_dtmArr==null) 
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}
			this.trvTime.Nodes[0].Nodes .Clear();
			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}
			
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}
		
		private void m_mthClearUpSheet()
		{
			m_mthRecursiveClear(this);

			this.m_rdbResumeAsthmaNone.Checked=true;
			this.m_rdbWalk.Checked=true;
			this.m_rdbResumeNone.Checked=true;
			this.dtpApplyTime.Value=DateTime.Now;
			this.lblApplyDotorID.Text=MDIParent.OperatorName;
			this.lblApplyDotorID.Tag=MDIParent.OperatorID;
            //this.m_txtSign.Text = MDIParent.OperatorName;

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
		}

		/// <summary>
		/// 递归清空
		/// </summary>
		/// <param name="p_ctlInput"></param>
		private void m_mthRecursiveClear(Control p_ctlInput)
		{
			if(!p_ctlInput.HasChildren)
			{
				if((p_ctlInput.GetType().Name =="ctlBorderTextBox" || p_ctlInput.GetType().Name=="RichTextBox" )&& p_ctlInput.Name!="txtInPatientID" && p_ctlInput.Name!="m_txtPatientName" && p_ctlInput.Name!="m_txtBedNO")
					p_ctlInput.Text="";
				else if(p_ctlInput.GetType().Name=="ctlRichTextBox")
					((ctlRichTextBox)p_ctlInput).m_mthClearText();
			}

			foreach(Control ctl in p_ctlInput.Controls)
			{
				m_mthRecursiveClear(ctl);
			}
		}
		
		
		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
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
				
		

		private void m_mthReadOnly(bool blnIsReadOnly)
		{			
			foreach(Control ctlRichText in this.Controls )
			{
				string typeName = ctlRichText.GetType().Name;
				if(typeName =="CheckBox")
				{
					((CheckBox)ctlRichText).Enabled= ! blnIsReadOnly;
				
				}
				else if(typeName =="ctlBorderTextBox" && ctlRichText.Name!="txtInPatientID" && ctlRichText.Name!="m_txtBedNO" && ctlRichText.Name!="m_txtPatientName" && ctlRichText.Name != "m_txtApplicationID")
					((ctlBorderTextBox)ctlRichText).ReadOnly=blnIsReadOnly;
				else if(typeName =="RichTextBox")
					((RichTextBox)ctlRichText).ReadOnly=blnIsReadOnly;
				else if(typeName =="ctlRichTextBox")
                    ((com.digitalwave.controls.ctlRichTextBox)ctlRichText).m_BlnReadOnly = blnIsReadOnly;
				this.dtpAdvanceTime.Enabled= ! blnIsReadOnly;
				blnCanDelete= ! blnIsReadOnly;
			}			
		}
       
		
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
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					if(((Control)sender).Name=="m_lsvJY_ItemChoice")
					{
						
						m_lsvJY_ItemChoice_DoubleClick(null,null);
					}

			
					break;

					//				case 38:
					//				case 40:					
					//					if(sender.Name=="m_lsvJY_ItemChoice" )
					//					{
					//						if( m_lsvJY_ItemChoice.Items.Count>0 && m_lsvJY_ItemChoice.Visible)
					//						{
					//							m_lsvJY_ItemChoice.Items[0].Selected=true;
					//							m_lsvJY_ItemChoice.Focus();
					//						}							
					//					}
					//				break;	
					

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
					this.lblAddressContent.Text="";
					this.lblTelContent.Text="";
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_mthReadOnly(false);
					m_objCT=null;
					m_objCurrentPatient=null;
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion

		#region 打印
		/*
* DataSet : dtsCTCheckOrder
* DataTable : CTCheckOrder
* 	DataColumn : CTNO(string)
* 	DataColumn : CheckPart(string)
* 	DataColumn : CreateDate(string)
* 	DataColumn : CheckMoneyContent(string)
* 	DataColumn : PhotoMontyContent(string)
* 	DataColumn : PatientName(string)
* 	DataColumn : PatientSex(string)
* 	DataColumn : PatientAge(string)
* 	DataColumn : PatientDepartment(string)
* 	DataColumn : PatientBed(string)
* 	DataColumn : InPatientID(string)
* 	DataColumn : PatientAdress(string)
* 	DataColumn : PatientContactPlace(string)
* 	DataColumn : ResumeHave(string)
* 	DataColumn : ResumeNone(string)
* 	DataColumn : ResumeAsthmaHave(string)
* 	DataColumn : ResumeAsthmaNone(string)
* 	DataColumn : Tool(string)
* 	DataColumn : Walk(string)
* 	DataColumn : Particular(string)
* 	DataColumn : Clinic(string)
* 	DataColumn : ApplyDotorID(string)
* 	DataColumn : Liver(string)
* 	DataColumn : Albumen(string)
* 	DataColumn : Fetus(string)
* 	DataColumn : Red(string)
* 	DataColumn : AKP(string)
* 	DataColumn : Cancer(string)
* 	DataColumn : Fecula(string)
* 	DataColumn : Pee17(string)
* 	DataColumn : Blood(string)
* 	DataColumn : BloodDoop(string)
* 	DataColumn : Phlegm(string)
* 	DataColumn : Emiction(string)
* 	DataColumn : Breast(string)
* 	DataColumn : Pancreas(string)
* 	DataColumn : Scan(string)
* 	DataColumn : Bladder(string)
* 	DataColumn : Ultrasonic(string)
* 	DataColumn : Other(string)
* 	DataColumn : Idea(string)
* 	DataColumn : AdvanceTime(string)
* 	DataColumn : AdvanceID(string)
*/ 
		private DataSet m_dtsInitdtsCTCheckOrderDataSet()
		{
			DataSet dsdtsCTCheckOrder = new DataSet("dtsCTCheckOrder");

			DataTable dtCTCheckOrder = new DataTable("CTCheckOrder");

			DataColumn dcCTCheckOrderCTNO = new DataColumn("CTNO",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderCTNO);

			DataColumn dcCTCheckOrderCheckPart = new DataColumn("CheckPart",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderCheckPart);

			DataColumn dcCTCheckOrderCreateDate = new DataColumn("CreateDate",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderCreateDate);

			DataColumn dcCTCheckOrderCheckMoneyContent = new DataColumn("CheckMoneyContent",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderCheckMoneyContent);

			DataColumn dcCTCheckOrderPhotoMontyContent = new DataColumn("PhotoMontyContent",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPhotoMontyContent);

			DataColumn dcCTCheckOrderPatientName = new DataColumn("PatientName",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientName);

			DataColumn dcCTCheckOrderPatientSex = new DataColumn("PatientSex",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientSex);

			DataColumn dcCTCheckOrderPatientAge = new DataColumn("PatientAge",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientAge);

			DataColumn dcCTCheckOrderPatientDepartment = new DataColumn("PatientDepartment",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientDepartment);

			DataColumn dcCTCheckOrderPatientBed = new DataColumn("PatientBed",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientBed);

			DataColumn dcCTCheckOrderInPatientID = new DataColumn("InPatientID",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderInPatientID);

			DataColumn dcCTCheckOrderPatientAdress = new DataColumn("PatientAdress",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientAdress);

			DataColumn dcCTCheckOrderPatientContactPlace = new DataColumn("PatientContactPlace",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPatientContactPlace);

			DataColumn dcCTCheckOrderResumeHave = new DataColumn("ResumeHave",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderResumeHave);

			DataColumn dcCTCheckOrderResumeNone = new DataColumn("ResumeNone",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderResumeNone);

			DataColumn dcCTCheckOrderResumeAsthmaHave = new DataColumn("ResumeAsthmaHave",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderResumeAsthmaHave);

			DataColumn dcCTCheckOrderResumeAsthmaNone = new DataColumn("ResumeAsthmaNone",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderResumeAsthmaNone);

			DataColumn dcCTCheckOrderTool = new DataColumn("Tool",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderTool);

			DataColumn dcCTCheckOrderWalk = new DataColumn("Walk",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderWalk);

			DataColumn dcCTCheckOrderParticular = new DataColumn("Particular",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderParticular);

			DataColumn dcCTCheckOrderClinic = new DataColumn("Clinic",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderClinic);

			DataColumn dcCTCheckOrderApplyDotorID = new DataColumn("ApplyDotorID",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderApplyDotorID);

			DataColumn dcCTCheckOrderLiver = new DataColumn("Liver",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderLiver);

			DataColumn dcCTCheckOrderAlbumen = new DataColumn("Albumen",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderAlbumen);

			DataColumn dcCTCheckOrderFetus = new DataColumn("Fetus",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderFetus);

			DataColumn dcCTCheckOrderRed = new DataColumn("Red",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderRed);

			DataColumn dcCTCheckOrderAKP = new DataColumn("AKP",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderAKP);

			DataColumn dcCTCheckOrderCancer = new DataColumn("Cancer",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderCancer);

			DataColumn dcCTCheckOrderFecula = new DataColumn("Fecula",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderFecula);

			DataColumn dcCTCheckOrderPee17 = new DataColumn("Pee17",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPee17);

			DataColumn dcCTCheckOrderBlood = new DataColumn("Blood",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderBlood);

			DataColumn dcCTCheckOrderBloodDoop = new DataColumn("BloodDoop",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderBloodDoop);

			DataColumn dcCTCheckOrderPhlegm = new DataColumn("Phlegm",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPhlegm);

			DataColumn dcCTCheckOrderEmiction = new DataColumn("Emiction",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderEmiction);

			DataColumn dcCTCheckOrderBreast = new DataColumn("Breast",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderBreast);

			DataColumn dcCTCheckOrderPancreas = new DataColumn("Pancreas",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderPancreas);

			DataColumn dcCTCheckOrderScan = new DataColumn("Scan",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderScan);

			DataColumn dcCTCheckOrderBladder = new DataColumn("Bladder",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderBladder);

			DataColumn dcCTCheckOrderUltrasonic = new DataColumn("Ultrasonic",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderUltrasonic);

			DataColumn dcCTCheckOrderOther = new DataColumn("Other",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderOther);

			DataColumn dcCTCheckOrderIdea = new DataColumn("Idea",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderIdea);

			DataColumn dcCTCheckOrderAdvanceTime = new DataColumn("AdvanceTime",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderAdvanceTime);

			DataColumn dcCTCheckOrderAdvanceID = new DataColumn("AdvanceID",typeof(string));

			dtCTCheckOrder.Columns.Add(dcCTCheckOrderAdvanceID);

			dsdtsCTCheckOrder.Tables.Add(dtCTCheckOrder);

			return dsdtsCTCheckOrder;
		}

		/*
		* DataSet : dtsCTCheckOrder
		* DataTable : CTCheckOrder
		* 	DataColumn0 : CTNO(string)
		* 	DataColumn1 : CheckPart(string)
		* 	DataColumn2 : CreateDate(string)
		* 	DataColumn3 : CheckMoneyContent(string)
		* 	DataColumn4 : PhotoMontyContent(string)
		* 	DataColumn5 : PatientName(string)
		* 	DataColumn6 : PatientSex(string)
		* 	DataColumn7 : PatientAge(string)
		* 	DataColumn8 : PatientDepartment(string)
		* 	DataColumn9 : PatientBed(string)
		* 	DataColumn10 : InPatientID(string)
		* 	DataColumn11 : PatientAdress(string)
		* 	DataColumn12 : PatientContactPlace(string)
		* 	DataColumn13 : ResumeHave(string)
		* 	DataColumn14 : ResumeNone(string)
		* 	DataColumn15 : ResumeAsthmaHave(string)
		* 	DataColumn16 : ResumeAsthmaNone(string)
		* 	DataColumn17 : Tool(string)
		* 	DataColumn18 : Walk(string)
		* 	DataColumn19 : Particular(string)
		* 	DataColumn20 : Clinic(string)
		* 	DataColumn21 : ApplyDotorID(string)
		* 	DataColumn22 : Liver(string)
		* 	DataColumn23 : Albumen(string)
		* 	DataColumn24 : Fetus(string)
		* 	DataColumn25 : Red(string)
		* 	DataColumn26 : AKP(string)
		* 	DataColumn27 : Cancer(string)
		* 	DataColumn28 : Fecula(string)
		* 	DataColumn29 : Pee17(string)
		* 	DataColumn30 : Blood(string)
		* 	DataColumn31 : BloodDoop(string)
		* 	DataColumn32 : Phlegm(string)
		* 	DataColumn33 : Emiction(string)
		* 	DataColumn34 : Breast(string)
		* 	DataColumn35 : Pancreas(string)
		* 	DataColumn36 : Scan(string)
		* 	DataColumn37 : Bladder(string)
		* 	DataColumn38 : Ultrasonic(string)
		* 	DataColumn39 : Other(string)
		* 	DataColumn40 : Idea(string)
		* 	DataColumn41 : AdvanceTime(string)
		* 	DataColumn42 : AdvanceID(string)
		*/ 
		private void m_mthAddNewDataFordtsCTCheckOrderDataSet(DataSet dsdtsCTCheckOrder)
		{
			DataTable dtCTCheckOrder = dsdtsCTCheckOrder.Tables["CTCHECKORDER"];
			dtCTCheckOrder.Rows.Clear();

			object [] objCTCheckOrderDatas = new object[43];

			if(m_objCT!=null && m_objCurrentPatient!=null)
			{
				objCTCheckOrderDatas[0] =m_objCT.strCTNO;
				objCTCheckOrderDatas[1] =m_objCT.strCheckPart;
				//objCTCheckOrderDatas[1] =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName ;
				//objCTCheckOrderDatas[2] =DateTime.Parse(m_objCT.strCreateDate).ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmCTCheckOrder"))+"          申请单号："+m_objCT.strApplicationID ;
				objCTCheckOrderDatas[2] =DateTime.Parse(m_objCT.strCreateDate).ToString()+"          申请单号："+m_objCT.strApplicationID ;
				objCTCheckOrderDatas[3] =m_objCT.strCheckMoneyContent ;
				objCTCheckOrderDatas[4] =m_objCT.strPhotoMontyContent ;
                if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
                {
                    objCTCheckOrderDatas[5] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;
				    objCTCheckOrderDatas[6] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
				    objCTCheckOrderDatas[7] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
				    objCTCheckOrderDatas[8] =m_ObjCurrentEmrPatientSession.m_strAreaName;
				    //objCTCheckOrderDatas[8] =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
				    objCTCheckOrderDatas[9] =string.Empty;
                    objCTCheckOrderDatas[10] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;

                    objCTCheckOrderDatas[11] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
                    objCTCheckOrderDatas[12] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLinkManAddress;
                }
                else
                {
                    objCTCheckOrderDatas[5] = string.Empty;
                    objCTCheckOrderDatas[6] = string.Empty;
                    objCTCheckOrderDatas[7] = string.Empty;
                    objCTCheckOrderDatas[8] = string.Empty;
                    //objCTCheckOrderDatas[8] =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
                    objCTCheckOrderDatas[9] = string.Empty;
                    objCTCheckOrderDatas[10] = string.Empty;
                    objCTCheckOrderDatas[11] = string.Empty;
                    objCTCheckOrderDatas[12] = string.Empty;
                }

				objCTCheckOrderDatas[13] =(m_objCT.strResumeHave=="True"? "√":"") ;
				objCTCheckOrderDatas[14] =(m_objCT.strResumeNone=="True"? "√":"") ;
				objCTCheckOrderDatas[15] =(m_objCT.strResumeAsthmaHave=="True"? "√":"") ;
				objCTCheckOrderDatas[16] =(m_objCT.strResumeAsthmaNone=="True"? "√":"") ;
				objCTCheckOrderDatas[17] =(m_objCT.strTool=="True"? "√":"") ;
				objCTCheckOrderDatas[18] =(m_objCT.strWalk=="True"? "√":"") ;

				objCTCheckOrderDatas[19] =m_objCT.strParticular ;
				objCTCheckOrderDatas[20] =m_objCT.strClinic ;
				objCTCheckOrderDatas[21] =m_txtSign.Text; 
				objCTCheckOrderDatas[22] =m_objCT.strLiver ; 
				objCTCheckOrderDatas[23] =m_objCT.strAlbumen ;
				objCTCheckOrderDatas[24] =m_objCT.strFetus ;
				objCTCheckOrderDatas[25] =m_objCT.strRed ;
				objCTCheckOrderDatas[26] =m_objCT.strAKP ;
				objCTCheckOrderDatas[27] =m_objCT.strCancer ;
				objCTCheckOrderDatas[28] =m_objCT.strFecula ;
				objCTCheckOrderDatas[29] =m_objCT.strPee17 ;
				objCTCheckOrderDatas[30] =m_objCT.strBlood ;
				objCTCheckOrderDatas[31] =m_objCT.strBloodDoop ;
				objCTCheckOrderDatas[32] =m_objCT.strPhlegm ;
				objCTCheckOrderDatas[33] =m_objCT.strEmiction ;
				objCTCheckOrderDatas[34] =m_objCT.strBreast ;
				objCTCheckOrderDatas[35] =m_objCT.strPancreas ;
				objCTCheckOrderDatas[36] =m_objCT.strScan ;
				objCTCheckOrderDatas[37] =m_objCT.strBladder ;
				objCTCheckOrderDatas[38] =m_objCT.strUltrasonic ;
				objCTCheckOrderDatas[39] =m_objCT.strOther ;
				objCTCheckOrderDatas[40] =m_objCT.strIdea ;
				objCTCheckOrderDatas[41] =(m_objCT.strAdvanceID.Trim()!="") ? DateTime.Parse(m_objCT.strAdvanceTime).ToString("yyyy年MM月dd日 HH时") : "";
				objCTCheckOrderDatas[42] =m_objCT.strAdvanceID;
			}
			else 
			{
				for(int i=0;i<objCTCheckOrderDatas.Length-1;i++)
					objCTCheckOrderDatas[i]="";
			}
		
			dtCTCheckOrder.Rows.Add(objCTCheckOrderDatas);
			m_rpdOrderRept.Database.Tables["CTCHECKORDER"].SetDataSource(dtCTCheckOrder);

			m_rpdOrderRept.Refresh();

			
		}
		#endregion 

		#region 显示最新检验结果
		protected clsLabAnalysisOrderDomain m_objCheckResultDomain=new clsLabAnalysisOrderDomain();
		private void m_cmdSetLabCheckResult_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient== null )
			{
				return;
			}
			m_lsvJY_ItemChoice.Visible=false;
			m_lsvJY_ItemChoice.Items.Clear();
			clsJY_ItemChoice[] objItemChoiceArr=null;
			long lngRes=m_objCheckResultDomain.m_lngGetLabCheckItemChoiceArr(this.m_objBaseCurrentPatient.m_StrInPatientID,dtpApplyTime.Value,out objItemChoiceArr);
			if(lngRes<=0)
			{
				m_mthShowDBError();
				return;
			}
			else 
			{
				if(objItemChoiceArr != null)
				{
					for(int i=0;i<objItemChoiceArr.Length;i++)
					{
						ListViewItem lviTemp= m_lsvJY_ItemChoice.Items.Add(objItemChoiceArr[i].m_strPat_c_name.Trim());
						lviTemp.SubItems.Add(objItemChoiceArr[i].m_dtmPat_sdate.ToString("yyyy-MM-dd HH:mm:ss"));
						lviTemp.Tag=objItemChoiceArr[i].m_strRes_id;
					}

					m_mthChangeListViewLastColumnWidth(m_lsvJY_ItemChoice);
					m_lsvJY_ItemChoice.Visible=true;
					m_lsvJY_ItemChoice.BringToFront();
				}
				else 
				{
					clsPublicFunction.ShowInformationMessageBox("当前没有最新检验结果出来！");
					return;
				}
			}					
		}

		private void m_lsvJY_ItemChoice_DoubleClick(object sender, System.EventArgs e)
		{
			m_lsvJY_ItemChoice.Visible=false;
			if(m_objBaseCurrentPatient== null || m_lsvJY_ItemChoice.SelectedItems.Count==0 || m_lsvJY_ItemChoice.SelectedItems[0].Tag==null)
			{
				return;
			}
			else
			{
				clsJY_JG[] objResultArr=null;
				long lngRes=m_objCheckResultDomain.m_lngGetLabCheckItemResultArr(m_lsvJY_ItemChoice.SelectedItems[0].Tag.ToString(),c_strNameArr,out objResultArr);
				if(lngRes<=0)
				{
					switch(lngRes)
					{
						case (long)iCareData.enmOperationResult.Not_permission:
							m_mthShowNotPermitted();
							break;							
					}
					return;
				}				

				if(objResultArr==null || objResultArr.Length==0 || c_strNameArr==null)
					return;

				for(int i=0;i<c_strNameArr.Length;i++)
					for(int j=0;j<objResultArr.Length;j++)
					{
						if(c_strNameArr[i]==objResultArr[j].m_strRes_it_ecd || c_strNameArr[i]==objResultArr[j].m_strRes_name)
						{
							m_mthHandleLabCheckValue(c_strNameArr[i],objResultArr[j]);
						}
					}
				
				lblCancer.Focus();
			}
		}

		private void m_mthClearCheckResults()
		{
			m_txtApplicationID.Text = "";
			m_txtLiver.Text="";
			m_txtFecula.Text="";
			m_txtBreast.Text="";
			m_txtAlbumen.Text="";
			m_txtPee17.Text="";
			m_txtPancreas.Text="";
			m_txtFetus.Text="";
			m_txtBlood.Text="";
			m_txtScan.Text="";
			m_txtRed.Text="";
			m_txtBloodDoop.Text="";
			m_txtBladder.Text="";
			m_txtAKP.Text="";
			m_txtPhlegm.Text="";
			m_txtUltrasonic.Text="";
			m_txtCancer.Text="";
			m_txtEmiction.Text="";
			m_txtOther.Text="";

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);

		}
		private string[] c_strNameArr = new string[]{"肝功","淀粉酶","胸片","蛋白电泳","尿17酮、17羟","胰胆管造影","胎甲",
														"血钾","同位素扫描","胆红质","血沉","膀胱镜","AKP","痰细胞学",
														"超声","癌胚抗原","尿常规","其它"};
		private void m_mthHandleLabCheckValue(string p_strName,clsJY_JG p_objResult)
		{
			switch(p_strName)
			{
				case "肝功":
					m_mthSetLabCheckValue(m_txtLiver,p_objResult);
					break;
				case "淀粉酶":
					m_mthSetLabCheckValue(m_txtFecula,p_objResult);
					break;
				case "胸片":
					m_mthSetLabCheckValue(m_txtBreast,p_objResult);
					break;
				case "蛋白电池":				
					m_mthSetLabCheckValue(m_txtAlbumen,p_objResult);
					break;
				case "尿17酮、17羟":
					m_mthSetLabCheckValue(m_txtPee17,p_objResult);
					break;
				case "胰胆管造影":
					m_mthSetLabCheckValue(m_txtPancreas,p_objResult);
					break;
				case "胎甲":
					m_mthSetLabCheckValue(m_txtFetus,p_objResult);
					break;
				case "血钾":
					m_mthSetLabCheckValue(m_txtBlood,p_objResult);
					break;
				case "同位素扫描":
					m_mthSetLabCheckValue(m_txtScan,p_objResult);
					break;
				case "胆红质":
					m_mthSetLabCheckValue(m_txtRed,p_objResult);
					break;
				case "血沉":
					m_mthSetLabCheckValue(m_txtBloodDoop,p_objResult);
					break;
				case "膀胱镜":
					m_mthSetLabCheckValue(m_txtBladder,p_objResult);
					break;
				case "AKP":
					m_mthSetLabCheckValue(m_txtAKP,p_objResult);
					break;
				case "痰细胞学":
					m_mthSetLabCheckValue(m_txtPhlegm,p_objResult);
					break;
				case "超声":
					m_mthSetLabCheckValue(m_txtUltrasonic,p_objResult);
					break;
				case "癌胚抗原":
					m_mthSetLabCheckValue(m_txtCancer,p_objResult);
					break;
				case "尿常规":
					m_mthSetLabCheckValue(m_txtEmiction,p_objResult);
					break;					
				case "其它":
					m_mthSetLabCheckValue(m_txtOther,p_objResult);
					break;				
				
			}
		}

		private void m_mthSetLabCheckValue(Control p_objText,clsJY_JG p_objResult)
		{			
			if(p_objResult.m_strRes_chr != null && p_objResult.m_strRes_chr.Trim() != "")
			{
				p_objText.Text = p_objResult.m_strRes_chr.Trim();
			}
			else if(p_objResult.m_strRes_chr1 != null && p_objResult.m_strRes_chr1.Trim() != "")
			{
				p_objText.Text = p_objResult.m_strRes_chr1.Trim();
			}
		}
		#endregion 显示最新检验结果		

		private void m_lsvJY_ItemChoice_Leave(object sender, System.EventArgs e)
		{
			if( !m_lsvJY_ItemChoice.Focused  && !m_cmdSetLabCheckResult.Focused)
				m_lsvJY_ItemChoice.Visible=false;
		}

		#region old
		//		private void m_txtApplyDotorID_TextChanged(object sender, System.EventArgs e)
		//		{
		//			if(blnSign==false) return ;
		//			clsOperationEqipmentQtyDomain m_objOEQDomain = new clsOperationEqipmentQtyDomain();
		//			
		//			lsvLike.Items.Clear();
		//			bool blnSuccess=false;
		//		
		//			ListViewItem[] lsvItemArr=null;
		//
		//		    lsvItemArr=m_objOEQDomain.m_lviGetEmployee(m_txtApplyDotorID.Text.Trim(),ref blnSuccess);	
		//			if(blnSuccess==false)
		//				return;
		//			for (int i=0; i<lsvItemArr.Length; i++)
		//			{
		//				lsvLike.Items.AddRange(new ListViewItem[]{lsvItemArr[i]});
		//			}
		//		    Point pntLsv=new Point(this.m_txtApplyDotorID.Location.X,this.m_txtApplyDotorID.Location.Y+this.m_txtApplyDotorID.Size.Height);
		//			lsvLike.BringToFront();
		//			lsvLike.Visible=true;
		//	
		//		}
		//
		//		private void lsvLike_DoubleClick(object sender, System.EventArgs e)
		//		{
		//			
		//			if(lsvLike.SelectedItems.Count<=0) return ;
		//		    blnSign=false;
		//			this.m_txtApplyDotorID.Tag=lsvLike.SelectedItems[0].Text;
		//			this.m_txtApplyDotorID.Text=lsvLike.SelectedItems[0].SubItems[1].Text;
		//			blnSign=true;
		//						
		//			lsvLike.Visible=false;
		//		}
		//		private void m_mthSignListControl(object sender,EventArgs e)
		//		{
		//			try
		//			{
		//				if(sender.Equals(m_txtApplyDotorID) && !lsvLike.Focused  )
		//				{
		//					lsvLike.Visible=false;
		//				}
		//				else if(sender.Equals(lsvLike) && !m_txtApplyDotorID.Focused )
		//				{
		//					lsvLike.Visible = false;
		//				}
		//			}
		//			catch{}
		//		}
		//	
		#endregion 

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			if(p_objPatient != null)
				new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
//			m_mthSetSpecialPatientTemplateSet(p_objPatient);
            //if(m_strPatientName!=null)
            //{
            //    if(m_strPatientName.Trim().Length!=0)
            //        m_txtPatientName.Text=m_strPatientName;
            //}
			if(m_strClinicDiagnoses!=null)
			{
				if(m_strClinicDiagnoses.Trim().Length!=0)
					m_txtClinic.Text=m_strClinicDiagnoses;
			}
		}

		private void m_chkNeedRequire_CheckedChanged(object sender, System.EventArgs e)
		{
			m_txtApplicationComment.Enabled = m_chkNeedRequire.Checked;
		}

		public override bool lngCanYouDoIt()
		{
			return true;
		}

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
            m_strPatientID = m_objCurrentPatient.m_StrInPatientID;

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllTimeOfAPatient(m_strPatientID);			
        }

	}
	
}

