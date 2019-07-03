using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    class clsController_SamplesCheckTotal : com.digitalwave.GUI_Base.clsController_Base
    {
        public long m_lngGetSamplesCheckTotal(out DataTable p_dtbResult, string strDateFrom, string strDateTo) 
        {
            long lngRes = 0;
            //System.Security.Principal.IPrincipal p_objPrincipal = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSampesCheckTotal =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));


            return lngRes = objSampesCheckTotal.m_lngGetSamplesCheckTotal(base.objPrincipal, out p_dtbResult, strDateFrom, strDateTo);
        }

        public long m_lngGetGermOccurRate(out DataTable p_dtbResult, string strDateFrom, string strDateTo) 
        {
            long lngRes = 0;
            //System.Security.Principal.IPrincipal p_objPrincipal = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objOccurRate =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));


            return lngRes = objOccurRate.m_lngGetGermOccurRate(base.objPrincipal, out p_dtbResult, strDateFrom, strDateTo);
        }

        /// <summary>
        /// 获取 【细菌分布趋势】报表数据
        /// </summary>
        public long m_lngGetGermDistributeTrend(out DataTable p_dtbResult, string strDateFrom, string strDateTo)
        {
            long lngRes = 0;
            //System.Security.Principal.IPrincipal p_objPrincipal = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objGermDistributeTrend =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));

            return lngRes = objGermDistributeTrend.m_lngGetGermDistributeTrend(base.objPrincipal, out p_dtbResult, strDateFrom, strDateTo);
        }

        public long m_lngGetAnimalculeCheckTotoal(out DataTable p_dtbResult, string strDateFrom, string strDateTo,ArrayList listSamples,ArrayList listPatientArea) 
        {
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objAnimalculeCheckTotal =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));

            return   objAnimalculeCheckTotal.m_lngGetAnimalculeCheckTotal(base.objPrincipal, out p_dtbResult, strDateFrom, strDateTo,listSamples,listPatientArea);
        }

        /// <summary>
        /// 样本列表
        /// </summary>
        /// <returns></returns>
        public DataTable m_dtbGetSamplesList() 
        {
            clsQueryStatSvc obj = (clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryStatSvc));
            return obj.m_dtbGetSamplesList();
        }

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public DataTable m_dtbGetDeptList()
        {
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc obj =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));

            return obj.m_dtbGetDeptList();
        }
    }
}
