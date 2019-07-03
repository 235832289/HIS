using System;
using System.Drawing;

namespace com.digitalwave.iCare.gui.LIS
{
	public delegate void d_mthPrintPartEnd(int p_intEndY,Graphics p_objGrp,Font p_fntNormalText);

	/// <summary>
	/// 表示每一次的打印
	/// </summary>
	public abstract class clsPrintLineBase
	{
		/// <summary>
		/// 打印下一行
		/// </summary>
		/// <param name="p_intPosY"></param>
		/// <param name="p_objGrp"></param>
		/// <param name="p_fntNormalText"></param>
		public abstract void m_mthPrintNextLine(ref int p_intPosY,Graphics p_objGrp,Font p_fntNormalText);

		protected d_mthPrintPartEnd m_objHandlePartEnd;

		public d_mthPrintPartEnd m_ObjHandlePartEnd
		{
			set
			{
				m_objHandlePartEnd = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public abstract void m_mthReset();		

		public virtual bool m_BlnHaveMoreLine
		{
			get
			{
				return m_blnHaveMoreLine;
			}
		}

		protected bool m_blnHaveMoreLine = true;

		protected object m_objPrintLineInfo = null;

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


		protected DateTime m_dtmFirstPrintTime;


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
	/// 
	/// </summary>
	public class clsPrintContext
	{

		private object m_objPrintLineInfo = null;

		/// <summary>
		/// 
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
		/// 
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

		private clsPrintLineBase [] m_objPrintLineArr;

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

		private int m_intCurrentPrintLineIndex;

		public clsPrintContext()
		{
			m_objPrintLineArr = null;

			m_intCurrentPrintLineIndex = -1;
		}

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

		private bool m_blnHaveMoreLine = false;

		public bool m_BlnHaveMoreLine
		{
			get
			{
				return m_blnHaveMoreLine;
			}
		}

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
                throw ex;	
			}
		}

		public void m_mthReset()
		{
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
