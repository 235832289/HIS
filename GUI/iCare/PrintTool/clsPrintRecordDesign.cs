using System;
using System.Collections;
using System.Drawing;

namespace com.digitalwave.Utility.Controls
{
	/// <summary>
	/// Summary description for clsPrintRecordSign
	/// </summary>
	public class clsPrintRecordSign
	{
		private class clsSignInfo
		{
			public string m_strPartDesc;

			public ctlRichTextBox.clsModifyUserInfo [] m_objModifyUserArr;
		}

		private class clsSignInfo2
		{
			public string m_strPartDesc;

			public com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] m_objModifyUserArr;
		}

		private bool m_blnHaveMoreLine = true;

		private bool m_blnAfterReset = false;

		public virtual bool m_BlnHaveMoreLine
		{
			get
			{
				return m_blnHaveMoreLine;
			}
		}
		
		private ArrayList m_arlSignInfo = new ArrayList();

		private int m_intCurrentPrintIndex = 0;

		private int m_intSignIndex = 1;

		private float m_fltDescWidth = 0;

		/// <summary>
		/// 添加签名
		/// </summary>
		/// <param name="p_strPartDesc">签名的描述</param>
		/// <param name="p_objRichTextBoxArr">签名的信息</param>
		public void m_mthAddSignInfo(string p_strPartDesc,ctlRichTextBox.clsModifyUserInfo [] p_objModifyUserArr)
		{
			if(p_objModifyUserArr == null || p_objModifyUserArr.Length < 2)
				return;

			if(m_blnAfterReset)
			{
				m_arlSignInfo.Clear();
				m_blnAfterReset = false;
			}

			clsSignInfo objSignInfo = new clsSignInfo();
			objSignInfo.m_strPartDesc = p_strPartDesc;
			objSignInfo.m_objModifyUserArr = p_objModifyUserArr;

			m_arlSignInfo.Add(objSignInfo);
		}

		/// <summary>
		/// 添加签名
		/// </summary>
		/// <param name="p_strPartDesc">签名的描述</param>
		/// <param name="p_objModifyUserArr">签名的信息</param>
		public void m_mthAddSignInfo2(string p_strPartDesc,com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] p_objModifyUserArr)
		{
			if(p_objModifyUserArr == null || p_objModifyUserArr.Length < 2)
				return;

			if(m_blnAfterReset)
			{
				m_arlSignInfo.Clear();
				m_blnAfterReset = false;
			}

			clsSignInfo2 objSignInfo = new clsSignInfo2();
			objSignInfo.m_strPartDesc = p_strPartDesc;
			objSignInfo.m_objModifyUserArr = p_objModifyUserArr;

			m_arlSignInfo.Add(objSignInfo);
		}

		
		public void m_mthPrintNextLine(int p_intX,int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
		{
			if(m_intCurrentPrintIndex < m_arlSignInfo.Count)
			{				
				clsSignInfo2 objSignInfo = (clsSignInfo2)m_arlSignInfo[m_intCurrentPrintIndex];
                
				//还没有打印完一处内容的修改者
				if(m_intSignIndex < objSignInfo.m_objModifyUserArr.Length)
				{
					if(m_intSignIndex == 1)
					{
						p_objGrp.DrawString(objSignInfo.m_strPartDesc,p_fntNormalText ,Brushes.Black,p_intX,p_intPosY);
						m_fltDescWidth = p_objGrp.MeasureString(objSignInfo.m_strPartDesc,p_fntNormalText).Width;
					}

					p_objGrp.DrawString(m_intSignIndex+" "+objSignInfo.m_objModifyUserArr[m_intSignIndex].m_strUserName+" "+objSignInfo.m_objModifyUserArr[m_intSignIndex].m_dtmModifyDate.ToString(),p_fntNormalText ,Brushes.Black,p_intX+m_fltDescWidth,p_intPosY);

					m_intSignIndex++;
				}

				if(m_intSignIndex >= objSignInfo.m_objModifyUserArr.Length)
				{
					m_intCurrentPrintIndex++;				
					m_intSignIndex = 1;
					m_fltDescWidth = 0;
				}

				if(m_intCurrentPrintIndex < m_arlSignInfo.Count)
				{
					m_blnHaveMoreLine = true;
				}
				else
				{
					m_blnHaveMoreLine = false;
				}
			}
			else
			{
				m_blnHaveMoreLine = false;
			}
		}

		public void m_mthReset()
		{
			m_blnHaveMoreLine = true;

			m_intCurrentPrintIndex = 0;

			m_fltDescWidth = 0;

			m_intSignIndex = 1;

			m_blnAfterReset = true;
		}
	}
}
