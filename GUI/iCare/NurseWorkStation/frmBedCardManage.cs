using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
	/// <summary>
	/// 床头卡管理(已废除不用)
	/// </summary>
	public class frmBedCardManage : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Define
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsBedCardManageDomain m_objBedCardDomain;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private Panel panel1;
        private Label lblInpatientDate;
        private TextBox m_txtChargeDoc;
        protected ctlComboBox m_cboStatus;
        private TextBox m_txtManageDoc;
        public PinkieControls.ButtonXP m_cmdManageDoc;
        public ctlTimePicker m_dtpInpatientDate;
        public PinkieControls.ButtonXP m_cmdSave;
        public PinkieControls.ButtonXP m_cmdCancel;
        private Label lblStatus;
        private Label label1;
        private Label label4;
        public PinkieControls.ButtonXP m_cmdChargeDoc;
        public PinkieControls.ButtonXP m_cmdManage;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		#endregion

		public frmBedCardManage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthIniti();
            //new clsCommonUseToolCollection(this).m_mthBindEmployeeSign(new Control[]{this.m_cmdManageDoc,this.m_cmdChargeDoc },new Control[]{this.m_txtManageDoc,this.m_txtChargeDoc},new int[]{1,1});

            //签名常用值
            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdManageDoc, m_txtManageDoc, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdChargeDoc, m_txtChargeDoc, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInpatientDate = new System.Windows.Forms.Label();
            this.m_txtChargeDoc = new System.Windows.Forms.TextBox();
            this.m_cboStatus = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_txtManageDoc = new System.Windows.Forms.TextBox();
            this.m_cmdManageDoc = new PinkieControls.ButtonXP();
            this.m_dtpInpatientDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdChargeDoc = new PinkieControls.ButtonXP();
            this.m_cmdManage = new PinkieControls.ButtonXP();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(257, 175);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(361, 175);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(253, 107);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(241, 139);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(37, 175);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(209, 175);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(313, 175);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(33, 139);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(91, 81);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(297, 135);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(81, 174);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(297, 103);
            this.m_txtBedNO.Size = new System.Drawing.Size(92, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(81, 135);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(268, 105);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(213, 105);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(81, 103);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(33, 107);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(141, 213);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdNext.Location = new System.Drawing.Point(389, 103);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(141, 83);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(233, 95);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(339, 40);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(661, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(740, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(738, 29);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblInpatientDate);
            this.panel1.Controls.Add(this.m_txtChargeDoc);
            this.panel1.Controls.Add(this.m_cboStatus);
            this.panel1.Controls.Add(this.m_txtManageDoc);
            this.panel1.Controls.Add(this.m_cmdManageDoc);
            this.panel1.Controls.Add(this.m_dtpInpatientDate);
            this.panel1.Controls.Add(this.m_cmdSave);
            this.panel1.Controls.Add(this.m_cmdCancel);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_cmdChargeDoc);
            this.panel1.Controls.Add(this.m_cmdManage);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 172);
            this.panel1.TabIndex = 10000006;
            // 
            // lblInpatientDate
            // 
            this.lblInpatientDate.AutoSize = true;
            this.lblInpatientDate.Location = new System.Drawing.Point(183, 20);
            this.lblInpatientDate.Name = "lblInpatientDate";
            this.lblInpatientDate.Size = new System.Drawing.Size(63, 14);
            this.lblInpatientDate.TabIndex = 10000128;
            this.lblInpatientDate.Text = "入院时间";
            // 
            // m_txtChargeDoc
            // 
            this.m_txtChargeDoc.Location = new System.Drawing.Point(253, 50);
            this.m_txtChargeDoc.Name = "m_txtChargeDoc";
            this.m_txtChargeDoc.ReadOnly = true;
            this.m_txtChargeDoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtChargeDoc.TabIndex = 10000131;
            // 
            // m_cboStatus
            // 
            this.m_cboStatus.BackColor = System.Drawing.Color.White;
            this.m_cboStatus.BorderColor = System.Drawing.Color.Black;
            this.m_cboStatus.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboStatus.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboStatus.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStatus.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboStatus.ForeColor = System.Drawing.Color.Black;
            this.m_cboStatus.ListBackColor = System.Drawing.Color.White;
            this.m_cboStatus.ListForeColor = System.Drawing.Color.Black;
            this.m_cboStatus.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboStatus.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboStatus.Location = new System.Drawing.Point(255, 82);
            this.m_cboStatus.m_BlnEnableItemEventMenu = false;
            this.m_cboStatus.Name = "m_cboStatus";
            this.m_cboStatus.SelectedIndex = -1;
            this.m_cboStatus.SelectedItem = null;
            this.m_cboStatus.SelectionStart = 0;
            this.m_cboStatus.Size = new System.Drawing.Size(100, 23);
            this.m_cboStatus.TabIndex = 10000122;
            this.m_cboStatus.TextBackColor = System.Drawing.Color.White;
            this.m_cboStatus.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_txtManageDoc
            // 
            this.m_txtManageDoc.Location = new System.Drawing.Point(446, 50);
            this.m_txtManageDoc.Name = "m_txtManageDoc";
            this.m_txtManageDoc.ReadOnly = true;
            this.m_txtManageDoc.Size = new System.Drawing.Size(100, 23);
            this.m_txtManageDoc.TabIndex = 10000130;
            // 
            // m_cmdManageDoc
            // 
            this.m_cmdManageDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdManageDoc.DefaultScheme = true;
            this.m_cmdManageDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdManageDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdManageDoc.Hint = "";
            this.m_cmdManageDoc.Location = new System.Drawing.Point(371, 48);
            this.m_cmdManageDoc.Name = "m_cmdManageDoc";
            this.m_cmdManageDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdManageDoc.Size = new System.Drawing.Size(68, 28);
            this.m_cmdManageDoc.TabIndex = 10000121;
            this.m_cmdManageDoc.Tag = "1";
            this.m_cmdManageDoc.Text = "管床医生";
            // 
            // m_dtpInpatientDate
            // 
            this.m_dtpInpatientDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpInpatientDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpInpatientDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpInpatientDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpInpatientDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpInpatientDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpInpatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpInpatientDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpInpatientDate.Location = new System.Drawing.Point(255, 18);
            this.m_dtpInpatientDate.m_BlnOnlyTime = false;
            this.m_dtpInpatientDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpInpatientDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpInpatientDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpInpatientDate.Name = "m_dtpInpatientDate";
            this.m_dtpInpatientDate.ReadOnly = true;
            this.m_dtpInpatientDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpInpatientDate.TabIndex = 10000119;
            this.m_dtpInpatientDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpInpatientDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(371, 134);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(68, 28);
            this.m_cmdSave.TabIndex = 10000124;
            this.m_cmdSave.Tag = "1";
            this.m_cmdSave.Text = "保  存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(479, 134);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(68, 28);
            this.m_cmdCancel.TabIndex = 10000125;
            this.m_cmdCancel.Tag = "1";
            this.m_cmdCancel.Text = "关  闭";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(183, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 14);
            this.lblStatus.TabIndex = 10000129;
            this.lblStatus.Text = "状    态";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(175, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 2);
            this.label1.TabIndex = 10000126;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(175, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(388, 2);
            this.label4.TabIndex = 10000127;
            // 
            // m_cmdChargeDoc
            // 
            this.m_cmdChargeDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdChargeDoc.DefaultScheme = true;
            this.m_cmdChargeDoc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdChargeDoc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdChargeDoc.Hint = "";
            this.m_cmdChargeDoc.Location = new System.Drawing.Point(179, 48);
            this.m_cmdChargeDoc.Name = "m_cmdChargeDoc";
            this.m_cmdChargeDoc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdChargeDoc.Size = new System.Drawing.Size(68, 28);
            this.m_cmdChargeDoc.TabIndex = 10000120;
            this.m_cmdChargeDoc.Tag = "";
            this.m_cmdChargeDoc.Text = "主治医生";
            // 
            // m_cmdManage
            // 
            this.m_cmdManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdManage.DefaultScheme = true;
            this.m_cmdManage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdManage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdManage.Hint = "";
            this.m_cmdManage.Location = new System.Drawing.Point(179, 134);
            this.m_cmdManage.Name = "m_cmdManage";
            this.m_cmdManage.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdManage.Size = new System.Drawing.Size(68, 28);
            this.m_cmdManage.TabIndex = 10000123;
            this.m_cmdManage.Tag = "1";
            this.m_cmdManage.Text = "管床设置";
            this.m_cmdManage.Click += new System.EventHandler(this.m_cmdManage_Click);
            // 
            // frmBedCardManage
            // 
            this.ClientSize = new System.Drawing.Size(760, 259);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBedCardManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "床头卡";
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#region 接口
		public void Copy()
		{
//			m_lngCopy();
		}

		public void Cut()
		{
//			m_lngCut();
		}

		public void Delete()
		{
//			long m_lngRe=m_lngDelete(); 
//			if(m_lngRe>0)
//
//			{	
//				if(this.trvTime.SelectedNode!=null)
//				{
//					this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
//				}
//			}

		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
//			m_lngPaste();
		}

		public void Print()
		{
//			m_lngPrint(); 
		}

		public void Redo()
		{
		
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Save()
		{
//			long m_lngRe=m_lngSave(); 
//			if(m_lngRe>0)
//			{
//				if(this.trvTime.SelectedNode!=null)
//				{
//					this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
//				}
//				
//			}
		}


				
		public void Undo()
		{
		
		}

		#endregion

		/// <summary>
		/// 设置病人表单信息，必须覆盖
		/// </summary>
		/// <param name="p_objSelectedPatient">病人</param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			this.m_dtpInpatientDate.Value = p_objSelectedPatient.m_DtmLastInDate;

			clsBedCardValue objBedCardValue = new clsBedCardValue();
			objBedCardValue.m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
			objBedCardValue.m_strInPatientDate = p_objSelectedPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss");
			long lngRes = m_objBedCardDomain.m_lngGetBedCardValue(ref objBedCardValue);
			if(lngRes <= 0 || string.IsNullOrEmpty(objBedCardValue.m_strDoc_ManageBed))
			{
				string strDoctor = null;
				m_objBedCardDomain.m_lngGetManageDocWithBedID(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID,out strDoctor);
				if(strDoctor != null)
				{
                    //clsEmployee objemp = new clsEmployee(strDoctor.Trim());
                    //this.m_txtManageDoc.Text = objemp.m_StrLastName;
                    //this.m_txtManageDoc.Tag = objemp;
                    clsEmrEmployeeBase_VO objEmpVO1 = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByID(strDoctor.Trim(), out objEmpVO1);
                    if (objEmpVO1 != null)
                    {
                        m_txtManageDoc.Tag = objEmpVO1;
                        m_txtManageDoc.Text = objEmpVO1.m_strLASTNAME_VCHR;
                    }
				}                
			}
			else
			{
                clsEmrEmployeeBase_VO objEmpVO2 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objBedCardValue.m_strDoc_ManageBed, out objEmpVO2);
                if (objEmpVO2 != null)
                {
                    this.m_txtManageDoc.Text = objEmpVO2.m_strLASTNAME_VCHR;
                    this.m_txtManageDoc.Tag = objEmpVO2;
                }
			}

            if (string.IsNullOrEmpty(objBedCardValue.m_strDoc_InCharge))
            {
                this.m_txtChargeDoc.Text = string.Empty;
                this.m_txtChargeDoc.Tag = null;
            }
            else
            {
                clsEmrEmployeeBase_VO objEmpVO3 = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByID(objBedCardValue.m_strDoc_InCharge, out objEmpVO3);
                if (objEmpVO3 != null)
                {
                    this.m_txtChargeDoc.Text = objEmpVO3.m_strLASTNAME_VCHR;
                    this.m_txtChargeDoc.Tag = objEmpVO3;
                }                
            }

			this.m_cboStatus.SelectedIndex = (( objBedCardValue.m_intState < -1 || objBedCardValue.m_intState > 3)? -1 :objBedCardValue.m_intState);
		}

		/// <summary>
		/// 初始化信息
		/// </summary>
		private void m_mthIniti()
		{
			m_objBedCardDomain = new clsBedCardManageDomain();

			string[] strStatus = new string[]{"稳定","慢性","病重","病危"};
			this.m_cboStatus.AddRangeItems(strStatus);
			this.m_cboStatus.SelectedIndex = 0;
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			if(m_lngSubAddNew() > 0)
			{
                //m_txtBedNO.Focus();
                //m_txtBedNO.SelectAll();
                //clsPublicFunction.ShowInformationMessageBox("保存成功！");
			}
//			else
//				clsPublicFunction.ShowInformationMessageBox("保存失败！");
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
			if(m_objBaseCurrentPatient == null)
			{
				clsPublicFunction.ShowInformationMessageBox("病人为空，请选择病人！");
				return 0;
			}
			if(this.m_txtChargeDoc.Text.Trim() == "" || this.m_txtChargeDoc.Tag == null)
			{
				
				clsPublicFunction.ShowInformationMessageBox("主治医生为空，或者不是本科室员工！");
				this.m_txtChargeDoc.Focus();
				return 0;
			}
			
			if(this.m_txtManageDoc.Text.Trim() == "" || this.m_txtManageDoc.Tag == null)
			{
				
				clsPublicFunction.ShowInformationMessageBox("管床医生为空，或者不是本科室医生！");
				this.m_txtManageDoc.Focus();
				return 0;
			}
			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain();

			clsBedCardValue objBedCardValue = new clsBedCardValue();
			objBedCardValue.m_strInPatientID = m_objBaseCurrentPatient.m_StrInPatientID;
			objBedCardValue.m_strInPatientDate = m_objBaseCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss");
			objBedCardValue.m_strOpenDate = m_objPDomain.m_strGetServerTime();
            if (this.m_txtChargeDoc.Tag != null)
            {
                objBedCardValue.m_strDoc_InCharge = ((clsEmrEmployeeBase_VO)(this.m_txtChargeDoc.Tag)).m_strEMPID_CHR;
            }
            else
            {
                objBedCardValue.m_strDoc_InCharge = string.Empty;
            }
            if (this.m_txtManageDoc.Tag != null)
            {
                objBedCardValue.m_strDoc_ManageBed = ((clsEmrEmployeeBase_VO)(this.m_txtManageDoc.Tag)).m_strEMPID_CHR;
            }
            else
            {
                objBedCardValue.m_strDoc_ManageBed = string.Empty;
            }
			objBedCardValue.m_intState = this.m_cboStatus.SelectedIndex;
			long lngRes = 0;
			try
			{
				lngRes = m_objBedCardDomain.m_lngSaveBedCardValue(objBedCardValue);
				if(lngRes > 0)
				{
					clsPublicFunction.ShowInformationMessageBox("保存成功！");
				}
			}
			catch(Exception e)
			{
//				clsPublicFunction.ShowInformationMessageBox("保存失败！");
			}
			finally
			{
				if(lngRes <= 0)
				{
					clsPublicFunction.ShowInformationMessageBox("保存失败！");
				}
			}
			return lngRes;
		}

		private void m_cmdManage_Click(object sender, System.EventArgs e)
		{
			if(m_ObjCurrentArea == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病区！");
                //this.m_cboArea.Focus();
				return ;
			}
			this.Hide();
            using (frmSetBed_Doctor frmBed_Doctor = new frmSetBed_Doctor(m_ObjCurrentArea.m_strDEPTID_CHR, m_ObjCurrentArea.m_strDEPTID_CHR))
			{
				if(frmBed_Doctor.ShowDialog() == DialogResult.Abort)
					this.Show();
			}
		}
    }
}
