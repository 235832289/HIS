using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmInvokeTemplateByICD10.
	/// </summary>
	public class frmInvokeTemplateByICD10 : System.Windows.Forms.Form
	{
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCategory;
		private System.Windows.Forms.ListView m_lsvAssistantDiagnoseItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] m_ojbIcdValue;
		private clsTemplateDomain m_objDomain;
		private ArrayList m_arlRTB = new ArrayList();
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboCategoryId;
		private Form m_frmWindows;
		private System.Windows.Forms.ListView m_lsvPreview;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.ComponentModel.Container components = null;
		private bool m_blnIsAutoShow=false;
		private PinkieControls.ButtonXP m_cmdOK;
		private RichTextBox m_txtTemp;

		public frmInvokeTemplateByICD10()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_objDomain=new clsTemplateDomain();
		}

		public frmInvokeTemplateByICD10(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_ojbIcdValue,Form frmTemp,bool p_blnIsAutoShow) : this()
		{
			m_blnIsAutoShow=p_blnIsAutoShow;
			m_ojbIcdValue=p_ojbIcdValue;
			m_frmWindows=frmTemp;
		}

		public frmInvokeTemplateByICD10(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_ojbIcdValue,Form frmTemp) : this()
		{
			m_ojbIcdValue=p_ojbIcdValue;
			m_frmWindows=frmTemp;
		}

		public frmInvokeTemplateByICD10(com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] p_ojbIcdValue,Form frmTemp,bool p_blnIsAutoShow,Control p_txtTemp) : this()
		{
			m_blnIsAutoShow=p_blnIsAutoShow;
			m_ojbIcdValue=p_ojbIcdValue;
			m_frmWindows=frmTemp;
			if(p_txtTemp is com.digitalwave.Utility.Controls.ctlRichTextBox)
			{
				m_txtTemp=p_txtTemp as com.digitalwave.Utility.Controls.ctlRichTextBox;
			}
			else if(p_txtTemp is com.digitalwave.controls.ctlRichTextBox)
			{
				m_txtTemp=p_txtTemp as com.digitalwave.controls.ctlRichTextBox;
			}
		}

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
			this.m_lsvAssistantDiagnoseItem = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_cboCategory = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboCategoryId = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_lsvPreview = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_lsvAssistantDiagnoseItem
			// 
			this.m_lsvAssistantDiagnoseItem.AllowColumnReorder = true;
			this.m_lsvAssistantDiagnoseItem.BackColor = System.Drawing.Color.White;
			this.m_lsvAssistantDiagnoseItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																										 this.columnHeader1});
			this.m_lsvAssistantDiagnoseItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvAssistantDiagnoseItem.ForeColor = System.Drawing.Color.Black;
			this.m_lsvAssistantDiagnoseItem.FullRowSelect = true;
			this.m_lsvAssistantDiagnoseItem.GridLines = true;
			this.m_lsvAssistantDiagnoseItem.HideSelection = false;
			this.m_lsvAssistantDiagnoseItem.Location = new System.Drawing.Point(8, 36);
			this.m_lsvAssistantDiagnoseItem.MultiSelect = false;
			this.m_lsvAssistantDiagnoseItem.Name = "m_lsvAssistantDiagnoseItem";
			this.m_lsvAssistantDiagnoseItem.Size = new System.Drawing.Size(188, 316);
			this.m_lsvAssistantDiagnoseItem.TabIndex = 6;
			this.m_lsvAssistantDiagnoseItem.View = System.Windows.Forms.View.Details;
			this.m_lsvAssistantDiagnoseItem.DoubleClick += new System.EventHandler(this.m_cmdOK_Click);
			this.m_lsvAssistantDiagnoseItem.SelectedIndexChanged += new System.EventHandler(this.m_lsvAssistantDiagnoseItem_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "模板名称";
			this.columnHeader1.Width = 183;
			// 
			// m_cboCategory
			// 
			this.m_cboCategory.BackColor = System.Drawing.Color.White;
			this.m_cboCategory.BorderColor = System.Drawing.Color.Black;
			this.m_cboCategory.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboCategory.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCategory.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCategory.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategory.ForeColor = System.Drawing.Color.Black;
			this.m_cboCategory.ListBackColor = System.Drawing.Color.White;
			this.m_cboCategory.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboCategory.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboCategory.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboCategory.Location = new System.Drawing.Point(8, 8);
			this.m_cboCategory.m_BlnEnableItemEventMenu = true;
			this.m_cboCategory.Name = "m_cboCategory";
			this.m_cboCategory.SelectedIndex = -1;
			this.m_cboCategory.SelectedItem = null;
			this.m_cboCategory.Size = new System.Drawing.Size(188, 23);
			this.m_cboCategory.TabIndex = 1;
			this.m_cboCategory.TextBackColor = System.Drawing.Color.White;
			this.m_cboCategory.TextForeColor = System.Drawing.Color.Black;
			this.m_cboCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCategory_SelectedIndexChanged);
			// 
			// m_cboCategoryId
			// 
			this.m_cboCategoryId.BackColor = System.Drawing.Color.White;
			this.m_cboCategoryId.BorderColor = System.Drawing.Color.Black;
			this.m_cboCategoryId.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboCategoryId.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboCategoryId.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboCategoryId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboCategoryId.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategoryId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboCategoryId.ForeColor = System.Drawing.Color.Black;
			this.m_cboCategoryId.ListBackColor = System.Drawing.Color.White;
			this.m_cboCategoryId.ListForeColor = System.Drawing.Color.Black;
			this.m_cboCategoryId.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboCategoryId.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboCategoryId.Location = new System.Drawing.Point(8, 8);
			this.m_cboCategoryId.m_BlnEnableItemEventMenu = true;
			this.m_cboCategoryId.Name = "m_cboCategoryId";
			this.m_cboCategoryId.SelectedIndex = -1;
			this.m_cboCategoryId.SelectedItem = null;
			this.m_cboCategoryId.Size = new System.Drawing.Size(188, 23);
			this.m_cboCategoryId.TabIndex = 7;
			this.m_cboCategoryId.TextBackColor = System.Drawing.Color.White;
			this.m_cboCategoryId.TextForeColor = System.Drawing.Color.Black;
			this.m_cboCategoryId.Visible = false;
			// 
			// m_lsvPreview
			// 
			this.m_lsvPreview.BackColor = System.Drawing.Color.White;
			this.m_lsvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader2,
																						   this.columnHeader3});
			this.m_lsvPreview.ForeColor = System.Drawing.Color.Black;
			this.m_lsvPreview.FullRowSelect = true;
			this.m_lsvPreview.GridLines = true;
			this.m_lsvPreview.Location = new System.Drawing.Point(204, 8);
			this.m_lsvPreview.Name = "m_lsvPreview";
			this.m_lsvPreview.Size = new System.Drawing.Size(392, 344);
			this.m_lsvPreview.TabIndex = 8;
			this.m_lsvPreview.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "项目名称";
			this.columnHeader2.Width = 150;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "项目内容";
			this.columnHeader3.Width = 235;
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdOK.ForeColor = System.Drawing.Color.Black;
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(524, 356);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(72, 32);
			this.m_cmdOK.TabIndex = 10000002;
			this.m_cmdOK.Text = "确 定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// frmInvokeTemplateByICD10
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(604, 391);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.m_lsvPreview);
			this.Controls.Add(this.m_lsvAssistantDiagnoseItem);
			this.Controls.Add(this.m_cboCategory);
			this.Controls.Add(this.m_cboCategoryId);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInvokeTemplateByICD10";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "疾病模板选择";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmInvokeTemplateByICD10_Load);
			this.VisibleChanged += new System.EventHandler(this.frmInvokeTemplateByICD10_VisibleChanged);
			this.ResumeLayout(false);

		}
		#endregion
	
		private void m_mthGetCategoryName()
		{
			if (m_ojbIcdValue!=null)
			{
				for(int i=0;i<=m_ojbIcdValue.Length-1;i++)
				{
					m_cboCategory.AddItem (m_ojbIcdValue[i].ICD10_Name);
					m_cboCategoryId.AddItem(m_ojbIcdValue[i].ICD10_ID);
				}
				if(m_cboCategory.GetItemsCount()>0)
					m_cboCategory.SelectedIndex=0;	
			}
		}

		private void frmInvokeTemplateByICD10_Load(object sender, System.EventArgs e)
		{
			m_mthGetCategoryName();

			
		}

		private void m_mthLoadTemplateSetInf(string p_strICD_Id)
		{
			if(p_strICD_Id!=null || p_strICD_Id.Trim().Length !=0)
			{
				m_lsvAssistantDiagnoseItem.Items.Clear();
				m_objDomain.m_lngGetICD10IDToTemplateSetName(p_strICD_Id,m_frmWindows.Name,m_lsvAssistantDiagnoseItem);
			}
		}

		private void m_cboCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_lsvPreview.Items.Clear();
			m_cboCategoryId.SelectedIndex=m_cboCategory.SelectedIndex;
			m_mthLoadTemplateSetInf(m_cboCategoryId.Text);
			
		}

		private clsTemplatesetContentValue[] m_mthLoadTemplateInf(string p_strSetID)
		{
			clsTemplatesetContentValue[] objTemplatesetContentArr=m_objDomain.lngGetAllTemplatesetContent(p_strSetID);
			return (objTemplatesetContentArr);
		}

		private void m_mthTemplateInfLoadToForm(clsTemplatesetContentValue[] objTemplatesetContentArr)
		{
			
			m_arlRTB.Clear();
			m_mthAddRichTextBox(m_frmWindows);
			RichTextBox[] RTBArr = (RichTextBox[])m_arlRTB.ToArray(typeof(RichTextBox));
			ArrayList arlTemp = new ArrayList();
			for(int i1=0;i1<objTemplatesetContentArr.Length;i1++)
				arlTemp.Add(objTemplatesetContentArr[i1].m_strContent);
			string[] strContentArr = (string[])arlTemp.ToArray(typeof(string));
//			clsDataShareTool.s_mthReplaceDataShareValue(p_objSelectedPatient,strContentArr);
			for(int i1=0;i1<objTemplatesetContentArr.Length;i1++)
			{
				for(int j=0;j<RTBArr.Length;j++)
				{
					if(RTBArr[j]!=null && RTBArr[j].Name==objTemplatesetContentArr[i1].m_strControl_ID)
					{
						switch(RTBArr[j].GetType().Name)
						{
							case "RichTextBox":
								RTBArr[j].Text = strContentArr[i1].TrimEnd();
								break;
							case "ctlRichTextBox":
								((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthClearText();
								((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText(strContentArr[i1].TrimEnd(),0);
								//((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthReplace(((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).Text,strContentArr[i1].TrimEnd());
								break;
//							case "RichTextBox":
//								if(RTBArr[j].Text=="")
//									RTBArr[j].Text = strContentArr[i1].TrimEnd();
//								else 
//									RTBArr[j].Text += "\r\n" + strContentArr[i1].TrimEnd();
//								break;
//							case "ctlRichTextBox":
//								int intLength=((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).Text.Length ;
//								if(RTBArr[j].Text=="")
//									((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText (strContentArr[i1].TrimEnd(),intLength);
//								else
//									((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText ("\r\n" + strContentArr[i1].TrimEnd(),intLength);
//								break;
						}
					}
				}
			}
		}

		private void m_mthAddRichTextBox(Control p_ctl)
		{
			foreach(Control ctlSub in p_ctl.Controls)
			{
				switch(ctlSub.GetType().Name)
				{
					case "ctlRichTextBox" :
						m_arlRTB.Add(ctlSub);
						break;
					case "RichTextBox" :
						m_arlRTB.Add(ctlSub);
						break;
				}

				if(ctlSub.HasChildren)
				{
					m_mthAddRichTextBox(ctlSub);
				}
			}
			
		}

		private void m_lsvAssistantDiagnoseItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_lsvPreview.Items.Clear();
			
			if(m_lsvAssistantDiagnoseItem.SelectedItems.Count>0)
			{
				clsTemplatesetContentValue[] obj_TemplatesetContentValue;
				obj_TemplatesetContentValue=m_mthLoadTemplateInf(m_lsvAssistantDiagnoseItem.SelectedItems[0].Tag.ToString());
				m_mthPreviewTemplate(obj_TemplatesetContentValue);
//				m_mthTemplateInfLoadToForm(obj_TemplatesetContentValue);
				
			}
		}

		private void m_mthPreviewTemplate(clsTemplatesetContentValue[] objTemplatesetContentArr)
		{
			m_arlRTB.Clear();
			m_mthAddRichTextBox(m_frmWindows);
			RichTextBox[] RTBArr = (RichTextBox[])m_arlRTB.ToArray(typeof(RichTextBox));
			ArrayList arlTemp = new ArrayList();
			for(int i1=0;i1<objTemplatesetContentArr.Length;i1++)
				arlTemp.Add(objTemplatesetContentArr[i1].m_strContent);
			string[] strContentArr = (string[])arlTemp.ToArray(typeof(string));
			//			clsDataShareTool.s_mthReplaceDataShareValue(p_objSelectedPatient,strContentArr);
			for(int i1=0;i1<objTemplatesetContentArr.Length;i1++)
			{
				for(int j=0;j<RTBArr.Length;j++)
				{
					if(RTBArr[j]!=null && RTBArr[j].Name==objTemplatesetContentArr[i1].m_strControl_ID)
					{
						ListViewItem lviTemp=m_lsvPreview.Items.Add(objTemplatesetContentArr[i1].m_strControl_Desc);
						lviTemp.SubItems.Add(strContentArr[i1].TrimEnd());
						lviTemp.Tag=objTemplatesetContentArr[i1].m_strControl_ID;
					}
				}
			}			
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if (m_lsvAssistantDiagnoseItem.SelectedItems.Count >0)
			{
				clsTemplatesetContentValue[] obj_TemplatesetContentValue;
				obj_TemplatesetContentValue=m_mthLoadTemplateInf(m_lsvAssistantDiagnoseItem.SelectedItems[0].Tag.ToString());
				m_mthTemplateInfLoadToForm(obj_TemplatesetContentValue);
				if(m_txtTemp!=null)
				{
					if(m_txtTemp is com.digitalwave.Utility.Controls.ctlRichTextBox)
					{
						((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtTemp).m_mthClearText();
						((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtTemp).Text =m_cboCategory.Text;
					}
					else if(m_txtTemp is com.digitalwave.controls.ctlRichTextBox)
					{
						((com.digitalwave.controls.ctlRichTextBox)m_txtTemp).m_mthClearText();
						((com.digitalwave.controls.ctlRichTextBox)m_txtTemp).Text =m_cboCategory.Text;
					}
				}
			}
			this.Close();
		}

		private void frmInvokeTemplateByICD10_VisibleChanged(object sender, System.EventArgs e)
		{
			int intIcdCount=0;
			int intTemplateByICDCount=0;

			if(m_blnIsAutoShow)
			{

				intIcdCount=m_cboCategoryId.GetItemsCount();
				intTemplateByICDCount=m_lsvAssistantDiagnoseItem.Items.Count;
				if (intIcdCount<=0)
				{
					this.Close();
					return;
				}
				if(intTemplateByICDCount<=0)	
				{
					this.Close();
					return;
				}
				if (intIcdCount==1 && intTemplateByICDCount==1)
				{
					m_lsvAssistantDiagnoseItem.Items[0].Selected =true;
					m_cmdOK_Click(null,null);
				}
			}

		}
	}
}
