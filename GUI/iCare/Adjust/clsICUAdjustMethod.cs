using System;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace com.digitalwave.AdjustByDept
{
	/// <summary>
	/// ICU调整
	/// </summary>
	public class clsICUAdjustMethod : infAdjustMethod
	{
		public clsICUAdjustMethod()
		{			
		}

		/// <summary>
		/// 调整时间控件的宽度
		/// </summary>
		/// <param name="m_dtpDateTimePick">时间控件</param>
		public void m_mthAdjuestDateTimePick(ref ctlTimePicker p_dtpDateTimePick)
		{
			p_dtpDateTimePick.Width = 188;
		}

		/// <summary>
		/// 调整打印时间格式
		/// </summary>
		/// <param name="m_dtmDate">打印时间</param>
		public string m_strAdjustPrintDate(DateTime p_dtmDate)
		{
			return p_dtmDate.ToString("yyyy-MM-dd HH:mm");
		}
	}
}
