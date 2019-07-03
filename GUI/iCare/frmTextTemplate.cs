using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using iCare.CustomForm;
using System.Xml;
namespace iCare
{
	/// <summary>
	/// frmTextTemplate 的摘要说明。
	/// </summary>
	public class frmTextTemplate : System.Windows.Forms.Form
	{
		private string m_strTemplateID;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TreeView treeView1;
		private PinkieControls.ButtonXP m_cmdNew;
		private PinkieControls.ButtonXP m_cmdChange;
		private System.Windows.Forms.ImageList m_imgIcons;
		private PinkieControls.ButtonXP m_cmdCreatText;
		private PinkieControls.ButtonXP m_cmdExit;
		private System.Windows.Forms.Panel m_pnlControl;
		private System.ComponentModel.IContainer components;


        //CustomFromService.clsMinElementColServ m_objServ;
		/// <summary>
		/// 窗体ID
		/// </summary>
		private string m_strFormID;
		private com.digitalwave.Utility.Controls.ctlRichTextBox m_txtText;
		private PinkieControls.ButtonXP m_cmdReturn;
		private PinkieControls.ButtonXP m_cmdHaltTemp;
		/// <summary>
		/// 控件ID
		/// </summary>
		private string m_strControlID;
		/// <summary>
		/// 选择的病人
		/// </summary>
//		private clsPatient m_objCurrentPatient;

		public frmTextTemplate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			m_objTextTemplate=new clsTextTemplate();
			
