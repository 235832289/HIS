using System;
using com.digitalwave.DataShareService ;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsInPatientCaseHisoryDefaultDomain.
	/// </summary>
	public class clsInPatientCaseHisoryDefaultDomain
	{
		public clsInPatientCaseHisoryDefaultDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        //private clsInPatientCaseHisoryDefaultService m_objServ = new clsInPatientCaseHisoryDefaultService();

		#region �õ����е�InPatientCaseHisoryDefault,Domain��,��ӱԴ,2003-5-7 19:24:10
		//�ڴ˱�дͬ�๦�ܺ�����
		public clsInPatientCaseHisoryDefaultValue[] lngGetAllInPatientCaseHisoryDefault(string p_strInPaitentID,string p_strInPatientDate)
		{
			clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultArr=null;

            clsInPatientCaseHisoryDefaultService m_objServ =
                (clsInPatientCaseHisoryDefaultService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInPatientCaseHisoryDefaultService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.lngGetAllInPatientCaseHisoryDefault  (clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID, p_strInPatientDate,out objInPatientCaseHisoryDefaultArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return(objInPatientCaseHisoryDefaultArr );
		}
		#endregion
	}
}
