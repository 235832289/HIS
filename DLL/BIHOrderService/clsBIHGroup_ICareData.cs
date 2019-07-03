using System;

namespace com.digitalwave.iCare.ValueObject
{
	/// <summary>
	/// 医嘱组套Vo类
	/// </summary>
	public class clsBIHOrderGroup2
	{
		/// <summary>
		/// 组套流水号
		/// </summary>
		public string m_strGroupID="";
		/// <summary>
		/// 组套名称
		/// </summary>
		public string m_strName="";
		/// <summary>
		/// 描述
		/// </summary>
		public string m_strDes="";
		/// <summary>
		/// 创建者
		/// </summary>
		public string m_strCreatorID="";
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime m_dtCreate=clsBIHOrder.m_dtNullDate;
		/// <summary>
		/// 共享类型
		/// </summary>
		public int m_intShareType=0;
		/// <summary>
		/// 五笔码
		/// </summary>
		public string m_strWBCode="";
		/// <summary>
		/// 拼音码
		/// </summary>
		public string m_strPYCode="";
	}


}
