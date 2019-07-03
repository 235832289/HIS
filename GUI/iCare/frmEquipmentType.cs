//#define FunctionPrivilege
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using PrivilegeData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmEquipmentType.
	/// </summary>
	public class frmEquipmentType : iCare.iCareBaseForm.frmBaseForm,PublicFunction
	{
		private System.Windows.Forms.ListView lsvEquipmentType;
		private System.Windows.Forms.ColumnHeader clhEquimentID;
		private System.Windows.Forms.ColumnHeader clhEquimentName;
		private System.Windows.Forms.Label lblEquimentName;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtEquimentName;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdDel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private clsEquipmentTypeDomain objDomain;
		
        //private com.digitalwave.EquipmentTypeService.clsEquipmentTypeService objETServ;
		private System.Windows.Forms.Label lblEquipmentTypeIDText;
		private System.Windows.Forms.Label lblTitle;
		private string g_strEquipmentTypeID = "";
		private System.Windows.Forms.Button cmdExit;
		private System.Windows.Forms.Label lblPYCode;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtPYCode;
        //private com.digitalwave.Utility.Controls.clsBorderTool objBorderTool;

		public frmEquipmentType()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			objDomain = new clsEquipmentTypeDomain();
			
            //objETServ = new com.digitalwave.EquipmentTypeService.clsEquipmentTypeService();
            //objBorderTool = new com.digitalwave.Utility.Controls.clsBorderTool(Color.White);
            //objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{lsvEquipmentType});
		
			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
		}

		protected ctlHighLightFocus m_objHighLight;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEquipmentType));
			this.lsvEquipmentType = new System.Windows.Forms.ListView();
			this.clhEquimentID = new System.Windows.Forms.ColumnHeader();
			this.clhEquimentName = new System.Windows.Forms.ColumnHeader();
			this.lblEquimentName = new System.Windows.Forms.Label();
			this.txtEquimentName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDel = new System.Windows.Forms.Button();
			this.lblEquipmentTypeIDText = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.cmdExit = new System.Windows.Forms.Button();
			this.lblPYCode = new System.Windows.Forms.Label();
			this.txtPYCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.SuspendLayout();
			// 
			// lsvEquipmentType
			// 
			this.lsvEquipmentType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.lsvEquipmentType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lsvEquipmentType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.clhEquimentID,
																							   this.clhEquimentName});
			this.lsvEquipmentType.ForeColor = System.Drawing.Color.White;
			this.lsvEquipmentType.FullRowSelect = true;
			this.lsvEquipmentType.GridLines = true;
			this.lsvEquipmentType.Location = new System.Drawing.Point(32, 72);
			this.lsvEquipmentType.Name = "lsvEquipmentType";
			this.lsvEquipmentType.Size = new System.Drawing.Size(168, 240);
			this.lsvEquipmentType.TabIndex = 404;
			this.lsvEquipmentType.View = System.Windows.Forms.View.Details;
			this.lsvEquipmentType.Click += new System.EventHandler(this.lsvEquipmentType_Click);
			this.lsvEquipmentType.SelectedIndexChanged += new System.EventHandler(this.lsvEquipmentType_SelectedIndexChanged);
			// 
			// clhEquimentID
			// 
			this.clhEquimentID.Text = "编号";
			this.clhEquimentID.Width = 0;
			// 
			// clhEquimentName
			// 
			this.clhEquimentName.Text = " 编  号  名  称";
			this.clhEquimentName.Width = 150;
			// 
			// lblEquimentName
			// 
			this.lblEquimentName.ForeColor = System.Drawing.Color.White;
			this.lblEquimentName.Location = new System.Drawing.Point(232, 96);
			this.lblEquimentName.Name = "lblEquimentName";
			this.lblEquimentName.Size = new System.Drawing.Size(100, 20);
			this.lblEquimentName.TabIndex = 406;
			this.lblEquimentName.Text = "编号名称：";
			// 
			// txtEquimentName
			// 
			this.txtEquimentName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtEquimentName.BorderColor = System.Drawing.Color.White;
			this.txtEquimentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtEquimentName.ForeColor = System.Drawing.SystemColors.Window;
			this.txtEquimentName.Location = new System.Drawing.Point(232, 128);
			this.txtEquimentName.Name = "txtEquimentName";
			this.txtEquimentName.Size = new System.Drawing.Size(216, 26);
			this.txtEquimentName.TabIndex = 407;
			this.txtEquimentName.Text = "";
			// 
			// cmdAdd
			// 
			this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdAdd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdAdd.ForeColor = System.Drawing.Color.White;
			this.cmdAdd.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdAdd.Image")));
			this.cmdAdd.Location = new System.Drawing.Point(232, 248);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(48, 48);
			this.cmdAdd.TabIndex = 408;
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDel
			// 
			this.cmdDel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdDel.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdDel.ForeColor = System.Drawing.Color.White;
			this.cmdDel.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdDel.Image")));
			this.cmdDel.Location = new System.Drawing.Point(312, 248);
			this.cmdDel.Name = "cmdDel";
			this.cmdDel.Size = new System.Drawing.Size(48, 48);
			this.cmdDel.TabIndex = 409;
			this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
			// 
			// lblEquipmentTypeIDText
			// 
			this.lblEquipmentTypeIDText.ForeColor = System.Drawing.Color.White;
			this.lblEquipmentTypeIDText.Location = new System.Drawing.Point(72, 32);
			this.lblEquipmentTypeIDText.Name = "lblEquipmentTypeIDText";
			this.lblEquipmentTypeIDText.Size = new System.Drawing.Size(40, 23);
			this.lblEquipmentTypeIDText.TabIndex = 410;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("SimSun", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(156, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(242, 37);
			this.lblTitle.TabIndex = 411;
			this.lblTitle.Text = "初始化设备类型";
			// 
			// cmdExit
			// 
			this.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdExit.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdExit.ForeColor = System.Drawing.Color.White;
			this.cmdExit.Image = ((System.Drawing.Bitmap)(resources.GetObject("cmdExit.Image")));
			this.cmdExit.Location = new System.Drawing.Point(396, 248);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(48, 48);
			this.cmdExit.TabIndex = 409;
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// lblPYCode
			// 
			this.lblPYCode.ForeColor = System.Drawing.Color.White;
			this.lblPYCode.Location = new System.Drawing.Point(232, 168);
			this.lblPYCode.Name = "lblPYCode";
			this.lblPYCode.Size = new System.Drawing.Size(100, 20);
			this.lblPYCode.TabIndex = 406;
			this.lblPYCode.Text = "编号名称：";
			// 
			// txtPYCode
			// 
			this.txtPYCode.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtPYCode.BorderColor = System.Drawing.Color.White;
			this.txtPYCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPYCode.ForeColor = System.Drawing.SystemColors.Window;
			this.txtPYCode.Location = new System.Drawing.Point(232, 200);
			this.txtPYCode.Name = "txtPYCode";
			this.txtPYCode.Size = new System.Drawing.Size(216, 26);
			this.txtPYCode.TabIndex = 407;
			this.txtPYCode.Text = "";
			// 
			// frmEquipmentType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(488, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtEquimentName,
																		  this.lblEquimentName,
																		  this.lblTitle,
																		  this.lblEquipmentTypeIDText,
																		  this.cmdDel,
																		  this.cmdAdd,
																		  this.lsvEquipmentType,
																		  this.cmdExit,
																		  this.lblPYCode,
																		  this.txtPYCode});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmEquipmentType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "初始化设备类型";
			this.Load += new System.EventHandler(this.frmEquipmentType_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			clsEquipmentTypeInfo objETInfo = new clsEquipmentTypeInfo();
			try
			{
				if(this.txtEquimentName.Text == ""&&this.lblEquipmentTypeIDText.Text == "")
				{
					MessageBox.Show("对不起，该设备编号或设备名称不在右列！");
				}
				else
				{
					objETInfo.strEquipmentTypeID = ((int.Parse(objDomain.m_strGetRecordCount()))+1).ToString().PadLeft(3,'0');
					objETInfo.strEquipmentTypeName = this.txtEquimentName.Text ;
					objETInfo.strBegin_Type_Date  = System.DateTime.Now.ToString("yyyy-M-dd");
					objETInfo.strPYCode=this.txtPYCode.Text ; 
					objETInfo.strStatus = "0";
					objETInfo.strDeActivedDate = null;
					objETInfo.strOperatorID = MDIParent.strOperatorID ;
//					bool exist = objETServ.m_lngRecordExist(this.lblEquipmentTypeIDText.Text);
					if(this.lblEquipmentTypeIDText.Text!="" )
					{
//						objETInfo.strEquipmentTypeID = this.lblEquipmentTypeIDText.Text;
//						objETInfo.strEquipmentTypeName = this.txtEquimentName.Text ;
//						objETInfo.strStatus = "0";
//						objETInfo.strPYCode = this.txtPYCode.Text ;
//						objETInfo.strDeActivedDate = System.DateTime.Now.ToString("yyyy-M-dd");
//						objETInfo.strOperatorID = MDIParent.strOperatorID ;

						long lngSuccess = objDomain.m_lngModifyRecord(objETInfo);
						if(lngSuccess == 1)
						{
							RefreshData("Modify",objETInfo);
						}
					}
					else
					{
						this.lblEquipmentTypeIDText.Text = objETInfo.strEquipmentTypeID; 
						long lngSucc = objDomain.m_lngAddNewRecord(objETInfo);
						if(lngSucc == 1)
						{
							RefreshData("Add",objETInfo);
						}
					}
				}
			}
			catch
			{
			
			}
		}

		private void Add_To_ListView(clsEquipmentTypeInfo objEtinfo)
		{
			clsEquipmentTypeInfo objETInfo1 = new clsEquipmentTypeInfo();
			try
			{
				ListViewItem tempItem;
				tempItem = new ListViewItem(new string[] {objETInfo1.strEquipmentTypeID,this.txtEquimentName.Text});
				tempItem.Tag =(clsEquipmentTypeInfo)objETInfo1;
				lsvEquipmentType.Items.Add(tempItem);
			}
			catch{}
		}

		private void frmEquipmentType_Load(object sender, System.EventArgs e)
		{
			int rows =0;
			try
			{
				clsEquipmentTypeInfo[] EquipmentTypeInfo = objDomain.m_clsGetXMLTable(ref rows);
				ListViewItem tempItem;
				for(int i = 0; i< rows; i++)
				{
					tempItem = new ListViewItem(new string[] {EquipmentTypeInfo[i].strEquipmentTypeID,EquipmentTypeInfo[i].strEquipmentTypeName});
					tempItem.Tag =(clsEquipmentTypeInfo)EquipmentTypeInfo[i];
                    lsvEquipmentType.Items.Add(tempItem);
				}

				m_objHighLight.m_mthAddControlInContainer(this);

				txtEquimentName.Focus();
			}
			catch{}
		}

		private void lsvEquipmentType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lsvEquipmentType_Click(object sender, System.EventArgs e)
		{
			this.txtEquimentName.Text = "";
			this.lblEquipmentTypeIDText.Text = "";
			this.txtPYCode.Text = "";
			g_strEquipmentTypeID = this.lsvEquipmentType.SelectedItems[0].Text;
			this.txtEquimentName.Text = this.lsvEquipmentType.SelectedItems[0].SubItems[1].Text;
			this.lblEquipmentTypeIDText.Text = this.lsvEquipmentType.SelectedItems[0].Text;
			this.txtPYCode.Text = ((clsEquipmentTypeInfo)this.lsvEquipmentType.SelectedItems[0].Tag).strPYCode  ;
		}

		private void cmdDel_Click(object sender, System.EventArgs e)
		{
			clsEquipmentTypeInfo objETInfo2 = new clsEquipmentTypeInfo();
			try
			{
				objETInfo2.strEquipmentTypeID = this.lblEquipmentTypeIDText.Text;
				objETInfo2.strEquipmentTypeName = this.txtEquimentName.Text ;
				objETInfo2.strStatus = "1";
				objETInfo2.strDeActivedDate = System.DateTime.Now.ToString("yyyy-M-dd");
				objETInfo2.strOperatorID = MDIParent.strOperatorID ;
				long lngSuccess = objDomain.m_lngModifyRecord(objETInfo2);
				if(lngSuccess == 1)
				{
					RefreshData("Del",objETInfo2);
					this.cmdAdd.Text = "添加";
				}		
			}
			catch{}
		}


		#region public function
		public void CleanUp()
		{
			this.lblEquipmentTypeIDText.Text="";
			this.txtEquimentName.Text="";
			this.txtPYCode.Text ="";	
		}

		public void Save()
		{
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmEquipmentType,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			this.cmdAdd_Click(null,null);
		}

		public void Delete()
		{
			
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmEquipmentType,PrivilegeData.enmPrivilegeOperation.Delete))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif

			this.cmdDel_Click(null,null);
		}

		public void Display()
		{
		
		}

		public void Print()
		{
		}

		public void Display(string id,string name)
		{
		
		}


		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{m_lngCut();}

		public void Paste()
		{m_lngPaste();}
		public void Verify()
		{
			////long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Redo()
		{}

		public void Undo()
		{}
		
		#endregion

		private void RefreshData(string flag,clsEquipmentTypeInfo objEtinfo)
		{
			clsEquipmentTypeInfo aa= new clsEquipmentTypeInfo();
			
			try
			{
				if(flag == "Del")
				{
					for(int i=0;i<lsvEquipmentType.Items.Count;i++)
						if(lsvEquipmentType.Items[i].SubItems[0].Text==this.lblEquipmentTypeIDText.Text)
						{
							lsvEquipmentType.Items[i].Remove();
							CleanUp();
							break;
						}
				}
				else if(flag == "Add")
				{
					Add_To_ListView(objEtinfo);
					CleanUp();
				}
				else if (flag == "Modify")
				{
					for(int j = 0;j <lsvEquipmentType.Items.Count; j++)
						if(lsvEquipmentType.Items[j].SubItems[0].Text==this.lblEquipmentTypeIDText.Text)
						{
							lsvEquipmentType.Items[j].SubItems[1].Text = this.txtEquimentName.Text;
							lsvEquipmentType.Items[j].Tag = (clsEquipmentTypeInfo)objEtinfo;
							CleanUp();
							break;
						}
				}
			}
			catch{}
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close(); 
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
	}
}
