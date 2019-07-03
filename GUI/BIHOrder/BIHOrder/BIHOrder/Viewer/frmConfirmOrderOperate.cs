using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 确认医嘱操作	界面表示层
	/// </summary>
	public class frmConfirmOrderOperate : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private PinkieControls.ButtonXP m_cmdOk;
		private PinkieControls.ButtonXP m_cmdClose;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.Label m_lblStatus4;
		internal System.Windows.Forms.Label m_lblStatus5;
		internal System.Windows.Forms.Label m_lblStatus3;
		internal System.Windows.Forms.Label m_lblStatus2;
		internal System.Windows.Forms.Label m_lblStatus1;
		internal System.Windows.Forms.Label m_lblStatus0;
		internal System.Windows.Forms.Label m_lblTemp;
		internal System.Windows.Forms.Label m_lblLong;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;		
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 医嘱名称
		/// </summary>
		internal System.Windows.Forms.TextBox m_txbOrderName;
		/// <summary>
		/// 病人名称
		/// </summary>
		internal System.Windows.Forms.TextBox m_txbPatientName;
		/// <summary>
		/// 操作名称	{例如：停止、重整等}
		/// </summary>
		internal string m_strOperateName ="";
		/// <summary>
		/// 用于返回操作结果	{0=取消或关闭窗口；1=确定}
		/// </summary>
		internal int m_intResult =0;
		internal System.Windows.Forms.Label m_lblPrompt;
		internal System.Windows.Forms.ListView m_lsvDisplayOrder;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		/// <summary>
		/// 医嘱ＩＤ
		/// </summary>
		internal string m_strOrderID ="";

        internal bool IsChildPrice { get; set; }

		#endregion 

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public frmConfirmOrderOperate()
		{
			InitializeComponent();
		}
		/// <summary>
		/// 构造函数	
		/// </summary>
		/// <param name="m_strOrderID">医嘱ＩＤ</param>
		public frmConfirmOrderOperate(string p_strOrderID, bool _isChildPrice)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_strOrderID =p_strOrderID;
            this.IsChildPrice = _isChildPrice;
		}

		/// <summary>
		/// 构造函数	
		/// </summary>
		/// <param name="p_strOperateName">操作名称</param>
		/// <param name="p_strOrderID">医嘱ＩＤ</param>
        public frmConfirmOrderOperate(string p_strOperateName, string p_strOrderID, bool _isChildPrice)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_strOperateName =p_strOperateName;
			m_strOrderID =p_strOrderID;
            this.IsChildPrice = _isChildPrice;
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
			this.m_cmdOk = new PinkieControls.ButtonXP();
			this.m_cmdClose = new PinkieControls.ButtonXP();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_lblStatus4 = new System.Windows.Forms.Label();
			this.m_lblStatus5 = new System.Windows.Forms.Label();
			this.m_lblStatus3 = new System.Windows.Forms.Label();
			this.m_lblStatus2 = new System.Windows.Forms.Label();
			this.m_lblStatus1 = new System.Windows.Forms.Label();
			this.m_lblStatus0 = new System.Windows.Forms.Label();
			this.m_lblTemp = new System.Windows.Forms.Label();
			this.m_lblLong = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txbOrderName = new System.Windows.Forms.TextBox();
			this.m_txbPatientName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_lblPrompt = new System.Windows.Forms.Label();
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
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cmdOk
			// 
			this.m_cmdOk.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOk.DefaultScheme = true;
			this.m_cmdOk.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOk.Hint = "";
			this.m_cmdOk.Location = new System.Drawing.Point(677, 0);
			this.m_cmdOk.Name = "m_cmdOk";
			this.m_cmdOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOk.Size = new System.Drawing.Size(112, 32);
			this.m_cmdOk.TabIndex = 6;
			this.m_cmdOk.Text = "确定(F2)";
			this.m_cmdOk.Click += new System.EventHandler(this.m_cmdOk_Click);
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClose.DefaultScheme = true;
			this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClose.Hint = "";
			this.m_cmdClose.Location = new System.Drawing.Point(677, 32);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClose.Size = new System.Drawing.Size(112, 32);
			this.m_cmdClose.TabIndex = 7;
			this.m_cmdClose.Text = "关闭(Esc)";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.m_lblStatus4);
			this.panel2.Controls.Add(this.m_lblStatus5);
			this.panel2.Controls.Add(this.m_lblStatus3);
			this.panel2.Controls.Add(this.m_lblStatus2);
			this.panel2.Controls.Add(this.m_lblStatus1);
			this.panel2.Controls.Add(this.m_lblStatus0);
			this.panel2.Controls.Add(this.m_lblTemp);
			this.panel2.Controls.Add(this.m_lblLong);
			this.panel2.Controls.Add(this.label12);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.label10);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 325);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 32);
			this.panel2.TabIndex = 55;
			// 
			// m_lblStatus4
			// 
			this.m_lblStatus4.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus4.Location = new System.Drawing.Point(328, 12);
			this.m_lblStatus4.Name = "m_lblStatus4";
			this.m_lblStatus4.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus4.TabIndex = 16;
			this.m_lblStatus4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblStatus5
			// 
			this.m_lblStatus5.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus5.Location = new System.Drawing.Point(376, 12);
			this.m_lblStatus5.Name = "m_lblStatus5";
			this.m_lblStatus5.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus5.TabIndex = 15;
			this.m_lblStatus5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblStatus3
			// 
			this.m_lblStatus3.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus3.Location = new System.Drawing.Point(280, 12);
			this.m_lblStatus3.Name = "m_lblStatus3";
			this.m_lblStatus3.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus3.TabIndex = 14;
			this.m_lblStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblStatus2
			// 
			this.m_lblStatus2.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus2.Location = new System.Drawing.Point(232, 12);
			this.m_lblStatus2.Name = "m_lblStatus2";
			this.m_lblStatus2.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus2.TabIndex = 13;
			this.m_lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblStatus1
			// 
			this.m_lblStatus1.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus1.Location = new System.Drawing.Point(180, 12);
			this.m_lblStatus1.Name = "m_lblStatus1";
			this.m_lblStatus1.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus1.TabIndex = 12;
			this.m_lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblStatus0
			// 
			this.m_lblStatus0.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblStatus0.Location = new System.Drawing.Point(128, 12);
			this.m_lblStatus0.Name = "m_lblStatus0";
			this.m_lblStatus0.Size = new System.Drawing.Size(10, 10);
			this.m_lblStatus0.TabIndex = 11;
			this.m_lblStatus0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblTemp
			// 
			this.m_lblTemp.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblTemp.Location = new System.Drawing.Point(55, 12);
			this.m_lblTemp.Name = "m_lblTemp";
			this.m_lblTemp.Size = new System.Drawing.Size(10, 10);
			this.m_lblTemp.TabIndex = 10;
			this.m_lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblLong
			// 
			this.m_lblLong.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_lblLong.Location = new System.Drawing.Point(8, 12);
			this.m_lblLong.Name = "m_lblLong";
			this.m_lblLong.Size = new System.Drawing.Size(10, 10);
			this.m_lblLong.TabIndex = 9;
			this.m_lblLong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(338, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(34, 19);
			this.label12.TabIndex = 8;
			this.label12.Text = "重整";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(384, 8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(34, 19);
			this.label11.TabIndex = 7;
			this.label11.Text = "作废";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(288, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 19);
			this.label10.TabIndex = 6;
			this.label10.Text = "停止";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.SystemColors.Control;
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(242, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(34, 19);
			this.label9.TabIndex = 5;
			this.label9.Text = "执行";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(191, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 19);
			this.label8.TabIndex = 4;
			this.label8.Text = "提交";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(139, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 19);
			this.label7.TabIndex = 3;
			this.label7.Text = "新建";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(67, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 19);
			this.label6.TabIndex = 2;
			this.label6.Text = "临时";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 19);
			this.label5.TabIndex = 1;
			this.label5.Text = "长期";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txbOrderName
			// 
			this.m_txbOrderName.Location = new System.Drawing.Point(264, 2);
			this.m_txbOrderName.Name = "m_txbOrderName";
			this.m_txbOrderName.ReadOnly = true;
			this.m_txbOrderName.Size = new System.Drawing.Size(120, 23);
			this.m_txbOrderName.TabIndex = 58;
			this.m_txbOrderName.Text = "";
			// 
			// m_txbPatientName
			// 
			this.m_txbPatientName.Location = new System.Drawing.Point(64, 2);
			this.m_txbPatientName.Name = "m_txbPatientName";
			this.m_txbPatientName.ReadOnly = true;
			this.m_txbPatientName.Size = new System.Drawing.Size(120, 23);
			this.m_txbPatientName.TabIndex = 59;
			this.m_txbPatientName.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 56;
			this.label1.Text = "病人姓名：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 57;
			this.label2.Text = "医嘱名称：";
			// 
			// m_lblPrompt
			// 
			this.m_lblPrompt.BackColor = System.Drawing.Color.Silver;
			this.m_lblPrompt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_lblPrompt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblPrompt.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_lblPrompt.Location = new System.Drawing.Point(0, 32);
			this.m_lblPrompt.Name = "m_lblPrompt";
			this.m_lblPrompt.Size = new System.Drawing.Size(672, 32);
			this.m_lblPrompt.TabIndex = 57;
			this.m_lblPrompt.Text = "此医嘱为下列医嘱的父级医嘱，[]此医嘱，下列满足操作条件的医嘱将自动[]，你确定操作吗？";
			this.m_lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lsvDisplayOrder
			// 
			this.m_lsvDisplayOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			this.m_lsvDisplayOrder.Location = new System.Drawing.Point(0, 69);
			this.m_lsvDisplayOrder.Name = "m_lsvDisplayOrder";
			this.m_lsvDisplayOrder.Size = new System.Drawing.Size(792, 256);
			this.m_lsvDisplayOrder.TabIndex = 60;
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
			// frmConfirmOrderOperate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(792, 357);
			this.Controls.Add(this.m_lsvDisplayOrder);
			this.Controls.Add(this.m_txbOrderName);
			this.Controls.Add(this.m_txbPatientName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_cmdOk);
			this.Controls.Add(this.m_cmdClose);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.m_lblPrompt);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfirmOrderOperate";
			this.Text = "提示框!";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfirmOrderOperate_KeyDown);
			this.Load += new System.EventHandler(this.frmConfirmOrderOperate_Load);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_ConfirmOrderOperate();
			objController.Set_GUI_Apperance(this);
		}

		#region 事件
		private void m_cmdOk_Click(object sender, System.EventArgs e)
		{
			this.m_intResult =1;
			this.Close();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmConfirmOrderOperate_Load(object sender, System.EventArgs e)
		{
			((clsCtl_ConfirmOrderOperate)this.objController).LoadData();
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
					m_cmdOk_Click(sender,e);
					break;
			}
		}
		#endregion 
	}
}
