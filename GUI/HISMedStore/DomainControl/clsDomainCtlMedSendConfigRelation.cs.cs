using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 领域层
	///发药窗口与配药窗口的关系 的摘要说明。
	///  Create by xgpeng 2006-02-15
	/// </summary>
	public class clsDomainCtlMedSendConfigRelation : clsDomainController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsDomainCtlMedSendConfigRelation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 获得药房信息(名称)
		/// <summary>
		/// 获得药房信息(名称)
		/// </summary>
		/// <param name="p_dtable"></param>
		/// <returns></returns>
		public long m_lngGetMedStoreInfo(out DataTable p_dtable)
		{
			long lngRes = 0;			
			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

			lngRes = objSvc.m_lngGetMedStoreInfo(objPrincipal,out p_dtable);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 根据药房ID获取药房窗口信息 
		/// <summary>
		/// 根据药房ID获取药房窗口信息 
		/// </summary>
		/// <param name="p_TypeID">窗口ID</param>
		/// <param name="flage">0-发药窗口 ; 1-配药窗口</param>
		/// <param name="p_objResArr"></param>
		/// <returns></returns>
		public long m_lngGetMedWindowInfo(string p_TypeID,int flage,out clsOPMedStoreWin_VO[] p_objResArr)
		{
			long lngRes = 0;			

			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

			lngRes = objSvc.m_lngGetMedWindowInfo(objPrincipal,p_TypeID,flage,out p_objResArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 根据配药窗口ID获取配药窗口->发药窗口 信息   
		/// <summary>
		/// 根据配药窗口ID获取配药窗口->发药窗口 信息   
		/// </summary>
		/// <param name="p_WinID"></param>
		/// <param name="p_objResArr"></param>
		/// <returns></returns>
		public long m_lngGetMedWinByID(string p_WinID,out clsMedSendConfig_VO[] p_objResArr)
		{
			long lngRes = 0;			

			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));
			lngRes = objSvc.m_lngGetMedWinByID(objPrincipal,p_WinID,out p_objResArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 新增 配药窗口->发药窗口 关系
	/// <summary>
	/// 新增 配药窗口->发药窗口 关系
	/// </summary>
	/// <param name="p_intSeq">流水号</param>
	/// <param name="p_objWinArr"></param>
	/// <returns></returns>
		public long m_lngAddMedSendGiveRelation(out int p_intSeq,clsMedSendConfig_VO p_objWinArr)
		{
			long lngRes = 0;			

			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));
			lngRes = objSvc.m_lngAddMedSendGiveRelation(objPrincipal,out p_intSeq,p_objWinArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 删除 配药窗口->发药窗口 关系
		/// <summary>
		/// 删除 配药窗口->发药窗口 关系
		/// </summary>
		/// <param name="p_intID">流水号</param>
		/// <returns></returns>
		public long m_thDelMedSendGiveRelation(int p_intID)
		{
			long lngRes = 0;			

			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));
			lngRes = objSvc.m_thDelMedSendGiveRelation(objPrincipal,p_intID);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
        
		#region 保存 批量移动记录
		/// <summary>
		/// 保存 批量移动记录
		/// </summary>
		/// <param name="p_objWinArr"></param>
		/// <returns></returns>
		public long m_lngUpdateMovRecord(clsMedSendConfig_VO[] p_objWinArr)
		{
			long lngRes = 0;			

			clsMedSendConfigRelation_SVC objSvc = 
				(clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));
			lngRes = objSvc.m_lngUpdateMovRecord(objPrincipal,p_objWinArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion


	}
}
