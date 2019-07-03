using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using com.digitalwave.Utility.Controls;
using System.Runtime.InteropServices;

namespace iCare
{
	/// <summary>
	/// frmTemplateSelect 的摘要说明。
	/// </summary>
	public class frmTemplateSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView m_tvwTemplate;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel m_pnlContent;
		private System.Windows.Forms.Splitter splitter2;

		private clsTransferTemplate m_objTemplate=null;
		private System.Windows.Forms.ImageList m_imgIcons;

		private ArrayList m_arlControlGroup;

		[DllImport("user32.dll")]
		private extern static int ReleaseCapture();

		[DllImport("user32.dll")]
		private extern static int SendMessage (int hwnd ,int wMsg,int wParam ,int  lParam );
		private static int WM_SYSCOMMAND = 0x112;
		private static int SC_MOVE = 0xF010;
		private static int HTCAPTION = 0x2;

		//文本框默认的宽度(为m_pnlContent的宽度减去滚动条的宽度,即使没有滚动条也减)
		private const int c_intDefaultTextBoxWidth=372;

		public frmTemplateSelect(clsTransferTemplate objTemplate)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_objTemplate=objTemplate;
			
//			ctlRichTextBox.m_ClrDefaultViewText=Color.Black;

			m_arlControlGroup=new ArrayList();
		
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTemplateSelect));
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_pnlContent = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.m_tvwTemplate = new System.Windows.Forms.TreeView();
			this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.m_pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.m_pnlContent);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.m_tvwTemplate);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(592, 301);
			this.panel1.TabIndex = 0;
			// 
			// m_pnlContent
			// 
			this.m_pnlContent.AutoScroll = true;
			this.m_pnlContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(225)), ((System.Byte)(225)), ((System.Byte)(192)));
			this.m_pnlContent.Controls.Add(this.splitter2);
			this.m_pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pnlContent.Location = new System.Drawing.Point(203, 0);
			this.m_pnlContent.Name = "m_pnlContent";
			this.m_pnlContent.Size = new System.Drawing.Size(387, 299);
			this.m_pnlContent.TabIndex = 3;
			this.m_pnlContent.Resize += new System.EventHandler(this.m_pnlContent_Resize);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(387, 3);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Desktop;
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 299);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// m_tvwTemplate
			// 
			this.m_tvwTemplate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(225)), ((System.Byte)(225)), ((System.Byte)(192)));
			this.m_tvwTemplate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_tvwTemplate.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_tvwTemplate.HideSelection = false;
			this.m_tvwTemplate.ImageList = this.m_imgIcons;
			this.m_tvwTemplate.Location = new System.Drawing.Point(0, 0);
			this.m_tvwTemplate.Name = "m_tvwTemplate";
			this.m_tvwTemplate.Size = new System.Drawing.Size(200, 299);
			this.m_tvwTemplate.TabIndex = 0;
			this.m_tvwTemplate.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.m_tvwTemplate_AfterExpand);
			this.m_tvwTemplate.DoubleClick += new System.EventHandler(this.m_tvwTemplate_DoubleClick);
			this.m_tvwTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_tvwTemplate_AfterSelect);
			this.m_tvwTemplate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_tvwTemplate_MouseMove);
			// 
			// m_imgIcons
			// 
			this.m_imgIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
			this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmTemplateSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(592, 301);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "frmTemplateSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模板";
			this.TopMost = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTemplateSelect_KeyDown);
			this.Load += new System.EventHandler(this.frmTemplateSelect_Load);
			this.Deactivate += new System.EventHandler(this.frmTemplateSelect_Deactivate);
			this.panel1.ResumeLayout(false);
			this.m_pnlContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		private void frmTemplateSelect_Load(object sender, System.EventArgs e)
		{
			 int c_intScreenHeight=SystemInformation.MaxWindowTrackSize.Height;
			 int c_intScreenWidth=SystemInformation.MaxWindowTrackSize.Width/SystemInformation.MonitorCount;
			
			if(m_objTemplate!=null)
			{
				m_objTemplate.m_mthLoadTemplateRootNode(m_tvwTemplate);
				
//				Point ptPos=m_objTemplate.m_ptGetCursorPosition();

//				if(ptPos.X<0) 
//				{
//					ptPos.X=0;
//				}
//				else if(ptPos.X<c_intScreenWidth)
//				{
//					if(ptPos.X + this.Width>c_intScreenWidth) ptPos.X=c_intScreenWidth-this.Width;
//				}
//				else
//				{
//					if(ptPos.X + this.Width > c_intScreenWidth*2) ptPos.X=c_intScreenWidth*2 -this.Width;
//				}
				
//				if(ptPos.Y<0) ptPos.Y=0;
//				if(ptPos.Y+ this.Height>c_intScreenHeight) ptPos.Y=c_intScreenHeight-this.Height;

//				this.Location=ptPos;

//				this.Location = Control.MousePosition;
			}

			this.TopMost = true;
			

		}


		#region 事件处理

		//选中后显示模板内容
		private void m_tvwTemplate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_objTemplate!=null)
			{

				string[] strTitle, strContent,strXml;
				m_objTemplate.m_mthGetTemplateNodeContent(e.Node,out strTitle,out strContent,out strXml);

				Color clrDefault = ctlRichTextBox.m_ClrDefaultViewText;
				ctlRichTextBox.m_ClrDefaultViewText=Color.Black;
				m_mthShowTemplateContent(strTitle,strContent,strXml);
				ctlRichTextBox.m_ClrDefaultViewText = clrDefault;
			}
		}


		//双击确定使用模板
		private void m_tvwTemplate_DoubleClick(object sender, System.EventArgs e)
		{
            if (m_objTemplate.m_frmForm is frmHRPBaseForm)
            {
                if (((frmHRPBaseForm)(m_objTemplate.m_frmForm)).m_objBaseCurrentPatient == null)
                {
                    return;
                }
            }
			if(m_objTemplate!=null)
			{
				if(m_tvwTemplate.SelectedNode!=null)
				{
					m_objTemplate.m_mthSelectedTemplateNode(m_tvwTemplate.SelectedNode);
					this.Close();
				}
			}
		}
		private void m_txtTemplate_MouseDown(object sender,System.Windows.Forms.MouseEventArgs  e)
		{
			if((e.Button==MouseButtons.Left) && (e.Clicks==2))
			{
				m_tvwTemplate_DoubleClick(sender,e);
			}
		}

		//窗口失去焦点时关闭
		private void frmTemplateSelect_Deactivate(object sender, System.EventArgs e)
		{
			this.Close();
		}


		//节点展开后显示子节点
		private void m_tvwTemplate_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_objTemplate!=null)
			{
				//m_objTemplate.m_mthExpandTemplateNode(e.Node);

//				for(int i=0;i<e.Node.Nodes.Count;i++)
//				{
					m_objTemplate.m_mthExpandTemplateNode(e.Node);
//				}
			}
		}


		//按键处理
		private void frmTemplateSelect_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				e.Handled=true;
				frmTemplateSelect_Deactivate(null,null);
			}
			else if(e.KeyCode==Keys.Enter)
			{
				e.Handled=true;
				m_tvwTemplate_DoubleClick(null,null);
			}
		}

		//调整文本框宽度
		private void m_pnlContent_Resize(object sender, System.EventArgs e)
		{
			for(int i=0;i<m_arlControlGroup.Count;i++)
			{
				((clsControlGroup)(m_arlControlGroup[i])).m_txtTitle.Width=m_pnlContent.ClientSize.Width;
				((clsControlGroup)(m_arlControlGroup[i])).m_txtContent.Width=m_pnlContent.ClientSize.Width;
				//((clsControlGroup)(m_arlControlGroup[0])).m_txtTitle.Text=m_pnlContent.ClientSize.Width.ToString();
			}
		}


		#endregion


		#region 创建控件
		private void m_mthCreateControls(int intIndex,out clsControlGroup ctlGroup)
		{

			System.Windows.Forms.TextBox txtTitle=new System.Windows.Forms.TextBox();
			ctlRichTextBox txtContent=new ctlRichTextBox();

			// txtTitle
			txtTitle.BackColor = System.Drawing.SystemColors.Info;
			txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
//			txtTitle.Dock = System.Windows.Forms.DockStyle.Top;
//			txtTitle.Location = new System.Drawing.Point(0, 0);
			txtTitle.Size = new System.Drawing.Size(296, 23);
			txtTitle.Name = "textBox_" + intIndex.ToString();
			txtTitle.TabIndex=30 + 5 * intIndex;
			txtTitle.Text="";
			//txtContent
			txtContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(225)), ((System.Byte)(225)), ((System.Byte)(192)));
			txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
