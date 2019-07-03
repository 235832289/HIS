using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices ;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// Form2 的摘要说明。
	/// </summary>
	public class frmShowOverFlow : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public frmShowOverFlow()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmShowOverFlow));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1300;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmShowOverFlow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(168, 104);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.Name = "frmShowOverFlow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "";
			this.TopMost = true;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmShowOverFlow_Closing);
			this.Load += new System.EventHandler(this.frmShowOverFlow_Load);

		}
		#endregion
		int i=0;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.timer1.Enabled=false;
			this.Close();
//			if(i==0)
//			{
//				this.timer1.Interval=10;
//				i=1;
//			}
//			
//			this.Opacity -=0.01;
//			if(this.Opacity<0.02)
//			{
//				this.timer1.Enabled=false;
//				this.Close();
//			}
		}

		private void frmShowOverFlow_Load(object sender, System.EventArgs e)
		{
			Win32.AnimateWindow(this.Handle,500,Win32.AW_SLIDE | Win32.AW_VER_NEGATIVE);
		}

		private void frmShowOverFlow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Win32.AnimateWindow(this.Handle, 500,Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_VER_POSITIVE);
		}

	
	}
	public  class  Win32    
	{    
		public  const  Int32  AW_HOR_POSITIVE  =  0x00000001;    
		public  const  Int32  AW_HOR_NEGATIVE  =  0x00000002;    
		public  const  Int32  AW_VER_POSITIVE  =  0x00000004;    
		public  const  Int32  AW_VER_NEGATIVE  =  0x00000008;    
		public  const  Int32  AW_CENTER  =  0x00000010;    
		public  const  Int32  AW_HIDE  =  0x00010000;    
		public  const  Int32  AW_ACTIVATE  =  0x00020000;    
		public  const  Int32  AW_SLIDE  =  0x00040000;    
		public  const  Int32  AW_BLEND  =  0x00080000;    
		[DllImport("user32.dll",  CharSet=CharSet.Auto)]    
		public  static  extern  bool  AnimateWindow(    
			IntPtr  hwnd,  //  handle  to  window    
			int  dwTime,  //  duration  of  animation    
			int  dwFlags  //  animation  type    
			);    
	}    
}
