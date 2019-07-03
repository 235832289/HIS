using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// TextBoxListView 控件。
	/// 作者： 徐斌辉
	/// 最后修改时间： 2004-09-24
	/// </summary>
	[DefaultProperty("Text")]
	public class TextBoxListView : System.Windows.Forms.UserControl
	{
		#region 控件-变量申明
		public System.Windows.Forms.ListView lsvContext;
		public System.Windows.Forms.TextBox txbDisplay;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		//ListView的tag属性 [_text对应的tag]
		private string _value ="";
		private int _textfieldindex =1;		//Text的字段索引,从0开始算.		显示在文本框中
		private int _valuefieldindex =0;	//Value的字段索引,从0开始算.	放在Tag属性中
		private bool _tagfieldvisible =true;//Tag对应的字段是否显示在ListView中
		private DataTable _datatable =null;	//绑定数据源
		private string _columnsname ="";	//ListView的列表Text属性，用“,”号分割。{注意：1、没有得则默认显示字段；2、隐藏的字段也算；}
		private string _columnswidth ="";	//ListView的列表Text属性，用“,”号分割。{注意：1、没有得则默认为80；2、隐藏的字段也算；}
		private string _indexfield ="";		//确定索引字段,用“,”号分割。{注意：1、为空得则默认所有字段；2、小于0则不索引；3、隐藏的字段不算；}
		const int COLUMNWIDTH =80;			//默认的列宽值.
		#endregion

		#region 构造函数
		public TextBoxListView()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化		
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

		#endregion

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.lsvContext = new System.Windows.Forms.ListView();
			this.txbDisplay = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lsvContext
			// 
			this.lsvContext.FullRowSelect = true;
			this.lsvContext.GridLines = true;
			this.lsvContext.Location = new System.Drawing.Point(0, 24);
			this.lsvContext.MultiSelect = false;
			this.lsvContext.Name = "lsvContext";
			this.lsvContext.Size = new System.Drawing.Size(160, 152);
			this.lsvContext.TabIndex = 7;
			this.lsvContext.View = System.Windows.Forms.View.Details;
			this.lsvContext.Visible = false;
			this.lsvContext.ItemActivate += new System.EventHandler(this.lsvContext_ItemActivate);
			this.lsvContext.VisibleChanged += new System.EventHandler(this.lsvContext_VisibleChanged);
			this.lsvContext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lsvContext_KeyUp);
			this.lsvContext.Leave += new System.EventHandler(this.lsvContext_Leave);
			// 
			// txbDisplay
			// 
			this.txbDisplay.Dock = System.Windows.Forms.DockStyle.Top;
			this.txbDisplay.Location = new System.Drawing.Point(0, 0);
			this.txbDisplay.Name = "txbDisplay";
			this.txbDisplay.Size = new System.Drawing.Size(160, 26);
			this.txbDisplay.TabIndex = 6;
			this.txbDisplay.Text = "";
			this.txbDisplay.Validated += new System.EventHandler(this.txbDisplay_Leave);
			this.txbDisplay.DoubleClick += new System.EventHandler(this.txbDisplay_DoubleClick);
			this.txbDisplay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbDisplay_KeyUp);
			this.txbDisplay.Enter += new System.EventHandler(this.txbDisplay_Enter);
			// 
			// TextBoxListView
			// 
			this.Controls.Add(this.lsvContext);
			this.Controls.Add(this.txbDisplay);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.Name = "TextBoxListView";
			this.Size = new System.Drawing.Size(160, 176);
			this.Resize += new System.EventHandler(this.TextBoxListView_Resize);
			this.Load += new System.EventHandler(this.TextBoxListView_Load);
			this.ResumeLayout(false);

		}
		#endregion		

		#region 属性
		/// <summary>
		/// 获取或设置控件的Value
		/// </summary>
		[Category("外观"),Description("获取或设置控件的Value.")]
		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value =value;
			}
		}
		/// <summary>
		/// 获取或设置控件的Text
		/// </summary>
		[Category("外观"),Description("获取或设置控件的Text.")]
		public override string Text
		{
			get
			{
				if(txbDisplay!=null)
					return txbDisplay.Text;
				else
					return "";
			}
			set
			{
				txbDisplay.Text =value;
			}
		}
		/// <summary>
		/// 获取或设置ListView的高度
		/// </summary>
		[Category("外观"),DefaultValue(100),Description("获取或设置ListView的高度.")]
		public int HeightListView
		{
			get
			{
				return lsvContext.Height;
			}
			set
			{
				lsvContext.Height =value;
			}
		}
		/// <summary>
		/// Text的字段索引,从0开始算.
		/// </summary>
		[Category("行为"),DefaultValue(1),Description("Text的字段索引,从0开始算..")]
		public int TextField
		{
			get
			{
				return _textfieldindex;
			}
			set
			{
				_textfieldindex =value;
			}
		}
		/// <summary>
		/// Value的字段索引,从0开始算.
		/// </summary>
		[Category("行为"),DefaultValue(0),Description("Value的字段索引,从0开始算..")]
		public int ValueField
		{
			get
			{
				return _valuefieldindex;
			}
			set
			{
				_valuefieldindex =value;
			}
		}
		/// <summary>
		/// Tag对应的字段是否显示在ListView中
		/// </summary>
		[Category("行为"),DefaultValue(true),Description("Tag对应的字段是否显示在ListView中")]
		public bool TagFieldVisible
		{
			get
			{
				return _tagfieldvisible;
			}
			set
			{
				_tagfieldvisible=value;
			}
		}
		/// <summary>
		/// 绑定的数据源
		/// </summary>
		[Category("数据"),Description("绑定的数据源")]
		public DataTable DataSource
		{
			get
			{
				return _datatable;
			}
			set
			{
				_datatable =value;
			}
		}
		/// <summary>
		/// 给列表头赋值.
		/// ListView的列表Text属性，用“,”号分割。{注意：1、没有得则默认显示字段；2、隐藏的字段也算；}
		/// </summary>
		[Category("行为"),DefaultValue(""),Description("列表头文本，用“,”号分割。\n{注意：1、没有得则默认显示字段；2、隐藏的字段也算；}\n例如：编号,姓名,性别")]
		public string ColumnsName
		{
			get
			{
				if(_columnsname.Trim()=="")
				{
					string strTem ="";
					for(int i1=0;i1<lsvContext.Columns.Count;i1++)
					{
						strTem +=lsvContext.Columns[i1].Text.Trim() + ",";
					}
					if(strTem.Trim() !="")
						_columnsname =strTem.Substring(0,strTem.Length-1);
					else
						_columnswidth ="";
				}
				return _columnsname;
			}
			set
			{
				try
				{
					_columnsname =value;
				}
				catch
				{
					_columnsname ="";
				}
			}
		}
		/// <summary>
		/// 制定列表的宽度
		/// ListView的列表Text属性，用“,”号分割。{注意：1、没有得则默认为80；2、隐藏的字段也算；}
		/// </summary>
		[Category("行为"),DefaultValue(""),Description("列表头的宽，用“,”号分割。\n{注意：1、没有得则默认为80；2、隐藏的字段也算；}\n例如：40,120,60")]
		public string ColumnsWidth
		{
			get
			{	
				if(_columnswidth.Trim()=="")
				{
					string strTem ="";
					for(int i1=0;i1<lsvContext.Columns.Count;i1++)
					{
						strTem +=lsvContext.Columns[i1].Width.ToString().Trim() + ",";
					}
					if(strTem.Trim() !="")
						_columnswidth =strTem.Substring(0,strTem.Length-1);
					else
						_columnswidth ="";
				}
				return _columnswidth;
			}
			set
			{
				_columnswidth =value;
			}
		}
		/// <summary>
		/// 确定索引字段
		/// 确定索引字段,用“,”号分割。{注意：1、为空得则默认所有字段；2、小于0则不索引；3、隐藏的字段也算；}
		/// </summary>
		[Category("行为"),DefaultValue(""),Description("确定索引字段,用“,”号分割。\n{注意：1、为空得则默认所有字段；2、小于0则不索引；3、隐藏的字段不算；}\n例如：1,2,3 ")]
		public string IndexField
		{
			get
			{
				return _indexfield;
			}
			set
			{
				_indexfield =value;			
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 绑定数据
		/// </summary>
		public void BindData()
		{	
			lsvContext.Columns.Clear();	
			lsvContext.Items.Clear();	
			if(_datatable==null || _datatable.Rows.Count <=0)
			{
				//显示列名
				DisplayColumnsName();
				return ;
			}
			lsvContext.HideSelection =false;

			ListViewItem lsvItem =null;
			string strColumnName="";			//列名
			int intColumnWidth =COLUMNWIDTH;	//列宽
			for(int iRow=0;iRow<_datatable.Rows.Count;iRow++)
			{
				lsvItem =null;
				for(int iCol=0;iCol<_datatable.Columns.Count;iCol++)
				{
					#region 加列表头
					//添加列名	
					if(iRow==0)
					{
						if(iCol!=_valuefieldindex || _tagfieldvisible)
						{
							//列名
							if(_columnsname.Trim()=="")
								strColumnName ="";
							else
								strColumnName =GetStringBySplit(_columnsname.Trim(),",",iCol);
							if(strColumnName.Trim()=="")
							{
								strColumnName =_datatable.Columns[iCol].ColumnName;
							}

							//列宽
							if(_columnswidth.Trim()=="")
								intColumnWidth =COLUMNWIDTH;
							else
							{
								try
								{
									intColumnWidth =Int32.Parse(GetStringBySplit(_columnswidth.Trim(),",",iCol));	//列宽
								}
								catch
								{
									intColumnWidth=COLUMNWIDTH;
								}
							}
							lsvContext.Columns.Add(strColumnName,intColumnWidth,HorizontalAlignment.Center);
						}
					}
					#endregion

					#region 加列表项
					if(iCol!=_valuefieldindex || _tagfieldvisible)
					{
						if (lsvItem==null)
						{
							try
							{
								lsvItem =new ListViewItem(_datatable.Rows[iRow][iCol].ToString());	
							}
							catch
							{
								lsvItem =new ListViewItem("");
							}	
						}
						else
						{
							try
							{
								lsvItem.SubItems.Add(_datatable.Rows[iRow][iCol].ToString());							
							}
							catch
							{
								lsvItem =new ListViewItem("");
							}	
						}
					}					
					#endregion
				}
				#region 给Tag赋值 {保证此字段必须有值}
				try
				{
					lsvItem.Tag = _datatable.Rows[iRow][_valuefieldindex].ToString();
				}
				catch
				{
					lsvItem.Tag = "";
				}
				#endregion
				lsvContext.Items.Add(lsvItem);
			}	
		}
		#endregion

		#region 事件
		private void TextBoxListView_Resize(object sender, System.EventArgs e)
		{
			if(this.DesignMode)
			{
				this.Height=txbDisplay.Height;
			}

			txbDisplay.Location=new Point(0,0);
			txbDisplay.Width=this.Width;
			lsvContext.Location=new Point(0,txbDisplay.Height);
			lsvContext.Size=new Size(this.Width,HeightListView);
		}

		private void TextBoxListView_Load(object sender, System.EventArgs e)
		{
			DisplayColumnsName();
		}

		private void lsvContext_ItemActivate(object sender, System.EventArgs e)
		{
			GetTextValue();
			HideListView();		
		}

		private void lsvContext_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
				GetTextValue();
				HideListView();	
			}
			this.OnKeyUp(e);
		}

		private void lsvContext_Leave(object sender, System.EventArgs e)
		{
			if(txbDisplay.Focused) return;
			GetTextValue();
			HideListView();
			this.OnLeave(e);
		}
		private void txbDisplay_DoubleClick(object sender, System.EventArgs e)
		{
			ShowListView();
			this.OnDoubleClick(e);
		}

		private void txbDisplay_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//索引功能
			Index(txbDisplay.Text);
			this.OnKeyUp(e);
		}
		private void txbDisplay_Leave(object sender, System.EventArgs e)
		{
			if(lsvContext.Focused) return;
			GetTextValue();
			HideListView();
			this.OnLeave(e);
		}

		private void txbDisplay_Enter(object sender, System.EventArgs e)
		{
			ShowListView();
			this.OnEnter(e);
		}

		private void lsvContext_VisibleChanged(object sender, System.EventArgs e)
		{
			if(lsvContext.Visible)
				this.Height=txbDisplay.Height + HeightListView;
			else
				this.Height =txbDisplay.Height;
		}
		#endregion

		#region 私有方法
		/// <summary>
		/// 确定索引	{1、按第一列索引；2、如果没有则按照第二列索引；}
		/// </summary>
		private void Index(string strInput)
		{
			if(txbDisplay.Text.Trim()=="")  return;
			lsvContext.SelectedItems.Clear();

			string strTem ="";
			int i;
			for(int i1=0;i1<lsvContext.Columns.Count;i1++)
			{
				if(IsIndex(i1))//判断本字段是否要索引
				{
					foreach(ListViewItem lsvItem in lsvContext.Items)
					{
						strTem =lsvItem.SubItems[i1].Text.ToLower();
						i =strTem.IndexOf(strInput.ToLower());
						if(i==0)
						{
							lsvItem.Selected =true;
							lsvContext.EnsureVisible(lsvItem.Index);
							break;
						}
					}
					if(lsvContext.SelectedItems.Count>0)
						break;
				}
			}			
		}
		/// <summary>
		/// 获取值
		/// </summary>
		private void GetTextValue()
		{
			if(lsvContext.SelectedItems.Count<=0) 
			{
				#region 
				//如果Text为空Value为空,则不处理.
				if(txbDisplay.Text.Trim()=="" && _value.Trim()=="")
				{
					return;
				}
				//如果Text为空Value不为空，则显示Value对应的Text，如果Value不存在清空Value
				if(txbDisplay.Text.Trim()=="" && _value.Trim()!="")
				{
					foreach(ListViewItem livItem in lsvContext.Items)
					{
						if(livItem.Tag.ToString().Trim().ToLower()==_value.Trim().ToLower())
						{
							livItem.Selected =true;
							txbDisplay.Text =livItem.SubItems[_textfieldindex].Text;
							break;
						}
					}
					if(txbDisplay.Text.Trim()=="")
						_value="";
				}
				//如果Text不为空Value为空，则清空Text
				if(txbDisplay.Text.Trim()!="" && _value.Trim()=="")
				{
					txbDisplay.Text ="";
					return;
				}
				//如果Text不为空Value不为空，则显示Value对应的Text，如果Value不存在则提示用户，根据用户的交互的信息决定是否清空Text
				if(txbDisplay.Text.Trim()!="" && _value.Trim()!="")
				{
					string strText =txbDisplay.Text.Trim();
					txbDisplay.Text ="";
					foreach(ListViewItem livItem in lsvContext.Items)
					{
						if(livItem.Tag.ToString().Trim().ToLower()==_value.Trim().ToLower())
						{
							livItem.Selected =true;
							txbDisplay.Text =livItem.SubItems[_textfieldindex-intPre()].Text;
							break;
						}
					}
					if(txbDisplay.Text.Trim()=="")
					{
						txbDisplay.Text =strText;
						if(MessageBox.Show(this.Parent,"显示信息的值不是有效的值,是否清空?\n建议从下拉框选择你要的数据","提示框!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
						{
							txbDisplay.Text ="";
							_value ="";
						}
					}
				}
				#endregion
			}
			else
			{
				txbDisplay.Text =lsvContext.SelectedItems[0].SubItems[_textfieldindex-intPre()].Text;				
				_value = lsvContext.SelectedItems[0].Tag.ToString();			
			}
		}
		/// <summary>
		/// 隐藏ListView
		/// </summary>
		private void HideListView()
		{
			lsvContext.Visible =false;
		}

		/// <summary>
		/// 显示ListView
		/// </summary>
		private void ShowListView()
		{
			lsvContext.Visible =true;
		}
		/// <summary>
		/// 获得字符串
		/// </summary>
		/// <param name="strSourceString">源字符串</param>
		/// <param name="strListSeparator">分割符</param>
		/// <param name="Index">要取第几个子字符串</param>
		/// <returns>子字符串	{没有要的,则返回为空串}</returns>
		private string GetStringBySplit(string strSourceString,string strListSeparator,int ItemIndex)
		{
			if(strSourceString.Trim()=="")
				return "";
			char [] delimiter = strListSeparator.ToCharArray();
			string [] strTem =strSourceString.Split(delimiter);
			if(strTem.Length <=ItemIndex)
				return "";
			return strTem[ItemIndex].Trim();
		}
		private bool IsIndex(int ItemIndex)
		{
			if(_indexfield.Trim()=="")
				return true;
			string [] strTem =_indexfield.Split(new char[]{','});
			for(int i1=0;i1<strTem.Length;i1++)
			{
				if(ItemIndex.ToString().Trim()==strTem[i1].Trim())
					return true;
			}
			return false;			
		}
		private int intPre()
		{
			if(_valuefieldindex<_textfieldindex && !_tagfieldvisible)
			{
				return 1;
			}
			return 0;
		}
		/// <summary>
		/// 显示列表头
		/// </summary>
		private void DisplayColumnsName()
		{
			if(this._columnsname.Trim()=="")
				return;
			string [] strTem =this._columnsname.Split(new char[] {','});

			string strColumnName="";			//列名
			int intColumnWidth =COLUMNWIDTH;	//列宽
			for(int i=0;i<strTem.Length;i++)
			{
				strColumnName =strTem[i];
				if(_columnswidth.Trim()=="")
					intColumnWidth =COLUMNWIDTH;
				else
				{
					try
					{
						intColumnWidth =Int32.Parse(GetStringBySplit(_columnswidth.Trim(),",",i));	//列宽
					}
					catch
					{
						intColumnWidth=COLUMNWIDTH;
					}
				}
				lsvContext.Columns.Add(strColumnName,intColumnWidth,HorizontalAlignment.Center);
			}		
		}
		#endregion
	}
}
