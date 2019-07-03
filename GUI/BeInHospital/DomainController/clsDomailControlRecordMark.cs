using System;
using System.Data;
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomailControlRecordMark ��ժҪ˵����
	/// </summary>
	public class clsDomailControlRecordMark:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomailControlRecordMark()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public long m_objGetRecordMark(System.Security.Principal.IPrincipal p_objPrincipal,out clsRecordMark_VO[] p_objVO,string dateStar,string dateEnd)
		{
			long lngRes = 1;
			com.digitalwave.iCare.middletier.HIS.clsRecordMark objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRecordMark)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecordMark));
			lngRes = objSvc.m_objGetRecordMark(p_objPrincipal,out p_objVO,dateStar,dateEnd);
			return lngRes;
		}
		public long m_objGetRecordMark(System.Security.Principal.IPrincipal p_objPrincipal,out clsRecordMark_VO[] p_objVO,string dateStar,string dateEnd,string strTable)
		{
			long lngRes = 1;
			com.digitalwave.iCare.middletier.HIS.clsRecordMark objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRecordMark)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecordMark));
			lngRes = objSvc.m_objGetRecordMark(p_objPrincipal,out p_objVO,dateStar,dateEnd,strTable);
			return lngRes;
        }

        #region TextList�ؼ���ȡ���� glzhang 2006.4.11
        /// <summary>
        /// TextList�ؼ���ȡ���� glzhang 2006.4.11
        /// </summary>
        /// <param name="p_strSQL"></param>
        /// <param name="p_dtbRecord"></param>
        /// <returns></returns>
        public long m_lngGetData(string p_strSQL,out DataTable p_dtbRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsOrderExecuteReportSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderExecuteReportSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderExecuteReportSvc));
            return objSvc.m_lngGetTextListData(objPrincipal, p_strSQL, out p_dtbRecord);
        }
        #endregion
    }
}
