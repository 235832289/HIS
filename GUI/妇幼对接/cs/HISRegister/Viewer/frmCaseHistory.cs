using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCare.CustomForm;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCaseHistory 的摘要说明。
	/// </summary>
	public class frmCaseHistory : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private com.digitalwave.iCare.Template.Client.clsTemplateClient m_objTemplate;
		private com.digitalwave.iCare.Public.MenuExtend.clsMenuInteface m_objMenuInteface;
		/// <summary>
		/// 记录活动文本框
		/// </summary>
		private System.Windows.Forms.Control TempControl;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.controls.ctlRichTextBox txtDiagMain;
		private com.digitalwave.controls.ctlRichTextBox txtDiagCurr;
		private com.digitalwave.controls.ctlRichTextBox txtDiagHis;
        private com.digitalwave.controls.ctlRichTextBox txtAidCheck;
        internal com.digitalwave.controls.ctlRichTextBox txtDiag;
		private com.digitalwave.controls.ctlRichTextBox txtAnaphylaxis;
		private com.digitalwave.controls.ctlRichTextBox txtTreatment;
		private com.digitalwave.controls.ctlRichTextBox txtReMark;
		private com.digitalwave.controls.ctlRichTextBox txtPersonHis;
		private com.digitalwave.controls.ctlRichTextBox txtExamineResult;
		private System.Windows.Forms.Panel objpanel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menu_Template;
		private System.Windows.Forms.MenuItem menu_Copy;
		private System.Windows.Forms.MenuItem menu_Cut;
		private System.Windows.Forms.MenuItem menuI_Paste;
		private System.Windows.Forms.MenuItem menu_CreatTemplate;
		private System.Windows.Forms.MenuItem menu_changeTemplate;
		private System.Windows.Forms.LinkLabel linkLabel_txtReMark;
		private System.Windows.Forms.LinkLabel linkLabel_txtTreatment;
		private System.Windows.Forms.LinkLabel linkLabel_txtDiag;
		private System.Windows.Forms.LinkLabel linkLabel_txtAidCheck;
		private System.Windows.Forms.LinkLabel linkLabel_txtExamineResult;
		private System.Windows.Forms.LinkLabel linkLabel_txtPersonHis;
		private System.Windows.Forms.LinkLabel linkLabel_txtAnaphylaxis;
		private System.Windows.Forms.LinkLabel linkLabel_txtDiagHis;
		private System.Windows.Forms.LinkLabel linkLabel_txtDiagCurr;
		private System.Windows.Forms.LinkLabel linkLabel_txtDiagMain;
		private System.Windows.Forms.Button btShowID10;
		private System.Windows.Forms.MenuItem menuI_ICD10;
		private System.Windows.Forms.MenuItem menuI_Undo;
		private System.Windows.Forms.LinkLabel linkLabel_New;
		private com.digitalwave.controls.ctlRichTextBox txtChangeDepartment;
		private System.Windows.Forms.LinkLabel linkLabel_txtChangeDepartment;
		private System.Windows.Forms.Panel panel_Illness;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCaseHistory()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			objColor =new System.Drawing.Imaging.ColorMap();
