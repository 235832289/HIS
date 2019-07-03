using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 系统参数Smp
    /// </summary>
    internal class clsDcl_SysParamSmp : GUI_Base.clsDomainController_Base
    {

        public clsDcl_SysParamSmp() 
        {
            objSvc=(clsSysParamVOSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSysParamVOSvc));
        }

        private clsSysParamVOSvc objSvc;
        public static clsDcl_SysParamSmp s_object 
        {
            get 
            {
                return new clsDcl_SysParamSmp();
            }
        }

        public long m_lngInsert(clsSysParamVO sysParamVO) 
        {
            long lngRes = 0;
            try
            {
                lngRes = objSvc.m_lngInsert(sysParamVO);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        public long m_lngDelete(string sysParamCode)
        {
            long lngRes = 0;
            try
            {
                lngRes = objSvc.m_lngDelete(sysParamCode);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        public long m_lngUpdate(clsSysParamVO sysParamVO) 
        {
            long lngRes = 0;
            try
            {
                lngRes = objSvc.m_lngUpdate(sysParamVO);
            }
            catch 
            {
                lngRes = 0;
            }
            return lngRes;
        }


        public long m_lngFind(out clsSysParamVO[] arrParams) 
        {
            long lngRes = 0;
            arrParams = null;
            try
            {
                lngRes=objSvc.m_lngFind(out arrParams);
            }
            catch 
            {
                lngRes = 0;
            }
            return lngRes;
        }

    }
}
