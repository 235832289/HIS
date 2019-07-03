using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Xml;
using System.IO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
using iCareData;

namespace iCare
{
	public class frmHighOxygen : iCare.frmHRPBaseForm,PublicFunction 
	{
		#region define 

		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.Label lblResume;
		private System.Windows.Forms.Label lblClinicCheck;
		private System.Windows.Forms.Label lblAssistant;
		private System.Windows.Forms.Label lblClinicCure;
		private System.Windows.Forms.Label lblCT;
		private System.Windows.Forms.Label lblMR;
		private System.Windows.Forms.Label lblEEG;
		private System.Windows.Forms.Label lblEKG;
		private System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.Label lblHighOxygen;
		private System.Windows.Forms.Label lblClinicDiagnose;
		private System.Windows.Forms.Label lblHighOxygenTime;
		private System.Windows.Forms.Label lblApplyDate;
		private System.Windows.Forms.RichTextBox txtResume;
		private System.Windows.Forms.RichTextBox txtClinicCheck;
		private System.Windows.Forms.RichTextBox txtAssistantCT;
		private System.Windows.Forms.RichTextBox txtAssistantMR;
		private System.Windows.Forms.RichTextBox txtAssistantOther;
		private System.Windows.Forms.RichTextBox txtAssistantEKG;
		private System.Windows.Forms.RichTextBox txtAssistantEEG;
		private System.Windows.Forms.RichTextBox txtClinicDiagnose;
		private System.Windows.Forms.RichTextBox txtHighOxygen;
        private System.Windows.Forms.RichTextBox txtClinicCure;
		private System.Windows.Forms.RichTextBox txtHighOxygenTime;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplyTime;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtOrderID;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.Label lblApplyDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmployeeSign;
		private System.ComponentModel.IContainer components = null;
		#endregion 
		private PinkieControls.ButtonXP m_cmdApplyDoc;
		private clsCommonUseToolCollection m_objCUTC;
		private PinkieControls.ButtonXP m_cmdDoc;
        private TextBox m_txtSign;
        private TextBox txtDoc;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		private clsEmployeeSignTool m_objSignTool;
		public frmHighOxygen()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	this.trvTime
                                                                             //,txtResume
                                                                             //,txtClinicCheck
                                                                             //,txtAssistantCT
                                                                             //,txtAssistantMR
                                                                             //,txtAssistantOther
                                                                             //,txtAssistantEKG
                                                                             //,txtAssistantEEG
                                                                             //,txtClinicDiagnose
                                                                             //,txtHighOxygen
                                                                             //,txtClinicCure
                                                                             //,txtHighOxygenTime});	
            //txtDoc.LostFocus += new EventHandler(lsvLike_LostFocus);			
            //lsvLike.LostFocus += new EventHandler(lsvLike_LostFocus);
            //this.lsvLike.DoubleClick += new System.EventHandler(this.lsvLike_DoubleClick);			

			m_objDomain=new clsHighOxygenDomain();
			this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);

			m_dtsRept = m_dtsInitdtsHighOxygenDataSet();
			//			m_rpdOrderRept = new ReportDocument();
			//			m_rpdOrderRept.Load(m_strTemplatePath+"rptHighOxygen.rpt");

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdApplyDoc, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDoc, txtDoc, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;
		private clsHighOxygenDomain m_objDomain;
		
		private clsHightOxygen m_objHightOxygen=null;
		private clsPatient m_objCurrentPatient=null;

