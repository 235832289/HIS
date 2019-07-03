using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
//using System.Runtime.InteropServices;
using Static = com.digitalwave.Emr.StaticObject;

namespace iCare
{
	/// <summary>
	/// 打印预览
	/// </summary>
	public class frmPrintPreviewDialogPF : System.Windows.Forms.Form
	{
		#region Variable
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Label m_lblSpliter;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ImageList m_imlToolbar;
		private System.Windows.Forms.Panel m_pnlPrintPreview;
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private System.Windows.Forms.ToolBarButton m_tlbPrint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBar toolBar1;

		/// <summary>
		/// 每英寸多少像素
		/// </summary>
//		private int m_intPixelPerInch;

		/// <summary>
		/// 是否续打
		/// </summary>
		private bool m_blnContinuePrint = false;
		private System.Windows.Forms.RadioButton m_rdbAll;
		private System.Windows.Forms.RadioButton m_rdbSpecify;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown m_nudView;
		private System.Windows.Forms.NumericUpDown m_nudEnd;
		private System.Windows.Forms.NumericUpDown m_nudFrom;
		/// <summary>
		/// 当前打印页
		/// </summary>
		private int m_intCurrentPrintPage = 0;
		private System.Windows.Forms.ToolBarButton m_tlbContinue;
		private System.Windows.Forms.ContextMenu m_ctmContinuePrint;
		private System.Windows.Forms.MenuItem m_mniLine;
		private System.Windows.Forms.MenuItem m_mniArea;
		private System.Windows.Forms.ContextMenu m_ctmClear;
		private System.Windows.Forms.MenuItem m_mniClear;
		/// <summary>
		/// 是否控制打印
		/// </summary>
		private bool m_blnControlPrint = false;
		/// <summary>
		/// 打印预览显示与真实打印的尺寸单位比例。
		/// 预览时GraphisUnit为Display(1/75 inch)，打印则为Point(1/72 inch)。
		/// </summary>
		private const float c_fltScale = 75f/72;
		/// <summary>
		/// 打印文档的上边缘
		/// </summary>
		private const int c_intDocumentTop = 11;
		/// <summary>
		/// 打印文档的左边缘
		/// </summary>
		private const int c_intDocumentLeft = 106;
		/// <summary>
		/// 选择打印的区域
		/// </summary>
		private ArrayList m_arlSelected;
		/// <summary>
		/// 鼠标正选择移动的区域
		/// </summary>
		private Rectangle m_rtgMove;
		private System.Windows.Forms.ToolTip m_ttpPrompt;
		/// <summary>
		/// 是否画鼠标移动时选择的区域
		/// </summary>
		private bool m_blnPaintMove = false;

        private PrintDialog pd = null;
		#endregion

