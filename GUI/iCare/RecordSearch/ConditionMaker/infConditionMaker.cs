using System;

namespace iCare.RecordSearch.ConditionMaker
{	
	/// <summary>
	/// 为其他条件生成者提供默认实现
	/// </summary>
	public class clsConditionMakerBase 
	{
		protected iCare.frmRecordSearch m_frmRecordSearch;
		protected string m_strConditionField;
	
		/// <summary>
		/// 设置记录查询窗体
		/// </summary>
		/// <param name="p_frmRecordSearch"></param>
		public void m_mthSetRecordSearchForm(iCare.frmRecordSearch p_frmRecordSearch)
		{
			if(p_frmRecordSearch == null)
				return; 

			m_frmRecordSearch = p_frmRecordSearch;

			m_mthHandleRecordSearchFormSet();
		}

		/// <summary>
		/// 设置查询条件的字段
		/// </summary>
		/// <param name="p_strConditionField"></param>
		public void m_mthSetConditionField(string p_strConditionField)
		{
			if(p_strConditionField == null)
				return;

			m_strConditionField = p_strConditionField;
		}		

		/// <summary>
		/// 重置查询条件的输入
		/// </summary>
		public virtual void m_mthResetConditionInput()
		{
			
		}	
		/// <summary>
		/// 在记录查询窗体设置后进行处理
		/// </summary>
		/// <param name="p_frmRecordSearch"></param>
		protected virtual void m_mthHandleRecordSearchFormSet()
		{
		}
		/// <summary>
		/// 检查条件。可以在实现中对错误的条件作提醒。
		/// </summary>
		/// <returns></returns>
		public virtual bool m_blnCheckCondition()
		{
			return true;
		}

		public virtual clsConditionStatus m_ObjStatus
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public class clsConditionStatus
		{
			/// <summary>
			/// 查询条件SQL
			/// </summary>
			public string m_strConditionSQL;

			/// <summary>
			/// 查询条件描述
			/// </summary>
			public string m_strConditionDesc;

			public string m_strPreDesc = "";

			public int m_intFieldIndex;

			public override string ToString()
			{
				return m_strPreDesc+m_strConditionDesc;
			}
		}
	}
}
