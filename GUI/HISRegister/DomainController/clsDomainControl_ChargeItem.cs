using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 收费项目以及各相关项目的数据控制层 Create By Sam 2004-6-9
	/// </summary>
	public class clsDomainControl_ChargeItem:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControl_ChargeItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//收费项目
		#region 新增收费项目
		public long m_mthInsertCASEHISCHR(string GroupID,string strCatID,string strName)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_mthInsertCASEHISCHR(objPrincipal,GroupID,strCatID,strName);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
//		#region 修改收费项目
//		public long m_lngDoUpdChargeItem(clsChargeItem_VO p_objResultArr)
//		{
//			long lngRes=0;
//			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
//				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
//			lngRes = objSvc.m_lngDoUpdChargeItemByID(objPrincipal,p_objResultArr);
//			objSvc.Dispose();
//			return lngRes;
//		}
//		#endregion
		#region 删除收费项目
		public long m_mthDeleteCASEHISCHR(string strID,string strCatID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_mthDeleteCASEHISCHR(objPrincipal,strID,strCatID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region 查找收费项目（根据组ID查询项目)
		public long m_mthGetCASEHISCHR(string strID,out DataTable dt)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_mthGetCASEHISCHR(objPrincipal,strID,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		

		//收费项目分类类型
		#region 新增收费项目分类类型
		public long m_lngAddCat(clsCharegeItemCat_VO objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoAddNewChargeItemCat(objPrincipal,objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 修改收费项目分类类型
		public long m_lngDoUpdCatByID(clsCharegeItemCat_VO p_objResultArr,string ID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoUpdChargeItemCatByID(objPrincipal,p_objResultArr,ID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 删除收费项目分类类型
		public long m_lngDelCatByID(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDeleteChargeItemCatByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 查询收费项目分类类型
		public long m_lngFindCat(out clsCharegeItemCat_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindChargeItemCatList(objPrincipal,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		//收费特别类别
		#region 新增收费特别类别
		public long m_lngAddEXType(clsChargeItemEXType_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoAddNewChargeItemEXType(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 修改收费特别类别
		public long m_lngDoUpdEXType(clsChargeItemEXType_VO p_objResultArr,string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoUpdChargeItemEXTypeByID(objPrincipal,p_objResultArr,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 删除收费特别类别
		public long m_lngDelEXType(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDeleteCharegeItemEXTypeByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 查找收费特别类别
		public long m_GetEXType(string strFlag,out clsChargeItemEXType_VO[] objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindChargeItemEXTypeListByFlag(objPrincipal,strFlag,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		//用法
		#region 新增用法
		public long m_lngAddUsage(clsUsageType_VO p_objResultArr,out string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngAddNewUsage(objPrincipal,p_objResultArr,out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 修改用法
		public long m_lngDoUpdUsage(clsUsageType_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoUpUsage(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 删除用法
		public long m_lngDelUsage(string strID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDelUsage(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		//用法项目
		#region 新增用法项目
		/// <summary>
		/// 新增用法项目	[没有用了]
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngDoAddNewChargeItemUsageGroup(clsChargeItemUsageGroup_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoAddNewChargeItemUsageGroup(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 新增用法项目	徐斌辉加	2005-03-17
		/// </summary>
		/// <param name="p_strRecordID">流水号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngDoAddNewChargeItemUsageGroup(out string p_strRecordID,clsChargeItemUsageGroup_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoAddNewChargeItemUsageGroup(objPrincipal,out p_strRecordID,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
        #region 新增中药用法带出的项目
        /// <summary>
        ///新增中药用法带出的项目
        /// </summary>
        /// <param name="p_strRecordID">流水号</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngDoAddNewChargeItemCMUsageGroup(out string p_strRecordID, clsChargeItemUsageGroup_VO p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
            lngRes = objSvc.m_lngDoAddNewChargeItemCMUsageGroup(objPrincipal, out p_strRecordID, p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 修改用法项目
        /// <summary>
		/// 修改用法项目	徐斌辉修改	2005-03-17
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngDoModifyChargeItemUsageGroup(clsChargeItemUsageGroup_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoModifyChargeItemUsageGroup(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
        #region 修改中药用法的项目
        /// <summary>
        /// 修改中药用法的项目
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngDoModifyChargeItemCMUsageGroup(clsChargeItemUsageGroup_VO p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
            lngRes = objSvc.m_lngDoModifyChargeItemCMUsageGroup(objPrincipal, p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 删除用法项目
        public long m_lngDelUsageGroupByID(clsChargeItemUsageGroup_VO p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDelUsageGroupByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
        #region 删除中药用法项目
        public long m_lngDelCMUsageGroupByID(clsChargeItemUsageGroup_VO p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
            lngRes = objSvc.m_lngDelCMUsageGroupByID(objPrincipal, p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion 
		#region 查询用法项目
		public long m_lngFindItemByUsageID(string strUsageID,out clsChargeItem_VO[] p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetItemByUsageID(objPrincipal,strUsageID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
        #region 查询用法项目
        public long m_lngGetItemByCMUsageID(string strUsageID, out clsChargeItem_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
            lngRes = objSvc.m_lngGetItemByCMUsageID(objPrincipal, strUsageID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion 
		#region 查询用法表中没有的项目
		public long m_lngFindItemNoUsageGroup(string strCatID,string strUsageID,out DataTable p_objResultArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetItemNoUsageGroup(objPrincipal,strCatID,strUsageID,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		//查询
		#region 根据项目分类的ID取得最上级的目录
		public long m_lngGetGroupCat(string strID,out clsChargeItem_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsChargeItem_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetGroupCat(objPrincipal,strID,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 查询所有用法
		public long m_lngGetUsage(out clsUsageType_VO[] objResult,string strEx)
		{
			long lngRes=0;
			objResult=new clsUsageType_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
			lngRes = objSvc.m_lngFindAllUsage(objPrincipal,out objResult,strEx);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region 查询所有用法设置
		public long m_lngGetUsageSet(out clsUsageType_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsUsageType_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
			lngRes = objSvc.m_lngFindAllUsageSet(objPrincipal,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增用法设置
		public long m_lngDoAddNewUsageType(string p_usageID,string p_usageType)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
			lngRes = objSvc.m_lngDoAddNewUsageType(objPrincipal,p_usageID,p_usageType);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region 删除用法设置
		public long m_lngDelUsageSet(string p_usageID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
			lngRes = objSvc.m_lngDelUsageSet(objPrincipal,p_usageID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		


		#region 查询所有单位
		public long m_lngGetUnit(out clsUnit_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsUnit_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
			lngRes = objSvc.m_lngFindAllUnit(objPrincipal,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		

		#region 取回所有未有目录的项目
		public long m_lngGetNoGroup(string strCatID,out clsChargeItem_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsChargeItem_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetItemNoGroup(objPrincipal,strCatID,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据项目编号取回项目
		public long m_GetItemByItemCode(string strID,out clsChargeItem_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsChargeItem_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetItemByItemCode(objPrincipal,strID,out objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据用法ID查询用法
		public long m_lngGetUsageByCode(string strCode,out clsUsageType_VO[] objResult)
		{
			long lngRes=0;
			objResult=new clsUsageType_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_GetUsage(objPrincipal,out objResult,strCode);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据源ID取回源名称
		public long m_GetSourName(string strID,string SourType,out string strName)
		{
			long lngRes=0;
			strName="";
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindSour(objPrincipal,strID,SourType,out strName);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据源列表
		public long m_GetAllSour(string SourType,ref DataTable dtResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindAllSour(objPrincipal,SourType,ref dtResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		// 收费项目用法
		#region 查询收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 查询收费项目用法
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngFindUsageTypeList(out clsUsageType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc =	(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngFindUsageTypeList(objPrincipal, out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 新增收费项目用法
		/// </summary>
		/// <param name="strCode"></param>
		/// <param name="strName"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		public long m_lngAddUsageType(string strCode, string strName, out string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoAddNewUsageType(objPrincipal, strCode, strName, out strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 修改收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 修改收费项目用法
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngDoUpdUsageTypeByID(clsUsageType_VO p_objResultArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoUpdUsageTypeByID(objPrincipal,p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 删除收费项目用法
		/// </summary>
		/// <param name="strID"></param>
		/// <returns></returns>
		public long m_lngDelUsageTypeByID(string strID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDelUsageTypeByID(objPrincipal,strID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 新增与删除单据
		/// <summary>
		/// 新增与删除单据
		/// </summary>
		/// <param name="strID"></param>
		/// <returns></returns>
		public long m_lngDoUpdUsageorderid_vchrByIDAndTypeId(int p_intTypeindex,string p_strUsageID,string p_strGroupID,bool p_blnAdd)
		
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDoUpdUsageorderid_vchrByIDAndTypeId(objPrincipal,p_intTypeindex,p_strUsageID,p_strGroupID,p_blnAdd);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 根据传入的SQL语句查询出数据
		
		public long m_lngGetData(string SQLstr,out DataTable dt)
		{
			dt=null;
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngGetData(objPrincipal,SQLstr,out dt);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 删除收费项目
		
		public long m_lngDel(string ID)
		{
		
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc));
			lngRes = objSvc.m_lngDelCharegeItem(objPrincipal,ID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
