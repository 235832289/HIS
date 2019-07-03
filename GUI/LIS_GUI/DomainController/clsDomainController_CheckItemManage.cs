using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainControl_LisDevice 的摘要说明。
	/// Alex 2004-5-6
	/// </summary>
	public class clsDomainController_CheckItemManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		private string strCheckItemID;

		public clsDomainController_CheckItemManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		public clsDomainController_CheckItemManage(string p_strCheckItemID)
		{
			strCheckItemID = p_strCheckItemID;		
		}

		#region 根据检验类别获取检验项目 童华 2004.10.12
		public long m_lngGetCheckItemArrByCheckCategory(string p_strCheckCategory,out DataTable p_dtbResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objSvc.m_lngGetCheckItemArrByCheckCategory(objPrincipal,p_strCheckCategory,out p_dtbResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 值模板

		#region 根据模板ID更新T_AID_LIS_VALUETEMPLATE_DETAIL的默认标记
		public long m_lngSetDefaultFlagByTemplateID(string p_strTemplateID,int p_intFlag)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngSetDefaultFlagByTemplateID(p_objPrincipal,p_strTemplateID,p_intFlag);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验类别、样本类别查询模板信息 童华 2004.08.10
		public long m_lngGetTemplateInfoByCondition(string p_strCheckCategory,string p_strSampleType,out clsLisValueTemplate_VO[] p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetTemplateInfoByCondition(p_objPrincipal,p_strCheckCategory,p_strSampleType,out p_objResultArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region 根据模板ID查询相应的模板明细信息 童华 2004.08.10
		public long m_lngGetTemplateDetailByTemplateID(string p_strTemplateID,out clsLisValueTemplateDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetTemplateDetailByTemplateID(p_objPrincipal,p_strTemplateID,out p_objResultArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验项目ID查询相应的模板明细信息 童华 2004.08.11
		public long m_lngGetTemplateDetailByCheckItemID(string p_strCheckItemID,out clsLisValueTemplateDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetTemplateDetailByCheckItemID(p_objPrincipal,p_strCheckItemID,out p_objResultArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增记录到表T_AID_LIS_VALUETEMPLATE_ITEM 童华 2004.08.11
		public long m_lngAddNewValueTemplateItem(clsLisValueTemplateItem_VO p_objRecord)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngAddNewValueTemplateItem(p_objPrincipal,p_objRecord);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除表T_AID_LIS_VALUETEMPLATE_ITEM的记录 童华 2004.08.11
		public long m_lngDelValueTemplateItem(clsLisValueTemplateItem_VO p_objRecord)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngDelValueTemplateItem(p_objPrincipal,p_objRecord);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 复用模板（如果新增模板的复用，则p_objOldRecord为null)
		public long m_lngReuseTemplate(clsLisValueTemplateItem_VO p_objOldRecord,clsLisValueTemplateItem_VO p_objNewRecord)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngReuseTemplate(p_objPrincipal,p_objOldRecord,p_objNewRecord);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验项目ID查询表T_AID_LIS_VALUETEMPLATE_ITEM的记录 童华 2004.08.11
		public long m_lngGetValueTemplateItemByCheckItemID(string p_strCheckItemID,out clsLisValueTemplateItem_VO p_objResult)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetValueTemplateItemByCheckItemID(p_objPrincipal,p_strCheckItemID,out p_objResult);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增检验项目的模板及其明细 童华 2004.08.11
		public long m_lngAddNewCheckItemVauleTemplate(clsLisValueTemplate_VO p_objValueTemplate,clsLisValueTemplateItem_VO p_objValueTemplateItem,
			clsLisValueTemplateDetail_VO[] p_objValueTemplateDetailArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngAddNewCheckItemVauleTemplate(p_objPrincipal,p_objValueTemplate,p_objValueTemplateItem,p_objValueTemplateDetailArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 批量新增、删除和修改模板明细信息 童华 2004.08.11
		public long m_lngValueTemplateDetailArr(ArrayList p_arlAddNewArr,ArrayList p_arlDelArr,ArrayList p_arlUpdArr,string p_strTemplateID,string p_strIdx)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngValueTemplateDetailArr(p_objPrincipal,p_arlAddNewArr,p_arlDelArr,p_arlUpdArr,p_strTemplateID,p_strIdx);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验项目ID查询模板的所有信息 童华 2004.08.12
		public long m_lngGetAllTemplateInfoByCheckItemID(string p_strCheckItemID,out clsLisValueTemplateItem_VO p_objTemplateItem,
			out clsLisValueTemplate_VO p_objTemplate,
			out clsLisValueTemplateDetail_VO[] p_objTemplateDetailArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetAllTemplateInfoByCheckItemID(p_objPrincipal,p_strCheckItemID,out p_objTemplateItem,
				out p_objTemplate,out p_objTemplateDetailArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#endregion

		#region 更新检验项目和参考值
		public long m_lngSetCheckItemAndRef(clsCheckItem_VO p_objCheckItem,clsCheckItemRef_VO[] p_objCheckItemRefArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSvc =
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSvc.m_lngSetCheckItemAndRef(objPrincipal,p_objCheckItem,p_objCheckItemRefArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 删除检验项目
		public long m_lngDelCheckItemAndRef(string p_strCheckItemID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSvc =
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSvc.m_lngDelCheckItemAndRef(objPrincipal,p_strCheckItemID);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 更新表该检验项目的基本信息
		public long m_lngSetCheckItemDetailByCheckItemID(clsCheckItem_VO p_objCheckItem)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSvc =
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSvc.m_lngSetCheckItemDetailByCheckItemID(objPrincipal,ref p_objCheckItem);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验类别、样本类别和标本组查询对应的检验项目 童华 2004.07.28
		public long m_lngQryCheckItemByCheckCategoryAndSampleType(string p_strCheckCategory,string p_strSampleType,string p_strSampleGroup,
			out DataTable dtbAllCheckItem)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngQryCheckItemByCheckCategoryAndSampleType(p_objPrincipal,p_strCheckCategory,p_strSampleType,p_strSampleGroup,
				out dtbAllCheckItem);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验类别和样本类别组合查询检验项目 童华 2004.06.29
		public long m_lngGetCheckItemArrByCondition(string p_strCheckCategoryID,string p_strSampleTypeID,out clsCheckItem_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemArrByCondition(objPrincipal,p_strCheckCategoryID,p_strSampleTypeID,out p_objResultArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据check_item_id查询对应的检验项目信息VO 刘彬 2004.06.09
		/// <summary>
		/// 根据check_item_id查询对应的检验项目信息VO
		/// </summary>
		/// <param name="p_strCheckItemID"></param>
		/// <param name="p_objCheckItemVO"></param>
		/// <returns></returns>
		public long m_lngGetCheckItemVOByCheckItemID(string p_strCheckItemID,out clsCheckItem_VO p_objCheckItemVO)
		{
			long lngRes = 0;
			p_objCheckItemVO = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemVOByCheckItemID(objPrincipal,p_strCheckItemID,out p_objCheckItemVO);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region 删除某一检验项目下的所有参考值范围 童华 2004.06.08
		public long m_lngDelCheckItemRefByCheckItemID(string strCheckItemID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc =
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngDelCheckItemRef(objPrincipal,strCheckItemID);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 新增检验项目 童华 2004.06.08
		public long m_lngAddNewCheckItem(ref clsCheckItem_VO objCheckItemVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc =
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngAddCheckItem(objPrincipal,ref objCheckItemVO);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 保存某一检验项目下的参考值系列 童华 2004.06.08
		public long m_lngAddCheckItemRefList(ref clsCheckItemRef_VO[] objCheckItemRefVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngAddCheckItemRefList(objPrincipal,ref objCheckItemRefVOList);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验类别和样品类别查询检验项目 童华 2004.05.16
		public long m_lngGetCheckItemByCheckCategoryAndSampleType(string strCheckCategory,string strSampleType,out DataTable dtbAllCheckItem)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngQryCheckItemByCheckCategoryAndSampleType(objPrincipal,strCheckCategory,strSampleType,out dtbAllCheckItem);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据检验项目分类获得检验项目
		/// <summary>
		/// 根据检验项目分类获得检验项目
		/// </summary>
		/// <param name="p_strCategoryID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetCheckItemByCategoryID(string p_strCategoryID,out clsCheckItem_VO[] p_objResultArr)
		{
			p_objResultArr = new clsCheckItem_VO[0];
			
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemByCategoryID(p_objPrincipal,p_strCategoryID,out p_objResultArr);
			//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 查询所有的检验项目类别
		/// <summary>
		/// 查询所有的检验项目类别
		/// </summary>
		/// <param name="p_strCategoryID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetCheckCategory(out clsCheckCategory_VO[] p_objResultArr)
		{
			p_objResultArr = new clsCheckCategory_VO[0];
			
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckCategory(p_objPrincipal,out p_objResultArr);
			//			objCheckItemSvc.Dispose();
			return lngRes;

			
		}
		#endregion

		#region 查询所有的检验项目类别 2004.07.15
		public long m_lngGetCheckCategory(out DataTable p_dtbResult)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetAllCheckCategory(p_objPrincipal,out p_dtbResult);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region 得到检验项目的参考范围 刘彬 2004.4.22 18:57
		public static clsReferenceValue s_objGetCheckItemRefVal(string p_strCheckItemID, string p_strSex, string p_strAge, string p_strMenses)
		{
			long lngRes = 0;			
			System.Security.Principal.IPrincipal objPrincipal = null;
			DataTable dtbCheckItemRef = null;
			clsReferenceValue objRefVal = null;
			try
			{
                com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                    (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
				DataRow dtrRef = null;
				#region 从附加参考值表查询符合条件的参考值
				clsCheckItemRef_VO objCheckItemRefVO = null;
				lngRes = objCheckItemSvc.m_lngGetCheckItemRefByCondition(objPrincipal,p_strAge,p_strSex,p_strMenses,p_strCheckItemID,out objCheckItemRefVO);
				if(lngRes > 0 && objCheckItemRefVO != null)
				{
					objRefVal = new clsReferenceValue(objCheckItemRefVO.m_strMin_Val,objCheckItemRefVO.m_strMax_Val);
					objRefVal.m_StrRefRange = objCheckItemRefVO.m_strRef_Val;
					return objRefVal;
				}
				#endregion
				#region 如果附加参考值表中没有符合条件的参考值则得到默认的参考值
				if(dtrRef == null)
				{
					lngRes = objCheckItemSvc.m_lngGetDefaultRefByCheckItemID(objPrincipal,p_strCheckItemID,out dtbCheckItemRef);
					if(lngRes >0 && dtbCheckItemRef != null && dtbCheckItemRef.Rows.Count !=0)
					{
						dtrRef = dtbCheckItemRef.Rows[0];
						objRefVal = new clsReferenceValue(
							dtrRef["REF_MIN_VAL_VCHR"] == System.DBNull.Value ? null:dtrRef["REF_MIN_VAL_VCHR"].ToString().Trim(),
							dtrRef["REF_MAX_VAL_VCHR"] == System.DBNull.Value ? null:dtrRef["REF_MAX_VAL_VCHR"].ToString().Trim());
						objRefVal.m_StrRefRange = dtrRef["REF_VALUE_RANGE_VCHR"] == System.DBNull.Value ? null:dtrRef["REF_VALUE_RANGE_VCHR"].ToString().Trim();
					}
				}				
				#endregion
			}
			catch(Exception ex)
			{
				//				try
				//				{
				new com.digitalwave.Utility.clsLogText().LogError(ex);
				//				}
				//				catch{}
				objRefVal = null;
			}
			return objRefVal;
		}
		public clsReferenceValue m_objGetCheckItemRefVal(string p_strSex, string p_strAge,string p_strMenses)
		{
			return clsDomainController_CheckItemManage.s_objGetCheckItemRefVal(this.strCheckItemID,p_strSex,p_strAge,p_strMenses);
		}
		#endregion xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

		#region 得到检验项目 CheckItem 的单位的方法 刘彬 2004.04.24 15:41
		public static string s_strGetCheckItemUnitByCheckItemID(string p_strCheckItemID)
		{
			if(p_strCheckItemID == null)
				return null;
			long lngRes = 0;
			string strUnit = null;
			DataTable dtbCheckItemsInfo = null;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			try
			{
                com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckCheckItemSvc =
                    (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
				lngRes = objCheckCheckItemSvc.m_lngGetCheckItemInfoByCheckItemID(p_objPrincipal,new string[]{p_strCheckItemID},out dtbCheckItemsInfo);
//				objCheckCheckItemSvc.Dispose();
				if(lngRes > 0 && dtbCheckItemsInfo != null && dtbCheckItemsInfo.Rows.Count != 0)
				{
					strUnit = dtbCheckItemsInfo.Rows[0]["UNIT_CHR"].ToString().Trim();
				}
			}
			catch(Exception ex)
			{
				new com.digitalwave.Utility.clsLogText().LogError(ex);
			}
			return strUnit;
		}
		public string m_strGetCheckItemUnit()
		{
			return s_strGetCheckItemUnitByCheckItemID(this.strCheckItemID);
		}
		#endregion xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	}
}
