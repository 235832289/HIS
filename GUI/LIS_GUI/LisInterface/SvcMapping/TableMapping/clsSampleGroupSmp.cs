using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsSampleGroupSmp : clsDomainController_Base
    {

        #region 构  造


        private clsSampleGroupSmp()
        {
            objSvc = (clsQuerySampleGroupSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuerySampleGroupSvc));
        }
        private clsQuerySampleGroupSvc objSvc;
        public static clsSampleGroupSmp s_obj
        {
            get
            {
                return new clsSampleGroupSmp();
            }
        }

        #endregion

        #region 根据申请单元ID得到它所在标本组的VO
        /// <summary>
        /// 根据检验项目ID获得标本组的VO
        /// </summary>
        /// <param name="applyUnitId"></param>
        /// <param name="p_intPrintSeq"></param>
        /// <param name="sampleGroupVO"></param>
        /// <returns></returns>
        public long m_lngGetSampleGoupVO(string applyUnitId, out clsSampleGroup_VO sampleGroupVO)
        {
            long lngRes = 0;
            sampleGroupVO = null;
            try
            {
                lngRes=objSvc.m_lngGetSampleGoupVOByApplyUnitID(objPrincipal, applyUnitId, out sampleGroupVO);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

    }
}
