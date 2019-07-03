using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    ///  T_OPR_LIS_APPLICATION【检验申请单新增,修改,删除】
    /// </summary>
    internal class clsApplicationSmp : clsDomainController_Base
    {

        #region 构造


        private clsApplicationSmp()
        {
            objSvc = (clsApplicationSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
        }
        private clsApplicationSvc objSvc;

        public static clsApplicationSmp s_obj
        {
            get
            {
                return new clsApplicationSmp();
            }
        }

        #endregion

        /// <summary>
        ///新增检验申请单
        /// </summary>
        /// <param name="objApplMainVO"></param>
        /// <returns></returns>
        public long m_lngAddNewApplication(clsLisApplMainVO objApplMainVO)
        {
            clsLisApplMainVO objOutVO = null;
            long lngRes = 0;

            clsApplicationSvc objAppSvc =
                              (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));

            try
            {
                lngRes = objAppSvc.m_lngAddNewAppl(objPrincipal, objApplMainVO, out objOutVO);
                if (lngRes > 0 && objOutVO != null)
                {
                    objOutVO.m_mthCopyTo(objApplMainVO);
                }
            }
            catch 
            {
                lngRes = 0;
            }
            return lngRes;
        }

    }
}
