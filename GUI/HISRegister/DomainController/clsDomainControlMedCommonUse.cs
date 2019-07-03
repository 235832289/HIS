using System;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomainControlMedCommonUse 的摘要说明。
	/// </summary>
	public class clsDomainControlMedCommonUse:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControlMedCommonUse()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public long GetMedBseInfo(string p_strMedSort,string p_strMedShape,out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.m_lngGetMedBseInfo(this.objPrincipal, p_strMedSort, p_strMedShape, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}

		public long GetPrjBseInfo(string p_strMedSort,out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.m_lngGetPrjBseInfo(this.objPrincipal, p_strMedSort, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		
		public long GetMedSort(out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.m_lngGetMedSort(this.objPrincipal, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		public long GetMedShape(out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.m_lngGetMedShape(this.objPrincipal, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		public long GetMedCommonUseInfo(com.digitalwave.iCare.ValueObject.clsLoginInfo p_loginInfo,out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.GetMedCommonUseInfo(this.objPrincipal, p_loginInfo, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		//GetPrjCommonUseInfo

		public long GetPrjCommonUseInfo(com.digitalwave.iCare.ValueObject.clsLoginInfo p_loginInfo,out System.Data.DataTable p_outdtResult)
		{
			p_outdtResult = null;
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
			try
			{
                lngRes = objSvc.GetPrjCommonUseInfo(this.objPrincipal, p_loginInfo, out p_outdtResult);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return -1;
			}
			return lngRes;
		}
		public long SaveMedCommonUseInfo(System.Data.DataTable p_SrcDt,System.Data.DataTable p_DelDt,string strType)
		{			
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			long lngRes;
            lngRes = objSvc.SavePrjCommonUseInfo(this.objPrincipal, p_SrcDt, p_DelDt, strType);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		public bool IsHasPrescriptionRight(string p_strEmpID)
		{
			com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedCommonUseSvc));
			bool bRes;
			try
			{
                bRes = objSvc.m_bIsHasPrescriptionRight(this.objPrincipal, p_strEmpID);
                objSvc.Dispose();
                objSvc = null;
			}
			catch
			{
				return false;
			}
			return bRes;
		}
	}
}
