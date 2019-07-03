using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using System.Data;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	/// <summary>
	/// 爱婴区婴儿评估表
	/// </summary>
	public class frmAYQBabyAssessmentRecord : iCare.frmBaseCaseHistory
	{
		#region 控件
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBabySex;
        private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem m_mniAddBabyCircsRecord;
		private System.Windows.Forms.MenuItem m_mmiModifyBabyCircsRecord;
		private System.Windows.Forms.MenuItem m_mmiDelBabyCircsRecord;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ContextMenu m_ctmRecordControl;

		#endregion


        private bool m_blnCanShowNewForm = true;
		private string m_strCurrentOpenDate = "";
        private new clsAYQBabyAssessmentContent_EspRecord m_objCurrentRecordContent;
		private new clsAYQBabyAssessmentContentDomain m_objDomain;
		private clsEmployeeSignTool m_objSignTool;
        private clsEmployeeSignTool m_objSignTool1;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private TabPage tabPage2;
        protected com.digitalwave.controls.ctlRichTextBox m_txtEspRecord;
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordDateofDay;
        private cltDataGridDSTRichTextBox m_dtcFacecolor;
        private cltDataGridDSTRichTextBox m_dtcRespiration;
        private cltDataGridDSTRichTextBox m_dtcReaction;
        private cltDataGridDSTRichTextBox m_dtcTakeFood;
        private cltDataGridDSTRichTextBox m_dtcArmpitWet;
        private cltDataGridDSTRichTextBox m_dtcDerm;
        private cltDataGridDSTRichTextBox m_dtcAurigo;
        private cltDataGridDSTRichTextBox m_dtcUmbilicalRegion;
        private cltDataGridDSTRichTextBox m_dtcLimbActivity;
        private cltDataGridDSTRichTextBox m_dtcStool;
        private cltDataGridDSTRichTextBox m_dtcUrine;
        private System.Windows.Forms.DataGridTextBoxColumn clmRecordSign;
        private TabPage tabPage1;
        protected DataGrid m_dtgRecord;
        private TabControl tabControl1;
        private DataGridTableStyle dataGridTableStyle1;
        private Label label4;
        protected com.digitalwave.controls.ctlRichTextBox m_txtEspRecord4;
        private Label label3;
        protected com.digitalwave.controls.ctlRichTextBox m_txtEspRecord3;
        private Label label2;
        protected com.digitalwave.controls.ctlRichTextBox m_txtEspRecord2;
        private Label label1;
        private PinkieControls.ButtonXP m_cmdDoctorSign;
        private TextBox m_txtDoctorSign;
        private Label label40;
        public ctlTimePicker m_dtpRecordTime;
        private PinkieControls.ButtonXP buttonXP3;
        private TextBox textBox3;
        private PinkieControls.ButtonXP buttonXP2;
        private TextBox textBox2;
        private PinkieControls.ButtonXP buttonXP1;
        private Label label7;
        private TextBox textBox1;
        private Label label6;
        public ctlTimePicker ctlTimePicker3;
        private Label label5;
        public ctlTimePicker ctlTimePicker2;
        public ctlTimePicker ctlTimePicker1;
		/// <summary>
		/// 文字栏字体
		/// </summary>
		protected virtual Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
		}

		private DataTable m_dtbRecords;
        public frmAYQBabyAssessmentRecord()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_dtbRecords = new DataTable("RecordDetail");
			this.m_dtgRecord.HeaderFont = m_FntHeaderFont;
			m_objDomain = new clsAYQBabyAssessmentContentDomain();

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(buttonXP1, textBox1, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(buttonXP2, textBox2, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(buttonXP3, textBox3, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("入院时间");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAYQBabyAssessmentRecord));
            this.m_cboBabySex = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_ctmRecordControl = new System.Windows.Forms.ContextMenu();
            this.m_mniAddBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.m_mmiModifyBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.m_mmiDelBabyCircsRecord = new System.Windows.Forms.MenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_txtEspRecord4 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEspRecord3 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEspRecord2 = new com.digitalwave.controls.ctlRichTextBox();
            this.m_txtEspRecord = new com.digitalwave.controls.ctlRichTextBox();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonXP2 = new PinkieControls.ButtonXP();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.ctlTimePicker3 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.ctlTimePicker2 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.ctlTimePicker1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.m_dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_dtgRecord = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.clmRecordDateofDay = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcFacecolor = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRespiration = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcReaction = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTakeFood = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcArmpitWet = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcDerm = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcAurigo = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUmbilicalRegion = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcLimbActivity = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcStool = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcUrine = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmRecordSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_pnlNewBase.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecord)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Visible = false;
            // 
            // trvTime
            // 
            this.trvTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(20, 130);
            treeNode1.Name = "";
            treeNode1.Text = "入院时间";
            this.trvTime.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.trvTime.Visible = false;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(90, 72);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(10, 76);
            this.lblCreateDate.Text = "出生时间:";
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(120, 200);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(168, 200);
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(456, 200);
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(408, 200);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(432, 192);
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(368, 192);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Visible = false;
            // 
            // lblNation
            // 
            this.lblNation.Location = new System.Drawing.Point(522, 127);
            this.lblNation.Visible = false;
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(564, 127);
            this.m_lblNation.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(544, 160);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(632, 160);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(405, 136);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(390, 173);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(568, 136);
            this.lblNameTitle.Size = new System.Drawing.Size(70, 14);
            this.lblNameTitle.Text = "母亲姓名:";
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(504, 44);
            this.lblSexTitle.Size = new System.Drawing.Size(70, 14);
            this.lblSexTitle.Text = "婴儿性别:";
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(584, 160);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(212, 173);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(452, 145);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(452, 171);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(648, 132);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(452, 132);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(262, 169);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(622, 191);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(452, 187);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(262, 130);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(212, 130);
            this.lblDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(528, 132);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(156, 128);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(618, 122);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(704, 72);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(668, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(798, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(796, 29);
            // 
            // m_cboBabySex
            // 
            this.m_cboBabySex.AccessibleDescription = "婴儿性别";
            this.m_cboBabySex.BackColor = System.Drawing.Color.White;
            this.m_cboBabySex.BorderColor = System.Drawing.Color.Black;
            this.m_cboBabySex.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboBabySex.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboBabySex.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboBabySex.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBabySex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboBabySex.ForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.ListBackColor = System.Drawing.Color.White;
            this.m_cboBabySex.ListForeColor = System.Drawing.Color.Black;
            this.m_cboBabySex.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboBabySex.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboBabySex.Location = new System.Drawing.Point(575, 40);
            this.m_cboBabySex.m_BlnEnableItemEventMenu = true;
            this.m_cboBabySex.Name = "m_cboBabySex";
            this.m_cboBabySex.SelectedIndex = -1;
            this.m_cboBabySex.SelectedItem = null;
            this.m_cboBabySex.SelectionStart = 0;
            this.m_cboBabySex.Size = new System.Drawing.Size(72, 23);
            this.m_cboBabySex.TabIndex = 10000083;
            this.m_cboBabySex.TextBackColor = System.Drawing.Color.White;
            this.m_cboBabySex.TextForeColor = System.Drawing.Color.Black;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // m_ctmRecordControl
            // 
            this.m_ctmRecordControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniAddBabyCircsRecord,
            this.m_mmiModifyBabyCircsRecord,
            this.m_mmiDelBabyCircsRecord});
            this.m_ctmRecordControl.Popup += new System.EventHandler(this.ctmRecordControl_Popup);
            // 
            // m_mniAddBabyCircsRecord
            // 
            this.m_mniAddBabyCircsRecord.Index = 0;
            this.m_mniAddBabyCircsRecord.Text = "新增评估内容";
            this.m_mniAddBabyCircsRecord.Click += new System.EventHandler(this.m_mniAddBabyCircsRecord_Click);
            // 
            // m_mmiModifyBabyCircsRecord
            // 
            this.m_mmiModifyBabyCircsRecord.Index = 1;
            this.m_mmiModifyBabyCircsRecord.Text = "修改评估内容";
            this.m_mmiModifyBabyCircsRecord.Click += new System.EventHandler(this.m_mmiModifyBabyCircsRecord_Click);
            // 
            // m_mmiDelBabyCircsRecord
            // 
            this.m_mmiDelBabyCircsRecord.Index = 2;
            this.m_mmiDelBabyCircsRecord.Text = "删除评估内容";
            this.m_mmiDelBabyCircsRecord.Click += new System.EventHandler(this.m_mmiDelBabyCircsRecord_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_txtEspRecord4);
            this.tabPage2.Controls.Add(this.m_txtEspRecord3);
            this.tabPage2.Controls.Add(this.m_txtEspRecord2);
            this.tabPage2.Controls.Add(this.m_txtEspRecord);
            this.tabPage2.Controls.Add(this.buttonXP3);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.buttonXP2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.buttonXP1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.m_cmdDoctorSign);
            this.tabPage2.Controls.Add(this.ctlTimePicker3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ctlTimePicker2);
            this.tabPage2.Controls.Add(this.m_txtDoctorSign);
            this.tabPage2.Controls.Add(this.ctlTimePicker1);
            this.tabPage2.Controls.Add(this.label40);
            this.tabPage2.Controls.Add(this.m_dtpRecordTime);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(784, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "特殊记录";
            // 
            // m_txtEspRecord4
            // 
            this.m_txtEspRecord4.AccessibleDescription = "4";
            this.m_txtEspRecord4.BackColor = System.Drawing.Color.White;
            this.m_txtEspRecord4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEspRecord4.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtEspRecord4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEspRecord4.Location = new System.Drawing.Point(88, 347);
            this.m_txtEspRecord4.m_BlnIgnoreUserInfo = false;
            this.m_txtEspRecord4.m_BlnPartControl = false;
            this.m_txtEspRecord4.m_BlnReadOnly = false;
            this.m_txtEspRecord4.m_BlnUnderLineDST = false;
            this.m_txtEspRecord4.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEspRecord4.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEspRecord4.m_IntCanModifyTime = 6;
            this.m_txtEspRecord4.m_IntPartControlLength = 0;
            this.m_txtEspRecord4.m_IntPartControlStartIndex = 0;
            this.m_txtEspRecord4.m_StrUserID = "";
            this.m_txtEspRecord4.m_StrUserName = "";
            this.m_txtEspRecord4.Name = "m_txtEspRecord4";
            this.m_txtEspRecord4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtEspRecord4.Size = new System.Drawing.Size(684, 76);
            this.m_txtEspRecord4.TabIndex = 10000099;
            this.m_txtEspRecord4.Tag = "8";
            this.m_txtEspRecord4.Text = "";
            // 
            // m_txtEspRecord3
            // 
            this.m_txtEspRecord3.AccessibleDescription = "特殊记录3";
            this.m_txtEspRecord3.BackColor = System.Drawing.Color.White;
            this.m_txtEspRecord3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEspRecord3.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtEspRecord3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEspRecord3.Location = new System.Drawing.Point(88, 231);
            this.m_txtEspRecord3.m_BlnIgnoreUserInfo = false;
            this.m_txtEspRecord3.m_BlnPartControl = false;
            this.m_txtEspRecord3.m_BlnReadOnly = false;
            this.m_txtEspRecord3.m_BlnUnderLineDST = false;
            this.m_txtEspRecord3.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEspRecord3.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEspRecord3.m_IntCanModifyTime = 6;
            this.m_txtEspRecord3.m_IntPartControlLength = 0;
            this.m_txtEspRecord3.m_IntPartControlStartIndex = 0;
            this.m_txtEspRecord3.m_StrUserID = "";
            this.m_txtEspRecord3.m_StrUserName = "";
            this.m_txtEspRecord3.Name = "m_txtEspRecord3";
            this.m_txtEspRecord3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtEspRecord3.Size = new System.Drawing.Size(684, 73);
            this.m_txtEspRecord3.TabIndex = 10000099;
            this.m_txtEspRecord3.Tag = "8";
            this.m_txtEspRecord3.Text = "";
            // 
            // m_txtEspRecord2
            // 
            this.m_txtEspRecord2.AccessibleDescription = "特殊记录2";
            this.m_txtEspRecord2.BackColor = System.Drawing.Color.White;
            this.m_txtEspRecord2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEspRecord2.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtEspRecord2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEspRecord2.Location = new System.Drawing.Point(88, 118);
            this.m_txtEspRecord2.m_BlnIgnoreUserInfo = false;
            this.m_txtEspRecord2.m_BlnPartControl = false;
            this.m_txtEspRecord2.m_BlnReadOnly = false;
            this.m_txtEspRecord2.m_BlnUnderLineDST = false;
            this.m_txtEspRecord2.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEspRecord2.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEspRecord2.m_IntCanModifyTime = 6;
            this.m_txtEspRecord2.m_IntPartControlLength = 0;
            this.m_txtEspRecord2.m_IntPartControlStartIndex = 0;
            this.m_txtEspRecord2.m_StrUserID = "";
            this.m_txtEspRecord2.m_StrUserName = "";
            this.m_txtEspRecord2.Name = "m_txtEspRecord2";
            this.m_txtEspRecord2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtEspRecord2.Size = new System.Drawing.Size(684, 69);
            this.m_txtEspRecord2.TabIndex = 10000099;
            this.m_txtEspRecord2.Tag = "8";
            this.m_txtEspRecord2.Text = "";
            // 
            // m_txtEspRecord
            // 
            this.m_txtEspRecord.AccessibleDescription = "特殊记录";
            this.m_txtEspRecord.BackColor = System.Drawing.Color.White;
            this.m_txtEspRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtEspRecord.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtEspRecord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtEspRecord.Location = new System.Drawing.Point(88, 9);
            this.m_txtEspRecord.m_BlnIgnoreUserInfo = false;
            this.m_txtEspRecord.m_BlnPartControl = false;
            this.m_txtEspRecord.m_BlnReadOnly = false;
            this.m_txtEspRecord.m_BlnUnderLineDST = false;
            this.m_txtEspRecord.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtEspRecord.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtEspRecord.m_IntCanModifyTime = 6;
            this.m_txtEspRecord.m_IntPartControlLength = 0;
            this.m_txtEspRecord.m_IntPartControlStartIndex = 0;
            this.m_txtEspRecord.m_StrUserID = "";
            this.m_txtEspRecord.m_StrUserName = "";
            this.m_txtEspRecord.Name = "m_txtEspRecord";
            this.m_txtEspRecord.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtEspRecord.Size = new System.Drawing.Size(684, 67);
            this.m_txtEspRecord.TabIndex = 10000099;
            this.m_txtEspRecord.Tag = "8";
            this.m_txtEspRecord.Text = "";
            // 
            // buttonXP3
            // 
            this.buttonXP3.AccessibleDescription = "签名4(cmd)";
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(192, 429);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(63, 29);
            this.buttonXP3.TabIndex = 10000119;
            this.buttonXP3.Tag = "1";
            this.buttonXP3.Text = "签 名:";
            // 
            // textBox3
            // 
            this.textBox3.AccessibleDescription = "签名4(txt)";
            this.textBox3.Location = new System.Drawing.Point(268, 433);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 10000120;
            // 
            // buttonXP2
            // 
            this.buttonXP2.AccessibleDescription = "签名3(cmd)";
            this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP2.DefaultScheme = true;
            this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP2.Hint = "";
            this.buttonXP2.Location = new System.Drawing.Point(192, 310);
            this.buttonXP2.Name = "buttonXP2";
            this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP2.Size = new System.Drawing.Size(63, 29);
            this.buttonXP2.TabIndex = 10000119;
            this.buttonXP2.Tag = "1";
            this.buttonXP2.Text = "签 名:";
            // 
            // textBox2
            // 
            this.textBox2.AccessibleDescription = "签名3(txt)";
            this.textBox2.Location = new System.Drawing.Point(268, 314);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 10000120;
            // 
            // buttonXP1
            // 
            this.buttonXP1.AccessibleDescription = "签名2(cmd)";
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(192, 194);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(63, 29);
            this.buttonXP1.TabIndex = 10000119;
            this.buttonXP1.Tag = "1";
            this.buttonXP1.Text = "签 名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(417, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 10000117;
            this.label7.Text = "日期:";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleDescription = "签名2(txt)";
            this.textBox1.Location = new System.Drawing.Point(268, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 10000120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(417, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 10000117;
            this.label6.Text = "日期:";
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.AccessibleDescription = "签名(cmd)";
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(192, 81);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(63, 29);
            this.m_cmdDoctorSign.TabIndex = 10000119;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "签 名:";
            // 
            // ctlTimePicker3
            // 
            this.ctlTimePicker3.AccessibleDescription = "记录日期";
            this.ctlTimePicker3.BorderColor = System.Drawing.Color.Black;
            this.ctlTimePicker3.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.ctlTimePicker3.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.ctlTimePicker3.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.ctlTimePicker3.DropButtonForeColor = System.Drawing.Color.Black;
            this.ctlTimePicker3.flatFont = new System.Drawing.Font("宋体", 12F);
            this.ctlTimePicker3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctlTimePicker3.Location = new System.Drawing.Point(462, 431);
            this.ctlTimePicker3.m_BlnOnlyTime = false;
            this.ctlTimePicker3.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.ctlTimePicker3.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ctlTimePicker3.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ctlTimePicker3.Name = "ctlTimePicker3";
            this.ctlTimePicker3.ReadOnly = false;
            this.ctlTimePicker3.Size = new System.Drawing.Size(215, 22);
            this.ctlTimePicker3.TabIndex = 10000118;
            this.ctlTimePicker3.TextBackColor = System.Drawing.Color.White;
            this.ctlTimePicker3.TextForeColor = System.Drawing.Color.Black;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(417, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10000117;
            this.label5.Text = "日期:";
            // 
            // ctlTimePicker2
            // 
            this.ctlTimePicker2.AccessibleDescription = "记录日期";
            this.ctlTimePicker2.BorderColor = System.Drawing.Color.Black;
            this.ctlTimePicker2.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.ctlTimePicker2.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.ctlTimePicker2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.ctlTimePicker2.DropButtonForeColor = System.Drawing.Color.Black;
            this.ctlTimePicker2.flatFont = new System.Drawing.Font("宋体", 12F);
            this.ctlTimePicker2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctlTimePicker2.Location = new System.Drawing.Point(462, 312);
            this.ctlTimePicker2.m_BlnOnlyTime = false;
            this.ctlTimePicker2.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.ctlTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ctlTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ctlTimePicker2.Name = "ctlTimePicker2";
            this.ctlTimePicker2.ReadOnly = false;
            this.ctlTimePicker2.Size = new System.Drawing.Size(215, 22);
            this.ctlTimePicker2.TabIndex = 10000118;
            this.ctlTimePicker2.TextBackColor = System.Drawing.Color.White;
            this.ctlTimePicker2.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleDescription = "签名(txt)";
            this.m_txtDoctorSign.Location = new System.Drawing.Point(268, 85);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtDoctorSign.TabIndex = 10000120;
            // 
            // ctlTimePicker1
            // 
            this.ctlTimePicker1.AccessibleDescription = "记录日期";
            this.ctlTimePicker1.BorderColor = System.Drawing.Color.Black;
            this.ctlTimePicker1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.ctlTimePicker1.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.ctlTimePicker1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.ctlTimePicker1.DropButtonForeColor = System.Drawing.Color.Black;
            this.ctlTimePicker1.flatFont = new System.Drawing.Font("宋体", 12F);
            this.ctlTimePicker1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctlTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ctlTimePicker1.Location = new System.Drawing.Point(462, 196);
            this.ctlTimePicker1.m_BlnOnlyTime = false;
            this.ctlTimePicker1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.ctlTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.ctlTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.ctlTimePicker1.Name = "ctlTimePicker1";
            this.ctlTimePicker1.ReadOnly = false;
            this.ctlTimePicker1.Size = new System.Drawing.Size(215, 22);
            this.ctlTimePicker1.TabIndex = 10000118;
            this.ctlTimePicker1.TextBackColor = System.Drawing.Color.White;
            this.ctlTimePicker1.TextForeColor = System.Drawing.Color.Black;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label40.Location = new System.Drawing.Point(417, 87);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 10000117;
            this.label40.Text = "日期:";
            // 
            // m_dtpRecordTime
            // 
            this.m_dtpRecordTime.AccessibleDescription = "记录日期";
            this.m_dtpRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordTime.Location = new System.Drawing.Point(462, 83);
            this.m_dtpRecordTime.m_BlnOnlyTime = false;
            this.m_dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordTime.Name = "m_dtpRecordTime";
            this.m_dtpRecordTime.ReadOnly = false;
            this.m_dtpRecordTime.Size = new System.Drawing.Size(215, 22);
            this.m_dtpRecordTime.TabIndex = 10000118;
            this.m_dtpRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 10000100;
            this.label4.Text = "特殊记录4：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 10000100;
            this.label3.Text = "特殊记录3：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 10000100;
            this.label2.Text = "特殊记录2：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 10000100;
            this.label1.Text = "特殊记录1：";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_dtgRecord);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(784, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "评估项目";
            // 
            // m_dtgRecord
            // 
            this.m_dtgRecord.AccessibleName = "DataGrid";
            this.m_dtgRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_dtgRecord.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtgRecord.CaptionText = "评估项目";
            this.m_dtgRecord.CaptionVisible = false;
            this.m_dtgRecord.DataMember = "";
            this.m_dtgRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgRecord.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_dtgRecord.HeaderFont = new System.Drawing.Font("宋体", 40F);
            this.m_dtgRecord.HeaderForeColor = System.Drawing.SystemColors.Window;
            this.m_dtgRecord.Location = new System.Drawing.Point(5, 8);
            this.m_dtgRecord.Name = "m_dtgRecord";
            this.m_dtgRecord.ParentRowsForeColor = System.Drawing.Color.White;
            this.m_dtgRecord.PreferredRowHeight = 200;
            this.m_dtgRecord.RowHeaderWidth = 15;
            this.m_dtgRecord.Size = new System.Drawing.Size(768, 513);
            this.m_dtgRecord.TabIndex = 10000098;
            this.m_dtgRecord.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.m_dtgRecord;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.clmRecordDateofDay,
            this.m_dtcFacecolor,
            this.m_dtcRespiration,
            this.m_dtcReaction,
            this.m_dtcTakeFood,
            this.m_dtcArmpitWet,
            this.m_dtcDerm,
            this.m_dtcAurigo,
            this.m_dtcUmbilicalRegion,
            this.m_dtcLimbActivity,
            this.m_dtcStool,
            this.m_dtcUrine,
            this.clmRecordSign});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "RecordDetail";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // clmRecordDateofDay
            // 
            this.clmRecordDateofDay.Format = "";
            this.clmRecordDateofDay.FormatInfo = null;
            this.clmRecordDateofDay.MappingName = "RecordDateofDay";
            this.clmRecordDateofDay.Width = 120;
            // 
            // m_dtcFacecolor
            // 
            this.m_dtcFacecolor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFacecolor.m_BlnGobleSet = true;
            this.m_dtcFacecolor.m_BlnUnderLineDST = false;
            this.m_dtcFacecolor.MappingName = "Facecolor";
            this.m_dtcFacecolor.Width = 60;
            // 
            // m_dtcRespiration
            // 
            this.m_dtcRespiration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRespiration.m_BlnGobleSet = true;
            this.m_dtcRespiration.m_BlnUnderLineDST = false;
            this.m_dtcRespiration.MappingName = "Respiration";
            this.m_dtcRespiration.Width = 60;
            // 
            // m_dtcReaction
            // 
            this.m_dtcReaction.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcReaction.m_BlnGobleSet = true;
            this.m_dtcReaction.m_BlnUnderLineDST = false;
            this.m_dtcReaction.MappingName = "Reaction";
            this.m_dtcReaction.Width = 60;
            // 
            // m_dtcTakeFood
            // 
            this.m_dtcTakeFood.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTakeFood.m_BlnGobleSet = true;
            this.m_dtcTakeFood.m_BlnUnderLineDST = false;
            this.m_dtcTakeFood.MappingName = "TakeFood";
            this.m_dtcTakeFood.Width = 60;
            // 
            // m_dtcArmpitWet
            // 
            this.m_dtcArmpitWet.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcArmpitWet.m_BlnGobleSet = true;
            this.m_dtcArmpitWet.m_BlnUnderLineDST = false;
            this.m_dtcArmpitWet.MappingName = "ArmpitWet";
            this.m_dtcArmpitWet.Width = 60;
            // 
            // m_dtcDerm
            // 
            this.m_dtcDerm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcDerm.m_BlnGobleSet = true;
            this.m_dtcDerm.m_BlnUnderLineDST = false;
            this.m_dtcDerm.MappingName = "Derm";
            this.m_dtcDerm.Width = 60;
            // 
            // m_dtcAurigo
            // 
            this.m_dtcAurigo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcAurigo.m_BlnGobleSet = true;
            this.m_dtcAurigo.m_BlnUnderLineDST = false;
            this.m_dtcAurigo.MappingName = "Aurigo";
            this.m_dtcAurigo.Width = 60;
            // 
            // m_dtcUmbilicalRegion
            // 
            this.m_dtcUmbilicalRegion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUmbilicalRegion.m_BlnGobleSet = true;
            this.m_dtcUmbilicalRegion.m_BlnUnderLineDST = false;
            this.m_dtcUmbilicalRegion.MappingName = "UmbilicalRegion";
            this.m_dtcUmbilicalRegion.Width = 60;
            // 
            // m_dtcLimbActivity
            // 
            this.m_dtcLimbActivity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcLimbActivity.m_BlnGobleSet = true;
            this.m_dtcLimbActivity.m_BlnUnderLineDST = false;
            this.m_dtcLimbActivity.MappingName = "LimbActivity";
            this.m_dtcLimbActivity.Width = 75;
            // 
            // m_dtcStool
            // 
            this.m_dtcStool.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcStool.m_BlnGobleSet = true;
            this.m_dtcStool.m_BlnUnderLineDST = false;
            this.m_dtcStool.MappingName = "Stool";
            this.m_dtcStool.Width = 60;
            // 
            // m_dtcUrine
            // 
            this.m_dtcUrine.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcUrine.m_BlnGobleSet = true;
            this.m_dtcUrine.m_BlnUnderLineDST = false;
            this.m_dtcUrine.MappingName = "Urine";
            this.m_dtcUrine.Width = 60;
            // 
            // clmRecordSign
            // 
            this.clmRecordSign.Format = "";
            this.clmRecordSign.FormatInfo = null;
            this.clmRecordSign.MappingName = "Sign";
            this.clmRecordSign.Width = 80;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(16, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 551);
            this.tabControl1.TabIndex = 10000084;
            // 
            // frmAYQBabyAssessmentRecord
            // 
            this.ClientSize = new System.Drawing.Size(824, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.m_cboBabySex);
            this.Name = "frmAYQBabyAssessmentRecord";
            this.Text = "爱婴区婴儿评估表";
            this.Load += new System.EventHandler(this.frmAYQBabyAssessmentRecord_Load);
            this.Controls.SetChildIndex(this.m_cboBabySex, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblLinkMan, 0);
            this.Controls.SetChildIndex(this.lblMarriaged, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecord)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void m_mniAddBabyCircsRecord_Click(object sender, System.EventArgs e)
		{		
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }

			if(m_objCurrentPatient == null)
				return;
            //dtSelectedInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			string strOpenDate = "";
            frmAYQBabyAssessmentRecord_Rec frm = new frmAYQBabyAssessmentRecord_Rec(true, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
			frm.StartPosition = FormStartPosition.CenterParent;
			if(frm.ShowDialog() == DialogResult.Yes)
			{
                clsAYQBabyAssessmentContent[] objCircsRecordArr;
				long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                if (strOpenDate == "")
                    strOpenDate = "1900-01-01 00:00:00";
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse(strOpenDate));
			}
		}

		private void m_mmiDelBabyCircsRecord_Click(object sender, System.EventArgs e)
		{
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
			DateTime dtOpen = DateTime.MinValue;
			DateTime dtModify = DateTime.MinValue;

            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
			try
			{
				dtOpen = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1]);
				dtModify = Convert.ToDateTime(m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][2]);
			}
			catch
			{
				MDIParent.ShowInformationMessageBox("请先选择一条记录");
				return;
			}
			//传递参数
			int intSelectedRecordStartRow =m_dtgRecord.CurrentCell.RowNumber;
			//确认
			if(MessageBox.Show("确认要删除选中的病情记录内容？","删除提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.Cancel)
				return;

			//打开窗体
			//删除
            clsAYQBabyAssessmentContent objDelRecord = new clsAYQBabyAssessmentContent();
            objDelRecord.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objDelRecord.m_dtmOpenDate = dtOpen;
			objDelRecord.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
			objDelRecord.m_strDeActivedOperatorID = MDIParent.OperatorID;
			objDelRecord.m_dtmDeActivedDate = DateTime.Now;
			objDelRecord.m_dtmModifyDate = dtModify;

			long lngRes=m_objDomain.m_lngDeleteCircsRecord(objDelRecord);
			//更新
			if (lngRes>0)
			{
                clsAYQBabyAssessmentContent[] objCircsRecordArr;
                lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_dtbRecords.Clear();
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));
			}
		}

		private void m_mmiModifyBabyCircsRecord_Click(object sender, System.EventArgs e)
		{
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }
			if(m_objCurrentPatient == null)
				return;
            //dtSelectedInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			string strOpenDate =  m_dtbRecords.Rows[m_dtgRecord.CurrentRowIndex][1].ToString();;
            frmAYQBabyAssessmentRecord_Rec frm = new frmAYQBabyAssessmentRecord_Rec(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate);
			frm.StartPosition = FormStartPosition.CenterParent;
			if(frm.ShowDialog() == DialogResult.Yes)
			{
                clsAYQBabyAssessmentContent[] objCircsRecordArr;
				long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out objCircsRecordArr);

                //设置内容到DataTable
                object[][] objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

                //添加内容到DataTable
                m_mthAddDataToDataTable(objDataArr, DateTime.Parse("1900-01-01 00:00:00"));
                m_mthDoAfterSelect();
			}
		}

        private void frmAYQBabyAssessmentRecord_Load(object sender, System.EventArgs e)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			m_mthInitDataTable(m_dtbRecords);
			m_dtgRecord.DataSource = m_dtbRecords;			
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthSetAllDataGridTextBoxColum();
			m_dtmPreRecordDate = DateTime.MinValue;
		}

		private void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
            //存放记录时间的字符串
            p_dtbRecordTable.Columns.Add("CreateDate");//0
            //存放记录的OpenDate字符串
            p_dtbRecordTable.Columns.Add("OpenDate");  //1
            //存放记录的ModifyDate字符串
            p_dtbRecordTable.Columns.Add("ModifyDate"); //2
            DataColumn dc1 = p_dtbRecordTable.Columns.Add("RecordDateofDay");//3
            dc1.DefaultValue = "";
            p_dtbRecordTable.Columns.Add("Facecolor", typeof(clsDSTRichTextBoxValue));//4
            p_dtbRecordTable.Columns.Add("Respiration", typeof(clsDSTRichTextBoxValue));//5
            p_dtbRecordTable.Columns.Add("Reaction", typeof(clsDSTRichTextBoxValue));//6
            p_dtbRecordTable.Columns.Add("TakeFood", typeof(clsDSTRichTextBoxValue));//7
            p_dtbRecordTable.Columns.Add("ArmpitWet", typeof(clsDSTRichTextBoxValue));//8
            p_dtbRecordTable.Columns.Add("Derm", typeof(clsDSTRichTextBoxValue));//9
            p_dtbRecordTable.Columns.Add("Aurigo", typeof(clsDSTRichTextBoxValue));//10
            p_dtbRecordTable.Columns.Add("UmbilicalRegion", typeof(clsDSTRichTextBoxValue));//11
            p_dtbRecordTable.Columns.Add("LimbActivity", typeof(clsDSTRichTextBoxValue));//12
            p_dtbRecordTable.Columns.Add("Stool", typeof(clsDSTRichTextBoxValue));//13
            p_dtbRecordTable.Columns.Add("Urine", typeof(clsDSTRichTextBoxValue));//14
            DataColumn dc3 = p_dtbRecordTable.Columns.Add("Sign");//15
            dc3.DefaultValue = "";
            //设置文字栏
            this.clmRecordDateofDay.HeaderText = "日期";
            this.m_dtcFacecolor.HeaderText = "面色";
            this.m_dtcRespiration.HeaderText = "呼吸";
            this.m_dtcReaction.HeaderText = "反应";
            this.m_dtcTakeFood.HeaderText = "进食";
            this.m_dtcArmpitWet.HeaderText = "腋温";
            this.m_dtcDerm.HeaderText = "皮肤";
            this.m_dtcAurigo.HeaderText = "黄疸";
            this.m_dtcUmbilicalRegion.HeaderText = "脐部";
            this.m_dtcLimbActivity.HeaderText = "四肢行动";
            this.m_dtcStool.HeaderText = "大便";
            this.m_dtcUrine.HeaderText = "小便";
            this.clmRecordSign.HeaderText = "  签 名";
		}

		private void m_mthSetAllDataGridTextBoxColum()
		{
            m_mthSetControl(clmRecordDateofDay);
            m_mthSetControl(m_dtcFacecolor);
            m_mthSetControl(m_dtcRespiration);
            m_mthSetControl(m_dtcReaction);
            m_mthSetControl(m_dtcTakeFood);
            m_mthSetControl(m_dtcArmpitWet);
            m_mthSetControl(m_dtcDerm);
            m_mthSetControl(m_dtcAurigo);
            m_mthSetControl(m_dtcUmbilicalRegion);
            m_mthSetControl(m_dtcLimbActivity);
            m_mthSetControl(m_dtcStool);
            m_mthSetControl(m_dtcUrine);
            m_mthSetControl(clmRecordSign);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		private void m_mthSetControl(DataGridTextBoxColumn p_objControl)
		{
			Control m_objControl;
			m_objControl = (DataGridTextBox)p_objControl.TextBox;
			m_objControl.ContextMenu = m_ctmRecordControl;
			m_objControl.DoubleClick += new EventHandler(m_mthTxtDoubleClick);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		private void m_mthSetControl(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox p_objControl)
		{
			p_objControl.m_RtbBase.ContextMenu = m_ctmRecordControl;
			p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBox_MouseDown);
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private  void m_mthTxtDoubleClick(object sender,EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
				if(intSelectedRecordStartRow < 0)
					return;
				string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
				m_mthModifyRecord(DateTime.Parse(strOpenDate));
			}
			catch(Exception exp)
			{
				string strErrorMessage=exp.Message;
			}
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cltDataGridDSTRichTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				if(e.Clicks > 1)
				{
					int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecord.CurrentCell.RowNumber);
					if(intSelectedRecordStartRow < 0)
						return;
					string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][1].ToString();
					m_mthModifyRecord(DateTime.Parse(strOpenDate));
				}
			}
			catch
			{
				
			}
		}

		/// <summary>
		/// 处理之前判断DataGrid与DataTable的关系
		/// </summary>
		/// <returns></returns>
		protected virtual bool m_blnCheckDataGridCurrentRow()
		{
			try
			{
				if(m_dtbRecords.Rows.Count <=0)
					return false;
				if(m_dtgRecord.CurrentCell.RowNumber  >= m_dtbRecords.Rows.Count)
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}

		}

		/// <summary>
		///  获取用户选择的记录的开始行位置
		/// </summary>
		/// <param name="p_intSelectRowIndex">返回索引</param>
		/// <returns></returns>
		protected virtual int m_intGetRecordStartRow(int p_intSelectRowIndex)
		{
			//以p_intSelectRow开始，从后往前循环DataTable
			//如果当前记录的第一个字段不为空
			//返回索引
			for(int i1=p_intSelectRowIndex;i1>=0;i1--)
			{
				if(m_dtbRecords.Rows[i1][1].ToString() != "")
				{
					return i1;
				}
			}
			return -1;
		}

		protected void m_mthModifyRecord(DateTime p_dtmOpenRecordTime)
		{
			if(!m_blnCanShowNewForm)
				return;

			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            //try
            //{
            //    dtSelectedInPatientDate = DateTime.Parse(trvTime.SelectedNode.Text.Trim());
            //}
            //catch
            //{
            //    m_dtbRecords.Clear();
            //}
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
            }
			//获取添加记录的窗体
			string strOpenDate = p_dtmOpenRecordTime.ToString("yyyy-MM-dd HH:mm:ss");
            frmAYQBabyAssessmentRecord_Rec frmAddNewForm = new frmAYQBabyAssessmentRecord_Rec(false, m_objCurrentPatient.m_StrInPatientID, dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtpCreateDate.Text, ref strOpenDate); 

			m_mthShowSubForm(frmAddNewForm);
			
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
		}

		protected void m_mthShowSubForm(Form p_frmSubForm)
		{
			p_frmSubForm.Closed += new EventHandler(m_mthSubFormClosed);
			m_blnCanShowNewForm = false;
            m_frmCurrentSub = (frmAYQBabyAssessmentRecord_Rec)p_frmSubForm;

			p_frmSubForm.TopMost = true;
			p_frmSubForm.Show();				
		}

        private frmAYQBabyAssessmentRecord_Rec m_frmCurrentSub = null;
		private void m_mthSubFormClosed(object p_objSender,EventArgs p_objArg)
		{
            frmAYQBabyAssessmentRecord_Rec frmAddNewForm = (frmAYQBabyAssessmentRecord_Rec)p_objSender; 			

			m_blnCanShowNewForm = true;
			m_frmCurrentSub = null;
		}

		// 获取病程记录的领域层实例
		protected override clsBaseCaseHistoryDomain  m_objGetDomain()
		{
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.AYQBabyAssessmentRecord);
		}

		private void ctmRecordControl_Popup(object sender, System.EventArgs e)
		{
			bool blnEnable=true;
			m_mniAddBabyCircsRecord.Enabled = blnEnable;
			m_mmiModifyBabyCircsRecord.Enabled = blnEnable;
			m_mmiDelBabyCircsRecord.Enabled = blnEnable;
		}

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
        //protected override string m_StrRecorder_ID
        //{
        //    get
        //    {
        //        if(m_txtCheckDocSign.Tag != null)
        //            return m_txtCheckDocSign.Tag.ToString();
        //        return "";
        //    }
        //}
		#endregion 属性

		protected override void m_mthClearRecordInfo()
		{
            m_txtDoctorSign.Text = "";
            m_dtpRecordTime.Value = DateTime.Now;
            textBox1.Text = "";
            ctlTimePicker1.Value = DateTime.Now;
            textBox2.Text = "";
            ctlTimePicker2.Value = DateTime.Now;
            textBox3.Text = "";
            ctlTimePicker3.Value = DateTime.Now;
		}

		protected override void m_mthUnEnableRichTextBox()
		{
            this.m_txtEspRecord.Text = "";
            this.m_txtEspRecord2.Text = "";
            this.m_txtEspRecord3.Text = "";
            this.m_txtEspRecord4.Text = "";
		}

		protected override void m_mthEnableRichTextBox()
		{			
			
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		// 获取选择已经删除记录的窗体标题
		public    override void m_strReloadFormTitle()
		{
		
		}
		// 是否允许修改特殊记录的记录信息。
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{

		}

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
        protected clsAYQBabyAssessmentContent_EspRecord m_objGetContentFromGUI()
        {
            clsAYQBabyAssessmentContent_EspRecord m_objContent = new clsAYQBabyAssessmentContent_EspRecord();
            try
            {
                m_objContent.m_strEspRecord = this.m_txtEspRecord.Text;
                m_objContent.m_strEspRecordXML = this.m_txtEspRecord.m_strGetXmlText();
                m_objContent.m_dtmRecordDate = this.m_dtpRecordTime.Value;
                m_objContent.m_strRecordSign = this.m_txtDoctorSign.Text;

                m_objContent.m_strEspRecord2 = this.m_txtEspRecord2.Text;
                m_objContent.m_strEspRecordXML2 = this.m_txtEspRecord2.m_strGetXmlText();
                m_objContent.m_dtmRecordDate2 = this.ctlTimePicker1.Value;
                m_objContent.m_strRecordSign2 = this.textBox1.Text;

                m_objContent.m_strEspRecord3 = this.m_txtEspRecord3.Text;
                m_objContent.m_strEspRecordXML3 = this.m_txtEspRecord3.m_strGetXmlText();
                m_objContent.m_dtmRecordDate3 = this.ctlTimePicker2.Value;
                m_objContent.m_strRecordSign3 = this.textBox2.Text;

                m_objContent.m_strEspRecord4 = this.m_txtEspRecord4.Text;
                m_objContent.m_strEspRecordXML4 = this.m_txtEspRecord4.m_strGetXmlText();
                m_objContent.m_dtmRecordDate4 = this.ctlTimePicker3.Value;
                m_objContent.m_strRecordSign4 = this.textBox3.Text;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return m_objContent;
        }

		// 把特殊记录的值显示到界面上。
        protected void m_mthSetGUIFromContent(clsAYQBabyAssessmentContent_EspRecord objContent)
		{
			if( objContent.m_strInPatientID !=null && objContent.m_strInPatientID !="")
			{
				m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
			}
			m_txtEspRecord.m_mthSetNewText(objContent.m_strEspRecord, objContent.m_strEspRecordXML);
            m_txtDoctorSign.Text = objContent.m_strRecordSign;
            m_dtpRecordTime.Value = objContent.m_dtmRecordDate;

            m_txtEspRecord2.m_mthSetNewText(objContent.m_strEspRecord2, objContent.m_strEspRecordXML2);
            textBox1.Text = objContent.m_strRecordSign2;
            ctlTimePicker1.Value = objContent.m_dtmRecordDate2;

            m_txtEspRecord3.m_mthSetNewText(objContent.m_strEspRecord3, objContent.m_strEspRecordXML3);
            textBox2.Text = objContent.m_strRecordSign3;
            ctlTimePicker2.Value = objContent.m_dtmRecordDate3;

            m_txtEspRecord4.m_mthSetNewText(objContent.m_strEspRecord4, objContent.m_strEspRecordXML4);
            textBox3.Text = objContent.m_strRecordSign4;
            ctlTimePicker3.Value = objContent.m_dtmRecordDate4;

			m_objCurrentRecordContent = objContent;

		}

		// 把选择时间记录内容重新整理为完全正确的内容。
		protected override void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
		{
		
		}		

		protected override void m_mthHandleAddRecordSucceed()
		{
			if(trvTime.SelectedNode != null)
				trvTime.SelectedNode.Tag =(string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") ;
		}

		//审核
		protected override string m_StrCurrentOpenDate
		{
			get
			{
                //if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
                //{
                //    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                //    return "";
                //}
                //return (string)this.trvTime.SelectedNode.Tag;
                if (string.IsNullOrEmpty(m_strCurrentOpenDate))
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return string.Empty;
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

		protected override void m_mthSetNewRecord()
		{
			if(m_objCurrentPatient != null)
			{			

				//默认值 m_IntCurCase
				new clsDefaultValueTool(this,m_objCurrentPatient).m_mthSetDefaultValue();				

				//设完默认值后回到光标床号
				m_txtBedNO.Focus();

			}
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
            clsAYQBabyAssessmentContent_EspRecord objContent = new clsAYQBabyAssessmentContent_EspRecord();
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue)
			{
				return ;
			}
		
			long lngRes=m_objDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"),out objContent);
			if(lngRes<=0 || objContent==null)
			{
				switch(lngRes)
				{
					case (long)(iCareData.enmOperationResult.Not_permission) :
						m_mthShowNotPermitted();break;
					case (long)(iCareData.enmOperationResult.DB_Fail) :
						m_mthShowDBError();break;
				}
				return;
			}
		}

		public	  override int m_IntFormID
		{
			get
			{
				return 82;
			}
		}

		protected new void m_mthSetSelectedRecord(clsPatient p_objPatient,
			string p_strRecordTime)
		{
			//检查参数
			if(p_objPatient==null || m_ObjCurrentEmrPatientSession == null)  
			{
				m_objCurrentRecordContent = null;
				return ;
			}

			clsBaseCaseHistoryInfo  objContent =null;  
			clsPictureBoxValue[] objPicValueArr = null;
			//获取记录

            long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_StrInPatientID, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"),/*p_strRecordTime ,*/ out objContent, out objPicValueArr);
		
			if(lngRes <= 0 || objContent == null)
			{
				m_objCurrentRecordContent = null;
				return;                            
			}
			
			//设置记录时间     
            m_objCurrentRecordContent = (clsAYQBabyAssessmentContent_EspRecord)objContent;

            m_mthSetGUIFromContent((clsAYQBabyAssessmentContent_EspRecord)objContent);
			m_mthEnableModify(false);

            m_mthSetModifyControl((clsAYQBabyAssessmentContent_EspRecord)objContent, false);			

		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
        protected void m_mthSetModifyControl(clsAYQBabyAssessmentContent_EspRecord p_objRecordContent,
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
                //m_mthSetRichTextModifyColor(this,Color.Red);
                m_mthSetRichTextModifyColor(this, Color.Black);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
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
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")			
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
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
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")
			{				
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
			{
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}	
	
		protected new long m_lngAddNewRecord()
		{
			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null || m_ObjCurrentEmrPatientSession == null)
				return (long)enmOperationResult .Parameter_Error;

			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//从界面获取记录信息
            clsAYQBabyAssessmentContent_EspRecord objContent = m_objGetContentFromGUI();     
		           
			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			string strDiseaseID = "";
			//界面输入值出错
			if(objContent == null)
				return (long)enmOperationResult.Parameter_Error;
					
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
			string strNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_dtmModifyDate =DateTime.Parse(strNow); 
			objContent.m_dtmOpenDate =DateTime.Parse(strNow); 
			objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =MDIParent.strOperatorID;
			objContent.m_dtmCreateDate=DateTime.Parse(strNow);
			 
			//保存记录
			clsPreModifyInfo p_objModifyInfo=null;

			long lngRes = m_objDomain.m_lngAddNewRecord(objContent,objPicValueArr,strDiseaseID,out p_objModifyInfo);
		     
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
			
					if((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
					{
						m_objCurrentRecordContent = objContent; 
					
						m_mthHandleAddRecordSucceed();
					}
					
					break;   
					//...
				case enmOperationResult.Record_Already_Exist:
					m_mthShowRecordTimeDouble();
					return lngRes;
			}  
			this.trvTime.ExpandAll();
			//返回结果
			return lngRes;
		}

		protected override long m_lngSubModify()
		{
			if(trvTime.Nodes[0].Nodes.Count>0 && trvTime.SelectedNode !=trvTime.Nodes[0].FirstNode)
				return 1;//窗体只读。
			//检查当前病人变量是否为null
			if(m_objCurrentPatient ==null)
				return (long)enmOperationResult .Parameter_Error ;
			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			//从界面获取记录信息
            clsAYQBabyAssessmentContent_EspRecord objContent = m_objGetContentFromGUI();     

			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			//获取病名
			string strDiseaseID = "";
		           
			//界面输入值出错           
			if(objContent == null)
				return (long)enmOperationResult .Parameter_Error;
		
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmModifyDate）
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
			objContent.m_dtmInPatientDate =m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmModifyDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			objContent.m_dtmCreateDate=m_objCurrentRecordContent.m_dtmCreateDate;
			objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =MDIParent.strOperatorID;

			//设置已有记录的开始使用时间
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;

			clsPreModifyInfo m_objModifyInfo;
			long lngRes = m_objDomain.m_lngModifyRecord(m_objCurrentRecordContent,objContent,objPicValueArr,strDiseaseID,out m_objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:

					if((enmOperationResult)lngRes == enmOperationResult.DB_Succeed)
					{
						m_objCurrentRecordContent = objContent;	
					}
					break;   
					//...
			}  
			//展开树显示所有时间节点。
			//			trvTime.ExpandAll();
			//返回结果
			return lngRes;
		}	

		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null  
			if(m_objCurrentPatient ==null || m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//检查当前记录是否为null
			if(m_objCurrentRecordContent==null)
			{
				clsPublicFunction.ShowInformationMessageBox("当前记录内容为空,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//获取服务器时间      
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//删除记录
            clsAYQBabyAssessmentContent_EspRecord objContent = m_objGetContentFromGUI();
			objContent.m_bytStatus =0;
			objContent.m_dtmCreateDate=m_objCurrentRecordContent.m_dtmCreateDate;
            objContent.m_dtmInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strDeActivedOperatorID =MDIParent.OperatorID ;
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;  
			
			//设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
			objContent.m_dtmDeActivedDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			
			clsPreModifyInfo m_objModifyInfo=null;

			long lngRes = m_objDomain.m_lngDeleteRecord(objContent,out m_objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					//清空记录信息   
					
					m_objCurrentRecordContent = null;       
					m_mthClearPatientRecordInfo();
					//选中根节点
					m_blnCanTreeAfterSelect = false;
					m_mthUnEnableRichTextBox();  
					m_blnCanTreeAfterSelect = true;

                    m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession,0);
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;
		}

		// 作废重做的数据库保存。
		protected new long m_lngReAddNew()
		{
			//检查当前病人变量是否为null
		
			//获取服务器时间
		
			//从界面获取记录信息
            clsAYQBabyAssessmentContent_EspRecord objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
			clsPreModifyInfo m_objModifyInfo=null;
			long lngRes = m_objDomain.m_lngReAddNewRecord(m_objReAddNewOld,objContent,out m_objModifyInfo);
			
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = objContent;  
					m_objReAddNewOld = null;
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;

		}

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null)// || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
              //  return false;
			else 
			//	return false;
                return true;
		}

		protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(!m_blnCanTreeAfterSelect)
				return;

			m_mthRecordChangedToSave();

			try
			{
				DateTime dtInDate = DateTime.Parse(trvTime.SelectedNode.Text);
				m_mthClearRecordInfo();

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                DateTime dtmEMRInDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_DtmEMRInDate;
                string strEMRInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;

                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(trvTime.SelectedNode.Text);
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;

                if (string.IsNullOrEmpty(m_objBaseCurrentPatient.m_StrRegisterId))
                {
                    string strRegisterID = string.Empty;
                    long lngRes = new clsPublicDomain().m_lngGetRegisterID(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				m_mthEnableRichTextBox();
				m_mthSetSelectedRecord(m_objCurrentPatient,(string)this.trvTime.SelectedNode.Tag );
				if(m_objCurrentRecordContent!=null)
				{
					this.m_dtpCreateDate.Enabled=false;

					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
				}
				else
				{
					m_mthSetNewRecord();
					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				}
			}
			catch (Exception exp)
			{
				string strtemp=exp.Message;
				m_mthClearRecordInfo();

				m_mthUnEnableRichTextBox();

				m_objCurrentRecordContent =null;
				m_mthEnableModify(true);
				this.m_dtpCreateDate.Enabled =true;
				this.m_dtpCreateDate.Text =DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");  
				
				m_mthSetNullPrintContext();

				//当前处于禁止输入状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );
			}
			finally
			{
				m_mthDoAfterSelect();
				m_mthAddFormStatusForClosingSave();
			}
		}

		/// <summary>
		/// 选择树节点后的操作
		/// </summary>
		protected override void m_mthDoAfterSelect()
		{
			object [][] objDataArr;
			clsAYQBabyAssessmentContent[] objCircsRecordArr;
			DateTime dtSelectedInPatientDate = DateTime.MinValue;
            //try
            //{
            //    dtSelectedInPatientDate = DateTime.Parse(trvTime.SelectedNode.Text.Trim());
            //}
            //catch
            //{
            //    m_dtbRecords.Clear();
            //    return;
            //}
            if (m_ObjCurrentEmrPatientSession != null)
            {
                dtSelectedInPatientDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
            }
            else
            {
                m_dtbRecords.Clear();
                return;
            }

			long lngRes = m_objDomain.m_lngGetAllCircsRecordContent(m_objCurrentPatient.m_StrInPatientID,dtSelectedInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),out objCircsRecordArr);
			objDataArr = m_objGetRecordsValueArr(objCircsRecordArr);

			m_dtbRecords.Clear();
			if(objDataArr == null)
				return;
			for(int j2=0;j2<objDataArr.Length;j2++)
			{
				m_dtbRecords.Rows.Add(objDataArr[j2]);	
			}
            m_dtgRecord.Refresh();
		}

		/// <summary>
		/// 添加记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			if(m_objReAddNewOld != null)
				return m_lngReAddNew();
			else  
				return m_lngAddNewRecord();
		

		}

		/// <summary>
		/// 是否是添加新记录的操作。true，添加新记录；false,修改记录
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_objCurrentRecordContent == null;
			}
		}

		/// <summary>
		/// 获取痕迹保留
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_strModifyUserID"></param>
		/// <param name="p_strModifyUserName"></param>
		/// <returns></returns>
		private string m_strGetDSTTextXML(string p_strText,string p_strModifyUserID,string p_strModifyUserName)
		{
			return com.digitalwave.controls.ctlRichTextBox.clsXmlTool.s_strMakeDSTXml(p_strText,p_strModifyUserID,p_strModifyUserName,Color.Black,Color.White);
		}

		private DataTable m_dtbTempTable;
		private DateTime m_dtmPreRecordDate;
		private object[][] m_objGetRecordsValueArr(clsAYQBabyAssessmentContent[] p_objTransDataInfo)
		{
			#region 显示记录到DataGrid
			try
			{
				object[] objData;
				ArrayList objReturnData=new ArrayList();
				m_dtmPreRecordDate = DateTime.MinValue;
		
				com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue objclsDSTRichTextBoxValue;
				string strText,strXml;

				if(p_objTransDataInfo == null)
					return null;

				int intRecordCount = p_objTransDataInfo.Length;

				for(int i=0; i<intRecordCount; i++)
				{
					objData = new object[16];   
					clsAYQBabyAssessmentContent objCurrent = p_objTransDataInfo[i];
					clsAYQBabyAssessmentContent objNext = new clsAYQBabyAssessmentContent();//下一条记录
					if(i < intRecordCount-1)
						objNext = p_objTransDataInfo[i+1];
                    //只显示最后一次修改的记录
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate
                        && objNext.m_dtmOpenDate == objCurrent.m_dtmOpenDate)
                    {
                        continue;
                    }
					#region 存放关键字段
					if(objCurrent.m_dtmCreateDate!=DateTime.MinValue)
					{
						objData[0] = objCurrent.m_dtmCreateDate;//存放记录时间的字符串
						objData[1] = objCurrent.m_dtmOpenDate;//存放记录的OpenDate字符串
						objData[2] = objCurrent.m_dtmModifyDate;//存放记录的ModifyDate字符串   
						
						if(objCurrent.m_dtmRecordDate.ToString() != m_dtmPreRecordDate.ToString())
						{
							objData[3] = objCurrent.m_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss") ;//日期字符串
						}
					}
					m_dtmPreRecordDate = objCurrent.m_dtmRecordDate;	
					#endregion ;

					#region 存放单项信息
					//面色
                    strText = objCurrent.m_strFacecolor;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strFacecolor != objCurrent.m_strFacecolor)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strFacecolor, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[4] = objclsDSTRichTextBoxValue;

					//呼吸
                    strText = objCurrent.m_strRespiration;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strRespiration != objCurrent.m_strRespiration)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strRespiration, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[5] = objclsDSTRichTextBoxValue;

					//反应
                    strText = objCurrent.m_strReaction;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strReaction != objCurrent.m_strReaction)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strReaction, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[6] = objclsDSTRichTextBoxValue;

					//进食
                    strText = objCurrent.m_strTakeFood;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strTakeFood != objCurrent.m_strTakeFood)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strTakeFood, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[7] = objclsDSTRichTextBoxValue;

					//腋温
                    strText = objCurrent.m_strArmpitWet;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strArmpitWet != objCurrent.m_strArmpitWet)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strArmpitWet, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[8] = objclsDSTRichTextBoxValue;

					//皮肤
                    strText = objCurrent.m_strDerm;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strDerm != objCurrent.m_strDerm)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strDerm, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[9] = objclsDSTRichTextBoxValue;

					//黄疸
                    strText = objCurrent.m_strAurigo;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strAurigo != objCurrent.m_strAurigo)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strAurigo, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[10] = objclsDSTRichTextBoxValue;

					//脐部
                    strText = objCurrent.m_strUmbilicalRegion;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strUmbilicalRegion != objCurrent.m_strUmbilicalRegion)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strUmbilicalRegion, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[11] = objclsDSTRichTextBoxValue;

					//四肢活动
                    strText = objCurrent.m_strLimbActivity;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strLimbActivity != objCurrent.m_strLimbActivity)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strLimbActivity, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[12] = objclsDSTRichTextBoxValue;

					//大便
                    strText = objCurrent.m_strStool;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strStool != objCurrent.m_strStool)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strStool, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[13] = objclsDSTRichTextBoxValue;

					//小便
                    strText = objCurrent.m_strUrine;
					strXml = "<root />";
                    if (objNext != null && objNext.m_dtmCreateDate == objCurrent.m_dtmCreateDate && objNext.m_strUrine != objCurrent.m_strUrine)/*objNext的记录内容与objCurrent的记录内容不一致，文本需要加双划线*/
					{
                        strXml = m_strGetDSTTextXML(objCurrent.m_strUrine, objCurrent.m_strModifyUserID, objCurrent.m_strModifyUserName);
					}
					objclsDSTRichTextBoxValue=new com.digitalwave.Utility.Controls.clsDSTRichTextBoxValue();
					objclsDSTRichTextBoxValue.m_strText=strText;						
					objclsDSTRichTextBoxValue.m_strDSTXml=strXml;	
					objData[14] = objclsDSTRichTextBoxValue;
					//签名	
					objData[15] = objCurrent.m_strSignUserName;

					objReturnData.Add(objData);
					#endregion
				}
				object[][] m_objRe=new object[objReturnData.Count][];

				for(int m=0;m<objReturnData.Count ;m++)
					m_objRe[m]=(object[])objReturnData[m];
				return m_objRe;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
				return null;
			}
			#endregion
		}

		/// <summary>
		/// 添加数据到DataTable
		/// </summary>
		/// <param name="p_objDataArr"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected void m_mthAddDataToDataTable(object[][] p_objDataArr,
			DateTime p_dtmCreateRecordTime)
		{
			//查找插入点
			//循环DataTable的记录，获取记录的日期（第一字段）
			//如果有记录日期
			//比较已有日期与p_dtmCreateDate
			//如果已有日期比p_dtmCreateDate大
			//在这行记录前添加记录（数组），返回
		
			//没有找到比p_dtmCreateDate大的日期，往DataTable后添加	
			if(p_objDataArr==null)
				return;
			m_dtbRecords.Clear();
			int m_intInsertIndex = -1;
			string m_strRecordTime = null;
			DataRow m_dtrNewRow;
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][0].ToString() != "")
				{
					m_strRecordTime = m_dtbRecords.Rows[i1][0].ToString();
					if(DateTime.Parse(m_strRecordTime) > p_dtmCreateRecordTime)
					{
						m_intInsertIndex = i1;
						break;
					}
				}
			}
			if(m_intInsertIndex < 0)//没有找到比p_dtmOpenRecordTime大的日期，往DataTable后添加		
			{
				for(int i1=0;i1<p_objDataArr.Length;i1++)
				{				
					m_dtbRecords.Rows.Add(p_objDataArr[i1]);
				}
			}
			else//否则，将p_dtmCreateDate 之后的记录放到内存中,先添加新增的记录，然后把内存中的记录，再添加回去
			{
				if(m_dtbTempTable == null)
				{
					m_dtbTempTable = m_dtbRecords.Clone();
				}
				while((m_intInsertIndex < m_dtbRecords.Rows.Count))//将p_dtmCreateDate 之后的记录放到内存中
				{
					m_mthSetDataGridFirstRowFocus();
					m_dtrNewRow = m_dtbTempTable.NewRow();
					m_dtrNewRow.ItemArray = m_dtbRecords.Rows[m_intInsertIndex].ItemArray;
					m_dtbTempTable.Rows.Add(m_dtrNewRow);
					m_dtbRecords.Rows.RemoveAt(m_intInsertIndex);
				}
				for(int i1=0;i1<p_objDataArr.Length;i1++)//新增的记录
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = p_objDataArr[i1];
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				for(int i1=0;i1<m_dtbTempTable.Rows.Count;i1++)//把内存中的记录，再添加回去
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = m_dtbTempTable.Rows[i1].ItemArray;
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				if(m_dtbTempTable != null)
				{
					m_dtbTempTable.Rows.Clear();
				}
			}
		}

		/// <summary>
		/// 使得DataGrid的第一行获得焦点
		/// </summary>
		protected void m_mthSetDataGridFirstRowFocus()
		{
			m_dtgRecord.CurrentCell = new DataGridCell(m_dtbRecords.Rows.Count,0);
		}

		protected override long m_lngSubPrint()
		{
			m_mthPrintRecord();
			return 1;
		}

        private clsAYQBabyAssessmentRecordPrintTool objPrintTool;
		private void m_mthPrintRecord()
		{
            objPrintTool = new clsAYQBabyAssessmentRecordPrintTool();
			objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                DateTime dtmTemp = DateTime.MinValue;
                if (!DateTime.TryParse(m_strCurrentOpenDate,out dtmTemp))
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.Parse(m_strCurrentOpenDate));
            }							
			objPrintTool.m_mthInitPrintContent();		
			
			m_mthStartPrint();
		}

		protected override void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);

			if(ppdPrintPreview != null)
				while(!ppdPrintPreview.m_blnHandlePrint(e))
					objPrintTool.m_mthPrintPage(e);
		}

		protected override void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}

		protected override void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
                return;

            //m_mthRecordChangedToSave();

            try
            {
                DateTime dtInDate = p_objSelectedSession.m_dtmHISInpatientDate;
                m_mthClearRecordInfo();

                DateTime dtmEMRInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                string strEMRInPatientID = p_objSelectedSession.m_strEMRInpatientId;

                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = dtInDate;
                m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;

                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthEnableRichTextBox();
                m_mthSetSelectedRecord(m_objCurrentPatient, string.Empty);
                if (m_objCurrentRecordContent != null)
                {
                    this.m_dtpCreateDate.Enabled = false;

                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                }
                else
                {
                    m_mthSetNewRecord();
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            catch (Exception exp)
            {
                string strtemp = exp.Message;
                m_mthClearRecordInfo();

                m_mthUnEnableRichTextBox();

                m_objCurrentRecordContent = null;
                m_mthEnableModify(true);
                this.m_dtpCreateDate.Enabled = true;
                this.m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

                m_mthSetNullPrintContext();

                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }
            finally
            {
                m_mthDoAfterSelect();
                m_mthAddFormStatusForClosingSave();
            }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                return "";//不知道有啥用
            }
        }
        /// <summary>
        /// 不需要打印前提示保存
        /// </summary>
        protected override  DialogResult m_dlgHandleSaveBeforePrint()
        {
            DialogResult dlgResult = DialogResult.Yes; 
            return dlgResult;
        }
	}
}