//			objColor.NewColor=Color.Gray;
//			m_objMenuInteface =new com.digitalwave.iCare.Public.MenuExtend.clsMenuInteface();
						
			//获取当前操作员所属科室列表中的第一门诊科室
			string m_strDeptID = "";
			string m_strEmpID = this.LoginInfo.m_strEmpID;						

			com.digitalwave.GUI_Base.clsController_Base objCtlBase = new com.digitalwave.GUI_Base.clsController_Base();			
			com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;	
			objCtlBase.m_objComInfo.m_mthGetDepartmentByUserID(m_strEmpID, out objDept);					
			if(objDept != null)
			{ 
				for(int i=0; i<objDept.Length; i++)
				{
					if(objDept[i].intInPatientOrOutPatient == 0)
					{
						m_strDeptID = objDept[i].strDeptID;				
						break;
					}
				}
			}

			m_objTemplate=new com.digitalwave.iCare.Template.Client.clsTemplateClient(this,this.LoginInfo.m_strEmpID,m_strDeptID);
			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind =new com.digitalwave.common.ICD10.Tool.clsBindICD10();
			m_objIcd10Bind.m_mthBindICD10(this.btShowID10,this.txtDiag,1,1,null,null,false);
			m_objIcd10Bind.OnReturnData+=new com.digitalwave.common.ICD10.Tool.OnReturnDataEventHandler(m_objIcd10Bind_OnReturnData);
			objColor.NewColor=System.Drawing.Color.FromArgb(((System.Byte)(165)), ((System.Byte)(176)), ((System.Byte)(189)));
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			foreach(System.Windows.Forms.Control c in objpanel.Controls)
			{
				if(c is com.digitalwave.controls.ctlRichTextBox)
				{
					((com.digitalwave.controls.ctlRichTextBox)c).ContentsResized+=new ContentsResizedEventHandler(frmCaseHistory_ContentsResized);
					((com.digitalwave.controls.ctlRichTextBox)c).Enter+=new EventHandler(frmCaseHistory_Enter);
					((com.digitalwave.controls.ctlRichTextBox)c).Leave+=new EventHandler(frmCaseHistory_Leave);
				}
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistory));
            this.objpanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Illness = new System.Windows.Forms.Panel();
            this.txtChangeDepartment = new com.digitalwave.controls.ctlRichTextBox();
            this.linkLabel_txtChangeDepartment = new System.Windows.Forms.LinkLabel();
            this.linkLabel_New = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtReMark = new com.digitalwave.controls.ctlRichTextBox();
            this.txtExamineResult = new com.digitalwave.controls.ctlRichTextBox();
            this.txtPersonHis = new com.digitalwave.controls.ctlRichTextBox();
            this.txtTreatment = new com.digitalwave.controls.ctlRichTextBox();
            this.txtAnaphylaxis = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDiag = new com.digitalwave.controls.ctlRichTextBox();
            this.txtAidCheck = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDiagHis = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDiagCurr = new com.digitalwave.controls.ctlRichTextBox();
            this.txtDiagMain = new com.digitalwave.controls.ctlRichTextBox();
            this.linkLabel_txtReMark = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtTreatment = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtDiag = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtAidCheck = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtExamineResult = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtPersonHis = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtAnaphylaxis = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtDiagHis = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtDiagCurr = new System.Windows.Forms.LinkLabel();
            this.linkLabel_txtDiagMain = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menu_Template = new System.Windows.Forms.MenuItem();
            this.menu_CreatTemplate = new System.Windows.Forms.MenuItem();
            this.menu_changeTemplate = new System.Windows.Forms.MenuItem();
            this.menu_Cut = new System.Windows.Forms.MenuItem();
            this.menu_Copy = new System.Windows.Forms.MenuItem();
            this.menuI_Paste = new System.Windows.Forms.MenuItem();
            this.menuI_ICD10 = new System.Windows.Forms.MenuItem();
            this.menuI_Undo = new System.Windows.Forms.MenuItem();
            this.btShowID10 = new System.Windows.Forms.Button();
            this.objpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // objpanel
            // 
            this.objpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objpanel.BackColor = System.Drawing.Color.White;
            this.objpanel.Controls.Add(this.label2);
            this.objpanel.Controls.Add(this.panel_Illness);
            this.objpanel.Controls.Add(this.txtChangeDepartment);
            this.objpanel.Controls.Add(this.linkLabel_txtChangeDepartment);
            this.objpanel.Controls.Add(this.linkLabel_New);
            this.objpanel.Controls.Add(this.label1);
            this.objpanel.Controls.Add(this.pictureBox1);
            this.objpanel.Controls.Add(this.txtReMark);
            this.objpanel.Controls.Add(this.txtExamineResult);
            this.objpanel.Controls.Add(this.txtPersonHis);
            this.objpanel.Controls.Add(this.txtTreatment);
            this.objpanel.Controls.Add(this.txtAnaphylaxis);
            this.objpanel.Controls.Add(this.txtDiag);
            this.objpanel.Controls.Add(this.txtAidCheck);
            this.objpanel.Controls.Add(this.txtDiagHis);
            this.objpanel.Controls.Add(this.txtDiagCurr);
            this.objpanel.Controls.Add(this.txtDiagMain);
            this.objpanel.Controls.Add(this.linkLabel_txtReMark);
            this.objpanel.Controls.Add(this.linkLabel_txtTreatment);
            this.objpanel.Controls.Add(this.linkLabel_txtDiag);
            this.objpanel.Controls.Add(this.linkLabel_txtAidCheck);
            this.objpanel.Controls.Add(this.linkLabel_txtExamineResult);
            this.objpanel.Controls.Add(this.linkLabel_txtPersonHis);
            this.objpanel.Controls.Add(this.linkLabel_txtAnaphylaxis);
            this.objpanel.Controls.Add(this.linkLabel_txtDiagHis);
            this.objpanel.Controls.Add(this.linkLabel_txtDiagCurr);
            this.objpanel.Controls.Add(this.linkLabel_txtDiagMain);
            this.objpanel.Location = new System.Drawing.Point(20, 16);
            this.objpanel.Name = "objpanel";
            this.objpanel.Size = new System.Drawing.Size(756, 464);
            this.objpanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(36, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "ICD 编码：";
            // 
            // panel_Illness
            // 
            this.panel_Illness.Location = new System.Drawing.Point(112, 436);
            this.panel_Illness.Name = "panel_Illness";
            this.panel_Illness.Size = new System.Drawing.Size(608, 28);
            this.panel_Illness.TabIndex = 22;
            // 
            // txtChangeDepartment
            // 
            this.txtChangeDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChangeDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChangeDepartment.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtChangeDepartment.Location = new System.Drawing.Point(116, 286);
            this.txtChangeDepartment.m_BlnIgnoreUserInfo = true;
            this.txtChangeDepartment.m_BlnPartControl = false;
            this.txtChangeDepartment.m_BlnReadOnly = false;
            this.txtChangeDepartment.m_BlnUnderLineDST = false;
            this.txtChangeDepartment.m_ClrDST = System.Drawing.Color.Red;
            this.txtChangeDepartment.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtChangeDepartment.m_IntCanModifyTime = 6;
            this.txtChangeDepartment.m_IntPartControlLength = 0;
            this.txtChangeDepartment.m_IntPartControlStartIndex = 0;
            this.txtChangeDepartment.m_StrUserID = "";
            this.txtChangeDepartment.m_StrUserName = "";
            this.txtChangeDepartment.MaxLength = 1000;
            this.txtChangeDepartment.Name = "txtChangeDepartment";
            this.txtChangeDepartment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtChangeDepartment.Size = new System.Drawing.Size(600, 19);
            this.txtChangeDepartment.TabIndex = 6;
            this.txtChangeDepartment.Text = "";
            // 
            // linkLabel_txtChangeDepartment
            // 
            this.linkLabel_txtChangeDepartment.AutoSize = true;
            this.linkLabel_txtChangeDepartment.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtChangeDepartment.Location = new System.Drawing.Point(36, 286);
            this.linkLabel_txtChangeDepartment.Name = "linkLabel_txtChangeDepartment";
            this.linkLabel_txtChangeDepartment.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtChangeDepartment.TabIndex = 17;
            this.linkLabel_txtChangeDepartment.TabStop = true;
            this.linkLabel_txtChangeDepartment.Text = "专科情况:";
            this.linkLabel_txtChangeDepartment.Click += new System.EventHandler(this.linkLabel_txtChangeDepartment_Click);
            // 
            // linkLabel_New
            // 
            this.linkLabel_New.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabel_New.LinkColor = System.Drawing.Color.Teal;
            this.linkLabel_New.Location = new System.Drawing.Point(656, 64);
            this.linkLabel_New.Name = "linkLabel_New";
            this.linkLabel_New.Size = new System.Drawing.Size(52, 20);
            this.linkLabel_New.TabIndex = 21;
            this.linkLabel_New.TabStop = true;
            this.linkLabel_New.Text = "新 建";
            this.linkLabel_New.Click += new System.EventHandler(this.linkLabel_New_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(676, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "门诊病历";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(756, 52);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // txtReMark
            // 
            this.txtReMark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReMark.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtReMark.Location = new System.Drawing.Point(116, 410);
            this.txtReMark.m_BlnIgnoreUserInfo = true;
            this.txtReMark.m_BlnPartControl = false;
            this.txtReMark.m_BlnReadOnly = false;
            this.txtReMark.m_BlnUnderLineDST = false;
            this.txtReMark.m_ClrDST = System.Drawing.Color.Red;
            this.txtReMark.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtReMark.m_IntCanModifyTime = 6;
            this.txtReMark.m_IntPartControlLength = 0;
            this.txtReMark.m_IntPartControlStartIndex = 0;
            this.txtReMark.m_StrUserID = "";
            this.txtReMark.m_StrUserName = "";
            this.txtReMark.MaxLength = 1000;
            this.txtReMark.Multiline = false;
            this.txtReMark.Name = "txtReMark";
            this.txtReMark.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtReMark.Size = new System.Drawing.Size(600, 19);
            this.txtReMark.TabIndex = 10;
            this.txtReMark.Text = "";
            // 
            // txtExamineResult
            // 
            this.txtExamineResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExamineResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExamineResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtExamineResult.Location = new System.Drawing.Point(116, 255);
            this.txtExamineResult.m_BlnIgnoreUserInfo = true;
            this.txtExamineResult.m_BlnPartControl = false;
            this.txtExamineResult.m_BlnReadOnly = false;
            this.txtExamineResult.m_BlnUnderLineDST = false;
            this.txtExamineResult.m_ClrDST = System.Drawing.Color.Red;
            this.txtExamineResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtExamineResult.m_IntCanModifyTime = 6;
            this.txtExamineResult.m_IntPartControlLength = 0;
            this.txtExamineResult.m_IntPartControlStartIndex = 0;
            this.txtExamineResult.m_StrUserID = "";
            this.txtExamineResult.m_StrUserName = "";
            this.txtExamineResult.MaxLength = 1000;
            this.txtExamineResult.Name = "txtExamineResult";
            this.txtExamineResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtExamineResult.Size = new System.Drawing.Size(600, 19);
            this.txtExamineResult.TabIndex = 5;
            this.txtExamineResult.Text = "";
            // 
            // txtPersonHis
            // 
            this.txtPersonHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersonHis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPersonHis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPersonHis.Location = new System.Drawing.Point(116, 224);
            this.txtPersonHis.m_BlnIgnoreUserInfo = true;
            this.txtPersonHis.m_BlnPartControl = false;
            this.txtPersonHis.m_BlnReadOnly = false;
            this.txtPersonHis.m_BlnUnderLineDST = false;
            this.txtPersonHis.m_ClrDST = System.Drawing.Color.Red;
            this.txtPersonHis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtPersonHis.m_IntCanModifyTime = 6;
            this.txtPersonHis.m_IntPartControlLength = 0;
            this.txtPersonHis.m_IntPartControlStartIndex = 0;
            this.txtPersonHis.m_StrUserID = "";
            this.txtPersonHis.m_StrUserName = "";
            this.txtPersonHis.MaxLength = 1000;
            this.txtPersonHis.Name = "txtPersonHis";
            this.txtPersonHis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPersonHis.Size = new System.Drawing.Size(600, 19);
            this.txtPersonHis.TabIndex = 4;
            this.txtPersonHis.Text = "";
            // 
            // txtTreatment
            // 
            this.txtTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTreatment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTreatment.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTreatment.Location = new System.Drawing.Point(116, 379);
            this.txtTreatment.m_BlnIgnoreUserInfo = true;
            this.txtTreatment.m_BlnPartControl = false;
            this.txtTreatment.m_BlnReadOnly = false;
            this.txtTreatment.m_BlnUnderLineDST = false;
            this.txtTreatment.m_ClrDST = System.Drawing.Color.Red;
            this.txtTreatment.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtTreatment.m_IntCanModifyTime = 6;
            this.txtTreatment.m_IntPartControlLength = 0;
            this.txtTreatment.m_IntPartControlStartIndex = 0;
            this.txtTreatment.m_StrUserID = "";
            this.txtTreatment.m_StrUserName = "";
            this.txtTreatment.MaxLength = 1000;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtTreatment.Size = new System.Drawing.Size(600, 19);
            this.txtTreatment.TabIndex = 9;
            this.txtTreatment.Text = "";
            // 
            // txtAnaphylaxis
            // 
            this.txtAnaphylaxis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnaphylaxis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAnaphylaxis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAnaphylaxis.Location = new System.Drawing.Point(116, 193);
            this.txtAnaphylaxis.m_BlnIgnoreUserInfo = true;
            this.txtAnaphylaxis.m_BlnPartControl = false;
            this.txtAnaphylaxis.m_BlnReadOnly = false;
            this.txtAnaphylaxis.m_BlnUnderLineDST = false;
            this.txtAnaphylaxis.m_ClrDST = System.Drawing.Color.Red;
            this.txtAnaphylaxis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAnaphylaxis.m_IntCanModifyTime = 6;
            this.txtAnaphylaxis.m_IntPartControlLength = 0;
            this.txtAnaphylaxis.m_IntPartControlStartIndex = 0;
            this.txtAnaphylaxis.m_StrUserID = "";
            this.txtAnaphylaxis.m_StrUserName = "";
            this.txtAnaphylaxis.MaxLength = 1000;
            this.txtAnaphylaxis.Name = "txtAnaphylaxis";
            this.txtAnaphylaxis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAnaphylaxis.Size = new System.Drawing.Size(600, 19);
            this.txtAnaphylaxis.TabIndex = 3;
            this.txtAnaphylaxis.Text = "";
            // 
            // txtDiag
            // 
            this.txtDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiag.Location = new System.Drawing.Point(116, 348);
            this.txtDiag.m_BlnIgnoreUserInfo = true;
            this.txtDiag.m_BlnPartControl = false;
            this.txtDiag.m_BlnReadOnly = false;
            this.txtDiag.m_BlnUnderLineDST = false;
            this.txtDiag.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiag.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiag.m_IntCanModifyTime = 6;
            this.txtDiag.m_IntPartControlLength = 0;
            this.txtDiag.m_IntPartControlStartIndex = 0;
            this.txtDiag.m_StrUserID = "";
            this.txtDiag.m_StrUserName = "";
            this.txtDiag.MaxLength = 1000;
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDiag.Size = new System.Drawing.Size(600, 19);
            this.txtDiag.TabIndex = 8;
            this.txtDiag.Text = "";
            // 
            // txtAidCheck
            // 
            this.txtAidCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAidCheck.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAidCheck.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtAidCheck.Location = new System.Drawing.Point(116, 317);
            this.txtAidCheck.m_BlnIgnoreUserInfo = true;
            this.txtAidCheck.m_BlnPartControl = false;
            this.txtAidCheck.m_BlnReadOnly = false;
            this.txtAidCheck.m_BlnUnderLineDST = false;
            this.txtAidCheck.m_ClrDST = System.Drawing.Color.Red;
            this.txtAidCheck.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtAidCheck.m_IntCanModifyTime = 6;
            this.txtAidCheck.m_IntPartControlLength = 0;
            this.txtAidCheck.m_IntPartControlStartIndex = 0;
            this.txtAidCheck.m_StrUserID = "";
            this.txtAidCheck.m_StrUserName = "";
            this.txtAidCheck.MaxLength = 1000;
            this.txtAidCheck.Name = "txtAidCheck";
            this.txtAidCheck.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAidCheck.Size = new System.Drawing.Size(600, 19);
            this.txtAidCheck.TabIndex = 7;
            this.txtAidCheck.Text = "";
            // 
            // txtDiagHis
            // 
            this.txtDiagHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagHis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiagHis.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagHis.Location = new System.Drawing.Point(116, 162);
            this.txtDiagHis.m_BlnIgnoreUserInfo = true;
            this.txtDiagHis.m_BlnPartControl = false;
            this.txtDiagHis.m_BlnReadOnly = false;
            this.txtDiagHis.m_BlnUnderLineDST = false;
            this.txtDiagHis.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagHis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagHis.m_IntCanModifyTime = 6;
            this.txtDiagHis.m_IntPartControlLength = 0;
            this.txtDiagHis.m_IntPartControlStartIndex = 0;
            this.txtDiagHis.m_StrUserID = "";
            this.txtDiagHis.m_StrUserName = "";
            this.txtDiagHis.MaxLength = 1000;
            this.txtDiagHis.Name = "txtDiagHis";
            this.txtDiagHis.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDiagHis.Size = new System.Drawing.Size(600, 19);
            this.txtDiagHis.TabIndex = 2;
            this.txtDiagHis.Text = "";
            // 
            // txtDiagCurr
            // 
            this.txtDiagCurr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagCurr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiagCurr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagCurr.Location = new System.Drawing.Point(116, 131);
            this.txtDiagCurr.m_BlnIgnoreUserInfo = true;
            this.txtDiagCurr.m_BlnPartControl = false;
            this.txtDiagCurr.m_BlnReadOnly = false;
            this.txtDiagCurr.m_BlnUnderLineDST = false;
            this.txtDiagCurr.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagCurr.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagCurr.m_IntCanModifyTime = 6;
            this.txtDiagCurr.m_IntPartControlLength = 0;
            this.txtDiagCurr.m_IntPartControlStartIndex = 0;
            this.txtDiagCurr.m_StrUserID = "";
            this.txtDiagCurr.m_StrUserName = "";
            this.txtDiagCurr.MaxLength = 1000;
            this.txtDiagCurr.Name = "txtDiagCurr";
            this.txtDiagCurr.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDiagCurr.Size = new System.Drawing.Size(600, 19);
            this.txtDiagCurr.TabIndex = 1;
            this.txtDiagCurr.Text = "";
            // 
            // txtDiagMain
            // 
            this.txtDiagMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiagMain.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDiagMain.Location = new System.Drawing.Point(116, 100);
            this.txtDiagMain.m_BlnIgnoreUserInfo = true;
            this.txtDiagMain.m_BlnPartControl = false;
            this.txtDiagMain.m_BlnReadOnly = false;
            this.txtDiagMain.m_BlnUnderLineDST = false;
            this.txtDiagMain.m_ClrDST = System.Drawing.Color.Red;
            this.txtDiagMain.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtDiagMain.m_IntCanModifyTime = 6;
            this.txtDiagMain.m_IntPartControlLength = 0;
            this.txtDiagMain.m_IntPartControlStartIndex = 0;
            this.txtDiagMain.m_StrUserID = "";
            this.txtDiagMain.m_StrUserName = "";
            this.txtDiagMain.MaxLength = 1000;
            this.txtDiagMain.Multiline = false;
            this.txtDiagMain.Name = "txtDiagMain";
            this.txtDiagMain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtDiagMain.Size = new System.Drawing.Size(600, 19);
            this.txtDiagMain.TabIndex = 0;
            this.txtDiagMain.Text = "";
            // 
            // linkLabel_txtReMark
            // 
            this.linkLabel_txtReMark.AutoSize = true;
            this.linkLabel_txtReMark.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtReMark.Location = new System.Drawing.Point(36, 410);
            this.linkLabel_txtReMark.Name = "linkLabel_txtReMark";
            this.linkLabel_txtReMark.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtReMark.TabIndex = 21;
            this.linkLabel_txtReMark.TabStop = true;
            this.linkLabel_txtReMark.Text = "备    注:";
            this.linkLabel_txtReMark.Click += new System.EventHandler(this.linkLabel_txtReMark_Click);
            // 
            // linkLabel_txtTreatment
            // 
            this.linkLabel_txtTreatment.AutoSize = true;
            this.linkLabel_txtTreatment.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtTreatment.Location = new System.Drawing.Point(36, 379);
            this.linkLabel_txtTreatment.Name = "linkLabel_txtTreatment";
            this.linkLabel_txtTreatment.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtTreatment.TabIndex = 20;
            this.linkLabel_txtTreatment.TabStop = true;
            this.linkLabel_txtTreatment.Text = "处    置:";
            this.linkLabel_txtTreatment.Click += new System.EventHandler(this.linkLabel_txtTreatment_Click);
            // 
            // linkLabel_txtDiag
            // 
            this.linkLabel_txtDiag.AutoSize = true;
            this.linkLabel_txtDiag.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtDiag.Location = new System.Drawing.Point(36, 348);
            this.linkLabel_txtDiag.Name = "linkLabel_txtDiag";
            this.linkLabel_txtDiag.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtDiag.TabIndex = 19;
            this.linkLabel_txtDiag.TabStop = true;
            this.linkLabel_txtDiag.Text = "诊    断:";
            this.linkLabel_txtDiag.Click += new System.EventHandler(this.linkLabel_txtDiag_Click);
            // 
            // linkLabel_txtAidCheck
            // 
            this.linkLabel_txtAidCheck.AutoSize = true;
            this.linkLabel_txtAidCheck.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtAidCheck.Location = new System.Drawing.Point(36, 317);
            this.linkLabel_txtAidCheck.Name = "linkLabel_txtAidCheck";
            this.linkLabel_txtAidCheck.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtAidCheck.TabIndex = 18;
            this.linkLabel_txtAidCheck.TabStop = true;
            this.linkLabel_txtAidCheck.Text = "辅助检查:";
            this.linkLabel_txtAidCheck.Click += new System.EventHandler(this.linkLabel_txtAidCheck_Click);
            // 
            // linkLabel_txtExamineResult
            // 
            this.linkLabel_txtExamineResult.AutoSize = true;
            this.linkLabel_txtExamineResult.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtExamineResult.Location = new System.Drawing.Point(36, 255);
            this.linkLabel_txtExamineResult.Name = "linkLabel_txtExamineResult";
            this.linkLabel_txtExamineResult.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtExamineResult.TabIndex = 16;
            this.linkLabel_txtExamineResult.TabStop = true;
            this.linkLabel_txtExamineResult.Text = "体格检查:";
            this.linkLabel_txtExamineResult.Click += new System.EventHandler(this.linkLabel_txtExamineResult_Click);
            // 
            // linkLabel_txtPersonHis
            // 
            this.linkLabel_txtPersonHis.AutoSize = true;
            this.linkLabel_txtPersonHis.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtPersonHis.Location = new System.Drawing.Point(36, 224);
            this.linkLabel_txtPersonHis.Name = "linkLabel_txtPersonHis";
            this.linkLabel_txtPersonHis.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtPersonHis.TabIndex = 15;
            this.linkLabel_txtPersonHis.TabStop = true;
            this.linkLabel_txtPersonHis.Text = "个 人 史:";
            this.linkLabel_txtPersonHis.Click += new System.EventHandler(this.linkLabel_txtPersonHis_Click);
            // 
            // linkLabel_txtAnaphylaxis
            // 
            this.linkLabel_txtAnaphylaxis.AutoSize = true;
            this.linkLabel_txtAnaphylaxis.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtAnaphylaxis.Location = new System.Drawing.Point(36, 193);
            this.linkLabel_txtAnaphylaxis.Name = "linkLabel_txtAnaphylaxis";
            this.linkLabel_txtAnaphylaxis.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtAnaphylaxis.TabIndex = 14;
            this.linkLabel_txtAnaphylaxis.TabStop = true;
            this.linkLabel_txtAnaphylaxis.Text = "过 敏 史:";
            this.linkLabel_txtAnaphylaxis.Click += new System.EventHandler(this.linkLabel_txtAnaphylaxis_Click);
            // 
            // linkLabel_txtDiagHis
            // 
            this.linkLabel_txtDiagHis.AutoSize = true;
            this.linkLabel_txtDiagHis.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtDiagHis.Location = new System.Drawing.Point(36, 162);
            this.linkLabel_txtDiagHis.Name = "linkLabel_txtDiagHis";
            this.linkLabel_txtDiagHis.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtDiagHis.TabIndex = 13;
            this.linkLabel_txtDiagHis.TabStop = true;
            this.linkLabel_txtDiagHis.Text = "既 往 史:";
            this.linkLabel_txtDiagHis.Click += new System.EventHandler(this.linkLabel_txtDiagHis_Click);
            // 
            // linkLabel_txtDiagCurr
            // 
            this.linkLabel_txtDiagCurr.AutoSize = true;
            this.linkLabel_txtDiagCurr.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtDiagCurr.Location = new System.Drawing.Point(36, 131);
            this.linkLabel_txtDiagCurr.Name = "linkLabel_txtDiagCurr";
            this.linkLabel_txtDiagCurr.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtDiagCurr.TabIndex = 12;
            this.linkLabel_txtDiagCurr.TabStop = true;
            this.linkLabel_txtDiagCurr.Text = "现 病 史:";
            this.linkLabel_txtDiagCurr.Click += new System.EventHandler(this.linkLabel_txtDiagCurr_Click);
            // 
            // linkLabel_txtDiagMain
            // 
            this.linkLabel_txtDiagMain.AutoSize = true;
            this.linkLabel_txtDiagMain.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_txtDiagMain.Location = new System.Drawing.Point(36, 100);
            this.linkLabel_txtDiagMain.Name = "linkLabel_txtDiagMain";
            this.linkLabel_txtDiagMain.Size = new System.Drawing.Size(70, 14);
            this.linkLabel_txtDiagMain.TabIndex = 11;
            this.linkLabel_txtDiagMain.TabStop = true;
            this.linkLabel_txtDiagMain.Text = "主    诉:";
            this.linkLabel_txtDiagMain.Click += new System.EventHandler(this.linkLabel_txtDiagMain_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Location = new System.Drawing.Point(0, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 20);
            this.panel2.TabIndex = 1;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_Template,
            this.menu_Cut,
            this.menu_Copy,
            this.menuI_Paste,
            this.menuI_ICD10,
            this.menuI_Undo});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // menu_Template
            // 
            this.menu_Template.Index = 0;
            this.menu_Template.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu_CreatTemplate,
            this.menu_changeTemplate});
            this.menu_Template.Text = "模板维护";
            // 
            // menu_CreatTemplate
            // 
            this.menu_CreatTemplate.Index = 0;
            this.menu_CreatTemplate.Text = "生成模板";
            this.menu_CreatTemplate.Click += new System.EventHandler(this.menu_CreatTemplate_Click);
            // 
            // menu_changeTemplate
            // 
            this.menu_changeTemplate.Index = 1;
            this.menu_changeTemplate.Text = "修改模板";
            this.menu_changeTemplate.Click += new System.EventHandler(this.menu_changeTemplate_Click);
            // 
            // menu_Cut
            // 
            this.menu_Cut.Index = 1;
            this.menu_Cut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menu_Cut.Text = "剪切";
            this.menu_Cut.Click += new System.EventHandler(this.menu_Cut_Click);
            // 
            // menu_Copy
            // 
            this.menu_Copy.Index = 2;
            this.menu_Copy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menu_Copy.Text = "复制";
            this.menu_Copy.Click += new System.EventHandler(this.menu_Copy_Click);
            // 
            // menuI_Paste
            // 
            this.menuI_Paste.Index = 3;
            this.menuI_Paste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuI_Paste.Text = "粘贴";
            this.menuI_Paste.Click += new System.EventHandler(this.menuI_Paste_Click);
            // 
            // menuI_ICD10
            // 
            this.menuI_ICD10.Index = 4;
            this.menuI_ICD10.Text = "辅助诊疗";
            this.menuI_ICD10.Click += new System.EventHandler(this.menuI_ICD10_Click);
            // 
            // menuI_Undo
            // 
            this.menuI_Undo.Index = 5;
            this.menuI_Undo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuI_Undo.Text = "撤消";
            this.menuI_Undo.Click += new System.EventHandler(this.menuI_Undo_Click);
            // 
            // btShowID10
            // 
            this.btShowID10.Location = new System.Drawing.Point(64, 76);
            this.btShowID10.Name = "btShowID10";
            this.btShowID10.Size = new System.Drawing.Size(75, 23);
            this.btShowID10.TabIndex = 2;
            this.btShowID10.Text = "button1";
            // 
            // frmCaseHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(796, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.objpanel);
            this.Controls.Add(this.btShowID10);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCaseHistory";
            this.Load += new System.EventHandler(this.frmCaseHistory_Load);
            this.objpanel.ResumeLayout(false);
            this.objpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		#region 公共属性
		private string strCaseHistoryID ="";
		/// <summary>
		/// 病历ID
		/// </summary>
		public string CaseHistoryID
		{
			set
			{
			strCaseHistoryID =value;
			}
			get
			{
			return strCaseHistoryID;
			}
		}
		private string strParentCaseHistoryID ="";

		private void frmCaseHistory_Load(object sender, System.EventArgs e)
		{
//			foreach(System.Windows.Forms.Control c in objpanel.Controls)
//			{
//				if(c is com.digitalwave.controls.ctlRichTextBox)
//				{
//					((com.digitalwave.controls.ctlRichTextBox)c).ContentsResized+=new ContentsResizedEventHandler(frmCaseHistory_ContentsResized);
//					((com.digitalwave.controls.ctlRichTextBox)c).Enter+=new EventHandler(frmCaseHistory_Enter);
//					((com.digitalwave.controls.ctlRichTextBox)c).Leave+=new EventHandler(frmCaseHistory_Leave);
//				}
//			}
			m_mthGetMenu();
		}
		/// <summary>
		/// 父病历ID
		/// </summary>
		public string ParentCaseHistoryID
		{
			set
			{
				strParentCaseHistoryID =value;
			}
			get
			{
				return strParentCaseHistoryID;
			}
		}

		/// <summary>
		/// 主诉
		/// </summary>
		public string DiagMain
		{
			set
			{
				this.txtDiagMain.Text =value;
			}
			get
			{
				return this.txtDiagMain.Text;
			}
		}
		/// <summary>
		/// 现病史
		/// </summary>
		public string DiagCurr
		{
			set
			{
				this.txtDiagCurr.Text =value;
			}
			get
			{
				return this.txtDiagCurr.Text;
			}
		}
		/// <summary>
		/// 既病史
		/// </summary>
		public string DiagHis
		{
			set
			{
				this.txtDiagHis.Text =value;
			}
			get
			{
				return this.txtDiagHis.Text;
			}
		}
		/// <summary>
		/// 过敏源
		/// </summary>
		public string Anaphylaxis
		{
			set
			{
				this.txtAnaphylaxis.Text =value;
			}
			get
			{
				return this.txtAnaphylaxis.Text;
			}
		}
		/// <summary>
		/// 个人史
		/// </summary>
		public string PersonHis
		{
			set
			{
				this.txtPersonHis.Text =value;
			}
			get
			{
				return this.txtPersonHis.Text;
			}
		}
		/// <summary>
		/// 体格检查
		/// </summary>
		public string ExamineResult
		{
			set
			{
				this.txtExamineResult.Text =value;
			}
			get
			{
				return this.txtExamineResult.Text;
			}
		}
		/// <summary>
		/// 辅助检查
		/// </summary>
		public string AidCheck
		{
			set
			{
				this.txtAidCheck.Text =value;
			}
			get
			{
				return this.txtAidCheck.Text.Trim();
			}
		}
		/// <summary>
		/// 诊断
		/// </summary>
		public string Diag
		{
			set
			{
				this.txtDiag.Text =value;
			}
			get
			{
				return this.txtDiag.Text.Trim();
			}
		}
		/// <summary>
		/// 处置
		/// </summary>
		public string Treatment
		{
			set
			{
				this.txtTreatment.Text =value;
			}
			get
			{
				return this.txtTreatment.Text.Trim();
			}
		}
		/// <summary>
		/// 转科情况
		/// </summary>
		public string ChangeDepartment
		{
			set
			{
				this.txtChangeDepartment.Text =value;
			}
			get
			{
				return this.txtChangeDepartment.Text.Trim();
			}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string ReMark
		{
			set
			{
				this.txtReMark.Text =value;
			}
			get
			{
				return this.txtReMark.Text.Trim();
			}
		}
		private string strPatinetID="";
		/// <summary>
		/// 病人ID
		/// </summary>
		public string PatinetID
		{
			set
			{
				strPatinetID =value;
			}
			get
			{
				return strPatinetID;
			}
		}
		private ArrayList obj_ICD10;
		/// <summary>
		/// 获取或设置ICD10数据
		/// </summary>
		public ArrayList ICD10
		{
			get
			{
				return obj_ICD10 ;
			}
			set
			{
				obj_ICD10 =value;
				m_mthShowICD10();
			}
		}
		#endregion
		private void m_mthShowICD10()
		{
			this.panel_Illness.Controls.Clear();
			int x =0;
			ContextMenu menu =new ContextMenu();
			MenuItem mi =new MenuItem("删除");
			mi.Click+=new EventHandler(MenuItem_Click);
			menu.MenuItems.Add(mi);
			ToolTip toolTip =new ToolTip();
			for(int i=0;i<obj_ICD10.Count;i++)
			{
				clsICD10_VO  obj =obj_ICD10[i] as clsICD10_VO;
				LinkLabel link =new LinkLabel();
				link.AutoSize =true;
				link.LinkBehavior=LinkBehavior.HoverUnderline;
				link.TabIndex =i;
				link.Text =obj.strICDCODE_VCHR+"、";
				this.panel_Illness.Controls.Add(link);
				link.Click+=new EventHandler(link_Click);
				toolTip.SetToolTip(link,"疾病编码:"+obj.strICDCODE_VCHR +"\n疾病名称:"+obj.strICDNAME_VCHR);

				link.Left =x;
				link.Top=5;
				link.Show();
				x+=link.Width;
				link.ContextMenu =menu;
			}
		}
		private void frmCaseHistory_ContentsResized(object sender, ContentsResizedEventArgs e)
		{
			com.digitalwave.controls.ctlRichTextBox objTemp =sender as com.digitalwave.controls.ctlRichTextBox;
			if(objTemp.Multiline==true)
			{
			m_mthMoveLocation(objTemp,e.NewRectangle.Height-objTemp.Height);
			}
		}
		private void m_mthMoveLocation(System.Windows.Forms.Control objControl,int p_Size)
		{
			this.objpanel.Height +=p_Size;
			objControl.Height +=p_Size;
			foreach(System.Windows.Forms.Control c in objpanel.Controls)
			{
				if(c.Top>objControl.Top)
				{
					c.Top+=p_Size;
				}
			}
		}
		public void m_mthClearData()
		{
			this.strCaseHistoryID="";
			this.strParentCaseHistoryID="";
			this.panel_Illness.Controls.Clear();
			if(this.obj_ICD10!=null)
			{
				this.obj_ICD10.Clear();
			}
			foreach(System.Windows.Forms.Control c in objpanel.Controls)
			{
				if(c is com.digitalwave.controls.ctlRichTextBox)
				{
					((com.digitalwave.controls.ctlRichTextBox)c).Text="";
				}
			}
		}
		public void m_mthClearData(int i)
		{
			foreach(System.Windows.Forms.Control c in objpanel.Controls)
			{
				if(c is com.digitalwave.controls.ctlRichTextBox)
				{
					((com.digitalwave.controls.ctlRichTextBox)c).Text="";
				}
			}
		}
		public void m_mthSetFouces()
		{
		this.txtDiagMain.Focus();
		}
		private System.Drawing.Imaging.ColorMap objColor;
		private void frmCaseHistory_Enter(object sender, EventArgs e)
		{
			TempControl =(System.Windows.Forms.Control)sender;
			objColor.OldColor=((System.Windows.Forms.Control)sender).BackColor;
			((System.Windows.Forms.Control)sender).BackColor =objColor.NewColor;
		}

		private void frmCaseHistory_Leave(object sender, EventArgs e)
		{
			((System.Windows.Forms.Control)sender).BackColor =objColor.OldColor;
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
//			m_objMenuInteface.m_mthSetARDataShareCondition(this.strPatinetID,TempControl);
//			m_objMenuInteface.m_mthSetDataShareSubMenu(m_mniIntelligenShare,false);
//			m_objMenuInteface.m_mthSetDataShareSubMenu(m_mniDataInvoking,true);
//			m_objMenuInteface.m_mthInitSubScriptItems(m_mniSubScript);
//			m_objMenuInteface.m_mthInitSpecialSymbolItems(m_mniSpecialSymbol);
//			m_objMenuInteface.m_mthInitLabCheckResultItems(m_mniLabCheckResult);
//			m_objMenuInteface.m_mthInitCheckResultItems(m_mniCheckResult);
		}
		#region
		private void m_mthGetMenu()
		{
//			 System.Windows.Forms.ContextMenu objTemp =p_control.ContextMenu;
			if(this.txtAidCheck.ContextMenu!=null)
			{
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menu_Template);
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menu_Cut);
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menu_Copy);
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menuI_Paste);
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menuI_Undo);
				this.txtAidCheck.ContextMenu.MenuItems.Add(this.menuI_ICD10);
				this.txtExamineResult.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtDiag.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtDiagCurr.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtDiagHis.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtDiagMain.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtExamineResult.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtPersonHis.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtReMark.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtTreatment.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtAnaphylaxis.ContextMenu =this.txtAidCheck.ContextMenu;
				this.txtChangeDepartment.ContextMenu =this.txtAidCheck.ContextMenu;
			}
