using System;
using com.digitalwave.iCare.common;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for clsController_SampleTypeInfo.
	/// </summary>
	public class clsController_SampleTypeInfo : com.digitalwave.GUI_Base.clsController_Base
	{
		public clsController_SampleTypeInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public long AddNewSample(string strSampleType,string strPyCode,string strWbCode,int intHasBarCode,out string strSampleTypeID)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			clsCheckItemSvc objSampleTypeSvc = 
				            (clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCheckItemSvc));
			clsSampleType_VO objSampleTypeVO= new clsSampleType_VO();
			objSampleTypeVO.m_strPyCode = strPyCode;
			objSampleTypeVO.m_strSample_Type_Desc = strSampleType;
			objSampleTypeVO.m_strWbCode = strWbCode;
            objSampleTypeVO.m_intHasBarCode = intHasBarCode;
			lngRes = objSampleTypeSvc.m_lngAddSampleType(p_objPrincipal,ref objSampleTypeVO);
			strSampleTypeID = objSampleTypeVO.m_strSample_Type_ID;
//			objSampleTypeSvc.Dispose();
			return lngRes;
		}

		public long DelSampleType(string strSampleTypeID)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSampleTypeSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSampleTypeSvc.m_lngDelSampleTypeBySampleTypeID(p_objPrincipal,strSampleTypeID);
//			objSampleTypeSvc.Dispose();
			return lngRes;
		}

		public long SetSampleTypeDetail(string strSampleType,string strPyCode,string strWbCode,string strSampleTypeID,int intHasCode)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			clsCheckItemSvc objSampleTypeSvc = 
				            (clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCheckItemSvc));
            lngRes = objSampleTypeSvc.m_lngSetSampleTypeDetailBySampleTypeID(p_objPrincipal, strSampleType, strPyCode, strWbCode, strSampleTypeID, intHasCode);
//			objSampleTypeSvc.Dispose();
			return lngRes;
		}

		//查询某一样品类别的所有样品性状
		public long QryAllSampleCharacter(out System.Data.DataTable dtbAllSampleCharacter,string strSampleTypeID)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSampleCharacterSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSampleCharacterSvc.m_lngGetAllSampleCharacter(p_objPrincipal,strSampleTypeID,out dtbAllSampleCharacter);
//			objSampleCharacterSvc.Dispose();
			return lngRes;
		}

		//查询所有的样品类别
		public long QryAllSampleType(out System.Data.DataTable dtbAllSampleType)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objSampleCharacterSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objSampleCharacterSvc.m_lngGetAllSampleType(p_objPrincipal,out dtbAllSampleType);
//			objSampleCharacterSvc.Dispose();
			return lngRes;
		}

		//新增样本性状记录
		public long AddNewSampleCharacter(string strSampleCharacter,string strPyCode,string strWbCode,string strSampleTypeID,ref string strSEQ)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.ValueObject.clsSampleCharacter_VO objSampleCharacterVO = new com.digitalwave.iCare.ValueObject.clsSampleCharacter_VO();
			objSampleCharacterVO.m_strCharacter_Desc = strSampleCharacter;
			objSampleCharacterVO.m_strPyCode = strPyCode;
			objSampleCharacterVO.m_strSample_Type_ID = strSampleTypeID;
			objSampleCharacterVO.m_strwbCode = strWbCode;
			objSampleCharacterVO.m_strCharacter_Ord = strSEQ;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSampleCharacterSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSampleCharacterSvc.m_lngAddSampleCharacterBySampleTypeID(p_objPrincipal,ref objSampleCharacterVO);
//			objSampleCharacterSvc.Dispose();
			strSEQ = objSampleCharacterVO.m_strCharacter_Ord;
			return lngRes;
		}

		//更样本性状记录
		public long SetSampleCharacter(string strSampleCharacter,string strPyCode,string strWbCode,string strSampleTypeID, string strSEQ)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSampleCharacterSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSampleCharacterSvc.m_lngSetSampleCharacterBySampleTypeIDAndSEQ(p_objPrincipal,strSampleTypeID,strSEQ,strSampleCharacter,
				strPyCode,strWbCode);
//			objSampleCharacterSvc.Dispose();
			return lngRes;
		}

		//删除样本性状记录
		public long DelSampleCharacter(string strSEQ,string strSampleTypeID)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objSampleCharacterSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objSampleCharacterSvc.m_lngDelSampleCharacterBySampleTypeIDAndSEQ(p_objPrincipal,strSampleTypeID,strSEQ);
//			objSampleCharacterSvc.Dispose();
			return lngRes;
		}
	}
}
