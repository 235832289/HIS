using System;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.Data;

using com.digitalwave.Utility.Controls;

namespace com.digitalwave.Utility
{
	/// <summary>
	/// 测试代码内容生成
	/// </summary>
	public class clsTestContentMaker
	{
		/// <summary>
		/// 数值类型
		/// </summary>
		public class DigitalValueType{}
		/// <summary>
		/// 数值类型的实例
		/// </summary>
		private DigitalValueType m_objDigitalValueType = new DigitalValueType();
		/// <summary>
		/// 数值类型的实例获取
		/// </summary>
		public DigitalValueType m_ObjDigitalValueType
		{
			get
			{
				return m_objDigitalValueType;
			}
		}

		/// <summary>
		/// 字符类型，但内容是数字（如卡号）
		/// </summary>
		public class DigitalStringValueType{}
		/// <summary>
		/// 字符类型，但内容是数字（如卡号）实例
		/// </summary>
		private DigitalStringValueType m_objDigitalStringValueType = new DigitalStringValueType();
		/// <summary>
		/// 字符类型，但内容是数字（如卡号）实例的获取
		/// </summary>
		public DigitalStringValueType m_ObjDigitalStringValueType
		{
			get
			{
				return m_objDigitalStringValueType;
			}
		}

		/// <summary>
		/// 字符类型
		/// </summary>
		public class StringValueType{}
		/// <summary>
		/// 字符类型实例
		/// </summary>
		private StringValueType m_objStringValueType = new StringValueType();
		/// <summary>
		/// 字符类型实例的获取
		/// </summary>
		public StringValueType m_ObjStringValueType
		{
			get
			{
				return m_objStringValueType;
			}
		}

		/// <summary>
		/// 外部文本值的生成
		/// </summary>
		public delegate string d_strMakeTextValue();

		/// <summary>
		/// 测试用的总文本
		/// </summary>
		private string m_strTotalTestCode;

		/// <summary>
		/// 记录各个文本生成的内容
		/// </summary>
		private ArrayList m_arlMakerLog;

		/// <summary>
		/// 随机数生成
		/// </summary>
		private Random m_objRand;	

		/// <summary>
		/// 窗体所有控件值临时缓冲
		/// </summary>
		private StringBuilder 
			m_sbdTextValueTemp,
			m_sbdCheckBoxValueTemp,
			m_sbdRadioButtonValueTemp,
			m_sbdDataGridValueTemp,
			m_sbdListBoxValueTemp,
			m_sbdCheckedListBoxValueTemp,
			m_sbdListViewValueTemp,
			m_sbdDomainUpDownValueTemp,
			m_sbdNumericUpDownValueTemp,
			m_sbdRichTextBoxValueTemp,
			m_sbdDateTimePickerValueTemp,
			m_sbdComboBoxValueTemp,
			m_sbdLabelValueTemp,
			m_sbdTreeViewValueTemp;

		private StringBuilder m_sbdFormValueTemp;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strFileName">测试用总文本的文件</param>
		public clsTestContentMaker(string p_strFileName)
		{
			StreamReader objSR = new StreamReader(p_strFileName,Encoding.Default);
			m_strTotalTestCode = objSR.ReadToEnd();
			objSR.Close();

			m_arlMakerLog = new ArrayList(100);

			m_objRand = new Random();

			m_sbdTextValueTemp = new StringBuilder(300);
			m_sbdCheckBoxValueTemp = new StringBuilder(300);
			m_sbdRadioButtonValueTemp = new StringBuilder(300);
			m_sbdDataGridValueTemp = new StringBuilder(300);
			m_sbdListBoxValueTemp = new StringBuilder(300);
			m_sbdCheckedListBoxValueTemp = new StringBuilder(300);
			m_sbdListViewValueTemp = new StringBuilder(300);
			m_sbdDomainUpDownValueTemp = new StringBuilder(300);
			m_sbdNumericUpDownValueTemp = new StringBuilder(300);
			m_sbdRichTextBoxValueTemp = new StringBuilder(300);
			m_sbdDateTimePickerValueTemp = new StringBuilder(300);
			m_sbdComboBoxValueTemp = new StringBuilder(300);
			m_sbdLabelValueTemp = new StringBuilder(300);
			m_sbdTreeViewValueTemp = new StringBuilder(300);

			m_sbdFormValueTemp = new StringBuilder(1200*6);
		}

