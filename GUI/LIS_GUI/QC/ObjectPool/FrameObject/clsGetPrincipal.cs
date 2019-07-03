using System;

namespace com.digitalwave.iCare.gui.LIS
{
    public class clsGetPrincipal : com.digitalwave.GUI_Base.clsController_Base
    {
        public System.Security.Principal.IPrincipal m_objPrincipal
        {
            get
            {
                return this.objPrincipal;
            }
        }
    }
}