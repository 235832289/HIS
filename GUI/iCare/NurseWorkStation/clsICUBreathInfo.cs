using System;
using iCareData;

namespace iCare
{
	/// <summary>
	///  ICU呼吸机信息。
	/// </summary>
	public class clsICUBreathInfo	: clsDiseaseTrackInfo
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
			return enmDiseaseTrackType.ICUBreath;
		}

	}// END CLASS DEFINITION clsWatchItemRecordInfo
}
