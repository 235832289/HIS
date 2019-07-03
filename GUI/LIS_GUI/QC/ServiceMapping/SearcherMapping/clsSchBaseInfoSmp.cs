using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
    public class clsSchBaseInfoSmp
    {
        #region Property
        public static clsSchBaseInfoSmp s_object
        {
            get
            {
                return new clsSchBaseInfoSmp();
            }
        }
        #endregion

        #region Parameters

        private com.digitalwave.iCare.middletier.LIS.clsSchBaseInfoSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;

        #endregion

        #region Construtor
        public clsSchBaseInfoSmp()
        {
            m_objSvc = (com.digitalwave.iCare.middletier.LIS.clsSchBaseInfoSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsSchBaseInfoSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region 返回检验项目树
        public long m_lngGetCheckItemTree(out clsLISUserGroupNode root)
        {
            root = null;
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngGetCheckItemTree(m_objPrincipal, out root);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}