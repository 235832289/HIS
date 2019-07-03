using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ChargeIns 的摘要说明。
	/// </summary>
	public class clsDcl_ChargeIns : com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ChargeIns()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//保险公司
		#region 获取保险公司列表	张国良		2004-9-22
		/// <summary>
		/// 获取保险公司列表
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetINSCOMPANYDataArr(out clsInsCompany_VO[] p_objResultArr)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngGetINSCOMPANYDataArr(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;

		}
		#endregion

		#region 新增保险公司	张国良		2004-9-24
		/// <summary>
		/// 新增保险公司
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSCOMPANYD( clsInsCompany_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSCOMPANYD(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 修改保险公司信息	张国良		2004-9-24
		/// <summary>
		/// 修改保险公司信息
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
			public long m_lngModifyINSCOMPANYD( clsInsCompany_VO objResult)
			{

				com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
				long lngRes = objSvc.m_lngModifyINSCOMPANYD(objPrincipal,objResult);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion

		#region 删除保险公司信息	张国良		2004-9-24
			/// <summary>
			/// 删除保险公司信息
			/// </summary>
			/// <param name="objResult"></param>
			/// <returns></returns>
			public long m_lngINSCOMPANYDel(string strID )
			{

				com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
                long lngRes = objSvc.m_lngINSCOMPANYDel(objPrincipal, strID);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion
		
		//保险计划	
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
                long lngRes = objSvc.m_lngGetINSPLANDataArr(objPrincipal, out p_objResultArr);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion

		#region 新增保险计划	张国良		2004-9-24
		/// <summary>
		/// 新增保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSPLAN( clsInsPlan_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSPLAN(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 修改保险计划	张国良		2004-9-24
		/// <summary>
		/// 修改保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngModifyINSPLAN( clsInsPlan_VO objResult)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngModifyINSPLAN(objPrincipal, objResult);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 删除保险计划	张国良		2004-9-24
		/// <summary>
		/// 删除保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngDelINSPLAN(string strID )
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngDelINSPLAN(objPrincipal, strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		//保险计划	
		#region 获取保险种类列表	张国良		2004-9-27
		/// <summary>
		/// 获取保险计划列表
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetINSCOPAYataArr(out clsInsPay_VO[] p_objResultArr)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngGetINSCOPAYataArr(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 新增保险种类	张国良		2004-9-27
		/// <summary>
		/// 新增保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSCOPAY( clsInsPay_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSCOPAY(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 修改保险种类	张国良		2004-9-27
		/// <summary>
		/// 修改保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngModifyINSCOPAY( clsInsPay_VO objResult)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngModifyINSCOPAY(objPrincipal, objResult);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region 删除保险种类	张国良		2004-9-27
		/// <summary>
		/// 删除保险计划
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngDelINSCOPAY(string strID )
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngDelINSCOPAY(objPrincipal, strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

	}
}