		/// <summary>
		/// 获取文本生成信息
		/// </summary>
		/// <returns>生成信息</returns>
		public string m_strGetMakerLog()
		{
			string[] strLogArr = (string[])m_arlMakerLog.ToArray(typeof(string));

			m_sbdFormValueTemp.Length = 0;

			for(int i=0;i<strLogArr.Length;i++)
			{
				m_sbdFormValueTemp.Append(strLogArr[i]);
			}

			return m_sbdFormValueTemp.ToString();
		}

		/// <summary>
		/// 获取窗体所有控件的值
		/// </summary>
		/// <param name="p_frmTestForm">窗体</param>
		/// <returns>值</returns>
		public string m_strGetFormCurrentValue(Form p_frmTestForm)
		{
			m_sbdCheckBoxValueTemp.Length = 0;		
			m_sbdCheckedListBoxValueTemp.Length = 0;	
			m_sbdDataGridValueTemp.Length = 0;	
			m_sbdDomainUpDownValueTemp.Length = 0;	
			m_sbdListBoxValueTemp.Length = 0;	
			m_sbdListViewValueTemp.Length = 0;	
			m_sbdNumericUpDownValueTemp.Length = 0;	
			m_sbdRadioButtonValueTemp.Length = 0;	
			m_sbdRichTextBoxValueTemp.Length = 0;
			m_sbdTextValueTemp.Length = 0;		
			m_sbdDateTimePickerValueTemp.Length = 0;
			m_sbdComboBoxValueTemp.Length = 0;	
			m_sbdLabelValueTemp.Length = 0;	
			m_sbdTreeViewValueTemp.Length = 0;	

			m_sbdFormValueTemp.Length = 0;	

			m_mthGetControlCurrentValue(p_frmTestForm);

			m_sbdFormValueTemp.Append("TextBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdTextValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("CheckBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdCheckBoxValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("RadioButton\r\n");
			m_sbdFormValueTemp.Append(m_sbdRadioButtonValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("DataGrid\r\n");
			m_sbdFormValueTemp.Append(m_sbdDataGridValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("ListBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdListBoxValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("CheckedListBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdCheckedListBoxValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("ListView\r\n");
			m_sbdFormValueTemp.Append(m_sbdListViewValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("DomainUpDown\r\n");
			m_sbdFormValueTemp.Append(m_sbdDomainUpDownValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("NumericUpDown\r\n");
			m_sbdFormValueTemp.Append(m_sbdNumericUpDownValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("RichTextBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdRichTextBoxValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("DateTimePicker\r\n");
			m_sbdFormValueTemp.Append(m_sbdDateTimePickerValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("ComboBox\r\n");
			m_sbdFormValueTemp.Append(m_sbdComboBoxValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("Label\r\n");
			m_sbdFormValueTemp.Append(m_sbdLabelValueTemp.ToString()+"\r\n");
			m_sbdFormValueTemp.Append("TreeView\r\n");
			m_sbdFormValueTemp.Append(m_sbdTreeViewValueTemp.ToString()+"\r\n");

			return m_sbdFormValueTemp.ToString();
			
		}

		/// <summary>
		/// 获取控件的值
		/// </summary>
		/// <param name="p_ctlTestControl">控件</param>
		private void m_mthGetControlCurrentValue(Control p_ctlTestControl)
		{
			foreach(Control ctlItem in p_ctlTestControl.Controls)
			{
				switch(ctlItem.GetType().Name)
				{
					case "Label":
						m_sbdLabelValueTemp.Append(ctlItem.Name+".Text : "+ctlItem.Text+"\r\n");
						break;
					case "ctlBorderTextBox":
					case "dwtBorderTextBox":
					case "TextBox":
						m_sbdTextValueTemp.Append(ctlItem.Name+".Text : "+ctlItem.Text+"\r\n");
						break;
					case "CheckBox":
						m_sbdCheckBoxValueTemp.Append(ctlItem.Name+".Checked : "+((CheckBox)ctlItem).Checked+"\r\n");
						break;
					case "RadioButton":						
						m_sbdRadioButtonValueTemp.Append(ctlItem.Name+".Checked : "+((RadioButton)ctlItem).Checked+"\r\n");
						break;
					case "DataGrid":
						m_sbdDataGridValueTemp.Append(ctlItem.Name+" : \r\n");
						DataTable dtbTable = (DataTable)((DataGrid)ctlItem).DataSource;

						for(int i1=0;i1<dtbTable.Rows.Count;i1++)
						{
							m_sbdDataGridValueTemp.Append("\t");
							object [] objValArr = dtbTable.Rows[i1].ItemArray;
							for(int j2=0;j2<objValArr.Length;j2++)
							{
								m_sbdDataGridValueTemp.Append(objValArr[j2].ToString()+"	");
							}
							m_sbdDataGridValueTemp.Append("\r\n");
						}
						break;
					case "ListBox":
						m_sbdListBoxValueTemp.Append(ctlItem.Name+" : \r\n");
						ListBox lstTestControl = (ListBox)ctlItem;

						for(int i=0;i<lstTestControl.Items.Count;i++)
						{
							m_sbdListBoxValueTemp.Append("\t"+lstTestControl.Items[i].ToString()+"("+lstTestControl.GetSelected(i)+")\r\n");
						}
						break;
					case "CheckedListBox":
						m_sbdCheckedListBoxValueTemp.Append(ctlItem.Name+" : \r\n");
						CheckedListBox clstTestControl = (CheckedListBox)ctlItem;

						for(int i=0;i<clstTestControl.Items.Count;i++)
						{
							m_sbdCheckedListBoxValueTemp.Append("\t"+clstTestControl.Items[i].ToString()+"("+clstTestControl.GetItemChecked(i)+")\r\n");
						}
						break;
					case "ComboBox":
						m_sbdComboBoxValueTemp.Append(ctlItem.Name+"("+ctlItem.Text+") : \r\n");
						ComboBox cboTestControl = (ComboBox)ctlItem;

						for(int i=0;i<cboTestControl.Items.Count;i++)
						{
							m_sbdComboBoxValueTemp.Append("\t"+cboTestControl.Items[i].ToString()+"\r\n");
						}
						break;
					case "ctlComboBox":
						ctlComboBox cboControl = (ctlComboBox)ctlItem;

						m_sbdComboBoxValueTemp.Append(ctlItem.Name+"("+cboControl.Text+") : \r\n");
						
						for(int i=0;i<cboControl.GetItemsCount();i++)
						{
							m_sbdComboBoxValueTemp.Append("\t"+cboControl.GetItem(i).ToString()+"\r\n");
						}
						break;
//					case "dwtFlatComboBox":
//						dwtFlatComboBox cboFlatControl = (dwtFlatComboBox)ctlItem;
//
//						m_sbdComboBoxValueTemp.Append(ctlItem.Name+"("+cboFlatControl.Text+") : \r\n");
//						
//						for(int i=0;i<cboFlatControl.GetItemsCount();i++)
//						{
//							m_sbdComboBoxValueTemp.Append("\t"+cboFlatControl.GetItem(i).ToString()+"\r\n");
//						}
//						break;
					case "ListView":
						m_sbdListViewValueTemp.Append(ctlItem.Name+" : \r\n");
						ListView lsvTestControl = (ListView)ctlItem;

						for(int i1=0;i1<lsvTestControl.Items.Count;i1++)
						{
							ListViewItem lviRow = lsvTestControl.Items[i1];

							m_sbdListViewValueTemp.Append("\t");
							for(int j2=0;j2<lviRow.SubItems.Count;j2++)
							{
								m_sbdListViewValueTemp.Append(lviRow.SubItems[j2].Text+"	");
							}
							m_sbdListViewValueTemp.Append("\r\n");							
						}
						break;
					case "DomainUpDown":
						m_sbdDomainUpDownValueTemp.Append(ctlItem.Name+".Text : "+ctlItem.Text+"\r\n");
						break;
					case "NumericUpDown":
						m_sbdNumericUpDownValueTemp.Append(ctlItem.Name+".Text : "+ctlItem.Text+"\r\n");
						break;
					case "RichTextBox":
						m_sbdRichTextBoxValueTemp.Append(ctlItem.Name+".Text : "+ctlItem.Text+"\r\n");
						break;
//					case "dwtFlatTimePick":
//						m_sbdDateTimePickerValueTemp.Append(ctlItem.Name+".Text : "+((dwtFlatTimePick)ctlItem).Text+"\r\n");
//						break;
					case "DateTimePicker":
						m_sbdDateTimePickerValueTemp.Append(ctlItem.Name+".Text : "+(ctlItem).Text+"\r\n");
						break;
					case "ctlTimePicker":
						m_sbdDateTimePickerValueTemp.Append(ctlItem.Name+".Text : "+((ctlTimePicker)ctlItem).Text+"\r\n");
						break;
					case "TreeView":
						m_sbdTreeViewValueTemp.Append(ctlItem.Name+" : \r\n");

						TreeView trvItem = (TreeView)ctlItem;

						for(int i=0;i<trvItem.Nodes.Count;i++)
						{
							m_mthAddChildTreeNode(trvItem.Nodes[i],0);
						}
						break;
					case "TabControl":
						m_mthGetControlCurrentValue(ctlItem);
						break;
					case "TabPage":
						m_mthGetControlCurrentValue(ctlItem);
						break;
				}				
			}
		}

		private void m_mthAddChildTreeNode(TreeNode p_trnSubItem,int p_intParentDepth)
		{
			string strIndent = "   ";
			for(int i=0;i<p_intParentDepth;i++)
			{
				strIndent += "   ";
			}
			m_sbdTreeViewValueTemp.Append(strIndent+p_trnSubItem.Text+"\r\n");
			for(int i=0;i<p_trnSubItem.Nodes.Count;i++)
			{
				m_mthAddChildTreeNode(p_trnSubItem.Nodes[i],p_intParentDepth+1);
			}
		}

		/// <summary>
		/// 清空文本生成信息
		/// </summary>
		public void m_mthClearMakerLog()
		{
			m_arlMakerLog.Clear();
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">数值类型的实例</param>
		/// <param name="p_dblMaxValue">双精度的最大值（数值以d结尾）</param>
		/// <param name="p_dblMinValue">双精度的最小值（数值以d结尾）</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,DigitalValueType p_objDummy,double p_dblMaxValue,double p_dblMinValue)
		{		
			double dblRang = m_objRand.NextDouble()*((p_dblMaxValue-p_dblMinValue))+p_dblMinValue;

			string strValue = dblRang.ToString();
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">数值类型的实例</param>
		/// <param name="p_intMaxValue">整形的最大值</param>
		/// <param name="p_intMinValue">整形的最小值</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,DigitalValueType p_objDummy,int p_intMaxValue,int p_intMinValue)
		{
			string strValue = m_objRand.Next(p_intMinValue,p_intMaxValue).ToString();
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">数值类型的实例</param>
		/// <param name="p_intMaxValue">最大值</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,DigitalValueType p_objDummy,int p_intMaxValue)
		{			
			string strValue = m_objRand.Next(p_intMaxValue).ToString();
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">数值类型的实例</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,DigitalValueType p_objDummy)
		{			
			string strValue = m_objRand.Next().ToString();
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}
		
		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">字符类型，但内容是数字（如卡号）实例</param>
		/// <param name="p_strFormat">格式。如（"0000047"="0000000","e015"="e000"）</param>
		/// <param name="p_intMaxValue">最大值。如（"9999999"="9999999","e999"="999"）</param>
		/// <param name="p_intMinValue">最小值。如（"0000001"="1","e001"="1"）</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,DigitalStringValueType p_objDummy,string p_strFormat,int p_intMaxValue,int p_intMinValue)
		{			
			string strValue = m_objRand.Next(p_intMinValue,p_intMaxValue+1).ToString(p_strFormat);
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">字符类型实例</param>
		/// <param name="p_intMaxLength">文本最大长度</param>
		/// <param name="p_intMinLength">文本最小长度</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,StringValueType p_objDummy,int p_intMaxLength,int p_intMinLength)
		{			
			int intLen = m_objRand.Next(p_intMinLength,p_intMaxLength);			

			int intIndex = m_objRand.Next(0,m_strTotalTestCode.Length-intLen);
            
			string strValue = m_strTotalTestCode.Substring(intIndex,intLen);
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">字符类型实例</param>
		/// <param name="p_intMaxLength">文本最小长度</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,StringValueType p_objDummy,int p_intMaxLength)
		{			
			int intLen = m_objRand.Next(0,p_intMaxLength);			

			int intIndex = m_objRand.Next(0,m_strTotalTestCode.Length-intLen);
            
			string strValue = m_strTotalTestCode.Substring(intIndex,intLen);
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objDummy">字符类型实例</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,StringValueType p_objDummy)
		{			
			int intLen = m_objRand.Next(0,m_strTotalTestCode.Length);			

			int intIndex = m_objRand.Next(0,m_strTotalTestCode.Length-intLen);
            
			string strValue = m_strTotalTestCode.Substring(intIndex,intLen);
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}

		/// <summary>
		/// 获取文本值
		/// </summary>
		/// <param name="p_ctlValueFor">文本值赋值的控件</param>
		/// <param name="p_objValueMaker">外部文本生成函数</param>
		/// <returns>文本值</returns>
		public string m_strNextTextValue(Control p_ctlValueFor,d_strMakeTextValue p_objValueMaker)
		{			
			string strValue = p_objValueMaker();
			
			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+strValue+"\r\n");

			return strValue;
		}		

		/// <summary>
		/// 获取索引
		/// </summary>
		/// <param name="p_ctlValueFor">索引赋值的控件</param>
		/// <param name="p_intMaxIndex"></param>
		/// <returns>索引值</returns>
		public int m_intNextSelectIndex(Control p_ctlValueFor,int p_intMaxIndex)
		{
			int intValue = m_objRand.Next(0,p_intMaxIndex);

			m_arlMakerLog.Add(p_ctlValueFor.Name+" : "+intValue+"\r\n");

			return intValue;
		}

		/// <summary>
		/// 获取树上的节点
		/// </summary>
		/// <param name="p_trvNodeFor">树控件</param>
		/// <returns>树节点</returns>
		public TreeNode m_trnNextTreeViewNode(TreeView p_trvNodeFor)
		{
			int intNodeCount = p_trvNodeFor.GetNodeCount(true);

			if(intNodeCount <= 0)
				return null;

			int intCurrentCount = 0;
			int intSelectCount = m_objRand.Next(1,intNodeCount+1);

			TreeNode trnResult = null;
				
			for(int i=0;i<p_trvNodeFor.Nodes.Count;i++)
			{
				intCurrentCount++;
					
				if(intCurrentCount == intSelectCount)
					trnResult = p_trvNodeFor.Nodes[i];
				else
				{
					trnResult = m_trnGetNodeByCountNum(p_trvNodeFor.Nodes[i],intSelectCount,ref intCurrentCount);
				}

				if(trnResult != null)
				{
					break;
				}
			}

			if(trnResult != null)
			{
				m_arlMakerLog.Add(p_trvNodeFor.Name+" : 节点名称："+trnResult.Text+"；节点计数号："+intSelectCount+"\r\n");				
			}
			else
			{
				m_arlMakerLog.Add(p_trvNodeFor.Name+" : 没有选择树节点\r\n");
			}

			return trnResult;
		}

		/// <summary>
		/// 根据数目选择树节点
		/// </summary>
		/// <param name="p_trnBase">“根”树节点</param>
		/// <param name="p_intCountNum">期望的树号</param>
		/// <param name="p_intCurrentCount">当前的树号</param>
		/// <returns>树节点</returns>
		private TreeNode m_trnGetNodeByCountNum(TreeNode p_trnBase,int p_intCountNum,ref int p_intCurrentCount)
		{
			TreeNode trnResult = null;

			for(int i=0;i<p_trnBase.Nodes.Count;i++)
			{				
				p_intCurrentCount++;	

				if(p_intCurrentCount == p_intCountNum)
				{
					trnResult = p_trnBase.Nodes[i];
					break;
				}
				
				trnResult = m_trnGetNodeByCountNum(p_trnBase.Nodes[i],p_intCountNum,ref p_intCurrentCount);

				if(trnResult != null)
					break;			
			}

			return trnResult;
		}
	}
}
