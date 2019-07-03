using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.LIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public class clsTmdQCReportSmp
    {

        public static clsTmdQCReportSmp s_object
        {
            get
            {
                return new clsTmdQCReportSmp();
            }
        }

        #region Parameters
        clsTmdQCReportSvc m_objSvc;
        private System.Security.Principal.IPrincipal m_objPrincipal;
        #endregion

        #region Construtor
        public clsTmdQCReportSmp()
        {
            m_objSvc = (clsTmdQCReportSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(clsTmdQCReportSvc));
            m_objPrincipal = new clsGetPrincipal().m_objPrincipal;
        }
        #endregion

        #region INSERT
        public long m_lngInsert(clsLisQCReportVO p_objRecord)
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
        public long m_lngUpdate(clsLisQCReportVO p_objRecord)
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
        public long m_lngFind(int p_intID, out clsLisQCReportVO p_objRecord)
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

        public long m_lngFind(out clsLisQCReportVO[] p_objRecordArr)
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

        public long m_lngFind(int p_intQCBatchSeq, DateTime p_datBegin, 
            DateTime p_datEnd, enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long lngRes = 0;
            p_objQCReportArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intQCBatchSeq, p_datBegin,
                    p_datEnd, p_status, out p_objQCReportArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        /// <summary>
        /// 查找质控样本结果数据
        /// </summary>
        /// <param name="p_intQCBatchSeqArr"></param>
        /// <param name="p_datBegin"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_status"></param>
        /// <param name="p_objQCReportArr"></param>
        /// <returns></returns>
        public long m_lngFind(int[] p_intQCBatchSeqArr, DateTime p_datBegin,
            DateTime p_datEnd, enmQCStatus p_status, out clsLisQCReportVO[] p_objQCReportArr)
        {
            long lngRes = 0;
            p_objQCReportArr = null;
            try
            {
                lngRes = m_objSvc.m_lngFind(m_objPrincipal, p_intQCBatchSeqArr, p_datBegin,
                    p_datEnd, p_status, out p_objQCReportArr);
            }
            catch { lngRes = 0; }
            return lngRes;
        }
        #endregion
    }
}