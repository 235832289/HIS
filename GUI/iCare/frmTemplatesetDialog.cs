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
	/// Summary description for frmTemplatesetDialog.
	/// </summary>
	public class frmTemplatesetDialog : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.TextBox m_txtTemplateID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpEndDate;
		private System.Windows.Forms.Label label5;
		private com.digitalwave.Utility.Controls.ctlTimePicker m_dtpStartDate;
		private System.Windows.Forms.TextBox m_txtTemplateName;
		private System.Windows.Forms.TextBox m_txtKeywordPY;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtKeyword;
		private System.Windows.Forms.Label lblTemplateType;
		protected System.Windows.Forms.RadioButton m_rdbBAXT;
		protected System.Windows.Forms.RadioButton m_rdbKeyWord;
		protected System.Windows.Forms.RadioButton m_rdbICD10;
		protected System.Windows.Forms.RadioButton m_rdbDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPublic;
		protected System.Windows.Forms.CheckedListBox m_lstDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPrivate;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDisease;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboOperation;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tpBase;
		private System.Windows.Forms.TabPage tpUserDefine;
		private System.Windows.Forms.TabPage tpWhere;
		private System.Windows.Forms.TabControl tcTemplateInfo;
		internal System.Windows.Forms.CheckedListBox m_lstUserDefine;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboKeyword;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblOperation;
		private System.Windows.Forms.Label lblDisease;
		private System.Windows.Forms.ListView m_lsvDisease;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP m_cmdDiseaseSelect;
		private PinkieControls.ButtonXP m_cmdDel;
		private PinkieControls.ButtonXP cmdSaveTemplateSet;
		private PinkieControls.ButtonXP cmdClose;
		private PinkieControls.ButtonXP m_cmdAll;
		private PinkieControls.ButtonXP m_cmdClear;
//		private com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind;
        private ArrayList m_arrlTemlateID = new ArrayList();
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmTemplatesetDialog()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.m_dtpEndDate.Value = DateTime.Now.AddYears(100);
        }

		public frmTemplatesetDialog(Form p_frmForm) : this()
		{
			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-9 9:13:43
//			clsBorderTool m_objBorderTool = new clsBorderTool(Color.White);
//			m_objBorderTool.m_mthChangedControlBorder(m_lstDepartment);
//
//			foreach(Control ctlControl in this.Controls )
//			{
//				string typeName = ctlControl.GetType().Name;
//				if(typeName == "ListView" )
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "TextBox" && ctlControl.Name!="m_txtKeywordPY")
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "DataGrid")
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//					((DataGrid)ctlControl).AllowSorting =false ;
//				}
//
//				if(typeName =="TreeView")
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "GroupBox")
//				{
//					foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
//					{
//						string strSubTypeName = ctlGrp.GetType().Name;
//						if(strSubTypeName == "PictureBox")
//						{
//							m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//														{
//															ctlGrp ,
//							});
//						}
//					}
//				}
//			}
			#endregion

			#region 画白边,在构造函数中执行此段代码,刘颖源,2003-5-9 9:13:43
