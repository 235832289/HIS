using System;
using System.Collections;

namespace iCare.RecordSearch.SearchInfoBuilder
{
	/// <summary>
	/// 根据用户的条件组合查询信息
	/// </summary>
	public class clsSearchInfoBuilderBase
	{
		/// <summary>
		/// 生成查询信息
		/// </summary>
		/// <param name="p_objFormInfo">表单信息</param>
		/// <param name="p_objConditionStatusEnumerator">查询条件</param>
		/// <returns></returns>
		public virtual iCareData.clsRecordSearch_SearchInfo m_objBuildSearchInfo(RecordSearch.clsRecordSearchDomain.clsFormInfo p_objFormInfo,IEnumerator p_objConditionStatusEnumerator)
		{
			return null;
		}

		/// <summary>
		/// 查询生成者名称
		/// </summary>
		public virtual string m_StrBuildType
		{
			get
			{
				return "none";
			}
		}		
	}
}