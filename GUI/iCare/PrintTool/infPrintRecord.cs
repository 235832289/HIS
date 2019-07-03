using System;

namespace iCare
{
	/// <summary>
	/// 统一的打印接口
	/// </summary>
	public interface infPrintRecord
	{
		/// <summary>
		/// 设置打印信息
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_dtmInPatientDate">入院日期</param>
		/// <param name="p_dtmOpenDate">OpenDate，如果是一次打印多次记录表单的类型（如病案记录），忽略OpenDate</param>
		void m_mthSetPrintInfo(clsPatient p_objPatient,DateTime p_dtmInPatientDate,DateTime p_dtmOpenDate);

		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。
		/// </summary>
		void m_mthInitPrintContent();

		/// <summary>
		/// 设置打印内容。当数据已经存在时使用。
		/// </summary>
		/// <param name="p_objPrintContent">打印内容</param>
		void m_mthSetPrintContent(object p_objPrintContent);

		/// <summary>
		/// 获取打印内容
		/// </summary>
		/// <returns>打印内容</returns>
		object m_objGetPrintInfo();
		
		/// <summary>
		/// 初始化打印变量
		/// </summary>
		/// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
		void m_mthInitPrintTool(object p_objArg);

		/// <summary>
		/// 释放打印变量
		/// </summary>
		/// <param name="p_objArg">外部使用到的变量，根据不同的实现使用</param>
		void m_mthDisposePrintTools(object p_objArg);

		/// <summary>
		/// 打印开始
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		void m_mthBeginPrint(object p_objPrintArg);

		/// <summary>
		/// 打印中
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		void m_mthPrintPage(object p_objPrintArg);

		/// <summary>
		/// 打印结束。一般使用它来更新数据库信息。
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		void m_mthEndPrint(object p_objPrintArg);
	}
}
