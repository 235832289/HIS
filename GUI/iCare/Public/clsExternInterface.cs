using System;
using System.Reflection;

namespace iCare
{
	/// <summary>
	/// 与外部接口的交互
	/// </summary>
	public class clsExternInterface
	{
		public clsExternInterface()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region PACS
		/// <summary>
		/// 生成PACS登记单，未审核
		/// </summary>
		/// <returns></returns>
		public long m_lngGeneratePACSBookIn()
		{
			return 1;
		}
		#endregion

		#region LIS
		/// <summary>
		/// 调用检验申请单
		/// </summary>
		public void m_mthInvokeLISApplyRecord(string p_strInPatientID)
		{
			
		}

		/// <summary>
		/// 调用检验报告单
		/// </summary>
		public void m_mthInvokeLISReportRecord(string p_strInPatientID)
		{
			Assembly asm = Assembly.LoadFrom("LIS_GUI.dll");
			object obj = asm.CreateInstance("com.digitalwave.iCare.gui.LIS.frmReportQuery");
			Type type = obj.GetType();
			MethodInfo mi = type.GetMethod("m_mthQueryReports");
			mi.Invoke(obj,new string[]{"3",null,p_strInPatientID,null,null,null,null,null});
		}
		#endregion

		#region 医嘱
		#endregion

		#region 麻醉
		#endregion

	}
}
