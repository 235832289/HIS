using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder.Control
{
	/// <summary>
	/// frmListView 的摘要说明。
	/// </summary>
	public class frmListView : System.Windows.Forms.Form
	{
		public System.Windows.Forms.ListView m_objListView;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmListView()
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
			this.m_objListView = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// m_objListView
			// 
			this.m_objListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_objListView.FullRowSelect = true;
			this.m_objListView.GridLines = true;
			this.m_objListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_objListView.Location = new System.Drawing.Point(8, 12);
			this.m_objListView.MultiSelect = false;
			this.m_objListView.Name = "m_objListView";
			this.m_objListView.Size = new System.Drawing.Size(108, 124);
			this.m_objListView.TabIndex = 0;
			this.m_objListView.View = System.Windows.Forms.View.Details;
			// 
			// frmListView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(228, 168);
			this.Controls.Add(this.m_objListView);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmListView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "frmListView";
			this.Deactivate += new System.EventHandler(this.frmListView_Deactivate);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmListView_Deactivate(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
