using System;

namespace iCare
{
	/// <summary>
	/// Summary description for clsListBoxSearchItem.
	/// </summary>
	public class clsListBoxSearchItem
	{
		public clsListBoxSearchItem(string p_strName,string p_strPY)
		{
			m_strName = p_strName;
			m_strPY = p_strPY;
		}

		private string m_strName,m_strPY;

		public string m_StrName
		{
			get {return m_strName;}
		}

		public string m_StrPY
		{
			get {return m_strPY;}
		}

		public override string ToString()
		{
			return m_strName;
		}
	}
}