			m_cmdChange.Enabled = false;
			m_cmdHaltTemp.Enabled = false;
            //m_objServ = new CustomFromService.clsMinElementColServ();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTextTemplate));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
			this.m_cmdNew = new PinkieControls.ButtonXP();
			this.m_cmdChange = new PinkieControls.ButtonXP();
			this.m_cmdHaltTemp = new PinkieControls.ButtonXP();
			this.m_cmdExit = new PinkieControls.ButtonXP();
			this.m_cmdCreatText = new PinkieControls.ButtonXP();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.m_txtText = new com.digitalwave.Utility.Controls.ctlRichTextBox();
			this.m_pnlControl = new System.Windows.Forms.Panel();
			this.m_cmdReturn = new PinkieControls.ButtonXP();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.m_cmdNew);
			this.panel1.Controls.Add(this.m_cmdChange);
			this.panel1.Controls.Add(this.m_cmdHaltTemp);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 625);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Location = new System.Drawing.Point(8, 8);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(184, 568);
			this.panel2.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageList = this.m_imgIcons;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("模板", 0, 0)});
			this.treeView1.Size = new System.Drawing.Size(184, 568);
			this.treeView1.TabIndex = 0;
			this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// m_imgIcons
			// 
			this.m_imgIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
			this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_cmdNew
			// 
			this.m_cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdNew.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdNew.DefaultScheme = true;
			this.m_cmdNew.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdNew.ForeColor = System.Drawing.Color.Black;
			this.m_cmdNew.Hint = "";
			this.m_cmdNew.Location = new System.Drawing.Point(4, 584);
			this.m_cmdNew.Name = "m_cmdNew";
			this.m_cmdNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdNew.Size = new System.Drawing.Size(64, 32);
			this.m_cmdNew.TabIndex = 10000013;
			this.m_cmdNew.Text = "新建模板 ";
			this.m_cmdNew.Click += new System.EventHandler(this.btNew_Click);
			// 
			// m_cmdChange
			// 
			this.m_cmdChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdChange.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdChange.DefaultScheme = true;
			this.m_cmdChange.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdChange.ForeColor = System.Drawing.Color.Black;
			this.m_cmdChange.Hint = "";
			this.m_cmdChange.Location = new System.Drawing.Point(68, 584);
			this.m_cmdChange.Name = "m_cmdChange";
			this.m_cmdChange.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdChange.Size = new System.Drawing.Size(64, 32);
			this.m_cmdChange.TabIndex = 10000014;
			this.m_cmdChange.Text = "修改模板 ";
			this.m_cmdChange.Click += new System.EventHandler(this.btChange_Click);
			// 
			// m_cmdHaltTemp
			// 
			this.m_cmdHaltTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdHaltTemp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdHaltTemp.DefaultScheme = true;
			this.m_cmdHaltTemp.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdHaltTemp.ForeColor = System.Drawing.Color.Black;
			this.m_cmdHaltTemp.Hint = "";
			this.m_cmdHaltTemp.Location = new System.Drawing.Point(132, 584);
			this.m_cmdHaltTemp.Name = "m_cmdHaltTemp";
			this.m_cmdHaltTemp.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdHaltTemp.Size = new System.Drawing.Size(64, 32);
			this.m_cmdHaltTemp.TabIndex = 10000013;
			this.m_cmdHaltTemp.Text = "停用模板 ";
			this.m_cmdHaltTemp.Click += new System.EventHandler(this.m_cmdHaltTemp_Click);
			// 
			// m_cmdExit
			// 
			this.m_cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdExit.DefaultScheme = true;
			this.m_cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdExit.ForeColor = System.Drawing.Color.Black;
			this.m_cmdExit.Hint = "";
			this.m_cmdExit.Location = new System.Drawing.Point(592, 584);
			this.m_cmdExit.Name = "m_cmdExit";
			this.m_cmdExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdExit.Size = new System.Drawing.Size(72, 32);
			this.m_cmdExit.TabIndex = 10000017;
			this.m_cmdExit.Text = "退  出";
			this.m_cmdExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// m_cmdCreatText
			// 
			this.m_cmdCreatText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdCreatText.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdCreatText.DefaultScheme = true;
			this.m_cmdCreatText.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdCreatText.ForeColor = System.Drawing.Color.Black;
			this.m_cmdCreatText.Hint = "";
			this.m_cmdCreatText.Location = new System.Drawing.Point(592, 436);
			this.m_cmdCreatText.Name = "m_cmdCreatText";
			this.m_cmdCreatText.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCreatText.Size = new System.Drawing.Size(72, 32);
			this.m_cmdCreatText.TabIndex = 10000016;
			this.m_cmdCreatText.Text = "生成文本 ";
			this.m_cmdCreatText.Click += new System.EventHandler(this.btCreatText_Click);
			// 
			// splitter1
			// 
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(2, 625);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.m_txtText);
			this.panel3.Controls.Add(this.m_pnlControl);
			this.panel3.Controls.Add(this.m_cmdCreatText);
			this.panel3.Controls.Add(this.m_cmdReturn);
			this.panel3.Controls.Add(this.m_cmdExit);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(202, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(670, 625);
			this.panel3.TabIndex = 2;
			// 
			// m_txtText
			// 
			this.m_txtText.AcceptsTab = true;
			this.m_txtText.AccessibleDescription = "";
			this.m_txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtText.BackColor = System.Drawing.Color.White;
			this.m_txtText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtText.ForeColor = System.Drawing.Color.Black;
			this.m_txtText.Location = new System.Drawing.Point(8, 432);
			this.m_txtText.m_BlnPartControl = false;
			this.m_txtText.m_BlnReadOnly = false;
			this.m_txtText.m_BlnUnderLineDST = false;
			this.m_txtText.m_ClrDST = System.Drawing.Color.Black;
			this.m_txtText.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtText.m_IntCanModifyTime = 0;
			this.m_txtText.m_IntPartControlLength = 0;
			this.m_txtText.m_IntPartControlStartIndex = 0;
			this.m_txtText.m_StrUserID = "";
			this.m_txtText.m_StrUserName = "";
			this.m_txtText.Name = "m_txtText";
			this.m_txtText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtText.Size = new System.Drawing.Size(576, 188);
			this.m_txtText.TabIndex = 111;
			this.m_txtText.Text = "";
			// 
			// m_pnlControl
			// 
			this.m_pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_pnlControl.Location = new System.Drawing.Point(8, 8);
			this.m_pnlControl.Name = "m_pnlControl";
			this.m_pnlControl.Size = new System.Drawing.Size(656, 416);
			this.m_pnlControl.TabIndex = 0;
			// 
			// m_cmdReturn
			// 
			this.m_cmdReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdReturn.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdReturn.DefaultScheme = true;
			this.m_cmdReturn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_cmdReturn.ForeColor = System.Drawing.Color.Black;
			this.m_cmdReturn.Hint = "";
			this.m_cmdReturn.Location = new System.Drawing.Point(592, 510);
			this.m_cmdReturn.Name = "m_cmdReturn";
			this.m_cmdReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdReturn.Size = new System.Drawing.Size(72, 32);
			this.m_cmdReturn.TabIndex = 10000016;
			this.m_cmdReturn.Text = "保  存";
			this.m_cmdReturn.Click += new System.EventHandler(this.m_cmdReturn_Click);
			// 
			// frmTextTemplate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(872, 625);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmTextTemplate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "最小元素集模板";
			this.Load += new System.EventHandler(this.frmTextTemplate_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 初始化模板信息
		/// </summary>
		/// <param name="p_strFormID"></param>
		/// <param name="p_strControlID"></param>
		public void m_mthInitilizeTemplateInfo( string p_strFormID,string p_strControlID)
		{
			if(p_strFormID == null || p_strControlID == null || p_strFormID.Length <=0 || p_strControlID.Length <=0)
				return;
			this.m_strFormID = p_strFormID;
			this.m_strControlID = p_strControlID;
			m_mthFindAllTemplateUsedInCtl(m_strFormID,m_strControlID);
		}

		#region 自定义属性
		private clsTextTemplate m_objTextTemplate;
		/// <summary>
		/// 获取信息
		/// </summary>
		public clsTextTemplate GetTextTemplate
		{
			get
			{
				return m_objTextTemplate;
			}
		
		}
		private string m_strTextBoxText="";
		/// <summary>
		/// 获取或设置合并后的字符串
		/// </summary>
		public string m_StrTextBoxText
		{
			get
			{
				return m_txtText.Text;
			}
			set
			{
				m_txtText.Text=value;
			}
		}
		#endregion
		#region 加载模板信息
//		private void m_mthLoadTemplate()
//		{
//			treeView1.Nodes[0].Nodes.Clear();
//			clsTemplateInfo[] objTIVOArr =null;
//			com.digitalwave.AssistantToolService.clsMinElementColServ objSvc =new com.digitalwave.AssistantToolService.clsMinElementColServ();
//			m_objServ.m_lngGetTemplates(out objTIVOArr);
//			if(objTIVOArr!=null)
//			{
//				TreeNode tn;
//				for(int i=0;i<objTIVOArr.Length;i++)
//				{
//				tn=new TreeNode(objTIVOArr[i].m_strTEMPLATE_NAME);
//				tn.ImageIndex =2;
//				tn.SelectedImageIndex=1;
//				tn.Tag=objTIVOArr[i];
//				treeView1.Nodes[0].Nodes.Add(tn);
//				}
//			}
//		}
		#endregion

		private void frmTextTemplate_Load(object sender, System.EventArgs e)
		{
			
//			m_mthLoadTemplate();
		}

		#region 传入ID信息查找模板的值 *****
		/// <summary>
		/// 传入ID信息查找模板的值
		/// </summary>
		/// <param name="strReportID"></param>
		/// <param name="strFormID"></param>
		/// <param name="strControlID"></param>
		private void m_mthFindAllTemplateUsedInCtl(string strFormID,string strControlID)
		{
			if(strFormID == null || strControlID == null || strFormID.Length <=0 || strControlID.Length <= 0)
				return;
			m_objTextTemplate.m_strDoctor_ID=MDIParent.strOperatorID.Trim();
			m_objTextTemplate.m_strFORM_ID=strFormID;
			m_objTextTemplate.m_strCONTROL_ID=strControlID;
			clsTemplateInfo[] objTemplateInfo;
//			clsTextTemplate objTextTemplate;

            CustomFromService.clsMinElementColServ m_objServ =
                (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

			long lngRes =m_objServ.m_lngGetTemplates(strFormID,strControlID,out objTemplateInfo);
			if(lngRes>0&&objTemplateInfo!=null)
			{
				treeView1.BeginUpdate();
				for(int i=0;i<objTemplateInfo.Length;i++)
				{
					TreeNode node = new TreeNode(objTemplateInfo[i].m_strTEMPLATE_NAME);
					node.Tag = objTemplateInfo[i];
					node.ImageIndex = 2;
					node.SelectedImageIndex = 1;
					if(objTemplateInfo[i].m_strDoctor_ID.Trim() == MDIParent.strOperatorID.Trim())
						node.ForeColor = Color.Green;
//					else
//						node.ForeColor = Color.Yellow;
					treeView1.Nodes[0].Nodes.Add(node);
				}
				treeView1.ExpandAll();
				treeView1.EndUpdate();
				m_pnlControl.Tag = "";
//				m_objTextTemplate.m_strGUI_ID=objTextTemplate.m_strGUI_ID;
//				this.m_pnlControl.Tag=objTTVO.m_strGUI_ID;
//				if(objTIVO!=null)
//				{
//				m_mthLoadControl(objTIVO.m_strTEMPLATE_XML);
//				this.m_cmdChange.Tag=objTIVO;
//				}
//				if(objTTVO.m_objTmpCtlValueArr!=null)
//				{
//				m_mthLoadControlValue(objTTVO.m_objTmpCtlValueArr);
//				}
			}
		}
		#endregion
		#region 加载控件信息
		/// <summary>
		/// 加载控件信息
		/// </summary>
		/// <param name="p_strXml"></param>
		private void m_mthLoadControl(string p_strXml)
		{
			XmlParserContext objXmlParser = new XmlParserContext(null,null,null,XmlSpace.None,System.Text.Encoding.Default);
			XmlTextReader objReader = new XmlTextReader(p_strXml,XmlNodeType.Element,objXmlParser);
			objReader.WhitespaceHandling = WhitespaceHandling.None;
			while(objReader.Read())
			{
				switch(objReader.NodeType)
				{
					case XmlNodeType.Element:
						if(objReader.GetAttribute("TYPE") == null)
							break;
						infPublicFuntion infControl = new clsGenerateControlFactory().m_infGetControl(objReader.GetAttribute("TYPE").ToString());
						infControl.ConfigMe(objReader);
						//						((Control)infControl).Name = m_strGetCtlName(p_ctlContainer,(Control)infControl);
						Form frm = this.m_pnlControl.FindForm();
						if(frm is frmUserDefinedEditor)//设计界面才需要加控件事件
						{
							((frmUserDefinedEditor)frm).m_mthAddCtlEvent((Control)infControl);
						}
						else if(frm is frmCustomFormDesign)
						{
							((frmCustomFormDesign)frm).m_mthAddCtlEvent((Control)infControl);
						}
						Control ctl = (Control)infControl;
						if(ctl != null)
						{
							switch(ctl.GetType().FullName)
							{
						
						
								case "iCare.CustomForm.ctlRichTextBox" :
									ctl.BackColor=Color.White;
									ctl.ForeColor=Color.Black;
									break;
								case "iCare.CustomForm.ctlComboBox" ://添加组合框项目事件
									iCare.CustomForm.ctlComboBox cbo = ctl as iCare.CustomForm.ctlComboBox;
									cbo.DropDown += new System.EventHandler(m_mthComboBox_DropDown);
									cbo.evtAddItem += new System.EventHandler(m_mthComboBox_Additem);
									cbo.evtModifyItem += new System.EventHandler(m_mthComboBox_Modifyitem);
									cbo.evtDelItem += new System.EventHandler(m_mthComboBox_Deleteitem);
									break;
								default :
									ctl.BackColor=System.Drawing.SystemColors.Control;
									ctl.ForeColor=Color.Black;
									break;
							}
						

							m_pnlControl.Controls.Add(ctl);
						}
						break;
				}
			}//end whi
		}
		#endregion

		#region 加载控件数据
		/// <summary>
		/// 加载控件数据
		/// </summary>
		/// <param name="objArr"></param>
		private void m_mthLoadControlValue(clsTemplateControlValue[] objArr)
		{
			for(int i=0;i<objArr.Length;i++)
			{
				foreach(Control obj in this.m_pnlControl.Controls)
				{
					if(obj.Name==objArr[i].m_strCONTROL_ID)
					{
						m_mthSetControlValue(obj,objArr[i].m_strCONTROL_VALUE);
						break;
					}
					
				}
			}
		}
		/// <summary>
		/// 赋值
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="strValue"></param>
		private void m_mthSetControlValue(Control obj,string strValue)
		{
			if(strValue == null || obj == null)
				return;
			switch(obj.GetType().Name)
			{
				case "ctlCheckBox" :
					if(strValue.Trim() == "true")
					{
					((ctlCheckBox)obj).Checked=true;
					}
					else
					{
					((ctlCheckBox)obj).Checked=false;
					}
					break;
				case "ctlDateTimePicker" :
					try
					{
						((ctlDateTimePicker)obj).Value=DateTime.Parse(strValue);
					}
					catch
					{
					((ctlDateTimePicker)obj).Value =DateTime.Now;
					}
					break;
				case "ctlRichTextBox" :
					((ctlRichTextBox)obj).Text=strValue;
					break;
				case "ctlComboBox" :
					((ctlComboBox)obj).Text=strValue;
					break;
			}
		}
		#endregion
		#region 收集控件值
		/// <summary>
		/// 从界面取值
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthGetControlValues()
		{
			ArrayList arlItems = new ArrayList();
			foreach(Control obj in this.m_pnlControl.Controls)
			{
				clsTemplateControlValue objValue = new clsTemplateControlValue();
				objValue.m_strGUI_ID=m_objTextTemplate.m_strGUI_ID;
				switch(obj.GetType().Name)
				{
					case "ctlCheckBox" :
						ctlCheckBox chk = obj as ctlCheckBox;
						objValue.m_strCONTROL_ID = chk.Name;
						objValue.m_strCONTROL_DESC = chk.名称;
						objValue.m_strCONTROL_VALUE=(chk.Checked == true?"true":"false");
						break;
					case "ctlDateTimePicker" :
						ctlDateTimePicker dtp = obj as ctlDateTimePicker;
						objValue.m_strCONTROL_ID = dtp.Name;
						objValue.m_strCONTROL_DESC = dtp.名称;
						objValue.m_strCONTROL_VALUE=dtp.Value.ToString("yyyy-MM-dd HH:mm:ss");
						break;
					case "ctlComboBox" :
						ctlComboBox cbo = obj as ctlComboBox;
						objValue.m_strCONTROL_ID = cbo.Name;
						objValue.m_strCONTROL_DESC = cbo.名称;
						objValue.m_strCONTROL_VALUE=cbo.Text.Trim();;
						break;
					case "ctlRichTextBox" :
						ctlRichTextBox txt = obj as ctlRichTextBox;
						objValue.m_strCONTROL_ID = txt.Name;
						objValue.m_strCONTROL_DESC = txt.名称;
						objValue.m_strCONTROL_VALUE=txt.Text.Trim();;
						break;
					default:
						objValue = null;
						break;
				}
				if(objValue != null)
					arlItems.Add(objValue);
			}
			if(arlItems.Count > 0)
				m_objTextTemplate.m_objTmpCtlValueArr=(clsTemplateControlValue[])arlItems.ToArray(typeof(clsTemplateControlValue));
		
		}
		#endregion

		private void btCreatText_Click(object sender, System.EventArgs e)
		{
			m_strTextBoxText="";
			ArrayList objArrayList =new ArrayList();
			foreach(Control obj in this.m_pnlControl.Controls)
			{
				objArrayList.Add(obj.TabIndex);
			}
			objArrayList.Sort(0,objArrayList.Count,null);
			for(int i=0;i<objArrayList.Count;i++)
			{
				foreach(Control obj in this.m_pnlControl.Controls)
				{
					if(objArrayList[i].ToString()==obj.TabIndex.ToString())
					{
						m_mthGetText(obj);
						break;
					}
				}
			}
			if(m_strTextBoxText.Length > 0)
				this.m_txtText.Text = m_strTextBoxText;
			m_mthGetControlValues();
		}
		/// <summary>
		/// 添加字符到合并后的字符串
		/// </summary>
		/// <param name="obj"></param>
		private void m_mthGetText(Control obj)
		{
			switch(obj.GetType().Name)
			{
				case "ctlCheckBox" :
					if(((ctlCheckBox)obj).Checked==true)
					{
					m_strTextBoxText+=((ctlCheckBox)obj).Text;
					}
					break;
				case "ctlDateTimePicker" :
				m_strTextBoxText+=((ctlDateTimePicker)obj).Value.ToString(((ctlDateTimePicker)obj).CustomFormat);
					break;
				case "ctlLabel" :
				m_strTextBoxText+=((ctlLabel)obj).Text;
					break;
				case "ctlRichTextBox" :
				m_strTextBoxText+= ((ctlRichTextBox)obj).Text;
					break;
				case "ctlComboBox" :
					m_strTextBoxText+= ((ctlComboBox)obj).Text;
					break;
				
			}
		}

		
		private void btNew_Click(object sender, System.EventArgs e)
		{
			frmCustomFormDesign objfrm =new frmCustomFormDesign();
			if(objfrm.ShowDialog()!=DialogResult.OK)//设计模板
			{
				return;
			}
			frmInputName frminput =new frmInputName();
			frminput.TopMost = true;
			frminput.StartPosition = FormStartPosition.CenterScreen;
			if(frminput.ShowDialog()!=DialogResult.OK)//名称
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			clsTextTemplate objTextTemplate = new clsTextTemplate();
			try
			{
                CustomFromService.clsMinElementColServ m_objServ =
                    (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

				clsTemplateInfo obj =new clsTemplateInfo();
				obj.m_strTEMPLATE_NAME=frminput.strName;
				obj.m_strTEMPLATE_XML=objfrm.m_StrGUIXml;
				frminput.Close();
				//			objfrm.Close();
				string strID;
				//保存模板
				long lngRes =m_objServ.m_lngSaveTemplate(obj,out strID);
				if(lngRes<=0||strID=="")
					return;

				objTextTemplate.m_strGUI_ID = strID;
				objTextTemplate.m_strDoctor_ID = MDIParent.strOperatorID;
				//保存主表‘min_element_apply’
				if(m_strFormID != null && m_strControlID != null)
				{
					objTextTemplate.m_strFORM_ID = m_strFormID;
					objTextTemplate.m_strCONTROL_ID = m_strControlID;
					m_objServ.m_lngSaveApplyInfo(objTextTemplate);
				}
				//保存模板控件描述
				if(objfrm.m_ObjTmpCtlDescArr != null)
				{
					objTextTemplate.m_objTmpCtlValueArr = objfrm.m_ObjTmpCtlDescArr;
					m_objServ.m_lngSaveTemplateDesc(objTextTemplate);
				}
				obj.m_strTEMPLATE_ID=strID;
				obj.m_strDoctor_ID = MDIParent.strOperatorID;
				TreeNode tn =new TreeNode(obj.m_strTEMPLATE_NAME);
				tn.ImageIndex =2;
				tn.SelectedImageIndex=1;
				tn.Tag=obj;
				tn.ForeColor = Color.Green;
				treeView1.Nodes[0].Nodes.Add(tn);
			}
			catch
			{}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		
		private void btChange_Click(object sender, System.EventArgs e)
		{
			if(this.m_cmdChange.Tag==null)
				return;
			clsTemplateInfo obj=(clsTemplateInfo)this.m_cmdChange.Tag;
			frmCustomFormDesign objfrm =new frmCustomFormDesign();
			objfrm.m_mthConfigXmlToGUI(obj.m_strTEMPLATE_XML);
			if(objfrm.ShowDialog()!=DialogResult.OK)
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			try
			{
                CustomFromService.clsMinElementColServ m_objServ =
                    (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

				obj.m_strTEMPLATE_XML=objfrm.m_StrGUIXml;
				//			objfrm.Close();
				if(MessageBox.Show("是否要更改模板名称?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					using(frmInputName frminput = new frmInputName())
					{
						if(frminput.ShowDialog()==DialogResult.OK)
						{
							obj.m_strTEMPLATE_NAME = frminput.strName;
						}
					}
				}
				long lngRes =m_objServ.m_lngUpdateTemplate(obj);
				if(lngRes<=0)
					return;
				clsTextTemplate objTextTemplate = new clsTextTemplate();
				objTextTemplate.m_strGUI_ID = obj.m_strTEMPLATE_ID;
				//保存模板控件描述
				if(objfrm.m_ObjTmpCtlDescArr != null)
				{
					objTextTemplate.m_objTmpCtlValueArr = objfrm.m_ObjTmpCtlDescArr;
					m_objServ.m_lngSaveTemplateDesc(objTextTemplate);
				}
				this.m_cmdChange.Tag=obj;
				treeView1.BeginUpdate();
				//修改树结点名称，重新load出模板
				foreach(TreeNode node in treeView1.Nodes[0].Nodes)
				{
					if(((clsTemplateInfo)node.Tag).m_strTEMPLATE_ID == obj.m_strTEMPLATE_ID)
					{
						node.Text = obj.m_strTEMPLATE_NAME;
						treeView1.SelectedNode = node;
						break;
					}
				}
				this.m_pnlControl.Tag = "";
				treeView1_DoubleClick(null,null);
				treeView1.EndUpdate();
			}
			catch
			{}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		
		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.treeView1.SelectedNode==null || treeView1.SelectedNode.Parent == null)
			{
				return;
			}
			
			clsTemplateInfo obj =(clsTemplateInfo)this.treeView1.SelectedNode.Tag;
			if(obj.m_strTEMPLATE_ID==(this.m_pnlControl.Tag==null? "" : this.m_pnlControl.Tag.ToString()))
			{
				return;
			}
			else
			{
				this.m_pnlControl.Tag = obj.m_strTEMPLATE_ID;
			}
			m_objTextTemplate.m_strGUI_ID = obj.m_strTEMPLATE_ID;
			this.m_cmdChange.Tag = obj;
			//权限控制
//			if(MDIParent.strOperatorID.Trim() != obj.m_strDoctor_ID.Trim())
//			{
//				m_cmdChange.Enabled = false;
//				m_cmdHaltTemp.Enabled = false;
//			}
//			else
//			{
//				m_cmdChange.Enabled = true;
//				m_cmdHaltTemp.Enabled = true;
//			}
			this.m_pnlControl.Controls.Clear();
			m_strTemplateID = obj.m_strTEMPLATE_ID;
			m_mthLoadControl(obj.m_strTEMPLATE_XML);

			m_objTextTemplate.m_strInPatientID = MDIParent.s_ObjCurrentPatient == null?"":MDIParent.s_ObjCurrentPatient.m_StrInPatientID;
			m_objTextTemplate.m_strGUI_ID = obj.m_strTEMPLATE_ID;
			m_objTextTemplate.m_dtInPatientDate = MDIParent.s_ObjCurrentPatient == null?DateTime.MinValue:MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate;
			m_objTextTemplate.m_objTmpCtlValueArr = null;

            CustomFromService.clsMinElementColServ m_objServ =
                (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

			long lngRes = m_objServ.m_lngGetValue(ref m_objTextTemplate);
			if(lngRes > 0 && m_objTextTemplate.m_objTmpCtlValueArr != null)
			{
				m_mthLoadControlValue(m_objTextTemplate.m_objTmpCtlValueArr);
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region 下拉框事件
		/// <summary>
		/// 添加项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Additem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "")
				return;
			clsComboBoxValue objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strTemplateID;
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.Text;
			long lngRef = new clsComboBoxDomainOld().m_lngAddItemToDB(objValue);
			if(lngRef < 1)
				return;
			cbo.Items.Insert(0,objValue.m_strItemContent);
			cbo.SelectedIndex = 0;
			
		}

		/// <summary>
		/// 修改项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Modifyitem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "" || cbo.SelectedItem == null)
				return;
			clsComboBoxValue objValue;
			objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strTemplateID;
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.SelectedItem.ToString();
			long lngRef = new clsComboBoxDomainOld().m_lngModifyItem(objValue,cbo.Text);
			if(lngRef < 1)
				return;
			string strText = cbo.Text;
			cbo.Items.Remove(cbo.SelectedItem);
			cbo.Update();
			cbo.Items.Insert(0,strText);
			cbo.SelectedIndex = 0;
		}

		/// <summary>
		/// 删除项目
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthComboBox_Deleteitem(object sender,System.EventArgs e)
		{
			iCare.CustomForm.ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as iCare.CustomForm.ctlComboBox;
			if(cbo == null)
				return;
			if(cbo.Text == "" || cbo.SelectedItem == null)
				return;
			clsComboBoxValue objValue;
			objValue = new clsComboBoxValue();
			objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
			objValue.m_strTypeID = m_strTemplateID;
			objValue.m_strItemID = cbo.Name;
			objValue.m_strItemContent = cbo.SelectedItem.ToString();
			long lngRef = new clsComboBoxDomainOld().m_lngDeleteItem(objValue);
			if(lngRef < 1)
				return;
			cbo.Items.Remove(cbo.SelectedItem);
			cbo.Update();
		}

		/// <summary>
		/// 设置下拉项目
		/// </summary>
		/// <param name="p_cboSender"></param>
		private void m_mthSetComboBoxListItem(ctlComboBox p_cboSender)
		{
			if(p_cboSender == null)
				return;
			clsComboBoxValue[] objValueArr = null;
			new clsComboBoxDomainOld().m_lngGetAllItem(MDIParent.s_ObjDepartment.m_StrDeptID,m_strTemplateID,p_cboSender.Name,out objValueArr);
			if(objValueArr == null)
				return;
			
			p_cboSender.Items.Clear();
			for(int i=0; i<objValueArr.Length; i++)
			{
				if(objValueArr[i].m_strItemContent != null && objValueArr[i].m_strItemContent != string.Empty)
					p_cboSender.Items.Add(objValueArr[i].m_strItemContent);
			}
		}

		private void m_mthComboBox_DropDown(object sender,System.EventArgs e)
		{
			m_mthSetComboBoxListItem((iCare.CustomForm.ctlComboBox)sender);
		}
		#endregion

		private void m_cmdReturn_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(treeView1.SelectedNode==null || treeView1.SelectedNode.Parent == null)
				return;
			if(treeView1.SelectedNode.Tag is clsTemplateInfo)
			{
				if(((clsTemplateInfo)treeView1.SelectedNode.Tag).m_strDoctor_ID.Trim() == MDIParent.strOperatorID.Trim())
				{
					m_cmdChange.Enabled = true;
					m_cmdHaltTemp.Enabled = true;
				}
				else
				{
					m_cmdChange.Enabled = false;
					m_cmdHaltTemp.Enabled = false;
				}
			}
		}

		private void m_cmdHaltTemp_Click(object sender, System.EventArgs e)
		{
			if(treeView1.SelectedNode==null || treeView1.SelectedNode.Parent == null)
				return;
			TreeNode node = treeView1.SelectedNode;
			if(node.Tag is clsTemplateInfo)
			{
				if(clsPublicFunction.ShowQuestionMessageBox("确定要删除所选的模板？") == DialogResult.Yes)
				{
                    CustomFromService.clsMinElementColServ m_objServ =
                        (CustomFromService.clsMinElementColServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(CustomFromService.clsMinElementColServ));

					long lngRes = m_objServ.m_lngHaltTemplate(((clsTemplateInfo)node.Tag).m_strTEMPLATE_ID);
					if(lngRes > 0)
					{
						if(((clsTemplateInfo)node.Tag).m_strTEMPLATE_ID==(this.m_pnlControl.Tag==null? "" : this.m_pnlControl.Tag.ToString()))
							this.m_pnlControl.Controls.Clear();
						node.Remove();
					}
				}
			}
		}
	}
}
