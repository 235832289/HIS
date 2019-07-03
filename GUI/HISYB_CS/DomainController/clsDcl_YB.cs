using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HISYBCS_SVC.DLL
using System.Data;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsDcl_YB : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_YB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 保存医保结算返回信息SP3_2004
        /// <summary>
        /// 保存医保结算返回信息SP3_2004
        /// </summary>
        /// <param name="objDgmzjsfhVo"></param>
        /// <returns></returns>
        public long m_lngSaveYBChargeReturn(string strRegID, clsDGMzjsfh_VO objDgmzjsfhVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngSaveYBChargeReturn(strRegID, objDgmzjsfhVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取门诊结算需传入的数据
        /// <summary>
        /// 获取门诊结算需传入的数据
        /// </summary>
        /// <param name="strRecipeID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetDgmzjsdata(string strRecipeID, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetDgmzjsdata(strRecipeID, out dtResult);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 获取住院医保登记所需数据
        /// <summary>
        /// 获取住院医保登记所需数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetZYYBRegister(string strRegisterId, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetZYYBRegister(strRegisterId, out dtResult);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 保存住院医保登记返回信息
        /// <summary>
        /// 保存住院医保登记返回信息
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strJzjlh"></param>
        /// <returns></returns>
        public long m_lngSaveYBZYRegInfo(string strRegID, string strJzjlh, string jbr, clsDGZydj_VO objDgzydjVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngSaveYBZYRegInfo(strRegID, strJzjlh, jbr, objDgzydjVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 修改住院医保登记返回信息
        /// <summary>
        /// 修改住院医保登记返回信息
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strJzjlh"></param>
        /// <returns></returns>
        public long m_lngUpdateYBZYRegInfo(string strRegID, clsDGZydj_VO objDgzydjVo, clsDGExtra_VO objDgextraVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateYBZYRegInfo(strRegID, objDgzydjVo, objDgextraVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取住院医保待遇享受所需数据
        /// <summary>
        /// 获取住院医保待遇享受所需数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="objDgzydyxsVo"></param>
        /// <returns></returns>
        public long m_lngGetZYYBDyxs(string strJslx, string strRegisterId, ref string strName, ref string strZyh, ref string strStatus, out clsDGZydyxs_VO objDgzydyxsVo, out clsDGZyjsfh_VO objDgzyjsfhVo, out decimal decZyfyze, out decimal decGrzfeije)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetZYYBDyxs(strJslx, strRegisterId, ref strName, ref strZyh, ref strStatus, out objDgzydyxsVo, out objDgzyjsfhVo, out decZyfyze, out decGrzfeije);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 获取住院传送明细数据
        /// <summary>
        /// 获取住院传送明细数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="lstDgzyxmcsVo"></param>
        /// <param name="p_blnDiffCostOn">启用让利</param>
        /// <returns></returns>
        public long m_lngGetDgzyxmcs(string strRegisterId, out List<clsDGZyxmcs_VO> lstDgzyxmcsVo, bool p_blnDiffCostOn, decimal decHISTotalSum, List<string> lstPChargeId)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetDgzyxmcs(strRegisterId, out lstDgzyxmcsVo, p_blnDiffCostOn, decHISTotalSum, lstPChargeId);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 获取住院传送明细数据
        /// <summary>
        /// 获取住院传送明细数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="lstDgzyxmcsVo"></param>
        /// <param name="p_blnDiffCostOn">启用让利</param>
        /// <returns></returns>
        public long m_lngGetDgzyxmcs(DateTime p_dateBegin, DateTime p_dateEnd, out List<clsDGZyxmcs_VO> lstDgzyxmcsVo, bool p_blnDiffCostOn)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetDgzyxmcs(p_dateBegin, p_dateEnd, out lstDgzyxmcsVo, p_blnDiffCostOn);
            objSvc.Dispose();
            return l;
        }

        public long m_lngGetDgzyxmcs(DateTime p_dateBegin, DateTime p_dateEnd, out List<clsDGZyxmcs_VO> lstDgzyxmcsVo, bool p_blnDiffCostOn, string jzjlh)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetDgzyxmcs2(p_dateBegin, p_dateEnd, out lstDgzyxmcsVo, p_blnDiffCostOn, jzjlh);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 更新住院传送明细数据
        /// <summary>
        /// 更新住院传送明细数据
        /// </summary>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngUpdateDgzyxmcs(List<clsDGZyxmcs_VO> lstDgzyxmcsVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateDgzyxmcs(lstDgzyxmcsVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新住院传送明细数据
        /// <summary>
        /// 更新住院传送明细数据
        /// </summary>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngUpdateDgzyxmcs(string strRegID)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateDgzyxmcs(strRegID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取住院医保结算所需数据
        /// <summary>
        /// 获取住院医保结算所需数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="objDgzyjsVo"></param>
        /// <returns></returns>
        public long m_lngGetZYYBjs(string strJslb, string strInvNo, string strZDZMHM, decimal decTotal, string strRegisterId, out clsDGZyjs_VO objDgzyjsVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetZYYBjs(strJslb, strInvNo, strZDZMHM, decTotal, strRegisterId, out objDgzyjsVo);
            objSvc.Dispose();
            return l;
        }

        /// <summary>
        /// 获取住院医保结算所需数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="objDgzyjsVo"></param>
        /// <returns></returns>
        public long m_lngGetZYYBjs(string strJslb, string strInvNo, string strZDZMHM, decimal decTotal, string strRegisterId, out clsDGZyjs_VO objDgzyjsVo, bool p_blnDiffOn)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetZYYBjs(strJslb, strInvNo, strZDZMHM, decTotal, strRegisterId, out objDgzyjsVo, p_blnDiffOn);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 获取住院医保出院登记所需数据
        /// <summary>
        /// 获取住院医保出院登记所需数据
        /// </summary>
        /// <param name="strRegisterId"></param>
        /// <param name="objDgzycydjVo"></param>
        /// <returns></returns>
        public long m_lngGetZYYBCydj(string strRegisterId, string strJZJLH, out clsDGZycydj_VO objDgzycydjVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc =
                                                                      (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));

            long l = objSvc.m_lngGetZYYBCydj(strRegisterId, strJZJLH, out objDgzycydjVo);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 保存住院医保结算返回信息
        /// <summary>
        /// 保存住院医保结算返回信息
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="objDgzyjsfhVo"></param>
        /// <returns></returns>
        public long m_lngSaveYBChargeReturnZY(string strRegID, string strInvNo, clsDGZyjsfh_VO objDgzyjsfhVo, string strJSDYZDBY)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngSaveYBChargeReturnZY(strRegID, strInvNo, objDgzyjsfhVo, strJSDYZDBY);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新住院登记表状态
        /// <summary>
        /// 更新住院登记表状态
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strStatusFlag"></param>
        /// <returns></returns>
        public long m_lngUpdateYBRegisterStatusZY(string strRegID, string strStatusFlag)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateYBRegisterStatusZY(strRegID, strStatusFlag);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新住院结算表状态
        /// <summary>
        /// 更新住院结算表状态
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strStatusFlag"></param>
        /// <returns></returns>
        public long m_lngUpdateYBChargeStatusZY(string strSdywh, string strRegID, string strStatusFlag)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateYBChargeStatusZY(strSdywh, strRegID, strStatusFlag);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 保存医院经办人注册记录
        /// <summary>
        /// 保存医院经办人注册记录
        /// </summary>
        /// <param name="m_clsDGYBjbrzcVo">办人注册VO</param>
        /// <returns></returns>
        public long m_lngSaveUserRegister(clsDGYBjbrzc_VO m_clsDGYBjbrzcVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngSaveUserRegister(m_clsDGYBjbrzcVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据发票号取病人医保结算信息
        /// <summary>
        /// 根据发票号取病人医保结算信息
        /// </summary>
        /// <param name="strInvoiceNo"></param>
        /// <param name="dtPatientInfo"></param>
        /// <param name="dtFee"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByInvoice(string strInvoiceNo, out DataTable dtPatientInfo, out DataTable dtFee)
        {
            long lngRes = -1;
            dtPatientInfo = null;
            dtFee = null;
            //com.digitalwave.iCare.middletier.HIS.clsYBTSQuerySVC objSvc =
            //    (com.digitalwave.iCare.middletier.HIS.clsYBTSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBTSQuerySVC));
            //long lngRes =  objSvc.m_lngGetPatientInfoByInvoice(strInvoiceNo, out dtPatientInfo, out dtFee);
            //objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 加载医院经办人
        /// <summary>
        /// 加载医院经办人
        /// </summary>
        /// <param name="p_objResult">输出数据</param>
        /// <returns></returns>
        public long m_lngGetUserRegister(out clsDGYBjbrzc_VO[] p_objResult)
        {
            p_objResult = new clsDGYBjbrzc_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            long lngRes = objSvc.m_lngGetUserRegister(out p_objResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取病人的基本信息
        /// <summary>
        /// 获取病人的基本信息
        /// </summary>
        /// <param name="p_InPatientID"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfo(string p_InPatientID, string strFlag, out DataTable dtResult)
        {
            dtResult = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            long lngRes = objSvc.m_lngGetPatientInfo(p_InPatientID, strFlag, out dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 修改医院登录密码
        /// <summary>
        /// 修改医院登录密码
        /// </summary>
        /// <param name="p_strPwd">新密码</param>
        /// <param name="p_strYYBH">医院编码</param>
        /// <returns></returns>
        public long m_lngHospitalUserLogin(string p_strPwd, string p_strYYBH)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngHospitalUserLogin(p_strPwd, p_strYYBH);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取门诊结算退款的相关信息
        /// <summary>
        /// 获取门诊结算退款的相关信息
        /// </summary>
        /// <param name="p_strSywh"></param>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngCSYBChargeCancel(string p_strSywh, int flag, out  clsDGExtra_VO objDgextraVo, out bool p_blRefund)
        {
            objDgextraVo = null;
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            long lngRes = objSvc.m_lngCSYBChargeCancel(p_strSywh, flag, out objDgextraVo, out p_blRefund);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新门诊结算退款的相关信息
        /// <summary>
        /// 更新门诊结算退款的相关信息
        /// </summary>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngUpdateCSYBChargeCancel(clsDGExtra_VO objDgextraVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateCSYBChargeCancel(objDgextraVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 医保结算单打印验证
        /// <summary>
        /// 医保结算单打印验证
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngGetYBChargeZY(string p_strRegisterId, out  clsDGExtra_VO objDgextraVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            long lngRes = objSvc.m_lngGetYBChargeZY(p_strRegisterId, out objDgextraVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断是否有社保病人登记
        /// <summary>
        /// 判断是否有社保病人登记
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <returns></returns>
        public bool m_blGetIsYBReg(string p_strRegisterId)
        {
            bool blRes = false;
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            blRes = objSvc.m_lngGetPatientInfo(p_strRegisterId);
            objSvc.Dispose();
            return blRes;
        }
        #endregion

        #region 门诊结算信息修改
        /// <summary>
        /// 门诊结算信息修改
        /// </summary>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngUpdateCSYBChargeInfo(clsDGExtra_VO objDgextraVo, string strMZorZY)
        {
            clsYBCSRequiredSVC objSvc = (clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSRequiredSVC));
            long lngRes = objSvc.m_lngUpdateCSYBChargeInfo(objDgextraVo, strMZorZY);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查询门诊病人信息
        /// <summary>
        /// 查询门诊病人信息
        /// </summary>
        /// <param name="objDgextraVo"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfo(string p_strID, out DataTable dtResult)
        {
            clsYBCSQuerySVC objSvc = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC));
            long lngRes = objSvc.m_lngGetPatientInfo(p_strID, out dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 检测是否已填住院诊断
        /// <summary>
        /// 检测是否已填住院诊断
        /// </summary>
        /// <param name="p_strCheckOutType"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngCheckDiagnose2(string p_strCheckOutType, string p_strRegisterID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = new DataTable();
            #region 中间件操作
            clsYBCSQuerySVC objServ = null;
            try
            {
                objServ = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC));
                lngRes = objServ.m_lngCheckDiagnose2(p_strCheckOutType, p_strRegisterID, out p_dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 通过住院号来获取社保病人的就诊记录号
        /// <summary>
        /// 通过住院号来获取社保病人的就诊记录号
        /// </summary>
        /// <param name="strInpatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetJZJLHbyInpatientID(string strInpatientID, out DataTable dtResult)
        {
            long lngRes = 0;
            dtResult = new DataTable();
            #region 中间件操作
            clsYBCSQuerySVC objServ = null;
            try
            {
                objServ = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC));
                lngRes = objServ.m_lngGetJZJLHbyInpatientID(strInpatientID, out dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 通过就诊记录号来获取社保病人的结算号
        /// <summary>
        /// 通过就诊记录号来获取社保病人的结算号
        /// </summary>
        /// <param name="strInpatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetJSHbyJZJLH(string strInpatientID, out DataTable dtResult)
        {
            long lngRes = 0;
            dtResult = new DataTable();
            #region 中间件操作
            clsYBCSQuerySVC objServ = null;
            try
            {
                objServ = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC));
                lngRes = objServ.m_lngGetJSHbyJZJLH(strInpatientID, out dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 获取社保、医院科室或病人身份的数据
        /// <summary>
        /// 获取社保、医院科室或病人身份的数据
        /// </summary>
        /// <param name="intType"></param>
        /// <returns></returns>
        public long m_lngGetHosYBData(int intType, out DataTable dtHosp, out DataTable dtYBHospCorr)
        {
            long lngRes = 0;
            dtHosp = new DataTable();
            dtYBHospCorr = new DataTable();
            #region 中间件操作
            clsYBCSQuerySVC objServ = null;
            try
            {
                objServ = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC));
                lngRes = objServ.m_lngGetHosYBData(intType, out dtHosp, out dtYBHospCorr);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="intType">1:科室；2:病人身份</param>
        /// <param name="strHospID"></param>
        /// <param name="strName"></param>
        /// <param name="strYBID"></param>
        /// <param name="strYBName"></param>
        /// <returns></returns>
        public long m_lngSaveData(int intType, string strHospID, string strName, string strYBID, string strYBName)
        {
            long lngRes = 0;
            #region 中间件操作
            clsYBCSRequiredSVC objServ = null;
            try
            {
                objServ = (clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSRequiredSVC));
                lngRes = objServ.m_lngSaveData(intType, strHospID, strName, strYBID, strYBName);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="strHospID"></param>
        /// <param name="strYBID"></param>
        /// <param name="intType"></param>
        /// <returns></returns>
        public long m_lngDelData(string strHospID, string strYBID, int intType)
        {
            long lngRes = 0;
            #region 中间件操作
            clsYBCSRequiredSVC objServ = null;
            try
            {
                objServ = (clsYBCSRequiredSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSRequiredSVC));
                lngRes = objServ.m_lngDelData(strHospID, strYBID, intType);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 根据就诊记录号来获取社保卡验证信息
        /// <summary>
        /// 根据就诊记录号来获取社保卡验证信息
        /// </summary>
        /// <param name="strJzjlh"></param>
        /// <param name="objDGExtraVO"></param>
        /// <returns></returns>
        public long m_lngGetYBPswCheckInfo(string strJzjlh, ref clsDGExtra_VO objDGExtraVO, out DateTime dtmFyrq)
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            long l = objSvc.m_lngGetYBPswCheckInfo(strJzjlh, ref objDGExtraVO, out dtmFyrq);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region ICD10诊断
        /// <summary>
        /// ICD10诊断
        /// </summary>
        /// <returns></returns>
        public DataTable GetIcd10()
        {
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC svc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            DataTable dt = svc.GetIcd10();
            svc.Dispose();
            return dt;
        }
        #endregion

        #region 费用结算最大(终止)日期
        /// <summary>
        /// 费用结算最大(终止)、最小日期
        /// </summary>
        /// <returns></returns>
        public string GetFeeMaxDate(string regId)
        {
            string maxDate = string.Empty;
            string minDate = string.Empty;
            com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC svc = (com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBCSQuerySVC));
            svc.m_lngGetZYFYSJ(regId, out maxDate, out minDate);
            svc.Dispose();
            if (string.IsNullOrEmpty(maxDate))
                maxDate = DateTime.Now.ToString("yyyyMMdd");
            else
                maxDate = Convert.ToDateTime(maxDate).ToString("yyyyMMdd");
            return maxDate;
        }
        #endregion

        #region 行政区域代码
        /// <summary>
        /// 行政区域代码
        /// </summary>
        /// <returns></returns>
        public DataTable GetAdministrative()
        {
            using (clsYBCSQuerySVC svc = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC)))
            {
                return svc.GetAdministrative();
            }
        }
        #endregion

        #region 是否启用儿童价格
        /// <summary>
        /// 是否启用儿童价格
        /// </summary>
        /// <returns></returns>
        public bool IsUseChildPrice()
        {
            using (clsYBCSQuerySVC svc = (clsYBCSQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBCSQuerySVC)))
            {
                return svc.IsUseChildPrice();
            }
        }
        #endregion

    }
}
