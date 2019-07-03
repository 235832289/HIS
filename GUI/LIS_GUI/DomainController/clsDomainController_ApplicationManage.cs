using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsDomainController_ApplicationManage 的摘要说明。
    /// </summary>
    public class clsDomainController_ApplicationManage : clsDomainController_Base
    {
        #region 发送申请单
        public long m_lngSendApplications(string[] p_strAppIDs)
        {
            long lngRes = 0;
            try
            {
                clsApplicationSvc objApplicationSvc = (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
                lngRes = objApplicationSvc.m_lngSendApplictions(this.objPrincipal, p_strAppIDs);
            }
            catch { }

            return lngRes;
        }
        #endregion

        #region 作废申请的样本    xing.chen add
        public long m_lngBlankOutApplication(clsLisApplMainVO p_objApplMainVO, clsBlankOutApplicationVO p_objBlankOutInfo)
        {
            long lngRes = 0;
            try
            {
                clsApplicationSvc objApplicationSvc = (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
                lngRes = objApplicationSvc.m_lngAddBlankOutInfo(this.objPrincipal, p_objApplMainVO, p_objBlankOutInfo);
            }
            catch { }

            return lngRes;
        }
        #endregion

        #region		检验审核身份确认 xing.chen add
        public long m_lngCheckComfirmLogin(string p_strLoignName, string p_strLoginPwd, out bool blnLogin, out string strLoginMsg, out string p_strEmpID)
        {
            long lngRes = 0;
            blnLogin = false;
            strLoginMsg = "";
            p_strEmpID = "";

            string strEmpID;
            string strEmpPwd;
            try
            {
                com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplicationSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
                lngRes = objApplicationSvc.m_lngFindEmpMsgByEmpNO(this.objPrincipal, p_strLoignName, out strEmpID, out strEmpPwd);
                if (lngRes < 0)
                {
                    return -1;
                }

                if (strEmpID == null || strEmpID == "")
                {
                    blnLogin = false;
                    strLoginMsg = "该帐号不存在";
                }
                else if (strEmpPwd.Trim() != p_strLoginPwd.Trim())
                {
                    blnLogin = false;
                    strLoginMsg = "密码错误";
                }
                else
                {
                    blnLogin = true;
                    p_strEmpID = strEmpID;
                    strLoginMsg = "身份核对成功";
                }
            }
            catch
            {
                blnLogin = false;
                strLoginMsg = "核对异常";
            }

            return lngRes;
        }
        #endregion

        #region 报告数据对象
        #region Get

        public long m_lngGetReportObject(string p_strApplicationID, out clsReportObject p_objReportObject)
        {
            long lngRes = 0;
            p_objReportObject = null;
            try
            {
                clsQueryReportSvc objSvc =
                             (clsQueryReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryReportSvc));

                lngRes = objSvc.m_lngGetReportObject(objPrincipal, p_strApplicationID, out p_objReportObject);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }

        #endregion

        #region Insert
        public long m_lngInsertReportObject(clsReportObject p_objReportObject)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.LIS.clsReportSvc objSvc =
                    (com.digitalwave.iCare.middletier.LIS.clsReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsReportSvc));

                lngRes = objSvc.m_lngInsertReportObject(objPrincipal, p_objReportObject);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }
        #endregion

        #region Update
        public long m_lngUpdateReportObject(clsReportObject p_objReportObject)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.LIS.clsReportSvc objSvc =
                    (com.digitalwave.iCare.middletier.LIS.clsReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsReportSvc));

                lngRes = objSvc.m_lngUpdateReportObject(objPrincipal, p_objReportObject);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }
        #endregion

        #region Delete
        public long m_lngDeleteReportObject(string p_strApplicationID)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.LIS.clsReportSvc objSvc =
                    (com.digitalwave.iCare.middletier.LIS.clsReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsReportSvc));

                lngRes = objSvc.m_lngDeleteReportObject(objPrincipal, p_strApplicationID);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }
        #endregion
        #endregion

        #region		获取病人信息	xing.chen 2005.9.22
        public long m_lngGetPatientInfoVOList(string p_InHospitalID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;

            try
            {
                //com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                //    (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
                clsQueryApplicationSvc objSvc =
                    (clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryApplicationSvc));

                lngRes = objSvc.m_lngFindPatientInfoByInpatientID(objPrincipal, p_InHospitalID, out p_dtResult);
            }
            catch
            {
                lngRes = 0;
            }

            return lngRes;
        }
        #endregion

        #region 获取检验配置信息		xing.chen add 2005/12/14
        /// <summary>
        /// 获取检验配置信息
        /// </summary>
        /// <param name="p_blnConfig"></param>
        /// <param name="p_strSetID"></param>
        /// <returns></returns>
        public long m_lngGetCollocate(out string p_strConfig, string p_strSetID)
        {
            p_strConfig = "";
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objApplicationSvc = (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            long lngRes = objApplicationSvc.m_lngGetCollocate(objPrincipal, out p_strConfig, p_strSetID);
            return lngRes;
        }
        #endregion

        #region 组合查询(包括病人住院号)申请单信息 xing.chen add 2005/12/14
        /// <summary>
        /// 组合查询查询申请单信息
        /// </summary>
        /// <param name="p_objSchVO"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        public long m_lngGetAppInfoByConditionAndInHospitalNO(
            clsLISApplicationSchVO p_objSchVO, string p_strInHospitalNO,
            out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppInfoByConditionAndInHospitalNO(objPrincipal, p_objSchVO, p_strInHospitalNO, out p_objAppVOArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 	增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,和样本在内(barcode为seq中取得)的全部信息)	 xing.chen  2005/12/14
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
        public long m_lngAddNewAppAndSampleInfoWithBarcode(com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO objLisApplMainVO = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppAndSampleInfoWithBarcode(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
            if (lngRes > 0 && objLisApplMainVO != null)
            {
                objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
            }
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查询申请单的收费信息 刘彬 2005.08.03
        /// <summary>
        /// 查询申请单的收费信息
        /// </summary>
        /// <param name="p_strApplicationID">申请单ID</param>
        /// <returns>0:查询失败;1:未收费;2:已收费</returns>
        public static long m_lngGetChargeState(string p_strApplicationID)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.common.clsCheckChargeInfo objChecker = new com.digitalwave.iCare.common.clsCheckChargeInfo();
                bool blnRes = objChecker.m_mthCheckIsCharge(p_strApplicationID, com.digitalwave.iCare.common.ApplyOrigin.LIS);
                if (blnRes)
                    lngRes = 2;
                else
                    lngRes = 1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                lngRes = 0;
            }

            return lngRes;
        }
        #endregion
        #region 根据申请单ID作废相应的仪器关联 刘彬 2004.11.18
        /// <summary>
        /// 根据申请单ID作废相应的仪器关联
        /// </summary>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strOringinDate"></param>
        /// <returns></returns>
        public long m_lngDeleteDeviceRelationByApplicationID(string p_strApplicationID, string p_strOringinDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngDeleteDeviceRelationByApplicationID(objPrincipal, p_strApplicationID, p_strOringinDate);
            objAppSvc.Dispose();
            return lngRes;
        }

        #endregion

        #region 修改申请单病人信息并相应修改样本信息 童华 2004.11.16
        public long m_lngSetApplicationAndSamplePatientInfo(clsLisApplMainVO p_objApplVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngSetApplicationAndSamplePatientInfo(objPrincipal, p_objApplVO);
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 组合查询查询已发送申请单及样本信息 刘彬 2004.11.10
        /// <summary>
        /// 组合查询查询已发送申请单及样本信息
        /// </summary>
        /// <param name="p_intSampleStatus">1为未采集,2为已采集,0为所有</param>
        /// <param name="p_strAppDept"></param>
        /// <param name="p_strFromDatApp"></param>
        /// <param name="p_strToDatApp"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        public long m_lngGetAppAndSampleInfo(int p_intSampleStatus, string p_strAppDept, string p_strFromDatApp,
                                                string p_strToDatApp, string p_strPatientName, string p_strPatientCardID, string p_strAcceptStatus, int p_intSampleBackeStatus, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            clsQueryApplicationSvc objAppSvc =
                              (clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppAndSampleInfo(objPrincipal, p_intSampleStatus, p_strAppDept, p_strFromDatApp, p_strToDatApp, p_strPatientName, p_strPatientCardID, p_strAcceptStatus, p_intSampleBackeStatus, out p_objAppVOArr);
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region [住院样本采集查询]组合查询已发送申请单及样本信息YMH 2006.9.26[BIH]
        /// <summary>
        /// [住院样本采集查询]组合查询已发送申请单及样本信息
        /// </summary>
        /// <param name="p_intSampleStatus">1为未采集,2为已采集,0为所有</param>
        /// <param name="p_strAppDept"></param>
        /// <param name="p_strFromDatApp"></param>
        /// <param name="p_strToDatApp"></param>
        /// <param name="p_strHosipitalNO"></param>
        /// <param name="p_strPatientCardID"></param>
        /// <param name="p_strPatientName"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        public long m_lngGetAppAndSampleInfo(int p_intSampleStatus, string p_strAppDept, string p_strFromDatApp,
                                             string p_strToDatApp, string p_strPatientName, string p_strPatientCardID, string p_strHosipitalNO, string bedNo, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            clsQueryApplicationSvc objAppSvc =
                             (clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppAndSampleInfo(objPrincipal, p_intSampleStatus, p_strAppDept, p_strFromDatApp, p_strToDatApp, p_strPatientName, p_strPatientCardID, p_strHosipitalNO, bedNo, out p_objAppVOArr);
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询打印申请单信息 童华 2004.11.08
        public long m_lngGetApplicationReportInfo(string p_strApplicationID, out clsLisApplyReportInfo_VO p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetApplicationReportInfo(objPrincipal, p_strApplicationID, out p_objResult);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询得到申请单详细信息 刘彬 2004.10.18
        /// <summary>
        /// 根据申请单ID查询得到申请单详细信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_strAppModifyDate"></param>
        /// <param name="p_objLISInfoVO"></param>
        /// <returns></returns>
        public long m_lngGetLISInfoByApplicationID(string p_strApplicationID, string p_strAppModifyDate, out clsLISInfoVO p_objLISInfoVO)
        {
            long lngRes = 0;
            p_objLISInfoVO = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetLISInfoByApplicationID(objPrincipal, p_strApplicationID, p_strAppModifyDate, out p_objLISInfoVO);
            //			objAppSvc.Dispose();
            return lngRes;

        }

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsDomainController_ApplicationManage()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 根据条件查询病人信息
        public long m_lngGetPatientInfoByCondition(string p_strPatientInhosptalNO, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetPatientInfoByCondition(objPrincipal, p_strPatientInhosptalNO, out p_dtbResult);
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region 组合查询查询申请单信息 刘彬 2004.06.21
        /// <summary>
        /// 组合查询查询申请单信息
        /// </summary>
        /// <param name="p_objSchVO"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        public long m_lngGetAppInfoByCondition(clsLISApplicationSchVO p_objSchVO, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            p_objAppVOArr = null;

            clsApplicationSvc objAppSvc =
                              (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppInfoByCondition(objPrincipal, p_objSchVO, out p_objAppVOArr);
            return lngRes;
        }
        #endregion

        #region 更新SampleID 到 AppSampleGroup 刘彬 2004.06.26

        /// <summary>
        /// 更新SampleID 到 AppSampleGroup 刘彬 2004.06.26
        /// </summary>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strSampleID"></param>
        /// <returns></returns>
        public long m_lngUpdateAppSampleGroupSampleID(
            string p_strAppID, string p_strSampleID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngUpdateAppSampleGroupSampleID(objPrincipal, p_strAppID, p_strSampleID);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 删除申请 刘彬 2004.07.23
        /// <summary>
        /// 删除申请
        /// </summary>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strOpID"></param>
        /// <returns></returns>
        public long m_lngDeleteApp(string p_strAppID, string p_strOpID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngDeleteApp(objPrincipal, p_strAppID, p_strOpID);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 确认报告 刘彬 2004.06.26
        /// <summary>
        /// 确认报告,同时确定样本
        /// </summary>
        /// <param name="p_strAppID"></param>
        /// <param name="p_strReportID"></param>
        /// <param name="p_strConfirmerID"></param>
        /// <returns></returns>
        public long m_lngConfirmAppReport(
            string p_strAppID, string p_strReportID, string p_strConfirmerID, DateTime p_dtmConfirmDate)
        {
            string strConfirmDate = p_dtmConfirmDate.ToString("yyyy-MM-dd HH:mm:ss");
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngConfirmAppReport(objPrincipal, p_strAppID, p_strReportID, p_strConfirmerID, strConfirmDate);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请日期、发送状态组合查询申请单信息 刘彬 2004.06.21
        /// <summary>
        /// 根据申请日期、发送状态组合查询申请单信息
        /// </summary>
        /// <param name="p_strFromDat"></param>
        /// <param name="p_strToDat"></param>
        /// <param name="p_blnSend"></param>
        /// <param name="p_blnUnSend"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetApplicationVOArrByCondition(string p_strFromDat, string p_strToDat, bool p_blnSend, bool p_blnUnSend, out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetApplicationVOArrByCondition(objPrincipal, p_strFromDat, p_strToDat, p_blnSend, p_blnUnSend, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据检验日期、标本号、仪器ID和病人姓名组合查询查询申请单信息 童华 2004.06.21
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strFromDat">检验起始日期</param>
        /// <param name="p_strToDat">检验终止日期</param>
        /// <param name="p_strDeviceModelID">仪器型号</param>
        /// <param name="p_strPatientName">病人姓名</param>
        /// <param name="p_strSampleID">标本号</param>
        /// <param name="p_objResultArr">查询结果VO</param>
        /// <returns></returns>
        public long m_lngGetApplicationVOArrByCondition(string p_strFromDat, string p_strToDat, string p_strDeviceID, string p_strPatientName,
            string p_strSampleID, out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetApplicationVOArrByCondition(objPrincipal, p_strFromDat, p_strToDat, p_strDeviceID, p_strPatientName, p_strSampleID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单信息 童华 2004.06.21
        public long m_lngGetApplicationInfoByApplicationID(string p_strApplicationID, out clsLisApplMainVO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));
            lngRes = objAppSvc.m_lngGetApplicationInfoByApplicationID(objPrincipal, p_strApplicationID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的申请单元 童华 2004.06.17
        public long m_lngGetAppApplyUnitVOByApplicationID(string p_strApplicationID, out clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppApplyUnitVOByApplicationID(objPrincipal, p_strApplicationID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的检验项目 童华 2004.06.17
        public long m_lngGetAppCheckItemVOArr(string p_strApplicationID, out clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppCheckItemVOArr(objPrincipal, p_strApplicationID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID、样本组ID和报告组ID查询申请单下的检验项目 童华 2004.06.17
        public long m_lngGetAppCheckItemVOArr(string p_strApplicationID, string p_strSampleGroupID, string p_strReportGroupID, out clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppCheckItemVOArr(objPrincipal, p_strApplicationID, p_strSampleGroupID, p_strReportGroupID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的标本组 童华 2004.06.17
        public long m_lngGetAppSampleGroupVOArr(string p_strApplicationID, out clsT_OPR_LIS_APP_SAMPLE_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppSampleGroupVOArr(objPrincipal, p_strApplicationID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID和报告组ID查询申请申请单下的标本组 童华 2004.06.17
        public long m_lngGetAppSampleGroupVOArr(string p_strApplicationID, string p_strReportGroupID, out clsT_OPR_LIS_APP_SAMPLE_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppSampleGroupVOArr(objPrincipal, p_strApplicationID, p_strReportGroupID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据申请单ID查询申请单下的报告组 童华 2004.06.17
        public long m_lngGetAppReportVOArrByApplicationID(string p_strApplicationID, out clsT_OPR_LIS_APP_REPORT_VO[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngGetAppReportVOArrByApplicationID(objPrincipal, p_strApplicationID, out p_objResultArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 为表 T_OPR_LIS_APPLICATION 新增,修改,删除 用的方法 刘彬 2004.06.3
        /// <summary>
        /// 为表 T_OPR_LIS_APPLICATION 新增,修改,删除 用的方法 刘彬 2004.06.3
        /// </summary>
        /// <param name="objApplMainVO"></param>
        /// <returns></returns>
        public long m_lngAddNewApplication(com.digitalwave.iCare.ValueObject.clsLisApplMainVO objApplMainVO)
        {
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO objOutVO = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppl(objPrincipal, objApplMainVO, out objOutVO);

            if (lngRes > 0 && objOutVO != null)
            {
                objOutVO.m_mthCopyTo(objApplMainVO);
            }
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region [U]m_lngInsertAppReportRecord  为表 t_opr_lis_app_report 新增,修改,删除 记录时用 刘彬 2004.05.26

        /// <summary>
        /// 为表 t_opr_lis_app_report 新增,修改,删除 记录时用 
        /// 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>
        public long m_lngInsertAppReportRecord(clsT_OPR_LIS_APP_REPORT_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngInsertAppReportRecord(objPrincipal, p_objRecordVOArr);
            //			objAppSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region m_lngAddNewAppSampleGroup 为表 T_OPR_LIS_APP_SAMPLE 新增 记录时用 刘彬 2004.05.26
        /// <summary>
        /// 为表 T_OPR_LIS_APP_SAMPLE 新增记录时用 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>

        public long m_lngAddNewAppSampleGroup(clsT_OPR_LIS_APP_SAMPLE_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppSampleGroup(objPrincipal, p_objRecordVOArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region m_lngAddNewAppApplyUint 为表 T_OPR_LIS_APP_APPLY_UNIT 新增记录时用 刘彬 2004.05.26
        /// <summary>
        /// 为表 T_OPR_LIS_APP_APPLY_UNIT 新增记录时用 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>

        public long m_lngAddNewAppApplyUint(clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppApplyUint(objPrincipal, p_objRecordVOArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region m_lngAddNewAppCheckItem 为表 T_OPR_LIS_APP_CHECK_ITEM 新增记录时用 刘彬 2004.05.26
        /// <summary>
        /// 为表 T_OPR_LIS_APP_CHECK_ITEM 新增记录时用 刘彬 2004.05.26
        /// </summary>
        /// <param name="p_objRecordVOArr"></param>
        /// <returns></returns>

        public long m_lngAddNewAppCheckItem(clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objRecordVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppCheckItem(objPrincipal, p_objRecordVOArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息) 刘彬 2004.05.26
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
        public long m_lngAddNewAppInfo(com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO objLisApplMainVO = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngAddNewAppInfo(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
            if (lngRes > 0 && objLisApplMainVO != null)
            {
                objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
            }
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,及样本在内的全部信息) 刘彬 2004.05.26
        /// <summary>
        /// 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目,及样本在内的全部信息)
        /// </summary>
        /// <param name="applMain"></param>
        /// <param name="arrReports"></param>
        /// <param name="arrSamples"></param>
        /// <param name="arrCheckItems"></param>
        /// <param name="arrUnitItemRelations"></param>
        /// <param name="arrApplyUnits"></param>
        /// <returns></returns>
        public long m_lngAddNewAppAndSampleInfo(ref com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
             ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            ref com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            ref com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            com.digitalwave.iCare.ValueObject.clsLisApplMainVO objLisApplMainVO = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            //lngRes = objAppSvc.m_lngAddNewAppAndSampleInfo(objPrincipal,p_objLisApplMainVO,out objLisApplMainVO, p_objReportArr,p_objAppSampleArr,	p_objAppItemArr,p_objAppUnitArr,p_objAppUnitItemArr);
            //change by wjqin(07-4-28) 解决三层爆错的问题 加上了个ref 
            lngRes = objAppSvc.m_lngAddNewAppAndSampleInfoNew(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, ref p_objReportArr, ref p_objAppSampleArr, ref p_objAppItemArr, ref p_objAppUnitArr, ref p_objAppUnitItemArr);
            /*<=======================*/
            if (lngRes > 0 && objLisApplMainVO != null)
            {
                objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
            }
            objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 增加-组新的检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息) 刘彬 2004.05.26
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
        public long m_lngAddAppInfoWithoutReceive(clsLisApplMainVO p_objLisApplMainVO,
                                        clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
                                        clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
                                        clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
                                        clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
                                        clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            clsLisApplMainVO objLisApplMainVO = null;
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
                lngRes = objAppSvc.m_lngAddNewAppAndSampleInfoWithoutReceive(objPrincipal, p_objLisApplMainVO, out objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);

                if (lngRes > 0 && objLisApplMainVO != null)
                {
                    objLisApplMainVO.m_mthCopyTo(p_objLisApplMainVO);
                }
                objAppSvc.Dispose();
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        #endregion

        #region  修改-组检验申请信息(包含报告组,申请单元,样本组,检验项目在内的全部信息) 刘彬 2004.06.30
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
        public long m_lngModifyAppInfo(com.digitalwave.iCare.ValueObject.clsLisApplMainVO p_objLisApplMainVO,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_REPORT_VO[] p_objReportArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_SAMPLE_VO[] p_objAppSampleArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_CHECK_ITEM_VO[] p_objAppItemArr,
            com.digitalwave.iCare.ValueObject.clsT_OPR_LIS_APP_APPLY_UNIT_VO[] p_objAppUnitArr,
            com.digitalwave.iCare.ValueObject.clsLisAppUnitItemVO[] p_objAppUnitItemArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objAppSvc.m_lngModifyAppInfo(objPrincipal, p_objLisApplMainVO, p_objReportArr, p_objAppSampleArr, p_objAppItemArr, p_objAppUnitArr, p_objAppUnitItemArr);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新体检登记表，使其状态为保存
        /// <summary>
        /// 更新体检登记表，使其状态为保存
        /// </summary>
        /// <param name="strApplicationID"></param>
        /// <returns></returns>
        public long m_lngUpdatePEReg(string strApplicationID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsReportSvc objAppSvc =
                (com.digitalwave.iCare.middletier.LIS.clsReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsReportSvc));
            lngRes = objAppSvc.m_lngUpdatePEReg(strApplicationID);
            //			objAppSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 作废申请单
        /// <summary>
        /// 作废申请单
        /// </summary>
        /// <param name="p_strAppID"></param>
        /// <returns></returns>
        public long m_lngUpdateVoidApply(string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objSvc.m_lngUpdateVoidApply(objPrincipal, p_strAppID, p_strOperatorID);
            return lngRes;
        }
        #endregion

        #region 通过申请单号判断是否审核
        /// <summary>
        /// 通过申请单号判断是否审核
        /// </summary>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_dtResult"></param>
        /// <param name="p_dtUnitResult"></param>
        /// <returns></returns>
        public long m_lnqQueryConfirmReport(string p_strApplicationID, out DataTable p_dtResult, out DataTable p_dtUnitResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objSvc =
              (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objSvc.m_lnqQueryConfirmReport(objPrincipal, p_strApplicationID, out p_dtResult, out p_dtUnitResult);
            return lngRes;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="p_strParmValue"></param>
        /// <returns></returns>
        public long m_lngGetSysParm(string p_strParmCode, out string p_strParmValue)
        {
            p_strParmValue = "";
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objSvc =
             (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objSvc.m_lngGetSysParm(p_strParmCode, out p_strParmValue);
            return lngRes;
        }
        #endregion

        #region 修改t_opr_lis_app_report 表的打印次数
        /// <summary>
        /// 修改t_opr_lis_app_report 表的打印次数
        /// </summary>
        /// <param name="p_strApplicaionID"></param>
        /// <returns></returns>
        public long m_lngUpdatePrinctTime(string p_strApplicaionID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objSvc =
             (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
            lngRes = objSvc.m_lngUpdatePrinctTime(objPrincipal, p_strApplicaionID);
            return lngRes;
        }
        #endregion

        #region 取消审核
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="p_strAppID">申请单ID</param>
        /// <param name="p_strOperatorID">操作员工ID</param>
        /// <returns>大于0成功，否则失败</returns>
        public long m_lngCancelConfimReport(string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;
            clsApplicationSvc objSvc =
                (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
            lngRes = objSvc.m_lngCancelConfimReport(p_strAppID, p_strOperatorID);
            return lngRes;
        }
        #endregion

        #region 获取检验类别
        /// <summary>
        /// 获取检验类别
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryCheckCategory(out DataTable p_dtResult)
        {
            long lngRes = 0;
            clsApplicationSvc objSvc =
                (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
            lngRes = objSvc.m_lngQueryCheckCategory(out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 查询申请信息
        /// <summary>
        /// 查询申请信息
        /// </summary>
        /// <param name="p_objSchVO"></param>
        /// <param name="p_strCheckCategory"></param>
        /// <param name="p_objAppVOArr"></param>
        /// <returns></returns>
        public long m_lngGetAppInfoByModifDate(clsLISApplicationSchVO p_objSchVO, string p_strCheckCategory, out clsLisApplMainVO[] p_objAppVOArr)
        {
            long lngRes = 0;
            clsApplicationSvc objSvc =
                (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc));
            lngRes = objSvc.m_lngGetAppInfoByModifDate(objPrincipal, p_objSchVO, p_strCheckCategory, out p_objAppVOArr);
            return lngRes;
        }
        #endregion

        #region 获取体检申请项目
        /// <summary>
        /// 获取体检申请项目
        /// </summary>
        /// <param name="regNo"></param>
        /// <returns></returns>
        public DataTable GetAppItem(string regNo)
        {
            using (bizCriticalValue lisSvc = (bizCriticalValue)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue)))
            {
                return lisSvc.GetAppItem(regNo);
            }
        }
        #endregion

        #region 检验-体检接口

        #region 打包-获取体检申请信息
        /// <summary>
        /// 打包-获取体检申请信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable GetPeSample(string barCode)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetPeSample(barCode);
            }
        }
        #endregion

        #region 打包-校验是否已打包
        /// <summary>
        /// 打包-校验是否已打包
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool SamplePackIsExist(string barCode)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackIsExist(barCode);
            }
        }
        #endregion

        #region 打包-插入
        /// <summary>
        /// 打包-插入
        /// </summary>
        /// <param name="lstSamplePack"></param>
        /// <param name="lstSamplePackDet"></param>
        /// <param name="packId"></param>
        /// <returns></returns>
        public int SamplePackInsert(List<EntitySamplePack> lstSamplePack, List<EntitySamplePackDetail> lstSamplePackDet, int bizType, out decimal packId)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackInsert(lstSamplePack, lstSamplePackDet, bizType, out packId);
            }
        }
        #endregion

        #region 打包-删除
        /// <summary>
        /// 打包-删除
        /// </summary>
        /// <param name="lstBarCode"></param>
        /// <returns></returns>
        public int SamplePackDel(List<string> lstBarCode)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackDel(lstBarCode);
            }
        }
        #endregion

        #region 打包-查询
        /// <summary>
        /// 打包-查询
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public List<EntitySamplePack> SamplePackQuery(string barCode, int bizType)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackQuery(barCode, bizType);
            }
        }
        #endregion

        #region 打包-核收
        /// <summary>
        /// 打包-核收
        /// </summary>
        /// <param name="sampleVo"></param>
        /// <returns></returns>
        public bool SamplePackCheck(EntitySamplePack sampleVo)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackCheck(sampleVo);
            }
        }
        #endregion

        #region bak-检验-体检接口
        /// <summary>
        /// bak-检验-体检接口 
        /// </summary>
        /// <param name="patVo"></param>
        /// <returns></returns>
        public bool PEItf(clsLisApplMainVO patVo, DataTable dtPe, out List<clsLisApplMainVO> lstApp)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.PEItf(patVo, dtPe, out lstApp);
            }
        }
        #endregion

        #region 住院检验项目查询
        /// <summary>
        /// 住院检验项目查询
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public DataTable GetIpSample(string barCode)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.GetIpSample(barCode);
            }
        }
        #endregion

        #endregion

        #region 病区报告查询
        /// <summary>
        /// 病区报告查询
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="ipNo"></param>
        /// <returns></returns>
        public DataTable QueryAreaReport(string deptId, string startDate, string endDate, string ipNo)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.QueryAreaReport(deptId, startDate, endDate, ipNo);
            }
        }
        #endregion

        #region 通过条码找申请单号
        /// <summary>
        /// 通过条码找申请单号
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public string GetApplicationIdByBarcode(string barCode)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.GetApplicationIdByBarcode(barCode);
            }
        }
        #endregion

        #region 打包-查询临时包
        /// <summary>
        /// 打包-查询临时包
        /// </summary>
        /// <param name="floorNo"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool SamplePackQueryTemp(decimal floorNo, out string barCode)
        {
            using (clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
            {
                return lisSvc.SamplePackQueryTemp(floorNo, out barCode);
            }
        }
        #endregion

        #region 通过申请单号找标本信息(微信)
        /// <summary>
        /// 通过申请单号找标本信息(微信)
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public DataTable GetWechatSampleInfo(string applicationId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetWechatSampleInfo(applicationId);
            }
        }
        #endregion

        #region 检查是否绑卡(微信)
        /// <summary>
        /// 微信检查是否绑卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsWechatBanding(string cardNo)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.IsWechatBanding(cardNo);
            }
        }
        #endregion

        #region 获取标本拒收原因
        /// <summary>
        /// 获取标本拒收原因
        /// </summary>
        /// <returns></returns>
        public DataTable GetRejectReason()
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetRejectReason();
            }
        }
        #endregion

        #region 通过处方号返回诊疗卡号
        /// <summary>
        /// 通过处方号返回诊疗卡号
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public string GetCardNoByRecipeId(string recipeId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetCardNoByRecipeId(recipeId);
            }
        }
        #endregion

        #region 获取医嘱字典.申请单元.采样次数
        /// <summary>
        /// 获取医嘱字典.申请单元.采样次数
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="applyUnitId"></param>
        /// <returns></returns>
        public DataTable GetOrderDicSamplingTimes(string orderId, string applyUnitId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetOrderDicSamplingTimes(orderId, applyUnitId);
            }
        }
        #endregion

        #region 获取申请单检验人、审核人
        /// <summary>
        /// 获取申请单检验人、审核人
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public DataTable GetApplicationOperInfo(string applicationId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetApplicationOperInfo(applicationId);
            }
        }
        #endregion

        #region 查询检验项目ID历史值
        /// <summary>
        /// 查询检验项目ID历史值
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="itemIdArr"></param>
        /// <returns></returns>
        public DataTable GetCheckItemHistoryValue(string applicationId, string itemIdArr)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetCheckItemHistoryValue(applicationId, itemIdArr);
            }
        }
        #endregion

        #region 查询:医嘱->诊疗项目-检验申请单元(一对多,如:糖耐量)
        /// <summary>
        /// 查询:医嘱->诊疗项目-检验申请单元(一对多,如:糖耐量)
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public DataTable GetOrderDicLisApplyUnitByOrderId(string orderId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetOrderDicLisApplyUnitByOrderId(orderId);
            }
        }
        #endregion

        #region 查询:诊疗项目-检验申请单元(一对多,如:糖耐量)
        /// <summary>
        /// 查询:诊疗项目-检验申请单元(一对多,如:糖耐量)
        /// </summary>
        /// <param name="orderDicId"></param>
        /// <returns></returns>
        public DataTable GetOrderDicLisApplyUnit(string orderDicId)
        {
            using (clsLIS_Svc2 lisSvc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            {
                return lisSvc.GetOrderDicLisApplyUnit(orderDicId);
            }
        }
        #endregion

        #region 修改急诊状态
        /// <summary>
        /// 修改急诊状态
        /// </summary>
        /// <param name="appMainVo"></param>
        /// <param name="emerStatus"></param>
        /// <returns></returns>
        public int UpdateEmergencyStatus(clsLisApplMainVO appMainVo)
        {
            using (clsApplicationSvc lisSvc = (clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsApplicationSvc)))
            {
                //return lisSvc.UpdateEmergencyStatus(appMainVo);
                return 0;
            } 
        }
        #endregion

    }
}