		public frmPrintPreviewDialogPF()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//			

//			m_intPixelPerInch = GetDeviceCaps(GetDC(GetActiveWindow()),cnLOG_PIXELS_Y);
            m_arlSelected = new ArrayList();
            pd = new PrintDialog();
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrintPreviewDialogPF));
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.m_lblSpliter = new System.Windows.Forms.Label();
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.m_ctmClear = new System.Windows.Forms.ContextMenu();
			this.m_mniClear = new System.Windows.Forms.MenuItem();
			this.m_nudView = new System.Windows.Forms.NumericUpDown();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.m_tlbPrint = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.m_tlbContinue = new System.Windows.Forms.ToolBarButton();
			this.m_ctmContinuePrint = new System.Windows.Forms.ContextMenu();
			this.m_mniLine = new System.Windows.Forms.MenuItem();
			this.m_mniArea = new System.Windows.Forms.MenuItem();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.m_imlToolbar = new System.Windows.Forms.ImageList(this.components);
			this.m_pnlPrintPreview = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.m_rdbAll = new System.Windows.Forms.RadioButton();
			this.m_rdbSpecify = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.m_nudEnd = new System.Windows.Forms.NumericUpDown();
			this.m_nudFrom = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.m_ttpPrompt = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.m_nudView)).BeginInit();
			this.m_pnlPrintPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_nudEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nudFrom)).BeginInit();
			this.SuspendLayout();
			// 
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// m_lblSpliter
			// 
			this.m_lblSpliter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.m_lblSpliter.BackColor = System.Drawing.Color.Red;
			this.m_lblSpliter.Location = new System.Drawing.Point(0, 300);
			this.m_lblSpliter.Name = "m_lblSpliter";
			this.m_lblSpliter.Size = new System.Drawing.Size(2888, 5);
			this.m_lblSpliter.TabIndex = 6;
			this.m_ttpPrompt.SetToolTip(this.m_lblSpliter, "按住鼠标左键可以进行上下拖动，分隔线下方为您需要续打的内容");
			this.m_lblSpliter.Visible = false;
			this.m_lblSpliter.MouseEnter += new System.EventHandler(this.m_lblSpliter_MouseEnter);
			this.m_lblSpliter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_lblSpliter_MouseMove);
			this.m_lblSpliter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lblSpliter_MouseDown);
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.ContextMenu = this.m_ctmClear;
			this.printPreviewControl1.Document = this.printDocument1;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new System.Drawing.Size(1008, 1150);
			this.printPreviewControl1.TabIndex = 0;
			this.m_ttpPrompt.SetToolTip(this.printPreviewControl1, "右键单击可查看您可以与此表单进行的交互");
			this.printPreviewControl1.Zoom = 1;
			this.printPreviewControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.printPreviewControl1_Paint);
			this.printPreviewControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.printPreviewControl1_MouseUp);
			this.printPreviewControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.printPreviewControl1_MouseMove);
			this.printPreviewControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.printPreviewControl1_MouseDown);
			// 
			// m_ctmClear
			// 
			this.m_ctmClear.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.m_mniClear});
			// 
			// m_mniClear
			// 
			this.m_mniClear.Index = 0;
			this.m_mniClear.Text = "清空已选择区域";
			this.m_mniClear.Click += new System.EventHandler(this.m_mniClear_Click);
			// 
			// m_nudView
			// 
			this.m_nudView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_nudView.Location = new System.Drawing.Point(744, 4);
			this.m_nudView.Minimum = new System.Decimal(new int[] {
																	  1,
																	  0,
																	  0,
																	  0});
			this.m_nudView.Name = "m_nudView";
			this.m_nudView.Size = new System.Drawing.Size(48, 21);
			this.m_nudView.TabIndex = 7;
			this.m_nudView.Value = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.m_nudView.ValueChanged += new System.EventHandler(this.m_nudView_ValueChanged);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.m_tlbPrint,
																						this.toolBarButton2,
																						this.toolBarButton1,
																						this.m_tlbContinue,
																						this.toolBarButton4});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.m_imlToolbar;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 28);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// m_tlbPrint
			// 
			this.m_tlbPrint.ImageIndex = 0;
			this.m_tlbPrint.Tag = "打印";
			this.m_tlbPrint.Text = "打印";
			this.m_tlbPrint.ToolTipText = "打印";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 1;
			this.toolBarButton1.Text = "打印机设置";
			// 
			// m_tlbContinue
			// 
			this.m_tlbContinue.DropDownMenu = this.m_ctmContinuePrint;
			this.m_tlbContinue.ImageIndex = 2;
			this.m_tlbContinue.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.m_tlbContinue.Text = "续打";
			// 
			// m_ctmContinuePrint
			// 
			this.m_ctmContinuePrint.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.m_mniLine,
																							   this.m_mniArea});
			// 
			// m_mniLine
			// 
			this.m_mniLine.Index = 0;
			this.m_mniLine.Text = "分隔线";
			this.m_mniLine.Click += new System.EventHandler(this.m_mniItem_Click);
			// 
			// m_mniArea
			// 
			this.m_mniArea.Index = 1;
			this.m_mniArea.Text = "区域选择";
			this.m_mniArea.Click += new System.EventHandler(this.m_mniItem_Click);
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 3;
			this.toolBarButton4.Text = "关闭";
			// 
			// m_imlToolbar
			// 
			this.m_imlToolbar.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imlToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imlToolbar.ImageStream")));
			this.m_imlToolbar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_pnlPrintPreview
			// 
			this.m_pnlPrintPreview.AutoScroll = true;
			this.m_pnlPrintPreview.Controls.Add(this.m_lblSpliter);
			this.m_pnlPrintPreview.Controls.Add(this.printPreviewControl1);
			this.m_pnlPrintPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pnlPrintPreview.Location = new System.Drawing.Point(0, 28);
			this.m_pnlPrintPreview.Name = "m_pnlPrintPreview";
			this.m_pnlPrintPreview.Size = new System.Drawing.Size(792, 545);
			this.m_pnlPrintPreview.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(696, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 17);
			this.label1.TabIndex = 11;
			this.label1.Text = "浏览页:";
			// 
			// m_rdbAll
			// 
			this.m_rdbAll.Checked = true;
			this.m_rdbAll.Location = new System.Drawing.Point(360, 2);
			this.m_rdbAll.Name = "m_rdbAll";
			this.m_rdbAll.Size = new System.Drawing.Size(48, 24);
			this.m_rdbAll.TabIndex = 13;
			this.m_rdbAll.TabStop = true;
			this.m_rdbAll.Text = "全部";
			// 
			// m_rdbSpecify
			// 
			this.m_rdbSpecify.Location = new System.Drawing.Point(416, 2);
			this.m_rdbSpecify.Name = "m_rdbSpecify";
			this.m_rdbSpecify.Size = new System.Drawing.Size(96, 24);
			this.m_rdbSpecify.TabIndex = 12;
			this.m_rdbSpecify.Text = "指定页  从:";
			this.m_rdbSpecify.CheckedChanged += new System.EventHandler(this.m_rdbSpecify_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(296, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 14;
			this.label2.Text = "打印范围:";
			// 
			// m_nudEnd
			// 
			this.m_nudEnd.Enabled = false;
			this.m_nudEnd.Location = new System.Drawing.Point(600, 4);
			this.m_nudEnd.Minimum = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
			this.m_nudEnd.Name = "m_nudEnd";
			this.m_nudEnd.Size = new System.Drawing.Size(48, 21);
			this.m_nudEnd.TabIndex = 15;
			this.m_nudEnd.Value = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.m_nudEnd.ValueChanged += new System.EventHandler(this.m_nudEnd_ValueChanged);
			// 
			// m_nudFrom
			// 
			this.m_nudFrom.Enabled = false;
			this.m_nudFrom.Location = new System.Drawing.Point(512, 4);
			this.m_nudFrom.Minimum = new System.Decimal(new int[] {
																	  1,
																	  0,
																	  0,
																	  0});
			this.m_nudFrom.Name = "m_nudFrom";
			this.m_nudFrom.Size = new System.Drawing.Size(48, 21);
			this.m_nudFrom.TabIndex = 16;
			this.m_nudFrom.Value = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.m_nudFrom.ValueChanged += new System.EventHandler(this.m_nudFrom_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(568, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(23, 17);
			this.label3.TabIndex = 17;
			this.label3.Text = "到:";
			// 
			// frmPrintPreviewDialogPF
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_nudFrom);
			this.Controls.Add(this.m_nudEnd);
			this.Controls.Add(this.m_rdbAll);
			this.Controls.Add(this.m_rdbSpecify);
			this.Controls.Add(this.m_pnlPrintPreview);
			this.Controls.Add(this.m_nudView);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPrintPreviewDialogPF";
			this.Text = "打印预览";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.m_nudView)).EndInit();
			this.m_pnlPrintPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_nudEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_nudFrom)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Windows API
		//		private const int cnLOG_PIXELS_Y = 90;
		//
		//		[DllImport("User32.dll",EntryPoint="GetActiveWindow")]
		//		private static extern int GetActiveWindow();
		//
		//		[DllImport("User32.dll",EntryPoint="GetDC")]
		//		private static extern int GetDC(int iHDC);
		//		
		//		[DllImport("GDI32.dll",EntryPoint="GetDeviceCaps")]
		//		private static extern int GetDeviceCaps(int iHDC,int iIndex);
		#endregion

		#region 打印事件
		private void m_mthPrintFrame(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(m_evtPrintFrame != null)
				m_evtPrintFrame(this,e);
		}
		public event System.Drawing.Printing.PrintPageEventHandler m_evtPrintFrame;
		public event System.Drawing.Printing.PrintPageEventHandler m_evtPrintContent;
		public event System.Drawing.Printing.PrintEventHandler m_evtEndPrint;
		public event System.Drawing.Printing.PrintEventHandler m_evtBeginPrint;
		
		private void m_mthPrintContent(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(m_evtPrintContent != null)
				m_evtPrintContent(this,e);
		}
		private void m_mthEndPrint(System.Drawing.Printing.PrintEventArgs e)
		{
			if(m_evtEndPrint != null)
				m_evtEndPrint(this,e);
		}
		private void m_mthBeginPrint(System.Drawing.Printing.PrintEventArgs e)
		{
			if(m_evtBeginPrint != null)
				m_evtBeginPrint(this,e);
		}
		#endregion

		#region 分隔条事件
		private void m_lblSpliter_MouseEnter(object sender, System.EventArgs e)
		{
			m_lblSpliter.Cursor = Cursors.SizeNS;
		}

		private void m_lblSpliter_MouseLeave(object sender, System.EventArgs e)
		{
			m_lblSpliter.Cursor = Cursors.Default;
		}

		private void m_lblSpliter_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				m_lblSpliter.Top += e.Y - m_intDownY;
			}
		}

		private int m_intDownY;
		private void m_lblSpliter_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_intDownY = e.Y;
		}
		#endregion

		#region 打印文档事件
		private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthBeginPrint(e);
			m_intCurrentPrintPage = 0;
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(!m_blnControlPrint)//不需要控制打印，正常打印，通常在预览时用
			{
				m_mthPrintContent(e);
				m_mthPrintFrame(e);
				m_intCurrentPrintPage++;
			}
			else
			{
				//还没打到指定的开始页，清空
				while(m_intCurrentPrintPage < (int)(m_nudFrom.Value-1))
				{
					m_mthPrintContent(e);
					m_mthPrintFrame(e);
					e.Graphics.Clear(Color.White);
					m_intCurrentPrintPage ++;
				}
				m_mthPrintContent(e);
				if(!m_blnIsContinuePrintPage)
				{
					m_mthPrintFrame(e);
				}
				else
					m_blnIsContinuePrintPage = false;
       
				if(m_blnContinuePrint)//清空续打以上的内容
				{
					if(m_intCurrentPrintPage == (int)(m_nudView.Value-1))
						m_mthClearNoNeed(e);
				}

				m_intCurrentPrintPage++;

				//已经打到指定的结束页，返回
				if(m_intCurrentPrintPage > (int)(m_nudEnd.Value-1))
				{
					e.HasMorePages = false;
					return;
				}
			}			
		}

		private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthEndPrint(e);
			if(!m_blnControlPrint)
			{
				m_nudView.Maximum = m_intCurrentPrintPage;
				m_nudFrom.Maximum = m_intCurrentPrintPage;
				m_nudEnd.Maximum = m_intCurrentPrintPage;
				m_nudEnd.Value = m_intCurrentPrintPage;
			}
			 m_blnIsContinuePrintPage = m_tlbContinue.Pushed;
		}

		private void m_mthClearNoNeed(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(m_mniLine.Checked)//打印分隔线下部内容
			{
				//开始打印的高度
				int intFromY = (int)((m_lblSpliter.Bottom - printPreviewControl1.Top - c_intDocumentTop)*c_fltScale);
				Rectangle rtlClear = new Rectangle(0,0,e.PageBounds.Width,intFromY);
				e.Graphics.FillRectangle(Brushes.White,rtlClear);
			}
			else//打印已选择的区域
			{
				Rectangle[] rtgArr = (Rectangle[])m_arlSelected.ToArray(typeof(Rectangle));
				for(int i=0;i<rtgArr.Length;i++)
				{
					Rectangle rtgOut = new Rectangle((int)((rtgArr[i].X-c_intDocumentLeft)*c_fltScale),(int)((rtgArr[i].Y-c_intDocumentTop)*c_fltScale),(int)(rtgArr[i].Width*c_fltScale),(int)(rtgArr[i].Height*c_fltScale));
					e.Graphics.SetClip(rtgOut,System.Drawing.Drawing2D.CombineMode.Exclude);
				}
				Rectangle rtlClear = new Rectangle(0,0,e.PageBounds.Width,e.PageBounds.Height);
				e.Graphics.FillRectangle(Brushes.White,rtlClear);
			}
		}
		#endregion

		#region Property
		private bool m_blnIsContinuePrintPage = false;
		
		/// <summary>
		/// 当前页是否续打页
		/// </summary>
		public bool m_BlnIsContinuePrintPage
		{
			get
			{
				return m_blnIsContinuePrintPage;
			}
		}
		public PageSettings m_pstDefaultPageSettings
		{
			set
			{
				printDocument1.DefaultPageSettings = value;
			}
		}

		#endregion

		#region 区域选择
		private int m_intRTGX1,m_intRTGY1;
		private void printPreviewControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(m_mniArea.Checked && e.Button == MouseButtons.Left)
			{
				m_intRTGX1 = e.X;
				m_intRTGY1 = e.Y;
			}
		}
		
		private void printPreviewControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(m_mniArea.Checked && e.Button == MouseButtons.Left)
			{
				m_rtgMove = new Rectangle(m_intRTGX1,m_intRTGY1,e.X-m_intRTGX1,e.Y-m_intRTGY1);
				m_blnPaintMove = true;
				printPreviewControl1.Invalidate(new Rectangle(m_intRTGX1,m_intRTGY1,e.X-m_intRTGX1+10,e.Y-m_intRTGY1+10));
			}
		}

		private void printPreviewControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(m_mniArea.Checked && e.Button == MouseButtons.Left)
			{
				Rectangle rtgSelected = new Rectangle(m_intRTGX1,m_intRTGY1,e.X-m_intRTGX1,e.Y-m_intRTGY1);
				m_arlSelected.Add(rtgSelected);
			}
		}		
		
		private void printPreviewControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(m_blnPaintMove)//画鼠标移动时的区域
			{
				e.Graphics.DrawRectangle(Pens.Red,m_rtgMove);
				m_blnPaintMove = false;
			}
			if(m_arlSelected.Count>0)//画所有已选择的区域
			{
				Rectangle[] rtgSelected = (Rectangle[])m_arlSelected.ToArray(typeof(Rectangle));
				e.Graphics.DrawRectangles(Pens.Red,rtgSelected);
			}
		}
		#endregion

		#region 右键菜单
		private void m_mniItem_Click(object sender, System.EventArgs e)
		{
			m_blnContinuePrint = true;

			MenuItem mni = (MenuItem)sender;
			m_mniLine.Checked = false;
			m_mniArea.Checked = false;
			mni.Checked = true;

			m_tlbContinue.Pushed = true;

			switch(mni.Text)
			{
				case "分隔线" :
					m_mniClear_Click(null,null);
					m_lblSpliter.Visible = true;
					break;
				case "区域选择":
					m_lblSpliter.Visible = false;
					break;
			}
		}

		/// <summary>
		/// 清空已选择的区域
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mniClear_Click(object sender, System.EventArgs e)
		{
			m_arlSelected.Clear();
			printPreviewControl1.Invalidate();
		}
		#endregion

		#region 工具栏函数
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Text)
			{
				case "打印" :
                    if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1)
                    {
                        bool blnIsCase = false;
                        if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr != null)
                        {
                            int intRolesCount = Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr.Length;
                            for (int i = 0; i < intRolesCount; i++)
                            {
                                if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr[i] == "病案室")
                                {
                                    blnIsCase = true;
                                    break;
                                }
                            }
                        }
                        if (!blnIsCase)
                        {
                            clsPublicFunction.ShowInformationMessageBox("此病人病历为只读，不能打印！");
                            return;
                        }                        
                    }
                    if (pd == null)
                    {
                        pd = new PrintDialog();
                    }

                    if (string.IsNullOrEmpty(pd.PrinterSettings.PrinterName))
                    {
                        pd.Document = printDocument1;
                        pd.AllowPrintToFile = false;
                        pd.ShowDialog();
                    }

                    if (string.IsNullOrEmpty(pd.PrinterSettings.PrinterName))//关闭打印设置后再次判断
                    {
                        clsPublicFunction.ShowInformationMessageBox("请指定一台打印机！");
                        return;
                    }

                    m_blnControlPrint = true;
                    printDocument1.Print();
                    m_blnControlPrint = false;
					break;
				case "打印机设置" :
                    if (pd == null)
                    {
                        pd = new PrintDialog();
                    }
					pd.Document = printDocument1;
					pd.ShowDialog();
					break;
				case "续打" :
					e.Button.Pushed = !e.Button.Pushed;
					m_blnContinuePrint = e.Button.Pushed;
					if(m_blnContinuePrint)
						m_mniItem_Click(m_mniLine,EventArgs.Empty);
					else
					{
						m_lblSpliter.Visible = false;
						m_mniClear_Click(null,null);
					}
					m_mthSyncFromPage();
					m_blnIsContinuePrintPage = e.Button.Pushed;
					if(m_rdbSpecify.Checked)
					{
						m_nudFrom.Enabled = !m_blnContinuePrint;
					}
					break;
				case "关闭" :
					this.Close();
					break;
			}
			
		}

		private void m_nudEnd_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_nudEnd.Value < m_nudFrom.Value)
				m_nudEnd.Value = m_nudFrom.Value;
		}

		private void m_rdbSpecify_CheckedChanged(object sender, System.EventArgs e)
		{
			m_nudFrom.Enabled = m_rdbSpecify.Checked;
			m_nudEnd.Enabled = m_rdbSpecify.Checked;
			if(!m_nudEnd.Enabled)
				m_nudEnd.Value = m_intCurrentPrintPage;
			m_mthSyncFromPage();
		}

		/// <summary>
		/// 同步起始页
		/// </summary>
		private void m_mthSyncFromPage()
		{
			if(m_blnContinuePrint)
			{
				m_nudFrom.Value = m_nudView.Value;
				m_nudFrom.Enabled = false;
			}
		}

		private void m_nudFrom_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_nudFrom.Value > m_nudEnd.Value)
				m_nudFrom.Value = m_nudEnd.Value;
		}

		private void m_nudView_ValueChanged(object sender, System.EventArgs e)
		{
			printPreviewControl1.StartPage = (int)(m_nudView.Value - 1);
			
			m_mthSyncFromPage();
		}
		#endregion

        #region 能否打印到设备
        /// <summary>
        /// 不能再预览中打印
        /// </summary>
        public void m_mthCoverPrinter()
        {
            m_tlbPrint.Enabled = false;
        }
        #endregion 能否打印到设备
    }
}
