using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
namespace iCare
{
	/// <summary>
	/// Summary description for frmModifyStatistics.
	/// </summary>
	public class frmModifyStatistics : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Button m_cmdOK;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboStaticDefinition;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboConditionRelation;
		private System.Windows.Forms.Button m_cmdCancel;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtConditionalValue;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboConditionOperator;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboConditionItem;
		private System.Windows.Forms.Label m_lblStatisticType;
		private System.Windows.Forms.Label m_lblRelation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmModifyStatistics(bool p_blnIsNew, string p_strStatisticID,TreeNode p_trnNode)
		{
			
			
			
			m_trnNode=p_trnNode;
			m_strStatisticID=p_strStatisticID;
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_objHighLight.m_mthAddControlInContainer(this);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			m_mthLoadConditionOperator();
			m_mthLoadConditionOption();
			m_mthLoadConditionRelation();
			m_mthLoadStaticDefinition();


			if(p_trnNode.Tag.ToString()=="9")
			{
				m_intType=0;
				if(!p_blnIsNew) m_mthDisplayRoot();
			}
			else if(p_trnNode.Tag.ToString().IndexOf("き")>0)
			{
				m_intType=2;
				if(!p_blnIsNew) m_mthDisplayOption();
			}
			else
			{
				m_intType=1;
				if(!p_blnIsNew) m_mthDisplayConditionRelation();
			}
		}

		
		int m_intType=0;//0=root,1=condition,2=item;
		TreeNode m_trnNode=null;
		private ctlHighLightFocus m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
	
		private string m_strStatisticID=null;
		public string m_StrStatisticID
		{
			get
			{
				return m_strStatisticID;
			}
		}
		clsStatisticDefinitionValue [] m_objStatisticDefinitionArr=null;
		clsStatisticCCOperatorValue [] m_objCCOperatorArr=null;
		clsStatisticCondictionOptionValue [] m_objCondictionOptionArr=null;
		clsStatisticConditionOperatorValue [] m_objConditionOperatorArr=null;
		clsIntelligentStatisticsDomain m_objDomain=new clsIntelligentStatisticsDomain();

		private void m_mthLoadStaticDefinition()
		{
			m_cboStaticDefinition.ClearItem();
			long lngRes=m_objDomain.m_lngGetAllStatisticDefinition(out m_objStatisticDefinitionArr);
			if(lngRes<=0 || m_objStatisticDefinitionArr==null) return;
			for(int i=0;i<m_objStatisticDefinitionArr.Length;i++)
			{
				m_cboStaticDefinition.AddItem(m_objStatisticDefinitionArr[i].m_strStatisticDesc);
			}
		}
		
