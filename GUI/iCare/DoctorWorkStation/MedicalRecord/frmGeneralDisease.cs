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
using System.Text;

namespace iCare
{
	/// <summary>
	/// （一般）病程记录子窗体的实现,Jacky-2003-5-12
	/// </summary>
	public class frmGeneralDisease : frmDiseaseTrackBase
	{
        private com.digitalwave.controls.ctlRichTextBox m_txtRecordContent;
		private System.Windows.Forms.Label lblTitle1;
		private System.Windows.Forms.Label lblTitle3;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboRecordTitleType;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.Label lblRecordTitleTypeTitle;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.MenuItem mniLabCheckResult;
		private System.ComponentModel.IContainer components = null;
		private clsCommonUseToolCollection m_objCUTC;
		private System.Windows.Forms.MenuItem m_mniOperation;
		private ListBox m_lstOperation;

		private clsEmployeeSignTool m_objSignTool;

		private clsElectronIdiographDomain m_objElectronIdiographDomain;
		protected System.Windows.Forms.ListView lsvSign;
		private string m_strOpenDateRecord = "";
		private PinkieControls.ButtonXP m_cmdEmployeeSign;
        private ctlComboBox m_txtRecordTitle;

		//定义签名类
		private clsEmrSignToolCollection m_objSign;
        /// <summary>
        /// 是否广西区医院
        /// </summary>
        private bool m_blnIsNanNing = true;


		public frmGeneralDisease()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			cmdConfirm.Visible=false;
            m_cboDept.Visible = false;
            if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                m_txtRecordTitle.Visible = true;
                m_cboRecordTitleType.Visible = false;
                m_blnIsNanNing = true;

                m_txtRecordTitle.AddItem("病程记录");
                m_txtRecordTitle.AddItem("腰穿记录");
                m_txtRecordTitle.AddItem("胸穿记录");
                m_txtRecordTitle.AddItem("骨穿记录");
                m_txtRecordTitle.AddItem("腹穿记录");
                m_txtRecordTitle.AddItem("介入治疗记录");
                m_txtRecordTitle.AddItem("活检记录");
                m_txtRecordTitle.AddItem("肠镜检查记录");
                m_txtRecordTitle.AddItem("胃镜检查记录");
                m_txtRecordTitle.AddItem("纤支镜检查记录");
                m_txtRecordTitle.AddItem("其他治疗操作记录");

                m_cboRecordTitleType.AddItem("病程记录");
                m_cboRecordTitleType.AddItem("交班记录");
            }
            else
            {
                m_txtRecordTitle.Visible = false;
                m_cboRecordTitleType.Visible = true;
                m_blnIsNanNing = false;
                m_cboRecordTitleType.AddItem("");
                m_cboRecordTitleType.AddItem("病程记录");
                m_cboRecordTitleType.AddItem("交班记录");
                m_cboRecordTitleType.AddItem("接班记录");
                //			m_cboRecordTitleType.AddItem("会诊记录");
                m_cboRecordTitleType.AddItem("转出记录");
                m_cboRecordTitleType.AddItem("转入记录");
                m_cboRecordTitleType.AddItem("阶段小结");
                m_cboRecordTitleType.AddItem("主任查房记录");
                m_cboRecordTitleType.AddItem("副主任查房记录");
                m_cboRecordTitleType.AddItem("主治医师查房记录"); // 新加
                m_cboRecordTitleType.AddItem("医师查房记录");
                m_cboRecordTitleType.AddItem("疑难病例讨论记录");
                m_cboRecordTitleType.AddItem("术前讨论记录");
                m_cboRecordTitleType.AddItem("死亡病例讨论记录");
                m_cboRecordTitleType.AddItem("手术后病程记录");
                m_cboRecordTitleType.AddItem("死亡记录");
                //			m_cboRecordTitleType.AddItem("出院记录");
                m_cboRecordTitleType.AddItem("抢救记录");
                m_cboRecordTitleType.AddItem("颈内静脉穿刺术记录");
                m_cboRecordTitleType.AddItem("纤维支气管镜吸痰+灌洗术记录");
                m_cboRecordTitleType.AddItem("其他记录");
            }

            // 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、输入字体颜色，双画线颜色）
            m_mthSetRichTextBoxAttribInControl(this);

			//签名常用值
			m_objSign = new clsEmrSignToolCollection();
			//m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            m_objSign.m_mthBindEmployeeSign(m_cmdEmployeeSign, lsvSign, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);