//			m_objBorderTool = new clsBorderTool(Color.White);
//
//			foreach(Control ctlControl in this.m_glbTemplateType.Controls )
//			{
//				string typeName = ctlControl.GetType().Name;
//				if(typeName == "ListView" )
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "TextBox" )
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "DataGrid")
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//					((DataGrid)ctlControl).AllowSorting =false ;
//				}
//
//				if(typeName =="TreeView")
//				{
//					m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//										{
//											ctlControl ,
//					});
//				}
//				if(typeName == "GroupBox")
//				{
//					foreach(Control ctlGrp in ((GroupBox)ctlControl).Controls)
//					{
//						string strSubTypeName = ctlGrp.GetType().Name;
//						if(strSubTypeName == "PictureBox")
//						{
//							m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
//														{
//															ctlGrp ,
//							});
//						}
//					}
//				}
//			}
			#endregion

			m_mthGetFormControlsInformation(p_frmForm);

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);			

			//画白边
            //clsBorderTool objBorderTool = new clsBorderTool(Color.White);
            //objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_txtTemplateName,
            //m_txtKeyword,m_lstUserDefine,m_lstDepartment});
			//ICD10查询
			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind=new com.digitalwave.common.ICD10.Tool.clsBindICD10();
			
			m_objIcd10Bind.m_mthBindICD10(m_cmdDiseaseSelect,m_lsvDisease,0,3,null,null);

		}
		protected ctlHighLightFocus m_objHighLight;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		
		#region 成员变量

		clsControlInfomation[] m_objControlInformationArr;
		string m_strTemplateSetID="";
		string m_strTemplateSetName="";
		string m_strKeyWord="";
		string m_strPYCode="";
		int m_intVisiable=0;
		
		clsTemplateDomain m_objDomain=new clsTemplateDomain ();				//Domain层
		clsDepartmentManager m_objDeptManager = new clsDepartmentManager();
		clsDepartment [] m_objDepartmentArr=null;		//所有的部门
		clsGUI_Info_DetailValue [] m_objControls=null;	//当前Form的Control列表
		ArrayList m_objControlsInForm=new ArrayList ();
		int m_intBeginTemplateID=0;
		#endregion
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
				m_objControlInformationArr = null;
				m_objDomain = null;
				m_objDeptManager = null;
				m_objControls = null;
				if(m_objControlsInForm != null)
				{
					m_objControlsInForm.Clear();
					m_objControlsInForm = null;
				}
				if(m_ctlCurrent != null)
				{
					m_ctlCurrent.Dispose();
					m_ctlCurrent = null;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTemplatesetDialog));
			this.m_txtTemplateID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_dtpEndDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.m_dtpStartDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_txtTemplateName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.m_cboOperation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblOperation = new System.Windows.Forms.Label();
			this.m_cboDisease = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblDisease = new System.Windows.Forms.Label();
			this.m_txtKeyword = new System.Windows.Forms.TextBox();
			this.lblTemplateType = new System.Windows.Forms.Label();
			this.m_rdbBAXT = new System.Windows.Forms.RadioButton();
			this.m_rdbKeyWord = new System.Windows.Forms.RadioButton();
			this.m_rdbICD10 = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtKeywordPY = new System.Windows.Forms.TextBox();
			this.m_rdbDepartment = new System.Windows.Forms.RadioButton();
			this.m_rdbPublic = new System.Windows.Forms.RadioButton();
			this.m_lstDepartment = new System.Windows.Forms.CheckedListBox();
			this.m_rdbPrivate = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tcTemplateInfo = new System.Windows.Forms.TabControl();
			this.tpBase = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lsvDisease = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_cboKeyword = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.tpUserDefine = new System.Windows.Forms.TabPage();
			this.m_lstUserDefine = new System.Windows.Forms.CheckedListBox();
			this.tpWhere = new System.Windows.Forms.TabPage();
			this.m_cmdDiseaseSelect = new PinkieControls.ButtonXP();
			this.m_cmdDel = new PinkieControls.ButtonXP();
			this.cmdSaveTemplateSet = new PinkieControls.ButtonXP();
			this.cmdClose = new PinkieControls.ButtonXP();
			this.m_cmdAll = new PinkieControls.ButtonXP();
			this.m_cmdClear = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			this.tcTemplateInfo.SuspendLayout();
			this.tpBase.SuspendLayout();
			this.tpUserDefine.SuspendLayout();
			this.tpWhere.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtTemplateID
			// 
			this.m_txtTemplateID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtTemplateID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtTemplateID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemplateID.ForeColor = System.Drawing.Color.White;
			this.m_txtTemplateID.Location = new System.Drawing.Point(376, 16);
			this.m_txtTemplateID.Name = "m_txtTemplateID";
			this.m_txtTemplateID.Size = new System.Drawing.Size(101, 19);
			this.m_txtTemplateID.TabIndex = 15022;
			this.m_txtTemplateID.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(280, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 22);
			this.label3.TabIndex = 15029;
			this.label3.Text = "模板编号:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(168, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 22);
			this.label6.TabIndex = 15028;
			this.label6.Text = "停用时间:";
			// 
			// m_dtpEndDate
			// 
			this.m_dtpEndDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpEndDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpEndDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpEndDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpEndDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpEndDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpEndDate.Location = new System.Drawing.Point(260, 40);
			this.m_dtpEndDate.m_BlnOnlyTime = false;
			this.m_dtpEndDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpEndDate.Name = "m_dtpEndDate";
			this.m_dtpEndDate.ReadOnly = false;
			this.m_dtpEndDate.Size = new System.Drawing.Size(52, 22);
			this.m_dtpEndDate.TabIndex = 15025;
			this.m_dtpEndDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpEndDate.TextForeColor = System.Drawing.Color.White;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(20, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 22);
			this.label5.TabIndex = 15027;
			this.label5.Text = "启用时间:";
			// 
			// m_dtpStartDate
			// 
			this.m_dtpStartDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpStartDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpStartDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpStartDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpStartDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpStartDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpStartDate.Location = new System.Drawing.Point(108, 40);
			this.m_dtpStartDate.m_BlnOnlyTime = false;
			this.m_dtpStartDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpStartDate.Name = "m_dtpStartDate";
			this.m_dtpStartDate.ReadOnly = false;
			this.m_dtpStartDate.Size = new System.Drawing.Size(40, 22);
			this.m_dtpStartDate.TabIndex = 15024;
			this.m_dtpStartDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpStartDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_txtTemplateName
			// 
			this.m_txtTemplateName.BackColor = System.Drawing.Color.White;
			this.m_txtTemplateName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtTemplateName.ForeColor = System.Drawing.Color.Black;
			this.m_txtTemplateName.Location = new System.Drawing.Point(103, 16);
			this.m_txtTemplateName.MaxLength = 25;
			this.m_txtTemplateName.Name = "m_txtTemplateName";
			this.m_txtTemplateName.Size = new System.Drawing.Size(240, 23);
			this.m_txtTemplateName.TabIndex = 0;
			this.m_txtTemplateName.Text = "";
			this.m_txtTemplateName.TextChanged += new System.EventHandler(this.m_txtTemplateName_TextChanged);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblName.ForeColor = System.Drawing.Color.Black;
			this.lblName.Location = new System.Drawing.Point(23, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(70, 19);
			this.lblName.TabIndex = 15026;
			this.lblName.Text = "模板名称:";
			// 
			// m_cboOperation
			// 
			this.m_cboOperation.BackColor = System.Drawing.Color.White;
			this.m_cboOperation.BorderColor = System.Drawing.Color.Black;
			this.m_cboOperation.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboOperation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboOperation.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboOperation.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboOperation.ForeColor = System.Drawing.Color.Black;
			this.m_cboOperation.ListBackColor = System.Drawing.Color.White;
			this.m_cboOperation.ListForeColor = System.Drawing.Color.Black;
			this.m_cboOperation.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboOperation.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboOperation.Location = new System.Drawing.Point(35, 172);
			this.m_cboOperation.m_BlnEnableItemEventMenu = true;
			this.m_cboOperation.Name = "m_cboOperation";
			this.m_cboOperation.SelectedIndex = -1;
			this.m_cboOperation.SelectedItem = null;
			this.m_cboOperation.Size = new System.Drawing.Size(28, 23);
			this.m_cboOperation.TabIndex = 300;
			this.m_cboOperation.TextBackColor = System.Drawing.Color.White;
			this.m_cboOperation.TextForeColor = System.Drawing.Color.Black;
			this.m_cboOperation.Visible = false;
			this.m_cboOperation.DropDown += new System.EventHandler(this.m_cboOperation_DropDown);
			// 
			// lblOperation
			// 
			this.lblOperation.AutoSize = true;
			this.lblOperation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOperation.ForeColor = System.Drawing.Color.Black;
			this.lblOperation.Location = new System.Drawing.Point(31, 176);
			this.lblOperation.Name = "lblOperation";
			this.lblOperation.Size = new System.Drawing.Size(70, 19);
			this.lblOperation.TabIndex = 3032;
			this.lblOperation.Text = "手术名称:";
			this.lblOperation.Visible = false;
			// 
			// m_cboDisease
			// 
			this.m_cboDisease.BackColor = System.Drawing.Color.White;
			this.m_cboDisease.BorderColor = System.Drawing.Color.Black;
			this.m_cboDisease.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboDisease.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDisease.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDisease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboDisease.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDisease.ForeColor = System.Drawing.Color.Black;
			this.m_cboDisease.ListBackColor = System.Drawing.Color.White;
			this.m_cboDisease.ListForeColor = System.Drawing.Color.Black;
			this.m_cboDisease.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDisease.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboDisease.Location = new System.Drawing.Point(35, 172);
			this.m_cboDisease.m_BlnEnableItemEventMenu = true;
			this.m_cboDisease.Name = "m_cboDisease";
			this.m_cboDisease.SelectedIndex = -1;
			this.m_cboDisease.SelectedItem = null;
			this.m_cboDisease.Size = new System.Drawing.Size(28, 23);
			this.m_cboDisease.TabIndex = 200;
			this.m_cboDisease.TextBackColor = System.Drawing.Color.White;
			this.m_cboDisease.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDisease.Visible = false;
			this.m_cboDisease.DropDown += new System.EventHandler(this.m_cboDisease_DropDown);
			// 
			// lblDisease
			// 
			this.lblDisease.AutoSize = true;
			this.lblDisease.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDisease.ForeColor = System.Drawing.Color.Black;
			this.lblDisease.Location = new System.Drawing.Point(31, 172);
			this.lblDisease.Name = "lblDisease";
			this.lblDisease.Size = new System.Drawing.Size(41, 19);
			this.lblDisease.TabIndex = 3030;
			this.lblDisease.Text = "病名:";
			this.lblDisease.Visible = false;
			// 
			// m_txtKeyword
			// 
			this.m_txtKeyword.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtKeyword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtKeyword.ForeColor = System.Drawing.Color.White;
			this.m_txtKeyword.Location = new System.Drawing.Point(48, 12);
			this.m_txtKeyword.Name = "m_txtKeyword";
			this.m_txtKeyword.Size = new System.Drawing.Size(28, 19);
			this.m_txtKeyword.TabIndex = 200;
			this.m_txtKeyword.Text = "";
			// 
			// lblTemplateType
			// 
			this.lblTemplateType.AutoSize = true;
			this.lblTemplateType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTemplateType.ForeColor = System.Drawing.Color.Black;
			this.lblTemplateType.Location = new System.Drawing.Point(52, 46);
			this.lblTemplateType.Name = "lblTemplateType";
			this.lblTemplateType.Size = new System.Drawing.Size(41, 19);
			this.lblTemplateType.TabIndex = 3028;
			this.lblTemplateType.Text = "分类:";
			// 
			// m_rdbBAXT
			// 
			this.m_rdbBAXT.Enabled = false;
			this.m_rdbBAXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbBAXT.Location = new System.Drawing.Point(112, 12);
			this.m_rdbBAXT.Name = "m_rdbBAXT";
			this.m_rdbBAXT.Size = new System.Drawing.Size(16, 24);
			this.m_rdbBAXT.TabIndex = 900;
			this.m_rdbBAXT.Text = "八大系统";
			// 
			// m_rdbKeyWord
			// 
			this.m_rdbKeyWord.Checked = true;
			this.m_rdbKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbKeyWord.Location = new System.Drawing.Point(136, 12);
			this.m_rdbKeyWord.Name = "m_rdbKeyWord";
			this.m_rdbKeyWord.Size = new System.Drawing.Size(20, 24);
			this.m_rdbKeyWord.TabIndex = 700;
			this.m_rdbKeyWord.TabStop = true;
			this.m_rdbKeyWord.Text = "关键字";
			// 
			// m_rdbICD10
			// 
			this.m_rdbICD10.Enabled = false;
			this.m_rdbICD10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbICD10.Location = new System.Drawing.Point(92, 16);
			this.m_rdbICD10.Name = "m_rdbICD10";
			this.m_rdbICD10.Size = new System.Drawing.Size(16, 12);
			this.m_rdbICD10.TabIndex = 600;
			this.m_rdbICD10.Text = "ICD - 10";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(164, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 22);
			this.label4.TabIndex = 3046;
			this.label4.Text = "拼音首码";
			this.label4.Visible = false;
			// 
			// m_txtKeywordPY
			// 
			this.m_txtKeywordPY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_txtKeywordPY.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtKeywordPY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtKeywordPY.ForeColor = System.Drawing.Color.White;
			this.m_txtKeywordPY.Location = new System.Drawing.Point(248, 16);
			this.m_txtKeywordPY.Name = "m_txtKeywordPY";
			this.m_txtKeywordPY.Size = new System.Drawing.Size(28, 19);
			this.m_txtKeywordPY.TabIndex = 1400;
			this.m_txtKeywordPY.Text = "";
			this.m_txtKeywordPY.Visible = false;
			// 
			// m_rdbDepartment
			// 
			this.m_rdbDepartment.Location = new System.Drawing.Point(16, 152);
			this.m_rdbDepartment.Name = "m_rdbDepartment";
			this.m_rdbDepartment.Size = new System.Drawing.Size(92, 22);
			this.m_rdbDepartment.TabIndex = 1200;
			this.m_rdbDepartment.Text = "科室使用";
			this.m_rdbDepartment.CheckedChanged += new System.EventHandler(this.m_rdbDepartment_CheckedChanged);
			// 
			// m_rdbPublic
			// 
			this.m_rdbPublic.Checked = true;
			this.m_rdbPublic.Location = new System.Drawing.Point(16, 84);
			this.m_rdbPublic.Name = "m_rdbPublic";
			this.m_rdbPublic.Size = new System.Drawing.Size(60, 26);
			this.m_rdbPublic.TabIndex = 1100;
			this.m_rdbPublic.TabStop = true;
			this.m_rdbPublic.Text = "公用";
			this.m_rdbPublic.CheckedChanged += new System.EventHandler(this.m_rdbPublic_CheckedChanged);
			// 
			// m_lstDepartment
			// 
			this.m_lstDepartment.BackColor = System.Drawing.Color.White;
			this.m_lstDepartment.CheckOnClick = true;
			this.m_lstDepartment.ForeColor = System.Drawing.Color.Black;
			this.m_lstDepartment.Location = new System.Drawing.Point(116, 16);
			this.m_lstDepartment.Name = "m_lstDepartment";
			this.m_lstDepartment.Size = new System.Drawing.Size(236, 166);
			this.m_lstDepartment.TabIndex = 1300;
			// 
			// m_rdbPrivate
			// 
			this.m_rdbPrivate.Location = new System.Drawing.Point(16, 24);
			this.m_rdbPrivate.Name = "m_rdbPrivate";
			this.m_rdbPrivate.Size = new System.Drawing.Size(60, 24);
			this.m_rdbPrivate.TabIndex = 1000;
			this.m_rdbPrivate.Text = "自用";
			this.m_rdbPrivate.CheckedChanged += new System.EventHandler(this.m_rdbPrivate_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_rdbICD10);
			this.groupBox1.Controls.Add(this.m_rdbBAXT);
			this.groupBox1.Controls.Add(this.m_rdbKeyWord);
			this.groupBox1.Controls.Add(this.m_txtKeywordPY);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.m_txtTemplateID);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.m_dtpStartDate);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.m_dtpEndDate);
			this.groupBox1.Controls.Add(this.m_txtKeyword);
			this.groupBox1.Location = new System.Drawing.Point(16, 280);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(116, 4);
			this.groupBox1.TabIndex = 15035;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "no use";
			this.groupBox1.Visible = false;
			// 
			// tcTemplateInfo
			// 
			this.tcTemplateInfo.Controls.Add(this.tpBase);
			this.tcTemplateInfo.Controls.Add(this.tpUserDefine);
			this.tcTemplateInfo.Controls.Add(this.tpWhere);
			this.tcTemplateInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.tcTemplateInfo.Location = new System.Drawing.Point(0, 0);
			this.tcTemplateInfo.Name = "tcTemplateInfo";
			this.tcTemplateInfo.SelectedIndex = 0;
			this.tcTemplateInfo.Size = new System.Drawing.Size(374, 228);
			this.tcTemplateInfo.TabIndex = 15036;
			// 
			// tpBase
			// 
			this.tpBase.BackColor = System.Drawing.SystemColors.Control;
			this.tpBase.Controls.Add(this.m_cmdDiseaseSelect);
			this.tpBase.Controls.Add(this.label1);
			this.tpBase.Controls.Add(this.m_lsvDisease);
			this.tpBase.Controls.Add(this.m_cboKeyword);
			this.tpBase.Controls.Add(this.m_txtTemplateName);
			this.tpBase.Controls.Add(this.lblOperation);
			this.tpBase.Controls.Add(this.m_cboDisease);
			this.tpBase.Controls.Add(this.lblTemplateType);
			this.tpBase.Controls.Add(this.m_cboOperation);
			this.tpBase.Controls.Add(this.lblName);
			this.tpBase.Controls.Add(this.lblDisease);
			this.tpBase.Controls.Add(this.m_cmdDel);
			this.tpBase.ForeColor = System.Drawing.Color.Black;
			this.tpBase.Location = new System.Drawing.Point(4, 23);
			this.tpBase.Name = "tpBase";
			this.tpBase.Size = new System.Drawing.Size(366, 201);
			this.tpBase.TabIndex = 0;
			this.tpBase.Text = "基本信息";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(23, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 19);
			this.label1.TabIndex = 15029;
			this.label1.Text = "国际疾病:";
			// 
			// m_lsvDisease
			// 
			this.m_lsvDisease.BackColor = System.Drawing.Color.White;
			this.m_lsvDisease.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1});
			this.m_lsvDisease.ForeColor = System.Drawing.Color.Black;
			this.m_lsvDisease.FullRowSelect = true;
			this.m_lsvDisease.GridLines = true;
			this.m_lsvDisease.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvDisease.HideSelection = false;
			this.m_lsvDisease.Location = new System.Drawing.Point(103, 68);
			this.m_lsvDisease.Name = "m_lsvDisease";
			this.m_lsvDisease.Size = new System.Drawing.Size(240, 96);
			this.m_lsvDisease.TabIndex = 15028;
			this.m_lsvDisease.View = System.Windows.Forms.View.Details;
			this.m_lsvDisease.DoubleClick += new System.EventHandler(this.m_cmdDel_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 231;
			// 
			// m_cboKeyword
			// 
			this.m_cboKeyword.BackColor = System.Drawing.Color.White;
			this.m_cboKeyword.BorderColor = System.Drawing.Color.Black;
			this.m_cboKeyword.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboKeyword.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboKeyword.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboKeyword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboKeyword.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboKeyword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboKeyword.ForeColor = System.Drawing.Color.Black;
			this.m_cboKeyword.ListBackColor = System.Drawing.Color.White;
			this.m_cboKeyword.ListForeColor = System.Drawing.Color.Black;
			this.m_cboKeyword.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboKeyword.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboKeyword.Location = new System.Drawing.Point(103, 44);
			this.m_cboKeyword.m_BlnEnableItemEventMenu = true;
			this.m_cboKeyword.Name = "m_cboKeyword";
			this.m_cboKeyword.SelectedIndex = -1;
			this.m_cboKeyword.SelectedItem = null;
			this.m_cboKeyword.Size = new System.Drawing.Size(240, 23);
			this.m_cboKeyword.TabIndex = 100;
			this.m_cboKeyword.TextBackColor = System.Drawing.Color.White;
			this.m_cboKeyword.TextForeColor = System.Drawing.Color.Black;
			this.m_cboKeyword.DropDown += new System.EventHandler(this.m_cboKeyword_DropDown);
			// 
			// tpUserDefine
			// 
			this.tpUserDefine.BackColor = System.Drawing.SystemColors.Control;
			this.tpUserDefine.Controls.Add(this.m_cmdAll);
			this.tpUserDefine.Controls.Add(this.m_lstUserDefine);
			this.tpUserDefine.Controls.Add(this.m_cmdClear);
			this.tpUserDefine.ForeColor = System.Drawing.Color.Black;
			this.tpUserDefine.Location = new System.Drawing.Point(4, 23);
			this.tpUserDefine.Name = "tpUserDefine";
			this.tpUserDefine.Size = new System.Drawing.Size(366, 201);
			this.tpUserDefine.TabIndex = 1;
			this.tpUserDefine.Text = "自定义组合";
			// 
			// m_lstUserDefine
			// 
			this.m_lstUserDefine.BackColor = System.Drawing.Color.White;
			this.m_lstUserDefine.CheckOnClick = true;
			this.m_lstUserDefine.ForeColor = System.Drawing.Color.Black;
			this.m_lstUserDefine.Location = new System.Drawing.Point(12, 8);
			this.m_lstUserDefine.Name = "m_lstUserDefine";
			this.m_lstUserDefine.Size = new System.Drawing.Size(236, 166);
			this.m_lstUserDefine.TabIndex = 1301;
			// 
			// tpWhere
			// 
			this.tpWhere.BackColor = System.Drawing.SystemColors.Control;
			this.tpWhere.Controls.Add(this.m_rdbDepartment);
			this.tpWhere.Controls.Add(this.m_rdbPublic);
			this.tpWhere.Controls.Add(this.m_lstDepartment);
			this.tpWhere.Controls.Add(this.m_rdbPrivate);
			this.tpWhere.ForeColor = System.Drawing.Color.Black;
			this.tpWhere.Location = new System.Drawing.Point(4, 23);
			this.tpWhere.Name = "tpWhere";
			this.tpWhere.Size = new System.Drawing.Size(366, 201);
			this.tpWhere.TabIndex = 2;
			this.tpWhere.Text = "适用范围";
			// 
			// m_cmdDiseaseSelect
			// 
			this.m_cmdDiseaseSelect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDiseaseSelect.DefaultScheme = true;
			this.m_cmdDiseaseSelect.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDiseaseSelect.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDiseaseSelect.Hint = "";
			this.m_cmdDiseaseSelect.Location = new System.Drawing.Point(208, 168);
			this.m_cmdDiseaseSelect.Name = "m_cmdDiseaseSelect";
			this.m_cmdDiseaseSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDiseaseSelect.Size = new System.Drawing.Size(60, 28);
			this.m_cmdDiseaseSelect.TabIndex = 10000002;
			this.m_cmdDiseaseSelect.Text = "添 加";
			// 
			// m_cmdDel
			// 
			this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDel.DefaultScheme = true;
			this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDel.Hint = "";
			this.m_cmdDel.Location = new System.Drawing.Point(284, 168);
			this.m_cmdDel.Name = "m_cmdDel";
			this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDel.Size = new System.Drawing.Size(60, 28);
			this.m_cmdDel.TabIndex = 10000002;
			this.m_cmdDel.Text = "删 除";
			this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
			// 
			// cmdSaveTemplateSet
			// 
			this.cmdSaveTemplateSet.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdSaveTemplateSet.DefaultScheme = true;
			this.cmdSaveTemplateSet.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdSaveTemplateSet.ForeColor = System.Drawing.Color.Black;
			this.cmdSaveTemplateSet.Hint = "";
			this.cmdSaveTemplateSet.Location = new System.Drawing.Point(228, 244);
			this.cmdSaveTemplateSet.Name = "cmdSaveTemplateSet";
			this.cmdSaveTemplateSet.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdSaveTemplateSet.Size = new System.Drawing.Size(60, 36);
			this.cmdSaveTemplateSet.TabIndex = 10000002;
			this.cmdSaveTemplateSet.Text = "保 存";
			this.cmdSaveTemplateSet.Click += new System.EventHandler(this.cmdSaveTemplateSet_Click);
			// 
			// cmdClose
			// 
			this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdClose.DefaultScheme = true;
			this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdClose.ForeColor = System.Drawing.Color.Black;
			this.cmdClose.Hint = "";
			this.cmdClose.Location = new System.Drawing.Point(308, 244);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdClose.Size = new System.Drawing.Size(60, 36);
			this.cmdClose.TabIndex = 10000002;
			this.cmdClose.Text = "关 闭";
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			// 
			// m_cmdAll
			// 
			this.m_cmdAll.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAll.DefaultScheme = true;
			this.m_cmdAll.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAll.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAll.Hint = "";
			this.m_cmdAll.Location = new System.Drawing.Point(280, 88);
			this.m_cmdAll.Name = "m_cmdAll";
			this.m_cmdAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAll.Size = new System.Drawing.Size(60, 36);
			this.m_cmdAll.TabIndex = 10000003;
			this.m_cmdAll.Text = "全 选";
			this.m_cmdAll.Click += new System.EventHandler(this.m_cmdAll_Click);
			// 
			// m_cmdClear
			// 
			this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClear.DefaultScheme = true;
			this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClear.ForeColor = System.Drawing.Color.Black;
			this.m_cmdClear.Hint = "";
			this.m_cmdClear.Location = new System.Drawing.Point(280, 140);
			this.m_cmdClear.Name = "m_cmdClear";
			this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClear.Size = new System.Drawing.Size(60, 36);
			this.m_cmdClear.TabIndex = 10000003;
			this.m_cmdClear.Text = "清 空";
			this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
			// 
			// frmTemplatesetDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(374, 295);
			this.Controls.Add(this.tcTemplateInfo);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdSaveTemplateSet);
			this.Controls.Add(this.cmdClose);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTemplatesetDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "生成模板";
			this.Load += new System.EventHandler(this.frmTemplatesetDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.tcTemplateInfo.ResumeLayout(false);
			this.tpBase.ResumeLayout(false);
			this.tpUserDefine.ResumeLayout(false);
			this.tpWhere.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdSaveTemplateSet_Click(object sender, System.EventArgs e)
		{
			if(this.m_txtTemplateName.Text.Trim() =="" || this.m_cboKeyword.Text.Trim() =="")
			{
				this.cmdSaveTemplateSet.Enabled =true;
				clsPublicFunction.ShowInformationMessageBox("请输入模板名称或分类!");
				return;
			}

			if(m_txtTemplateName.Text.Length > 25 || m_cboKeyword.Text.Length > 25)
			{
				this.cmdSaveTemplateSet.Enabled =true;
				clsPublicFunction.ShowInformationMessageBox("注意：模板名或关键字不能超过25个字符！");
				return;
			}

			if(m_lstUserDefine.CheckedItems.Count <= 0)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少选择一项!");
				return;
			}

            if(m_rdbDepartment.Checked && this.m_lstDepartment.CheckedItems.Count <=0)
            {
                clsPublicFunction.ShowInformationMessageBox("没有选定任何部门使用该模板");
                return;
            }

            ArrayList arlTemp = new ArrayList();
            arlTemp.AddRange(m_lstUserDefine.CheckedItems);
            m_objControlInformationArr = (clsControlInfomation[])arlTemp.ToArray(typeof(clsControlInfomation));

            string strFormID = "";
            if (m_objControlInformationArr != null && m_objControlInformationArr.Length > 0)
            {
                strFormID = m_objControlInformationArr[0].objGUI_Info.m_strForm_ID;
            }
            string m_strCheckSetID = m_objDomain.strCheckTemplateSetID(m_txtTemplateName.Text.Trim(), m_cboKeyword.Text.Trim(), strFormID.Trim());
            if (m_strCheckSetID != null && m_strCheckSetID != string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("当前模板已存在，请重新指定模板名！");
                return;
            }

            this.cmdSaveTemplateSet.Enabled = false;

            m_arrlTemlateID.Clear();

			for(int i=0;i<m_objControlInformationArr.Length ;i++)
			{
				string strTemplateID = "";
				m_mthSaveTemplateUnit(m_objControlInformationArr[i].objGUI_Info.m_strControl_Desc ,
                    m_objControlInformationArr[i].strContent ,m_objControlInformationArr[i].objGUI_Info.m_strForm_ID ,
                    m_objControlInformationArr[i].objGUI_Info.m_strControl_ID, m_objControlInformationArr[i].objGUI_Info.m_strControl_TabIndex,out strTemplateID ); 
				m_arrlTemlateID.Add(strTemplateID);
			}

			#region 只保存有内容的单元模板，如果全没内容，不允许保存。
//			ArrayList arlTemplateUnits = new ArrayList();
//			for(int i = 0; i < m_objControlInformationArr.Length; i++)
//			{
//				if(m_objControlInformationArr[i].strContent.Trim() != "")	
//					arlTemplateUnits.Add(m_objControlInformationArr[i]);
//			}
//			if(arlTemplateUnits.Count <= 0)
//			{
//				clsPublicFunction.ShowInformationMessageBox("请输入模板内容！");
//				return;
//			}
//			clsControlInfomation[] objCIArr = (clsControlInfomation[])arlTemplateUnits.ToArray(typeof(clsControlInfomation));
//			for(int i = 0; i < objCIArr.Length; i++)
//			{
//				int intID=(m_intBeginTemplateID +i);
//				m_mthSaveTemplateUnit(intID.ToString ("00000"),objCIArr[i].objGUI_Info.m_strControl_Desc ,objCIArr[i].strContent ,objCIArr[i].objGUI_Info.m_strForm_ID ,objCIArr[i].objGUI_Info.m_strControl_ID ); 			
//			}
			#endregion

			
			m_mthSaveTemplateSet();

			this.cmdSaveTemplateSet.Enabled =true;
			this.Close ();
		}
		#region 保存套装模板
		private void m_mthSaveTemplateSet()
		{
			if(this.m_txtTemplateName.Text.Trim() =="" || this.m_cboKeyword.Text.Trim() =="")
			{
				clsPublicFunction.ShowInformationMessageBox("请输入模板名称或分类!");
				return;
			}
            string strTemplateID = "";
//			strTemplateID =m_objDomain.strGetTemplateSetID ();
//			if(strTemplateID ==null || strTemplateID =="")strTemplateID ="000001";
			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
			#region clsTempate_SetValue,刘颖源,2003-5-9 11:05:50
			clsTempate_SetValue objTemplate_Set=new clsTempate_SetValue();
            objTemplate_Set.m_strSet_ID = strTemplateID;
			objTemplate_Set.m_strStart_Date = this.m_dtpStartDate.Value.ToString ();
			objTemplate_Set.m_strEnd_Date =this.m_dtpEndDate.Value.ToString (); 
			#endregion

			#region clsTemplate_Set_Detail_01Value,刘颖源,2003-5-9 14:37:44
			clsTemplate_Set_Detail_01Value[] objTemplate_Set_Detail01=new clsTemplate_Set_Detail_01Value[1];
			objTemplate_Set_Detail01[0]=new clsTemplate_Set_Detail_01Value();
            objTemplate_Set_Detail01[0].m_strSet_ID = strTemplateID;
			objTemplate_Set_Detail01[0].m_strActivity_Date =strCurrentDate ;
			objTemplate_Set_Detail01[0].m_strSet_Name =this.m_txtTemplateName.Text ;
			#endregion
		
			#region clsTemplate_Set_Detail_02Value,刘颖源,2003-5-9 14:44:54
			clsTemplate_Set_Detail_02Value [] objTemplate_Set_Detail02=null;
			if(m_objControlInformationArr !=null && m_objControlInformationArr.Length >0)
			{
				objTemplate_Set_Detail02=new clsTemplate_Set_Detail_02Value[m_objControlInformationArr.Length ];
				for(int i=0;i<m_objControlInformationArr.Length  ;i++)
				{
					string strTempID = m_arrlTemlateID[i].ToString().Trim();
					objTemplate_Set_Detail02[i] =new clsTemplate_Set_Detail_02Value();
					objTemplate_Set_Detail02[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Set_Detail02[i].m_strControl_ID =m_objControlInformationArr[i].objGUI_Info.m_strControl_ID  ;
					objTemplate_Set_Detail02[i].m_strForm_ID =m_objControlInformationArr[i].objGUI_Info.m_strForm_ID   ;
                    objTemplate_Set_Detail02[i].m_strSet_ID = strTemplateID; 
					objTemplate_Set_Detail02[i].m_strTemplate_ID =strTempID ;
                    objTemplate_Set_Detail02[i].m_strControl_TabIndex = m_objControlInformationArr[i].objGUI_Info.m_strControl_TabIndex;
				}
			}
			#endregion

			#region clsTemplate_Set_KeywordValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_Set_KeywordValue [] objTemplate_Keyword=null;
			if(this.m_rdbKeyWord.Checked )
			{
				string strKeywords=this.m_cboKeyword.Text ;
				string strKeywordPYs=this.m_txtKeywordPY.Text ;
				string[] strKeywodArr= strKeywords.Split (',');
				string[] strKeywordPyArr=strKeywordPYs.Split (',');
				objTemplate_Keyword=new clsTemplate_Set_KeywordValue [strKeywodArr.Length];
				for(int i=0;i<strKeywodArr.Length ;i++)
				{
					objTemplate_Keyword[i]=new clsTemplate_Set_KeywordValue ();
                    objTemplate_Keyword[i].m_strSet_ID = strTemplateID;
					objTemplate_Keyword[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Keyword[i].m_strKeyword =strKeywodArr[i];
					objTemplate_Keyword[i].m_strKeyword_PY ="";
					objTemplate_Keyword[i].m_strKeyword_Type ="1";
				}
			}
			else if(this.m_rdbICD10.Checked )
			{

			}
			else
			{
			}
			#endregion				

            m_objDomain.lngSaveTemplateSet(true, objTemplate_Set, objTemplate_Set_Detail01, objTemplate_Set_Detail02, objTemplate_Keyword, out strTemplateID);

            m_strTemplateSetID = strTemplateID;
			m_strTemplateSetName=this.m_txtTemplateName.Text ; 
			m_strKeyWord =this.m_cboKeyword.Text ;
			m_strPYCode = this.m_txtKeywordPY.Text ;		
	
			m_mthSaveTemplateSet_Associate();
			m_mthSaveICD10_TemplateSet(m_lsvDisease,m_strTemplateSetID);

//			clsPublicFunction.ShowInformationMessageBox ("套装模板已经生成,编号为" + m_strTemplateSetID  );
            this.m_txtTemplateID.Text = m_strTemplateSetID;
		}		

		#endregion
		
		/// <summary>
		/// 保存套装模板所关联的字段
		/// </summary>
		private void m_mthSaveTemplateSet_Associate()
		{
//			clsTemplateSetDisease objTSD = new clsTemplateSetDisease();
//
//			string strDiseaseName = m_cboDisease.Text.Trim();
//			objTSD.strDiseaseID = (strDiseaseName == "") ? "" : m_objDomain.m_strGetDiseaseIDByDiseaseName(strDiseaseName);
//
//			objTSD.strFormName = m_strTemplateSetFormName;
//			objTSD.strTemplateSetID = m_strTemplateSetID;
//			objTSD.strDiseaseName = m_cboDisease.Text.Trim();
//
//			m_objDomain.lngSaveTemplateSetDisease(objTSD);

			clsTemplateSet_Associate objDisease = new clsTemplateSet_Associate();
			string strDiseaseName = m_cboDisease.Text.Trim();
			objDisease.strAssociateID = (strDiseaseName == "") ? "" : m_objDomain.m_strGetAssociateIDByAssociateName(strDiseaseName,(int)enmAssociate.Disease);
			objDisease.strFormName = m_strTemplateSetFormName;
			objDisease.strTemplateSetID = m_strTemplateSetID;
			objDisease.strAssociateName = strDiseaseName;
			objDisease.intType = (int)enmAssociate.Disease;
			objDisease.strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			m_objDomain.lngSaveTemplateSet_Associate(objDisease);

			clsTemplateSet_Associate objOperation = new clsTemplateSet_Associate();
			string strOperationName = m_cboOperation.Text.Trim();
			objOperation.strAssociateID = (strOperationName == "") ? "" : m_objDomain.m_strGetAssociateIDByAssociateName(strOperationName,(int)enmAssociate.Operation);
			objOperation.strFormName = m_strTemplateSetFormName;
			objOperation.strTemplateSetID = m_strTemplateSetID;
			objOperation.strAssociateName = strOperationName;
			objOperation.intType = (int)enmAssociate.Operation;
			objOperation.strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			m_objDomain.lngSaveTemplateSet_Associate(objOperation);
		}





		#region 寻找各个窗体下所有的控件及其文本信息
		private void m_mthGetFormControlsInformation(Form p_strForm)
		{
			string strFormName = p_strForm.Name;
			if(p_strForm is iCare.CustomForm.frmCustomFormBase)
				strFormName = ((iCare.CustomForm.frmCustomFormBase)p_strForm).m_strGetCurFormName();

			m_objControls = m_objDomain.lngGetAllControls (strFormName);			
			if(m_objControls!=null && m_objControls.Length >0)
			{
				m_objControlsInForm.Clear ();
				m_mthFindTemplateControlInContainer(p_strForm);
			}
		}

		private void m_mthFindTemplateControlInContainer(Control p_ctlContainer)
		{
			foreach(Control ctlChild in p_ctlContainer.Controls)
			{
				switch(ctlChild.GetType().Name)
				{
					case "ctlRichTextBox":
						m_objControlsInForm.Add ((RichTextBox)ctlChild);						
						break;
					case "RichTextBox":
						m_objControlsInForm.Add ((RichTextBox)ctlChild);
						break;
					default:
						m_mthFindTemplateControlInContainer(ctlChild);
						break;
				}				
			}
		}
		#endregion

		#region 保存单元模板
		public void m_mthSaveTemplateUnit(string p_strTemplateName,string p_strTemplateUnitContent,string p_strFormID,
            string p_strControlID, string p_strControl_TabIndex, out string p_strTemplate)
		{
			//判断
            clsTemplateValue objTemplateValueExist;
            bool blnInsert = true;
			p_strTemplate = "";
			string strCurrentDate=DateTime.Now.ToString ("yyyy-MM-dd HH:mm:ss");
			long lngRes = m_objDomain.m_lngCheckTemplate (m_txtTemplateName.Text, m_cboKeyword.Text,this.m_txtTemplateName.Text + " - " + p_strTemplateName, out p_strTemplate);		
			
			if(p_strTemplate !=null && p_strTemplate != string.Empty)
			{
				blnInsert=false;
			}

			//所有的Template_ID和ActiveDate在Domain层中获得
			#region clsTemplateValue和clsTemplate_DetailValue,刘颖源,2003-5-8 11:11:40
			clsTemplateValue objTemplate=new clsTemplateValue();
			objTemplate.m_strStart_Date = this.m_dtpStartDate.Value.ToString ();
			objTemplate.m_strEnd_Date = this.m_dtpEndDate.Value.ToString ();
			objTemplate.m_strTemplate_ID =p_strTemplate ;
			
			
			clsTemplate_DetailValue objTemplate_Detail=new clsTemplate_DetailValue();
			objTemplate_Detail.m_strContent =p_strTemplateUnitContent;
			//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			objTemplate_Detail.m_strEmployeeID =MDIParent.OperatorID;
			objTemplate_Detail.m_strTemplate_Name = this.m_txtTemplateName.Text + " - " + p_strTemplateName ;
			objTemplate_Detail.m_strActivity_Date =strCurrentDate ;
			objTemplate_Detail.m_strTemplate_ID =p_strTemplate ;
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
//				if(strKeywodArr.Length !=strKeywordPyArr.Length || strKeywodArr.Length <=0)
//				{
//					clsPublicFunction.ShowInformationMessageBox  ("关键字和对应的拼音码数目不相同或者没有输入关键字!");
//					return;
//				}
				objTemplate_Keyword=new clsTemplate_KeywordValue [strKeywodArr.Length];
				for(int i=0;i<strKeywodArr.Length ;i++)
				{
					objTemplate_Keyword[i]=new clsTemplate_KeywordValue ();
					objTemplate_Keyword[i].m_strTemplate_ID =p_strTemplate ;
					objTemplate_Keyword[i].m_strActivity_Date =strCurrentDate ;
					objTemplate_Keyword[i].m_strKeyword =strKeywodArr[i];
					objTemplate_Keyword[i].m_strKeyword_PY ="";
					objTemplate_Keyword[i].m_strKeyword_Type ="1";
				}
			}
			else if(this.m_rdbICD10.Checked )
			{

			}
			else
			{

			}
			#endregion

			#region clsTemplate_TargetValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_TargetValue[] objTemplate_Target=null;

			objTemplate_Target=new clsTemplate_TargetValue [1];
			for(int i=0;i<objTemplate_Target.Length  ;i++)
			{
				objTemplate_Target[i]=new clsTemplate_TargetValue ();
				objTemplate_Target[i].m_strActivity_Date =strCurrentDate ;
				objTemplate_Target[i].m_strTemplate_ID =p_strTemplate  ;
				objTemplate_Target[i].m_strControl_ID = p_strControlID ;
				objTemplate_Target[i].m_strForm_ID  = p_strFormID ;
                objTemplate_Target[i].m_strControl_TabIndex = p_strControl_TabIndex;
			}
			#endregion

			#region clsTemplate_Dept_VisibilityValue,刘颖源,2003-5-8 11:11:40
			clsTemplate_Dept_VisibilityValue[] objTemplate_Dept_Visiblity=null;
			m_intVisiable = int.Parse (objTemplate_Detail.m_strVisibility_Level);
			if(objTemplate_Detail.m_strVisibility_Level=="2")
			{
                //此判断在上一层中操作
                //if(this.m_lstDepartment.CheckedItems.Count <=0)
                //{
                //    clsPublicFunction.ShowInformationMessageBox  ("没有选定任何部门使用该模板");
                //    return;
                //}
				 
				objTemplate_Dept_Visiblity=new clsTemplate_Dept_VisibilityValue [this.m_lstDepartment.CheckedItems.Count];
				for(int i1=0;i1<this.m_lstDepartment.CheckedIndices.Count;i1++)
				{
					objTemplate_Dept_Visiblity[i1]=new clsTemplate_Dept_VisibilityValue ();
					objTemplate_Dept_Visiblity[i1].m_strActivity_Date =strCurrentDate ;
					objTemplate_Dept_Visiblity[i1].m_strTemplate_ID =p_strTemplate ;
					objTemplate_Dept_Visiblity[i1].m_strDepartmentID =m_objDepartmentArr[m_lstDepartment.CheckedIndices[i1]].m_strDeptNewID.Trim();
				}

			}
			#endregion
			m_objDomain.lngSaveTemplate (blnInsert,objTemplate ,objTemplate_Detail ,objTemplate_Keyword ,objTemplate_Target ,objTemplate_Dept_Visiblity, out p_strTemplate);
		}
		#endregion

		private void m_rdbPublic_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lstDepartment.Items.Clear (); 
		}

		private void m_rdbDepartment_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0;i<m_objDepartmentArr.Length ;i++)
				this.m_lstDepartment.Items.Add (m_objDepartmentArr[i].m_StrDeptName ); 

		}

		private void m_rdbPrivate_CheckedChanged(object sender, System.EventArgs e)
		{
			this.m_lstDepartment.Items.Clear ();
		}

		private void frmTemplatesetDialog_Load(object sender, System.EventArgs e)
		{
			m_objDepartmentArr= m_objDeptManager.m_objGetAllInDeptArr1();
//			m_intBeginTemplateID=int.Parse (m_objDomain.strGetTemplateID ());
			this.m_rdbDepartment.Checked =true;
			for(int i=0;i<m_objDepartmentArr.Length ;i++)
			{
				if(com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR.Trim() == m_objDepartmentArr[i].m_strDeptNewID )
//				if(clsEMRLogin.LoginInfo.m_strDepartmentID == m_objDepartmentArr[i].m_StrDeptID )
					this.m_lstDepartment.SetItemChecked (i,true);  
			}

            //m_objHighLight.m_mthAddControlInContainer(this);

			m_txtTemplateID.Focus();
		}

		private string m_strTemplateSetFormName = "";
		private Control m_ctlCurrent;
		/// <summary>
		/// 当前控件
		/// </summary>
		public Control m_CtlCurrent
		{
			set
			{
				m_ctlCurrent = value;
			}
		}
		public void mthShowSaveDialog(string p_strFormName,bool p_blnCommonUse)
		{
			mthShowSaveDialog(p_strFormName,null,p_blnCommonUse);
		}
		public void mthShowSaveDialog(string p_strFormName,Form p_frmBase,bool p_blnCommonUse)
		{
			#region 初始化界面
			m_mthClear();		
			
			if(p_blnCommonUse)
			{
				lblOperation.ForeColor = SystemColors.GrayText;
				lblDisease.ForeColor = SystemColors.GrayText;
				m_cboDisease.Enabled = false;
				m_cboOperation.Enabled = false;

				string strTemplateName = "";
				switch(m_ctlCurrent.GetType().FullName)
				{
					case "com.digitalwave.Utility.Controls.ctlRichTextBox":
						strTemplateName = ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_ctlCurrent).SelectionLength > 0 ? ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_ctlCurrent).SelectedText : ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_ctlCurrent).m_strGetRightText();						
						break;
					case "com.digitalwave.controls.ctlRichTextBox":
						strTemplateName = ((com.digitalwave.controls.ctlRichTextBox)m_ctlCurrent).SelectionLength > 0 ? ((com.digitalwave.controls.ctlRichTextBox)m_ctlCurrent).SelectedText : ((com.digitalwave.controls.ctlRichTextBox)m_ctlCurrent).m_strGetRightText();						
						break;
					case "System.Windows.Forms.RichTextBox":
					case "iCare.CustomForm.ctlRichTextBox":
						strTemplateName = ((RichTextBox)m_ctlCurrent).SelectionLength > 0 ? ((RichTextBox)m_ctlCurrent).SelectedText : ((RichTextBox)m_ctlCurrent).Text;
						break;
				}

				if(strTemplateName.Length > 25)
				{
					if(p_frmBase == null)
						clsPublicFunction.ShowInformationMessageBox("注意：模板名称不能超过25个字符！");
					else
						clsPublicFunction.ShowInformationMessageBox("注意：模板名称不能超过25个字符！",p_frmBase);

					m_txtTemplateName.Text = strTemplateName.Substring(0,25);
				}
				else
				{
					m_txtTemplateName.Text = strTemplateName;
				}

				if(m_txtTemplateName.Text=="")
				{
					if(p_frmBase == null)
						clsPublicFunction.ShowInformationMessageBox("该输入框不能生成常用值或者内容为空！");
					else
						clsPublicFunction.ShowInformationMessageBox("该输入框不能生成常用值或者内容为空！",p_frmBase);
					return;
				}
			}
			else
			{
				lblOperation.ForeColor = Color.White;
				lblDisease.ForeColor = Color.White;
				m_cboDisease.Enabled = true;
				m_cboOperation.Enabled = true;
			}
			#endregion

			m_strTemplateSetFormName = p_strFormName;

			if(m_objControlsInForm.Count <=0)
			{
				if(p_frmBase == null)
					clsPublicFunction.ShowInformationMessageBox ("此单中没有任何可用的模板!");
				else
					clsPublicFunction.ShowInformationMessageBox ("此单中没有任何可用的模板!",p_frmBase);
				return;
			}

			object[] objArr = m_objControlsInForm.ToArray ();

			for(int i=0;i<m_objControls.Length ;i++)
			{
				clsControlInfomation obj = new clsControlInfomation();
				obj.objGUI_Info.m_strForm_ID = m_objControls[i].m_strForm_ID ;
				obj.objGUI_Info.m_strControl_ID =m_objControls[i].m_strControl_ID ;
				obj.objGUI_Info.m_strControl_Desc =m_objControls[i].m_strControl_Desc ;
                obj.objGUI_Info.m_strControl_TabIndex = m_objControls[i].m_strControl_TabIndex;
				for(int j=0;j<m_objControlsInForm.Count;j++)
				{
					switch(objArr[j].GetType().FullName)
					{
						case "com.digitalwave.Utility.Controls.ctlRichTextBox":
							if(((com.digitalwave.Utility.Controls.ctlRichTextBox)objArr[j]).Name == m_objControls[i].m_strControl_ID )
							{
								if(p_blnCommonUse)
									obj.strContent = ((com.digitalwave.Utility.Controls.ctlRichTextBox)objArr[j]).SelectionLength > 0 ? ((com.digitalwave.Utility.Controls.ctlRichTextBox)objArr[j]).SelectedText : ((com.digitalwave.Utility.Controls.ctlRichTextBox)objArr[j]).m_strGetRightText();
								else
									obj.strContent = ((com.digitalwave.Utility.Controls.ctlRichTextBox)objArr[j]).m_strGetRightText() ;
							}
							break;
						case "com.digitalwave.controls.ctlRichTextBox":
							if(((com.digitalwave.controls.ctlRichTextBox)objArr[j]).Name == m_objControls[i].m_strControl_ID )
							{
								if(p_blnCommonUse)
									obj.strContent = ((com.digitalwave.controls.ctlRichTextBox)objArr[j]).SelectionLength > 0 ? ((com.digitalwave.controls.ctlRichTextBox)objArr[j]).SelectedText : ((com.digitalwave.controls.ctlRichTextBox)objArr[j]).m_strGetRightText();
								else
									obj.strContent = ((com.digitalwave.controls.ctlRichTextBox)objArr[j]).m_strGetRightText() ;
							}
							break;
						case "System.Windows.Forms.RichTextBox":
						case "iCare.CustomForm.ctlRichTextBox":
							if(((RichTextBox)objArr[j]).Name == m_objControls[i].m_strControl_ID )
							{
								if(p_blnCommonUse)
									obj.strContent = ((RichTextBox)objArr[j]).SelectionLength > 0 ? ((RichTextBox)objArr[j]).SelectedText : ((RichTextBox)objArr[j]).Text;
								else
									obj.strContent = ((RichTextBox)objArr[j]).Text ;
							}
							break;
					}
				}
				if(obj.strContent.Trim() != "")
				{
					if(!p_blnCommonUse)
					{
						m_lstUserDefine.Items.Add(obj,true);
					}
					else if(m_objControls[i].m_strControl_ID.Equals(m_ctlCurrent.Name))
					{
						m_cboKeyword.Text = "常用值--" + obj.objGUI_Info.m_strControl_Desc;
						m_lstUserDefine.Items.Add(obj,true);
					}
					else
						m_lstUserDefine.Items.Add(obj);
				}
			}

			if(m_lstUserDefine.Items.Count <= 0)
			{
				if(p_frmBase == null)
					clsPublicFunction.ShowInformationMessageBox("请输入模板内容！");
				else
					clsPublicFunction.ShowInformationMessageBox("请输入模板内容！",p_frmBase);

				return;
			}
			
			switch(m_intVisiable )
			{
				case 0:
					this.m_rdbPrivate.Enabled =true;
					break;
				case 1:
					this.m_rdbPublic.Enabled =true;
					break;
				default:
					this.m_rdbDepartment.Enabled =true;
					break;
			}

			if(p_frmBase == null)
			{
				this.ShowDialog ();
			}
			else
			{
				this.ShowDialog(p_frmBase);
			}
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}

		private void m_cboDisease_DropDown(object sender, System.EventArgs e)
		{
			m_mthLoadAllAssociate((int)enmAssociate.Disease,m_cboDisease);
		}

		/// <summary>
		/// 查找所有关联字段
		/// </summary>
		private void m_mthLoadAllAssociate(int p_intType,ctlComboBox p_cbo)
		{
			clsTemplateSet_Associate[] m_objArr;
			m_objDomain.m_lngGetAllAssociate(p_intType,out m_objArr);
			if(m_objArr!=null && m_objArr.Length>0)			
			{
				p_cbo.ClearItem();
				p_cbo.AddRangeItems(m_objArr);
			}
		}

		private void m_cboOperation_DropDown(object sender, System.EventArgs e)
		{
			m_mthLoadAllAssociate((int)enmAssociate.Operation,m_cboOperation);
		}

		private void m_txtTemplateName_TextChanged(object sender, System.EventArgs e)
		{
			m_txtKeyword.Text = m_txtTemplateName.Text;
		}

		private void m_cmdAll_Click(object sender, System.EventArgs e)
		{
			for(int i = 0; i < m_lstUserDefine.Items.Count; i++)
				m_lstUserDefine.SetItemChecked(i,true);
		}

		private void m_cmdClear_Click(object sender, System.EventArgs e)
		{
			for(int i = 0; i < m_lstUserDefine.Items.Count; i++)
				m_lstUserDefine.SetItemChecked(i,false);
		}

		private void m_cboKeyword_DropDown(object sender, System.EventArgs e)
		{
			m_cboKeyword.ClearItem();

			DataTable dtKeywords = new DataTable();
			long lngRes = m_objDomain.m_lngGetKeywordsByForm(m_strTemplateSetFormName,out dtKeywords);
			if(lngRes > 0 && dtKeywords != null && dtKeywords.Rows.Count > 0)
			{
				for(int i = 0; i < dtKeywords.Rows.Count; i++)
					m_cboKeyword.AddItem(dtKeywords.Rows[i][0]);
			}
		}

		/// <summary>
		/// 清空界面
		/// </summary>
		private void m_mthClear()
		{
			m_txtTemplateName.Clear();
			m_cboKeyword.Text = "";
			m_cboDisease.Text = "";
			m_cboOperation.Text = "";
			m_lstUserDefine.Items.Clear();

			m_txtTemplateID.Focus();
		}

		private void m_cmdDel_Click(object sender, System.EventArgs e)
		{
			if(m_lsvDisease.SelectedItems!=null)
			{
				foreach(ListViewItem livTemp in m_lsvDisease.SelectedItems)
				{
					m_lsvDisease.SelectedItems[0].Remove();
				}
			}
		}
		
		private void m_mthSaveICD10_TemplateSet(ListView p_lsvTemp,string p_strTemplateSetID)
		{
			m_objDomain.m_lngSaveICD10_TemplateSet(p_lsvTemp,p_strTemplateSetID);
		}

	}
	public class clsControlInfomation
	{
		public clsGUI_Info_DetailValue objGUI_Info=new clsGUI_Info_DetailValue();
		public string strContent = "";
		public override string ToString()
		{
			return objGUI_Info.m_strControl_Desc;
		}
	};
}