		private void m_mthLoadConditionOption()
		{
			if(m_strStatisticID==null || m_strStatisticID.Trim().Length==0)
			{
				
				return;
			}
			m_cboConditionItem.ClearItem();
			long lngRes=m_objDomain.m_lngGetStatisticCondictionOptionValue(m_strStatisticID,out m_objCondictionOptionArr);
			if(lngRes<=0 || m_objCondictionOptionArr==null) return;
			string [] strTempArr=new string [m_objCondictionOptionArr.Length];
			for(int i=0;i<m_objCondictionOptionArr.Length;i++)
			{
				strTempArr[i]= m_objCondictionOptionArr[i].m_strOptionDesc;
			}
			m_cboConditionItem.AddRangeItems(strTempArr);
		}
		private void m_mthLoadConditionOperator()
		{
			m_cboConditionOperator.ClearItem();
			long lngRes=m_objDomain.lngGetStatisticConditionOperatorValue(out m_objConditionOperatorArr);
			if(lngRes<=0 || m_objConditionOperatorArr==null) return;
			for(int i=0;i<m_objConditionOperatorArr.Length;i++)
			{
				m_cboConditionOperator.AddItem(m_objConditionOperatorArr[i].m_strOperatorDesc);
			}

		}
		private void m_mthLoadConditionRelation()
		{
			m_cboConditionRelation.ClearItem();
			long lngRes=m_objDomain.m_lngGetAllStatisticCCOperator(out m_objCCOperatorArr);
			if(lngRes<=0 || m_objCCOperatorArr==null) return;
			for(int i=0;i<m_objCCOperatorArr.Length;i++)
			{
				m_cboConditionRelation.AddItem(m_objCCOperatorArr[i].m_strOperatorDesc);
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



		private bool m_blnSaveToNode()
		{
			switch(m_intType)
			{
				case 0:
					if(m_cboStaticDefinition.SelectedIndex==-1)
					{
						clsPublicFunction.ShowInformationMessageBox("你还没选择统计类型。");
						return false;
					}
					if(m_strStatisticID!=m_objStatisticDefinitionArr[m_cboStaticDefinition.SelectedIndex].m_strStatistic_ID)
					{
						if(clsPublicFunction.ShowQuestionMessageBox("改变统计类型会丢失未保存的查询条件，是否继续？")!=DialogResult.Yes) return false;

					}
					m_strStatisticID=m_objStatisticDefinitionArr[m_cboStaticDefinition.SelectedIndex].m_strStatistic_ID;
					break;
				case 1:
					if(m_cboConditionRelation.SelectedIndex==-1)
					{
						clsPublicFunction.ShowInformationMessageBox("你还没选择条件关系类型。");
						return false;
					}
					m_trnNode.Text=m_objCCOperatorArr[m_cboConditionRelation.SelectedIndex].m_strOperatorDesc;
					m_trnNode.Tag=m_objCCOperatorArr[m_cboConditionRelation.SelectedIndex].m_strOperatorSymbol;
					break;
				case 2:
					if(m_cboConditionItem.SelectedIndex==-1)
					{
						clsPublicFunction.ShowInformationMessageBox("你还没选择条件项名称。");
						return false;
					}
					if(m_cboConditionOperator.SelectedIndex==-1)
					{
						clsPublicFunction.ShowInformationMessageBox("你还没选择条件项的比较关系。");
						return false;
					}
					if(m_txtConditionalValue.Text==null || m_txtConditionalValue.Text.Trim().Length==0)
					{
						clsPublicFunction.ShowInformationMessageBox("你还没输入条件项的比较值。");
						return false;
					}
					if(m_txtConditionalValue.Text.IndexOf("き")>0)
					{
						clsPublicFunction.ShowInformationMessageBox("条件项的比较值中有非法字符\"き\"。");
						return false;
					}
					
					m_trnNode.Text=m_objCondictionOptionArr[m_cboConditionItem.SelectedIndex].m_strOptionDesc+" "
						+ m_objConditionOperatorArr[m_cboConditionOperator.SelectedIndex].m_strOperatorDesc + " "
						+m_txtConditionalValue.Text;
					string strConditioinalValue=m_txtConditionalValue.Text.Trim();
					strConditioinalValue=strConditioinalValue.Replace("'","''");
					strConditioinalValue="'"+strConditioinalValue+"'";
					string strTagText=m_objCondictionOptionArr[m_cboConditionItem.SelectedIndex].m_strOptionFieldName + "き"
						+ m_objConditionOperatorArr[m_cboConditionOperator.SelectedIndex].m_strOperatorSymbol + "き"
						+strConditioinalValue;
					m_trnNode.Tag=strTagText;
					break;
				default:
					break;
			}
			return true;
		}

		private void m_mthDisplayOption()
		{
			m_cboConditionItem.Visible=true;
			m_cboConditionOperator.Visible=true;
			m_txtConditionalValue.Visible=true;
			m_cboConditionRelation.Visible=false;
			m_lblStatisticType.Visible=false;
			m_cboStaticDefinition.Visible=false;
			m_lblRelation.Visible=false;
			if(m_objCondictionOptionArr==null) return;
			if(m_trnNode==null) return;
			if( m_trnNode.Tag.ToString().IndexOf("き")<0) return;
			string[] strItemArr=m_trnNode.Tag.ToString().Split('き');
			for(int i=0;i<m_objCondictionOptionArr.Length;i++)
			{
				if(strItemArr[0]==m_objCondictionOptionArr[i].m_strOptionFieldName)
				{
					m_cboConditionItem.SelectedIndex=i;
					break;
				}
			}
			for(int i=0;i<m_objConditionOperatorArr.Length;i++)
			{
				if(strItemArr[1]==m_objConditionOperatorArr[i].m_strOperatorSymbol)
				{
					m_cboConditionOperator.SelectedIndex=i;
					break;
				}
			}
			string strConditioinalValue=strItemArr[2].Trim();
			if(strConditioinalValue.Length==0 || strConditioinalValue.Substring(0,1)!="'" || strConditioinalValue.Substring(strConditioinalValue.Length-1,1)!="'")
			{
				clsPublicFunction.ShowInformationMessageBox("条件项的比较值错误。");
				return;
			}
			strConditioinalValue=strConditioinalValue.Substring(1,strConditioinalValue.Length-2);
			strConditioinalValue=strConditioinalValue.Replace("''","'");
			m_txtConditionalValue.Text=strConditioinalValue;
		}
		private void m_mthDisplayConditionRelation()
		{
			m_cboConditionItem.Visible=false;
			m_cboConditionOperator.Visible=false;
			m_txtConditionalValue.Visible=false;
			m_cboConditionRelation.Visible=true;
			m_lblRelation.Visible=true;
			m_lblStatisticType.Visible=false;
			m_cboStaticDefinition.Visible=false;
			if(m_trnNode==null) return;
			
			
			for(int i=0;i<m_objCCOperatorArr.Length;i++)
			{
				if(m_trnNode.Tag.ToString()==m_objCCOperatorArr[i].m_strOperatorSymbol)
				{
					m_cboConditionRelation.SelectedIndex=i;
					break;
				}
			}
		}
		private void m_mthDisplayRoot()
		{
			m_cboConditionItem.Visible=false;
			m_cboConditionOperator.Visible=false;
			m_txtConditionalValue.Visible=false;
			m_cboConditionRelation.Visible=false;
			m_lblRelation.Visible=false;
			m_lblStatisticType.Visible=true;
			m_cboStaticDefinition.Visible=true;
			for(int i=0;i<m_objStatisticDefinitionArr.Length;i++)
			{
				if(m_strStatisticID==m_objStatisticDefinitionArr[i].m_strStatistic_ID)
				{
					m_cboStaticDefinition.SelectedIndex=i;
					break;
				}
			}
		}


		

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmModifyStatistics));
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_lblStatisticType = new System.Windows.Forms.Label();
			this.m_cboStaticDefinition = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboConditionRelation = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cmdCancel = new System.Windows.Forms.Button();
			this.m_txtConditionalValue = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_cboConditionOperator = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboConditionItem = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_lblRelation = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdOK.ForeColor = System.Drawing.Color.White;
			this.m_cmdOK.Location = new System.Drawing.Point(292, 20);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(68, 28);
			this.m_cmdOK.TabIndex = 16;
			this.m_cmdOK.Text = "确定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_lblStatisticType
			// 
			this.m_lblStatisticType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblStatisticType.ForeColor = System.Drawing.Color.White;
			this.m_lblStatisticType.Location = new System.Drawing.Point(32, 24);
			this.m_lblStatisticType.Name = "m_lblStatisticType";
			this.m_lblStatisticType.Size = new System.Drawing.Size(88, 23);
			this.m_lblStatisticType.TabIndex = 15;
			this.m_lblStatisticType.Text = "统计类型：";
			// 
			// m_cboStaticDefinition
			// 
			this.m_cboStaticDefinition.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.BorderColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboStaticDefinition.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboStaticDefinition.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboStaticDefinition.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboStaticDefinition.ForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.ListForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboStaticDefinition.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.Location = new System.Drawing.Point(128, 20);
			this.m_cboStaticDefinition.Name = "m_cboStaticDefinition";
			this.m_cboStaticDefinition.SelectedIndex = -1;
			this.m_cboStaticDefinition.SelectedItem = null;
			this.m_cboStaticDefinition.Size = new System.Drawing.Size(156, 26);
			this.m_cboStaticDefinition.TabIndex = 14;
			this.m_cboStaticDefinition.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.TextForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.SelectedIndexChanged += new System.EventHandler(this.m_cboStaticDefinition_SelectedIndexChanged);
			// 
			// m_cboConditionRelation
			// 
			this.m_cboConditionRelation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionRelation.BorderColor = System.Drawing.Color.White;
			this.m_cboConditionRelation.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionRelation.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboConditionRelation.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboConditionRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboConditionRelation.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionRelation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionRelation.ForeColor = System.Drawing.Color.White;
			this.m_cboConditionRelation.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionRelation.ListForeColor = System.Drawing.Color.White;
			this.m_cboConditionRelation.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboConditionRelation.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboConditionRelation.Location = new System.Drawing.Point(132, 20);
			this.m_cboConditionRelation.Name = "m_cboConditionRelation";
			this.m_cboConditionRelation.SelectedIndex = -1;
			this.m_cboConditionRelation.SelectedItem = null;
			this.m_cboConditionRelation.Size = new System.Drawing.Size(148, 26);
			this.m_cboConditionRelation.TabIndex = 13;
			this.m_cboConditionRelation.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionRelation.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdCancel.ForeColor = System.Drawing.Color.White;
			this.m_cmdCancel.Location = new System.Drawing.Point(292, 52);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Size = new System.Drawing.Size(68, 28);
			this.m_cmdCancel.TabIndex = 100;
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_txtConditionalValue
			// 
			this.m_txtConditionalValue.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtConditionalValue.BorderColor = System.Drawing.Color.White;
			this.m_txtConditionalValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtConditionalValue.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtConditionalValue.ForeColor = System.Drawing.Color.White;
			this.m_txtConditionalValue.Location = new System.Drawing.Point(72, 52);
			this.m_txtConditionalValue.Name = "m_txtConditionalValue";
			this.m_txtConditionalValue.Size = new System.Drawing.Size(212, 26);
			this.m_txtConditionalValue.TabIndex = 11;
			this.m_txtConditionalValue.Text = "";
			// 
			// m_cboConditionOperator
			// 
			this.m_cboConditionOperator.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionOperator.BorderColor = System.Drawing.Color.White;
			this.m_cboConditionOperator.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionOperator.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboConditionOperator.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboConditionOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboConditionOperator.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionOperator.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionOperator.ForeColor = System.Drawing.Color.White;
			this.m_cboConditionOperator.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionOperator.ListForeColor = System.Drawing.Color.White;
			this.m_cboConditionOperator.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboConditionOperator.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboConditionOperator.Location = new System.Drawing.Point(180, 20);
			this.m_cboConditionOperator.Name = "m_cboConditionOperator";
			this.m_cboConditionOperator.SelectedIndex = -1;
			this.m_cboConditionOperator.SelectedItem = null;
			this.m_cboConditionOperator.Size = new System.Drawing.Size(104, 26);
			this.m_cboConditionOperator.TabIndex = 10;
			this.m_cboConditionOperator.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionOperator.TextForeColor = System.Drawing.Color.White;
			// 
			// m_cboConditionItem
			// 
			this.m_cboConditionItem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionItem.BorderColor = System.Drawing.Color.White;
			this.m_cboConditionItem.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionItem.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboConditionItem.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboConditionItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboConditionItem.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionItem.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboConditionItem.ForeColor = System.Drawing.Color.White;
			this.m_cboConditionItem.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionItem.ListForeColor = System.Drawing.Color.White;
			this.m_cboConditionItem.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboConditionItem.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboConditionItem.Location = new System.Drawing.Point(16, 20);
			this.m_cboConditionItem.Name = "m_cboConditionItem";
			this.m_cboConditionItem.SelectedIndex = -1;
			this.m_cboConditionItem.SelectedItem = null;
			this.m_cboConditionItem.Size = new System.Drawing.Size(160, 26);
			this.m_cboConditionItem.TabIndex = 9;
			this.m_cboConditionItem.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboConditionItem.TextForeColor = System.Drawing.Color.White;
			// 
			// m_lblRelation
			// 
			this.m_lblRelation.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblRelation.ForeColor = System.Drawing.Color.White;
			this.m_lblRelation.Location = new System.Drawing.Point(28, 22);
			this.m_lblRelation.Name = "m_lblRelation";
			this.m_lblRelation.TabIndex = 17;
			this.m_lblRelation.Text = "关系类型：";
			// 
			// frmModifyStatistics
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(384, 97);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cboConditionItem,
																		  this.m_cboConditionOperator,
																		  this.m_lblRelation,
																		  this.m_cboConditionRelation,
																		  this.m_cmdOK,
																		  this.m_lblStatisticType,
																		  this.m_cboStaticDefinition,
																		  this.m_cmdCancel,
																		  this.m_txtConditionalValue});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmModifyStatistics";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "修改";
			this.ResumeLayout(false);

		}
		#endregion

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
			this.Close();
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(!m_blnSaveToNode()) return;
			this.DialogResult=DialogResult.OK;
			this.Close();
		}

		private void m_cboStaticDefinition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(m_cboStaticDefinition.SelectedIndex==-1) return;
			m_mthLoadConditionOption();
			
		}
	}
}
