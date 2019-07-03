using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Static = com.digitalwave.Emr.StaticObject;

namespace iCare.PrintTool
{
	/// <summary>
	/// frmPrintPreviewDialogAll 的摘要说明。
	/// 全套病历打印预览
	/// </summary>
	public class frmPrintPreviewDialogAll : System.Windows.Forms.PrintPreviewDialog
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown m_nudFrom;
		private System.Windows.Forms.NumericUpDown m_nudEnd;
		private System.Windows.Forms.RadioButton m_rdbAll;
		private System.Windows.Forms.RadioButton m_rdbSpecify;
		private System.Windows.Forms.Button m_cmdPrintSetup;
		private System.Drawing.Printing.PrintDocument pdcCase;
		public ArrayList arlPrintContent=null;                    //打印内容
		private bool blnFromFile=false;                           //文档内容来自文件
		private bool blnPrint=false;                              //false=预览 ture=打印
		private int intEndPages=0;                                //最后打印页数
		private int intPages=0;                                   //当前打印页数
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton m_rdbCurrent;
        private Label m_lblCoverPrinter;
		private System.ComponentModel.IContainer components;
        private bool m_blnIsCase = false;

		public frmPrintPreviewDialogAll()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//最大化
			Type ppdType = typeof(System.Windows.Forms.PrintPreviewDialog);
			PropertyInfo objWSPI = ppdType.GetProperty("WindowState", BindingFlags.Public|BindingFlags.Instance);
			objWSPI.SetValue(this,FormWindowState.Maximized,null);

		}
		public frmPrintPreviewDialogAll(ArrayList arlContent,bool blnFile)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//最大化
			Type ppdType = typeof(System.Windows.Forms.PrintPreviewDialog);
			PropertyInfo objWSPI = ppdType.GetProperty("WindowState", BindingFlags.Public|BindingFlags.Instance);
			objWSPI.SetValue(this,FormWindowState.Maximized,null);

			this.UseAntiAlias=true;
			arlPrintContent=arlContent;
			blnFromFile=blnFile;
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_nudFrom = new System.Windows.Forms.NumericUpDown();
            this.m_nudEnd = new System.Windows.Forms.NumericUpDown();
            this.m_rdbAll = new System.Windows.Forms.RadioButton();
            this.m_rdbSpecify = new System.Windows.Forms.RadioButton();
            this.m_cmdPrintSetup = new System.Windows.Forms.Button();
            this.pdcCase = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_rdbCurrent = new System.Windows.Forms.RadioButton();
            this.m_lblCoverPrinter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "到:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "打印范围:";
            // 
            // m_nudFrom
            // 
            this.m_nudFrom.Enabled = false;
            this.m_nudFrom.Location = new System.Drawing.Point(562, 2);
            this.m_nudFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudFrom.Name = "m_nudFrom";
            this.m_nudFrom.Size = new System.Drawing.Size(48, 21);
            this.m_nudFrom.TabIndex = 22;
            this.m_nudFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudFrom.ValueChanged += new System.EventHandler(this.m_nudFrom_ValueChanged);
            // 
            // m_nudEnd
            // 
            this.m_nudEnd.Enabled = false;
            this.m_nudEnd.Location = new System.Drawing.Point(632, 2);
            this.m_nudEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudEnd.Name = "m_nudEnd";
            this.m_nudEnd.Size = new System.Drawing.Size(48, 21);
            this.m_nudEnd.TabIndex = 21;
            this.m_nudEnd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_nudEnd.ValueChanged += new System.EventHandler(this.m_nudEnd_ValueChanged);
            // 
            // m_rdbAll
            // 
            this.m_rdbAll.Checked = true;
            this.m_rdbAll.Location = new System.Drawing.Point(370, 2);
            this.m_rdbAll.Name = "m_rdbAll";
            this.m_rdbAll.Size = new System.Drawing.Size(48, 20);
            this.m_rdbAll.TabIndex = 19;
            this.m_rdbAll.TabStop = true;
            this.m_rdbAll.Text = "全部";
            this.m_rdbAll.CheckedChanged += new System.EventHandler(this.m_rdbAll_CheckedChanged);
            // 
            // m_rdbSpecify
            // 
            this.m_rdbSpecify.Location = new System.Drawing.Point(476, 2);
            this.m_rdbSpecify.Name = "m_rdbSpecify";
            this.m_rdbSpecify.Size = new System.Drawing.Size(96, 20);
            this.m_rdbSpecify.TabIndex = 18;
            this.m_rdbSpecify.Text = "指定页  从:";
            this.m_rdbSpecify.CheckedChanged += new System.EventHandler(this.m_rdbSpecify_CheckedChanged);
            // 
            // m_cmdPrintSetup
            // 
            this.m_cmdPrintSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrintSetup.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmdPrintSetup.Location = new System.Drawing.Point(254, 4);
            this.m_cmdPrintSetup.Name = "m_cmdPrintSetup";
            this.m_cmdPrintSetup.Size = new System.Drawing.Size(50, 20);
            this.m_cmdPrintSetup.TabIndex = 24;
            this.m_cmdPrintSetup.Text = "设置";
            this.m_cmdPrintSetup.Click += new System.EventHandler(this.m_cmdPrintSetup_Click);
            // 
            // pdcCase
            // 
            this.pdcCase.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdcCase_PrintPage);
            this.pdcCase.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.pdcCase_EndPrint);
            this.pdcCase.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdcCase_BeginPrint);
            // 
            // m_rdbCurrent
            // 
            this.m_rdbCurrent.Location = new System.Drawing.Point(416, 2);
            this.m_rdbCurrent.Name = "m_rdbCurrent";
            this.m_rdbCurrent.Size = new System.Drawing.Size(60, 20);
            this.m_rdbCurrent.TabIndex = 32;
            this.m_rdbCurrent.Text = "当前页";
            // 
            // m_lblCoverPrinter
            // 
            this.m_lblCoverPrinter.Location = new System.Drawing.Point(40, -1);
            this.m_lblCoverPrinter.Name = "m_lblCoverPrinter";
            this.m_lblCoverPrinter.Size = new System.Drawing.Size(21, 23);
            this.m_lblCoverPrinter.TabIndex = 33;
            this.m_lblCoverPrinter.Visible = false;
            // 
            // frmPrintPreviewDialogAll
            // 
            this.ClientSize = new System.Drawing.Size(918, 449);
            this.Controls.Add(this.m_lblCoverPrinter);
            this.Controls.Add(this.m_rdbCurrent);
            this.Controls.Add(this.m_cmdPrintSetup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_nudFrom);
            this.Controls.Add(this.m_nudEnd);
            this.Controls.Add(this.m_rdbAll);
            this.Controls.Add(this.m_rdbSpecify);
            this.Name = "frmPrintPreviewDialogAll";
            this.Text = "全套病历浏览";
            this.Load += new System.EventHandler(this.frmPrintPreviewDialogAll_Load);
            this.Controls.SetChildIndex(this.m_rdbSpecify, 0);
            this.Controls.SetChildIndex(this.m_rdbAll, 0);
            this.Controls.SetChildIndex(this.m_nudEnd, 0);
            this.Controls.SetChildIndex(this.m_nudFrom, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_cmdPrintSetup, 0);
            this.Controls.SetChildIndex(this.m_rdbCurrent, 0);
            this.Controls.SetChildIndex(this.m_lblCoverPrinter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 事件
		/// <summary>
		/// 启动窗体事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmPrintPreviewDialogAll_Load(object sender, System.EventArgs e)
		{
			try
			{
                ////获取工具栏控制
                //m_mthGetToolBar();
                ////替换原工具栏中的打印按钮
                //System.Windows.Forms.ToolBarButton toolBarButton1;
                //toolBarButton1=new System.Windows.Forms.ToolBarButton();
                //toolBarButton1.ImageIndex=0;
                //toolBarButton1.ToolTipText="打印";
                //tb.Buttons.Insert(1,toolBarButton1);
                //tb.Buttons[0].Visible=false;
				//设置最大页数
				m_nudEnd.Value=arlPrintContent.Count;
				//打印文档
				Document=pdcCase;

                if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1)
                {
                    if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr != null)
                    {
                        int intRolesCount = Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr.Length;
                        for (int i = 0; i < intRolesCount; i++)
                        {
                            if (Static::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr[i] == "病案室")
                            {
                                m_blnIsCase = true;
                                break;
                            }
                        }
                    }
                    if (!m_blnIsCase)
                    {
                        this.m_lblCoverPrinter.Visible = true;
                    }
                }
			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
		
		}

		/// <summary>
		/// 打印设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_cmdPrintSetup_Click(object sender, System.EventArgs e)
		{
 			try
			{
				PrintDialog pd=new PrintDialog();
				pd.Document=this.Document;
				pd.ShowDialog();

			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
 		
		}
		/// <summary>
		/// 打印全部
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// 打印范围设定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_rdbSpecify_CheckedChanged(object sender, System.EventArgs e)
		{
 			try
			{
				m_nudFrom.Enabled = m_rdbSpecify.Checked;
				m_nudEnd.Enabled = m_rdbSpecify.Checked;
			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
 		}

		/// <summary>
		/// 开始页面设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_nudFrom_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_nudFrom.Value > m_nudEnd.Value)
				m_nudFrom.Value = m_nudEnd.Value;

		}
		/// <summary>
		/// 结束页面设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_nudEnd_ValueChanged(object sender, System.EventArgs e)
		{
			if(m_nudFrom.Value > m_nudEnd.Value)
				m_nudEnd.Value = m_nudFrom.Value;

		}

		#endregion

		#region 打印事件
		/// <summary>
		/// 开始打印事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pdcCase_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
            //if (blnPrint)//打印
            //{
            m_mthGetToolBar();
				if (m_rdbAll.Checked)
				{
					intPages=0;
					intEndPages=arlPrintContent.Count-1;
				}
				if (m_rdbSpecify.Checked)
				{
					intPages=(int)m_nudFrom.Value-1;
					intEndPages=(int)m_nudEnd.Value-1;
				}
				if (m_rdbCurrent.Checked)
				{
					intPages=(int)nudControl.Value-1;
					intEndPages=(int)nudControl.Value-1;
				}
					 
            //}
            //else//预览
            //{
            //    intPages=0;	
            //    intEndPages=arlPrintContent.Count-1;
            //}
			
		}

		/// <summary>
		/// 打印中事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pdcCase_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				
				Rectangle destRect = new Rectangle( 0, 0, 827, 1169);
				Image imgxx;
				if (blnFromFile)
				{
					byte[] data =(byte[])arlPrintContent[intPages];
					MemoryStream ms = new MemoryStream();
					ms.Write(data,0,data.Length);	
					imgxx=new Bitmap(ms);
					ms.Close();
		 
				}
				else
				{
					imgxx=(Image)arlPrintContent[intPages];

				}
					
				e.Graphics.SmoothingMode =System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				e.Graphics.InterpolationMode=System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

				e.Graphics.DrawImage(imgxx,destRect);
				if (intPages<intEndPages)
				{
					intPages++;
					e.HasMorePages=true;
				}
				else
				{
					e.HasMorePages=false;
				} 
			}
			catch (Exception ex)
			{
				e.HasMorePages=false;
				string strMsg=ex.Message;
			}

		
		}
		/// <summary>
		/// 打印结束事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pdcCase_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		
		}
		#endregion

		#region 获取控制打印工具栏
		private ToolBar tb;
        private ToolStrip ts;
		private NumericUpDown nudControl;
		/// <summary>
		/// 获取打印工具栏对象
		/// </summary>
		private void m_mthGetToolBar()
		{
			foreach(System.Windows.Forms.Control c in this.Controls)
			{
				if(c is ToolBar )
				{
					((ToolBar)c).ButtonClick+=new ToolBarButtonClickEventHandler(frmPrintPreviewDialogAll_ButtonClick);
					tb  =(ToolBar)c;
					break;
				}
                if (c is ToolStrip)
                {
                    ts = (ToolStrip)c;
                }
			}
			//get numericUpDown object
			foreach(System.Windows.Forms.Control c in ts.Controls)
			{
				nudControl = c as NumericUpDown;
				if(nudControl!=null)
				{
					nudControl =(NumericUpDown)c;
					break;
				}
			}
		}
		/// <summary>
		/// 响应工具栏打印事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmPrintPreviewDialogAll_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			try
			{
				if (tb.Buttons.IndexOf(e.Button)==1)
				{
                    if (MDIParent.s_ObjCurrentPatient != null && MDIParent.s_ObjCurrentPatient.m_IntCharacter == 1 && !m_blnIsCase)
                    {
                        clsPublicFunction.ShowInformationMessageBox("此病人病历为只读，不能打印！");
                        return;
                    }
					blnPrint = true;
 					Document.Print();
 				}
			}
			catch (Exception ex)
			{
				blnPrint = false;
				string strMsg=ex.Message;
			}
		}

		#endregion




	}
}
