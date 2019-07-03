using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;


namespace iCare
{
	/// <summary>
	/// Jacky-2003-3-18 磁共振(MRI)申请单
	/// </summary>
	public class frmMRIApply : iCare.frmHRPBaseForm,PublicFunction
	{
		#region FormDefines
		private System.Windows.Forms.Label lblCheckPriceTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtCheckPrice;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMR_ID;
		private System.Windows.Forms.Label lblMR_IDTitle;
		protected System.Windows.Forms.RichTextBox m_txtSicknessHistoryAndBodyCharacter;
		private System.Windows.Forms.Label lblSicknessHistoryAndBodyCharacterTitle;
		protected System.Windows.Forms.RichTextBox m_txtOtherCheckResultAndRegisterID;
		private System.Windows.Forms.Label lblOtherCheckResultAndRegisterIDTitle;
		protected System.Windows.Forms.RichTextBox m_txtCheckPart;
		private System.Windows.Forms.Label lblCheckPartTitle;
		private System.Windows.Forms.Label lblTitle2;
		private System.Windows.Forms.Label lblPYCodeTitle;
		private System.Windows.Forms.Label m_lblPYCode;
		private System.Windows.Forms.Label m_lblBirthday;
		private System.Windows.Forms.Label lblBirthdayTitle;
		private System.Windows.Forms.Label lblWeightTitle;
		private System.Windows.Forms.Label lblWeight2Title;
		private System.Windows.Forms.Label m_lblAddress;
		private System.Windows.Forms.Label lblAddressTitle;
		private System.Windows.Forms.Label lblZipeCodeTitle;
		private System.Windows.Forms.Label m_lblZipeCode;
		private System.Windows.Forms.Label lblTelTitle;
		private System.Windows.Forms.Label m_lblTel;
		protected System.Windows.Forms.RichTextBox m_txtClinicDiagnose;
        private System.Windows.Forms.Label lblClinicDiagnoseTitle;
		private System.Windows.Forms.CheckBox m_chkHasOperationHistory;
		private System.Windows.Forms.DataGrid m_dtgOperationTime;
		private System.Windows.Forms.Label lblHasMetalInBodyAndPartTitle;
		private System.Windows.Forms.RichTextBox m_txtHasMetalInBodyAndPart;
		private System.Windows.Forms.Label lblTitle3;
		private System.Windows.Forms.Label lblApplyDeptTitle;
		private System.Windows.Forms.Label m_lblApplyDeptName;
		private System.Windows.Forms.Label lblCreateDateTitle;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		private System.Windows.Forms.Label lblScanTimeTitle;
		protected System.Windows.Forms.RichTextBox m_txtScanTime;
		private System.Windows.Forms.Label lblPatientReactionInScanTitle;
		protected System.Windows.Forms.RichTextBox m_txtPatientReactionInScan;
		private System.Windows.Forms.Label lblMakeShadowQtyTitle;
		protected System.Windows.Forms.RichTextBox m_txtMakeShadowQty;
		private System.Windows.Forms.GroupBox m_gpbBottom;
		private System.Windows.Forms.Label lblTitel10;
		private System.Windows.Forms.Label lblMakeShadowQtyTitle2;
		private System.Windows.Forms.Label lblMR_IDTitle2;
		private System.Windows.Forms.Label m_lblDept;
		private System.Windows.Forms.Label lblDeptTitle;
		private System.Windows.Forms.Label m_lblRoom;
		private System.Windows.Forms.Label lblRoomTitle;
		private System.Windows.Forms.TreeView m_trvCreateDate;
		private System.Windows.Forms.DataGrid m_dtgMRRoom;
		private System.Windows.Forms.DataGridTableStyle m_dtsOperationTime;
		private System.Windows.Forms.DataGridTableStyle m_dtsMRRoom;
		private System.Windows.Forms.DataGridTextBoxColumn clmSerialNO;
		private System.Windows.Forms.DataGridTextBoxColumn clmPartAndLine;
		private System.Windows.Forms.DataGridTextBoxColumn clmPulseSerial;
		private System.Windows.Forms.DataGridTextBoxColumn clmParam;
		private System.Windows.Forms.DataGridTextBoxColumn clmFix;
		private System.Windows.Forms.DataGridTextBoxColumn clmLayerNum;
		private System.Windows.Forms.DataGridTextBoxColumn clmLayerHeight;
		private System.Windows.Forms.DataGridTextBoxColumn clmLayerDistance;
        private System.Windows.Forms.DataGridTextBoxColumn clmOperationHistoryTime;
        private System.Windows.Forms.Label lblEmployeeSign;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		private System.ComponentModel.IContainer components = null;
		#endregion FormDefines
		private PinkieControls.ButtonXP m_cmdTechnicianSignTitle;
		private clsCommonUseToolCollection m_objCUTC;
        private PinkieControls.ButtonXP m_cmdCreateUserTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtWeightTitle;
        private TextBox m_txtCreateUserName;
        private TextBox m_txtTechnicianSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();

