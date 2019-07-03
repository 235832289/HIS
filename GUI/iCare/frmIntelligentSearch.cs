using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using iCareData;

using System.Windows.Forms;


namespace iCare
{
	public class frmIntelligentSearch : iCare.frmPrimaryForm
	{
		private System.Windows.Forms.TreeView trvSearchType;
		protected System.Windows.Forms.Label m_lblForTitle;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button m_cmdPerformQuery;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView m_lsvQueryResult;
		private System.Windows.Forms.Label m_lblSearchDesc;
		private System.Data.DataSet dtsTemp;
		private System.Data.DataTable m_dtbSearchContent;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn1;
		private System.ComponentModel.IContainer components = null;

		public frmIntelligentSearch()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool.m_mthChangedSubControlsBorder(this);

			trvSearchType.Nodes.Add(m_trnRoot);
		}

		private const string c_strSplitSelectedFieldSymbol = "ぁ";

		#region Xml节点名称定义
		/// <summary>
		/// 系统定义条件
		/// </summary>
		private const string c_strFixedSystems = "FixedSystems";
		/// <summary>
		/// 用户定义条件
		/// </summary>
		private const string c_strUserCondiction = "UserCondiction";
		/// <summary>
		/// 查询条件
		/// </summary>
		private const string c_strCondiction = "Condiction";
		/// <summary>
		/// 查询条件的组合类型
		/// </summary>
		private const string c_strCondictionSymbol = "Symbol";
		/// <summary>
		/// 查询条件项目
		/// </summary>
		private const string c_strItem = "Item";
		/// <summary>
		/// 查询条件项目的字段名称
		/// </summary>
		private const string c_strItemOptionName = "OptionName";
		/// <summary>
		/// 查询条件项目的操作
		/// </summary>
		private const string c_strItemSymbol = "Symbol";
		/// <summary>
		/// 查询条件项目的默认值
		/// </summary>
		private const string c_strItemDefaultValue = "DefaultValue";
		/// <summary>
		/// 查询条件项目的默认值
		/// </summary>
		private const string c_strItemIsUse = "IsUse";

		/// <summary>
		/// Like操作符
		/// </summary>
		private const string c_strLikeOperator = "like";
		#endregion Xml节点名称定义

		/// <summary>
		/// 查询模板列表的根节点
		/// </summary>
		private TreeNode m_trnRoot = new TreeNode("查询分类");

		/// <summary>
		/// 查询条件的操作符：＝ != like ...
		/// </summary>
		private clsStatisticConditionOperatorValue [] m_objConditionOperatorArr=null;

		/// <summary>
		/// 查询条件的组合关系：and or
		/// </summary>
		private clsStatisticCCOperatorValue [] m_objCCOperatorArr=null;
		
		/// <summary>
		/// 智能统计的Domain
		/// </summary>
		private clsIntelligentStatisticsDomain m_objDomain=new clsIntelligentStatisticsDomain();

		/// <summary>
		/// 存放查询类型中定义的可以作为显示结果的字段信息。m_strStatistic_ID为Key，clsStatisticSelectedFieldValue[]为Value。
		/// </summary>
		private Hashtable m_hasSelectedField = new Hashtable();
		/// <summary>
		/// 存放查询类型中定义的可以作为条件的字段信息。m_strStatistic_ID为Key，clsStatisticCondictionOptionValue[]为Value。
		/// </summary>
		private Hashtable m_hasConditionField = new Hashtable();
		
