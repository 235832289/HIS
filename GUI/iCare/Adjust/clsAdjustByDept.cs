using System;
using iCare;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace com.digitalwave.AdjustByDept
{
	/// <summary>
	/// 根据科室进行调整
	/// </summary>
	public class clsAdjustByDept
	{
//		private clsDepartment m_objDept;

		private infAdjustMethod m_objAdjustMethod;

		/// <summary>
		/// 根据员工所在部门，生成对应的infAdjustMethod实例
		/// </summary>
		/// <param name="p_objDept">员工所在部门</param>
		public clsAdjustByDept(clsDepartment p_objDept)
		{
			switch(p_objDept.m_StrDeptID)
			{
				case "1110000" :
					m_objAdjustMethod =  new clsEBHKAdjustMethod();
					break;
				case "1560000" :
					m_objAdjustMethod = new clsICUAdjustMethod();
					break;
			}
		}
		
		/// <summary>
		/// 根据员工所在科室和传入的窗体，修改窗体上所有时间控件的格式
		/// </summary>
		/// <param name="p_objForm">传入的窗体</param>
		public void m_mthAdjustDateTimePick(Form p_objForm)//form是object,也就是ref type,故无须加ref
		{
			foreach(Control ctlSub in p_objForm.Controls)
			{
				m_mthAdustDateTimePick(ctlSub);			
			}
		}

		/// <summary>
		/// 根据员工所在科室，改变相应的时间格式
		/// </summary>
		/// <param name="p_dtmDate">时间</param>
		/// <returns></returns>
		public string m_strAdjustPrintDate(DateTime p_dtmDate)
		{
			return m_objAdjustMethod.m_strAdjustPrintDate(p_dtmDate);	
		}

		/// <summary>
		/// 利用递归调用，设置窗体上每个时间控件的宽度
		/// </summary>
		/// <param name="p_ctlControl"></param>
		public void m_mthAdustDateTimePick(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlTimePicker")
			{
				ctlTimePicker ctlTP = (ctlTimePicker)p_ctlControl;
				m_objAdjustMethod.m_mthAdjuestDateTimePick(ref ctlTP);
			}

			foreach(Control ctlSub in p_ctlControl.Controls)
			{
				m_mthAdustDateTimePick(ctlSub);
			}
		}
	}
}
