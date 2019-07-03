using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsTmdQCSampleLotSmp
    {

        public static clsTmdQCSampleLotSmp s_object
        {
            get
            {
                return new clsTmdQCSampleLotSmp();
            }
        }

        #region Parameters
        clsTmdQCSampleLotSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;
        #endregion

        #region Construtor
        public clsTmdQCSampleLotSmp()
        {
            m_objSvc = (clsTmdQCSampleLotSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(clsTmdQCSampleLotSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region INSERT
        public long m_lngInsert(clsLisQCSamplelotVO p_objRecord)
        {

            int intID = -1;
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngInsert(m_objPrincipal, p_objRecord, out intID);
            }
            catch { lngRes = 0; }
            if (lngRes > 0)
            {
                p_objRecord.m_intSeq = intID;
            }
            return lngRes;
        }
        #endregion

        #region UPDATE
        public long m_lngUpdate(clsLisQCSamplelotVO p_objRecord)
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
        public long m_lngDelete(int p_intID)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngDelete(m_objPrincipal, p_intID);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion

        #region FIND
        public long m_lngFind(int p_intID, out clsLisQCSamplelotVO p_objRecord)
        {
            long lngRes = 0;
            p_objRecord = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intID, out p_objRecord);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}