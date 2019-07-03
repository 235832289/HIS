using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomainControl_RegDefine 的摘要说明。
	/// </summary>
	public class clsDomainControl_RegDefine : com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControl_RegDefine()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		// 挂号种类
		#region 查询挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngFindRegType(out clsRegType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc =	(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngFindRegTypeList(objPrincipal, out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngAddRegType(clsRegType_VO p_objResult , out string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDoAddNewRegType(objPrincipal, p_objResult, out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 修改挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngDoUpdRegByID(clsRegType_VO p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDoUpdRegTypeByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 停用挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngIsUseing(string p_strID,string p_Isusering)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngIsUseing(objPrincipal,p_strID,p_Isusering);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngDelRegByID(string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDelRegTypeByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		// 煎制方法
		#region 查询挂号种类 created by Cameron Wong on Aug 9, 2004
		public long m_lngFindCookMethodList(out clsCookMethod_VO[] p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc =	(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngFindCookMethodList(objPrincipal, out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增煎制方法 created by Cameron Wong on Aug 11, 2004
		public long m_lngAddCookMethod(string strName, string strMNemonic, out string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDoAddNewCookMethod(objPrincipal, strName, strMNemonic, out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 修改煎制方法 created by Cameron Wong on Aug 11, 2004
		public long m_lngDoUpdMethodByID(clsCookMethod_VO p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDoUpdMethodByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除煎制方法 created by Cameron Wong on Aug 11, 2004
		public long m_lngDelMethodByID(string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegTypeSvc));
			lngRes = objSvc.m_lngDelMethodByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		//挂号费种
		#region 获取挂号费种列表	张国良		2004-8-8
		public long m_lngFindType(out clsRegchargeType_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngFindRegChargeTypeList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增挂号费种	张国良		2004-8-8
		public long m_lngAddType(clsRegchargeType_VO objResult, out string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngAddNewRegChargeType(objPrincipal,objResult,out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 修改挂号费种	张国良		2004-8-8
		public long m_lngDoUpdTypeByID(clsRegchargeType_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDoUpdRegChargeTypeByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 停用挂号费种	张国良		2004-9-22
		public long m_lngIsUseingRgechargeType(string p_strID,string p_Isusering)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));

			lngRes = objSvc.m_lngIsUseingRgechargeType(objPrincipal,p_strID,p_Isusering);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 删除挂号费种	张国良		2004-8-8
		public long m_lngDelTypeByID(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDeleteRegChargeTypeByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		//挂号身份
		#region 获取挂号身份列表	张国良		2004-8-9
		public long m_lngFindPatientPayTypeList(out clstPatientPaytype_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngFindPatientPayTypeList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增挂号身份	张国良		2004-8-9
		public long m_lngAddPatientPayType(clstPatientPaytype_VO objResult ,out string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngAddNewPatientPayType(objPrincipal,objResult,out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 修改挂号身份	张国良		2004-8-9
		public long m_lngDoUpdPatientPayTypeByID(clstPatientPaytype_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDoUpdPatientPayTypeByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 停用挂号身份	张国良		2004-9-22
		public long m_lngIsUseingPAYTYPE(string p_strID,string p_Isusering)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngIsUseingPAYTYPE(objPrincipal,p_strID,p_Isusering);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 删除挂号身份	张国良		2004-8-9
		public long m_lngDelTPatientPayTypeByID(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegChargeTypeSvc));
			lngRes = objSvc.m_lngDeletePatientPayTypeByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取保险计划列表	张国良		2004-9-24
		/// <summary>
		/// 获取保险计划列表
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetINSPLANDataArr(out clsInsPlan_VO[] p_objResultArr)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
			long lngRes= objSvc.m_lngGetINSPLANDataArr(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

	}
}
