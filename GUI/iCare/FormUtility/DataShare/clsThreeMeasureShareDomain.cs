using System;
using System.Data;
using com.digitalwave.DataShareService;

namespace iCare
{
	/// <summary>
	/// Summary description for clsThreeMeasureShareDomain.
	/// </summary>
	public class clsThreeMeasureShareDomain
	{		
        //private clsThreeMeasureShareService m_objServ;

		public clsThreeMeasureShareDomain()
		{
            //m_objServ = new clsThreeMeasureShareService();
		}

		public long m_lngGetFirstValue(string p_strInPaitentID,string p_strInPatientDate, out stuFirstValue p_stuResult)
		{
			p_stuResult = new stuFirstValue();
			p_stuResult.m_strDiastolicValue = "";
			p_stuResult.m_strSystolicValue = "";
			p_stuResult.m_strDiastolicValue2 = "";
			p_stuResult.m_strSystolicValue2 = "";
			p_stuResult.m_strPulseValue = "";
			p_stuResult.m_strTemperatureValue = "";
			p_stuResult.m_strBreathValue = "";

			DataTable dtbResult;

            clsThreeMeasureShareService m_objServ =
                (clsThreeMeasureShareService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureShareService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetFirstValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID, p_strInPatientDate,out dtbResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes <= 0)
				return lngRes;

			if(dtbResult.Rows.Count != 1)
				return 0;

            p_stuResult.m_strDiastolicValue = dtbResult.Rows[0]["DIASTOLICVALUE"].ToString();
			p_stuResult.m_strSystolicValue = dtbResult.Rows[0]["SYSTOLICVALUE"].ToString();
			p_stuResult.m_strDiastolicValue2 = dtbResult.Rows[0]["DIASTOLICVALUE2"].ToString();
			p_stuResult.m_strSystolicValue2 = dtbResult.Rows[0]["SYSTOLICVALUE2"].ToString();
			p_stuResult.m_strPulseValue = dtbResult.Rows[0]["PULSEVALUE"].ToString();
			p_stuResult.m_strTemperatureValue = dtbResult.Rows[0]["TEMPERATUREVALUE"].ToString();
			p_stuResult.m_strBreathValue = dtbResult.Rows[0]["BREATHVALUE"].ToString();

			return 1;
		}


		/// <summary>
		/// 获取最邻近时间的数据
		/// </summary>
		/// <param name="p_strInPaitentID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_dtmCompare"></param>
		/// <param name="p_strResult"></param>
		/// <returns></returns>
		public long m_lngGetNearestValue(string p_strInPaitentID,string p_strInPatientDate, DateTime p_dtmCompare, out string[] p_strResult)
		{
            clsThreeMeasureShareService m_objServ =
                (clsThreeMeasureShareService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsThreeMeasureShareService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetNearestValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID, p_strInPatientDate,p_dtmCompare,out p_strResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 三测表的第一个记录
		/// </summary>
		public struct stuFirstValue
		{
			/// <summary>
			/// 舒张压
			/// </summary>
			public string m_strDiastolicValue;
			/// <summary>
			/// 收缩压
			/// </summary>
			public string m_strSystolicValue;
			/// <summary>
			/// 舒张压2
			/// </summary>
			public string m_strDiastolicValue2;
			/// <summary>
			/// 收缩压2
			/// </summary>
			public string m_strSystolicValue2;
			/// <summary>
			/// 脉搏
			/// </summary>
			public string m_strPulseValue;
			/// <summary>
			/// 体温
			/// </summary>
			public string m_strTemperatureValue;
			/// <summary>
			/// 呼吸
			/// </summary>
			public string m_strBreathValue;
		}
	}
}
