using System;
using System.Drawing;
using iCare;

namespace com.digitalwave.Utility.Controls
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_intEndY"></param>
    /// <param name="p_objGrp"></param>
    /// <param name="p_fntNormalText"></param>
	public delegate void d_mthPrintPartEnd(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText);
	/// <summary>
    /// 行打印类，(只管单行打印)
	/// </summary>
	public abstract class clsPrintLineBase
	{
		/// <summary>
		/// 打印下一行数据
		/// </summary>
		/// <param name="p_intPosY"></param>
		/// <param name="p_objGrp"></param>
		/// <param name="p_fntNormalText"></param>
		public abstract void m_mthPrintNextLine(ref int p_intPosY,Graphics p_objGrp,Font p_fntNormalText);
        /// <summary>
        /// 
        /// </summary>
		protected d_mthPrintPartEnd m_objHandlePartEnd;
        /// <summary>
        /// 
        /// </summary>
		public d_mthPrintPartEnd m_ObjHandlePartEnd
		{
			set
			{
				m_objHandlePartEnd = value;
			}
		}
		/// <summary>
		/// 重置该次打印所使用的参数值
		/// </summary>
		public abstract void m_mthReset();		
        /// <summary>
        /// 获取是否还有下一行，true 为还有，false 为没有
        /// </summary>
		public virtual bool m_BlnHaveMoreLine
		{
			get
			{
				return m_blnHaveMoreLine;
			}
		}
        /// <summary>
        /// 标识是否还有下一行，true 为还有，false 为没有
        /// </summary>
		protected bool m_blnHaveMoreLine = true;
        /// <summary>
        /// 打印内容对象
        /// </summary>
		protected object m_objPrintLineInfo = null;
        /// <summary>
        /// 获取或者设置打印内容对象
        /// </summary>
		public virtual object m_ObjPrintLineInfo
		{
			get
			{
				return m_objPrintLineInfo;
			}
			set
			{
				m_objPrintLineInfo = value;
			}
		}
        /// <summary>
        /// 打印的签名信息对象
        /// </summary>
		protected clsPrintRecordSign m_objPrintSign = null;
        /// <summary>
        /// 获取或者设置带打印的签名信息对象
        /// </summary>
		public clsPrintRecordSign m_ObjPrintSign
		{
			get
			{
				return m_objPrintSign;
			}
			set
			{
				m_objPrintSign = value;
			}
		}
		/// <summary>
		/// 添加签名
		/// </summary>
		/// <param name="p_strPartDesc">签名的描述</param>
		/// <param name="p_objRichTextBoxArr">签名的信息</param>
		protected void m_mthAddSign(string p_strPartDesc,ctlRichTextBox.clsModifyUserInfo [] p_objModifyUserArr)
		{
			if(m_objPrintSign != null)
			{
				m_objPrintSign.m_mthAddSignInfo(p_strPartDesc,p_objModifyUserArr);
			}
		}
		/// <summary>
		/// 添加签名
		/// </summary>
		/// <param name="p_strPartDesc">签名的描述</param>
		/// <param name="p_objModifyUserArr">签名的信息</param>
		protected void m_mthAddSign2(string p_strPartDesc,com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo [] p_objModifyUserArr)
		{
			if(m_objPrintSign != null)
			{
				m_objPrintSign.m_mthAddSignInfo2(p_strPartDesc,p_objModifyUserArr);
			}
		}
        /// <summary>
        /// 第一次打印时间
        /// </summary>
		protected DateTime m_dtmFirstPrintTime;
        /// <summary>
        /// 获取或设置第一次打印时间
        /// </summary>
		public virtual object m_DtmFirstPrintTime
		{
			get
			{
				return m_dtmFirstPrintTime;
			}
			set
			{
				m_dtmFirstPrintTime =(DateTime)value;
			}
		}
	}
	/// <summary>
	/// 打印上下文助手类
	/// </summary>
	public class clsPrintContext
	{
        /// <summary>
        /// 打印信息对象
        /// </summary>
		private object m_objPrintLineInfo = null;
		/// <summary>
		/// 获取或者设置打印信息对象
		/// </summary>
		public object m_ObjPrintLineInfo
		{
			get
			{
				return m_objPrintLineInfo;
			}
			set
			{
				m_objPrintLineInfo = value;

				if(m_objPrintLineArr != null)
				{
					for(int i=0;i<m_objPrintLineArr.Length;i++)
					{
						m_objPrintLineArr[i].m_ObjPrintLineInfo = value;
					}
				}
			}
		}
        /// <summary>
        /// 打印的签名内容对象
        /// </summary>
		private clsPrintRecordSign m_objPrintSign = null;
        /// <summary>
        /// 设置打印的签名内容对象
        /// </summary>
		public clsPrintRecordSign m_ObjPrintSign
		{
			set
			{
				m_objPrintSign = value;

				if(m_objPrintLineArr != null)
				{
					for(int i=0;i<m_objPrintLineArr.Length;i++)
					{
						m_objPrintLineArr[i].m_ObjPrintSign = value;
					}
				}
			}
		}
		/// <summary>
		/// 设置第一次打印的时间
		/// </summary>
		public DateTime m_DtmFirstPrintTime
		{
			set
			{
				for(int i=0;i<m_objPrintLineArr.Length;i++)
				{
					m_objPrintLineArr[i].m_DtmFirstPrintTime = value;
				}
				
			}
		}
        /// <summary>
        /// 打印的内容对象
        /// </summary>
		private clsPrintLineBase [] m_objPrintLineArr;
        /// <summary>
        /// 获取或设置打印的内容对象
        /// </summary>
		public clsPrintLineBase [] m_ObjPrintLineArr
		{
			get
			{
				return m_objPrintLineArr;
			}
			set
			{
				m_objPrintLineArr = value;

				if(m_objPrintLineArr != null && 
					m_objPrintLineArr.Length > 0 && 
					m_objPrintLineArr[0].m_BlnHaveMoreLine)
				{
					m_intCurrentPrintLineIndex = 0;

					m_blnHaveMoreLine = true;
				}
				else
				{
					m_intCurrentPrintLineIndex = -1;

					m_blnHaveMoreLine = false;
				}
			}
		}
        /// <summary>
        /// 当前打印行的行号
        /// </summary>
		private int m_intCurrentPrintLineIndex;
        /// <summary>
        /// 构造函数1
        /// </summary>
		public clsPrintContext()
		{
			m_objPrintLineArr = null;

			m_intCurrentPrintLineIndex = -1;
		}
        /// <summary>
        /// 构造函数2 (初始化打印内容)
        /// </summary>
        /// <param name="p_objPrintLineArr">打印内容对象</param>
		public clsPrintContext(clsPrintLineBase [] p_objPrintLineArr)
		{
			m_objPrintLineArr = p_objPrintLineArr;

			if(m_objPrintLineArr != null && 
				m_objPrintLineArr.Length > 0 && 
				m_objPrintLineArr[0].m_BlnHaveMoreLine)
			{
				m_intCurrentPrintLineIndex = 0;

				m_blnHaveMoreLine = true;
			}
			else
			{
				m_intCurrentPrintLineIndex = -1;

				m_blnHaveMoreLine = false;
			}
		}
        /// <summary>
        /// 打印一行签名
        /// </summary>
        /// <param name="p_intPosX">该行的横坐标</param>
        /// <param name="p_intPosY">该行的纵坐标</param>
        /// <param name="p_objGrp">打印绘图对象</param>
        /// <param name="p_fntNormalText">打印的字体</param>
		public void m_mthPrintNextSign(int p_intPosX,int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
		{
			if(m_objPrintSign != null)
			{
				try
				{
					m_objPrintSign.m_mthPrintNextLine(p_intPosX,p_intPosY,p_objGrp,p_fntNormalText);
				}
				catch
				{
				}
			}
		}
        /// <summary>
        /// 获取是否还有需要打印的签名行，true 为还有，false 为没有
        /// </summary>
		public bool m_BlnHaveMoreSign
		{
			get
			{
				if(m_objPrintSign != null && m_objPrintSign.m_BlnHaveMoreLine)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
        /// <summary>
        /// 是否还有需要打印的行，true 为还有，false 为没有
        /// </summary>
		private bool m_blnHaveMoreLine = false;
        /// <summary>
        /// 获取是否还有需要打印的行，true 为还有，false 为没有
        /// </summary>
		public bool m_BlnHaveMoreLine
		{
			get
			{
				return m_blnHaveMoreLine;
			}
		}
        /// <summary>
        /// 打印一行数据
        /// </summary>
        /// <param name="p_intPosY">该行的纵坐标</param>
        /// <param name="p_objGrp">打印绘图对象</param>
        /// <param name="p_fntNormalText">打印的字体</param>
		public void m_mthPrintNextLine(ref int p_intPosY,Graphics p_objGrp,Font p_fntNormalText)
		{
			if(!m_blnHaveMoreLine)
				return;

			try
			{
				m_objPrintLineArr[m_intCurrentPrintLineIndex].m_mthPrintNextLine(ref p_intPosY,p_objGrp,p_fntNormalText);//

				if(m_objPrintLineArr[m_intCurrentPrintLineIndex].m_BlnHaveMoreLine)
				{
					return;
				}
				else
				{
					m_intCurrentPrintLineIndex++;

					if(m_intCurrentPrintLineIndex >= m_objPrintLineArr.Length
						|| !m_objPrintLineArr[m_intCurrentPrintLineIndex].m_BlnHaveMoreLine)
					{
						m_intCurrentPrintLineIndex = -1;

						m_blnHaveMoreLine = false;
					}
				}
			}
			catch(Exception  ex)
			{				
				clsPublicFunction.ShowInformationMessageBox(ex.TargetSite.ReflectedType.ToString() +" : "+ ex.TargetSite.Name+" : " +ex.Message+":" + ex.StackTrace);
			}
		}
        /// <summary>
        /// 重置所有与该次打印相关且必须重置的参数值
        /// </summary>
		public void m_mthReset()
		{
			if(m_objPrintSign != null)
				m_objPrintSign.m_mthReset();

			if(m_objPrintLineArr == null)
				return;

			for(int i=0;i<m_objPrintLineArr.Length;i++)
			{
				m_objPrintLineArr[i].m_mthReset();
			}

			if(m_objPrintLineArr.Length > 0 && 
				m_objPrintLineArr[0].m_BlnHaveMoreLine)
			{
				m_intCurrentPrintLineIndex = 0;

				m_blnHaveMoreLine = true;
			}
			else
			{
				m_intCurrentPrintLineIndex = -1;

				m_blnHaveMoreLine = false;
			}
		}
	}
}