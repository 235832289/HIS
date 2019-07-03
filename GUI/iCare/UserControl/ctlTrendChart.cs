using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Forms.Design;

namespace com.digitalwave.Utility.ctlTrendViewer
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class ctlTrendChart : System.Windows.Forms.UserControl
	{
		#region Control Defination
		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ToolTip ttpInfo;
		private System.Windows.Forms.Panel pnlChart;
		private System.Windows.Forms.PictureBox picChart;
		private System.Windows.Forms.Panel pnlRight;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		public ctlTrendChart()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();	
			
			this.picChart.Height = m_intChartHeight;
			this.picChart.Width = m_intChartWidth;
		}
		#endregion

		#region Member
		private bool m_boolShowAlarm = true;

		/// <summary>
		/// Trend Chart 的实际宽度
		/// </summary>
		private int m_intChartWidth = 954;

		/// <summary>
		/// Trend Chart 的实际高度, 至少为300
		/// </summary>
		private int m_intChartHeight = c_intNormalChartHeight;

		private const int c_intNormalChartHeight = 300;

		/// <summary>
		/// 坐标和参数的宽度
		/// </summary>
		private int m_intCoordernateWidth = 352;

		/// <summary>
		/// 时间栏的高度
		/// </summary>
		private int m_intDateTimeHeight = 35;

		/// <summary>
		/// Trend Chart 到底边框的距离
		/// </summary>
		private const int c_intToButtom = 10;

		/// <summary>
		/// Trend Chart 到顶边框的距离
		/// </summary>
		private const int c_intToTop = 2;

		/// <summary>
		/// Trend Chart 到左边框的距离
		/// </summary>
		private const int c_intToLeft = 2;

		/// <summary>
		/// Trend Chart 到右边框的距离
		/// </summary>
		private const int c_intToRight = 2;

		/// <summary>
		/// Trend Chart 每格的宽度，默认为120像素
		/// </summary>
		private int m_intGridWidth = 120;

		/// <summary>
		/// Trend Chart 的格数,至少为5格
		/// </summary>
		private int m_intGridCount = 5;

		/// <summary>
		/// Trend Chart 格线的颜色
		/// </summary>
		private Color m_clrChartColor = Color.Black;

		/// <summary>
		/// 时间的颜色
		/// </summary>
		private Color m_clrDateColor = Color.Black;

		/// <summary>
		/// 显示方式
		/// </summary>
		private enmDisplay m_enmDisplay = enmDisplay.Mixed;

		/// <summary>
		/// 分辨率
		/// </summary>
		private enmResolution m_enmResolution = enmResolution.Five_Minute;

		/// <summary>
		/// 开始时间
		/// </summary>
		private DateTime m_dtmStartDate = DateTime.Now;

		/// <summary>
		/// 总的趋势时间
		/// </summary>
		private int m_intTotalTime = 25;

		/// <summary>
		/// 一个参数的宽度
		/// </summary>
		private int m_intParamWidth = 120;

		/// <summary>
		/// 一个参数的高度
		/// </summary>
		private int m_intParamHeight = 15;

		/// <summary>
		/// 趋势图的背景色，默认为白色
		/// </summary>
		private Color m_clrCharBackColor = Color.White;

		#endregion

		#region Dispose
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.ttpInfo = new System.Windows.Forms.ToolTip(this.components);
			this.pnlChart = new System.Windows.Forms.Panel();
			this.picChart = new System.Windows.Forms.PictureBox();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.pnlTitle.SuspendLayout();
			this.pnlChart.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTitle
			// 
			this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTitle.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lblTitle});
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Size = new System.Drawing.Size(28, 176);
			this.pnlTitle.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(26, 174);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "趋势图表";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ttpInfo
			// 
			this.ttpInfo.AutoPopDelay = 5000;
			this.ttpInfo.InitialDelay = 500;
			this.ttpInfo.ReshowDelay = 100;
			// 
			// pnlChart
			// 
			this.pnlChart.AutoScroll = true;
			this.pnlChart.AutoScrollMinSize = new System.Drawing.Size(100, 0);
			this.pnlChart.BackColor = System.Drawing.Color.White;
			this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlChart.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.picChart});
			this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlChart.Name = "pnlChart";
			this.pnlChart.Size = new System.Drawing.Size(676, 176);
			this.pnlChart.TabIndex = 1;
			// 
			// picChart
			// 
			this.picChart.BackColor = System.Drawing.Color.White;
			this.picChart.Name = "picChart";
			this.picChart.Size = new System.Drawing.Size(608, 136);
			this.picChart.TabIndex = 0;
			this.picChart.TabStop = false;
			this.picChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picChart_Paint);
			this.picChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picChart_MouseMove);
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.pnlChart});
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRight.Location = new System.Drawing.Point(28, 0);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Size = new System.Drawing.Size(676, 176);
			this.pnlRight.TabIndex = 2;
			// 
			// ctlTrendChart
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlRight,
																		  this.pnlTitle});
			this.Name = "ctlTrendChart";
			this.Size = new System.Drawing.Size(704, 176);
			this.pnlTitle.ResumeLayout(false);
			this.pnlChart.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Method
		private void picChart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			m_mthDrawChart(e.Graphics);

			if(m_blnShowParam)
			{
				m_mthDrawParams(e.Graphics);

				if(m_blnShowTrend)
					m_mthDrawParamsValue(e.Graphics);
			}
		}


		/// <summary>
		/// 画表格
		/// </summary>
		/// <param name="p_objGraphic"></param>
		private void m_mthDrawChart(Graphics p_objGraphic)
		{
			#region 画笔, 画刷
			Pen objSolidPen = new Pen(m_clrChartColor);

			Pen objDashPen = new Pen(m_clrChartColor);
			objDashPen.DashStyle = DashStyle.Dash;

			SolidBrush objBrush = new SolidBrush(m_clrDateColor);
			#endregion

			#region 画格线
			int intCharRectX = m_intCoordernateWidth;
			int intCharRectY = c_intToTop * 5 + m_intDateTimeHeight;
			int intCharRectWidth = m_intChartWidth - m_intCoordernateWidth - c_intToRight;
			int intChartRectHeight = m_intChartHeight - intCharRectY - c_intToButtom;
			m_intChartRectHeight = intChartRectHeight;
			m_intCharRectY = intCharRectY;
			m_intCharRectX = intCharRectX;
			
			//画Trend Chart 的外框
			p_objGraphic.DrawRectangle(objSolidPen,intCharRectX, intCharRectY, intCharRectWidth, intChartRectHeight);

			//画Trend Chart 的竖线
			for(int i = 1; i <= m_intGridCount; i++)
			{
				p_objGraphic.DrawLine(objSolidPen,intCharRectX + m_intGridWidth * i,intCharRectY, intCharRectX + m_intGridWidth * i, intCharRectY + intChartRectHeight);
			}

			//画横线
			for(int i = 1; i < 4; i++)
			{
				p_objGraphic.DrawLine(objDashPen, intCharRectX, intCharRectY + intChartRectHeight * i/ 4, intCharRectX + intCharRectWidth,intCharRectY + intChartRectHeight * i/ 4);
			}
			#endregion

			#region 画坐标
			//画坐标 -- 每个坐标之间的距离为50像素
			for(int i = 0; i < 3; i++)
			{
				p_objGraphic.DrawLine(objSolidPen,intCharRectX - 10 - i * 50, intCharRectY, intCharRectX - 10 - i * 50, intCharRectY + intChartRectHeight);
			}

			//画坐标的刻度
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < 5; j++)
				{
					if(j % 2 == 0)
						p_objGraphic.DrawLine(objSolidPen, intCharRectX - 10 - i * 50 - 5, intCharRectY + intChartRectHeight * j/ 4, intCharRectX - 10 - i * 50,intCharRectY + intChartRectHeight * j/ 4);
					else
						p_objGraphic.DrawLine(objSolidPen, intCharRectX - 10 - i * 50 - 3, intCharRectY + intChartRectHeight * j/ 4, intCharRectX - 10 - i * 50,intCharRectY + intChartRectHeight * j/ 4);
				}
			}
			#endregion

			#region 画时间
			//画时间外框
			p_objGraphic.DrawRectangle(objSolidPen,c_intToTop,c_intToLeft,m_intChartWidth - c_intToRight - c_intToLeft, m_intDateTimeHeight);

			//画竖线
			for(int i = -1; i <= m_intGridCount; i++)
			{
				p_objGraphic.DrawLine(objSolidPen,intCharRectX + i * m_intGridWidth,c_intToTop,intCharRectX + i * m_intGridWidth, c_intToTop + m_intDateTimeHeight);
				
				switch(m_enmResolution)
				{
					case enmResolution.Five_Minute:
						p_objGraphic.DrawString(m_dtmStartDate.AddMinutes(5 * (i + 1)).ToString("yy-MM-dd HH:mm"),new Font("SimSun",10),objBrush,intCharRectX + i * m_intGridWidth + 10,c_intToTop + 10);
						break;

					case enmResolution.One_Minute:
						p_objGraphic.DrawString(m_dtmStartDate.AddMinutes(1 * (i + 1)).ToString("yy-MM-dd HH:mm"),new Font("SimSun",10),objBrush,intCharRectX + i * m_intGridWidth + 10,c_intToTop + 10);
						break;

					case enmResolution.Thirty_Minute:
						p_objGraphic.DrawString(m_dtmStartDate.AddMinutes(30 * (i + 1)).ToString("yy-MM-dd HH:mm"),new Font("SimSun",10),objBrush,intCharRectX + i * m_intGridWidth + 10,c_intToTop + 10);
						break;

					case enmResolution.One_Hour:
						p_objGraphic.DrawString(m_dtmStartDate.AddMinutes(60 * (i + 1)).ToString("yy-MM-dd HH:mm"),new Font("SimSun",10),objBrush,intCharRectX + i * m_intGridWidth + 10,c_intToTop + 10);
						break;
				}
			}
			#endregion
		}

		/// <summary>
		/// 画参数
		/// </summary>
		/// <param name="p_objGraphic"></param>
		private void m_mthDrawParams(Graphics p_objGraphic)
		{
			
			Font fntParams = new Font("SimSun",10,FontStyle.Bold);

			for(int i = 0; i < m_objGroupSetArr.Length; i++)
			{
				if(m_objGroupSetArr[i] != null)
				{
					//画参数名
					p_objGraphic.DrawString(m_objGroupSetArr[i].m_strParamLabel, fntParams,new SolidBrush(m_objGroupSetArr[i].m_clrColor),10,m_intDateTimeHeight + 20 + i * m_intParamHeight);

					//画单位描述
					p_objGraphic.DrawString(m_objGroupSetArr[i].m_strUnitDesc, fntParams,new SolidBrush(m_objGroupSetArr[i].m_clrColor),10 + m_intParamWidth,m_intDateTimeHeight + 20 + i * m_intParamHeight);

					//画标记
					switch(m_objGroupSetArr[i].m_intScaleNumber)
					{
						case 0:
							m_mthDrawMarker(p_objGraphic,new PointF(m_intCharRectX - 10 - 0 * 50 - 10,m_intDateTimeHeight + 20 + i * m_intParamHeight + 5), m_objGroupSetArr[i].m_intMarkerIndex,m_objGroupSetArr[i].m_clrColor);
							break;

						case 1:
							m_mthDrawMarker(p_objGraphic,new PointF(m_intCharRectX - 10 - 1 * 50 - 10,m_intDateTimeHeight + 20 + i * m_intParamHeight + 5), m_objGroupSetArr[i].m_intMarkerIndex,m_objGroupSetArr[i].m_clrColor);
							break;

						case 2:
							m_mthDrawMarker(p_objGraphic,new PointF(m_intCharRectX - 10 - 2 * 50 - 10,m_intDateTimeHeight + 20 + i * m_intParamHeight + 5), m_objGroupSetArr[i].m_intMarkerIndex,m_objGroupSetArr[i].m_clrColor);
							break;
					}
					
				}
			}


			if(m_objGroupSetArr[0] != null)
			{
				SolidBrush objBrush = new SolidBrush(m_clrChartColor);
				//坐标0 的刻度
				p_objGraphic.DrawString(m_strScaleValueArr[0],fntParams,objBrush,m_intCharRectX - 10 - 0 * 50 - 50, m_intCharRectY);
				p_objGraphic.DrawString(m_strScaleValueArr[1],fntParams,objBrush,m_intCharRectX - 10 - 0 * 50 - 50, m_intCharRectY + m_intChartRectHeight - 10);

				//坐标1 的刻度
				p_objGraphic.DrawString(m_strScaleValueArr[2].ToString().PadLeft(5,' '),fntParams,objBrush,m_intCharRectX - 10 - 1 * 50 - 50, m_intCharRectY);
				p_objGraphic.DrawString(m_strScaleValueArr[3].ToString().PadLeft(5,' '),fntParams,objBrush,m_intCharRectX - 10 - 1 * 50 - 50, m_intCharRectY + m_intChartRectHeight - 10);

				//坐标2 的刻度
				p_objGraphic.DrawString(m_strScaleValueArr[4].ToString().PadLeft(5,' '),fntParams,objBrush,m_intCharRectX - 10 - 2 * 50 - 50, m_intCharRectY);
				p_objGraphic.DrawString(m_strScaleValueArr[5].ToString().PadLeft(5,' '),fntParams,objBrush,m_intCharRectX - 10 - 2 * 50 - 50, m_intCharRectY + m_intChartRectHeight - 10);
			}
		}

		/// <summary>
		/// 画坐标值
		/// </summary>
		/// <param name="p_objGraphic"></param>
		private void m_mthDrawParamsValue(Graphics p_objGraphic)
		{
			try
			{
				if(m_objParamValueArr != null)
				{
					for(int i = 0 ; i < m_objParamValueArr.Length; i ++)
					{
						if(m_objParamValueArr[i] != null)
						{
							clsVitalGroupSet objVitalGroupSet = m_objParamValueArr[i].m_objVitalGroupSet;

							if(objVitalGroupSet != null)
							{
								Pen objPenLine = new Pen(objVitalGroupSet.m_clrColor);
								PointF[] pnfValueArr = (PointF[])m_objParamValueArr[i].m_arlValue.ToArray(typeof(PointF));

								if(pnfValueArr == null || pnfValueArr.Length == 0)
									continue;

								switch(m_EnmDisplay) //显示方式
								{
									case enmDisplay.Continues: //连续
										if(pnfValueArr.Length > 1)
											p_objGraphic.DrawLines(objPenLine,pnfValueArr);
										break;

									case enmDisplay.Scatter: //离散
										for(int j = 0; j < pnfValueArr.Length; j++)
										{
											m_mthDrawMarker(p_objGraphic, pnfValueArr[j],objVitalGroupSet.m_intMarkerIndex,objVitalGroupSet.m_clrColor);
										}
										break;

									case enmDisplay.Mixed: //混合
										for(int j = 0; j < pnfValueArr.Length; j++)
										{
											m_mthDrawMarker(p_objGraphic, pnfValueArr[j],objVitalGroupSet.m_intMarkerIndex,objVitalGroupSet.m_clrColor);
										}
										if(pnfValueArr.Length > 1)
											p_objGraphic.DrawLines(objPenLine,pnfValueArr);
										break;
								}
							}
						}
					}//end for
				}
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
		}

		/// <summary>
		/// 鼠标移动到点上时，显示该点的值和采集时间，只对离散和混合的显示方式有效
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picChart_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnShowTrend)
				return;

			if(m_enmDisplay == enmDisplay.Continues)
				return;

			string strToolTipText = "";

			if(m_objParamValueArr != null)
			{
				for(int i = 0 ; i < m_objParamValueArr.Length; i++)
				{
					if(m_objParamValueArr[i] != null)
					{
						PointF[] pnfValueArr = (PointF[])m_objParamValueArr[i].m_arlValue.ToArray(typeof(PointF));

						for(int j = 0; j < pnfValueArr.Length; j++)
						{
							//判断鼠标的位置是否在点的范围内
							if(e.X >= pnfValueArr[j].X - 2 && e.X <= pnfValueArr[j].X + 2 && e.Y >= pnfValueArr[j].Y - 2 && e.Y <= pnfValueArr[j].Y + 2)
							{
								clsVitalGroupSet objVitalGroup = m_objParamValueArr[i].m_objVitalGroupSet;
								clsTrendValue objTrendValue = (clsTrendValue)m_objParamValueArr[i].m_arlTrendValue[j];

								if(objVitalGroup == null || objTrendValue == null)
									continue;

								strToolTipText += objVitalGroup.m_strParamLabel + " : "  ;
								strToolTipText += objTrendValue.m_fltValue.ToString() + "  ";
								strToolTipText += objVitalGroup.m_strUnitDesc + "\r\n";
								strToolTipText += "采集时间：" + objTrendValue.m_dtmStoreDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
							}
						}
					} //end for j
				}//end for i

				if(strToolTipText != null && strToolTipText != "")
					ttpInfo.SetToolTip(this.picChart,strToolTipText);
			}
		}
		#endregion

		#region  [Properties] 
		public bool m_BlnShowAlarm
		{
			get
			{
				return m_boolShowAlarm;
			}
			set
			{
				m_boolShowAlarm = value;
				this.picChart.Invalidate();
			}
		}
		/// <summary>
		/// Trend Chart 的网格线颜色
		/// </summary>
		public Color m_ClrChartColor
		{
			get
			{
				return m_clrChartColor;
			}
			set
			{
				m_clrChartColor = value;
				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}

		/// <summary>
		/// 趋势图的背静色
		/// </summary>
		public Color m_ClrChartBackColor
		{
			get
			{
				return m_clrCharBackColor;
			}
			set
			{
				m_clrCharBackColor = value;

				this.picChart.BackColor = m_clrCharBackColor;
				this.pnlChart.BackColor = m_clrCharBackColor;
			}
		}

		/// <summary>
		/// 时间的颜色
		/// </summary>
		public Color m_ClrDateColor
		{
			get
			{
				return m_clrDateColor;
			}
			set
			{
				m_clrDateColor = value;
				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}

		/// <summary>
		/// 显示方式
		/// </summary>
		public enmDisplay m_EnmDisplay
		{
			get
			{
				return m_enmDisplay;
			}
			set
			{
				m_enmDisplay = value;
				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}

		/// <summary>
		/// 分辨率
		/// </summary>
		public enmResolution m_EnmResolution
		{
			get
			{
				return m_enmResolution;
			}
			set
			{
				m_enmResolution = value;

				m_intGridCount = (m_intTotalTime/(int)m_enmResolution) > 5 ? (m_intTotalTime/(int)m_enmResolution) : 5;

				m_intChartWidth = m_intGridCount * m_intGridWidth + m_intCoordernateWidth + c_intToRight;

				this.picChart.Width = m_intChartWidth;

				if(m_objTrendValueArr != null)
					m_mthShowParamValue(m_objTrendValueArr);
				
				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}

		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime m_DtmStartDate
		{
			get
			{
				return m_dtmStartDate;
			}
			set
			{
				m_dtmStartDate = value;
				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}


		/// <summary>
		/// 总的趋势时间
		/// </summary>
		public int m_IntTotalTime
		{
			get
			{
				return m_intTotalTime;
			}
			set
			{
				m_intTotalTime = value;

				m_intGridCount = (m_intTotalTime/(int)m_enmResolution) > 5 ? (m_intTotalTime/(int)m_enmResolution) : 5;

				m_intChartWidth = m_intGridCount * m_intGridWidth + m_intCoordernateWidth + c_intToRight;

				this.picChart.Width = m_intChartWidth;

				this.picChart.Invalidate();
				this.picChart.Update();
			}
		}


		#endregion

		#region Public Method

		private bool m_blnShowParam = false;

		private clsVitalGroupSet[] m_objGroupSetArr;

		/// <summary>
		/// [0:Max0][1:Min0][2:Max1][3:Min1][4:Max2][5:Min2]
		/// </summary>
		private string[] m_strScaleValueArr = new string[6];

		private clsTrendValue[] m_objTrendValueArr;

		/// <summary>
		/// 显示参数的名称、单位和图标
		/// </summary>
		/// <param name="p_objGroupSetArr"></param>
		public void m_mthShowParamDesc(clsVitalGroupSet[] p_objGroupSetArr)
		{
			m_blnShowParam = false;

			if(p_objGroupSetArr != null)
			{
				m_objGroupSetArr = p_objGroupSetArr;
				m_blnShowParam = true;

				m_strScaleValueArr[0] = m_objGroupSetArr[0].m_intMaxScale0.ToString().PadLeft(5,' ');
				m_strScaleValueArr[1] = m_objGroupSetArr[0].m_intMinScale0.ToString().PadLeft(5,' ');
				m_strScaleValueArr[2] = m_objGroupSetArr[0].m_intMaxScale1.ToString().PadLeft(5,' ');
				m_strScaleValueArr[3] = m_objGroupSetArr[0].m_intMinScale1.ToString().PadLeft(5,' ');
				m_strScaleValueArr[4] = m_objGroupSetArr[0].m_intMaxScale2.ToString().PadLeft(5,' ');
				m_strScaleValueArr[5] = m_objGroupSetArr[0].m_intMinScale2.ToString().PadLeft(5,' ');


				int intNewHeight = m_objGroupSetArr.Length * m_intParamHeight + m_intDateTimeHeight + c_intToTop + c_intToButtom;
				if(intNewHeight < c_intNormalChartHeight)
					intNewHeight = c_intNormalChartHeight;

//				m_intChartHeight = (intNewHeight > m_intChartHeight) ? intNewHeight : m_intChartHeight;
				m_intChartHeight = intNewHeight;

				this.picChart.Height = m_intChartHeight;

				picChart.Invalidate();
				picChart.Update();
			}
		}


		/// <summary>
		/// 存储每个参数的信息
		/// </summary>
		private clsParamValue[]  m_objParamValueArr ;

		private bool m_blnShowTrend = false;

		/// <summary>
		/// 显示参数的值
		/// </summary>
		/// <param name="p_objTrendValueArr">参数的值，时间为 X 轴坐标, 值为 Y 轴坐标</param>
		public void m_mthShowParamValue(clsTrendValue[] p_objTrendValueArr)
		{
			m_blnShowTrend = false;

			m_objTrendValueArr = p_objTrendValueArr;

			if(m_objGroupSetArr == null && m_objGroupSetArr.Length == 0)
				return;

			
			m_objParamValueArr = new clsParamValue[m_objGroupSetArr.Length];

			if(p_objTrendValueArr != null && p_objTrendValueArr.Length != 0)
			{
				for(int i = 0; i < m_objGroupSetArr.Length; i ++)
				{
					m_objParamValueArr[i] = new clsParamValue();
					m_objParamValueArr[i].m_objVitalGroupSet = m_objGroupSetArr[i];

					for(int j = 0; j < p_objTrendValueArr.Length; j++)
					{
						if(p_objTrendValueArr[j] == null || m_objGroupSetArr[i] == null)
							continue;

						if(p_objTrendValueArr[j].m_intEMFCID == m_objGroupSetArr[i].m_intEMFCID)
						{
							m_objParamValueArr[i].m_arlTrendValue.Add(p_objTrendValueArr[j]);

							#region 计算参数的实际坐标值
							float fltX = 0; //X轴坐标 
							float fltY = 0; //Y轴坐标

							TimeSpan tmsDiff = p_objTrendValueArr[j].m_dtmStoreDate - m_dtmStartDate;

							float fltTotalMinute = (float)tmsDiff.TotalMinutes;

							fltX = m_fltCalX(fltTotalMinute);

							float fltMaxScale = 0;
							float fltMinScale = 0;
							switch(m_objGroupSetArr[i].m_intScaleNumber)
							{
								case 0:
									fltMaxScale = (float)m_objGroupSetArr[i].m_intMaxScale0;
									fltMinScale = (float)m_objGroupSetArr[i].m_intMinScale0;
									break;
									
								case 1:
									fltMaxScale = (float)m_objGroupSetArr[i].m_intMaxScale1;
									fltMinScale = (float)m_objGroupSetArr[i].m_intMinScale1;
									break;

								case 2:
									fltMaxScale = (float)m_objGroupSetArr[i].m_intMaxScale2;
									fltMinScale = (float)m_objGroupSetArr[i].m_intMinScale2;
									break;
							}

							fltY = m_fltCalY(p_objTrendValueArr[j].m_fltValue,fltMaxScale,fltMinScale);

							if(fltX >= m_intCharRectX && fltY >= m_intCharRectY && fltY <= (m_intChartRectHeight + m_intCharRectY))
							{
								PointF pnfValue = new PointF(fltX,fltY);

								m_objParamValueArr[i].m_arlValue.Add(pnfValue);
							}
							#endregion

						}//end if
					}//end for j
				}//end for i


				m_blnShowTrend = true;
			}

			this.picChart.Invalidate();
			this.picChart.Update();
		}
		#endregion

		#region 计算坐标值
		/// <summary>
		/// 计算横坐标的值
		/// </summary>
		/// <param name="p_fltXValue">实际的值</param>
		/// <returns>返回坐标值</returns>
		private float m_fltCalX(float p_fltXValue)
		{
			float fltUnitWidth = (float)m_intGridWidth / (float)m_enmResolution;

			float fltX = fltUnitWidth * p_fltXValue + (float)m_intCoordernateWidth;

			return fltX;
		}

		/// <summary>
		/// 趋势图的纵高度
		/// </summary>
		private int m_intChartRectHeight ;

		/// <summary>
		/// 趋势图的起始位置
		/// </summary>
		private int m_intCharRectY;

		/// <summary>
		/// 趋势图的起始位置
		/// </summary>
		private int m_intCharRectX;
		
		/// <summary>
		/// 计算纵坐标的值
		/// </summary>
		/// <param name="p_fltYValue">实际的值</param>
		/// <param name="p_fltMaxScale">Y轴的上限</param>
		/// <param name="p_fltMinScale">Y轴的下限</param>
		/// <returns>返回坐标值</returns>
		private float m_fltCalY(float p_fltYValue, float p_fltMaxScale, float p_fltMinScale)
		{
			float fltUnitHeight = (float)m_intChartRectHeight/(p_fltMaxScale - p_fltMinScale);

			float fltY = ((float)m_intChartRectHeight - fltUnitHeight * (p_fltYValue - p_fltMinScale)) + (float)m_intCharRectY;

			return fltY;
		}
		#endregion

		#region 画标记
		//标记 -- 0：空心正方形  1：实心正方形  2：空心圆  3：*  4: +  5:∧  6:∨

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objGraphic"></param>
        /// <param name="p_pnfPos"></param>
        /// <param name="p_intMarker"></param>
        /// <param name="p_clrParamColor"></param>
		private void m_mthDrawMarker(Graphics p_objGraphic, PointF p_pnfPos, int p_intMarker, Color p_clrParamColor)
		{
			switch(p_intMarker)
			{
				case 0:
					p_objGraphic.DrawRectangle(new Pen(p_clrParamColor), p_pnfPos.X - 2, p_pnfPos.Y - 2, 4, 4);
					break;

				case 2:
					p_objGraphic.DrawEllipse(new Pen(p_clrParamColor), p_pnfPos.X - 2, p_pnfPos.Y - 2, 4, 4);
					break;

				case 1:
					p_objGraphic.FillRectangle(new SolidBrush(p_clrParamColor),p_pnfPos.X - 2,p_pnfPos.Y - 2,5,5);
					break;

				case 3:
					p_objGraphic.DrawString("*", new Font("SimSun",10), new SolidBrush(p_clrParamColor),new RectangleF(p_pnfPos.X - 8,p_pnfPos.Y - 8, 16, 16));
					break;

				case 4:
					p_objGraphic.DrawString("+", new Font("SimSun",10,FontStyle.Bold), new SolidBrush(p_clrParamColor),new RectangleF(p_pnfPos.X - 8,p_pnfPos.Y - 8, 16, 16));
					break;

				case 5:
					p_objGraphic.DrawString("∧", new Font("SimSun",6), new SolidBrush(p_clrParamColor),new RectangleF(p_pnfPos.X - 2,p_pnfPos.Y - 2, 16, 16));
					break;

				case 6:
					p_objGraphic.DrawString("∨", new Font("SimSun",6), new SolidBrush(p_clrParamColor),new RectangleF(p_pnfPos.X - 2,p_pnfPos.Y - 2, 16, 16));
					break;
			}
		}
		#endregion

		/// <summary>
		/// 清空参数值
		/// </summary>
		public void m_mthClearParam()
		{
			m_objParamValueArr = null;

			this.picChart.Invalidate();
			this.picChart.Update();
		}
	}


	#region [枚举和类]
	/// <summary>
	/// 分辨率
	/// </summary>
	public enum enmResolution
	{
		One_Minute = 1,
		Five_Minute = 5,
		Thirty_Minute = 30,
		One_Hour = 60
	}

	/// <summary>
	/// 显示
	/// </summary>
	public enum enmDisplay
	{
		Scatter,
		Continues,
		Mixed 
	}

	/// <summary>
	/// 参数组的信息（包括参数的信息）
	/// </summary>
	public class clsVitalGroupSet
	{
		public int m_intGroupID;
		public string m_strGroupName;

		/// <summary>
		/// EMFC_ID 是标示参数的ID
		/// </summary>
		public int m_intEMFCID;
		public string m_strParamLabel;
		public string m_strParamLabelDesc;

		public int m_intUnitID;
		public string m_strUnitDesc;

		public int m_intMaxScale0;
		public int m_intMinScale0;

		public int m_intMaxScale1;
		public int m_intMinScale1;

		public int m_intMaxScale2;
		public int m_intMinScale2;

		public int m_intScaleNumber;

		public int m_intMarkerIndex;

		public int m_intMaxAlarm;

		public int m_intMinAlarm;

		public Color m_clrColor = Color.Green;
	}

	/// <summary>
	/// 趋势的数据
	/// </summary>
	public class clsTrendValue
	{
		public int m_intEMFCID;

		public DateTime m_dtmStoreDate;

		public float m_fltValue;
	}

	/// <summary>
	/// 参数的值
	/// </summary>
	internal class clsParamValue
	{
		/// <summary>
		/// PointF类型的object,实际的坐标值
		/// </summary>
		public ArrayList m_arlValue = new ArrayList();

		/// <summary>
		/// clsTrendValue类型的object
		/// </summary>
		public ArrayList m_arlTrendValue = new ArrayList();

		public clsVitalGroupSet m_objVitalGroupSet;
	}
	#endregion
}
