using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	public class frmQCRecord : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Define
		private System.Windows.Forms.Label lblOtherRecord;
		private System.Windows.Forms.Label lblCure;
		private System.Windows.Forms.Label lblDiagnose;
		private System.Windows.Forms.Label lblCheck;
		private System.Windows.Forms.Label lblCaseHistory;
		private System.Windows.Forms.Label txtLitigant;
		private System.Windows.Forms.Label lblReasonRrecord;
		private System.Windows.Forms.Label lblFactRecord;
		private System.Windows.Forms.Label lblStandardRecored;
		private System.Windows.Forms.Label lblItem;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonNurse;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonOther;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonState;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonCure;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonDiagnose;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonCheck;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonHistory;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonLitigant;
		private System.Windows.Forms.Label lblDesc2;
		private System.Windows.Forms.Label lblDesc12;
		private System.Windows.Forms.Label lblDesc11;
		private System.Windows.Forms.Label lblStandardCure;
		private System.Windows.Forms.Label lblStandardHistory;
		private System.Windows.Forms.Label lblStandardLitigant;
		private System.Windows.Forms.Label lblStandardOther;
		private System.Windows.Forms.Label lblStandardDiagnose;
		private System.Windows.Forms.Label lblStandardState;
		private System.Windows.Forms.Label lblStandardCheck;
		private System.Windows.Forms.Label lblStandardNurse;
		private System.Windows.Forms.NumericUpDown m_nmuFactLitigant;
		private System.Windows.Forms.NumericUpDown m_nmuFactHistory;
		private System.Windows.Forms.NumericUpDown m_nmuFactCheck;
		private System.Windows.Forms.NumericUpDown m_nmuFactDiagnose;
		private System.Windows.Forms.NumericUpDown m_nmuFactCure;
		private System.Windows.Forms.NumericUpDown m_nmuFactState;
		private System.Windows.Forms.NumericUpDown m_nmuFactOther;
		private System.Windows.Forms.NumericUpDown m_nmuFactNurse;
		private System.Windows.Forms.Label lblNurse;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonDoctorAdvice;
		private System.Windows.Forms.Label lblDoctorAdvice;
		private System.Windows.Forms.Label lblStateillness;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReasonFirstTidy;
		private System.Windows.Forms.Label lblFirstPageTidy;
		private System.Windows.Forms.Label lblStandardFirstTidy;
		private System.Windows.Forms.Label lblStandardDoctorAdvice;
		private System.Windows.Forms.NumericUpDown m_nmuFactFirstTidy;
		private System.Windows.Forms.NumericUpDown m_nmuFactDoctorAdvice;
        private TextBox m_txtFileChecker;
        private TextBox m_txtWriteDoctor;
        private TextBox m_txtCheckDoctor;
		private System.Windows.Forms.Label m_lblTotalValue;
		private System.Windows.Forms.Label lblTotalValue;
		private System.Windows.Forms.TreeView m_trvInPatientDate;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactFirstTidy;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactLitigant;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactHistory;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactCheck;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactDiagnose;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactCure;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactState;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactOther;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactDoctorAdvice;
        private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtFactNurse;
		private System.ComponentModel.IContainer components = null;
		private PinkieControls.ButtonXP m_cmdFileChecker;
		private PinkieControls.ButtonXP m_cmdCheckDoctor;
		#endregion 

		private PinkieControls.ButtonXP m_cmdEmployeeSign;
		private PinkieControls.ButtonXP m_cmdWriteDoctor;
		private System.Windows.Forms.GroupBox groupBox1;

        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private TextBox m_txtEmployeeSign;
        private clsEmrSignToolCollection m_objSign;

		public frmQCRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(
            //    new Control[]{				
            //    m_trvInPatientDate
            //                 });

			m_objQCRecordDomain = new clsQCRecordDomain();

			m_trnRoot = new TreeNode("入院日期");
			m_trvInPatientDate.Nodes.Add(m_trnRoot);

			m_blnCanValueChanged = true;

			m_bytListOnDoctor = 0;		

			m_blnWriteDoctorCanGotFocus = true;
			m_blnCheckDoctorCanGotFocus = true;
			m_blnFileCheckerCanGotFocus = true;

			m_blnCanDoctorTextChanged = true;

			m_lblForTitle.Text = "病 案 质 量 评 分 表";

			m_dtsRept = m_dtsInitQCRecordDataSet();

//			m_rpdQCRecord = new ReportDocument();
//			m_rpdQCRecord.Load(m_strTemplatePath+"cryQCRecord.rpt");

			//签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdWriteDoctor, m_txtWriteDoctor, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdCheckDoctor, m_txtCheckDoctor, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdFileChecker, m_txtFileChecker, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, m_txtEmployeeSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		public override int m_IntFormID
		{
			get
			{
				return 29;
			}
		}

		/// <summary>
		/// 边框颜色工具
		/// </summary>
        //private clsBorderTool m_objBorderTool;

		/// <summary>
		/// QCRecord的领域层
		/// </summary>
		private clsQCRecordDomain m_objQCRecordDomain;

		/// <summary>
		/// 入院日期的树结点
		/// </summary>
		private TreeNode m_trnRoot;

		/// <summary>
		/// 是否处理评分值的ValueChanged事件
		/// </summary>
		private bool m_blnCanValueChanged;

		/// <summary>
		/// 是哪一个医生的输入选择（0，书写医生；1，医疗文件检查者；2，护理文件检查者）
		/// </summary>
		private byte m_bytListOnDoctor;

		/// <summary>
		/// 是否处理医生的TextChanged事件
		/// </summary>
		private bool m_blnCanDoctorTextChanged;

		/// <summary>
		/// 是否全选书写医生的输入内容
		/// </summary>
		private bool m_blnWriteDoctorCanGotFocus;

		/// <summary>
		/// 是否全选医疗文件检查者的输入内容
		/// </summary>
		private bool m_blnCheckDoctorCanGotFocus;

		/// <summary>
		/// 是否全选护理文件检查者的输入内容
		/// </summary>
		private bool m_blnFileCheckerCanGotFocus;

		/// <summary>
		/// 出报表的DataSet
		/// </summary>
		private DataSet m_dtsRept;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdQCRecord;

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
		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtEmployeeSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)m_txtEmployeeSign.Tag).m_strEMPNO_CHR;
				return "";
			}
		}
		#endregion 属性
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblDesc2 = new System.Windows.Forms.Label();
            this.lblDesc12 = new System.Windows.Forms.Label();
            this.lblDesc11 = new System.Windows.Forms.Label();
            this.m_txtReasonNurse = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblNurse = new System.Windows.Forms.Label();
            this.m_txtReasonDoctorAdvice = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblDoctorAdvice = new System.Windows.Forms.Label();
            this.m_txtReasonOther = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblOtherRecord = new System.Windows.Forms.Label();
            this.m_txtReasonState = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblStateillness = new System.Windows.Forms.Label();
            this.m_txtReasonCure = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblCure = new System.Windows.Forms.Label();
            this.m_txtReasonDiagnose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblDiagnose = new System.Windows.Forms.Label();
            this.m_txtReasonCheck = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblCheck = new System.Windows.Forms.Label();
            this.m_txtReasonHistory = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblCaseHistory = new System.Windows.Forms.Label();
            this.m_txtReasonLitigant = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtLitigant = new System.Windows.Forms.Label();
            this.m_txtReasonFirstTidy = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblFirstPageTidy = new System.Windows.Forms.Label();
            this.lblReasonRrecord = new System.Windows.Forms.Label();
            this.lblFactRecord = new System.Windows.Forms.Label();
            this.lblStandardRecored = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.m_txtFileChecker = new System.Windows.Forms.TextBox();
            this.m_txtWriteDoctor = new System.Windows.Forms.TextBox();
            this.m_txtCheckDoctor = new System.Windows.Forms.TextBox();
            this.lblStandardCure = new System.Windows.Forms.Label();
            this.lblStandardHistory = new System.Windows.Forms.Label();
            this.lblStandardFirstTidy = new System.Windows.Forms.Label();
            this.lblStandardLitigant = new System.Windows.Forms.Label();
            this.lblStandardOther = new System.Windows.Forms.Label();
            this.lblStandardDiagnose = new System.Windows.Forms.Label();
            this.lblStandardState = new System.Windows.Forms.Label();
            this.lblStandardCheck = new System.Windows.Forms.Label();
            this.lblStandardDoctorAdvice = new System.Windows.Forms.Label();
            this.lblStandardNurse = new System.Windows.Forms.Label();
            this.m_nmuFactFirstTidy = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactLitigant = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactHistory = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactCheck = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactDiagnose = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactCure = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactDoctorAdvice = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactState = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactOther = new System.Windows.Forms.NumericUpDown();
            this.m_nmuFactNurse = new System.Windows.Forms.NumericUpDown();
            this.m_lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.m_trvInPatientDate = new System.Windows.Forms.TreeView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_txtFactFirstTidy = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactLitigant = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactHistory = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactCheck = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactDiagnose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactCure = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactState = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactOther = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactDoctorAdvice = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtFactNurse = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cmdFileChecker = new PinkieControls.ButtonXP();
            this.m_cmdCheckDoctor = new PinkieControls.ButtonXP();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_cmdWriteDoctor = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtEmployeeSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactFirstTidy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactLitigant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactDiagnose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactCure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactDoctorAdvice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactNurse)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(647, 520);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(731, 520);
            this.lblAge.Size = new System.Drawing.Size(40, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(343, 520);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(343, 548);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(479, 520);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(599, 520);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(683, 520);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(179, 548);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(223, 557);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(72, 104);
            this.m_lsvInPatientID.TabIndex = 2;
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(399, 544);
            this.txtInPatientID.Size = new System.Drawing.Size(72, 23);
            this.txtInPatientID.TabIndex = 3;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(523, 516);
            this.m_txtPatientName.Size = new System.Drawing.Size(72, 23);
            this.m_txtPatientName.TabIndex = 2;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(399, 516);
            this.m_txtBedNO.Size = new System.Drawing.Size(48, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(223, 544);
            this.m_cboArea.Size = new System.Drawing.Size(112, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(309, 540);
            this.m_lsvPatientName.Size = new System.Drawing.Size(72, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, 540);
            this.m_lsvBedNO.Size = new System.Drawing.Size(48, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(223, 516);
            this.m_cboDept.Size = new System.Drawing.Size(112, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(179, 520);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(11, 70);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 24);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdNext.Location = new System.Drawing.Point(447, 516);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPre.Location = new System.Drawing.Point(299, 516);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(520, 44);
            this.m_lblForTitle.Size = new System.Drawing.Size(8, 4);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(339, 40);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(491, 35);
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
            // lblDesc2
            // 
            this.lblDesc2.AutoSize = true;
            this.lblDesc2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesc2.Location = new System.Drawing.Point(80, 492);
            this.lblDesc2.Name = "lblDesc2";
            this.lblDesc2.Size = new System.Drawing.Size(280, 14);
            this.lblDesc2.TabIndex = 553;
            this.lblDesc2.Text = "2、评分细则参考广东省病案质量评定标准。";
            // 
            // lblDesc12
            // 
            this.lblDesc12.AutoSize = true;
            this.lblDesc12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesc12.Location = new System.Drawing.Point(104, 468);
            this.lblDesc12.Name = "lblDesc12";
            this.lblDesc12.Size = new System.Drawing.Size(343, 14);
            this.lblDesc12.TabIndex = 552;
            this.lblDesc12.Text = "术前讨论、术前麻醉查房记录、死亡记录、死亡讨论。";
            // 
            // lblDesc11
            // 
            this.lblDesc11.AutoSize = true;
            this.lblDesc11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDesc11.Location = new System.Drawing.Point(28, 444);
            this.lblDesc11.Name = "lblDesc11";
            this.lblDesc11.Size = new System.Drawing.Size(630, 14);
            this.lblDesc11.TabIndex = 551;
            this.lblDesc11.Text = "说明：1、病案质检的重点内容是三级医师查房、院内感染、输血同意书、手术同意书、传染病报告、";
            // 
            // m_txtReasonNurse
            // 
            this.m_txtReasonNurse.AccessibleDescription = "扣分原因";
            this.m_txtReasonNurse.BackColor = System.Drawing.Color.White;
            this.m_txtReasonNurse.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonNurse.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonNurse.Location = new System.Drawing.Point(268, 404);
            this.m_txtReasonNurse.Multiline = true;
            this.m_txtReasonNurse.Name = "m_txtReasonNurse";
            this.m_txtReasonNurse.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonNurse.TabIndex = 1111;
            // 
            // lblNurse
            // 
            this.lblNurse.AutoSize = true;
            this.lblNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNurse.Location = new System.Drawing.Point(24, 404);
            this.lblNurse.Name = "lblNurse";
            this.lblNurse.Size = new System.Drawing.Size(63, 14);
            this.lblNurse.TabIndex = 547;
            this.lblNurse.Text = "护理文件";
            // 
            // m_txtReasonDoctorAdvice
            // 
            this.m_txtReasonDoctorAdvice.AccessibleDescription = "扣分原因";
            this.m_txtReasonDoctorAdvice.BackColor = System.Drawing.Color.White;
            this.m_txtReasonDoctorAdvice.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonDoctorAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonDoctorAdvice.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonDoctorAdvice.Location = new System.Drawing.Point(268, 376);
            this.m_txtReasonDoctorAdvice.Multiline = true;
            this.m_txtReasonDoctorAdvice.Name = "m_txtReasonDoctorAdvice";
            this.m_txtReasonDoctorAdvice.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonDoctorAdvice.TabIndex = 1101;
            // 
            // lblDoctorAdvice
            // 
            this.lblDoctorAdvice.AutoSize = true;
            this.lblDoctorAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoctorAdvice.Location = new System.Drawing.Point(24, 376);
            this.lblDoctorAdvice.Name = "lblDoctorAdvice";
            this.lblDoctorAdvice.Size = new System.Drawing.Size(35, 14);
            this.lblDoctorAdvice.TabIndex = 543;
            this.lblDoctorAdvice.Text = "医嘱";
            // 
            // m_txtReasonOther
            // 
            this.m_txtReasonOther.AccessibleDescription = "扣分原因";
            this.m_txtReasonOther.BackColor = System.Drawing.Color.White;
            this.m_txtReasonOther.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonOther.Location = new System.Drawing.Point(268, 348);
            this.m_txtReasonOther.Multiline = true;
            this.m_txtReasonOther.Name = "m_txtReasonOther";
            this.m_txtReasonOther.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonOther.TabIndex = 1091;
            // 
            // lblOtherRecord
            // 
            this.lblOtherRecord.AutoSize = true;
            this.lblOtherRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherRecord.Location = new System.Drawing.Point(24, 348);
            this.lblOtherRecord.Name = "lblOtherRecord";
            this.lblOtherRecord.Size = new System.Drawing.Size(63, 14);
            this.lblOtherRecord.TabIndex = 539;
            this.lblOtherRecord.Text = "其它记录";
            // 
            // m_txtReasonState
            // 
            this.m_txtReasonState.AccessibleDescription = "扣分原因";
            this.m_txtReasonState.BackColor = System.Drawing.Color.White;
            this.m_txtReasonState.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonState.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonState.Location = new System.Drawing.Point(268, 320);
            this.m_txtReasonState.Multiline = true;
            this.m_txtReasonState.Name = "m_txtReasonState";
            this.m_txtReasonState.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonState.TabIndex = 1081;
            // 
            // lblStateillness
            // 
            this.lblStateillness.AutoSize = true;
            this.lblStateillness.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStateillness.Location = new System.Drawing.Point(24, 320);
            this.lblStateillness.Name = "lblStateillness";
            this.lblStateillness.Size = new System.Drawing.Size(63, 14);
            this.lblStateillness.TabIndex = 535;
            this.lblStateillness.Text = "病情记录";
            // 
            // m_txtReasonCure
            // 
            this.m_txtReasonCure.AccessibleDescription = "扣分原因";
            this.m_txtReasonCure.BackColor = System.Drawing.Color.White;
            this.m_txtReasonCure.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonCure.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonCure.Location = new System.Drawing.Point(268, 292);
            this.m_txtReasonCure.Multiline = true;
            this.m_txtReasonCure.Name = "m_txtReasonCure";
            this.m_txtReasonCure.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonCure.TabIndex = 971;
            // 
            // lblCure
            // 
            this.lblCure.AutoSize = true;
            this.lblCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCure.Location = new System.Drawing.Point(24, 292);
            this.lblCure.Name = "lblCure";
            this.lblCure.Size = new System.Drawing.Size(35, 14);
            this.lblCure.TabIndex = 531;
            this.lblCure.Text = "治疗";
            // 
            // m_txtReasonDiagnose
            // 
            this.m_txtReasonDiagnose.AccessibleDescription = "扣分原因";
            this.m_txtReasonDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtReasonDiagnose.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonDiagnose.Location = new System.Drawing.Point(268, 264);
            this.m_txtReasonDiagnose.Multiline = true;
            this.m_txtReasonDiagnose.Name = "m_txtReasonDiagnose";
            this.m_txtReasonDiagnose.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonDiagnose.TabIndex = 861;
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDiagnose.Location = new System.Drawing.Point(24, 264);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(35, 14);
            this.lblDiagnose.TabIndex = 527;
            this.lblDiagnose.Text = "诊断";
            // 
            // m_txtReasonCheck
            // 
            this.m_txtReasonCheck.AccessibleDescription = "扣分原因";
            this.m_txtReasonCheck.BackColor = System.Drawing.Color.White;
            this.m_txtReasonCheck.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonCheck.Location = new System.Drawing.Point(268, 236);
            this.m_txtReasonCheck.Multiline = true;
            this.m_txtReasonCheck.Name = "m_txtReasonCheck";
            this.m_txtReasonCheck.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonCheck.TabIndex = 751;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheck.Location = new System.Drawing.Point(24, 236);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(35, 14);
            this.lblCheck.TabIndex = 523;
            this.lblCheck.Text = "检查";
            // 
            // m_txtReasonHistory
            // 
            this.m_txtReasonHistory.AccessibleDescription = "扣分原因";
            this.m_txtReasonHistory.BackColor = System.Drawing.Color.White;
            this.m_txtReasonHistory.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonHistory.Location = new System.Drawing.Point(268, 208);
            this.m_txtReasonHistory.Multiline = true;
            this.m_txtReasonHistory.Name = "m_txtReasonHistory";
            this.m_txtReasonHistory.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonHistory.TabIndex = 641;
            // 
            // lblCaseHistory
            // 
            this.lblCaseHistory.AutoSize = true;
            this.lblCaseHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCaseHistory.Location = new System.Drawing.Point(24, 208);
            this.lblCaseHistory.Name = "lblCaseHistory";
            this.lblCaseHistory.Size = new System.Drawing.Size(35, 14);
            this.lblCaseHistory.TabIndex = 519;
            this.lblCaseHistory.Text = "病史";
            // 
            // m_txtReasonLitigant
            // 
            this.m_txtReasonLitigant.AccessibleDescription = "扣分原因";
            this.m_txtReasonLitigant.BackColor = System.Drawing.Color.White;
            this.m_txtReasonLitigant.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonLitigant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonLitigant.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonLitigant.Location = new System.Drawing.Point(268, 180);
            this.m_txtReasonLitigant.Multiline = true;
            this.m_txtReasonLitigant.Name = "m_txtReasonLitigant";
            this.m_txtReasonLitigant.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonLitigant.TabIndex = 531;
            // 
            // txtLitigant
            // 
            this.txtLitigant.AutoSize = true;
            this.txtLitigant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLitigant.Location = new System.Drawing.Point(24, 180);
            this.txtLitigant.Name = "txtLitigant";
            this.txtLitigant.Size = new System.Drawing.Size(35, 14);
            this.txtLitigant.TabIndex = 515;
            this.txtLitigant.Text = "主诉";
            // 
            // m_txtReasonFirstTidy
            // 
            this.m_txtReasonFirstTidy.AccessibleDescription = "扣分原因";
            this.m_txtReasonFirstTidy.BackColor = System.Drawing.Color.White;
            this.m_txtReasonFirstTidy.BorderColor = System.Drawing.Color.White;
            this.m_txtReasonFirstTidy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtReasonFirstTidy.ForeColor = System.Drawing.Color.Black;
            this.m_txtReasonFirstTidy.Location = new System.Drawing.Point(268, 152);
            this.m_txtReasonFirstTidy.Multiline = true;
            this.m_txtReasonFirstTidy.Name = "m_txtReasonFirstTidy";
            this.m_txtReasonFirstTidy.Size = new System.Drawing.Size(500, 21);
            this.m_txtReasonFirstTidy.TabIndex = 421;
            // 
            // lblFirstPageTidy
            // 
            this.lblFirstPageTidy.AutoSize = true;
            this.lblFirstPageTidy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFirstPageTidy.Location = new System.Drawing.Point(24, 152);
            this.lblFirstPageTidy.Name = "lblFirstPageTidy";
            this.lblFirstPageTidy.Size = new System.Drawing.Size(91, 14);
            this.lblFirstPageTidy.TabIndex = 511;
            this.lblFirstPageTidy.Text = "首页楣栏整洁";
            // 
            // lblReasonRrecord
            // 
            this.lblReasonRrecord.AutoSize = true;
            this.lblReasonRrecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReasonRrecord.Location = new System.Drawing.Point(268, 124);
            this.lblReasonRrecord.Name = "lblReasonRrecord";
            this.lblReasonRrecord.Size = new System.Drawing.Size(63, 14);
            this.lblReasonRrecord.TabIndex = 510;
            this.lblReasonRrecord.Text = "扣分原因";
            // 
            // lblFactRecord
            // 
            this.lblFactRecord.AutoSize = true;
            this.lblFactRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFactRecord.Location = new System.Drawing.Point(208, 124);
            this.lblFactRecord.Name = "lblFactRecord";
            this.lblFactRecord.Size = new System.Drawing.Size(49, 14);
            this.lblFactRecord.TabIndex = 509;
            this.lblFactRecord.Text = "实得分";
            // 
            // lblStandardRecored
            // 
            this.lblStandardRecored.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardRecored.Location = new System.Drawing.Point(116, 124);
            this.lblStandardRecored.Name = "lblStandardRecored";
            this.lblStandardRecored.Size = new System.Drawing.Size(55, 19);
            this.lblStandardRecored.TabIndex = 508;
            this.lblStandardRecored.Text = "标准分";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblItem.Location = new System.Drawing.Point(24, 124);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(35, 14);
            this.lblItem.TabIndex = 507;
            this.lblItem.Text = "项目";
            // 
            // m_txtFileChecker
            // 
            this.m_txtFileChecker.AccessibleDescription = "护理文件检查者";
            this.m_txtFileChecker.AccessibleName = "NoDefault";
            this.m_txtFileChecker.BackColor = System.Drawing.Color.White;
            this.m_txtFileChecker.ForeColor = System.Drawing.Color.Black;
            this.m_txtFileChecker.Location = new System.Drawing.Point(700, 76);
            this.m_txtFileChecker.Name = "m_txtFileChecker";
            this.m_txtFileChecker.ReadOnly = true;
            this.m_txtFileChecker.Size = new System.Drawing.Size(68, 23);
            this.m_txtFileChecker.TabIndex = 306;
            // 
            // m_txtWriteDoctor
            // 
            this.m_txtWriteDoctor.AccessibleDescription = "书写医生";
            this.m_txtWriteDoctor.AccessibleName = "NoDefault";
            this.m_txtWriteDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtWriteDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_txtWriteDoctor.Location = new System.Drawing.Point(280, 76);
            this.m_txtWriteDoctor.Name = "m_txtWriteDoctor";
            this.m_txtWriteDoctor.ReadOnly = true;
            this.m_txtWriteDoctor.Size = new System.Drawing.Size(68, 23);
            this.m_txtWriteDoctor.TabIndex = 151;
            // 
            // m_txtCheckDoctor
            // 
            this.m_txtCheckDoctor.AccessibleDescription = "医疗文件检查者";
            this.m_txtCheckDoctor.AccessibleName = "NoDefault";
            this.m_txtCheckDoctor.BackColor = System.Drawing.Color.White;
            this.m_txtCheckDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_txtCheckDoctor.Location = new System.Drawing.Point(488, 76);
            this.m_txtCheckDoctor.Name = "m_txtCheckDoctor";
            this.m_txtCheckDoctor.ReadOnly = true;
            this.m_txtCheckDoctor.Size = new System.Drawing.Size(68, 23);
            this.m_txtCheckDoctor.TabIndex = 205;
            // 
            // lblStandardCure
            // 
            this.lblStandardCure.AutoSize = true;
            this.lblStandardCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardCure.Location = new System.Drawing.Point(120, 292);
            this.lblStandardCure.Name = "lblStandardCure";
            this.lblStandardCure.Size = new System.Drawing.Size(14, 14);
            this.lblStandardCure.TabIndex = 531;
            this.lblStandardCure.Text = "5";
            // 
            // lblStandardHistory
            // 
            this.lblStandardHistory.AutoSize = true;
            this.lblStandardHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardHistory.Location = new System.Drawing.Point(120, 208);
            this.lblStandardHistory.Name = "lblStandardHistory";
            this.lblStandardHistory.Size = new System.Drawing.Size(21, 14);
            this.lblStandardHistory.TabIndex = 519;
            this.lblStandardHistory.Text = "25";
            // 
            // lblStandardFirstTidy
            // 
            this.lblStandardFirstTidy.AutoSize = true;
            this.lblStandardFirstTidy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardFirstTidy.Location = new System.Drawing.Point(120, 152);
            this.lblStandardFirstTidy.Name = "lblStandardFirstTidy";
            this.lblStandardFirstTidy.Size = new System.Drawing.Size(14, 14);
            this.lblStandardFirstTidy.TabIndex = 511;
            this.lblStandardFirstTidy.Text = "5";
            // 
            // lblStandardLitigant
            // 
            this.lblStandardLitigant.AutoSize = true;
            this.lblStandardLitigant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardLitigant.Location = new System.Drawing.Point(120, 180);
            this.lblStandardLitigant.Name = "lblStandardLitigant";
            this.lblStandardLitigant.Size = new System.Drawing.Size(14, 14);
            this.lblStandardLitigant.TabIndex = 515;
            this.lblStandardLitigant.Text = "5";
            // 
            // lblStandardOther
            // 
            this.lblStandardOther.AutoSize = true;
            this.lblStandardOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardOther.Location = new System.Drawing.Point(120, 348);
            this.lblStandardOther.Name = "lblStandardOther";
            this.lblStandardOther.Size = new System.Drawing.Size(21, 14);
            this.lblStandardOther.TabIndex = 539;
            this.lblStandardOther.Text = "10";
            // 
            // lblStandardDiagnose
            // 
            this.lblStandardDiagnose.AutoSize = true;
            this.lblStandardDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardDiagnose.Location = new System.Drawing.Point(120, 264);
            this.lblStandardDiagnose.Name = "lblStandardDiagnose";
            this.lblStandardDiagnose.Size = new System.Drawing.Size(14, 14);
            this.lblStandardDiagnose.TabIndex = 527;
            this.lblStandardDiagnose.Text = "5";
            // 
            // lblStandardState
            // 
            this.lblStandardState.AutoSize = true;
            this.lblStandardState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardState.Location = new System.Drawing.Point(120, 320);
            this.lblStandardState.Name = "lblStandardState";
            this.lblStandardState.Size = new System.Drawing.Size(21, 14);
            this.lblStandardState.TabIndex = 535;
            this.lblStandardState.Text = "15";
            // 
            // lblStandardCheck
            // 
            this.lblStandardCheck.AutoSize = true;
            this.lblStandardCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardCheck.Location = new System.Drawing.Point(120, 236);
            this.lblStandardCheck.Name = "lblStandardCheck";
            this.lblStandardCheck.Size = new System.Drawing.Size(21, 14);
            this.lblStandardCheck.TabIndex = 523;
            this.lblStandardCheck.Text = "15";
            // 
            // lblStandardDoctorAdvice
            // 
            this.lblStandardDoctorAdvice.AutoSize = true;
            this.lblStandardDoctorAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardDoctorAdvice.Location = new System.Drawing.Point(120, 376);
            this.lblStandardDoctorAdvice.Name = "lblStandardDoctorAdvice";
            this.lblStandardDoctorAdvice.Size = new System.Drawing.Size(14, 14);
            this.lblStandardDoctorAdvice.TabIndex = 543;
            this.lblStandardDoctorAdvice.Text = "5";
            // 
            // lblStandardNurse
            // 
            this.lblStandardNurse.AutoSize = true;
            this.lblStandardNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStandardNurse.Location = new System.Drawing.Point(120, 404);
            this.lblStandardNurse.Name = "lblStandardNurse";
            this.lblStandardNurse.Size = new System.Drawing.Size(21, 14);
            this.lblStandardNurse.TabIndex = 547;
            this.lblStandardNurse.Text = "10";
            // 
            // m_nmuFactFirstTidy
            // 
            this.m_nmuFactFirstTidy.AllowDrop = true;
            this.m_nmuFactFirstTidy.BackColor = System.Drawing.Color.White;
            this.m_nmuFactFirstTidy.DecimalPlaces = 3;
            this.m_nmuFactFirstTidy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactFirstTidy.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactFirstTidy.Hexadecimal = true;
            this.m_nmuFactFirstTidy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_nmuFactFirstTidy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactFirstTidy.Location = new System.Drawing.Point(156, 152);
            this.m_nmuFactFirstTidy.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactFirstTidy.Name = "m_nmuFactFirstTidy";
            this.m_nmuFactFirstTidy.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactFirstTidy.TabIndex = 420;
            this.m_nmuFactFirstTidy.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactFirstTidy.Visible = false;
            this.m_nmuFactFirstTidy.ValueChanged += new System.EventHandler(this.m_nmuFactFirstTidy_ValueChanged);
            this.m_nmuFactFirstTidy.TextChanged += new System.EventHandler(this.m_nmuFactFirstTidy_ValueChanged);
            // 
            // m_nmuFactLitigant
            // 
            this.m_nmuFactLitigant.BackColor = System.Drawing.Color.White;
            this.m_nmuFactLitigant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactLitigant.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactLitigant.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactLitigant.Location = new System.Drawing.Point(156, 180);
            this.m_nmuFactLitigant.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactLitigant.Name = "m_nmuFactLitigant";
            this.m_nmuFactLitigant.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactLitigant.TabIndex = 530;
            this.m_nmuFactLitigant.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactLitigant.Visible = false;
            this.m_nmuFactLitigant.ValueChanged += new System.EventHandler(this.m_nmuFactLitigant_ValueChanged);
            this.m_nmuFactLitigant.TextChanged += new System.EventHandler(this.m_nmuFactLitigant_ValueChanged);
            // 
            // m_nmuFactHistory
            // 
            this.m_nmuFactHistory.BackColor = System.Drawing.Color.White;
            this.m_nmuFactHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactHistory.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactHistory.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactHistory.Location = new System.Drawing.Point(156, 208);
            this.m_nmuFactHistory.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nmuFactHistory.Name = "m_nmuFactHistory";
            this.m_nmuFactHistory.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactHistory.TabIndex = 640;
            this.m_nmuFactHistory.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.m_nmuFactHistory.Visible = false;
            this.m_nmuFactHistory.ValueChanged += new System.EventHandler(this.m_nmuFactHistory_ValueChanged);
            this.m_nmuFactHistory.TextChanged += new System.EventHandler(this.m_nmuFactHistory_ValueChanged);
            // 
            // m_nmuFactCheck
            // 
            this.m_nmuFactCheck.BackColor = System.Drawing.Color.White;
            this.m_nmuFactCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactCheck.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactCheck.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactCheck.Location = new System.Drawing.Point(156, 236);
            this.m_nmuFactCheck.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nmuFactCheck.Name = "m_nmuFactCheck";
            this.m_nmuFactCheck.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactCheck.TabIndex = 750;
            this.m_nmuFactCheck.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nmuFactCheck.Visible = false;
            this.m_nmuFactCheck.ValueChanged += new System.EventHandler(this.m_nmuFactCheck_ValueChanged);
            this.m_nmuFactCheck.TextChanged += new System.EventHandler(this.m_nmuFactCheck_ValueChanged);
            // 
            // m_nmuFactDiagnose
            // 
            this.m_nmuFactDiagnose.BackColor = System.Drawing.Color.White;
            this.m_nmuFactDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactDiagnose.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactDiagnose.Location = new System.Drawing.Point(156, 352);
            this.m_nmuFactDiagnose.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactDiagnose.Name = "m_nmuFactDiagnose";
            this.m_nmuFactDiagnose.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactDiagnose.TabIndex = 860;
            this.m_nmuFactDiagnose.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactDiagnose.Visible = false;
            this.m_nmuFactDiagnose.ValueChanged += new System.EventHandler(this.m_nmuFactDiagnose_ValueChanged);
            this.m_nmuFactDiagnose.TextChanged += new System.EventHandler(this.m_nmuFactDiagnose_ValueChanged);
            // 
            // m_nmuFactCure
            // 
            this.m_nmuFactCure.BackColor = System.Drawing.Color.White;
            this.m_nmuFactCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactCure.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactCure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactCure.Location = new System.Drawing.Point(156, 404);
            this.m_nmuFactCure.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactCure.Name = "m_nmuFactCure";
            this.m_nmuFactCure.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactCure.TabIndex = 970;
            this.m_nmuFactCure.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactCure.Visible = false;
            this.m_nmuFactCure.ValueChanged += new System.EventHandler(this.m_nmuFactCure_ValueChanged);
            this.m_nmuFactCure.TextChanged += new System.EventHandler(this.m_nmuFactCure_ValueChanged);
            // 
            // m_nmuFactDoctorAdvice
            // 
            this.m_nmuFactDoctorAdvice.BackColor = System.Drawing.Color.White;
            this.m_nmuFactDoctorAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactDoctorAdvice.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactDoctorAdvice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactDoctorAdvice.Location = new System.Drawing.Point(156, 264);
            this.m_nmuFactDoctorAdvice.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactDoctorAdvice.Name = "m_nmuFactDoctorAdvice";
            this.m_nmuFactDoctorAdvice.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactDoctorAdvice.TabIndex = 1100;
            this.m_nmuFactDoctorAdvice.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.m_nmuFactDoctorAdvice.Visible = false;
            this.m_nmuFactDoctorAdvice.ValueChanged += new System.EventHandler(this.m_nmuFactDoctorAdvice_ValueChanged);
            this.m_nmuFactDoctorAdvice.TextChanged += new System.EventHandler(this.m_nmuFactDoctorAdvice_ValueChanged);
            // 
            // m_nmuFactState
            // 
            this.m_nmuFactState.BackColor = System.Drawing.Color.White;
            this.m_nmuFactState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactState.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactState.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactState.Location = new System.Drawing.Point(156, 292);
            this.m_nmuFactState.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nmuFactState.Name = "m_nmuFactState";
            this.m_nmuFactState.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactState.TabIndex = 1080;
            this.m_nmuFactState.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_nmuFactState.Visible = false;
            this.m_nmuFactState.ValueChanged += new System.EventHandler(this.m_nmuFactState_ValueChanged);
            this.m_nmuFactState.TextChanged += new System.EventHandler(this.m_nmuFactState_ValueChanged);
            // 
            // m_nmuFactOther
            // 
            this.m_nmuFactOther.BackColor = System.Drawing.Color.White;
            this.m_nmuFactOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactOther.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactOther.Location = new System.Drawing.Point(156, 324);
            this.m_nmuFactOther.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nmuFactOther.Name = "m_nmuFactOther";
            this.m_nmuFactOther.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactOther.TabIndex = 1090;
            this.m_nmuFactOther.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nmuFactOther.Visible = false;
            this.m_nmuFactOther.ValueChanged += new System.EventHandler(this.m_nmuFactOther_ValueChanged);
            this.m_nmuFactOther.TextChanged += new System.EventHandler(this.m_nmuFactOther_ValueChanged);
            // 
            // m_nmuFactNurse
            // 
            this.m_nmuFactNurse.BackColor = System.Drawing.Color.White;
            this.m_nmuFactNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_nmuFactNurse.ForeColor = System.Drawing.Color.Black;
            this.m_nmuFactNurse.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_nmuFactNurse.Location = new System.Drawing.Point(156, 376);
            this.m_nmuFactNurse.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nmuFactNurse.Name = "m_nmuFactNurse";
            this.m_nmuFactNurse.Size = new System.Drawing.Size(44, 23);
            this.m_nmuFactNurse.TabIndex = 1110;
            this.m_nmuFactNurse.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nmuFactNurse.Visible = false;
            this.m_nmuFactNurse.ValueChanged += new System.EventHandler(this.m_nmuFactNurse_ValueChanged);
            this.m_nmuFactNurse.TextChanged += new System.EventHandler(this.m_nmuFactNurse_ValueChanged);
            // 
            // m_lblTotalValue
            // 
            this.m_lblTotalValue.AutoSize = true;
            this.m_lblTotalValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTotalValue.Location = new System.Drawing.Point(736, 124);
            this.m_lblTotalValue.Name = "m_lblTotalValue";
            this.m_lblTotalValue.Size = new System.Drawing.Size(28, 14);
            this.m_lblTotalValue.TabIndex = 510;
            this.m_lblTotalValue.Text = "100";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalValue.Location = new System.Drawing.Point(688, 124);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(42, 14);
            this.lblTotalValue.TabIndex = 509;
            this.lblTotalValue.Text = "得分:";
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.HideSelection = false;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(3, 508);
            this.m_trvInPatientDate.Name = "m_trvInPatientDate";
            this.m_trvInPatientDate.ShowRootLines = false;
            this.m_trvInPatientDate.Size = new System.Drawing.Size(168, 92);
            this.m_trvInPatientDate.TabIndex = 103;
            this.m_trvInPatientDate.Visible = false;
            this.m_trvInPatientDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvInPatientDate_AfterSelect);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 100;
            // 
            // m_txtFactFirstTidy
            // 
            this.m_txtFactFirstTidy.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactFirstTidy.BackColor = System.Drawing.Color.White;
            this.m_txtFactFirstTidy.BorderColor = System.Drawing.Color.White;
            this.m_txtFactFirstTidy.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactFirstTidy.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactFirstTidy.Location = new System.Drawing.Point(208, 152);
            this.m_txtFactFirstTidy.MaxLength = 5;
            this.m_txtFactFirstTidy.Name = "m_txtFactFirstTidy";
            this.m_txtFactFirstTidy.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactFirstTidy.TabIndex = 400;
            this.m_txtFactFirstTidy.Text = "5";
            this.m_txtFactFirstTidy.TextChanged += new System.EventHandler(this.m_nmuFactFirstTidy_ValueChanged);
            // 
            // m_txtFactLitigant
            // 
            this.m_txtFactLitigant.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactLitigant.BackColor = System.Drawing.Color.White;
            this.m_txtFactLitigant.BorderColor = System.Drawing.Color.White;
            this.m_txtFactLitigant.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactLitigant.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactLitigant.Location = new System.Drawing.Point(208, 180);
            this.m_txtFactLitigant.MaxLength = 5;
            this.m_txtFactLitigant.Name = "m_txtFactLitigant";
            this.m_txtFactLitigant.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactLitigant.TabIndex = 500;
            this.m_txtFactLitigant.Text = "5";
            this.m_txtFactLitigant.TextChanged += new System.EventHandler(this.m_nmuFactLitigant_ValueChanged);
            // 
            // m_txtFactHistory
            // 
            this.m_txtFactHistory.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactHistory.BackColor = System.Drawing.Color.White;
            this.m_txtFactHistory.BorderColor = System.Drawing.Color.White;
            this.m_txtFactHistory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactHistory.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactHistory.Location = new System.Drawing.Point(208, 208);
            this.m_txtFactHistory.MaxLength = 5;
            this.m_txtFactHistory.Name = "m_txtFactHistory";
            this.m_txtFactHistory.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactHistory.TabIndex = 600;
            this.m_txtFactHistory.Text = "25";
            this.m_txtFactHistory.TextChanged += new System.EventHandler(this.m_nmuFactHistory_ValueChanged);
            // 
            // m_txtFactCheck
            // 
            this.m_txtFactCheck.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactCheck.BackColor = System.Drawing.Color.White;
            this.m_txtFactCheck.BorderColor = System.Drawing.Color.White;
            this.m_txtFactCheck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactCheck.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactCheck.Location = new System.Drawing.Point(208, 236);
            this.m_txtFactCheck.MaxLength = 5;
            this.m_txtFactCheck.Name = "m_txtFactCheck";
            this.m_txtFactCheck.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactCheck.TabIndex = 700;
            this.m_txtFactCheck.Text = "15";
            this.m_txtFactCheck.TextChanged += new System.EventHandler(this.m_nmuFactCheck_ValueChanged);
            // 
            // m_txtFactDiagnose
            // 
            this.m_txtFactDiagnose.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtFactDiagnose.BorderColor = System.Drawing.Color.White;
            this.m_txtFactDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactDiagnose.Location = new System.Drawing.Point(208, 264);
            this.m_txtFactDiagnose.MaxLength = 5;
            this.m_txtFactDiagnose.Name = "m_txtFactDiagnose";
            this.m_txtFactDiagnose.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactDiagnose.TabIndex = 800;
            this.m_txtFactDiagnose.Text = "5";
            this.m_txtFactDiagnose.TextChanged += new System.EventHandler(this.m_nmuFactDiagnose_ValueChanged);
            // 
            // m_txtFactCure
            // 
            this.m_txtFactCure.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactCure.BackColor = System.Drawing.Color.White;
            this.m_txtFactCure.BorderColor = System.Drawing.Color.White;
            this.m_txtFactCure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactCure.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactCure.Location = new System.Drawing.Point(208, 292);
            this.m_txtFactCure.MaxLength = 5;
            this.m_txtFactCure.Name = "m_txtFactCure";
            this.m_txtFactCure.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactCure.TabIndex = 900;
            this.m_txtFactCure.Text = "900";
            this.m_txtFactCure.TextChanged += new System.EventHandler(this.m_nmuFactCure_ValueChanged);
            // 
            // m_txtFactState
            // 
            this.m_txtFactState.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactState.BackColor = System.Drawing.Color.White;
            this.m_txtFactState.BorderColor = System.Drawing.Color.White;
            this.m_txtFactState.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactState.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactState.Location = new System.Drawing.Point(208, 320);
            this.m_txtFactState.MaxLength = 5;
            this.m_txtFactState.Name = "m_txtFactState";
            this.m_txtFactState.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactState.TabIndex = 1050;
            this.m_txtFactState.Text = "15";
            this.m_txtFactState.TextChanged += new System.EventHandler(this.m_nmuFactState_ValueChanged);
            // 
            // m_txtFactOther
            // 
            this.m_txtFactOther.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactOther.BackColor = System.Drawing.Color.White;
            this.m_txtFactOther.BorderColor = System.Drawing.Color.White;
            this.m_txtFactOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactOther.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactOther.Location = new System.Drawing.Point(208, 348);
            this.m_txtFactOther.MaxLength = 5;
            this.m_txtFactOther.Name = "m_txtFactOther";
            this.m_txtFactOther.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactOther.TabIndex = 1085;
            this.m_txtFactOther.Text = "10";
            this.m_txtFactOther.TextChanged += new System.EventHandler(this.m_nmuFactOther_ValueChanged);
            // 
            // m_txtFactDoctorAdvice
            // 
            this.m_txtFactDoctorAdvice.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactDoctorAdvice.BackColor = System.Drawing.Color.White;
            this.m_txtFactDoctorAdvice.BorderColor = System.Drawing.Color.White;
            this.m_txtFactDoctorAdvice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactDoctorAdvice.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactDoctorAdvice.Location = new System.Drawing.Point(208, 376);
            this.m_txtFactDoctorAdvice.MaxLength = 5;
            this.m_txtFactDoctorAdvice.Name = "m_txtFactDoctorAdvice";
            this.m_txtFactDoctorAdvice.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactDoctorAdvice.TabIndex = 1100;
            this.m_txtFactDoctorAdvice.Text = "5";
            this.m_txtFactDoctorAdvice.TextChanged += new System.EventHandler(this.m_nmuFactDoctorAdvice_ValueChanged);
            // 
            // m_txtFactNurse
            // 
            this.m_txtFactNurse.AccessibleDescription = "医疗文件检查者";
            this.m_txtFactNurse.BackColor = System.Drawing.Color.White;
            this.m_txtFactNurse.BorderColor = System.Drawing.Color.White;
            this.m_txtFactNurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtFactNurse.ForeColor = System.Drawing.Color.Black;
            this.m_txtFactNurse.Location = new System.Drawing.Point(208, 404);
            this.m_txtFactNurse.MaxLength = 5;
            this.m_txtFactNurse.Name = "m_txtFactNurse";
            this.m_txtFactNurse.Size = new System.Drawing.Size(52, 23);
            this.m_txtFactNurse.TabIndex = 1110;
            this.m_txtFactNurse.Text = "10";
            this.m_txtFactNurse.TextChanged += new System.EventHandler(this.m_nmuFactNurse_ValueChanged);
            // 
            // m_cmdFileChecker
            // 
            this.m_cmdFileChecker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdFileChecker.DefaultScheme = true;
            this.m_cmdFileChecker.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFileChecker.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdFileChecker.Hint = "";
            this.m_cmdFileChecker.Location = new System.Drawing.Point(564, 74);
            this.m_cmdFileChecker.Name = "m_cmdFileChecker";
            this.m_cmdFileChecker.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFileChecker.Size = new System.Drawing.Size(132, 24);
            this.m_cmdFileChecker.TabIndex = 305;
            this.m_cmdFileChecker.Text = "护理文件检查者";
            // 
            // m_cmdCheckDoctor
            // 
            this.m_cmdCheckDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCheckDoctor.DefaultScheme = true;
            this.m_cmdCheckDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCheckDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCheckDoctor.Hint = "";
            this.m_cmdCheckDoctor.Location = new System.Drawing.Point(352, 74);
            this.m_cmdCheckDoctor.Name = "m_cmdCheckDoctor";
            this.m_cmdCheckDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCheckDoctor.Size = new System.Drawing.Size(132, 24);
            this.m_cmdCheckDoctor.TabIndex = 204;
            this.m_cmdCheckDoctor.Text = "医疗文件检查者";
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(568, 480);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(60, 24);
            this.m_cmdEmployeeSign.TabIndex = 1120;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            this.m_cmdEmployeeSign.Visible = false;
            // 
            // m_cmdWriteDoctor
            // 
            this.m_cmdWriteDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdWriteDoctor.DefaultScheme = true;
            this.m_cmdWriteDoctor.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdWriteDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdWriteDoctor.ForeColor = System.Drawing.Color.Black;
            this.m_cmdWriteDoctor.Hint = "";
            this.m_cmdWriteDoctor.Location = new System.Drawing.Point(200, 74);
            this.m_cmdWriteDoctor.Name = "m_cmdWriteDoctor";
            this.m_cmdWriteDoctor.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdWriteDoctor.Size = new System.Drawing.Size(76, 24);
            this.m_cmdWriteDoctor.TabIndex = 150;
            this.m_cmdWriteDoctor.Text = "书写医生";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 4);
            this.groupBox1.TabIndex = 10000039;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // m_txtEmployeeSign
            // 
            this.m_txtEmployeeSign.BackColor = System.Drawing.Color.White;
            this.m_txtEmployeeSign.Location = new System.Drawing.Point(634, 480);
            this.m_txtEmployeeSign.Name = "m_txtEmployeeSign";
            this.m_txtEmployeeSign.ReadOnly = true;
            this.m_txtEmployeeSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtEmployeeSign.TabIndex = 1130;
            this.m_txtEmployeeSign.Visible = false;
            // 
            // frmQCRecord
            // 
            this.AccessibleDescription = "病案质量评分表";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(792, 673);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNurse);
            this.Controls.Add(this.lblDoctorAdvice);
            this.Controls.Add(this.lblOtherRecord);
            this.Controls.Add(this.lblStateillness);
            this.Controls.Add(this.lblCure);
            this.Controls.Add(this.lblDiagnose);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.lblCaseHistory);
            this.Controls.Add(this.txtLitigant);
            this.Controls.Add(this.lblFirstPageTidy);
            this.Controls.Add(this.m_txtEmployeeSign);
            this.Controls.Add(this.lblStandardCure);
            this.Controls.Add(this.lblStandardHistory);
            this.Controls.Add(this.lblStandardFirstTidy);
            this.Controls.Add(this.lblStandardLitigant);
            this.Controls.Add(this.lblStandardOther);
            this.Controls.Add(this.lblStandardDiagnose);
            this.Controls.Add(this.lblStandardState);
            this.Controls.Add(this.lblStandardCheck);
            this.Controls.Add(this.lblStandardDoctorAdvice);
            this.Controls.Add(this.lblStandardNurse);
            this.Controls.Add(this.lblDesc11);
            this.Controls.Add(this.lblReasonRrecord);
            this.Controls.Add(this.lblFactRecord);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.m_lblTotalValue);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblDesc2);
            this.Controls.Add(this.lblDesc12);
            this.Controls.Add(this.m_txtFactNurse);
            this.Controls.Add(this.m_txtFactDoctorAdvice);
            this.Controls.Add(this.m_txtFactOther);
            this.Controls.Add(this.m_txtFactState);
            this.Controls.Add(this.m_txtFactCure);
            this.Controls.Add(this.m_txtFactDiagnose);
            this.Controls.Add(this.m_txtFactCheck);
            this.Controls.Add(this.m_txtFactHistory);
            this.Controls.Add(this.m_txtFactLitigant);
            this.Controls.Add(this.m_txtFactFirstTidy);
            this.Controls.Add(this.m_txtReasonNurse);
            this.Controls.Add(this.m_txtReasonDoctorAdvice);
            this.Controls.Add(this.m_txtReasonOther);
            this.Controls.Add(this.m_txtReasonState);
            this.Controls.Add(this.m_txtReasonCure);
            this.Controls.Add(this.m_txtReasonDiagnose);
            this.Controls.Add(this.m_txtReasonCheck);
            this.Controls.Add(this.m_txtReasonHistory);
            this.Controls.Add(this.m_txtReasonLitigant);
            this.Controls.Add(this.m_txtReasonFirstTidy);
            this.Controls.Add(this.m_txtFileChecker);
            this.Controls.Add(this.m_txtWriteDoctor);
            this.Controls.Add(this.m_txtCheckDoctor);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdCheckDoctor);
            this.Controls.Add(this.m_cmdFileChecker);
            this.Controls.Add(this.m_cmdWriteDoctor);
            this.Controls.Add(this.m_nmuFactFirstTidy);
            this.Controls.Add(this.lblStandardRecored);
            this.Controls.Add(this.m_nmuFactLitigant);
            this.Controls.Add(this.m_nmuFactHistory);
            this.Controls.Add(this.m_nmuFactCheck);
            this.Controls.Add(this.m_nmuFactDiagnose);
            this.Controls.Add(this.m_nmuFactCure);
            this.Controls.Add(this.m_nmuFactDoctorAdvice);
            this.Controls.Add(this.m_nmuFactState);
            this.Controls.Add(this.m_nmuFactOther);
            this.Controls.Add(this.m_nmuFactNurse);
            this.Controls.Add(this.m_trvInPatientDate);
            this.Name = "frmQCRecord";
            this.Text = "病案质量评分表";
            this.Load += new System.EventHandler(this.frmQCRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_nmuFactNurse, 0);
            this.Controls.SetChildIndex(this.m_nmuFactOther, 0);
            this.Controls.SetChildIndex(this.m_nmuFactState, 0);
            this.Controls.SetChildIndex(this.m_nmuFactDoctorAdvice, 0);
            this.Controls.SetChildIndex(this.m_nmuFactCure, 0);
            this.Controls.SetChildIndex(this.m_nmuFactDiagnose, 0);
            this.Controls.SetChildIndex(this.m_nmuFactCheck, 0);
            this.Controls.SetChildIndex(this.m_nmuFactHistory, 0);
            this.Controls.SetChildIndex(this.m_nmuFactLitigant, 0);
            this.Controls.SetChildIndex(this.lblStandardRecored, 0);
            this.Controls.SetChildIndex(this.m_nmuFactFirstTidy, 0);
            this.Controls.SetChildIndex(this.m_cmdWriteDoctor, 0);
            this.Controls.SetChildIndex(this.m_cmdFileChecker, 0);
            this.Controls.SetChildIndex(this.m_cmdCheckDoctor, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_txtCheckDoctor, 0);
            this.Controls.SetChildIndex(this.m_txtWriteDoctor, 0);
            this.Controls.SetChildIndex(this.m_txtFileChecker, 0);
            this.Controls.SetChildIndex(this.m_txtReasonFirstTidy, 0);
            this.Controls.SetChildIndex(this.m_txtReasonLitigant, 0);
            this.Controls.SetChildIndex(this.m_txtReasonHistory, 0);
            this.Controls.SetChildIndex(this.m_txtReasonCheck, 0);
            this.Controls.SetChildIndex(this.m_txtReasonDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtReasonCure, 0);
            this.Controls.SetChildIndex(this.m_txtReasonState, 0);
            this.Controls.SetChildIndex(this.m_txtReasonOther, 0);
            this.Controls.SetChildIndex(this.m_txtReasonDoctorAdvice, 0);
            this.Controls.SetChildIndex(this.m_txtReasonNurse, 0);
            this.Controls.SetChildIndex(this.m_txtFactFirstTidy, 0);
            this.Controls.SetChildIndex(this.m_txtFactLitigant, 0);
            this.Controls.SetChildIndex(this.m_txtFactHistory, 0);
            this.Controls.SetChildIndex(this.m_txtFactCheck, 0);
            this.Controls.SetChildIndex(this.m_txtFactDiagnose, 0);
            this.Controls.SetChildIndex(this.m_txtFactCure, 0);
            this.Controls.SetChildIndex(this.m_txtFactState, 0);
            this.Controls.SetChildIndex(this.m_txtFactOther, 0);
            this.Controls.SetChildIndex(this.m_txtFactDoctorAdvice, 0);
            this.Controls.SetChildIndex(this.m_txtFactNurse, 0);
            this.Controls.SetChildIndex(this.lblDesc12, 0);
            this.Controls.SetChildIndex(this.lblDesc2, 0);
            this.Controls.SetChildIndex(this.lblTotalValue, 0);
            this.Controls.SetChildIndex(this.m_lblTotalValue, 0);
            this.Controls.SetChildIndex(this.lblItem, 0);
            this.Controls.SetChildIndex(this.lblFactRecord, 0);
            this.Controls.SetChildIndex(this.lblReasonRrecord, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblDesc11, 0);
            this.Controls.SetChildIndex(this.lblStandardNurse, 0);
            this.Controls.SetChildIndex(this.lblStandardDoctorAdvice, 0);
            this.Controls.SetChildIndex(this.lblStandardCheck, 0);
            this.Controls.SetChildIndex(this.lblStandardState, 0);
            this.Controls.SetChildIndex(this.lblStandardDiagnose, 0);
            this.Controls.SetChildIndex(this.lblStandardOther, 0);
            this.Controls.SetChildIndex(this.lblStandardLitigant, 0);
            this.Controls.SetChildIndex(this.lblStandardFirstTidy, 0);
            this.Controls.SetChildIndex(this.lblStandardHistory, 0);
            this.Controls.SetChildIndex(this.lblStandardCure, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_txtEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblFirstPageTidy, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.txtLitigant, 0);
            this.Controls.SetChildIndex(this.lblCaseHistory, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblCheck, 0);
            this.Controls.SetChildIndex(this.lblDiagnose, 0);
            this.Controls.SetChildIndex(this.lblCure, 0);
            this.Controls.SetChildIndex(this.lblStateillness, 0);
            this.Controls.SetChildIndex(this.lblOtherRecord, 0);
            this.Controls.SetChildIndex(this.lblDoctorAdvice, 0);
            this.Controls.SetChildIndex(this.lblNurse, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactFirstTidy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactLitigant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactDiagnose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactCure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactDoctorAdvice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nmuFactNurse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 清空评分内容，设置评分结果为缺省值
		/// </summary>
		private void m_mthClearEvaluation()
		{
			m_strCurrentOpenDate = "";

			m_lblTotalValue.Text = "";
			
			m_trvInPatientDate.Tag = null;

            m_txtEmployeeSign.Text = "";
            m_txtEmployeeSign.Tag = null;

            m_blnCanDoctorTextChanged = false;
			m_txtWriteDoctor.Tag = null;
			m_txtWriteDoctor.Text = "";

			m_txtFileChecker.Tag = null;
			m_txtFileChecker.Text = "";

			m_txtCheckDoctor.Tag = null;
			m_txtCheckDoctor.Text = "";
			m_blnCanDoctorTextChanged = true;

			m_blnWriteDoctorCanGotFocus = true;
			m_blnCheckDoctorCanGotFocus = true;
			m_blnFileCheckerCanGotFocus = true;

			m_txtFactFirstTidy.Text = "5";
			m_txtReasonFirstTidy.Text = "";

			m_txtFactLitigant.Text = "5";
			m_txtReasonLitigant.Text = "";

			m_txtFactHistory.Text = "25";
			m_txtReasonHistory.Text = "";

			m_txtFactCheck.Text = "15";
			m_txtReasonCheck.Text = "";

			m_txtFactDiagnose.Text = "5";
			m_txtReasonDiagnose.Text = "";

			m_txtFactCure.Text = "5";
			m_txtReasonCure.Text = "";

			m_txtFactState.Text = "15";
			m_txtReasonState.Text = "";

			m_txtFactOther.Text = "10";
			m_txtReasonOther.Text = "";

			m_txtFactDoctorAdvice.Text = "5";
			m_txtReasonDoctorAdvice.Text = "";

			m_txtFactNurse.Text = "10";
			m_txtReasonNurse.Text = "";

			m_lblTotalValue.Text = "100";
		}

		/// <summary>
		/// 清空所有内容
		/// </summary>
		private void m_mthClear()
		{
			//清空病人信息
			m_mthClearPatientBaseInfo();
			txtInPatientID.Tag = null;
			m_trnRoot.Nodes.Clear();

			//清空打印需要的变量
			m_objCurrentPatient = null;
			m_objCurrentWriteDoctor = null;
			m_objCurrentCheckDoctor = null;
			m_objCurrentFileCheckDoctor = null;

			m_mthClearEvaluation();

			txtInPatientID.Focus(); 
		}

		#region override
		/// <summary>
		/// 设置（子表）内容
		/// </summary>
		/// <param name="p_objContentInfo">内容</param>
		private void m_mthSetContentInfo(clsQCRecordContentInfo p_objContentInfo)
		{
			p_objContentInfo.m_strFirstPageTidyValue = m_txtFactFirstTidy.Text.ToString();
			p_objContentInfo.m_strFirstPageTidyReason = m_txtReasonFirstTidy.Text;

			p_objContentInfo.m_strLitigantValue = m_txtFactLitigant.Text.ToString();
			p_objContentInfo.m_strLitigantReason = m_txtReasonLitigant.Text;

			p_objContentInfo.m_strCaseHistoryValue = m_txtFactHistory.Text.ToString();
			p_objContentInfo.m_strCaseHistoryReason = m_txtReasonHistory.Text;

			p_objContentInfo.m_strCheckValue = m_txtFactCheck.Text.ToString();
			p_objContentInfo.m_strCheckReason = m_txtReasonCheck.Text;

			p_objContentInfo.m_strDiagnoseValue = m_txtFactDiagnose.Text.ToString();
			p_objContentInfo.m_strDiagnoseReason = m_txtReasonDiagnose.Text;

			p_objContentInfo.m_strCureValue = m_txtFactCure.Text.ToString();
			p_objContentInfo.m_strCureReason = m_txtReasonCure.Text;

			p_objContentInfo.m_strStateillnessValue = m_txtFactState.Text.ToString();
			p_objContentInfo.m_strStateillnessReason = m_txtReasonState.Text;

			p_objContentInfo.m_strOtherRecordValue = m_txtFactOther.Text.ToString();
			p_objContentInfo.m_strOtherRecordReason = m_txtReasonOther.Text;

			p_objContentInfo.m_strDoctorAdviceValue = m_txtFactDoctorAdvice.Text.ToString();
			p_objContentInfo.m_strDoctorAdviceReason = m_txtReasonDoctorAdvice.Text;

			p_objContentInfo.m_strNurseValue = m_txtFactNurse.Text.ToString();
			p_objContentInfo.m_strNurseReason = m_txtReasonNurse.Text;

			p_objContentInfo.m_strTotalValue = m_lblTotalValue.Text;
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			/*
			 * 检查是否选择了病人和入院信息；检查是否选择了医生。
			 * 添加新记录。
			 */
			clsPatient objPatient = m_objCurrentPatient;

			if(objPatient == null)
			{
#if !Debug
				m_mthShowNoPatient();
#endif
				return -5;
			}

			if(m_ObjCurrentEmrPatientSession == null || m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate == DateTime.MinValue)
			{
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("请选择入院时间。");
#endif
				return -7;
			}

            clsEmrEmployeeBase_VO objWriteDoctor = m_txtWriteDoctor.Tag as clsEmrEmployeeBase_VO;
            clsEmrEmployeeBase_VO objCheckDoctor = m_txtCheckDoctor.Tag as clsEmrEmployeeBase_VO;
            clsEmrEmployeeBase_VO objFileDoctor = m_txtFileChecker.Tag as clsEmrEmployeeBase_VO;

            if (m_txtEmployeeSign.Tag == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请记录者签名！");
                return -6;
            }
//            string strNoSignDoctor = "请选择";

//            if(objWriteDoctor == null)
//            {
//                strNoSignDoctor += "书写医生";
//            }
//            if(objCheckDoctor == null)
//            {
//                if(strNoSignDoctor != "请选择")
//                    strNoSignDoctor += "、";

//                strNoSignDoctor += "医疗文件检查者";
//            }
//            if(objFileDoctor == null)
//            {
//                if(strNoSignDoctor != "请选择")
//                    strNoSignDoctor += "、";

//                strNoSignDoctor += "护理文件检查者";
//            }			

//            if(strNoSignDoctor != "请选择")
//            {
//#if !Debug
//                clsPublicFunction.ShowInformationMessageBox(strNoSignDoctor+"。");
//#endif
//                return -6;
//            }

            DateTime dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;

			string strOpenDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			clsQCRecordInfo objMainInfo = new clsQCRecordInfo();
			objMainInfo.m_strInPatientID = objPatient.m_StrInPatientID;
			objMainInfo.m_strInPatientDate = dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
			objMainInfo.m_strOpenDate = strOpenDate;
			objMainInfo.m_strCreateID = m_objCurrentContext.m_ObjEmployee.m_StrEmployeeID;
			
			clsQCRecordContentInfo objContentInfo = new clsQCRecordContentInfo();
			objContentInfo.m_strInPatientID = objPatient.m_StrInPatientID;
			objContentInfo.m_strInPatientDate = dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
			objContentInfo.m_strOpenDate = strOpenDate;
			objContentInfo.m_strModifyDate = strOpenDate;
            objContentInfo.m_strRecorderID = ((clsEmrEmployeeBase_VO)m_txtEmployeeSign.Tag).m_strEMPNO_CHR;
            objContentInfo.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            if (objWriteDoctor != null)
            {
                objContentInfo.m_strWriteDoctorID = objWriteDoctor.m_strEMPNO_CHR;
            }
            else
            {
                objContentInfo.m_strWriteDoctorID = "";
            }

            if (objCheckDoctor != null)
            {
                objContentInfo.m_strCheckDoctorID = objCheckDoctor.m_strEMPNO_CHR;
            }
            else
            {
                objContentInfo.m_strCheckDoctorID = "";
            }

            if (objFileDoctor != null)
            {
                objContentInfo.m_strFileCheckerID = objFileDoctor.m_strEMPNO_CHR;
            }
            else
            {
                objContentInfo.m_strFileCheckerID = "";
            }
			m_mthSetContentInfo(objContentInfo);

			long lngRes = m_objQCRecordDomain.m_lngAddNew(objMainInfo,objContentInfo);

			if(lngRes > 0)
			{
				m_objCurrentContent = objContentInfo;
				m_objCurrentWriteDoctor = objWriteDoctor;
				m_objCurrentCheckDoctor = objCheckDoctor;
				m_objCurrentFileCheckDoctor = objFileDoctor;
				
				m_trvInPatientDate.Tag = objContentInfo;
			}			
			else
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败");
			}
			return lngRes;
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			clsPatient objPatient = m_objCurrentPatient;

			if(objPatient==null|| m_ObjCurrentEmrPatientSession == null)	
			{
				m_mthShowNoPatient();
				return -5;
			}

            long lngRes = m_objQCRecordDomain.m_lngDelete(MDIParent.strOperatorID, objPatient.m_StrInPatientID, objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"));
			if(lngRes <=0)
			{				
				clsPublicFunction.ShowInformationMessageBox("删除失败");
			}
			else 
			{				
				m_mthClearEvaluation();				
				m_objCurrentContent=null;				
				m_objCurrentWriteDoctor = null;
				m_objCurrentCheckDoctor = null;
				m_objCurrentFileCheckDoctor = null;				
			}
			return lngRes;
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubModify()
		{
			/*
			 * 修改也是直接添加新记录，所以不用实现。
			 */
//			if(!m_bolShowIfModify()) return -1;
			return m_lngSubAddNew();
		}

		/// <summary>
		/// 内部不使用
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubPrint()
		{
			if(m_objCurrentPatient ==null || m_ObjCurrentEmrPatientSession == null)
			{	
				m_mthShowNoPatient();
				return -1;		
			}
            else if (m_objCurrentPatient != null && m_objCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择入院时间");
				return -1;
			}			

			else if(m_objCurrentPatient !=null)
			{
				clsQCRecordInfo objMainInfo;
				clsQCRecordContentInfo objContentInfo;
                long lngRes = m_objQCRecordDomain.m_lngGetQCRecord(m_objCurrentPatient, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objMainInfo, out objContentInfo);
					
				if(lngRes>0 && objContentInfo !=null && m_objCurrentContent !=null 
					&& DateTime.Parse(objContentInfo.m_strModifyDate) !=DateTime.Parse( m_objCurrentContent.m_strModifyDate))
				{//本判断根据最后修改时间的大小比较得到	，只可能大于（被修改）或等于（没修改），不可能小于（此时查询时为空记录）
							
					if(m_bolShowRecordModified(objContentInfo.m_strModifyUserID,objContentInfo.m_strModifyDate)==false)
						return -101;//若最新记录改变时的返回值	
			
					m_objCurrentContent= objContentInfo;//保存到内存对象			

					m_mthSetQCRecordContent(objContentInfo);//begin---更新显示			

					m_blnCanDoctorTextChanged = false;

                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strWriteDoctorID, out objEmpVO);
                    m_objCurrentWriteDoctor = objEmpVO;
                    if (objEmpVO != null)
                    {
                        m_txtWriteDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtWriteDoctor.Tag = objEmpVO;
                    }

                    clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strCheckDoctorID, out objEmpVO1);
                    m_objCurrentCheckDoctor = objEmpVO1;
                    if (objEmpVO1 != null)
                    {
                        m_txtCheckDoctor.Text = objEmpVO1.m_strLASTNAME_VCHR;
                        m_txtCheckDoctor.Tag = objEmpVO1;
                    }

                    clsEmrEmployeeBase_VO objEmpVO2 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strFileCheckerID, out objEmpVO2);
                    m_objCurrentFileCheckDoctor = objEmpVO2;
                    if (objEmpVO2 != null)
                    {
                        m_txtFileChecker.Text = objEmpVO2.m_strLASTNAME_VCHR;
                        m_txtFileChecker.Tag = objEmpVO2;
                    }

                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strRecorderID, out objEmpVO);
                    if (objEmpVO != null)
                    {
                        m_txtEmployeeSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtEmployeeSign.Tag = objEmpVO;
                    }

					m_blnCanDoctorTextChanged = true;//end---更新显示
				}			
				else if(lngRes<0)
				{
					m_mthShowDBError();
					return -200;
				}

				if(objMainInfo==null || objContentInfo==null)
				{
                    //clsQCRecordInfo objMainInfo_Deleted;
                    //long lngRes2 = m_objQCRecordDomain.m_lngGetIDandTimeOfDeletedRecord((clsPatient)txtInPatientID.Tag, Convert.ToDateTime(m_trvInPatientDate.SelectedNode.Tag).ToString("yyyy-MM-dd HH:mm:ss"), out objMainInfo_Deleted);
                    //if(lngRes2>0 && objMainInfo_Deleted !=null)
                    //    m_mthShowRecordDeleted(objMainInfo_Deleted.m_strDeActivedOperatorID,objMainInfo_Deleted.m_strDeActivedDate);
                    //else if(lngRes2<0)
                    //{
                    //    m_mthShowDBError();
                    //    return -200;
                    //}
                    //else
						clsPublicFunction.ShowInformationMessageBox("当前为空白表");

					m_objCurrentContent= null;//保存到内存对象		

					return -19;
				}
			}

			if(m_rpdQCRecord == null)
			{
				m_rpdQCRecord = new ReportDocument();
				m_rpdQCRecord.Load(m_strTemplatePath+"cryQCRecord.rpt");
			}

			m_mthAddNewDataForQCRecordDataSet(m_dtsRept);

			frmCryReptView objView = new frmCryReptView(m_rpdQCRecord);
