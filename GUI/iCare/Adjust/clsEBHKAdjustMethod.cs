using System;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace com.digitalwave.AdjustByDept
{
	/// <summary>
	/// 耳鼻喉科调整
	/// </summary>
	public class clsEBHKAdjustMethod : infAdjustMethod
	{
		public clsEBHKAdjustMethod()
		{			
		}

		/// <summary>
		/// 调整时间控件的宽度
		/// </summary>
		/// <param name="m_dtpDateTimePick"></param>
		public void m_mthAdjuestDateTimePick(ref ctlTimePicker p_dtpDateTimePick)
		{
			p_dtpDateTimePick.Width = 140;
		}

		/// <summary>
		/// 调整打印时间格式
		/// </summary>
		/// <param name="m_dtmDate"></param>
		public string m_strAdjustPrintDate(DateTime p_dtmDate)
		{
			return p_dtmDate.ToString("yyyy-MM-dd 00:00:00");
		}
	}
}
