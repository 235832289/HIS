using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.digitalwave.Utility.Controls
{
	/// <summary>
	/// 模板内容编辑控件
	/// </summary>
	public class ctlTemplateEditer : RichTextBox
	{
		/// <summary>
		/// 选择项目组
		/// </summary>
		private class clsSelectInfoGroup
		{
			/// <summary>
			/// 选择项目
			/// </summary>
			private string[] m_strSelectInfoArr;
			/// <summary>
			/// 已经选择的项目
			/// </summary>
            private int m_intSelected;

			/// <summary>
			/// 没有选择过项目
			/// </summary>
			private const int c_intNotSelected = -1;

			/// <summary>
			/// 没有项目被选择
			/// </summary>
			private const int c_intNoSelectedItems = -2;

			/// <summary>
			/// 构造函数
			/// </summary>
			public clsSelectInfoGroup()
			{
				m_intSelected = c_intNotSelected;
				m_strSelectInfoArr = null;//必须先赋值，才能使用函数赋值				
			}

			/// <summary>
			/// 设置选择项目格式内容，返回界面显示内容。
			/// </summary>
			/// <param name="p_strSelectInfoFormat">选择项目格式内容。不包含{{}}符号</param>
			/// <returns>界面显示内容。</returns>
			public string m_strSetSelectInfoFormat(string p_strSelectInfoFormat)
			{
				string [] strContentArr = p_strSelectInfoFormat.Split(' ');
				System.Collections.ArrayList arlTemp = new System.Collections.ArrayList(strContentArr.Length);
				System.Text.StringBuilder sbdViewText = new System.Text.StringBuilder(p_strSelectInfoFormat.Length);;
				for(int i=0;i<strContentArr.Length;i++)
				{
					if(strContentArr[i].Trim() != "")
					{
						arlTemp.Add(strContentArr[i]);
						sbdViewText.Append(strContentArr[i]);
						sbdViewText.Append(' ');
					}
				}				

				m_strSelectInfoArr = (string[])arlTemp.ToArray(typeof(string));

				if(sbdViewText.Length == 0)
					return "";
				else
					return sbdViewText.ToString(0,sbdViewText.Length-1);
			}

			/// <summary>
			/// 是否已经选择过。如果选择过，返回true
			/// </summary>
			public bool m_blnIsSelected
			{
				get
				{
					return m_intSelected != c_intNotSelected;
				}
			}

			/// <summary>
			/// 选择的内容
			/// </summary>
			public string m_strSelectedInfo
			{
				get
				{
					if(m_intSelected < 0 || m_strSelectInfoArr == null || m_intSelected >= m_strSelectInfoArr.Length)
					{
						return "";
					}
					else
					{
						return m_strSelectInfoArr[m_intSelected];
					}
				}
			}

			/// <summary>
			/// 处理项目组选择。如果有内容被选择，返回true，否则返回false。
			/// </summary>
			/// <param name="p_intSelectIndex">选择的下标</param>
			/// <param name="p_intStartIndex">被选择项目的开始下标</param>
			/// <param name="p_intTextLength">被选择项目的内容长度</param>
			/// <param name="p_intUnslectedIndex">不被选择的下标</param>
			/// <param name="p_intUnselectedTextLength">不被选择项目的内容长度</param>
			/// <returns></returns>
			public bool m_blnHandleSelected(int p_intSelectIndex,out int p_intStartIndex,out int p_intTextLength,out int p_intUnslectedIndex,out int p_intUnselectedTextLength)
			{
				if(p_intSelectIndex < 0)
				{
					p_intStartIndex = -1;
					p_intTextLength = 0;
					p_intUnslectedIndex = -1;
					p_intUnselectedTextLength = 0;
					return false;
				}

				int intStartIndex = 0;
				int intEndIndex = m_strSelectInfoArr[0].Length-1;

				if(p_intSelectIndex >= intStartIndex && p_intSelectIndex <= intEndIndex)
				{
					m_mthHandleInfoSelect(0,intStartIndex,out p_intStartIndex,out p_intTextLength,out p_intUnslectedIndex,out p_intUnselectedTextLength);
					return true;
				}
				else
				{
					for(int i=1;i<m_strSelectInfoArr.Length;i++)
					{
						intStartIndex += m_strSelectInfoArr[i-1].Length+1;//加一个空格
						intEndIndex = intStartIndex+m_strSelectInfoArr[i].Length-1;
						if(p_intSelectIndex >= intStartIndex && p_intSelectIndex <= intEndIndex)
						{
							m_mthHandleInfoSelect(i,intStartIndex,out p_intStartIndex,out p_intTextLength,out p_intUnslectedIndex,out p_intUnselectedTextLength);
							return true;
						}
					}
				}

				p_intStartIndex = -1;
				p_intTextLength = 0;
				p_intUnslectedIndex = -1;
				p_intUnselectedTextLength = 0;
				return false;
			}		
			/// <summary>
			/// 处理选项被选择
			/// </summary>
			/// <param name="p_intInfoIndex">选项在选项组里的下标</param>
			/// <param name="p_intStartIndex">选项内容的开始下标</param>
			/// <param name="p_intUnslectedIndex">不被选择的下标</param>
			/// <param name="p_intUnselectedTextLength">不被选择项目的内容长度</param>
			private void m_mthHandleInfoSelect(int p_intInfoIndex,int p_intStartIndex,out int p_intStartIndex_Out,out int p_intTextLength,out int p_intUnslectedIndex,out int p_intUnselectedTextLength)
			{
				p_intStartIndex_Out = p_intStartIndex;
				if(m_intSelected == c_intNotSelected)
				{
					//原来没有选择过
					p_intTextLength = m_strSelectInfoArr[p_intInfoIndex].Length;
					m_intSelected = p_intInfoIndex;

					p_intUnslectedIndex = 0;
					p_intUnselectedTextLength = 0;
					for(int i=0;i<m_strSelectInfoArr.Length;i++)
					{
						p_intUnselectedTextLength += m_strSelectInfoArr[i].Length+1;//加一个空格
					}
					p_intUnselectedTextLength -= 1;
				}
				else
				{
					//不选择之前的内容
					if(m_intSelected != c_intNoSelectedItems)
					{
						p_intUnslectedIndex = 0;
						for(int i=0;i<m_intSelected;i++)
						{
							p_intUnslectedIndex += m_strSelectInfoArr[i].Length+1;//加一个空格
						}
						p_intUnselectedTextLength = m_strSelectInfoArr[m_intSelected].Length;
					}
					else
					{
						p_intUnslectedIndex = 0;
						p_intUnselectedTextLength = 0;
					}

					//设置选择的内容
					if(m_intSelected != p_intInfoIndex)
					{
						p_intTextLength = m_strSelectInfoArr[p_intInfoIndex].Length;
						m_intSelected = p_intInfoIndex;
					}
					else
					{
						p_intTextLength = 0;
						m_intSelected = c_intNoSelectedItems;
					}
				}
			}

			/// <summary>
			/// 判断是否同一个选择内容
			/// </summary>
			/// <param name="p_objOther"></param>
			/// <returns></returns>
			public bool m_blnIsSameInfo(clsSelectInfoGroup p_objOther)
			{
				if(this.m_strSelectInfoArr.Length == p_objOther.m_strSelectInfoArr.Length)
				{
					for(int i=0;i<this.m_strSelectInfoArr.Length;i++)
					{
						if(this.m_strSelectInfoArr[i] != p_objOther.m_strSelectInfoArr[i])
							return false;
					}
					//如果相同设置相同的选择项目
					this.m_intSelected = p_objOther.m_intSelected;
					return true;;
				}

				return false;
			}
		}		


		/// <summary>
		/// 选择项目组信息
		/// </summary>
		private class clsGroupInfo
		{
			public clsSelectInfoGroup m_objGroup;

			/// <summary>
			/// 项目组内容开始下标
			/// </summary>
			public int m_intStartIndex;

			/// <summary>
			/// 项目组内容结束下标
			/// </summary>
			public int m_intEndIndex;
		}

		/// <summary>
		/// 全部的选择项目组信息
		/// </summary>
		private clsGroupInfo[] m_objGroupInfosArr;

		public ctlTemplateEditer()
		{
			InitializeComponent();

			this.Cursor = Cursors.Arrow;
			this.ReadOnly = true;		
			this.SelectionBullet = false;
		}

		/// <summary>
		/// 设置模板内容
		/// </summary>
		/// <param name="p_strTemplateText">模板内容</param>
		public void m_mthSetTemplateText(string p_strTemplateText)
		{
			p_strTemplateText=p_strTemplateText.Replace("\r\n","\n");
			if(p_strTemplateText.Length == 0)
			{
				this.Text = "";
				return;
			}

			int intIndex = 0;

			int intPreIndex = intIndex;			

			bool blnIsStart = true;

			System.Collections.ArrayList arlTemp = new System.Collections.ArrayList();
			System.Text.StringBuilder sbdTempText = new System.Text.StringBuilder(p_strTemplateText.Length);

			while(intIndex >= 0)
			{				
				string strCurrentSymbol = blnIsStart?"{{":"}}";
				
				intIndex = p_strTemplateText.IndexOf(strCurrentSymbol,intIndex);

				if(intIndex >= 0)
				{
					if(!blnIsStart)
					{
						//找到匹配的结束符
						clsGroupInfo objGroup = new clsGroupInfo();
						objGroup.m_objGroup = new clsSelectInfoGroup();
						objGroup.m_intStartIndex = sbdTempText.Length;
						sbdTempText.Append(objGroup.m_objGroup.m_strSetSelectInfoFormat(p_strTemplateText.Substring(intPreIndex,intIndex-intPreIndex)));
						objGroup.m_intEndIndex = sbdTempText.Length-1;
						
						arlTemp.Add(objGroup);

						intPreIndex = intIndex+2;
						blnIsStart = true;
					}
					else
					{
						//找到开始符
						//添加开始符到前一个Index的内容
						sbdTempText.Append(p_strTemplateText.Substring(intPreIndex,intIndex-intPreIndex));

						intPreIndex = intIndex+2;
						blnIsStart = false;
					}
				}				
			}	
		
			if(intPreIndex < p_strTemplateText.Length)
			{
				sbdTempText.Append(p_strTemplateText.Substring(intPreIndex));
			}

			m_objGroupInfosArr = (clsGroupInfo[])arlTemp.ToArray(typeof(clsGroupInfo));
			this.Text = "";
			this.SelectionColor = m_clrNormalText;
			this.Text = sbdTempText.ToString();

			m_mthSetNeedSelectedColor();
		}

		private void InitializeComponent()
		{
			this.m_ctmCopy = new System.Windows.Forms.ContextMenu();
			this.m_ctmCopy.MenuItems.Add("复制",new EventHandler(Copy_Click));
			this.ContextMenu = this.m_ctmCopy;
		}

		/// <summary>
		/// 需要选择的文本颜色
		/// </summary>
		private Color m_clrNeedSelected = Color.Red;
		/// <summary>
		/// 需要选择的文本颜色
		/// </summary>
		public Color m_ClrNeedSelected
		{
			get
			{
				return m_clrNeedSelected;
			}
			set
			{
				m_clrNeedSelected = value;
			}
		}
		/// <summary>
		/// 选择的文本颜色
		/// </summary>
		private Color m_clrSelected = Color.Blue;
		/// <summary>
		/// 选择的文本颜色
		/// </summary>
		public Color m_ClrSelected
		{
			get
			{
				return m_clrSelected;
			}
			set
			{
				m_clrSelected = value;
			}
		}
		/// <summary>
		/// 不选择的文本颜色
		/// </summary>
		private Color m_clrUnselected = Color.Gray;
		private System.Windows.Forms.ContextMenu m_ctmCopy;
		/// <summary>
		/// 不选择的文本颜色
		/// </summary>
		public Color m_ClrUnselected
		{
			get
			{
				return m_clrUnselected;
			}
			set
			{
				m_clrUnselected = value;
			}
		}
		/// <summary>
		/// 普通的文本颜色
		/// </summary>
		private Color m_clrNormalText = Color.Black;
		/// <summary>
		/// 普通的文本颜色
		/// </summary>
		public Color m_ClrNormalText
		{
			get
			{
				return m_clrNormalText;
			}
			set
			{
				m_clrNormalText = value;
			}
		}
		/// <summary>
		/// 设置需要选择的颜色
		/// </summary>
		private void m_mthSetNeedSelectedColor()
		{
			for(int i=0;i<m_objGroupInfosArr.Length;i++)
			{
				this.SelectionStart = m_objGroupInfosArr[i].m_intStartIndex;
				this.SelectionLength = m_objGroupInfosArr[i].m_intEndIndex - m_objGroupInfosArr[i].m_intStartIndex+1;
				this.SelectionColor = m_clrNeedSelected;
			}
		}

		/// <summary>
		/// 是否已经选择过
		/// </summary>
		public bool m_BlnIsSelected
		{
			get
			{
				if(m_objGroupInfosArr == null)
					return false;
				else
				{
					for(int i=0;i<m_objGroupInfosArr.Length;i++)
					{
						if(!m_objGroupInfosArr[i].m_objGroup.m_blnIsSelected)
							return false;
					}

					return true;
				}				
			}
		}

		/// <summary>
		/// 编辑内容
		/// </summary>
		public string m_StrEditedText
		{
			get
			{
				System.Text.StringBuilder sbdEditedText = new System.Text.StringBuilder(this.Text.Length);

				int intNormalStart = 0;

				for(int i=0;i<m_objGroupInfosArr.Length;i++)
				{
					if(intNormalStart < m_objGroupInfosArr[i].m_intStartIndex)
					{
						//选择项目前有普通模板内容
						sbdEditedText.Append(this.Text.Substring(intNormalStart,m_objGroupInfosArr[i].m_intStartIndex-intNormalStart));
					}

					sbdEditedText.Append(m_objGroupInfosArr[i].m_objGroup.m_strSelectedInfo);

					intNormalStart = m_objGroupInfosArr[i].m_intEndIndex+1;
				}

				if(intNormalStart < this.Text.Length)
				{
					sbdEditedText.Append(this.Text.Substring(intNormalStart,this.Text.Length-intNormalStart));
				}

				sbdEditedText.Replace("\n","\r\n");
				return sbdEditedText.ToString();
			}
		}
		
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			//处理点击
			if(m_objGroupInfosArr == null)
				return;

			int intOnIndex = this.GetCharIndexFromPosition(new Point(e.X,e.Y));

			int intStartIndex = 0;
			int intLength = 0;
			int intUnselectedStartIndex = 0;
			int intUnselectedLength = 0;
			clsSelectInfoGroup objSelectedGroup = null;

			for(int i=0;i<m_objGroupInfosArr.Length;i++)
			{
				if(intOnIndex >= m_objGroupInfosArr[i].m_intStartIndex && intOnIndex <= m_objGroupInfosArr[i].m_intEndIndex)
				{					
					if(m_objGroupInfosArr[i].m_objGroup.m_blnHandleSelected(intOnIndex-m_objGroupInfosArr[i].m_intStartIndex,out intStartIndex,out intLength,out intUnselectedStartIndex,out intUnselectedLength))
					{
						objSelectedGroup = m_objGroupInfosArr[i].m_objGroup;						
					}		
					break;
				}
			}	
	        
			if(objSelectedGroup != null)
			{
				//把所有相同的项目做相同的选择
				for(int i=0;i<m_objGroupInfosArr.Length;i++)
				{
					if(m_objGroupInfosArr[i].m_objGroup.m_blnIsSameInfo(objSelectedGroup))
					{
						this.SelectionStart = m_objGroupInfosArr[i].m_intStartIndex+intUnselectedStartIndex;
						this.SelectionLength = intUnselectedLength;
						this.SelectionColor = m_clrUnselected;

						this.SelectionStart = m_objGroupInfosArr[i].m_intStartIndex+intStartIndex;
						this.SelectionLength = intLength;
						this.SelectionColor = m_clrSelected;

						this.SelectionLength = 0;

					}
				}

				this.SelectionStart = intOnIndex;
			}
		}

		private void Copy_Click(object sender,EventArgs e)
		{
			this.Copy();
		}

	}
}
