using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.controls;

namespace iCare
{
	/// <summary>
	/// 设置自定义DataGrid列头名
	/// </summary>
	public class frmSetCustomDataGridColumn : System.Windows.Forms.Form
	{
		private PinkieControls.ButtonXP m_cmdChangeTime;
		private PinkieControls.ButtonXP m_cmdCancel;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox m_txtSetName;
		private string m_strSetName = "";
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSetCustomDataGridColumn(string p_strColumnName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_txtSetName.Text = p_strColumnName;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSetCustomDataGridColumn));
			this.m_cmdChangeTime = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtSetName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// m_cmdChangeTime
			// 
			this.m_cmdChangeTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdChangeTime.DefaultScheme = true;
			this.m_cmdChangeTime.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdChangeTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdChangeTime.Hint = "";
			this.m_cmdChangeTime.Location = new System.Drawing.Point(36, 48);
			this.m_cmdChangeTime.Name = "m_cmdChangeTime";
			this.m_cmdChangeTime.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdChangeTime.Size = new System.Drawing.Size(80, 32);
			this.m_cmdChangeTime.TabIndex = 10000022;
			this.m_cmdChangeTime.Tag = "1";
			this.m_cmdChangeTime.Text = "确定";
			this.m_cmdChangeTime.Click += new System.EventHandler(this.m_cmdChangeTime_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(156, 48);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(80, 32);
			this.m_cmdCancel.TabIndex = 10000021;
			this.m_cmdCancel.Tag = "1";
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 19);
			this.label1.TabIndex = 10000023;
			this.label1.Text = "设置该列的列名为:";
			// 
			// m_txtSetName
			// 
			this.m_txtSetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtSetName.Location = new System.Drawing.Point(140, 12);
			this.m_txtSetName.MaxLength = 25;
			this.m_txtSetName.Name = "m_txtSetName";
			this.m_txtSetName.Size = new System.Drawing.Size(108, 21);
			this.m_txtSetName.TabIndex = 10;
			this.m_txtSetName.Text = "";
			// 
			// frmSetCustomDataGridColumn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(280, 95);
			this.Controls.Add(this.m_txtSetName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_cmdChangeTime);
			this.Controls.Add(this.m_cmdCancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSetCustomDataGridColumn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设置自定义列名";
			this.Load += new System.EventHandler(this.frmSetCustomDataGridColumn_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdChangeTime_Click(object sender, System.EventArgs e)
		{
			m_strSetName = this.m_txtSetName.Text.ToString ();
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}

		private void frmSetCustomDataGridColumn_Load(object sender, System.EventArgs e)
		{
			this.m_txtSetName.Focus();
		}

		public string m_StrSetName
		{
			get{return m_strSetName;}
            set { m_strSetName = value; }
		}
	}
}
