using System;
using System.Diagnostics;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsHelpFile 的摘要说明。
	/// </summary>
	public class clsHelpFile
	{
		public clsHelpFile()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void m_mthShowHelp()
		{
			try
			{
				Process.Start("Help/HelpFile.chm");
			}
			catch
			{
			System.Windows.Forms.MessageBox.Show("找不到帮助文件!","ICare");
			}
		}
	}
	/// <summary>
	/// 显示计算器
	/// </summary>
	public class clsShowCalc
	{
		public clsShowCalc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public void m_mthShowCalc()
		{
			try
			{
				foreach(Process p in Process.GetProcesses())
				{
					if(p.ProcessName.Trim()=="calc")
					{
					return;
					}
				}
				System.Diagnostics.Process.Start("calc.exe");
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("计算器不可用!","iCare系统温馨提示:");
			}
		}
	}
}
