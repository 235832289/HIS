using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 皮试录入框	界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-12-23
	/// </summary>
	public class frmNeedFeel : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private PinkieControls.ButtonXP m_cmdSaveOrderFeel;
		/// <summary>
		/// 登陆信息
		/// </summary>
		internal com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo=null;
		/// <summary>
		/// 病人姓名
		/// </summary>
		internal System.Windows.Forms.TextBox m_txbPatientName;
		/// <summary>
		/// 医嘱名称
		/// </summary>
		internal System.Windows.Forms.TextBox m_txbOrderName;
		/// <summary>
		/// 1=阴性;2=阳性
		/// </summary>
		internal System.Windows.Forms.ComboBox m_cmbRESULTTYPE_INT;
		/// <summary>
		/// 备注
		/// </summary>
		internal System.Windows.Forms.TextBox m_txbDES_VCHR;
		private PinkieControls.ButtonXP m_cmdClose;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 医嘱ID
		/// </summary>
		internal string m_strOrderID="";
		/// <summary>
		/// 报告退出状态 {-1=执行错误后退出；0=未执行退出；1=执行正确后退出}
		/// </summary>
		internal int m_intResult =0;
        //填充皮试结果Vo
        public clsT_Opr_Bih_OrderFeel_VO p_objRecord;

        /// <summary>
        /// 看其是否由阳性改为了阴性（值为1），此时需要把费用表的记录删除
        /// 如果改之的改后都是阳性(值为2)，则要提示是否再次加收费用，不加收的话须删除之前的费用再另插入新的费用
        /// </summary>
        internal int m_intFeelFlag = -1;

		internal clsFeelEdit m_objFeelEdit =new clsFeelEdit();
		#endregion 

		#region 构造函数
		public frmNeedFeel()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		public frmNeedFeel(string p_strOrderID):this()
		{			
			m_strOrderID =p_strOrderID;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		public frmNeedFeel(clsFeelEdit objFeelEdit):this()
		{			
			m_objFeelEdit =objFeelEdit;
			m_strOrderID =m_objFeelEdit.m_strOrderID;
			this.m_txbOrderName.Text =m_objFeelEdit.m_strOrderName;
			this.m_txbPatientName.Text =m_objFeelEdit.m_strPatientName;
            
		}

        /// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		public frmNeedFeel(clsT_Opr_Bih_OrderFeel_VO m_objFell)
		{
            InitializeComponent();
            this.p_objRecord = m_objFell;
			m_strOrderID =m_objFell.m_strORDERID_CHR;
			this.m_txbOrderName.Text =m_objFell.m_strOrderName;
			this.m_txbPatientName.Text =m_objFell.m_strParentName;
            this.m_txbDES_VCHR.Text = m_objFell.m_strDES_VCHR;
            this.m_cmbRESULTTYPE_INT.SelectedIndex = m_objFell.m_intRESULTTYPE_INT;
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
            this.m_cmbRESULTTYPE_INT = new System.Windows.Forms.ComboBox();
            this.m_txbOrderName = new System.Windows.Forms.TextBox();
            this.m_txbPatientName = new System.Windows.Forms.TextBox();
            this.m_cmdSaveOrderFeel = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txbDES_VCHR = new System.Windows.Forms.TextBox();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_cmbRESULTTYPE_INT
            // 
            this.m_cmbRESULTTYPE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRESULTTYPE_INT.Items.AddRange(new object[] {
            "",
            "阴性",
            "阳性"});
            this.m_cmbRESULTTYPE_INT.Location = new System.Drawing.Point(64, 45);
            this.m_cmbRESULTTYPE_INT.Name = "m_cmbRESULTTYPE_INT";
            this.m_cmbRESULTTYPE_INT.Size = new System.Drawing.Size(120, 22);
            this.m_cmbRESULTTYPE_INT.TabIndex = 2;
            // 
            // m_txbOrderName
            // 
            this.m_txbOrderName.Location = new System.Drawing.Point(253, 8);
            this.m_txbOrderName.Name = "m_txbOrderName";
            this.m_txbOrderName.ReadOnly = true;
            this.m_txbOrderName.Size = new System.Drawing.Size(120, 23);
            this.m_txbOrderName.TabIndex = 44;
            // 
            // m_txbPatientName
            // 
            this.m_txbPatientName.Location = new System.Drawing.Point(64, 8);
            this.m_txbPatientName.Name = "m_txbPatientName";
            this.m_txbPatientName.ReadOnly = true;
            this.m_txbPatientName.Size = new System.Drawing.Size(120, 23);
            this.m_txbPatientName.TabIndex = 44;
            // 
            // m_cmdSaveOrderFeel
            // 
            this.m_cmdSaveOrderFeel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSaveOrderFeel.DefaultScheme = true;
            this.m_cmdSaveOrderFeel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSaveOrderFeel.Hint = "";
            this.m_cmdSaveOrderFeel.Location = new System.Drawing.Point(380, 4);
            this.m_cmdSaveOrderFeel.Name = "m_cmdSaveOrderFeel";
            this.m_cmdSaveOrderFeel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSaveOrderFeel.Size = new System.Drawing.Size(112, 32);
            this.m_cmdSaveOrderFeel.TabIndex = 4;
            this.m_cmdSaveOrderFeel.Text = "保存(F2)";
            this.m_cmdSaveOrderFeel.Click += new System.EventHandler(this.m_cmdSaveOrderFeel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "病人姓名：";
            // 
            // m_txbDES_VCHR
            // 
            this.m_txbDES_VCHR.Location = new System.Drawing.Point(0, 80);
            this.m_txbDES_VCHR.MaxLength = 40;
            this.m_txbDES_VCHR.Multiline = true;
            this.m_txbDES_VCHR.Name = "m_txbDES_VCHR";
            this.m_txbDES_VCHR.Size = new System.Drawing.Size(496, 232);
            this.m_txbDES_VCHR.TabIndex = 3;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(380, 40);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(112, 32);
            this.m_cmdClose.TabIndex = 5;
            this.m_cmdClose.Text = "关闭(Esc)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "医嘱名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "皮试结果：";
            // 
            // frmNeedFeel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(496, 309);
            this.Controls.Add(this.m_cmbRESULTTYPE_INT);
            this.Controls.Add(this.m_txbOrderName);
            this.Controls.Add(this.m_txbPatientName);
            this.Controls.Add(this.m_cmdSaveOrderFeel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txbDES_VCHR);
            this.Controls.Add(this.m_cmdClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNeedFeel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "皮试录入框";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNeedFeel_KeyDown);
            this.Load += new System.EventHandler(this.frmNeedFeel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_NeedFeel();
			objController.Set_GUI_Apperance(this);
		}
		#region 事件
		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdSaveOrderFeel_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_NeedFeel)this.objController).SaveOrderFeel2();
			this.Cursor =Cursors.Default;
		}

		private void frmNeedFeel_Load(object sender, System.EventArgs e)
		{
			m_mthSetEnter2Tab(new System.Windows.Forms.Control[]{});
			//((clsCtl_NeedFeel)this.objController).LoadData();
			m_objLoginInfo = this.LoginInfo;
			((clsCtl_NeedFeel)this.objController).m_strOperatorID =m_objLoginInfo.m_strEmpID;
            ((clsCtl_NeedFeel)this.objController).SetVo(this.p_objRecord);

		}

		private void frmNeedFeel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2://保存
					m_cmdSaveOrderFeel_Click(sender,e);
					break;
			}
		}
		#endregion 
	}
}