		public frmMRIApply()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_trvCreateDate,m_dtgMRRoom,m_dtgOperationTime});

            //foreach(Control ctl in this.Controls)
            //{
            //    string strType = ctl.GetType().Name;
            //    if(strType == "RichTextBox")
            //    {
            //        m_objBorderTool.m_mthChangedControlBorder(ctl);
            //    }
            //}
						
            //m_txtCreateUserName.Text=MDIParent.strOperatorName;	
            //m_txtTechnicianSign.Text="";
		
			#region 初始化DataTable
			m_dtbMRRoom=new DataTable("m_dtbMRRoom");
			m_dtbMRRoom.Columns.Add("clmSerialNO",typeof(int));
			m_dtbMRRoom.Columns.Add("clmPartAndLine");
			m_dtbMRRoom.Columns.Add("clmPulseSerial");
			m_dtbMRRoom.Columns.Add("clmParam");
			m_dtbMRRoom.Columns.Add("clmFix");
			m_dtbMRRoom.Columns.Add("clmLayerNum",typeof(int));
			m_dtbMRRoom.Columns.Add("clmLayerHeight",typeof(int));
			m_dtbMRRoom.Columns.Add("clmLayerDistance",typeof(int));
			m_dtgMRRoom.DataSource=m_dtbMRRoom;

			m_dtbOperationTime=new DataTable("m_dtbOperationTime");
			m_dtbOperationTime.Columns.Add("clmOperationHistoryTime",typeof(DateTime));	
			m_dtgOperationTime.DataSource=m_dtbOperationTime;
			#endregion					

			clmOperationHistoryTime.TextBox.GotFocus += new EventHandler(m_dtgOperationTime_GotFocus);
			
            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdTechnicianSignTitle, m_txtTechnicianSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdCreateUserTitle, m_txtCreateUserName, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}


		#region UserDefines
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;		
		private clsMRIApplyDomain m_objDomain=new clsMRIApplyDomain();
		private bool m_blnCanLikeSeaching=true;

		private clsPatient m_objCurrentPatient=null;
		private clsMRIApply_All objclsMRIApply_All=null; //dick 2003-3-27

		private string m_strInPatientID="";
		private string m_strInPatientDate="";

		private DataTable m_dtbMRRoom;
		private DataTable m_dtbOperationTime;

		private bool blnCanDelete = true;
		#endregion UserDefines

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
            this.lblCheckPriceTitle = new System.Windows.Forms.Label();
            this.m_txtCheckPrice = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMR_ID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblMR_IDTitle = new System.Windows.Forms.Label();
            this.lblMR_IDTitle2 = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.lblPYCodeTitle = new System.Windows.Forms.Label();
            this.m_lblPYCode = new System.Windows.Forms.Label();
            this.m_lblDept = new System.Windows.Forms.Label();
            this.lblDeptTitle = new System.Windows.Forms.Label();
            this.m_lblRoom = new System.Windows.Forms.Label();
            this.lblRoomTitle = new System.Windows.Forms.Label();
            this.m_lblBirthday = new System.Windows.Forms.Label();
            this.lblBirthdayTitle = new System.Windows.Forms.Label();
            this.lblWeightTitle = new System.Windows.Forms.Label();
            this.lblWeight2Title = new System.Windows.Forms.Label();
            this.m_lblAddress = new System.Windows.Forms.Label();
            this.lblAddressTitle = new System.Windows.Forms.Label();
            this.lblZipeCodeTitle = new System.Windows.Forms.Label();
            this.m_lblZipeCode = new System.Windows.Forms.Label();
            this.lblTelTitle = new System.Windows.Forms.Label();
            this.m_lblTel = new System.Windows.Forms.Label();
            this.m_txtSicknessHistoryAndBodyCharacter = new System.Windows.Forms.RichTextBox();
            this.lblSicknessHistoryAndBodyCharacterTitle = new System.Windows.Forms.Label();
            this.m_txtOtherCheckResultAndRegisterID = new System.Windows.Forms.RichTextBox();
            this.lblOtherCheckResultAndRegisterIDTitle = new System.Windows.Forms.Label();
            this.m_txtClinicDiagnose = new System.Windows.Forms.RichTextBox();
            this.lblClinicDiagnoseTitle = new System.Windows.Forms.Label();
            this.m_txtCheckPart = new System.Windows.Forms.RichTextBox();
            this.lblCheckPartTitle = new System.Windows.Forms.Label();
            this.m_chkHasOperationHistory = new System.Windows.Forms.CheckBox();
            this.m_dtgOperationTime = new System.Windows.Forms.DataGrid();
            this.m_dtsOperationTime = new System.Windows.Forms.DataGridTableStyle();
            this.clmOperationHistoryTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblHasMetalInBodyAndPartTitle = new System.Windows.Forms.Label();
            this.m_txtHasMetalInBodyAndPart = new System.Windows.Forms.RichTextBox();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblApplyDeptTitle = new System.Windows.Forms.Label();
            this.m_lblApplyDeptName = new System.Windows.Forms.Label();
            this.lblCreateDateTitle = new System.Windows.Forms.Label();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_dtgMRRoom = new System.Windows.Forms.DataGrid();
            this.m_dtsMRRoom = new System.Windows.Forms.DataGridTableStyle();
            this.clmSerialNO = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmPartAndLine = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmPulseSerial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmParam = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmFix = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmLayerNum = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmLayerHeight = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmLayerDistance = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTitel10 = new System.Windows.Forms.Label();
            this.lblScanTimeTitle = new System.Windows.Forms.Label();
            this.m_txtScanTime = new System.Windows.Forms.RichTextBox();
            this.lblPatientReactionInScanTitle = new System.Windows.Forms.Label();
            this.m_txtPatientReactionInScan = new System.Windows.Forms.RichTextBox();
            this.lblMakeShadowQtyTitle = new System.Windows.Forms.Label();
            this.m_txtMakeShadowQty = new System.Windows.Forms.RichTextBox();
            this.lblMakeShadowQtyTitle2 = new System.Windows.Forms.Label();
            this.m_gpbBottom = new System.Windows.Forms.GroupBox();
            this.m_trvCreateDate = new System.Windows.Forms.TreeView();
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cmdTechnicianSignTitle = new PinkieControls.ButtonXP();
            this.m_txtWeightTitle = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cmdCreateUserTitle = new PinkieControls.ButtonXP();
            this.m_txtCreateUserName = new System.Windows.Forms.TextBox();
            this.m_txtTechnicianSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgOperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgMRRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(108, 177);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(95, 177);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(108, 171);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(219, 190);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(208, 190);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(108, 187);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(80, 182);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(184, 190);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(187, 179);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(92, 50);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(80, 179);
            this.txtInPatientID.Size = new System.Drawing.Size(88, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(211, 190);
            this.m_txtPatientName.Size = new System.Drawing.Size(80, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(191, 181);
            this.m_txtBedNO.Size = new System.Drawing.Size(64, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(98, 178);
            this.m_cboArea.Size = new System.Drawing.Size(24, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(184, 190);
            this.m_lsvPatientName.Size = new System.Drawing.Size(80, 39);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(187, 179);
            this.m_lsvBedNO.Size = new System.Drawing.Size(88, 57);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(187, 190);
            this.m_cboDept.Size = new System.Drawing.Size(128, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(188, 232);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(187, 179);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(222, 207);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(240, 194);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblForTitle.Location = new System.Drawing.Point(245, 190);
            this.m_lblForTitle.Text = "磁共振（MRI）申请单";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(380, 190);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(736, 62);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(63, 30);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_lblDept);
            this.m_pnlNewBase.Controls.Add(this.lblZipeCodeTitle);
            this.m_pnlNewBase.Controls.Add(this.m_lblTel);
            this.m_pnlNewBase.Controls.Add(this.m_lblBirthday);
            this.m_pnlNewBase.Controls.Add(this.lblBirthdayTitle);
            this.m_pnlNewBase.Controls.Add(this.lblTelTitle);
            this.m_pnlNewBase.Location = new System.Drawing.Point(4, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(795, 84);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblTelTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblBirthdayTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblBirthday, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblTel, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblZipeCodeTitle, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_lblDept, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 30);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(601, 53);
            // 
            // lblCheckPriceTitle
            // 
            this.lblCheckPriceTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckPriceTitle.Location = new System.Drawing.Point(418, 96);
            this.lblCheckPriceTitle.Name = "lblCheckPriceTitle";
            this.lblCheckPriceTitle.Size = new System.Drawing.Size(80, 19);
            this.lblCheckPriceTitle.TabIndex = 501;
            this.lblCheckPriceTitle.Text = "检 查 费:";
            this.lblCheckPriceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtCheckPrice
            // 
            this.m_txtCheckPrice.BackColor = System.Drawing.Color.White;
            this.m_txtCheckPrice.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtCheckPrice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckPrice.ForeColor = System.Drawing.Color.Black;
            this.m_txtCheckPrice.Location = new System.Drawing.Point(494, 94);
            this.m_txtCheckPrice.Name = "m_txtCheckPrice";
            this.m_txtCheckPrice.Size = new System.Drawing.Size(132, 23);
            this.m_txtCheckPrice.TabIndex = 23;
            // 
            // m_txtMR_ID
            // 
            this.m_txtMR_ID.BackColor = System.Drawing.Color.White;
            this.m_txtMR_ID.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtMR_ID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMR_ID.ForeColor = System.Drawing.Color.Black;
            this.m_txtMR_ID.Location = new System.Drawing.Point(670, 94);
            this.m_txtMR_ID.Name = "m_txtMR_ID";
            this.m_txtMR_ID.Size = new System.Drawing.Size(124, 23);
            this.m_txtMR_ID.TabIndex = 24;
            // 
            // lblMR_IDTitle
            // 
            this.lblMR_IDTitle.AutoSize = true;
            this.lblMR_IDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMR_IDTitle.Location = new System.Drawing.Point(626, 98);
            this.lblMR_IDTitle.Name = "lblMR_IDTitle";
            this.lblMR_IDTitle.Size = new System.Drawing.Size(42, 14);
            this.lblMR_IDTitle.TabIndex = 501;
            this.lblMR_IDTitle.Text = "MR号:";
            this.lblMR_IDTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMR_IDTitle2
            // 
            this.lblMR_IDTitle2.AutoSize = true;
            this.lblMR_IDTitle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMR_IDTitle2.ForeColor = System.Drawing.Color.Tomato;
            this.lblMR_IDTitle2.Location = new System.Drawing.Point(504, 121);
            this.lblMR_IDTitle2.Name = "lblMR_IDTitle2";
            this.lblMR_IDTitle2.Size = new System.Drawing.Size(294, 14);
            this.lblMR_IDTitle2.TabIndex = 501;
            this.lblMR_IDTitle2.Text = "（曾于本院 MR 检查者申请时请填写此号）";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle2.Location = new System.Drawing.Point(8, 123);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(357, 14);
            this.lblTitle2.TabIndex = 501;
            this.lblTitle2.Text = "机型: 菲利溥公司GYROSCAN T10-NT 高磁场超导型磁共振";
            // 
            // lblPYCodeTitle
            // 
            this.lblPYCodeTitle.AutoSize = true;
            this.lblPYCodeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPYCodeTitle.Location = new System.Drawing.Point(226, 218);
            this.lblPYCodeTitle.Name = "lblPYCodeTitle";
            this.lblPYCodeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblPYCodeTitle.TabIndex = 501;
            this.lblPYCodeTitle.Text = "姓名拼音:";
            this.lblPYCodeTitle.Visible = false;
            // 
            // m_lblPYCode
            // 
            this.m_lblPYCode.Location = new System.Drawing.Point(301, 216);
            this.m_lblPYCode.Name = "m_lblPYCode";
            this.m_lblPYCode.Size = new System.Drawing.Size(76, 20);
            this.m_lblPYCode.TabIndex = 501;
            this.m_lblPYCode.Visible = false;
            // 
            // m_lblDept
            // 
            this.m_lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblDept.Location = new System.Drawing.Point(695, 166);
            this.m_lblDept.Name = "m_lblDept";
            this.m_lblDept.Size = new System.Drawing.Size(91, 25);
            this.m_lblDept.TabIndex = 501;
            this.m_lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDept.Visible = false;
            // 
            // lblDeptTitle
            // 
            this.lblDeptTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptTitle.Location = new System.Drawing.Point(222, 193);
            this.lblDeptTitle.Name = "lblDeptTitle";
            this.lblDeptTitle.Size = new System.Drawing.Size(48, 16);
            this.lblDeptTitle.TabIndex = 501;
            this.lblDeptTitle.Text = "科别:";
            this.lblDeptTitle.Visible = false;
            // 
            // m_lblRoom
            // 
            this.m_lblRoom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblRoom.Location = new System.Drawing.Point(227, 196);
            this.m_lblRoom.Name = "m_lblRoom";
            this.m_lblRoom.Size = new System.Drawing.Size(52, 16);
            this.m_lblRoom.TabIndex = 501;
            this.m_lblRoom.Visible = false;
            // 
            // lblRoomTitle
            // 
            this.lblRoomTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRoomTitle.Location = new System.Drawing.Point(223, 191);
            this.lblRoomTitle.Name = "lblRoomTitle";
            this.lblRoomTitle.Size = new System.Drawing.Size(48, 16);
            this.lblRoomTitle.TabIndex = 501;
            this.lblRoomTitle.Text = "病室:";
            this.lblRoomTitle.Visible = false;
            // 
            // m_lblBirthday
            // 
            this.m_lblBirthday.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblBirthday.Location = new System.Drawing.Point(601, 57);
            this.m_lblBirthday.Name = "m_lblBirthday";
            this.m_lblBirthday.Size = new System.Drawing.Size(130, 26);
            this.m_lblBirthday.TabIndex = 501;
            this.m_lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBirthdayTitle
            // 
            this.lblBirthdayTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBirthdayTitle.Location = new System.Drawing.Point(536, 57);
            this.lblBirthdayTitle.Name = "lblBirthdayTitle";
            this.lblBirthdayTitle.Size = new System.Drawing.Size(70, 26);
            this.lblBirthdayTitle.TabIndex = 501;
            this.lblBirthdayTitle.Text = "出生日期:";
            this.lblBirthdayTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeightTitle
            // 
            this.lblWeightTitle.AutoSize = true;
            this.lblWeightTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWeightTitle.Location = new System.Drawing.Point(6, 99);
            this.lblWeightTitle.Name = "lblWeightTitle";
            this.lblWeightTitle.Size = new System.Drawing.Size(42, 14);
            this.lblWeightTitle.TabIndex = 501;
            this.lblWeightTitle.Text = "体重:";
            // 
            // lblWeight2Title
            // 
            this.lblWeight2Title.AutoSize = true;
            this.lblWeight2Title.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWeight2Title.Location = new System.Drawing.Point(144, 99);
            this.lblWeight2Title.Name = "lblWeight2Title";
            this.lblWeight2Title.Size = new System.Drawing.Size(21, 14);
            this.lblWeight2Title.TabIndex = 501;
            this.lblWeight2Title.Text = "Kg";
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblAddress.Location = new System.Drawing.Point(177, 189);
            this.m_lblAddress.Name = "m_lblAddress";
            this.m_lblAddress.Size = new System.Drawing.Size(148, 20);
            this.m_lblAddress.TabIndex = 501;
            this.m_lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblAddress.Visible = false;
            // 
            // lblAddressTitle
            // 
            this.lblAddressTitle.AutoSize = true;
            this.lblAddressTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddressTitle.Location = new System.Drawing.Point(77, 193);
            this.lblAddressTitle.Name = "lblAddressTitle";
            this.lblAddressTitle.Size = new System.Drawing.Size(70, 14);
            this.lblAddressTitle.TabIndex = 501;
            this.lblAddressTitle.Text = "通讯地址:";
            this.lblAddressTitle.Visible = false;
            // 
            // lblZipeCodeTitle
            // 
            this.lblZipeCodeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZipeCodeTitle.Location = new System.Drawing.Point(655, 30);
            this.lblZipeCodeTitle.Name = "lblZipeCodeTitle";
            this.lblZipeCodeTitle.Size = new System.Drawing.Size(44, 25);
            this.lblZipeCodeTitle.TabIndex = 501;
            this.lblZipeCodeTitle.Text = "邮编:";
            this.lblZipeCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblZipeCode
            // 
            this.m_lblZipeCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblZipeCode.Location = new System.Drawing.Point(705, 38);
            this.m_lblZipeCode.Name = "m_lblZipeCode";
            this.m_lblZipeCode.Size = new System.Drawing.Size(90, 25);
            this.m_lblZipeCode.TabIndex = 501;
            this.m_lblZipeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTelTitle
            // 
            this.lblTelTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTelTitle.Location = new System.Drawing.Point(516, 30);
            this.lblTelTitle.Name = "lblTelTitle";
            this.lblTelTitle.Size = new System.Drawing.Size(42, 25);
            this.lblTelTitle.TabIndex = 501;
            this.lblTelTitle.Text = "电话:";
            this.lblTelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblTel
            // 
            this.m_lblTel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTel.Location = new System.Drawing.Point(558, 30);
            this.m_lblTel.Name = "m_lblTel";
            this.m_lblTel.Size = new System.Drawing.Size(96, 25);
            this.m_lblTel.TabIndex = 501;
            this.m_lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSicknessHistoryAndBodyCharacter
            // 
            this.m_txtSicknessHistoryAndBodyCharacter.AccessibleDescription = "病史和体征";
            this.m_txtSicknessHistoryAndBodyCharacter.BackColor = System.Drawing.Color.White;
            this.m_txtSicknessHistoryAndBodyCharacter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSicknessHistoryAndBodyCharacter.ForeColor = System.Drawing.Color.Black;
            this.m_txtSicknessHistoryAndBodyCharacter.Location = new System.Drawing.Point(10, 168);
            this.m_txtSicknessHistoryAndBodyCharacter.Name = "m_txtSicknessHistoryAndBodyCharacter";
            this.m_txtSicknessHistoryAndBodyCharacter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSicknessHistoryAndBodyCharacter.Size = new System.Drawing.Size(380, 78);
            this.m_txtSicknessHistoryAndBodyCharacter.TabIndex = 25;
            this.m_txtSicknessHistoryAndBodyCharacter.Text = "";
            // 
            // lblSicknessHistoryAndBodyCharacterTitle
            // 
            this.lblSicknessHistoryAndBodyCharacterTitle.AutoSize = true;
            this.lblSicknessHistoryAndBodyCharacterTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSicknessHistoryAndBodyCharacterTitle.Location = new System.Drawing.Point(12, 147);
            this.lblSicknessHistoryAndBodyCharacterTitle.Name = "lblSicknessHistoryAndBodyCharacterTitle";
            this.lblSicknessHistoryAndBodyCharacterTitle.Size = new System.Drawing.Size(84, 14);
            this.lblSicknessHistoryAndBodyCharacterTitle.TabIndex = 501;
            this.lblSicknessHistoryAndBodyCharacterTitle.Text = "病史和体征:";
            // 
            // m_txtOtherCheckResultAndRegisterID
            // 
            this.m_txtOtherCheckResultAndRegisterID.AccessibleDescription = "其他检查结果及登记号";
            this.m_txtOtherCheckResultAndRegisterID.BackColor = System.Drawing.Color.White;
            this.m_txtOtherCheckResultAndRegisterID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOtherCheckResultAndRegisterID.ForeColor = System.Drawing.Color.Black;
            this.m_txtOtherCheckResultAndRegisterID.Location = new System.Drawing.Point(418, 168);
            this.m_txtOtherCheckResultAndRegisterID.Name = "m_txtOtherCheckResultAndRegisterID";
            this.m_txtOtherCheckResultAndRegisterID.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOtherCheckResultAndRegisterID.Size = new System.Drawing.Size(380, 92);
            this.m_txtOtherCheckResultAndRegisterID.TabIndex = 26;
            this.m_txtOtherCheckResultAndRegisterID.Text = "";
            // 
            // lblOtherCheckResultAndRegisterIDTitle
            // 
            this.lblOtherCheckResultAndRegisterIDTitle.AutoSize = true;
            this.lblOtherCheckResultAndRegisterIDTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherCheckResultAndRegisterIDTitle.Location = new System.Drawing.Point(418, 145);
            this.lblOtherCheckResultAndRegisterIDTitle.Name = "lblOtherCheckResultAndRegisterIDTitle";
            this.lblOtherCheckResultAndRegisterIDTitle.Size = new System.Drawing.Size(364, 14);
            this.lblOtherCheckResultAndRegisterIDTitle.TabIndex = 501;
            this.lblOtherCheckResultAndRegisterIDTitle.Text = "其他检查结果及登记号:（X线、CT、B超、核素、病理等）";
            // 
            // m_txtClinicDiagnose
            // 
            this.m_txtClinicDiagnose.AccessibleDescription = "临床诊断";
            this.m_txtClinicDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtClinicDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtClinicDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtClinicDiagnose.Location = new System.Drawing.Point(8, 268);
            this.m_txtClinicDiagnose.Name = "m_txtClinicDiagnose";
            this.m_txtClinicDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtClinicDiagnose.Size = new System.Drawing.Size(380, 80);
            this.m_txtClinicDiagnose.TabIndex = 27;
            this.m_txtClinicDiagnose.Text = "";
            // 
            // lblClinicDiagnoseTitle
            // 
            this.lblClinicDiagnoseTitle.AutoSize = true;
            this.lblClinicDiagnoseTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicDiagnoseTitle.Location = new System.Drawing.Point(8, 248);
            this.lblClinicDiagnoseTitle.Name = "lblClinicDiagnoseTitle";
            this.lblClinicDiagnoseTitle.Size = new System.Drawing.Size(70, 14);
            this.lblClinicDiagnoseTitle.TabIndex = 501;
            this.lblClinicDiagnoseTitle.Text = "临床诊断:";
            // 
            // m_txtCheckPart
            // 
            this.m_txtCheckPart.AccessibleDescription = "检查部位";
            this.m_txtCheckPart.BackColor = System.Drawing.Color.White;
            this.m_txtCheckPart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckPart.ForeColor = System.Drawing.Color.Black;
            this.m_txtCheckPart.Location = new System.Drawing.Point(418, 268);
            this.m_txtCheckPart.Name = "m_txtCheckPart";
            this.m_txtCheckPart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCheckPart.Size = new System.Drawing.Size(380, 52);
            this.m_txtCheckPart.TabIndex = 38;
            this.m_txtCheckPart.Text = "";
            // 
            // lblCheckPartTitle
            // 
            this.lblCheckPartTitle.AutoSize = true;
            this.lblCheckPartTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckPartTitle.Location = new System.Drawing.Point(418, 248);
            this.lblCheckPartTitle.Name = "lblCheckPartTitle";
            this.lblCheckPartTitle.Size = new System.Drawing.Size(308, 14);
            this.lblCheckPartTitle.TabIndex = 501;
            this.lblCheckPartTitle.Text = "检查部位:(脊柱、脊髓请着重注明颈、胸、腰段)";
            // 
            // m_chkHasOperationHistory
            // 
            this.m_chkHasOperationHistory.Location = new System.Drawing.Point(418, 324);
            this.m_chkHasOperationHistory.Name = "m_chkHasOperationHistory";
            this.m_chkHasOperationHistory.Size = new System.Drawing.Size(128, 24);
            this.m_chkHasOperationHistory.TabIndex = 100;
            this.m_chkHasOperationHistory.Text = "病人有否手术史";
            // 
            // m_dtgOperationTime
            // 
            this.m_dtgOperationTime.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgOperationTime.CaptionBackColor = System.Drawing.Color.White;
            this.m_dtgOperationTime.CaptionForeColor = System.Drawing.Color.Black;
            this.m_dtgOperationTime.CaptionVisible = false;
            this.m_dtgOperationTime.DataMember = "";
            this.m_dtgOperationTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgOperationTime.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtgOperationTime.Location = new System.Drawing.Point(418, 348);
            this.m_dtgOperationTime.Name = "m_dtgOperationTime";
            this.m_dtgOperationTime.Size = new System.Drawing.Size(188, 84);
            this.m_dtgOperationTime.TabIndex = 101;
            this.m_dtgOperationTime.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.m_dtsOperationTime});
            // 
            // m_dtsOperationTime
            // 
            this.m_dtsOperationTime.AllowSorting = false;
            this.m_dtsOperationTime.DataGrid = this.m_dtgOperationTime;
            this.m_dtsOperationTime.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.clmOperationHistoryTime});
            this.m_dtsOperationTime.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtsOperationTime.MappingName = "m_dtbOperationTime";
            // 
            // clmOperationHistoryTime
            // 
            this.clmOperationHistoryTime.Format = "yyyy-MM-dd HH:mm:ss";
            this.clmOperationHistoryTime.FormatInfo = null;
            this.clmOperationHistoryTime.HeaderText = "手术时间";
            this.clmOperationHistoryTime.MappingName = "clmOperationHistoryTime";
            this.clmOperationHistoryTime.NullText = "";
            this.clmOperationHistoryTime.Width = 170;
            // 
            // lblHasMetalInBodyAndPartTitle
            // 
            this.lblHasMetalInBodyAndPartTitle.AutoSize = true;
            this.lblHasMetalInBodyAndPartTitle.Location = new System.Drawing.Point(602, 328);
            this.lblHasMetalInBodyAndPartTitle.Name = "lblHasMetalInBodyAndPartTitle";
            this.lblHasMetalInBodyAndPartTitle.Size = new System.Drawing.Size(154, 14);
            this.lblHasMetalInBodyAndPartTitle.TabIndex = 507;
            this.lblHasMetalInBodyAndPartTitle.Text = "体内是否有金属及部位:";
            // 
            // m_txtHasMetalInBodyAndPart
            // 
            this.m_txtHasMetalInBodyAndPart.AccessibleDescription = "体内是否有金属及部位";
            this.m_txtHasMetalInBodyAndPart.BackColor = System.Drawing.Color.White;
            this.m_txtHasMetalInBodyAndPart.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtHasMetalInBodyAndPart.ForeColor = System.Drawing.Color.Black;
            this.m_txtHasMetalInBodyAndPart.Location = new System.Drawing.Point(606, 348);
            this.m_txtHasMetalInBodyAndPart.Name = "m_txtHasMetalInBodyAndPart";
            this.m_txtHasMetalInBodyAndPart.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtHasMetalInBodyAndPart.Size = new System.Drawing.Size(192, 84);
            this.m_txtHasMetalInBodyAndPart.TabIndex = 121;
            this.m_txtHasMetalInBodyAndPart.Text = "";
            // 
            // lblTitle3
            // 
            this.lblTitle3.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle3.ForeColor = System.Drawing.Color.Tomato;
            this.lblTitle3.Location = new System.Drawing.Point(24, 361);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(240, 68);
            this.lblTitle3.TabIndex = 503;
            this.lblTitle3.Text = "禁忌症:                                   1.装有心脏起博器或其他电子装置                2.装有人工心脏瓣膜" +
                "、人工角膜             3.动脉瘤术后止血夹或金属人工听骨";
            // 
            // lblApplyDeptTitle
            // 
            this.lblApplyDeptTitle.AutoSize = true;
            this.lblApplyDeptTitle.Location = new System.Drawing.Point(8, 436);
            this.lblApplyDeptTitle.Name = "lblApplyDeptTitle";
            this.lblApplyDeptTitle.Size = new System.Drawing.Size(70, 14);
            this.lblApplyDeptTitle.TabIndex = 509;
            this.lblApplyDeptTitle.Text = "申请单位:";
            // 
            // m_lblApplyDeptName
            // 
            this.m_lblApplyDeptName.Location = new System.Drawing.Point(80, 436);
            this.m_lblApplyDeptName.Name = "m_lblApplyDeptName";
            this.m_lblApplyDeptName.Size = new System.Drawing.Size(216, 20);
            this.m_lblApplyDeptName.TabIndex = 510;
            this.m_lblApplyDeptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.AutoSize = true;
            this.lblCreateDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreateDateTitle.Location = new System.Drawing.Point(496, 440);
            this.lblCreateDateTitle.Name = "lblCreateDateTitle";
            this.lblCreateDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblCreateDateTitle.TabIndex = 513;
            this.lblCreateDateTitle.Text = "申请时间:";
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(568, 436);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpCreateDate.TabIndex = 131;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_dtgMRRoom
            // 
            this.m_dtgMRRoom.BackgroundColor = System.Drawing.Color.White;
            this.m_dtgMRRoom.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_dtgMRRoom.CaptionVisible = false;
            this.m_dtgMRRoom.DataMember = "";
            this.m_dtgMRRoom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtgMRRoom.Location = new System.Drawing.Point(36, 464);
            this.m_dtgMRRoom.Name = "m_dtgMRRoom";
            this.m_dtgMRRoom.Size = new System.Drawing.Size(452, 132);
            this.m_dtgMRRoom.TabIndex = 141;
            this.m_dtgMRRoom.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.m_dtsMRRoom});
            // 
            // m_dtsMRRoom
            // 
            this.m_dtsMRRoom.AllowSorting = false;
            this.m_dtsMRRoom.DataGrid = this.m_dtgMRRoom;
            this.m_dtsMRRoom.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.clmSerialNO,
            this.clmPartAndLine,
            this.clmPulseSerial,
            this.clmParam,
            this.clmFix,
            this.clmLayerNum,
            this.clmLayerHeight,
            this.clmLayerDistance});
            this.m_dtsMRRoom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dtsMRRoom.MappingName = "m_dtbMRRoom";
            this.m_dtsMRRoom.RowHeaderWidth = 15;
            // 
            // clmSerialNO
            // 
            this.clmSerialNO.Format = "";
            this.clmSerialNO.FormatInfo = null;
            this.clmSerialNO.HeaderText = "序号";
            this.clmSerialNO.MappingName = "clmSerialNO";
            this.clmSerialNO.NullText = "";
            this.clmSerialNO.ReadOnly = true;
            this.clmSerialNO.Width = 60;
            // 
            // clmPartAndLine
            // 
            this.clmPartAndLine.Format = "";
            this.clmPartAndLine.FormatInfo = null;
            this.clmPartAndLine.HeaderText = "部位/线圈";
            this.clmPartAndLine.MappingName = "clmPartAndLine";
            this.clmPartAndLine.NullText = "";
            this.clmPartAndLine.Width = 75;
            // 
            // clmPulseSerial
            // 
            this.clmPulseSerial.Format = "";
            this.clmPulseSerial.FormatInfo = null;
            this.clmPulseSerial.HeaderText = "脉冲序列";
            this.clmPulseSerial.MappingName = "clmPulseSerial";
            this.clmPulseSerial.NullText = "";
            this.clmPulseSerial.Width = 80;
            // 
            // clmParam
            // 
            this.clmParam.Format = "";
            this.clmParam.FormatInfo = null;
            this.clmParam.HeaderText = "参数";
            this.clmParam.MappingName = "clmParam";
            this.clmParam.NullText = "";
            this.clmParam.Width = 120;
            // 
            // clmFix
            // 
            this.clmFix.Format = "";
            this.clmFix.FormatInfo = null;
            this.clmFix.HeaderText = "方位";
            this.clmFix.MappingName = "clmFix";
            this.clmFix.NullText = "";
            this.clmFix.Width = 60;
            // 
            // clmLayerNum
            // 
            this.clmLayerNum.Format = "";
            this.clmLayerNum.FormatInfo = null;
            this.clmLayerNum.HeaderText = "层数";
            this.clmLayerNum.MappingName = "clmLayerNum";
            this.clmLayerNum.NullText = "";
            this.clmLayerNum.Width = 60;
            // 
            // clmLayerHeight
            // 
            this.clmLayerHeight.Format = "";
            this.clmLayerHeight.FormatInfo = null;
            this.clmLayerHeight.HeaderText = "层厚cm";
            this.clmLayerHeight.MappingName = "clmLayerHeight";
            this.clmLayerHeight.NullText = "";
            this.clmLayerHeight.Width = 65;
            // 
            // clmLayerDistance
            // 
            this.clmLayerDistance.Format = "";
            this.clmLayerDistance.FormatInfo = null;
            this.clmLayerDistance.HeaderText = "层距cm";
            this.clmLayerDistance.MappingName = "clmLayerDistance";
            this.clmLayerDistance.NullText = "";
            this.clmLayerDistance.Width = 65;
            // 
            // lblTitel10
            // 
            this.lblTitel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitel10.Location = new System.Drawing.Point(8, 464);
            this.lblTitel10.Name = "lblTitel10";
            this.lblTitel10.Size = new System.Drawing.Size(30, 132);
            this.lblTitel10.TabIndex = 516;
            this.lblTitel10.Text = "由MR室填写";
            this.lblTitel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScanTimeTitle
            // 
            this.lblScanTimeTitle.AutoSize = true;
            this.lblScanTimeTitle.Location = new System.Drawing.Point(492, 556);
            this.lblScanTimeTitle.Name = "lblScanTimeTitle";
            this.lblScanTimeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblScanTimeTitle.TabIndex = 519;
            this.lblScanTimeTitle.Text = "扫描时间:";
            // 
            // m_txtScanTime
            // 
            this.m_txtScanTime.AccessibleDescription = "扫描时间";
            this.m_txtScanTime.BackColor = System.Drawing.Color.White;
            this.m_txtScanTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtScanTime.ForeColor = System.Drawing.Color.Black;
            this.m_txtScanTime.Location = new System.Drawing.Point(568, 552);
            this.m_txtScanTime.Multiline = false;
            this.m_txtScanTime.Name = "m_txtScanTime";
            this.m_txtScanTime.Size = new System.Drawing.Size(231, 24);
            this.m_txtScanTime.TabIndex = 153;
            this.m_txtScanTime.Text = "";
            // 
            // lblPatientReactionInScanTitle
            // 
            this.lblPatientReactionInScanTitle.Location = new System.Drawing.Point(492, 492);
            this.lblPatientReactionInScanTitle.Name = "lblPatientReactionInScanTitle";
            this.lblPatientReactionInScanTitle.Size = new System.Drawing.Size(80, 36);
            this.lblPatientReactionInScanTitle.TabIndex = 521;
            this.lblPatientReactionInScanTitle.Text = "病人扫描中反应:";
            // 
            // m_txtPatientReactionInScan
            // 
            this.m_txtPatientReactionInScan.AccessibleDescription = "病人扫描中反应";
            this.m_txtPatientReactionInScan.BackColor = System.Drawing.Color.White;
            this.m_txtPatientReactionInScan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPatientReactionInScan.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientReactionInScan.Location = new System.Drawing.Point(568, 488);
            this.m_txtPatientReactionInScan.Name = "m_txtPatientReactionInScan";
            this.m_txtPatientReactionInScan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtPatientReactionInScan.Size = new System.Drawing.Size(230, 60);
            this.m_txtPatientReactionInScan.TabIndex = 152;
            this.m_txtPatientReactionInScan.Text = "";
            // 
            // lblMakeShadowQtyTitle
            // 
            this.lblMakeShadowQtyTitle.AutoSize = true;
            this.lblMakeShadowQtyTitle.Location = new System.Drawing.Point(496, 464);
            this.lblMakeShadowQtyTitle.Name = "lblMakeShadowQtyTitle";
            this.lblMakeShadowQtyTitle.Size = new System.Drawing.Size(70, 14);
            this.lblMakeShadowQtyTitle.TabIndex = 523;
            this.lblMakeShadowQtyTitle.Text = "造影剂量:";
            // 
            // m_txtMakeShadowQty
            // 
            this.m_txtMakeShadowQty.AccessibleDescription = "造影剂量";
            this.m_txtMakeShadowQty.BackColor = System.Drawing.Color.White;
            this.m_txtMakeShadowQty.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMakeShadowQty.ForeColor = System.Drawing.Color.Black;
            this.m_txtMakeShadowQty.Location = new System.Drawing.Point(568, 460);
            this.m_txtMakeShadowQty.Multiline = false;
            this.m_txtMakeShadowQty.Name = "m_txtMakeShadowQty";
            this.m_txtMakeShadowQty.Size = new System.Drawing.Size(140, 24);
            this.m_txtMakeShadowQty.TabIndex = 151;
            this.m_txtMakeShadowQty.Text = "";
            this.m_txtMakeShadowQty.Leave += new System.EventHandler(this.m_txtMakeShadowQty_Leave);
            // 
            // lblMakeShadowQtyTitle2
            // 
            this.lblMakeShadowQtyTitle2.AutoSize = true;
            this.lblMakeShadowQtyTitle2.Location = new System.Drawing.Point(712, 464);
            this.lblMakeShadowQtyTitle2.Name = "lblMakeShadowQtyTitle2";
            this.lblMakeShadowQtyTitle2.Size = new System.Drawing.Size(21, 14);
            this.lblMakeShadowQtyTitle2.TabIndex = 524;
            this.lblMakeShadowQtyTitle2.Text = "ml";
            // 
            // m_gpbBottom
            // 
            this.m_gpbBottom.BackColor = System.Drawing.SystemColors.Control;
            this.m_gpbBottom.Location = new System.Drawing.Point(4, 608);
            this.m_gpbBottom.Name = "m_gpbBottom";
            this.m_gpbBottom.Size = new System.Drawing.Size(968, 1);
            this.m_gpbBottom.TabIndex = 527;
            this.m_gpbBottom.TabStop = false;
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.BackColor = System.Drawing.Color.White;
            this.m_trvCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvCreateDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.HideSelection = false;
            this.m_trvCreateDate.ItemHeight = 18;
            this.m_trvCreateDate.Location = new System.Drawing.Point(5, 39);
            this.m_trvCreateDate.Name = "m_trvCreateDate";
            this.m_trvCreateDate.Size = new System.Drawing.Size(191, 50);
            this.m_trvCreateDate.TabIndex = 22;
            this.m_trvCreateDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvCreateDate_AfterSelect);
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.Location = new System.Drawing.Point(632, 624);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000097;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(676, 620);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtSign.TabIndex = 10000095;
            this.m_txtSign.Visible = false;
            // 
            // m_cmdTechnicianSignTitle
            // 
            this.m_cmdTechnicianSignTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdTechnicianSignTitle.DefaultScheme = true;
            this.m_cmdTechnicianSignTitle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdTechnicianSignTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdTechnicianSignTitle.Hint = "";
            this.m_cmdTechnicianSignTitle.Location = new System.Drawing.Point(500, 579);
            this.m_cmdTechnicianSignTitle.Name = "m_cmdTechnicianSignTitle";
            this.m_cmdTechnicianSignTitle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdTechnicianSignTitle.Size = new System.Drawing.Size(100, 24);
            this.m_cmdTechnicianSignTitle.TabIndex = 10000098;
            this.m_cmdTechnicianSignTitle.Tag = "0";
            this.m_cmdTechnicianSignTitle.Text = "技术员签名:";
            // 
            // m_txtWeightTitle
            // 
            this.m_txtWeightTitle.BackColor = System.Drawing.Color.White;
            this.m_txtWeightTitle.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtWeightTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWeightTitle.ForeColor = System.Drawing.Color.Black;
            this.m_txtWeightTitle.Location = new System.Drawing.Point(54, 95);
            this.m_txtWeightTitle.Name = "m_txtWeightTitle";
            this.m_txtWeightTitle.Size = new System.Drawing.Size(84, 23);
            this.m_txtWeightTitle.TabIndex = 10000099;
            // 
            // m_cmdCreateUserTitle
            // 
            this.m_cmdCreateUserTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCreateUserTitle.DefaultScheme = true;
            this.m_cmdCreateUserTitle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCreateUserTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCreateUserTitle.Hint = "";
            this.m_cmdCreateUserTitle.Location = new System.Drawing.Point(304, 434);
            this.m_cmdCreateUserTitle.Name = "m_cmdCreateUserTitle";
            this.m_cmdCreateUserTitle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCreateUserTitle.Size = new System.Drawing.Size(84, 24);
            this.m_cmdCreateUserTitle.TabIndex = 10000102;
            this.m_cmdCreateUserTitle.Tag = "1";
            this.m_cmdCreateUserTitle.Text = "申请医师:";
            // 
            // m_txtCreateUserName
            // 
            this.m_txtCreateUserName.Location = new System.Drawing.Point(392, 437);
            this.m_txtCreateUserName.Name = "m_txtCreateUserName";
            this.m_txtCreateUserName.Size = new System.Drawing.Size(96, 23);
            this.m_txtCreateUserName.TabIndex = 10000103;
            // 
            // m_txtTechnicianSign
            // 
            this.m_txtTechnicianSign.Location = new System.Drawing.Point(607, 580);
            this.m_txtTechnicianSign.Name = "m_txtTechnicianSign";
            this.m_txtTechnicianSign.Size = new System.Drawing.Size(96, 23);
            this.m_txtTechnicianSign.TabIndex = 10000104;
            // 
            // frmMRIApply
            // 
            this.AccessibleDescription = "磁共振（MRI）申请单";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(803, 673);
            this.Controls.Add(this.m_txtTechnicianSign);
            this.Controls.Add(this.m_txtCreateUserName);
            this.Controls.Add(this.m_txtWeightTitle);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.lblMakeShadowQtyTitle2);
            this.Controls.Add(this.lblScanTimeTitle);
            this.Controls.Add(this.lblCreateDateTitle);
            this.Controls.Add(this.lblApplyDeptTitle);
            this.Controls.Add(this.lblHasMetalInBodyAndPartTitle);
            this.Controls.Add(this.lblMR_IDTitle);
            this.Controls.Add(this.lblMR_IDTitle2);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblWeightTitle);
            this.Controls.Add(this.lblWeight2Title);
            this.Controls.Add(this.lblAddressTitle);
            this.Controls.Add(this.lblSicknessHistoryAndBodyCharacterTitle);
            this.Controls.Add(this.lblOtherCheckResultAndRegisterIDTitle);
            this.Controls.Add(this.lblClinicDiagnoseTitle);
            this.Controls.Add(this.lblCheckPartTitle);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.m_txtCheckPrice);
            this.Controls.Add(this.m_txtMR_ID);
            this.Controls.Add(this.m_cmdCreateUserTitle);
            this.Controls.Add(this.m_cmdTechnicianSignTitle);
            this.Controls.Add(this.lblCheckPriceTitle);
            this.Controls.Add(this.m_trvCreateDate);
            this.Controls.Add(this.m_gpbBottom);
            this.Controls.Add(this.m_txtMakeShadowQty);
            this.Controls.Add(this.m_txtPatientReactionInScan);
            this.Controls.Add(this.m_txtScanTime);
            this.Controls.Add(this.lblTitel10);
            this.Controls.Add(this.m_dtgMRRoom);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Controls.Add(this.m_lblApplyDeptName);
            this.Controls.Add(this.m_txtHasMetalInBodyAndPart);
            this.Controls.Add(this.m_dtgOperationTime);
            this.Controls.Add(this.m_chkHasOperationHistory);
            this.Controls.Add(this.lblTitle3);
            this.Controls.Add(this.m_lblPYCode);
            this.Controls.Add(this.lblDeptTitle);
            this.Controls.Add(this.m_lblRoom);
            this.Controls.Add(this.lblRoomTitle);
            this.Controls.Add(this.m_lblAddress);
            this.Controls.Add(this.m_lblZipeCode);
            this.Controls.Add(this.m_txtSicknessHistoryAndBodyCharacter);
            this.Controls.Add(this.m_txtOtherCheckResultAndRegisterID);
            this.Controls.Add(this.m_txtClinicDiagnose);
            this.Controls.Add(this.m_txtCheckPart);
            this.Controls.Add(this.lblMakeShadowQtyTitle);
            this.Controls.Add(this.lblPatientReactionInScanTitle);
            this.Controls.Add(this.lblPYCodeTitle);
            this.Name = "frmMRIApply";
            this.Text = "磁共振（MRI）申请单";
            this.Load += new System.EventHandler(this.frmMRIApply_Load);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblPYCodeTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lblPatientReactionInScanTitle, 0);
            this.Controls.SetChildIndex(this.lblMakeShadowQtyTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_txtCheckPart, 0);
            this.Controls.SetChildIndex(this.m_txtClinicDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtOtherCheckResultAndRegisterID, 0);
            this.Controls.SetChildIndex(this.m_txtSicknessHistoryAndBodyCharacter, 0);
            this.Controls.SetChildIndex(this.m_lblZipeCode, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.lblRoomTitle, 0);
            this.Controls.SetChildIndex(this.m_lblRoom, 0);
            this.Controls.SetChildIndex(this.lblDeptTitle, 0);
            this.Controls.SetChildIndex(this.m_lblPYCode, 0);
            this.Controls.SetChildIndex(this.lblTitle3, 0);
            this.Controls.SetChildIndex(this.m_chkHasOperationHistory, 0);
            this.Controls.SetChildIndex(this.m_dtgOperationTime, 0);
            this.Controls.SetChildIndex(this.m_txtHasMetalInBodyAndPart, 0);
            this.Controls.SetChildIndex(this.m_lblApplyDeptName, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_dtgMRRoom, 0);
            this.Controls.SetChildIndex(this.lblTitel10, 0);
            this.Controls.SetChildIndex(this.m_txtScanTime, 0);
            this.Controls.SetChildIndex(this.m_txtPatientReactionInScan, 0);
            this.Controls.SetChildIndex(this.m_txtMakeShadowQty, 0);
            this.Controls.SetChildIndex(this.m_gpbBottom, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCheckPriceTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdTechnicianSignTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateUserTitle, 0);
            this.Controls.SetChildIndex(this.m_txtMR_ID, 0);
            this.Controls.SetChildIndex(this.m_txtCheckPrice, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.lblCheckPartTitle, 0);
            this.Controls.SetChildIndex(this.lblClinicDiagnoseTitle, 0);
            this.Controls.SetChildIndex(this.lblOtherCheckResultAndRegisterIDTitle, 0);
            this.Controls.SetChildIndex(this.lblSicknessHistoryAndBodyCharacterTitle, 0);
            this.Controls.SetChildIndex(this.lblAddressTitle, 0);
            this.Controls.SetChildIndex(this.lblWeight2Title, 0);
            this.Controls.SetChildIndex(this.lblWeightTitle, 0);
            this.Controls.SetChildIndex(this.lblTitle2, 0);
            this.Controls.SetChildIndex(this.lblMR_IDTitle2, 0);
            this.Controls.SetChildIndex(this.lblMR_IDTitle, 0);
            this.Controls.SetChildIndex(this.lblHasMetalInBodyAndPartTitle, 0);
            this.Controls.SetChildIndex(this.lblApplyDeptTitle, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.lblScanTimeTitle, 0);
            this.Controls.SetChildIndex(this.lblMakeShadowQtyTitle2, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_txtWeightTitle, 0);
            this.Controls.SetChildIndex(this.m_txtCreateUserName, 0);
            this.Controls.SetChildIndex(this.m_txtTechnicianSign, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgOperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgMRRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		#region 窗体常用附加函数
		#region Override Function
		protected override long m_lngSubPrint()
		{
			m_mthPrintPreView();	
			return 1;
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
				if(m_dtpCreateDate.Enabled==true)
					return true;
				else 
					return false;
			}
		}
		
		protected override long m_lngSubModify()
		{			
			return m_lngSaveWithMessageBox();
		}

		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			m_mthClearUpFormInfo();
			m_objCurrentPatient=p_objSelectedPatient;

            this.m_lblBirthday.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth == DateTime.MinValue ? string.Empty : p_objSelectedPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy年MM月dd日");
            this.m_lblTel.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePhone;
            this.m_lblZipeCode.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomePC;
            this.m_lblAddress.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            //m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
            //m_strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            //this.m_mthDisplayDates(m_strInPatientID,m_strInPatientDate);			
		}

		/// <summary>
		/// 是否处理病人号内容改变事件
		/// </summary>
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return this.m_blnCanLikeSeaching;
			}			
		}

		/// <summary>
		/// 清空病人基本住院信息的界面（可覆盖提供新的实现）
		/// </summary>
		protected override void m_mthClearPatientBaseInfo()
		{		
			m_txtPatientName.Text = "";
			lblSex.Text = "";
			lblAge.Text = "";
			m_cboArea.Text = "";
			m_txtBedNO.Text = "";	
		
			m_lblAddress.Text="";
			m_lblBirthday.Text="";
			m_lblDept.Text="";
			m_lblPYCode.Text="";
			m_lblRoom.Text="";
			m_lblTel.Text="";
			m_txtWeightTitle.Text="";
			m_lblZipeCode.Text="";			
		}

		protected override long m_lngSubDelete()  
		{
			if(blnCanDelete==false )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,无权删除他人的记录!");
				return 1;
			}
			if(objclsMRIApply_All==null || m_objCurrentPatient==null ||objclsMRIApply_All.m_objclsMRIApply==null || m_ObjCurrentEmrPatientSession == null)
				return 0;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID, objclsMRIApply_All.m_objclsMRIApply.m_strInPatientID, objclsMRIApply_All.m_objclsMRIApply.m_strInPatientDate, objclsMRIApply_All.m_objclsMRIApply.m_strCreateDate);
			if(lngRes>0)
			{
				foreach(TreeNode trnNode in m_trvCreateDate.Nodes[0].Nodes)
				{
					if(trnNode.Text== objclsMRIApply_All.m_objclsMRIApply.m_strCreateDate)
					{
						trnNode.Remove();
						break;
					}
				}
				m_trvCreateDate.SelectedNode=m_trvCreateDate.Nodes[0];
				m_mthClearUp2();
				//				m_mthReadOnly(false);
			}
			return lngRes ;
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
		
		#endregion
		#endregion 窗体常用附加函数

		#region DataControl
		public void Save()
		{			
			this.m_lngSave();
		}
		private long m_lngSaveWithMessageBox()
		{
			if(m_dtpCreateDate.Enabled==false)
			{
				//				if(!m_bolShowIfModify()) return -1;
				if(clsEMRLogin.LoginEmployee.m_strEMPID_CHR != objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserID.Trim())
				{	//非申请医生无法更改记录,崔汉瑜,2003-5-27
					clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
					return -1;
				}
			}
			long lngRes=m_lngSaveWithoutMessageBox();
            if (lngRes > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功！");	
            }
			else if(lngRes==-10)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择住院号再保存！");				
			}
			else if(lngRes==-19)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，不能为该病人重复申请此单!\r\n如果需要如此，请修改申请时间!");					
			}
			else if(lngRes==-11)
			{
				clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");				
			}
			else if(lngRes==-21)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
			}
			return lngRes;
		}

		private clsMRIApply m_objGetMRIApplyInfo(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,string p_strModifyDate)
		{
            if (m_txtCreateUserName.Tag == null)
            {
                return null;
            }
			clsMRIApply objclsMRIApply=new clsMRIApply();
			objclsMRIApply.m_strInPatientID=p_strInPatientID;
			objclsMRIApply.m_strInPatientDate=p_strInPatientDate;
			objclsMRIApply.m_strCreateDate=p_strCreateDate;
			objclsMRIApply.m_strModifyDate=p_strModifyDate;

			if(m_dtpCreateDate.Enabled==true)
			{
				objclsMRIApply.m_strCreateUserID= ((clsEmrEmployeeBase_VO)m_txtCreateUserName.Tag).m_strEMPID_CHR;
                if (m_ObjCurrentArea != null)
                {
                    objclsMRIApply.m_strApplyDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
                }
                else
                {
                    objclsMRIApply.m_strApplyDeptID = string.Empty;
                }
			}
//			else if(m_lblCreateUserName.Tag!=null && m_lblApplyDeptName.Tag !=null)
            else if (m_lblApplyDeptName.Tag != null)
            {
                //				objclsMRIApply.m_strCreateUserID=m_lblCreateUserName.Tag.ToString();
                objclsMRIApply.m_strApplyDeptID = m_lblApplyDeptName.Tag.ToString();
            }
            else return null;
			objclsMRIApply.m_strCheckPrice=m_txtCheckPrice.Text;
			objclsMRIApply.m_strMR_ID=m_txtMR_ID.Text;
			objclsMRIApply.m_strSicknessHistoryAndBodyCharacter=m_txtSicknessHistoryAndBodyCharacter.Text;
			objclsMRIApply.m_strOtherCheckResultAndRegisterID=m_txtOtherCheckResultAndRegisterID.Text;
			objclsMRIApply.m_strClinicDiagnose=m_txtClinicDiagnose.Text;
			objclsMRIApply.m_strCheckPart=m_txtCheckPart.Text;
			objclsMRIApply.m_strHasOperationHistory=m_chkHasOperationHistory.Checked==true? "1":"0";
			objclsMRIApply.m_strHasMetalInBodyAndPart=m_txtHasMetalInBodyAndPart.Text;
			objclsMRIApply.m_strMakeShadowQty=m_txtMakeShadowQty.Text;
			objclsMRIApply.m_strPatientReactionInScan=m_txtPatientReactionInScan.Text;
			objclsMRIApply.m_strScanTime=m_txtScanTime.Text;
			objclsMRIApply.m_strWeight = m_txtWeightTitle.Text;
			if(m_txtTechnicianSign.Tag!=null)
				objclsMRIApply.m_strTechnicianSignID=((clsEmrEmployeeBase_VO)m_txtTechnicianSign.Tag).m_strEMPID_CHR;
			else objclsMRIApply.m_strTechnicianSignID="";
			return objclsMRIApply;
		}

		private clsMRIApply_MRRoom[] m_objGetMRIApply_MRRoomInfo(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,string p_strModifyDate)
		{
			clsMRIApply_MRRoom[] objclsMRIApply_MRRoomArr=new clsMRIApply_MRRoom[m_dtbMRRoom.Rows.Count];
			for(int i=0;i<m_dtbMRRoom.Rows.Count;i++)
			{
				objclsMRIApply_MRRoomArr[i]=new clsMRIApply_MRRoom();
				objclsMRIApply_MRRoomArr[i].m_strInPatientID=p_strInPatientID;
				objclsMRIApply_MRRoomArr[i].m_strInPatientDate=p_strInPatientDate;
				objclsMRIApply_MRRoomArr[i].m_strCreateDate=p_strCreateDate;
				objclsMRIApply_MRRoomArr[i].m_strModifyDate=p_strModifyDate;
				objclsMRIApply_MRRoomArr[i].m_strSerialNO=(i+1).ToString();
				objclsMRIApply_MRRoomArr[i].m_strPartAndLine=m_dtbMRRoom.Rows[i][1].ToString();
				objclsMRIApply_MRRoomArr[i].m_strPulseSerial=m_dtbMRRoom.Rows[i][2].ToString();
				objclsMRIApply_MRRoomArr[i].m_strParam=m_dtbMRRoom.Rows[i][3].ToString();
				objclsMRIApply_MRRoomArr[i].m_strFix=m_dtbMRRoom.Rows[i][4].ToString();
				objclsMRIApply_MRRoomArr[i].m_strLayerNum=m_dtbMRRoom.Rows[i][5].ToString();
				objclsMRIApply_MRRoomArr[i].m_strLayerHeight=m_dtbMRRoom.Rows[i][6].ToString();
				objclsMRIApply_MRRoomArr[i].m_strLayerDistance=m_dtbMRRoom.Rows[i][7].ToString();
			}	
			return objclsMRIApply_MRRoomArr;
		}

		private string[] m_strOperationHistoryTimeArr()
		{
			ArrayList arlDate=new ArrayList();			
			for(int i=0;i<m_dtbOperationTime.Rows.Count;i++)
			{		
				try
				{
					DateTime.Parse(m_dtbOperationTime.Rows[i][0].ToString());
					arlDate.Add(m_dtbOperationTime.Rows[i][0].ToString());
				}
				catch{}				
			}	
			return (string[])(arlDate.ToArray(typeof(string)));
		}

		private long m_lngSaveWithoutMessageBox()
		{			
            //if(this.txtInPatientID.Text.Trim()!=m_strInPatientID.Trim())				
            //    return -10;	

			if(m_dtpCreateDate.Enabled)
				for(int i=0;i<m_trvCreateDate.Nodes[0].Nodes.Count;i++)
				{
					if(m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")==m_trvCreateDate.Nodes[0].Nodes[i].Text)
						return -19;
				}

			string strCreateDate=m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
//			string strModifyDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+((float)(DateTime.Now.Millisecond)/1000f).ToString(".000");
			string strModifyDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			
			objclsMRIApply_All=new clsMRIApply_All();
			objclsMRIApply_All.m_objclsMRIApply=m_objGetMRIApplyInfo(m_strInPatientID,m_strInPatientDate,strCreateDate,strModifyDate);
			objclsMRIApply_All.m_objclsMRIApply_MRRoomArr=m_objGetMRIApply_MRRoomInfo(m_strInPatientID,m_strInPatientDate,strCreateDate,strModifyDate);;
			objclsMRIApply_All.m_strOperationHistoryTimeArr=m_strOperationHistoryTimeArr();			

			if(objclsMRIApply_All.m_objclsMRIApply==null)
			{				
				//clsPublicFunction.ShowInformationMessageBox("你所修改的记录已被他人删除或不存在！");
				return -11;				
			}
			
			long lngRes=m_objDomain.m_lngSave(objclsMRIApply_All,m_dtpCreateDate.Enabled);
			if(lngRes<=0)
			{
				//clsPublicFunction.ShowInformationMessageBox("对不起，保存失败！");
				return -21;
			}
			else if(m_dtpCreateDate.Enabled)//添加记录时，刷新界面时间树
			{
				m_mthAddNodeToTrv(m_dtpCreateDate.Value);
				m_dtpCreateDate.Enabled=false;				
			}
			else //修改记录成功时，更新DataGrid中的序号
			{
				for(int i=0;i<m_dtbMRRoom.Rows.Count;i++)
				{
					m_dtbMRRoom.Rows[i][0]=(i+1).ToString();
				}
			}
			return 1;
		}
		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			string strDate=p_dtmAdd.ToString("yyyy-MM-dd HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmAdd;
			if(m_trvCreateDate.Nodes[0].Nodes.Count==0)
				m_trvCreateDate.Nodes[0].Nodes.Add(trnDate);
			else 
			{
				for(int i=0;i<m_trvCreateDate.Nodes[0].Nodes.Count;i++)
				{
					if(trnDate.Text.CompareTo (m_trvCreateDate.Nodes[0].Nodes[i].Text)>0)
					{
						m_trvCreateDate.Nodes[0].Nodes.Insert(i,trnDate);
						break;
					}
				}
			}
			m_trvCreateDate.SelectedNode=trnDate ;
			this.m_trvCreateDate.ExpandAll();

		}
				
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(){}
		public void Display(string strInPatientID,string strInPatientDate)
		{
		}
		public void Print()
		{
			m_lngPrint();
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
		#endregion

		#region 窗体事件及流程控制		
		private void frmMRIApply_Load(object sender, System.EventArgs e)
		{			
			m_mthSetQuickKeys();

			m_trvCreateDate.Nodes.Add("申请时间");			
			m_lsvInPatientID.Visible=false;

            //m_lsvTechnicianSign.FullRowSelect=true;
            //m_lsvTechnicianSign.Visible=false;		
			
            //m_lsvCreateUserName.FullRowSelect=true;
            //m_lsvCreateUserName.Visible=false;		

			this.m_trvCreateDate.SelectedNode=this.m_trvCreateDate.Nodes[0];

			m_txtCheckPrice.Focus();
		}		
		
		private void m_mthDisplayDates(string p_strInPatientID,string p_strInPatientDate)
		{
			if(p_strInPatientID ==null || p_strInPatientDate =="") 
				return ;

			m_trvCreateDate.Nodes[0].Nodes.Clear();

			DateTime [] m_dtmArr= m_objDomain.m_dtmGetTimeInfoOfAPatientArr(p_strInPatientID ,p_strInPatientDate);

			if(m_dtmArr==null) 
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}

			for(int i=m_dtmArr.Length-1;i>=0 ;i--)
			{
		
				string strDate=m_dtmArr[i].ToString("yyyy-MM-dd HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.m_trvCreateDate.Nodes[0].Nodes.Add(trnDate );
				
			}
			this.m_trvCreateDate.ExpandAll();
			this.m_trvCreateDate.SelectedNode = this.m_trvCreateDate.Nodes[0].Nodes[0];		
		}
		
		private void m_mthReadOnly(bool blnIsReadOnly)
		{
			if(blnIsReadOnly)
			{
				foreach(Control ctlText in this.Controls )
				{
					string typeName = ctlText.GetType().Name;
				
					if(typeName =="ctlBorderTextBox" && ctlText.Name!="txtInPatientID" && ctlText.Name!="m_txtBedNO" && ctlText.Name!="m_txtPatientName" && ctlText.Name != "m_txtWeightTitle")
						ctlText.Enabled=false;
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name != "m_dtpCreateDate") 
						((ctlTimePicker)ctlText).Enabled=false;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = true;
					if(typeName == "RichTextBox") ((RichTextBox)ctlText).ReadOnly=true;
					if(typeName == "DataGrid") ((DataGrid)ctlText).ReadOnly=true;
					
					
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
					if(typeName == "ctlTimePicker" && ((ctlTimePicker)ctlText).Name != "m_dtpCreateDate") 
						((ctlTimePicker)ctlText).Enabled=true;
                    if (typeName == "ctlRichTextBox") ((com.digitalwave.controls.ctlRichTextBox)ctlText).m_BlnReadOnly = false;
					if(typeName == "RichTextBox") ((RichTextBox)ctlText).ReadOnly=false;
					if(typeName == "DataGrid") ((DataGrid)ctlText).ReadOnly=false;
										
				}
				blnCanDelete=true;

			}
		}

		private void m_trvCreateDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUp2();

			if(m_trvCreateDate.SelectedNode==m_trvCreateDate.Nodes[0])
			{
				objclsMRIApply_All=null;
				m_dtpCreateDate.Enabled=true;
				m_mthReadOnly(false);

				if(m_objCurrentPatient != null && m_strInPatientDate != null)
				{
					m_mthSetDefaultValue(m_objCurrentPatient);		
				}

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			}
			else
			{
				if(m_objCurrentPatient!=null)
					m_mthSetFormInfo(e.Node.Text);
				if(objclsMRIApply_All!=null && objclsMRIApply_All.m_objclsMRIApply!=null)
				{
					m_mthReadOnly(clsEMRLogin.LoginEmployee.m_strEMPID_CHR!=objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserID.Trim());
				}

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}

			m_mthAddFormStatusForClosingSave();
		}

		private void m_mthSetFormInfo(string p_strCreateDate)
		{
			objclsMRIApply_All=m_objDomain.m_objGetMRIApply_All(m_strInPatientID,m_strInPatientDate,p_strCreateDate);
			if(objclsMRIApply_All==null || objclsMRIApply_All.m_objclsMRIApply==null)
				return;
//			m_lblCreateUserName.Text=objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserName;
//			m_lblCreateUserName.Tag=objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserID;
			
			m_lblApplyDeptName.Text=objclsMRIApply_All.m_objclsMRIApply.m_strApplyDeptName;
			m_lblApplyDeptName.Tag=objclsMRIApply_All.m_objclsMRIApply.m_strApplyDeptID;

			m_txtCheckPrice.Text=objclsMRIApply_All.m_objclsMRIApply.m_strCheckPrice;
			m_txtMR_ID.Text=objclsMRIApply_All.m_objclsMRIApply.m_strMR_ID;
			m_txtSicknessHistoryAndBodyCharacter.Text=objclsMRIApply_All.m_objclsMRIApply.m_strSicknessHistoryAndBodyCharacter;
			m_txtOtherCheckResultAndRegisterID.Text=objclsMRIApply_All.m_objclsMRIApply.m_strOtherCheckResultAndRegisterID;
			m_txtClinicDiagnose.Text=objclsMRIApply_All.m_objclsMRIApply.m_strClinicDiagnose;
			m_txtCheckPart.Text=objclsMRIApply_All.m_objclsMRIApply.m_strCheckPart;
			m_chkHasOperationHistory.Checked=objclsMRIApply_All.m_objclsMRIApply.m_strHasOperationHistory=="True" ? true:false;
			m_txtHasMetalInBodyAndPart.Text=objclsMRIApply_All.m_objclsMRIApply.m_strHasMetalInBodyAndPart;
			m_txtMakeShadowQty.Text=objclsMRIApply_All.m_objclsMRIApply.m_strMakeShadowQty;
			m_txtPatientReactionInScan.Text=objclsMRIApply_All.m_objclsMRIApply.m_strPatientReactionInScan;
			m_txtScanTime.Text=objclsMRIApply_All.m_objclsMRIApply.m_strScanTime;
			this.m_txtWeightTitle.Text=objclsMRIApply_All.m_objclsMRIApply.m_strWeight;
			m_blnCanLikeSeaching=false;
			m_txtTechnicianSign.Text=objclsMRIApply_All.m_objclsMRIApply.m_strTechnicianSignName;			
			m_txtTechnicianSign.Tag=objclsMRIApply_All.m_objclsMRIApply.m_strTechnicianSignID;
			m_blnCanLikeSeaching=true;

			m_dtpCreateDate.Value=DateTime.Parse(p_strCreateDate);
			m_dtpCreateDate.Enabled=false;
			m_mthReadOnly(true);


			///
//			this.m_lblBirthday.Text =MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy年MM月dd日");
//			this.m_lblTel.Text=MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_StrHomePhone;
//			this.m_lblZipeCode.Text=MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_StrHomePC;
//			this.m_lblAddress.Text=MDIParent.s_ObjCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;

			if(objclsMRIApply_All.m_objclsMRIApply_MRRoomArr!=null)
				for(int i=0;i<objclsMRIApply_All.m_objclsMRIApply_MRRoomArr.Length;i++)
				{
					Object[] objRes=new Object[8];
					objRes[0]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strSerialNO;
					objRes[1]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strPartAndLine;
					objRes[2]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strPulseSerial;
					objRes[3]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strParam;
					objRes[4]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strFix;
					objRes[5]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerNum.Trim()=="" ? "0" : objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerNum;
					objRes[6]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerHeight=="" ? "0": objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerHeight ;
					objRes[7]=objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerDistance=="" ? "0" : objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerDistance;
					
					m_dtbMRRoom.Rows.Add(objRes);
				}

			if(objclsMRIApply_All.m_strOperationHistoryTimeArr!=null)
				for(int i=0;i<objclsMRIApply_All.m_strOperationHistoryTimeArr.Length;i++)
				{
					Object[] objRes=new Object[1];
					try
					{
						DateTime dtmTemp=DateTime.Parse(objclsMRIApply_All.m_strOperationHistoryTimeArr[i]);
						objRes[0]=dtmTemp;										
						m_dtbOperationTime.Rows.Add(objRes);
					}
					catch{}
				}
		}			
		
		/// <summary>
		/// 清空除时间树节点和病人基本信息以外的界面
		/// </summary>
		private void m_mthClearUp2()
		{
			m_dtpCreateDate.Value=DateTime.Now;
//			m_lblCreateUserName.Text=MDIParent.strOperatorName;
//			m_lblCreateUserName.Tag=MDIParent.strOperatorID;
			
            //m_lblApplyDeptName.Text=MDIParent.s_ObjDepartment.m_StrDeptName;
            //m_lblApplyDeptName.Tag=MDIParent.s_ObjDepartment.m_StrDeptID;
			m_txtWeightTitle.Text = "";
			m_txtCheckPrice.Text="";
			m_txtMR_ID.Text="";
			m_txtSicknessHistoryAndBodyCharacter.Text="";
			m_txtOtherCheckResultAndRegisterID.Text="";
			m_txtClinicDiagnose.Text="";
			m_txtCheckPart.Text="";
			m_chkHasOperationHistory.Checked=false;
			m_txtHasMetalInBodyAndPart.Text="";
			m_txtMakeShadowQty.Text="";
			m_txtPatientReactionInScan.Text="";
			m_txtScanTime.Text="";
			
			m_blnCanLikeSeaching=false;
			m_txtTechnicianSign.Text="";
			m_txtTechnicianSign.Tag=null;
			m_blnCanLikeSeaching=true;

			m_dtgOperationTime.CurrentRowIndex=0;
			((DataTable)m_dtgOperationTime.DataSource).Clear();

			m_dtgMRRoom.CurrentRowIndex=0;
			((DataTable)m_dtgMRRoom.DataSource).Clear();

            MDIParent.m_mthSetDefaulEmployee(m_txtCreateUserName);

		}

		/// <summary>
		/// 清空除病人基本信息以外的界面
		/// </summary>
		private void m_mthClearUpFormInfo()
		{	
            //m_objSignTool.m_mthSetDefaulEmployee();

			m_mthClearUp2();
			m_trvCreateDate.Nodes[0].Nodes.Clear();			
		}

		/// <summary>
		/// 清空所有界面
		/// </summary>
		private void m_mthClearUp()
		{
			this.m_mthClearPatientBaseInfo();	
			this.m_mthClearUpFormInfo();
			this.m_blnCanLikeSeaching=false;
			txtInPatientID.Text="";
			this.m_blnCanLikeSeaching=true;			
		}
		

		#region 医师签名		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter					
                    //if(((Control)sender).Name=="m_txtTechnicianSign")
                    //{						
                    //    m_mthGetDoctorList(m_txtTechnicianSign.Text);

                    //    if(((Control)sender).Name=="m_txtTechnicianSign")
                    //    {
                    //        if(m_lsvTechnicianSign.Items.Count==1 && (m_txtTechnicianSign.Text==m_lsvTechnicianSign.Items[0].SubItems[0].Text|| m_txtTechnicianSign.Text==m_lsvTechnicianSign.Items[0].SubItems[1].Text))
                    //        {
                    //            m_lsvTechnicianSign.Items[0].Selected=true;
                    //            m_lsvTechnicianSign_DoubleClick(null,null);
                    //            break;
                    //        }
                    //    }
                        
                    //}
                    //if(((Control)sender).Name=="m_txtCreateUserName")
                    //{
                    //    m_mthGetDoctorListEx(m_txtCreateUserName.Text);

                    //    if(this.m_lsvCreateUserName.Items.Count==1 && (m_txtCreateUserName.Text==m_lsvCreateUserName.Items[0].SubItems[0].Text|| m_txtCreateUserName.Text==m_lsvCreateUserName.Items[0].SubItems[1].Text))
                    //    {
                    //        m_lsvCreateUserName.Items[0].Selected=true;
                    //        m_lsvCreateUserName_DoubleClick(null,null);
                    //        break;
                    //    }
                    //}
                    //if(((Control)sender).Name=="m_lsvTechnicianSign")
                    //{
                    //    m_lsvTechnicianSign_DoubleClick(null,null);						
                    //}
                    //if(((Control)sender).Name=="m_lsvCreateUserName")
                    //{
                    //    m_lsvCreateUserName_DoubleClick(null,null);
                    //}
					

					break;

				case 38:
				case 40:
                    //if(((Control)sender).Name=="m_txtTechnicianSign")
                    //{
                    //    if(m_txtTechnicianSign.Text.Length>0)
                    //    {	
                    //        if(m_lsvTechnicianSign.Visible==false || m_lsvTechnicianSign.Items.Count==0)
                    //        {								
                    //            m_mthGetDoctorList(m_txtTechnicianSign.Text);
                    //        }

                    //        m_lsvTechnicianSign.BringToFront();
                    //        m_lsvTechnicianSign.Visible=true;
                    //        m_lsvTechnicianSign.Focus();
                    //        if( m_lsvTechnicianSign.Items.Count>0)
                    //        {
                    //            m_lsvTechnicianSign.Items[0].Selected=true;
                    //            m_lsvTechnicianSign.Items[0].Focused=true;
                    //        }	
                    //    }
                    //}				
	
                    //if(((Control)sender).Name=="m_txtCreateUserName")
                    //{
                    //    if(m_txtCreateUserName .Text.Length>0)
                    //    {	
                    //        if(m_lsvCreateUserName.Visible==false || m_lsvCreateUserName.Items.Count==0)
                    //        {								
                    //            m_mthGetDoctorListEx(m_txtCreateUserName .Text);
                    //        }

                    //        m_lsvCreateUserName.BringToFront();
                    //        m_lsvCreateUserName.Visible=true;
                    //        m_lsvCreateUserName.Focus();
                    //        if( m_lsvCreateUserName.Items.Count>0)
                    //        {
                    //            m_lsvCreateUserName.Items[0].Selected=true;
                    //            m_lsvCreateUserName.Items[0].Focused=true;
                    //        }	
                    //    }
                    //}				
	
					break;	
			
				case 113://save
					this.m_lngSave(); 
					break;
				case 114://del
					this.m_lngDelete(); 
					break;
				case 115://print
					this.m_lngPrint();
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}

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
            //    m_lsvTechnicianSign.Visible = false;
            //    return;
            //}

            //clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

            //if(objDoctorArr == null)
            //{
            //    m_lsvTechnicianSign.Visible = false;
            //    return;
            //}

            //m_lsvTechnicianSign.Items.Clear();

            //for(int i=0;i<objDoctorArr.Length;i++)
            //{
            //    ListViewItem lviDoctor = new ListViewItem(
            //        new string[]{
            //                        objDoctorArr[i].m_StrEmployeeID,
            //                        objDoctorArr[i].m_StrFirstName
            //                    });
            //    lviDoctor.Tag = objDoctorArr[i];

            //    m_lsvTechnicianSign.Items.Add(lviDoctor);
            //}

            //m_mthChangeListViewLastColumnWidth(m_lsvTechnicianSign);
            //m_lsvTechnicianSign.BringToFront();
            //m_lsvTechnicianSign.Visible = true;
		}


		private void m_mthGetDoctorListEx(string p_strDoctorNameLike)
		{
			
			/*
			 * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
			 * 在相应的位置显示ListView。
			 */			

            //if(p_strDoctorNameLike.Length == 0)
            //{
            //    m_lsvCreateUserName .Visible = false;
            //    return;
            //}

            //clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

            //if(objDoctorArr == null)
            //{
            //    m_lsvCreateUserName.Visible = false;
            //    return;
            //}

            //m_lsvCreateUserName.Items.Clear();

            //for(int i=0;i<objDoctorArr.Length;i++)
            //{
            //    ListViewItem lviDoctor = new ListViewItem(
            //        new string[]{
            //                        objDoctorArr[i].m_StrEmployeeID,
            //                        objDoctorArr[i].m_StrFirstName
            //                    });
            //    lviDoctor.Tag = objDoctorArr[i];

            //    m_lsvCreateUserName.Items.Add(lviDoctor);
            //}

            //m_mthChangeListViewLastColumnWidth(m_lsvCreateUserName);
            //m_lsvCreateUserName.BringToFront();
            //m_lsvCreateUserName.Visible = true;
		}


		private void m_lsvTechnicianSign_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
