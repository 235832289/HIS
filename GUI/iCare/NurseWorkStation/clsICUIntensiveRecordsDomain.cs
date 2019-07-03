using System;
using iCareData;
using com.digitalwave.clsRecordsService;
using com.digitalwave.clsICUIntensiveTrackService;


namespace iCare
{
	/// <summary>
	/// Summary description for clsICUIntensiveRecordsDomain.
	/// 蔡沐忠 2003-7-7
	/// 用于危重特护的Domain层
	/// </summary>
	public class clsICUIntensiveRecordsDomain : clsRecordsDomain
	{
		/// <summary>
		///  构造函数。参数为指定的中间件。
		/// </summary>
		/// <param name="p_objRecordsServ"></param>
        public clsICUIntensiveRecordsDomain(enmRecordsType p_enmRecordsType)
            : base(p_enmRecordsType)
		{
		}

		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			out clsICUIntensiveTendDataInfo p_objTansDataInfo)
		{
            long lngResult = 0;
            clsICUIntensiveTrackService m_objServ =
                (clsICUIntensiveTrackService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsICUIntensiveTrackService));

            try
            {
                lngResult = m_objServ.m_lngGetRecordContent(p_strInPatientID,
                p_strInPatientDate,
                p_strOpenDate,
                out p_objTansDataInfo);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngResult;	
		}
	}
}
