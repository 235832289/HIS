using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsTmdQCSampleLotParaSmp
    {

        public static clsTmdQCSampleLotParaSmp s_object
        {
            get
            {
                return new clsTmdQCSampleLotParaSmp();
            }
        }

        #region Parameters
        clsTmdQCSampleLotParaSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;
        #endregion

        #region Construtor
        public clsTmdQCSampleLotParaSmp()
        {
            m_objSvc = (clsTmdQCSampleLotParaSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(clsTmdQCSampleLotParaSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region INSERT
        public long m_lngInsert(clsLisQCSampleLotParaVO p_objRecord)
        {
            int intID = -1;
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngInsert(m_objPrincipal, p_objRecord);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion

        #region UPDATE
        public long m_lngUpdate(clsLisQCSampleLotParaVO p_objRecord)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngUpdate(m_objPrincipal, p_objRecord);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion

        #region DELETE
        public long m_lngDelete(string p_strCheckItemId, int p_intQCSmplotSeq)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngDelete(m_objPrincipal, p_strCheckItemId, p_intQCSmplotSeq);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion

        #region FIND
        public long m_lngFind(string p_strCheckItemId, int p_intQCSmplotSeq, out clsLisQCSampleLotParaVO p_objRecord)
        {
            long lngRes = 0;
            p_objRecord = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_strCheckItemId, p_intQCSmplotSeq, out p_objRecord);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}