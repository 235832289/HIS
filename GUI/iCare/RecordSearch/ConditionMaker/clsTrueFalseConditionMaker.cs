using System;

namespace iCare.RecordSearch.ConditionMaker
{
	/// <summary>
	/// Summary description for clsTrueFalseConditionMaker.
	/// </summary>
	public class clsTrueFalseConditionMaker : clsConditionMakerBase
	{		
		private string m_strGetConditionSQL()
		{
			string strVal = m_frmRecordSearch.m_rdbTrueFalseTrue.Checked?"1":"0";
			return " ("+m_strConditionField+" ='"+strVal+"')";
		}

		private string m_strGetConditionDesc()
		{
			string strDesc = m_frmRecordSearch.m_rdbTrueFalseTrue.Checked?
				m_frmRecordSearch.m_rdbTrueFalseTrue.Text:m_frmRecordSearch.m_rdbTrueFalseFalse.Text;

			return strDesc;
		}

		public override void m_mthResetConditionInput()
		{
			m_frmRecordSearch.m_rdbTrueFalseTrue.Checked = true;
		}

		public override iCare.RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus m_ObjStatus
		{
			get
			{
				clsTrueFalseConditionStatus objStatus = new clsTrueFalseConditionStatus();
				objStatus.m_blnValue = m_frmRecordSearch.m_rdbTrueFalseTrue.Checked;
				objStatus.m_strConditionSQL = m_strGetConditionSQL();
				objStatus.m_strConditionDesc = m_strGetConditionDesc();
				
				return objStatus;
			}
			set
			{
				clsTrueFalseConditionStatus objStatus = value as clsTrueFalseConditionStatus;
                    
				if(objStatus != null)
				{					
					m_frmRecordSearch.m_rdbTrueFalseTrue.Checked = objStatus.m_blnValue;
				}	
			}
		}

		/// <summary>
		/// 记录布尔条件项的的状态
		/// </summary>
		public class clsTrueFalseConditionStatus : clsConditionMakerBase.clsConditionStatus
		{
			public bool m_blnValue;
		}
	}
}