		private bool blnCanDelete=true;              //是否可以执行删除操作

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		private DataSet m_dtsRept;
		private bool blnCanSearch=true; 
		private bool blnSignSelectAll=true;


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
		/// 		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHighOxygen));
            this.lblID = new System.Windows.Forms.Label();
            this.lblResume = new System.Windows.Forms.Label();
            this.lblClinicCheck = new System.Windows.Forms.Label();
            this.lblAssistant = new System.Windows.Forms.Label();
            this.lblClinicCure = new System.Windows.Forms.Label();
            this.lblCT = new System.Windows.Forms.Label();
            this.lblMR = new System.Windows.Forms.Label();
            this.lblEEG = new System.Windows.Forms.Label();
            this.lblEKG = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblHighOxygen = new System.Windows.Forms.Label();
            this.lblClinicDiagnose = new System.Windows.Forms.Label();
            this.lblHighOxygenTime = new System.Windows.Forms.Label();
            this.lblApplyDate = new System.Windows.Forms.Label();
            this.txtResume = new System.Windows.Forms.RichTextBox();
            this.txtClinicCheck = new System.Windows.Forms.RichTextBox();
            this.txtAssistantCT = new System.Windows.Forms.RichTextBox();
            this.txtAssistantMR = new System.Windows.Forms.RichTextBox();
            this.txtAssistantOther = new System.Windows.Forms.RichTextBox();
            this.txtAssistantEKG = new System.Windows.Forms.RichTextBox();
            this.txtAssistantEEG = new System.Windows.Forms.RichTextBox();
            this.txtClinicDiagnose = new System.Windows.Forms.RichTextBox();
            this.txtHighOxygen = new System.Windows.Forms.RichTextBox();
            this.txtClinicCure = new System.Windows.Forms.RichTextBox();
            this.txtHighOxygenTime = new System.Windows.Forms.RichTextBox();
            this.txtOrderID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.dtpApplyTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblApplyDoctor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_cmdApplyDoc = new PinkieControls.ButtonXP();
            this.m_cmdDoc = new PinkieControls.ButtonXP();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(275, 154);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(245, 152);
            this.lblAge.Size = new System.Drawing.Size(32, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(240, 145);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(245, 145);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(263, 152);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(269, 146);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(240, 160);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(245, 159);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(223, 155);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 51);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(243, 143);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.TabIndex = 3;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(243, 143);
            this.m_txtPatientName.Size = new System.Drawing.Size(68, 23);
            this.m_txtPatientName.TabIndex = 2;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(236, 150);
            this.m_txtBedNO.Size = new System.Drawing.Size(60, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(223, 141);
            this.m_cboArea.Size = new System.Drawing.Size(120, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(248, 155);
            this.m_lsvPatientName.Size = new System.Drawing.Size(68, 51);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(223, 155);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 51);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(228, 141);
            this.m_cboDept.Size = new System.Drawing.Size(120, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(225, 141);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(232, 141);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdNext.Location = new System.Drawing.Point(281, 145);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdPre.Location = new System.Drawing.Point(248, 155);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.AutoSize = true;
            this.m_lblForTitle.Location = new System.Drawing.Point(232, 146);
            this.m_lblForTitle.Size = new System.Drawing.Size(119, 14);
            this.m_lblForTitle.Text = "高压氧治疗申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(386, 138);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(720, 62);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(72, 30);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.lblID);
            this.m_pnlNewBase.Controls.Add(this.txtOrderID);
            this.m_pnlNewBase.Controls.Add(this.dtpApplyTime);
            this.m_pnlNewBase.Controls.Add(this.lblApplyDate);
            this.m_pnlNewBase.Location = new System.Drawing.Point(6, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(791, 88);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblApplyDate, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.dtpApplyTime, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtOrderID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblID, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(192, 32);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(597, 55);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.Location = new System.Drawing.Point(499, 64);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(42, 14);
            this.lblID.TabIndex = 501;
            this.lblID.Text = "编号:";
            // 
            // lblResume
            // 
            this.lblResume.AutoSize = true;
            this.lblResume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResume.Location = new System.Drawing.Point(4, 98);
            this.lblResume.Name = "lblResume";
            this.lblResume.Size = new System.Drawing.Size(70, 14);
            this.lblResume.TabIndex = 503;
            this.lblResume.Text = "简要病历:";
            // 
            // lblClinicCheck
            // 
            this.lblClinicCheck.AutoSize = true;
            this.lblClinicCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicCheck.Location = new System.Drawing.Point(404, 99);
            this.lblClinicCheck.Name = "lblClinicCheck";
            this.lblClinicCheck.Size = new System.Drawing.Size(70, 14);
            this.lblClinicCheck.TabIndex = 505;
            this.lblClinicCheck.Text = "临床检查:";
            // 
            // lblAssistant
            // 
            this.lblAssistant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAssistant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAssistant.Location = new System.Drawing.Point(6, 191);
            this.lblAssistant.Name = "lblAssistant";
            this.lblAssistant.Size = new System.Drawing.Size(30, 193);
            this.lblAssistant.TabIndex = 506;
            this.lblAssistant.Text = "辅助检查";
            this.lblAssistant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClinicCure
            // 
            this.lblClinicCure.AutoSize = true;
            this.lblClinicCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicCure.Location = new System.Drawing.Point(12, 388);
            this.lblClinicCure.Name = "lblClinicCure";
            this.lblClinicCure.Size = new System.Drawing.Size(70, 14);
            this.lblClinicCure.TabIndex = 507;
            this.lblClinicCure.Text = "临床治疗:";
            // 
            // lblCT
            // 
            this.lblCT.AutoSize = true;
            this.lblCT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCT.Location = new System.Drawing.Point(40, 192);
            this.lblCT.Name = "lblCT";
            this.lblCT.Size = new System.Drawing.Size(21, 14);
            this.lblCT.TabIndex = 509;
            this.lblCT.Text = "CT";
            // 
            // lblMR
            // 
            this.lblMR.AutoSize = true;
            this.lblMR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMR.Location = new System.Drawing.Point(404, 192);
            this.lblMR.Name = "lblMR";
            this.lblMR.Size = new System.Drawing.Size(21, 14);
            this.lblMR.TabIndex = 510;
            this.lblMR.Text = "MR";
            // 
            // lblEEG
            // 
            this.lblEEG.AutoSize = true;
            this.lblEEG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEEG.Location = new System.Drawing.Point(36, 260);
            this.lblEEG.Name = "lblEEG";
            this.lblEEG.Size = new System.Drawing.Size(28, 14);
            this.lblEEG.TabIndex = 511;
            this.lblEEG.Text = "EEG";
            // 
            // lblEKG
            // 
            this.lblEKG.AutoSize = true;
            this.lblEKG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEKG.Location = new System.Drawing.Point(404, 263);
            this.lblEKG.Name = "lblEKG";
            this.lblEKG.Size = new System.Drawing.Size(28, 14);
            this.lblEKG.TabIndex = 512;
            this.lblEKG.Text = "EKG";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOther.Location = new System.Drawing.Point(36, 332);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(35, 14);
            this.lblOther.TabIndex = 513;
            this.lblOther.Text = "其它";
            // 
            // lblHighOxygen
            // 
            this.lblHighOxygen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHighOxygen.Location = new System.Drawing.Point(403, 388);
            this.lblHighOxygen.Name = "lblHighOxygen";
            this.lblHighOxygen.Size = new System.Drawing.Size(152, 20);
            this.lblHighOxygen.TabIndex = 520;
            this.lblHighOxygen.Text = "既往高压氧治疗情况:";
            // 
            // lblClinicDiagnose
            // 
            this.lblClinicDiagnose.AutoSize = true;
            this.lblClinicDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicDiagnose.Location = new System.Drawing.Point(12, 488);
            this.lblClinicDiagnose.Name = "lblClinicDiagnose";
            this.lblClinicDiagnose.Size = new System.Drawing.Size(70, 14);
            this.lblClinicDiagnose.TabIndex = 522;
            this.lblClinicDiagnose.Text = "临床诊断:";
            // 
            // lblHighOxygenTime
            // 
            this.lblHighOxygenTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHighOxygenTime.Location = new System.Drawing.Point(403, 488);
            this.lblHighOxygenTime.Name = "lblHighOxygenTime";
            this.lblHighOxygenTime.Size = new System.Drawing.Size(212, 20);
            this.lblHighOxygenTime.TabIndex = 526;
            this.lblHighOxygenTime.Text = "高压氧治疗方案及时间安排:";
            // 
            // lblApplyDate
            // 
            this.lblApplyDate.AutoSize = true;
            this.lblApplyDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplyDate.Location = new System.Drawing.Point(195, 64);
            this.lblApplyDate.Name = "lblApplyDate";
            this.lblApplyDate.Size = new System.Drawing.Size(70, 14);
            this.lblApplyDate.TabIndex = 530;
            this.lblApplyDate.Text = "申请日期:";
            // 
            // txtResume
            // 
            this.txtResume.AccessibleDescription = "简要病历";
            this.txtResume.BackColor = System.Drawing.Color.White;
            this.txtResume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResume.ForeColor = System.Drawing.Color.Black;
            this.txtResume.Location = new System.Drawing.Point(6, 117);
            this.txtResume.Name = "txtResume";
            this.txtResume.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtResume.Size = new System.Drawing.Size(395, 71);
            this.txtResume.TabIndex = 7;
            this.txtResume.Text = "";
            // 
            // txtClinicCheck
            // 
            this.txtClinicCheck.AccessibleDescription = "临床检查";
            this.txtClinicCheck.BackColor = System.Drawing.Color.White;
            this.txtClinicCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicCheck.ForeColor = System.Drawing.Color.Black;
            this.txtClinicCheck.Location = new System.Drawing.Point(407, 116);
            this.txtClinicCheck.Name = "txtClinicCheck";
            this.txtClinicCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicCheck.Size = new System.Drawing.Size(389, 72);
            this.txtClinicCheck.TabIndex = 8;
            this.txtClinicCheck.Text = "";
            // 
            // txtAssistantCT
            // 
            this.txtAssistantCT.AccessibleDescription = "辅助检查-CT";
            this.txtAssistantCT.BackColor = System.Drawing.Color.White;
            this.txtAssistantCT.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssistantCT.ForeColor = System.Drawing.Color.Black;
            this.txtAssistantCT.Location = new System.Drawing.Point(36, 212);
            this.txtAssistantCT.Name = "txtAssistantCT";
            this.txtAssistantCT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssistantCT.Size = new System.Drawing.Size(365, 48);
            this.txtAssistantCT.TabIndex = 9;
            this.txtAssistantCT.Text = "";
            // 
            // txtAssistantMR
            // 
            this.txtAssistantMR.AccessibleDescription = "辅助检查-MR";
            this.txtAssistantMR.BackColor = System.Drawing.Color.White;
            this.txtAssistantMR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssistantMR.ForeColor = System.Drawing.Color.Black;
            this.txtAssistantMR.Location = new System.Drawing.Point(407, 212);
            this.txtAssistantMR.Name = "txtAssistantMR";
            this.txtAssistantMR.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssistantMR.Size = new System.Drawing.Size(390, 48);
            this.txtAssistantMR.TabIndex = 10;
            this.txtAssistantMR.Text = "";
            // 
            // txtAssistantOther
            // 
            this.txtAssistantOther.AccessibleDescription = "辅助检查-其它";
            this.txtAssistantOther.BackColor = System.Drawing.Color.White;
            this.txtAssistantOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssistantOther.ForeColor = System.Drawing.Color.Black;
            this.txtAssistantOther.Location = new System.Drawing.Point(36, 352);
            this.txtAssistantOther.Name = "txtAssistantOther";
            this.txtAssistantOther.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssistantOther.Size = new System.Drawing.Size(760, 32);
            this.txtAssistantOther.TabIndex = 13;
            this.txtAssistantOther.Text = "";
            // 
            // txtAssistantEKG
            // 
            this.txtAssistantEKG.AccessibleDescription = "辅助检查-EKG";
            this.txtAssistantEKG.BackColor = System.Drawing.Color.White;
            this.txtAssistantEKG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssistantEKG.ForeColor = System.Drawing.Color.Black;
            this.txtAssistantEKG.Location = new System.Drawing.Point(407, 280);
            this.txtAssistantEKG.Name = "txtAssistantEKG";
            this.txtAssistantEKG.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssistantEKG.Size = new System.Drawing.Size(390, 48);
            this.txtAssistantEKG.TabIndex = 12;
            this.txtAssistantEKG.Text = "";
            // 
            // txtAssistantEEG
            // 
            this.txtAssistantEEG.AccessibleDescription = "辅助检查-EEG";
            this.txtAssistantEEG.BackColor = System.Drawing.Color.White;
            this.txtAssistantEEG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAssistantEEG.ForeColor = System.Drawing.Color.Black;
            this.txtAssistantEEG.Location = new System.Drawing.Point(36, 280);
            this.txtAssistantEEG.Name = "txtAssistantEEG";
            this.txtAssistantEEG.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtAssistantEEG.Size = new System.Drawing.Size(365, 48);
            this.txtAssistantEEG.TabIndex = 11;
            this.txtAssistantEEG.Text = "";
            // 
            // txtClinicDiagnose
            // 
            this.txtClinicDiagnose.AccessibleDescription = "临床诊断";
            this.txtClinicDiagnose.BackColor = System.Drawing.Color.White;
            this.txtClinicDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicDiagnose.ForeColor = System.Drawing.Color.Black;
            this.txtClinicDiagnose.Location = new System.Drawing.Point(8, 508);
            this.txtClinicDiagnose.Name = "txtClinicDiagnose";
            this.txtClinicDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicDiagnose.Size = new System.Drawing.Size(393, 80);
            this.txtClinicDiagnose.TabIndex = 16;
            this.txtClinicDiagnose.Text = "";
            // 
            // txtHighOxygen
            // 
            this.txtHighOxygen.AccessibleDescription = "既往高压氧治疗情况";
            this.txtHighOxygen.BackColor = System.Drawing.Color.White;
            this.txtHighOxygen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHighOxygen.ForeColor = System.Drawing.Color.Black;
            this.txtHighOxygen.Location = new System.Drawing.Point(407, 408);
            this.txtHighOxygen.Name = "txtHighOxygen";
            this.txtHighOxygen.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtHighOxygen.Size = new System.Drawing.Size(389, 76);
            this.txtHighOxygen.TabIndex = 15;
            this.txtHighOxygen.Text = "";
            // 
            // txtClinicCure
            // 
            this.txtClinicCure.AccessibleDescription = "临床治疗";
            this.txtClinicCure.BackColor = System.Drawing.Color.White;
            this.txtClinicCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicCure.ForeColor = System.Drawing.Color.Black;
            this.txtClinicCure.Location = new System.Drawing.Point(8, 408);
            this.txtClinicCure.Name = "txtClinicCure";
            this.txtClinicCure.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicCure.Size = new System.Drawing.Size(393, 76);
            this.txtClinicCure.TabIndex = 14;
            this.txtClinicCure.Text = "";
            // 
            // txtHighOxygenTime
            // 
            this.txtHighOxygenTime.AccessibleDescription = "高压氧治疗方案及时间安排";
            this.txtHighOxygenTime.BackColor = System.Drawing.Color.White;
            this.txtHighOxygenTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHighOxygenTime.ForeColor = System.Drawing.Color.Black;
            this.txtHighOxygenTime.Location = new System.Drawing.Point(407, 512);
            this.txtHighOxygenTime.Name = "txtHighOxygenTime";
            this.txtHighOxygenTime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtHighOxygenTime.Size = new System.Drawing.Size(389, 76);
            this.txtHighOxygenTime.TabIndex = 17;
            this.txtHighOxygenTime.Text = "";
            // 
            // txtOrderID
            // 
            this.txtOrderID.AccessibleDescription = "编号";
            this.txtOrderID.BackColor = System.Drawing.Color.White;
            this.txtOrderID.BorderColor = System.Drawing.Color.Transparent;
            this.txtOrderID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOrderID.ForeColor = System.Drawing.Color.Black;
            this.txtOrderID.Location = new System.Drawing.Point(543, 60);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(116, 23);
            this.txtOrderID.TabIndex = 6;
            // 
            // dtpApplyTime
            // 
            this.dtpApplyTime.BorderColor = System.Drawing.Color.Black;
            this.dtpApplyTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplyTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplyTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplyTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplyTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplyTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplyTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplyTime.Location = new System.Drawing.Point(264, 60);
            this.dtpApplyTime.m_BlnOnlyTime = false;
            this.dtpApplyTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplyTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplyTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplyTime.Name = "dtpApplyTime";
            this.dtpApplyTime.ReadOnly = false;
            this.dtpApplyTime.Size = new System.Drawing.Size(216, 22);
            this.dtpApplyTime.TabIndex = 5;
            this.dtpApplyTime.TextBackColor = System.Drawing.Color.White;
            this.dtpApplyTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(7, 38);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(193, 56);
            this.trvTime.TabIndex = 4;
            // 
            // lblApplyDoctor
            // 
            this.lblApplyDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplyDoctor.Location = new System.Drawing.Point(404, 592);
            this.lblApplyDoctor.Name = "lblApplyDoctor";
            this.lblApplyDoctor.Size = new System.Drawing.Size(108, 24);
            this.lblApplyDoctor.TabIndex = 800;
            this.lblApplyDoctor.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(240, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 662;
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(352, 596);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000082;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // m_cmdApplyDoc
            // 
            this.m_cmdApplyDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdApplyDoc.DefaultScheme = true;
            this.m_cmdApplyDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdApplyDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdApplyDoc.Hint = "";
            this.m_cmdApplyDoc.Location = new System.Drawing.Point(36, 592);
            this.m_cmdApplyDoc.Name = "m_cmdApplyDoc";
            this.m_cmdApplyDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdApplyDoc.Size = new System.Drawing.Size(92, 24);
            this.m_cmdApplyDoc.TabIndex = 10000083;
            this.m_cmdApplyDoc.Tag = "1";
            this.m_cmdApplyDoc.Text = "申请医师:";
            // 
            // m_cmdDoc
            // 
            this.m_cmdDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoc.DefaultScheme = true;
            this.m_cmdDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoc.Hint = "";
            this.m_cmdDoc.Location = new System.Drawing.Point(516, 592);
            this.m_cmdDoc.Name = "m_cmdDoc";
            this.m_cmdDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoc.Size = new System.Drawing.Size(60, 24);
            this.m_cmdDoc.TabIndex = 10000084;
            this.m_cmdDoc.Tag = "0";
            this.m_cmdDoc.Text = "医师:";
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(134, 592);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(102, 23);
            this.m_txtSign.TabIndex = 10000085;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(582, 592);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.ReadOnly = true;
            this.txtDoc.Size = new System.Drawing.Size(102, 23);
            this.txtDoc.TabIndex = 10000085;
            // 
            // frmHighOxygen
            // 
            this.AccessibleDescription = "高压氧治疗申请单";
            this.AutoScroll = false;
            this.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.ClientSize = new System.Drawing.Size(802, 633);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.txtResume);
            this.Controls.Add(this.txtClinicCheck);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.lblOther);
            this.Controls.Add(this.lblEKG);
            this.Controls.Add(this.lblEEG);
            this.Controls.Add(this.lblMR);
            this.Controls.Add(this.lblCT);
            this.Controls.Add(this.lblClinicDiagnose);
            this.Controls.Add(this.lblClinicCure);
            this.Controls.Add(this.lblClinicCheck);
            this.Controls.Add(this.lblResume);
            this.Controls.Add(this.m_cmdDoc);
            this.Controls.Add(this.m_cmdApplyDoc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.lblApplyDoctor);
            this.Controls.Add(this.txtHighOxygenTime);
            this.Controls.Add(this.txtClinicCure);
            this.Controls.Add(this.txtHighOxygen);
            this.Controls.Add(this.txtClinicDiagnose);
            this.Controls.Add(this.txtAssistantEEG);
            this.Controls.Add(this.txtAssistantEKG);
            this.Controls.Add(this.txtAssistantOther);
            this.Controls.Add(this.txtAssistantMR);
            this.Controls.Add(this.txtAssistantCT);
            this.Controls.Add(this.lblHighOxygenTime);
            this.Controls.Add(this.lblHighOxygen);
            this.Controls.Add(this.lblAssistant);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHighOxygen";
            this.Text = "高压氧治疗申请单";
            this.Load += new System.EventHandler(this.frmHighOxygen__Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblAssistant, 0);
            this.Controls.SetChildIndex(this.lblHighOxygen, 0);
            this.Controls.SetChildIndex(this.lblHighOxygenTime, 0);
            this.Controls.SetChildIndex(this.txtAssistantCT, 0);
            this.Controls.SetChildIndex(this.txtAssistantMR, 0);
            this.Controls.SetChildIndex(this.txtAssistantOther, 0);
            this.Controls.SetChildIndex(this.txtAssistantEKG, 0);
            this.Controls.SetChildIndex(this.txtAssistantEEG, 0);
            this.Controls.SetChildIndex(this.txtClinicDiagnose, 0);
            this.Controls.SetChildIndex(this.txtHighOxygen, 0);
            this.Controls.SetChildIndex(this.txtClinicCure, 0);
            this.Controls.SetChildIndex(this.txtHighOxygenTime, 0);
            this.Controls.SetChildIndex(this.lblApplyDoctor, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_cmdApplyDoc, 0);
            this.Controls.SetChildIndex(this.m_cmdDoc, 0);
            this.Controls.SetChildIndex(this.lblResume, 0);
            this.Controls.SetChildIndex(this.lblClinicCheck, 0);
            this.Controls.SetChildIndex(this.lblClinicCure, 0);
            this.Controls.SetChildIndex(this.lblClinicDiagnose, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblCT, 0);
            this.Controls.SetChildIndex(this.lblMR, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblEEG, 0);
            this.Controls.SetChildIndex(this.lblEKG, 0);
            this.Controls.SetChildIndex(this.lblOther, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.txtClinicCheck, 0);
            this.Controls.SetChildIndex(this.txtResume, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.txtDoc, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
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
			if(p_objSelectedPatient == null)
				return;
			m_mthClearPatientBaseInfo();
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objHightOxygen=null;
			m_objCurrentPatient=null;

            //txtInPatientID.Tag = p_objSelectedPatient.m_DtmSelectedInDate.ToString();
            //txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;
			
            //m_mthSetPatientBaseInfo(p_objSelectedPatient);

			m_objCurrentPatient=p_objSelectedPatient ;		
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

            //m_objSignTool.m_mthSetDefaulEmployee();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);
			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtResume.Text ="患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。";
//				this.txtClinicDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				txtClinicCheck.Text = objInPatientCaseDefaultValue[0].m_strProfessionalCheck;
//			}			
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
			if(m_objHightOxygen==null) return -1;
			//			if(!m_bolShowIfModify()) return -1;
			if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=m_objHightOxygen.strCreateUserID.Trim())
			{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
				clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
				return -1;
			}
            clsHightOxygen objContent = objHightOxygenContent(false);
            if (objContent == null)
            {
                return -1;
            }
            long lngSave = m_objDomain.lngSave(objContent); 
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

			m_objHightOxygen=new clsHightOxygen();

            clsHightOxygen objContent = objHightOxygenContent(true);
            if (objContent == null)
            {
                return -1;
            }
            long lngSave = m_objDomain.lngSave(objContent); 
			if(lngSave>0)
			{
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
				m_mthAddNodeToTrv(this.dtpApplyTime.Value);
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
				m_rpdOrderRept.Load(m_strTemplatePath+"rptHighOxygen.rpt");
			}

			m_mthAddNewDataFordtsHighOxygenDataSet(m_dtsRept);
			
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
			if(blnCanDelete==false ) return 1;
			if(m_objHightOxygen==null || m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objHightOxygen.strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objHightOxygen.strInPatientID,m_objHightOxygen.strInPatientDate,m_objHightOxygen.strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objHightOxygen.strCreateDate)
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
			m_objHightOxygen=m_objDomain.objDisplay( strInPatientID,strInPatientDate,strCreateDate);
			if(m_objHightOxygen==null) 
				return ;

			if(m_objHightOxygen.strCreateUserID.Trim()!= clsEMRLogin.LoginEmployee.m_strEMPID_CHR)
			{
				m_mthReadOnly(true);
			}
			else
			{
				m_mthReadOnly(false);
			}
            
//			this.lblApplyDoctor.Text=new clsEmployee( m_objHightOxygen.strApplyDocID).m_StrFirstName ;

            //m_objSignTool.m_mtSetSpecialEmployee(m_objHightOxygen.strApplyDocID);
            //m_objSignTool.m_mtSetSpecialEmployee(m_objHightOxygen.strDocID,txtDoc);
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objHightOxygen.strApplyDocID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO;
            }

            clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objHightOxygen.strDocID, out objEmpVO1);
            if (objEmpVO1 != null)
            {
                txtDoc.Text = objEmpVO1.m_strLASTNAME_VCHR;
                txtDoc.Tag = objEmpVO1;
            }

