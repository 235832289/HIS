using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房业务操作
	/// Create by kong 2004-07-08
	/// </summary>
	public class clsDomainControlMedStore : clsDomainController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsDomainControlMedStore()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 药房进出药

		#region 新系统的方法

		#region 获得药库信息(2005-6-24)
        ///// <summary>
		/// 获得药库信息
		/// </summary>
		/// <returns></returns>
		public long m_lngGetStore(out DataTable  dtStore)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objChangPrice.m_lngGetStore(objPrincipal,out dtStore);
			return lngRes;
		}
		#endregion

		#region 获得药库信息(2005-6-24)
		/// <summary>
		/// 获得药库信息
		/// </summary>
		/// <returns></returns>
		public long m_lngGetMedStore(out DataTable  dtMedStore)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetMedStore(objPrincipal,out dtMedStore);

			return lngRes;
		}
		#endregion
		#region 获得药房最大的源单据号(2005-6-24)
		/// <summary>
		/// 获得药房最大的源单据号
		/// </summary>
		/// <returns></returns>
		public long m_lngGetScrNO(out string ScrNO)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetScrNO(objPrincipal,out ScrNO);

			return lngRes;
		}
		#endregion

		#region 获取药品基本信息(11-10)
		/// <summary>
		/// 获取药品基本信息
		/// </summary>
		/// <returns></returns>
		public long m_lngGetAllMedicine(out DataTable dtbMedicine)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetAllMedicine(objPrincipal,out dtbMedicine);

			return lngRes;
		}
		#endregion

		#region 根据药房获得有库存的药品
		/// <summary>
		/// 根据药房获得有库存的药品
		/// </summary>
		/// <param name="dtbMedicine"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		public long m_lngGetMedicineByID(out DataTable dtbMedicine,string strID)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetMedicineByID(objPrincipal,out dtbMedicine,strID);
			return lngRes;
		}
		#endregion

		#region 获得药房入库类型、药房信息(11-10)
		/// <summary>
		/// 获得药房入库类型、药房信息
		/// </summary>
		/// <param name="strTypeName">入库类型名称</param>
		/// <param name="intSIGN_INT">出入标志，2-出库,1-入库,3-调拔</param>
		/// <param name="StorageName">药房名称</param>
		///  <param name="strTypeID">入库类型ID</param>
		///  <param name="StorageID">药房ID</param>
		/// <returns></returns>
		public long m_lngGetTypeAndStorage(string strTypeID,string StorageID,out string strTypeName,out int intSIGN_INT,out string StorageName)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetTypeAndStorage(objPrincipal,strTypeID,StorageID,out strTypeName,out intSIGN_INT,out StorageName);

			return lngRes;
		}
		#endregion

		#region 获得药房入库单数据信息(11-10)
		/// <summary>
		/// 获得药房入库单数据信息
		/// </summary>
		/// <param name="dtbResult"></param>
		///  <param name="nowPriod">财务期ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrd(string strTypeID,out DataTable dtbResult,string nowPriod,string strStorageID,string strOutFlan)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreOrd(objPrincipal,strTypeID,out dtbResult,nowPriod,strStorageID,strOutFlan);

			return lngRes;
		}
		#endregion

		#region 根据入库单号获得入库单明细(11-10)
		/// <summary>
		/// 根据入库单号获得入库单明细
		/// </summary>
		/// <param name="strID"></param>
		/// <param name="p_dtbResultArr"></param>
		/// <returns></returns>
		public long m_lngGetStoreOrdDeByOrdID(string strID,out DataTable p_dtbResultArr,bool blCenter,string storageID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetStoreOrdDeByOrdID(objPrincipal,strID,out p_dtbResultArr,blCenter,storageID);
			return lngRes;
		}
		#endregion

		#region 保存入库单数据(11-10)
        /// <summary>
        /// 保存入库单数据
        /// </summary>
        /// <param name="DtrStorage"></param>
        /// <param name="dtbStorageDe"></param>
        /// <param name="newID"></param>
        /// <param name="intSign">出入标志，2-出库,1-入库,3-调拔出库，4调拔入库</param>
        /// <returns></returns>
		public long m_lngSave(DataRow DtrStorage,DataTable dtbStorageDe,out string newID,int intSign)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngSave(objPrincipal,DtrStorage,dtbStorageDe,out newID,intSign);
			return lngRes;
		}
		#endregion

		#region 保存出库单数据(11-10)
		/// <summary>
		/// 保存出库单数据
		/// </summary>
		/// <param name="DtrStorage"></param>
		/// <param name="dtbStorageDe"></param>
		/// <param name="newID"></param>
		/// <returns></returns>
		public long m_lngSaveOut(DataRow DtrStorage,DataTable dtbStorageDe,out string newID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngSaveOut(objPrincipal,DtrStorage,dtbStorageDe,out newID);
			return lngRes;
		}
		#endregion

		#region 删除数据(11-10)
		/// <summary>
		/// 删除数据(11-10)
		/// </summary>
		/// <param name="strID">入库单ID</param>
		/// <param name="strDeID">入库单明细ID,不为null只删除明细数据</param>
		/// <param name="TolMoney">单据总金额</param>
		/// <param name="DelDeMoney">要删除明细数据的金额</param>
		/// <returns></returns>
		public long m_lngDelete(string strID,string strDeID,double TolMoney,double DelDeMoney)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDelete(objPrincipal,strID,strDeID,TolMoney,DelDeMoney);
			return lngRes;
		}
		#endregion

		#region 修改数据(11-10)
		/// <summary>
		/// 修改数据
		/// </summary>
		/// <param name="UpOrdDe">明细数据行，如为null不用修改</param>
		/// <param name="UpOrd">入库单数据</param>
		/// <returns></returns>
		public long m_lngModifiy(DataRow UpOrdDe,DataRow UpOrd)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngModifiy(objPrincipal,UpOrdDe,UpOrd);
			return lngRes;
		}
		#endregion

		#region 增加明细数据数据(11-10)
		/// <summary>
		/// 增加明细
		/// </summary>
		/// <param name="strOrdID">单据号ID</param>
		/// <param name="tolMoney">单据的总金额</param>
		/// <param name="ModifiyMoney">返回增加后的单据总金额</param>
		/// <param name="dtbStorageDe">明细数据</param>
		/// <param name="strOrdDeID">返回新增的明细ID</param>
		/// <returns></returns>
		public long m_lngAddNewDe(string strOrdID,double tolMoney,DataRow dtbStorageDe,out string strOrdDeID,out double ModifiyMoney)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAddNewDe(objPrincipal,strOrdID,tolMoney,dtbStorageDe,out strOrdDeID,out ModifiyMoney);
			return lngRes;
		}
		#endregion

		#region 审核功能(11-10)
		/// <summary>
		/// 审核功能
		/// </summary>
		/// <param name="stroageID">药库ID</param>
		/// <param name="GrearName">审核人ID</param>
		/// <param name="strID">单号ID</param>
		/// <param name="OrdDeTable">入库单明细</param>
		/// <param name="intFlan">出入标志，2-出库,1-入库,3-调拔出库，4调拔入库</param>
		/// <param name="blisAutoInsert">是否要自动生成相应的入库单</param>
		/// <param name="OrdTableRow">出库单数据</param>
		/// <returns></returns>
		public long m_lngAduiTemp(string strID,string stroageID,string GrearName,DataTable OrdDeTable,int intFlan,bool blisAutoInsert,DataRow OrdTableRow)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAduiTemp(objPrincipal,strID,stroageID,GrearName,OrdDeTable,intFlan,blisAutoInsert,OrdTableRow);
			return lngRes;
		}
		#endregion

		#region 检查相应的单据号是否存在
		/// <summary>
		/// 检查相应的单据号是否存在
		/// </summary>
		/// <param name="ordTypeName"></param>
		/// <param name="ordTypeID"></param>
		///  <param name="intFlan">0-药房，1-药库</param>
		/// <returns></returns>
		public long m_lngGetOrdTypeID(out string ordTypeID,int intFlan)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetOrdTypeID(objPrincipal,out  ordTypeID,intFlan);
			return lngRes;
		}
		#endregion


		#region 获得药房出药类型、药房信息
		/// <summary>
		/// 获得药房出药类型、药房信息
		/// </summary>
		/// <param name="dtbType">出药类型</param>
		/// <param name="dtbStorage">药房</param>
		/// <returns></returns>
		public long m_lngGetTypeAndStorageOut(string strTypeID,out string strTypeName,out DataTable dtbStorage)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetTypeAndStorageOut(objPrincipal,strTypeID,out strTypeName,out dtbStorage);
			return lngRes;
		}
		#endregion

		#region 获得所有的出药数据
        /// <summary>
        /// 获得所有的出药数据
        /// </summary>
        /// <param name="dtbResult"></param>
        ///  <param name="nowPriod">财务期ID</param>
        ///  <param name="strTypeID">类型ID</param>
        /// <returns></returns>
		public long m_lngGetMedStoreOrdOut(string strTypeID,out DataTable dtbResult,string nowPriod)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreOrdOut(objPrincipal,strTypeID,out dtbResult,nowPriod);
			return lngRes;
		}
		#endregion

		#region 查找药品的库存
		/// <summary>
		/// 查找药品的库存
		/// </summary>
		/// <param name="StoreNumber"></param>
		/// <returns></returns>
		public long m_lngGetAllStorage(string strstogeId,string Medid,out int StoreNumber)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetAllStorage(objPrincipal,strstogeId,Medid,out StoreNumber);
			return lngRes;
		}
		#endregion

		#region 审核功能(出药)
		/// <summary>
		/// 审核功能(出药)
		/// </summary>
		/// <param name="stroageID"></param>
		/// <param name="GrearName"></param>
		/// <param name="strID"></param>
		/// <param name="OrdDeTable"></param>
		/// <returns></returns>
		public long m_lngAduiTempOut(string strID,string stroageID,string GrearName,DataTable OrdDeTable)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAduiTempOut(objPrincipal,strID,stroageID,GrearName,OrdDeTable);
			return lngRes;
		}
		#endregion

		#endregion

		#region 新增药房进出药记录单
		/// <summary>
		/// 新增药房进出药记录单
		/// </summary>
		/// <param name="p_objItem">药房进出记录单数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 修改药房进出药记录单
		/// <summary>
		/// 修改药房进出药记录单
		/// </summary>
		/// <param name="p_objItem">药房进出记录单数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 修改药房进出药记录单状态标志
		/// <summary>
		/// 修改药房进出药记录单状态标志
		/// </summary>
		/// <param name="strID">药房进出记录单ID</param>
		/// <param name="intStatus">状态标志</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrdStatus(string strID,int intStatus)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrdStatus(objPrincipal,strID,intStatus);

			return lngRes;

		}
		#endregion

		#region 删除药房进出药记录单
		/// <summary>
		/// 删除药房进出药记录单
		/// </summary>
		/// <param name="p_strID">药房进出记录单ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreOrd(string p_strID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDeleteMedStoreOrd(objPrincipal,p_strID);
			return lngRes;
		}
		#endregion

		#region 审核药房进出药记录单
		/// <summary>
		/// 药房进出药记录单审核
		/// </summary>
		/// <param name="p_objItem">药房进出记录单数据</param>
		/// <returns></returns>
		public long m_lngAduitMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAduitMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 审核药房进出药记录单后更改库存
		/// <summary>
		/// 药房进出药记录单审核后更改库存
		/// </summary>
		/// <param name="p_strID">药房进出记录单ID</param>
		/// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
		/// <returns></returns>
		public long m_lngChangeStorageAfterAduitMedStoreOrd(string p_strID,out int p_intFlag)
		{
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeStorageAfterAduitMedStoreOrd(objPrincipal,p_strID,out p_intFlag);

			return lngRes;
		}
		#endregion

		#region 药房进出药记录单登帐
		/// <summary>
		/// 药房进出药记录单登帐
		/// </summary>
		/// <param name="p_objItem">药房进出记录单数据</param>
		/// <returns></returns>
		public long m_lngAcctMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAcctMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 药房进出药记录单登帐后更改帐务
		/// <summary>
		/// 药房进出药记录单登帐后更改帐务
		/// </summary>
		/// <param name="p_strID">药房进出记录单ID</param>
		/// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
		/// <returns></returns>
		public long m_lngChangeFinAfterAcctMedStoreOrd(string p_strID,out int p_intFlag)
		{
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeFinAfterAcctMedStoreOrd(objPrincipal,p_strID,out p_intFlag);

			return lngRes;
		}
		#endregion

		#region 新增药房进出药明细单记录
		/// <summary>
		/// 新增药房进出药明细单记录
		/// </summary>
		/// <param name="p_objItem">药房进出药明细数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreOrdDe(clsMedStoreOrdDe_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreOrdDe(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 修改药房进出药明细单记录
		/// <summary>
		/// 修改药房进出药明细单记录
		/// </summary>
		/// <param name="p_objItem">药房进出药明细数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrdDe(clsMedStoreOrdDe_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrdDe(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region 删除药房进出药明细单记录
		/// <summary>
		/// 删除药房进出药明细单记录
		/// </summary>
		/// <param name="p_strID">药房进出药明细ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreOrdDe(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreOrdDe(objPrincipal,p_strID);

			return lngRes;
		}
		#endregion

		#region 模糊查询药房进出药记录单
		/// <summary>
		/// 模糊查询药房进出药记录单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByAny(string p_strSQL,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByAny(objPrincipal,p_strSQL,out p_objResultArr);

			return lngRes;	
		}
		#endregion

		#region 按记录单ID查询药房进出药记录单
		/// <summary>
		/// 按记录单ID查询药房进出药记录单
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByID(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByID(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;	
		}
		#endregion

		#region 按单据类型查询药房进出药记录单
		/// <summary>
		/// 按单据类型查询药房进出药记录单
		/// </summary>
		/// <param name="p_strID">单据类型ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByOrdType(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByOrdType(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按药房查询药房进出药记录单
		/// <summary>
		/// 按药房查询药房进出药记录单
		/// </summary>
		/// <param name="p_strID">药房ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByMedStore(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByMedStore(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按操作时间查询药房进出药记录单
		/// <summary>
		/// 按操作时间查询药房进出药记录单
		/// </summary>
		/// <param name="p_strStartDate">开始时间</param>
		/// <param name="p_strEndDate">结束时间</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按帐务期查询药房进出药记录单
		/// <summary>
		/// 按帐务期查询药房进出药记录单
		/// </summary>
		/// <param name="p_strID">帐务期ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByPeriod(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByPeriod(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按状态标志查询药房进出药记录单
		/// <summary>
		/// 按状态标志查询药房进出药记录单
		/// </summary>
		/// <param name="p_intStatus">状态标识</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByStatus(int p_intStatus,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByStatus(objPrincipal,p_intStatus,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 模糊查询药房进出药明细单
		/// <summary>
		/// 模糊查询药房进出药明细单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByAny(string p_strSQL,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByAny(objPrincipal,p_strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按药房进出药记录单ID查询药房进出药明细单
		/// <summary>
		/// 按药房进出药记录单ID查询药房进出药明细单
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByOrdID(string p_strID,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByOrdID(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 按药品查询药房进出药明细单
		/// <summary>
		/// 按药品查询药房进出药明细单
		/// </summary>
		/// <param name="p_strID">药品ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByMedicine(string p_strID,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByMedicine(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region 获取当前最大的药房进出药记录单ID
		/// <summary>
		/// 获取当前最大的药房进出药记录单ID
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdID(out string p_strID)
		{
			long lngRes = 0;	
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#region 获取当前最大的药房显示出药明细单ID
		/// <summary>
		/// 获取当前最大的药房显示出药明细单ID
		/// </summary>
		/// <param name="p_strID">明细单ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeID(out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#endregion

		#region 药房领药申请

		#region 新系统的方法

		#region 获取当前最大的药房领药申请记录单ID
		/// <summary>
		/// 获取当前最大的药房领药申请记录单ID
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <returns></returns>
		public long m_lngGetMedApplID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplID(objPrincipal,out p_strID);

			return lngRes;	
		}
		#endregion

		#region 获得药库、药房信息
		/// <summary>
		/// 获得药库、药房信息
		/// </summary>
		/// <param name="dtbStorage">药库信息表</param>
		/// <param name="dtbStore">药房信息</param>
		/// <returns></returns>
		public long m_lngGetStoreAndStorage(out DataTable dtbStorage,out DataTable dtbStore)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetStoreAndStorage(objPrincipal,out dtbStorage,out dtbStore);

			return lngRes;	
		}
		#endregion

		#region 获得药房领药申请记录单
        /// <summary>
        /// 获得药房领药申请记录单
        /// </summary>
        /// <param name="p_objResultArr">输出数据</param>
        /// <param name="storageID">申请药房</param>
        /// <returns></returns>
		public long m_lngGetMedApplAll(out DataTable p_objResultArr,string storageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplAll(objPrincipal,out p_objResultArr,storageID);

			return lngRes;	
		}
		#endregion

		#region 保存申请单
		/// <summary>
		/// 保存申请单
		/// </summary>
		/// <param name="DtrAppl">申请单行</param>
		/// <param name="dtbApplDe">明细表数据</param>
		/// <param name="newid"></param>
		/// <returns></returns>
		public long m_lngApplSave(DataRow DtrAppl,DataTable dtbApplDe,out string newid)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngApplSave(objPrincipal,DtrAppl,dtbApplDe,out newid);
			

			return lngRes;	
		}
		#endregion

        #region 保存申请单
        /// <summary>
        /// 保存申请单
        /// </summary>
        /// <param name="DtrAppl">申请</param>
        /// <param name="dtbApplDe">明细表数据</param>
        /// <param name="newid"></param>
        /// <returns></returns>
        public long m_lngApplSave(DataTable DtrAppl, DataTable dtbApplDe, out string newid)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

            lngRes = objSvc.m_lngApplSave(objPrincipal, DtrAppl, dtbApplDe, out newid);


            return lngRes;
        }
        #endregion

		#region 根据单号获得明细
        /// <summary>
        /// 根据单号获得明细
        /// </summary>
        /// <param name="strID">申请单ID</param>
        /// <param name="dtbApplDe">返回申请明细</param>
        /// <param name="strStorageID">药房ID</param>
        /// <returns></returns>
		public long m_lngGetMedApplDeById(string strID,out DataTable  dtbApplDe,string strStorageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeById(objPrincipal,strID,out dtbApplDe,strStorageID);
			
			return lngRes;	
		}
		#endregion

		#region 修改申请单数据
		/// <summary>
		/// 修改申请单数据
		/// </summary>
		/// <param name="RowApplDe"></param>
		/// <param name="RowAppl"></param>
		/// <returns></returns>
		public long m_lngModifiyAppl(DataRow RowApplDe,DataRow RowAppl)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngModifiyAppl(objPrincipal,RowApplDe,RowAppl);
			
			return lngRes;	
		}
		#endregion

		#region 删除数据
		/// <summary>
		/// 删除数据
		/// </summary>
		/// <param name="strDeId"></param>
		/// <param name="strId"></param>
		/// <returns></returns>
		public long m_lngDeleAppl(string strDeId,string strId)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDeleAppl(objPrincipal,strDeId,strId);
			
			return lngRes;	
		}
		#endregion


        #region 提交申请单
        /// <summary>
        /// 提交申请单
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public long m_lngPutinAppll(string strId)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngPutinAppll(objPrincipal,strId);

            return lngRes;
        }
        #endregion

		#region 向申请单新增一条明细
		/// <summary>
		/// 向申请单新增一条明细
		/// </summary>
		/// <param name="strId"></param>
		/// <param name="RowDe"></param>
		/// <param name="newDeid">返回ID</param>
		/// <returns></returns>
		public long m_lngAddApplDe(string strId,DataRow RowDe,out string newDeid)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAddApplDe(objPrincipal,strId,RowDe,out newDeid);
			
			return lngRes;	
		}
		#endregion

		#region 自动生成领药申请单
		/// <summary>
		/// 自动生成领药申请单
		/// </summary>
		/// <param name="dtbResult">返回生成数据表</param>
		///  <param name="stroageID">药房ID</param>
		/// <returns></returns>
		public long m_lngAutoGetMedAppl(out DataTable dtbResult,string stroageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAutoGetMedAppl(objPrincipal,out dtbResult,stroageID);
			
			return lngRes;	
		}
		#endregion
		
		#region 获得药房信息
		/// <summary>
		/// 获得药房信息
		/// </summary>
		/// <param name="StoreID"></param>
		/// <param name="StoreName"></param>
		/// <returns></returns>
		public long m_lngGetMedStoreName(string StoreID,out string StoreName)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreName(objPrincipal,StoreID,out StoreName);
			
			return lngRes;	
		}
		#endregion
		#endregion

		#region 新增药房领药申请记录单
		/// <summary>
		/// 新增药房领药申请记录单
		/// </summary>
		/// <param name="p_objItem">药房领药申请记录单数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedAppl(clsMedStoreMedAppl_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedAppl(objPrincipal,p_objItem);
			

			return lngRes;
		}
		#endregion

		#region 修改药房领药申请记录单
		/// <summary>
		/// 修改药房领药申请记录单
		/// </summary>
		/// <param name="p_objItem">药房领药申请记录单数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedAppl(clsMedStoreMedAppl_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedAppl(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 删除药房领药申请记录单
		/// <summary>
		/// 删除药房领药申请记录单
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedAppl(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedAppl(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region 新增药房领药申请明细单记录
		/// <summary>
		/// 新增药房领药申请明细单记录
		/// </summary>
		/// <param name="p_objItem">药房领药申请明细数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedApplDe(clsMedStoreMedApplDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedApplDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 修改药房领药申请明细单记录
		/// <summary>
		/// 修改药房领药申请明细单记录
		/// </summary>
		/// <param name="p_objItem">药房领药申请明细数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedApplDe(clsMedStoreMedApplDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedApplDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 删除药房领药申请明细单记录
		/// <summary>
		/// 删除药房领药申请明细单记录
		/// </summary>
		/// <param name="p_strID">明细单ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedApplDe(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedApplDe(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region 模糊查询药房领药申请记录单
		/// <summary>
		/// 模糊查询药房领药申请记录单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByAny(string p_strSQL,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按记录单ID查询药房领药申请记录单
		/// <summary>
		/// 按记录单ID查询药房领药申请记录单
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByID(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药房查询药房领药申请记录单
		/// <summary>
		/// 按药房查询药房领药申请记录单
		/// </summary>
		/// <param name="p_strID">药房ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByMedStore(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按申请药库查询药房领药申请单
		/// <summary>
		/// 按申请药库查询药房领药申请单
		/// </summary>
		/// <param name="p_strID">库房ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByStorage(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByStorage(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按申请时间查询药房领药申请单
		/// <summary>
		/// 按申请时间查询药房领药申请单
		/// </summary>
		/// <param name="p_strStartDate">开始时间</param>
		/// <param name="p_strEndDate">结束时间</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按状态标志查询药房领药申请单
		/// <summary>
		/// 按状态标志查询药房领药申请单
		/// </summary>
		/// <param name="p_intStatus">状态标识</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplByStatus(int p_intStatus,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByStatus(objPrincipal,p_intStatus,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 模糊查询药房领药申请明细单
		/// <summary>
		/// 模糊查询药房领药申请明细单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByAny(string p_strSQL,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按领药申请记录单ID查询药房领药申请明细单
		/// <summary>
		/// 按领药申请记录单ID查询药房领药申请明细单
		/// </summary>
		/// <param name="p_strID">记录单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByApplID(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByApplID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药品查询药房领药申请明细单
		/// <summary>
		/// 按药品查询药房领药申请明细单
		/// </summary>
		/// <param name="p_strID">药品ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByMedicine(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 获取当前最大的药房领药申请明细单ID
		/// <summary>
		/// 获取当前最大的药房领药申请明细单ID
		/// </summary>
		/// <param name="p_strID">明细单ID</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeID(out string p_strID)
		{			
			long lngRes = 0;	
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

//			lngRes = objSvc.m_lngGetMedApplDeID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#region 自动获得领药申请单
		/// <summary>
		/// 自动生成采购单
		/// </summary>
		/// <param name="p_strID">药房ID</param>
		/// <param name="p_objResult">输出数据</param>
		/// <returns></returns>
		public long m_lngAutoCalcMedAppl(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResult)
		{
			long lngRes = 0;
			p_objResult = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAutoCalcMedAppl(objPrincipal,p_strID,out p_objResult);
			
			return lngRes;
		}
		#endregion


		#endregion

		#region 药房盘点

		#region 新系统
		#region 获得所有的盘点数据
        /// <summary>
        /// 获得所有的盘点数据
        /// </summary>
        /// <param name="dtStorData"></param>
        /// <returns></returns>
		public long m_lngGetCheckStore(out DataTable dtStorData)
		{			
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetCheckStore(objPrincipal,out dtStorData);
			
			return lngRes;
		}
		#endregion

		#region 自动生成出入库单
		/// <summary>
		/// 自动生成出入库单
		/// </summary>
		/// <param name="dtStorCheckData"></param>
		/// <returns></returns>
		public long m_lngGetAutoGreat(DataTable dtStorCheckData)
		{			
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetAutoGreat(objPrincipal,dtStorCheckData);
			
			return lngRes;
		}
		#endregion

		#region 判断是否设置有盘点出库或入库的单据类型
		/// <summary>
		/// 判断是否设置有盘点出库或入库的单据类型
		/// </summary>
		/// <param name="typeName">出入库类型名称</param>
		/// <param name="typeID">返回单据类型ID</param>
		/// <returns>2有，3则是该类型在更新库类别中不存在</returns>
		public long m_lngisCheckType(string  typeName,out string typeID)
		{
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngisCheckType(objPrincipal,typeName,out typeID);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region 新增药房盘点记录单
		/// <summary>
		/// 新增药房盘点记录单
		/// </summary>
		/// <param name="p_objItem">药房盘点记录数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 修改药房盘点记录单
		/// <summary>
		/// 修改药房盘点记录单
		/// </summary>
		/// <param name="p_objItem">药房盘点记录数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 删除药房盘点记录单
		/// <summary>
		/// 删除药房盘点记录单
		/// </summary>
		/// <param name="p_strID">药房盘点记录单ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreCheck(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreCheck(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region 审核药房盘点记录单
		/// <summary>
		/// 审核药房盘点记录单
		/// </summary>
		/// <param name="p_objItem">药房盘点记录单数据</param>
		/// <returns></returns>
		public long m_lngAduitMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAduitMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 审核药房盘点记录单后更改库存
		/// <summary>
		/// 审核药房盘点记录单后更改库存
		/// </summary>
		/// <param name="p_strID">药房盘点记录单ID</param>
		/// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
		/// <returns></returns>
		public long m_lngChangeStorageAfterAduitMedStoreCheck(string p_strID,out int p_intFlag)
		{			
			long lngRes = 0;	
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeStorageAfterAduitMedStoreCheck(objPrincipal,p_strID,out p_intFlag);
			
			return lngRes;
		}
		#endregion

		#region 药房盘点记录单登帐
		/// <summary>
		/// 药房盘点记录单登帐
		/// </summary>
		/// <param name="p_objItem">药房盘点记录单数据</param>
		/// <returns></returns>
		public long m_lngAcctMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAcctMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 药房盘点记录单登帐后更改帐务
		/// <summary>
		/// 药房盘点记录单登帐后更改帐务
		/// </summary>
		/// <param name="p_strID">药房盘点记录单ID</param>
		/// <param name="p_intFlag">标识，1：成功，0：失败，-1：异常</param>
		/// <returns></returns>
		public long m_lngChangeFinAfterAcctMedStoreCheck(string p_strID,out int p_intFlag)
		{			
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeFinAfterAcctMedStoreCheck(objPrincipal,p_strID,out p_intFlag);
			
			return lngRes;
		}
		#endregion

		#region 新增药房盘点明细单记录
		/// <summary>
		/// 新增药房盘点明细单记录
		/// </summary>
		/// <param name="p_objItem">药房盘点明细数据</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreCheckDe(clsMedStoreCheckDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreCheckDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 修改药房盘点明细单记录
		/// <summary>
		/// 修改药房盘点明细单记录
		/// </summary>
		/// <param name="p_objItem">药房盘点明细数据</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreCheckDe(clsMedStoreCheckDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreCheckDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region 删除药房盘点明细单记录
		/// <summary>
		/// 删除药房盘点明细单记录
		/// </summary>
		/// <param name="p_strID">药房盘点明细ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreCheckDe(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreCheckDe(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region 模糊查询药房盘点记录单
		/// <summary>
		/// 模糊查询药房盘点记录单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByAny(string p_strSQL,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;	
		}
		#endregion

		#region 按盘点单ID查询药房盘点记录单
		/// <summary>
		/// 按盘点单ID查询药房盘点记录单
		/// </summary>
		/// <param name="p_strID">盘点单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByID(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药房查询药房盘点记录单
		/// <summary>
		/// 按药房查询药房盘点记录单
		/// </summary>
		/// <param name="p_strID">药房ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByMedStore(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按盘点时间查询药房盘点记录单
		/// <summary>
		/// 按盘点时间查询药房盘点记录单
		/// </summary>
		/// <param name="p_strStartDate">开始时间</param>
		/// <param name="p_strEndDate">结束时间</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按帐务期查询药房盘点记录单
		/// <summary>
		/// 按帐务期查询药房盘点记录单
		/// </summary>
		/// <param name="p_strID">帐务期ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByPeriod(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByPeriod(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;	
		}
		#endregion

		#region 按单据标志查询药房盘点记录单
		/// <summary>
		/// 按单据标志查询药房盘点记录单
		/// </summary>
		/// <param name="p_intStatus">状态标志</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByStatus(int p_intStatus,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByStatus(objPrincipal,p_intStatus,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 模糊查询药房盘点明细单
		/// <summary>
		/// 模糊查询药房盘点记录单
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByAny(string p_strSQL,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按记录单ID查询药房盘点明细单
		/// <summary>
		/// 按记录单ID查询药房盘点明细单
		/// </summary>
		/// <param name="p_strID">盘点记录单ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByCheckID(string p_strID,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByCheckID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药品查询药房盘点明细单
		/// <summary>
		/// 按药品查询药房盘点明细单
		/// </summary>
		/// <param name="p_strID">药品ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByMedicine(string p_strID,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 获取当前最大的药房盘点记录单ID
		/// <summary>
		/// 获取当前最大的药房盘点记录单ID
		/// </summary>
		/// <param name="p_strID">药房盘点记录单ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckID(objPrincipal,out p_strID);
			
			return lngRes;	
		}
		#endregion

		#region 获取当前最大的盘点明细单ID
		/// <summary>
		/// 获取当前最大的盘点明细单ID
		/// </summary>
		/// <param name="p_strID">药房盘点明细ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeID(objPrincipal,out p_strID);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region 药房库存
		
		#region 模糊查询药房明细库存
		/// <summary>
		/// 模糊查询药房明细库存
		/// </summary>
		/// <param name="p_strSQL">SQL语句</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByAny(string p_strSQL,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药房查询药房明细库存
		/// <summary>
		/// 按药房查询药房明细库存
		/// </summary>
		/// <param name="p_strID">药房ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByMedStore(string p_strID,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 按药品查询药房明细库存
		/// <summary>
		/// 按药品查询药房明细库存
		/// </summary>
		/// <param name="p_strID">药品ID</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByMedicine(string p_strID,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region 根据收费项目ID查找药品库存
		/// <summary>
		/// 根据收费项目ID查找药品库存
		/// </summary>
		/// <param name="p_strID">收费项目ID</param>
		/// <param name="p_decQty">药品数量</param>
		/// <param name="p_blnResult">库存是否足：true为够，false为库存不够申请的数量</param>
		/// <param name="p_decResult"></param>
		/// <returns></returns>
		public long m_lngCheckMedStoreMedicineStorageByID(string p_strID,decimal p_decQty,
			out bool p_blnResult,out decimal p_decResult)
		{
			long lngRes = 0;
			p_blnResult = false;
			p_decResult = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngCheckMedStoreMedicineStorageByID(objPrincipal,p_strID,p_decQty,
				out p_blnResult,out p_decResult);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region 查找员工名称
		/// <summary>
		/// 查找员工名称
		/// </summary>
		/// <param name="p_strID">员工ID</param>
		/// <param name="p_strName">输出员工名</param>
		public long m_lngfinedata(string p_strID,out string p_strName,out string empID)
		{
			long lngRes = 0;

			clsOPMedStoreSvc objSvc = 
				(clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
			lngRes = objSvc.m_lngfinedata(objPrincipal,p_strID,out p_strName,out empID);
			
			return lngRes;
		}
		#endregion

		#region 公共模块的方法
		/// <summary>
		/// 公共模块的方法
		/// </summary>
		public long m_lngGetMedicine(out DataTable dtbResult)
		{
			long lngRes = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedicine(objPrincipal,out dtbResult);
			
			return lngRes;
		}
		#endregion

		#region 根据药房ID查找药房信息及窗口信息
		/// <summary>
		/// 公共模块的方法
		/// </summary>
		public long m_lngGetStorageMessage(string strID,out DataTable dtstroageMessage ,out DataTable dtwindowsMessage,int intStatus)
		{
			long lngRes = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetStorageMessage(objPrincipal, strID, out dtstroageMessage, out dtwindowsMessage, intStatus);
			return lngRes;
		}
		#endregion
        #region 打印处方信息
        /// <summary>
        /// 获取打印处方信息
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeDetail(string m_strRecipeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            clsDoctorWorkStationSvc m_objSvc = (clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetOutpatientRecipeDetail(objPrincipal, m_strRecipeID, out  obj_VO);
            return lngRes;
        }
        #endregion 
        #region 打印处方信息
        /// <summary>
        /// 获取打印处方信息
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        public long m_lngGetOutpatientRecipeDetail(string m_strRecipeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetOutpatientRecipeDetail(objPrincipal, m_strRecipeID, out  obj_VO);
            return lngRes;
        }
            #endregion 
        #region 获取处方类型信息
        /// <summary>
        /// 获取处方类型信息
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="m_objRTVO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeTypeInfo( string m_strRecipeID, out clsRecipeType_VO m_objRTVO)
        {
            long lngRes = 0;
            clsDoctorWorkStationSvc m_objSvc = (clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetRecipeTypeInfo(objPrincipal, m_strRecipeID, out  m_objRTVO);
            return lngRes;
        }
       #endregion

        #region 报表
        /// <summary>
        /// 药房月结报表
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="arrPrID">要统计的财务期列表</param>
        /// <param name="strUpPr">要统计的第一个财务期</param>
        /// <param name="dt">返回相应的财务期统计数据</param>
        /// <param name="strStorageID">仓库ＩＤ</param>
        /// <returns></returns>
        public long m_lngGetReportmoth(System.Collections.ArrayList arrPrID, string strUpPr, out DataTable dt, string strStorageID)
        {
            long lngRes = 0;
            clsMedStoreSvc m_objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = m_objSvc.m_lngGetReportmoth(objPrincipal, arrPrID, strUpPr, out  dt, strStorageID);
            return lngRes;
        }
        #endregion
        #region  获取病历ID获取病历信息
        /// <summary>
        ///  获取病历ID获取病历信息
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetCaseHistoryByID(string m_strCaseHistoryID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetCaseHistoryByID(objPrincipal, m_strCaseHistoryID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region  获取病历ID获取项目信息
        /// <summary>
        /// 获取病历ID获取项目信息
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetItemsInformationByID(string m_strCaseHistoryID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetItemsInformationByID(objPrincipal, m_strCaseHistoryID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region  获取注射单信息
        /// <summary>
        /// 获取病历ID获取项目信息
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetInjectionInfoByID(string m_strSid, out ArrayList m_objList1, out ArrayList m_objList2, out ArrayList m_objListGroup, out clsOutpatientPrintRecipe_VO m_objVo)
        {
            long lngRes = 0;
            clsCalPatientChargeSvc m_objSvc = (clsCalPatientChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCalPatientChargeSvc));
            lngRes = m_objSvc.m_lngGetPrintData(m_strSid,out m_objList1,out m_objList2,out m_objListGroup,out m_objVo);
            return lngRes;
        }
                #endregion
    }
}
