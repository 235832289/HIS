using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;


using HRP;
using PrivilegeData;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmPrimaryForm.
	/// </summary>
	public class frmPrimaryForm : iCare.iCareBaseForm.frmBaseForm
	{
		private System.ComponentModel.IContainer components;

		public frmPrimaryForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            m_objBorderTool = new clsBorderTool(Color.White);
			//Liu RongGuo 2003.4.11
			m_strTemplatePath = m_strGetFilePathHeader() + "Templates\\\\" ;	

//			#region 获取当前员工的所有权限
//			objPIArr = clsLoginContext.s_ObjLoginContext.m_ObjPIArr;
//			#endregion

			if(MDIParent.s_bolIAnaSystem)
				m_objHighLight = new ctlHighLightFocus(Color.White);
			else
				m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
		}

		/// <summary>
		/// 控件边框颜色的设定
		/// </summary>
        protected com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;
		/// <summary>
		/// Crystal Report模板的路径
		/// </summary>
		protected string m_strTemplatePath = "";
//		/// <summary>
//		/// 登录员工的权限信息
//		/// </summary>
//		protected clsPrivilegeInfo[] objPIArr;
		/// <summary>
		/// 高亮显示获得焦点的空间
		/// </summary>
		protected ctlHighLightFocus m_objHighLight;
		private System.Windows.Forms.ToolTip m_ttpTextInfo;
		/// <summary>
		/// 设置模板调用
		/// </summary>
		protected clsTemplatesetInvoke m_objTempTool;
		private System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;

		/// <summary>
		/// 最小时间
		/// </summary>
		protected readonly DateTime m_dtmEmptyDate = new DateTime(1900,1,1);

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPrimaryForm));
			this.m_ttpTextInfo = new System.Windows.Forms.ToolTip(this.components);
			this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
			this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
			// 
			// m_ttpTextInfo
			// 
			this.m_ttpTextInfo.AutomaticDelay = 200;
			// 
			// m_cmuRichTextBoxMenu
			// 
			this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.mniDoubleStrikeOutDelete});
			// 
			// mniDoubleStrikeOutDelete
			// 
			this.mniDoubleStrikeOutDelete.Index = 0;
			this.mniDoubleStrikeOutDelete.Text = "双划线删除";
			// 
			// frmPrimaryForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1016, 733);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPrimaryForm";
			this.Text = "frmPrimaryForm";
			this.Load += new System.EventHandler(this.frmPrimaryForm_Load);

		}
		#endregion

		#region Copy,Cut,Paste
		/// <summary>
		/// 复制操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCopy()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Copy();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Copy();
							return 1;
						}
						break;

					default:
						Clipboard.SetDataObject("");
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 剪切操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngCut()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;
			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						if(((ctlRichTextBox)ctlControl).Text != "")
						{
							((ctlRichTextBox)ctlControl).Cut();
							return 1;
						}
						break;
					
					case "RichTextBox":
						if(((RichTextBox)ctlControl).Text != "")
						{
							((RichTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "TextBox":
						if(((TextBox)ctlControl).Text != "")
						{
							((TextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "ctlBorderTextBox":
						if(((ctlBorderTextBox)ctlControl).Text != "")
						{
							((ctlBorderTextBox)ctlControl).Cut();
							return 1;
						}
						break;

					case "DataGridTextBox":
						if(((DataGridTextBox)ctlControl).Text != "")
						{
							((DataGridTextBox)ctlControl).Cut();
							return 1;
						}
						break;
				}
			}

			return 0;
		}

		/// <summary>
		/// 粘贴操作
		/// </summary>
		/// <returns>操作结果</returns>
		public long m_lngPaste()
		{
			Control ctlControl = this.ActiveControl;
			string strTypeName = ctlControl.GetType().Name;

			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
			{
				switch(strTypeName)
				{
					case "ctlRichTextBox":
						((ctlRichTextBox)ctlControl).Paste();
						break;

					case "RichTextBox":
						((RichTextBox)ctlControl).Paste();
						break;

					case "TextBox":
						((TextBox)ctlControl).Paste();
						break;

					case "ctlBorderTextBox":
						((ctlBorderTextBox)ctlControl).Paste();
						break;

					case "DataGridTextBox":
						((DataGridTextBox)ctlControl).Paste();
						break;
				}
				return 1;
			}

			return 0;
		}
		#endregion

		private void frmPrimaryForm_Load(object sender, System.EventArgs e)
		{
			m_objHighLight.m_mthAddControlInContainer(this);
		}

		#region 添加模板功能
		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="p_txtControl"></param>
		protected void m_mthAddRichTemplate(RichTextBox p_txtControl)
		{
			m_objTempTool.m_mthAddTextBox(this,p_txtControl,this.Name,p_txtControl.Name);
		}

		/// <summary>
		/// 添加模板
		/// </summary>
		/// <param name="p_txtControl"></param>
		protected void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
		{
			foreach(Control ctlChild in p_ctlContainer.Controls)
			{
				switch(ctlChild.GetType().Name)
				{
					case "ctlRichTextBox":
						m_mthAddRichTemplate((RichTextBox)ctlChild);
						m_mthAddRichTextInfo((ctlRichTextBox)ctlChild);
						break;
					case "RichTextBox":
						m_mthAddRichTemplate((RichTextBox)ctlChild);
						break;
					default:
						m_mthAddRichTemplateInContainer(ctlChild);
						break;
				}				
			}
		}
		#endregion

		#region 设置RichTextBox属性
		/// <summary>
		/// 设置RichTextBox属性
		/// </summary>
		/// <param name="p_ctlControl"></param>
		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}	
		}

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(ctlRichTextBox p_objRichTextBox)
		{
            m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] { p_objRichTextBox });
			//设置右键菜单			
