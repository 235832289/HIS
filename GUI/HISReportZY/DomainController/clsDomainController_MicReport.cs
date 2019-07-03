using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDomainController_MicReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainController_MicReport()
        {
        }

        public long lngGetAllAnti(out DataTable dt)
        {
            using (clsMicReportSvc svc = (clsMicReportSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsMicReportSvc)))
            {
                return svc.lngGetAllAnti(out dt);
            }
        }

        public long lngGetFuzzyQueryAnti(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            using (clsMicReportSvc svc = (clsMicReportSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsMicReportSvc)))
            {
                return svc.lngGetFuzzyQueryAnti(micName, IsEnglish, out dtbResult);
            }
        }

        public long lngGetAllMic(out DataTable dt)
        {
            using (clsMicReportSvc svc = (clsMicReportSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsMicReportSvc)))
            {
                return svc.lngGetAllMic(out dt);
            }
        }

        public long lngGetFuzzyQueryMic(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            //com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
            //    (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
            //    (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            //lngRes = objSvc.lngGetFuzzyQueryMic(micName, IsEnglish, out dtbResult);
            return lngRes;
        }

        /// <summary>
        /// 细菌分布报告统计报表
        /// </summary>
        /// <param name="micname"></param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="SamtNo"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="AgeFrom"></param>
        /// <param name="AgeTo"></param>
        /// <param name="TestMethod"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns> 
        public long lngGetBacteriaDistribution(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            using (clsMicReportSvc svc = (clsMicReportSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsMicReportSvc)))
            {
                return svc.lngGetBacteriaDistribution(micname, p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, TestMethod, out dtbResult);
            }
        }
        //细菌分布趋势报告
        public long lngGetMicdistributionTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string TestMethod, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicdistributionTend(micname, p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, TestMethod, out dtbResult);
            return lngRes;
        }

        // 累计敏感性
        public long lngGetMicSensitive(DateTime p_dtDateFrom, DateTime p_dtDateTo, string SamtName, string DisName, string Sex, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicSensitive(p_dtDateFrom, p_dtDateTo, SamtName, DisName, Sex, TestMethod, strTempAntiID, out dtbResult);
            return lngRes;
        }

        #region 敏感率趋势报告
        /// <summary>
        /// 敏感率趋势报告
        /// </summary>
        /// <param name="micname"></param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="SamtNo"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="AgeFrom"></param>
        /// <param name="AgeTo"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns> 
        public long lngGetSensitiveTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            //com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
            //    (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
            //    (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            //lngRes = objSvc.lngGetSensitiveTend( micname,  p_dtDateFrom,  p_dtDateTO,  SamtNo,  DisNo,  Sex,  AgeFrom, AgeTo, TestMethod, strTempAntiID,out dtbResult);
            return lngRes;
        }
        #endregion

        public long lngGetMicCumulative(DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicCumulative(p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, TestMethod, strTempAntiID, out dtbResult);
            return lngRes;
        }

        public long lngGetSensitiveRate(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            //com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
            //    (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
            //    (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            //lngRes = objSvc.lngGetSensitiveRate(  micname,p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod,  strTempAntiID, out dtbResult);
            return lngRes;
        }

        //取得病区
        public long lngGetDeptName(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetDeptName(out  dtbResult);
            return lngRes;
        }

        //取得样本类型
        public long lngGetSamType(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetSamType(out  dtbResult);
            return lngRes;
        }
    }
}