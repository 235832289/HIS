using System;
using System.Data;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 门诊发药控制层
    /// </summary>
    public class clsDomainControlOPMedStore : clsDomainController_Base
    {
        /// <summary>
        /// 获取药房信息
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo(string m_strMedStoreid, ref DataTable dtResult)
        {
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetMedStoreInfo(m_strMedStoreid, ref dtResult);
            return lngRes;
        }
        /// <summary>
        /// 获取退药处方信息
        /// </summary>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetReturnMedicine(string strMedStoreid, string strBeginDate, string strEndDate, int p_intDeductFlow, out DataTable m_objTable)
        {
            m_objTable = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetReturnMedicine(objPrincipal, strMedStoreid, strBeginDate, strEndDate, p_intDeductFlow, out m_objTable);
            return lngRes;

        }
        /// <summary>
        /// 根据处方id和药房id获取已发药处方明细
        /// </summary>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        public long m_lngGetSendMedRecipeDetailByid(string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            p_dtItemDe = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetSendMedRecipeDetailByid(objPrincipal, m_strOPRecipeid, m_strMedStoreid, out p_dtItemDe);
            return lngRes;
        }
        /// <summary>
        /// 获取退药信息
        /// </summary>
        /// <param name="m_strOutPatientRecipe"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetReturnDetailInfo(string m_strOutPatientRecipe, ref DataTable dtResult)
        {
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetReturnDetailInfo(m_strOutPatientRecipe, ref dtResult);
            return lngRes;
        }
        /// <summary>
        /// 根据处方号获取处方状态
        /// </summary>
        /// <param name="m_strOutPatientRecipeid"></param>
        /// <param name="m_intStatus"></param>
        /// <returns></returns>
        public long m_lngGetRecipeStatus(string m_strOutPatientRecipeid, out int m_intStatus)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetRecipeStatus(objPrincipal, m_strOutPatientRecipeid, out m_intStatus);
            return lngRes;
        }
        /// <summary>
        /// 撤销药房退药信息
        /// </summary>
        /// <param name="m_objDetailList"></param>
        /// <returns></returns>
        public long m_lngRollBackReturnMedInfo(string m_strOperatorid, List<clsReutrnMedEntry> m_objDetailList, out string p_strExcp)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngRollBackReturnMedInfo(objPrincipal, m_strOperatorid, m_objDetailList, out p_strExcp);
            return lngRes;

        }
        /// <summary>
        /// 添加药房退药信息
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailList"></param>
        /// <returns></returns>
        public long m_lngAddReturnMedInfo(clsReutrnMed m_objMainVo, List<clsReutrnMedEntry> m_objDetailList)
        {

            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngAddReturnMedInfo(objPrincipal, m_objMainVo, m_objDetailList);
            return lngRes;

        }
        /// <summary>
        /// 判断是否存在该员工
        /// </summary>
        /// <param name="m_strEmpNO"></param>
        /// <param name="m_strPwd"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetEmpInfo(string m_strEmpNO, string m_strPwd, ref DataTable dtResult)
        {

            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetEmpInfo(m_strEmpNO, m_strPwd, ref dtResult);
            return lngRes;
        }

        #region 构造函数
        /// <summary>
        /// 门诊发药控制层
        /// </summary>
        public clsDomainControlOPMedStore()
        {

        }
        #endregion

        #region 通过窗口取当前病人队列
        /// <summary>
        /// 通过窗口取当前病人队列
        /// </summary>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region 获取先诊疗后结算病人的配药列表
        /// <summary>
        /// 获取先诊疗后结算病人的配药列表
        /// </summary>
        /// <param name="windStatus"></param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetTreatMetnFirstByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetTreatMetnFirstByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region 通过窗口取当前麻醉等特殊处方的病人队列
        /// <summary>
        /// 通过窗口取当前麻醉等特殊处方的病人队列
        /// </summary>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListByWinIDForData(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListByWinIDForData(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region 不通过通过发药窗口取当前病人队列
        /// <summary>
        ///不通过通过发药窗口取当前病人队列
        /// </summary>
        /// <param name="windStatus">窗体状态信息</param>
        /// <param name="strDate"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="dtDuty"></param>
        /// <returns></returns>
        public long m_lngGetPatientListNotByWinID(clsStatusWindows_VO windStatus, string strDate, out DataTable p_dtbResult, DataTable dtDuty)
        {
            long lngRes = 0;
            p_dtbResult = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPatientListNotByWinID(objPrincipal, windStatus, strDate, out p_dtbResult, dtDuty);
            return lngRes;
        }
        #endregion

        #region 获取发药项目详细资料
        /// <summary>
        /// 获取发药项目详细资料
        /// </summary>
        /// <param name="itemCode">行目编码</param>
        /// <param name="dtbResult">返回的数据表</param>
        /// <returns></returns>
        public long m_lngGetItemData(string itemCode, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetItemData(objPrincipal, itemCode, out dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 修改药房发送表叫号标志
        public long m_lngUpdateRecipeSendCalledFlag2(long m_intSid)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCalledFlag2(m_intSid);
            return lngRes;
        }
        #endregion

        #region 修改药房发送表叫号标志
        /// <summary>
        /// 修改药房发送表叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCalledFlag(long m_intSid, int p_intIsReCall)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCalledFlag(m_intSid, p_intIsReCall);
            return lngRes;

        }
        #endregion
        #region 修改药房发送表当前叫号标志
        /// <summary>
        /// 修改药房发送表当前叫号标志
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <param name="m_strSendWindowid"></param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendCurrentCallFlag(long m_intSid, string m_strSendWindowid, int m_intIsReCall, bool m_blnIsModfilySendWinId)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngUpdateRecipeSendCurrentCallFlag2(m_intSid, m_strSendWindowid, m_intIsReCall, m_blnIsModfilySendWinId);
            return lngRes;
        }
        #endregion

        #region 放弃叫号（并不是真正下屏，只是放到队列的后面）
        /// <summary>
        /// 放弃叫号（并不是真正下屏，只是放到队列的后面）
        /// </summary>
        /// <param name="m_intSid">序列号</param>
        /// <returns></returns>
        public long m_lngRecipeSendQuit(long m_intSid)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngRecipeSendQuit(m_intSid);
            return lngRes;
        }
        #endregion

        #region 撤消叫号
        /// <summary>
        /// 撤消叫号
        /// </summary>
        /// <param name="p_intSid"></param>
        /// <returns></returns>
        public long m_lngCancelCalledFalg(long p_lngSid)
        {
            long lngRes = -1;
            clsMedStoreSvc objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngCancelRecipeSendCalledFlag(p_lngSid);
            return lngRes;

        }
        #endregion

        #region 通过窗口取当前病人队列
        /// <summary>
        /// 通过窗口取己发药病人队列
        /// </summary>
        /// <param name="p_strID">窗口号</param>
        /// <param name="p_dtbResult">输出数据</param>
        /// <returns></returns>
        public long m_lngGetPutOutPatientListByWinID(string p_strID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPutOutPatientListByWinID(objPrincipal, p_strID, out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 通过ID更改发药的处方记录的状态
        /// <summary>
        /// 通过ID更改发药的处方记录的状态
        /// </summary>
        /// <param name="p_objItem">处方发送数据</param>
        /// <param name="winID">窗口ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, clsMedRecipeSend_VO p_objItem, DataTable dt, string stroageID, string strTOLMNY, clst_opr_nurseexecute[] nurseexecuteArr, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail, string m_strSubtractMode, string m_strSecondLevelMode)
        {
            long lngRes = 0;

            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, p_objItem, dt, stroageID, strTOLMNY, nurseexecuteArr, p_objDetail, ref m_objOutStorageDetail, m_strSubtractMode, m_strSecondLevelMode);
            return lngRes;
        }
        #endregion
        #region 查找数据
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strCardID">诊疗卡号</param>
        /// <param name="p_strPatient">病人姓名</param>
        /// <param name="p_strRegNo">流水号</param>
        /// <param name="p_strRegDate">开始日期</param>
        ///  <param name="p_endDate">结束日期</param>
        /// <param name="p_dtbResult">输出数据</param>
        /// <returns></returns>
        public long m_lngGetPatientList(int p_intStatus, string p_strStorageID, string p_strWinID, string p_strCardID, string p_strPatient,
            string p_strRegNo, string p_strRegDate, string p_endDate, bool isShowReturn, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPatientList(objPrincipal, p_intStatus, p_strStorageID, p_strWinID, p_strCardID, p_strPatient,
                p_strRegNo, p_strRegDate, p_endDate, isShowReturn, out p_dtbResult);
            return lngRes;
        }
        #endregion
        #region 配药处理
        /// <summary>
        ///  配药处理
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="m_strWindowid"></param>
        /// <param name="m_strSendwindowid"></param>
        /// <param name="m_intSID"></param>
        /// <param name="p_objDetail"></param>
        /// <param name="m_objOutStorageDetail"></param>
        /// <param name="m_strSubtractMode"></param>
        /// <param name="m_strSecondLevelMode"></param>
        /// <returns></returns>
        public long m_lngDosage(clst_opr_nurseexecute[] p_objRecord, string m_strWindowid, string m_strSendwindowid, int m_intSID, clsDS_StorageDetail_VO[] p_objDetail, ref clsDS_Outstorage_Detail[] m_objOutStorageDetail, string m_strSubtractMode, string m_strSecondLevelMode, string p_strMedStoreID)
        {
            long lngRes = 0;

            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngDosageRecipe(objPrincipal, p_objRecord, m_strWindowid, m_strSendwindowid, m_intSID, p_objDetail, ref m_objOutStorageDetail, m_strSubtractMode, m_strSecondLevelMode, p_strMedStoreID);
            return lngRes;
        }
        #endregion
        #region 配药处理
        /// <summary>
        /// 配药处理
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="strwindowsID"></param>
        /// <param name="oldWinID"></param>
        /// <param name="m_intSID"></param>
        /// <returns></returns>
        public long m_lngDosage(clst_opr_nurseexecute[] p_objRecord, string strwindowsID, string oldWinID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngDosage(objPrincipal, p_objRecord, strwindowsID, oldWinID, m_intSID);
            return lngRes;
        }
        #endregion

        #region 退处方
        /// <summary>
        /// 退处方
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngBreak(clst_opr_nurseexecute[] p_objRecord, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngBreak(objPrincipal, p_objRecord, m_intSID);
            return lngRes;
        }
        #endregion

        #region 审核处方处理事务
        /// <summary>
        /// 审核处方处理事务
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="intStatus"></param>
        /// <param name="strCONFIRMDESC"></param>
        /// <param name="strEMPID"></param>
        /// <returns></returns>
        public long m_lngAuditing(clsOutpatientRecipe_VO[] p_objRecord, int intStatus, string strCONFIRMDESC, string strEMPID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngAuditing(objPrincipal, p_objRecord, intStatus, strCONFIRMDESC, strEMPID);
            return lngRes;
        }
        #endregion

        #region 查找未发药病人
        /// <summary>
        /// 查找未发药病人
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strCardID">诊疗卡号</param>
        /// <param name="p_strPatient">病人姓名</param>
        /// <param name="p_strRegNo">流水号</param>
        /// <param name="p_strRegDate">挂号日期</param>
        /// <param name="p_dtbResult">输出数据</param>
        /// <returns></returns>
        public long m_lngGetPatient(string p_strWinID, string p_strCardID, string p_strPatient,
            string p_strRegNo, string p_strRegDate, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetPatient(objPrincipal, p_strWinID, p_strCardID, p_strPatient,
                p_strRegNo, p_strRegDate, out p_dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 是否自动打印发药单
        /// <summary>
        /// 是否自动打印发药单
        /// </summary>
        /// <param name="isAuto"></param>
        /// <returns></returns>
        public long m_mthIsAutoPrint(out bool isAuto)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_mthIsAutoPrint(out isAuto);
            return lngRes;
        }
        #endregion

        #region 通过挂号ID查找处方
        /// <summary>
        /// 通过挂号ID查找处方
        /// </summary>
        /// <param name="p_strID">挂号ID</param>
        /// <param name="p_objResult">输出数据</param>
        /// <returns></returns>
        public long m_lngGetRepiceListByRegID(string p_strID,
            out clsOutpatientRecipe_VO[] p_objResult, DateTime date1, DateTime date2, int intptatus, string strDep)
        {
            long lngRes = 0;
            p_objResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMainRecipe(objPrincipal, p_strID, out p_objResult, date1, date2, intptatus, strDep);
            return lngRes;
        }
        #endregion
        #region 通过序列ID查找处方
        /// <summary>
        /// 通过序列ID查找处方
        /// </summary>
        /// <param name="m_strSid"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetRepiceListBySid(string m_strSid, out clsOutpatientRecipe_VO[] p_objResult)
        {
            long lngRes = 0;
            p_objResult = null;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetMainRecipe(objPrincipal, m_strSid, out p_objResult);
            return lngRes;
        }
        #endregion
        #region 查找所有的发票号（分发票）
        /// <summary>
        /// 查找所有的发票号（分发票）
        /// </summary>
        /// <param name="strOutpatrecipeid">处方ＩＤ</param>
        /// <returns></returns>
        public string m_lngGetAllINVOICENO(string strOutpatrecipeid)
        {
            string strNO = "";
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            strNO = objSvc.m_lngGetAllINVOICENO(objPrincipal, strOutpatrecipeid);
            return strNO;
        }
        #endregion

        #region 通过窗口ID取当前需要发药的处方队列
        /// <summary>
        /// 通过窗口ID取当前需要发药的处方队列
        /// </summary>
        /// <param name="p_strID">窗口ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinID(string p_strID,
            out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinID(objPrincipal, p_strID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过处方ID取当前需要发药的处方队列
        /// <summary>
        /// 通过处方ID取当前需要发药的处方队列
        /// </summary>
        /// <param name="p_strID">处方ID</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByOPID(string p_strID,
            out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByOPID(objPrincipal, p_strID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和处方类型取发药的处方队列
        /// <summary>
        /// 通过窗口号和处方类型取发药的处方队列
        /// </summary>
        /// <param name="p_strID">窗口号</param>
        /// <param name="p_intType">处方类型，1：西药，2：中药</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndType(string p_strID,
            int p_intType, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndType(objPrincipal, p_strID, p_intType, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和处方状态取发药的处方队列
        /// <summary>
        /// 通过窗口号和处方状态取发药的处方队列
        /// </summary>
        /// <param name="p_strID">窗口号</param>
        /// <param name="p_intStatus">处方状态，1：新建，2：已发药...</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndStatus(string p_strID,
            int p_intStatus, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndStatus(objPrincipal, p_strID, p_intStatus, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和发送员取发药的处方队列
        /// <summary>
        /// 通过窗口号和发送员取发药的处方队列
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strEmpID">发送员工号</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndSendEmp(string p_strWinID,
            string p_strEmpID, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndSendEmp(objPrincipal, p_strWinID, p_strEmpID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和发送时间取发药的处方队列
        /// <summary>
        /// 通过窗口号和发送时间取发药的处方队列
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strDate">发送时间</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndSendDate(string p_strWinID,
            string p_strDate, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndSendDate(objPrincipal, p_strWinID, p_strDate, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和处理员取发药的处方队列
        /// <summary>
        /// 通过窗口号和处理员取发药的处方队列
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strEmpID">处理员工号</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndTreatEmp(string p_strWinID,
            string p_strEmpID, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndTreatEmp(objPrincipal, p_strWinID, p_strEmpID, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口号和处理时间取发药的处方队列
        /// <summary>
        /// 通过窗口号和处理时间取发药的处方队列
        /// </summary>
        /// <param name="p_strWinID">窗口号</param>
        /// <param name="p_strDate">处理时间</param>
        /// <param name="p_objResultArr">输出数据</param>
        /// <returns></returns>
        public long m_lngGetMedRecipeListByWinAndTreatDate(string p_strWinID,
            string p_strDate, out clsMedRecipeSend_VO[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = new clsMedRecipeSend_VO[0];

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetMedRecipeListByWinAndTreatDate(objPrincipal, p_strWinID, p_strDate, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过ID更改发药的处方记录的状态
        /// <summary>
        /// 通过ID更改发药的处方记录的状态
        /// </summary>
        /// <param name="p_objItem">处方发送数据</param>
        /// <param name="winID">窗口ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, clsMedRecipeSend_VO p_objItem, DataTable dt, string stroageID, string strTOLMNY, clst_opr_nurseexecute[] nurseexecuteArr)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, p_objItem, dt, stroageID, strTOLMNY, nurseexecuteArr);
            return lngRes;
        }
        #endregion

        #region 写入已打印标志
        /// <summary>
        /// 写入已打印标志
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="m_intSID"></param>
        /// <returns></returns>
        public long m_lngPrintSucc(string winID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngPrintSucc(winID, m_intSID, 0);
            return lngRes;
        }
        #endregion

        #region 获取处方NO
        /// <summary>
        /// 获取处方NO
        /// </summary>
        /// <param name="strOUTPATRECIPEID"></param>
        /// <param name="RECORDDATE"></param>
        /// <param name="strPATIENTID"></param>
        /// <returns></returns>
        public string m_getOutpatientNO(string strOUTPATRECIPEID, string RECORDDATE, string strPATIENTID)
        {
            string strRes = "";

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            strRes = objSvc.m_getOutpatientNO(strOUTPATRECIPEID, RECORDDATE, strPATIENTID);
            return strRes;
        }
        #endregion

        #region 保存出库单修改库存
        /// <summary>
        /// 保存出库单修改库存
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="SaveRow"></param>
        /// <param name="SaveTableDe"></param>
        /// <returns>1-正常，2-还没有设置药房出库类型，3-没有找到相应的药品</returns>
        public long m_mthSaveData(DataRow SaveRow, DataTable SaveTableDe)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_mthSaveData(objPrincipal, SaveRow, SaveTableDe);
            return lngRes;
        }
        #endregion

        #region 查找收费项目的源ID
        /// <summary>
        /// 查找收费项目的源ID
        /// </summary>
        /// <param name="NewID"></param>
        /// <param name="oldID"></param>
        /// <returns></returns>
        public long m_lngGetID(string NewID,
            out string oldID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetID(objPrincipal, NewID, out oldID);
            return lngRes;
        }
        #endregion

        #region 通过ID更改发药的处方记录的状态
        /// <summary>
        /// 通过ID更改发药的处方记录的状态
        /// </summary>
        /// <param name="winID">窗口ID</param>
        /// <param name="m_intSID">序列号ID</param>
        /// <returns></returns>
        public long m_lngUpdateMedCiPeByID(string winID, int m_intSID)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedCiPeByID(objPrincipal, winID, m_intSID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 通过窗口ID、处方ID、处方类型取当前需要发药的处方记录
        /// <summary>
        /// 通过窗口ID、处方ID、处方类型取当前需要发药的处方记录
        /// </summary>
        /// <param name="p_strOPRecID">处方ID</param>
        /// <param name="p_intType">处方类型</param>
        /// <param name="p_objResultArr">输出数据</param>
        ///  <param name="flag">标志位,1-发药，配药 2-门诊审核处方</param>
        /// <returns></returns>
        public long m_lngGetOPRecipeListByWinAndOpRecAndType(
            string m_intSid, string p_intType, out DataTable p_objResultArr, int flag)
        {
            long lngRes = 0;
            p_objResultArr = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPRecipeListByWinAndOpRecAndType(objPrincipal, int.Parse(m_intSid),
                p_intType, out p_objResultArr, flag);
            return lngRes;
        }
        #endregion

        #region 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细及病人信息
        /// <summary>
        /// 通过窗口ID、处方ID、处方类型取当前需要发药的处方明细及病人信息
        /// </summary>
        /// <param name="p_strOPRecID">处方ID</param>
        /// <param name="p_strWinID">窗口ID</param>
        /// <param name="p_dtOutPatrecIp">返回处方信息</param>
        /// <param name="p_dtItemDe">返回处方明细</param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public long m_lngGetPrintItem(int m_intSID, string p_strWinID, out DataTable p_dtOutPatrecIp, out DataTable p_dtItemDe, int flag)
        {
            long lngRes = 0;
            p_dtOutPatrecIp = null;
            p_dtItemDe = null;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetPrintItem(objPrincipal, m_intSID,
                p_strWinID, out p_dtOutPatrecIp, out p_dtItemDe, flag);
            return lngRes;
        }
        #endregion


        #region 通过ID更改发药的处方记录的状态(是否自动打印过)
        /// <summary>
        /// 通过ID更改发药的处方记录的状态(是否自动打印过)
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="arrList"></param>
        /// <returns></returns>
        public long m_lngUpdateMedRecipeListByID(string winID, System.Collections.ArrayList arrList, int m_intFlag)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateMedRecipeListByID(objPrincipal, winID, arrList, m_intFlag);
            return lngRes;
        }
        #endregion

        #region 通过ID更改发药的处方记录的状态(是否自动打印注射单)
        /// <summary>
        ///  通过ID更改发药的处方记录的状态(是否自动打印注射单)
        /// </summary>
        /// <param name="winID"></param>
        /// <param name="arrList"></param>
        /// <returns></returns>
        public long m_lngUpdateRecipeSendTableByID(string winID, System.Collections.ArrayList arrList)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngUpdateRecipeSendTableByID(objPrincipal, winID, arrList);
            return lngRes;
        }
        #endregion

        #region 门诊药品发放（更改库存）
        /// <summary>
        /// 门诊药品发放（更改库存）
        /// </summary>
        /// <param name="p_strMedStoreID">药房</param>
        /// <param name="p_strWinID">窗口</param>
        /// <param name="p_strOPRecID">处方号</param>
        /// <param name="p_intType">处方类型，1：西药，2：中药</param>
        /// <param name="p_intFlag">标志，1：成功，0：失败，-1：异常</param>
        /// <returns></returns>
        public long m_lngOPRecipeMedProvide(string p_strMedStoreID, string p_strWinID,
            string p_strOPRecID, int p_intType, out int p_intFlag)
        {
            long lngRes = 0;
            p_intFlag = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngOPRecipeMedProvide(objPrincipal, p_strMedStoreID, p_strWinID, p_strOPRecID,
                p_intType, out p_intFlag);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据处方ID查找员工名称及工号
        /// <summary>
        /// 根据处方ID查找员工名称及工号
        /// </summary>
        /// <param name="p_patrecipeid">处方ID</param>
        /// <param name="p_strID">输出员工ID</param>
        /// <param name="p_strName">输出员工名</param>
        public long m_lngFinaEmp(string p_patrecipeid, out string p_strID, out string p_strName)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngFinaEmp(objPrincipal, p_patrecipeid, out p_strID, out p_strName);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获得处方的其它收费明细
        /// <summary>
        /// 获得处方的其它收费明细
        /// </summary>
        /// <param name="p_strOUTPATRECIPEID"></param>
        /// <param name="btpatientcnkre"></param>
        /// <param name="btpatientest"></param>
        /// <param name="btpatienOpsre"></param>
        /// <param name="btpatienothre"></param>
        /// <returns></returns>
        public long m_lngGetAll(string p_strOUTPATRECIPEID, out DataTable btpatientcnkre, out DataTable btpatientest, out DataTable btpatienOpsre, out DataTable btpatienothre)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_lngGetAll(objPrincipal, p_strOUTPATRECIPEID, out btpatientcnkre, out btpatientest, out btpatienOpsre, out btpatienothre);
            return lngRes;
        }
        #endregion

        #region 获取所有的项目数据
        /// <summary>
        /// 获取所有的项目数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindMedicine(out DataTable dt)
        {
            long lngRes = 0;

            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            lngRes = objSvc.m_mthFindMedicine(objPrincipal, out dt);
            return lngRes;
        }
        #endregion

        #region 把发药单据设成无效单据
        /// <summary>
        /// 把发药单据设成无效单据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public long m_lngSetNullityData(string strID)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngSetNullityData(objPrincipal, strID);
            return lngRes;
        }
        #endregion

        #region 判断发票是否有效
        /// <summary>
        /// 判断发票是否有效
        /// </summary>
        /// <param name="INVOICENO"></param>
        /// <returns></returns>
        public bool m_blCheckOut(string INVOICENO)
        {
            bool lngRes;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_blCheckOut(INVOICENO);
            return lngRes;
        }
        #endregion

        #region 获取特殊药房的所有指向的窗口
        /// <summary>
        /// 获取特殊药房的所有指向的窗口
        /// </summary>
        public long m_longDutydt(string strStorageID, out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_longDutydt(strStorageID, out dt);
            return lngRes;
        }
        #endregion

        #region 获取部门信息
        /// <summary>
        /// 获取部门信息
        /// </summary>
        public long m_lngGetOPDeptList(out DataTable dt)
        {
            long lngRes = 0;
            dt = new DataTable();
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDeptList(null, out dt);
            return lngRes;
        }
        #endregion

        #region 根据单据类别获取用法列表：0 注射单 1 输液巡视卡 2 贴瓶单 3 治疗单 4 手术单 5 输血单 6 配药 7 发药
        /// <summary>
        /// 根据单据类别获取用法列表：0 注射单 1 输液巡视卡 2 贴瓶单 3 治疗单 4 手术单 5 输血单 6 配药 7 发药
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetUsagebyordertypeid(string typeid, out DataTable dtRecord)
        {
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            long res = objSvc.m_lngGetUsagebyordertypeid(typeid, out dtRecord);
            return res;
        }
        #endregion


        #region 根据用户工号密码获取员工名称
        /// <summary>
        /// 根据用户工号密码获取员工名称
        /// </summary>
        /// <param name="EmpNO"></param>
        /// <param name="EmpPw"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public long m_lngGetEmpName(string EmpNO, string EmpPw, out string EmpName, out string empID)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetEmpName(EmpNO, EmpPw, out EmpName, out empID);
            return lngRes;
        }
        #endregion

        #region 取时间
        /// <summary>
        /// 取时间
        /// </summary>
        /// <param name="p_datatime"></param>
        /// <returns></returns>
        public long m_lngGetServerDate(out DateTime p_datatime)
        {
            p_datatime = DateTime.Now;
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetServerDate(out p_datatime);
            return lngRes;
        }
        #endregion

        #region 取窗口信息
        /// <summary>
        /// 取窗口信息
        /// </summary>
        /// <param name="p_datatime"></param>
        /// <returns></returns>
        public long m_lngGetWindowInfo(out DataTable dtbResult, string p_strWINDOWID_CHR, string p_strMEDSTOREID_CHR)
        {
            dtbResult = null;
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetWindowInfo(out dtbResult, p_strWINDOWID_CHR, p_strMEDSTOREID_CHR);
            return lngRes;
        }
        #endregion

        #region GetSendMedInfo
        /// <summary>
        /// GetSendMedInfo
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public DataTable GetSendMedInfo(string recipeId)
        {
            clsMedStoreSvc svc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            return svc.GetSendMedInfo(recipeId);
        }
        #endregion

        #region 判断是否已发药
        /// <summary>
        /// 判断是否已发药
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool IsSendMed(string sid)
        {
            clsMedStoreSvc svc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            return svc.IsSendMed(sid);
        }
        #endregion

        #region 根据部门ID和科室自编码判断是否存在该员工
        /// <summary>
        /// 根据部门ID和科室自编码判断是否存在该员工
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        public long m_lngJudgeEmpByIDAndCode(string m_strDeptID, string m_strDeptSelfCode, out string m_strEMPID, out string m_strEMPName)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngJudgeEmpByIDAndCode(objPrincipal, m_strDeptID, m_strDeptSelfCode, out m_strEMPID, out m_strEMPName);
            return lngRes;

        }
        #endregion
        #region 根据员工工号判断是否存在该员工
        /// <summary>
        /// 根据员工工号判断是否存在该员工
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strDeptSelfCode"></param>
        /// <param name="m_strEMPID"></param>
        /// <param name="m_strEMPName"></param>
        /// <returns></returns>
        public long m_lngJudgeEmpByEmpNo(string m_strEMPNO, out string m_strEMPID, out string m_strEMPName)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngJudgeEmpByEmpNo(objPrincipal, m_strEMPNO, out m_strEMPID, out m_strEMPName);
            return lngRes;

        }
        #endregion
        #region  获取门诊治疗单对应的用法ID
        /// <summary>
        /// 获取门诊治疗单对应的用法ID
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetUsageIDByOrderID(string m_strOrderID, out DataTable m_objTable)
        {

            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetUsageIDByOrderID(objPrincipal, m_strOrderID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region 获取门诊医生常用药信息
        /// <summary>
        ///  获取门诊医生常用药信息
        /// </summary>
        /// <param name="m_strDepID"></param>
        /// <param name="m_strMedType"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetDoctorUseMedInfo(string m_strDepID, string m_strDoctorID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDoctorUseMedInfo(objPrincipal, m_strDepID, m_strDoctorID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        public long m_lngGetDoctorUseMedInfoByQuatity(string m_strDepID, string m_strDoctorID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDoctorUseMedInfoByQuatity(objPrincipal, m_strDepID, m_strDoctorID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        #endregion
        #region 获取科室信息
        /// <summary>
        /// 获取科室信息
        /// </summary>
        /// <param name="objDep"></param>
        /// <returns></returns>
        public long m_lngGetOPDeptInfo(out DataTable objDep)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetOPDeptInfo(objPrincipal, out objDep);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// 获取药品类型信息
        /// </summary>
        /// <param name="m_strMedType"></param>
        /// <param name="p_dtbData"></param>
        /// <returns></returns>
        public long m_lngGetMedTypeInfo(string m_strMedType, out DataTable p_dtbData)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetMedTypeInfo(objPrincipal, m_strMedType, out p_dtbData);
            return lngRes;

        }
        #region  获取科室药品费用比例
        /// <summary>
        /// 获取科室药品费用比例
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetDeptMedFeePercentInfo(string m_strDeptID, string m_strCataID, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.m_lngGetDeptMedFeePercentInfo(objPrincipal, m_strDeptID, m_strCataID, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
        }
        #endregion

        #region  获取单项药品消耗信息
        /// <summary>
        /// 获取单项药品消耗信息
        /// </summary>
        /// <param name="m_strDepID"></param>
        /// <param name="m_strItemID"></param>
        /// <param name="m_strMedType"></param>
        /// <param name="m_strBeginTime"></param>
        /// <param name="m_strEndTime"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long GetDoctorUseMedByItemId(string m_strDepID, string m_strItemID, string m_strMedType, string m_strBeginTime, string m_strEndTime, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc objSvc =
                (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = objSvc.GetDoctorUseMedByItemId(objPrincipal, m_strDepID, m_strItemID, m_strMedType, m_strBeginTime, m_strEndTime, out m_objTable);
            return lngRes;
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
            clsOPMedStoreSvc objSvc =
                       (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));

            long l = objSvc.m_lngFindChargeItem(FindStr, PatType, out dt);
            objSvc.Dispose();

            return l;
        }

        #endregion
        /// <summary>
        /// 判断是否有足够的库存可以进行扣减
        /// </summary>
        /// <param name="m_strDrugStoreid"></param>
        /// <param name="m_dtPutMedDetail"></param>
        /// <param name="m_strMsg"></param>
        /// <param name="m_htReturn"></param>
        /// <returns></returns>
        public bool m_lngJudgeHasEnoughStorage(string m_strDrugStoreid, DataTable m_dtPutMedDetail, out string m_strMsg, out Hashtable m_htReturn)
        {
            bool blnHasEnough = false;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));

            blnHasEnough = objSvc.m_lngJudgeHasEnoughStorage(m_strDrugStoreid, m_dtPutMedDetail, out m_strMsg, out m_htReturn);
            return blnHasEnough;

        }
        #region 根据处方号查找发送处方序列ID
        /// <summary>
        /// 根据处方号查找发送处方序列ID
        /// </summary>
        /// <param name="m_lngSid"></param>
        /// <param name="m_strStatus"></param>
        /// <returns></returns>
        public long m_lngGetRecipeSendStatusBySid(long m_lngSid, out string m_strStatus)
        {
            long lngRes = 0;
            clsMedStoreSvc m_objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = m_objSvc.m_lngGetRecipeSendStatusBySid(objPrincipal, m_lngSid, out m_strStatus);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取未配处方信息
        /// </summary>
        /// <param name="strMedStoreid"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetQueryUnDosageRecipeInfo(string strMedStoreid, string strBeginDate, string strEndDate, out DataTable m_objTable)
        {
            m_objTable = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetQueryUnDosageRecipeInfo(objPrincipal, strMedStoreid, strBeginDate, strEndDate, out m_objTable);
            return lngRes;

        }
        #region 根据处方id和药房id获取为配药处方明细
        /// <summary>
        /// 根据处方id和药房id获取为配药处方明细
        /// </summary>
        /// <param name="m_strOPRecipeid"></param>
        /// <param name="m_strMedStoreid"></param>
        /// <param name="p_dtItemDe"></param>
        /// <returns></returns>
        public long m_lngGetUnDosageRecipeDetailByid(string m_strOPRecipeid, string m_strMedStoreid, out DataTable p_dtItemDe)
        {
            p_dtItemDe = null;
            long lngRes = 0;
            clsHisMedStoreSelect objSvc =
                (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            lngRes = objSvc.m_lngGetUnDosageRecipeDetailByid(objPrincipal, m_strOPRecipeid, m_strMedStoreid, out p_dtItemDe);
            return lngRes;
        }
        #endregion

        #region 根据药品ID查询出相关的药品信息
        /// <summary>
        /// 根据药品ID查询出相关的药品信息
        /// </summary>
        /// <param name="p_strMedID"></param>
        /// <param name="p_strDosage"></param>
        /// <param name="p_strIpUnit"></param>
        /// <param name="p_strPrepType"></param>
        /// <returns></returns>
        public long m_lngGetMedDetailByMedID(string p_strMedID, out string p_strDosage, out string p_strIpUnit, out string p_strPrepType)
        {
            long lngRes = 0;
            p_strDosage = "";
            p_strIpUnit = "";
            p_strPrepType = "";

            #region 中间件操作
            clsHisMedStoreSelect objServ = null;
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                lngRes = objServ.m_lngGetMedDetailByMedID(objPrincipal, p_strMedID, out p_strDosage, out p_strIpUnit, out p_strPrepType);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
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

        #region 获取系统时间
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime m_datGetServerDate()
        {
            clsHisMedStoreSelect objSvc = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
            return objSvc.m_datGetServerDate();
        }
        #endregion

        #region 根据身份证号或者社保号查询诊疗卡号
        /// <summary>
        /// 根据身份证号或者社保号查询诊疗卡号
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="p_strTable"></param>
        /// <returns></returns>
        public string m_strGetCardID(string p_strPatientID, string p_strTable)
        {
            clsHisMedStoreSelect objServ = null;
            string strCardID = "";
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                strCardID = objServ.m_strGetCardID(p_strPatientID, p_strTable);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
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
            return strCardID;
        }
        #endregion

        #region 查询药品剂型
        /// <summary>
        /// 查询药品剂型
        /// </summary>
        /// <param name="lstMedId"></param>
        /// <returns></returns>
        public void GetMedPrepType(List<string> lstMedId, out Dictionary<string, string> dicPrepType, out Dictionary<string, string> dicIpUnit, out Dictionary<string, string> dicMedBagUnit)
        {
            clsHisMedStoreSelect svc = null;
            dicPrepType = new Dictionary<string, string>();
            dicIpUnit = new Dictionary<string, string>();
            dicMedBagUnit = new Dictionary<string, string>();
            try
            {
                svc = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                svc.GetMedPrepType(lstMedId, out dicPrepType, out dicIpUnit, out dicMedBagUnit);
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + ex.Message);
            }
            finally
            {
                if (svc != null)
                {
                    svc.Dispose();
                    svc = null;
                }
            }
        }
        #endregion

        #region 查用法
        /// <summary>
        /// 查用法
        /// </summary>
        /// <param name="strMedUsageID"></param>
        /// <param name="dtKFUsageID"></param>
        public void GetMedUsageID(string strMedUsageID, ref DataTable dtKFUsageID)
        {
            clsHisMedStoreSelect objServ = null;
            try
            {
                objServ = (clsHisMedStoreSelect)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHisMedStoreSelect));
                objServ.m_lngGetMedUsageID(strMedUsageID, ref dtKFUsageID);
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
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
        }

        #endregion

        #region 通过发票号查询患者信息
        /// <summary>
        /// 通过发票号查询患者信息
        /// </summary>
        /// <param name="invoNo"></param>
        /// <returns></returns>
        public DataTable GetPatInfoByInvo(string invoNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc));
            return svc.GetPatInfoByInvo(invoNo);
        }
        #endregion

        #region 微信检查是否绑卡
        /// <summary>
        /// 微信检查是否绑卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsWechatBanding(string cardNo)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.IsWechatBanding(cardNo);
            }
        }
        #endregion

        #region 通过处方ID获取诊疗卡号
        /// <summary>
        /// 通过处方ID获取诊疗卡号
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public string GetCardNoByRecipeId(string recipeId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.GetCardNoByRecipeId(recipeId);
            }
        }
        #endregion

        #region 外送代煎中药方法

        #region 查询外送代煎中药数据源列表
        /// <summary>
        /// 查询外送代煎中药数据源列表
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="opIp">1 门诊; 2 住院</param>
        /// <returns></returns>
        public DataTable QueryProxyBoilMed(string startDate, string endDate, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.QueryProxyBoilMed(startDate, endDate, opIp);
            }
        }
        #endregion

        #region 查询外送代煎中药明细
        /// <summary>
        /// 查询外送代煎中药明细
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="recipeNo"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        public DataTable QueryProxyBoilMedDet(string recipeId, string recipeNo, string recipeDate, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.QueryProxyBoilMedDet(recipeId, recipeNo, recipeDate, opIp);
            }
        }
        #endregion

        #region 检测是否已发送
        /// <summary>
        /// 检测是否已发送
        /// </summary>
        /// <param name="putMedIds"></param>
        /// <returns></returns>
        public bool CheckIsSend(string putMedIds, bool isEqual)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.CheckIsSend(putMedIds, isEqual);
            }
        }
        #endregion

        #region 外送代煎药转门诊中药房
        /// <summary>
        /// 外送代煎药转门诊中药房
        /// </summary>
        /// <param name="recipeIds"></param>
        /// <param name="putMedIds"></param>
        /// <param name="operId"></param>
        /// <param name="opIp"></param>
        /// <returns></returns>
        public int ConvertMedStore(string recipeIds, string putMedIds, string operId, int opIp)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc svc = (com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsMedStoreSvc)))
            {
                return svc.ConvertMedStore(recipeIds, putMedIds, operId, opIp);
            }
        }
        #endregion

        #endregion

    }
}
