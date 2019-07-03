using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCreatePlanByDate 的摘要说明。
	/// </summary>
	public class frmCreatePlanByDate :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP buttonXP2;
		internal System.Windows.Forms.DateTimePicker m_DTPStart;
		internal System.Windows.Forms.DateTimePicker m_DTPEnd;
		private System.Windows.Forms.Label m_lb;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreatePlanByDate()
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.m_DTPStart = new System.Windows.Forms.DateTimePicker();
			this.m_DTPEnd = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.m_btnSave = new PinkieControls.ButtonXP();
			this.buttonXP2 = new PinkieControls.ButtonXP();
			this.m_lb = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "开始日期";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_DTPStart
			// 
			this.m_DTPStart.Location = new System.Drawing.Point(80, 16);
			this.m_DTPStart.Name = "m_DTPStart";
			this.m_DTPStart.Size = new System.Drawing.Size(120, 23);
			this.m_DTPStart.TabIndex = 2;
			// 
			// m_DTPEnd
			// 
			this.m_DTPEnd.Location = new System.Drawing.Point(80, 48);
			this.m_DTPEnd.Name = "m_DTPEnd";
			this.m_DTPEnd.Size = new System.Drawing.Size(120, 23);
			this.m_DTPEnd.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "结束日期";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btnSave
			// 
			this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnSave.DefaultScheme = true;
			this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnSave.Hint = "";
			this.m_btnSave.Location = new System.Drawing.Point(24, 88);
			this.m_btnSave.Name = "m_btnSave";
			this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnSave.Size = new System.Drawing.Size(72, 24);
			this.m_btnSave.TabIndex = 5;
			this.m_btnSave.Text = "导入";
			this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
			// 
			// buttonXP2
			// 
			this.buttonXP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP2.DefaultScheme = true;
			this.buttonXP2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonXP2.Hint = "";
			this.buttonXP2.Location = new System.Drawing.Point(128, 88);
			this.buttonXP2.Name = "buttonXP2";
			this.buttonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP2.Size = new System.Drawing.Size(72, 24);
			this.buttonXP2.TabIndex = 6;
			this.buttonXP2.Text = "取消";
			this.buttonXP2.Click += new System.EventHandler(this.buttonXP2_Click);
			// 
			// m_lb
			// 
			this.m_lb.Location = new System.Drawing.Point(9, 8);
			this.m_lb.Name = "m_lb";
			this.m_lb.Size = new System.Drawing.Size(200, 72);
			this.m_lb.TabIndex = 7;
			this.m_lb.Text = "正在导入数据...";
			this.m_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lb.Visible = false;
			// 
			// frmCreatePlanByDate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.buttonXP2;
			this.ClientSize = new System.Drawing.Size(224, 125);
			this.Controls.Add(this.m_lb);
			this.Controls.Add(this.buttonXP2);
			this.Controls.Add(this.m_btnSave);
			this.Controls.Add(this.m_DTPEnd);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_DTPStart);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmCreatePlanByDate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "导入周计划";
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlCreatePlan();
			objController.Set_GUI_Apperance(this);
		}
		private bool IsRefresh=false;
		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			m_lb.Show();
			m_lb.BringToFront();
			long lngRes=((clsControlCreatePlan)this.objController).m_lngCreatePlan(this.m_DTPStart.Value,this.m_DTPEnd.Value);
            if(lngRes>=0)
				this.IsRefresh=true;
			m_lb.Hide();
			this.Cursor=Cursors.Default;
		}
		public bool ShowMe()
		{
			this.m_DTPEnd.Value=DateTime.Now.Date;
			this.m_DTPStart.Value=DateTime.Now.Date;
            this.ShowDialog();
			return this.IsRefresh;
		}

		private void buttonXP2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