			//m_objElectronIdiographDomain = new clsElectronIdiographDomain(this.Name);
		}

		#region 手术名称
		/// <summary>
		/// 初始化手术名称的ListBox
		/// </summary>
		private void m_mthInitListBox()
		{
			this.m_lstOperation = new ListBox();

			this.m_lstOperation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_lstOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lstOperation.Font =new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstOperation.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.m_lstOperation.ItemHeight = 25;
			this.m_lstOperation.Location = new System.Drawing.Point(10, 10);
			this.m_lstOperation.Name = "m_lstOperation";
			this.m_lstOperation.Size = new System.Drawing.Size(222, 200);
			this.m_lstOperation.TabIndex = 15006;
			this.m_lstOperation.BringToFront ();
			this.m_lstOperation.Visible = false;
			this.m_lstOperation.HorizontalScrollbar = true;

			m_lstOperation.DoubleClick += new EventHandler(m_lstOperation_DoubleClick);
			m_lstOperation.Leave += new EventHandler(m_lstOperation_Leave);
			
			//不添加这个Control不能显示
			this.Controls.Add(m_lstOperation);
		}

		private void m_lstOperation_DoubleClick(object sender,EventArgs e)
		{
			ListBox lstOperation = (ListBox)sender;
			if(lstOperation.SelectedItems.Count > 0 && lstOperation.SelectedItems[0] != null)
			{
				m_txtRecordContent.Tag = ((clsTemplateSet_Associate)lstOperation.SelectedItems[0]).strAssociateID;
			}
			m_txtRecordContent.m_mthInsertText(((clsTemplateSet_Associate)lstOperation.SelectedItems[0]).strAssociateName,m_txtRecordContent.SelectionStart);

			lstOperation.Visible = false;
			m_txtRecordContent.Focus();
		}

		private void m_lstOperation_Leave(object sender, System.EventArgs e)
		{
			m_lstOperation.Visible = false;
			m_txtRecordContent.Focus();
		}

		private void m_mniOperation_Click(object sender, System.EventArgs e)
		{
			m_lstOperation.Items.Clear();

			clsTemplateSet_Associate[] m_objArr;
			new clsTemplateDomain().m_lngGetAllAssociate((int)enmAssociate.Operation,out m_objArr);
			if(m_objArr!=null && m_objArr.Length>0)
			{
				m_lstOperation.Items.AddRange(m_objArr);
			}

			System.Drawing.Point pt= m_txtRecordContent.GetPositionFromCharIndex(m_txtRecordContent.SelectionStart );

			m_lstOperation.Left = m_txtRecordContent.Left + pt.X;
			m_lstOperation.Top = m_txtRecordContent.Top + pt.Y + 20;
			
			m_lstOperation.Visible = true;
			m_lstOperation.BringToFront();
			if(m_lstOperation.Items.Count > 0)
				m_lstOperation.SelectedIndex = 0;
			m_lstOperation.Focus();
		}
		#endregion

		public override int m_IntFormID
		{
			get
			{
				return 0;
			}
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
            this.m_txtRecordContent = new com.digitalwave.controls.ctlRichTextBox();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblRecordTitleTypeTitle = new System.Windows.Forms.Label();
            this.m_cboRecordTitleType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.mniLabCheckResult = new System.Windows.Forms.MenuItem();
            this.m_cmdEmployeeSign = new PinkieControls.ButtonXP();
            this.m_mniOperation = new System.Windows.Forms.MenuItem();
            this.m_txtRecordTitle = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(174, 150);
            this.m_trvCreateDate.Size = new System.Drawing.Size(68, 24);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(20, 12);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(92, 8);
            this.m_dtpCreateDate.TabIndex = 112;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(668, 8);
            this.lblSex.Size = new System.Drawing.Size(32, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(752, 8);
            this.lblAge.Size = new System.Drawing.Size(28, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(182, 102);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(332, 8);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(131, 106);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(360, 4);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(704, 8);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(262, 102);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(428, 0);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(76, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(544, 32);
            this.m_lsvPatientName.Size = new System.Drawing.Size(76, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(428, -24);
            this.m_lsvBedNO.Size = new System.Drawing.Size(76, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(160, 120);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(504, 208);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(396, 4);
            this.m_lblForTitle.Text = "病程记录";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(16, 412);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(631, 76);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // m_txtRecordContent
            // 
            this.m_txtRecordContent.AccessibleDescription = "记录内容";
            this.m_txtRecordContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtRecordContent.BackColor = System.Drawing.Color.White;
            this.m_txtRecordContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecordContent.ForeColor = System.Drawing.Color.Black;
            this.m_txtRecordContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRecordContent.Location = new System.Drawing.Point(16, 57);
            this.m_txtRecordContent.m_BlnIgnoreUserInfo = false;
            this.m_txtRecordContent.m_BlnPartControl = false;
            this.m_txtRecordContent.m_BlnReadOnly = false;
            this.m_txtRecordContent.m_BlnUnderLineDST = false;
            this.m_txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRecordContent.m_IntCanModifyTime = 500;
            this.m_txtRecordContent.m_IntPartControlLength = 0;
            this.m_txtRecordContent.m_IntPartControlStartIndex = 0;
            this.m_txtRecordContent.m_StrUserID = "";
            this.m_txtRecordContent.m_StrUserName = "";
            this.m_txtRecordContent.Name = "m_txtRecordContent";
            this.m_txtRecordContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtRecordContent.Size = new System.Drawing.Size(772, 339);
            this.m_txtRecordContent.TabIndex = 120;
            this.m_txtRecordContent.Text = "";
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle1.Location = new System.Drawing.Point(404, 12);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(42, 14);
            this.lblTitle1.TabIndex = 6074;
            this.lblTitle1.Text = "标题:";
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle3.Location = new System.Drawing.Point(20, 40);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(70, 14);
            this.lblTitle3.TabIndex = 6076;
            this.lblTitle3.Text = "记录内容:";
            // 
            // lblRecordTitleTypeTitle
            // 
            this.lblRecordTitleTypeTitle.AutoSize = true;
            this.lblRecordTitleTypeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordTitleTypeTitle.Location = new System.Drawing.Point(67, 160);
            this.lblRecordTitleTypeTitle.Name = "lblRecordTitleTypeTitle";
            this.lblRecordTitleTypeTitle.Size = new System.Drawing.Size(70, 14);
            this.lblRecordTitleTypeTitle.TabIndex = 6077;
            this.lblRecordTitleTypeTitle.Text = "类    型:";
            this.lblRecordTitleTypeTitle.Visible = false;
            // 
            // m_cboRecordTitleType
            // 
            this.m_cboRecordTitleType.BackColor = System.Drawing.Color.White;
            this.m_cboRecordTitleType.BorderColor = System.Drawing.Color.Black;
            this.m_cboRecordTitleType.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_cboRecordTitleType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboRecordTitleType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTitleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboRecordTitleType.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRecordTitleType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboRecordTitleType.ForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTitleType.ListBackColor = System.Drawing.Color.White;
            this.m_cboRecordTitleType.ListForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTitleType.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboRecordTitleType.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboRecordTitleType.Location = new System.Drawing.Point(450, 7);
            this.m_cboRecordTitleType.m_BlnEnableItemEventMenu = false;
            this.m_cboRecordTitleType.Name = "m_cboRecordTitleType";
            this.m_cboRecordTitleType.SelectedIndex = -1;
            this.m_cboRecordTitleType.SelectedItem = null;
            this.m_cboRecordTitleType.SelectionStart = 0;
            this.m_cboRecordTitleType.Size = new System.Drawing.Size(287, 23);
            this.m_cboRecordTitleType.TabIndex = 110;
            this.m_cboRecordTitleType.TextBackColor = System.Drawing.Color.White;
            this.m_cboRecordTitleType.TextForeColor = System.Drawing.Color.Black;
            this.m_cboRecordTitleType.Visible = false;
            this.m_cboRecordTitleType.SelectedValueChanged += new System.EventHandler(this.m_cboRecordTitleType_SelectedValueChanged);
            // 
            // lsvSign
            // 
            this.lsvSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmEmployeeName});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(172, 410);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(424, 28);
            this.lsvSign.TabIndex = 140;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            this.lsvSign.SelectedIndexChanged += new System.EventHandler(this.lsvSign_SelectedIndexChanged);
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.Width = 55;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(616, 408);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(72, 30);
            this.cmdConfirm.TabIndex = 200;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(704, 408);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(72, 30);
            this.m_cmdClose.TabIndex = 201;
            this.m_cmdClose.Text = "取消";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // mniLabCheckResult
            // 
            this.mniLabCheckResult.Index = -1;
            this.mniLabCheckResult.Text = "检 验 结 果";
            this.mniLabCheckResult.Visible = false;
            this.mniLabCheckResult.Click += new System.EventHandler(this.mniLabCheckResult_Click);
            // 
            // m_cmdEmployeeSign
            // 
            this.m_cmdEmployeeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmdEmployeeSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdEmployeeSign.DefaultScheme = true;
            this.m_cmdEmployeeSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdEmployeeSign.Hint = "";
            this.m_cmdEmployeeSign.Location = new System.Drawing.Point(108, 408);
            this.m_cmdEmployeeSign.Name = "m_cmdEmployeeSign";
            this.m_cmdEmployeeSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdEmployeeSign.Size = new System.Drawing.Size(58, 30);
            this.m_cmdEmployeeSign.TabIndex = 125;
            this.m_cmdEmployeeSign.Tag = "1";
            this.m_cmdEmployeeSign.Text = "签名:";
            // 
            // m_mniOperation
            // 
            this.m_mniOperation.Index = -1;
            this.m_mniOperation.Text = "手术名称";
            this.m_mniOperation.Click += new System.EventHandler(this.m_mniOperation_Click);
            // 
            // m_txtRecordTitle
            // 
            this.m_txtRecordTitle.BackColor = System.Drawing.Color.White;
            this.m_txtRecordTitle.BorderColor = System.Drawing.Color.Black;
            this.m_txtRecordTitle.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_txtRecordTitle.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_txtRecordTitle.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_txtRecordTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_txtRecordTitle.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecordTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecordTitle.ForeColor = System.Drawing.Color.Black;
            this.m_txtRecordTitle.ListBackColor = System.Drawing.Color.White;
            this.m_txtRecordTitle.ListForeColor = System.Drawing.Color.Black;
            this.m_txtRecordTitle.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_txtRecordTitle.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_txtRecordTitle.Location = new System.Drawing.Point(450, 7);
            this.m_txtRecordTitle.m_BlnEnableItemEventMenu = false;
            this.m_txtRecordTitle.Name = "m_txtRecordTitle";
            this.m_txtRecordTitle.SelectedIndex = -1;
            this.m_txtRecordTitle.SelectedItem = null;
            this.m_txtRecordTitle.SelectionStart = 0;
            this.m_txtRecordTitle.Size = new System.Drawing.Size(287, 23);
            this.m_txtRecordTitle.TabIndex = 10000005;
            this.m_txtRecordTitle.TextBackColor = System.Drawing.Color.White;
            this.m_txtRecordTitle.TextForeColor = System.Drawing.Color.Black;
            // 
            // frmGeneralDisease
            // 
            this.AccessibleDescription = "病程记录";
            this.AutoScroll = false;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(794, 447);
            this.Controls.Add(this.m_txtRecordTitle);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.m_txtRecordContent);
            this.Controls.Add(this.lblTitle3);
            this.Controls.Add(this.m_cmdEmployeeSign);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.lblRecordTitleTypeTitle);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_cboRecordTitleType);
            this.Name = "frmGeneralDisease";
            this.Text = "病程记录";
            this.Load += new System.EventHandler(this.frmGeneralDisease_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_cboRecordTitleType, 0);
            this.Controls.SetChildIndex(this.lsvSign, 0);
            this.Controls.SetChildIndex(this.lblRecordTitleTypeTitle, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.m_cmdClose, 0);
            this.Controls.SetChildIndex(this.m_cmdEmployeeSign, 0);
            this.Controls.SetChildIndex(this.lblTitle3, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtRecordContent, 0);
            this.Controls.SetChildIndex(this.lblTitle1, 0);
            this.Controls.SetChildIndex(this.m_txtRecordTitle, 0);
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
			clsGeneralDiseaseInfo objTrackInfo = new clsGeneralDiseaseInfo();

			objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
			objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
			objTrackInfo.m_StrTitle = m_txtRecordTitle.Text;

			//设置m_strTitle和m_dtmRecordTime
			if(objTrackInfo.m_ObjRecordContent !=null)
			{
				m_txtRecordTitle.Text=((clsGeneralDiseaseRecordContent)m_objCurrentRecordContent).m_strRecordTitle;//objTrackInfo.m_StrTitle;
				m_dtpCreateDate.Value=objTrackInfo.m_ObjRecordContent.m_dtmCreateDate;
			}
			return objTrackInfo;		
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected override void m_mthClearRecordInfo()
		{
			//清空具体记录内容
			m_txtRecordTitle.Text="";
			m_txtRecordContent.m_mthClearText();
			m_cboRecordTitleType.SelectedIndex=-1;
			m_cboRecordTitleType.Text="";			
			//默认签名
			MDIParent.m_mthSetDefaulEmployee(lsvSign);

		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected override void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
				cmdConfirm.Visible=true;
		}

		/// <summary>
		/// 具体记录的特殊控制,根据子窗体的需要重载实现
		/// </summary>
		/// <param name="p_blnEnable">是否允许修改特殊记录的记录信息。</param>
		protected override void m_mthEnableModifySub(bool p_blnEnable)
		{
			m_cboRecordTitleType.Enabled= p_blnEnable;
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
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null || intSignCount == 0)				
				return null;

            //if(m_cboRecordTitleType.SelectedIndex==-1)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("请选择记录类型!");
            //    return null;
            //}

			//从界面获取表单值
			clsGeneralDiseaseRecordContent objContent=new clsGeneralDiseaseRecordContent();

			//获取lsvsign签名
			objContent.objSignerArr=new clsEmrSigns_VO[intSignCount];
			strUserIDList="";
			strUserNameList="";
            m_mthGetSignArr(new Control[] { lsvSign }, ref objContent.objSignerArr, ref strUserIDList, ref strUserNameList);
            //for (int i = 0; i < intSignCount; i++)
            //{
            //    objContent.objSignerArr[i]=new clsEmrSigns_VO();
            //    objContent.objSignerArr[i].objEmployee=new clsEmrEmployeeBase_VO();
            //    objContent.objSignerArr[i].objEmployee=(clsEmrEmployeeBase_VO)( lsvSign.Items[i].Tag);
            //    objContent.objSignerArr[i].controlName="lsvSign";
            //    objContent.objSignerArr[i].m_strFORMID_VCHR="frmGeneralDisease";//注意大小写
            //    objContent.objSignerArr[i].m_strREGISTERID_CHR=com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            //    //痕迹格式 0972,0324,
            //    strUserIDList=strUserIDList+objContent.objSignerArr[i].objEmployee.m_strEMPID_CHR.Trim()+",";
            //    strUserNameList=strUserNameList+objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR.Trim()+",";
            //}
			objContent.m_strModifyUserID=strUserIDList;
			
			//设置Richtextbox的modifyuserID 和modifyuserName
			m_mthSetRichTextBoxAttribInControlWithIDandName(this);
			#region 是否可以无痕迹修改
			if (chkModifyWithoutMatk.Checked)
				objContent.m_intMarkStatus=0;
			else
				objContent.m_intMarkStatus=1;
			#endregion
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;

            if (m_blnIsNanNing)//南宁
            {
                objContent.m_strRecordTitle = m_txtRecordTitle.Text;
                objContent.m_intRecordTitleType = m_cboRecordTitleType.SelectedIndex;
            }
            else
            {
                //if (string.IsNullOrEmpty(m_cboRecordTitleType.Text ))
                //{
                //    clsPublicFunction.ShowInformationMessageBox("请选择记录类型!");
                //    return null;
                //}
                objContent.m_strRecordTitle = m_cboRecordTitleType.Text;
                objContent.m_intRecordTitleType = m_cboRecordTitleType.SelectedIndex;
            }

			objContent.m_strRecordContent_Right=m_txtRecordContent.m_strGetRightText();	
			objContent.m_strRecordContent=m_txtRecordContent.Text;
			objContent.m_strRecordContentXml=m_txtRecordContent.m_strGetXmlText();



			return objContent;	
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsGeneralDiseaseRecordContent objContent=(clsGeneralDiseaseRecordContent)p_objContent;
            if (objContent == null) return;
            //把表单值赋值到界面，由子窗体重载实现
            if (m_blnIsNanNing)//南宁
            {
                m_txtRecordTitle.Text = objContent.m_strRecordTitle;
            }
            else
            {
                m_cboRecordTitleType.Text = objContent.m_strRecordTitle;
            }

            //m_cboRecordTitleType.SelectedIndex=objContent.m_intRecordTitleType;	
			m_txtRecordContent.m_mthClearText();
			m_txtRecordContent.m_mthSetNewText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);
            m_txtRecordTitle.Enabled = false;

			#region 签名集合
			if (objContent.objSignerArr!=null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
                //lsvSign.Items.Clear();
                //for (int i = 0; i < objContent.objSignerArr.Length; i++)
                //{
                //    if (objContent.objSignerArr[i].controlName=="lsvSign")
                //    {
                //        ListViewItem lviNewItem=new 						 ListViewItem(objContent.objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
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
			}
			#endregion 签名		

            //ArrayList alt = new ArrayList();
            //alt.Add(m_txtRecordContent.Name);
            //m_strOpenDateRecord = objContent.m_dtmOpenDate.ToString();
            //m_objElectronIdiographDomain.m_mthGetIdiograph(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),m_strOpenDateRecord,alt);
		}

		protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			clsGeneralDiseaseRecordContent objContent=(clsGeneralDiseaseRecordContent)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现
            if (m_blnIsNanNing)//南宁
            {
                m_txtRecordTitle.Text = objContent.m_strRecordTitle;
            }
            else
            {
                m_cboRecordTitleType.Text = objContent.m_strRecordTitle;
            }
            //m_cboRecordTitleType.SelectedIndex=objContent.m_intRecordTitleType;	
			m_txtRecordContent.m_mthClearText();
			m_txtRecordContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);

            if (objContent.objSignerArr != null)
            {
                m_mthAddSignToListView(lsvSign, objContent.objSignerArr);
            }
        }

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.GeneralDisease);					
		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
			clsGeneralDiseaseRecordContent objContent=(clsGeneralDiseaseRecordContent)p_objRecordContent;
			//把表单值赋值到界面，由子窗体重载实现
            if (m_blnIsNanNing)//南宁
            {
                m_txtRecordTitle.Text = objContent.m_strRecordTitle;
            }
            else
            {
                m_cboRecordTitleType.Text = objContent.m_strRecordTitle;
            }
            //m_cboRecordTitleType.SelectedIndex=objContent.m_intRecordTitleType;	
			m_txtRecordContent.m_mthClearText();
			m_txtRecordContent.Text=com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strRecordContent,objContent.m_strRecordContentXml);		
			
		}

		#region 打印
		/// <summary>
		///  设置打印内容。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected override void m_mthSetPrintContent(clsTrackRecordContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		/// <summary>
		/// 初始化打印变量
		/// </summary>
		protected override void m_mthInitPrintTool()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		protected override void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		/// <summary>
		/// 开始打印。
		/// </summary>
		protected override void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		/// <summary>
		/// 打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}

		/// <summary>
		/// 打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}
		#endregion 打印

		// 获取选择已经删除记录的窗体标题
		public override string m_strReloadFormTitle()
		{
			//由子窗体重载实现
            if (m_blnIsNanNing)//南宁
            {
                return m_txtRecordTitle.Text;
            }
            else
            {
                return m_cboRecordTitleType.Text;
            }
		}		

		private void frmGeneralDisease_Load(object sender, System.EventArgs e)
		{
			try
			{
    
	//			m_cmdNewTemplate.Visible = true;		
				this.m_dtpCreateDate.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
				this.m_dtpCreateDate.m_mthResetSize();

                if (m_blnIsNanNing)//南宁
                {
                    m_txtRecordTitle.Focus();
                }
                else
                {
                    m_cboRecordTitleType.Focus();
                }

				if(m_BlnIsAddNew)
				{
					m_cboRecordTitleType.SelectedIndex = 0;
					
					m_txtRecordTitle_LostFocus(null,null);
				}

				//在此初始化手术名称的ListBox是因为不想改变其Focus的颜色
				//frmHRPBaseForm在Load时初始化控件的HighLight
				m_mthInitListBox();
	 

	//			new clsAddOperationTool(this,m_txtRecordContent).m_mthAddContextMenu_Operation();
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message,"iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
    
			}

		}

		#region 添加键盘快捷键		
