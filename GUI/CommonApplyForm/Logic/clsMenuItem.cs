using System;

namespace com.digitalwave.GLS_WS.Logic
{
	/// <summary>
	/// clsMenuItem 的摘要说明。
	/// </summary>
	public class clsMenuItem :System.Windows.Forms.MenuItem
	{
		private object tag = null;

		public object Tag
		{
			get { return tag;}
			set { tag = value;}
		}

		public clsMenuItem(string menuText) : base(menuText)
		{
				
		}


	}
}
