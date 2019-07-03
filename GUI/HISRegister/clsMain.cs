using System;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsMain：处理类 Create by Sam 2004-5-24
	/// </summary>
	public class clsMain
	{
		public clsMain()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static void Tips(string Values)
		{
			MessageBox.Show(Values,"提示");
		}
		#region 调用警告窗体
		public void m_mthShowWarning(exDataGridSour.exComboBox txtBox,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(TextBox txtBox,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
            ShowWarning.TopMost = false;
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			//ShowWarning.Show();
            m_mthShowForm(ShowWarning);
		}
		public void m_mthShowWarning(com.digitalwave.iCare.gui.HIS.exComboBox txtBox,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning( SourceLibrary.Windows.Forms.TextBoxTypedNumeric txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(com.digitalwave.controls.ctlTextBoxFind txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(System.Windows.Forms.Panel txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-0,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(System.Windows.Forms.GroupBox txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-0,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(System.Windows.Forms.ComboBox txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(System.Windows.Forms.ListView txtBox ,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.X+=(txtBox.Width/2);
			p.Y+=(txtBox.Height/2);
			ShowWarning.Location=p;
			ShowWarning.Show();
		}
		public void m_mthShowWarning(com.digitalwave.controls.datagrid.ctlDataGrid txtBox,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.X+=(txtBox.Width/2);
			p.Y+=(txtBox.Height/2);
			ShowWarning.Location=p;
			ShowWarning.Show();
		}

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary>
        /// 窗口最前端打开,但并不获得焦点
        /// 注:窗体的TopMost属性必须为false
        /// kenny add in 2008.08.13
        /// </summary>
        /// <param name="form"></param>
        public static void m_mthShowForm(Form form)
        {
            SetWindowPos(form.Handle, new IntPtr(-1), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0040 | 0x0010);
        }
		#endregion
		#region 获取新新的发票号
		/// <summary>
		/// 获取新新的发票号
		/// </summary>
		/// <param name="oldCheckNO">前一张发票号</param>
		/// <returns></returns>
		public static string  m_mthGetNewCheckNO(string oldCheckNO)
		{
			string strNewDocument="";
			Encoding ascii=Encoding.ASCII;
			Byte[] byCoding= ascii.GetBytes(oldCheckNO);
			int intEnLengt=-1;
			for(int i1=0;i1<byCoding.Length;i1++)
			{
				if((int)byCoding[i1]<=57)
				{
					intEnLengt=i1-1;
					break;
				}
			}
			if(intEnLengt>-1)
			{
				string strEN=oldCheckNO.Substring(0,intEnLengt+1);
				string strNumber=oldCheckNO.Substring(intEnLengt+1);
				long  intNumber=0;
				try
				{
					strNumber="1"+strNumber;
					intNumber=Convert.ToInt64(strNumber)+1;
					strNumber=intNumber.ToString().Substring(1,strNumber.Length-1);
					strNewDocument=strEN+strNumber;
				}
				catch
				{
					strNewDocument=strEN;
				}
			}
			else
			{
				
				try
				{
					string strOldCheckNo="1"+oldCheckNO;
					long n=Convert.ToInt64(strOldCheckNo)+1;
					string strNewCheckNo=n.ToString().Substring(1,strOldCheckNo.Length-1);
					strNewDocument=strNewCheckNo;
				}
				catch
				{
				}
			}
			return strNewDocument;
		}

		#endregion
		#region 把数字转换成中文大写
		private static string[] cstr={"零","壹","贰","叁","肆", "伍", "陆","柒","捌","玖"};
		private  static string[] wstr={"分","角","圆","拾","佰","仟","万","拾","佰","仟","亿","拾","佰","仟"};
		public static string CurrencyToString(float fltCurrency)
		{
			string str=fltCurrency.ToString("0.00");
			str=str.Replace(".","");
			int len=str.Length;
			int i;
			string tmpstr,rstr;
			rstr="";
			for(i=1;i<=len;i++)
			{
				tmpstr=str.Substring(len-i,1);
				rstr=string.Concat(cstr[Int32.Parse(tmpstr)]+wstr[i-1],rstr);
			}
			rstr=rstr.Replace("拾零","拾");
			rstr=rstr.Replace("零拾","零");
			rstr=rstr.Replace("零佰","零");
			rstr=rstr.Replace("零仟","零");
			rstr=rstr.Replace("零万","万");
			for(i=1;i<=6;i++)
				rstr=rstr.Replace("零零","零");
			rstr=rstr.Replace("零万","零");
			rstr=rstr.Replace("零亿","億");
			rstr=rstr.Replace("零零","零");
			rstr=rstr.Replace("零角零分","");
			rstr=rstr.Replace("零分","");
			rstr+="整"; 
			rstr=rstr.Replace("分整","分");
			return rstr;
		}

        public static string CurrencyToString2(double fltCurrency)
        {
            int num2;
            string str = fltCurrency.ToString("0.00").Replace(".", "");
            int length = str.Length;
            string str3 = "";
            for (num2 = 1; num2 <= length; num2++)
            {
                string s = str.Substring(length - num2, 1);
                str3 = cstr[int.Parse(s)] + wstr[num2 - 1] + str3;
            }
            str3 = str3.Replace("拾零", "拾").Replace("零拾", "零").Replace("零佰", "零").Replace("零仟", "零").Replace("零万", "万");
            for (num2 = 1; num2 <= 6; num2++)
            {
                str3 = str3.Replace("零零", "零");
            }
            return (str3.Replace("零万", "零").Replace("零亿", "億").Replace("零零", "零").Replace("零角零分", "").Replace("零分", "") + "整").Replace("分整", "分");
        } 

		#endregion

		#region 把数据按某一个字段来分组

		public static void m_Detach(DataTable dt ,string fieldName,out ArrayList arrList)
		{
			arrList=new ArrayList();
			DataView myDataView = dt.DefaultView;
			myDataView.Sort = fieldName+" ASC";
			if(dt.Rows.Count==0)
				return;
			Encoding ascii=Encoding.ASCII;
			Byte[] byCoding= ascii.GetBytes(myDataView[0][fieldName].ToString());
			int intEnLengt=-1;
			for(int i1=0;i1<byCoding.Length;i1++)
			{
				if((int)byCoding[i1]<=57)
				{
					intEnLengt=i1-1;
					break;
				}
			}
			string strEng="";
			string strCount="";
			string strEng1="";
			string strCount1="";
			if(intEnLengt==-1)
			{
				arrList.Add(myDataView[0][fieldName].ToString());
				for(int i1=1;i1<myDataView.Count;i1++)
				{
					try
					{
						if(Convert.ToInt32(myDataView[i1-1][fieldName].ToString())==Convert.ToInt32(myDataView[i1][fieldName].ToString()))
						{
							continue;
						}
						if(Convert.ToInt32(myDataView[i1-1][fieldName].ToString())+1==Convert.ToInt32(myDataView[i1][fieldName].ToString()))
						{
							arrList.Add(myDataView[i1][fieldName].ToString());
						}
						else
						{
							arrList.Add(",");
							arrList.Add(myDataView[i1][fieldName].ToString());
						}
					}
					catch
					{
					}
				}
			}
			else
			{
				arrList.Add(myDataView[0][fieldName].ToString());
				for(int i1=1;i1<myDataView.Count;i1++)
				{
					try
					{
						strEng=myDataView[i1-1][fieldName].ToString().Substring(0,intEnLengt+1);
						strCount=myDataView[i1-1][fieldName].ToString().Substring(intEnLengt+1);
						strEng1=myDataView[i1][fieldName].ToString().Substring(0,intEnLengt+1);
						strCount1=myDataView[i1][fieldName].ToString().Substring(intEnLengt+1);
						if(strEng==strEng1&&Convert.ToInt32(strCount)==Convert.ToInt32(strCount1))
						{
							continue;
						}
						if(strEng==strEng1&&Convert.ToInt32(strCount)+1==Convert.ToInt32(strCount1))
						{
							arrList.Add(myDataView[i1][fieldName].ToString());
						}
						else
						{
							arrList.Add(",");
							arrList.Add(myDataView[i1][fieldName].ToString());
						}
					}
					catch
					{
					}
				}

			}
		}
		#endregion

		#region 检查用户输入数据的类型
		/// <summary>
		/// 检查用户输入数据的类型
		/// </summary>
		/// <param name="strVal">1-数字，2-中文，3-英文，4-英文夹杂中文或中文夹杂英文字符</param>
		/// <returns></returns>
		public static int  IsEngOrNumOrChina(string strVal)
		{
			//转换包含中文的字符串
			if(IsNumber(strVal))
				return 1;//数字
			Byte[] byteArr = null;
			try
			{
				byteArr = System.Text.Encoding.GetEncoding("GB2312").GetBytes(strVal);
			}
			catch{}
			if(byteArr.Length%2==0&&strVal.Length==byteArr.Length)
			{
				return 3;//英文或英文夹杂数字
			}
			if(byteArr.Length%2==0)
			{
				return 2;//中文
			}
			else if(strVal.Length==byteArr.Length)
			{
				return 3;//英文或英文夹杂数字
			}
			else
			{
				return 4;//英文夹杂中文或中文夹杂英文字符
			}
		}
		#endregion

		#region 查找listView中的项目
		/// <summary>
		/// 查找listView中的项目
		/// </summary>
		/// <param name="lvwItem"></param>
		/// <param name="findType">1-从助记码中查找（任何类型的字符），2-从代码中查找（数字），3-中文名称查找（中文），4-拼音码和五笔码查找（英文）</param>
		/// <param name="MatchCol">从listView中的第几列开始查找</param>
		/// <param name="strValues"></param>
		/// <param name="isCode">标识助记码在listView中是否存在并标识所在的列号,-1-不存在</param>
		/// <returns></returns>
		public static int FindItemByValues(ListView lvwItem,int findType,int MatchCol,int isCode,string strValues)
		{
			if(isCode!=-1)
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[isCode].Text.IndexOf(strValues)==0)
						return i1;
				}
			}
			if(findType == 2)//从代码中查找
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[MatchCol].Text.IndexOf(strValues)==0)
						return i1;
				}
			}
			if(findType == 3)//中文名称查找
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[MatchCol].Text.IndexOf(strValues)==0)
						return i1;
				}
			}
			if(findType == 4)//拼音码和五笔码查找
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[MatchCol].Text.IndexOf(strValues.ToUpper())==0||lvwItem.Items[i1].SubItems[MatchCol+1].Text.IndexOf(strValues.ToUpper())==0)
						return i1;
				}
			}
			return -1;
		}
		#endregion

		#region 获取配置信息
		/// <summary>
		/// 获取配置信息
		/// </summary>
		/// <param name="strsetid">配置ID号</param>
		/// <returns>当配置 0--否 1--是时，false 否，true 是；当配置 1--否 0--是时，false 是，true 否</returns>
		public static bool m_blGetCollocate(string strsetid)
		{
			bool isTrue;
			clsDomainControl_Register domain=new clsDomainControl_Register();
			domain.m_lngGetCollocate(out isTrue,strsetid);
			return isTrue;
		}

        /// <summary>
        /// 获取配置信息
        /// by huafeng.xiao
        /// 2009年9月15日9:31:13
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strStatus">返回状态，适合多状态开关使用</param>
        /// <param name="strsetid">配置ID号</param>
        /// <returns></returns>
        public static string m_strGetCollocate(string strsetid)
        {
            string m_strStatus = string.Empty;
            clsDomainControl_Register domain = new clsDomainControl_Register();
            domain.m_lngGetCollocateStatus(out m_strStatus, strsetid);
            return m_strStatus;
        }

		#endregion

		/// <summary>
		/// 重定义数组
		/// </summary>
		/// <param name="newELementCount"></param>
		/// <param name="originalArray"></param>
		/// <returns></returns>
		public static object[] redefineArray(int newELementCount, object[] originalArray)
		{
			object[] temp = new object[newELementCount];
			if (newELementCount >= originalArray.Length)
			{
				for(int i = 0; i < originalArray.Length; i ++)
				{
					temp[i] = originalArray[i];
				}
			}
			else
			{
				for(int i = 0; i < temp.Length; i ++)
				{
					temp[i] = originalArray[i];
				}
			}
			return temp;
		}
		/// <summary>
		/// 查找listView中的项目
		/// </summary>
		/// <param name="lvwItem"></param>
		/// <param name="MatchCol"></param>
		/// <param name="strValues"></param>
		/// <returns></returns>
		public static int FindItemByValues(ListView lvwItem,int MatchCol,string strValues)
		{
			if(MatchCol == 2)
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[MatchCol-1].Text.IndexOf(strValues)==0
						|| lvwItem.Items[i1].SubItems[MatchCol].Text.IndexOf(strValues.ToUpper())==0)
						return i1;
				}
			}
			else
			{
				for(int i1=0;i1<lvwItem.Items.Count;i1++)
				{
					if(lvwItem.Items[i1].SubItems[MatchCol].Text.IndexOf(strValues)==0)
						return i1;
				}
			}
			return -1;
		}
		public static int FindItemByValues(DataGrid dg,int MatchCol,string strValues)
		{
			
			
			for(int i1=0;i1<dg.VisibleRowCount;i1++)
			{
				if(dg[i1,MatchCol].ToString().Trim()==strValues)
					return i1;
			}    
			return -1;
		}
		/// <summary>
		/// 把null转换成""
		/// </summary>
		/// <param name="strValues"></param>
		/// <param name="IsZero"></param>
		/// <returns></returns>
		public static string IsNullToString(string strValues,string IsZero)
		{
			if(strValues==null)
			{
				if(IsZero!=null)
					return IsZero;
				else
					return "";
			}
			else
			{
				strValues=ReplaceTo(strValues);
				if(strValues!="")
					return strValues;
				else
				{
					if(IsZero!=null)
						return IsZero;
					else
						return strValues;
				}
			}
		}
		/// <summary>
		/// 去除空格和单引号
		/// </summary>
		/// <param name="strValues"></param>
		/// <returns></returns>
		public static string ReplaceTo(string strValues)
		{
			strValues=strValues.Trim();
			strValues=strValues.Replace(" ","");
			strValues=strValues.Replace("'","");
			return strValues;
		}
		/// <summary>
		/// 只能输入数字strTxt不为空时可输入小数点
		/// </summary>
		/// <param name="KeyChar"></param>
		/// <param name="strTxt"></param>
		/// <returns></returns>
		public static bool ValNumer(char KeyChar,string strTxt)
		{
			if(KeyChar==(char)8) //删除键
				return true;
			if(strTxt==null)//只能输入数字
			{
				return char.IsDigit(KeyChar);
			}
			else
			{
				if(char.IsDigit(KeyChar))
					return true;
				else
				{
					if(KeyChar=='.') //如果是小数点
					{
						if(strTxt.IndexOf(".")>=0) //如果已经有小数点
							return false;
						else
							return true;
					}
					else //不是数字也不是小数点
						return false;
				}
			}
		}
		/// <summary>
		/// 是数字
		/// </summary>
		/// <param name="strVal"></param>
		/// <returns></returns>
		public static bool IsNumber(string strVal)
		{
			if(strVal==null)
				return false;
			strVal=ReplaceTo(strVal);
			if(strVal=="")
				return false;
			for(int i=0;i<strVal.Length;i++)
			{
				if(!char.IsNumber(strVal.ToCharArray()[i]))
					return false;
			}
			return true;
		}
		/// <summary>
		/// 是带有一个小数点的数字
		/// </summary>
		/// <param name="strVal"></param>
		/// <returns></returns>
		public static bool IsNumberWithPoint(string strVal)
		{
			if(strVal==null)
				return false;
			strVal=ReplaceTo(strVal);
			if(strVal=="")
				return false;
			bool WithPoint=false;
			for(int i=0;i<strVal.Length;i++)
			{
				if(strVal.ToCharArray()[i]=='.')
				{
					if(!WithPoint) //没有过小数点
						WithPoint=true;
					else
						return false;
				}
				else
				{
					if(!char.IsNumber(strVal.ToCharArray()[i]))
						return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 检查是否为中文
		/// </summary>
		/// <param name="strVal"></param>
		/// <returns></returns>
		public static bool IsEngOrNum(string strVal)
		{
			if(IsNumber(strVal))
				return true;
			ASCIIEncoding AE = new ASCIIEncoding();
			byte[] ByteArray = AE.GetBytes(strVal);

			for(int x = 0;x <= ByteArray.Length - 1; x++)
			{
				if(ByteArray[x]<0) //有中文字符
					return false;
			}
			return true;
		}
		/// <summary>
		/// 格式化Grid 其中strColName为显示的列名，strFieldName为绑定的字段。
		/// </summary>
		/// <param name="dtsConstruct"></param>
		/// <param name="strColName"></param>
		/// <param name="strFieldName"></param>
		/// <param name="intWidth"></param>
		public static void m_SetTableStyle(DataGridTableStyle dtsConstruct, string strColName, string strFieldName, int intWidth)
		{
			DataGridTextBoxColumn ColumnStyle = new DataGridTextBoxColumn();//定义表的列头
			ColumnStyle.HeaderText = strColName;
			ColumnStyle.MappingName = strFieldName;
			ColumnStyle.Width = intWidth;
			ColumnStyle.Alignment=HorizontalAlignment.Center;
			ColumnStyle.NullText="";
			dtsConstruct.GridColumnStyles.Add(ColumnStyle);
		}
	}

	//重新定义一ListView对比排列类
	/// <summary>
	///  对ListView进行排序 Create By Sam 2004-5-25
	/// </summary>
	public class ListViewItemComparer : IComparer 
	{
		private int col;
		private bool IsAsc=false; //是否为升序
		public ListViewItemComparer() 
		{
			col=0;
		}
		public ListViewItemComparer(int column,bool IsAsc,ListView objListView) 
		{
			string strColTxt="";
			for(int i=0;i<objListView.Columns.Count;i++)
			{
				strColTxt=objListView.Columns[i].Text;
				//↓↑
				strColTxt=strColTxt.Replace(" ↑","");
				strColTxt=strColTxt.Replace(" ↓","");
				objListView.Columns[i].Text=strColTxt;
			}
			
			col=column;
			this.IsAsc=IsAsc;
			strColTxt=objListView.Columns[col].Text;
			if(IsAsc==true)//如果是升序
				objListView.Columns[col].Text=strColTxt+" ↑";
			else
				objListView.Columns[col].Text=strColTxt+" ↓";
		}
		//不出现箭头
		public ListViewItemComparer(int column,bool IsAsc) 
		{
			col=column;
			this.IsAsc=IsAsc;
		}

		// created by Sam
		// modify by Cameron Wong on Aug 13, 2004
		// there is a bug in the origional version!
		public int Compare(object x, object y) 
		{
			int i=0;
			i=String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

			// the following line is added by Cameron Wong on Aug 13, 2004
			if (!IsAsc) i = -i;

/* commented by Cameron Wong on Aug 13, 2004
 
			if(i>0)//strA大于strB
			{
				if(IsAsc==true)//如果是升序
					i=1;
				else
					i=-1;
			}
			if(i<0)//strA小于strB
			{
				if(IsAsc==true)//如果是升序
					i=-1;
				else
					i=1;
			}
			else //相等
			{
				i=0;
			}
*/
			return i;
		}
	}



	public class ComboBoxItem 
	{
		internal ArrayList sText;
		internal ArrayList sValue;
		private exComboBox objCombo;
		public ComboBoxItem(exComboBox source)
		{
			this.objCombo=source;
			sText=new ArrayList();
			sValue=new ArrayList();
		}
		public void Add(string Text,string Value)
		{
			//this.sText=Text;
			this.objCombo.Items.Add(Text);
			//this.Value=Value;
			sText.Add(Text);
			sValue.Add(Value);
			//this.Add(Text);
		}
		public string this[int index]
		{
			get
			{
				string tmpText;
				if(index>-1 && sText.Count>0)
					tmpText=sText[index].ToString();
				else
					tmpText="";
				return tmpText;
			}
		}
	}
	
	public class exTreeNode:TreeNode
	{
		private string sKey;
		public string Key
		{
			get
			{
				return sKey;
			}
			set
			{
				sKey=value;
			}
		}
	}
	public class exComboBox:ComboBox
	{
		public ComboBoxItem Item;

		public exComboBox()
		{
			Item=new ComboBoxItem(this);
		}
		public void m_mthClear()
		{
			Item.sText.Clear();
			Item.sValue.Clear();
		}
		/// <summary>
		/// 当前选择的值
		/// </summary>
		public string SelectItemValue
		{
			get
			{
				string tmp="";
				if(Item.sValue.Count==0)
					return tmp;
				if(SelectedIndex>-1)
					tmp=Item.sValue[SelectedIndex].ToString();
				else
					tmp="";
				return tmp;
			}
		}
		/// <summary>
		/// 当前显示的值
		/// </summary>
		public string SelectItemText
		{
			get
			{
				string tmp="";
				if(Item.sText.Count==0)
					return tmp;
				if(SelectedIndex>-1)
					tmp=Item.sText[SelectedIndex].ToString();
				else
					tmp="";
				return tmp;
			}
		}
		public void Clear()
		{
			this.SelectedIndex=-1;
			this.Text="";
		}
		/// <summary>
		/// 查找保存的值
		/// </summary>
		/// <param name="Key"></param>
		public void FindKey(string Key)
		{
//			this.Clear();
			if(clsMain.IsNullToString(Key,null)=="")
			{
				this.SelectedIndex=-1;
				return;
			}
			if(Item.sValue.Count==0)
				return;
			bool b_temp =false;
			for(int i1=0;i1<this.Items.Count;i1++)
			{
				if(Item.sValue[i1].ToString()==Key)
				{
					b_temp =true;
					if(this.SelectedIndex!=i1)
					{
						this.SelectedIndex=i1;
						
					}
					return;
				}
			}
			if(!b_temp)
			{
			this.SelectedIndex=-1;
			}
		}	
	}
   

}
