using System;

namespace iCare.RecordSearch.PatientDetailMaker
{
	/// <summary>
	/// 病人详细信息生成者
	/// </summary>
	public class clsPatientDetailMakerBase
	{
		/// <summary>
		/// 获取病人详细信息描述
		/// </summary>
		/// <param name="p_objPatientList"></param>
		/// <returns></returns>
		public virtual string m_strMakerPatientDetailDesc(clsPatient p_objPatient,RecordSearch.clsRecordSearchDomain.clsPatientList p_objPatientList)
		{
			return "";
		}

		public virtual string m_StrFormName
		{
			get
			{
				return "none";
			}
		}
	}
}