//            if(m_lsvTechnicianSign.SelectedItems.Count <= 0)
//                return;

//            clsEmployee objEmp = (clsEmployee)m_lsvTechnicianSign.SelectedItems[0].Tag;

//            if(objEmp == null)
//                return;	

////			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
////				return;

//            m_lsvTechnicianSign.Visible = false;
//            m_txtTechnicianSign.Text=objEmp.m_StrLastName;
//            m_txtTechnicianSign.Tag= objEmp.m_StrEmployeeID;
//            m_txtTechnicianSign.Focus();
		}

		private void m_lsvTechnicianSign_LostFocus(object sender,EventArgs e)
		{							
            //if(!m_txtTechnicianSign.Focused && !m_lsvTechnicianSign.Focused)
            //{
            //    m_lsvTechnicianSign.Visible=false;				
            //}				
		}	

		#endregion 医师签名

		private void m_dtgOperationTime_GotFocus(object sender, System.EventArgs e)
		{
			if(clmOperationHistoryTime.TextBox.Text=="")
			{
				clmOperationHistoryTime.TextBox.Text=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		private void m_txtMakeShadowQty_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(m_txtMakeShadowQty.Text.Trim() !="")
					float.Parse(m_txtMakeShadowQty.Text);
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("造影剂量只能输入数字!");
				m_txtMakeShadowQty.Focus();
			}
		}
		#endregion		

		#region 打印
		private ReportDocument m_objReportDocument;	
		private void m_mthInitializeReportDocument()
		{
			m_objReportDocument = new ReportDocument();
			m_objReportDocument.Load(m_strTemplatePath+"cryMRIApplyReport.rpt");
		
		}
		
		private void m_mthPrintPreView()
		{
			m_mthInitializeReportDocument();
			DataSet objDataSet =  m_mthInitMRIApplyDataSet();
			m_mthAddNewDataForMRIApplyDataSet(objDataSet);
			
			frmCryReptView objfrmCryReptView=new frmCryReptView(m_objReportDocument);
			objfrmCryReptView.MdiParent=this.MdiParent;
			objfrmCryReptView.Show();
	
		}

		/*
* DataSet : MRIApply
* DataTable : dtbMRIApply
* 	DataColumn : InPatientID(string)
* 	DataColumn : InPatientDate(string)
* 	DataColumn : CreateDate(string)
* 	DataColumn : ModifyDate(string)
* 	DataColumn : CreateUserID(string)
* 	DataColumn : ApplyDeptID(string)
* 	DataColumn : CreateUserName(string)
* 	DataColumn : ApplyDeptName(string)
* 	DataColumn : CheckPrice(string)
* 	DataColumn : MR_ID(string)
* 	DataColumn : SicknessHistoryAndBodyCharacter(string)
* 	DataColumn : OtherCheckResultAndRegisterID(string)
* 	DataColumn : ClinicDiagnose(string)
* 	DataColumn : CheckPart(string)
* 	DataColumn : HasOperationHistory(string)
* 	DataColumn : HasMetalInBodyAndPart(string)
* 	DataColumn : MakeShadowQty(string)
* 	DataColumn : PatientReactionInScan(string)
* 	DataColumn : ScanTime(string)
* 	DataColumn : TechnicianSignName(string)
* DataTable : dtbMRIApply_MRRoom
* 	DataColumn : SerialNO(string)
* 	DataColumn : PartAndLine(string)
* 	DataColumn : PulseSerial(string)
* 	DataColumn : Param(string)
* 	DataColumn : Fix(string)
* 	DataColumn : LayerNum(string)
* 	DataColumn : LayerHeight(string)
* 	DataColumn : LayerDistance(string)
* 	DataColumn : Other0(string)
* 	DataColumn : Other1(string)
* 	DataColumn : Other2(string)
* DataTable : dtbMRIApply_OperationTime
* 	DataColumn : OperationHistoryTime(string)
* 	DataColumn : Other0(string)
* 	DataColumn : Other1(string)
* 	DataColumn : Other2(string)
* 	DataColumn : Other3(string)
* 	DataColumn : Other4(string)
* DataTable : dtbPatientBaseInfo
* 	DataColumn : Name(string)
* 	DataColumn : Sex(string)
* 	DataColumn : Age(string)
* 	DataColumn : Area(string)
* 	DataColumn : BedNo(string)
* 	DataColumn : Address(string)
* 	DataColumn : Birthday(string)
* 	DataColumn : Dept(string)
* 	DataColumn : PYCode(string)
* 	DataColumn : Room(string)
* 	DataColumn : Tel(string)
* 	DataColumn : Weight(string)
* 	DataColumn : ZipeCode(string)
* 	DataColumn : Other0(string)
* 	DataColumn : Other1(string)
* 	DataColumn : Other2(string)
* 	DataColumn : Other3(string)
* 	DataColumn : Other4(string)
* 	DataColumn : Other5(string)
* 	DataColumn : Other6(string)
*/ 
		private DataSet m_mthInitMRIApplyDataSet()
		{
			DataSet dsMRIApply = new DataSet("MRIApply");

			DataTable dtdtbMRIApply = new DataTable("dtbMRIApply");

			DataColumn dcdtbMRIApplyInPatientID = new DataColumn("InPatientID",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyInPatientID);

			DataColumn dcdtbMRIApplyInPatientDate = new DataColumn("InPatientDate",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyInPatientDate);

			DataColumn dcdtbMRIApplyCreateDate = new DataColumn("CreateDate",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyCreateDate);

			DataColumn dcdtbMRIApplyModifyDate = new DataColumn("ModifyDate",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyModifyDate);

			DataColumn dcdtbMRIApplyCreateUserID = new DataColumn("CreateUserID",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyCreateUserID);

			DataColumn dcdtbMRIApplyApplyDeptID = new DataColumn("ApplyDeptID",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyApplyDeptID);

			DataColumn dcdtbMRIApplyCreateUserName = new DataColumn("CreateUserName",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyCreateUserName);

			DataColumn dcdtbMRIApplyApplyDeptName = new DataColumn("ApplyDeptName",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyApplyDeptName);

			DataColumn dcdtbMRIApplyCheckPrice = new DataColumn("CheckPrice",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyCheckPrice);

			DataColumn dcdtbMRIApplyMR_ID = new DataColumn("MR_ID",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyMR_ID);

			DataColumn dcdtbMRIApplySicknessHistoryAndBodyCharacter = new DataColumn("SicknessHistoryAndBodyCharacter",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplySicknessHistoryAndBodyCharacter);

			DataColumn dcdtbMRIApplyOtherCheckResultAndRegisterID = new DataColumn("OtherCheckResultAndRegisterID",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyOtherCheckResultAndRegisterID);

			DataColumn dcdtbMRIApplyClinicDiagnose = new DataColumn("ClinicDiagnose",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyClinicDiagnose);

			DataColumn dcdtbMRIApplyCheckPart = new DataColumn("CheckPart",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyCheckPart);

			DataColumn dcdtbMRIApplyHasOperationHistory = new DataColumn("HasOperationHistory",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyHasOperationHistory);

			DataColumn dcdtbMRIApplyHasMetalInBodyAndPart = new DataColumn("HasMetalInBodyAndPart",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyHasMetalInBodyAndPart);

			DataColumn dcdtbMRIApplyMakeShadowQty = new DataColumn("MakeShadowQty",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyMakeShadowQty);

			DataColumn dcdtbMRIApplyPatientReactionInScan = new DataColumn("PatientReactionInScan",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyPatientReactionInScan);

			DataColumn dcdtbMRIApplyScanTime = new DataColumn("ScanTime",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyScanTime);

			DataColumn dcdtbMRIApplyTechnicianSignName = new DataColumn("TechnicianSignName",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyTechnicianSignName);

			DataColumn dcdtbMRIApplyTechnicianWeight = new DataColumn("WEITHT",typeof(string));

			dtdtbMRIApply.Columns.Add(dcdtbMRIApplyTechnicianWeight);


			dsMRIApply.Tables.Add(dtdtbMRIApply);

			DataTable dtdtbMRIApply_MRRoom = new DataTable("dtbMRIApply_MRRoom");

			DataColumn dcdtbMRIApply_MRRoomSerialNO = new DataColumn("SerialNO",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomSerialNO);

			DataColumn dcdtbMRIApply_MRRoomPartAndLine = new DataColumn("PartAndLine",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomPartAndLine);

			DataColumn dcdtbMRIApply_MRRoomPulseSerial = new DataColumn("PulseSerial",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomPulseSerial);

			DataColumn dcdtbMRIApply_MRRoomParam = new DataColumn("Param",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomParam);

			DataColumn dcdtbMRIApply_MRRoomFix = new DataColumn("Fix",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomFix);

			DataColumn dcdtbMRIApply_MRRoomLayerNum = new DataColumn("LayerNum",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomLayerNum);

			DataColumn dcdtbMRIApply_MRRoomLayerHeight = new DataColumn("LayerHeight",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomLayerHeight);

			DataColumn dcdtbMRIApply_MRRoomLayerDistance = new DataColumn("LayerDistance",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomLayerDistance);

			DataColumn dcdtbMRIApply_MRRoomOther0 = new DataColumn("Other0",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomOther0);

			DataColumn dcdtbMRIApply_MRRoomOther1 = new DataColumn("Other1",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomOther1);

			DataColumn dcdtbMRIApply_MRRoomOther2 = new DataColumn("Other2",typeof(string));

			dtdtbMRIApply_MRRoom.Columns.Add(dcdtbMRIApply_MRRoomOther2);

			dsMRIApply.Tables.Add(dtdtbMRIApply_MRRoom);

			DataTable dtdtbMRIApply_OperationTime = new DataTable("dtbMRIApply_OperationTime");

			DataColumn dcdtbMRIApply_OperationTimeOperationHistoryTime = new DataColumn("OperationHistoryTime",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOperationHistoryTime);

			DataColumn dcdtbMRIApply_OperationTimeOther0 = new DataColumn("Other0",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOther0);

			DataColumn dcdtbMRIApply_OperationTimeOther1 = new DataColumn("Other1",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOther1);

			DataColumn dcdtbMRIApply_OperationTimeOther2 = new DataColumn("Other2",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOther2);

			DataColumn dcdtbMRIApply_OperationTimeOther3 = new DataColumn("Other3",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOther3);

			DataColumn dcdtbMRIApply_OperationTimeOther4 = new DataColumn("Other4",typeof(string));

			dtdtbMRIApply_OperationTime.Columns.Add(dcdtbMRIApply_OperationTimeOther4);

			dsMRIApply.Tables.Add(dtdtbMRIApply_OperationTime);

			DataTable dtdtbPatientBaseInfo = new DataTable("dtbPatientBaseInfo");

			DataColumn dcdtbPatientBaseInfoName = new DataColumn("Name",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoName);

			DataColumn dcdtbPatientBaseInfoSex = new DataColumn("Sex",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoSex);

			DataColumn dcdtbPatientBaseInfoAge = new DataColumn("Age",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoAge);

			DataColumn dcdtbPatientBaseInfoArea = new DataColumn("Area",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoArea);

			DataColumn dcdtbPatientBaseInfoBedNo = new DataColumn("BedNo",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoBedNo);

			DataColumn dcdtbPatientBaseInfoAddress = new DataColumn("Address",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoAddress);

			DataColumn dcdtbPatientBaseInfoBirthday = new DataColumn("Birthday",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoBirthday);

			DataColumn dcdtbPatientBaseInfoDept = new DataColumn("Dept",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoDept);

			DataColumn dcdtbPatientBaseInfoPYCode = new DataColumn("PYCode",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoPYCode);

			DataColumn dcdtbPatientBaseInfoRoom = new DataColumn("Room",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoRoom);

			DataColumn dcdtbPatientBaseInfoTel = new DataColumn("Tel",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoTel);

			DataColumn dcdtbPatientBaseInfoWeight = new DataColumn("Weight",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoWeight);

			DataColumn dcdtbPatientBaseInfoZipeCode = new DataColumn("ZipeCode",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoZipeCode);

			DataColumn dcdtbPatientBaseInfoOther0 = new DataColumn("Other0",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther0);

			DataColumn dcdtbPatientBaseInfoOther1 = new DataColumn("Other1",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther1);

			DataColumn dcdtbPatientBaseInfoOther2 = new DataColumn("Other2",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther2);

			DataColumn dcdtbPatientBaseInfoOther3 = new DataColumn("Other3",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther3);

			DataColumn dcdtbPatientBaseInfoOther4 = new DataColumn("Other4",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther4);

			DataColumn dcdtbPatientBaseInfoOther5 = new DataColumn("Other5",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther5);

			DataColumn dcdtbPatientBaseInfoOther6 = new DataColumn("Other6",typeof(string));

			dtdtbPatientBaseInfo.Columns.Add(dcdtbPatientBaseInfoOther6);

			dsMRIApply.Tables.Add(dtdtbPatientBaseInfo);

			return dsMRIApply;
		}

		/*
		* DataSet : MRIApply
		* DataTable : dtbMRIApply
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : InPatientDate(string)
		* 	DataColumn : CreateDate(string)
		* 	DataColumn : ModifyDate(string)
		* 	DataColumn : CreateUserID(string)
		* 	DataColumn : ApplyDeptID(string)
		* 	DataColumn : CreateUserName(string)
		* 	DataColumn : ApplyDeptName(string)
		* 	DataColumn : CheckPrice(string)
		* 	DataColumn : MR_ID(string)
		* 	DataColumn : SicknessHistoryAndBodyCharacter(string)
		* 	DataColumn : OtherCheckResultAndRegisterID(string)
		* 	DataColumn : ClinicDiagnose(string)
		* 	DataColumn : CheckPart(string)
		* 	DataColumn : HasOperationHistory(string)
		* 	DataColumn : HasMetalInBodyAndPart(string)
		* 	DataColumn : MakeShadowQty(string)
		* 	DataColumn : PatientReactionInScan(string)
		* 	DataColumn : ScanTime(string)
		* 	DataColumn : TechnicianSignName(string)
		* DataTable : dtbMRIApply_MRRoom
		* 	DataColumn : SerialNO(string)
		* 	DataColumn : PartAndLine(string)
		* 	DataColumn : PulseSerial(string)
		* 	DataColumn : Param(string)
		* 	DataColumn : Fix(string)
		* 	DataColumn : LayerNum(string)
		* 	DataColumn : LayerHeight(string)
		* 	DataColumn : LayerDistance(string)
		* 	DataColumn : Other0(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* DataTable : dtbMRIApply_OperationTime
		* 	DataColumn : OperationHistoryTime(string)
		* 	DataColumn : Other0(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* DataTable : dtbPatientBaseInfo
		* 	DataColumn : Name(string)
		* 	DataColumn : Sex(string)
		* 	DataColumn : Age(string)
		* 	DataColumn : Area(string)
		* 	DataColumn : BedNo(string)
		* 	DataColumn : Address(string)
		* 	DataColumn : Birthday(string)
		* 	DataColumn : Dept(string)
		* 	DataColumn : PYCode(string)
		* 	DataColumn : Room(string)
		* 	DataColumn : Tel(string)
		* 	DataColumn : Weight(string)
		* 	DataColumn : ZipeCode(string)
		* 	DataColumn : Other0(string)
		* 	DataColumn : Other1(string)
		* 	DataColumn : Other2(string)
		* 	DataColumn : Other3(string)
		* 	DataColumn : Other4(string)
		* 	DataColumn : Other5(string)
		* 	DataColumn : Other6(string)
		*/ 
		private void m_mthAddNewDataForMRIApplyDataSet(DataSet dsMRIApply)
		{
			DataTable dtdtbMRIApply = dsMRIApply.Tables["DTBMRIAPPLY"];

			object [] objdtbMRIApplyDatas = new object[21];
			objclsMRIApply_All=m_objDomain.m_objGetMRIApply_All(m_strInPatientID,m_strInPatientDate,m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (m_ObjCurrentEmrPatientSession != null)
            {
                objdtbMRIApplyDatas[0] = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
			    objdtbMRIApplyDatas[1] = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                objdtbMRIApplyDatas[0] = string.Empty;
                objdtbMRIApplyDatas[1] = string.Empty;
            }
           
			objdtbMRIApplyDatas[2] = m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objdtbMRIApplyDatas[3] = "";//ModifyDate;

			if(objclsMRIApply_All !=null)
			{
				objdtbMRIApplyDatas[4] = objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserID;//CreateUserID;
				objdtbMRIApplyDatas[5] = objclsMRIApply_All.m_objclsMRIApply.m_strApplyDeptID;//ApplyDeptID;
				objdtbMRIApplyDatas[6] = objclsMRIApply_All.m_objclsMRIApply.m_strCreateUserName;//CreateUserName;
				objdtbMRIApplyDatas[7] = objclsMRIApply_All.m_objclsMRIApply.m_strApplyDeptName;//ApplyDeptName;
				objdtbMRIApplyDatas[8] = objclsMRIApply_All.m_objclsMRIApply.m_strCheckPrice;//CheckPrice;
				objdtbMRIApplyDatas[9] = objclsMRIApply_All.m_objclsMRIApply.m_strMR_ID;//MR_ID;
				objdtbMRIApplyDatas[10] = objclsMRIApply_All.m_objclsMRIApply.m_strSicknessHistoryAndBodyCharacter;//SicknessHistoryAndBodyCharacter;
				objdtbMRIApplyDatas[11] = objclsMRIApply_All.m_objclsMRIApply.m_strOtherCheckResultAndRegisterID;//OtherCheckResultAndRegisterID;
				objdtbMRIApplyDatas[12] = objclsMRIApply_All.m_objclsMRIApply.m_strClinicDiagnose;//ClinicDiagnose;
				objdtbMRIApplyDatas[13] = objclsMRIApply_All.m_objclsMRIApply.m_strCheckPart;//CheckPart;
				objdtbMRIApplyDatas[14] = objclsMRIApply_All.m_objclsMRIApply.m_strHasOperationHistory;//HasOperationHistory;
				objdtbMRIApplyDatas[15] = objclsMRIApply_All.m_objclsMRIApply.m_strHasMetalInBodyAndPart;//HasMetalInBodyAndPart;
				objdtbMRIApplyDatas[16] = objclsMRIApply_All.m_objclsMRIApply.m_strMakeShadowQty;//MakeShadowQty;
				objdtbMRIApplyDatas[17] = objclsMRIApply_All.m_objclsMRIApply.m_strPatientReactionInScan;//PatientReactionInScan;
				objdtbMRIApplyDatas[18] = objclsMRIApply_All.m_objclsMRIApply.m_strScanTime;//ScanTime;
				objdtbMRIApplyDatas[19] = objclsMRIApply_All.m_objclsMRIApply.m_strTechnicianSignName;//TechnicianSignName;
				objdtbMRIApplyDatas[20] = objclsMRIApply_All.m_objclsMRIApply.m_strWeight;
			}
			else 
			{
				objdtbMRIApplyDatas[4] = "";//CreateUserID;
				objdtbMRIApplyDatas[5] = "";//ApplyDeptID;
				objdtbMRIApplyDatas[6] = "";//CreateUserName;
				objdtbMRIApplyDatas[7] = "";//ApplyDeptName;
				objdtbMRIApplyDatas[8] = "";//CheckPrice;
				objdtbMRIApplyDatas[9] = "";//MR_ID;
				objdtbMRIApplyDatas[10] = "";
				objdtbMRIApplyDatas[11] = "";//OtherCheckResultAndRegisterID;
				objdtbMRIApplyDatas[12] = "";
				objdtbMRIApplyDatas[13] = "";
				objdtbMRIApplyDatas[14] = "";
				objdtbMRIApplyDatas[15] = "";
				objdtbMRIApplyDatas[16] = "";
				objdtbMRIApplyDatas[17] = "";
				objdtbMRIApplyDatas[18] = "";
				objdtbMRIApplyDatas[19] = "";
				objdtbMRIApplyDatas[20] = "";
			}
			dtdtbMRIApply.Rows.Add(objdtbMRIApplyDatas);
			m_objReportDocument.Database.Tables["DTBMRIAPPLY"].SetDataSource(dtdtbMRIApply);

			DataTable dtdtbMRIApply_MRRoom = dsMRIApply.Tables["DTBMRIAPPLY_MRROOM"];

			object [] objdtbMRIApply_MRRoomDatas = new object[11];
			if(objclsMRIApply_All !=null && objclsMRIApply_All.m_objclsMRIApply_MRRoomArr!=null)
			{
				for(int i=0;i<objclsMRIApply_All.m_objclsMRIApply_MRRoomArr.Length;i++)
				{
					objdtbMRIApply_MRRoomDatas[0] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strSerialNO;
					objdtbMRIApply_MRRoomDatas[1] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strPartAndLine;
					objdtbMRIApply_MRRoomDatas[2] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strPulseSerial;
					objdtbMRIApply_MRRoomDatas[3] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strParam;
					objdtbMRIApply_MRRoomDatas[4] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strFix;
					objdtbMRIApply_MRRoomDatas[5] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerNum;
					objdtbMRIApply_MRRoomDatas[6] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerHeight;
					objdtbMRIApply_MRRoomDatas[7] = objclsMRIApply_All.m_objclsMRIApply_MRRoomArr[i].m_strLayerDistance;
					objdtbMRIApply_MRRoomDatas[8] = "";//Other0;
					objdtbMRIApply_MRRoomDatas[9] = "";//Other1;
					objdtbMRIApply_MRRoomDatas[10] ="";//Other2;
					dtdtbMRIApply_MRRoom.Rows.Add(objdtbMRIApply_MRRoomDatas);
				}
			}
			else
			{
				objdtbMRIApply_MRRoomDatas[0] = "";
				objdtbMRIApply_MRRoomDatas[1] = "";
				objdtbMRIApply_MRRoomDatas[2] = "";
				objdtbMRIApply_MRRoomDatas[3] = "";
				objdtbMRIApply_MRRoomDatas[4] = "";
				objdtbMRIApply_MRRoomDatas[5] = "";
				objdtbMRIApply_MRRoomDatas[6] = "";
				objdtbMRIApply_MRRoomDatas[7] = "";
				objdtbMRIApply_MRRoomDatas[8] = "";//Other0;
				objdtbMRIApply_MRRoomDatas[9] = "";//Other1;
				objdtbMRIApply_MRRoomDatas[10] ="";//Other2;
				dtdtbMRIApply_MRRoom.Rows.Add(objdtbMRIApply_MRRoomDatas);
			}
			m_objReportDocument.Database.Tables["DTBMRIAPPLY_MRROOM"].SetDataSource(dtdtbMRIApply_MRRoom);

			DataTable dtdtbMRIApply_OperationTime = dsMRIApply.Tables["DTBMRIAPPLY_OPERATIONTIME"];

			object [] objdtbMRIApply_OperationTimeDatas = new object[6];
			
			if(objclsMRIApply_All !=null)
			{
				string strOperationDateAll="";
				if(objclsMRIApply_All.m_strOperationHistoryTimeArr!=null)
				{
					for(int i=0;i<objclsMRIApply_All.m_strOperationHistoryTimeArr.Length;i++)
					{
						strOperationDateAll += objclsMRIApply_All.m_strOperationHistoryTimeArr[i];
						if(i !=objclsMRIApply_All.m_strOperationHistoryTimeArr.Length-1)
							strOperationDateAll +="、\r\n";
					}
				}
				objdtbMRIApply_OperationTimeDatas[0] = strOperationDateAll;// OperationHistoryTime;
				objdtbMRIApply_OperationTimeDatas[1] = objclsMRIApply_All.m_objclsMRIApply.m_strHasMetalInBodyAndPart;//HasMetalInBodyAndPart;//Other0;
				objdtbMRIApply_OperationTimeDatas[2] = "";//Other1;
				objdtbMRIApply_OperationTimeDatas[3] = "";//Other2;
				objdtbMRIApply_OperationTimeDatas[4] = "";//Other3;
				objdtbMRIApply_OperationTimeDatas[5] = "";//Other4;			
			}
			else
			{
				objdtbMRIApply_OperationTimeDatas[0] = "";// OperationHistoryTime;
				objdtbMRIApply_OperationTimeDatas[1] = "";
				objdtbMRIApply_OperationTimeDatas[2] = "";//Other1;
				objdtbMRIApply_OperationTimeDatas[3] = "";//Other2;
				objdtbMRIApply_OperationTimeDatas[4] = "";//Other3;
				objdtbMRIApply_OperationTimeDatas[5] = "";//Other4;		
			}
			dtdtbMRIApply_OperationTime.Rows.Add(objdtbMRIApply_OperationTimeDatas);
			m_objReportDocument.Database.Tables["DTBMRIAPPLY_OPERATIONTIME"].SetDataSource(dtdtbMRIApply_OperationTime);

			DataTable dtdtbPatientBaseInfo = dsMRIApply.Tables["DTBPATIENTBASEINFO"];

			object [] objdtbPatientBaseInfoDatas = new object[20];

            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                objdtbPatientBaseInfoDatas[0] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrLastName;//Name;
			    objdtbPatientBaseInfoDatas[1] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;//Sex;
			    objdtbPatientBaseInfoDatas[2] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;//Age;
			    objdtbPatientBaseInfoDatas[3] = m_ObjCurrentEmrPatientSession.m_strAreaName;//Area;
                if (m_ObjCurrentBed != null)
                {
                    objdtbPatientBaseInfoDatas[4] = m_ObjCurrentBed.m_strCODE_CHR;
                }
                else
                {
                    objdtbPatientBaseInfoDatas[4] = string.Empty;
                }
                objdtbPatientBaseInfoDatas[5] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;//Address;
                objdtbPatientBaseInfoDatas[6] = (m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth == DateTime.MinValue) ? "    年  月  日" : m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy年MM月dd日");//Birthday;
                objdtbPatientBaseInfoDatas[7] = m_ObjCurrentEmrPatientSession.m_strDeptName;//Dept;
            }
            else
            {
                objdtbPatientBaseInfoDatas[0] = string.Empty;
                objdtbPatientBaseInfoDatas[1] = string.Empty;
                objdtbPatientBaseInfoDatas[2] = string.Empty;
                objdtbPatientBaseInfoDatas[3] = string.Empty;
                objdtbPatientBaseInfoDatas[4] = string.Empty;
                objdtbPatientBaseInfoDatas[5] = string.Empty;
                objdtbPatientBaseInfoDatas[6] = string.Empty;
                objdtbPatientBaseInfoDatas[7] = string.Empty;
            }
			objdtbPatientBaseInfoDatas[8] = m_lblPYCode.Text;//PYCode;
            objdtbPatientBaseInfoDatas[9] = string.Empty; //Room;
			objdtbPatientBaseInfoDatas[10] = m_lblTel.Text;//Tel;
			objdtbPatientBaseInfoDatas[11] = this.m_txtWeightTitle.Text;//Weight;
			objdtbPatientBaseInfoDatas[12] = m_lblZipeCode.Text;//ZipeCode;
			objdtbPatientBaseInfoDatas[13] = "";//Other0;
			objdtbPatientBaseInfoDatas[14] = "";//Other1;
			objdtbPatientBaseInfoDatas[15] = "";//Other2;
			objdtbPatientBaseInfoDatas[16] = "";//Other3;
			objdtbPatientBaseInfoDatas[17] = "";//Other4;
			objdtbPatientBaseInfoDatas[18] = "";//Other5;
			objdtbPatientBaseInfoDatas[19] = "";//Other6;

			dtdtbPatientBaseInfo.Rows.Add(objdtbPatientBaseInfoDatas);
			m_objReportDocument.Database.Tables["DTBPATIENTBASEINFO"].SetDataSource(dtdtbPatientBaseInfo);

		}
		#endregion		


		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			this.m_lblBirthday.Text =p_objPatient.m_ObjPeopleInfo.m_DtmBirth.ToString("yyyy年MM月dd日");
			this.m_lblTel.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomePhone;
			this.m_lblZipeCode.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomePC;
			this.m_lblAddress.Text=p_objPatient.m_ObjPeopleInfo.m_StrHomeAddress ;

			//签名默认值
            //clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtCreateUserName );

			//默认值
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);

			//数据复用
