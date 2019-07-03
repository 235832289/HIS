using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsDcl_DoctorWorkstation 的摘要说明。
    /// </summary>
    public class clsDcl_DoctorWorkstation : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_DoctorWorkstation()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 查找收费项目
        public long m_mthFindWMedicineByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID, string p_strRealMedStoreID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindWMedicineByID(objPrincipal, strType, ID.ToUpper(), strPatientTypeID, out dt, strEmployID, p_strRealMedStoreID);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindCMedicineByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID, string m_strRealMedStoreID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindCMedicineByID(objPrincipal, strType, ID, strPatientTypeID, out dt, strEmployID, m_strRealMedStoreID);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindTestChargeByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindTestChargeByID(objPrincipal, strType, ID, strPatientTypeID, out dt, strEmployID);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindExamineChargeByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindExamineChargeByID(objPrincipal, strType, ID, strPatientTypeID, out dt, strEmployID);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindOPSChargeByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindOPSChargeByID(objPrincipal, strType, ID, strPatientTypeID, out dt, strEmployID);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindOPSChargeByID(string strType, string ID, string strPatientTypeID, string strEmployID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindOPSChargeByID(strType, ID, strPatientTypeID, strEmployID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindOPSChargeByID(string ID, string strPatientTypeID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindOPSChargeByID(objPrincipal, ID, strPatientTypeID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindOtherChargeByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindOtherChargeByID(objPrincipal, strType, ID, strPatientTypeID, out dt, strEmployID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查找频率
        /// <summary>
        /// 查找频率
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindFrequency(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindFrequency(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查找用法
        /// <summary>
        /// 查找用法
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindUsage(string ID, int scope, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindUsage(objPrincipal, ID, scope, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="OPR_VO"></param>
        /// <param name="CH_VO"></param>
        /// <param name="DR_VO"></param>
        /// <param name="PWM_VO"></param>
        /// <param name="CM_VO"></param>
        /// <param name="CHK_VO"></param>
        /// <param name="TR_VO"></param>
        /// <param name="OP_VO"></param>
        /// <param name="Other_VO"></param>
        /// <param name="strRecipeID"></param>
        /// <param name="strCaseHisID"></param>
        /// <param name="IsModify"></param>
        /// <param name="blnCashStatus"></param>
        /// <param name="blnSaveCash"></param>
        /// <returns></returns>
        public long m_mthSaveAllData(clsOutPatientRecipe_VO OPR_VO, clsOutpatientCaseHis_VO CH_VO, clsOutpatientDiagRec_VO DR_VO, clsOutpatientPWMRecipeDe_VO[] PWM_VO, clsOutpatientCMRecipeDe_VO[] CM_VO,
            clsOutpatientCHKRecipeDe_VO[] CHK_VO, clsOutpatientTestRecipeDe_VO[] TR_VO,
            clsOutpatientOPSRecipeDe_VO[] OP_VO, clsOutpatientOtherRecipeDe_VO[] Other_VO, clsOutpatientOrderRecipeDe_VO[] Order_VO,
            out string strRecipeID, out string strCaseHisID, bool IsModify, bool blnCashStatus, bool blnSaveCash)
        {
            strRecipeID = "";
            strCaseHisID = "";
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
                lngRes = objSvc.m_mthSaveAllData(OPR_VO, CH_VO, DR_VO, PWM_VO, CM_VO, CHK_VO, TR_VO, OP_VO, Other_VO, Order_VO, out strRecipeID, out strCaseHisID, IsModify, blnCashStatus, blnSaveCash, objPrincipal);
                objSvc.Dispose();
            }
            catch
            { }
            return lngRes;
        }
        #endregion

        #region 保存病历
        /// <summary>
        /// 保存病历
        /// </summary>
        /// <param name="CH_VO"></param>
        /// <param name="strCaseHisID"></param>
        /// <param name="IsModify"></param>
        /// <returns></returns>
        public long m_lngSaveCaseHis(clsOutpatientCaseHis_VO CH_VO, bool IsModify, ref string strCashID)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
                lngRes = objSvc.m_mthSaveCaseHistory(objPrincipal, CH_VO, IsModify, ref strCashID);
                objSvc.Dispose();
            }
            catch
            { }
            return lngRes;
        }
        #endregion

        #region 删除处方明细
        /// <summary>
        /// 删除处方明细
        /// </summary>
        /// <param name="ID"></param>
        public void m_mthDeleteRecipeDetail(string ID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            objSvc.m_mthDeleteRecipeDetail(objPrincipal, ID);
            objSvc.Dispose();
        }

        #endregion

        #region 显示处方号
        /// <summary>
        /// 显示处方号
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dt"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public long m_mthGetRepiceNo(string type, out DataTable dt, string ID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthGetRepiceNo(objPrincipal, type, out dt, ID);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion

        #region 根据处方号查找明细
        /// <summary>
        /// 根据处方号查找明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public long m_mthFindDiagnoses(string ID, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindDiagnoses(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 病历
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public long m_mthFindCaseHistory(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindCaseHistory(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 当天病历
        /// </summary>
        /// <param name="strPatientID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetMaxCaseHistory(string strPatientID, string strDoctor, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindMaxCaseHistory(objPrincipal, strPatientID, strDoctor, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail1(string ID, out DataTable dt, bool flag)//西药
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail1(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail2(string ID, out DataTable dt, bool flag)//中药
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail2(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail3(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail3(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail3ByOrder(string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail3ByOrder(objPrincipal, RecID, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail4(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail4(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail4ByOrder(string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail4ByOrder(objPrincipal, RecID, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail5(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail5(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail5ByOrder(string RecID, string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail5ByOrder(objPrincipal, RecID, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindRecipeDetail6(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetail6(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }

        public long m_mthFindRecipeDetailOrder(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindRecipeDetailOrder(ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }

        #endregion

        #region 收费根据处方号查询处方明细
        public long m_lngGetRecipeDetail(string p_strRecipeNo, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngGetRecipeDetail(p_strRecipeNo, out dtResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据用法查找附加的收费项目
        /// <summary>
        /// 根据用法查找附加的收费项目
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetChargeItemByUsageID(string strID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthGetChargeItemByUsageID(objPrincipal, strID, out dt);
            objSvc.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 根据用法查找附加的收费项目
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetChargeItemByUsageID(string strID, string p_strPayTypeID, out DataTable dt)
        {
            dt = null;
            if (p_strPayTypeID == string.Empty)
            {
                p_strPayTypeID = "0001";
            }
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthGetChargeItemByUsageID(strID, p_strPayTypeID, out dt);
            objSvc.Dispose();
            return lngRes;
        }

        #endregion

        #region 查找模板列表
        /// <summary>
        /// 查找模板列表
        /// </summary>
        /// <param name="ID">查询关键字</param>
        public long m_mthFindAccordRecipe(string ID, string strType, string strCreatID, out DataTable dt, int flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindAccordRecipe(objPrincipal, ID, strType, strCreatID, out dt, flag);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion

        #region 根据申请单的项目源ID查找收费项目
        /// <summary>
        /// 根据申请单的项目源ID查找收费项目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindChargeItemByApplyBillID(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindChargeItemByApplyBillID(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据项目ID查出禁忌药品
        /// <summary>
        /// 根据项目ID查出禁忌药品
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindTabuByID(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindTabuByID(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion

        #region 获取药品详细信息
        /// <summary>
        /// 获取药品详细信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strText"></param>
        public void m_mthGetMedicineInfo(string ID, out string strText, out string strRemark)
        {
            strText = "";
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            objSvc.m_mthGetMedicineInfo(objPrincipal, ID, out strText, out strRemark);
            objSvc.Dispose();
        }
        #endregion

        #region 获取候诊挂号
        /// <summary>
        /// 获取候诊挂号
        /// </summary>
        /// <param name="strDoctor"></param>
        /// <param name="strDep"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetWaitReg(string strDoctor, string strDep, out DataTable dt)
        {

            dt = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngGetGeg(objPrincipal, strDoctor, strDep, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 转入就诊
        /// <summary>
        /// 转入就诊
        /// </summary>
        /// <param name="objVo"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public long m_lngAddNewTake(clsTakeDiagrec objVo, out string ID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngAddNewTakeDiagrec(objPrincipal, out ID, objVo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 作废处方
        /// <summary>
        /// 作废处方
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="p_status"></param>
        /// <returns></returns>
        public long m_mthDelRecipe(string ID, string p_status)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthDelRecipe(objPrincipal, ID, p_status);
            objSvc.Dispose();
            return lngRes;

        }
        #endregion

        #region 获取就诊挂号
        /// <summary>
        /// 获取就诊挂号
        /// </summary>
        /// <param name="strDoctor"></param>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetTakeGeg(string strDoctor, string strBeginDate, string strEndDate, out DataTable dt)
        {
            dt = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngGetTakeGeg(objPrincipal, strDoctor, strBeginDate, strEndDate, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 结束就诊
        /// <summary>
        /// 结束就诊
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strWaitID"></param>
        /// <returns></returns>
        public long m_lngEndTakeReg(string strRegID, string strWaitID)
        {

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngEndTakeReg(objPrincipal, strRegID, strWaitID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 继续就诊
        /// <summary>
        /// 继续就诊
        /// </summary>
        /// <param name="strWaitID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public long m_mthContinueTake(string strWaitID, int status)
        {

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthContinue(strWaitID, status, "TAKEDIAGRECID_CHR");
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 检查当前挂号状态
        /// <summary>
        ///  检查当前挂号状态
        /// </summary>
        /// <param name="RegID"></param>
        /// <returns></returns>
        public long m_lngGetCurRegF(string RegID)
        {
            long lngFlag = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            lngFlag = objSvc.m_lngGetCurRegF(objPrincipal, RegID);
            objSvc.Dispose();
            return lngFlag;
        }
        #endregion

        #region 结束就诊
        /// <summary>
        /// 结束就诊
        /// </summary>
        /// <param name="strRegID"></param>
        /// <param name="strWaitID"></param>
        /// <returns></returns>
        public long m_lngReturnWait(string strRegID, string strWaitID)
        {

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngReturnWait(objPrincipal, strRegID, strWaitID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取病人看病次数
        /// <summary>
        /// 获取病人看病次数
        /// </summary>
        /// <param name="strPatientID"></param>
        /// <returns></returns>
        public int m_mthGetPatientSeeDocTimes(string strPatientID)
        {
            int ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetPatientSeeDocTimes(strPatientID);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 获取注射治疗ID
        /// <summary>
        /// 获取注射治疗ID
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetinjectInfo(out DataTable dt)
        {
            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetinjectInfo(out dt);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 获取系统参数属性
        /// <summary>
        /// 获取系统参数属性
        /// </summary>
        /// <param name="p_flag"></param>
        /// <returns></returns>
        public bool m_mthIsCanDo(string p_flag)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            return objSvc.m_mthIsCanDo(p_flag) == 1;

        }
        #endregion

        #region 查找对应表信息
        /// <summary>
        /// 查找对应表信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthRelationInfo(out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthRelationInfo(out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查找处方类型信息
        /// <summary>
        /// 查找处方类型信息
        /// </summary>
        /// <param name="objRTVO"></param>
        /// <param name="strEx"></param>
        /// <returns></returns>
        public long m_mthGetRecipeTypeInfo(out clsRecipeType_VO[] objRTVO, string strEx)
        {
            objRTVO = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthGetRecipeTypeInfo(this.objPrincipal, out objRTVO, strEx);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查出在病历不显示的项目分类
        /// <summary>
        /// 查出在病历不显示的项目分类
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strID"></param>
        /// <returns></returns>
        public long m_mthGetUnDisplayCat(out DataTable dt, string strID)
        {

            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetUnDisplayCat(out dt, strID);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 根据项目ID查找申请分类
        /// <summary>
        /// 根据项目ID查找申请分类
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetApplyTypeByID(string strID, out DataTable dt)
        {

            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetApplyTypeByID(strID, out dt);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 根据项目ID查找申请分类
        /// <summary>
        /// 根据项目ID查找申请分类
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public string m_mthGetResourceIDByItemID(string strID)
        {

            string ret = "";
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetResourceIDByItemID(strID);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="objArr"></param>
        /// <param name="objOPSarr"></param>
        /// <returns></returns>
        public long m_mthPutIn(string ID, ArrayList objArr, ArrayList objOPSarr)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthPutIn(ID, objArr, objOPSarr);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据药房ID、药品读取当前理论库存（茶山暂时用不用理论库存，改为检查实际库存）
        /// <summary>
        /// 根据药房ID、药品读取当前理论库存（茶山暂时用不用理论库存，改为检查实际库存）
        /// </summary>
        /// <param name="strStoreID">仓库(药库)ID</param>
        /// <param name="strItemID">收费项目ID</param>        
        /// <returns></returns>        
        public long m_lngGetTheoryAmountByMedID(string strStoreID, string strItemID, string strDeductType, out DataTable dtInventory)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc));

            long l = objSvc.m_lngGetTheoryAmountByMedID(strStoreID, strItemID, strDeductType, out dtInventory);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据收费项目ID查询药品ID
        /// <summary>
        /// 根据收费项目ID查询药品ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string m_strGetMedicineIDByChargeItemID(string ID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc));

            string s = objSvc.m_strGetMedicineIDByChargeItemID(ID);
            objSvc.Dispose();

            return s;
        }
        #endregion

        #region 获取药房设置信息
        /// <summary>
        /// 获取药房设置信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetMedStore(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc));

            long l = objSvc.m_lngGetMedStore(out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取药房分类
        /// <summary>
        /// 获取药房分类
        /// </summary>
        /// <param name="strChrgItem"></param>
        /// <returns></returns>
        public string m_strGetOutSendMedStoretype(string strChrgItem)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            string strMedStoretype = objSvc.m_strGetOutSendMedStoretype(strChrgItem);
            //objSvc.Dispose();
            return strMedStoretype;
        }
        #endregion

        #region 判断下班后发药： 普通药房转急诊药房
        /// <summary>
        /// 判断下班后发药： 普通药房转急诊药房
        /// </summary>
        /// <param name="strOldStorageID"></param>
        /// <param name="strNewStorageID"></param>
        /// <returns></returns>
        public long m_lngGetWorkStorage(string strOldStorageID, out string strNewStorageID)
        {
            com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol));

            long lngRes = objSvc.m_lngGetWorkStorage(objPrincipal, strOldStorageID, out strNewStorageID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据病病号获取疾病信息
        /// <summary>
        /// 根据病病号获取疾病信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="objICD10"></param>
        /// <returns></returns>
        public long m_mthIllnessInfo(string ID, out clsICD10_VO[] objICD10)
        {
            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthIllnessInfo(this.objPrincipal, ID, out objICD10);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 查找样本类型
        /// <summary>
        /// 查找样本类型
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetLisSampletyType(string ID, string strType, out DataTable dt)
        {

            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_lngGetLisSampletyType(objPrincipal, ID, strType, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查找样本类型
        /// <summary>
        /// 查找样本类型
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <param name="strex"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthLoadCheckPart(string ID, string strex, out DataTable dt)
        {

            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthLoadCheckPart(out dt, ID, strex);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthLoadCheckPartOrder(string ID, string strex, out DataTable dt)
        {

            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthLoadCheckPartOrder(out dt, ID, strex);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 新增住院申请
        /// <summary>
        /// 新增住院申请
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        public long m_mthAddInHospitalApply(out string strID, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            strID = "";
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objS =
               (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objS.m_lngAddNewBihRegister(null, out strID, objBIHVO);
            }
            catch
            {
                return 0;
            }
            objS.Dispose();
            return lngRes;
        }
        #endregion

        #region 更改住院申请
        /// <summary>
        /// 更改住院申请
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        public long m_mthUpdateInHospitalApply(string strID, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objS =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objS.m_lngModifyBihRegisterInfoByVo(null, strID, objBIHVO);
            }
            catch
            {
                return 0;
            }
            objS.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据病人ID 查出住院号和病人病人住院次数
        /// <summary>
        /// 根据病人ID 查出住院号和病人病人住院次数
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindInhospitalTimesByID(string strID, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objS =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            lngRes = objS.m_mthFindInhospitalTimesByID(strID, out dt);
            objS.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据病人ID查找用药情况
        /// <summary>
        /// 根据病人ID查找用药情况
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strID"></param>
        /// <param name="strEx"></param>
        /// <returns></returns>
        public long m_mthGetUsingMedicineByPatientID(out DataTable dt, string strID, string strEx)
        {
            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetUsingMedicineByPatientID(out dt, strID, strEx);
            objSvc.Dispose();
            return ret;

        }
        #endregion

        #region 获取调价信息
        /// <summary>
        /// 获取调价信息
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <param name="strEx"></param>
        /// <returns></returns>
        public long m_mthGetChangePriceInfo(string strID, out DataTable dt, string strEx)
        {
            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetChangePriceInfo(strID, out dt, strEx);
            objSvc.Dispose();
            return ret;

        }
        #endregion

        #region 获取病区信息
        /// <summary>
        /// 获取病区信息	
        /// </summary>
        /// <param name="p_strFilter"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        public long m_lngGetAreaInfo(string p_strFilter, out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = new clsT_BSE_DEPTDESC_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetAreaInfo(objPrincipal, p_strFilter, out p_objRecordArr);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取主治医师信息
        /// <summary>
        /// 获取主治医师信息	
        /// </summary>
        /// <param name="p_strFilter"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        public long m_lngGetMainDoctor(string p_strFilter, out com.digitalwave.iCare.ValueObject.clsEmployee_VO[] p_objRecordArr)
        {
            long lngRes = 0;
            p_objRecordArr = new clsEmployee_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC));
            try
            {
                lngRes = objSvc.m_lngGetMainDoctor(objPrincipal, p_strFilter, out p_objRecordArr);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取住院号
        /// <summary>
        /// 获取住院号	
        /// </summary>
        /// <param name="p_strFilter"></param>
        /// <param name="p_objRecordArr"></param>
        /// <returns></returns>
        public long m_lngGetInpatientID(out string p_strInPatientID)
        {
            long lngRes = 0;
            p_strInPatientID = "";
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetInpatientID(objPrincipal, out p_strInPatientID);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据病人ID获取病人在院信息,供门诊填写入院登记卡时作判断
        /// <summary>
        /// 根据病人ID获取病人在院信息,供门诊填写入院登记卡时作判断 
        /// </summary>
        /// <param name="p_strInPatientID">病人ID</param>
        /// <param name="p_intFlag">标志:0=在院和门诊转入的病人信息,供门诊入院登记卡使用;1=在院和门诊转入的病人信息,入院时使用</param>
        /// <param name="p_dtbResult">结果集</param>
        /// <returns></returns>
        public long m_lngGetPatientInHospitalInfo(string p_strInPatientID, int p_intFlag, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetPatientInHospitalInfo(objPrincipal, p_strInPatientID, p_intFlag, out p_dtbResult);

            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断收费项目是否有子项
        /// <summary>
        /// 判断收费项目是否有子项
        /// </summary>
        /// <param name="p_strChargeItem"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public bool m_blnCheckSubChargeItem(string p_strChargeItem, out DataTable dtRecord)
        {
            long lngRes = 0;
            bool blnRet = false;
            dtRecord = new DataTable();

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            try
            {
                lngRes = objSvc.m_lngGetSubChargeItem(p_strChargeItem, out dtRecord);
                if (lngRes > 0 && dtRecord.Rows.Count > 0)
                {
                    blnRet = true;
                }
            }
            catch
            {
                blnRet = false;
            }
            return blnRet;
        }
        #endregion

        #region 判断收费项目是否是子项目
        /// <summary>
        /// 判断收费项目是否是子项目
        /// </summary>		
        public bool m_blnIsSubChrgItem(string strSubChrgItem, string strChrgItem)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool lngRes = objSvc.m_blnIsSubChrgItem(strSubChrgItem, strChrgItem);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据病历号获取有效处方号
        /// <summary>
        /// 根据病历号获取有效处方号
        /// </summary>
        /// <param name="strCaseID"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public bool m_blnGetRecipeIDByCaseID(string strCaseID, out DataTable dtRecord)
        {
            long lngRes = 0;
            bool blnRet = false;
            dtRecord = new DataTable();

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            try
            {
                lngRes = objSvc.m_lngGetRecipeIDByCaseID(strCaseID, out dtRecord);
                if (lngRes > 0 && dtRecord.Rows.Count > 0)
                {
                    blnRet = true;
                }
            }
            catch
            {
                blnRet = false;
            }
            objSvc.Dispose();
            return blnRet;
        }
        #endregion

        #region 判断是否急诊
        /// <summary>
        /// 判断是否急诊
        /// </summary>
        /// <param name="strRegTypeID"></param>
        /// <returns></returns>
        public bool m_blnCheckRegEmer(string strRegTypeID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool lngRes = objSvc.m_blnCheckRegiterType(strRegTypeID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断处方是否已收费
        /// <summary>
        /// 判断处方是否已收费
        /// </summary>
        /// <param name="strRecID"></param>
        /// <returns></returns>
        public bool m_blnCheckRecipeChrg(string strRecID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool lngRes = objSvc.m_blnCheckRecipeChrg(strRecID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取医生工作站各状态参数
        /// <summary>
        /// 获取医生工作站各状态参数
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetWSParm(string strType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetWSParm(strType, out dt);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 过敏人员列表
        /// <summary>
        /// 过敏人员列表
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public long m_lngGetAllergiclist(out DataTable dtRecord, string DoctorID, string Status)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetAllergiclist(out dtRecord, DoctorID, Status);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 过敏信息更新确认
        /// <summary>
        /// 过敏信息更新确认
        /// </summary>
        /// <param name="PatientID"></param>
        /// <param name="RecipeID"></param>
        /// <param name="AllergicMed"></param>
        /// <param name="AllergicDesc"></param>
        /// <returns></returns>
        public long m_lngUpdateallergic(string PatientID, string RecipeID, string AllergicMed, string AllergicDesc)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngUpdateallergic(PatientID, RecipeID, AllergicMed, AllergicDesc);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据科室、预约时间获取门诊手术申请记录
        /// <summary>
        /// 根据科室、预约时间获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="bookingdate"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public long m_lngGetOPSApply(out DataTable dtRecord, string bookingdate, string deptid, int flag, int ischrg)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetOPSApply(out dtRecord, bookingdate, deptid, flag, ischrg);
            objSvc.Dispose();

            return ret;
        }
        /// <summary>
        /// 根据科室、预约时间获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="bookingdate"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public long m_lngGetOPSApply(out DataTable dtRecord, string bookingdate, string deptid, int flag, int ischrg, bool p_blnPstauts_int_2)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetOPSApply(out dtRecord, bookingdate, deptid, flag, ischrg, p_blnPstauts_int_2);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据申请单号获取门诊手术申请记录
        /// <summary>
        /// 根据申请单号获取门诊手术申请记录
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="applyid"></param>
        /// <returns></returns>
        public long m_lngGetOPSApply(out DataTable dtRecord, string applyid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetOPSApply(out dtRecord, applyid);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 确认门诊手术申请单
        /// <summary>
        /// 确认门诊手术申请单
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public long m_lngConfrimOPS(string applyid, string empid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngConfrimOPS(applyid, empid);
            objSvc.Dispose();

            return ret;
        }
        /// <summary>
        ///  确认门诊手术报告单
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="empid"></param>
        /// <returns></returns>
        public long m_lngConfrimOPSReport(string applyid, string empid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngConfrimOPSReport(applyid, empid);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 返回科室ID和科室名称数组
        /// <summary>
        /// 返回科室ID和科室名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strDeptArr"></param>
        /// <returns></returns>
        public long m_lngGetDeptArr(string p_strLike, out string[,] p_strDeptArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetDeptAreaByLike(p_strLike, out p_strDeptArr, "");
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据操作员工号获取ID、姓名和密码
        /// <summary>
        /// 根据操作员工号获取ID、姓名和密码
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="empno"></param>
        /// <returns></returns>
        public long m_lngGetempinfo(out DataTable dtRecord, string empno)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetempinfo(out dtRecord, empno);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 保存门诊手术记录信息
        /// <summary>
        /// 保存门诊手术记录信息
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="objops"></param>
        /// <returns></returns>
        public long m_lngSaveOPS(string applyid, clsOutops_VO objops)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngSaveOPS(applyid, objops);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据申请单号获取手术报告单信息
        /// <summary>
        /// 根据申请单号获取手术报告单信息
        /// </summary>
        /// <param name="applyid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetopsrecord(string applyid, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetopsrecord(applyid, out dtRecord);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 获取处方审核未通过的记录
        /// <summary>
        /// 获取处方审核未通过的记录
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetrecipeconfirmfall(string DoctorID, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetrecipeconfirmfall(DoctorID, out dtRecord);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 获取门诊手术报告单信息
        /// <summary>
        /// 获取门诊手术报告单信息
        /// </summary>
        /// <param name="SQLSelect"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetopsreports(string SQLSelect, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetopsreports(SQLSelect, out dtRecord);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 获取麻醉方式
        /// <summary>
        /// 获取麻醉方式
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetanaesthesiamode(out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetanaesthesiamode(out dtRecord);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 模糊查找员工，返回员工ID和员工名称数组
        /// <summary>
        /// 模糊查找员工，返回员工ID和员工名称数组
        /// </summary>
        /// <param name="p_strLike"></param>
        /// <param name="p_strNameArr"></param>
        /// <returns></returns>
        public long m_lngGetEmployeeNameByLike(string p_strLike, out string[,] p_strNameArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetEmployeeNameByLike(p_strLike, out p_strNameArr);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据收费ID判断是否属于手术费用
        /// <summary>
        /// 根据收费ID判断是否属于手术费用
        /// </summary>
        /// <param name="chrgitemcode"></param>
        /// <returns></returns>
        public bool m_blnChkopsitem(string chrgitemcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool ret = objSvc.m_blnChkopsitem(chrgitemcode);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 根据条件获取手术申请单信息
        /// <summary>
        /// 根据条件获取手术申请单信息
        /// </summary>
        /// <returns></returns>
        public long m_lngGetApplyOPInfoByOrCondition(string p_strOr, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetApplyOPInfoByOrCondition(p_strOr, out dtRecord);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 更新手术申请单信息预约时间
        /// <summary>
        /// 更新手术申请单信息预约时间
        /// </summary>
        /// <returns></returns>
        public long m_lngGetApplyOPInfoUpdateDate(string p_strAPPLYID_VCHR, string p_strOPSBOOKINGDATE_DAT)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetApplyOPInfoUpdateDate(p_strAPPLYID_VCHR, p_strOPSBOOKINGDATE_DAT);
            return ret;
        }
        #endregion

        #region 根据操作员ID获取毒、麻药权限
        /// <summary>
        /// 根据操作员ID获取毒、麻药权限
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="neurpur"></param>
        /// <param name="drugpur"></param>
        public void m_mthGetmedpurview(string empid, out string neurpur, out string drugpur, out string recpur)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                    (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            objSvc.m_mthGetmedpurview(empid, out neurpur, out drugpur, out recpur);
        }
        #endregion

        #region 根据收费项目判断是否为片剂
        /// <summary>
        /// 根据收费项目判断是否为片剂
        /// </summary>
        /// <param name="chrgitemid"></param>
        /// <returns></returns>
        public bool m_blnCheckmedicament(string chrgitemid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool b = objSvc.m_blnCheckmedicament(chrgitemid);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 设置初始化模板数据
        /// <summary>
        /// 设置初始化模板数据
        /// </summary>
        /// <returns></returns>
        public long m_lngSetModeByItem(string p_strFormName, string p_strFormDesc, string p_strControlName, string p_strControlDesc)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long lngRes = objSvc.m_lngSetModeByItem(objPrincipal, p_strFormName, p_strFormDesc, p_strControlName, p_strControlDesc);

            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取药品毒性、麻醉、精神一、二类属性
        /// <summary>
        /// 获取药品毒性、麻醉、精神一、二类属性
        /// </summary>
        /// <param name="chrgitemid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetmedproperty(string chrgitemid, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetmedproperty(chrgitemid, out dtRecord);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 获取新系统参数
        /// <summary>
        /// 获取新系统参数
        /// </summary>
        /// <param name="parmcode">参数代码</param>
        /// <returns>参数值</returns>
        public string m_strGetSysparm(string parmcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            string ret = objSvc.m_strGetSysparm(parmcode);
            objSvc.Dispose();

            return ret;
        }
        /// <summary>
        /// 批量获取系统参数
        /// </summary>
        /// <param name="p_strParamKeyArr"></param>
        /// <param name="p_hasParamValue"></param>
        /// <returns></returns>
        public long m_lngGetSysparm(string[] p_strParamKeyArr, out Hashtable p_hasParamValue)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long lngRes = objSvc.m_lngGetSysparm(p_strParamKeyArr, out p_hasParamValue);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 批量获取系统功能设置
        /// </summary>
        /// <param name="p_strParamKeyArr"></param>
        /// <param name="p_hasParamValue"></param>
        /// <returns></returns>
        public long m_lngGetSysSetting(string[] p_strParamKeyArr, out Hashtable p_hasParamValue)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long lngRes = objSvc.m_lngGetSysSetting(p_strParamKeyArr, out p_hasParamValue);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region (医保)根据ICD10获取所对应的特种病代码
        /// <summary>
        /// (医保)根据ICD10获取所对应的特种病代码
        /// </summary>
        /// <param name="icd10_id"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetYBSpeciaTypeDiseaseByICD10(string icd10_id, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetYBSpeciaTypeDiseaseByICD10(icd10_id, out dt);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region (医保)根据特种病代码获取所对应的收费项目
        /// <summary>
        /// (医保)根据特种病代码获取所对应的收费项目
        /// </summary>
        /// <param name="deacode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetYBSpecChargeItemByDeacode(string deacode, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetYBSpecChargeItemByDeacode(deacode, out dt);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region (医保)获取特种病信息
        /// <summary>
        /// (医保)获取特种病信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetYBSpeciaTypeDisease(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetYBSpeciaTypeDisease(out dt);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region (医保)根据特种病代码获取所对应的ICD10
        /// <summary>
        /// (医保)根据特种病代码获取所对应的ICD10
        /// </summary>
        /// <param name="deacode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetICD10ByDeacode(string deacode, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long ret = objSvc.m_lngGetICD10ByDeacode(deacode, out dt);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 获取检验收费项目临床意思
        /// <summary>
        /// 获取检验收费项目临床意思
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>        
        public long m_lngGetLisItemClinicMeaning(string ItemID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetLisItemClinicMeaning(ItemID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 设置处方权
        /// <summary>
        /// 获取门诊开方医生列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetDoctorList(out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                               (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetDoctorList(out dt);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 保存医生权限定义表
        /// </summary>
        /// <param name="objArr"></param>
        /// <param name="Flag">1 新加 2 删除</param>
        /// <returns></returns>        
        public long m_lngSaveDoctorRecipePurview(ArrayList objArr, int Flag)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngSaveDoctorRecipePurview(objArr, Flag);
            objSvc.Dispose();

            return l;
        }

        /// <summary>
        /// 获取医生权限定义表
        /// </summary>
        /// <param name="objArr"></param>
        /// <returns></returns>        
        public long m_lngGetDoctorRecipePurview(string DoctID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetDoctorRecipePurview(DoctID, out dt);
            objSvc.Dispose();

            return l;
        }

        #endregion

        #region 查找处方-诊疗项目
        /// <summary>
        /// 查找处方-诊疗项目
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="OrderCat"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngFindRecipeOrderByID(string ID, ArrayList OrderCatArr, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngFindRecipeOrderByID(ID, OrderCatArr, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 根据诊疗项目获取收费项目
        /// <summary>
        /// 根据诊疗项目获取收费项目
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetChargeItemByOrderID(string OrderID, string PayTypeID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetChargeItemByOrderID(OrderID, PayTypeID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 判断诊疗项目(组合)是否允许打折
        /// <summary>
        /// 判断诊疗项目(组合)是否允许打折
        /// </summary>
        /// <param name="OrderID">诊疗项目ID</param>
        /// <param name="InvoCatArr">发票类型数组</param>
        /// <param name="SysType">系统 1 门诊 2 住院</param>
        /// <param name="ItemNums">项目个数</param>
        /// <returns></returns>        
        public bool m_blnCheckOrderDiscount(string OrderID, ArrayList InvoCatArr, int SysType, int ItemNums)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool b = objSvc.m_blnCheckOrderDiscount(OrderID, InvoCatArr, SysType, ItemNums);
            objSvc.Dispose();

            return b;
        }
        #endregion

        #region 查找协定处方
        /// <summary>
        /// 查找协定处方
        /// </summary>
        /// <param name="CreateEmpID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngFindAccordRecipe(string CreateEmpID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngFindAccordRecipe(CreateEmpID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 查询协定处方
        /// <summary>
        /// 查询协定处方
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <param name="ClassID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetAccordRecipe(string RecipeID, int ClassID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetAccordRecipe(RecipeID, ClassID, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 删除处方
        /// <summary>
        /// 删除处方
        /// </summary>
        /// <param name="RecipeID"></param> 
        public long m_lngDelAccordRecipe(string RecipeID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngDelAccordRecipe(RecipeID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 保存协定处方
        /// <summary>
        /// 保存协定处方
        /// </summary>
        /// <param name="AccordRecipe_VO"></param>
        /// <param name="objRecEntryArr"></param>
        /// <param name="RecipeID"></param>        
        public long m_lngSaveAccordRecipe(clsAccordRecipe_VO AccordRecipe_VO, ArrayList objRecEntryArr, out string RecipeID)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngSaveAccordRecipe(AccordRecipe_VO, objRecEntryArr, out RecipeID);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 综合查询收费项目
        /// <summary>
        /// 综合查询收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="Type">1 西药 2 中药 3 检验 4 检查 5 治疗 6 其他</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngFindChargeItem(string FindStr, int Type, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngFindChargeItem(FindStr, Type, out dt);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 系统内部申请单分类
        /// <summary>
        /// 系统内部申请单分类
        /// </summary>
        /// <param name="objArr"></param>
        /// <returns></returns>
        public long m_lngGetAPPLY_RLT(out System.Collections.Generic.Dictionary<string, string> objArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetAPPLY_RLT(out objArr);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 批量获取比例
        /// <summary>
        /// 批量获取比例
        /// </summary>
        /// <param name="p_strPayTypeID"></param>
        /// <param name="p_strItemIDArr"></param>
        /// <param name="p_hasItemScale"></param>
        /// <returns></returns>
        public long m_lngGetItemScaleByArr(string p_strPayTypeID, string[] p_strItemIDArr, ref Hashtable p_hasItemScale)
        {

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetItemScaleByArr(p_strPayTypeID, p_strItemIDArr, ref p_hasItemScale);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取处方主表信息
        /// <summary>
        /// 获取处方主表信息
        /// </summary>
        /// <param name="p_strRecipeID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetRecipeMainInfo(string p_strRecipeID, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetRecipeMainInfo(p_strRecipeID, out p_dtResult);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region
        public long m_lngGetRecipeCreateType(ref int p_createtype, string p_strRecipeNO)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                                         (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long l = objSvc.m_lngGetRecipeCreateType(ref p_createtype, p_strRecipeNO);
            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 获取指定卡号的医保病人欠费信息
        /// <summary>
        /// 获取指定卡号的医保病人欠费信息
        /// </summary>
        /// <param name="p_strCard"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetVipDebtByCard(string p_strCard, out DataTable p_dtResult)
        {
            clsDoctorWorkStationSvc objSvc = (clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDoctorWorkStationSvc));
            long l = objSvc.m_lngGetVipDebtByCard(p_strCard, out p_dtResult);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 判断是某个药品的药品类型是否在9003中
        /// <summary>
        /// 判断是某个药品的药品类型是否在9003中
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool blMedicine9003(string p_strMedID)
        {
            bool blMedicine = false;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            blMedicine = objSvc.blMedicine9003(p_strMedID);
            objSvc.Dispose();
            return blMedicine;
        }
        #endregion

        #region 获取体重
        /// <summary>
        /// 获取体重
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string GetPatientWeight(string pid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            return svc.GetPatientWeight(pid);
        }
        #endregion

        #region 更新体重
        /// <summary>
        /// 更新体重
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="weight"></param>
        public void UpdatePatientWeight(string pid, string weight)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc =
                                                 (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            svc.UpdatePatientWeight(pid, weight);
            svc = null;
        }
        #endregion

        #region 获取易制毒药品
        /// <summary>
        /// 获取易制毒药品
        /// </summary>
        /// <returns></returns>
        public DataTable GetProduceDrugs()
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)))
            {
                return svc.GetProduceDrugs();
            }
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
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.IsWechatBanding(cardNo);
            }
        }
        #endregion

        #region 药品库存判断
        /// <summary>
        /// 药品库存判断
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public bool IsHaveDrugStock(string itemId, string storeId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.IsHaveDrugStock(itemId, storeId);
            }
        }
        #endregion

        #region 东莞市预约平台.判断是否有预约记录
        /// <summary>
        /// 东莞市预约平台.判断是否有预约记录
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="regDate"></param>
        /// <param name="psOrderNum"></param>
        /// <returns></returns>
        public bool IsWechatPlatformBooking(string cardNo, string regDate, string recipeId, out decimal bookingNo, out string psOrderNum, out string doctCode)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)))
            {
                return svc.IsWechatPlatformBooking(cardNo, regDate, recipeId, out bookingNo, out psOrderNum, out doctCode);
            }
        }
        #endregion

        #region 科室编码
        /// <summary>
        /// 科室编码
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public string GetDeptCode(string deptId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.GetDeptCode(deptId);
            }
        }
        #endregion

        #region 当日号源更新
        /// <summary>
        /// 当日号源更新
        /// </summary>
        /// <param name="doctId"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public bool UpdateTodayPlatformRecipe(string doctId, string recipeId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)))
            {
                return svc.UpdateTodayPlatformRecipe(doctId, recipeId);
            }
        }
        #endregion

        #region 获取现场号使用处方信息
        /// <summary>
        /// 获取现场号使用处方信息
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public DataTable GetTodayRegInfo(string recipeId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.GetTodayRegInfo(recipeId);
            }
        }
        #endregion

        #region 当日号源更新发送时间
        /// <summary>
        /// 当日号源更新发送时间
        /// </summary>
        /// <param name="serNo"></param>
        /// <returns></returns>
        public bool UpdateTodayPlatformSendDate(decimal serNo)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)))
            {
                return svc.UpdateTodayPlatformSendDate(serNo);
            }
        }
        #endregion

        #region 判断处方里是否只包含饮片,否则不允许代煎
        /// <summary>
        /// 判断处方里是否只包含饮片,否则不允许代煎
        /// </summary>
        /// <param name="lstChargeItemId"></param>
        /// <returns></returns>
        public bool CheckRecipeSlices(List<string> lstChargeItemId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.CheckRecipeSlices(lstChargeItemId);
            }
        }
        #endregion

        #region 患者代煎药收件信息
        /// <summary>
        /// 患者代煎药收件信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public DataTable GetPatientContactInfo(string patientId)
        {
            using (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc svc = (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStation_SupportedSvc)))
            {
                return svc.GetPatientContactInfo(patientId);
            }
        }
        #endregion

    }
}
