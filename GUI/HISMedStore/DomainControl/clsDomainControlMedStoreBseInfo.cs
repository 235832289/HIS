using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房基础信息
	/// Create by kong 2004-07-05
	/// </summary>
	public class clsDomainControlMedStoreBseInfo : clsDomainController_Base
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainControlMedStoreBseInfo()
		{
			
		}
		#endregion

		#region 药房信息
		#region 新增药房信息
		/// <summary>
		/// 新增药房信息
		/// </summary>
		/// <param name="p_objItem">药房数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStore(clsMedStore_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngAddNewMedStore(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;

		}
		#endregion

		#region 修改药房信息
		/// <summary>
		/// 修改药房信息
		/// </summary>
		/// <param name="p_objItem">药房数据</param>
		/// <returns></returns>
		public long m_lngUpdMedStoreByID(clsMedStore_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngUpdMedStoreByID(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除药房信息
		/// <summary>
		/// 删除药房信息
		/// </summary>
		/// <param name="p_strID">药房代码</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreByID(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngDeleteMedStoreByID(objPrincipal,p_strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 模糊查询药房信息
		/// <summary>
		/// 模糊查询药房信息
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreByAny(string p_strSQL,out clsMedStore_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStore_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreByAny(objPrincipal,p_strSQL,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 按药房代码查询药房信息
		/// <summary>
		/// 按药房代码查询药房信息
		/// </summary>
		/// <param name="p_strID">药房代码</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreByID(string p_strID,out clsMedStore_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStore_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreByID(objPrincipal,p_strID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 按药房类型查询药房信息
		/// <summary>
		/// 按药房类型查询药房信息
		/// </summary>
		/// <param name="p_intID">药房类型代码，1：门诊药房，2：住院药房 3：全院药房</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreByStoreType(int p_intID,out clsMedStore_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStore_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreByStoreType(objPrincipal,p_intID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 按药品类型查询药房信息
		/// <summary>
		/// 按药品类型查询药房信息
		/// </summary>
		/// <param name="p_intID">药品类型，1：西药，2：中药</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreByMedicineType(int p_intID,out clsMedStore_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStore_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreByMedicineType(objPrincipal,p_intID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 查询所有药房信息
		/// <summary>
		/// 查询所有药房信息
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreList(out clsMedStore_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStore_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获得最大的药房代码
		/// <summary>
		/// 获得最大的药房代码
		/// </summary>
		/// <param name="p_strID">药房代码</param>
		/// <returns></returns>
		public long m_lngGetMedStoreID(out string p_strID)
		{
			long lngRes = 0;	
			p_strID = null;

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreID(objPrincipal,out p_strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion

		#region 窗口信息
		#region 新增药房窗口
		/// <summary>
		/// 新增药房窗口
		/// </summary>
		/// <param name="p_objItem">药房窗口数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreWin(clsOPMedStoreWin_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngAddNewMedStoreWin(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region 修改药房窗口
		/// <summary>
		/// 修改药房窗口
		/// </summary>
		/// <param name="p_objItem">窗口数据</param>
		/// <returns></returns>
		public long m_lngUpdMedStoreWin(clsOPMedStoreWin_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngUpdMedStoreWin(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 删除药房窗口
		/// <summary>
		/// 删除药房窗口
		/// </summary>
		/// <param name="p_strID">药房窗口代码</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreWin(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngDeleteMedStoreWin(objPrincipal,p_strID);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 模糊查询药房窗口信息
		/// <summary>
		/// 模糊查询药房窗口信息
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinByAny(string p_strSQL,out clsOPMedStoreWin_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsOPMedStoreWin_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinByAny(objPrincipal,p_strSQL,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 按窗口号查询窗口信息
		/// <summary>
		/// 按窗口号查询窗口信息
		/// </summary>
		/// <param name="p_strID">窗口号</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinByID(string p_strID,out clsOPMedStoreWin_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsOPMedStoreWin_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinByID(objPrincipal,p_strID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region 按药房查询窗口
		/// <summary>
		/// 按药房查询窗口
		/// </summary>
		/// <param name="p_strID">药房代码</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinByMedStoreID(string p_strID,out clsOPMedStoreWin_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsOPMedStoreWin_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinByMedStoreID(objPrincipal,p_strID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 按条件查询窗口
		/// <summary>
		/// 按条件查询窗口
		/// </summary>
		/// <param name="p_Type">窗口类型</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinList(int p_Type,out clsOPMedStoreWin_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsOPMedStoreWin_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinList(objPrincipal,p_Type,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		#region 查询所有的窗口
		/// <summary>
		/// 查询所有的窗口
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinList(out clsOPMedStoreWin_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsOPMedStoreWin_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 得到当前最大的窗口号
		/// <summary>
		/// 得到当前最大的窗口号
		/// </summary>
		/// <param name="p_strID">窗口号</param>
		/// <returns></returns>
		public long m_lngGetMedStoreWinID(out string p_strID)
		{
			long lngRes = 0;	
			p_strID = null;

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreWinID(objPrincipal,out p_strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion

		#region 药房限额
		#region 新增药房限额
		/// <summary>
		/// 新增药房限额
		/// </summary>
		/// <param name="p_objItem">药房限额数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreLimit(DataRow p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngAddNewMedStoreLimit(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 获得药品资料
		/// <summary>
		/// 获得药品资料
		/// </summary>
		/// <param name="dtResult"></param>
		/// <returns></returns>
		public long m_lngGetMed(out DataTable dtResult)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMed(objPrincipal,out dtResult);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 修改药房限额
		/// <summary>
		/// 修改药房限额
		/// </summary>
		/// <param name="p_objItem">药房限额数据</param>
		/// <returns></returns>
		public long m_lngUpdMedStoreLimitByID(DataRow p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngUpdMedStoreLimitByID(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 删除药房限额
		/// <summary>
		/// 删除药房限额
		/// </summary>
		/// <param name="p_strMedStoreID">药房代码</param>
		/// <param name="p_strMedicineID">药品代码</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreLimitByID(string p_strMedStoreID,string p_strMedicineID)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngDeleteMedStoreLimitByID(objPrincipal,p_strMedStoreID,p_strMedicineID);	
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 检测药房限额
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public long m_lngCheckMedStoreLimit()
		{
			long lngRes = 0;
			return lngRes;
		
		}
		#endregion

		#region 模糊查询药房限额
		/// <summary>
		/// 模糊查询药房限额
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreLimitByAny(string p_strSQL,out clsMedStoreLimit_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreLimit_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreLimitByAny(objPrincipal,p_strSQL,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 按药房查询药房限额
		/// <summary>
		/// 按药房查询药房限额
		/// </summary>
		/// <param name="p_strID">药房代码</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreLimitByMedStore(string p_strID,out clsMedStoreLimit_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreLimit_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreLimitByMedStore(objPrincipal,p_strID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		#region 按药房查询药房限额(新）
/// <summary>
/// 按药房查询药房限额(新）
/// </summary>
/// <param name="winid"></param>
/// <param name="p_objResultArr"></param>
/// <returns></returns>
		public long m_lngGetMedStoreLimitByAnyWinID(string winid,out DataTable p_objResultArr)
		{
			long lngRes = 0;
			
			p_objResultArr=new DataTable();
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreLimitByAnyWinID(objPrincipal,winid,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		
		#endregion

		#region 药房单据类型
		#region 新增药房单据类型
		/// <summary>
		/// 新增药房单据类型
		/// </summary>
		/// <param name="p_objItem">药房单据类型数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreOrdType(clsMedStoreOrdType_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngAddNewMedStoreOrdType(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 修改药房单据类型
		/// <summary>
		/// 修改药房单据类型
		/// </summary>
		/// <param name="p_objItem">药房单据类型数据</param>
		/// <returns></returns>
		public long m_lngUpdMedStoreOrdTypeByID(clsMedStoreOrdType_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngUpdMedStoreOrdTypeByID(objPrincipal,p_objItem);
			objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region 删除药房单据类型
		/// <summary>
		/// 删除药房单据类型
		/// </summary>
		/// <param name="p_strID">药房单据类型代码</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreOrdType(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngDeleteMedStoreOrdType(objPrincipal,p_strID);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 模糊查询药房单据类型
		/// <summary>
		/// 模糊查询药房单据类型
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdTypeByAny(string p_strSQL,out clsMedStoreOrdType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdType_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdTypeByAny(objPrincipal,p_strSQL,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 按药房单据类型代码查询
		/// <summary>
		/// 按药房单据类型代码查询
		/// </summary>
		/// <param name="p_strID">药房单据类型代码</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdTypeByID(string p_strID,out clsMedStoreOrdType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdType_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdTypeByID(objPrincipal,p_strID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 按标志查询药房单据类型
		/// <summary>
		/// 按标志查询药房单据类型
		/// </summary>
		/// <param name="p_intSign">标志</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdTypeBySign(int p_intSign,out clsMedStoreOrdType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdType_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdTypeBySign(objPrincipal,p_intSign,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 查询所有的药房单据类型
		/// <summary>
		/// 查询所有的药房单据类型
		/// </summary>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdTypeList(out clsMedStoreOrdType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdType_VO[0];

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdTypeList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 获取当前最大的药房单据类型ID
		/// <summary>
		/// 获取当前最大的药房单据类型ID
		/// </summary>
		/// <param name="p_strID">药房单据类型ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdTypeID(out string p_strID)
		{
			long lngRes = 0;	
			p_strID = null;

			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdTypeID(objPrincipal,out p_strID);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#endregion


		#region 载入药房信息  xg.peng 2006-2-9
		/// <summary>
		/// 载入药房信息
		/// </summary>
		/// <param name="p_dtable"></param>
		/// <returns></returns>
		public long m_lngGetMedStoreInfo(out DataTable p_dtable)
		{
			long lngRes = 0;			
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetMedStoreInfo(objPrincipal,out p_dtable);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		#region 根据药房ID获取药房排班信息
		/// <summary>
		/// 根据药房ID获取药房排班信息
		/// </summary>
		/// <param name="p_TypeID"></param>
		/// <param name="p_objResArr"></param>
		/// <returns></returns>
		public long m_lngGetDeptDutyInfo(string p_TypeID,out clsMedDeptDuty_VO[] p_objResArr)
		{
			long lngRes = 0;			
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngGetDeptDutyInfo(objPrincipal,p_TypeID,out p_objResArr);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

		#region 新增药房排班信息
		/// <summary>
		/// 新增药房排班信息
		/// </summary>
		/// <param name="p_intSeq"></param>
		/// <param name="p_objDuty"></param>
		/// <returns></returns>
		public long m_lngAddDeptDutyInfo(out int p_intSeq,clsMedDeptDuty_VO p_objDuty)
		{
			long lngRes = 0;			
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

			lngRes = objSvc.m_lngAddDeptDutyInfo(objPrincipal,out p_intSeq, p_objDuty);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		#region 保存 修改排班信息
		/// <summary>
		/// 保存 修改排班信息
		/// </summary>
		/// <param name="p_objWorkDuty"></param>
		/// <returns></returns>
		public long m_thUpdateDeptDutyInfo(clsMedDeptDuty_VO p_objWorkDuty)
		{
			long lngRes = 0;			
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
			lngRes = objSvc.m_thUpdateDeptDutyInfo(objPrincipal,p_objWorkDuty);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion
		#region 删除排班信息
		/// <summary>
		/// 删除排班信息
		/// </summary>
		/// <param name="p_intID"></param>
		/// <returns></returns>
		public long m_thDelDeptDutyInfo(int p_intID)
		{
			long lngRes = 0;			
			clsMedStoreBseInfoSvc objSvc = 
				(clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
			lngRes = objSvc.m_thDelDeptDutyInfo(objPrincipal,p_intID);
			objSvc.Dispose();
			return lngRes;	
		}
		#endregion

        #region 药房专用窗口与科室对应表内容
        /// <summary>
        /// 药房专用窗口与科室对应表内容
        /// </summary>
        public long m_lngGetMedStoreWinDeptDefInfo(string p_strMedStoreId, string p_strWindowId, out DataTable p_dtable)
        {
            long lngRes = 0;
            p_dtable = null;
            clsMedStoreBseInfoSvc objSvc =
                (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetMedStoreWinDeptDefInfo(objPrincipal, p_strMedStoreId, p_strWindowId, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 插入药房专用窗口与科室对应
        /// </summary>
        public long m_lngInsertMEDSTOREWINDEPT(clsMEDSTOREWINDEPTDEF_VO[] p_VO)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
                (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngInsertMEDSTOREWINDEPT(objPrincipal, p_VO);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 删除药房专用窗口与科室对应
        /// </summary>
        public long m_lngDeleteMEDSTOREWINDEPT(clsMEDSTOREWINDEPTDEF_VO[] p_VO)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
                (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngDeleteMEDSTOREWINDEPT(objPrincipal, p_VO);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 取得数据
        /// <summary>
        /// 取得数据
        /// </summary>
        public long m_lngGeDataTableInfo(string p_sql, out DataTable p_dtable)
        {
            long lngRes = 0;
            p_dtable = null;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

            lngRes = objSvc.m_lngGeDataTableInfo(p_sql, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
       #endregion
        #region 根据药房类型获得药房信息(名称)
        /// <summary>
        /// 根据药房类型获得药房信息(名称)
        /// </summary>
        /// <param name="p_dtable"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfoByMedStoreType(out DataTable p_dtable)
        {
            long lngRes = 0;
            p_dtable = null;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));

            lngRes = objSvc.m_lngGetMedStoreInfoByMedStoreType(objPrincipal, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
         #endregion
        #region 获取全部病区信息
         /// <summary>
         /// 获取全部病区信息
         /// </summary>
         /// <param name="p_dtable"></param>
         /// <returns></returns>
        public long m_lngGetAreaInformation( out DataTable p_dtable)
        {
            long lngRes = 0;
            p_dtable = null;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetAreaInformation(objPrincipal, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 根据中心药房id获取相应管理病区的信息
        /// <summary>
        /// 根据中心药房id获取相应管理病区的信息
        /// </summary>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="p_dtable"></param>
        /// <returns></returns>
        public long m_lngGetAreaInformationByMedStoreID(string m_strMedStoreID, out DataTable p_dtable)
        {

            long lngRes = 0;
            p_dtable = null;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetAreaInformationByMedStoreID(objPrincipal,m_strMedStoreID, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 根据中心药房id插入相应管理病区的信息
        /// <summary>
        /// 根据中心药房id插入相应管理病区的信息
        /// </summary>
        /// <param name="m_objData"></param>
        /// <returns></returns>
        public long m_lngInsertMedStoreAreaRelation(clsMedStoreVsArea m_objData)
        {
            long lngRes = 0;
         
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngInsertMedStoreAreaRelation(objPrincipal, m_objData);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        //#region 根据药房id和病区id删除中心药房对应病区的纪录
        // /// <summary>
        ///// 根据药房id和病区id删除中心药房对应病区的纪录
        // /// </summary>
        // /// <param name="m_strMedStoreId"></param>
        // /// <param name="m_strAreaId"></param>
        // /// <returns></returns>
        //public long m_lngDelMedStoreVsAreaInfoByID(string m_strMedStoreId, string m_strAreaId)
        //{
        //    long lngRes = 0;
        //    clsMedStoreBseInfoSvc objSvc =
        //       (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
        //    lngRes = objSvc.m_lngDelMedStoreVsAreaInfoByID(objPrincipal, m_strMedStoreId, m_strAreaId);
        //    objSvc.Dispose();
        //    return lngRes;

        //}
        //#endregion 
        #region 根据药房id和病区id更新中心药房对应病区的纪录
        /// <summary>
        /// 根据药房id和病区id更新中心药房对应病区的纪录
        /// </summary>
        /// <param name="m_objVO"></param>
        /// <returns></returns>
        public long m_lngUpdateMedStoreVsAreaInfo(clsMedStoreVsArea m_objVO)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngUpdateMedStoreVsAreaInfo(objPrincipal,m_objVO);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion 
        #region 插入药房叫号内容信息表
        /// <summary>
        /// 插入药房叫号内容信息表
        /// </summary>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="m_strWindowID"></param>
        /// <param name="m_strCallContent"></param>
        /// <returns></returns>
        public long m_lngInsertMedStoreCallQue(string m_strMedStoreID, string m_strWindowID, string m_strCallContent)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngInsertMedStoreCallQue(objPrincipal, m_strMedStoreID, m_strWindowID, m_strCallContent);
            objSvc.Dispose();
            return lngRes;
        }
          #endregion
        #region 根据病人药房id和窗口id删除药房叫号内容信息表
       /// <summary>
        /// 根据病人药房id和窗口id删除药房叫号内容信息表
       /// </summary>
       /// <param name="m_strMedStoreID"></param>
       /// <param name="m_strWindowsID"></param>
       /// <returns></returns>
        public long m_lngDelMedStoreCallInfoByID(string m_strMedStoreID, string m_strWindowsID)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngDelMedStoreCallInfoByID(objPrincipal, m_strMedStoreID, m_strWindowsID);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion
        #region 根据病人药房id和窗口id获取药房叫号内容信息表
        /// <summary>
        /// 根据病人药房id和窗口id获取药房叫号内容信息表
        /// </summary>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="m_strWindowsID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreCallInfoByID(string m_strMedStoreID, string m_strWindowsID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetMedStoreCallInfoByID(objPrincipal, m_strMedStoreID, m_strWindowsID,out m_objTable);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 根据病人药房id获取药房叫号内容信息表
          /// <summary>
         /// 根据病人药房id获取药房叫号内容信息表
         /// </summary>
         /// <param name="m_strMedStoreID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreCallInfoByID(string m_strMedStoreID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetMedStoreCallInfoByID(objPrincipal, m_strMedStoreID,out m_objTable);
            objSvc.Dispose();
            return lngRes;

        }
         #endregion
        #region 根据病房ID获取各药房当天的未发药信息
         /// <summary>
         /// 根据病房ID获取各药房当天的未发药信息
         /// </summary>
         /// <param name="m_strCurrentDataTime"></param>
         /// <param name="m_strMedStoreID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreSendInfo(string m_strCurrentDataTime, string m_strMedStoreID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
               (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngGetMedStoreSendInfo(objPrincipal,m_strCurrentDataTime, m_strMedStoreID, out m_objTable);
            objSvc.Dispose();
            return lngRes;

        }
          #endregion
        #region 批量更新药房对应病区的顺序号
        /// <summary>
        ///  批量更新药房对应病区的顺序号
        /// </summary>
        /// <param name="m_objVOArr"></param>
        /// <returns></returns>
        public long m_lngUpdateOrderOfTable(clsMedStoreVsArea[] m_objVOArr)
        {
            long lngRes = 0;
            clsMedStoreBseInfoSvc objSvc =
                (clsMedStoreBseInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreBseInfoSvc));
            lngRes = objSvc.m_lngUpdateOrderOfTable(objPrincipal, m_objVOArr);
            objSvc.Dispose();
            return lngRes;

        }
          #endregion
        #region 根据药房id查找窗口信息
        /// <summary>
        /// 根据药房id查找窗口信息
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="m_bjTable"></param>
        /// <returns></returns>
        public long m_lngGetWindowInfoByMedstoreid(string m_strMedStoreid, out DataTable m_bjTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetWindowInfoByMedstoreid(objPrincipal, m_strMedStoreid,out m_bjTable);
            return lngRes;
        }
        #endregion
        #region 根据药房id和发生日期获取配药发药信息
        /// <summary>
        /// 根据药房id和发生日期获取配药发药信息
        /// </summary>
        /// <param name="m_strMedStoreID"></param>
        /// <param name="m_strCreateDate"></param>
        /// <param name="m_dtSendWindows"></param>
        /// <param name="m_dtWindows"></param>
        /// <returns></returns>
        public long m_lngGetDataByMedStoreID(string m_strMedStoreID, string m_strCreateDate, ref List<clsWindowsInfo> m_objWindowList, ref List<clsWindowsInfo> m_objSendWindowsList)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDataByMedStoreID(objPrincipal, m_strMedStoreID, m_strCreateDate, ref m_objWindowList, ref m_objSendWindowsList);
            return lngRes;
        }
         #endregion

        #region 获取科室基本信息表
        /// <summary>
        /// 获取门诊药房基本信息表
        /// </summary>
        /// <param name="m_dtDeptDesc"></param>
        /// <returns></returns>
        public long m_lngGetDeptInfo(out DataTable m_dtDeptDesc)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetDeptInfo(objPrincipal, out m_dtDeptDesc);
            return lngRes;

        }
        #endregion

	}
}
