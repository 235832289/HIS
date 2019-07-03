using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsTmdWorkGroupSmp
    {

        public static clsTmdWorkGroupSmp s_object
        {
            get
            {
                return new clsTmdWorkGroupSmp();
            }
        }

        #region Parameters
        clsTmdWorkGroupSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;
        #endregion

        #region Construtor
        public clsTmdWorkGroupSmp()
        {
            m_objSvc = (clsTmdWorkGroupSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(clsTmdWorkGroupSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region INSERT
        public long m_lngInsert(clsLisWorkGroupVO p_objRecord)
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
        public long m_lngUpdate(clsLisWorkGroupVO p_objRecord)
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
        public long m_lngFind(int p_intID, out clsLisWorkGroupVO p_objRecord)
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
        public long m_lngFind(out clsLisWorkGroupVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}