//			txtContent.Dock = System.Windows.Forms.DockStyle.Top;
			txtContent.ForeColor = System.Drawing.SystemColors.WindowText;
//			txtContent.Location = new System.Drawing.Point(0, 30);
			txtContent.m_BlnPartControl = false;
			txtContent.m_BlnUnderLineDST = false;
			txtContent.m_ClrDST = System.Drawing.Color.Red;
			txtContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			txtContent.m_IntCanModifyTime = 6;
			txtContent.m_IntPartControlLength = 0;
			txtContent.m_IntPartControlStartIndex = 0;
			txtContent.m_BlnCanModifyLast=true;
			txtContent.m_StrUserID = "";
			txtContent.m_StrUserName = "";
			txtContent.Name = "txtContent_" + intIndex.ToString();
//			txtContent.Size = new System.Drawing.Size(296, 125);
			txtContent.TabIndex=30 + 5 * intIndex + 1;
			txtContent.Text = "";			

			//
			txtContent.MouseDown +=new System.Windows.Forms.MouseEventHandler(m_txtTemplate_MouseDown);
			txtTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(m_txtTemplate_MouseDown);

			//
			clsControlGroup objGroup=new clsControlGroup();
			objGroup.m_txtTitle=txtTitle;
			objGroup.m_txtContent=txtContent;

			ctlGroup=objGroup;
		}

		class clsControlGroup
		{
			public ctlRichTextBox m_txtContent;
			public TextBox m_txtTitle;

			public void m_mthSetContent(int intWidth,string strTitle,string strContent,string strXml,bool blnReadOnly)
			{
				m_txtTitle.Text=strTitle;
				m_txtTitle.ReadOnly=blnReadOnly;
				m_txtContent.Text = strContent;
//				m_txtContent.m_mthSetNewText(strContent,clsTemplatesetInvoke.s_strRemoveUserInfoFromXml(strXml));
				//m_txtContent.m_mthSetNewText(strContent,strXml);
				
				m_txtContent.m_BlnReadOnly=blnReadOnly;
				m_txtContent.ReadOnly=blnReadOnly;

				m_txtTitle.Width=intWidth;
				m_txtContent.Width=intWidth;

				m_txtContent.Height= m_txtContent.GetPositionFromCharIndex(m_txtContent.Text.Length).Y + 43 ;

			}
		}

		#endregion

		#region 显示模板内容

		private void  m_mthShowTemplateContent(string[] strTitle,string[] strContent,string[] strXml)
		{
			bool blnReadOnly=true;

			if((strTitle==null) || (strContent==null) || (strXml==null) ) return ;

			//Create Controls
			while(strTitle.Length>m_arlControlGroup.Count)
			{
				clsControlGroup objCG;
				m_mthCreateControls(m_arlControlGroup.Count,out objCG);
				m_arlControlGroup.Add(objCG);
			}

			//
			m_pnlContent.Visible=false;
			m_pnlContent.SuspendLayout();
			m_pnlContent.Controls.Clear();

			int intTop =0 ;
			for(int i=0;i<strTitle.Length;i++)
			{
				if((i>=strContent.Length) || (i>=strXml.Length)) break;

				clsControlGroup objCG=(clsControlGroup)(m_arlControlGroup[i]);
				
				m_pnlContent.Controls.Add(objCG.m_txtTitle);
				m_pnlContent.Controls.Add(objCG.m_txtContent);

				objCG.m_mthSetContent(c_intDefaultTextBoxWidth,strTitle[i],strContent[i],strXml[i],blnReadOnly);
				objCG.m_txtContent.m_mthSetNewText(strContent[i],strXml[i]);
	
				objCG.m_txtTitle.Location=new Point(0,intTop);
				intTop += objCG.m_txtTitle.Height + 1;

				objCG.m_txtContent.Location=new Point(0,intTop);
				intTop += objCG.m_txtContent.Height + 1;

			}
			m_pnlContent.ResumeLayout(true);
			m_pnlContent.Visible=true;
		}

		#endregion

		private void m_tvwTemplate_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if((e.Button==MouseButtons.Left)&&(e.Clicks<=1))
			{
				Cursor.Current=Cursors.SizeAll;
				ReleaseCapture();
				SendMessage((int)(this.Handle), WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
			}
		}




	}
}