			this.txtAssistantCT.Text =m_objHightOxygen.strAssistantCT ;
			this.txtAssistantEEG.Text =m_objHightOxygen.strAssistantEEG ;
			this.txtAssistantEKG.Text =m_objHightOxygen.strAssistantEKG ; 
			this.txtAssistantMR.Text =m_objHightOxygen.strAssistantMR;
			this.txtAssistantOther.Text =m_objHightOxygen.strAssistantOthe ;
			this.txtClinicCheck.Text =m_objHightOxygen.strClinicCheck;
			this.txtClinicCure.Text =m_objHightOxygen.strClinicCure;
			this.txtClinicDiagnose .Text =m_objHightOxygen.strClinicDiagnose;
			this.txtResume.Text =m_objHightOxygen.strResume;
			this.txtHighOxygen.Text =m_objHightOxygen.strHighOxygen;
			this.txtHighOxygenTime.Text =m_objHightOxygen.strHighOxygenTime;
			this.txtOrderID.Text =m_objHightOxygen.strOrderID;
			this.dtpApplyTime.Text=m_objHightOxygen.strCreateDate;
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
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
	
		#endregion

		private void frmHighOxygen__Load(object sender, System.EventArgs e)
		{
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("申请日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

            //lsvLike.Visible=false;

			this.trvTime.SelectedNode=this.trvTime.Nodes[0];
		
			txtResume.Focus();
		}

	
		private clsHightOxygen objHightOxygenContent(bool blnIsAddNew)
		{
            if (m_txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请医师签名");
                return null;
            }
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                return null;
            }

            m_objHightOxygen.strCreateUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
            m_objHightOxygen.strApplyDocID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;

			if(txtDoc.Tag!=null)
                m_objHightOxygen.strDocID = ((clsEmrEmployeeBase_VO)txtDoc.Tag).m_strEMPID_CHR;
			else 
				m_objHightOxygen.strDocID= string.Empty;

			if(blnIsAddNew==true)
			{					
				//				m_objHightOxygen.strApplyDocID=MDIParent.OperatorID;
                m_objHightOxygen.strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                m_objHightOxygen.strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
				m_objHightOxygen.strCreateDate =this.dtpApplyTime.Value.ToString("yyyy-MM-dd HH:mm:ss");				
			}
					

			m_objHightOxygen.strStatus ="0";
			m_objHightOxygen.strIfConfirm  ="0";

			
			m_objHightOxygen.strAssistantCT=this.txtAssistantCT.Text.Trim() ;
			m_objHightOxygen.strAssistantEEG=this.txtAssistantEEG.Text.Trim() ;
			
			m_objHightOxygen.strAssistantEKG=this.txtAssistantEKG.Text.Trim() ;
			m_objHightOxygen.strAssistantMR=this.txtAssistantMR.Text.Trim() ;
			m_objHightOxygen.strAssistantOthe=this.txtAssistantOther.Text.Trim() ;
			
			m_objHightOxygen.strClinicCheck=this.txtClinicCheck.Text.Trim() ;
			m_objHightOxygen.strClinicCure=this.txtClinicCure.Text.Trim() ;
			m_objHightOxygen.strClinicDiagnose=this.txtClinicDiagnose.Text.Trim() ;
			
			
			m_objHightOxygen.strHighOxygen=this.txtHighOxygen.Text.Trim() ;
			m_objHightOxygen.strHighOxygenTime=this.txtHighOxygenTime.Text.Trim() ;
			
			m_objHightOxygen.strResume=this.txtResume.Text.Trim() ;
			m_objHightOxygen.strOrderID=this.txtOrderID.Text.Trim(); 
			m_objHightOxygen.strStatus="0";

			
			

			return m_objHightOxygen;
		}

		
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthClearUpSheet();
			m_objHightOxygen =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpApplyTime.Enabled =true;
            if (this.trvTime.SelectedNode.Tag.ToString() != "0" && m_ObjCurrentEmrPatientSession != null)
			{
                Display(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), trvTime.SelectedNode.Tag.ToString());
				this.dtpApplyTime.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpApplyTime.Enabled =false;

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthReadOnly(false);
				this.dtpApplyTime.Value=DateTime.Now;
				this.lblApplyDoctor.Text=MDIParent.OperatorName;
				this.dtpApplyTime.Enabled =true;
					
