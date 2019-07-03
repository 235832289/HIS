using System;
using System.Data;
//using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	#region 门诊收费核算分类组成报表
	/// <summary>	
	/// 门诊收费核算分类组成报表
	/// Create 黄伟灵 by 2005-09-13
	/// </summary>
	public class clsDomainControlOutPatient : clsDomainController_Base//GUI_Base.dll
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainControlOutPatient()
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
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc));
			return  objSvc.m_dtmGetServerDate();
						
		}
		#endregion

		#region 按时间统计收费 
		/// <summary>
		/// 按时间统计收费
		/// </summary>
		/// <param name="p_dtm1">开始时间</param>
		/// <param name="p_dtm2">结束时间</param>
		/// <param name="p_dtb">查询得到的结果</param>
		/// <returns></returns>
		public long m_lngGetStatiticsData(string p_dtm1,string p_dtm2,out DataTable p_dtb)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutPatientSvc));
			lngRes = objSvc.m_lngGetStatiticsData(objPrincipal,p_dtm1, p_dtm2, out p_dtb);
			return lngRes;
		}
		#endregion

	}
	#endregion

}
