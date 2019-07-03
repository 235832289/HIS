using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// TextBoxListView �ؼ���
	/// ���ߣ� ����
	/// ����޸�ʱ�䣺 2004-09-24
	/// </summary>
	[DefaultProperty("Text")]
	public class TextBoxListView : System.Windows.Forms.UserControl
	{
		#region �ؼ�-��������
		public System.Windows.Forms.ListView lsvContext;
		public System.Windows.Forms.TextBox txbDisplay;
		/// <summary> 
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		//ListView��tag���� [_text��Ӧ��tag]
		private string _value ="";
		private int _textfieldindex =1;		//Text���ֶ�����,��0��ʼ��.		��ʾ���ı�����
		private int _valuefieldindex =0;	//Value���ֶ�����,��0��ʼ��.	����Tag������
		private bool _tagfieldvisible =true;//Tag��Ӧ���ֶ��Ƿ���ʾ��ListView��
		private DataTable _datatable =null;	//������Դ
		private string _columnsname ="";	//ListView���б�Text���ԣ��á�,���ŷָ{ע�⣺1��û�е���Ĭ����ʾ�ֶΣ�2�����ص��ֶ�Ҳ�㣻}
		private string _columnswidth ="";	//ListView���б�Text���ԣ��á�,���ŷָ{ע�⣺1��û�е���Ĭ��Ϊ80��2�����ص��ֶ�Ҳ�㣻}
		private string _indexfield ="";		//ȷ�������ֶ�,�á�,���ŷָ{ע�⣺1��Ϊ�յ���Ĭ�������ֶΣ�2��С��0��������3�����ص��ֶβ��㣻}
		const int COLUMNWIDTH =80;			//Ĭ�ϵ��п�ֵ.
		#endregion

		#region ���캯��
		public TextBoxListView()
		{
			// �õ����� Windows.Forms ���������������ġ�
			InitializeComponent();

			// TODO: �� InitializeComponent ���ú�����κγ�ʼ��		
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
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

		#region �����������ɵĴ���
		/// <summary> 
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭�� 
		/// �޸Ĵ˷��������ݡ�
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
			this.Font = new System.Drawing.Font("����", 12F);
			this.Name = "TextBoxListView";
			this.Size = new System.Drawing.Size(160, 176);
			this.Resize += new System.EventHandler(this.TextBoxListView_Resize);
			this.Load += new System.EventHandler(this.TextBoxListView_Load);
			this.ResumeLayout(false);

		}
		#endregion		

		#region ����
		/// <summary>
		/// ��ȡ�����ÿؼ���Value
		/// </summary>
		[Category("���"),Description("��ȡ�����ÿؼ���Value.")]
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
		/// ��ȡ�����ÿؼ���Text
		/// </summary>
		[Category("���"),Description("��ȡ�����ÿؼ���Text.")]
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
		/// ��ȡ������ListView�ĸ߶�
		/// </summary>
		[Category("���"),DefaultValue(100),Description("��ȡ������ListView�ĸ߶�.")]
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
		/// Text���ֶ�����,��0��ʼ��.
		/// </summary>
		[Category("��Ϊ"),DefaultValue(1),Description("Text���ֶ�����,��0��ʼ��..")]
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
		/// Value���ֶ�����,��0��ʼ��.
		/// </summary>
		[Category("��Ϊ"),DefaultValue(0),Description("Value���ֶ�����,��0��ʼ��..")]
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
		/// Tag��Ӧ���ֶ��Ƿ���ʾ��ListView��
		/// </summary>
		[Category("��Ϊ"),DefaultValue(true),Description("Tag��Ӧ���ֶ��Ƿ���ʾ��ListView��")]
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
		/// �󶨵�����Դ
		/// </summary>
		[Category("����"),Description("�󶨵�����Դ")]
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
		/// ���б�ͷ��ֵ.
		/// ListView���б�Text���ԣ��á�,���ŷָ{ע�⣺1��û�е���Ĭ����ʾ�ֶΣ�2�����ص��ֶ�Ҳ�㣻}
		/// </summary>
		[Category("��Ϊ"),DefaultValue(""),Description("�б�ͷ�ı����á�,���ŷָ\n{ע�⣺1��û�е���Ĭ����ʾ�ֶΣ�2�����ص��ֶ�Ҳ�㣻}\n���磺���,����,�Ա�")]
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
		/// �ƶ��б�Ŀ��
		/// ListView���б�Text���ԣ��á�,���ŷָ{ע�⣺1��û�е���Ĭ��Ϊ80��2�����ص��ֶ�Ҳ�㣻}
		/// </summary>
		[Category("��Ϊ"),DefaultValue(""),Description("�б�ͷ�Ŀ��á�,���ŷָ\n{ע�⣺1��û�е���Ĭ��Ϊ80��2�����ص��ֶ�Ҳ�㣻}\n���磺40,120,60")]
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
		/// ȷ�������ֶ�
		/// ȷ�������ֶ�,�á�,���ŷָ{ע�⣺1��Ϊ�յ���Ĭ�������ֶΣ�2��С��0��������3�����ص��ֶ�Ҳ�㣻}
		/// </summary>
		[Category("��Ϊ"),DefaultValue(""),Description("ȷ�������ֶ�,�á�,���ŷָ\n{ע�⣺1��Ϊ�յ���Ĭ�������ֶΣ�2��С��0��������3�����ص��ֶβ��㣻}\n���磺1,2,3 ")]
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

		#region ����
		/// <summary>
		/// ������
		/// </summary>
		public void BindData()
		{	
			lsvContext.Columns.Clear();	
			lsvContext.Items.Clear();	
			if(_datatable==null || _datatable.Rows.Count <=0)
			{
				//��ʾ����
				DisplayColumnsName();
				return ;
			}
			lsvContext.HideSelection =false;

			ListViewItem lsvItem =null;
			string strColumnName="";			//����
			int intColumnWidth =COLUMNWIDTH;	//�п�
			for(int iRow=0;iRow<_datatable.Rows.Count;iRow++)
			{
				lsvItem =null;
				for(int iCol=0;iCol<_datatable.Columns.Count;iCol++)
				{
					#region ���б�ͷ
					//�������	
					if(iRow==0)
					{
						if(iCol!=_valuefieldindex || _tagfieldvisible)
						{
							//����
							if(_columnsname.Trim()=="")
								strColumnName ="";
							else
								strColumnName =GetStringBySplit(_columnsname.Trim(),",",iCol);
							if(strColumnName.Trim()=="")
							{
								strColumnName =_datatable.Columns[iCol].ColumnName;
							}

							//�п�
							if(_columnswidth.Trim()=="")
								intColumnWidth =COLUMNWIDTH;
							else
							{
								try
								{
									intColumnWidth =Int32.Parse(GetStringBySplit(_columnswidth.Trim(),",",iCol));	//�п�
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

					#region ���б���
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
				#region ��Tag��ֵ {��֤���ֶα�����ֵ}
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

		#region �¼�
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
			//��������
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

		#region ˽�з���
		/// <summary>
		/// ȷ������	{1������һ��������2�����û�����յڶ���������}
		/// </summary>
		private void Index(string strInput)
		{
			if(txbDisplay.Text.Trim()=="")  return;
			lsvContext.SelectedItems.Clear();

			string strTem ="";
			int i;
			for(int i1=0;i1<lsvContext.Columns.Count;i1++)
			{
				if(IsIndex(i1))//�жϱ��ֶ��Ƿ�Ҫ����
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
		/// ��ȡֵ
		/// </summary>
		private void GetTextValue()
		{
			if(lsvContext.SelectedItems.Count<=0) 
			{
				#region 
				//���TextΪ��ValueΪ��,�򲻴���.
				if(txbDisplay.Text.Trim()=="" && _value.Trim()=="")
				{
					return;
				}
				//���TextΪ��Value��Ϊ�գ�����ʾValue��Ӧ��Text�����Value���������Value
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
				//���Text��Ϊ��ValueΪ�գ������Text
				if(txbDisplay.Text.Trim()!="" && _value.Trim()=="")
				{
					txbDisplay.Text ="";
					return;
				}
				//���Text��Ϊ��Value��Ϊ�գ�����ʾValue��Ӧ��Text�����Value����������ʾ�û��������û��Ľ�������Ϣ�����Ƿ����Text
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
						if(MessageBox.Show(this.Parent,"��ʾ��Ϣ��ֵ������Ч��ֵ,�Ƿ����?\n�����������ѡ����Ҫ������","��ʾ��!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
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
		/// ����ListView
		/// </summary>
		private void HideListView()
		{
			lsvContext.Visible =false;
		}

		/// <summary>
		/// ��ʾListView
		/// </summary>
		private void ShowListView()
		{
			lsvContext.Visible =true;
		}
		/// <summary>
		/// ����ַ���
		/// </summary>
		/// <param name="strSourceString">Դ�ַ���</param>
		/// <param name="strListSeparator">�ָ��</param>
		/// <param name="Index">Ҫȡ�ڼ������ַ���</param>
		/// <returns>���ַ���	{û��Ҫ��,�򷵻�Ϊ�մ�}</returns>
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
		/// ��ʾ�б�ͷ
		/// </summary>
		private void DisplayColumnsName()
		{
			if(this._columnsname.Trim()=="")
				return;
			string [] strTem =this._columnsname.Split(new char[] {','});

			string strColumnName="";			//����
			int intColumnWidth =COLUMNWIDTH;	//�п�
			for(int i=0;i<strTem.Length;i++)
			{
				strColumnName =strTem[i];
				if(_columnswidth.Trim()=="")
					intColumnWidth =COLUMNWIDTH;
				else
				{
					try
					{
						intColumnWidth =Int32.Parse(GetStringBySplit(_columnswidth.Trim(),",",i));	//�п�
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
