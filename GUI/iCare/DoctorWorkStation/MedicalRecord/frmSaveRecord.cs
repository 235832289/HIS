using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;

namespace iCare
{
	/*
	 * 2003-8-27 liyi修改：
	 * 1.把“病情变化情况”和“抢救措施”合拼，输入框使用原来“病情变化情况”输入框。
	 * 2.把“抢救措施”改为“在场家属”，并移到“抢救结果”下面。
	 * 3.数据库所有字段不改变。
	 */ 
	public class frmSaveRecord : iCare.frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label label6;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpSaveTime;
		private System.Windows.Forms.Label lblDiscussContentTitle;
		private System.Windows.Forms.Label lblDeadDiagnoseTitle;
		private System.Windows.Forms.Label lblDeadReasonTitle;
		private PinkieControls.ButtonXP cmdConfirm;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiseaseChangeCase;
		private com.digitalwave.controls.ctlRichTextBox m_txtSaveDeal;
		private com.digitalwave.controls.ctlRichTextBox m_txtDiseaseName;
		private com.digitalwave.controls.ctlRichTextBox m_txtSaveResult;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.ComponentModel.IContainer components = null;

		private PinkieControls.ButtonXP m_cmdSaveDoctor;
		private clsCommonUseToolCollection m_objCUTC;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		protected System.Windows.Forms.ListView lsvAttendPeople;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private PinkieControls.ButtonXP m_cmdEmployeeSign;

		//定义签名类
		private clsEmrSignToolCollection m_objSign;

		public frmSaveRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			 
//
//			m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	m_lsvSaveDoctor});
			cmdConfirm.Visible=false;
			
			m_mthSetRichTextBoxAttribInControl(this);
            //指明医生工作站表单
            intFormType = 1;
			this.Text="抢救记录";			
			this.m_lblForTitle.Text=this.Text;			
		
		 
		 

		 
			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdSaveDoctor, lsvAttendPeople, 0, false, clsEMRLogin.LoginInfo.m_strEmpID);



