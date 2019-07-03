using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.OperationAgreedRecordServ;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// 手术（麻醉，介入治疗）前签字同意书
	/// </summary>
	public class frmOpraAnaSignAgree : frmHRPBaseForm,PublicFunction
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DateTimePicker m_dtpRelationSignDate;
		private System.Windows.Forms.DateTimePicker m_dtpDoctorSignDate;
		private System.Windows.Forms.TextBox m_txtRelationSign;
		private System.Windows.Forms.TextBox m_txtLeadSign;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboStateOfIllness;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboAction;
		private System.Windows.Forms.DateTimePicker m_dtpDirectorSignDate;
		private System.Windows.Forms.DateTimePicker m_dtpLeadSignDate;
		private System.Windows.Forms.Label m_lblPatient;
		private com.digitalwave.controls.ctlRichTextBox m_txtBadFactor;
		private com.digitalwave.controls.ctlRichTextBox m_txtSyndrome;
		private TextBox m_txtDoctorSign;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private PinkieControls.ButtonXP m_cmdDoctorSign;
		private TextBox m_txtDirectorSign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private PinkieControls.ButtonXP m_cmdDirectorSign;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
		private clsPatient objCurrentPatient=null;
		protected System.Windows.Forms.TreeView m_trvCreateDate;
        //private clsOperationAgreedRecordServ m_objoperation;
        //protected clsOperationAgreedRecordServ m_objOperationGet= new clsOperationAgreedRecordServ();
		private TreeNode m_trnRoot;
		protected System.Drawing.Printing.PrintDocument m_pdtPrintDocument;
		/// <summary>
		/// 是否可以触发树节点的选中事件
		/// </summary>
		private bool m_blnCanTreeNodeAfterSelectEventTakePlace=true; 
		public frmOpraAnaSignAgree()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			if(m_trvCreateDate.Nodes.Count==0)
				m_trvCreateDate.Nodes.Add("记录时间");
			m_trnRoot=m_trvCreateDate.Nodes[0];
			m_trvCreateDate.SelectedNode=m_trnRoot;

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDirectorSign, m_txtDirectorSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpraAnaSignAgree));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtDirectorSign = new System.Windows.Forms.TextBox();
            this.m_cmdDirectorSign = new PinkieControls.ButtonXP();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_txtSyndrome = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtBadFactor = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cboAction = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_cboStateOfIllness = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_lblPatient = new System.Windows.Forms.Label();
            this.m_txtLeadSign = new System.Windows.Forms.TextBox();
            this.m_txtRelationSign = new System.Windows.Forms.TextBox();
            this.m_dtpDoctorSignDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpLeadSignDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpDirectorSignDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpRelationSignDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_trvCreateDate = new System.Windows.Forms.TreeView();
            this.m_pdtPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(652, 193);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(748, 193);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(408, 157);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(408, 189);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(582, 157);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(616, 193);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(712, 193);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(216, 189);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(280, 209);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(460, 185);
            this.txtInPatientID.TabIndex = 3;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(626, 153);
            this.m_txtPatientName.TabIndex = 4;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(444, 153);
            this.m_txtBedNO.Size = new System.Drawing.Size(107, 23);
            this.m_txtBedNO.TabIndex = 2;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(256, 185);
            this.m_cboArea.TabIndex = 1;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(640, 222);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(460, 217);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(256, 153);
            this.m_cboDept.TabIndex = 0;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(216, 153);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 189);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(552, 153);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 80);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(622, 149);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(542, 39);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(657, 38);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(801, 89);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(198, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(601, 58);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtDirectorSign);
            this.panel1.Controls.Add(this.m_cmdDirectorSign);
            this.panel1.Controls.Add(this.m_txtDoctorSign);
            this.panel1.Controls.Add(this.m_cmdDoctorSign);
            this.panel1.Controls.Add(this.m_txtSyndrome);
            this.panel1.Controls.Add(this.m_txtBadFactor);
            this.panel1.Controls.Add(this.m_cboAction);
            this.panel1.Controls.Add(this.m_cboStateOfIllness);
            this.panel1.Controls.Add(this.m_lblPatient);
            this.panel1.Controls.Add(this.m_txtLeadSign);
            this.panel1.Controls.Add(this.m_txtRelationSign);
            this.panel1.Controls.Add(this.m_dtpDoctorSignDate);
            this.panel1.Controls.Add(this.m_dtpLeadSignDate);
            this.panel1.Controls.Add(this.m_dtpDirectorSignDate);
            this.panel1.Controls.Add(this.m_dtpRelationSignDate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 509);
            this.panel1.TabIndex = 10000004;
            // 
            // m_txtDirectorSign
            // 
            this.m_txtDirectorSign.AccessibleName = "NoDefault";
            this.m_txtDirectorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDirectorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDirectorSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtDirectorSign.Location = new System.Drawing.Point(488, 482);
            this.m_txtDirectorSign.Name = "m_txtDirectorSign";
            this.m_txtDirectorSign.ReadOnly = true;
            this.m_txtDirectorSign.Size = new System.Drawing.Size(102, 23);
            this.m_txtDirectorSign.TabIndex = 10000025;
            // 
            // m_cmdDirectorSign
            // 
            this.m_cmdDirectorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDirectorSign.DefaultScheme = true;
            this.m_cmdDirectorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDirectorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDirectorSign.Hint = "";
            this.m_cmdDirectorSign.Location = new System.Drawing.Point(392, 482);
            this.m_cmdDirectorSign.Name = "m_cmdDirectorSign";
            this.m_cmdDirectorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDirectorSign.Size = new System.Drawing.Size(96, 24);
            this.m_cmdDirectorSign.TabIndex = 10000026;
            this.m_cmdDirectorSign.Tag = "1";
            this.m_cmdDirectorSign.Text = "科主任签名:";
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleName = "NoDefault";
            this.m_txtDoctorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctorSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(84, 482);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(102, 23);
            this.m_txtDoctorSign.TabIndex = 10000022;
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(8, 482);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(76, 24);
            this.m_cmdDoctorSign.TabIndex = 10000023;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "医师签名:";
            // 
            // m_txtSyndrome
            // 
            this.m_txtSyndrome.AccessibleDescription = "并发症";
            this.m_txtSyndrome.BackColor = System.Drawing.Color.White;
            this.m_txtSyndrome.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSyndrome.ForeColor = System.Drawing.Color.Black;
            this.m_txtSyndrome.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtSyndrome.Location = new System.Drawing.Point(16, 257);
            this.m_txtSyndrome.m_BlnIgnoreUserInfo = false;
            this.m_txtSyndrome.m_BlnPartControl = false;
            this.m_txtSyndrome.m_BlnReadOnly = false;
            this.m_txtSyndrome.m_BlnUnderLineDST = false;
            this.m_txtSyndrome.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtSyndrome.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtSyndrome.m_IntCanModifyTime = 6;
            this.m_txtSyndrome.m_IntPartControlLength = 0;
            this.m_txtSyndrome.m_IntPartControlStartIndex = 0;
            this.m_txtSyndrome.m_StrUserID = "";
            this.m_txtSyndrome.m_StrUserName = "";
            this.m_txtSyndrome.Name = "m_txtSyndrome";
            this.m_txtSyndrome.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtSyndrome.Size = new System.Drawing.Size(760, 192);
            this.m_txtSyndrome.TabIndex = 1702;
            this.m_txtSyndrome.Text = "";
            // 
            // m_txtBadFactor
            // 
            this.m_txtBadFactor.AccessibleDescription = "不利因素";
            this.m_txtBadFactor.BackColor = System.Drawing.Color.White;
            this.m_txtBadFactor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBadFactor.ForeColor = System.Drawing.Color.Black;
            this.m_txtBadFactor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtBadFactor.Location = new System.Drawing.Point(16, 78);
            this.m_txtBadFactor.m_BlnIgnoreUserInfo = false;
            this.m_txtBadFactor.m_BlnPartControl = false;
            this.m_txtBadFactor.m_BlnReadOnly = false;
            this.m_txtBadFactor.m_BlnUnderLineDST = false;
            this.m_txtBadFactor.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtBadFactor.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtBadFactor.m_IntCanModifyTime = 6;
            this.m_txtBadFactor.m_IntPartControlLength = 0;
            this.m_txtBadFactor.m_IntPartControlStartIndex = 0;
            this.m_txtBadFactor.m_StrUserID = "";
            this.m_txtBadFactor.m_StrUserName = "";
            this.m_txtBadFactor.Name = "m_txtBadFactor";
            this.m_txtBadFactor.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBadFactor.Size = new System.Drawing.Size(760, 104);
            this.m_txtBadFactor.TabIndex = 1701;
            this.m_txtBadFactor.Text = "";
            // 
            // m_cboAction
            // 
            this.m_cboAction.AccessibleDescription = "手术";
            this.m_cboAction.AccessibleName = "NoDefault";
            this.m_cboAction.BackColor = System.Drawing.Color.White;
            this.m_cboAction.BorderColor = System.Drawing.Color.Black;
            this.m_cboAction.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboAction.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboAction.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboAction.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboAction.ForeColor = System.Drawing.Color.Black;
            this.m_cboAction.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboAction.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboAction.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboAction.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboAction.Location = new System.Drawing.Point(340, 32);
            this.m_cboAction.m_BlnEnableItemEventMenu = true;
            this.m_cboAction.Name = "m_cboAction";
            this.m_cboAction.SelectedIndex = -1;
            this.m_cboAction.SelectedItem = null;
            this.m_cboAction.SelectionStart = 0;
            this.m_cboAction.Size = new System.Drawing.Size(440, 23);
            this.m_cboAction.TabIndex = 1;
            this.m_cboAction.TabStop = false;
            this.m_cboAction.TextBackColor = System.Drawing.Color.White;
            this.m_cboAction.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cboStateOfIllness
            // 
            this.m_cboStateOfIllness.AccessibleDescription = "诊断";
            this.m_cboStateOfIllness.AccessibleName = "NoDefault";
            this.m_cboStateOfIllness.BackColor = System.Drawing.Color.White;
            this.m_cboStateOfIllness.BorderColor = System.Drawing.Color.Black;
            this.m_cboStateOfIllness.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboStateOfIllness.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboStateOfIllness.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboStateOfIllness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboStateOfIllness.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboStateOfIllness.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboStateOfIllness.ForeColor = System.Drawing.Color.Black;
            this.m_cboStateOfIllness.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboStateOfIllness.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboStateOfIllness.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboStateOfIllness.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboStateOfIllness.Location = new System.Drawing.Point(380, 8);
            this.m_cboStateOfIllness.m_BlnEnableItemEventMenu = true;
            this.m_cboStateOfIllness.Name = "m_cboStateOfIllness";
            this.m_cboStateOfIllness.SelectedIndex = -1;
            this.m_cboStateOfIllness.SelectedItem = null;
            this.m_cboStateOfIllness.SelectionStart = 0;
            this.m_cboStateOfIllness.Size = new System.Drawing.Size(400, 23);
            this.m_cboStateOfIllness.TabIndex = 0;
            this.m_cboStateOfIllness.TabStop = false;
            this.m_cboStateOfIllness.TextBackColor = System.Drawing.Color.White;
            this.m_cboStateOfIllness.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lblPatient
            // 
            this.m_lblPatient.AutoSize = true;
            this.m_lblPatient.Location = new System.Drawing.Point(92, 12);
            this.m_lblPatient.Name = "m_lblPatient";
            this.m_lblPatient.Size = new System.Drawing.Size(0, 14);
            this.m_lblPatient.TabIndex = 22;
            // 
            // m_txtLeadSign
            // 
            this.m_txtLeadSign.Location = new System.Drawing.Point(488, 454);
            this.m_txtLeadSign.Name = "m_txtLeadSign";
            this.m_txtLeadSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtLeadSign.TabIndex = 6;
            // 
            // m_txtRelationSign
            // 
            this.m_txtRelationSign.Location = new System.Drawing.Point(84, 454);
            this.m_txtRelationSign.Name = "m_txtRelationSign";
            this.m_txtRelationSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtRelationSign.TabIndex = 4;
            // 
            // m_dtpDoctorSignDate
            // 
            this.m_dtpDoctorSignDate.Location = new System.Drawing.Point(236, 482);
            this.m_dtpDoctorSignDate.Name = "m_dtpDoctorSignDate";
            this.m_dtpDoctorSignDate.Size = new System.Drawing.Size(132, 23);
            this.m_dtpDoctorSignDate.TabIndex = 9;
            // 
            // m_dtpLeadSignDate
            // 
            this.m_dtpLeadSignDate.Location = new System.Drawing.Point(644, 454);
            this.m_dtpLeadSignDate.Name = "m_dtpLeadSignDate";
            this.m_dtpLeadSignDate.Size = new System.Drawing.Size(132, 23);
            this.m_dtpLeadSignDate.TabIndex = 7;
            // 
            // m_dtpDirectorSignDate
            // 
            this.m_dtpDirectorSignDate.Location = new System.Drawing.Point(644, 482);
            this.m_dtpDirectorSignDate.Name = "m_dtpDirectorSignDate";
            this.m_dtpDirectorSignDate.Size = new System.Drawing.Size(132, 23);
            this.m_dtpDirectorSignDate.TabIndex = 11;
            // 
            // m_dtpRelationSignDate
            // 
            this.m_dtpRelationSignDate.Location = new System.Drawing.Point(236, 454);
            this.m_dtpRelationSignDate.Name = "m_dtpRelationSignDate";
            this.m_dtpRelationSignDate.Size = new System.Drawing.Size(132, 23);
            this.m_dtpRelationSignDate.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(196, 458);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "时间：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 486);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "时间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(604, 458);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 11;
            this.label12.Text = "时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(604, 486);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "时间：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 9;
            this.label10.Text = "家属签名：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 458);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "单位领导签名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "手术（麻醉，介入治疗）中可能出现的意外及并发症有：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(760, 48);
            this.label5.TabIndex = 4;
            this.label5.Text = "等不利因素，大大的增加了本次手术（麻醉，介入治疗）的危险性，我们将充分做好各项准备工作，另外，即使患者不存在上述不利因素，手术（麻醉，介入治疗）的风险仍不能完全避" +
                "免，可能出现意外及并发症附后，如家属及单位领导对此表示理解并同意进行本次手术（麻醉，介入治疗),请签字。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "由于患者术前存在";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "根据病情（手术）的需要，拟于近期（急诊）实施";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "经我院医生全面认真检查，诊断为";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "患者";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(10, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 527);
            this.groupBox1.TabIndex = 10000005;
            this.groupBox1.TabStop = false;
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.BackColor = System.Drawing.Color.White;
            this.m_trvCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvCreateDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvCreateDate.HideSelection = false;
            this.m_trvCreateDate.ItemHeight = 18;
            this.m_trvCreateDate.Location = new System.Drawing.Point(12, 38);
            this.m_trvCreateDate.Name = "m_trvCreateDate";
            this.m_trvCreateDate.Size = new System.Drawing.Size(196, 56);
            this.m_trvCreateDate.TabIndex = 10000006;
            this.m_trvCreateDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvCreateDate_AfterSelect);
            // 
            // frmOpraAnaSignAgree
            // 
            this.ClientSize = new System.Drawing.Size(832, 665);
            this.Controls.Add(this.m_trvCreateDate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpraAnaSignAgree";
            this.Text = "手术(麻醉，介入治疗)前签字同意书";
            this.Load += new System.EventHandler(this.frmOpraAnaSignAgree_Load);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		
	

		//		private void m_txtPatientName_TextChanged(object sender, System.EventArgs e)
		//		{
		//			if (m_txtPatientName.Text.Trim().Length!=0)
		//				m_lblPatient.Text=m_txtPatientName.Text;
		//			else
		//				m_lblPatient.Text=string.Empty;
		//		}
		#endregion

		
		public override int m_IntFormID
		{
			get
			{
				return 77;
			}
		}

		#region  覆盖父类方法
		/// <summary>
		/// 设置病人的基本住院信息（覆盖实现新的信息）此方法已废弃
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
		{
            m_clearData();
			//如果当前病人为空则置空
			if(p_objSelectedPatient.m_ObjPeopleInfo == null)
			{
				m_mthShowNoPatient();
				m_trvCreateDate.SelectedNode=m_trnRoot;
				return;
			}
		
			//			m_objBaseCurrentPatient = p_objSelectedPatient;
			//这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
			m_blnCanTextChanged = false;
			
			m_mthSetDefaultValue(p_objSelectedPatient);
			if(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
			{			
				//				m_cboDept.ClearItem();
				//				m_cboArea.ClearItem();
				//				m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
				//				m_cboDept.SelectedIndex=0;
				//				//m_cboArea_DropDown(null,null);
				//				clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.		      
				//				m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
				//				m_cboArea.AddItem(objInPatientArea);
				//				m_cboArea.SelectedIndex=0;
				//				m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;				
				//使用新表 modified by tfzhang at 2005年10月17日 17:09:12
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
					clsInPatientArea objInPatientArea =new clsInPatientArea(str3,str4,objAreNew.m_strDEPTID_CHR);
					//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
					objInPatientArea.m_strAreaNewID=objAreNew.m_strDEPTID_CHR;
					m_cboArea.AddItem(objInPatientArea);
					m_cboArea.SelectedIndex=0;
				}
							
				
				m_txtBedNO.Text =p_objSelectedPatient.m_strBedCode;
			}
			else
			{				
				m_txtBedNO.Text = "";
			}
			//病人的基本信息
			txtInPatientID.Text = p_objSelectedPatient.m_StrHISInPatientID;
			m_txtPatientName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			m_lblPatient.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex;
			lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge;
			m_blnCanTextChanged = true;
			objCurrentPatient=p_objSelectedPatient;		

		}


		/// <summary>
		/// 清空病人基本住院信息的界面（覆盖实现新的方法）
		/// </summary>
		protected override void m_mthClearPatientBaseInfo()
		{
			m_blnCanTextChanged = false;

			txtInPatientID.Text = "";
			m_txtPatientName.Text = "";
			lblSex.Text = "";
			lblAge.Text = "";
			m_cboArea.Text = "";
			m_txtBedNO.Text = "";

			m_objBaseCurrentPatient = null;

			//			m_blnPatientSelected = false;
			m_trnRoot.Nodes.Clear();

			m_blnCanTextChanged = true;
			m_clearData();
			
		}
		/// <summary>
		/// 清空非公用数据
		/// </summary>
		private void m_clearData()
		{
			//继承类新的清空设置
			m_lblPatient.Text="";
			m_cboAction.Text="";
			m_cboStateOfIllness.Text="";
			m_txtBadFactor.Text="";
			m_txtSyndrome.Text="";
			m_txtRelationSign.Text="";
			m_dtpRelationSignDate.Value=DateTime.Now;
			m_txtLeadSign.Text="";
			m_dtpLeadSignDate.Value=DateTime.Now;
			m_txtDoctorSign.Text="";
            m_txtDoctorSign.Tag = null;
			m_dtpDoctorSignDate.Value=DateTime.Now;
			m_txtDirectorSign.Text="";
            m_txtDirectorSign.Tag = null;
			m_dtpDirectorSignDate.Value=DateTime.Now;
			m_strCurrentOpenDate =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
		/// <summary>
		/// 标识当前记录是否新增或修改 true 新增 false修改
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				if(m_trvCreateDate.SelectedNode==m_trnRoot)
					return true;
				else 
					return false;
			}
		}

		#endregion

		#region 接口函数
		public void Delete()
		{
			long m_lngRes=this.m_lngDelete();
		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Print()
		{
			m_lngPrint();
		}

		public   void Save()
		{
			long m_lngRe=this.m_lngSave();
            if (m_lngRe > 0)
            {
                clsPublicFunction.ShowInformationMessageBox("保存成功!");
                if (this.m_trvCreateDate.SelectedNode != null)
                {
                    this.m_trvCreateDate_AfterSelect(this.m_trvCreateDate, new System.Windows.Forms.TreeViewEventArgs(this.m_trvCreateDate.SelectedNode));
                }
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("保存失败!");
            }
		}

		public void Copy()
		{
			//			m_lngCopy();
		}

		public void Cut()
		{
			//			m_lngCut();
		}

		public void Paste()
		{
			//			m_lngPaste();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Redo()
		{
		
		}

		public void Undo()
		{
		
		}	
		#endregion

		#region 实现添加、修改、删除、打印操作

		/// <summary>
		/// 添加记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			if(objCurrentPatient == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择病人");
				return -5;
			}
			long lngRes;
			
			clsOpraAnaSignAgree objMainInfo = new clsOpraAnaSignAgree();
			objMainInfo.m_strInpatientID = objCurrentPatient.m_StrInPatientID;
			objMainInfo.m_dtInpatientDate =objCurrentPatient.m_DtmSelectedInDate;
			objMainInfo.m_dtOpenDate=DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			objMainInfo.m_dtCreateDate =DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			objMainInfo.m_strCreateUserID= m_objCurrentContext.m_ObjEmployee.m_StrEmployeeID;
			objMainInfo.m_strStatus="0";
			objMainInfo.m_strStateOfIllness=m_cboStateOfIllness.Text.Trim();
			objMainInfo.m_strAction=m_cboAction.Text.Trim();
			objMainInfo.m_strBadFactor=m_txtBadFactor.Text.Trim();
			objMainInfo.m_strSyndrome=m_txtSyndrome.Text.Trim();
			objMainInfo.m_strRelationSign=m_txtRelationSign.Text;
			objMainInfo.m_dtRelationSignDate=m_txtRelationSign.Text.Length==0? DateTime.Now: m_dtpRelationSignDate.Value;
			objMainInfo.m_strLeadsign=m_txtLeadSign.Text;
			objMainInfo.m_dtLeadSignDate=m_txtLeadSign.Text.Length==0?DateTime.Now:m_dtpLeadSignDate.Value;

            if (m_txtDoctorSign.Tag != null)
            {
                objMainInfo.m_strDoctorSign = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
            }
			objMainInfo.m_strDoctorSignDate=m_txtDoctorSign.Text.Length==0?DateTime.Now:m_dtpDoctorSignDate.Value;

            if (m_txtDirectorSign.Tag != null)
            {
                objMainInfo.m_strDirectorSign = ((clsEmrEmployeeBase_VO)m_txtDirectorSign.Tag).m_strEMPNO_CHR.Trim();
            }
			objMainInfo.m_dtDirectorSignDate=m_txtDirectorSign.Text.Length==0?DateTime.Now:m_dtpDirectorSignDate.Value;

            clsOperationAgreedRecordServ m_objoperation =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            //m_objoperation=new clsOperationAgreedRecordServ();

			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objMainInfo.m_strInpatientID.Trim() + "-" + objMainInfo.m_dtInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objMainInfo, objSign_VO) == -1)
                return -1;


			lngRes = m_objoperation.m_lngAddItemRecord(objMainInfo);
			if(lngRes > 0)
			{
				m_mthAddNode(objMainInfo.m_dtCreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
				m_trnRoot.Expand();	
			}
			return lngRes;
		}
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubModify()
		{
			if(objCurrentPatient == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择病人");
				return -5;
			}
			long lngRes;
			clsOpraAnaSignAgree objMainInfo = new clsOpraAnaSignAgree();
			objMainInfo.m_strInpatientID = objCurrentPatient.m_StrInPatientID;
			objMainInfo.m_dtInpatientDate =objCurrentPatient.m_DtmSelectedInDate;
			objMainInfo.m_dtOpenDate=DateTime.Now;
			objMainInfo.m_dtCreateDate =DateTime.Parse(m_trvCreateDate.SelectedNode.Text);
			objMainInfo.m_dtModifyDate=DateTime.Now;
			objMainInfo.m_strModifyUserID=m_objCurrentContext.m_ObjEmployee.m_StrEmployeeID;;
			objMainInfo.m_strCreateUserID= m_objCurrentContext.m_ObjEmployee.m_StrEmployeeID;
			objMainInfo.m_strStatus="0";
			objMainInfo.m_strStateOfIllness=m_cboStateOfIllness.Text;
			objMainInfo.m_strAction=m_cboAction.Text;
			objMainInfo.m_strBadFactor=m_txtBadFactor.Text;
			objMainInfo.m_strSyndrome=m_txtSyndrome.Text;
			objMainInfo.m_strRelationSign=m_txtRelationSign.Text;
			objMainInfo.m_dtRelationSignDate=m_txtRelationSign.Text.Length==0? DateTime.Now: m_dtpRelationSignDate.Value;
			objMainInfo.m_strLeadsign=m_txtLeadSign.Text;
			objMainInfo.m_dtLeadSignDate=m_txtLeadSign.Text.Length==0?DateTime.Now:m_dtpLeadSignDate.Value;

            if (m_txtDoctorSign.Tag != null)
            {
                objMainInfo.m_strDoctorSign = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
            }
			objMainInfo.m_strDoctorSignDate=m_txtDoctorSign.Text.Length==0?DateTime.Now:m_dtpDoctorSignDate.Value;

            if (m_txtDirectorSign.Tag != null)
            {
                objMainInfo.m_strDirectorSign = ((clsEmrEmployeeBase_VO)m_txtDirectorSign.Tag).m_strEMPNO_CHR.Trim();
            }
			objMainInfo.m_dtDirectorSignDate=m_txtDirectorSign.Text.Length==0?DateTime.Now:m_dtpDirectorSignDate.Value;

            //m_objoperation=new clsOperationAgreedRecordServ();

            clsOperationAgreedRecordServ m_objoperation =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objMainInfo.m_strInpatientID.Trim() + "-" + objMainInfo.m_dtInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objMainInfo, objSign_VO) == -1)
                return -1;

			lngRes = m_objoperation.m_lngUpateItemRecord(objMainInfo);
			return lngRes;
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			if(objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择病人");
				return -5;
			}
			DateTime m_dtTemp=DateTime.Parse(m_trvCreateDate.SelectedNode.Text);
			long lngRes;
            //m_objoperation=new clsOperationAgreedRecordServ();

            clsOperationAgreedRecordServ m_objoperation =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_StrRecorder_ID, clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;

			lngRes = m_objoperation.m_lngDeleteItemRecord(objCurrentPatient.m_StrInPatientID,MDIParent.strOperatorID.Trim(),m_dtTemp);
			//成功删除，更新日期列表
			if(lngRes > 0)
			{
				//				m_mthRemoveNode(m_dtTemp.ToString("yyyy-MM-dd HH:mm:ss"));
				m_trvCreateDate.Nodes.Remove(m_trvCreateDate.SelectedNode);
				m_trnRoot.Expand();	
			}
			return lngRes;		}
		
		/// <summary>
		/// 成功保存后更新创建日期列表
		/// </summary>
		/// <param name="strTime"></param>
		private void m_mthAddNode(string strTime)
		{ 
			if(strTime=="" ||strTime==null) return ;
			TreeNode trnNode=new TreeNode(strTime);	
			trnNode.Tag=strTime;
			if(m_trnRoot.Nodes.Count==0 || trnNode.Text.CompareTo (m_trnRoot.LastNode.Text)<0)
			{
				m_trnRoot.Nodes.Add(trnNode);
				m_trvCreateDate.SelectedNode=m_trnRoot.LastNode;//Jacky-2003-4-28
			}
			else 
			{
				for(int i=0;i<m_trnRoot.Nodes.Count;i++)
				{
					if(trnNode.Text.CompareTo (m_trnRoot.Nodes[i].Text)>0)
					{
						m_trnRoot.Nodes.Insert(i,trnNode);
						m_trvCreateDate.SelectedNode=m_trnRoot.Nodes[i];//
						break;
					}
				}
			}			
		}
		/// <summary>
		/// 成功删除后更新创建日期列表
		/// </summary>
		/// <param name="strTime"></param>
		private void m_mthRemoveNode(string strTime)
		{ 
			if(strTime=="" ||strTime==null) return ;
			TreeNode trnNode=new TreeNode(strTime);			
			
			for(int i=0;i<m_trnRoot.Nodes.Count;i++)
			{
				if(trnNode.Text.CompareTo (m_trnRoot.Nodes[i].Text)==0)
				{
					m_trnRoot.Nodes.Remove(trnNode);		
					//						if(m_trnRoot.Nodes.Count==0 )
					//						{
					m_trvCreateDate.SelectedNode=m_trnRoot;
					//						}
					//						else 
					//						{
					//							m_trvCreateDate.SelectedNode=m_trnRoot.LastNode;
					//						}
					break;
				}
			}
						
		}
		/// <summary>
		/// 设置TeeeView默认选择的节点
		/// </summary>
		private  void m_mthSetNodeSelected()
		{
			if(m_trnRoot.Nodes.Count == 0)
				m_trvCreateDate.SelectedNode = m_trnRoot;
			else
				m_trvCreateDate.SelectedNode = m_trnRoot.Nodes[0];
		}
		/// <summary>
		/// 改变日期列表项的处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_trvCreateDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            m_clearData();

			if(m_blnCanTreeNodeAfterSelectEventTakePlace==false)
				return;

			m_mthRecordChangedToSave();

			if(m_trvCreateDate.SelectedNode==m_trnRoot)
			{
				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
		
				//				return;
			}
			else if(m_trvCreateDate.SelectedNode.Tag !=null)
			{
				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
				clsOpraAnaSignAgree m_tempGetData = new clsOpraAnaSignAgree();
				DateTime dtTemp =DateTime.Parse(m_trvCreateDate.SelectedNode.Text);

                clsOperationAgreedRecordServ m_objOperationGet =
                    (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

				long lngRes = m_objOperationGet.m_lngGetItemRecord(objCurrentPatient.m_StrInPatientID,dtTemp, out m_tempGetData);
				if(lngRes > 0 && m_tempGetData != null)
				{
					m_mthSetGUIContent(m_tempGetData);
				}
			}

			m_mthAddFormStatusForClosingSave();

		}
		private void m_mthSetGUIContent(clsOpraAnaSignAgree p_objtempGetData)
		{
			if(p_objtempGetData == null)  return;
			m_strCurrentOpenDate =p_objtempGetData.m_dtOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
			//赋值
			m_lblPatient.Text=objCurrentPatient.m_StrName;
			m_cboAction.Text=p_objtempGetData.m_strAction;
			m_cboStateOfIllness.Text=p_objtempGetData.m_strStateOfIllness;
			m_txtBadFactor.Text=p_objtempGetData.m_strBadFactor;
			m_txtSyndrome.Text=p_objtempGetData.m_strSyndrome;
			m_txtRelationSign.Text=p_objtempGetData.m_strRelationSign;
			m_dtpRelationSignDate.Value=p_objtempGetData.m_dtRelationSignDate;
			m_txtLeadSign.Text=p_objtempGetData.m_strLeadsign;
			m_dtpLeadSignDate.Value=p_objtempGetData.m_dtLeadSignDate;

            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(p_objtempGetData.m_strDoctorSign, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
            }

			m_dtpDoctorSignDate.Value=p_objtempGetData.m_strDoctorSignDate;

            objEmployeeSign.m_lngGetEmpByNO(p_objtempGetData.m_strDirectorSign, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDirectorSign.Tag = objEmpVO;
                m_txtDirectorSign.Text = objEmpVO.m_strLASTNAME_VCHR;
            }

			m_dtpDirectorSignDate.Value=p_objtempGetData.m_dtDirectorSignDate;
		}

	 
		#endregion
		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}			
		
			
			clsOpraAnaSignAgree m_tempGetData = new clsOpraAnaSignAgree();

            clsOperationAgreedRecordServ m_objOperationGet =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

			long lngRes = m_objOperationGet.m_lngGetItemRecord(objCurrentPatient.m_StrInPatientID,p_dtmRecordDate, out m_tempGetData);
			if(lngRes > 0 && m_tempGetData != null)
			{
				m_mthSetGUIContent(m_tempGetData);
			}	
				
		}
		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			//			clsEmployeeSignTool.s_mthSetDefaulEmployee(m_txtSign);
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();
		}

		//		/// <summary>
		//		/// 数据复用
		//		/// </summary>
		//		/// <param name="p_objSelectedPatient"></param>
		//		protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
		//		{
		//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString());
		//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
		//			{
		//				this.m_cboStateOfIllness.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
		////				this.m_txtOutHospitalDiagnose.Text = objInPatientCaseDefaultValue[0].m_strFinallyDiagnose!= "" ? objInPatientCaseDefaultValue[0].m_strFinallyDiagnose : objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
		//			}
		//		}
       
	 
		#region 外部打印.	
				
		//System.Drawing.Printing.PrintDocument m_pdcPrintDocument;

		/// <summary>
		/// 打印记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		{				
			m_mthDemoPrint_FromDataSource();				
			return 1;
			
		}

		private void m_mthfrmLoad()
		{	
			if(m_pdtPrintDocument==null)
				this.m_pdtPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_pdtPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPrintDocument_BeginPrint);
			this.m_pdtPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPrintDocument_EndPrint);
			this.m_pdtPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdtPrintDocument_PrintPage);		
		}
		private void m_pdtPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);
		}
		
		private void m_pdtPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}
		
		private void m_pdtPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}
		
		private bool m_blnHasInitPrintTool=false;
		//定义打印实例
		clsOperationAgreedRecordPrintTool objPrintTool;

		private void m_mthDemoPrint_FromDataSource()
		{	
			if(m_blnHasInitPrintTool==false)
			{
				objPrintTool=new clsOperationAgreedRecordPrintTool();
				objPrintTool.m_mthInitPrintTool(null);	
				m_blnHasInitPrintTool=true;
			}
            if (objCurrentPatient == null || m_trvCreateDate.SelectedNode == m_trnRoot)
				objPrintTool.m_mthSetPrintInfo(objCurrentPatient,DateTime.MinValue,DateTime.MinValue);
			else //if(this.m_lblInHospitalDate.Text.Trim() !="")
			{
				//				if(this.m_trvCreateDate.SelectedNode==null||this.m_trvCreateDate.SelectedNode.Tag ==null)
				//					objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_DtmLastInDate,DateTime.MinValue);
				//				else 
				objPrintTool.m_mthSetPrintInfo(objCurrentPatient,objCurrentPatient.m_DtmSelectedInDate,DateTime.Parse(this.m_trvCreateDate.SelectedNode.Text.ToString()));
			}
			objPrintTool.m_mthInitPrintContent();						
						
			m_mthStartPrint_this();
		}
				
		private void m_mthStartPrint_this()
		{			
			if(m_blnDirectPrint)
			{
				m_pdtPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdtPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

	
		#endregion 外部打印.


		private void frmOpraAnaSignAgree_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			m_mthfrmLoad();
		}
		#region 审核
		private string m_strCurrentOpenDate = "";
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

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtDoctorSign.Tag != null)
					return ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
				return "";
			}
		}

		#endregion 属性

        /// <summary>
        /// 显示记录时间列表
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_dtmInDate">入院时间</param>
        private void m_mthLoadRecordDateList(string p_strInPatientID, DateTime p_dtmInDate)
        {
            //获取病人记录列表
            string[] strCreateTimeListArr;
            string[] strOpenTimeListArr;

            clsOperationAgreedRecordServ m_objOperationGet =
                (clsOperationAgreedRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationAgreedRecordServ));

            long lngRes = m_objOperationGet.m_lngGetRecordTimeList(p_strInPatientID, p_dtmInDate, out strCreateTimeListArr, out strOpenTimeListArr);
            if (lngRes <= 0 || strCreateTimeListArr == null || strOpenTimeListArr == null || strOpenTimeListArr.Length != strCreateTimeListArr.Length)
            {
                m_trnRoot.Nodes.Clear();
                m_trvCreateDate.SelectedNode = m_trnRoot;
                //m_mthSetNodeSelected();
                return;
            }


            //清空时间列表树
            m_trnRoot.Nodes.Clear();
            //添加查询到的时间到时间树上 
            for (int i = strCreateTimeListArr.Length - 1; i >= 0; i--)
            {
                TreeNode trnRecordDate = new TreeNode(strCreateTimeListArr[i]);
                trnRecordDate.Tag = strOpenTimeListArr[i];
                m_trnRoot.Nodes.Add(trnRecordDate);
            }

            //对时间节点进行倒序排序
            new clsSortTool().m_mthSortTreeNode(m_trnRoot, true);

            //设置TeeeView默认选择的节点
            m_mthSetNodeSelected();

            //展开树显示所有时间节点。
            m_trnRoot.Expand();
        }

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            m_clearData();
            
            if (p_objSelectedSession == null)
            {
                return;
            }

            m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objBaseCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objBaseCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            objCurrentPatient = m_objBaseCurrentPatient;	
            m_mthLoadRecordDateList(p_objSelectedSession.m_strEMRInpatientId, p_objSelectedSession.m_dtmEMRInpatientDate);
        }
	}
}
