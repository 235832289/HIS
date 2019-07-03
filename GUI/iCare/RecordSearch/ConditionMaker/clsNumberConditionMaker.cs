using System;

namespace iCare.RecordSearch.ConditionMaker
{
	/// <summary>
	/// Summary description for clsNumberConditionMaker.
	/// </summary>
	public class clsNumberConditionMaker : clsConditionMakerBase
	{
		
		protected override void m_mthHandleRecordSearchFormSet()
		{
			string [] strTypeArr = new string[]{"范围","大于","大于等于","小于","小于等于","等于","不等于"};
			m_frmRecordSearch.m_cboNumberConditionType.AddRangeItems(strTypeArr);

			m_frmRecordSearch.m_cboNumberConditionType.SelectedIndexChanged += new EventHandler(m_mthHandleConditionTypeChanged);
		}

		private void m_mthHandleConditionTypeChanged(object p_objSender,EventArgs p_objArg)
		{
			switch(m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex)
			{
				case 0://"范围"
					m_frmRecordSearch.m_lblNumberTo.Visible = true;
					m_frmRecordSearch.m_txtNumberTo.Visible = true;
					m_frmRecordSearch.m_txtNumberTo.Text = "";
					break;
				default:
					m_frmRecordSearch.m_lblNumberTo.Visible = false;
					m_frmRecordSearch.m_txtNumberTo.Visible = false;
					break;
			}
		}

		private string m_strGetConditionSQL()
		{
			string strText = null;
			switch(m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex)
			{
				case 0://"范围"
					strText = " ("+m_strConditionField+" between '"+m_frmRecordSearch.m_txtNumberFrom.Text+"' and '"+m_frmRecordSearch.m_txtNumberTo.Text+"') ";
					break;
				case 1://"大于"
					strText = " ("+m_strConditionField+"> '"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				case 2://"大于等于"
					strText = " ("+m_strConditionField+">='"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				case 3://"小于"
					strText = " ("+m_strConditionField+"< '"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				case 4://"小于等于"
					strText = " ("+m_strConditionField+"<= '"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				case 5://"等于"
					strText = " ("+m_strConditionField+"= '"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				case 6://"不等于"
					strText = " ("+m_strConditionField+"!= '"+m_frmRecordSearch.m_txtNumberFrom.Text+"') ";
					break;
				
			}
			return strText;
		}

		private string m_strGetConditionDesc()
		{
			string strText = null;
			switch(m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex)
			{
				case 0://"范围"
					strText = "范围在"+m_frmRecordSearch.m_txtNumberFrom.Text+"～"+m_frmRecordSearch.m_txtNumberTo.Text;
					break;
				default:
					strText = m_frmRecordSearch.m_cboNumberConditionType.Text+m_frmRecordSearch.m_txtNumberFrom.Text;
					break;
			}
			return strText;
		}

		public override bool m_blnCheckCondition()
		{
			switch(m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex)
			{
				case 0://"范围"
					if(!m_blnIsNumber(m_frmRecordSearch.m_txtNumberFrom.Text))
					{
						clsPublicFunction.ShowInformationMessageBox("请输入数值");
						m_frmRecordSearch.m_txtNumberFrom.Focus();
						return false;
					}
					if(!m_blnIsNumber(m_frmRecordSearch.m_txtNumberTo.Text))
					{
						clsPublicFunction.ShowInformationMessageBox("请输入数值");
						m_frmRecordSearch.m_txtNumberTo.Focus();
						return false;
					}
					return true;
				default:
					if(!m_blnIsNumber(m_frmRecordSearch.m_txtNumberFrom.Text))
					{
						clsPublicFunction.ShowInformationMessageBox("请输入数值");
						m_frmRecordSearch.m_txtNumberFrom.Focus();
						return false;
					}
					return true;
			}			
		}
		private bool m_blnIsNumber(string p_strTextToCheck)
		{
			try
			{
				Decimal.Parse(p_strTextToCheck.Trim());				
			}
			catch
			{
				return false;
			}
			
			return true;
		}

		public override void m_mthResetConditionInput()
		{
			m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex = 0;
			m_frmRecordSearch.m_lblNumberFrom.Visible = true;
			m_frmRecordSearch.m_lblNumberTo.Visible = true;
			m_frmRecordSearch.m_txtNumberFrom.Visible = true;
			m_frmRecordSearch.m_txtNumberFrom.Text = "";
			m_frmRecordSearch.m_txtNumberTo.Visible = true;
			m_frmRecordSearch.m_txtNumberTo.Text = "";
		}

		public override iCare.RecordSearch.ConditionMaker.clsConditionMakerBase.clsConditionStatus m_ObjStatus
		{
			get
			{
				clsNumberConditionStatus objStatus = new clsNumberConditionStatus();
				objStatus.m_intTypeIndex = m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex;
				objStatus.m_strFromValue = m_frmRecordSearch.m_txtNumberFrom.Text;
				objStatus.m_strToValue = m_frmRecordSearch.m_txtNumberTo.Text;
				objStatus.m_strConditionSQL = m_strGetConditionSQL();
				objStatus.m_strConditionDesc = m_strGetConditionDesc();
				
				return objStatus;
			}
			set
			{
				clsNumberConditionStatus objStatus = value as clsNumberConditionStatus;
                    
				if(objStatus != null)
				{
					m_frmRecordSearch.m_txtNumberFrom.Text = objStatus.m_strFromValue;
					m_frmRecordSearch.m_txtNumberTo.Text = objStatus.m_strToValue;
					m_frmRecordSearch.m_cboNumberConditionType.SelectedIndex = objStatus.m_intTypeIndex;
				}	
			}
		}

		/// <summary>
		/// 记录数值条件项的的状态
		/// </summary>
		public class clsNumberConditionStatus : clsConditionMakerBase.clsConditionStatus
		{
			public int m_intTypeIndex;

			public string m_strFromValue;

			public string m_strToValue;
		}
	}
}