				if(m_objCurrentPatient != null && txtInPatientID.Tag != null)
				{
					m_mthSetDefaultValue(m_objCurrentPatient);						
				}
				
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			
			}
		
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
		
		/// <summary>
		/// 清空除了基本资料和"树"外的全部界面内容
		/// </summary>
		private void m_mthClearUpSheet()
		{
			this.lblApplyDoctor.Text=MDIParent.OperatorName;
			this.txtAssistantCT.Text="";
			this.txtAssistantEEG.Text="";
			this.txtAssistantEKG.Text ="";
			this.txtAssistantMR.Text="";
			this.txtAssistantOther.Text="";
			this.txtClinicCheck.Text="";
			this.txtClinicCure.Text="";
			this.txtClinicDiagnose.Text="";
            
			this.txtDoc.Text="";
			this.txtDoc.Tag=null;

			this.txtHighOxygen.Text="";
			this.txtHighOxygenTime.Text="";
			this.txtOrderID.Text ="";
			this.txtResume.Text="";

            MDIParent.m_mthSetDefaulEmployee(m_txtSign);
		}

		
		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName")
						ctlText.Enabled=false;
					if(typeName == "RichTextBox") ((RichTextBox)ctlText).ReadOnly=true;
					
					
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
					if(typeName == "RichTextBox") ((RichTextBox)ctlText).ReadOnly=false;
										
				}
				blnCanDelete=true;

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
		
		private void txtDoc_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(blnSignSelectAll)
			{
				txtDoc.SelectAll();
				blnSignSelectAll = false;
			}

		
		}

        #region 医师签名		
