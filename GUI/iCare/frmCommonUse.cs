using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmCommonUse.
	/// </summary>
	public class frmCommonUse : iCare.iCareBaseForm.frmBaseForm,PublicFunction
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ColumnHeader clmCommonUseID;
		private System.Windows.Forms.ColumnHeader clmCommonUseValue;
		private System.Windows.Forms.Label lblCommonUseTypeTitle;
		private System.Windows.Forms.Button m_cmdDel;
		private System.Windows.Forms.Button m_cmdAdd;
		private System.Windows.Forms.ListView m_lsvCommonUseValue;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtCommonUseValue;
		private System.Windows.Forms.Label lblCommonUseValueTitle;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCommonUseType;
		private System.Windows.Forms.Button m_cmdModify;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCommonUse()
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
            //objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvCommonUseValue});
		
			
		}

		protected ctlHighLightFocus m_objHighLight;
		clsCommonUseDomain m_objDomain=new clsCommonUseDomain();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCommonUse));
			this.clmCommonUseID = new System.Windows.Forms.ColumnHeader();
			this.clmCommonUseValue = new System.Windows.Forms.ColumnHeader();
			this.lblCommonUseTypeTitle = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.m_cmdDel = new System.Windows.Forms.Button();
			this.m_cmdAdd = new System.Windows.Forms.Button();
			this.m_lsvCommonUseValue = new System.Windows.Forms.ListView();
			this.m_txtCommonUseValue = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblCommonUseValueTitle = new System.Windows.Forms.Label();
			this.m_cboCommonUseType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cmdModify = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// clmCommonUseID
			// 
			this.clmCommonUseID.Text = "编号";
			this.clmCommonUseID.Width = 0;
			// 
			// clmCommonUseValue
			// 
			this.clmCommonUseValue.Text = "                 已有常用值";
			this.clmCommonUseValue.Width = 385;
			// 
			// lblCommonUseTypeTitle
			// 
			this.lblCommonUseTypeTitle.AutoSize = true;
			this.lblCommonUseTypeTitle.ForeColor = System.Drawing.Color.White;
			this.lblCommonUseTypeTitle.Location = new System.Drawing.Point(412, 80);
			this.lblCommonUseTypeTitle.Name = "lblCommonUseTypeTitle";
			this.lblCommonUseTypeTitle.Size = new System.Drawing.Size(96, 19);
			this.lblCommonUseTypeTitle.TabIndex = 414;
			this.lblCommonUseTypeTitle.Text = "常用值类别:";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(252, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(176, 37);
			this.lblTitle.TabIndex = 421;
			this.lblTitle.Text = "常用值录入";
			// 
			// m_cmdDel
			// 
			this.m_cmdDel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdDel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdDel.ForeColor = System.Drawing.Color.White;
			this.m_cmdDel.Location = new System.Drawing.Point(560, 248);
			this.m_cmdDel.Name = "m_cmdDel";
			this.m_cmdDel.Size = new System.Drawing.Size(64, 32);
			this.m_cmdDel.TabIndex = 160;
			this.m_cmdDel.Text = "删除";
			this.m_cmdDel.Click += new System.EventHandler(this.m_cmdDel_Click);
			// 
			// m_cmdAdd
			// 
			this.m_cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdAdd.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdAdd.ForeColor = System.Drawing.Color.White;
			this.m_cmdAdd.Location = new System.Drawing.Point(416, 248);
			this.m_cmdAdd.Name = "m_cmdAdd";
			this.m_cmdAdd.Size = new System.Drawing.Size(64, 32);
			this.m_cmdAdd.TabIndex = 130;
			this.m_cmdAdd.Text = "增加";
			this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
			// 
			// m_lsvCommonUseValue
			// 
			this.m_lsvCommonUseValue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvCommonUseValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvCommonUseValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.clmCommonUseID,
																								  this.clmCommonUseValue});
			this.m_lsvCommonUseValue.ForeColor = System.Drawing.Color.White;
			this.m_lsvCommonUseValue.FullRowSelect = true;
			this.m_lsvCommonUseValue.GridLines = true;
			this.m_lsvCommonUseValue.HideSelection = false;
			this.m_lsvCommonUseValue.Location = new System.Drawing.Point(16, 76);
			this.m_lsvCommonUseValue.MultiSelect = false;
			this.m_lsvCommonUseValue.Name = "m_lsvCommonUseValue";
			this.m_lsvCommonUseValue.Size = new System.Drawing.Size(386, 208);
			this.m_lsvCommonUseValue.TabIndex = 100;
			this.m_lsvCommonUseValue.View = System.Windows.Forms.View.Details;
			this.m_lsvCommonUseValue.Click += new System.EventHandler(this.m_lsvCommonUseValue_Click);
			// 
			// m_txtCommonUseValue
			// 
			this.m_txtCommonUseValue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtCommonUseValue.BorderColor = System.Drawing.Color.White;
			this.m_txtCommonUseValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtCommonUseValue.ForeColor = System.Drawing.SystemColors.Window;
			this.m_txtCommonUseValue.Location = new System.Drawing.Point(416, 168);
			this.m_txtCommonUseValue.Multiline = true;
			this.m_txtCommonUseValue.Name = "m_txtCommonUseValue";
			this.m_txtCommonUseValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.m_txtCommonUseValue.Size = new System.Drawing.Size(272, 52);
			this.m_txtCommonUseValue.TabIndex = 120;
			this.m_txtCommonUseValue.Text = "";
			// 
			// lblCommonUseValueTitle
			// 
			this.lblCommonUseValueTitle.AutoSize = true;
			this.lblCommonUseValueTitle.ForeColor = System.Drawing.Color.White;
			this.lblCommonUseValueTitle.Location = new System.Drawing.Point(412, 144);
			this.lblCommonUseValueTitle.Name = "lblCommonUseValueTitle";
			this.lblCommonUseValueTitle.Size = new System.Drawing.Size(72, 19);
			this.lblCommonUseValueTitle.TabIndex = 422;
			this.lblCommonUseValueTitle.Text = "常用值：";
			// 
			// m_cboCommonUseType
			// 
			this.m_cboCommonUseType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCommonUseType.BorderColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCommonUseType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCommonUseType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCommonUseType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCommonUseType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCommonUseType.ForeColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCommonUseType.ListForeColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboCommonUseType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.Location = new System.Drawing.Point(416, 108);
			this.m_cboCommonUseType.Name = "m_cboCommonUseType";
			this.m_cboCommonUseType.SelectedIndex = -1;
			this.m_cboCommonUseType.SelectedItem = null;
			this.m_cboCommonUseType.Size = new System.Drawing.Size(272, 26);
			this.m_cboCommonUseType.TabIndex = 110;
			this.m_cboCommonUseType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboCommonUseType.TextForeColor = System.Drawing.Color.White;
			this.m_cboCommonUseType.Load += new System.EventHandler(this.m_cboCommonUseType_Load);
			this.m_cboCommonUseType.SelectedIndexChanged += new System.EventHandler(this.m_cboCommonUseType_SelectedIndexChanged);
			// 
			// m_cmdModify
			// 
			this.m_cmdModify.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_cmdModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdModify.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdModify.ForeColor = System.Drawing.Color.White;
			this.m_cmdModify.Location = new System.Drawing.Point(488, 248);
			this.m_cmdModify.Name = "m_cmdModify";
			this.m_cmdModify.Size = new System.Drawing.Size(64, 32);
			this.m_cmdModify.TabIndex = 140;
			this.m_cmdModify.Text = "修改";
			this.m_cmdModify.Click += new System.EventHandler(this.m_cmdModify_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdCancel.Location = new System.Drawing.Point(632, 248);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.cmdCancel.TabIndex = 423;
			this.cmdCancel.Text = "取消";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmCommonUse
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(704, 313);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCancel,
																		  this.m_cboCommonUseType,
																		  this.lblCommonUseValueTitle,
																		  this.lblCommonUseTypeTitle,
																		  this.lblTitle,
																		  this.m_cmdDel,
																		  this.m_cmdAdd,
																		  this.m_lsvCommonUseValue,
																		  this.m_txtCommonUseValue,
																		  this.m_cmdModify});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmCommonUse";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "常用值录入";
			this.Load += new System.EventHandler(this.frmCommonUse_Load);
			this.ResumeLayout(false);

		}
		#endregion		

		private void m_cboCommonUseType_Load(object sender, System.EventArgs e)
		{
			clsPublicIDAndName[] objclsPublicIDAndNameArr;
			m_objDomain.m_lngGetAllCommonUseType(out objclsPublicIDAndNameArr);
			if(objclsPublicIDAndNameArr!=null)				
				m_cboCommonUseType.AddRangeItems(objclsPublicIDAndNameArr);					

			m_objHighLight.m_mthAddControlInContainer(this);
			m_cboCommonUseType.Focus();
		}

		private void m_cboCommonUseType_SelectedIndexChanged(object sender, System.EventArgs e)
		{		
			m_blnIsAddNew=true;
			m_txtCommonUseValue.Text="";
			m_lsvCommonUseValue.Items.Clear();
			if(m_cboCommonUseType.GetItemsCount() ==0)
				return;
			clsCommonUseValue[] objclsCommonUseValue=null;
			if(m_cboCommonUseType.SelectedItem !=null)
				m_objDomain.m_lngGetAllCommonUseValue(((clsPublicIDAndName)(m_cboCommonUseType.SelectedItem)).m_strID,out objclsCommonUseValue);
			if(objclsCommonUseValue!=null)
				for(int i=0;i<objclsCommonUseValue.Length;i++)
				{
					ListViewItem lviNew = m_lsvCommonUseValue.Items.Add(objclsCommonUseValue[i].m_strTypeID);
					lviNew.SubItems.Add(objclsCommonUseValue[i].m_strCommonUseValue);
				}
			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvCommonUseValue,11);
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
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
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
		private void m_mthSetGUIFromContent(clsCommonUseValue p_objContent)
		{
			if(p_objContent==null)
				return;
			for(int i=0;i<m_cboCommonUseType.GetItemsCount();i++)
			{
				if(((clsPublicIDAndName)(m_cboCommonUseType.GetItem(i))).m_strID==p_objContent.m_strTypeID)
					m_cboCommonUseType.SelectedIndex=i;
			}			
			this.m_txtCommonUseValue.Text=p_objContent.m_strCommonUseValue;			
		}

		/// <summary>
		/// 从界面获取表单值
		/// </summary>
		/// <returns></returns>
		private clsCommonUseValue m_objGetContentFromGUI()
		{		
			if(this.m_cboCommonUseType.SelectedItem==null || this.m_cboCommonUseType.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择常用值类别！");
				return null;
			}
			//从界面获取表单值		
			clsCommonUseValue objCommonUseValue=new clsCommonUseValue();
			objCommonUseValue.m_strTypeID=((clsPublicIDAndName)(m_cboCommonUseType.SelectedItem)).m_strID;
			objCommonUseValue.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			objCommonUseValue.m_strCommonUseValue=this.m_txtCommonUseValue.Text.Trim();
			
			return objCommonUseValue;
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
			clsCommonUseValue objCommonUseValue=m_objGetContentFromGUI();
			if(objCommonUseValue==null)
			{				
				return -1;
			}

			long lngRes=0;

			if( m_blnIsAddNew)
				lngRes= m_objDomain.m_lngAddNewRecord2DB(objCommonUseValue);
			else 
			{
				if(this.m_lsvCommonUseValue.SelectedItems.Count==0)
				{
					clsPublicFunction.ShowInformationMessageBox("请在左边树中选择要修改的常用值！");
					return 0;
				}

				if(!clsPublicFunction.s_blnAskForModify())
					return 0;

				clsCommonUseValue objOld=new clsCommonUseValue();
				objOld.m_strTypeID=objCommonUseValue.m_strTypeID;
				objOld.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
				objOld.m_strCommonUseValue=this.m_lsvCommonUseValue.SelectedItems[0].SubItems[1].Text;
				lngRes= m_objDomain.m_lngModifyRecord2DB(objOld,objCommonUseValue);
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
			else if(m_blnIsAddNew)//lngRes>0
			{
				ListViewItem lviNewItem=m_lsvCommonUseValue.Items.Add(objCommonUseValue.m_strTypeID);		
				lviNewItem.SubItems.Add(objCommonUseValue.m_strCommonUseValue);
				m_blnIsAddNew=false;
				
				m_lsvCommonUseValue.Items[m_lsvCommonUseValue.Items.Count-1].Selected=true;
				
			}
			else 
			{
				m_lsvCommonUseValue.SelectedItems[0].SubItems[1].Text=objCommonUseValue.m_strCommonUseValue;

			}

			return lngRes;
		}

		private long  m_lngDelete()
		{
			if( m_blnIsAddNew )
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,清先选择要删除的常用值!");				
				return 1;
			}
			
			if(!clsPublicFunction.s_blnAskForDelete())
				return 1;

			clsCommonUseValue objCommonUseValue=m_objGetContentFromGUI();
			if(objCommonUseValue==null || objCommonUseValue.m_strCommonUseValue==null)
				return 1;
			long lngRes= m_objDomain.m_lngDeleteRecord2DB(objCommonUseValue);

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
				this.m_txtCommonUseValue.Text="";
				if(this.m_lsvCommonUseValue.SelectedItems.Count>0)
					this.m_lsvCommonUseValue.SelectedItems[0].Remove();
			}
			return lngRes;
		}

		private void  m_mthClearUp()
		{
			this.m_txtCommonUseValue.Text="";
			this.m_cboCommonUseType.SelectedIndex=-1;
			this.m_lsvCommonUseValue.Items.Clear();
		}

		private void m_lsvCommonUseValue_Click(object sender, System.EventArgs e)
		{
			if(m_lsvCommonUseValue.SelectedItems.Count>0)
				this.m_txtCommonUseValue.Text=m_lsvCommonUseValue.SelectedItems[0].SubItems[1].Text.Trim();
			m_blnIsAddNew=false;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmCommonUse_Load(object sender, System.EventArgs e)
		{
			m_lsvCommonUseValue.Focus();
		}				
	}
}
