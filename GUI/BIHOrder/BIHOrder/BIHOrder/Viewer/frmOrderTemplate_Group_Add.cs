using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.BIHOrder
{

	/// <summary>
	/// frmOrderTemplate_Group_Add 
	/// </summary>
	public class frmOrderTemplate_Group_Add  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.TextBox txt_createDate;
		internal System.Windows.Forms.TextBox txt_creator;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox m_txtDES_VCHR;
		private System.Windows.Forms.Label label4;
		internal System.Windows.Forms.CheckBox m_chkISSAMERECIPENO_INT;
		internal System.Windows.Forms.TextBox m_txtNAME_CHR;
		internal System.Windows.Forms.ComboBox m_txtSHARETYPE_INT;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox m_txtPYCODE_CHR;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox m_txtWBCODE_CHR;
		private System.Windows.Forms.Label label7;
		public PinkieControls.ButtonXP cmdSave;
		private PinkieControls.ButtonXP cmdClose;
        private System.Windows.Forms.Panel panel1;
        private Panel panel2;
        public DataGridView m_dtvOrderGroup;
        private Panel panel3;
        internal RadioButton m_rdoYes;
        internal RadioButton m_rdoNO;
        internal TextBox m_txtUSERCODE_VCHR;
        private Label label1;
        internal GroupBox m_plDept;
        internal com.digitalwave.controls.ctlFindTextBox m_txtArea;
        internal ListView m_listDept;
        private ColumnHeader columnHeader9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private DataGridViewCheckBoxColumn dtv_Check;
        private DataGridViewTextBoxColumn dtv_ExecuteType;
        private DataGridViewTextBoxColumn m_dtPOSTDATE_DAT;
        private DataGridViewTextBoxColumn CREATOR_CHR;
        private DataGridViewTextBoxColumn ASSESSORFOREXEC_CHR;
        private DataGridViewTextBoxColumn dtv_RecipeNo;
        private DataGridViewTextBoxColumn dtv_Name;
        private DataGridViewTextBoxColumn dtv_Dosage;
        private DataGridViewTextBoxColumn dtv_UseType;
        private DataGridViewTextBoxColumn dtv_Freq;
        private DataGridViewTextBoxColumn dtv_REMARK;
        private DataGridViewTextBoxColumn dtv_FinishDate;
        private DataGridViewTextBoxColumn dtv_Stoper;
        private DataGridViewTextBoxColumn ASSESSORFORSTOP_CHR;
        private DataGridViewTextBoxColumn ATTACHTIMES_INT;
        private DataGridViewTextBoxColumn STATUS_INT;
        private DataGridViewTextBoxColumn RATETYPE_INT;
        private DataGridViewTextBoxColumn MedicareTypeName;
        private DataGridViewTextBoxColumn dtv_Get;
        private DataGridViewTextBoxColumn dtv_Sum;
        private DataGridViewTextBoxColumn dtv_StartDate;
        private DataGridViewTextBoxColumn dtv_Executor;
        private DataGridViewTextBoxColumn dtv_DELETE_DAT;
        private DataGridViewTextBoxColumn dtv_DELETERNAME_VCHR;
        private DataGridViewTextBoxColumn viewname_vchr;
        private DataGridViewTextBoxColumn dtv_method;
        private DataGridViewTextBoxColumn dtv_NO;
        private DataGridViewTextBoxColumn dtv_OUTGETMEDDAYS_INT;
        private DataGridViewTextBoxColumn dtv_CREATEAREA_Name;
        private DataGridViewTextBoxColumn dtv_DOCTOR_VCHR;
        private DataGridViewTextBoxColumn CREATEDATE_DAT;
        private DataGridViewTextBoxColumn dtv_ChangedID;
        private DataGridViewTextBoxColumn dtv_ChangedDate;
        private DataGridViewTextBoxColumn m_dtStartDate;
        /// <summary>
        /// 医嘱类型列表
        /// </summary>
        public Hashtable m_htOrderCate = new Hashtable();
        /// <summary>
        /// 住院基本配置表VO
        /// </summary>
        public clsSPECORDERCATE m_objSpecateVo;

		public frmOrderTemplate_Group_Add()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			// group_add=new clsCtl_OrderTemplate_Group_Add();
			 ((clsCtl_OrderTemplate_Group_Add)this.objController).m_LoadOrderGroupDetail();
			

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

        public frmOrderTemplate_Group_Add(clsBIHOrder[] m_arrObjOrder, Hashtable OrderCate, clsSPECORDERCATE SpecateVo)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            m_htOrderCate = OrderCate;
            m_objSpecateVo = SpecateVo;
            // group_add=new clsCtl_OrderTemplate_Group_Add();
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_LoadOrderDetail(m_arrObjOrder);
            m_mthRefreshSameReqNoColor();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_OrderTemplate_Group_Add();
			objController.Set_GUI_Apperance(this);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_createDate = new System.Windows.Forms.TextBox();
            this.txt_creator = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtDES_VCHR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkISSAMERECIPENO_INT = new System.Windows.Forms.CheckBox();
            this.m_txtNAME_CHR = new System.Windows.Forms.TextBox();
            this.m_txtSHARETYPE_INT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtPYCODE_CHR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtWBCODE_CHR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdSave = new PinkieControls.ButtonXP();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_plDept = new System.Windows.Forms.GroupBox();
            this.m_txtArea = new com.digitalwave.controls.ctlFindTextBox();
            this.m_listDept = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.m_txtUSERCODE_VCHR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_rdoNO = new System.Windows.Forms.RadioButton();
            this.m_rdoYes = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_dtvOrderGroup = new System.Windows.Forms.DataGridView();
            this.dtv_Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtv_ExecuteType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtPOSTDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATOR_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASSESSORFOREXEC_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_RecipeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_UseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_REMARK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_FinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Stoper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ASSESSORFORSTOP_CHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ATTACHTIMES_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RATETYPE_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicareTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Get = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DELETE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DELETERNAME_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewname_vchr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_OUTGETMEDDAYS_INT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_CREATEAREA_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_DOCTOR_VCHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATEDATE_DAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ChangedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtv_ChangedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dtStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.m_plDept.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_createDate
            // 
            this.txt_createDate.Location = new System.Drawing.Point(317, 75);
            this.txt_createDate.Name = "txt_createDate";
            this.txt_createDate.ReadOnly = true;
            this.txt_createDate.Size = new System.Drawing.Size(110, 23);
            this.txt_createDate.TabIndex = 67;
            this.txt_createDate.Visible = false;
            // 
            // txt_creator
            // 
            this.txt_creator.Location = new System.Drawing.Point(94, 75);
            this.txt_creator.Name = "txt_creator";
            this.txt_creator.ReadOnly = true;
            this.txt_creator.Size = new System.Drawing.Size(10, 23);
            this.txt_creator.TabIndex = 66;
            this.txt_creator.Visible = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(247, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 20);
            this.label11.TabIndex = 65;
            this.label11.Text = "创建时间：";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(22, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 21);
            this.label10.TabIndex = 64;
            this.label10.Text = "创建人：";
            this.label10.Visible = false;
            // 
            // m_txtDES_VCHR
            // 
            this.m_txtDES_VCHR.Location = new System.Drawing.Point(88, 74);
            this.m_txtDES_VCHR.MaxLength = 50;
            this.m_txtDES_VCHR.Multiline = true;
            this.m_txtDES_VCHR.Name = "m_txtDES_VCHR";
            this.m_txtDES_VCHR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtDES_VCHR.Size = new System.Drawing.Size(466, 74);
            this.m_txtDES_VCHR.TabIndex = 5;
            this.m_txtDES_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDES_VCHR_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(22, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 60;
            this.label4.Text = "描述";
            // 
            // m_chkISSAMERECIPENO_INT
            // 
            this.m_chkISSAMERECIPENO_INT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_chkISSAMERECIPENO_INT.Enabled = false;
            this.m_chkISSAMERECIPENO_INT.Location = new System.Drawing.Point(706, 129);
            this.m_chkISSAMERECIPENO_INT.Name = "m_chkISSAMERECIPENO_INT";
            this.m_chkISSAMERECIPENO_INT.Size = new System.Drawing.Size(67, 23);
            this.m_chkISSAMERECIPENO_INT.TabIndex = 57;
            this.m_chkISSAMERECIPENO_INT.Text = "同方号";
            this.m_chkISSAMERECIPENO_INT.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.m_chkISSAMERECIPENO_INT.Visible = false;
            // 
            // m_txtNAME_CHR
            // 
            this.m_txtNAME_CHR.Location = new System.Drawing.Point(88, 12);
            this.m_txtNAME_CHR.MaxLength = 50;
            this.m_txtNAME_CHR.Name = "m_txtNAME_CHR";
            this.m_txtNAME_CHR.Size = new System.Drawing.Size(235, 23);
            this.m_txtNAME_CHR.TabIndex = 1;
            this.m_txtNAME_CHR.Leave += new System.EventHandler(this.m_txtNAME_CHR_Leave);
            this.m_txtNAME_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtNAME_CHR_KeyDown);
            // 
            // m_txtSHARETYPE_INT
            // 
            this.m_txtSHARETYPE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_txtSHARETYPE_INT.Items.AddRange(new object[] {
            "私用",
            "公用",
            "科室"});
            this.m_txtSHARETYPE_INT.Location = new System.Drawing.Point(444, 11);
            this.m_txtSHARETYPE_INT.Name = "m_txtSHARETYPE_INT";
            this.m_txtSHARETYPE_INT.Size = new System.Drawing.Size(110, 22);
            this.m_txtSHARETYPE_INT.TabIndex = 2;
            this.m_txtSHARETYPE_INT.SelectedIndexChanged += new System.EventHandler(this.m_txtSHARETYPE_INT_SelectedIndexChanged);
            this.m_txtSHARETYPE_INT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSHARETYPE_INT_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(19, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 63;
            this.label5.Text = "组套名称";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(351, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 62;
            this.label9.Text = "共享类型";
            // 
            // m_txtPYCODE_CHR
            // 
            this.m_txtPYCODE_CHR.Enabled = false;
            this.m_txtPYCODE_CHR.Location = new System.Drawing.Point(298, 43);
            this.m_txtPYCODE_CHR.MaxLength = 15;
            this.m_txtPYCODE_CHR.Name = "m_txtPYCODE_CHR";
            this.m_txtPYCODE_CHR.ReadOnly = true;
            this.m_txtPYCODE_CHR.Size = new System.Drawing.Size(90, 23);
            this.m_txtPYCODE_CHR.TabIndex = 4;
            this.m_txtPYCODE_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPYCODE_CHR_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label12.Location = new System.Drawing.Point(230, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 61;
            this.label12.Text = "拼音码";
            // 
            // m_txtWBCODE_CHR
            // 
            this.m_txtWBCODE_CHR.Enabled = false;
            this.m_txtWBCODE_CHR.Location = new System.Drawing.Point(460, 41);
            this.m_txtWBCODE_CHR.MaxLength = 15;
            this.m_txtWBCODE_CHR.Name = "m_txtWBCODE_CHR";
            this.m_txtWBCODE_CHR.ReadOnly = true;
            this.m_txtWBCODE_CHR.Size = new System.Drawing.Size(96, 23);
            this.m_txtWBCODE_CHR.TabIndex = 3;
            this.m_txtWBCODE_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtWBCODE_CHR_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(397, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 59;
            this.label7.Text = "五笔码";
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdSave.DefaultScheme = true;
            this.cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSave.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdSave.Hint = "";
            this.cmdSave.Location = new System.Drawing.Point(705, 19);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSave.Size = new System.Drawing.Size(99, 37);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "保存(F4)";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Font = new System.Drawing.Font("宋体", 10.5F);
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(705, 75);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(99, 38);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "退出(ESC)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_plDept);
            this.panel1.Controls.Add(this.m_txtUSERCODE_VCHR);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtDES_VCHR);
            this.panel1.Controls.Add(this.txt_createDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_chkISSAMERECIPENO_INT);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_creator);
            this.panel1.Controls.Add(this.cmdClose);
            this.panel1.Controls.Add(this.cmdSave);
            this.panel1.Controls.Add(this.m_txtWBCODE_CHR);
            this.panel1.Controls.Add(this.m_txtSHARETYPE_INT);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.m_txtNAME_CHR);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.m_txtPYCODE_CHR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 179);
            this.panel1.TabIndex = 102;
            // 
            // m_plDept
            // 
            this.m_plDept.Controls.Add(this.m_txtArea);
            this.m_plDept.Controls.Add(this.m_listDept);
            this.m_plDept.Location = new System.Drawing.Point(562, 3);
            this.m_plDept.Name = "m_plDept";
            this.m_plDept.Size = new System.Drawing.Size(137, 146);
            this.m_plDept.TabIndex = 74;
            this.m_plDept.TabStop = false;
            // 
            // m_txtArea
            // 
            this.m_txtArea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtArea.Location = new System.Drawing.Point(1, 9);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.Size = new System.Drawing.Size(127, 23);
            this.m_txtArea.TabIndex = 71;
            this.m_txtArea.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
            this.m_txtArea.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
            this.m_txtArea.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
            // 
            // m_listDept
            // 
            this.m_listDept.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.m_listDept.GridLines = true;
            this.m_listDept.Location = new System.Drawing.Point(2, 35);
            this.m_listDept.Name = "m_listDept";
            this.m_listDept.Size = new System.Drawing.Size(126, 109);
            this.m_listDept.TabIndex = 73;
            this.m_listDept.UseCompatibleStateImageBehavior = false;
            this.m_listDept.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "科室名称";
            this.columnHeader9.Width = 103;
            // 
            // m_txtUSERCODE_VCHR
            // 
            this.m_txtUSERCODE_VCHR.Location = new System.Drawing.Point(88, 45);
            this.m_txtUSERCODE_VCHR.MaxLength = 15;
            this.m_txtUSERCODE_VCHR.Name = "m_txtUSERCODE_VCHR";
            this.m_txtUSERCODE_VCHR.Size = new System.Drawing.Size(124, 23);
            this.m_txtUSERCODE_VCHR.TabIndex = 3;
            this.m_txtUSERCODE_VCHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtUSERCODE_VCHR_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(22, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 70;
            this.label1.Text = "助记码";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_rdoNO);
            this.panel3.Controls.Add(this.m_rdoYes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 396);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(892, 29);
            this.panel3.TabIndex = 68;
            // 
            // m_rdoNO
            // 
            this.m_rdoNO.AutoSize = true;
            this.m_rdoNO.Location = new System.Drawing.Point(133, 7);
            this.m_rdoNO.Name = "m_rdoNO";
            this.m_rdoNO.Size = new System.Drawing.Size(53, 18);
            this.m_rdoNO.TabIndex = 1;
            this.m_rdoNO.Text = "反选";
            this.m_rdoNO.UseVisualStyleBackColor = true;
            this.m_rdoNO.CheckedChanged += new System.EventHandler(this.m_rdoNO_CheckedChanged);
            // 
            // m_rdoYes
            // 
            this.m_rdoYes.AutoSize = true;
            this.m_rdoYes.Checked = true;
            this.m_rdoYes.Location = new System.Drawing.Point(39, 7);
            this.m_rdoYes.Name = "m_rdoYes";
            this.m_rdoYes.Size = new System.Drawing.Size(53, 18);
            this.m_rdoYes.TabIndex = 0;
            this.m_rdoYes.TabStop = true;
            this.m_rdoYes.Text = "全选";
            this.m_rdoYes.UseVisualStyleBackColor = true;
            this.m_rdoYes.CheckedChanged += new System.EventHandler(this.m_rdoNO_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_dtvOrderGroup);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 425);
            this.panel2.TabIndex = 103;
            // 
            // m_dtvOrderGroup
            // 
            this.m_dtvOrderGroup.AllowUserToAddRows = false;
            this.m_dtvOrderGroup.BackgroundColor = System.Drawing.Color.White;
            this.m_dtvOrderGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtvOrderGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtv_Check,
            this.dtv_ExecuteType,
            this.m_dtPOSTDATE_DAT,
            this.CREATOR_CHR,
            this.ASSESSORFOREXEC_CHR,
            this.dtv_RecipeNo,
            this.dtv_Name,
            this.dtv_Dosage,
            this.dtv_UseType,
            this.dtv_Freq,
            this.dtv_REMARK,
            this.dtv_FinishDate,
            this.dtv_Stoper,
            this.ASSESSORFORSTOP_CHR,
            this.ATTACHTIMES_INT,
            this.STATUS_INT,
            this.RATETYPE_INT,
            this.MedicareTypeName,
            this.dtv_Get,
            this.dtv_Sum,
            this.dtv_StartDate,
            this.dtv_Executor,
            this.dtv_DELETE_DAT,
            this.dtv_DELETERNAME_VCHR,
            this.viewname_vchr,
            this.dtv_method,
            this.dtv_NO,
            this.dtv_OUTGETMEDDAYS_INT,
            this.dtv_CREATEAREA_Name,
            this.dtv_DOCTOR_VCHR,
            this.CREATEDATE_DAT,
            this.dtv_ChangedID,
            this.dtv_ChangedDate,
            this.m_dtStartDate});
            this.m_dtvOrderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtvOrderGroup.Location = new System.Drawing.Point(0, 0);
            this.m_dtvOrderGroup.MultiSelect = false;
            this.m_dtvOrderGroup.Name = "m_dtvOrderGroup";
            this.m_dtvOrderGroup.ReadOnly = true;
            this.m_dtvOrderGroup.RowHeadersVisible = false;
            this.m_dtvOrderGroup.RowTemplate.Height = 28;
            this.m_dtvOrderGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dtvOrderGroup.Size = new System.Drawing.Size(892, 396);
            this.m_dtvOrderGroup.TabIndex = 44;
            this.m_dtvOrderGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtvOrderGroup_CellClick);
            // 
            // dtv_Check
            // 
            this.dtv_Check.FalseValue = "0";
            this.dtv_Check.HeaderText = "";
            this.dtv_Check.Name = "dtv_Check";
            this.dtv_Check.ReadOnly = true;
            this.dtv_Check.TrueValue = "1";
            this.dtv_Check.Width = 30;
            // 
            // dtv_ExecuteType
            // 
            this.dtv_ExecuteType.HeaderText = "类型";
            this.dtv_ExecuteType.Name = "dtv_ExecuteType";
            this.dtv_ExecuteType.ReadOnly = true;
            this.dtv_ExecuteType.Width = 60;
            // 
            // m_dtPOSTDATE_DAT
            // 
            this.m_dtPOSTDATE_DAT.HeaderText = "下嘱时间";
            this.m_dtPOSTDATE_DAT.Name = "m_dtPOSTDATE_DAT";
            this.m_dtPOSTDATE_DAT.ReadOnly = true;
            // 
            // CREATOR_CHR
            // 
            this.CREATOR_CHR.HeaderText = "开嘱者";
            this.CREATOR_CHR.Name = "CREATOR_CHR";
            this.CREATOR_CHR.ReadOnly = true;
            this.CREATOR_CHR.Width = 80;
            // 
            // ASSESSORFOREXEC_CHR
            // 
            this.ASSESSORFOREXEC_CHR.HeaderText = "过嘱者";
            this.ASSESSORFOREXEC_CHR.Name = "ASSESSORFOREXEC_CHR";
            this.ASSESSORFOREXEC_CHR.ReadOnly = true;
            this.ASSESSORFOREXEC_CHR.Width = 80;
            // 
            // dtv_RecipeNo
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtv_RecipeNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtv_RecipeNo.HeaderText = "方";
            this.dtv_RecipeNo.Name = "dtv_RecipeNo";
            this.dtv_RecipeNo.ReadOnly = true;
            this.dtv_RecipeNo.Width = 40;
            // 
            // dtv_Name
            // 
            this.dtv_Name.HeaderText = "医嘱内容";
            this.dtv_Name.Name = "dtv_Name";
            this.dtv_Name.ReadOnly = true;
            this.dtv_Name.Width = 350;
            // 
            // dtv_Dosage
            // 
            this.dtv_Dosage.HeaderText = "用量";
            this.dtv_Dosage.Name = "dtv_Dosage";
            this.dtv_Dosage.ReadOnly = true;
            this.dtv_Dosage.Visible = false;
            this.dtv_Dosage.Width = 60;
            // 
            // dtv_UseType
            // 
            this.dtv_UseType.HeaderText = "用法";
            this.dtv_UseType.Name = "dtv_UseType";
            this.dtv_UseType.ReadOnly = true;
            this.dtv_UseType.Visible = false;
            this.dtv_UseType.Width = 60;
            // 
            // dtv_Freq
            // 
            this.dtv_Freq.HeaderText = "频率";
            this.dtv_Freq.Name = "dtv_Freq";
            this.dtv_Freq.ReadOnly = true;
            this.dtv_Freq.Visible = false;
            this.dtv_Freq.Width = 60;
            // 
            // dtv_REMARK
            // 
            this.dtv_REMARK.HeaderText = "说明";
            this.dtv_REMARK.Name = "dtv_REMARK";
            this.dtv_REMARK.ReadOnly = true;
            // 
            // dtv_FinishDate
            // 
            this.dtv_FinishDate.HeaderText = "停嘱时间";
            this.dtv_FinishDate.Name = "dtv_FinishDate";
            this.dtv_FinishDate.ReadOnly = true;
            // 
            // dtv_Stoper
            // 
            this.dtv_Stoper.HeaderText = "停嘱者";
            this.dtv_Stoper.Name = "dtv_Stoper";
            this.dtv_Stoper.ReadOnly = true;
            this.dtv_Stoper.Width = 80;
            // 
            // ASSESSORFORSTOP_CHR
            // 
            this.ASSESSORFORSTOP_CHR.HeaderText = "过嘱者";
            this.ASSESSORFORSTOP_CHR.Name = "ASSESSORFORSTOP_CHR";
            this.ASSESSORFORSTOP_CHR.ReadOnly = true;
            // 
            // ATTACHTIMES_INT
            // 
            this.ATTACHTIMES_INT.HeaderText = "补次";
            this.ATTACHTIMES_INT.Name = "ATTACHTIMES_INT";
            this.ATTACHTIMES_INT.ReadOnly = true;
            this.ATTACHTIMES_INT.Width = 60;
            // 
            // STATUS_INT
            // 
            this.STATUS_INT.HeaderText = "医嘱状态";
            this.STATUS_INT.Name = "STATUS_INT";
            this.STATUS_INT.ReadOnly = true;
            // 
            // RATETYPE_INT
            // 
            this.RATETYPE_INT.HeaderText = "自备药";
            this.RATETYPE_INT.Name = "RATETYPE_INT";
            this.RATETYPE_INT.ReadOnly = true;
            this.RATETYPE_INT.Width = 80;
            // 
            // MedicareTypeName
            // 
            this.MedicareTypeName.HeaderText = "医保分类";
            this.MedicareTypeName.Name = "MedicareTypeName";
            this.MedicareTypeName.ReadOnly = true;
            // 
            // dtv_Get
            // 
            this.dtv_Get.HeaderText = "数量";
            this.dtv_Get.Name = "dtv_Get";
            this.dtv_Get.ReadOnly = true;
            this.dtv_Get.Width = 60;
            // 
            // dtv_Sum
            // 
            this.dtv_Sum.HeaderText = "总量";
            this.dtv_Sum.Name = "dtv_Sum";
            this.dtv_Sum.ReadOnly = true;
            this.dtv_Sum.Width = 80;
            // 
            // dtv_StartDate
            // 
            this.dtv_StartDate.HeaderText = "执行时间";
            this.dtv_StartDate.Name = "dtv_StartDate";
            this.dtv_StartDate.ReadOnly = true;
            this.dtv_StartDate.Visible = false;
            this.dtv_StartDate.Width = 120;
            // 
            // dtv_Executor
            // 
            this.dtv_Executor.HeaderText = "执行人";
            this.dtv_Executor.Name = "dtv_Executor";
            this.dtv_Executor.ReadOnly = true;
            // 
            // dtv_DELETE_DAT
            // 
            this.dtv_DELETE_DAT.HeaderText = "作废时间";
            this.dtv_DELETE_DAT.Name = "dtv_DELETE_DAT";
            this.dtv_DELETE_DAT.ReadOnly = true;
            // 
            // dtv_DELETERNAME_VCHR
            // 
            this.dtv_DELETERNAME_VCHR.HeaderText = "作废人";
            this.dtv_DELETERNAME_VCHR.Name = "dtv_DELETERNAME_VCHR";
            this.dtv_DELETERNAME_VCHR.ReadOnly = true;
            // 
            // viewname_vchr
            // 
            this.viewname_vchr.HeaderText = "类别";
            this.viewname_vchr.Name = "viewname_vchr";
            this.viewname_vchr.ReadOnly = true;
            this.viewname_vchr.Visible = false;
            this.viewname_vchr.Width = 60;
            // 
            // dtv_method
            // 
            this.dtv_method.HeaderText = "方法";
            this.dtv_method.Name = "dtv_method";
            this.dtv_method.ReadOnly = true;
            this.dtv_method.Width = 60;
            // 
            // dtv_NO
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtv_NO.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtv_NO.HeaderText = "序号";
            this.dtv_NO.Name = "dtv_NO";
            this.dtv_NO.ReadOnly = true;
            this.dtv_NO.Width = 60;
            // 
            // dtv_OUTGETMEDDAYS_INT
            // 
            this.dtv_OUTGETMEDDAYS_INT.HeaderText = "天数";
            this.dtv_OUTGETMEDDAYS_INT.Name = "dtv_OUTGETMEDDAYS_INT";
            this.dtv_OUTGETMEDDAYS_INT.ReadOnly = true;
            // 
            // dtv_CREATEAREA_Name
            // 
            this.dtv_CREATEAREA_Name.HeaderText = "开单科室";
            this.dtv_CREATEAREA_Name.Name = "dtv_CREATEAREA_Name";
            this.dtv_CREATEAREA_Name.ReadOnly = true;
            // 
            // dtv_DOCTOR_VCHR
            // 
            this.dtv_DOCTOR_VCHR.HeaderText = "医生名称 ";
            this.dtv_DOCTOR_VCHR.Name = "dtv_DOCTOR_VCHR";
            this.dtv_DOCTOR_VCHR.ReadOnly = true;
            this.dtv_DOCTOR_VCHR.Visible = false;
            // 
            // CREATEDATE_DAT
            // 
            this.CREATEDATE_DAT.HeaderText = "录入时间";
            this.CREATEDATE_DAT.Name = "CREATEDATE_DAT";
            this.CREATEDATE_DAT.ReadOnly = true;
            this.CREATEDATE_DAT.Width = 120;
            // 
            // dtv_ChangedID
            // 
            this.dtv_ChangedID.HeaderText = "修改人";
            this.dtv_ChangedID.Name = "dtv_ChangedID";
            this.dtv_ChangedID.ReadOnly = true;
            // 
            // dtv_ChangedDate
            // 
            this.dtv_ChangedDate.HeaderText = "修改时间";
            this.dtv_ChangedDate.Name = "dtv_ChangedDate";
            this.dtv_ChangedDate.ReadOnly = true;
            // 
            // m_dtStartDate
            // 
            this.m_dtStartDate.HeaderText = "下嘱时间";
            this.m_dtStartDate.Name = "m_dtStartDate";
            this.m_dtStartDate.ReadOnly = true;
            this.m_dtStartDate.Visible = false;
            // 
            // frmOrderTemplate_Group_Add
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(892, 604);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmOrderTemplate_Group_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加组套";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderTemplate_Group_Add_KeyDown);
            this.Load += new System.EventHandler(this.frmOrderTemplate_Group_Add_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_plDept.ResumeLayout(false);
            this.m_plDept.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtvOrderGroup)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmdSave_Click(object sender, System.EventArgs e)
		{

			this.Cursor =Cursors.WaitCursor;
			
		    ((clsCtl_OrderTemplate_Group_Add)this.objController).m_SaveTheNew();
			this.Cursor =Cursors.Default;
			
		}

		private void frmOrderTemplate_Group_Add_Load(object sender, System.EventArgs e)
		{
			((clsCtl_OrderTemplate_Group_Add)this.objController).m_strOperatorID =this.LoginInfo.m_strEmpID;	
			((clsCtl_OrderTemplate_Group_Add)this.objController).m_strOperatorName =this.LoginInfo.m_strEmpName;
            m_txtSHARETYPE_INT.SelectedIndex = 0;
			/*初始化医嘱组套成员表  目的是得到一个空表*/
			
			/*-----------------------*/
			/*完成医嘱记录中相关字段向组套成员表字段的赋值*/
            ((clsCtl_OrderTemplate_Group_Add)this.objController).GetTheSystemRole();
            ((clsCtl_OrderTemplate_Group_Add)this.objController).EnableSaveBtn();
			
		
			
		}

       

		public void BIHOrderToOrderGroup(clsBIHOrder objItem,bool ifParent,bool blnSame)
		{
              ((clsCtl_OrderTemplate_Group_Add)this.objController).m_InitValueOrderGroupDetail(objItem,ifParent,blnSame);
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_txtNAME_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			    SendKeys.Send("{tab}");
		}

		private void m_txtSHARETYPE_INT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			    SendKeys.Send("{tab}");
		}

		

		private void m_txtPYCODE_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{tab}");
		}

		private void m_txtWBCODE_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{tab}");
		}

		private void m_txtDES_VCHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				SendKeys.Send("{tab}");
		}

        private void m_txtNAME_CHR_Leave(object sender, EventArgs e)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_lngGetpywb();
           
        }

       

        private void m_rdoNO_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_SelectChange();
        }

        private void m_dtvOrderGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_SelectItemexChange(e.RowIndex,e.ColumnIndex);
            ((clsCtl_OrderTemplate_Group_Add)this.objController).EnableSaveBtn();
        }

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion

        private void m_txtSHARETYPE_INT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_OrderTemplate_Group_Add)this.objController).m_lngSHARETYPEChange();
        }

        private void m_txtUSERCODE_VCHR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void frmOrderTemplate_Group_Add_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    if (cmdSave.Enabled)
                    {
                        cmdSave_Click(null, null);
                    }
                    break;
                case Keys.Escape:
                    cmdClose_Click(null, null);
                    break;
            }
        }


        /// <summary>
        /// 刷新同方医嘱的方号颜色并隐藏相同性质的字段
        /// </summary>
        public void m_mthRefreshSameReqNoColor()
        {
            for (int i = 1; i < this.m_dtvOrderGroup.Rows.Count; i++)
            {
                clsBIHOrder order = (clsBIHOrder)m_dtvOrderGroup.Rows[i - 1].Tag;
                DataGridViewRow objRow = m_dtvOrderGroup.Rows[i];

                if (order.m_intRecipenNo == ((clsBIHOrder)m_dtvOrderGroup.Rows[i].Tag).m_intRecipenNo)
                {
                    //m_dtvOrderGroup.Rows[i - 1].Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //objRow.Cells["dtv_RecipeNo"].Style.ForeColor = Color.SkyBlue;
                    //隐藏的字段
                    //方号dtv_RecipeNo
                    objRow.Cells["dtv_RecipeNo"].Value = "";
                    //类型dtv_ExecuteType
                    objRow.Cells["dtv_ExecuteType"].Value = "";
                    //下嘱时间m_dtStartDate
                    //objRow.Cells["m_dtStartDate"].Value = "";
                    objRow.Cells["m_dtPOSTDATE_DAT"].Value = "";
                    //开医嘱者CREATOR_CHR
                    objRow.Cells["CREATOR_CHR"].Value = "";
                    //过医嘱者ASSESSORFOREXEC_CHR
                    objRow.Cells["ASSESSORFOREXEC_CHR"].Value = "";
                    //用法dtv_UseType
                    objRow.Cells["dtv_UseType"].Value = "";
                    // 频率dtv_Freq
                    objRow.Cells["dtv_Freq"].Value = "";
                    //说明dtv_ENTRUST
                    //objRow.Cells["dtv_ENTRUST"].Value = "";
                    //停嘱时间dtv_FinishDate
                    objRow.Cells["dtv_FinishDate"].Value = "";
                    //停医嘱者dtv_Stoper
                    objRow.Cells["dtv_Stoper"].Value = "";
                    //过医嘱者 
                    //objRow.Cells[""].Value = "";
                    //补次ATTACHTIMES_INT
                    objRow.Cells["ATTACHTIMES_INT"].Value = "";
                    //医嘱状态STATUS_INT
                    objRow.Cells["STATUS_INT"].Value = "";
                    //执行时间dtv_StartDate
                    objRow.Cells["dtv_StartDate"].Value = "";

                    //执行人dtv_Executor
                    objRow.Cells["dtv_Executor"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废时间dtv_DELETE_DAT
                    objRow.Cells["dtv_DELETE_DAT"].Value = "";
                    //作废人dtv_DELETERNAME_VCHR
                    objRow.Cells["dtv_DELETERNAME_VCHR"].Value = "";

                    /*<=================================*/
                    //皮试
                    string m_strFeel = "";
                    if (((clsBIHOrder)objRow.Tag).m_intISNEEDFEEL == 1)
                    {

                        switch (((clsBIHOrder)objRow.Tag).m_intFEEL_INT)
                        {
                            case 0:
                                m_strFeel = " AST( ) ";
                                break;
                            case 1:
                                m_strFeel = " AST(-) ";
                                break;
                            case 2:
                                m_strFeel = " AST(+) ";
                                break;
                        }

                    }
                    //名称  同一方号的医嘱，子医嘱的用法与频率不用显示
                    objRow.Cells["dtv_Name"].Value = ((clsBIHOrder)objRow.Tag).m_strName + " " + objRow.Cells["dtv_Dosage"].Value.ToString() + "  " + m_strFeel;

                }

                //已停或正在停的医嘱,已执行过的临嘱用红色显示(包括执行出院带药)

                if (order.m_intStatus == 3 || order.m_intStatus == 6 || (order.m_intExecuteType == 2 && order.m_intStatus == 2) || (order.m_intExecuteType == 3 && order.m_intStatus == 2))
                {
                    m_dtvOrderGroup.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Red;
                }

            }
            //已停或正在停的医嘱,已执行过的临嘱用红色显示(最后一条的处理)
            if (m_dtvOrderGroup.RowCount > 0)
            {
                clsBIHOrder order2 = (clsBIHOrder)m_dtvOrderGroup.Rows[m_dtvOrderGroup.RowCount - 1].Tag;
                if (order2.m_intStatus == 3 || order2.m_intStatus == 6 || (order2.m_intExecuteType == 2 && order2.m_intStatus == 2) || (order2.m_intExecuteType == 3 && order2.m_intStatus == 2))
                {
                    m_dtvOrderGroup.Rows[m_dtvOrderGroup.RowCount - 1].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

        }

		
		
	}
}
