using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// frmImageList 的摘要说明。
	/// </summary>
	public class frmImageList : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList m_imgMenu;
		private System.ComponentModel.IContainer components;

		public frmImageList()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImageList));
			this.m_imgMenu = new System.Windows.Forms.ImageList(this.components);
			// 
			// m_imgMenu
			// 
			this.m_imgMenu.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgMenu.ImageStream")));
			this.m_imgMenu.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmImageList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "frmImageList";
			this.Text = "frmImageList";

		}
		#endregion

		public ImageList m_ImgMenu
		{
			get
			{
				return m_imgMenu;
			}
		}
	}
}