//		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			switch(e.KeyValue)
//			{
//				case 13:// enter					
//					if(((Control)sender).Name=="m_txtDoctorSign")
//					{						
//						m_mthGetDoctorList(m_txtDoctorSign.Text);
//
//						if(m_lsvDoctorList.Items.Count==1 && (m_txtDoctorSign.Text==m_lsvDoctorList.Items[0].SubItems[0].Text|| m_txtDoctorSign.Text==m_lsvDoctorList.Items[0].SubItems[1].Text))
//						{
//							m_lsvDoctorList.Items[0].Selected=true;
//							m_lsvDoctorList_DoubleClick(null,null);
//							break;
//						}
//					}					
//					else if(((Control)sender).Name=="m_lsvDoctorList")
//					{
//						m_lsvDoctorList_DoubleClick(null,null);						
//					}
//
//					break;
//
//				case 38:
//				case 40:
//					if(((Control)sender).Name=="m_txtDoctorSign")
//					{
//						if(m_txtDoctorSign.Text.Length>0)
//						{	
//							if(m_lsvDoctorList.Visible==false || m_lsvDoctorList.Items.Count==0)
//							{								
//								m_mthGetDoctorList(m_txtDoctorSign.Text);
//							}
//
//							m_lsvDoctorList.BringToFront();
//							m_lsvDoctorList.Visible=true;
//							m_lsvDoctorList.Focus();
//							if( m_lsvDoctorList.Items.Count>0)
//							{
//								m_lsvDoctorList.Items[0].Selected=true;
//								m_lsvDoctorList.Items[0].Focused=true;
//							}	
//						}
//					}					
//					break;
//				case 46:
//					if(((Control)sender).Name=="m_lsvEmployee")
//					{
//						while(m_lsvEmployee.SelectedItems.Count>0)
//							m_lsvEmployee.SelectedItems[0].Remove();
//					}
//					break;
//			}	
//		}

		/// <summary>
		/// 显示医生列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
