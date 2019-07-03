using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsTmdQCBatchConcentrationSmp
    {

        public static clsTmdQCBatchConcentrationSmp s_object
        {
            get
            {
                return new clsTmdQCBatchConcentrationSmp();
            }
        }

        #region Parameters
        clsTmdQCBatchConcentrationSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;
        #endregion

        #region Construtor
        public clsTmdQCBatchConcentrationSmp()
        {
            m_objSvc = (clsTmdQCBatchConcentrationSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(clsTmdQCBatchConcentrationSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region INSERT
        public long m_lngInsert(clsLisQCConcentrationVO p_objRecord)
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
        public long m_lngUpdate(clsLisQCConcentrationVO p_objRecord)
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
        public long m_lngDelete(int p_intQCBatchSeq, int p_intConcentrationSeq)
        {
            long lngRes = 0;
            try
            {
                lngRes = m_objSvc.m_lngDelete(m_objPrincipal, p_intQCBatchSeq, p_intConcentrationSeq);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion

        #region FIND
        public long m_lngFind(int p_intQCBatchSeq, int p_intConcentrationSeq, out clsLisQCConcentrationVO p_objRecord)
        {
            long lngRes = 0;
            p_objRecord = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intQCBatchSeq, p_intConcentrationSeq, out p_objRecord);
            }
            catch { lngRes = 0; }
            return lngRes;
        }

        public long m_lngFind(int p_intQCBatchSeq, out clsLisQCConcentrationVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intQCBatchSeq, out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }

        /// <summary>
        /// 查找质控浓度设置
        /// </summary>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        public long m_lngFind(int[] p_intQCBatchSeqArr, out clsLisQCConcentrationVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intQCBatchSeqArr, out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }

        public long m_lngFindDeleted(int p_intQCBatchSeq, out clsLisQCConcentrationVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFindDeleted(m_objPrincipal, p_intQCBatchSeq, out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }

        public long m_lngFind(out clsLisQCConcentrationVO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal,out p_objRecordArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}