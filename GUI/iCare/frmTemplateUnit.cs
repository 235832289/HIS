using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using com.digitalwave.DataService;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls ;
using iCare;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmTemplateUnit : iCare.iCareBaseForm.frmBaseForm,PublicFunction
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox m_txtTemplateName;
		private System.Windows.Forms.TextBox m_txtTemplateContent;
		protected System.Windows.Forms.GroupBox m_gpbAvailableIn;
		protected System.Windows.Forms.RadioButton m_rdbDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPublic;
		protected System.Windows.Forms.CheckedListBox m_lstDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPrivate;
		protected System.Windows.Forms.RadioButton m_rdbBAXT;
		protected System.Windows.Forms.RadioButton m_rdbICD10;
		protected System.Windows.Forms.GroupBox m_glbUseIn;
		private System.Windows.Forms.ListBox m_lstForms;
		private System.Windows.Forms.ListBox m_lstControls;
		private System.Windows.Forms.Button cmdComboItems;
		private System.Windows.Forms.ListBox m_lstComboResult;
		private System.Windows.Forms.Button cmdRemove;
		protected System.Windows.Forms.GroupBox m_glbTemplateType;
		private System.Windows.Forms.Label lblTemplateType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox m_txtKeyword;
		protected System.Windows.Forms.RadioButton m_rdbKeyWord;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpStartDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpEndDate;
		private System.Windows.Forms.Button cmdSaveTemplate;
		private System.Windows.Forms.TextBox m_txtKeywordPY;
		private System.Windows.Forms.ListBox lstICD10;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox m_txtTemplateID;
		private System.Windows.Forms.Button cmdClear;
		private System.Windows.Forms.ListBox lstTemplateIDs;
		private System.Windows.Forms.Label lblCreator;
		protected System.Windows.Forms.RadioButton m_rdbCommonUse;
		private System.Windows.Forms.CheckBox m_chkAll;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTemplateUnit()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objDepartmentArr= m_objDeptManager.m_objGetAllInDeptArr();
			m_objFormListArr =m_objDomain.lngGetAllForms ();
			this.m_lstForms.Items.Clear (); 
			if(m_objFormListArr !=null && m_objFormListArr.Length >0)
			for(int i=0;i<m_objFormListArr.Length ;i++)
				this.m_lstForms.Items.Add (m_objFormListArr[i].m_strForm_Desc );
			lstICD10.Visible =false;
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

			
		}

		protected ctlHighLightFocus m_objHighLight;
		#region 成员变量,刘颖源,2003-5-7 19:07:25
		//在此编写同类功能函数体
		clsDepartmentManager m_objDeptManager = new clsDepartmentManager();
		clsDepartment [] m_objDepartmentArr=null;		//所有的部门
		clsGUI_InfoValue[] m_objFormListArr=null;		//所有的Form列表
		clsGUI_Info_DetailValue [] m_objControls=null;	//当前Form的Control列表
		ArrayList m_objArrComboResult=new ArrayList ();//组合后的目标结构体
		
		clsICD10_IllnessIDValue [] m_objICD10_IllnessIDValue=null;	//当前的ICD10
		clsICD10_IllnessSubIDValue [] m_objICD10_IllnessSubID=null;
		clsICD10_IllnessDetailIDValue [] m_objICD10_IllnessDetail=null;

		int m_intSelectICD10Level=-1;					//选中的ICD10层
		string m_strSelectICD10_0ID="";					//选中的0层的ID
		string m_strSelectICD10_1ID="";					//选中的1层的ID
		string m_strSelectICD10_2D="";					//选中的2层的ID

		clsBio_SystemValue [] m_objBio_System=null;		//八大系统
		clsBio_System_DetailValue[] m_objBio_System_Detail=null;//八大系统部位
		
		int m_intSelectSystem=-1;						//选中的系统
		string m_strSelectSystemID="";					//选中的系统
		string m_strSelectSystemDetailID="";			//选中的部位
		
		
		clsTemplateDomain m_objDomain=new clsTemplateDomain ();				//Domain层
		#endregion
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTemplateUnit));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtTemplateName = new System.Windows.Forms.TextBox();
			this.m_txtTemplateContent = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.m_gpbAvailableIn = new System.Windows.Forms.GroupBox();
			this.m_rdbDepartment = new System.Windows.Forms.RadioButton();
			this.m_rdbPublic = new System.Windows.Forms.RadioButton();
			this.m_lstDepartment = new System.Windows.Forms.CheckedListBox();
			this.m_rdbPrivate = new System.Windows.Forms.RadioButton();
			this.m_glbTemplateType = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.m_chkAll = new System.Windows.Forms.CheckBox();
			this.m_rdbCommonUse = new System.Windows.Forms.RadioButton();
			this.m_txtKeywordPY = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtKeyword = new System.Windows.Forms.TextBox();
			this.lblTemplateType = new System.Windows.Forms.Label();
			this.m_rdbBAXT = new System.Windows.Forms.RadioButton();
			this.m_rdbKeyWord = new System.Windows.Forms.RadioButton();
			this.m_rdbICD10 = new System.Windows.Forms.RadioButton();
			this.m_glbUseIn = new System.Windows.Forms.GroupBox();
			this.cmdRemove = new System.Windows.Forms.Button();
			this.cmdComboItems = new System.Windows.Forms.Button();
			this.m_lstComboResult = new System.Windows.Forms.ListBox();
			this.m_lstControls = new System.Windows.Forms.ListBox();
			this.m_lstForms = new System.Windows.Forms.ListBox();
			this.m_dtpStartDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_dtpEndDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.cmdSaveTemplate = new System.Windows.Forms.Button();
			this.lstICD10 = new System.Windows.Forms.ListBox();
			this.m_txtTemplateID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cmdClear = new System.Windows.Forms.Button();
			this.lstTemplateIDs = new System.Windows.Forms.ListBox();
			this.lblCreator = new System.Windows.Forms.Label();
			this.m_gpbAvailableIn.SuspendLayout();
			this.m_glbTemplateType.SuspendLayout();
			this.m_glbUseIn.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(380, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(211, 40);
			this.label1.TabIndex = 3025;
			this.label1.Text = "单 元 模 板";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(208, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3026;
			this.label2.Text = "模板名称:";
			// 
			// m_txtTemplateName
			// 
			this.m_txtTemplateName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemplateName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemplateName.ForeColor = System.Drawing.Color.White;
			this.m_txtTemplateName.Location = new System.Drawing.Point(296, 68);
			this.m_txtTemplateName.Name = "m_txtTemplateName";
			this.m_txtTemplateName.Size = new System.Drawing.Size(248, 19);
			this.m_txtTemplateName.TabIndex = 110;
			this.m_txtTemplateName.Text = "";
			this.m_txtTemplateName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtTemplateName_KeyDown);
			// 
			// m_txtTemplateContent
			// 
			this.m_txtTemplateContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtTemplateContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemplateContent.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemplateContent.ForeColor = System.Drawing.Color.White;
			this.m_txtTemplateContent.Location = new System.Drawing.Point(88, 432);
			this.m_txtTemplateContent.Multiline = true;
			this.m_txtTemplateContent.Name = "m_txtTemplateContent";
			this.m_txtTemplateContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtTemplateContent.Size = new System.Drawing.Size(912, 144);
			this.m_txtTemplateContent.TabIndex = 300;
			this.m_txtTemplateContent.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(24, 432);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 19);
			this.label3.TabIndex = 3028;
			this.label3.Text = "内容:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(24, 587);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 19);
			this.label12.TabIndex = 3041;
			this.label12.Text = "创建人：";
			// 
			// m_gpbAvailableIn
			// 
			this.m_gpbAvailableIn.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.m_rdbDepartment,
																						   this.m_rdbPublic,
																						   this.m_lstDepartment,
																						   this.m_rdbPrivate});
			this.m_gpbAvailableIn.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_gpbAvailableIn.ForeColor = System.Drawing.Color.White;
			this.m_gpbAvailableIn.Location = new System.Drawing.Point(24, 96);
			this.m_gpbAvailableIn.Name = "m_gpbAvailableIn";
			this.m_gpbAvailableIn.Size = new System.Drawing.Size(296, 160);
			this.m_gpbAvailableIn.TabIndex = 140;
			this.m_gpbAvailableIn.TabStop = false;
			this.m_gpbAvailableIn.Text = "适用范围";
			// 
			// m_rdbDepartment
			// 
			this.m_rdbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbDepartment.Location = new System.Drawing.Point(12, 124);
			this.m_rdbDepartment.Name = "m_rdbDepartment";
			this.m_rdbDepartment.Size = new System.Drawing.Size(92, 22);
			this.m_rdbDepartment.TabIndex = 170;
			this.m_rdbDepartment.Text = "科室使用";
			this.m_rdbDepartment.CheckedChanged += new System.EventHandler(this.m_rdbDepartment_CheckedChanged);
			// 
			// m_rdbPublic
			// 
			this.m_rdbPublic.Checked = true;
			this.m_rdbPublic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbPublic.Location = new System.Drawing.Point(12, 76);
			this.m_rdbPublic.Name = "m_rdbPublic";
			this.m_rdbPublic.Size = new System.Drawing.Size(84, 26);
			this.m_rdbPublic.TabIndex = 160;
			this.m_rdbPublic.TabStop = true;
			this.m_rdbPublic.Text = "公用";
			this.m_rdbPublic.CheckedChanged += new System.EventHandler(this.m_rdbPublic_CheckedChanged);
			// 
			// m_lstDepartment
			// 
			this.m_lstDepartment.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lstDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lstDepartment.CheckOnClick = true;
			this.m_lstDepartment.ForeColor = System.Drawing.Color.White;
			this.m_lstDepartment.Location = new System.Drawing.Point(108, 24);
			this.m_lstDepartment.Name = "m_lstDepartment";
			this.m_lstDepartment.Size = new System.Drawing.Size(172, 126);
			this.m_lstDepartment.TabIndex = 180;
			// 
			// m_rdbPrivate
			// 
			this.m_rdbPrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbPrivate.Location = new System.Drawing.Point(12, 36);
			this.m_rdbPrivate.Name = "m_rdbPrivate";
			this.m_rdbPrivate.Size = new System.Drawing.Size(76, 24);
			this.m_rdbPrivate.TabIndex = 150;
			this.m_rdbPrivate.Text = "自用";
			this.m_rdbPrivate.CheckedChanged += new System.EventHandler(this.m_rdbPrivate_CheckedChanged);
			// 
			// m_glbTemplateType
			// 
			this.m_glbTemplateType.Controls.AddRange(new System.Windows.Forms.Control[] {
																							this.label9,
																							this.label8,
																							this.m_chkAll,
																							this.m_rdbCommonUse,
																							this.m_txtKeywordPY,
																							this.label4,
																							this.m_txtKeyword,
																							this.lblTemplateType,
																							this.m_rdbBAXT,
																							this.m_rdbKeyWord,
																							this.m_rdbICD10});
			this.m_glbTemplateType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_glbTemplateType.ForeColor = System.Drawing.Color.White;
			this.m_glbTemplateType.Location = new System.Drawing.Point(24, 268);
			this.m_glbTemplateType.Name = "m_glbTemplateType";
			this.m_glbTemplateType.Size = new System.Drawing.Size(296, 152);
			this.m_glbTemplateType.TabIndex = 190;
			this.m_glbTemplateType.TabStop = false;
			this.m_glbTemplateType.Text = "类型";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(84, 126);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(20, 16);
			this.label9.TabIndex = 3050;
			this.label9.Text = "(";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(164, 126);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(20, 16);
			this.label8.TabIndex = 3049;
			this.label8.Text = ")";
			// 
			// m_chkAll
			// 
			this.m_chkAll.Location = new System.Drawing.Point(104, 124);
			this.m_chkAll.Name = "m_chkAll";
			this.m_chkAll.Size = new System.Drawing.Size(60, 24);
			this.m_chkAll.TabIndex = 3048;
			this.m_chkAll.Text = "全部";
			this.m_chkAll.CheckedChanged += new System.EventHandler(this.m_chkAll_CheckedChanged);
			// 
			// m_rdbCommonUse
			// 
			this.m_rdbCommonUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbCommonUse.Location = new System.Drawing.Point(16, 124);
			this.m_rdbCommonUse.Name = "m_rdbCommonUse";
			this.m_rdbCommonUse.Size = new System.Drawing.Size(72, 24);
			this.m_rdbCommonUse.TabIndex = 3047;
			this.m_rdbCommonUse.Text = "常用值";
			this.m_rdbCommonUse.CheckedChanged += new System.EventHandler(this.m_rdbCommonUse_CheckedChanged);
			// 
			// m_txtKeywordPY
			// 
			this.m_txtKeywordPY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtKeywordPY.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtKeywordPY.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtKeywordPY.ForeColor = System.Drawing.Color.White;
			this.m_txtKeywordPY.Location = new System.Drawing.Point(116, 92);
			this.m_txtKeywordPY.Name = "m_txtKeywordPY";
			this.m_txtKeywordPY.Size = new System.Drawing.Size(160, 19);
			this.m_txtKeywordPY.TabIndex = 235;
			this.m_txtKeywordPY.Text = "";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(116, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 16);
			this.label4.TabIndex = 3046;
			this.label4.Text = "拼音首码";
			// 
			// m_txtKeyword
			// 
			this.m_txtKeyword.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtKeyword.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtKeyword.ForeColor = System.Drawing.Color.White;
			this.m_txtKeyword.Location = new System.Drawing.Point(116, 48);
			this.m_txtKeyword.Name = "m_txtKeyword";
			this.m_txtKeyword.Size = new System.Drawing.Size(160, 19);
			this.m_txtKeyword.TabIndex = 230;
			this.m_txtKeyword.Text = "";
			this.m_txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtKeyword_KeyDown);
			// 
			// lblTemplateType
			// 
			this.lblTemplateType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTemplateType.ForeColor = System.Drawing.Color.White;
			this.lblTemplateType.Location = new System.Drawing.Point(116, 24);
			this.lblTemplateType.Name = "lblTemplateType";
			this.lblTemplateType.Size = new System.Drawing.Size(160, 16);
			this.lblTemplateType.TabIndex = 3028;
			this.lblTemplateType.Text = "关键字";
			// 
			// m_rdbBAXT
			// 
			this.m_rdbBAXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbBAXT.Location = new System.Drawing.Point(16, 92);
			this.m_rdbBAXT.Name = "m_rdbBAXT";
			this.m_rdbBAXT.Size = new System.Drawing.Size(92, 24);
			this.m_rdbBAXT.TabIndex = 220;
			this.m_rdbBAXT.Text = "八大系统";
			this.m_rdbBAXT.CheckedChanged += new System.EventHandler(this.m_rdbBAXT_CheckedChanged);
			// 
			// m_rdbKeyWord
			// 
			this.m_rdbKeyWord.Checked = true;
			this.m_rdbKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbKeyWord.Location = new System.Drawing.Point(16, 28);
			this.m_rdbKeyWord.Name = "m_rdbKeyWord";
			this.m_rdbKeyWord.Size = new System.Drawing.Size(92, 24);
			this.m_rdbKeyWord.TabIndex = 200;
			this.m_rdbKeyWord.TabStop = true;
			this.m_rdbKeyWord.Text = "关键字";
			this.m_rdbKeyWord.CheckedChanged += new System.EventHandler(this.rdbKeyWord_CheckedChanged);
			// 
			// m_rdbICD10
			// 
			this.m_rdbICD10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbICD10.Location = new System.Drawing.Point(16, 60);
			this.m_rdbICD10.Name = "m_rdbICD10";
			this.m_rdbICD10.Size = new System.Drawing.Size(96, 24);
			this.m_rdbICD10.TabIndex = 210;
			this.m_rdbICD10.Text = "ICD - 10";
			this.m_rdbICD10.CheckedChanged += new System.EventHandler(this.m_rdbICD10_CheckedChanged);
			// 
			// m_glbUseIn
			// 
			this.m_glbUseIn.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.cmdRemove,
																					 this.cmdComboItems,
																					 this.m_lstComboResult,
																					 this.m_lstControls,
																					 this.m_lstForms});
			this.m_glbUseIn.ForeColor = System.Drawing.Color.White;
			this.m_glbUseIn.Location = new System.Drawing.Point(332, 96);
			this.m_glbUseIn.Name = "m_glbUseIn";
			this.m_glbUseIn.Size = new System.Drawing.Size(676, 324);
			this.m_glbUseIn.TabIndex = 245;
			this.m_glbUseIn.TabStop = false;
			this.m_glbUseIn.Text = "该模板应用于";
			// 
			// cmdRemove
			// 
			this.cmdRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdRemove.Location = new System.Drawing.Point(280, 260);
			this.cmdRemove.Name = "cmdRemove";
			this.cmdRemove.Size = new System.Drawing.Size(64, 32);
			this.cmdRemove.TabIndex = 280;
			this.cmdRemove.Text = "←";
			this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
			// 
			// cmdComboItems
			// 
			this.cmdComboItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdComboItems.Location = new System.Drawing.Point(280, 200);
			this.cmdComboItems.Name = "cmdComboItems";
			this.cmdComboItems.Size = new System.Drawing.Size(64, 32);
			this.cmdComboItems.TabIndex = 270;
			this.cmdComboItems.Text = "→";
			this.cmdComboItems.Click += new System.EventHandler(this.cmdComboItems_Click);
			// 
			// m_lstComboResult
			// 
			this.m_lstComboResult.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lstComboResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lstComboResult.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstComboResult.ForeColor = System.Drawing.Color.White;
			this.m_lstComboResult.HorizontalScrollbar = true;
			this.m_lstComboResult.ItemHeight = 16;
			this.m_lstComboResult.Location = new System.Drawing.Point(356, 24);
			this.m_lstComboResult.Name = "m_lstComboResult";
			this.m_lstComboResult.Size = new System.Drawing.Size(308, 288);
			this.m_lstComboResult.TabIndex = 290;
			this.m_lstComboResult.DoubleClick += new System.EventHandler(this.m_lstComboResult_DoubleClick);
			// 
			// m_lstControls
			// 
			this.m_lstControls.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lstControls.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lstControls.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstControls.ForeColor = System.Drawing.Color.White;
			this.m_lstControls.HorizontalScrollbar = true;
			this.m_lstControls.ItemHeight = 16;
			this.m_lstControls.Location = new System.Drawing.Point(8, 168);
			this.m_lstControls.Name = "m_lstControls";
			this.m_lstControls.Size = new System.Drawing.Size(264, 144);
			this.m_lstControls.TabIndex = 260;
			this.m_lstControls.DoubleClick += new System.EventHandler(this.m_lstControls_DoubleClick);
			// 
			// m_lstForms
			// 
			this.m_lstForms.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lstForms.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lstForms.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lstForms.ForeColor = System.Drawing.Color.White;
			this.m_lstForms.HorizontalScrollbar = true;
			this.m_lstForms.ItemHeight = 16;
			this.m_lstForms.Location = new System.Drawing.Point(8, 24);
			this.m_lstForms.Name = "m_lstForms";
			this.m_lstForms.Size = new System.Drawing.Size(264, 128);
			this.m_lstForms.TabIndex = 250;
			this.m_lstForms.SelectedIndexChanged += new System.EventHandler(this.m_lstForms_SelectedIndexChanged);
			// 
			// m_dtpStartDate
			// 
			this.m_dtpStartDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpStartDate.CustomFormat = "yyyy年MM月dd日         ";
			this.m_dtpStartDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpStartDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpStartDate.flatFont = new System.Drawing.Font("SimSun", 12F);
			this.m_dtpStartDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpStartDate.Location = new System.Drawing.Point(640, 66);
			this.m_dtpStartDate.m_BlnOnlyTime = false;
			this.m_dtpStartDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
			this.m_dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpStartDate.Name = "m_dtpStartDate";
			this.m_dtpStartDate.ReadOnly = false;
			this.m_dtpStartDate.Size = new System.Drawing.Size(140, 22);
			this.m_dtpStartDate.TabIndex = 120;
			this.m_dtpStartDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.TextForeColor = System.Drawing.Color.White;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(556, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 15002;
			this.label5.Text = "启用时间:";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(784, 69);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 15004;
			this.label6.Text = "停用时间:";
			// 
			// m_dtpEndDate
			// 
			this.m_dtpEndDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpEndDate.CustomFormat = "yyyy年MM月dd日         ";
			this.m_dtpEndDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpEndDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpEndDate.flatFont = new System.Drawing.Font("SimSun", 12F);
			this.m_dtpEndDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpEndDate.Location = new System.Drawing.Point(868, 66);
			this.m_dtpEndDate.m_BlnOnlyTime = false;
			this.m_dtpEndDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
			this.m_dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpEndDate.Name = "m_dtpEndDate";
			this.m_dtpEndDate.ReadOnly = false;
			this.m_dtpEndDate.Size = new System.Drawing.Size(140, 22);
			this.m_dtpEndDate.TabIndex = 130;
			this.m_dtpEndDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.TextForeColor = System.Drawing.Color.White;
			// 
			// cmdSaveTemplate
			// 
			this.cmdSaveTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdSaveTemplate.Location = new System.Drawing.Point(848, 592);
			this.cmdSaveTemplate.Name = "cmdSaveTemplate";
			this.cmdSaveTemplate.Size = new System.Drawing.Size(64, 32);
			this.cmdSaveTemplate.TabIndex = 310;
			this.cmdSaveTemplate.Text = "保存";
			this.cmdSaveTemplate.Click += new System.EventHandler(this.cmdSaveTemplate_Click);
			// 
			// lstICD10
			// 
			this.lstICD10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lstICD10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstICD10.Font = new System.Drawing.Font("SimSun", 10.5F);
			this.lstICD10.ForeColor = System.Drawing.Color.White;
			this.lstICD10.ItemHeight = 14;
			this.lstICD10.Location = new System.Drawing.Point(364, 472);
			this.lstICD10.Name = "lstICD10";
			this.lstICD10.Size = new System.Drawing.Size(152, 170);
			this.lstICD10.TabIndex = 15006;
			this.lstICD10.Visible = false;
			this.lstICD10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstICD10_KeyDown);
			this.lstICD10.Leave += new System.EventHandler(this.lstICD10_Leave);
			// 
			// m_txtTemplateID
			// 
			this.m_txtTemplateID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtTemplateID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemplateID.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemplateID.ForeColor = System.Drawing.Color.White;
			this.m_txtTemplateID.Location = new System.Drawing.Point(120, 68);
			this.m_txtTemplateID.Name = "m_txtTemplateID";
			this.m_txtTemplateID.Size = new System.Drawing.Size(80, 19);
			this.m_txtTemplateID.TabIndex = 100;
			this.m_txtTemplateID.Text = "";
			this.m_txtTemplateID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemplateID_KeyDown);
			// 
			// label7
			// 
			this.label7.AllowDrop = true;
			this.label7.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(32, 68);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 15010;
			this.label7.Text = "模板编号:";
			// 
			// cmdClear
			// 
			this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdClear.Location = new System.Drawing.Point(932, 592);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Size = new System.Drawing.Size(64, 32);
			this.cmdClear.TabIndex = 320;
			this.cmdClear.Text = "清空";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// lstTemplateIDs
			// 
			this.lstTemplateIDs.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lstTemplateIDs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstTemplateIDs.Font = new System.Drawing.Font("SimSun", 10.5F);
			this.lstTemplateIDs.ForeColor = System.Drawing.Color.White;
			this.lstTemplateIDs.HorizontalScrollbar = true;
			this.lstTemplateIDs.ItemHeight = 14;
			this.lstTemplateIDs.Location = new System.Drawing.Point(24, 464);
			this.lstTemplateIDs.Name = "lstTemplateIDs";
			this.lstTemplateIDs.Size = new System.Drawing.Size(248, 170);
			this.lstTemplateIDs.TabIndex = 15012;
			this.lstTemplateIDs.Visible = false;
			this.lstTemplateIDs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTemplateIDs_KeyDown);
			this.lstTemplateIDs.DoubleClick += new System.EventHandler(this.lstTemplateIDs_DoubleClick);
			this.lstTemplateIDs.Leave += new System.EventHandler(this.lstTemplateIDs_Leave);
			// 
			// lblCreator
			// 
			this.lblCreator.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblCreator.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCreator.ForeColor = System.Drawing.Color.White;
			this.lblCreator.Location = new System.Drawing.Point(104, 587);
			this.lblCreator.Name = "lblCreator";
			this.lblCreator.Size = new System.Drawing.Size(140, 24);
			this.lblCreator.TabIndex = 3042;
			// 
			// frmTemplateUnit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(1028, 709);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lstTemplateIDs,
																		  this.cmdClear,
																		  this.lstICD10,
																		  this.cmdSaveTemplate,
																		  this.label6,
																		  this.m_dtpEndDate,
																		  this.label5,
																		  this.m_dtpStartDate,
																		  this.m_glbUseIn,
																		  this.m_glbTemplateType,
																		  this.m_gpbAvailableIn,
																		  this.lblCreator,
																		  this.label12,
																		  this.label3,
																		  this.label1,
																		  this.m_txtTemplateContent,
																		  this.m_txtTemplateName,
																		  this.label2,
																		  this.label7,
																		  this.m_txtTemplateID});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTemplateUnit";
			this.Text = "模板单元工具";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmTemplateUnit_Closing);
			this.Load += new System.EventHandler(this.frmTemplateUnit_Load);
			this.m_gpbAvailableIn.ResumeLayout(false);
			this.m_glbTemplateType.ResumeLayout(false);
			this.m_glbUseIn.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region 私有函数,刘颖源,2003-5-7 14:50:41
		
		private void m_mthSaveTemplate()
		{
			//判断
			clsTemplateValue objTemplateValueExist;
			string strTemplateID="";
			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
//			strTemplateID =m_objDomain.strGetTemplateID ();
			objTemplateValueExist=m_objDomain.lngGetTemplate (this.m_txtTemplateID.Text );
			bool blnInsert=true;
			if(objTemplateValueExist !=null)
			{
				if(clsPublicFunction.ShowQuestionMessageBox( "模板已经存在(" + objTemplateValueExist.m_strTemplate_ID + "),是否修改?")==System.Windows.Forms.DialogResult.No  )
					return;
				else
				{
					blnInsert=false;
					strTemplateID=this.m_txtTemplateID.Text ;
				}
			}
			if(this.m_txtTemplateName.Text =="" || this.m_txtKeyword.Text =="")
			{
				clsPublicFunction.ShowInformationMessageBox  ("请输入模板名称或关键字!");
				return;
			}

			//所有的Template_ID和ActiveDate在Domain层中获得
			#region clsTemplateValue和clsTemplate_DetailValue,刘颖源,2003-5-8 11:11:40
			clsTemplateValue objTemplate=new clsTemplateValue();
			objTemplate.m_strStart_Date = this.m_dtpStartDate.Value.ToString ();
			objTemplate.m_strEnd_Date = this.m_dtpEndDate.Value.ToString ();
			objTemplate.m_strTemplate_ID =strTemplateID ;
			
			
			clsTemplate_DetailValue objTemplate_Detail=new clsTemplate_DetailValue();
			objTemplate_Detail.m_strContent =this.m_txtTemplateContent.Text ;
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			objTemplate_Detail.m_strEmployeeID =MDIParent.OperatorID;
			objTemplate_Detail.m_strTemplate_Name = this.m_txtTemplateName.Text  ;
			objTemplate_Detail.m_strActivity_Date =strCurrentDate ;
			objTemplate_Detail.m_strTemplate_ID =strTemplateID ;
			if(this.m_rdbPrivate.Checked )
				objTemplate_Detail.m_strVisibility_Level = "0";
			else if(this.m_rdbPublic.Checked )
				objTemplate_Detail.m_strVisibility_Level ="1";
			else
				objTemplate_Detail.m_strVisibility_Level ="2";
			#endregion

			#region clsTemplate_KeywordValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_KeywordValue[] objTemplate_Keyword=null;
			if(this.m_rdbKeyWord.Checked )
			{
				string strKeywords=this.m_txtKeyword.Text ;
				string strKeywordPYs=this.m_txtKeywordPY.Text ;
				string[] strKeywodArr= strKeywords.Split (',');
				string[] strKeywordPyArr=strKeywordPYs.Split (',');
				if(strKeywodArr.Length !=strKeywordPyArr.Length || strKeywodArr.Length <=0)
				{
					clsPublicFunction.ShowInformationMessageBox  ("关键字和对应的拼音码数目不相同或者没有输入关键字!");
					return;
				}
				objTemplate_Keyword=new clsTemplate_KeywordValue [strKeywodArr.Length];
				for(int i=0;i<strKeywodArr.Length ;i++)
				{
					objTemplate_Keyword[i]=new clsTemplate_KeywordValue ();
					objTemplate_Keyword[i].m_strTemplate_ID =strTemplateID ;
					objTemplate_Keyword[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Keyword[i].m_strKeyword =strKeywodArr[i];
					objTemplate_Keyword[i].m_strKeyword_PY =strKeywordPyArr[i];
					objTemplate_Keyword[i].m_strKeyword_Type ="1";
				}
			}
			else if(this.m_rdbCommonUse.Checked )
			{
				string strKeywords=this.m_txtKeyword.Text ;
				string strKeywordPYs=this.m_txtKeywordPY.Text ;
				string[] strKeywodArr= strKeywords.Split (',');
				string[] strKeywordPyArr=strKeywordPYs.Split (',');
				if(strKeywodArr.Length !=strKeywordPyArr.Length || strKeywodArr.Length <=0)
				{
					clsPublicFunction.ShowInformationMessageBox  ("常用值和对应的拼音码数目不相同或者没有输入关键字!");
					return;
				}
				objTemplate_Keyword=new clsTemplate_KeywordValue [strKeywodArr.Length];
				for(int i=0;i<strKeywodArr.Length ;i++)
				{
					objTemplate_Keyword[i]=new clsTemplate_KeywordValue ();
					objTemplate_Keyword[i].m_strTemplate_ID =strTemplateID ;
					objTemplate_Keyword[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Keyword[i].m_strKeyword =strKeywodArr[i];
					objTemplate_Keyword[i].m_strKeyword_PY =strKeywordPyArr[i];
					objTemplate_Keyword[i].m_strKeyword_Type ="4";
				}
			}
			else if(this.m_rdbICD10.Checked )
			{
				objTemplate_Keyword=new clsTemplate_KeywordValue[1];
				objTemplate_Keyword[0]=new clsTemplate_KeywordValue();
				if(m_strSelectICD10_2D=="" && m_strSelectICD10_1ID=="" && m_strSelectICD10_0ID=="")
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有指定ICD - 10中的疾病");
					return;
				}
				objTemplate_Keyword[0].m_strActivity_Date =strCurrentDate ;
				objTemplate_Keyword[0].m_strTemplate_ID =strTemplateID ;
				if(m_strSelectICD10_2D  !="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_2D ;
				else if(m_strSelectICD10_1ID !="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_1ID ;
				else
					objTemplate_Keyword[0].m_strKeyword =m_strSelectICD10_0ID ;
				objTemplate_Keyword[0].m_strKeyword_PY =this.m_txtKeywordPY.Text  ;
				objTemplate_Keyword[0].m_strKeyword_Type ="0";
			}
			else
			{
				objTemplate_Keyword=new clsTemplate_KeywordValue[1];
				objTemplate_Keyword[0]=new clsTemplate_KeywordValue();
				if(m_strSelectSystemDetailID=="" && m_strSelectSystemID=="")
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有指定系统或系统部位!");
					return;
				}
				objTemplate_Keyword[0].m_strActivity_Date =strCurrentDate;
				objTemplate_Keyword[0].m_strTemplate_ID =strTemplateID ;
				if(m_strSelectSystemDetailID!="")
					objTemplate_Keyword[0].m_strKeyword =m_strSelectSystemDetailID ;
				else
					objTemplate_Keyword[0].m_strKeyword =m_strSelectSystemID  ;
				objTemplate_Keyword[0].m_strKeyword_PY =this.m_txtKeywordPY.Text;
				objTemplate_Keyword[0].m_strKeyword_Type ="2";

			}
			#endregion

			#region clsTemplate_TargetValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_TargetValue[] objTemplate_Target=null;
			if(m_objArrComboResult==null || m_objArrComboResult.Count<=0)
			{
				clsPublicFunction.ShowInformationMessageBox  ("没有指定模板的使用区域!");
				return;
			}
			objTemplate_Target=new clsTemplate_TargetValue [m_objArrComboResult.Count ];
			for(int i=0;i<m_objArrComboResult.Count ;i++)
			{
				objTemplate_Target[i]=new clsTemplate_TargetValue ();
				objTemplate_Target[i].m_strActivity_Date =strCurrentDate ;
				objTemplate_Target[i].m_strTemplate_ID =strTemplateID  ;
				objTemplate_Target[i].m_strControl_ID = ((clsTemplate_TargetValue )m_objArrComboResult[i]) .m_strControl_ID ;
				objTemplate_Target[i].m_strForm_ID  = ((clsTemplate_TargetValue )m_objArrComboResult[i]) .m_strForm_ID ;
			}
			#endregion

			#region clsTemplate_Dept_VisibilityValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_Dept_VisibilityValue[] objTemplate_Dept_Visiblity=null;
			if(objTemplate_Detail.m_strVisibility_Level=="2")
			{
				if(this.m_lstDepartment.CheckedItems.Count <=0)
				{
					clsPublicFunction.ShowInformationMessageBox  ("没有选定任何部门使用该模板");
					return;
				}
				 
				objTemplate_Dept_Visiblity=new clsTemplate_Dept_VisibilityValue [this.m_lstDepartment.CheckedItems.Count];
				for(int i1=0;i1<this.m_lstDepartment.CheckedIndices.Count;i1++)
				{
					objTemplate_Dept_Visiblity[i1]=new clsTemplate_Dept_VisibilityValue ();
					objTemplate_Dept_Visiblity[i1].m_strActivity_Date =strCurrentDate ;
					objTemplate_Dept_Visiblity[i1].m_strTemplate_ID =strTemplateID ;
					objTemplate_Dept_Visiblity[i1].m_strDepartmentID =m_objDepartmentArr[m_lstDepartment.CheckedIndices[i1]].m_StrDeptID;
				}

			}
			#endregion
			m_objDomain.lngSaveTemplate (blnInsert,objTemplate ,objTemplate_Detail ,objTemplate_Keyword ,objTemplate_Target ,objTemplate_Dept_Visiblity,out strTemplateID);
			clsPublicFunction.ShowInformationMessageBox  ("已经保存模板,编号为" + strTemplateID );
			this.m_txtTemplateID.Text =strTemplateID;
		}
		private void m_mthClearInterface()
		{
			this.m_txtKeyword.Text ="";
			this.m_txtTemplateContent.Text ="";
			this.m_txtTemplateName.Text ="";
			this.m_txtKeywordPY.Text ="";
			this.m_rdbKeyWord.Checked =true;
			this.m_dtpStartDate.Value =DateTime.Now ;
			this.m_dtpEndDate.Value =DateTime.Now.AddYears (100);
			
		}

		#endregion

//	/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
//		/// <summary>
//		/// The main entry point for the application.
//		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmTemplateUnit());
//		}
//	/*``````````````````````````````````````````````````````````````````````````````````````````*/
		private void frmTemplateUnit_Load(object sender, System.EventArgs e)
		{
			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-7 17:03:11
			
            //com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool (Color.White);

			

            //foreach(Control ctlControl in this.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
			#endregion

            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-7 18:59:03				

            //foreach(Control ctlControl in this.m_gpbAvailableIn.Controls   )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "CheckedListBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
            //#endregion

            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-7 19:0305		

            //foreach(Control ctlControl in this.m_glbUseIn.Controls   )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ListBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
            //#endregion

            //#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-8 09:05:01
			
            //m_objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool (Color.White);

			

            //foreach(Control ctlControl in this.m_glbTemplateType.Controls )
            //{
            //    string typeName = ctlControl.GetType().Name;
            //    if(typeName == "ctlRichTextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "TextBox" )
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "DataGrid")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //        ((DataGrid)ctlControl).AllowSorting =false ;
            //    }

            //    if(typeName =="TreeView")
            //    {
            //        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                            {
            //                                ctlControl ,
            //        });
            //    }
            //    if(typeName == "GroupBox")
            //    {
            //        foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
            //        {
            //            string strSubTypeName = ctlGrp.GetType().Name;
            //            if(strSubTypeName == "PictureBox")
            //            {
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                            {
            //                                                ctlGrp ,
            //                });
            //            }
            //        }
            //    }
            //}
            //#endregion

			m_mthClearInterface();

			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			this.lblCreator.Text =MDIParent.OperatorName;

			m_objHighLight.m_mthAddControlInContainer(this);	
			this.m_rdbDepartment.Checked =true;

			for(int i=0;i<m_objDepartmentArr.Length ;i++)
			{
				if(MDIParent.s_ObjDepartment.m_StrDeptID == m_objDepartmentArr[i].m_StrDeptID )
					this.m_lstDepartment.SetItemChecked (i,true);  
			}

			m_txtTemplateID.Focus();

		}

		private void m_rdbPrivate_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lstDepartment.Items.Clear (); 		
		}

		private void m_rdbDepartment_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0;i<m_objDepartmentArr.Length ;i++)
				this.m_lstDepartment.Items.Add (m_objDepartmentArr[i].m_StrDeptName ); 
		}

		private void m_rdbPublic_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lstDepartment.Items.Clear (); 
		}

		private void m_lstForms_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intIndex=this.m_lstForms.SelectedIndex ;
			m_objControls = m_objDomain.lngGetAllControls (m_objFormListArr[intIndex ].m_strForm_ID );
			this.m_lstControls.Items.Clear ();
			if(m_objControls!=null && m_objControls.Length >0)
			{
				for(int i=0;i<m_objControls.Length ;i++)
					this.m_lstControls.Items.Add (m_objControls[i].m_strControl_Desc );
			}
		
		}

		private void cmdComboItems_Click(object sender, System.EventArgs e)
		{
			if(m_objFormListArr==null || m_objControls==null)return;
			int intFormIndex=this.m_lstForms.SelectedIndex ;
			int intControlsIndex=this.m_lstControls.SelectedIndex ;
			if(intFormIndex <0 || intFormIndex >= this.m_lstForms.Items.Count )return;

			if(intControlsIndex <0 || intControlsIndex >=this.m_lstControls.Items.Count )return; 
			for(int i=0;i<m_objArrComboResult.Count ;i++)
			{
				clsTemplate_TargetValue objTempTar=(clsTemplate_TargetValue)m_objArrComboResult[i];
				if(objTempTar.m_strForm_ID == m_objFormListArr[intFormIndex].m_strForm_ID && objTempTar.m_strControl_ID == m_objControls[intControlsIndex].m_strControl_ID )
				{
					clsPublicFunction.ShowInformationMessageBox  ("该文本框已经选择了,请另选一个!");
					return;
				}
			}
			string strResult=m_objFormListArr[intFormIndex ].m_strForm_Desc + " - " + m_objControls[intControlsIndex].m_strControl_Desc ;			 
			this.m_lstComboResult.Items.Add (strResult); 
			clsTemplate_TargetValue objTemplateTarget=new clsTemplate_TargetValue();
			objTemplateTarget.m_strActivity_Date ="";
			objTemplateTarget.m_strForm_ID=m_objFormListArr[intFormIndex].m_strForm_ID ;
			objTemplateTarget.m_strControl_ID =m_objControls[intControlsIndex].m_strControl_ID ;
			objTemplateTarget.m_strTemplate_ID ="";

			m_objArrComboResult.Add (objTemplateTarget );

		}

		private void cmdRemove_Click(object sender, System.EventArgs e)
		{
			if(this.m_lstComboResult.SelectedIndex <0 || this.m_lstComboResult.SelectedIndex >=this.m_lstComboResult.Items.Count )return;
			int intComboIndex=this.m_lstComboResult.SelectedIndex ;
			this.m_lstComboResult.Items.RemoveAt (intComboIndex );
			m_objArrComboResult.RemoveAt (intComboIndex );
		}

		private void m_rdbICD10_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="ICD - 10编号"; 
			this.m_txtKeywordPY.Enabled =false; 
		}

		private void rdbKeyWord_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="关键字";
			this.m_txtKeywordPY.Enabled =true;
		}

		private void m_rdbBAXT_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="八大系统"; 
			this.m_txtKeywordPY.Enabled =false;
		}

		private void cmdSaveTemplate_Click(object sender, System.EventArgs e)
		{
			m_mthSaveTemplate ();
		}

		private void m_txtKeyword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Escape )
				this.lstICD10.Visible =false;
			#region ICD-10键盘处理程序,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbICD10.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
					}
				}
				if(e.KeyCode ==System.Windows.Forms.Keys.Decimal || e.KeyCode ==System.Windows.Forms.Keys.OemPeriod)
				{
					int intLeftOff=m_txtKeyword.TextLength ;
					this.lstICD10.Left =this.m_glbTemplateType.Left +  this.m_txtKeyword.Left + intLeftOff;
					this.lstICD10.Top =this.m_glbTemplateType.Top + this.m_txtKeyword.Top + this.m_txtKeyword.Height ;

					this.lstICD10.Items.Clear (); 
					int intPointnumber=0;
					string strText=this.m_txtKeyword.Text ;
					for(int i=0;i<strText.Length ;i++)
						if(strText[i]=='.')intPointnumber ++;
					m_intSelectICD10Level=intPointnumber ;
					switch(intPointnumber )
					{
						case 1:
							m_objICD10_IllnessSubID =m_objDomain.lngGetAllICD10_IllnessSubID (m_strSelectICD10_0ID );
							if(m_objICD10_IllnessSubID !=null && m_objICD10_IllnessSubID.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessSubID.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessSubID[i].m_strIllnessSubName); 
							}
							break;
						case 2:
							m_objICD10_IllnessDetail =m_objDomain.lngGetAllICD10_IllnessDetailID (m_strSelectICD10_1ID );
							if(m_objICD10_IllnessDetail !=null && m_objICD10_IllnessDetail.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessDetail.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessDetail[i].m_strIllnessDetailName ); 
							}
							break;
						case 0:
							m_objICD10_IllnessIDValue =m_objDomain.lngGetAllICD10_IllnessID ();
							if(m_objICD10_IllnessIDValue !=null && m_objICD10_IllnessIDValue.Length >0)
							{
								for(int i=0;i<m_objICD10_IllnessIDValue.Length ;i++)
									this.lstICD10.Items.Add (m_objICD10_IllnessIDValue[i].m_strIllnessName ); 
							}
							break;

						default:
							break;

					}
					if(this.lstICD10.Items.Count >0)
					{
						this.lstICD10.SelectedIndex =0;						
						this.lstICD10.Visible =true;
						this.lstICD10.BringToFront();						
						this.lstICD10.Focus ();
					}
				}
			}
			#endregion

			#region 八大系统键盘处理,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbBAXT.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
					}
				}
				if(e.KeyCode ==System.Windows.Forms.Keys.Decimal || e.KeyCode ==System.Windows.Forms.Keys.OemPeriod )
				{
					int intLeftOff=m_txtKeyword.TextLength ;
					this.lstICD10.Left =this.m_glbTemplateType.Left +  this.m_txtKeyword.Left + intLeftOff;
					this.lstICD10.Top =this.m_glbTemplateType.Top + this.m_txtKeyword.Top + this.m_txtKeyword.Height ;

					this.lstICD10.Items.Clear (); 
					int intPointnumber=0;
					string strText=this.m_txtKeyword.Text ;
					for(int i=0;i<strText.Length ;i++)
						if(strText[i]=='.')intPointnumber ++;
					m_intSelectSystem =intPointnumber ;
					switch(intPointnumber )
					{
						case 1:
							m_objBio_System_Detail  =m_objDomain.lngGetAllBio_System_Detail  (m_strSelectSystemID  );
							if(m_objBio_System_Detail !=null && m_objBio_System_Detail.Length >0)
							{
								for(int i=0;i<m_objBio_System_Detail.Length ;i++)
									this.lstICD10.Items.Add (m_objBio_System_Detail[i].m_strComponen_Name ); 
							}
							break;
						case 0:
							m_objBio_System  =m_objDomain.lngGetAllBio_System();
							if(m_objBio_System !=null && m_objBio_System.Length >0)
							{
								for(int i=0;i<m_objBio_System.Length ;i++)
									this.lstICD10.Items.Add (m_objBio_System[i].m_strSystem_Name  ); 
							}
							break;
						default:
							break;

					}
					if(this.lstICD10.Items.Count >0)
					{
						this.lstICD10.SelectedIndex =0;						
						this.lstICD10.Visible =true;
						this.lstICD10.BringToFront();						
						this.lstICD10.Focus ();
					}
				}
			}
			#endregion

		}

		private void lstICD10_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				if(e.KeyCode ==System.Windows.Forms.Keys.Escape )
					this.lstICD10.Visible =false;
			#region ICD-10键盘处理程序,刘颖源,2003-5-8 17:26:57
			if(this.m_rdbICD10.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						switch(m_intSelectICD10Level )
						{
							case 1:
								if(m_objICD10_IllnessSubID !=null &&  m_objICD10_IllnessSubID.Length >intIndex )
								{
									m_strSelectICD10_1ID =m_objICD10_IllnessSubID[intIndex].m_strIllnessSubID ;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessSubID[intIndex].m_strPYCode;
								}
								break;
							case 2:
								if(m_objICD10_IllnessDetail !=null && m_objICD10_IllnessDetail.Length > intIndex )
								{
									m_strSelectICD10_2D =m_objICD10_IllnessDetail[intIndex ].m_strIllnessDetailID;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessDetail[intIndex ].m_strPYCode ;
								}
								break;
							default:			//选中0层了
								if(m_objICD10_IllnessIDValue !=null && m_objICD10_IllnessIDValue.Length >intIndex )
								{
									m_strSelectICD10_0ID = m_objICD10_IllnessIDValue[intIndex].m_strIllnessID ;
									this.m_txtKeywordPY.Text =m_objICD10_IllnessIDValue[intIndex].m_strPYCode ;
								}
								break;

						}

						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ;						
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
						this.m_txtKeyword.Focus ();
					}
				}
			}
			#endregion

			#region 八大系统,刘颖源,2003-5-8 17:38:38
			if(this.m_rdbBAXT.Checked )
			{
				if((e.KeyCode == System.Windows.Forms.Keys.Space || e.KeyCode ==System.Windows.Forms.Keys.Enter ) && this.lstICD10.Visible )
				{
					int intIndex=this.lstICD10.SelectedIndex ;
					if(intIndex>=0 && intIndex < this.lstICD10.Items.Count )
					{
						switch(m_intSelectSystem  )
						{
							case 1:
								if(m_objBio_System_Detail  !=null &&  m_objBio_System_Detail.Length >intIndex )
								{
									m_strSelectSystemDetailID  =m_objBio_System_Detail[intIndex].m_strComponen_ID  ;
								}
								break;
							default:			//选中0层了
								if(m_objBio_System  !=null && m_objBio_System.Length >intIndex )
								{
									m_strSelectSystemID  = m_objBio_System[intIndex].m_strSystem_ID  ;
								}
								break;


						}

						this.lstICD10.Visible =false;
						this.m_txtKeyword.Text = this.m_txtKeyword.Text + this.lstICD10.Text ; 
						this.m_txtKeyword.SelectionStart =this.m_txtKeyword.TextLength ;
						this.m_txtKeyword.SelectionLength =1;
						this.m_txtKeyword.Focus ();
					}
				}
			}
			#endregion

		}

		private void cmdTemplateSet_Click(object sender, System.EventArgs e)
		{
			frmTemplateSet objTemplateset=new frmTemplateSet ();
			objTemplateset.ShowDialog ();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
//			Application.Exit ();
		}

		private void frmTemplateUnit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
