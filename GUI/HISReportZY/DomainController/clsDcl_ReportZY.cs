using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS.Report;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 报告生成Domain类
    /// </summary>
    public class clsDcl_ReportZY : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_ReportZY()
        {
        }
        #endregion

        #region 项目统计发生明细报表
        /// <summary>
        /// 项目统计发生明细报表
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngRptItemDetailStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngRptItemDetailStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取功能科室专业组分类统计数据
        /// <summary>
        /// 获取功能科室专业组分类统计数据
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByDoctor(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.Report.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.Report.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取功能科室核算实收统计数据-主治医生
        /// <summary>
        /// 获取功能科室核算实收统计数据
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public long m_lngGetGroupInComeByArea(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            //lngRes = objSvc.m_lngGetGroupInComeByDoctor(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }

        /// <summary>
        /// 获取病区数据
        /// </summary>
        /// <param name="strFindCode"></param>
        /// <param name="objItemArr"></param>
        /// <returns></returns>
        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));
            return objSvc.m_lngFindArea(strFindCode, out objItemArr);
        }

        #endregion

        #region 获取流水号
        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        internal long m_lngGetRegisterID(string inPatientID, out DataTable dt, int p_intType)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
    (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));
            long l = objSvc.m_lngGetRegisterID(inPatientID, out dt, p_intType);
            objSvc.Dispose();
            return l;
        }

        /// <summary>
        /// 台山市基本医疗保险住院自费项目签字单
        /// </summary>
        /// <param name="strInpinsurancetype"></param>
        /// <param name="RegisterID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetOwnCastItem(string strInpinsurancetype, string RegisterID, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));
            long l = objSvc.m_lngGetOwnCastItem(strInpinsurancetype, RegisterID, out dtResult);
            objSvc.Dispose();
            return l;
        }
        #endregion 

        public long m_lngGetRptNursingLog(DateTime dtmTmp, string DeptID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                               (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetRptNursingLog(dtmTmp, DeptID, out dt);
            objSvc.Dispose();

            return l;
        }

        public long m_lngGetRptNusingPatientCount(DateTime dtmTmp, string DeptID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                   (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetRptNusingPatientCount(dtmTmp, DeptID, out dt);
            objSvc.Dispose();

            return l;
        }


        #region 住院协议单位查询统计报表
        /// <summary>
        /// 住院协议单位查询统计报表
        /// </summary>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngContractUnitPayType(string p_strStartDate, string p_strEndDate, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                   (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long lngRes = objSvc.m_lngContractUnitPayType(p_strStartDate, p_strEndDate, out p_dtbResult);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

    }

    public class clsDcl_CommonFind : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_CommonFind()
        {
        }
        #endregion

        #region 根据病区ID获取该病区床位信息
        /// <summary>
        /// 根据病区ID获取该病区床位信息
        /// </summary>
        /// <param name="AreaID"></param>
        /// <param name="status"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetBedinfo(string AreaID, int status, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetBedinfo(AreaID, status, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院号或诊疗卡号获取当前在院病人信息
        /// <summary>
        /// 根据住院号或诊疗卡号获取当前在院病人信息
        /// </summary>
        /// <param name="no"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetPatientinfoByZyh(string no, out DataTable dt, int type)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetPatientinfoByZyh(no, out dt, type);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 通用查找窗口用
        /// <summary>
        /// 通用查找窗口用
        /// </summary>
        /// <param name="SqlWhereZY"></param>
        /// <param name="Status">0 全部 1 在院 2 出院</param>
        /// <param name="IsIncludeMZ"></param>
        /// <param name="SqlWhereMZ"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientinfo(string SqlWhereZY, int Status, bool IsIncludeMZ, string SqlWhereMZ, clsCommonQueryDate_VO CommonQueryDate_VO, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetPatientinfo(SqlWhereZY, Status, IsIncludeMZ, SqlWhereMZ, CommonQueryDate_VO, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据住院号获取病人基本资料
        /// <summary>
        /// 根据住院号获取病人基本资料
        /// </summary>
        /// <param name="Zyh"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientinfoByZyh(string Zyh, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetPatientinfoByZyh(Zyh, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
    }

    /// <summary>
    /// 结算DOMIAN类
    /// </summary>
    public class clsDcl_Charge : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsDcl_Charge()
        {
        }
        #endregion

        #region 获取身份(费别)信息
        /// <summary>
        /// 获取身份(费别)信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPayTypeInfo(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetPayTypeInfo(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获得病区信息
        /// <summary>
        /// 获得病区信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Flag">1 科室 2 病区</param>
        /// <returns></returns>
        public long m_lngGetDeptArea(out DataTable dt, int Flag)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetDeptArea(out dt, Flag);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 查询收费项目
        /// <summary>
        /// 查询收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="PatType">病人身份</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindChargeItem(string FindStr, string PatType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngFindChargeItem(FindStr, PatType, out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 根据项目ID查找收费项目
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngFindChargeItem(string ItemID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngFindChargeItem(ItemID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取不同费别的费用明细
        /// <summary>
        /// 获取不同费别的费用明细
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPatientFeeDetByPayType(string RegID, string PayTypeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));

            long l = objSvc.m_lngGetPatientFeeDetByPayType(RegID, PayTypeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion
    }

    /// <summary>
    /// 统计查询逻辑控制层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-09-23
    /// </summary>
    public class clsDcl_StatQuery : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数
        public clsDcl_StatQuery()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 病人入院单统计表  liuyingrui 2006.05.08
        /// <summary>
        /// 病人入院单统计表  liuyingrui 2006.05.08
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        public long GetPatientBihStatistics(DateTime dtStartime, DateTime dtEndTime, object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------->
                if (strPaytypeId == null)
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);

                }
                else if (((string)strPaytypeId).Equals("0000"))
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);

                }
                /*<--------------------*/
            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region  病人出院单统计表 2006.11.18
        /// <summary>
        ///  病人出院单统计表 2006.11.18
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        public long GetPatientLeftStatistics(DateTime dtStartime, DateTime dtEndTime, object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Report.clsReportZY_Svc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------------------------->
                if (strPaytypeId == null)
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else if (strPaytypeId.Equals("0000"))
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);
                }
                //<---------------------------------

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
    }
}
