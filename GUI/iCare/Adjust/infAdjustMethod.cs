using System;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace com.digitalwave.AdjustByDept
{
	/// <summary>
	/// 调整时间控件接口
	/// </summary>
	public interface infAdjustMethod
	{
		/// <summary>
		/// 调整时间控件的宽度
		/// </summary>
		/// <param name="m_dtpDateTimePick">时间控件</param>
		void m_mthAdjuestDateTimePick(ref ctlTimePicker p_dtpDateTimePick);

		/// <summary>
		/// 调整打印时间格式
		/// </summary>
		/// <param name="m_dtmDate">打印时间</param>
		string m_strAdjustPrintDate(DateTime p_dtmDate);
	}
}