//			Application.Exit ();
		}

		private void cmdTestInput_Click(object sender, System.EventArgs e)
		{
//			frmTestInput objTestInput=new frmTestInput ();
//			objTestInput.ShowDialog ();
		}

		private void lstICD10_Leave(object sender, System.EventArgs e)
		{
			this.lstICD10.Visible =false;
		}

		private void m_lstControls_DoubleClick(object sender, System.EventArgs e)
		{
			cmdComboItems_Click(sender,e);
		}

		private void m_lstComboResult_DoubleClick(object sender, System.EventArgs e)
		{
			cmdRemove_Click(sender,e);
		}

		private void mthCleanInterface()
		{
			foreach(Control ctrControl in this.Controls )
			{
				switch(ctrControl.GetType().Name )
				{
					case "TextBox":
					case "RichTextBox":
						ctrControl.Text ="";
						break;
				}
			}
			foreach(Control ctrControl in this.m_glbTemplateType.Controls  )
			{
				switch(ctrControl.GetType().Name )
				{
					case "TextBox":
					case "RichTextBox":
						ctrControl.Text ="";
						break;
				}
			}

			this.m_lstComboResult.Items.Clear ();
			this.m_objArrComboResult.Clear ();
		}
		private void txtTemplateID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Enter)
			{
				m_mthLoadTemplate(m_txtTemplateID);
			}
		}

		private void m_mthLoadTemplate(Control p_ctl)
		{
			if(p_ctl.Text =="" && m_lstForms.SelectedItem != null)
			{
				clsTemplate_DetailValue[] objTemplate_Detail=null;
//				objTemplate_Detail=m_objDomain.lngGetEmployeeTemplateIDs (MDIParent.OperatorID );
	
				string strFormID = m_objFormListArr[m_lstForms.SelectedIndex].m_strForm_ID;
				objTemplate_Detail=m_objDomain.lngGetEmployeeTemplateIDsByForm(MDIParent.OperatorID,strFormID);

				this.lstTemplateIDs.Items.Clear ();
				if(objTemplate_Detail !=null && objTemplate_Detail.Length >0)
				{
					for(int i=0;i<objTemplate_Detail.Length ;i++)
						this.lstTemplateIDs.Items.Add (objTemplate_Detail[i]);
					this.lstTemplateIDs.Visible =true;
					this.lstTemplateIDs.Left =p_ctl.Left ;
					this.lstTemplateIDs.Top =p_ctl.Top + this.m_txtTemplateID.Height;
					this.lstTemplateIDs.SelectedIndex =0;
					this.lstTemplateIDs.Focus ();
				}
				return;
			}
			else
				m_mthLoadTemplateInfo();
		}
		private void m_mthLoadTemplateInfo()
		{
			if(this.m_txtTemplateID.Text=="")return;
			clsTemplateValue [] objTemplateVale=null;
			clsTemplate_KeywordValue [] objTemplate_KeywordValue=null;
			clsTemplate_DetailValue [] objTemplate_DetailValue=null;
			clsTemplate_Target_Gui_InfoValue [] objTemplate_Target_Gui_InfoValue=null;
			clsTemplate_Dept_VisibilityValue [] objTemplate_Dept_Visiblity=null;
			m_objDomain.lngGetTemplateUnit (this.m_txtTemplateID.Text,out objTemplateVale ,out objTemplate_KeywordValue ,out objTemplate_DetailValue ,out objTemplate_Target_Gui_InfoValue ,out objTemplate_Dept_Visiblity );
			mthCleanInterface();
			if(objTemplateVale !=null && objTemplateVale.Length ==1)
			{
				this.m_txtTemplateID.Text =objTemplateVale[0].m_strTemplate_ID ;
				this.m_dtpStartDate.Value = DateTime.Parse (objTemplateVale[0].m_strStart_Date );
				this.m_dtpEndDate.Value =DateTime.Parse (objTemplateVale[0].m_strEnd_Date );

				if(objTemplate_KeywordValue !=null && objTemplate_KeywordValue.Length >0)
				{
					switch(int.Parse (objTemplate_KeywordValue[0].m_strKeyword_Type ))
					{
						case 0:
							this.m_rdbICD10.Checked =true;
							this.m_strSelectICD10_0ID=objTemplate_KeywordValue[0].m_strKeyword ;
							this.m_strSelectICD10_1ID =m_strSelectICD10_0ID;
							this.m_strSelectICD10_2D  =m_strSelectICD10_0ID;
							break;
						case 1:
							this.m_rdbKeyWord.Checked =true;
							for(int i=0;i<objTemplate_KeywordValue.Length ;i++)
							{
								this.m_txtKeyword.Text += objTemplate_KeywordValue[i].m_strKeyword +"," ;
								this.m_txtKeywordPY.Text  +=objTemplate_KeywordValue [i].m_strKeyword_PY +",";
							}
							if(this.m_txtKeyword.Text.Length >0)this.m_txtKeyword.Text= this.m_txtKeyword.Text.Substring (0,this.m_txtKeyword.Text.Length -1);
							if(this.m_txtKeywordPY.Text.Length >0)this.m_txtKeywordPY.Text= this.m_txtKeywordPY.Text.Substring (0,this.m_txtKeywordPY.Text.Length -1);
							break;
						case 2:
							this.m_rdbBAXT.Checked =true;
							this.m_strSelectSystemID =objTemplate_KeywordValue[0].m_strKeyword ;
							this.m_strSelectSystemDetailID =objTemplate_KeywordValue[0].m_strKeyword ;
							break;
					}
				}

				if(objTemplate_DetailValue !=null && objTemplate_DetailValue.Length >0)
				{
					this.m_txtTemplateName.Text =objTemplate_DetailValue[0].m_strTemplate_Name ;
					this.m_txtTemplateContent.Text =objTemplate_DetailValue[0].m_strContent ;
					switch(int.Parse (objTemplate_DetailValue[0].m_strVisibility_Level) )
					{
						case 0:
							this.m_rdbPrivate.Checked =true;								
							break;
						case 1:
							this.m_rdbPublic.Checked =true;
							break;
						case 2:
							this.m_rdbDepartment.Checked =true;
							if(m_objDepartmentArr !=null && objTemplate_Dept_Visiblity !=null && m_objDepartmentArr.Length >0 && objTemplate_Dept_Visiblity.Length >0)
							{
								for(int i=0;i<objTemplate_Dept_Visiblity.Length ;i++)
									for(int j=0;j<m_objDepartmentArr.Length; j++)
									{
										if(objTemplate_Dept_Visiblity[i].m_strDepartmentID ==m_objDepartmentArr[j].m_StrDeptID )
										{
											this.m_lstDepartment.SetItemChecked(j,true);
										}
									}
							}
							break;
					}
				}
				if(objTemplate_Target_Gui_InfoValue !=null && objTemplate_Target_Gui_InfoValue.Length >0)
				{
					for(int i=0;i<objTemplate_Target_Gui_InfoValue.Length ;i++)
					{
						clsTemplate_TargetValue objTemplateTarget=new clsTemplate_TargetValue();
						objTemplateTarget.m_strActivity_Date ="";
						objTemplateTarget.m_strForm_ID=objTemplate_Target_Gui_InfoValue[i].m_strForm_ID  ;
						objTemplateTarget.m_strControl_ID =objTemplate_Target_Gui_InfoValue[i].m_strControl_ID  ;
						objTemplateTarget.m_strTemplate_ID ="";
						string strResult=objTemplate_Target_Gui_InfoValue[i].m_strForm_Desc + " - " + objTemplate_Target_Gui_InfoValue[i].m_strControl_Desc ;			 
						this.m_lstComboResult.Items.Add (strResult); 
						m_objArrComboResult.Add (objTemplateTarget );
					}
				}
			}

		}
		private void lstTemplateIDs_Leave(object sender, System.EventArgs e)
		{
			this.lstTemplateIDs.Visible =false; 
		}

		private void lstTemplateIDs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Enter )
			{
				string strText=this.lstTemplateIDs.Text;
				this.m_txtTemplateID.Text = ((clsTemplate_DetailValue)lstTemplateIDs.SelectedItem).m_strTemplate_ID;  
				this.lstTemplateIDs.Visible =false;
				m_mthLoadTemplateInfo();
			}
		}

		private void m_txtTemplateName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==System.Windows.Forms.Keys.Enter)
			{
				m_mthLoadTemplate(m_txtTemplateName);
			}
		}

		#region Copy,Cut,Paste
		/// <summary>
		/// 复制操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCopy()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Copy();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					default:
						Clipboard.SetDataObject("");
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 剪切操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCut()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Cut();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Cut();
							return 1;
						}
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 粘贴操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngPaste()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;

			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						((ctlRichTextBox)ctlControl).Paste();
						break;

					case "RichTextBox":
						((RichTextBox)ctlControl).Paste();
						break;

					case "TextBox":
						((TextBox)ctlControl).Paste();
						break;

					case "ctlBorderTextBox":
						((ctlBorderTextBox)ctlControl).Paste();
						break;

					case "DataGridTextBox":
						((DataGridTextBox)ctlControl).Paste();
						break;
				}
				return 1;
			}

			return 0;
		}
		#endregion

		# region PublicFuction
		public void Save()
		{
			m_mthSaveTemplate();
		}
		public void Display()
		{
		}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{ 			
		}
		public void Delete()
		{			
		}
		public void Display(string cardno,string sendcheckdate){}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{			
		}
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
	
		#endregion

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text ="";
			this.m_txtTemplateContent.Text ="";
			this.m_txtTemplateName.Text ="";
			this.m_txtTemplateID.Text =""; 
			this.m_lstComboResult.Items.Clear (); 
			m_objArrComboResult.Clear ();

		}

		private void lstTemplateIDs_DoubleClick(object sender, System.EventArgs e)
		{
				string strText=this.lstTemplateIDs.Text;
				if(strText ==null || strText =="") return;
				this.m_txtTemplateID.Text = ((clsTemplate_DetailValue)lstTemplateIDs.SelectedItem).m_strTemplate_ID;  
				this.lstTemplateIDs.Visible =false;
				m_mthLoadTemplateInfo();
		}

		private void m_rdbCommonUse_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_txtKeyword.Text ="";
			this.m_txtKeywordPY.Text =""; 
			m_strSelectICD10_0ID ="";
			m_strSelectICD10_1ID ="";
			m_strSelectICD10_2D ="";
			m_strSelectSystemDetailID ="";
			m_strSelectSystemID ="";
			this.lblTemplateType.Text ="常用值";
			this.m_txtKeywordPY.Enabled =true;
		}

		private void m_chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lstComboResult.Items.Clear ();

			if(m_chkAll.Checked)
			{
				for(int i=0;i<this.m_lstForms.Items.Count;i++)
				{
					m_objControls = m_objDomain.lngGetAllControls (m_objFormListArr[i].m_strForm_ID );
					if(m_objControls!=null && m_objControls.Length >0)
					{
						for(int j=0;j<m_objControls.Length ;j++)
						{
							this.m_lstComboResult.Items.Add (m_objFormListArr[i].m_strForm_Desc + " - " + m_objControls[j].m_strControl_Desc);

							clsTemplate_TargetValue objTemplateTarget=new clsTemplate_TargetValue();
							objTemplateTarget.m_strActivity_Date ="";
							objTemplateTarget.m_strForm_ID=m_objFormListArr[i].m_strForm_ID ;
							objTemplateTarget.m_strControl_ID =m_objControls[j].m_strControl_ID ;
							objTemplateTarget.m_strTemplate_ID ="";

							m_objArrComboResult.Add (objTemplateTarget );
						}
					}				
				}
			}
			else
			{
				m_objArrComboResult.Clear();
			}
						
		}
	}
}
