using System;
using iCareData;
namespace iCare
{
	/// <summary>
	///  观察项目记录单信息。
	/// </summary>
	public class clsWatchItemRecordInfo	: clsDiseaseTrackInfo
	{

		/// <summary>
		///  特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackText()
		{
			return "";
		}

		/// <summary>
		///  特殊记录内容格式Xml的获取
		/// </summary>
		/// <returns></returns>
		public override string m_strGetTrackXml()
		{
			return "";
		}

		/// <summary>
		///  特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public override enmDiseaseTrackType m_enmGetTrackType()
		{
			return enmDiseaseTrackType.WatchItem;
		}

	}// END CLASS DEFINITION clsWatchItemRecordInfo

}
