using System;
using com.digitalwave.CommonUseServ;
using iCareData;

namespace iCare
{
	/// <summary>
	/// 默认值的商业逻辑层
	/// </summary>
	public class clsDefaultValueDomain
	{
        //private clsDefaultValueService m_objServ;

		public clsDefaultValueDomain()
		{
            //m_objServ = new clsDefaultValueService();
		}
		
		public long m_lngSaveDefaultValue(clsCustomDefaultValue[] p_objArr)
		{
            clsDefaultValueService m_objServ =
                (clsDefaultValueService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDefaultValueService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngSaveDefaultValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public long m_lngGetDefaultValue(string p_strAreaID,string p_strFormName,out clsCustomDefaultValue[] p_objArr)
		{
            clsDefaultValueService m_objServ =
                (clsDefaultValueService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDefaultValueService));

			long lngRes = 0;
            try
            {
                string strDeptID = "";
                string strAreaID = "";

                if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment != null)
                {
                    strDeptID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR;
                    if (com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea == null)
                        strAreaID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment.m_strDEPTID_CHR;
                    else
                        strAreaID = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR;
                }
                else if (MDIParent.m_objCurrentPatient != null)
                {
                    strDeptID = MDIParent.m_objCurrentPatient.m_strDEPTID_CHR;
                    strAreaID = MDIParent.m_objCurrentPatient.m_strAREAID_CHR;
                }
                //lngRes = m_objServ.m_lngGetDefaultValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,
                //clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,p_strAreaID,p_strFormName,
                //out p_objArr);
                lngRes = m_objServ.m_lngGetDefaultValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,
                strDeptID, strAreaID, p_strFormName, out p_objArr);
               
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
	}
}
