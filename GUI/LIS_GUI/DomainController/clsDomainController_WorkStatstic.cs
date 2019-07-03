using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.LIS
{
    public class clsDomainController_WorkStatstic : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainController_WorkStatstic()
        {

        }

        public long lngGetWorkStatstic(int p_intQueryType, DateTime p_dtDateFrom, DateTime p_dtDateTO, int p_strQuery, string p_strCondition, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc));
            lngRes = objSvc.lngGetWorkStatstic(p_intQueryType, p_dtDateFrom, p_dtDateTO, p_strQuery, p_strCondition, out dtbResult);
            return lngRes;
        }

        public long lngGetDept(out DataTable dtbDept)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc));
            lngRes = objSvc.lngGetDept(out dtbDept);
            return lngRes; 
        }

        public long lngGetEmployee(out DataTable dtbEmp)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsWorkStatsticSvc));
            lngRes = objSvc.lngGetEmployee(out  dtbEmp);
            return lngRes;
        }
    }
}
