using System;
using iCareData;
using System.Text;

namespace iCare
{
	/// <summary>
	/// 代表病程记录的信息，用于病程记录窗体与各特殊记录窗体相联系。
	/// 由于各记录特殊有各自的信息，使用抽象函数做信息交换的载体。
	/// </summary>
	public abstract class clsDiseaseTrackInfo	: IComparable
	{

		/// <summary>
		/// 特殊记录的标题
		/// </summary>
		protected string m_strTitle;

		/// <summary>
		/// 特殊记录的日期
		/// </summary>
		protected DateTime m_dtmRecordTime;

		/// <summary>
		/// 特殊记录的内容
		/// </summary>
		protected clsTrackRecordContent m_objRecordContent;

		protected StringBuilder m_sbdTemp = new StringBuilder();

		/// <summary>
		/// 比较参数值与当前实例的大小
		/// </summary>
		/// <param name="p_objValue"></param>
		/// <returns></returns>
		public int CompareTo(object p_objValue)
		{
			clsDiseaseTrackInfo objDiff = (clsDiseaseTrackInfo)p_objValue;

			if(this.m_objRecordContent.m_dtmCreateDate == objDiff.m_objRecordContent.m_dtmCreateDate)
				return 0;
			else if(this.m_objRecordContent.m_dtmCreateDate > objDiff.m_objRecordContent.m_dtmCreateDate)
				return 1;
			else 
				return -1;
		}

		/// <summary>
		/// 特殊记录标题的获取和设置
		/// </summary>
		public string m_StrTitle
		{
			get
			{
				return m_strTitle;
			}
			set
			{
				m_strTitle=value;
			}
		}
		/// <summary>
		/// 特殊记录日期的获取和设置
		/// </summary>
		public DateTime m_DtmRecordTime
		{
			get
			{
				return m_dtmRecordTime;
			}
			set
			{
				m_dtmRecordTime=value;
			}
		}
		/// <summary>
		/// 特殊记录内容的获取和设置
		/// </summary>
		public clsTrackRecordContent m_ObjRecordContent
		{
			get
			{
				return m_objRecordContent;
			}
			set
			{
				m_objRecordContent=value;
			}
		}
		/// <summary>
		/// 特殊记录内容文本的获取。
		/// </summary>
		/// <returns></returns>
		public abstract string m_strGetTrackText();

		/// <summary>
		/// 特殊记录内容格式Xml的获取
		/// </summary>
		/// <returns></returns>
		public abstract string m_strGetTrackXml();

		/// <summary>
		/// 特殊记录内容签名的获取。
		/// </summary>
		/// <returns></returns>
		public virtual string m_strGetSignText()
		{
			return "";
		}

		/// <summary>
		/// 特殊记录内容签名Xml的获取
		/// </summary>
		/// <returns></returns>
		public virtual string m_strGetSignXml()
		{
			return "";
		}

		/// <summary>
		/// 特殊记录类型的获取
		/// </summary>
		/// <returns></returns>
		public abstract enmDiseaseTrackType m_enmGetTrackType();
		/// <summary>
		///  控制分页（0＝不分页；1＝从此记录起分页）
		/// </summary>
		private string m_strPagination = "";
		/// <summary>
		/// 控制分页（0＝不分页；1＝从此记录起分页）
		/// </summary>
		public string m_StrPagination
		{
			get{return m_strPagination;}
			set{m_strPagination = value;}
		}

	}

}
