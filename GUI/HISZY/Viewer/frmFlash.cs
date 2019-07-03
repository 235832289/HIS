using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// Flash窗口
    /// </summary>
    public partial class frmFlash : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmFlash()
        {
            InitializeComponent();
        }

        private string Info = "";
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Information
        {
            get
            {
                return Info;
            }
            set
            {
                Info = value;
            }
        }

        private void frmFlash_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
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
            Font font = new Font("SimSun", 10);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            if (e.Graphics.MeasureString(Info, font).Width > 180)
            {
                string str1 = Info.Substring(0, 14);
                string str2 = Info.Substring(14);
                if (str2.Length > 14)
                {
                    e.Graphics.DrawString(
                        str1,
                        font, solidBrush,
                        new PointF(10, 2));
                    string str3 = str2.Substring(0, 14);
                    string str4 = str2.Substring(14);
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
                    Info,
                    font, solidBrush,
                    new PointF(10, 10));
            }
        }

        private int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {               
                this.timer1.Interval = 15;
                i = 1;
            }

            this.Opacity -= 0.01;
            if (this.Opacity < 0.02)
            {
                this.timer1.Enabled = false;
                this.Close();
            }
        }
    }
}