//		private void m_mthGetDoctorList(string p_strDoctorNameLike)
//		{
//			
//			/*
//			 * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
//			 * 在相应的位置显示ListView。
//			 */			
//
//			if(p_strDoctorNameLike.Length == 0)
//			{
//				m_lsvDoctorList.Visible = false;
//				return;
//			}
//
//			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);
//
//			if(objDoctorArr == null)
//			{
//				m_lsvDoctorList.Visible = false;
//				return;
//			}
//
//			m_lsvDoctorList.Items.Clear();
//
//			for(int i=0;i<objDoctorArr.Length;i++)
//			{
//				ListViewItem lviDoctor = new ListViewItem(
//					new string[]{
//									objDoctorArr[i].m_StrEmployeeID,
//									objDoctorArr[i].m_StrFirstName
//								});
//				lviDoctor.Tag = objDoctorArr[i];
//
//				m_lsvDoctorList.Items.Add(lviDoctor);
//			}
//
//			m_mthChangeListViewLastColumnWidth(m_lsvDoctorList);
//			m_lsvDoctorList.BringToFront();
//			m_lsvDoctorList.Visible = true;
//		}

//		private void m_lsvDoctorList_DoubleClick(object sender, System.EventArgs e)
//		{
//			/*
//			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
//			 */
//			if(m_lsvDoctorList.SelectedItems.Count <= 0)
//				return;
//
//			clsEmployee objEmp = (clsEmployee)m_lsvDoctorList.SelectedItems[0].Tag;
//
//			if(objEmp == null)
//				return;
//			
//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;
//
//			for(int i=0;i<m_lsvEmployee.Items.Count;i++)
//			{
//				if(m_lsvEmployee.Items[i].SubItems[1].Text==objEmp.m_StrEmployeeID)
//				{
//					clsPublicFunction.ShowInformationMessageBox("对不起,医生不能重复签名!");
//					return;
//				}
//			}
//			ListViewItem lviNewItem=m_lsvEmployee.Items.Add(objEmp.m_StrLastName);
//			lviNewItem.SubItems.Add(objEmp.m_StrEmployeeID);					
//
//			m_lsvDoctorList.Visible = false;
//			m_txtDoctorSign.Text="";//清空
//			m_txtDoctorSign.Focus();
//		}
//
//		private void m_lsvDoctorList_LostFocus(object sender,EventArgs e)
//		{							
//			if(!m_txtDoctorSign.Focused && !m_lsvDoctorList.Focused)
//			{
//				m_lsvDoctorList.Visible=false;				
//			}				
//		}	

		#endregion

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
		
			if(m_lngSave() > 0)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
		}
		
		private clsTemplateDomain m_objTemplateDomain = new clsTemplateDomain();

		private void m_txtRecordTitle_LostFocus(object sender,EventArgs e)
		{		
			if(m_txtRecordContent.Text.Trim()!="" )
				return;

            if (m_blnIsNanNing)//南宁
            {
                if (m_txtRecordTitle.Text.Trim()=="")
                {
                    return;
                }
            }
            else
            {
                if (m_cboRecordTitleType.Text.Trim() == "")
                {
                    return;
                }
            }

			if(m_BlnIsAddNew )
			{
				if(m_objCurrentPatient !=null)
				{					
//					if(m_trvCreateDate.Nodes[0].Nodes.Count==0 && m_cboRecordTitleType.Text=="病程记录")
//					{
//						#region 记录时间跟住院病历
//						clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString());
//						if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//						{
//							m_dtpCreateDate.Value = DateTime.Parse(objInPatientCaseDefaultValue[0].m_strCreateDate);
//						}
//						#endregion
//						m_txtRecordContent.Text="    患者"+m_txtPatientName.Text+","+lblSex.Text+","+lblAge.Text;

//						//默认值
//						new clsDefaultValueTool(this,m_objCurrentPatient).m_mthSetDefaultValue();
//						//左上端空几格
//						m_txtRecordContent.m_mthInsertText("    ",0);
//	
//						//自动调用模板
//						m_mthSetSpecialPatientTemplateSet(m_objCurrentPatient);
//
//						if(m_blnHaveAssociateTemplate)
//						{
//							int intIndex1 = m_txtRecordContent.Text.IndexOf("鉴别诊断");
//							int intIndex2 = m_txtRecordContent.Text.LastIndexOf("鉴别诊断");
//							if(intIndex1 != -1 && intIndex2 > intIndex1)
//								m_txtRecordContent.Text = m_txtRecordContent.Text.Remove(intIndex1,intIndex2 - intIndex1);
//						}
						

						//记住关联了哪个手术名称
//						string strTemplateSetID = m_objTemplateDomain.m_strGetPatientHaveDisease_TemplateSetID(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmLastInDate.ToString(),this.Name,(int)enmAssociate.Disease);
//						m_txtRecordContent.Tag = m_objTemplateDomain.m_strGetAssociateIDBySetID(strTemplateSetID,(int)enmAssociate.Operation);
//					}
//					else
//					{
//						m_txtRecordContent.Text = "    患者"+m_txtPatientName.Text+","+lblSex.Text+","+lblAge.Text+",";
//					}

					//默认值
                    new clsDefaultValueTool(this, m_objCurrentPatient).m_mthSetDefaultValue();
                    m_txtRecordContent.m_mthInsertText("    ", 0);
					//自动调用模板
					m_mthSetSpecialPatientTemplateSet(m_objCurrentPatient);
				}
			}			
		}

		private void m_cboRecordTitleType_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(m_BlnIsAddNew )
			{
				if(m_objCurrentPatient !=null)
				{					
//					if(m_trvCreateDate.Nodes[0].Nodes.Count==0 && m_cboRecordTitleType.Text=="病程记录")
//					{
//						m_txtRecordTitle.Text="首次病程记录";
//					}
//					else
//					{
						m_txtRecordTitle.Text=m_cboRecordTitleType.Text;
//					}
				}
			}
			m_txtRecordTitle.Focus();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mniLabCheckResult_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			frmLabCheckReport frmlabcheckreport=new frmLabCheckReport();
			frmlabcheckreport.m_mthSetPatient(m_objCurrentPatient);
			frmlabcheckreport.m_mthInitLabCheckResult(m_txtRecordContent);
			frmlabcheckreport.ShowDialog(this);
			this.Cursor=Cursors.Default;
		}

