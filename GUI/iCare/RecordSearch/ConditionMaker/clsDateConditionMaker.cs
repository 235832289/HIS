using System;
using com.digitalwave.Utility.SQLConvert;

namespace iCare.RecordSearch.ConditionMaker
{
	/// <summary>
	/// Summary description for clsDateConditionMaker.
	/// </summary>
	public class clsDateConditionMaker : clsConditionMakerBase
	{
		protected override void m_mthHandleRecordSearchFormSet()
		{
			string [] strTypeArr = new string[]{"日期范围","日期是"};
			m_frmRecordSearch.m_cboDateConditionType.AddRangeItems(strTypeArr);	
			m_frmRecordSearch.m_cboDateConditionType.SelectedIndex = 0;
		
			m_frmRecordSearch.m_cboDateConditionType.SelectedIndexChanged += new EventHandler(m_mthHandleConditionTypeChanged);
		}

		private void m_mthHandleConditionTypeChanged(object p_objSender,EventArgs p_objArg)
		{
			switch(m_frmRecordSearch.m_cboDateConditionType.SelectedIndex)
			{
				case 0://"日期范围"
					m_frmRecordSearch.m_lblDateFrom.Visible = true;
					m_frmRecordSearch.m_lblDateTo.Visible = true;
					m_frmRecordSearch.m_dtpSecond.Visible = true;
					m_frmRecordSearch.m_dtpSecond.Value = m_frmRecordSearch.m_dtpFirst.Value;
					break;
				default:
					m_frmRecordSearch.m_lblDateFrom.Visible = false;
					m_frmRecordSearch.m_lblDateTo.Visible = false;
					m_frmRecordSearch.m_dtpSecond.Visible = false;
					break;
			}
		}

		private string m_strGetConditionSQL()
		{
			string strText = null;
			switch(m_frmRecordSearch.m_cboDateConditionType.SelectedIndex)
			{
				case 0://"日期范围"
					strText = " ("+m_strConditionField+" between "+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_frmRecordSearch.m_dtpFirst.Value.ToString("yyyy-MM-dd HH:mm:ss"))+" and "+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_frmRecordSearch.m_dtpSecond.Value.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"))+") ";
					break;
				case 1://"日期是"
					strText = " ("+m_strConditionField+"= "+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(m_frmRecordSearch.m_dtpFirst.Value.ToString("yyyy-MM-dd HH:mm:ss"))+") ";
					break;			
				
			}
			return strText;
		}

		private string m_strGetConditionDesc()
		{
			string strText = null;
			switch(m_frmRecordSearch.m_cboDateConditionType.SelectedIndex)
			{
				case 0://"日期范围"
					strText = "日期从"+m_frmRecordSearch.m_dtpFirst.Text.Trim()+"到"+m_frmRecordSearch.m_dtpSecond.Text.Trim();
					break;
				case 1://"日期是"
					strText = "日期是"+m_frmRecordSearch.m_dtpFirst.Text.Trim();
					break;			
				
			}
			return strText;
		}

		public override void m_mthResetConditionInput()
		{			
			m_frmRecordSearch.m_lblDateFrom.Visible = true;
			m_frmRecordSearch.m_dtpFirst.Value = DateTime.Today;
			m_frmRecordSearch.m_lblDateTo.Visible = true;
			m_frmRecordSearch.m_dtpSecond.Visible = true;
			m_frmRecordSearch.m_dtpSecond.Value = m_frmRecordSearch.m_dtpFirst.Value;

			m_frmRecordSearch.m_cboDateConditionType.SelectedIndex = 0;
		}

		public override iCare.RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus m_ObjStatus
		{
			get
			{
				clsDateConditionStatus objStatus = new clsDateConditionStatus();
				objStatus.m_intTypeIndex = m_frmRecordSearch.m_cboDateConditionType.SelectedIndex;
				objStatus.m_dtmFirstDateValue = m_frmRecordSearch.m_dtpFirst.Value;
				objStatus.m_dtmSecondDateValue = m_frmRecordSearch.m_dtpSecond.Value;
				objStatus.m_strConditionSQL = m_strGetConditionSQL();
				objStatus.m_strConditionDesc = m_strGetConditionDesc();

				return objStatus;
			}
			set
			{
				clsDateConditionStatus objStatus = value as clsDateConditionStatus;
                    
				if(objStatus != null)
				{
					m_frmRecordSearch.m_dtpFirst.Value = objStatus.m_dtmFirstDateValue;
					m_frmRecordSearch.m_dtpSecond.Value = objStatus.m_dtmSecondDateValue;
					m_frmRecordSearch.m_cboDateConditionType.SelectedIndex = objStatus.m_intTypeIndex;
				}				
			}
		}

		/// <summary>
		/// 记录日期条件项的的状态
		/// </summary>
		public class clsDateConditionStatus : clsConditionMakerBase.clsConditionStatus
		{
			public int m_intTypeIndex;

			public DateTime m_dtmFirstDateValue;

			public DateTime m_dtmSecondDateValue;
		}
	}
}
