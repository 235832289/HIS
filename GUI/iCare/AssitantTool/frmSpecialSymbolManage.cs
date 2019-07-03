using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare.AssitantTool
{
	/// <summary>
	/// Summary description for frmSpecialSymbolManage.
	/// </summary>
	public class frmSpecialSymbolManage : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSpecialSymbolValueTitle;
		private System.Windows.Forms.ListView m_lsvSpecialSymbolValue;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSpecialSymbolValue;
		private System.Windows.Forms.ColumnHeader clmSpecialSymbolID;
		private System.Windows.Forms.ColumnHeader clmSpecialSymbolValue;
		private PinkieControls.ButtonXP m_cmdAdd;
		private PinkieControls.ButtonXP m_cmdModify;
		private PinkieControls.ButtonXP m_cmdDel;
		private PinkieControls.ButtonXP cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSpecialSymbolManage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
            //objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool(Color.White);
            //objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvSpecialSymbolValue});
		}

        protected ctlHighLightFocus m_objHighLight;
		clsSpecialSymbolDomain m_objDomain=new clsSpecialSymbolDomain();
        //private com.digitalwave.Utility.Controls.clsBorderTool objBorderTool;
		private bool m_blnIsAddNew;	

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSpecialSymbolManage));
			this.clmSpecialSymbolID = new System.Windows.Forms.ColumnHeader();
			this.lblSpecialSymbolValueTitle = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.m_lsvSpecialSymbolValue = new System.Windows.Forms.ListView();
			this.clmSpecialSymbolValue = new System.Windows.Forms.ColumnHeader();
			this.m_txtSpecialSymbolValue = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cmdAdd = new PinkieControls.ButtonXP();
			this.m_cmdModify = new PinkieControls.ButtonXP();
			this.m_cmdDel = new PinkieControls.ButtonXP();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// clmSpecialSymbolID
			// 
			this.clmSpecialSymbolID.Text = "编号";
			this.clmSpecialSymbolID.Width = 0;
			// 
			// lblSpecialSymbolValueTitle
			// 
			this.lblSpecialSymbolValueTitle.AutoSize = true;
			this.lblSpecialSymbolValueTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSpecialSymbolValueTitle.ForeColor = System.Drawing.Color.Black;
			this.lblSpecialSymbolValueTitle.Location = new System.Drawing.Point(224, 12);
			this.lblSpecialSymbolValueTitle.Name = "lblSpecialSymbolValueTitle";
			this.lblSpecialSymbolValueTitle.Size = new System.Drawing.Size(77, 19);
			this.lblSpecialSymbolValueTitle.TabIndex = 432;
			this.lblSpecialSymbolValueTitle.Text = "特殊符号：";
			this.lblSpecialSymbolValueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(4, 4);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(143, 40);
			this.lblTitle.TabIndex = 431;
			this.lblTitle.Text = "特殊符号";
			this.lblTitle.Visible = false;
			// 
			// m_lsvSpecialSymbolValue
			// 
			this.m_lsvSpecialSymbolValue.BackColor = System.Drawing.SystemColors.Window;
			this.m_lsvSpecialSymbolValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									  this.clmSpecialSymbolID,
																									  this.clmSpecialSymbolValue});
			this.m_lsvSpecialSymbolValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvSpecialSymbolValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_lsvSpecialSymbolValue.FullRowSelect = true;
			this.m_lsvSpecialSymbolValue.GridLines = true;
			this.m_lsvSpecialSymbolValue.HideSelection = false;
			this.m_lsvSpecialSymbolValue.Location = new System.Drawing.Point(8, 8);
			this.m_lsvSpecialSymbolValue.MultiSelect = false;
			this.m_lsvSpecialSymbolValue.Name = "m_lsvSpecialSymbolValue";
			this.m_lsvSpecialSymbolValue.Size = new System.Drawing.Size(204, 168);
			this.m_lsvSpecialSymbolValue.TabIndex = 424;
			this.m_lsvSpecialSymbolValue.View = System.Windows.Forms.View.Details;
			this.m_lsvSpecialSymbolValue.Click += new System.EventHandler(this.m_lsvSpecialSymbolValue_Click);
			// 
			// clmSpecialSymbolValue
			// 
			this.clmSpecialSymbolValue.Text = "已有符号";
			this.clmSpecialSymbolValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clmSpecialSymbolValue.Width = 200;
			// 
			// m_txtSpecialSymbolValue
			// 
			this.m_txtSpecialSymbolValue.BackColor = System.Drawing.Color.White;
			this.m_txtSpecialSymbolValue.BorderColor = System.Drawing.Color.White;
			this.m_txtSpecialSymbolValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSpecialSymbolValue.ForeColor = System.Drawing.Color.Black;
			this.m_txtSpecialSymbolValue.Location = new System.Drawing.Point(220, 40);
			this.m_txtSpecialSymbolValue.Multiline = true;
			this.m_txtSpecialSymbolValue.Name = "m_txtSpecialSymbolValue";
			this.m_txtSpecialSymbolValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtSpecialSymbolValue.Size = new System.Drawing.Size(272, 96);
			this.m_txtSpecialSymbolValue.TabIndex = 426;
			this.m_txtSpecialSymbolValue.Text = "";
			// 
			// m_cmdAdd
			// 
			this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAdd.DefaultScheme = true;
			this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAdd.ForeColor = System.Drawing.Color.Black;
			this.m_cmdAdd.Hint = "";
			this.m_cmdAdd.Location = new System.Drawing.Point(220, 144);
			this.m_cmdAdd.Name = "m_cmdAdd";
			this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAdd.Size = new System.Drawing.Size(68, 32);
			this.m_cmdAdd.TabIndex = 10000001;
			this.m_cmdAdd.Text = "增 加";
			this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
			// 
			// m_cmdModify
			// 
			this.m_cmdModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdModify.DefaultScheme = true;
			this.m_cmdModify.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdModify.ForeColor = System.Drawing.Color.Black;
			this.m_cmdModify.Hint = "";
			this.m_cmdModify.Location = new System.Drawing.Point(288, 144);
			this.m_cmdModify.Name = "m_cmdModify";
			this.m_cmdModify.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdModify.Size = new System.Drawing.Size(68, 32);
			this.m_cmdModify.TabIndex = 10000002;
			this.m_cmdModify.Text = "修 改";
			this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
			// 
			// m_cmdDel
			// 
			this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDel.DefaultScheme = true;
			this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDel.ForeColor = System.Drawing.Color.Black;
			this.m_cmdDel.Hint = "";
			this.m_cmdDel.Location = new System.Drawing.Point(356, 144);
			this.m_cmdDel.Name = "m_cmdDel";
			this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDel.Size = new System.Drawing.Size(68, 32);
			this.m_cmdDel.TabIndex = 10000003;
			this.m_cmdDel.Text = "删 除";
			this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCancel.ForeColor = System.Drawing.Color.Black;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(424, 144);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(68, 32);
			this.cmdCancel.TabIndex = 10000004;
			this.cmdCancel.Text = "取 消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmSpecialSymbolManage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(502, 183);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.m_cmdDel);
			this.Controls.Add(this.m_cmdModify);
			this.Controls.Add(this.m_cmdAdd);
			this.Controls.Add(this.lblSpecialSymbolValueTitle);
			this.Controls.Add(this.m_txtSpecialSymbolValue);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.m_lsvSpecialSymbolValue);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmSpecialSymbolManage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "特殊符号";
			this.Load += new System.EventHandler(this.frmSpecialSymbolManage_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 填充符号到ListView控件m_lsvSpecialSymbolValue
		/// </summary>
		private void m_mthSpecialSymbolLoad()
		{
			m_lsvSpecialSymbolValue.Items.Clear();
			clsSpecialSymbolValue[] objclsSpecialSymbolValue = null;

            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea == null)
                return;

			m_objDomain.m_lngGetAlSpecialSymbolValue(out objclsSpecialSymbolValue);
			if(objclsSpecialSymbolValue != null)
				for(int i=0;i<objclsSpecialSymbolValue.Length;i++)
				{
                    if (string.IsNullOrEmpty(objclsSpecialSymbolValue[i].m_strSpecialSymbolValue)) continue;
					ListViewItem lviNew = m_lsvSpecialSymbolValue.Items.Add(objclsSpecialSymbolValue[i].m_strDeptID);
					lviNew.SubItems.Add(objclsSpecialSymbolValue[i].m_strSpecialSymbolValue);
				}
			if (m_lsvSpecialSymbolValue.Items.Count > 0)
				m_lsvSpecialSymbolValue.Items[0].Selected = true;
			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvSpecialSymbolValue,11);
		}

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

		# region PublicFuction
		public void Save()
		{			
			this.m_lngSave();
		}		
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display()
		{
		}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{ 			
		}		
		public void Display(string cardno,string sendcheckdate){}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{			
		}
		
	
		#endregion

		private void m_cmdAdd_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew=true;
			m_lngSave();
		}

		private void m_cmdModify_Click(object sender, System.EventArgs e)
		{
			m_blnIsAddNew=false;
			m_lngSave();
		}

		private void m_cmdDel_Click(object sender, System.EventArgs e)
		{
			m_lngDelete();
		}

		/// <summary>
		/// 设置界面值
		/// </summary>
		/// <param name="p_objContent"></param>
		private void m_mthSetGUIFromContent(clsSpecialSymbolValue p_objContent)
		{
			if(p_objContent==null)
				return;
			this.m_txtSpecialSymbolValue.Text=p_objContent.m_strSpecialSymbolValue;			
		}

		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsSpecialSymbolValue m_objGetContentFromGUI()
		{		
			//从界面获取表单值		
			clsSpecialSymbolValue objSpecialSymbolValue=new clsSpecialSymbolValue();
//			objSpecialSymbolValue.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			objSpecialSymbolValue.m_strDeptID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR;
			objSpecialSymbolValue.m_strSpecialSymbolValue = this.m_txtSpecialSymbolValue.Text.Trim();
			
			return objSpecialSymbolValue;
		}

		
		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren  && strTypeName !="DateTimePicker")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter
					break;

				case 38:
				case 40:									
					break;
				case 113://save
					this.Save(); 
					break;
				case 114://del
					this.Delete(); 
					break;
				case 115://print
					this.Print();
					break;
				case 116://refresh
					m_mthClearUp();
					break;
				case 117://Search					
					break;
			}	
		}		
		#endregion			

		private long  m_lngSave()
		{
            if (this.m_txtSpecialSymbolValue.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("不能保存空符号！");
                this.m_txtSpecialSymbolValue.Focus();
                return 0;
            }
            if (m_lsvSpecialSymbolValue.Items.Count > 0)
            {
                ListViewItem item = m_lsvSpecialSymbolValue.FindItemWithText(this.m_txtSpecialSymbolValue.Text.Trim(), true, 0);
                if (item != null)
                {
                    clsPublicFunction.ShowInformationMessageBox("不能重复保存符号！");
                    item.Selected = true;
                    item.EnsureVisible();
                    this.m_txtSpecialSymbolValue.Focus();
                    return 0;
                }
            }
            if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea == null
                || string.IsNullOrEmpty(com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR))
            {
                clsPublicFunction.ShowInformationMessageBox("请先指定一个科室！");
            }

			clsSpecialSymbolValue objSpecialSymbolValue=m_objGetContentFromGUI();
			if(objSpecialSymbolValue==null)
			{				
				return -1;
			}

			long lngRes=0;

			if( m_blnIsAddNew)
				lngRes= m_objDomain.m_lngAddNewRecord2DB(objSpecialSymbolValue);
			else 
			{
				if(this.m_lsvSpecialSymbolValue.SelectedItems.Count==0)
				{
					clsPublicFunction.ShowInformationMessageBox("请在左边列表中选择要修改的常用值！");
					return 0;
				}

				if(!clsPublicFunction.s_blnAskForModify())
					return 0;

				clsSpecialSymbolValue objOld=new clsSpecialSymbolValue();
				objOld.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
				objOld.m_strSpecialSymbolValue=this.m_lsvSpecialSymbolValue.SelectedItems[0].SubItems[1].Text;
				lngRes= m_objDomain.m_lngModifyRecord2DB(objOld,objSpecialSymbolValue);
			}
			if(lngRes<=0)
			{
				if(lngRes==(long)iCareData.enmOperationResult.Parameter_Error)
				{
					clsPublicFunction.ShowInformationMessageBox("参数错误");
				}
				else if(lngRes==(long)iCareData.enmOperationResult.Not_permission)
				{
					clsPublicFunction.s_mthShowNotPermitMessage();
				}
				else if(lngRes==(long)iCareData.enmOperationResult.Record_Already_Exist)
				{
					clsPublicFunction.ShowInformationMessageBox("对不起，该记录已经存在，不能添加相同的记录!");
				}
				else if(lngRes==(long)iCareData.enmOperationResult.Record_Already_Delete)
				{
					clsPublicFunction.ShowInformationMessageBox("对不起，该记录已被他人删除!");
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("保存失败");
				}
			}
			else if(m_blnIsAddNew)
			{
				ListViewItem lviNewItem=m_lsvSpecialSymbolValue.Items.Add(objSpecialSymbolValue.m_strDeptID);		
				lviNewItem.SubItems.Add(objSpecialSymbolValue.m_strSpecialSymbolValue);
				m_blnIsAddNew=false;
				
				m_lsvSpecialSymbolValue.Items[m_lsvSpecialSymbolValue.Items.Count-1].Selected=true;
				
			}
			else 
			{
				m_lsvSpecialSymbolValue.SelectedItems[0].SubItems[1].Text=objSpecialSymbolValue.m_strSpecialSymbolValue;

			}

			return lngRes;
		}

		private long  m_lngDelete()
		{
            if (m_lsvSpecialSymbolValue.SelectedIndices.Count <= 0)
                return 1;
			if( m_blnIsAddNew )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,请先选择要删除的特殊符号!");				
				return 1;
			}
			
			if(!clsPublicFunction.s_blnAskForDelete())
				return 1;

			clsSpecialSymbolValue objSpecialSymbolValue = new clsSpecialSymbolValue();
            objSpecialSymbolValue.m_strDeptID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR;
            objSpecialSymbolValue.m_strSpecialSymbolValue = m_lsvSpecialSymbolValue.SelectedItems[0].SubItems[1].Text.Trim();

			if(objSpecialSymbolValue == null || objSpecialSymbolValue.m_strSpecialSymbolValue == null)
				return 1;
			long lngRes= m_objDomain.m_lngDeleteRecord2DB(objSpecialSymbolValue);

			if(lngRes<=0)
			{
				if(lngRes==(long)iCareData.enmOperationResult.Parameter_Error)
				{
					clsPublicFunction.ShowInformationMessageBox("参数错误");
				}
				else if(lngRes==(long)iCareData.enmOperationResult.Not_permission)
				{
					clsPublicFunction.s_mthShowNotPermitMessage();
				}
				else
				{
					clsPublicFunction.ShowInformationMessageBox("删除失败");
				}
			}
			else 
			{
				this.m_txtSpecialSymbolValue.Text="";
				if(this.m_lsvSpecialSymbolValue.SelectedItems.Count>0)
					this.m_lsvSpecialSymbolValue.SelectedItems[0].Remove();
			}
			return lngRes;
		}

		private void  m_mthClearUp()
		{
			this.m_txtSpecialSymbolValue.Text="";
			this.m_lsvSpecialSymbolValue.Items.Clear();
		}

		private void m_lsvSpecialSymbolValue_Click(object sender, System.EventArgs e)
		{
			if(m_lsvSpecialSymbolValue.SelectedItems.Count>0)
				this.m_txtSpecialSymbolValue.Text=m_lsvSpecialSymbolValue.SelectedItems[0].SubItems[1].Text.Trim();
			m_blnIsAddNew=false;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmSpecialSymbolManage_Load(object sender, System.EventArgs e)
		{
			m_lsvSpecialSymbolValue.Focus();
			m_mthSpecialSymbolLoad();
		}

		
	}
}