//			iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//			{
//				this.m_txtSicknessHistoryAndBodyCharacter.Text = "患者因" + objInPatientCaseDefaultValue[0].m_strMainDescription + "于" + DateTime.Parse(objInPatientCaseDefaultValue[0].m_strInPatientDate).ToString("yyyy年M月d日") + "入院。";
//				this.m_txtClinicDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
//			}
		}

		private void m_lsvCreateUserName_DoubleClick(object sender, System.EventArgs e)
		{
			/*
				 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
				 */
            //if(m_lsvCreateUserName.SelectedItems.Count <= 0)
            //    return;

            //clsEmployee objEmp = (clsEmployee)m_lsvCreateUserName.SelectedItems[0].Tag;

            //if(objEmp == null)
            //    return;	

            //if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
            //    return;

            //m_lsvCreateUserName.Visible = false;
            //m_txtCreateUserName.Text=objEmp.m_StrLastName;
            //m_txtCreateUserName.Tag= objEmp.m_StrEmployeeID;
            //m_txtCreateUserName.Focus();
		}

		private void m_lsvCreateUserName_Leave(object sender, System.EventArgs e)
		{
            //if(!m_lsvCreateUserName.Focused && !m_lsvCreateUserName.Focused)
            //{
            //    m_lsvCreateUserName.Visible=false;				
            //}		
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_strInPatientID = string.Empty;
            m_strInPatientDate = string.Empty;
            m_mthClearUp2();

            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objCurrentPatient = m_objBaseCurrentPatient;
            m_strInPatientID = p_objSelectedSession.m_strEMRInpatientId;
            m_strInPatientDate = p_objSelectedSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss");

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

            this.m_mthDisplayDates(m_strInPatientID, m_strInPatientDate);	
        }
	}
}

