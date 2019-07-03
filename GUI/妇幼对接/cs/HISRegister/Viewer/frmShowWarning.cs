using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;  
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmShowWarning 的摘要说明。
	/// </summary>
	public class frmShowWarning : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public frmShowWarning()
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmShowWarning
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(248, 75);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmShowWarning";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "frmShowWarning";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmShowWarning_Paint);

		}
		#endregion
		string strWaring="";
		public string m_GetWaring
		{
			set
			{
				strWaring=value;
			}
			get
			{
				return strWaring;
			}
		}

		private void frmShowWarning_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics ; 
			Point[] polyPoints = {
									 new Point(10, 0),
									 new Point(200, 0), 
									 new Point(200, 50),
									 new Point(100, 50),
									 new Point(100, 75),
									 new Point(80, 50),
									 new Point(10, 50),
									 new Point(10, 0)};
			GraphicsPath path = new GraphicsPath();
			path.AddPolygon(polyPoints);
			Region region = new Region(path);
			PathGradientBrush pgb = new PathGradientBrush(path); 
			pgb.SurroundColors = new Color[] { System.Drawing.SystemColors.Info,System.Drawing.SystemColors.Info, System.Drawing.SystemColors.Info, 
												 System.Drawing.SystemColors.Info, System.Drawing.SystemColors.Info}; 
			g.FillPath(pgb, path); 
			Pen pen = Pens.Black;
			e.Graphics.DrawPath(pen, path);

			e.Graphics.SetClip(region, CombineMode.Replace);
			Font font=new Font("SimSun",10);
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
			if(e.Graphics.MeasureString(strWaring,font).Width>180)
			{
				string str1=strWaring.Substring(0,14);
				string str2=strWaring.Substring(14);
				if(str2.Length>14)
				{
					e.Graphics.DrawString(
						str1,
						font, solidBrush,
						new PointF(10, 2));
					string str3=str2.Substring(0,14);
					string str4=str2.Substring(14);
					e.Graphics.DrawString(
						str3,
						font, solidBrush,
						new PointF(10, 18));
					e.Graphics.DrawString(
						str4,
						font, solidBrush,
						new PointF(10, 35));
				}
				else
				{
					e.Graphics.DrawString(
						str1,
						font, solidBrush,
						new PointF(10, 10));
					e.Graphics.DrawString(
						str2,
						font, solidBrush,
						new PointF(10, 30));
				}
			}
			else
			{
				e.Graphics.DrawString(
					strWaring,
					font, solidBrush,
					new PointF(10, 10));
			}
		}
		int i=0;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(i==0)
			{
				this.timer1.Interval=10;
				i=1;
			}
			
			this.Opacity -=0.01;
			if(this.Opacity<0.02)
			{
				this.timer1.Enabled=false;
				this.Close();
			}
		}
	}
}
