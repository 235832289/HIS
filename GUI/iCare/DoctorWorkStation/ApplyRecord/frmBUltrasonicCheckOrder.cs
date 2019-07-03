using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using HRP;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	public class frmBUltrasonicCheckOrder : frmHRPBaseForm,PublicFunction 
	{
		#region Windows Generate
		private System.Windows.Forms.TreeView trvTime;
		protected System.Windows.Forms.Label lblOperationBeginTimeTitle;
		protected System.Windows.Forms.Label label1;
		private com.digitalwave.controls.ctlRichTextBox txtHistory;
		protected System.Windows.Forms.Label label2;
		private com.digitalwave.controls.ctlRichTextBox txtBodyCheck;
		protected System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label4;
		private com.digitalwave.controls.ctlRichTextBox txtXRayCheck;
		protected System.Windows.Forms.Label label5;
		private com.digitalwave.controls.ctlRichTextBox txtLabCheck;
		protected System.Windows.Forms.Label label6;
		private com.digitalwave.controls.ctlRichTextBox txtOtherCheck;
		protected System.Windows.Forms.Label label7;
		private com.digitalwave.controls.ctlRichTextBox txtClinicalDisgonse;
		protected System.Windows.Forms.Label label8;
		private com.digitalwave.controls.ctlRichTextBox txtCheckPlace;
		protected System.Windows.Forms.Label lblDoctor;
		protected System.Windows.Forms.Label lblDept_Local ;
		protected System.Windows.Forms.Label label10;
		private com.digitalwave.controls.ctlRichTextBox txtOperationInformation;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpOperationDate;
		protected System.Windows.Forms.Label label12;
		protected System.Windows.Forms.Label label13;
		protected System.Windows.Forms.Label label14;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpDisgnoseDate;
		public com.digitalwave.controls.ctlRichTextBox txtXRayNumber;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpXRayDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpApplicateDate;
		protected System.Windows.Forms.Label label15;
		protected System.Windows.Forms.Label lblSickRoom;
		protected System.Windows.Forms.Label label16;
		protected System.Windows.Forms.Label lblAddress;
		protected System.Windows.Forms.Label label17;
        public com.digitalwave.controls.ctlRichTextBox txtCheckNumber;
		private System.ComponentModel.IContainer components = null;
		#endregion
		public com.digitalwave.controls.ctlRichTextBox m_txtApplicationID;
		protected System.Windows.Forms.Label label18;
		private PinkieControls.ButtonXP m_cmdRequestDoctor;

		private clsEmployeeSignTool m_objSignTool;
		private System.Windows.Forms.CheckBox m_chkNeedRequire;
		protected System.Windows.Forms.RichTextBox m_txtApplicationComment;
        private TextBox m_txtSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
		
		#region Constructor
		public frmBUltrasonicCheckOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_objDomain = new clsBUltrasonicCheckOrderDomain();

            //m_objBorderTool = new clsBorderTool(Color.White);

			#region White Border
            //m_objBorderTool.m_mthChangedControlBorder(m_txtApplicationComment);
            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox")
            //    {
            //        //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //        //                                    {
            //        //                                        ctlControl ,
            //        //});
            //    }
            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlControl ,
            //        });
					
            //    }
            //}
			#endregion

			m_mthSetQuickKeys();

			m_dtsRept = InitdtsBUltrasoniceCheckOrderDataSet();

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdRequestDoctor, m_txtSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

            TreeNode trnNode = new TreeNode("申请日期");
            trnNode.Tag = "0";
            this.trvTime.Nodes.Add(trnNode);
		}
		#endregion 

		#region Member
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private clsBorderTool  m_objBorderTool;

		private bool m_blnCanSearch = true;

		private string m_strInPatientID;

		private string m_strInPatientDate;

		private clsPatient m_objSelectedPatient=null;

		private clsBUltrasonicCheckOrderDomain m_objDomain; 

		private string m_strCreateDate = "";

		private clsBUltrasonicCheckOrder m_objBUltrasonicCheckOrder=null;
		private bool blnCanDelete=true;

		/// <summary>
		/// 出报表的DataSet
		/// </summary>
		private DataSet m_dtsRept;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
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
            this.trvTime = new System.Windows.Forms.TreeView();
            this.dtpApplicateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblOperationBeginTimeTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHistory = new com.digitalwave.controls.ctlRichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBodyCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpXRayDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXRayNumber = new com.digitalwave.controls.ctlRichTextBox();
            this.txtXRayCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLabCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOtherCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClinicalDisgonse = new com.digitalwave.controls.ctlRichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCheckPlace = new com.digitalwave.controls.ctlRichTextBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblDept_Local = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOperationInformation = new com.digitalwave.controls.ctlRichTextBox();
            this.dtpOperationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDisgnoseDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSickRoom = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCheckNumber = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtApplicationID = new com.digitalwave.controls.ctlRichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cmdRequestDoctor = new PinkieControls.ButtonXP();
            this.m_chkNeedRequire = new System.Windows.Forms.CheckBox();
            this.m_txtApplicationComment = new System.Windows.Forms.RichTextBox();
            this.m_txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(229, 151);
            this.lblSex.Size = new System.Drawing.Size(32, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(212, 151);
            this.lblAge.Size = new System.Drawing.Size(32, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(224, 152);
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(214, 156);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(204, 149);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(212, 156);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(252, 158);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(214, 156);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(207, 155);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(23, 15);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(215, 156);
            this.txtInPatientID.Size = new System.Drawing.Size(11, 23);
            this.txtInPatientID.TabIndex = 3;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(198, 160);
            this.m_txtPatientName.Size = new System.Drawing.Size(11, 23);
            this.m_txtPatientName.TabIndex = 2;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(222, 149);
            this.m_txtBedNO.Size = new System.Drawing.Size(10, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(227, 158);
            this.m_cboArea.Size = new System.Drawing.Size(10, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(216, 146);
            this.m_lsvPatientName.Size = new System.Drawing.Size(14, 24);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(232, 160);
            this.m_lsvBedNO.Size = new System.Drawing.Size(10, 10);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(227, 163);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(204, 146);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(217, 146);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(22, 10);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(218, 160);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(222, 145);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(632, 36);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 8);
            this.m_lblForTitle.Text = "B型超声显像检查申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(343, 154);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(731, 97);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 29);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(797, 58);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(795, 27);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(10, 66);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(184, 63);
            this.trvTime.TabIndex = 4;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // dtpApplicateDate
            // 
            this.dtpApplicateDate.BackColor = System.Drawing.Color.White;
            this.dtpApplicateDate.BorderColor = System.Drawing.Color.Black;
            this.dtpApplicateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpApplicateDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpApplicateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpApplicateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpApplicateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpApplicateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpApplicateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApplicateDate.Location = new System.Drawing.Point(464, 100);
            this.dtpApplicateDate.m_BlnOnlyTime = false;
            this.dtpApplicateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpApplicateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplicateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplicateDate.Name = "dtpApplicateDate";
            this.dtpApplicateDate.ReadOnly = false;
            this.dtpApplicateDate.Size = new System.Drawing.Size(212, 22);
            this.dtpApplicateDate.TabIndex = 5;
            this.dtpApplicateDate.TextBackColor = System.Drawing.Color.White;
            this.dtpApplicateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblOperationBeginTimeTitle
            // 
            this.lblOperationBeginTimeTitle.AutoSize = true;
            this.lblOperationBeginTimeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationBeginTimeTitle.Location = new System.Drawing.Point(392, 104);
            this.lblOperationBeginTimeTitle.Name = "lblOperationBeginTimeTitle";
            this.lblOperationBeginTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblOperationBeginTimeTitle.TabIndex = 520;
            this.lblOperationBeginTimeTitle.Text = "申请日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 521;
            this.label1.Text = "病史摘要:";
            // 
            // txtHistory
            // 
            this.txtHistory.AccessibleDescription = "病史摘要";
            this.txtHistory.BackColor = System.Drawing.Color.White;
            this.txtHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHistory.ForeColor = System.Drawing.Color.Black;
            this.txtHistory.Location = new System.Drawing.Point(10, 147);
            this.txtHistory.m_BlnPartControl = false;
            this.txtHistory.m_BlnReadOnly = false;
            this.txtHistory.m_BlnUnderLineDST = false;
            this.txtHistory.m_ClrDST = System.Drawing.Color.Red;
            this.txtHistory.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtHistory.m_IntCanModifyTime = 6;
            this.txtHistory.m_IntPartControlLength = 0;
            this.txtHistory.m_IntPartControlStartIndex = 0;
            this.txtHistory.m_StrUserID = "";
            this.txtHistory.m_StrUserName = "";
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtHistory.Size = new System.Drawing.Size(776, 60);
            this.txtHistory.TabIndex = 7;
            this.txtHistory.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 14);
            this.label2.TabIndex = 1293;
            this.label2.Text = "体检（注意肝、脾、子宫、附件、腹块的大小，质地）";
            // 
            // txtBodyCheck
            // 
            this.txtBodyCheck.AccessibleDescription = "体检";
            this.txtBodyCheck.BackColor = System.Drawing.Color.White;
            this.txtBodyCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBodyCheck.ForeColor = System.Drawing.Color.Black;
            this.txtBodyCheck.Location = new System.Drawing.Point(8, 231);
            this.txtBodyCheck.m_BlnPartControl = false;
            this.txtBodyCheck.m_BlnReadOnly = false;
            this.txtBodyCheck.m_BlnUnderLineDST = false;
            this.txtBodyCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtBodyCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtBodyCheck.m_IntCanModifyTime = 6;
            this.txtBodyCheck.m_IntPartControlLength = 0;
            this.txtBodyCheck.m_IntPartControlStartIndex = 0;
            this.txtBodyCheck.m_StrUserID = "";
            this.txtBodyCheck.m_StrUserName = "";
            this.txtBodyCheck.Name = "txtBodyCheck";
            this.txtBodyCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtBodyCheck.Size = new System.Drawing.Size(380, 64);
            this.txtBodyCheck.TabIndex = 8;
            this.txtBodyCheck.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 1295;
            this.label3.Text = "X线检查(日期";
            // 
            // dtpXRayDate
            // 
            this.dtpXRayDate.BorderColor = System.Drawing.Color.Black;
            this.dtpXRayDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpXRayDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpXRayDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpXRayDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpXRayDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpXRayDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpXRayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpXRayDate.Location = new System.Drawing.Point(100, 300);
            this.dtpXRayDate.m_BlnOnlyTime = false;
            this.dtpXRayDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpXRayDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpXRayDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpXRayDate.Name = "dtpXRayDate";
            this.dtpXRayDate.ReadOnly = false;
            this.dtpXRayDate.Size = new System.Drawing.Size(140, 22);
            this.dtpXRayDate.TabIndex = 100;
            this.dtpXRayDate.TextBackColor = System.Drawing.Color.White;
            this.dtpXRayDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(244, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 1297;
            this.label4.Text = ") X线号";
            // 
            // txtXRayNumber
            // 
            this.txtXRayNumber.AccessibleDescription = "X线号";
            this.txtXRayNumber.BackColor = System.Drawing.Color.White;
            this.txtXRayNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXRayNumber.ForeColor = System.Drawing.Color.Black;
            this.txtXRayNumber.Location = new System.Drawing.Point(300, 304);
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
            this.txtXRayNumber.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtXRayNumber.Size = new System.Drawing.Size(88, 20);
            this.txtXRayNumber.TabIndex = 110;
            this.txtXRayNumber.Text = "";
            // 
            // txtXRayCheck
            // 
            this.txtXRayCheck.AccessibleDescription = "X线检查";
            this.txtXRayCheck.BackColor = System.Drawing.Color.White;
            this.txtXRayCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXRayCheck.ForeColor = System.Drawing.Color.Black;
            this.txtXRayCheck.Location = new System.Drawing.Point(8, 328);
            this.txtXRayCheck.m_BlnPartControl = false;
            this.txtXRayCheck.m_BlnReadOnly = false;
            this.txtXRayCheck.m_BlnUnderLineDST = false;
            this.txtXRayCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtXRayCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtXRayCheck.m_IntCanModifyTime = 6;
            this.txtXRayCheck.m_IntPartControlLength = 0;
            this.txtXRayCheck.m_IntPartControlStartIndex = 0;
            this.txtXRayCheck.m_StrUserID = "";
            this.txtXRayCheck.m_StrUserName = "";
            this.txtXRayCheck.Name = "txtXRayCheck";
            this.txtXRayCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtXRayCheck.Size = new System.Drawing.Size(380, 64);
            this.txtXRayCheck.TabIndex = 210;
            this.txtXRayCheck.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 14);
            this.label5.TabIndex = 30008;
            this.label5.Text = "实验室检查（怀疑肝肿瘤时请查AFP －RIA）";
            // 
            // txtLabCheck
            // 
            this.txtLabCheck.AccessibleDescription = "实验室检查";
            this.txtLabCheck.BackColor = System.Drawing.Color.White;
            this.txtLabCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLabCheck.ForeColor = System.Drawing.Color.Black;
            this.txtLabCheck.Location = new System.Drawing.Point(8, 416);
            this.txtLabCheck.m_BlnPartControl = false;
            this.txtLabCheck.m_BlnReadOnly = false;
            this.txtLabCheck.m_BlnUnderLineDST = false;
            this.txtLabCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtLabCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtLabCheck.m_IntCanModifyTime = 6;
            this.txtLabCheck.m_IntPartControlLength = 0;
            this.txtLabCheck.m_IntPartControlStartIndex = 0;
            this.txtLabCheck.m_StrUserID = "";
            this.txtLabCheck.m_StrUserName = "";
            this.txtLabCheck.Name = "txtLabCheck";
            this.txtLabCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLabCheck.Size = new System.Drawing.Size(380, 64);
            this.txtLabCheck.TabIndex = 212;
            this.txtLabCheck.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(404, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 14);
            this.label6.TabIndex = 30010;
            this.label6.Text = "其它检查（A超、同位素等）";
            // 
            // txtOtherCheck
            // 
            this.txtOtherCheck.AccessibleDescription = "其它检查（A超、同位素等）";
            this.txtOtherCheck.BackColor = System.Drawing.Color.White;
            this.txtOtherCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOtherCheck.ForeColor = System.Drawing.Color.Black;
            this.txtOtherCheck.Location = new System.Drawing.Point(404, 231);
            this.txtOtherCheck.m_BlnPartControl = false;
            this.txtOtherCheck.m_BlnReadOnly = false;
            this.txtOtherCheck.m_BlnUnderLineDST = false;
            this.txtOtherCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtOtherCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOtherCheck.m_IntCanModifyTime = 6;
            this.txtOtherCheck.m_IntPartControlLength = 0;
            this.txtOtherCheck.m_IntPartControlStartIndex = 0;
            this.txtOtherCheck.m_StrUserID = "";
            this.txtOtherCheck.m_StrUserName = "";
            this.txtOtherCheck.Name = "txtOtherCheck";
            this.txtOtherCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOtherCheck.Size = new System.Drawing.Size(380, 64);
            this.txtOtherCheck.TabIndex = 9;
            this.txtOtherCheck.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(408, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 30012;
            this.label7.Text = "临床诊断:";
            // 
            // txtClinicalDisgonse
            // 
            this.txtClinicalDisgonse.AccessibleDescription = "临床诊断";
            this.txtClinicalDisgonse.BackColor = System.Drawing.Color.White;
            this.txtClinicalDisgonse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClinicalDisgonse.ForeColor = System.Drawing.Color.Black;
            this.txtClinicalDisgonse.Location = new System.Drawing.Point(404, 328);
            this.txtClinicalDisgonse.m_BlnPartControl = false;
            this.txtClinicalDisgonse.m_BlnReadOnly = false;
            this.txtClinicalDisgonse.m_BlnUnderLineDST = false;
            this.txtClinicalDisgonse.m_ClrDST = System.Drawing.Color.Red;
            this.txtClinicalDisgonse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtClinicalDisgonse.m_IntCanModifyTime = 6;
            this.txtClinicalDisgonse.m_IntPartControlLength = 0;
            this.txtClinicalDisgonse.m_IntPartControlStartIndex = 0;
            this.txtClinicalDisgonse.m_StrUserID = "";
            this.txtClinicalDisgonse.m_StrUserName = "";
            this.txtClinicalDisgonse.Name = "txtClinicalDisgonse";
            this.txtClinicalDisgonse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtClinicalDisgonse.Size = new System.Drawing.Size(380, 64);
            this.txtClinicalDisgonse.TabIndex = 211;
            this.txtClinicalDisgonse.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(404, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 30014;
            this.label8.Text = "要求检查部位";
            // 
            // txtCheckPlace
            // 
            this.txtCheckPlace.AccessibleDescription = "要求检查部位";
            this.txtCheckPlace.BackColor = System.Drawing.Color.White;
            this.txtCheckPlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckPlace.ForeColor = System.Drawing.Color.Black;
            this.txtCheckPlace.Location = new System.Drawing.Point(404, 416);
            this.txtCheckPlace.m_BlnPartControl = false;
            this.txtCheckPlace.m_BlnReadOnly = false;
            this.txtCheckPlace.m_BlnUnderLineDST = false;
            this.txtCheckPlace.m_ClrDST = System.Drawing.Color.Red;
            this.txtCheckPlace.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCheckPlace.m_IntCanModifyTime = 6;
            this.txtCheckPlace.m_IntPartControlLength = 0;
            this.txtCheckPlace.m_IntPartControlStartIndex = 0;
            this.txtCheckPlace.m_StrUserID = "";
            this.txtCheckPlace.m_StrUserName = "";
            this.txtCheckPlace.Name = "txtCheckPlace";
            this.txtCheckPlace.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtCheckPlace.Size = new System.Drawing.Size(380, 64);
            this.txtCheckPlace.TabIndex = 213;
            this.txtCheckPlace.Text = "";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctor.Location = new System.Drawing.Point(516, 892);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(0, 16);
            this.lblDoctor.TabIndex = 30017;
            this.lblDoctor.Visible = false;
            // 
            // lblDept_Local
            // 
            this.lblDept_Local.AutoSize = true;
            this.lblDept_Local.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept_Local.Location = new System.Drawing.Point(628, 532);
            this.lblDept_Local.Name = "lblDept_Local";
            this.lblDept_Local.Size = new System.Drawing.Size(0, 16);
            this.lblDept_Local.TabIndex = 30019;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(12, 516);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 14);
            this.label10.TabIndex = 30020;
            this.label10.Text = "(以下由B超室人员填写)";
            // 
            // txtOperationInformation
            // 
            this.txtOperationInformation.AccessibleDescription = "手术所见";
            this.txtOperationInformation.BackColor = System.Drawing.Color.White;
            this.txtOperationInformation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOperationInformation.ForeColor = System.Drawing.Color.Black;
            this.txtOperationInformation.Location = new System.Drawing.Point(8, 588);
            this.txtOperationInformation.m_BlnPartControl = false;
            this.txtOperationInformation.m_BlnReadOnly = false;
            this.txtOperationInformation.m_BlnUnderLineDST = false;
            this.txtOperationInformation.m_ClrDST = System.Drawing.Color.Red;
            this.txtOperationInformation.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtOperationInformation.m_IntCanModifyTime = 6;
            this.txtOperationInformation.m_IntPartControlLength = 0;
            this.txtOperationInformation.m_IntPartControlStartIndex = 0;
            this.txtOperationInformation.m_StrUserID = "";
            this.txtOperationInformation.m_StrUserName = "";
            this.txtOperationInformation.Name = "txtOperationInformation";
            this.txtOperationInformation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOperationInformation.Size = new System.Drawing.Size(776, 56);
            this.txtOperationInformation.TabIndex = 316;
            this.txtOperationInformation.Text = "";
            // 
            // dtpOperationDate
            // 
            this.dtpOperationDate.BorderColor = System.Drawing.Color.Black;
            this.dtpOperationDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpOperationDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpOperationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpOperationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpOperationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpOperationDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpOperationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOperationDate.Location = new System.Drawing.Point(76, 536);
            this.dtpOperationDate.m_BlnOnlyTime = false;
            this.dtpOperationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpOperationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOperationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOperationDate.Name = "dtpOperationDate";
            this.dtpOperationDate.ReadOnly = false;
            this.dtpOperationDate.Size = new System.Drawing.Size(144, 22);
            this.dtpOperationDate.TabIndex = 314;
            this.dtpOperationDate.TextBackColor = System.Drawing.Color.White;
            this.dtpOperationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(12, 540);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 30023;
            this.label12.Text = "手术日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(12, 564);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 30024;
            this.label13.Text = "手术所见";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(224, 540);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 14);
            this.label14.TabIndex = 30025;
            this.label14.Text = "病理诊断日期";
            // 
            // dtpDisgnoseDate
            // 
            this.dtpDisgnoseDate.BorderColor = System.Drawing.Color.Black;
            this.dtpDisgnoseDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpDisgnoseDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpDisgnoseDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDisgnoseDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpDisgnoseDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpDisgnoseDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDisgnoseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDisgnoseDate.Location = new System.Drawing.Point(316, 536);
            this.dtpDisgnoseDate.m_BlnOnlyTime = false;
            this.dtpDisgnoseDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpDisgnoseDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDisgnoseDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDisgnoseDate.Name = "dtpDisgnoseDate";
            this.dtpDisgnoseDate.ReadOnly = false;
            this.dtpDisgnoseDate.Size = new System.Drawing.Size(144, 22);
            this.dtpDisgnoseDate.TabIndex = 315;
            this.dtpDisgnoseDate.TextBackColor = System.Drawing.Color.White;
            this.dtpDisgnoseDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(219, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 30026;
            this.label15.Text = "病室:";
            this.label15.Visible = false;
            // 
            // lblSickRoom
            // 
            this.lblSickRoom.AutoSize = true;
            this.lblSickRoom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSickRoom.Location = new System.Drawing.Point(444, 108);
            this.lblSickRoom.Name = "lblSickRoom";
            this.lblSickRoom.Size = new System.Drawing.Size(0, 16);
            this.lblSickRoom.TabIndex = 30027;
            this.lblSickRoom.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(204, 146);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 14);
            this.label16.TabIndex = 30028;
            this.label16.Text = "住址:";
            this.label16.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.Location = new System.Drawing.Point(229, 156);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(10, 16);
            this.lblAddress.TabIndex = 30029;
            this.lblAddress.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(200, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 14);
            this.label17.TabIndex = 30030;
            this.label17.Text = "检 查 号:";
            // 
            // txtCheckNumber
            // 
            this.txtCheckNumber.AccessibleDescription = "检查号";
            this.txtCheckNumber.BackColor = System.Drawing.Color.White;
            this.txtCheckNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCheckNumber.ForeColor = System.Drawing.Color.Black;
            this.txtCheckNumber.Location = new System.Drawing.Point(272, 104);
            this.txtCheckNumber.m_BlnPartControl = false;
            this.txtCheckNumber.m_BlnReadOnly = false;
            this.txtCheckNumber.m_BlnUnderLineDST = false;
            this.txtCheckNumber.m_ClrDST = System.Drawing.Color.Red;
            this.txtCheckNumber.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtCheckNumber.m_IntCanModifyTime = 6;
            this.txtCheckNumber.m_IntPartControlLength = 0;
            this.txtCheckNumber.m_IntPartControlStartIndex = 0;
            this.txtCheckNumber.m_StrUserID = "";
            this.txtCheckNumber.m_StrUserName = "";
            this.txtCheckNumber.Multiline = false;
            this.txtCheckNumber.Name = "txtCheckNumber";
            this.txtCheckNumber.Size = new System.Drawing.Size(104, 20);
            this.txtCheckNumber.TabIndex = 6;
            this.txtCheckNumber.Text = "";
            // 
            // m_txtApplicationID
            // 
            this.m_txtApplicationID.AccessibleDescription = "检查号";
            this.m_txtApplicationID.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplicationID.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationID.Location = new System.Drawing.Point(272, 77);
            this.m_txtApplicationID.m_BlnPartControl = false;
            this.m_txtApplicationID.m_BlnReadOnly = true;
            this.m_txtApplicationID.m_BlnUnderLineDST = false;
            this.m_txtApplicationID.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtApplicationID.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtApplicationID.m_IntCanModifyTime = 6;
            this.m_txtApplicationID.m_IntPartControlLength = 0;
            this.m_txtApplicationID.m_IntPartControlStartIndex = 0;
            this.m_txtApplicationID.m_StrUserID = "";
            this.m_txtApplicationID.m_StrUserName = "";
            this.m_txtApplicationID.Multiline = false;
            this.m_txtApplicationID.Name = "m_txtApplicationID";
            this.m_txtApplicationID.ReadOnly = true;
            this.m_txtApplicationID.Size = new System.Drawing.Size(104, 20);
            this.m_txtApplicationID.TabIndex = 6;
            this.m_txtApplicationID.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(200, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 30030;
            this.label18.Text = "申请单号:";
            // 
            // m_cmdRequestDoctor
            // 
            this.m_cmdRequestDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRequestDoctor.DefaultScheme = true;
            this.m_cmdRequestDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRequestDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdRequestDoctor.Hint = "";
            this.m_cmdRequestDoctor.Location = new System.Drawing.Point(596, 528);
            this.m_cmdRequestDoctor.Name = "m_cmdRequestDoctor";
            this.m_cmdRequestDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRequestDoctor.Size = new System.Drawing.Size(84, 24);
            this.m_cmdRequestDoctor.TabIndex = 10000085;
            this.m_cmdRequestDoctor.Tag = "1";
            this.m_cmdRequestDoctor.Text = "申请医师:";
            // 
            // m_chkNeedRequire
            // 
            this.m_chkNeedRequire.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_chkNeedRequire.Location = new System.Drawing.Point(12, 488);
            this.m_chkNeedRequire.Name = "m_chkNeedRequire";
            this.m_chkNeedRequire.Size = new System.Drawing.Size(112, 24);
            this.m_chkNeedRequire.TabIndex = 10000086;
            this.m_chkNeedRequire.Text = "需要预约答复";
            this.m_chkNeedRequire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkNeedRequire.CheckedChanged += new System.EventHandler(this.m_chkNeedRequire_CheckedChanged);
            // 
            // m_txtApplicationComment
            // 
            this.m_txtApplicationComment.AccessibleDescription = "申请检查部位";
            this.m_txtApplicationComment.BackColor = System.Drawing.Color.White;
            this.m_txtApplicationComment.Enabled = false;
            this.m_txtApplicationComment.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplicationComment.ForeColor = System.Drawing.Color.Black;
            this.m_txtApplicationComment.Location = new System.Drawing.Point(132, 488);
            this.m_txtApplicationComment.MaxLength = 150;
            this.m_txtApplicationComment.Multiline = false;
            this.m_txtApplicationComment.Name = "m_txtApplicationComment";
            this.m_txtApplicationComment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtApplicationComment.Size = new System.Drawing.Size(656, 24);
            this.m_txtApplicationComment.TabIndex = 10000087;
            this.m_txtApplicationComment.Text = "";
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(684, 529);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.ReadOnly = true;
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 10000088;
            // 
            // frmBUltrasonicCheckOrder
            // 
            this.AccessibleDescription = "B型超声显像检查申请单";
            this.ClientSize = new System.Drawing.Size(807, 673);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.txtHistory);
            this.Controls.Add(this.dtpOperationDate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOperationBeginTimeTitle);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_chkNeedRequire);
            this.Controls.Add(this.m_cmdRequestDoctor);
            this.Controls.Add(this.txtCheckNumber);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblSickRoom);
            this.Controls.Add(this.dtpDisgnoseDate);
            this.Controls.Add(this.txtOperationInformation);
            this.Controls.Add(this.lblDept_Local);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.txtCheckPlace);
            this.Controls.Add(this.txtClinicalDisgonse);
            this.Controls.Add(this.txtOtherCheck);
            this.Controls.Add(this.txtLabCheck);
            this.Controls.Add(this.txtXRayCheck);
            this.Controls.Add(this.txtXRayNumber);
            this.Controls.Add(this.dtpXRayDate);
            this.Controls.Add(this.txtBodyCheck);
            this.Controls.Add(this.dtpApplicateDate);
            this.Controls.Add(this.m_txtApplicationID);
            this.Controls.Add(this.m_txtApplicationComment);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label16);
            this.Name = "frmBUltrasonicCheckOrder";
            this.Text = "B型超声显像检查申请单";
            this.Load += new System.EventHandler(this.frmBUltrasonicCheckOrder_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.m_txtApplicationComment, 0);
            this.Controls.SetChildIndex(this.m_txtApplicationID, 0);
            this.Controls.SetChildIndex(this.dtpApplicateDate, 0);
            this.Controls.SetChildIndex(this.txtBodyCheck, 0);
            this.Controls.SetChildIndex(this.dtpXRayDate, 0);
            this.Controls.SetChildIndex(this.txtXRayNumber, 0);
            this.Controls.SetChildIndex(this.txtXRayCheck, 0);
            this.Controls.SetChildIndex(this.txtLabCheck, 0);
            this.Controls.SetChildIndex(this.txtOtherCheck, 0);
            this.Controls.SetChildIndex(this.txtClinicalDisgonse, 0);
            this.Controls.SetChildIndex(this.txtCheckPlace, 0);
            this.Controls.SetChildIndex(this.lblDoctor, 0);
            this.Controls.SetChildIndex(this.lblDept_Local, 0);
            this.Controls.SetChildIndex(this.txtOperationInformation, 0);
            this.Controls.SetChildIndex(this.dtpDisgnoseDate, 0);
            this.Controls.SetChildIndex(this.lblSickRoom, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.txtCheckNumber, 0);
            this.Controls.SetChildIndex(this.m_cmdRequestDoctor, 0);
            this.Controls.SetChildIndex(this.m_chkNeedRequire, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblOperationBeginTimeTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.dtpOperationDate, 0);
            this.Controls.SetChildIndex(this.txtHistory, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Control Event
		private void frmBUltrasonicCheckOrder_Load(object sender, System.EventArgs e)
		{
			this.m_lsvInPatientID.Visible =false;

			lblDept_Local .Text = MDIParent.s_ObjDepartment.m_StrDeptName;
			lblDoctor.Text = MDIParent.strOperatorName;

			this.dtpApplicateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpApplicateDate.m_mthResetSize();
            DateTime dtmNow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpDisgnoseDate.Value = dtmNow;
            dtpXRayDate.Value = dtmNow;
            dtpOperationDate.Value = dtmNow;
            dtpApplicateDate.Value = dtmNow;

			trvTime.Focus();
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
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicateDate") 
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
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name!="dtpApplicateDate") 
						((ctlTimePicker)ctlText).Enabled=true;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = false;
										
				}
				blnCanDelete=true;

			}

			m_txtApplicationID.m_BlnReadOnly = true;
		}

        protected bool m_blnCanShowDiseaseTrack = true;
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpRecord();

			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			{
				this.dtpApplicateDate.Enabled=true;
				m_mthReadOnly(false);
			
				m_objBUltrasonicCheckOrder=null;

                if (m_ObjCurrentEmrPatientSession != null)
                {
                    m_mthSetDefaultValue(new clsPatient(true, m_ObjCurrentEmrPatientSession.m_strRegisterId));
                }
				
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);

			}
			else
			{

				this.dtpApplicateDate.Enabled=false;
				
				m_strCreateDate = ((DateTime)trvTime.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss");
				
				m_objBUltrasonicCheckOrder = m_objDomain.m_objGetBUltrasonicCheckOrder(m_strInPatientID,m_strInPatientDate,m_strCreateDate);
				if(m_objBUltrasonicCheckOrder!=null)
				{
					m_mthReadOnly(clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim()!=m_objBUltrasonicCheckOrder.m_strCreateUserID.Trim());
				}
				m_mthDisplay();

				//光标回到床位
				m_txtBedNO.Focus();
				
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}

			m_mthAddFormStatusForClosingSave();
		}
		#endregion

		#region Tools


		private void m_mthClearUpRecord()
		{
            MDIParent.m_mthSetDefaulEmployee(m_txtSign);

			//清除RichTextBox 的内容
			foreach(Control ctlControl in this.Controls )
			{
				string typeName = ctlControl.GetType().FullName;
                if (typeName == "com.digitalwave.controls.ctlRichTextBox")
				{
                    ((com.digitalwave.controls.ctlRichTextBox)ctlControl).m_mthClearText();
				}
			}

			m_strCreateDate = "";
            
			dtpApplicateDate.Enabled=true;
			m_mthReadOnly(false);
            DateTime dtmNow = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dtpApplicateDate.Value = dtmNow;
            dtpDisgnoseDate.Value = dtmNow;
            dtpOperationDate.Value = dtmNow;
            dtpXRayDate.Value = dtmNow;
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

			DateTime [] m_dtmArr= m_objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strPatientID ,p_strPatientDate);

			if(m_dtmArr==null)
			{
				m_mthSetDefaultValue(m_objSelectedPatient);
				return ;
			}

			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate);
				
			}
			this.trvTime.ExpandAll();

			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}

		private void m_mthDisplay()
		{
            if (m_objBUltrasonicCheckOrder == null)
            {
                return;
            }
			dtpApplicateDate.Value = DateTime.Parse(m_objBUltrasonicCheckOrder.m_strCreateDate);
			m_txtApplicationID.Text = m_objBUltrasonicCheckOrder.m_strApplicationID;
			txtCheckNumber.Text = m_objBUltrasonicCheckOrder.m_strCheckNumber;
			txtHistory.Text = m_objBUltrasonicCheckOrder.m_strHistory;
			txtBodyCheck.Text = m_objBUltrasonicCheckOrder.m_strBodyCheck;
			txtXRayNumber.Text = m_objBUltrasonicCheckOrder.m_strXRayNumber;
			txtXRayCheck.Text = m_objBUltrasonicCheckOrder.m_strXRay;
			txtLabCheck.Text = m_objBUltrasonicCheckOrder.m_strLabCheck;
			txtOtherCheck.Text = m_objBUltrasonicCheckOrder.m_strOtherCheck;
			txtClinicalDisgonse.Text = m_objBUltrasonicCheckOrder.m_strClinicalDisgonse;
			txtCheckPlace.Text = m_objBUltrasonicCheckOrder.m_strCheckPlace;
			dtpDisgnoseDate.Value = DateTime.Parse(m_objBUltrasonicCheckOrder.m_strPatholyDisgonseDate);
			txtOperationInformation.Text = m_objBUltrasonicCheckOrder.m_strOperationInformation;
			dtpOperationDate.Value = DateTime.Parse(m_objBUltrasonicCheckOrder.m_strOperationDate);
			dtpXRayDate.Value = DateTime.Parse(m_objBUltrasonicCheckOrder.m_strXRayDate);

            //clsEmployee objEmployee = new clsEmployee(m_objBUltrasonicCheckOrder.m_strCreateUserID);
			clsDepartment objdept = new clsDepartment();
			objdept.m_strDeptNewID = m_objBUltrasonicCheckOrder.m_strCreateUserDeptID;
			
			lblDept_Local .Text = objdept.m_StrDeptName;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByID(m_objBUltrasonicCheckOrder.m_strCreateUserID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                m_txtSign.Tag = objEmpVO;
                lblDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
            }

			m_chkNeedRequire.Checked = false;
			m_txtApplicationComment.Text = "";
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
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Delete()
		{
			m_lngDelete();
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
			this.m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			this.m_lngSave();
		}

		public void Undo()
		{
		
		}
		#endregion

		#region Overide
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
				return dtpApplicateDate.Enabled==true;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

		#region UnUsable
		protected override void m_mthSetPatientBaseInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_blnCanSearch = false;

			m_objSelectedPatient = p_objSelectedPatient;

			m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
            m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

			txtInPatientID.Text = p_objSelectedPatient.m_StrInPatientID;
			txtInPatientID.Tag=m_strInPatientDate;
			m_txtPatientName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			
			lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			
			lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
			
			m_blnCanAreaSelectIndexChangeEventTakePlace = false;
			m_cboArea.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
			m_blnCanAreaSelectIndexChangeEventTakePlace=true;

			m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
			
			lblSickRoom.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomName;
			lblAddress.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
			

//			m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
//			m_cboDept.SelectedIndex=0;
//			clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
//			m_cboArea.AddItem(objInPatientArea);
//			m_cboArea.SelectedIndex=0;
			//使用新表 modified by tfzhang at 2005年10月17日 16:02:29
			//清空
			m_cboDept.ClearItem();
			 
			//获取科室
			string str1=p_objSelectedPatient.m_strDeptNewID;
			string str2;
			clsHospitalManagerDomain objDomain =new clsHospitalManagerDomain();
			clsEmrDept_VO objDeptNew;
			objDomain.m_lngGetSpecialDeptInfo(str1,out objDeptNew);
			str1=objDeptNew.m_strSHORTNO_CHR.Trim();
			str2=objDeptNew.m_strDEPTNAME_VCHR.Trim();
			string str11=objDeptNew.m_strDEPTID_CHR.Trim();
			clsDepartment objDeptTemp= new clsDepartment(str1,str2);
			//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
			objDeptTemp.m_strDeptNewID=str11;
			m_cboDept.AddItem(objDeptTemp);
			m_cboDept.SelectedIndex=0;

			//获取病区
			m_cboArea.ClearItem();
			string str3=p_objSelectedPatient.m_strAreaNewID;
			if (str3.Trim().Length!=0)//病区不为空
			{
				string str4;
				clsEmrDept_VO objAreNew;
				objDomain.m_lngGetSpecialAreaInfo(str3,out objAreNew);
				str3=objAreNew.m_strSHORTNO_CHR;
				str4=objAreNew.m_strDEPTNAME_VCHR;
				clsInPatientArea objInPatientArea =new clsInPatientArea(str3,str4,str3);
				//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
				objInPatientArea.m_strAreaNewID=objAreNew.m_strDEPTID_CHR;
				m_cboArea.AddItem(objInPatientArea);
				m_cboArea.SelectedIndex=0;
			}
							
			m_txtBedNO.Text =p_objSelectedPatient.m_strBedCode;
			m_blnCanSearch = true;

		}
		#endregion UnUsable

		protected override long m_lngSubAddNew()
		{
			return m_lngSaveWithMessageBox(true);
		}

		protected override long m_lngSubModify()
		{
			return m_lngSaveWithMessageBox(false);
		}

		protected override long m_lngSubPrint()
		{
			//			if(this.m_strInPatientID == null || this.m_strInPatientID == "")
			//			{
			//				return 0;
			//			}
			//
			//			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			//			{
			//				return 0;
			//			}
			try
			{
				if(m_rpdOrderRept == null)
				{
					m_rpdOrderRept = new ReportDocument();
					m_rpdOrderRept.Load(m_strTemplatePath + "rptBUltrasonicCheckOrder.rpt");
				}

				AddNewDataFordtsBUltrasoniceCheckOrderDataSet(m_dtsRept);

				if(m_blnDirectPrint)
				{
					m_rpdOrderRept.PrintToPrinter(1,true,1,100);
				}
				else
				{
					frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//					objView.MdiParent = this.MdiParent;
					objView.ShowDialog();
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
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
			if(m_objBUltrasonicCheckOrder==null || m_objSelectedPatient==null || m_ObjCurrentEmrPatientSession == null)
				return 0;
            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objBUltrasonicCheckOrder.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objBUltrasonicCheckOrder.m_strInPatientID,m_objBUltrasonicCheckOrder.m_strInPatientDate,m_objBUltrasonicCheckOrder.m_strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in trvTime.Nodes[0].Nodes)
				{
					if(trnNode.Tag.ToString()==m_objBUltrasonicCheckOrder.m_strCreateDate)
					{
						trnNode.Remove();
						this.trvTime.SelectedNode=trvTime.Nodes[0];
						break;
					}
				}
				
				m_mthClearUpRecord();
				
			}
			return lngRes ;
		}
		
		#endregion

		#region Save
		private long m_lngSaveWithMessageBox(bool p_bnlIsNew)
		{
			
			long lngRes=m_lngSaveWithoutMessageBox(p_bnlIsNew);
			if(lngRes==-11)
			{
				clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");				
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

		private long m_lngSaveWithoutMessageBox(bool p_bnlIsNew)
		{
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病人");
                return 0;
            }

            if (m_txtSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请申请者签名");
            }
			if(m_strCreateDate!="")
			{
				//				if(!m_bolShowIfModify()) return -1;
				if(MDIParent.OperatorID.Trim()!=m_objBUltrasonicCheckOrder.m_strCreateUserID.Trim())
				{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
					clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
					return -1;
				}
				
			}

			string strCurrentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

//			clsBUltrasonicCheckOrder objBUltraCheckOrder = new clsBUltrasonicCheckOrder();

			if (m_objBUltrasonicCheckOrder==null)
				m_objBUltrasonicCheckOrder=new clsBUltrasonicCheckOrder() ;

			m_objBUltrasonicCheckOrder.m_strCheckNumber = txtCheckNumber.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strHistory = txtHistory.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strBodyCheck	= txtBodyCheck.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strXRay = txtXRayCheck.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strXRayDate = dtpXRayDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			m_objBUltrasonicCheckOrder.m_strXRayNumber = txtXRayNumber.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strLabCheck = txtLabCheck.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strOtherCheck = txtOtherCheck.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strClinicalDisgonse = txtClinicalDisgonse.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strCheckPlace = txtCheckPlace.Text.Trim();
			m_objBUltrasonicCheckOrder.m_strPatholyDisgonseDate = dtpDisgnoseDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			m_objBUltrasonicCheckOrder.m_strOperationDate = dtpOperationDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			m_objBUltrasonicCheckOrder.m_strOperationInformation = txtOperationInformation.Text.Trim();

            m_objBUltrasonicCheckOrder.m_strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
            m_objBUltrasonicCheckOrder.m_strInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
			m_objBUltrasonicCheckOrder.m_strCreateDate = (m_strCreateDate == "") ? dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : m_strCreateDate;
			m_objBUltrasonicCheckOrder.m_strModifyDate = strCurrentDate;
			m_objBUltrasonicCheckOrder.m_strStatus = "0";
            m_objBUltrasonicCheckOrder.m_strCreateUserID = ((clsEmrEmployeeBase_VO)m_txtSign.Tag).m_strEMPID_CHR;
			m_objBUltrasonicCheckOrder.m_strIfConfirm = "1";
            m_objBUltrasonicCheckOrder.m_strCreateUserDeptID = m_ObjCurrentEmrPatientSession.m_strAreaId;

			//// 将B超数据记录入影像表
			/////构建ApplicationInfo
			string strApplicationInfo="";
			if(this.txtHistory.Text.Trim()!="")
				strApplicationInfo="病史摘要:"+this.txtHistory.Text.Trim()+","+"\n\r";
			if(this.txtBodyCheck.Text.Trim()!="")
				strApplicationInfo+="体检(注意肝、脾、子宫、附件、腹块的大小，质地):"+this.txtBodyCheck.Text.Trim()+","+"\n\r";
			if(this.txtOtherCheck.Text.Trim()!="")
				strApplicationInfo+="其它检查(A超、同位素等):"+this.txtOtherCheck.Text.Trim()+","+"\n\r";
			if(this.txtXRayCheck.Text.Trim()!="")
				strApplicationInfo+="X线检查(日期 "+this.dtpXRayDate.Value.ToString()+"): X线号 "+this.txtXRayNumber.Text.Trim()+","+"\n\r";
			if(this.txtLabCheck.Text.Trim()!="")
				strApplicationInfo+="实验室检查(怀疑肝肿瘤时请查AFP-RIA)："+this.txtLabCheck.Text.Trim();

			ImageRequest m_objImageRequest=new ImageRequest();
			m_objImageRequest.m_strApplicationInfo=strApplicationInfo;
			m_objImageRequest.m_strApplicationType="2";		//B超
			m_objImageRequest.m_strBedName=m_ObjCurrentBed.m_strCODE_CHR;
			m_objImageRequest.m_strCheckPart=m_objBUltrasonicCheckOrder.m_strCheckPlace;;	//检查部位
			//m_objImageRequest.m_strCheckPurpose=m_objBUltrasonicCheckOrder.m_strche
            m_objImageRequest.m_strDeptID = m_ObjCurrentEmrPatientSession.m_strAreaId;
            m_objImageRequest.m_strDeptName = m_ObjCurrentEmrPatientSession.m_strAreaName;
			m_objImageRequest.m_strDiagnose=m_objBUltrasonicCheckOrder.m_strClinicalDisgonse;
			m_objImageRequest.m_strDoctorID =m_objBUltrasonicCheckOrder.m_strCreateUserID;
			m_objImageRequest.m_strDoctorName  =m_txtSign.Text ;
            m_objImageRequest.m_strInPatientID = m_ObjCurrentEmrPatientSession.m_strEMRInpatientId;
			m_objImageRequest.m_strPatientBirth =MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy-MM-dd HH:mm:ss");
			m_objImageRequest.m_strPatientName =MDIParent.s_ObjCurrentPatient.m_StrName;
			m_objImageRequest.m_strPatientSex  =MDIParent.s_ObjCurrentPatient.m_StrSex ;
			m_objImageRequest.m_strRequestDateTime  =m_objBUltrasonicCheckOrder.m_strCreateDate;
			m_objImageRequest.m_blnIfNeedRequire = m_chkNeedRequire.Checked;
			if(m_objImageRequest.m_blnIfNeedRequire)
			{
				m_objImageRequest.m_strApplicationComment = m_txtApplicationComment.Text;
			}
			else
			{
				m_objImageRequest.m_strApplicationComment = "";
			}

			string m_strApplicationID="";
			m_strApplicationID=m_objBUltrasonicCheckOrder.m_strApplicationID;

			long lngRes = m_objDomain.m_lngSave(m_objBUltrasonicCheckOrder,m_objImageRequest, ref m_strApplicationID,p_bnlIsNew);
			if(lngRes<=0)
			{
				return -21;
			}
			else
			{
				m_objBUltrasonicCheckOrder.m_strApplicationID = m_strApplicationID;
				m_txtApplicationID.Text = m_strApplicationID;

				string strBookingInfo = "申请单号："+m_strApplicationID+"\r\n姓名："+m_objImageRequest.m_strPatientName+"\r\n住院号："+m_objImageRequest.m_strInPatientID+"\r\n检查部位："+m_objImageRequest.m_strCheckPart;

				bool blnSendRes = PACS.clsPACSTool.s_blnSendBookingMSG(PACS.clsPACSTool.s_strGetStationName(2),strBookingInfo);	
			
				if(!blnSendRes)
					clsPublicFunction.ShowInformationMessageBox("不能发送预约信息。");

				if(m_strCreateDate == "")
				{
					int intNodeIndex = -1;
					for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
					{
						if(DateTime.Parse(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")) == (DateTime)(trvTime.Nodes[0].Nodes[i].Tag))
						{
							intNodeIndex = i;
							break;
						}
					}

					if(intNodeIndex == -1)
					{
						m_mthAddNodeToTrv(dtpApplicateDate.Value);
						//						TreeNode m_trnNewNode = new TreeNode(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_trnNewNode.Tag = DateTime.Parse(dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
						//						m_strCreateDate = dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						//						trvTime.Nodes[0].Nodes.Add(m_trnNewNode);
						//						trvTime.SelectedNode = trvTime.Nodes[0];
						//						trvTime.SelectedNode = m_trnNewNode;
					}
					else
					{
						m_strCreateDate = dtpApplicateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
						trvTime.SelectedNode = trvTime.Nodes[0].Nodes[intNodeIndex];
					}
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
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
				
					if(((Control)sender).Name!="txtHistory" && 
						((Control)sender).Name != "txtBodyCheck" &&
						((Control)sender).Name!= "txtOtherCheck" &&
						((Control)sender).Name!= "txtXRayCheck" &&
						((Control)sender).Name!= "txtClinicalDisgonse" &&
						((Control)sender).Name!= "txtLabCheck" &&
						((Control)sender).Name!= "txtCheckPlace" &&
						((Control)sender).Name!= "txtOperationInformation" &&
						((Control)sender).Name!= "m_txtBedNO" &&
						((Control)sender).Name!= "m_txtPatientName" &&
						((Control)sender).Name!= "m_txtSign" &&
						((Control)sender).Name!= "txtInPatientID")
						SendKeys.Send(  "{tab}"); //注意:如果是button控件,则不能send "Tab" 而应该是"Enter",如果是Text控件且允许多行编辑，也不能send "Tab"
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
					m_blnCanSearch =false;
					this.txtInPatientID.Text ="";
					m_blnCanSearch =true;
					m_mthClearUpRecord();

					this.lblAddress.Text = "";
					this.lblAge.Text = "";
					this.m_cboArea.Text = "";
					this.m_txtBedNO.Text = "";
					this.lblDept_Local .Text = MDIParent.s_ObjDepartment.m_StrDeptName;
					this.m_txtPatientName.Text = "";
					this.lblSex.Text = "";
					this.lblSickRoom.Text = "";

					this.dtpApplicateDate.Value = DateTime.Now;
					this.dtpDisgnoseDate.Value = DateTime.Now;
					this.dtpOperationDate.Value = DateTime.Now;

					m_strInPatientDate = "";
					m_strInPatientID = "";

					m_objBaseCurrentPatient=null;
                    
					this.trvTime.Nodes[0].Nodes .Clear ();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion

		#region 打印
		/*
		* DataSet : dtsBUltrasoniceCheckOrder
		* DataTable : Record
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : InPatientDate(string)
		* 	DataColumn : CreateDate(string)
		* 	DataColumn : ModifyDate(string)
		* 	DataColumn : CreateUserID(string)
		* 	DataColumn : IfConfirm(string)
		* 	DataColumn : ConfirmReason(string)
		* 	DataColumn : FirstPrintDate(string)
		* 	DataColumn : History(string)
		* 	DataColumn : BodyCheck(string)
		* 	DataColumn : XRay(string)
		* 	DataColumn : XRayDate(string)
		* 	DataColumn : XRayNumber(string)
		* 	DataColumn : LabCheck(string)
		* 	DataColumn : OtherCheck(string)
		* 	DataColumn : ClinicalDisgonse(string)
		* 	DataColumn : CheckPlace(string)
		* 	DataColumn : PatholyDisgonseDate(string)
		* 	DataColumn : OperationDate(string)
		* 	DataColumn : OperationInformation(string)
		* 	DataColumn : CreateUserDeptID(string)
		* 	DataColumn : CreateUserName(string)
		* 	DataColumn : CreateUserDeptName(string)
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : PatientArea(string)
		* 	DataColumn : PatientRoom(string)
		* 	DataColumn : PatientBed(string)
		* 	DataColumn : PatientAddress(string)
		*/ 
		private DataSet InitdtsBUltrasoniceCheckOrderDataSet()
		{
			DataSet dsdtsBUltrasoniceCheckOrder = new DataSet("dtsBUltrasoniceCheckOrder");

			DataTable dtRecord = new DataTable("Record");

			DataColumn dcRecordInPatientID = new DataColumn("InPatientID",typeof(string));

			dtRecord.Columns.Add(dcRecordInPatientID);

			DataColumn dcRecordInPatientDate = new DataColumn("InPatientDate",typeof(string));

			dtRecord.Columns.Add(dcRecordInPatientDate);

			DataColumn dcRecordCreateDate = new DataColumn("CreateDate",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateDate);

			DataColumn dcRecordModifyDate = new DataColumn("ModifyDate",typeof(string));

			dtRecord.Columns.Add(dcRecordModifyDate);

			DataColumn dcRecordCreateUserID = new DataColumn("CreateUserID",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserID);

			DataColumn dcRecordIfConfirm = new DataColumn("IfConfirm",typeof(string));

			dtRecord.Columns.Add(dcRecordIfConfirm);

			DataColumn dcRecordConfirmReason = new DataColumn("ConfirmReason",typeof(string));

			dtRecord.Columns.Add(dcRecordConfirmReason);

			DataColumn dcRecordFirstPrintDate = new DataColumn("FirstPrintDate",typeof(string));

			dtRecord.Columns.Add(dcRecordFirstPrintDate);

			DataColumn dcRecordHistory = new DataColumn("History",typeof(string));

			dtRecord.Columns.Add(dcRecordHistory);

			DataColumn dcRecordBodyCheck = new DataColumn("BodyCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordBodyCheck);

			DataColumn dcRecordXRay = new DataColumn("XRay",typeof(string));

			dtRecord.Columns.Add(dcRecordXRay);

			DataColumn dcRecordXRayDate = new DataColumn("XRayDate",typeof(string));

			dtRecord.Columns.Add(dcRecordXRayDate);

			DataColumn dcRecordXRayNumber = new DataColumn("XRayNumber",typeof(string));

			dtRecord.Columns.Add(dcRecordXRayNumber);

			DataColumn dcRecordLabCheck = new DataColumn("LabCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordLabCheck);

			DataColumn dcRecordOtherCheck = new DataColumn("OtherCheck",typeof(string));

			dtRecord.Columns.Add(dcRecordOtherCheck);

			DataColumn dcRecordClinicalDisgonse = new DataColumn("ClinicalDisgonse",typeof(string));

			dtRecord.Columns.Add(dcRecordClinicalDisgonse);

			DataColumn dcRecordCheckPlace = new DataColumn("CheckPlace",typeof(string));

			dtRecord.Columns.Add(dcRecordCheckPlace);

			DataColumn dcRecordPatholyDisgonseDate = new DataColumn("PatholyDisgonseDate",typeof(string));

			dtRecord.Columns.Add(dcRecordPatholyDisgonseDate);

			DataColumn dcRecordOperationDate = new DataColumn("OperationDate",typeof(string));

			dtRecord.Columns.Add(dcRecordOperationDate);

			DataColumn dcRecordOperationInformation = new DataColumn("OperationInformation",typeof(string));

			dtRecord.Columns.Add(dcRecordOperationInformation);

			DataColumn dcRecordCreateUserDeptID = new DataColumn("CreateUserDeptID",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserDeptID);

			DataColumn dcRecordCreateUserName = new DataColumn("CreateUserName",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserName);

			DataColumn dcRecordCreateUserDeptName = new DataColumn("CreateUserDeptName",typeof(string));

			dtRecord.Columns.Add(dcRecordCreateUserDeptName);

			DataColumn dcRecordPatientName = new DataColumn("PatientName",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientName);

			DataColumn dcRecordPatientSex = new DataColumn("PatientSex",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientSex);

			DataColumn dcRecordPatientAge = new DataColumn("PatientAge",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientAge);

			DataColumn dcRecordPatientArea = new DataColumn("PatientArea",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientArea);

			DataColumn dcRecordPatientRoom = new DataColumn("PatientRoom",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientRoom);

			DataColumn dcRecordPatientBed = new DataColumn("PatientBed",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientBed);

			DataColumn dcRecordPatientAddress = new DataColumn("PatientAddress",typeof(string));

			dtRecord.Columns.Add(dcRecordPatientAddress);

			dsdtsBUltrasoniceCheckOrder.Tables.Add(dtRecord);

			return dsdtsBUltrasoniceCheckOrder;
		}


		/*
		* DataSet : dtsBUltrasoniceCheckOrder
		* DataTable : Record
		* 	DataColumn 0: InPatientID(string)
		* 	DataColumn 1: InPatientDate(string)
		* 	DataColumn 2: CreateDate(string)
		* 	DataColumn 3: ModifyDate(string)
		* 	DataColumn 4: CreateUserID(string)
		* 	DataColumn 5: IfConfirm(string)
		* 	DataColumn 6: ConfirmReason(string)
		* 	DataColumn 7: FirstPrintDate(string)
		* 	DataColumn 8: History(string)
		* 	DataColumn 9: BodyCheck(string)
		* 	DataColumn 10: XRay(string)
		* 	DataColumn 11: XRayDate(string)
		* 	DataColumn 12: XRayNumber(string)
		* 	DataColumn 13: LabCheck(string)
		* 	DataColumn 14: OtherCheck(string)
		* 	DataColumn 15: ClinicalDisgonse(string)
		* 	DataColumn 16: CheckPlace(string)
		* 	DataColumn 17: PatholyDisgonseDate(string)
		* 	DataColumn 18: OperationDate(string)
		* 	DataColumn 19: OperationInformation(string)
		* 	DataColumn 20: CreateUserDeptID(string)
		* 	DataColumn 21: CreateUserName(string)
		* 	DataColumn 22: CreateUserDeptName(string)
		* 	DataColumn 23: PatientName(string)
		* 	DataColumn 24: PatientSex(string)
		* 	DataColumn 25: PatientAge(string)
		* 	DataColumn 26: PatientArea(string)
		* 	DataColumn 27: PatientRoom(string)
		* 	DataColumn 28: PatientBed(string)
		* 	DataColumn 29: PatientAddress(string)
	*/ 
		private void AddNewDataFordtsBUltrasoniceCheckOrderDataSet(DataSet dsdtsBUltrasoniceCheckOrder)
		{
			DataTable dtRecord = dsdtsBUltrasoniceCheckOrder.Tables["RECORD"];
			dtRecord.Rows.Clear();

			object [] objRecordDatas = new object[30];

            //objRecordDatas[0] = m_strInPatientID;
			//			objRecordDatas[1] = ;
			objRecordDatas[2] = !string.IsNullOrEmpty(m_strInPatientID) ? dtpApplicateDate.Value.ToString("D") : "";
			objRecordDatas[3] = txtCheckNumber.Text.Trim();
			//objRecordDatas[4] =;
			//			objRecordDatas[5] = ;
			//			objRecordDatas[6] = ;
			objRecordDatas[7] =  m_txtApplicationID.Text;
			objRecordDatas[8] =txtHistory.Text.Trim();
			objRecordDatas[9] =txtBodyCheck.Text.Trim();
			objRecordDatas[10] =txtXRayCheck.Text.Trim();
            objRecordDatas[11] = (!string.IsNullOrEmpty(m_strInPatientID) && txtXRayNumber.Text.Trim() != "") ? dtpXRayDate.Value.ToString("D") : "";
			objRecordDatas[12] = txtXRayNumber.Text.Trim();
			objRecordDatas[13] =txtLabCheck.Text.Trim();
			objRecordDatas[14] =txtOtherCheck.Text.Trim();
			objRecordDatas[15] =txtClinicalDisgonse.Text.Trim();
			objRecordDatas[16] =txtCheckPlace.Text.Trim();
            objRecordDatas[17] = (!string.IsNullOrEmpty(m_strInPatientID) && txtOperationInformation.Text.Trim() != "") ? dtpDisgnoseDate.Value.ToString("D") : "";
            objRecordDatas[18] = (!string.IsNullOrEmpty(m_strInPatientID) && txtOperationInformation.Text.Trim() != "") ? dtpOperationDate.Value.ToString("D") : "";
			objRecordDatas[19] = txtOperationInformation.Text.Trim();
			//			objRecordDatas[20] = ;
            objRecordDatas[21] = !string.IsNullOrEmpty(m_strInPatientID) ? m_txtSign.Text.Trim() : "";
            objRecordDatas[22] = !string.IsNullOrEmpty(m_strInPatientID) ? lblDept_Local.Text.Trim() : "";
            if (m_ObjCurrentEmrPatientSession != null && m_objBaseCurrentPatient != null)
            {
                objRecordDatas[0] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                objRecordDatas[23] = m_objBaseCurrentPatient.m_StrName;
                objRecordDatas[24] = m_objBaseCurrentPatient.m_StrSex;
                objRecordDatas[25] = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrAge;
                objRecordDatas[26] = m_ObjCurrentEmrPatientSession.m_strAreaName;
                objRecordDatas[27] = string.Empty;
                objRecordDatas[28] = m_ObjCurrentBed == null ? string.Empty : m_ObjCurrentBed.m_strCODE_CHR;
                objRecordDatas[29] = m_objBaseCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            }
            else
            {
                objRecordDatas[0] = string.Empty;
                objRecordDatas[23] = string.Empty;
                objRecordDatas[24] = string.Empty;
                objRecordDatas[25] = string.Empty;
                objRecordDatas[26] = string.Empty;
                objRecordDatas[27] = string.Empty;
                objRecordDatas[28] = string.Empty;
                objRecordDatas[29] = string.Empty;
            }			
			dtRecord.Rows.Add(objRecordDatas);

			m_rpdOrderRept.Database.Tables["RECORD"].SetDataSource(dtRecord);

			m_rpdOrderRept.Refresh();

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

			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.txtHistory.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日")  + "入院。"; 
//				this.txtClinicalDisgonse.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//				this.txtBodyCheck.Text = objInPatientCaseDefaultValue[0].m_strMedical + objInPatientCaseDefaultValue[0].m_strLabCheck;
//			}

			//光标回到床位
            //m_txtBedNO.Focus();
		}

		private void m_chkNeedRequire_CheckedChanged(object sender, System.EventArgs e)
		{
			m_txtApplicationComment.Enabled = m_chkNeedRequire.Checked;
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_strInPatientID = string.Empty;
            m_strInPatientDate = string.Empty;
            m_mthClearUpRecord();

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objSelectedPatient = m_objBaseCurrentPatient;
            m_strInPatientID = p_objSelectedSession.m_strEMRInpatientId;
            m_strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_objSelectedPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objSelectedPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objSelectedPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objSelectedPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();

            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID, m_strInPatientDate);
        }
	}
}

