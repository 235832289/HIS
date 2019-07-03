using System;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for infPrintRecord.
	/// </summary>
	/// <summary>
	/// 统一的打印接口
	/// </summary>
	public interface infPrintRecord
	{
		/// <summary>
		/// 从数据库初始化打印内容。如果没有记录，打印空报表。
		/// </summary>
		void m_mthInitPrintContent();
		
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
