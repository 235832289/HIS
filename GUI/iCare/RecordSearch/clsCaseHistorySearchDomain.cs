using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.DepartmentManagerService;
using iCareData;
using com.digitalwave.clsRecordsService;
using System.Data;
using com.digitalwave.PublicMiddleTier;
using com.digitalwave.PatientManagerService;
using com.digitalwave.InHospitalMainRecord;

namespace iCare
{
    class clsCaseHistorySearchDomain
    {
        #region 未编目病案查询

        #region 获取所有科室
        /// <summary>
        /// 获取所有科室
        /// </summary>
        /// <param name="p_objDeptArr">VO</param>
        /// <returns></returns>
        public long m_lngGetAllDept(out clsDept_Desc[] p_objDeptArr)
        {
            p_objDeptArr = null;

            clsDepartmentManagerService objService =
                (clsDepartmentManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDepartmentManagerService));

            long lngRes = objService.m_lngGetAllDept(out p_objDeptArr);
            return lngRes;
        }
        #endregion

        #region 查询一段时间内尚未编目的出院病人
        /// <summary>
        /// 查询一段时间内尚未编目的出院病人
        /// </summary>
        /// <param name="p_strOutDateBegin">查询的出院日期开始时间</param>
        /// <param name="p_strOutDateEnd">查询的出院日期结束时间</param>
        /// <param name="p_strDeptID">科室ID(如为空则查询所有科室)</param>
        /// <param name="p_dtpResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetUnlistOutPatient(string p_strOutDateBegin,
            string p_strOutDateEnd,
            string p_strDeptID,
            out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetUnlistOutPatient(p_strOutDateBegin, p_strOutDateEnd, p_strDeptID, out p_dtbResult);
            return lngRes;
        }
        #endregion         

        #region 超过提交时限，获取应该提交的时间
        /// <summary>
        /// 超过提交时限，获取应该提交的时间
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_strSetID">SetID</param>
        /// <param name="p_dtmMofifyDate">修改时间</param>
        /// <returns></returns>
        public long m_lngGetAboveTimeModifyDate(string p_strRegisterID, string p_strSetID, out DateTime p_dtmMofifyDate)
        {
            p_dtmMofifyDate = DateTime.MinValue;
            if (p_strRegisterID == null || p_strRegisterID == string.Empty
                || p_strSetID == null || p_strSetID == string.Empty)
                return -1;
            long lngRes = 0;
            try
            {
                clsPublicMiddleTier objMid =
                    (clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPublicMiddleTier));

                string strReturn = "";
                lngRes = objMid.m_lngGetConfigBySettingID(p_strSetID, out strReturn);

                clsPatientManagerService objServ =
                    (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

                DateTime dtOut = new DateTime(1900, 1, 1);
                lngRes = objServ.m_lngGetOutHospitalDate(p_strRegisterID, out dtOut);

                if (strReturn != "" && dtOut != new DateTime(1900, 1, 1))
                {
                    p_dtmMofifyDate = dtOut.AddHours(double.Parse(strReturn));
                }
            }
            catch
            {
                return -1;
            }
            return lngRes;
        } 
        #endregion

        #endregion

        #region 住院史查询

        #region 根据病人住院号获取入出院情况
        /// <summary>
        /// 根据病人住院号获取入出院情况
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetInAndOutInfo(string p_strInPatientID, out DataTable p_dtbResult)
        {
            p_dtbResult = null;

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetInAndOutInfo(p_strInPatientID, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取病案首页诊断及手术信息
        /// <summary>
        /// 获取病案首页诊断及手术信息
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objCollection"></param>
        /// <returns></returns>
        public long lngGetDiagnoseAndOpInfo(string p_strRegisterID, out clsInHospitalMainRecord_GX_Collection p_objCollection)
        {
            p_objCollection = null;

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.lngGetDiagnoseAndOpInfo(p_strRegisterID, out p_objCollection);
            return lngRes;
        }
        #endregion 

        #endregion

        #region 出院病人情况查询
        /// <summary>
        /// 查询出院病人情况
        /// </summary>
        /// <param name="p_intDiagnoseResult">治疗结果(出院方式)</param>
        /// <param name="p_strDeptID">科室ID(为空时查询所有科室)</param>
        /// <param name="p_dtmOutDateBegin">查询出院时间开始</param>
        /// <param name="p_dtmOutDateEnd">查询出院时间结束</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetOutInfo(int p_intDiagnoseResult,
            string p_strDeptID,
            DateTime p_dtmOutDateBegin,
            DateTime p_dtmOutDateEnd,
            out DataTable p_dtbResult)
        {
            p_dtbResult = null;

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetOutInfo(p_intDiagnoseResult, p_strDeptID, p_dtmOutDateBegin, p_dtmOutDateEnd, out p_dtbResult);
            return lngRes;
        } 
        #endregion

        #region 出院病人登记表
        /// <summary>
        /// 出院病人登记表
        /// </summary>
        /// <param name="p_strDeptID">科室ID(为空时查询所有科室)</param>
        /// <param name="p_dtmOutDate">查询出院时间</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetOutAndNoCatalogPatient(string p_strDeptID,
            DateTime p_dtmOutDate,
            out DataTable p_dtbResult)
        {
            p_dtbResult = null;
            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetOutAndNoCatalogPatient(p_strDeptID, p_dtmOutDate, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 疾病谱统计
        /// <summary>
        /// 疾病谱统计
        /// </summary>
        /// <param name="p_blnIsFirst">是否第一诊断</param>
        /// <param name="p_strDeptID">科室ID(为空时查询所有科室)</param>
        /// <param name="p_dtmOutDateBegin">查询出院时间开始</param>
        /// <param name="p_dtmOutDateEnd">查询出院时间结束</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetStatDiagnose(bool p_blnIsFirst,
            string p_strDeptID,
            DateTime p_dtmOutDateBegin,
            DateTime p_dtmOutDateEnd,
            out DataTable p_dtbResult)
        {
            p_dtbResult = null;

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngStatDiagnose(p_blnIsFirst, p_strDeptID, p_dtmOutDateBegin, p_dtmOutDateEnd, out p_dtbResult);
            return lngRes;
        }  
        #endregion

        #region 手术谱统计
        /// <summary>
        /// 手术谱统计
        /// </summary>
        /// <param name="p_strDeptID">科室ID(为空时查询所有科室)</param>
        /// <param name="p_dtmOutDateBegin">查询出院时间开始</param>
        /// <param name="p_dtmOutDateEnd">查询出院时间结束</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetStatOperation(string p_strDeptID,
            DateTime p_dtmOutDateBegin,
            DateTime p_dtmOutDateEnd,
            out DataTable p_dtbResult)
        {
            p_dtbResult = null;

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngStatOperation( p_strDeptID, p_dtmOutDateBegin, p_dtmOutDateEnd, out p_dtbResult);
            return lngRes;
        }
        #endregion

        #region 编目工作量统计

        #region 编目病案数
		/// <summary>
        /// 编目病案数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngGetCatalogCaseNum(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetCatalogCaseNum(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region VIP病案数
		/// <summary>
        /// VIP病案数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngGetVipPatientNum(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngGetVipPatientNum(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 死亡病案数
		/// <summary>
        /// 死亡病案数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngGetDeadCaseNum(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetDeadCaseNum(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 编目诊断总数
		/// <summary>
        /// 编目诊断总数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngCatalogDiagDict(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngCatalogDiagDict(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 编目手术总数
		/// <summary>
        /// 编目手术总数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngGetCatalogOpNum(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetCatalogOpNum(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 新建手术编码数
		/// <summary>
        /// 新建手术编码数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngNewOpDict(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngNewOpDict(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 新建疾病编码数
		/// <summary>
        /// 新建疾病编码数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngNewDiagDict(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngNewDiagDict(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
    	#endregion

        #region 编目手术种类数
		/// <summary>
        /// 编目手术种类数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngGetCatalogOpTypeNum(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsCaseHistorySearchService objService =
                (clsCaseHistorySearchService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCaseHistorySearchService));

            long lngRes = objService.m_lngGetCatalogOpTypeNum(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 编目诊断种类数
		/// <summary>
        /// 编目诊断种类数
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngCatalogDiagTypeDict(DateTime p_dtmBegin, DateTime p_dtmEnd, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngCatalogDiagTypeDict(p_dtmBegin, p_dtmEnd, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #region 特定编码诊断总类数(如V码，E码，M码)
		/// <summary>
        /// 特定编码诊断总类数(如V码，E码，M码)
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strDiagType">编码类型</param>
        /// <param name="p_strNum">查询结果</param>
        /// <returns></returns>
        public long m_lngCatalogSpecifyDiagTypeDict(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strDiagType, out string p_strNum)
        {
            p_strNum = "0";

            clsQuery8iServ objService =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objService.m_lngCatalogSpecifyDiagTypeDict(p_dtmBegin, p_dtmEnd, p_strDiagType, out p_strNum);
            return lngRes;
        } 
	    #endregion

        #endregion
    }
}
