using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsLisServiceSmp : clsDomainController_Base
    {
        
        #region 构造


        private clsLisServiceSmp()
        {
            objSvc = (clsApplicationMainSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationMainSvc));
        }
        private clsApplicationMainSvc objSvc;
        public static clsLisServiceSmp s_obj
        {
            get
            {
                return new clsLisServiceSmp();
            }
        }

        #endregion

        public long m_lngFindSample(string strSampleID, out clsT_OPR_LIS_SAMPLE_VO sample)
        {
            long lngRes = 0;
            sample = null;

            clsQuerySampleSvc objSvc =
                         (clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuerySampleSvc));
            clsT_OPR_LIS_SAMPLE_VO[] samples;
            lngRes = objSvc.m_lngGetSampleVOArrBySampleID(this.objPrincipal, strSampleID, out samples);
            if (samples!=null&&samples.Length>0)
            {
                sample=samples[0];
            }

            return lngRes;
        }

        public long m_lngDeleteApplication(string applicationId)
        {
            long lngRes = 0;

            try
            {
                lngRes = objSvc.m_lngDeleteApplication(applicationId);
            }
            catch (Exception ex)
            {
                lngRes = 0;
                throw new LisCreateApplyException(string.Format("创建检验申请申请!(申请单号ID{0})({1})",applicationId,ex.Message));
            }

            return lngRes;
        }

        public bool GetApplicationIsValid(string applicationId)
        {
            long lngRes = 0;
            bool isValid = false;
            try
            {
                lngRes = objSvc.m_lngGetApplicationValid(applicationId,out isValid);
            }
            catch (Exception ex)
            {
                isValid = false;
            }

            return isValid;
        }

        #region m_lngAddApplyApplication
        /// <summary>
        /// 增加-组新的检验申请信息
        /// </summary>
        /// <param name="applMain"></param>
        /// <param name="arrReports"></param>
        /// <param name="arrSamples"></param>
        /// <param name="arrCheckItems"></param>
        /// <param name="arrApplyUnits"></param>
        /// <param name="arrUnitItemRelations"></param>
        /// <returns></returns>
        public long m_lngAddApplyApplication(clsLisApplMainVO applMain, bool isSend,
                                             clsT_OPR_LIS_APP_REPORT_VO[] arrReports,
                                             clsT_OPR_LIS_APP_SAMPLE_VO[] arrSamples,
                                             clsT_OPR_LIS_APP_CHECK_ITEM_VO[] arrCheckItems,
                                             clsT_OPR_LIS_APP_APPLY_UNIT_VO[] arrApplyUnits,
                                             clsLisAppUnitItemVO[] arrUnitItemRelations)
        {

            long lngRes = 0;
            clsLisApplMainVO applMainOut = null;

            try
            {
                lngRes = objSvc.m_lngAddNewAppInfo(applMain, out applMainOut, isSend, arrReports, arrSamples, arrCheckItems, arrApplyUnits, arrUnitItemRelations);
                if (lngRes > 0 && applMainOut != null)
                {
                    applMainOut.m_mthCopyTo(applMain);
                }
            }
            catch (Exception ex)
            {
                throw new LisCreateApplyException(string.Format("创建检验申请失败!({0})", ex.Message));
            }

            return lngRes;
        } 
        #endregion

        #region m_lngGetApplication
        public long m_lngGetApplication(string orderId, out List<clsLisApplMainVO> lstAppMain)
        {
            long lngRes = 0;
            lstAppMain = null;

            try
            {
                lngRes = objSvc.m_lngGetApplication(orderId, out lstAppMain);
            }
            catch (Exception ex)
            {
                throw new LisCreateApplyException(ex.Message);
            }

            return lngRes;
        } 
        #endregion

        #region m_lngGetApplVO
        public long m_lngGetApplVO(string orderId, out clsLisApplMainVO applMain)
        {
            long lngRes = 0;
            applMain = null;

            try
            {
                lngRes = objSvc.m_lngGetApplVO(orderId, out applMain);
            }
            catch (Exception ex)
            {
                throw new LisCreateApplyException(ex.Message);
            }

            return lngRes;
        }
        #endregion
    }
}
