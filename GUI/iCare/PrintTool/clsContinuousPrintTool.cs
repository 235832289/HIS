using System;

namespace iCare
{
	/// <summary>
	/// 续打工具
	/// </summary>
	public class clsContinuousPrintTool
	{		
		private string m_strInPatientID,m_strInPatientDate;

		protected int m_intFromRecord = 0;
		/// <summary>
		/// 从哪一条记录开始打
		/// </summary>
		public int m_IntFromRecord
		{
			set 
			{
				m_intFromRecord = value;
			}
		}

		/// <summary>
		/// 设置续打
		/// </summary>
		public void m_mthSetContinuePrint(string p_strInPatientID,string p_strInPatientDate)
		{
			m_strInPatientID = p_strInPatientID;
			m_strInPatientDate = p_strInPatientDate;
			if(m_strGetRecordType() != "" && m_strGetRecordType() != null)
			{
				//获取上打印到哪条记录
				new clsPrintDateInfo().m_lngGetPrintFromRecord(p_strInPatientID,p_strInPatientDate,m_strGetRecordType(),out m_intFromRecord);
			}
		}

		/// <summary>
		/// 获取记录类型
		/// </summary>
		protected virtual string m_strGetRecordType()
		{
			return "";
		}

		/// <summary>
		/// 上一次打印是否已打印完全部记录
		/// </summary>
		/// <returns></returns>
		public virtual bool m_blnHavePrintAllRecords()
		{
			return false;
		}

		/// <summary>
		/// 保存当前打印到哪条记录
		/// </summary>
		protected void m_mthSavePrintToRecord(int p_intRecord)
		{
			if(m_strInPatientID != null && m_strGetRecordType() != "" && m_strGetRecordType() != null)
				new clsPrintDateInfo().m_lngSavePrintToRecord(m_strInPatientID,m_strInPatientDate,m_strGetRecordType(),p_intRecord);
		}

	}
}