//			m_objSignTool.m_mthAddListViewDeleteMenu(new ListView[]{m_lsvSaveDoctor});
		}

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
            this.label6 = new System.Windows.Forms.Label();
            this.m_dtpSaveTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblDiscussContentTitle = new System.Windows.Forms.Label();
            this.m_txtDiseaseName = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDeadDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtDiseaseChangeCase = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDeadReasonTitle = new System.Windows.Forms.Label();
            this.m_txtSaveDeal = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_txtSaveResult = new com.digitalwave.controls.ctlRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.m_cmdSaveDoctor = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lsvAttendPeople = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(2, -89);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(30, 30);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(114, 26);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(480, -33);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(376, -25);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(632, -35);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(538, -21);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(304, -21);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(570, -20);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(432, -21);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(580, -21);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(684, -21);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(352, -25);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(148, -105);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(596, -38);
            this.txtInPatientID.Size = new System.Drawing.Size(112, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(480, -25);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(352, -25);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(408, -29);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(78, -105);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(40, -105);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(124, -34);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(68, -26);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(28, 485);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(240, -62);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(200, -62);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(316, -58);
            this.m_lblForTitle.Text = "抢 救 记 录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(24, 485);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(527, -41);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(54, -74);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(366, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 29163;
            this.label6.Text = "抢救时间:";
            // 
            // m_dtpSaveTime
            // 
            this.m_dtpSaveTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpSaveTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpSaveTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpSaveTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpSaveTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpSaveTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpSaveTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpSaveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpSaveTime.Location = new System.Drawing.Point(442, 26);
            this.m_dtpSaveTime.m_BlnOnlyTime = false;
            this.m_dtpSaveTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpSaveTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpSaveTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpSaveTime.Name = "m_dtpSaveTime";
            this.m_dtpSaveTime.ReadOnly = false;
            this.m_dtpSaveTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpSaveTime.TabIndex = 110;
            this.m_dtpSaveTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpSaveTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblDiscussContentTitle
            // 
            this.lblDiscussContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscussContentTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiscussContentTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDiscussContentTitle.Location = new System.Drawing.Point(12, 57);
            this.lblDiscussContentTitle.Name = "lblDiscussContentTitle";
            this.lblDiscussContentTitle.Size = new System.Drawing.Size(98, 40);
            this.lblDiscussContentTitle.TabIndex = 29169;
            this.lblDiscussContentTitle.Text = "危重病情名称:";
            // 
            // m_txtDiseaseName
            // 
            this.m_txtDiseaseName.AccessibleDescription = "危重病情名称";
            this.m_txtDiseaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiseaseName.BackColor = System.Drawing.Color.White;
            this.m_txtDiseaseName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiseaseName.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiseaseName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiseaseName.Location = new System.Drawing.Point(114, 54);
            this.m_txtDiseaseName.m_BlnIgnoreUserInfo = false;
            this.m_txtDiseaseName.m_BlnPartControl = false;
            this.m_txtDiseaseName.m_BlnReadOnly = false;
            this.m_txtDiseaseName.m_BlnUnderLineDST = false;
            this.m_txtDiseaseName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiseaseName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiseaseName.m_IntCanModifyTime = 6;
            this.m_txtDiseaseName.m_IntPartControlLength = 0;
            this.m_txtDiseaseName.m_IntPartControlStartIndex = 0;
            this.m_txtDiseaseName.m_StrUserID = "";
            this.m_txtDiseaseName.m_StrUserName = "";
            this.m_txtDiseaseName.Name = "m_txtDiseaseName";
            this.m_txtDiseaseName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiseaseName.Size = new System.Drawing.Size(808, 108);
            this.m_txtDiseaseName.TabIndex = 120;
            this.m_txtDiseaseName.Text = "";
            // 
            // lblDeadDiagnoseTitle
            // 
            this.lblDeadDiagnoseTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadDiagnoseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadDiagnoseTitle.Location = new System.Drawing.Point(12, 171);
            this.lblDeadDiagnoseTitle.Name = "lblDeadDiagnoseTitle";
            this.lblDeadDiagnoseTitle.Size = new System.Drawing.Size(98, 64);
            this.lblDeadDiagnoseTitle.TabIndex = 29171;
            this.lblDeadDiagnoseTitle.Text = "病情变化情况及抢救措施:";
            // 
            // m_txtDiseaseChangeCase
            // 
            this.m_txtDiseaseChangeCase.AccessibleDescription = "病情变化情况及抢救措施";
            this.m_txtDiseaseChangeCase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDiseaseChangeCase.BackColor = System.Drawing.Color.White;
            this.m_txtDiseaseChangeCase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDiseaseChangeCase.ForeColor = System.Drawing.Color.Black;
            this.m_txtDiseaseChangeCase.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDiseaseChangeCase.Location = new System.Drawing.Point(114, 168);
            this.m_txtDiseaseChangeCase.m_BlnIgnoreUserInfo = false;
            this.m_txtDiseaseChangeCase.m_BlnPartControl = false;
            this.m_txtDiseaseChangeCase.m_BlnReadOnly = false;
            this.m_txtDiseaseChangeCase.m_BlnUnderLineDST = false;
            this.m_txtDiseaseChangeCase.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDiseaseChangeCase.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDiseaseChangeCase.m_IntCanModifyTime = 6;
            this.m_txtDiseaseChangeCase.m_IntPartControlLength = 0;
            this.m_txtDiseaseChangeCase.m_IntPartControlStartIndex = 0;
            this.m_txtDiseaseChangeCase.m_StrUserID = "";
            this.m_txtDiseaseChangeCase.m_StrUserName = "";
            this.m_txtDiseaseChangeCase.Name = "m_txtDiseaseChangeCase";
            this.m_txtDiseaseChangeCase.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDiseaseChangeCase.Size = new System.Drawing.Size(808, 122);
            this.m_txtDiseaseChangeCase.TabIndex = 130;
            this.m_txtDiseaseChangeCase.Text = "";
            // 
            // lblDeadReasonTitle
            // 
            this.lblDeadReasonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeadReasonTitle.AutoSize = true;
            this.lblDeadReasonTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeadReasonTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeadReasonTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeadReasonTitle.Location = new System.Drawing.Point(30, 412);
            this.lblDeadReasonTitle.Name = "lblDeadReasonTitle";
            this.lblDeadReasonTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeadReasonTitle.TabIndex = 29170;
            this.lblDeadReasonTitle.Text = "在场家属:";
            // 
            // m_txtSaveDeal
            // 
            this.m_txtSaveDeal.AccessibleDescription = "在场家属";
            this.m_txtSaveDeal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSaveDeal.BackColor = System.Drawing.Color.White;
            this.m_txtSaveDeal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSaveDeal.ForeColor = System.Drawing.Color.Black;
            this.m_txtSaveDeal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSaveDeal.Location = new System.Drawing.Point(114, 409);
            this.m_txtSaveDeal.m_BlnIgnoreUserInfo = false;
            this.m_txtSaveDeal.m_BlnPartControl = false;
            this.m_txtSaveDeal.m_BlnReadOnly = false;
            this.m_txtSaveDeal.m_BlnUnderLineDST = false;
            this.m_txtSaveDeal.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSaveDeal.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSaveDeal.m_IntCanModifyTime = 6;
            this.m_txtSaveDeal.m_IntPartControlLength = 0;
            this.m_txtSaveDeal.m_IntPartControlStartIndex = 0;
            this.m_txtSaveDeal.m_StrUserID = "";
            this.m_txtSaveDeal.m_StrUserName = "";
            this.m_txtSaveDeal.Multiline = false;
            this.m_txtSaveDeal.Name = "m_txtSaveDeal";
            this.m_txtSaveDeal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSaveDeal.Size = new System.Drawing.Size(808, 24);
            this.m_txtSaveDeal.TabIndex = 150;
            this.m_txtSaveDeal.Text = "";
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(760, 484);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(80, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_txtSaveResult
            // 
            this.m_txtSaveResult.AccessibleDescription = "抢救结果";
            this.m_txtSaveResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSaveResult.BackColor = System.Drawing.Color.White;
            this.m_txtSaveResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSaveResult.ForeColor = System.Drawing.Color.Black;
            this.m_txtSaveResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSaveResult.Location = new System.Drawing.Point(114, 296);
            this.m_txtSaveResult.m_BlnIgnoreUserInfo = false;
            this.m_txtSaveResult.m_BlnPartControl = false;
            this.m_txtSaveResult.m_BlnReadOnly = false;
            this.m_txtSaveResult.m_BlnUnderLineDST = false;
            this.m_txtSaveResult.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSaveResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSaveResult.m_IntCanModifyTime = 6;
            this.m_txtSaveResult.m_IntPartControlLength = 0;
            this.m_txtSaveResult.m_IntPartControlStartIndex = 0;
            this.m_txtSaveResult.m_StrUserID = "";
            this.m_txtSaveResult.m_StrUserName = "";
            this.m_txtSaveResult.Name = "m_txtSaveResult";
            this.m_txtSaveResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSaveResult.Size = new System.Drawing.Size(808, 107);
            this.m_txtSaveResult.TabIndex = 140;
            this.m_txtSaveResult.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 29185;
            this.label1.Text = "抢救结果:";
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(844, 484);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(80, 30);
            this.m_cmdClose.TabIndex = 201;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // m_cmdSaveDoctor
            // 
            this.m_cmdSaveDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdSaveDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSaveDoctor.DefaultScheme = true;
            this.m_cmdSaveDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSaveDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSaveDoctor.Hint = "";
            this.m_cmdSaveDoctor.Location = new System.Drawing.Point(20, 439);
            this.m_cmdSaveDoctor.Name = "m_cmdSaveDoctor";
            this.m_cmdSaveDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSaveDoctor.Size = new System.Drawing.Size(92, 30);
            this.m_cmdSaveDoctor.TabIndex = 10000040;
            this.m_cmdSaveDoctor.Text = "参加人员:";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(116, 485);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(92, 30);
            this.m_cmdEmployeeSign.TabIndex = 10000041;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "医师签名:";
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(214, 484);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(534, 28);
            this.lsvSign.TabIndex = 10000042;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // lsvAttendPeople
            // 
            this.lsvAttendPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvAttendPeople.BackColor = System.Drawing.Color.White;
            this.lsvAttendPeople.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvAttendPeople.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvAttendPeople.ForeColor = System.Drawing.Color.Black;
            this.lsvAttendPeople.FullRowSelect = true;
            this.lsvAttendPeople.GridLines = true;
            this.lsvAttendPeople.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvAttendPeople.Location = new System.Drawing.Point(116, 440);
            this.lsvAttendPeople.Name = "lsvAttendPeople";
            this.lsvAttendPeople.Size = new System.Drawing.Size(808, 28);
            this.lsvAttendPeople.TabIndex = 10000043;
            this.lsvAttendPeople.UseCompatibleStateImageBehavior = false;
            this.lsvAttendPeople.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // frmSaveRecord
            // 
            this.AccessibleDescription = "抢救记录";
            this.CancelButton = this.m_cmdClose;
            this.ClientSize = new System.Drawing.Size(954, 527);
            this.Controls.Add(this.lsvAttendPeople);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeadReasonTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_txtSaveResult);
            this.Controls.Add(this.m_txtDiseaseName);
            this.Controls.Add(this.m_txtDiseaseChangeCase);
            this.Controls.Add(this.m_txtSaveDeal);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdSaveDoctor);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.lblDiscussContentTitle);
            this.Controls.Add(this.lblDeadDiagnoseTitle);
            this.Controls.Add(this.m_dtpSaveTime);
            this.Name = "frmSaveRecord";
            this.Text = "抢救记录";
            this.Load += new System.EventHandler(this.frmSaveRecord_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpSaveTime, 0);
            this.Controls.SetChildIndex(this.lblDeadDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblDiscussContentTitle, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdSaveDoctor, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_txtSaveDeal, 0);
            this.Controls.SetChildIndex(this.m_txtDiseaseChangeCase, 0);
            this.Controls.SetChildIndex(this.m_txtDiseaseName, 0);
            this.Controls.SetChildIndex(this.m_txtSaveResult, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblDeadReasonTitle, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lsvAttendPeople, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			clsSaveRecordInfo objTrackInfo = new clsSaveRecordInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			//设置m_strTitle和m_dtmRecordTime
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = "抢救记录";			
			
			return objTrackInfo;		
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//默认签名
			MDIParent.m_mthSetDefaulEmployee(lsvSign);

 			//清空具体记录内容			
			m_txtDiseaseName.m_mthClearText();			
			m_txtDiseaseChangeCase.m_mthClearText();
			m_txtSaveDeal.m_mthClearText();
			m_txtSaveResult.m_mthClearText();
  			 
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
			if(p_blnEnable==false)
			{
                //foreach(Control control in this.Controls)
                //{					
                //    control.Top=control.Top-105;				
                //}
			
				cmdConfirm.Visible=true;
				
                //this.Size=new Size(this.Size.Width, this.Size.Height-105);
				this.CenterToParent();				
			}
            //this.MaximizeBox=false;
		}

		/// <summary>
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
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected override clsTrackRecordContent m_objGetContentFromGUI()
		{
			//界面参数校验
			int intSignCount=lsvSign.Items.Count;
			int intAtend=lsvAttendPeople.Items.Count;
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null||intSignCount==0)				
				return null;
			if (intAtend==0)
			{
				clsPublicFunction.ShowInformationMessageBox("至少有一个参加人员");
				return null;

			}
			
			//从界面获取表单值
			clsSaveRecordContent objContent=new clsSaveRecordContent();

			#region 获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount+intAtend];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign,lsvAttendPeople }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
			//获取正式签名
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmSaveRecord";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,
            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
            //}
			objContent.m_strModifyUserID=strUserIDList;
			//获取参加人员签名
            //for (int i = 0; i < intAtend; i++)
            //{
            //    objContent.objSignerArr[intSignCount+i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[intSignCount+i].objEmployee=(clsEmrEmployeeBase_VO)( lsvAttendPeople.Items[i].Tag);
            //    objContent.objSignerArr[intSignCount+i].controlName="lsvAttendPeople";
            //    objContent.objSignerArr[intSignCount+i].m_strFORMID_VCHR="frmSaveRecord";//注意大小写
            //    objContent.objSignerArr[intSignCount+i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //}

			#endregion

			//设置Richtextbox的modifyuserID 和modifyuserName
			m_mthSetRichTextBoxAttribInControlWithIDandName(this);
			#region 是否可以无痕迹修改
			if (chkModifyWithoutMatk.Checked)
				objContent.m_intMarkStatus=0;
			else
				objContent.m_intMarkStatus=1;
			#endregion

			//获取表单值
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;	
			
			objContent.m_dtmSaveTime = m_dtpSaveTime.Value;
				
			objContent.m_strDiseaseName_Right=m_txtDiseaseName.m_strGetRightText();	
			objContent.m_strDiseaseName=m_txtDiseaseName.Text;
			objContent.m_strDiseaseNameXML=m_txtDiseaseName.m_strGetXmlText();					
			
			objContent.m_strDiseaseChangeCase_Right=m_txtDiseaseChangeCase.m_strGetRightText();	
			objContent.m_strDiseaseChangeCase=m_txtDiseaseChangeCase.Text;
			objContent.m_strDiseaseChangeCaseXML=m_txtDiseaseChangeCase.m_strGetXmlText();			
			
			objContent.m_strSaveDeal_Right=m_txtSaveDeal.m_strGetRightText();	
			objContent.m_strSaveDeal=m_txtSaveDeal.Text;
			objContent.m_strSaveDealXML=m_txtSaveDeal.m_strGetXmlText();			
			
			objContent.m_strSaveResult_Right=m_txtSaveResult.m_strGetRightText();	
			objContent.m_strSaveResult=m_txtSaveResult.Text;
			objContent.m_strSaveResultXML=m_txtSaveResult.m_strGetXmlText();

		

			
 
			return objContent;	
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsSaveRecordContent objContent=(clsSaveRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpSaveTime.Value = objContent.m_dtmSaveTime;

			m_txtDiseaseName.m_mthSetNewText(objContent.m_strDiseaseName,objContent.m_strDiseaseNameXML);		
			m_txtDiseaseChangeCase.m_mthSetNewText(objContent.m_strDiseaseChangeCase,objContent.m_strDiseaseChangeCaseXML);		
			m_txtSaveDeal.m_mthSetNewText(objContent.m_strSaveDeal,objContent.m_strSaveDealXML);		
			m_txtSaveResult.m_mthSetNewText(objContent.m_strSaveResult,objContent.m_strSaveResultXML);	
			
			
			#region 签名集合
			
			if (objContent.objSignerArr!=null)
			{
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                m_mthAddSignToListView(lsvAttendPeople, objContent.objSignerArr);
				//正式签名
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR + "(" + objContent.objSignerArr[i].objEmployee.m_strTECHNICALRANK_CHR + ");");
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvSign.Items.Add(lviNewItem);
                //    }
                //}
                ////参加人员
                //lsvAttendPeople.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvAttendPeople")
                //    {
                //        ListViewItem lviNewItem = new ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR + "(" + objContent.objSignerArr[i].objEmployee.m_strTECHNICALRANK_CHR + ");");
                //        //ID 检查重复用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR);
                //        //级别 排序用
                //        lviNewItem.SubItems.Add(objContent.objSignerArr[i].objEmployee.m_strLEVEL_CHR);
                //        //tag均为对象
                //        lviNewItem.Tag=objContent.objSignerArr[i].objEmployee;
                //        //是按顺序保存故获取顺序也一样
                //        lsvAttendPeople.Items.Add(lviNewItem);
                //    }
                //}
			}
			
			#endregion 签名	
		}

		public override int m_IntFormID
		{
			get
			{
				return 17;
			}
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			clsSaveRecordContent objContent=(clsSaveRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
			m_dtpSaveTime.Value = objContent.m_dtmSaveTime;

			m_txtDiseaseName.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiseaseName,objContent.m_strDiseaseNameXML);		
			m_txtDiseaseChangeCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiseaseChangeCase,objContent.m_strDiseaseChangeCaseXML);		
			m_txtSaveDeal.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSaveDeal,objContent.m_strSaveDealXML);		
			m_txtSaveResult.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSaveResult,objContent.m_strSaveResultXML);	