//        /// <summary>
//        /// 显示医生列表
//        /// </summary>
//        /// <param name="p_strDoctorNameLike">医生号</param>
//        private void m_mthGetDoctorList(string p_strDoctorNameLike)
//        {
			
//            /*
//             * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
//             * 在相应的位置显示ListView。
//             */			

//            if(p_strDoctorNameLike.Length == 0)
//            {
//                lsvLike.Visible = false;
//                return;
//            }

//            clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

//            if(objDoctorArr == null)
//            {
//                lsvLike.Visible = false;
//                return;
//            }

//            lsvLike.Items.Clear();

//            for(int i=0;i<objDoctorArr.Length;i++)
//            {
//                ListViewItem lviDoctor = new ListViewItem(
//                    new string[]{
//                                    objDoctorArr[i].m_StrEmployeeID,
//                                    objDoctorArr[i].m_StrFirstName
//                                });
//                lviDoctor.Tag = objDoctorArr[i];

//                lsvLike.Items.Add(lviDoctor);
//            }

//            m_mthChangeListViewLastColumnWidth(lsvLike);
//            lsvLike.BringToFront();
//            lsvLike.Visible = true;
//        }

//        private void lsvLike_DoubleClick(object sender, System.EventArgs e)
//        {
//            /*
//             * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
//             */
//            if(lsvLike.SelectedItems.Count <= 0)
//                return;

