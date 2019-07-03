using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// UI层：	用法项目编辑	
	/// 作者：	徐斌辉	
	/// 时间：	2005-04-06
	/// </summary>
	public class frmUsaEdit : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件、变量申明
		private System.Windows.Forms.Label label18;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdSaveAdd;
		internal PinkieControls.ButtonXP m_cmdDel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private PinkieControls.ButtonXP cmdClose;
		internal com.digitalwave.controls.ctlFindTextBox m_txtItem;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox m_txtCLINICQTY;
		internal System.Windows.Forms.TextBox m_txtBIHQTY;
		internal System.Windows.Forms.TextBox m_txtBIHOTALPRICE;
		internal System.Windows.Forms.TextBox m_txtCLINICTOTALPRICE;
		internal System.Windows.Forms.TextBox m_txtItemSpec;
		internal System.Windows.Forms.TextBox m_txtItemType;
		internal System.Windows.Forms.TextBox m_txtItemPrice;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 收费项目用法组合
		/// </summary>
		internal clsBridgeForUsaEdit m_objBridgeForUsaEdit =null;
		/// <summary>
		/// 操作状态	{0、新增(默认)；1、修改；}
		/// </summary>
		internal int m_intOperateState =0;
		internal System.Windows.Forms.ComboBox m_cboCLINICTYPE;
		internal System.Windows.Forms.ComboBox m_cboBIHTYPE;
		private PinkieControls.ButtonXP m_cmdRefurbish;
		internal System.Windows.Forms.Label m_lblSaveDosageUnit;
		internal System.Windows.Forms.TextBox m_txtDOSAGE_DEC;
		internal System.Windows.Forms.Label m_lblBihUnit;
		internal System.Windows.Forms.Label m_lblClinicUnit;
		internal System.Windows.Forms.ComboBox m_cboContinueUseType;
		private System.Windows.Forms.Label label10;
        public bool m_blnIsCMUsageEdit = false;
        internal Label label11;
        internal ComboBox m_cboZyFlag;
        internal com.digitalwave.controls.ctlTextBoxFind m_ctfDefDept;
        private Label label12;
		/// <summary>
		/// 操作结果状态	{0、直接关闭(默认)；1、操作成功；2、操作失败；}
		/// </summary>
		internal int m_intResultState =0;
		#endregion
		#region 构造函数
		public frmUsaEdit()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_objBridgeForUsaEdit">用法维护桥梁类</param>
		public frmUsaEdit(clsBridgeForUsaEdit p_objBridgeForUsaEdit) :this()
		{
			m_objBridgeForUsaEdit =p_objBridgeForUsaEdit;
			if(m_objBridgeForUsaEdit!=null && m_objBridgeForUsaEdit.m_strItemID!=null && m_objBridgeForUsaEdit.m_strItemID.Trim()!="")
			{
				((clsControlUsaEdit)this.objController).isnoqty=false;
				m_intOperateState =1;
				this.m_cmdDel.Enabled =true;
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
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsaEdit));
            this.m_ctfDefDept = new com.digitalwave.controls.ctlTextBoxFind();
            this.label12 = new System.Windows.Forms.Label();
            this.m_cboZyFlag = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cboContinueUseType = new System.Windows.Forms.ComboBox();
            this.m_txtDOSAGE_DEC = new System.Windows.Forms.TextBox();
            this.m_cboBIHTYPE = new System.Windows.Forms.ComboBox();
            this.m_cboCLINICTYPE = new System.Windows.Forms.ComboBox();
            this.m_txtItemType = new System.Windows.Forms.TextBox();
            this.m_txtItemSpec = new System.Windows.Forms.TextBox();
            this.m_txtItemPrice = new System.Windows.Forms.TextBox();
            this.m_txtCLINICQTY = new System.Windows.Forms.TextBox();
            this.m_txtItem = new com.digitalwave.controls.ctlFindTextBox();
            this.m_txtBIHQTY = new System.Windows.Forms.TextBox();
            this.m_txtCLINICTOTALPRICE = new System.Windows.Forms.TextBox();
            this.m_txtBIHOTALPRICE = new System.Windows.Forms.TextBox();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdSaveAdd = new PinkieControls.ButtonXP();
            this.label18 = new System.Windows.Forms.Label();
            this.m_cmdDel = new PinkieControls.ButtonXP();
            this.cmdClose = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblSaveDosageUnit = new System.Windows.Forms.Label();
            this.m_cmdRefurbish = new PinkieControls.ButtonXP();
            this.m_lblClinicUnit = new System.Windows.Forms.Label();
            this.m_lblBihUnit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_ctfDefDept
            // 
            this.m_ctfDefDept.Enabled = false;
            this.m_ctfDefDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctfDefDept.intHeight = 150;
            this.m_ctfDefDept.IsEnterShow = true;
            this.m_ctfDefDept.isHide = 3;
            this.m_ctfDefDept.isTxt = 1;
            this.m_ctfDefDept.isUpOrDn = 1;
            this.m_ctfDefDept.isValuse = 3;
            this.m_ctfDefDept.Location = new System.Drawing.Point(328, 169);
            this.m_ctfDefDept.m_IsHaveParent = false;
            this.m_ctfDefDept.m_strParentName = "";
            this.m_ctfDefDept.Name = "m_ctfDefDept";
            this.m_ctfDefDept.nextCtl = null;
            this.m_ctfDefDept.Size = new System.Drawing.Size(168, 23);
            this.m_ctfDefDept.TabIndex = 84;
            this.m_ctfDefDept.txtValuse = "";
            this.m_ctfDefDept.VsLeftOrRight = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 83;
            this.label12.Text = "指定科室：";
            // 
            // m_cboZyFlag
            // 
            this.m_cboZyFlag.BackColor = System.Drawing.Color.Wheat;
            this.m_cboZyFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboZyFlag.DropDownWidth = 145;
            this.m_cboZyFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cboZyFlag.FormattingEnabled = true;
            this.m_cboZyFlag.Items.AddRange(new object[] {
            "1 - 根据开单科室",
            "2 - 指定执行科室"});
            this.m_cboZyFlag.Location = new System.Drawing.Point(96, 170);
            this.m_cboZyFlag.Name = "m_cboZyFlag";
            this.m_cboZyFlag.Size = new System.Drawing.Size(136, 22);
            this.m_cboZyFlag.TabIndex = 82;
            this.m_cboZyFlag.SelectedIndexChanged += new System.EventHandler(this.m_cboZyFlag_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label11.Location = new System.Drawing.Point(1, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 14);
            this.label11.TabIndex = 81;
            this.label11.Text = "住院执行标志：";
            // 
            // m_cboContinueUseType
            // 
            this.m_cboContinueUseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboContinueUseType.Items.AddRange(new object[] {
            "连续用",
            "首次用"});
            this.m_cboContinueUseType.Location = new System.Drawing.Point(400, 9);
            this.m_cboContinueUseType.Name = "m_cboContinueUseType";
            this.m_cboContinueUseType.Size = new System.Drawing.Size(96, 22);
            this.m_cboContinueUseType.TabIndex = 80;
            // 
            // m_txtDOSAGE_DEC
            // 
            this.m_txtDOSAGE_DEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDOSAGE_DEC.Enabled = false;
            this.m_txtDOSAGE_DEC.Location = new System.Drawing.Point(64, 136);
            this.m_txtDOSAGE_DEC.Name = "m_txtDOSAGE_DEC";
            this.m_txtDOSAGE_DEC.Size = new System.Drawing.Size(168, 23);
            this.m_txtDOSAGE_DEC.TabIndex = 70;
            // 
            // m_cboBIHTYPE
            // 
            this.m_cboBIHTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBIHTYPE.Items.AddRange(new object[] {
            "领量单位",
            "剂量单位"});
            this.m_cboBIHTYPE.Location = new System.Drawing.Point(232, 73);
            this.m_cboBIHTYPE.Name = "m_cboBIHTYPE";
            this.m_cboBIHTYPE.Size = new System.Drawing.Size(96, 22);
            this.m_cboBIHTYPE.TabIndex = 66;
            this.m_cboBIHTYPE.SelectedIndexChanged += new System.EventHandler(this.m_txtBIHQTY_TextChanged);
            this.m_cboBIHTYPE.TextChanged += new System.EventHandler(this.m_TextChanged);
            // 
            // m_cboCLINICTYPE
            // 
            this.m_cboCLINICTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCLINICTYPE.Items.AddRange(new object[] {
            "领量单位",
            "剂量单位"});
            this.m_cboCLINICTYPE.Location = new System.Drawing.Point(232, 41);
            this.m_cboCLINICTYPE.Name = "m_cboCLINICTYPE";
            this.m_cboCLINICTYPE.Size = new System.Drawing.Size(96, 22);
            this.m_cboCLINICTYPE.TabIndex = 61;
            this.m_cboCLINICTYPE.SelectedIndexChanged += new System.EventHandler(this.m_cboCLINICTYPE_SelectedIndexChanged);
            this.m_cboCLINICTYPE.TextChanged += new System.EventHandler(this.m_TextChanged);
            // 
            // m_txtItemType
            // 
            this.m_txtItemType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtItemType.Enabled = false;
            this.m_txtItemType.Location = new System.Drawing.Point(64, 104);
            this.m_txtItemType.Name = "m_txtItemType";
            this.m_txtItemType.Size = new System.Drawing.Size(168, 23);
            this.m_txtItemType.TabIndex = 70;
            // 
            // m_txtItemSpec
            // 
            this.m_txtItemSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtItemSpec.Enabled = false;
            this.m_txtItemSpec.Location = new System.Drawing.Point(328, 104);
            this.m_txtItemSpec.Name = "m_txtItemSpec";
            this.m_txtItemSpec.Size = new System.Drawing.Size(168, 23);
            this.m_txtItemSpec.TabIndex = 71;
            // 
            // m_txtItemPrice
            // 
            this.m_txtItemPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtItemPrice.Enabled = false;
            this.m_txtItemPrice.Location = new System.Drawing.Point(328, 136);
            this.m_txtItemPrice.Name = "m_txtItemPrice";
            this.m_txtItemPrice.Size = new System.Drawing.Size(168, 23);
            this.m_txtItemPrice.TabIndex = 76;
            // 
            // m_txtCLINICQTY
            // 
            this.m_txtCLINICQTY.Location = new System.Drawing.Point(64, 40);
            this.m_txtCLINICQTY.MaxLength = 3;
            this.m_txtCLINICQTY.Name = "m_txtCLINICQTY";
            this.m_txtCLINICQTY.Size = new System.Drawing.Size(64, 23);
            this.m_txtCLINICQTY.TabIndex = 60;
            this.m_txtCLINICQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtCLINICQTY_KeyPress);
            this.m_txtCLINICQTY.TextChanged += new System.EventHandler(this.m_TextChanged);
            // 
            // m_txtItem
            // 
            this.m_txtItem.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtItem.Location = new System.Drawing.Point(64, 8);
            this.m_txtItem.MaxLength = 40;
            this.m_txtItem.Name = "m_txtItem";
            this.m_txtItem.Size = new System.Drawing.Size(264, 23);
            this.m_txtItem.TabIndex = 50;
            this.m_txtItem.m_evtFindItem += new com.digitalwave.controls.EventHandler_OnFindItem(this.m_txtItem_m_evtFindItem);
            this.m_txtItem.m_evtInitListView += new com.digitalwave.controls.EventHandler_InitListView(this.m_txtItem_m_evtInitListView);
            this.m_txtItem.m_evtSelectItem += new com.digitalwave.controls.EventHandler_OnSelectItem(this.m_txtItem_m_evtSelectItem);
            // 
            // m_txtBIHQTY
            // 
            this.m_txtBIHQTY.Location = new System.Drawing.Point(64, 72);
            this.m_txtBIHQTY.MaxLength = 3;
            this.m_txtBIHQTY.Name = "m_txtBIHQTY";
            this.m_txtBIHQTY.Size = new System.Drawing.Size(64, 23);
            this.m_txtBIHQTY.TabIndex = 65;
            this.m_txtBIHQTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txtBIHQTY_KeyPress);
            this.m_txtBIHQTY.TextChanged += new System.EventHandler(this.m_txtBIHQTY_TextChanged);
            // 
            // m_txtCLINICTOTALPRICE
            // 
            this.m_txtCLINICTOTALPRICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCLINICTOTALPRICE.Enabled = false;
            this.m_txtCLINICTOTALPRICE.Location = new System.Drawing.Point(400, 40);
            this.m_txtCLINICTOTALPRICE.MaxLength = 12;
            this.m_txtCLINICTOTALPRICE.Name = "m_txtCLINICTOTALPRICE";
            this.m_txtCLINICTOTALPRICE.Size = new System.Drawing.Size(96, 23);
            this.m_txtCLINICTOTALPRICE.TabIndex = 62;
            // 
            // m_txtBIHOTALPRICE
            // 
            this.m_txtBIHOTALPRICE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBIHOTALPRICE.Enabled = false;
            this.m_txtBIHOTALPRICE.Location = new System.Drawing.Point(400, 72);
            this.m_txtBIHOTALPRICE.MaxLength = 12;
            this.m_txtBIHOTALPRICE.Name = "m_txtBIHOTALPRICE";
            this.m_txtBIHOTALPRICE.Size = new System.Drawing.Size(96, 23);
            this.m_txtBIHOTALPRICE.TabIndex = 67;
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(512, 2);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(104, 32);
            this.m_cmdSave.TabIndex = 77;
            this.m_cmdSave.Text = "保存(F2)";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdSaveAdd
            // 
            this.m_cmdSaveAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSaveAdd.DefaultScheme = true;
            this.m_cmdSaveAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSaveAdd.Hint = "";
            this.m_cmdSaveAdd.Location = new System.Drawing.Point(512, 34);
            this.m_cmdSaveAdd.Name = "m_cmdSaveAdd";
            this.m_cmdSaveAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSaveAdd.Size = new System.Drawing.Size(104, 32);
            this.m_cmdSaveAdd.TabIndex = 78;
            this.m_cmdSaveAdd.Text = "保存新增(F3)";
            this.m_cmdSaveAdd.Click += new System.EventHandler(this.m_cmdSaveAdd_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label18.Location = new System.Drawing.Point(0, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 14);
            this.label18.TabIndex = 63;
            this.label18.Text = "项目名称：";
            // 
            // m_cmdDel
            // 
            this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDel.DefaultScheme = true;
            this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDel.Enabled = false;
            this.m_cmdDel.Hint = "";
            this.m_cmdDel.Location = new System.Drawing.Point(512, 66);
            this.m_cmdDel.Name = "m_cmdDel";
            this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDel.Size = new System.Drawing.Size(104, 32);
            this.m_cmdDel.TabIndex = 78;
            this.m_cmdDel.Text = "删除(F4)";
            this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdClose.DefaultScheme = true;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdClose.Hint = "";
            this.cmdClose.Location = new System.Drawing.Point(512, 130);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdClose.Size = new System.Drawing.Size(104, 32);
            this.cmdClose.TabIndex = 78;
            this.cmdClose.Text = "关闭(Esc)";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(0, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 63;
            this.label1.Text = "门诊数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(168, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 63;
            this.label2.Text = "数量类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(168, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 63;
            this.label3.Text = "数量类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(0, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 63;
            this.label4.Text = "住院数量：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(336, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 63;
            this.label5.Text = "费用合计：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(336, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 63;
            this.label6.Text = "费用合计：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(264, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 63;
            this.label7.Text = "项目规格：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(0, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 63;
            this.label8.Text = "项目类型：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(264, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 63;
            this.label9.Text = "住院单价：";
            // 
            // m_lblSaveDosageUnit
            // 
            this.m_lblSaveDosageUnit.AutoSize = true;
            this.m_lblSaveDosageUnit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblSaveDosageUnit.Location = new System.Drawing.Point(0, 140);
            this.m_lblSaveDosageUnit.Name = "m_lblSaveDosageUnit";
            this.m_lblSaveDosageUnit.Size = new System.Drawing.Size(77, 14);
            this.m_lblSaveDosageUnit.TabIndex = 63;
            this.m_lblSaveDosageUnit.Text = "单位剂量：";
            // 
            // m_cmdRefurbish
            // 
            this.m_cmdRefurbish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdRefurbish.DefaultScheme = true;
            this.m_cmdRefurbish.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRefurbish.Hint = "";
            this.m_cmdRefurbish.Location = new System.Drawing.Point(512, 98);
            this.m_cmdRefurbish.Name = "m_cmdRefurbish";
            this.m_cmdRefurbish.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefurbish.Size = new System.Drawing.Size(104, 32);
            this.m_cmdRefurbish.TabIndex = 78;
            this.m_cmdRefurbish.Text = "刷新(F5)";
            this.m_cmdRefurbish.Click += new System.EventHandler(this.m_cmdRefurbish_Click);
            // 
            // m_lblClinicUnit
            // 
            this.m_lblClinicUnit.AutoSize = true;
            this.m_lblClinicUnit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblClinicUnit.Location = new System.Drawing.Point(128, 44);
            this.m_lblClinicUnit.Name = "m_lblClinicUnit";
            this.m_lblClinicUnit.Size = new System.Drawing.Size(35, 14);
            this.m_lblClinicUnit.TabIndex = 63;
            this.m_lblClinicUnit.Text = "单位";
            // 
            // m_lblBihUnit
            // 
            this.m_lblBihUnit.AutoSize = true;
            this.m_lblBihUnit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_lblBihUnit.Location = new System.Drawing.Point(128, 76);
            this.m_lblBihUnit.Name = "m_lblBihUnit";
            this.m_lblBihUnit.Size = new System.Drawing.Size(35, 14);
            this.m_lblBihUnit.TabIndex = 63;
            this.m_lblBihUnit.Text = "单位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label10.Location = new System.Drawing.Point(337, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 63;
            this.label10.Text = "续用类型：";
            // 
            // frmUsaEdit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(624, 206);
            this.Controls.Add(this.m_ctfDefDept);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.m_cboZyFlag);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_cboContinueUseType);
            this.Controls.Add(this.m_txtDOSAGE_DEC);
            this.Controls.Add(this.m_cboBIHTYPE);
            this.Controls.Add(this.m_cboCLINICTYPE);
            this.Controls.Add(this.m_txtItemType);
            this.Controls.Add(this.m_txtItemSpec);
            this.Controls.Add(this.m_txtItemPrice);
            this.Controls.Add(this.m_txtCLINICQTY);
            this.Controls.Add(this.m_txtItem);
            this.Controls.Add(this.m_txtBIHQTY);
            this.Controls.Add(this.m_txtCLINICTOTALPRICE);
            this.Controls.Add(this.m_txtBIHOTALPRICE);
            this.Controls.Add(this.m_cmdSave);
            this.Controls.Add(this.m_cmdSaveAdd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.m_cmdDel);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.m_lblSaveDosageUnit);
            this.Controls.Add(this.m_cmdRefurbish);
            this.Controls.Add(this.m_lblClinicUnit);
            this.Controls.Add(this.m_lblBihUnit);
            this.Controls.Add(this.label10);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用法项目编辑";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsaEdit_KeyDown);
            this.Load += new System.EventHandler(this.frmUsaEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private ArrayList _objArrItem;
		public ArrayList CurrentItem
		{
			set
			{
				_objArrItem =value;
			}
			get
			{
			return _objArrItem;
			}
		}
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlUsaEdit();
			objController.Set_GUI_Apperance(this);
		}

		#region 窗体事件
		private void frmUsaEdit_Load(object sender, System.EventArgs e)
		{
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtCLINICTOTALPRICE, m_txtBIHOTALPRICE, m_txtItem });
			//门诊数量类型
			m_cboCLINICTYPE.SelectedIndex =0;
			//住院数量类型
			m_cboBIHTYPE.SelectedIndex =0;
			m_cboContinueUseType.SelectedIndex =0;
			((clsControlUsaEdit)this.objController).m_FromLoad();	
			((clsControlUsaEdit)this.objController).m_FillTextFromObject(m_objBridgeForUsaEdit);
            ((clsControlUsaEdit)this.objController).m_lngGetZyExecDept();
		}

		private void frmUsaEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F2:					
					if(m_cmdSave.Visible && m_cmdSave.Enabled ) m_cmdSave_Click(sender,e);
					break;
				case Keys.F3:
					if(m_cmdSaveAdd.Visible && m_cmdSaveAdd.Enabled ) m_cmdSaveAdd_Click(sender,e);
					break;
				case Keys.F4:
					if(m_cmdDel.Visible && m_cmdDel.Enabled ) m_cmdDel_Click(sender,e);
					break;
				case Keys.F5:
					if(m_cmdRefurbish.Visible && m_cmdRefurbish.Enabled ) m_cmdRefurbish_Click(sender,e);
					break;
			}	
		}
		#endregion
		#region 按钮事件
		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
            if (this.m_blnIsCMUsageEdit == true)
            {
                ((clsControlUsaEdit)this.objController).m_mthCMUsageSave();
                return;
            }
			((clsControlUsaEdit)this.objController).m_Save();
		}

		private void m_cmdSaveAdd_Click(object sender, System.EventArgs e)
		{
            if (this.m_blnIsCMUsageEdit == true)
            {
                ((clsControlUsaEdit)this.objController).m_mthCMUsageSaveAdd();
                return;
            }
			((clsControlUsaEdit)this.objController).m_SaveAdd();	
		}

		private void m_cmdDel_Click(object sender, System.EventArgs e)
		{
            if (this.m_blnIsCMUsageEdit == true)
            {
                ((clsControlUsaEdit)this.objController).m_mthDel();
                return;
            }
			((clsControlUsaEdit)this.objController).m_Del();		
		}

		private void m_cmdRefurbish_Click(object sender, System.EventArgs e)
		{		
			((clsControlUsaEdit)this.objController).m_ClearInput();	
			((clsControlUsaEdit)this.objController).m_FillTextFromObject(m_objBridgeForUsaEdit);	
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region 文本事件
		private void m_txtItem_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			((clsControlUsaEdit)this.objController).m_TextItemInitListView(lvwList);
		}

		private void m_txtItem_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsControlUsaEdit)this.objController).m_TextItemFindItem(strFindCode,lvwList);
			this.Cursor =Cursors.Default;
		}

		private void m_txtItem_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			((clsControlUsaEdit)this.objController).m_TextItemSelectItem(lviSelected);
		}	

		private void m_TextChanged(object sender, System.EventArgs e)
		{
			if(m_txtCLINICQTY.Text.Trim()=="" || m_txtItem.Tag == null)
				return;
			m_txtCLINICTOTALPRICE.Text=((clsControlUsaEdit)this.objController).m_dblCalMoney((string)m_txtItem.Tag,1,double.Parse(m_txtCLINICQTY.Text),m_cboCLINICTYPE.SelectedIndex==0?1:2).ToString();
		}
		private void m_cboCLINICTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboCLINICTYPE.SelectedIndex==0)
			{
				if(this.m_lblClinicUnit.Tag!=null)
					m_lblClinicUnit.Text =m_lblClinicUnit.Tag.ToString();
				else
					m_lblClinicUnit.Text ="";
			}
			else if(this.m_cboCLINICTYPE.SelectedIndex==1)
			{
				if(this.m_lblSaveDosageUnit.Tag!=null)
					m_lblClinicUnit.Text =m_lblSaveDosageUnit.Tag.ToString();
				else
					m_lblClinicUnit.Text ="";
			}
		}

		private void m_cboBIHTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboBIHTYPE.SelectedIndex==0)
			{
				if(this.m_lblBihUnit.Tag!=null)
					m_lblBihUnit.Text =m_lblBihUnit.Tag.ToString();
				else
					m_lblBihUnit.Text ="";
			}
			else if(this.m_cboBIHTYPE.SelectedIndex==1)
			{
				if(this.m_lblSaveDosageUnit.Tag!=null)
					m_lblBihUnit.Text =m_lblSaveDosageUnit.Tag.ToString();
				else
					m_lblBihUnit.Text ="";
			}
		}
		#endregion

		private void m_txtBIHQTY_TextChanged(object sender, System.EventArgs e)
		{
			if(m_txtBIHQTY.Text.Trim()=="" || m_txtItem.Tag == null)
				return;
          
			m_txtBIHOTALPRICE.Text=((clsControlUsaEdit)this.objController).m_dblCalMoney((string)m_txtItem.Tag,2,double.Parse(m_txtBIHQTY.Text),m_cboCLINICTYPE.SelectedIndex==0?1:2).ToString();
		}

		#region 属性
		/// <summary>
		/// 获取操作结果状态	[只读]	{0、直接关闭(默认)；1、操作成功；2、操作失败；}
		/// </summary>
		public int ResultState
		{
			get
			{
				return this.m_intResultState;
			}
		}
		#endregion

        private void m_txtBIHQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            //alex 2006-11-10 注释掉该段代码，以开放小数点的输入
            //e.Handled = !((char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8) && m_txtBIHQTY.Text.Trim().Length <= 3);
            
        }

        private void m_txtCLINICQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            //alex 2006-11-10 注释掉该段代码，以开放小数点的输入
            //e.Handled = !((char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8 )&& m_txtCLINICQTY.Text.Trim().Length <= 3);
        }

        private void m_cboZyFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cboZyFlag.SelectedIndex == 1)
            {
                m_ctfDefDept.Enabled = true;
            }
            else
            {
                m_ctfDefDept.Enabled = false;
            }

        }
	}	
}
