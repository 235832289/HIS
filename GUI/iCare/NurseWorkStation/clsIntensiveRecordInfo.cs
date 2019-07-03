using System;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsIntensiveRecordInfo.
	/// </summary>
	public class clsIntensiveRecordInfo : clsDiseaseTrackInfo
	{
		#region  特殊记录内容文本的获取。,刘颖源,2003-5-13 14:21:05
		public override string m_strGetTrackText()
		{
            if (m_objRecordContent == null)
                return "";
            return ((clsIntensiveTendRecordContent1)m_objRecordContent).m_strRecordContent;
		}
		#endregion

		#region 特殊记录内容格式Xml的获取,刘颖源,2003-5-13 14:21:05
		public override string m_strGetTrackXml()
		{
			if(m_objRecordContent==null)
				return "";
			return ((clsIntensiveTendRecordContent1 )m_objRecordContent).m_strRecordContentXml;
		}
		#endregion

		#region 特殊记录类型的获取,刘颖源,2003-5-13 14:21:05
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.IntensiveTend ;
		}
		#endregion
		
	}
}
