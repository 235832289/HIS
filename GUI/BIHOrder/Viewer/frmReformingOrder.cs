using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 重整医嘱	表示层
	/// 创建人:		 
	/// 创建时间:	 
	/// </summary>
	public class frmReformingOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		internal System.Windows.Forms.ListView m_lsvDisplayOrder;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private PinkieControls.ButtonXP m_cmdOk;
		private PinkieControls.ButtonXP m_cmdClose;
		internal System.Windows.Forms.TextBox m_txbPatientName;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label m_lblPrompt;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 入院登记流水号
		/// </summary>
		internal string m_strRegisterID ="";
		internal System.Windows.Forms.CheckBox chkSelectAll;
		/// <summary>
		/// 操作类型	{3-停止医嘱；4-重整医嘱；}
		/// </summary>
		internal int m_intType =0;
		#endregion 

		#region 构造函数
		public frmReformingOrder()
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
		/// <param name="p_strOrderID">医嘱ID</param>
		/// <param name="p_intType">操作类型	{3-停止医嘱；4-重整医嘱；}</param>
		public frmReformingOrder(string p_strRegisterID,int p_intType):this()
		{
			m_strRegisterID =p_strRegisterID;
			m_intType =p_intType;
			switch(p_intType)
			{
				case 3:
					this.m_lblPrompt.Text ="您可以停止下列医嘱!";
					this.Text ="停止医嘱";
					this.m_cmdOk.Text ="停止(F2)";
					break;
				case 4:
					this.m_lblPrompt.Text ="您可以重整下列医嘱!";
					this.Text ="重整医嘱";
					this.m_cmdOk.Text ="重整(F2)";
					break;
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
			this.m_lsvDisplayOrder = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdOk = new PinkieControls.ButtonXP();
			this.m_cmdClose = new PinkieControls.ButtonXP();
			this.m_txbPatientName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lblPrompt = new System.Windows.Forms.Label();
			this.chkSelectAll = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// m_lsvDisplayOrder
			// 
			this.m_lsvDisplayOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvDisplayOrder.CheckBoxes = true;
			this.m_lsvDisplayOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.columnHeader1,
																								this.columnHeader2,
																								this.columnHeader3,
																								this.columnHeader4,
																								this.columnHeader5,
																								this.columnHeader6,
																								this.columnHeader7,
																								this.columnHeader8,
																								this.columnHeader9,
																								this.columnHeader10});
			this.m_lsvDisplayOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lsvDisplayOrder.FullRowSelect = true;
			this.m_lsvDisplayOrder.GridLines = true;
			this.m_lsvDisplayOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvDisplayOrder.Location = new System.Drawing.Point(0, 39);
			this.m_lsvDisplayOrder.Name = "m_lsvDisplayOrder";
			this.m_lsvDisplayOrder.Size = new System.Drawing.Size(786, 288);
			this.m_lsvDisplayOrder.TabIndex = 9;
			this.m_lsvDisplayOrder.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "方号";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 40;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "长/临";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 50;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "名称";
			this.columnHeader4.Width = 150;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "剂 量";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader5.Width = 70;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "领量";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader6.Width = 70;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "执行频率";
			this.columnHeader7.Width = 80;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "用 法";
			this.columnHeader8.Width = 70;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "皮";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader9.Width = 40;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "父级医嘱";
			this.columnHeader10.Width = 150;
			// 
			// m_cmdOk
			// 
			this.m_cmdOk.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOk.DefaultScheme = true;
			this.m_cmdOk.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOk.Hint = "";
			this.m_cmdOk.Location = new System.Drawing.Point(560, 4);
			this.m_cmdOk.Name = "m_cmdOk";
			this.m_cmdOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOk.Size = new System.Drawing.Size(112, 32);
			this.m_cmdOk.TabIndex = 10;
			this.m_cmdOk.Text = "重整(F2)";
			this.m_cmdOk.Click += new System.EventHandler(this.m_cmdOk_Click);
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClose.DefaultScheme = true;
			this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClose.Hint = "";
			this.m_cmdClose.Location = new System.Drawing.Point(672, 4);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClose.Size = new System.Drawing.Size(112, 32);
			this.m_cmdClose.TabIndex = 11;
			this.m_cmdClose.Text = "关闭(Esc)";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
			// 
			// m_txbPatientName
			// 
			this.m_txbPatientName.Location = new System.Drawing.Point(64, 9);
			this.m_txbPatientName.Name = "m_txbPatientName";
			this.m_txbPatientName.ReadOnly = true;
			this.m_txbPatientName.Size = new System.Drawing.Size(120, 23);
			this.m_txbPatientName.TabIndex = 62;
			this.m_txbPatientName.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 60;
			this.label1.Text = "病人姓名：";
			// 
			// m_lblPrompt
			// 
			this.m_lblPrompt.BackColor = System.Drawing.Color.Gainsboro;
			this.m_lblPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lblPrompt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.m_lblPrompt.ForeColor = System.Drawing.Color.CadetBlue;
			this.m_lblPrompt.Location = new System.Drawing.Point(192, 8);
			this.m_lblPrompt.Name = "m_lblPrompt";
			this.m_lblPrompt.Size = new System.Drawing.Size(264, 24);
			this.m_lblPrompt.TabIndex = 61;
			this.m_lblPrompt.Text = "您可以重整下列医嘱!";
			this.m_lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkSelectAll
			// 
			this.chkSelectAll.BackColor = System.Drawing.SystemColors.Control;
			this.chkSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkSelectAll.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.chkSelectAll.ForeColor = System.Drawing.Color.Maroon;
			this.chkSelectAll.Location = new System.Drawing.Point(480, 11);
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.Size = new System.Drawing.Size(60, 24);
			this.chkSelectAll.TabIndex = 63;
			this.chkSelectAll.Text = "全选";
			this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
			// 
			// frmReformingOrder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(786, 327);
			this.Controls.Add(this.chkSelectAll);
			this.Controls.Add(this.m_txbPatientName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cmdOk);
			this.Controls.Add(this.m_cmdClose);
			this.Controls.Add(this.m_lblPrompt);
			this.Controls.Add(this.m_lsvDisplayOrder);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReformingOrder";
			this.Text = "重整医嘱";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfirmOrderOperate_KeyDown);
			this.Load += new System.EventHandler(this.frmConfirmOrderOperate_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_ReformingOrder();
			objController.Set_GUI_Apperance(this);
		}

		#region 窗体事件
		private void frmConfirmOrderOperate_Load(object sender, System.EventArgs e)
		{
			com.digitalwave.iCare.ValueObject.clsLoginInfo objLoginInfo = this.LoginInfo;
			((clsCtl_ReformingOrder)this.objController).m_strOperatorID =objLoginInfo.m_strEmpID;
			((clsCtl_ReformingOrder)this.objController).m_strOperatorName =objLoginInfo.m_strEmpName;
			((clsCtl_ReformingOrder)this.objController).LoadData();
		}

		private void frmConfirmOrderOperate_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2://保存
					if(m_cmdOk.Visible && m_cmdOk.Enabled) m_cmdOk_Click(sender,e);
					break;
			}
		}
		#endregion
		#region 按钮事件
		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void m_cmdOk_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ReformingOrder)this.objController).m_OK();
		}
		private void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			for(int i=0;i<m_lsvDisplayOrder.Items.Count;i++)
			{
				m_lsvDisplayOrder.Items[i].Checked =chkSelectAll.Checked;
			}
		}
		#endregion

		#region ListView事件
		#endregion
	}
}
