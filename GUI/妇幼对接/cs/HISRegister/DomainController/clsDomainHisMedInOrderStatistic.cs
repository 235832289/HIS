using System;
using System.Data;
//using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS
{
	#region 药库入库单统计业务控制类 ：created by weiling.huang  at 2005-9-14
	/// <summary>
	/// clsDomainHisMedInOrderStatistic 的摘要说明。
	/// </summary>
	public class clsDomainHisMedInOrderStatistic : clsDomainController_Base//GUI_Base.dll
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainHisMedInOrderStatistic()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region  获得系统时间
		/// <summary>
		/// 获得系统时间 Create 黄伟灵 by 2005-09-13
		/// <summary>
		/// <returns>DateTime</returns>
		public  DateTime m_dtmGetServerDate()
		{			
			com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc));
			return  objSvc.m_dtmGetServerDate();
						
		}
		#endregion

		#region 按时间统计药库入库情况 
		/// <summary>
		/// 按时间统计药库入库情况
		/// </summary>
		/// <param name="p_strPeriodId">查询账务期ID</param>
		/// <param name="p_dtb">查询得到的结果</param>
		/// <returns></returns>
		public long m_lngGetStatiticsData(out DataTable p_dtb, string p_strPeriodId)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc));
            lngRes = objSvc.m_lngGetStatiticsData(objPrincipal, out p_dtb, p_strPeriodId);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 获取账务期
		/// <summary>
		/// 获取账务期
		/// </summary>
		/// <param name="p_dtb">查询得到的结果</param>
		/// <returns></returns>
		public long m_lngGetPeriodList(out clsPeriod_VO[] p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisMedInOrderStatisticSvc));
            lngRes = objSvc.m_lngGetPeriodList(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion


	}
	#endregion

}
