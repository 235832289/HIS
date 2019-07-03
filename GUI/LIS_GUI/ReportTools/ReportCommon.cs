using System;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	public class clsGroup
	{
		public string m_strGroupName;
		public DataView m_dtvGroupData;
	}
	
    /// <summary>
    /// ¥Ú”°ƒ⁄»›¿‡
    /// </summary>
	[Serializable]
	public class clsPrintValuePara
	{
		public DataTable m_dtbBaseInfo;
		public DataTable m_dtbResult;
		public string m_strTitle;
	}
}