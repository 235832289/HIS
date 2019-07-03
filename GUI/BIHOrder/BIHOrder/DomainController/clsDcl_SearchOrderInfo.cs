using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.HIS.HISYBMapping;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 查询医嘱	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-02-22
	/// </summary>>
	public class clsDcl_SearchOrderInfo: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		public clsDcl_SearchOrderInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		//病人信息区
		#region 查询住院号
		/// <summary>
		/// 查询住院号	[数组]
		/// </summary>
		/// <param name="p_strFindString">查询字符串</param>
		/// <param name="p_strHospitalNoArr">住院号	[数组]	[out参数]</param>
		/// <returns></returns>
		public long m_lngFindHospitalNo(string p_strFindString,out string [] p_strHospitalNoArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindHospitalNo(p_strFindString, out p_strHospitalNoArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		/// <summary>
		/// 查找住院号	[数组]	
		/// 包括(1=已上床;2=预出院;4=请假)
		/// </summary>
		/// <param name="p_strCode">查询字符串</param>
		/// <param name="p_objResultArr">入院登记对象 [out 参数]</param>
		/// <returns></returns>
		public long m_lngFindHospitalNo(string p_strFindString,out clsT_Opr_Bih_Register_VO[] p_strResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindHospitalNo(p_strFindString, out p_strResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取病区、病床
		/// <summary>
		/// 查询病区	[数组]
		/// </summary>
		/// <param name="p_strFindString">查询字符串</param>
		/// <param name="p_objResultArr">病区对象	[数组]	[out参数]</param>
		/// <returns></returns>
		public long m_lngFindArea(string p_strFindString,out clsBIHArea[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindArea(p_strFindString, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		/// <summary>
		/// 查询病床	根据病区ID	[数组]
		/// </summary>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strFindString">查询字符串</param>
		/// <param name="p_objResultArr">病床对象	[数组]	[out参数]</param>
		/// <returns></returns>
		public long m_lngGetBedByArea(string p_strAreaID,string p_strFindString,out com.digitalwave.iCare.ValueObject.clsBIHBed[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetBedByArea(p_strAreaID, p_strFindString, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取余额
		/// <summary>
		/// 获取余额	根据住院ID
		/// </summary>
		/// <param name="p_strRegisterID">住院ID</param>
		/// <param name="p_dblBalanceMoney">余额</param>
		/// <returns></returns>
		public long m_lngGetBalanceMoneyByRegisterID(string  p_strRegisterID,out double p_dblBalanceMoney)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            lngRes = objSvc.m_lngGetBalanceMoneyByRegisterID(p_strRegisterID, out p_dblBalanceMoney);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取病人对象
		/// <summary>
		/// 获取病人对象	根据住院号
		/// </summary>
		/// <param name="p_strInHospitalNo">住院号</param>
		/// <param name="p_objResult">病人对象</param>
		/// <returns></returns>
		public long m_lngGetPatientByInHospitalNo(string p_strInHospitalNo,out clsBIHPatientInfo p_objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetPatientByInHospitalNo(p_strInHospitalNo, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		/// <summary>
		/// 获取病人对象	根据病区ID、病床ID
		/// </summary>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strBedID">病床ID</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetPatientByAreaBed(string p_strAreaID,string p_strBedID,out clsBIHPatientInfo p_objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetPatientByAreaBed(p_strAreaID, p_strBedID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 取得病人医保对应类型
		public long m_lngGetYBPayTypeName(string strHisPayTypeId, out clsYBMappingPayTypeVO retVal) 
		{
			long lngRes=0;
			retVal = null;
			com.digitalwave.iCare.middletier.HIS.HISYBMapping.clsYBMappingPayTypeSVC objSvc =
				(com.digitalwave.iCare.middletier.HIS.HISYBMapping.clsYBMappingPayTypeSVC) 
					com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
						typeof(com.digitalwave.iCare.middletier.HIS.HISYBMapping.clsYBMappingPayTypeSVC)); 
            return lngRes;			
		}
		#endregion
		//统计区
		#region 查询医嘱信息	根据条件
		/// <summary>
		/// 查询医嘱信息	根据条件
		/// </summary>
		/// <param name="p_strCondition">条件表达式[不包括“Where”]</param>
		/// <param name="p_objResultArr">医嘱记录对象	[数组]</param>
		/// <returns></returns>
        public long m_lngGetOrderByCondition(string p_strCondition, out clsBIHOrder[] p_objResultArr )
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderByCondition(objPrincipal, p_strCondition, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取医嘱执行单	根据医嘱ID
		/// <summary>
		/// 获取医嘱执行单	根据医嘱ID	[数组]
		/// </summary>
		/// <param name="p_strOrderIDArr">医嘱ID	[数组]</param>
		/// <param name="p_objResultArr">医嘱执行单对象</param>
		/// <returns></returns>
        public long m_lngGetExecuteOrderByOrderID(string[] p_strOrderIDArr, out clsBIHExecOrder[] p_objResultArr )
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetExecuteOrderByOrderID(objPrincipal, p_strOrderIDArr, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取摆药明细单	根据医嘱ID
		/// <summary>
		/// 查找摆药明细单	医嘱ID	[数组]
		/// </summary>
		/// <param name="p_strOrderIDArr">医嘱ID	[数组]</param>
		/// <param name="p_objResultArr">医嘱摆药明细对象</param>
		/// <returns></returns>
		public long m_lngGetPutMedDetailByOrderID(string[] p_strOrderIDArr,out clsT_Bih_Opr_Putmeddetail_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsPutMedicineSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsPutMedicineSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPutMedicineSvc));
            lngRes = objSvc.m_lngGetPutMedDetailByOrderID(objPrincipal, p_strOrderIDArr, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region  获取病人帐务明细	根据医嘱ID
		/// <summary>
		/// 获取病人帐务明细	根据医嘱ID[数组]
		/// </summary>
		/// <param name="p_strRegisterID">医嘱ID	[数组]</param>
		/// <param name="p_objResultArr">病人帐务明细对象</param>
		/// <returns></returns>
		public long m_lngGetPatientChargeByOrderID(string[] p_strOrderIDArr,out clsT_opr_bih_patientcharge_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            lngRes = objSvc.m_lngGetPatientChargeByOrderID(objPrincipal, p_strOrderIDArr, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
		#region 获取附加单据内容对象	根据医嘱ID
		/// <summary>
		/// 获取附加单据内容对象	根据医嘱ID
		/// </summary>
		/// <param name="p_strOrderIDArr">医嘱ID	[数组]</param>
		/// <param name="p_objResultArr">附加单据内容对象</param>
		/// <returns></returns>
		public long m_lngGetAttachOrderByOrderID(string[] p_strOrderIDArr,out clsOrderAttach[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetAttachOrderByOrderID(objPrincipal, p_strOrderIDArr, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion
 
		/// <summary>
		/// 根据住院登记号,查找历史住院记录
		/// </summary>
		/// <param name="registerId"></param>
		/// <returns></returns>
		public DataTable getBihHistory(string registerId) 
		{
			DataTable dt = null;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            dt = objSvc.getBihHistory(registerId);
            objSvc.Dispose();
            objSvc = null;
			return dt;
		} 
	}
}
