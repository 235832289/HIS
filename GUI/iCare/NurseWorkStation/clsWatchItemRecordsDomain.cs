using System;
using iCareData;
using com.digitalwave.clsWatchItemTrackService;
using com.digitalwave.clsRecordsService;
namespace iCare
{
	/// <summary>
	/// Summary description for clsWatchItemRecordsDomain.
	/// Alex 2003-5-14
	/// 用于观察项目记录单的Domain层
	/// </summary>
	public class clsWatchItemRecordsDomain	: clsRecordsDomain
	{
		/// <summary>
		///  构造函数。参数为指定的中间件。
		/// </summary>
		/// <param name="p_objRecordsServ"></param>
        public clsWatchItemRecordsDomain(enmRecordsType p_enmRecordsType)
            : base(p_enmRecordsType)
		{
			
		}

		public long m_lngGetRecordContent(string p_strInPatientID,
			string p_strInPatientDate,
			string p_strOpenDate,
			out clsWatchItemDataInfo p_objTansDataInfo)
		{
            clsWatchItemTrackService m_objServ =
                (clsWatchItemTrackService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsWatchItemTrackService));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetRecordContent(p_strInPatientID,
                    p_strInPatientDate,
                    p_strOpenDate,
                    out p_objTansDataInfo);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

	}
}
