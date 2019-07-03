using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 检验申请的服务类

    /// </summary>
    public class clsApplicationBizSmp:clsController_Base
    {
        #region 构造


        private clsApplicationBizSmp()
        {
            objSvc = (clsApplicationSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
        }
        private clsApplicationSvc objSvc;
        public static clsApplicationBizSmp s_obj
        {
            get
            {
                return new clsApplicationBizSmp();
            }
        }

        #endregion

        #region 	增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)
        /// </summary>
        /// <param name="applMain"></param>
        /// <param name="arrReports"></param>
        /// <param name="arrSamples"></param>
        /// <param name="arrCheckItems"></param>
        /// <param name="arrApplyUnits"></param>
        /// <param name="arrUnitItemRelations"></param>
        /// <returns></returns>
        public long m_lngAddApplicationInfo(clsLisApplMainVO p_objLisApplMainVO,
                                            clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr, 
                                            clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                            clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr, 
                                            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                            clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            
            long lngRes = 0;
            clsLisApplMainVO objLisApplMainVO = null;

            try 
	        {	        
        		 lngRes = objSvc.m_lngAddNewAppAndSampleInfoWithBarcode(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
                 if (lngRes > 0 && objLisApplMainVO != null)
                {
                    objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
                }
	        }
	        catch 
	        {
        		lngRes=0;
	        }
            return lngRes;
        }
        #endregion

        #region 跳过采样不核收4002.status=2
        /// <summary>
        /// 跳过采样不核收4002.status=2
        /// 莫宝健 2007.09.13 add
        /// </summary>
        /// <param name="p_objLisApplMainVO"></param>
        /// <param name="p_objReportArr"></param>
        /// <param name="p_objAppSampleArr"></param>
        /// <param name="p_objAppItemArr"></param>
        /// <param name="p_objAppUnitArr"></param>
        /// <param name="p_objAppUnitItemArr"></param>
        /// <returns></returns>
        public long m_lngAddAppInfoWithoutReceive(clsLisApplMainVO p_objLisApplMainVO,
                                            clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                            clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                            clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                            clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {

            long lngRes = 0;
            clsLisApplMainVO objLisApplMainVO = null;

            try
            {
                lngRes = objSvc.m_lngAddNewAppAndSampleInfoWithoutReceive(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
                if (lngRes > 0 && objLisApplMainVO != null)
                {
                    objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
                }
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        #endregion


        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)

        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="applMain"></param>
        /// <param name="arrReports"></param>
        /// <param name="arrSamples"></param>
        /// <param name="arrCheckItems"></param>
        /// <param name="arrUnitItemRelations"></param>
        /// <param name="arrApplyUnits"></param>
        /// <returns></returns>
        public long m_lngAddNewAppInfo(clsLisApplMainVO p_objLisApplMainVO,
                                       clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                       clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                       clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                       clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                       clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;
            clsLisApplMainVO objLisApplMainVO = null;

            try
            {
                lngRes = objSvc.m_lngAddNewAppInfo(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
                if (lngRes > 0 && objLisApplMainVO != null)
                {
                    objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
                }
            }
            catch 
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region  修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// <summary>
        /// 修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        /// </summary>
        /// <param name="applMain"></param>
        /// <param name="arrReports"></param>
        /// <param name="arrSamples"></param>
        /// <param name="arrCheckItems"></param>
        /// <param name="arrApplyUnits"></param>
        /// <param name="arrUnitItemRelations"></param>
        /// <returns></returns>
        public long m_lngModifyAppInfo(clsLisApplMainVO p_objLisApplMainVO,
                                       clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                       clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                       clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                       clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                       clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;

            try
            {
                lngRes = objSvc.m_lngModifyAppInfo(objPrincipal, p_objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
            }
            catch 
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 注释NEW

        //#region 构造


        //private clsApplicationBizSmp()
        //{
        //    objSvc = (clsApplicationBizSvc)
        //       com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationBizSvc));
        //}
        //private clsApplicationBizSvc objSvc;
        //public static clsApplicationBizSmp s_obj
        //{
        //    get
        //    {
        //        return new clsApplicationBizSmp();
        //    }
        //}

        //#endregion

        //#region 	增加一组新的检验申请信息(跳过采集和核收)

        ///// <summary>
        ///// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)
        ///// </summary>
        ///// <param name="applMain"></param>
        ///// <param name="arrReports"></param>
        ///// <param name="arrSamples"></param>
        ///// <param name="arrCheckItems"></param>
        ///// <param name="arrApplyUnits"></param>
        ///// <param name="arrUnitItemRelations"></param>
        ///// <returns></returns>
        //public long m_lngAddApplyApplication(clsLisApplMainVO applMain, clsT_OPR_LIS_APP_REPORT_VO[] arrReports,
        //                                    clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples, clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems,
        //                                    clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnits, clsLisAppUnitItemVO[] arrUnitItemRelations)
        //{

        //    long lngRes = 0;
        //    clsLisApplMainVO applMainOut = null;

        //    try
        //    {
        //        lngRes = objSvc.m_lngAddNewAppAndSampleInfoWithBarcode(objPrincipal, applMain, out applMainOut, arrReports, arrSamples, arrCheckItems, arrApplyUnits, arrUnitItemRelations);
        //        if (lngRes > 0 && applMainOut != null)
        //        {
        //            applMainOut.m_mthCopyTo(applMain);
        //        }
        //    }
        //    catch
        //    {
        //        lngRes = 0;
        //    }
        //    return lngRes;
        //}


        //#endregion

        //#region 增加-组新的检验申请信息


        ///// <summary>
        ///// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        ///// </summary>
        ///// <param name="applMain"></param>
        ///// <param name="arrReports"></param>
        ///// <param name="arrSamples"></param>
        ///// <param name="arrCheckItems"></param>
        ///// <param name="arrUnitItemRelations"></param>
        ///// <param name="arrApplyUnits"></param>
        ///// <returns></returns>
        //public long m_lngAddNewAppInfo(clsLisApplMainVO applicationMainInfo, clsT_OPR_LIS_APP_REPORT_VO[] arrReport,
        //                               clsT_OPR_LIS_APP_SAMPLE_VO[] arrSample, clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrItems,
        //                               clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrUnit, clsLisAppUnitItemVO[] arrUnitItems, out string errorMessage)
        //{
        //    long lngRes = 0;
        //    clsLisApplMainVO applMainOut = null;
        //    errorMessage = string.Empty;

        //    try
        //    {
        //        lngRes = objSvc.m_lngAddNewApplication(applicationMainInfo, out applMainOut, arrReport, arrSample, arrItems, arrUnit, arrUnitItems);

        //        if (lngRes > 0 && applMainOut != null)
        //        {
        //            applMainOut.m_mthCopyTo(applicationMainInfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lngRes = 0;
        //        errorMessage = ex.Message;
        //    }

        //    return lngRes;
        //}

        //#endregion

        //#region  修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)

        ///// <summary>
        ///// 修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息)
        ///// </summary>
        ///// <param name="applMain"></param>
        ///// <param name="arrReports"></param>
        ///// <param name="arrSamples"></param>
        ///// <param name="arrCheckItems"></param>
        ///// <param name="arrApplyUnits"></param>
        ///// <param name="arrUnitItemRelations"></param>
        ///// <returns></returns>
        //public long m_lngModifyAppInfo(clsLisApplMainVO applMain,
        //                               clsT_OPR_LIS_APP_REPORT_VO[] arrReports,
        //                               clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples,
        //                               clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems,
        //                               clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnits,
        //                               clsLisAppUnitItemVO[] arrUnitItemRelations)
        //{
        //    long lngRes = 0;

        //    try
        //    {
        //        lngRes = objSvc.m_lngModifyAppInfo(applMain, arrReports, arrSamples, arrCheckItems, arrApplyUnits, arrUnitItemRelations);
        //    }
        //    catch
        //    {
        //        lngRes = 0;
        //    }
        //    return lngRes;
        //}

        //#endregion

        #endregion
    }
}
