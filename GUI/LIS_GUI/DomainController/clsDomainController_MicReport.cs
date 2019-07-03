using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.LIS
{
    public class clsDomainController_MicReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDomainController_MicReport( )
        {
        }

        public long lngGetAllAnti(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetAllAnti(out dtbResult);
            return lngRes;
        }

        public long lngGetFuzzyQueryAnti(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetFuzzyQueryAnti(micName, IsEnglish, out dtbResult);
            return lngRes;
        }

        public long lngGetAllMic(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetAllMic(out dtbResult);
            return lngRes;
        }

        public long lngGetFuzzyQueryMic(string micName, bool IsEnglish, out DataTable dtbResult)
        { 
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetFuzzyQueryMic(micName, IsEnglish, out dtbResult);
            return lngRes;
        }

        //细菌分布报告统计报表
        public long lngGetBacteriaDistribution(string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetBacteriaDistribution(micname,p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, out dtbResult);
            return lngRes;
        }
        //细菌分布趋势报告
        public long lngGetMicdistributionTend(string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicdistributionTend(micname,p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod, out dtbResult);
            return lngRes;
        }

        // 累计敏感性
        public long lngGetMicSensitive(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTo, string SamtName, string DisName, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicSensitive(micname, p_dtDateFrom, p_dtDateTo, SamtName, DisName, Sex, AgeFrom,AgeTo, TestMethod, strTempAntiID,out dtbResult);
            return lngRes;
        }
        // 敏感率趋势报告
        public long lngGetSensitiveTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetSensitiveTend( micname,  p_dtDateFrom,  p_dtDateTO,  SamtNo,  DisNo,  Sex,  AgeFrom, AgeTo, TestMethod, strTempAntiID,out dtbResult);
            return lngRes;
        }

        public long lngGetMicCumulative(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetMicCumulative(micname, p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod,  strTempAntiID,  out dtbResult);
            return lngRes;
        }

        public long lngGetSensitiveRate( string micname,DateTime p_dtDateFrom, DateTime p_dtDateTO, string SamtNo, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsMicReportSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsMicReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsMicReportSvc));
            lngRes = objSvc.lngGetSensitiveRate(  micname,p_dtDateFrom, p_dtDateTO, SamtNo, DisNo, Sex, AgeFrom, AgeTo, TestMethod,  strTempAntiID, out dtbResult);
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