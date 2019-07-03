using System;
using System.Data;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	#region 门诊收费按身份分类统计报表业务控制类 ：created by weiling.huang  at 2005-9-16
	/// <summary>
	///门诊收费按身份分类统计报表业务控制类
	/// <summary>
	public class clsDomainOutpatientChargeIdetityPrint: clsDomainController_Base//GUI_Base.dll
	{
		#region 构造函�?
		public clsDomainOutpatientChargeIdetityPrint()
		{

		}
		#endregion

		#region  方法：获得系统时间：Created by  weiling.huang by 2005-09-16
		/// <summary>
		/// 获得系统时间 Create weiling.huang by 2005-09-16
		/// <summary>
		/// <returns>DateTime</returns>
		public  DateTime m_dtmGetServerDate()
		{
            System.DateTime datResult = System.DateTime.Now;
            string time = "";
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc));
			time = objSvc.m_dtmGetServerDate();
            datResult = System.DateTime.Parse(time);
            return datResult;
						
		}
		#endregion

		#region 方法：获取病人分类的列信息：created by weiling.huang  at 2005-9-16
		/// <summary>
		/// 方法：获取病人分类的列信息：created by weiling.huang  at 2005-9-16
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败�?1 ，成功：所影响的结果数</returns>
		public long m_mthGetPatientCatInfo(	out clsPType_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc));
			lngRes = objSvc.m_mthGetPatientCatInfo(objPrincipal,out p_objResultArr);
			return lngRes;
		}
		#endregion

		#region 方法：获取已结账的收费员的ID与姓名信息：created by weiling.huang  at 2005-9-16
		/// <summary>
		/// 方法：获取已结账的收费员的ID与姓名信息：created by weiling.huang  at 2005-9-16
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败�?1 ，成功：所影响的结果数</returns>
		public long m_mthGetChargeManInfo(	out clsEChargeInfo_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc));
			lngRes = objSvc.m_mthGetChargeManInfo(objPrincipal,out p_objResultArr);
			return lngRes;
		}
		#endregion

		#region 方法：根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等：created by weiling.huang  at 2005-9-19
		/// <summary>
		/// 根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <param name="p_strdtmBegin">查询条件：就诊起始日�?/param>
		/// <param name="p_strdtmEnd">查询条件：就诊终止日�?/param>
		/// <param name="p_strPatientTypeId">查询条件：病人身份类型ID</param>
		/// <param name="p_strEmployeeID">查询条件：收费员ID</param>
		/// <returns>失败�?1 ，成功：所影响的结果数</returns>
		public long m_lngGetDataByTimeIndetityOp(out clsOutPatientTableInfo_VO[] p_objResultArr, string p_strdtmBegin, string p_strdtmEnd, string p_strPatientTypeId, string p_strEmployeeID)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsOutpatientChargeIdetityPrintSvc));
			lngRes = objSvc.m_lngGetDataByTimeIndetityOp(objPrincipal,out p_objResultArr, p_strdtmBegin, p_strdtmEnd, p_strPatientTypeId, p_strEmployeeID);
			return lngRes;
		}
		#endregion

	}
	#endregion
}
