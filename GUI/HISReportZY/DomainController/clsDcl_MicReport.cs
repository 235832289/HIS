using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsDcl_MicReport : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_MicReport()
        {
        }

        #region 获取所有抗生素
        /// <summary>
        /// 获取所有抗生素
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long lngGetAllAnti(out DataTable dt)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAllAnti(out dt);
            }
        }
        #endregion

        #region 模糊查询抗生素
        /// <summary>
        /// 模糊查询抗生素
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetFuzzyQueryAnti(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetFuzzyQueryAnti(micName, IsEnglish, out dtbResult);
            }
        }
        #endregion

        #region 获取所有细菌
        /// <summary>
        /// 获取所有细菌
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long lngGetAllMic(out DataTable dt)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAllMic(out dt);
            }
        }
        #endregion

        #region 获取所有革兰细菌
        /// <summary>
        /// 获取所有革兰细菌
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long lngGetAllGlMic(out DataTable dt)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAllGlMic(out dt);
            }
        }
        #endregion


        #region 细菌名称检验细菌
        /// <summary>
        /// 细菌名称检验细菌
        /// </summary>
        /// <param name="micName"></param>
        /// <param name="IsEnglish"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetFuzzyQueryMic(string micName, bool IsEnglish, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
                lngRes = svc.lngGetFuzzyQueryMic(micName, IsEnglish, out dtbResult);
            return lngRes;
        }
        #endregion

        #region 细菌分布报告统计报表
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
        public long lngGetBacteriaDistribution(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, string AgeFrom, string AgeTo, string TestMethod, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetBacteriaDistribution(micname, p_dtDateFrom, p_dtDateTO, applicationStr, DeptIdArr, sampleId, DisNo, Sex, TestMethod, out dtbResult);
            }
        }
        #endregion

        #region 细菌分布趋势报告
        /// <summary>
        /// 细菌分布趋势报告
        /// </summary>
        /// <param name="micname"></param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="SamtNo"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetMicdistributionTend(string micname, DateTime p_dtDateFrom, DateTime p_dtDateTO, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, string TestMethod, out DataTable dtbResult)
        {

            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetMicdistributionTend(micname, p_dtDateFrom, p_dtDateTO, applicationStr,DeptIdArr, sampleId, DisNo, Sex, TestMethod, out dtbResult);
            }
        }
        #endregion

        #region 累计敏感性
        /// <summary>
        /// 累计敏感性
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTo"></param>
        /// <param name="SamtName"></param>
        /// <param name="DisName"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>

        public long lngGetMicSensitive(string applicationStr, string sampleId, string DisName, string Sex, string strTempAntiName,string strTempAnti, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetMicSensitive(applicationStr, sampleId, DisName, Sex, strTempAntiName,strTempAnti, out dtbResult);
            }
        }
        #endregion

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
        public long lngGetSensitiveTend(string applictionStr, string sampleId, string DisNo, string Sex,  string strTempAntiID, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
                lngRes = svc.lngGetSensitiveTend(applictionStr, sampleId, DisNo, Sex, strTempAntiID, out dtbResult);
            return lngRes;
        }
        #endregion

        #region 累计MIC报告
        /// <summary>
        /// 累计MIC报告
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="SamtNo"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetMicCumulative(string applicationStr, string sampleId, string DisNo, string Sex, string TestMethod, string strTempAntiID, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetMicCumulative( applicationStr, sampleId, DisNo, Sex, TestMethod, strTempAntiID, out dtbResult);
            }
        }
        #endregion

        #region 细菌明细
        /// <summary>
        /// 细菌明细
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="applicationStr"></param>
        /// <param name="sampleId"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAntiDetail(string strTempName,DateTime p_dtDateFrom, DateTime p_dtDateTO, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAntiDetail(strTempName,p_dtDateFrom, p_dtDateTO,DeptIdArr, sampleId, DisNo, Sex, out dtbResult);
            }
        }
        #endregion

        #region 细菌 按类型
        /// <summary>
        /// 细菌 按类型
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="applicationStr"></param>
        /// <param name="sampleId"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAntiSample(string strTempName, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAntiSample(strTempName, applicationStr, DeptIdArr, sampleId, DisNo, Sex, out dtbResult);
            }
        }
        #endregion

        #region 细菌 按科室
        /// <summary>
        /// 细菌 按类型
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="applicationStr"></param>
        /// <param name="sampleId"></param>
        /// <param name="DisNo"></param>
        /// <param name="Sex"></param>
        /// <param name="TestMethod"></param>
        /// <param name="strTempAntiID"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAntiByDept(string strTempName, string applicationStr, string DeptIdArr, string sampleId, string DisNo, string Sex, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAntiByDept(strTempName, applicationStr, DeptIdArr, sampleId, DisNo, Sex, out dtbResult);
            }
        }
        #endregion

        #region 获取item 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAntiCheckItem(DateTime p_dtDateFrom, DateTime p_dtDateTO, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAntiCheckItem(p_dtDateFrom, p_dtDateTO, out dtbResult);
            }
        }
        #endregion

        #region  细菌名称 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetAnti(string strTempAntiName, DateTime p_dtDateFrom, DateTime p_dtDateTo, string DeptIdArr, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetAnti( strTempAntiName, p_dtDateFrom, p_dtDateTo, DeptIdArr, out dtbResult);
            }
        }
        #endregion

        #region 获取application
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTo"></param>
        /// <param name="SamtName"></param>
        /// <param name="strTempAntiName"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>

        public long lngGetMicApplication(string strTempAntiName,DateTime p_dtDateFrom, DateTime p_dtDateTo,string criticalStr,string DeptIdArr,out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetApplicateion(strTempAntiName, p_dtDateFrom, p_dtDateTo, criticalStr, DeptIdArr, out dtbResult);
            }
        }
        #endregion

        #region 获取抗生素
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationStr"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetGss(string applicationStr, out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetGss(applicationStr, out dtbResult);
            }
        }
        #endregion
        

        #region 取得病区
        /// <summary>
        /// 取得病区
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long lngGetDeptName(out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetDeptName(out  dtbResult);
            }
        }
        #endregion

        #region 取得样本类型
        /// <summary>
        /// 取得样本类型
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>

        public long lngGetSamType(out DataTable dtbResult)
        {
            using (clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc)))
            {
                return svc.lngGetSamType(out  dtbResult);
            }
        }
        #endregion
    }
}