//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
//			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
//			
//			//设置其他属性			
//			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
//			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
//			p_objRichTextBox.m_ClrOldPartInsertText = Color.White;
//			p_objRichTextBox.m_ClrDST = Color.Red;
		}
		#endregion

		#region 获取打印路径
		/// <summary>
		/// 获取打印路径
		/// </summary>
		/// <returns></returns>
		public string m_strGetFilePathHeader() 
		{
			string [] strFilePathAll =  Application.ExecutablePath.Split('\\') ;
			string strFilePathHeader="";
			if(strFilePathAll!=null)
				for(int i=0;i<strFilePathAll.Length-3;i++)
					strFilePathHeader+=strFilePathAll[i]+"\\\\";
			return strFilePathHeader;
		}
		#endregion

		#region MessageBox 提示
		/// <summary>
		/// 显示数据库有误信息（可覆盖提供新的实现）
		/// </summary>
		protected virtual void m_mthShowDBError()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，数据库有误！");
		}

		/// <summary>
		/// 显示记录已被删除信息（可覆盖提供新的实现）
		/// </summary>
		protected virtual void m_mthShowRecordDeleted(string p_strDeleteUserID,string p_strDeleteTime)
		{
			if(p_strDeleteUserID == null || p_strDeleteUserID =="")
				return;
			if(p_strDeleteTime == null || p_strDeleteTime == "")
				return;
			string m_strDeleteTime;
			string m_strDeleteUserName;
			try
			{
				m_strDeleteUserName = new clsEmployee(p_strDeleteUserID).m_StrFirstName;
				m_strDeleteTime = DateTime.Parse(p_strDeleteTime).ToString("yyyy年MM月dd日 HH:mm:ss");
			}
			catch
			{
				return;
			}
			
			clsPublicFunction.ShowInformationMessageBox("对不起，该记录已被 "+ m_strDeleteUserName +" 于 "+m_strDeleteTime+" 删除！");
		}

		/// <summary>
		/// 显示记录已被他人修改信息（可覆盖提供新的实现）
		/// </summary>
		protected virtual bool m_bolShowRecordModified(string p_strModifyUserID,string p_strModifyTime)
		{
			//			clsPublicFunction.ShowInformationMessageBox("对不起，该记录已被他人修改！");
			if(p_strModifyUserID == null || p_strModifyUserID =="")
				return false;
			if(p_strModifyTime == null || p_strModifyTime == "")
				return false;
			string m_strModifyTime;
			string m_strModifyUserName;
			try
			{
				m_strModifyUserName = new clsEmployee(p_strModifyUserID).m_StrFirstName;
				m_strModifyTime = DateTime.Parse(p_strModifyTime).ToString("yyyy年MM月dd日 HH:mm:ss");
			}
			catch
			{
				return false;
			}
			if(clsPublicFunction.ShowQuestionMessageBox("对不起，该记录已被 "+ m_strModifyUserName +" 于 "+m_strModifyTime+" 修改，是否更新记录？") == DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 显示记录已被他人生成信息（可覆盖提供新的实现）
		/// </summary>
		protected virtual void m_mthShowRecordTimeDouble()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，该时间已经被其他用户生成过记录，您若要修改，请关闭当前窗体，再重新打开！");
		}

		/// <summary>
		/// 提示没有该病人（可覆盖提供新的实现）
		/// </summary>
		protected virtual void m_mthShowNoPatient()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
		}

		/// <summary>
		/// 提示没有该病人（可覆盖提供新的实现）
		/// </summary>
		protected virtual void m_mthShowNotPermitted()
		{
			clsPublicFunction.ShowInformationMessageBox("对不起，您的权限不够！");
		}
		#endregion

		#region RichTextBox的显示提示

		protected void m_mthAddRichTextInfo(ctlRichTextBox p_ctlTextBox)
		{
			p_ctlTextBox.m_evtMouseEnterDeleteText += new EventHandler(m_mthHandleMouseEnterDeleteText);
			p_ctlTextBox.m_evtMouseEnterInsertText += new EventHandler(m_mthHandleMouseEnterInsertText);
			p_ctlTextBox.MouseLeave += new EventHandler(m_mthHandleMouseLeaveControl);
		}

		private void m_mthHandleMouseLeaveControl(object p_objSender,EventArgs p_objArg)
		{
			m_ttpTextInfo.RemoveAll();
		}

		private void m_mthHandleMouseEnterDeleteText(object p_objSender,EventArgs p_objArg)
		{
			clsDoubleStrikeThoughEventArg objArg = (clsDoubleStrikeThoughEventArg)p_objArg;

			string strInfo = "用户ID : "+objArg.m_strUserID+"\r\n用户姓名 : "+
				objArg.m_strUserName+"\r\n删除时间 : ";

			if(objArg.m_dtmDeleteTime != m_dtmEmptyDate && objArg.m_dtmDeleteTime != DateTime.MinValue)
			{
				strInfo += objArg.m_dtmDeleteTime.ToLongDateString()+" "+objArg.m_dtmDeleteTime.ToLongTimeString();				
			}	
			else
			{
				strInfo += "----年--月--日 --:--:--";
			}
			
			m_ttpTextInfo.SetToolTip((Control)p_objSender,strInfo);
		}

		private void m_mthHandleMouseEnterInsertText(object p_objSender,EventArgs p_objArg)
		{
			com.digitalwave.Utility.Controls.clsInsertEventArg objArg = (com.digitalwave.Utility.Controls.clsInsertEventArg)p_objArg;
			
			if(objArg.m_intUserSeq == 1)
			{
				return;
			}
			
			string strInfo = "用户ID : "+objArg.m_strUserID+"\r\n用户姓名 : "+
				objArg.m_strUserName+"\r\n添加时间 : ";

			if(objArg.m_dtmInsertTime != m_dtmEmptyDate && objArg.m_dtmInsertTime != DateTime.MinValue)
			{
				strInfo += objArg.m_dtmInsertTime.ToLongDateString()+" "+objArg.m_dtmInsertTime.ToLongTimeString();				
			}	
			else
			{
				strInfo += "----年--月--日 --:--:--";
			}
			
			m_ttpTextInfo.SetToolTip((Control)p_objSender,strInfo);
		}

		#endregion

		#region 添加RichText附加属性(不包含DataGrid的边框设置)
		private ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_mthSetRichTextAttrib()
		{			
			m_mthSetRichTextEvent(this);			
		}
		#region 利用递归调用，读取并设置所有界面ctlRichTextBox控件的附加属性,Jacky-2003-2-25	
		/// <summary>
		/// 利用递归调用，读取并设置所有界面ctlRichTextBox控件的附加属性,Jacky-2003-2-25	
		/// </summary>
		/// <param name="p_ctlControl"></param>
		private void m_mthSetRichTextEvent(Control p_ctlControl)
		{
						
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] { p_ctlControl });
//				p_ctlControl.ContextMenu=m_cmuRichTextBoxMenu;
				p_ctlControl.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

				((ctlRichTextBox)p_ctlControl).m_StrUserID = MDIParent.strOperatorID;
				((ctlRichTextBox)p_ctlControl).m_StrUserName = MDIParent.strOperatorName;
				((ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = Color.Black;
				((ctlRichTextBox)p_ctlControl).m_ClrDST = Color.Red;
				m_mthAddRichTextInfo( (ctlRichTextBox)p_ctlControl );
			}
			
			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextEvent(subcontrol);						
				} 	
			}				
		}
		#endregion
		/// <summary>
		/// 双划线删除事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}
		/// <summary>
		/// RichTextBox 获得焦点时的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((ctlRichTextBox)(sender));
		}
		#endregion

		#region 添加键盘快捷键
		/// <summary>
		/// 添加键盘快捷键
		/// </summary>
		protected void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
		/// <summary>
		/// 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
		/// </summary>
		/// <param name="p_ctlControl"></param>
		private void m_mthSetControlEvent(Control p_ctlControl)
		{

			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthBaseEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			

		}
		
		/// <summary>
		/// 子类可覆盖实现
		/// </summary>
		protected virtual void m_mthBaseEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			
		}
		#endregion
		#endregion


		#region 设置是否允许修改（修改留痕迹），以及修改颜色

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsBeforeOperationSummaryContentInfo p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
			}
			else if(p_objRecordContent!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
			}
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")			
				((ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;				
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}
		#endregion
	}
}
