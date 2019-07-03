using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 手工执行连续医嘱滚费 表示层
	/// 作者：	徐斌辉	
	/// 创建时间：	2005-04-18
	/// </summary>
	public class frmHandworkContinuousOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP m_cmdAutoCharge;
		internal com.digitalwave.controls.ctlTimePicker m_dtpAuto;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 登陆信息
		/// </summary>
		internal com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo=null;
		#endregion
		#region 构造函数
		public frmHandworkContinuousOrder()
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
			this.m_cmdAutoCharge = new PinkieControls.ButtonXP();
			this.m_dtpAuto = new com.digitalwave.controls.ctlTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_cmdAutoCharge
			// 
			this.m_cmdAutoCharge.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAutoCharge.DefaultScheme = true;
			this.m_cmdAutoCharge.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAutoCharge.Hint = "";
			this.m_cmdAutoCharge.Location = new System.Drawing.Point(46, 16);
			this.m_cmdAutoCharge.Name = "m_cmdAutoCharge";
			this.m_cmdAutoCharge.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAutoCharge.Size = new System.Drawing.Size(236, 32);
			this.m_cmdAutoCharge.TabIndex = 41;
			this.m_cmdAutoCharge.Text = "手工执行连续医嘱滚费(F5)";
			this.m_cmdAutoCharge.Click += new System.EventHandler(this.m_cmdAutoCharge_Click);
			// 
			// m_dtpAuto
			// 
			this.m_dtpAuto.BorderColor = System.Drawing.Color.DimGray;
			this.m_dtpAuto.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpAuto.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpAuto.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpAuto.DropButtonForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dtpAuto.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpAuto.Font = new System.Drawing.Font("宋体", 12F);
			this.m_dtpAuto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpAuto.Location = new System.Drawing.Point(112, 64);
			this.m_dtpAuto.m_BlnOnlyTime = false;
			this.m_dtpAuto.m_EnmVisibleFlag = com.digitalwave.controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpAuto.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpAuto.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpAuto.Name = "m_dtpAuto";
			this.m_dtpAuto.ReadOnly = false;
			this.m_dtpAuto.Size = new System.Drawing.Size(144, 22);
			this.m_dtpAuto.TabIndex = 42;
			this.m_dtpAuto.TextBackColor = System.Drawing.Color.White;
			this.m_dtpAuto.TextForeColor = System.Drawing.Color.Black;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 19);
			this.label1.TabIndex = 43;
			this.label1.Text = "滚费日期：";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
			this.label2.Location = new System.Drawing.Point(46, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(210, 23);
			this.label2.TabIndex = 44;
			this.label2.Text = "附：滚费时刻为“23:59:59”";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmHandworkContinuousOrder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(328, 149);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_dtpAuto);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cmdAutoCharge);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmHandworkContinuousOrder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "手工执行连续医嘱滚费";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHandworkContinuousOrder_KeyDown);
			this.Load += new System.EventHandler(this.frmHandworkContinuousOrder_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_HandworkContinuousOrder();
			objController.Set_GUI_Apperance(this);
		}

		#region 窗体事件
		private void frmHandworkContinuousOrder_Load(object sender, System.EventArgs e)
		{
			m_objLoginInfo = this.LoginInfo;
			((clsCtl_HandworkContinuousOrder)this.objController).m_strOperatorID =m_objLoginInfo.m_strEmpID;
			((clsCtl_HandworkContinuousOrder)this.objController).m_strOperatorName =m_objLoginInfo.m_strEmpName;
			((clsCtl_HandworkContinuousOrder)this.objController).m_LoadMoneyForContinuousOrder();
		}

		private void frmHandworkContinuousOrder_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.F5://查询
					if(m_cmdAutoCharge.Enabled && m_cmdAutoCharge.Visible) m_cmdAutoCharge_Click(sender,e);
					break;
			}
		}
		#endregion

		#region 按钮事件
		private void m_cmdAutoCharge_Click(object sender, System.EventArgs e)
		{
			((clsCtl_HandworkContinuousOrder)this.objController).m_AutoCumulateMoneyForContinuousOrder();
		}
		#endregion
	}
}