//			m_txtAttendPeople.Text =com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAttendPeople,objContent.m_strAttendPeopleXML );
		}
		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.Save);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsSaveRecordContent objContent=(clsSaveRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现

			m_txtDiseaseName.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiseaseName,objContent.m_strDiseaseNameXML);		
			m_txtDiseaseChangeCase.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDiseaseChangeCase,objContent.m_strDiseaseChangeCaseXML);		
			m_txtSaveDeal.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSaveDeal,objContent.m_strSaveDealXML);		
			m_txtSaveResult.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strSaveResult,objContent.m_strSaveResultXML);	
//			m_txtAttendPeople.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strAttendPeople,objContent.m_strAttendPeopleXML ); 
		}
		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return	"抢救记录";
		}	
	
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected override void m_mthSelectRootNode()
		{
			
		}



		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}		

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmSaveRecord_Load(object sender, System.EventArgs e)
		{
//			m_cmdNewTemplate.Left=cmdConfirm.Left-m_cmdNewTemplate.Width+(cmdConfirm.Right-m_cmdClose.Left);
//			m_cmdNewTemplate.Top=cmdConfirm.Top;
//		m_cmdNewTemplate.Visible=true;

			
			this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetDefaultTimeFlag();
			m_dtpSaveTime.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetDefaultTimeFlag();
			m_dtpSaveTime.m_mthResetSize();
			this.m_dtpCreateDate.m_mthResetSize();

			m_txtDiseaseName.Focus();
		}

		private void m_txtByDoctorSign_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lblMainDoctorSign_Click(object sender, System.EventArgs e)
		{
		
		}
	
		/// <summary>
		/// 数据复用
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		{
//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.m_txtDiseaseName.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//			}
		}

	

	}
}