//			if(this.txtExamineResult.ContextMenu!=null)
//			{
//				this.txtExamineResult.ContextMenu.MenuItems.Add(this.menu_Template);
//			}
//
//			if(this.txtDiag.ContextMenu!=null)
//			{
//				this.txtDiag.ContextMenu.MenuItems.Add(this.menu_Template);
//			}
	
		}
		#endregion

	

		private void menu_CreatTemplate_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthCreateTemplate();
		}

		private void menu_changeTemplate_Click(object sender, System.EventArgs e)
		{
			this.m_objTemplate.m_mthManageTemplate();
		}

		private void menu_Cut_Click(object sender, System.EventArgs e)
		{
			RichTextBox  objRTBox =TempControl as RichTextBox;
			objRTBox.Cut();
		}

		private void menu_Copy_Click(object sender, System.EventArgs e)
		{
			RichTextBox  objRTBox =TempControl as RichTextBox;
			objRTBox.Copy();
		}

		private void menuI_Paste_Click(object sender, System.EventArgs e)
		{
			RichTextBox  objRTBox =TempControl as RichTextBox;
			objRTBox.Paste();
		}

		private void linkLabel_txtDiagMain_Click(object sender, System.EventArgs e)
		{
			m_mth(txtDiagMain);
		}

		private void linkLabel_txtDiagCurr_Click(object sender, System.EventArgs e)
		{
			m_mth(txtDiagCurr);
		}

		private void linkLabel_txtDiagHis_Click(object sender, System.EventArgs e)
		{
			m_mth(txtDiagHis);
		}

		private void linkLabel_txtAnaphylaxis_Click(object sender, System.EventArgs e)
		{
			m_mth(txtAnaphylaxis);
		}

		private void linkLabel_txtPersonHis_Click(object sender, System.EventArgs e)
		{
			m_mth(txtPersonHis);
		}

		private void linkLabel_txtExamineResult_Click(object sender, System.EventArgs e)
		{
			m_mth(txtExamineResult);
		}

		private void linkLabel_txtAidCheck_Click(object sender, System.EventArgs e)
		{
			m_mth(txtAidCheck);
		}

		private void linkLabel_txtDiag_Click(object sender, System.EventArgs e)
		{
			m_mth(txtDiag);
		}

		private void linkLabel_txtTreatment_Click(object sender, System.EventArgs e)
		{
			m_mth(txtTreatment);
		}

		private void linkLabel_txtReMark_Click(object sender, System.EventArgs e)
		{
			m_mth(txtReMark);
		}
		private void linkLabel_txtChangeDepartment_Click(object sender, System.EventArgs e)
		{
			m_mth(txtChangeDepartment);
		}
		private void m_mth(System.Windows.Forms.Control c)
		{
			clsExteriorFunctionInterface.m_ObjUserInfo = this.LoginInfo;
			frmTextTemplate frm =new frmTextTemplate(c);
			frm.m_mthInitilizeTemplateInfo(this.Name,c.Name);
			frm.getEmpID=this.LoginInfo.m_strEmpID;
			frm.ShowDialog();
		}
		
		#region 更改状态
		public int CaseHistoryStatus
		{
			set
			{
			m_mthChangeStatus(value);
			}
		}
		private void m_mthChangeStatus(int flag)
		{
			if(flag==0)//正常病历
			{
				this.label1.Text="门诊病历";
				this.linkLabel_txtDiagMain.Top =100;
				this.linkLabel_txtDiagMain.Text="主    诉:";
				this.txtDiagMain.Top =100;
				this.txtDiagMain.Name ="txtDiagMain";
				this.linkLabel_txtDiagCurr.Top =this.txtDiagMain.Top+this.txtDiagMain.Height+10;
				this.linkLabel_txtDiagCurr.Text ="现 病 史:";
				this.txtDiagCurr.Top =this.txtDiagMain.Top+this.txtDiagMain.Height+10;
				this.txtDiagCurr.Name ="txtDiagCurr";
				this.linkLabel_txtDiagHis.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.linkLabel_txtDiagHis.Visible =true;
				this.txtDiagHis.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.txtDiagHis.Visible =true;
				this.linkLabel_txtAnaphylaxis.Top =this.txtDiagHis.Top+this.txtDiagHis.Height+10;
				this.linkLabel_txtAnaphylaxis.Visible=true;
				this.txtAnaphylaxis.Top =this.txtDiagHis.Top+this.txtDiagHis.Height+10;
				this.txtAnaphylaxis.Visible =true;
				this.linkLabel_txtPersonHis.Top =this.txtAnaphylaxis.Top+this.txtAnaphylaxis.Height+10;
				this.linkLabel_txtPersonHis.Visible =true;
				this.txtPersonHis.Top =this.txtAnaphylaxis.Top+this.txtAnaphylaxis.Height+10;
				this.txtPersonHis.Visible=true;
				this.linkLabel_txtExamineResult.Top =this.txtPersonHis.Top+this.txtPersonHis.Height+10;
				this.txtExamineResult.Top =this.txtPersonHis.Top+this.txtPersonHis.Height+10;
				this.linkLabel_txtChangeDepartment.Top =this.txtExamineResult.Top+this.txtExamineResult.Height+10;
				this.txtChangeDepartment.Top =this.txtExamineResult.Top+this.txtExamineResult.Height+10;
				this.linkLabel_txtAidCheck.Top =this.txtChangeDepartment.Top+this.txtChangeDepartment.Height+10;
				this.txtAidCheck.Top =this.txtChangeDepartment.Top+this.txtChangeDepartment.Height+10;
				this.linkLabel_txtDiag.Top =this.txtAidCheck.Top+this.txtAidCheck.Height+10;
				this.txtDiag.Top =this.txtAidCheck.Top+this.txtAidCheck.Height+10;
				this.linkLabel_txtTreatment.Top =this.txtDiag.Top+this.txtDiag.Height+10;
				this.txtTreatment.Top =this.txtDiag.Top+this.txtDiag.Height+10;
				this.linkLabel_txtReMark.Top =this.txtTreatment.Top+this.txtTreatment.Height+10;
				this.txtReMark.Top =this.txtTreatment.Top+this.txtTreatment.Height+10;
			}
			else//复诊病历
			{
				this.label1.Text="复诊病历";
				this.linkLabel_txtDiagMain.Top =100;
				this.linkLabel_txtDiagMain.Text="复诊时间:";
				this.txtDiagMain.Top =100;
				this.txtDiagMain.Name ="txtDiagMain2";
				this.linkLabel_txtDiagCurr.Top =this.txtDiagMain.Top+this.txtDiagMain.Height+10;
				this.linkLabel_txtDiagCurr.Text ="病情变化:";
				this.txtDiagCurr.Top =this.txtDiagMain.Top+this.txtDiagMain.Height+10;
				this.txtDiagCurr.Name ="txtDiagCurr2";
				this.linkLabel_txtDiagHis.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.linkLabel_txtDiagHis.Visible =false;
				this.txtDiagHis.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.txtDiagHis.Visible =false;
				this.linkLabel_txtAnaphylaxis.Top =this.txtDiagHis.Top+this.txtDiagHis.Height+10;
				this.linkLabel_txtAnaphylaxis.Visible=false;
				this.txtAnaphylaxis.Top =this.txtDiagHis.Top+this.txtDiagHis.Height+10;
				this.txtAnaphylaxis.Visible =false;
				this.linkLabel_txtPersonHis.Top =this.txtAnaphylaxis.Top+this.txtAnaphylaxis.Height+10;
				this.linkLabel_txtPersonHis.Visible =false;
				this.txtPersonHis.Top =this.txtAnaphylaxis.Top+this.txtAnaphylaxis.Height+10;
				this.txtPersonHis.Visible=false;
				this.linkLabel_txtExamineResult.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.txtExamineResult.Top =this.txtDiagCurr.Top+this.txtDiagCurr.Height+10;
				this.linkLabel_txtChangeDepartment.Top =this.txtExamineResult.Top+this.txtExamineResult.Height+10;
				this.txtChangeDepartment.Top =this.txtExamineResult.Top+this.txtExamineResult.Height+10;
				this.linkLabel_txtAidCheck.Top =this.txtChangeDepartment.Top+this.txtChangeDepartment.Height+10;
				this.txtAidCheck.Top =this.txtChangeDepartment.Top+this.txtChangeDepartment.Height+10;
				this.linkLabel_txtDiag.Top =this.txtAidCheck.Top+this.txtAidCheck.Height+10;
				this.txtDiag.Top =this.txtAidCheck.Top+this.txtAidCheck.Height+10;
				this.linkLabel_txtTreatment.Top =this.txtDiag.Top+this.txtDiag.Height+10;
				this.txtTreatment.Top =this.txtDiag.Top+this.txtDiag.Height+10;
				this.linkLabel_txtReMark.Top =this.txtTreatment.Top+this.txtTreatment.Height+10;
				this.txtReMark.Top =this.txtTreatment.Top+this.txtTreatment.Height+10;
			}
		}
		#endregion

		private void menuI_ICD10_Click(object sender, System.EventArgs e)
		{
			this.btShowID10.PerformClick();
//			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind=new com.digitalwave.common.ICD10.Tool.clsBindICD10();
//			com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] objIcd10inf=null;
//			m_objIcd10Bind.m_mthICD10FZZD(txtDiag,1,1,null,null,ref objIcd10inf);
		}

		private void menuI_Undo_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.controls.ctlRichTextBox   objRTBox =TempControl as com.digitalwave.controls.ctlRichTextBox ;
			objRTBox.m_mthUndo();
		}

		private void linkLabel_New_Click(object sender, System.EventArgs e)
		{
			 m_mthClearData();
			m_mthChangeStatus(0);
		}

		private void MenuItem_Click(object sender, EventArgs e)
		{
			 int i =objActiveLinkLabel.TabIndex;
			 obj_ICD10.RemoveAt(i);
			int with =objActiveLinkLabel.Width;
			this.panel_Illness.Controls.RemoveAt(i);
			foreach(System.Windows.Forms.Control c in this.panel_Illness.Controls)
			{
				if(c.TabIndex>i)
				{
					c.Left-=with;
					c.TabIndex-=1;
				}
			}
		}
		/// <summary>
		/// 记录当前活动控件
		/// </summary>
		private LinkLabel objActiveLinkLabel;
		private void link_Click(object sender, EventArgs e)
		{
			objActiveLinkLabel =sender as LinkLabel;
		}

		public void m_objIcd10Bind_OnReturnData(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_objICDValue)
		{
            if (this.obj_ICD10 == null)
            {
                this.obj_ICD10 = new ArrayList();
            }

            Hashtable has = new Hashtable();
            for (int i = 0; i < this.obj_ICD10.Count; i++)
			{                
                has.Add(((clsICD10_VO)this.obj_ICD10[i]).strICDCODE_VCHR.ToString(), null);
			}

			for(int i=0;i<p_objICDValue.Length;i++)
			{
                if (has.ContainsKey(p_objICDValue[i].ICD10_Code.ToString()))
                {
                    continue;
                }
				clsICD10_VO obj =new clsICD10_VO();
				obj.strICDCODE_VCHR=p_objICDValue[i].ICD10_Code;
				obj.strICDNAME_VCHR=p_objICDValue[i].ICD10_Name;
				obj_ICD10.Add(obj);
				
			}
			this.m_mthShowICD10();
		}
		/// <summary>
		/// 获取ICD码
		/// </summary>
		public string ICDCode
		{
			get
			{
				string ret ="";
				if(obj_ICD10!=null)
				{
					foreach(clsICD10_VO obj in obj_ICD10)
					{
						ret +=obj.strICDCODE_VCHR+",";
					}
				}
				return ret;
			}
		}
		/// <summary>
		/// 获取ICD名称
		/// </summary>
		public string ICDName
		{
			get
			{
				string ret ="";
				if(obj_ICD10!=null)
				{
					foreach(clsICD10_VO obj in obj_ICD10)
					{
						ret +=obj.strICDNAME_VCHR+",";
					}
				}
				return ret;
			}
		}
	}
}