//		public string m_StrRecordContent
//		{
//			set
//			{
//				m_txtRecordContent.Text += value;
//			}
//		}

		protected override void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
            m_txtRecordContent.m_mthInsertText("    ", 0);
		}

		/// <summary>
		/// 保存套装模板所关联的字段，这里是手术名称
		/// </summary>
		protected override void m_mthSaveTemplateSet_Associate()
		{
			if(m_objCurrentPatient != null)
			{
				if(m_txtRecordContent.Tag != null)
				{
					clsPatient_Associate objContent = new clsPatient_Associate();
					objContent.strInPatientID = m_objCurrentPatient.m_StrInPatientID;
					objContent.strInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
					objContent.strAssociateID = m_txtRecordContent.Tag.ToString();
					
					long lngRes = m_objTemplateDomain.m_lngSavePatient_Associate(objContent,(int)enmAssociate.Operation);
				}
			}
		}

		private void lsvSign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
		



	}

	/// <summary>
	/// 右键增加手术名称的工具
	/// </summary>
	public class clsAddOperationTool
	{
		private com.digitalwave.controls.ctlRichTextBox m_txtParent;
		private ListBox m_lstOperation;

		public clsAddOperationTool(Form p_frmParent,com.digitalwave.controls.ctlRichTextBox p_txtParent)
		{
			m_txtParent = p_txtParent;
			m_mthInitListBox(p_frmParent);
		}

		private void m_mthInitListBox(Form p_frmParent)
		{
			this.m_lstOperation = new ListBox();

			this.m_lstOperation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.m_lstOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lstOperation.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstOperation.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.m_lstOperation.ItemHeight = 12;
			this.m_lstOperation.Location = new System.Drawing.Point(10, 10);
			this.m_lstOperation.Name = "m_lstOperation";
			this.m_lstOperation.Size = new System.Drawing.Size(152, 182);
			this.m_lstOperation.TabIndex = 15006;
			this.m_lstOperation.BringToFront ();
			this.m_lstOperation.Visible = false;
			this.m_lstOperation.HorizontalScrollbar = true;

			m_lstOperation.DoubleClick += new EventHandler(m_lstOperation_DoubleClick);
			m_lstOperation.Leave += new EventHandler(m_lstOperation_Leave);
			
			//不添加这个Control不能显示
			p_frmParent.Controls.Add(m_lstOperation);
		}

		/// <summary>
		/// 右键增加手术名称
		/// </summary>
		public void m_mthAddContextMenu_Operation()
		{
			if(m_txtParent.ContextMenu != null)
			{
				m_txtParent.ContextMenu.MenuItems.Add("手术名称",new EventHandler(m_ctmOperation_Click));
			}
		}

		private void m_ctmOperation_Click(object sender,EventArgs e)
		{
			m_lstOperation.Items.Clear();

			clsTemplateSet_Associate[] m_objArr;
			new clsTemplateDomain().m_lngGetAllAssociate((int)enmAssociate.Operation,out m_objArr);
			if(m_objArr!=null && m_objArr.Length>0)
			{
				m_lstOperation.Items.AddRange(m_objArr);
			}

			System.Drawing.Point pt= m_txtParent.GetPositionFromCharIndex(m_txtParent.SelectionStart );

			m_lstOperation.Left = m_txtParent.Left + pt.X;
			m_lstOperation.Top = m_txtParent.Top + pt.Y + 20;
			
			m_lstOperation.Visible = true;
			m_lstOperation.BringToFront();
			if(m_lstOperation.Items.Count > 0)
				m_lstOperation.SelectedIndex = 0;
			m_lstOperation.Focus();
		}

		private void m_lstOperation_DoubleClick(object sender,EventArgs e)
		{
			ListBox lstOperation = (ListBox)sender;
			if(lstOperation.SelectedItems.Count > 0 && lstOperation.SelectedItems[0] != null)
			{
				m_txtParent.Tag = ((clsTemplateSet_Associate)lstOperation.SelectedItems[0]).strAssociateID;
			}
			m_txtParent.m_mthInsertText(((clsTemplateSet_Associate)lstOperation.SelectedItems[0]).strAssociateName,m_txtParent.SelectionStart);

			lstOperation.Visible = false;
			m_txtParent.Focus();
		}

		private void m_lstOperation_Leave(object sender, System.EventArgs e)
		{
			m_lstOperation.Visible = false;
			m_txtParent.Focus();
		}		

	}


	
}