		/// <summary>
		/// Clean up any resources being used.
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIntelligentSearch));
			this.trvSearchType = new System.Windows.Forms.TreeView();
			this.m_lblForTitle = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_lblSearchDesc = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.m_dtbSearchContent = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtsTemp = new System.Data.DataSet();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_lsvQueryResult = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cmdPerformQuery = new System.Windows.Forms.Button();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataGridBoolColumn1 = new System.Windows.Forms.DataGridBoolColumn();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtbSearchContent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtsTemp)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// trvSearchType
			// 
			this.trvSearchType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.trvSearchType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvSearchType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvSearchType.ForeColor = System.Drawing.SystemColors.Window;
			this.trvSearchType.HideSelection = false;
			this.trvSearchType.ImageIndex = -1;
			this.trvSearchType.ItemHeight = 18;
			this.trvSearchType.Location = new System.Drawing.Point(40, 68);
			this.trvSearchType.Name = "trvSearchType";
			this.trvSearchType.SelectedImageIndex = -1;
			this.trvSearchType.ShowRootLines = false;
			this.trvSearchType.Size = new System.Drawing.Size(260, 240);
			this.trvSearchType.TabIndex = 502;
			this.trvSearchType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvSearchType_AfterSelect);
			this.trvSearchType.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvSearchType_BeforeExpand);
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblForTitle.Location = new System.Drawing.Point(324, 8);
			this.m_lblForTitle.Name = "m_lblForTitle";
			this.m_lblForTitle.Size = new System.Drawing.Size(416, 48);
			this.m_lblForTitle.TabIndex = 503;
			this.m_lblForTitle.Text = "智 能 查 询";
			this.m_lblForTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_lblSearchDesc,
																					this.dataGrid1});
			this.groupBox1.Location = new System.Drawing.Point(316, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(660, 252);
			this.groupBox1.TabIndex = 504;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询内容";
			// 
			// m_lblSearchDesc
			// 
			this.m_lblSearchDesc.Location = new System.Drawing.Point(16, 28);
			this.m_lblSearchDesc.Name = "m_lblSearchDesc";
			this.m_lblSearchDesc.Size = new System.Drawing.Size(632, 40);
			this.m_lblSearchDesc.TabIndex = 2;
			this.m_lblSearchDesc.Text = "查询说明：";
			// 
			// dataGrid1
			// 
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.m_dtbSearchContent;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 76);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(632, 160);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// m_dtbSearchContent
			// 
			this.m_dtbSearchContent.Columns.AddRange(new System.Data.DataColumn[] {
																					  this.dataColumn1,
																					  this.dataColumn2,
																					  this.dataColumn3,
																					  this.dataColumn4,
																					  this.dataColumn5});
			this.m_dtbSearchContent.TableName = "SearchContent";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "名称";
			this.dataColumn1.ColumnName = "ConditionName";
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "条件值";
			this.dataColumn2.ColumnName = "ConditionValue";
			// 
			// dataColumn3
			// 
			this.dataColumn3.Caption = "说明";
			this.dataColumn3.ColumnName = "ConditionExplain";
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "XmlNode";
			this.dataColumn4.DataType = typeof(object);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridBoolColumn1,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "SearchContent";
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "名称";
			this.dataGridTextBoxColumn1.MappingName = "ConditionName";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 120;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "条件值";
			this.dataGridTextBoxColumn2.MappingName = "ConditionValue";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 120;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "说明";
			this.dataGridTextBoxColumn3.MappingName = "ConditionExplain";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 300;
			// 
			// dtsTemp
			// 
			this.dtsTemp.DataSetName = "TempDTS";
			this.dtsTemp.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.dtsTemp.Tables.AddRange(new System.Data.DataTable[] {
																		 this.m_dtbSearchContent});
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_lsvQueryResult,
																					this.label1,
																					this.m_cmdPerformQuery});
			this.groupBox2.Location = new System.Drawing.Point(40, 324);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(936, 304);
			this.groupBox2.TabIndex = 505;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "查询结果";
			// 
			// m_lsvQueryResult
			// 
			this.m_lsvQueryResult.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvQueryResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvQueryResult.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvQueryResult.ForeColor = System.Drawing.Color.White;
			this.m_lsvQueryResult.FullRowSelect = true;
			this.m_lsvQueryResult.GridLines = true;
			this.m_lsvQueryResult.Location = new System.Drawing.Point(16, 76);
			this.m_lsvQueryResult.MultiSelect = false;
			this.m_lsvQueryResult.Name = "m_lsvQueryResult";
			this.m_lsvQueryResult.Size = new System.Drawing.Size(904, 208);
			this.m_lsvQueryResult.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvQueryResult.TabIndex = 171;
			this.m_lsvQueryResult.View = System.Windows.Forms.View.Details;
			this.m_lsvQueryResult.DoubleClick += new System.EventHandler(this.m_lsvQueryResult_DoubleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(88, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 23);
			this.label1.TabIndex = 142;
			this.label1.Text = "提示：双击结果来查看具体内容";
			// 
			// m_cmdPerformQuery
			// 
			this.m_cmdPerformQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdPerformQuery.Location = new System.Drawing.Point(16, 32);
			this.m_cmdPerformQuery.Name = "m_cmdPerformQuery";
			this.m_cmdPerformQuery.Size = new System.Drawing.Size(64, 32);
			this.m_cmdPerformQuery.TabIndex = 141;
			this.m_cmdPerformQuery.Text = "查询";
			this.m_cmdPerformQuery.Click += new System.EventHandler(this.m_cmdPerformQuery_Click);
			// 
			// dataColumn5
			// 
			this.dataColumn5.AllowDBNull = false;
			this.dataColumn5.ColumnName = "IsUse";
			this.dataColumn5.DataType = typeof(bool);
			this.dataColumn5.DefaultValue = false;
			// 
			// dataGridBoolColumn1
			// 
			this.dataGridBoolColumn1.AllowNull = false;
			this.dataGridBoolColumn1.FalseValue = false;
			this.dataGridBoolColumn1.HeaderText = "使用";
			this.dataGridBoolColumn1.MappingName = "IsUse";
			this.dataGridBoolColumn1.NullText = "";
			this.dataGridBoolColumn1.NullValue = ((System.DBNull)(resources.GetObject("dataGridBoolColumn1.NullValue")));
			this.dataGridBoolColumn1.TrueValue = true;
			this.dataGridBoolColumn1.Width = 60;
			// 
			// frmIntelligentSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(1016, 733);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox1,
																		  this.groupBox2,
																		  this.m_lblForTitle,
																		  this.trvSearchType});
			this.Name = "frmIntelligentSearch";
			this.Text = "智能查询";
			this.Load += new System.EventHandler(this.frmIntelligentSearch_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtbSearchContent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtsTemp)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 控件事件
		private void frmIntelligentSearch_Load(object sender, System.EventArgs e)
		{
			m_mthInitStatisticDefinitionNode();
			m_mthInitConditionOperator();
			m_mthInitConditionRelation();
		}

		private void trvSearchType_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthInitQueryModeInfo(e.Node);
		}

		private void trvSearchType_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			m_mthInitStatisticQueryNode(e.Node);
		}

		private void m_cmdPerformQuery_Click(object sender, System.EventArgs e)
		{
			m_mthSearch();
		}

		private void m_lsvQueryResult_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvQueryResult.SelectedIndices == null ||
				m_lsvQueryResult.SelectedIndices.Count == 0)
				return;

			TreeNode trnCurrentQueryMode = trvSearchType.SelectedNode;

			//判断是否查询模板的节点
			if(!m_blnIsQueryModeTreeNode(trnCurrentQueryMode))
				return;

			clsStatisticDefinitionValue objDefinition = (clsStatisticDefinitionValue)trnCurrentQueryMode.Parent.Tag;


			m_mthOpenOrderByReflection(objDefinition,(string[,])m_lsvQueryResult.Tag,m_lsvQueryResult.SelectedIndices[0]);
		}
		#endregion 控件事件

		#region 模板列表信息
		/// <summary>
		/// 初始化查询类型
		/// </summary>
		private void m_mthInitStatisticDefinitionNode()
		{
			clsStatisticDefinitionValue [] objStatisticDefinitionArr=null;

			long lngRes=m_objDomain.m_lngGetAllStatisticDefinition(out objStatisticDefinitionArr);

			m_trnRoot.Nodes.Clear();

			if(lngRes<=0 || objStatisticDefinitionArr==null) return;

			for(int i=0;i<objStatisticDefinitionArr.Length;i++)
			{
				TreeNode trnType = new TreeNode(objStatisticDefinitionArr[i].m_strStatisticDesc);
				trnType.Tag = objStatisticDefinitionArr[i];
				trnType.Nodes.Add(".");

				m_trnRoot.Nodes.Add(trnType);
			}

			m_trnRoot.Expand();
		}
		/// <summary>
		/// 初始化已经生成的查询模板
		/// </summary>
		/// <param name="p_trnDefinition">查询模板相对应的查询类型节点。如果节点不是查询类型节点，不做任何操作</param>
		private void m_mthInitStatisticQueryNode(TreeNode p_trnDefinition)
		{
			if(!m_blnIsDefinitionTreeNode(p_trnDefinition))
				return;

			//判断是否已经初始化
			if(!(p_trnDefinition.Nodes.Count == 1 && p_trnDefinition.Nodes[0].Tag == null))
				return;

			clsStatisticDefinitionValue objStatisDefValue = (clsStatisticDefinitionValue)p_trnDefinition.Tag;

			p_trnDefinition.Nodes.Clear();

			clsStatisticQueryModeValue[] objStaticQueryMode;

			long lngRes=m_objDomain.m_lngGetStatisticQueryMode(objStatisDefValue.m_strStatistic_ID,out objStaticQueryMode);

			if(lngRes<=0 || objStaticQueryMode==null || objStaticQueryMode.Length==0) return;

			for(int i=0;i<objStaticQueryMode.Length;i++)
			{
				TreeNode trnType = new TreeNode(objStaticQueryMode[i].m_strQueryName);
				trnType.Tag = objStaticQueryMode[i];

				p_trnDefinition.Nodes.Add(trnType);
			}

			p_trnDefinition.Expand();
		}
		#endregion 模板列表信息

		#region Statistic信息
		/// <summary>
		/// 初始化查询条件的操作符
		/// </summary>
		private void m_mthInitConditionOperator()
		{
			long lngRes=m_objDomain.lngGetStatisticConditionOperatorValue(out m_objConditionOperatorArr);

			if(lngRes <= 0)
				m_objConditionOperatorArr = new clsStatisticConditionOperatorValue[0];
		}
		/// <summary>
		/// 初始化查询条件的组合关系
		/// </summary>
		private void m_mthInitConditionRelation()
		{
			long lngRes=m_objDomain.m_lngGetAllStatisticCCOperator(out m_objCCOperatorArr);

			if(lngRes <= 0)
				m_objCCOperatorArr = new clsStatisticCCOperatorValue[0];
		}
		#endregion Statistic信息

		#region 查询模板
		/// <summary>
		/// 初始化查询模板信息
		/// </summary>
		/// <param name="p_trnQueryMode">查询模板的树节点。如果节点不是查询模板节点，不做任何操作</param>
		private void m_mthInitQueryModeInfo(TreeNode p_trnQueryMode)
		{
			m_mthClearQueryInfo();

			if(!m_blnIsQueryModeTreeNode(p_trnQueryMode))
				return;

			clsStatisticQueryModeValue objQueryMode = (clsStatisticQueryModeValue)p_trnQueryMode.Tag;
			clsStatisticDefinitionValue objDefinition = (clsStatisticDefinitionValue)p_trnQueryMode.Parent.Tag;

			m_mthInitQueryDisplayField(objDefinition,objQueryMode);
			m_mthInitQueryDetail(objDefinition,objQueryMode);
		}
		/// <summary>
		/// 初始化查询结果字段
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_objQueryMode">查询模板</param>
		private void m_mthInitQueryDisplayField(clsStatisticDefinitionValue p_objDefinition,clsStatisticQueryModeValue p_objQueryMode)
		{
			if(p_objDefinition == null || m_blnIsEmptyString(p_objDefinition.m_strStatistic_ID) ||  p_objQueryMode == null || m_blnIsEmptyString(p_objQueryMode.m_strSelectedFieldIndexes))
			{
				return;
			}

			clsStatisticSelectedFieldValue [] objSelectedFieldArr = (clsStatisticSelectedFieldValue [])m_hasSelectedField[p_objDefinition.m_strStatistic_ID];

			if(objSelectedFieldArr == null)
			{
				long lngRes=m_objDomain.m_lngGetAllStatisticSelectedField(p_objDefinition.m_strStatistic_ID,out objSelectedFieldArr);

				if(lngRes <= 0 || objSelectedFieldArr == null || objSelectedFieldArr.Length == 0)
					return;

				m_hasSelectedField[p_objDefinition.m_strStatistic_ID] = objSelectedFieldArr;
			}

			string[] strSelectedFieldsArr=null;
			if( p_objQueryMode.m_strSelectedFieldIndexes.IndexOf(c_strSplitSelectedFieldSymbol)<0)
			{
				strSelectedFieldsArr=new string[1];
				strSelectedFieldsArr[0]=p_objQueryMode.m_strSelectedFieldIndexes.Trim();
			}
			else
			{
				strSelectedFieldsArr=p_objQueryMode.m_strSelectedFieldIndexes.Split(c_strSplitSelectedFieldSymbol.ToCharArray());
			}

			for(int i=0;i<strSelectedFieldsArr.Length;i++)
			{
				for(int j2=0;j2<objSelectedFieldArr.Length;j2++)
				{
					if(objSelectedFieldArr[j2].m_strFieldName == strSelectedFieldsArr[i])
					{
						m_lsvQueryResult.Columns.Add(objSelectedFieldArr[j2].m_strFieldDesc,120,HorizontalAlignment.Left);
						break;
					}
				}
			}
		}
		/// <summary>
		/// 初始化查询模板细节信息
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_objQueryMode">查询模板</param>
		private void m_mthInitQueryDetail(clsStatisticDefinitionValue p_objDefinition,clsStatisticQueryModeValue p_objQueryMode)
		{
			if(p_objDefinition == null || m_blnIsEmptyString(p_objDefinition.m_strStatistic_ID) ||  p_objQueryMode == null || m_blnIsEmptyString(p_objQueryMode.m_strModeDesc))
			{
				return;
			}

			m_lblSearchDesc.Text = "查询说明："+p_objQueryMode.m_strModeDesc;			

			m_mthLoadXmlToDataGrid(p_objDefinition,p_objQueryMode);
		}	
		/// <summary>
		/// 清空查询模板相关内容
		/// </summary>
		private void m_mthClearQueryInfo()
		{
			m_lblSearchDesc.Text = "查询说明：";

			m_dtbSearchContent.Rows.Clear();

			m_lsvQueryResult.Clear();
			m_lsvQueryResult.Tag = null;
		}
		#endregion 查询模板

		#region 执行查询
		/// <summary>
		/// 查询
		/// </summary>
		private void m_mthSearch()
		{
			m_lsvQueryResult.Items.Clear();

			TreeNode trnCurrentQueryMode = trvSearchType.SelectedNode;

			//判断是否查询模板的节点
			if(!m_blnIsQueryModeTreeNode(trnCurrentQueryMode))
				return;

			clsStatisticQueryModeValue objQueryMode = (clsStatisticQueryModeValue)trnCurrentQueryMode.Tag;
			clsStatisticDefinitionValue objDefinition = (clsStatisticDefinitionValue)trnCurrentQueryMode.Parent.Tag;

			m_mthMakeXmlContentValue();

			string [,] strQueryReslutDArr = m_strGetResultArr(objDefinition,objQueryMode);

			m_mthDisplayResult(objDefinition,strQueryReslutDArr);
		}
		/// <summary>
		/// 获取查询条件值
		/// </summary>
		/// <returns></returns>
		private void m_mthMakeXmlContentValue()
		{
			XmlDocument objXmlDoc = (XmlDocument)dataGrid1.Tag;

			if(objXmlDoc == null)
				return;

			for(int i=0;i<m_dtbSearchContent.Rows.Count;i++)
			{
				object [] objValueArr = m_dtbSearchContent.Rows[i].ItemArray;
				XmlNode xndItem = (XmlNode)objValueArr[3];

				string strSymbol = xndItem.Attributes[c_strItemSymbol].Value;
				if(strSymbol.ToLower() == c_strLikeOperator)
				{
					//去除Like中的%%
					objValueArr[1] = "%"+objValueArr[1].ToString()+"%";	
				}

				xndItem.Attributes[c_strItemDefaultValue].Value = "'"+objValueArr[1].ToString()+"'";
				
				XmlAttribute xmlIsUse = objXmlDoc.CreateAttribute(c_strItemIsUse);
				xmlIsUse.Value = objValueArr[4].ToString();
				xndItem.Attributes.Append(xmlIsUse);
			}
		}
		/// <summary>
		/// 获取查询结果
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_objQueryMode">查询模板</param>
		/// <returns></returns>
		private string [,] m_strGetResultArr(clsStatisticDefinitionValue p_objDefinition,clsStatisticQueryModeValue p_objQueryMode)
		{
			if(p_objDefinition == null || m_blnIsEmptyString(p_objDefinition.m_strStatisticSQLContent) || m_blnIsEmptyString(p_objDefinition.m_strOpenClassParameters))
				return null;

			if(p_objQueryMode == null || m_blnIsEmptyString(p_objQueryMode.m_strSelectedFieldIndexes) )
				return null;

			string [,] strQueryReslutDArr = null;
			long lngRes=m_objDomain.m_lngPerformSqlQuery(p_objDefinition.m_strStatisticSQLContent,p_objDefinition.m_strOpenClassParameters,p_objQueryMode.m_strSelectedFieldIndexes.Replace(c_strSplitSelectedFieldSymbol,","),
				(XmlDocument)dataGrid1.Tag,out strQueryReslutDArr);

			if(lngRes<=0 || strQueryReslutDArr == null)
			{				
				return null;
			}
			else
			{
				return strQueryReslutDArr;
			}
		}
		/// <summary>
		/// 显示查询结果
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_strQueryReslutDArr">查询结果</param>
		private void m_mthDisplayResult(clsStatisticDefinitionValue p_objDefinition,string [,] p_strQueryReslutDArr)
		{
			if(p_objDefinition == null || p_strQueryReslutDArr == null)
				return;

			int intParametersNum = m_intGetDefinitionParametersNum(p_objDefinition);

			int intColumnNum=m_lsvQueryResult.Columns.Count;
			int intRowNum=p_strQueryReslutDArr.Length/(intColumnNum+intParametersNum);

			ListViewItem[] objLsvItemArr=new ListViewItem[intRowNum];
			for(int i=0;i<intRowNum;i++)
			{
				string[] strItemArr=new string[intColumnNum];
				for(int k2=0;k2<intColumnNum;k2++)
				{
					strItemArr[k2]=p_strQueryReslutDArr[i,k2+intParametersNum];										
				}
				objLsvItemArr[i]=new ListViewItem(strItemArr);
			}
			m_lsvQueryResult.Items.AddRange(objLsvItemArr);
			m_lsvQueryResult.Tag = p_strQueryReslutDArr;
		}
		#endregion 执行查询

		#region Xml内容处理工具
		/// <summary>
		/// 把Xml中用户定义值放置在DataGrid
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_objQueryMode">查询模板</param>
		private void m_mthLoadXmlToDataGrid(clsStatisticDefinitionValue p_objDefinition,clsStatisticQueryModeValue p_objQueryMode)
		{
			if(p_objDefinition == null || p_objQueryMode == null || m_blnIsEmptyString(p_objQueryMode.m_strXMLContent))
				return;

			XmlDocument objXmlDoc = new XmlDocument();
			try
			{
				objXmlDoc.LoadXml(p_objQueryMode.m_strXMLContent);
			}
			catch
			{
				return;
			}

			XmlNodeList xnlUserCondition = objXmlDoc.GetElementsByTagName(c_strUserCondiction);

			if(xnlUserCondition.Count <= 0)
				return;

			clsStatisticCondictionOptionValue [] objCondictionOptionArr = (clsStatisticCondictionOptionValue [])m_hasConditionField[p_objDefinition.m_strStatistic_ID];

			if(objCondictionOptionArr == null)
			{
				long lngRes=m_objDomain.m_lngGetStatisticCondictionOptionValue(p_objDefinition.m_strStatistic_ID,out objCondictionOptionArr);

				if(lngRes <= 0 || objCondictionOptionArr == null)
					return;

				m_hasConditionField[p_objDefinition.m_strStatistic_ID] = objCondictionOptionArr; 
			}

			foreach(XmlNode xndCondition in xnlUserCondition)
			{
				XmlNode xndParentCondition = xndCondition;

				m_mthAddUserConditionToDataGrid(xndCondition,objCondictionOptionArr);
			}

			dataGrid1.Tag = objXmlDoc;
		}
		/// <summary>
		/// 把Xml中用户定义值放置在DataGrid
		/// </summary>
		/// <param name="p_xndCondition">用户定义的Xml节点</param>
		/// <param name="p_objCondictionOptionArr">查询类型中允许作为条件的字段信息</param>
		private void m_mthAddUserConditionToDataGrid(XmlNode p_xndCondition,clsStatisticCondictionOptionValue [] p_objCondictionOptionArr)
		{
			foreach(XmlNode xndChild in p_xndCondition.ChildNodes)
			{
				if(xndChild.Name == c_strItem)
				{
					string strOptionName = xndChild.Attributes[c_strItemOptionName].Value;
					for(int i=0;i<p_objCondictionOptionArr.Length;i++)
					{
						if(strOptionName == p_objCondictionOptionArr[i].m_strOptionFieldName)
						{
							strOptionName = p_objCondictionOptionArr[i].m_strOptionDesc;
							break;
						}
					}

					string strValue = xndChild.Attributes[c_strItemDefaultValue].Value;
					strValue = strValue.Substring(1,strValue.Length-2);	
				
					string strSymbol = xndChild.Attributes[c_strItemSymbol].Value;
					if(strSymbol.ToLower() == c_strLikeOperator)
					{
						//去除Like中的%%
						strValue = strValue.Substring(1,strValue.Length-2);	
					}

					for(int i=0;i<m_objConditionOperatorArr.Length;i++)
					{
						if(strSymbol == m_objConditionOperatorArr[i].m_strOperatorSymbol)
						{
							strSymbol = m_objConditionOperatorArr[i].m_strOperatorDesc;
							break;
						}
					}

					//添加到DataGrid
					object [] objCondition = new object[4];
					objCondition[0] = strOptionName;
					objCondition[1] = strValue;
					objCondition[2] = strSymbol;
					objCondition[3] = xndChild;

					m_dtbSearchContent.Rows.Add(objCondition);
					
				}
				else
				{
					//递归
					m_mthAddUserConditionToDataGrid(xndChild,p_objCondictionOptionArr);
				}
			}
		}
		#endregion Xml内容处理工具

		#region 打开查询结果对应的单
		/// <summary>
		/// 需要用到的数据库字段：OpenClassName,OpenClassMethod,OpenClassParameters。
		/// OpenClassParameters是放多个值，用","分隔，按顺序调用，其中记录的是数据库的字段名，并且跟OpenClassMethod的参数相对应(p_frmInvoker除外)。
		/// 查询时返回的二维数值前若干列返回OpenClassParameters对应的数据库中的值。
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <param name="p_strResArr">查询结果的数组</param>
		/// <param name="p_intClickRow">用户点击的记录行</param>
		private void m_mthOpenOrderByReflection(clsStatisticDefinitionValue p_objDefinition,string [,] p_strResArr,int p_intClickRow)
		{			
			int intParametersNum = m_intGetDefinitionParametersNum(p_objDefinition);				

			object[] objArr=new object[intParametersNum+1];
			objArr[0]=this;
			for(int i=0;i<objArr.Length-1;i++)
			{				
				objArr[i+1]=p_strResArr[p_intClickRow,i];
			}

			this.Cursor=Cursors.WaitCursor;
			try
			{
				Type typ = Type.GetType(p_objDefinition.m_strOpenClassName.Trim());
				Object obj=Activator.CreateInstance(typ);
				typ.GetMethod(p_objDefinition.m_strOpenClassMethod.Trim()).Invoke(obj,objArr);
			}
			catch
			{
				this.Cursor=Cursors.Default;
				return;
			}
			this.Cursor=Cursors.Default;
		}
		#endregion

		#region 辅助工具
		/// <summary>
		/// 判断字符串是否为空
		/// </summary>
		/// <param name="p_str">字符串</param>
		/// <returns></returns>
		private bool m_blnIsEmptyString(string p_str)
		{
			return (p_str==null || p_str.Trim().Length==0);
		}

		/// <summary>
		/// 判断是否模板类型的节点
		/// </summary>
		/// <param name="p_trnNode">树节点</param>
		/// <returns></returns>
		private bool m_blnIsDefinitionTreeNode(TreeNode p_trnNode)
		{
			if(p_trnNode == null || p_trnNode.Tag == null || p_trnNode.Tag.GetType().Name != "clsStatisticDefinitionValue")
				return false;
			else
				return true;
		}

		/// <summary>
		/// 判断是否查询模板的节点
		/// </summary>
		/// <param name="p_trnNode">树节点</param>
		/// <returns></returns>
		private bool m_blnIsQueryModeTreeNode(TreeNode p_trnNode)
		{
			if(p_trnNode == null || p_trnNode.Tag == null || p_trnNode.Tag.GetType().Name != "clsStatisticQueryModeValue")
				return false;
			else
				return true;
		}

		/// <summary>
		/// 获取查询类型中定义的参数个数
		/// </summary>
		/// <param name="p_objDefinition">查询类型</param>
		/// <returns></returns>
		private int m_intGetDefinitionParametersNum(clsStatisticDefinitionValue p_objDefinition)
		{
			int intParametersNum = 0;

			if(m_blnIsEmptyString(p_objDefinition.m_strOpenClassParameters))
			{
				intParametersNum=0;
			}
			else if(p_objDefinition.m_strOpenClassParameters.IndexOf(",")<0)
			{
				intParametersNum = 1;
			}
			else		
			{
				intParametersNum = p_objDefinition.m_strOpenClassParameters.Split(',').Length;
			}

			return intParametersNum;
		}
		#endregion 辅助工具
	}
}