//			objView.MdiParent = this.MdiParent;
			objView.ShowDialog();

			return 1;
		}
        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrSex;
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrAge;

        }
		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			/*
			 * 保存病人变量，获取病人所有入院时间。
			 */
            //txtInPatientID.Tag = p_objSelectedPatient;
			m_objCurrentPatient=p_objSelectedPatient;
			m_mthClearEvaluation();

            //m_trnRoot.Nodes.Clear();

            //for(int i=p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount()-1;i>=0;i--)
            //{
            //    TreeNode trnNewNode = new TreeNode(p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss"));
            //    trnNewNode.Tag = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmEMRInDate;
            //    m_trnRoot.Nodes.Add(trnNewNode);
            //}

            ////选中默认节点
            //for(int i = 0; i < m_trvInPatientDate.Nodes[0].Nodes.Count; i++)
            //{
            //    if((DateTime)m_trvInPatientDate.Nodes[0].Nodes[i].Tag == p_objSelectedPatient.m_DtmSelectedInDate)
            //    {
            //        m_trvInPatientDate.SelectedNode = m_trvInPatientDate.Nodes[0].Nodes[i];
            //        m_trvInPatientDate_AfterSelect(m_trvInPatientDate,new TreeViewEventArgs(m_trvInPatientDate.SelectedNode));
						
            //    }
            //}

            //m_trnRoot.Expand();
			
		}

		private void frmQCRecord_Load(object sender, System.EventArgs e)
		{
			/*
			 * 在Load的时候才隐藏ListView，可以解决由于滚动条而引起的控件错位的问题。
			 */			
			m_mthSetQuickKeys();

			
			m_trvInPatientDate.Focus();
		}

		protected override bool m_BlnCanTextChanged
		{
			get
			{
				//对病人号的输入不作处理，所有不需要控制。
				return true;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				//修改也是添加新记录。
				return m_trvInPatientDate.Tag == null;
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

		#region 接口函数
		public void Delete()
		{	
			if(m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择病人！");
				return ;
			}

			long m_lngRe=m_lngDelete(); 
			if(m_lngRe>0)

			{
                clsPublicFunction.ShowInformationMessageBox("删除成功！");
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
			}
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

		public void Save()
		{
			long m_lngRe=m_lngSave(); 
			if(m_lngRe>0)
			{
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
			}
		}

		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}

		public void Paste()
		{
			m_lngPaste();
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

		private void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();
			/*
			 * 清空界面。如果选择的是某个入院日期，显示该日期的评分信息。
			 */
			m_mthClearEvaluation();

			if(!e.Node.Equals(m_trnRoot))
			{
				clsQCRecordInfo objMainInfo;
				clsQCRecordContentInfo objContentInfo;

               //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);
                m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo;
                
                #region 获取病人当次入院登记号
                string strRegisterID = "";

                com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

                long lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(e.Node.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                #endregion

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                lngRes = m_objQCRecordDomain.m_lngGetQCRecord((clsPatient)txtInPatientID.Tag, Convert.ToDateTime(e.Node.Tag).ToString("yyyy-MM-dd HH:mm:ss"), out objMainInfo, out objContentInfo);

				if(lngRes > 0)
				{
 					m_mthSetQCRecordContent(objContentInfo);

					m_trvInPatientDate.Tag = objContentInfo;

					m_blnCanDoctorTextChanged = false;

                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strWriteDoctorID, out objEmpVO);
                    m_objCurrentWriteDoctor = objEmpVO;
                    if (objEmpVO != null)
                    {
                        m_txtWriteDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtWriteDoctor.Tag = objEmpVO;
                    }

                    clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strCheckDoctorID, out objEmpVO1);
                    m_objCurrentCheckDoctor = objEmpVO1;
                    if (objEmpVO1 != null)
                    {
                        m_txtCheckDoctor.Text = objEmpVO1.m_strLASTNAME_VCHR;
                        m_txtCheckDoctor.Tag = objEmpVO1;
                    }

                    clsEmrEmployeeBase_VO objEmpVO2 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strFileCheckerID, out objEmpVO2);
                    m_objCurrentFileCheckDoctor = objEmpVO2;
                    if (objEmpVO2 != null)
                    {
                        m_txtFileChecker.Text = objEmpVO2.m_strLASTNAME_VCHR;
                        m_txtFileChecker.Tag = objEmpVO2;
                    }

                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strRecorderID, out objEmpVO);
                    if (objEmpVO != null)
                    {
                        m_txtEmployeeSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtEmployeeSign.Tag = objEmpVO;
                    }

					m_blnCanDoctorTextChanged = true;
					
					m_objCurrentContent= objContentInfo;//保存到内存对象	

					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );

					m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;
				}
				else
				{
					m_mthSetDefaultValue((clsPatient)txtInPatientID.Tag);
					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				}
			}
			else
			{
				//当前处于禁止输入状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );
			}

			m_mthAddFormStatusForClosingSave();
		}

		/// <summary>
		/// 设置（子表）内容
		/// </summary>
		/// <param name="p_objContentInfo">（子表）内容</param>
		private void m_mthSetQCRecordContent(clsQCRecordContentInfo p_objContentInfo)
		{
			if(p_objContentInfo == null)
				return;

			m_strCurrentOpenDate = p_objContentInfo.m_strOpenDate;


			m_txtFactFirstTidy.Text = p_objContentInfo.m_strFirstPageTidyValue;
			m_txtReasonFirstTidy.Text = p_objContentInfo.m_strFirstPageTidyReason;

			m_txtFactLitigant.Text = p_objContentInfo.m_strLitigantValue;
			m_txtReasonLitigant.Text = p_objContentInfo.m_strLitigantReason;

			m_txtFactHistory.Text = p_objContentInfo.m_strCaseHistoryValue;
			m_txtReasonHistory.Text = p_objContentInfo.m_strCaseHistoryReason;

			m_txtFactCheck.Text = p_objContentInfo.m_strCheckValue;
			m_txtReasonCheck.Text = p_objContentInfo.m_strCheckReason;

			m_txtFactDiagnose.Text = p_objContentInfo.m_strDiagnoseValue;
			m_txtReasonDiagnose.Text = p_objContentInfo.m_strDiagnoseReason;

			m_txtFactCure.Text = p_objContentInfo.m_strCureValue;
			m_txtReasonCure.Text = p_objContentInfo.m_strCureReason;

			m_txtFactState.Text = p_objContentInfo.m_strStateillnessValue;
			m_txtReasonState.Text = p_objContentInfo.m_strStateillnessReason;

			m_txtFactOther.Text = p_objContentInfo.m_strOtherRecordValue;
			m_txtReasonOther.Text = p_objContentInfo.m_strOtherRecordReason;

			m_txtFactDoctorAdvice.Text = p_objContentInfo.m_strDoctorAdviceValue;
			m_txtReasonDoctorAdvice.Text = p_objContentInfo.m_strDoctorAdviceReason;

			m_txtFactNurse.Text = p_objContentInfo.m_strNurseValue;
			m_txtReasonNurse.Text = p_objContentInfo.m_strNurseReason;

			m_lblTotalValue.Text = p_objContentInfo.m_strTotalValue;
		}

		#region 评分数值改变的处理。
		/// <summary>
		/// 计算总评分值
		/// </summary>
		private void m_mthCalculateTotalValue()
		{
			try
			{
				m_lblTotalValue.Text = ""+
					(float.Parse(m_txtFactFirstTidy.Text)+
					float.Parse(m_txtFactLitigant.Text)+
					float.Parse(m_txtFactHistory.Text)+
					float.Parse(m_txtFactCheck.Text)+
					float.Parse(m_txtFactDiagnose.Text)+
					float.Parse(m_txtFactCure.Text)+
					float.Parse(m_txtFactState.Text)+
					float.Parse(m_txtFactOther.Text)+
					float.Parse(m_txtFactDoctorAdvice.Text)+
					float.Parse(m_txtFactNurse.Text));
			}
			catch
			{				
			}
		}

		private void m_nmuFactFirstTidy_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactFirstTidy.Text) < 0 || float.Parse(m_txtFactFirstTidy.Text) > 5)
				{
					m_txtFactFirstTidy.Text = "5";
				}
			}
			catch
			{
				m_txtFactFirstTidy.Text = "5";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactLitigant_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactLitigant.Text) < 0 || float.Parse(m_txtFactLitigant.Text) > 5)
				{
					m_txtFactLitigant.Text = "5";
				}
			}
			catch
			{
				m_txtFactLitigant.Text = "5";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactHistory_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactHistory.Text) < 0 || float.Parse(m_txtFactHistory.Text) > 25)
				{
					m_txtFactHistory.Text = "25";
				}
			}
			catch
			{
				m_txtFactHistory.Text = "25";
			}
			m_mthCalculateTotalValue();
		}

		private void m_nmuFactCheck_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactCheck.Text) < 0 || float.Parse(m_txtFactCheck.Text) > 15)
				{
					m_txtFactCheck.Text = "15";
				}
			}
			catch
			{
				m_txtFactCheck.Text = "15";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactDiagnose_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactDiagnose.Text) < 0 || float.Parse(m_txtFactDiagnose.Text) > 5)
				{
					m_txtFactDiagnose.Text = "5";
				}
			}
			catch
			{
				m_txtFactDiagnose.Text = "5";
			}
			m_mthCalculateTotalValue();
		}

		private void m_nmuFactCure_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactCure.Text) < 0 || float.Parse(m_txtFactCure.Text) > 5)
				{
					m_txtFactCure.Text = "5";
				}
			}
			catch
			{
				m_txtFactCure.Text = "5";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactState_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactState.Text) < 0 || float.Parse(m_txtFactState.Text) > 15)
				{
					m_txtFactState.Text = "15";
				}
			}
			catch
			{
				m_txtFactState.Text = "15";
			}
			m_mthCalculateTotalValue();
		}

		private void m_nmuFactOther_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;
			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactOther.Text) < 0 || float.Parse(m_txtFactOther.Text) > 10)
				{
					m_txtFactOther.Text = "10";
				}
			}
			catch
			{
				m_txtFactOther.Text = "10";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactDoctorAdvice_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;
			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactDoctorAdvice.Text) < 0 || float.Parse(m_txtFactDoctorAdvice.Text) > 5)
				{
					m_txtFactDoctorAdvice.Text = "5";
				}
			}
			catch
			{
				m_txtFactDoctorAdvice.Text = "5";
			}

			m_mthCalculateTotalValue();
		}

		private void m_nmuFactNurse_ValueChanged(object sender, System.EventArgs e)
		{
			if(!m_blnCanValueChanged)
				return;

			try
			{
				/*
				 * 如果输入值超出范围，设置为缺省值
				 */
				if(float.Parse(m_txtFactNurse.Text) < 0 || float.Parse(m_txtFactNurse.Text) > 10)
				{
					m_txtFactNurse.Text = "10";
				}
			}
			catch
			{
				m_txtFactNurse.Text = "10";
			}

			m_mthCalculateTotalValue();
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
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					//					if(sender.GetType().Name!="ctlRichTextBox")
					//						SendKeys.Send(  "{tab}");

					break;

				case 38:
				case 40:					
					
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
					m_mthClear();
					break;
				case 117://Search					
					break;
			}	
		}

		#endregion

		#region Print（使用Crystal Report）
		private clsQCRecordContentInfo m_objCurrentContent;
        private clsEmrEmployeeBase_VO m_objCurrentWriteDoctor;
        private clsEmrEmployeeBase_VO m_objCurrentCheckDoctor;
        private clsEmrEmployeeBase_VO m_objCurrentFileCheckDoctor;
		private clsPatient m_objCurrentPatient;
		/*
		* DataSet : QCRecord
		* DataTable : QCRecord
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : InPatientName(string)
		* 	DataColumn : DeptName(string)
		* 	DataColumn : WriteDoctor(string)
		* 	DataColumn : FileChecke(string)
		* 	DataColumn : CheckDoctor(string)
		* 	DataColumn : FirstPageTidyValue(string)
		* 	DataColumn : FirstPageTidyReason(string)
		* 	DataColumn : LitigantValue(string)
		* 	DataColumn : LitigantReason(string)
		* 	DataColumn : CaseHistoryValue(string)
		* 	DataColumn : CaseHistoryReason(string)
		* 	DataColumn : CheckValue(string)
		* 	DataColumn : CheckReason(string)
		* 	DataColumn : DiagnoseValue(string)
		* 	DataColumn : DiagnoseReason(string)
		* 	DataColumn : CureValue(string)
		* 	DataColumn : CureReason(string)
		* 	DataColumn : StateillnessValue(string)
		* 	DataColumn : StateillnessReason(string)
		* 	DataColumn : OtherRecordValue(string)
		* 	DataColumn : OtherRecordReason(string)
		* 	DataColumn : DoctorAdviceValue(string)
		* 	DataColumn : DoctorAdviceReason(string)
		* 	DataColumn : NurseValue(string)
		* 	DataColumn : NurseReason(string)
		* 	DataColumn : TotalValue(string)
		*/ 
		private DataSet m_dtsInitQCRecordDataSet()
		{
			DataSet dsQCRecord = new DataSet("QCRecord");

			DataTable dtQCRecord = new DataTable("QCRecord");

			DataColumn dcQCRecordInPatientID = new DataColumn("InPatientID",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordInPatientID);

			DataColumn dcQCRecordInPatientName = new DataColumn("InPatientName",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordInPatientName);

			DataColumn dcQCRecordDeptName = new DataColumn("DeptName",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordDeptName);

			DataColumn dcQCRecordWriteDoctor = new DataColumn("WriteDoctor",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordWriteDoctor);

			DataColumn dcQCRecordFileChecke = new DataColumn("FileChecke",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordFileChecke);

			DataColumn dcQCRecordCheckDoctor = new DataColumn("CheckDoctor",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCheckDoctor);

			DataColumn dcQCRecordFirstPageTidyValue = new DataColumn("FirstPageTidyValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordFirstPageTidyValue);

			DataColumn dcQCRecordFirstPageTidyReason = new DataColumn("FirstPageTidyReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordFirstPageTidyReason);

			DataColumn dcQCRecordLitigantValue = new DataColumn("LitigantValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordLitigantValue);

			DataColumn dcQCRecordLitigantReason = new DataColumn("LitigantReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordLitigantReason);

			DataColumn dcQCRecordCaseHistoryValue = new DataColumn("CaseHistoryValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCaseHistoryValue);

			DataColumn dcQCRecordCaseHistoryReason = new DataColumn("CaseHistoryReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCaseHistoryReason);

			DataColumn dcQCRecordCheckValue = new DataColumn("CheckValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCheckValue);

			DataColumn dcQCRecordCheckReason = new DataColumn("CheckReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCheckReason);

			DataColumn dcQCRecordDiagnoseValue = new DataColumn("DiagnoseValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordDiagnoseValue);

			DataColumn dcQCRecordDiagnoseReason = new DataColumn("DiagnoseReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordDiagnoseReason);

			DataColumn dcQCRecordCureValue = new DataColumn("CureValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCureValue);

			DataColumn dcQCRecordCureReason = new DataColumn("CureReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordCureReason);

			DataColumn dcQCRecordStateillnessValue = new DataColumn("StateillnessValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordStateillnessValue);

			DataColumn dcQCRecordStateillnessReason = new DataColumn("StateillnessReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordStateillnessReason);

			DataColumn dcQCRecordOtherRecordValue = new DataColumn("OtherRecordValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordOtherRecordValue);

			DataColumn dcQCRecordOtherRecordReason = new DataColumn("OtherRecordReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordOtherRecordReason);

			DataColumn dcQCRecordDoctorAdviceValue = new DataColumn("DoctorAdviceValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordDoctorAdviceValue);

			DataColumn dcQCRecordDoctorAdviceReason = new DataColumn("DoctorAdviceReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordDoctorAdviceReason);

			DataColumn dcQCRecordNurseValue = new DataColumn("NurseValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordNurseValue);

			DataColumn dcQCRecordNurseReason = new DataColumn("NurseReason",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordNurseReason);

			DataColumn dcQCRecordTotalValue = new DataColumn("TotalValue",typeof(string));

			dtQCRecord.Columns.Add(dcQCRecordTotalValue);

			dsQCRecord.Tables.Add(dtQCRecord);

			return dsQCRecord;
		}

		/*
		* DataSet : QCRecord
		* DataTable : QCRecord
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : InPatientName(string)
		* 	DataColumn : DeptName(string)
		* 	DataColumn : WriteDoctor(string)
		* 	DataColumn : FileChecke(string)
		* 	DataColumn : CheckDoctor(string)
		* 	DataColumn : FirstPageTidyValue(string)
		* 	DataColumn : FirstPageTidyReason(string)
		* 	DataColumn : LitigantValue(string)
		* 	DataColumn : LitigantReason(string)
		* 	DataColumn : CaseHistoryValue(string)
		* 	DataColumn : CaseHistoryReason(string)
		* 	DataColumn : CheckValue(string)
		* 	DataColumn : CheckReason(string)
		* 	DataColumn : DiagnoseValue(string)
		* 	DataColumn : DiagnoseReason(string)
		* 	DataColumn : CureValue(string)
		* 	DataColumn : CureReason(string)
		* 	DataColumn : StateillnessValue(string)
		* 	DataColumn : StateillnessReason(string)
		* 	DataColumn : OtherRecordValue(string)
		* 	DataColumn : OtherRecordReason(string)
		* 	DataColumn : DoctorAdviceValue(string)
		* 	DataColumn : DoctorAdviceReason(string)
		* 	DataColumn : NurseValue(string)
		* 	DataColumn : NurseReason(string)
		* 	DataColumn : TotalValue(string)
		*/ 
		private void m_mthAddNewDataForQCRecordDataSet(DataSet dsQCRecord)
		{
			DataTable dtQCRecord = dsQCRecord.Tables["QCRECORD"];
			dtQCRecord.Rows.Clear();

			object [] objQCRecordDatas = new object[27];

			if(m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null && m_objCurrentContent !=null)
			{
				objQCRecordDatas[0] = m_objCurrentPatient.m_StrInPatientID;
				objQCRecordDatas[1] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
                objQCRecordDatas[2] = m_ObjCurrentEmrPatientSession.m_strAreaName;
                objQCRecordDatas[3] = m_objCurrentWriteDoctor != null ? m_objCurrentWriteDoctor.m_strLASTNAME_VCHR : "";
                objQCRecordDatas[4] = m_objCurrentFileCheckDoctor != null ? m_objCurrentFileCheckDoctor.m_strLASTNAME_VCHR : "";
                objQCRecordDatas[5] = m_objCurrentCheckDoctor != null ? m_objCurrentCheckDoctor.m_strLASTNAME_VCHR : "";
				objQCRecordDatas[6] = m_objCurrentContent.m_strFirstPageTidyValue;
				objQCRecordDatas[7] = m_objCurrentContent.m_strFirstPageTidyReason;
				objQCRecordDatas[8] = m_objCurrentContent.m_strLitigantValue;
				objQCRecordDatas[9] = m_objCurrentContent.m_strLitigantReason;
				objQCRecordDatas[10] = m_objCurrentContent.m_strCaseHistoryValue;
				objQCRecordDatas[11] = m_objCurrentContent.m_strCaseHistoryReason;
				objQCRecordDatas[12] = m_objCurrentContent.m_strCheckValue;
				objQCRecordDatas[13] = m_objCurrentContent.m_strCheckReason;
				objQCRecordDatas[14] = m_objCurrentContent.m_strDiagnoseValue;
				objQCRecordDatas[15] = m_objCurrentContent.m_strDiagnoseReason;
				objQCRecordDatas[16] = m_objCurrentContent.m_strCureValue;
				objQCRecordDatas[17] = m_objCurrentContent.m_strCureReason;
				objQCRecordDatas[18] = m_objCurrentContent.m_strStateillnessValue;
				objQCRecordDatas[19] = m_objCurrentContent.m_strStateillnessReason;
				objQCRecordDatas[20] = m_objCurrentContent.m_strOtherRecordValue;
				objQCRecordDatas[21] = m_objCurrentContent.m_strOtherRecordReason;
				objQCRecordDatas[22] = m_objCurrentContent.m_strDoctorAdviceValue;
				objQCRecordDatas[23] = m_objCurrentContent.m_strDoctorAdviceReason;
				objQCRecordDatas[24] = m_objCurrentContent.m_strNurseValue;
				objQCRecordDatas[25] = m_objCurrentContent.m_strNurseReason;
				objQCRecordDatas[26] = m_objCurrentContent.m_strTotalValue;
			}
			else
			{
				//打印空报表
				objQCRecordDatas[0] = "";
				objQCRecordDatas[1] = "";
				objQCRecordDatas[2] = "";
				objQCRecordDatas[3] = "";
				objQCRecordDatas[4] = "";
				objQCRecordDatas[5] = "";
				objQCRecordDatas[6] = "";
				objQCRecordDatas[7] = "";
				objQCRecordDatas[8] = "";
				objQCRecordDatas[9] = "";
				objQCRecordDatas[10] = "";
				objQCRecordDatas[11] = "";
				objQCRecordDatas[12] = "";
				objQCRecordDatas[13] = "";
				objQCRecordDatas[14] = "";
				objQCRecordDatas[15] = "";
				objQCRecordDatas[16] = "";
				objQCRecordDatas[17] = "";
				objQCRecordDatas[18] = "";
				objQCRecordDatas[19] = "";
				objQCRecordDatas[20] = "";
				objQCRecordDatas[21] = "";
				objQCRecordDatas[22] = "";
				objQCRecordDatas[23] = "";
				objQCRecordDatas[24] = "";
				objQCRecordDatas[25] = "";
				objQCRecordDatas[26] = "";
			}
			dtQCRecord.Rows.Add(objQCRecordDatas);
			m_rpdQCRecord.Database.Tables["QCRECORD"].SetDataSource(dtQCRecord);

			m_rpdQCRecord.Refresh();			
		}
		#endregion


		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			/*
			 * 清空界面。
			 */
			m_mthClearEvaluation();
		
			clsQCRecordInfo objMainInfo;
			clsQCRecordContentInfo objContentInfo;


			long lngRes = m_objQCRecordDomain.m_lngGetDeleteQCRecord(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(),p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"),out objMainInfo,out objContentInfo);

			if(lngRes > 0)
			{
				m_mthSetQCRecordContent(objContentInfo);

				//以下这句是用来判断是否是新添记录的m_BlnIsAddNew
//				m_trvInPatientDate.Tag = objContentInfo;

				m_blnCanDoctorTextChanged = false;

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strWriteDoctorID, out objEmpVO);
                m_objCurrentWriteDoctor = objEmpVO;
                if (objEmpVO != null)
                {
                    m_txtWriteDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_txtWriteDoctor.Tag = objEmpVO;
                }

                clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strCheckDoctorID, out objEmpVO1);
                m_objCurrentCheckDoctor = objEmpVO1;
                if (objEmpVO1 != null)
                {
                    m_txtCheckDoctor.Text = objEmpVO1.m_strLASTNAME_VCHR;
                    m_txtCheckDoctor.Tag = objEmpVO1;
                }

                clsEmrEmployeeBase_VO objEmpVO2 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strFileCheckerID, out objEmpVO2);
                m_objCurrentFileCheckDoctor = objEmpVO2;
                if (objEmpVO2 != null)
                {
                    m_txtFileChecker.Text = objEmpVO2.m_strLASTNAME_VCHR;
                    m_txtFileChecker.Tag = objEmpVO2;
                }

                objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strRecorderID, out objEmpVO);
                if (objEmpVO != null)
                {
                    m_txtEmployeeSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                    m_txtEmployeeSign.Tag = objEmpVO;
                }

				m_blnCanDoctorTextChanged = true;
				
				m_objCurrentContent= objContentInfo;//保存到内存对象
			}
			
		}

		#region 审核
		private string m_strCurrentOpenDate = "";	
	
		protected override string m_StrCurrentOpenDate
		{
			get
			{
				if(m_strCurrentOpenDate=="")
				{
					//clsPublicFunction.ShowInformationMessageBox("当前已经是空记录");
					return "";
				}
				return m_strCurrentOpenDate;

//				if(this.m_trvInPatientDate.SelectedNode==null || this.m_trvInPatientDate.SelectedNode.Tag==null)
//				{
//					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
//					return "";
//				}
//				return (string)this.m_trvInPatientDate.SelectedNode.Tag;
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


		private long m_txtFactFirstTidy_TextChanged(object sender, System.EventArgs e)
		{	
			string strName=((Control)sender).Name;
			try
			{
				decimal.Parse( ((Control)sender).Text);				
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("请只输入数字!");
				((Control)sender).Focus();
				return -1;
			}

			return 1;
		}

		/// <summary>
		/// 设置各种类型的默认值
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			//默认值
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			//自动模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);		
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            m_mthRecordChangedToSave();
            /*
             * 清空界面。如果选择的是某个入院日期，显示该日期的评分信息。
             */
            m_mthClearEvaluation();

            if (p_objSelectedSession != null)
            {
                clsQCRecordInfo objMainInfo;
                clsQCRecordContentInfo objContentInfo;

                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                long lngRes = m_objQCRecordDomain.m_lngGetQCRecord(m_objCurrentPatient, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out objMainInfo, out objContentInfo);

                if (lngRes > 0)
                {
                    m_mthSetQCRecordContent(objContentInfo);

                    m_trvInPatientDate.Tag = objContentInfo;

                    m_blnCanDoctorTextChanged = false;

                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strWriteDoctorID, out objEmpVO);
                    m_objCurrentWriteDoctor = objEmpVO;
                    if (objEmpVO != null)
                    {
                        m_txtWriteDoctor.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtWriteDoctor.Tag = objEmpVO;
                    }

                    clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strCheckDoctorID, out objEmpVO1);
                    m_objCurrentCheckDoctor = objEmpVO1;
                    if (objEmpVO1 != null)
                    {
                        m_txtCheckDoctor.Text = objEmpVO1.m_strLASTNAME_VCHR;
                        m_txtCheckDoctor.Tag = objEmpVO1;
                    }

                    clsEmrEmployeeBase_VO objEmpVO2 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strFileCheckerID, out objEmpVO2);
                    m_objCurrentFileCheckDoctor = objEmpVO2;
                    if (objEmpVO2 != null)
                    {
                        m_txtFileChecker.Text = objEmpVO2.m_strLASTNAME_VCHR;
                        m_txtFileChecker.Tag = objEmpVO2;
                    }

                    objEmployeeSign.m_lngGetEmpByNO(objContentInfo.m_strRecorderID, out objEmpVO);
                    if (objEmpVO != null)
                    {
                        m_txtEmployeeSign.Text = objEmpVO.m_strLASTNAME_VCHR;
                        m_txtEmployeeSign.Tag = objEmpVO;
                    }

                    m_blnCanDoctorTextChanged = true;

                    m_objCurrentContent = objContentInfo;//保存到内存对象	

                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);

                    m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;
                }
                else
                {
                    m_mthSetDefaultValue(m_objCurrentPatient);
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            else
            {
                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }

            m_mthAddFormStatusForClosingSave();
        }
	}
}