//            clsEmployee objEmp = (clsEmployee)lsvLike.SelectedItems[0].Tag;

//            if(objEmp == null)
//                return;	

//            //报告医生不需要签名
////			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
////				return;

//            lsvLike.Visible = false;
//            txtDoc.Text=objEmp.m_StrLastName;
//            txtDoc.Tag= objEmp.m_StrEmployeeID;
//            txtDoc.Focus();
//        }

//        private void lsvLike_LostFocus(object sender,EventArgs e)
//        {							
//            if(!txtDoc.Focused && !lsvLike.Focused)
//            {
//                lsvLike.Visible=false;				
//            }				
//        }	

        #endregion 医师签名
		
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
                    //if(((Control)sender).Name=="txtDoc")
                    //{						
                    //    m_mthGetDoctorList(txtDoc.Text);

                    //    if(lsvLike.Items.Count==1 && (txtDoc.Text==lsvLike.Items[0].SubItems[0].Text|| txtDoc.Text==lsvLike.Items[0].SubItems[1].Text))
                    //    {
                    //        lsvLike.Items[0].Selected=true;
                    //        lsvLike_DoubleClick(null,null);
                    //        break;
                    //    }
                    //}					
                    //else if(((Control)sender).Name=="lsvLike")
                    //{
                    //    lsvLike_DoubleClick(null,null);						
                    //}

					break;

				case 38:
				case 40:
                    //if(((Control)sender).Name=="txtDoc")
                    //{
                    //    if(txtDoc.Text.Length>0)
                    //    {	
                    //        if(lsvLike.Visible==false || lsvLike.Items.Count==0)
                    //        {								
                    //            m_mthGetDoctorList(txtDoc.Text);
                    //        }

                    //        lsvLike.BringToFront();
                    //        lsvLike.Visible=true;
                    //        lsvLike.Focus();
                    //        if( lsvLike.Items.Count>0)
                    //        {
                    //            lsvLike.Items[0].Selected=true;
                    //            lsvLike.Items[0].Focused=true;
                    //        }	
                    //    }
                    //}					
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
					m_objHightOxygen=null;
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
* DataSet : dtsHighOxygen
* DataTable : dtbHighOxygen
* 	DataColumn : PatientName(string)
* 	DataColumn : PatientSex(string)
* 	DataColumn : PatientAge(string)
* 	DataColumn : PatientDepartment(string)
* 	DataColumn : ApplyDate(string)
* 	DataColumn : OrderID(string)
* 	DataColumn : Resume(string)
* 	DataColumn : ClinicCheck(string)
* 	DataColumn : AssistantCT(string)
* 	DataColumn : AssistantMR(string)
* 	DataColumn : AssistantEEG(string)
* 	DataColumn : AssistantEKG(string)
* 	DataColumn : AssistantOther(string)
* 	DataColumn : ClinicCure(string)
* 	DataColumn : HighOxygen(string)
* 	DataColumn : ClinicDiagnose(string)
* 	DataColumn : HighOxygenTime(string)
* 	DataColumn : ApplyDocID(string)
* 	DataColumn : DocID(string)
*/ 
		private DataSet m_dtsInitdtsHighOxygenDataSet()
		{
			DataSet dsdtsHighOxygen = new DataSet("dtsHighOxygen");

			DataTable dtdtbHighOxygen = new DataTable("dtbHighOxygen");

			DataColumn dcdtbHighOxygenPatientName = new DataColumn("PatientName",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenPatientName);

			DataColumn dcdtbHighOxygenPatientSex = new DataColumn("PatientSex",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenPatientSex);

			DataColumn dcdtbHighOxygenPatientAge = new DataColumn("PatientAge",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenPatientAge);

			DataColumn dcdtbHighOxygenPatientDepartment = new DataColumn("PatientDepartment",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenPatientDepartment);

			DataColumn dcdtbHighOxygenApplyDate = new DataColumn("ApplyDate",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenApplyDate);

			DataColumn dcdtbHighOxygenOrderID = new DataColumn("OrderID",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenOrderID);

			DataColumn dcdtbHighOxygenResume = new DataColumn("Resume",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenResume);

			DataColumn dcdtbHighOxygenClinicCheck = new DataColumn("ClinicCheck",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenClinicCheck);

			DataColumn dcdtbHighOxygenAssistantCT = new DataColumn("AssistantCT",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenAssistantCT);

			DataColumn dcdtbHighOxygenAssistantMR = new DataColumn("AssistantMR",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenAssistantMR);

			DataColumn dcdtbHighOxygenAssistantEEG = new DataColumn("AssistantEEG",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenAssistantEEG);

			DataColumn dcdtbHighOxygenAssistantEKG = new DataColumn("AssistantEKG",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenAssistantEKG);

			DataColumn dcdtbHighOxygenAssistantOther = new DataColumn("AssistantOther",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenAssistantOther);

			DataColumn dcdtbHighOxygenClinicCure = new DataColumn("ClinicCure",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenClinicCure);

			DataColumn dcdtbHighOxygenHighOxygen = new DataColumn("HighOxygen",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenHighOxygen);

			DataColumn dcdtbHighOxygenClinicDiagnose = new DataColumn("ClinicDiagnose",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenClinicDiagnose);

			DataColumn dcdtbHighOxygenHighOxygenTime = new DataColumn("HighOxygenTime",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenHighOxygenTime);

			DataColumn dcdtbHighOxygenApplyDocID = new DataColumn("ApplyDocID",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenApplyDocID);

			DataColumn dcdtbHighOxygenDocID = new DataColumn("DocID",typeof(string));

			dtdtbHighOxygen.Columns.Add(dcdtbHighOxygenDocID);

			dsdtsHighOxygen.Tables.Add(dtdtbHighOxygen);

			return dsdtsHighOxygen;
		}

		/*
		* DataSet : dtsHighOxygen
		* DataTable : dtbHighOxygen
		* 	DataColumn1 : PatientName(string)
		* 	DataColumn2 : PatientSex(string)
		* 	DataColumn3 : PatientAge(string)
		* 	DataColumn4 : PatientDepartment(string)
		* 	DataColumn5 : ApplyDate(string)
		* 	DataColumn6 : OrderID(string)
		* 	DataColumn7 : Resume(string)
		* 	DataColumn8 : ClinicCheck(string)
		* 	DataColumn9 : AssistantCT(string)
		* 	DataColumn10 : AssistantMR(string)
		* 	DataColumn11 : AssistantEEG(string)
		* 	DataColumn12 : AssistantEKG(string)
		* 	DataColumn13 : AssistantOther(string)
		* 	DataColumn14 : ClinicCure(string)
		* 	DataColumn15 : HighOxygen(string)
		* 	DataColumn16 : ClinicDiagnose(string)
		* 	DataColumn17 : HighOxygenTime(string)
		* 	DataColumn18 : ApplyDocID(string)
		* 	DataColumn19 : DocID(string)
		*/ 
		private void m_mthAddNewDataFordtsHighOxygenDataSet(DataSet dsdtsHighOxygen)
		{
			DataTable dtdtbHighOxygen = dsdtsHighOxygen.Tables["DTBHIGHOXYGEN"];
			dtdtbHighOxygen.Rows.Clear();

			object [] objdtbHighOxygenDatas = new object[19];

			if(m_objHightOxygen!=null && m_objCurrentPatient!=null && m_ObjCurrentEmrPatientSession != null)
			{
	
				objdtbHighOxygenDatas[0] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
				objdtbHighOxygenDatas[1] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
				objdtbHighOxygenDatas[2] =m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objdtbHighOxygenDatas[3] = m_ObjCurrentEmrPatientSession.m_strAreaName;
				objdtbHighOxygenDatas[4] =DateTime.Parse(m_objHightOxygen.strCreateDate).ToString("yyyy年MM月dd日");
				objdtbHighOxygenDatas[5] =m_objHightOxygen.strOrderID ;
				objdtbHighOxygenDatas[6] =m_objHightOxygen.strResume ;
				objdtbHighOxygenDatas[7] =m_objHightOxygen.strClinicCheck ;
				objdtbHighOxygenDatas[8] =m_objHightOxygen.strAssistantCT ;
				objdtbHighOxygenDatas[9] =m_objHightOxygen.strAssistantMR ;
				objdtbHighOxygenDatas[10] =m_objHightOxygen.strAssistantEEG ;
				objdtbHighOxygenDatas[11] =m_objHightOxygen.strAssistantEKG ;
				objdtbHighOxygenDatas[12] =m_objHightOxygen.strAssistantOthe ;
				objdtbHighOxygenDatas[13] =m_objHightOxygen.strClinicCure ;
				objdtbHighOxygenDatas[14] =m_objHightOxygen.strHighOxygen ;
				objdtbHighOxygenDatas[15] =m_objHightOxygen.strClinicDiagnose ;
				objdtbHighOxygenDatas[16] =m_objHightOxygen.strHighOxygenTime;
				objdtbHighOxygenDatas[17] =m_txtSign.Text ;
                objdtbHighOxygenDatas[18] = txtDoc.Text;
			}
			else 
			{
				for(int i=0;i<objdtbHighOxygenDatas.Length-1;i++)
					objdtbHighOxygenDatas[i]="";
			}
				
			dtdtbHighOxygen.Rows.Add(objdtbHighOxygenDatas);
			m_rpdOrderRept.Database.Tables["DTBHIGHOXYGEN"].SetDataSource(dtdtbHighOxygen);

			m_rpdOrderRept.Refresh();

		
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

