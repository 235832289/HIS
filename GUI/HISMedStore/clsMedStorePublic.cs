using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 公共类
	/// </summary>
	public class clsMedStorePublic
	{
		/// <summary>
		/// 
		/// </summary>
		public clsMedStorePublic()
		{
		}
		#region 调用警告窗体

		public void m_mthShowWarning(TextBox txtBox,string strWaring)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_GetWaring=strWaring;
			Point p= txtBox.Parent.PointToScreen(txtBox.Location);
			p.Offset(-50,-(ShowWarning.Height-txtBox.Height/2));
			ShowWarning.Location=p;
			ShowWarning.Show();
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
		public void m_mthShowWarning(System.Windows.Forms.ListView txtBox ,string strWaring,bool isPlay)
		{
			frmShowWarning ShowWarning=new frmShowWarning();
			ShowWarning.m_isplay=true;
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
		#endregion

		#region 获取出入库单据号
		public static string  m_mthGetNewDocument(string strOldDocument)
		{
			string strNewDocument="";
			if(strOldDocument==null||strOldDocument=="")
			{
				strNewDocument=clsPublicParm.s_datGetServerDate().Year.ToString()+clsPublicParm.s_datGetServerDate().Month.ToString("00")+clsPublicParm.s_datGetServerDate().Day.ToString("00")+"0001";
			}
			else
			{
				Encoding ascii=Encoding.ASCII;
				Byte[] byCoding= ascii.GetBytes(strOldDocument);
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
					string strEN=strOldDocument.Substring(0,intEnLengt+1);
					string strNumber=strOldDocument.Substring(intEnLengt+1);
					int intNumber=0;
					try
					{
						intNumber=Convert.ToInt32(strNumber)+1;
						strNewDocument=strEN+intNumber.ToString();
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
						long n=Convert.ToInt64(strOldDocument)+1;
						strNewDocument=n.ToString();
					}
					catch
					{
						strNewDocument=clsPublicParm.s_datGetServerDate().Year.ToString()+clsPublicParm.s_datGetServerDate().Month.ToString("00")+clsPublicParm.s_datGetServerDate().Day.ToString("00")+"0001";
					}
				}

			}
			return strNewDocument;
		}

		#endregion
		
		#region 模糊查询药房库存明细
		/// <summary>
		/// 模糊查询药房库存明细
		/// </summary>
		/// <param name="strSQL">SQL语句</param>
		/// <param name="objResults">输出数据</param>
		/// <returns></returns>
		public static long s_lngGetMedStoreDetailByAny(string strSQL,out clsMedStoreDetail_VO[] objResults)
		{
			long lngRes = 0;
			objResults = new clsMedStoreDetail_VO[0];

			clsDomainControlMedStore objManage = new clsDomainControlMedStore();
			lngRes = objManage.m_lngGetMedStoreDetailByAny(strSQL,out objResults);

			return lngRes;
		}
		#endregion

		#region 获得所有的药品资料
		/// <summary>
		/// 获得所有的药品资料
		/// </summary>
		public static long m_lngGetMed(string strSQL,out clsMedStoreDetail_VO[] objResults)
		{
			long lngRes = 0;
			objResults = new clsMedStoreDetail_VO[0];

			clsDomainControlMedStore objManage = new clsDomainControlMedStore();
			lngRes = objManage.m_lngGetMedStoreDetailByAny(strSQL,out objResults);

			return lngRes;
		}
		#endregion

		#region 获得所有的药品资料
		/// <summary>
		/// 获得所有的药品资料
		/// </summary>
		public static long m_lngGetMedicine(out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=null;
			clsDomainControlMedStore objManage = new clsDomainControlMedStore();
			lngRes = objManage.m_lngGetMedicine(out dtbResult);

			return lngRes;
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
		/// 
		/// </summary>
		/// <param name="strValues"></param>
		/// <returns></returns>
		public static string ReplaceTo(string strValues)
		{
			strValues=strValues.Replace(" ","");
			strValues=strValues.Replace("'","");
			return strValues;
		}
		#endregion

	}
}
